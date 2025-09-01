using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace f1.pos
{
    public partial class frm_note : DevExpress.XtraEditors.XtraForm
    {
        public frm_note()
        {
            InitializeComponent();
        }

        private void frm_note_Load(object sender, EventArgs e)
        {
            this.dt_piker.Text = DateTime.Now.ToString("yyyy/MM/dd");
            Load_dgv_();


        }
        private void  Load_dgv_()
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("select id_ware,code_items,(select name_items from items where code_items=wares_overdraft.code_items)as name,qty,shift_no from wares_overdraft ", dt);
            dgv.DataSource = dt;
            
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //1-cheak if overdraft.qty > wares.qty update ware and delete from wares_overdraft 
            //2-insert entry  COGS

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                double qty_over_draft = Convert.ToDouble(db.GetData("select isnull(sum(qty),0) from wares_overdraft where code_items ='" + dgv.Rows[i].Cells["code_items"].Value+"' and id_ware='"+dgv.Rows[i].Cells["id_ware"].Value+"'").Rows[0][0]+"");
                double qty_wares = Convert.ToDouble(db.GetData("select isnull(sum(qty),0) from wares where code_items ='" + dgv.Rows[i].Cells["code_items"].Value + "' and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'").Rows[0][0] + "");
                double net_qty = qty_over_draft + qty_wares;
                if (net_qty >=0)
                {
                    //insert
                    //_______________________
                    //insert entry_hd
                    //string code_book = db.GetData("select code_book from pos_cash_account where user_code='" + v.usercode + "' ").Rows[0][0].ToString();

                    string o_s = dgv.Rows[i].Cells["shift_no"].Value + "";
                    string wares = dgv.Rows[i].Cells["id_ware"].Value + "";

                    string emp = db.GetData("select isnull(max(emp_code),0) from pos_shift where shift_no='"+ o_s + "'").Rows[0][0] + "";
                    string code_book = db.GetData("select isnull(max(code_book),0) from pos_cash_account where user_code='"+emp+"'").Rows[0][0] + "";
                    string cogs = db.GetData("select isnull(max(cogs),0) from pos_cash_account where user_code='" + emp + "'").Rows[0][0] + "";
                    string wares_gl = db.GetData("select rootid from wares_acc where id_ware='" +wares + "' and acc_id='1'").Rows[0][0].ToString();

                    string code_entry_dt = db.GetData("select (max(convert(int,(right( CODE_ENTRY , len(CODE_ENTRY)-3)))))+1 from entry WHERE code_book='" + code_book + "'").Rows[0][0].ToString();
                    string code_entry_hd = db.GetData("select (max(convert(int,(right( CODE_ENTRY , len(CODE_ENTRY)-3)))))+1 from entry_hd WHERE code_book='" + code_book + "'").Rows[0][0].ToString();

                    if (code_entry_dt != code_entry_hd)
                    {
                        string error_code = db.GetData("select (max(convert(int,(right( CODE_ENTRY , len(CODE_ENTRY)-3))))) from entry_hd WHERE code_book='" + code_book + "'").Rows[0][0].ToString();
                        db.Run("delete from entry_hd where code_entry ='" + code_book + error_code + "'");
                    }
                    string text_code = code_book + code_entry_dt;
                    string code_entry = text_code;
                    db.Run("insert into entry_hd ([code_entry],code_book) values ('" + text_code + "','" + code_book + "')");
                    //entry
                    //___________
                    //2)COGS
                    //__________________________________
                    DataTable dt_cogs = new DataTable();
                    //db.GetData_DGV("select p.code_items,isnull(sum(p.qty* f_unite),0),isnull((c.cost*p.qty),0) as cost ,isnull((c.qty),0) from pos_dt p left join wares c on p.code_items=c.code_items where shift_no='" + o_s + "' and p.id_ware='" + wares + "' and p.state='sal' group by p.code_items, p.name_items, c.cost,c.qty,p.qty", dt_cogs);
                    db.GetData_DGV("select p.code_items,isnull(sum(p.qty),0),isnull((c.cost*p.qty),0) as cost ,isnull((c.qty),0) from wares_overdraft p left join wares c on p.code_items=c.code_items where shift_no='"+o_s+"' and p.id_ware='"+wares+"'  group by p.code_items, p.name_items, c.cost,c.qty,p.qty", dt_cogs);

                    //select p.code_items,isnull(sum(p.qty),0),isnull((c.cost*p.qty),0) as cost ,isnull((c.qty),0) from wares_overdraft p left join wares c on p.code_items=c.code_items where shift_no='68' and p.id_ware='10'  group by p.code_items, p.name_items, c.cost,c.qty,p.qty
                    double tot_cogs = 0;
                  
                    for (int ii = 0; ii < dt_cogs.Rows.Count; ii++)
                    {
                        tot_cogs += Convert.ToDouble(dt_cogs.Rows[ii][2] + "");
                        //update qty in wares
                        // mins war qty - pos
                        double new_qty = (Convert.ToDouble(dt_cogs.Rows[ii][3])) + (Convert.ToDouble(dt_cogs.Rows[ii][1]));
                        //insert qty + in wares and make entry <<< <<< insert qty - in item draft
                        if (new_qty >= 0)
                        {
                            db.Run("update wares set qty ='" + new_qty + "' where code_items='" + dt_cogs.Rows[ii][0] + "" + "'and id_ware='" + wares + "'");


                            //insert into itesm trans
                            // db.Run()

                            if (tot_cogs != 0)
                            {
                                db.Run("insert into entry(  [code_entry]                           ,    acc_num             ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                               ,   sort                                                            , type_acc                                                       ,             depit                                                             ,                credit                 ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext )values('" +

                                                   code_entry + "'                           ,'" + cogs + "'     ,(select top 1 rootname from tree where rootid='" + cogs + "')               ,  (select top 1 RootLevel from tree where rootid='" + cogs + "')    ,  (select top 1 rootlevel_name from entry where acc_num='" + cogs + "'), (select top 1 sort from entry where acc_num='" + cogs + "')       ,  (select top 1 type_acc from entry where acc_num='" + cogs + "')   ,'" + Convert.ToDecimal(tot_cogs*-1) + "'  ,'0', 'POS','" + code_book + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + o_s + "','POS','COGS','POS ')");
                                db.Run("insert into entry(  [code_entry]                           ,    acc_num             ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                               ,   sort                                                            , type_acc                                                       ,             depit                                                             ,                credit                 ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext )values('" +

                                                                        code_entry + "'                           ,'" + wares_gl + "'     ,(select top 1 rootname from tree where rootid='" + wares_gl + "')               ,  (select top 1 RootLevel from tree where rootid='" + wares_gl + "')    ,  (select top 1 rootlevel_name from entry where acc_num='" + wares_gl + "'), (select top 1 sort from entry where acc_num='" + wares_gl + "')       ,  (select top 1 type_acc from entry where acc_num='" + wares_gl + "')  ,  '0' ,'" + Convert.ToDecimal(tot_cogs*-1) + "'  , 'POS','" + code_book + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + o_s + "','POS','COGS','POS ')");

                            }
                        }
                        //////////////else  //wares_overdraft
                        //////////////{
                        //////////////    db.Run("INSERT INTO [wares_overdraft]([id_ware],[code_items],[qty],[shift_no])values('" + wares + "','" + dt_cogs.Rows[i][0] + "" + "','" + new_qty + "','" + o_s + "')");
                        //////////////}
                    }

                    //delete from over_darft
                    db.Run("delete from wares_overdraft where code_items='" + dgv.Rows[i].Cells["code_items"].Value+"" + "' and shift_no ='"+o_s+"'");
                   
                }
               
            }
            XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "يجب ان تختفي الاصناف السالبة واذا لم تختتفي فيجب عمل جرد او عمل فاتورة مشتريات لها !!؟؟؟؟ ", "رسال معالجة سندات", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Load_dgv_();

        }

        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv, "no"); 
        }
    }
}