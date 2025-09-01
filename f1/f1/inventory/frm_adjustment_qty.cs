using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Text.RegularExpressions;

namespace f1
{
    public partial class frm_adjustment_qty : DevExpress.XtraEditors.XtraForm
    {
        public frm_adjustment_qty()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
            db.Open();
        }
        string code_entry, sort, rootlevel, rootlevel_name, sort_acc;
     

        private void frm_adjustment_qty_Load(object sender, EventArgs e)
        {
            lbl_wars.Text = v.code_Wares_adj_qty;
           
            cls_book.loadbook(comb_code_name, "سند جرد");
            cls_book.load_from_term(combo_type, "سند جرد");
            //dt_piker.MinDate = new DateTime(2021, 01, 01);
            //dt_piker.MaxDate = new DateTime(2021, 12, 31);

            dt_piker.Text = DateTime.Now.ToString( "yyyy/MM/dd");

            dt_piker.Text = DateTime.Now.ToString("yyyy/MM/dd");


            progressBar1.Visible = false;
            
        }
        //--------------Function
        private void calc()
        {

               try
            {
                if (dgv.Rows.Count > 0)
                {
                    //////////////  cala total =qty* price-des
                    decimal tot_depit = 0;
                    decimal tot_crdit = 0;
                    decimal _min = 0;
                    decimal _plues = 0;

                    dgv.CurrentRow.Cells["net_qty"].Value = (Convert.ToDouble(dgv.CurrentRow.Cells["new_qty"].Value) - Convert.ToDouble(dgv.CurrentRow.Cells["qty"].Value));
                    if ((Convert.ToDouble(dgv.CurrentRow.Cells["net_qty"].Value) < 0))
                    {
                        dgv.CurrentRow.Cells["min"].Value = (Convert.ToDouble(dgv.CurrentRow.Cells["net_qty"].Value) * Convert.ToDouble(-1));
                        dgv.CurrentRow.Cells["plues"].Value = 0;
                        dgv.CurrentRow.Cells["net_plues"].Value = (Convert.ToDouble(dgv.CurrentRow.Cells["min"].Value) * Convert.ToDouble(dgv.CurrentRow.Cells["cost"].Value));
                        dgv.CurrentRow.Cells["net_min"].Value = 0;


                    }
                    if ((Convert.ToDouble(dgv.CurrentRow.Cells["net_qty"].Value) > 0))
                    {
                        dgv.CurrentRow.Cells["plues"].Value = (Convert.ToDouble(dgv.CurrentRow.Cells["net_qty"].Value) * Convert.ToDouble(1));
                        dgv.CurrentRow.Cells["min"].Value = 0;
                        dgv.CurrentRow.Cells["net_min"].Value = (Convert.ToDouble(dgv.CurrentRow.Cells["plues"].Value) * Convert.ToDouble(dgv.CurrentRow.Cells["cost"].Value));
                        dgv.CurrentRow.Cells["net_plues"].Value = 0;

                    }
                    if (Convert.ToDouble(dgv.CurrentRow.Cells["new_qty"].Value) == Convert.ToDouble(dgv.CurrentRow.Cells["qty"].Value))
                    {
                        dgv.CurrentRow.Cells["min"].Value = 0;
                        dgv.CurrentRow.Cells["plues"].Value = 0;
                        dgv.CurrentRow.Cells["net_plues"].Value = 0;
                        dgv.CurrentRow.Cells["net_min"].Value = 0;
                    }
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        _min += Convert.ToDecimal(dgv.Rows[i].Cells["net_plues"].Value);
                        _plues += Convert.ToDecimal(dgv.Rows[i].Cells["net_min"].Value);
                    }

                    lbl_rev.Text = _min + "";
                    lbl_exp.Text = _plues + "";
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        private void select_type_entry()
        {
            dgv_term.Rows.Clear();

            //book loaded:-
            //cls_book.load_from_terms(comb_type);
            //=============insert in dgv term 
            string term_id, rootid, rootname, depit, credit;

            int count = Convert.ToInt32(db.GetData("select count(term_id) from term where term_id='" + combo_type.Text + "'").Rows[0][0].ToString());
            code_entry = (db.GetData("select code_entry from term where term_id='" + combo_type.Text + "'").Rows[0][0].ToString());
            string bookname_entry = (db.GetData("select bookname_entry from term where term_id='" + combo_type.Text + "'").Rows[0][0].ToString());
            int c = 0;
            while (c < count)
            {
                int i = c++;
                term_id = db.GetData("select term_id from term where term_id='" + combo_type.Text + "'").Rows[i][0].ToString();
                rootid = db.GetData("select rootid from term where term_id='" + combo_type.Text + "'").Rows[i][0].ToString();
                rootname = db.GetData("select rootname from term where term_id='" + combo_type.Text + "'").Rows[i][0].ToString();
                depit = db.GetData("select depit from term where term_id='" + combo_type.Text + "'").Rows[i][0].ToString();
                credit = db.GetData("select credit from term where term_id='" + combo_type.Text + "'").Rows[i][0].ToString();
                //==============================================

                if (rootname.Length > 52)//wares
                {
                    rootid = db.GetData("" + rootid + "" + lbl_wars.Text + "" + "").Rows[0][0].ToString();
                    rootname = db.GetData("" + rootname + "" + lbl_wars.Text + "" + "").Rows[0][0].ToString();
                    rootlevel = db.GetData("select rootlevel from tree where rootid='" + rootid + "'").Rows[0][0].ToString();
                    rootlevel_name = "0";
                    sort_acc = db.GetData("select sort from tree where rootid='" + rootid + "'").Rows[0][0].ToString();
                    sort = "1";
                }
               
                else //other (fixed account)
                {
                    rootlevel = db.GetData("select rootlevel from tree where rootid='" + rootid + "'").Rows[0][0].ToString();
                    rootlevel_name = "0";
                    sort_acc = db.GetData("select sort from tree where rootid='" + rootid + "'").Rows[0][0].ToString();
                    sort = "1";

                }
                //==================================================

                //========fill field tot or tot_bef or discount=======
                if (depit == "rev")
                {
                    depit = lbl_rev.Text;
                }
                else if (depit == "exp")
                {
                    depit = lbl_exp.Text;
                }
                else
                {
                    depit = "0";
                }
                if (credit == "rev")
                {
                    credit = lbl_rev.Text;
                }
                else if (credit == "exp")
                {
                    credit = lbl_exp.Text;
                }
                else
                {
                    credit = "0";
                }
                //=========================================================
                // dgv_term.Rows.Clear();
                dgv_term.Rows.Add(term_id, rootid, rootname, depit, credit, rootlevel, rootlevel_name, sort, sort_acc);


            }
            //============end of terms        
        }
        private void insert()
        {
            progressBar1.Visible = true ;

            //select entry
            select_type_entry();

            //get only number for one user Entry
            txt_entry_string.Text = txt_code_entry_type.Text + txt_code_entry.Text;
            cls_book.selectbook("entry_hd", "سند قيد", txt_code_entry_type.Text, txt_code_entry, "code_entry");
            txt_entry_string.Text = txt_code_entry_type.Text + txt_code_entry.Text;
            //get only number for one user purchase
            txt_code_book.Text = db.GetData("select code_book from book where name_book='" + comb_code_name.Text + "'").Rows[0][0].ToString();
            cls_book.selectbook("adj_qty_hd", "سند جرد", txt_code_book.Text, txt_serial, "adj_qty_hd_id");
            txt_serial_string.Text = txt_code_book.Text + txt_serial.Text;
//--------------------------------------------------------------------------------only one user 

            //>>>>>>>>>>>>>>>>>>>>>insert entry
            db.Run("insert into entry_hd ([code_entry],code_book) values ('" + txt_entry_string.Text + "','" + txt_code_entry_type.Text + "')");
            //entry_hd
            for (int z = 0; z < dgv_term.Rows.Count; z++)
            {
                db.Run("insert into entry(  [code_entry]                           ,    acc_num                                                   ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                                          ,                              type_acc                                 ,   sort                                                     ,             depit                                                             ,                credit                                                   ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext )values('" +
                     txt_entry_string.Text + "','" + dgv_term.Rows[z].Cells[1].Value.ToString() + "','" + dgv_term.Rows[z].Cells[2].Value.ToString() + "',  '" + dgv_term.Rows[z].Cells["rootlevel_"].Value.ToString() + "'    ,  '" + dgv_term.Rows[z].Cells["rootlevel_name_"].Value.ToString() + "', '" + dgv_term.Rows[z].Cells["type_acc_"].Value.ToString() + "'       ,  '" + dgv_term.Rows[z].Cells["sort_"].Value.ToString() + "'  ,  '" + Convert.ToDecimal(dgv_term.Rows[z].Cells[3].Value.ToString()) + "'      ,'" + Convert.ToDecimal(dgv_term.Rows[z].Cells[4].Value.ToString()) + "' ,'" + txt_name_book_type.Text + "','" + txt_code_entry_type.Text + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + txt_serial_string.Text + "','" + txt_code_book.Text + "','" + comb_code_name.Text + "','system adjiustment qty')");
            }
            //inser into  adj_qty_hd
            db.Run("insert into adj_qty_hd (adj_qty_hd_id,code_book,name_book,term,date_P,id_ware,code_entry,book_name_entry,code_book_entry,user_code,user_name) values ('" + txt_serial_string.Text + "','" + txt_code_book.Text + "','" + lbl_comb_code_name.Text + "','" + combo_type.Text + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + lbl_wars.Text + "','" + txt_entry_string.Text + "','" + txt_name_book_type.Text+ "','" + txt_code_entry_type.Text + "','"+lbl_user_code.Text+"','"+lbl_user_name.Text+"')");

            //update ware 
            prog = dgv.Rows.Count;
            progressBar1.Visible = true;
            
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
               db.Run("update wares set qty=" + dgv.Rows[i].Cells["new_qty"].Value + " where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware ='" + lbl_wars.Text + "'");



                db.Run("insert into items_trans (                        code_items,                                name_items,                                                                qty                                                                ,f_unite                                                      ,                        name_unite            ,exp_date                    ,id_ware                            ,attachno                      ,attachbook            ,attachnamebook                    ,vcs_code                           ,vcs_name      ,                 dates    ,attachtext   ) values ('" +

                                                  dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "','" + Convert.ToDecimal(dgv.Rows[i].Cells["net_qty"].Value) + "' ,'1',(select name_unite from items where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'),null,'" + lbl_wars.Text + "','" + txt_serial_string.Text + "','" + comb_code_name.Text + "','" + comb_code_name.Text + "','','','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','جرد مخزني')");


                backgroundWorker1.ReportProgress(i);
            }
            progressBar1.Visible = false;
            v.adj_complet = true;
            XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "adjustment successfully ", "adjustment", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
        string code_items_a, name_items_a, cost_, qty_;//combo_add_items_SelectedIndexChanged
        private void add_items_in_property_comboadd_items(string find_fild, string code_items)
        {
            code_items_a = db.GetData("select code_items from wares where " + find_fild + "='" + code_items + "'").Rows[0][0].ToString();
            name_items_a = db.GetData("select name_items from wares where " + find_fild + "='" + code_items + "'").Rows[0][0].ToString();
            cost_ = db.GetData("select cost from wares where " + find_fild + "='" + code_items + "'").Rows[0][0].ToString();
            qty_ = db.GetData("select qty from wares where " + find_fild + "='" + code_items + "'").Rows[0][0].ToString();
        }
        private void add_in_dgv()
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (combo_add_items.Text == dgv.Rows[i].Cells[2].Value.ToString())
                {
                    MessageBox.Show("الصنف متكرر");
                    return;
                }
            }
            dgv.Rows.Add(0, code_items_a, name_items_a, cost_, qty_);
        }

        //================Controls

        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           // MessageBox.Show("Test");
            calc();
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
        }
        private void combo_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_name_book_type.Text = db.GetData("select bookname_entry  from term  where term_id ='" + combo_type.Text + "'").Rows[0][0].ToString();
            txt_code_entry_type.Text = db.GetData("select code_entry  from term  where term_id ='" + combo_type.Text + "'").Rows[0][0].ToString();
            cls_book.selectbook("entry_hd", "سند قيد", txt_code_entry_type.Text, txt_code_entry, "code_entry");
        }
       

        private void comb_code_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_code_book.Text = db.GetData("select code_book from book where name_book='" + comb_code_name.Text + "'").Rows[0][0].ToString();
            cls_book.selectbook("adj_qty_hd", "سند جرد", txt_code_book.Text, txt_serial, "adj_qty_hd_id");
            txt_serial_string.Text = txt_code_book.Text + txt_serial.Text;
            lbl_comb_code_name.Text = comb_code_name.Text;
        }
        int prog = 0;
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Maximum = prog;
            progressBar1.Value = e.ProgressPercentage;
        }

        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           // calc();

            Classes.command.LoadSerial(dgv, "no");
        }

        private void dgv_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
           // calc();

            Classes.command.LoadSerial(dgv, "no");
        }

        private void btn_find_items_Click(object sender, EventArgs e)
        {
            all_comb.load_name_items_normal_only(combo_add_items);
            txt_barcode.Text = db.GetData("select code_items from items where name_items='" + combo_add_items.Text + "'").Rows[0][0].ToString();
            combo_add_items.Text = "";
            txt_barcode.Text = "";
        }

        private void save_barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dr;
            dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "سيتم تعديل في الكميات المخزن وسيتم عمل قيود محاسبيها بها هل موافق علي ذالك ولا يمكن عمل رجوع بعد ذالك الخطوه ؟ ", "رسال تعديل مستند تحذير", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                lbl_wars.Text = "10";
                insert();
            }
            else
            {
                return;
            }
        }

        
       
        private void btn_add_all_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("select wares.code_items,wares.name_items,wares.cost,wares.qty from wares left join items on wares.code_items=items.code_items  where id_ware='" + lbl_wars.Text + "' and [exp]=0 and wares.name_items like '%" + txt_barcode.Text + "%'", dt);
            dgv.DataSource = dt;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].Cells["new_qty"].Value = 0;
            }
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            
            add_in_dgv();
        }
      
        private void combo_add_items_Click(object sender, EventArgs e)
        {
            //if (combo_add_items.Text=="")
            //{
            //    all_comb.load_name_items_normal_only(combo_add_items);
            //    txt_barcode.Text = db.GetData("select code_items from items where name_items='"+combo_add_items.Text+"'").Rows[0][0].ToString();
                
            //}

        }
        private void combo_add_items_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                add_items_in_property_comboadd_items("name_items", combo_add_items.Text);
                txt_barcode.Text = db.GetData("select code_items from items where name_items='" + combo_add_items.Text + "'").Rows[0][0].ToString();
            }
            catch (Exception)
            {
            }
        }
        //hotkeys
        private void combo_add_items_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                add_in_dgv();
            }
        }
        private void txt_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {

                    
                    code_items_a = "";
                    string str1 = txt_barcode.Text;
                    str1 = Regex.Replace(str1, "[+]+", "").Remove(Regex.Replace(str1, "[+]+", "").Length - 1, 1);
                    code_items_a = str1;
                    code_items_a = db.GetData("select isnull(max(code_items),null) from items where code_items='" + str1 + "'").Rows[0][0].ToString();
                    if (code_items_a == "")
                        code_items_a = db.GetData("select isnull(max(code_items),null) from barcode where barcode='" + txt_barcode.Text + "'").Rows[0][0].ToString();
                    if (code_items_a == "")
                    {
                        XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "لايوجد صنف  ..يجب تكويد الصنف", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.txt_barcode.Clear();
                    }
                    else
                    {
                        for (int i = 0; i < dgv.Rows.Count; i++)
                        {
                            if (code_items_a == dgv.Rows[i].Cells["code_items"].Value.ToString())
                            {
                                MessageBox.Show("الصنف متكرر");
                                txt_barcode.Text = "";
                                return;

                            }
                        }
                        //=============
                        add_items_in_property_comboadd_items("code_items", code_items_a);
                        add_in_dgv();
                        txt_barcode.Clear();
                        txt_barcode.Select();

                        //lbl_code_items.Text = "1";
                        //this.add_items_in_dgv();
                        this.txt_barcode.Clear();
                        txt_barcode.Select();
                    }

                    //=================
                    //add_items_in_property_comboadd_items("code_items", txt_barcode.Text);
                    //add_in_dgv();
                    //txt_barcode.Clear();
                    //txt_barcode.Select();
                }
                catch (Exception)
                {

                }
            }
        }

      

       

       










        //===========
    }
}