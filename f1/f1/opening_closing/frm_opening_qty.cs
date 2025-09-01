using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace f1.opening_closing
{
    public partial class frm_opening_qty : DevExpress.XtraEditors.XtraForm
    {
        public frm_opening_qty()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
            db.Open();
        }

        private void frm_opening_qty_Load(object sender, EventArgs e)
        {
            int year = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
            dt_piker.MinDate = new DateTime(year, 01, 01);
            dt_piker.MaxDate = new DateTime(year, 12, 31);
            all_comb.load_wares(combo_wars);
            progressBar1.Visible = false;
            dt_piker.Text = DateTime.Now.ToString("yyyy/MM/dd");
        }
        //function----------------------------------------------
        string code_items_a, name_items_a, cost_, qty_,exp_t_or_f;//combo_add_items_SelectedIndexChanged
        private void add_items_in_property_comboadd_items(string find_fild, string code_items)
        {
            try
            {
                code_items_a = db.GetData("select code_items from wares where " + find_fild + "='" + code_items + "'").Rows[0][0].ToString();
            name_items_a = db.GetData("select name_items from wares where " + find_fild + "='" + code_items + "'").Rows[0][0].ToString();
            cost_ = db.GetData("select cost from wares where " + find_fild + "='" + code_items + "'").Rows[0][0].ToString();
            qty_ = db.GetData("select qty from wares where " + find_fild + "='" + code_items + "'").Rows[0][0].ToString();
            exp_t_or_f = db.GetData("select exp from items where " + find_fild + "='" + code_items + "'").Rows[0][0].ToString();
            }
            catch (Exception)
            {
                
                
            }
        }
        private void add_in_dgv()
        {

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (combo_add_items.Text == dgv.Rows[i].Cells[2].Value.ToString())
                {
                    MessageBox.Show("douple");
                    return;
                }
            }
            dgv.Rows.Add(0, code_items_a, name_items_a, cost_,qty_,0,exp_t_or_f);
        }
        private void calc()
        {

            //   try
            {
                if (dgv.Rows.Count > 0)
                {
                    decimal _tot= 0;
                    dgv.CurrentRow.Cells["tot"].Value = (Convert.ToDouble(dgv.CurrentRow.Cells["qty"].Value) * Convert.ToDouble(dgv.CurrentRow.Cells["cost"].Value));
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        _tot += Convert.ToDecimal(dgv.Rows[i].Cells["tot"].Value);
                    }

                    lbl_tot.Text = _tot + "";
                }
            }
            // catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }
        private void insert()
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                
                // inser into items(qty + cost)  opening balance 
                db.Run("insert into opening_qty(acc_wares ,name_wares,id_ware,code_items,name_items,qty,cost,tot) values ('" + lbl_acc_wares.Text + "','" + lbl_acc_wares_name.Text + "','" + combo_wars.Text + "','" + dgv.Rows[i].Cells["code_items"].Value.ToString() + "','" + dgv.Rows[i].Cells["name_items"].Value.ToString() + "','" + dgv.Rows[i].Cells["cost"].Value.ToString() + "','" + dgv.Rows[i].Cells["qty"].Value.ToString() + "','" + dgv.Rows[i].Cells["tot"].Value.ToString() + "')");

                //update wares
                db.Run("update wares set qty='" + dgv.Rows[i].Cells["qty"].Value.ToString() + "' , cost='" + dgv.Rows[i].Cells["cost"].Value.ToString() + "' where id_ware='" + combo_wars.Text + "' and code_items='" + dgv.Rows[i].Cells["code_items"].Value.ToString() + "'");

                //insert into items_trans
                db.Run("insert into items_trans (code_items,name_items,opening_qty,qty,attachbook,attachtext,dates,old_cost,id_ware)values('" + dgv.Rows[i].Cells["code_items"].Value.ToString() + "','" + dgv.Rows[i].Cells["name_items"].Value.ToString() + "','" + dgv.Rows[i].Cells["qty"].Value.ToString() + "','" + dgv.Rows[i].Cells["qty"].Value.ToString() + "','ope','Opening QTY','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + dgv.Rows[i].Cells["cost"].Value.ToString() + "','" + combo_wars.Text + "')");
            }
            // insert into  Entry opening total qty and cost (Total)        in entre in -3 

                db.Run("insert into entry(  [code_entry]                           ,    acc_num                                                   ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name          ,   sort                                                                 , type_acc                                                                ,             depit                      ,    credit   ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook          ,              attachtext )values('" +
                                                -3 + "                            ','" + lbl_acc_wares.Text + "'                                  ,'" + lbl_acc_wares_name.Text + "'                                          ,  (select rootlevel from tree where rootid='" + lbl_acc_wares.Text + "') ,  0                , (1)                                                                  ,  (select sort from tree where rootid='" + lbl_acc_wares.Text + "')  ,     '" + Convert.ToDecimal(lbl_tot.Text) + "'   , '0',     'opening qty'           ,'ope'                                    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "'    ,' ope'                ,'ope'                    ,'ope-3'                  ,'system adjiustment opening qty ')");
                db.Run("update info_co set open_qty='True'");
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "saving ", "save", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void qty_wares_with_qty_exp()
        {
            //insert into trash to get equation
            for (int i = 0; i < dgv_Exp_qty.Rows.Count; i++)
            {
                db.Run("insert into trash_adj_exp (code_items,plues_wares)values('" + dgv_Exp_qty.Rows[i].Cells[1].Value.ToString() + "','" + dgv_Exp_qty.Rows[i].Cells["qty_c"].Value.ToString() + "')");
            }
            for (int i = 0; i < dgv_exp.Rows.Count; i++)
            {
                db.Run("insert into trash_adj_exp (code_items,plues_exp)values('" + dgv_exp.Rows[i].Cells[1].Value.ToString() + "','" + dgv_exp.Rows[i].Cells["plues_exp"].Value.ToString() + "')");
            }
            //test qty wares == qty exp
            DataTable dt = new DataTable();
            db.GetData_DGV("select  code_items ,sum(plues_wares) as plues_wares,SUM(plues_exp) as plues_exp ,(sum(plues_wares) ) - (SUM(plues_exp))as def   from trash_adj_exp group by code_items", dt);
            dgv_r.DataSource = dt;
            decimal def_s = 0;

            for (int i = 0; i < dgv_r.Rows.Count; i++)
            {
                def_s += Convert.ToDecimal(dgv_r.Rows[i].Cells["def"].Value);
            }
            lbl_def.Text = def_s + "";
            if ((def_s ) != 0)
            {
                MessageBox.Show(" رصيد الصلاحيات غير متوافق مع المخزون", "فشل الاختبار ");
                db.Run("DELETE FROM [trash_adj_exp]");
                return;
            }
            else
            {
                db.Run("DELETE FROM [trash_adj_exp]");
                db.Run("update info_co set stop_entry='True'");
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "تم الاختبار بنجاح ", "test", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        private void is_exp_or_not_and_move_to_screen_exp()
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgv.Rows[i].Cells["exp_c"].Value.ToString() )== true)
                {
                   // MessageBox.Show("Test");
                    dgv_Exp_qty.Rows.Add(dgv.Rows[i].Cells[0].Value.ToString(), dgv.Rows[i].Cells[1].Value.ToString(), dgv.Rows[i].Cells[2].Value.ToString(), dgv.Rows[i].Cells[3].Value.ToString(), dgv.Rows[i].Cells[4].Value.ToString());
                }
                
            }
        }
      //  ---------------------------------------------------------

        private void btn_add_all_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("select wares.code_items,wares.name_items,wares.cost,wares.qty from wares left join items on wares.code_items=items.code_items  where id_ware='" + combo_wars.Text + "' and [exp]=0 ", dt);
            dgv.DataSource = dt;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].Cells["qty"].Value = 0;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            add_in_dgv();
        }

        private void combo_add_items_Click(object sender, EventArgs e)
        {
            if (combo_add_items.Text == "")
            {
                all_comb.load_name_items_exp_and_normal(combo_add_items);

            }
        }

        private void txt_barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    add_items_in_property_comboadd_items("code_items", txt_barcode.Text);
                    add_in_dgv();
                    txt_barcode.Clear();
                    txt_barcode.Select();
                }
                catch (Exception)
                {

                }
            }
        }

        private void combo_add_items_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                add_in_dgv();
            }
        }

        private void combo_add_items_SelectedIndexChanged(object sender, EventArgs e)
        {
            add_items_in_property_comboadd_items("name_items", combo_add_items.Text);

        }

        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            calc();
        }

        private void combo_wars_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_acc_wares.Text = db.GetData("select rootid from wares_acc where id_ware='"+combo_wars.Text+"'").Rows[0][0].ToString();
            lbl_acc_wares_name.Text = db.GetData("select rootname from wares_acc where id_ware='" + combo_wars.Text + "'").Rows[0][0].ToString();

        }

        private void save_barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            is_exp_or_not_and_move_to_screen_exp();
            insert();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void test_btn_Click(object sender, EventArgs e)
        {
            qty_wares_with_qty_exp();
        }

       

        private void dgv_exp_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgv_exp.CurrentRow.Cells["net_qty_e"].Value = Convert.ToDouble(dgv_exp.CurrentRow.Cells["plues_exp"].Value) ;

        }

     

        private void dgv_Exp_qty_Click(object sender, EventArgs e)
        {
            if (dgv_Exp_qty.Rows.Count > 0)
            {
                 dgv_exp.Rows.Add(dgv_Exp_qty.CurrentRow.Cells[0].Value.ToString(),dgv_Exp_qty.CurrentRow.Cells[1].Value.ToString(), dgv_Exp_qty.CurrentRow.Cells[2].Value.ToString(), dgv_Exp_qty.CurrentRow.Cells[3].Value.ToString());

            }
        }

        private void btn_add_exp_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_exp.CurrentRow.Cells["exp_date"].Value = dt_exp.Value;

            }
            catch (Exception ex)
            {
                MessageBox.Show("حدد السطر في شاشه الصلاحيات ");
                return;
            }
        }

        private void dgv_exp_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv_exp, "no_ex");
        }

        //delete items
        private void btn_get_delete_opeining_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                db.GetData_DGV("select code_items,name_items,qty,opening_qty,id_ware from items_trans where opening_qty>0", dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgv_d.Rows.Add("", dt.Rows[i][0] + "", dt.Rows[i][1] + "", dt.Rows[i][2] + "", dt.Rows[i][3] + "", dt.Rows[i][4] + "");

                }
            }
            catch (Exception)
            {

            }
        }
        private void btn_get_delete_delete_Click(object sender, EventArgs e)
        {
           // delete();
        }


        //get item code opeining balance from items_trans 
        //select select * from items_trans where opening_qty>0
        int prog = 0;
        //private void delete()
        //{
        //    DialogResult dr;
        //    dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, " هل تريد حذف السند!!؟؟؟؟ ", "رسال حذف مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        //    if (dr == DialogResult.OK)
        //    {
        //        //============>>>
        //        Decimal qty_old, qty_current, qty_new;
        //        //  Decimal qty_old_exp, qty_current_exp, qty_current1_exp, qty_new_exp;
        //        progressBar1.Visible = true;
        //        prog = dgv_d.Rows.Count;//to know progras bar 
        //        for (int i = 0; i < dgv_d.Rows.Count; i++)
        //        {
        //            if (dgv_d.Rows[i].Cells["type"].Value.ToString() != "2")
        //            {
        //                qty_old = Convert.ToDecimal(db.GetData("select qty from wares where code_items='" + dgv_d.Rows[i].Cells["code_items"].Value + "'and id_ware='" + dgv_d.Rows[i].Cells["id_ware"].Value + "'").Rows[0][0]);
        //                qty_current = (Convert.ToDecimal(dgv_d.Rows[i].Cells["qty"].Value)) * (Convert.ToDecimal(dgv_d.Rows[i].Cells["f_unite"].Value));
        //                qty_new = qty_old - qty_current;
        //                if (qty_new < 0)
        //                {
        //                    XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "لايوجد  رصيد من الصنف  والفتوره مغلقه ويجب توريد او مسح فاتوره مبيعات  " + "  Codeitems=" + dgv_d.Rows[i].Cells["code_items"].Value + "", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //                    return;
        //                }

        //                //delete from wares update:-
        //                decimal total_cost = Convert.ToDecimal(db.GetData("select sum(tot_after_dis_forex) from purchase_dt where  code_items='" + dgv_d.Rows[i].Cells["code_items"].Value + "' and id_ware='" + dgv_d.Rows[i].Cells["id_ware"].Value + "'").Rows[0][0]);
        //                decimal total_specfic = Convert.ToDecimal(db.GetData("select sum(tot_after_dis_forex) from purchase_dt where code_items='" + dgv_d.Rows[i].Cells["code_items"].Value + "' and  purchase_hd_id='" + txt_serial_string.Text + "'and code_book='" + txt_code_book.Text + "' and id_ware='" + dgv_d.Rows[i].Cells["id_ware"].Value + "'").Rows[0][0]);
        //                decimal qty_purchase_tot = Convert.ToDecimal(db.GetData("select sum(qty*f_unite) from purchase_dt where  code_items='" + dgv_d.Rows[i].Cells["code_items"].Value + "' and id_ware='" + dgv_d.Rows[i].Cells["id_ware"].Value + "'").Rows[0][0]);
        //                decimal qty_purchase_specific = Convert.ToDecimal(db.GetData("select sum(qty*f_unite) from purchase_dt where code_items='" + dgv_d.Rows[i].Cells["code_items"].Value + "' and  purchase_hd_id='" + txt_serial_string.Text + "'and code_book='" + txt_code_book.Text + "' and id_ware='" + dgv_d.Rows[i].Cells["id_ware"].Value + "'").Rows[0][0]);
        //                decimal new_total_cost = 0;
        //                decimal cost = 0;
        //                qty_new = (qty_old - qty_current);
        //                new_total_cost = (total_cost - total_specfic);
        //                if (qty_new > 0)
        //                {
        //                    if ((qty_purchase_tot - qty_purchase_specific) == 0)
        //                    {
        //                        cost = 0;
        //                    }
        //                    else
        //                    {
        //                        cost = (new_total_cost / (qty_purchase_tot - qty_purchase_specific));
        //                    }
        //                }
        //                db.Run("update wares set cost =" + cost + " where code_items='" + dgv_d.Rows[i].Cells["code_items"].Value + "'and id_ware='" + dgv_d.Rows[i].Cells["id_ware"].Value + "'");
        //                db.Run("update wares set qty =" + qty_new + " where code_items='" + dgv_d.Rows[i].Cells["code_items"].Value + "'and id_ware='" + dgv_d.Rows[i].Cells["id_ware"].Value + "'");

        //                //delete exp_Date
        //                if (dgv_d.Rows[i].Cells["exp"].Value.ToString() == "True")
        //                {
        //                    //delete from wares update:-
        //                   // db.Run("delete from exp_date where code_items='" + dgv_d.Rows[i].Cells["code_items"].Value + "' and id_ware='" + dgv_d.Rows[i].Cells["id_ware"].Value + "' and code='" + txt_serial_string.Text + "' and code_book='" + txt_code_book.Text + "'");
        //                }
        //            }

        //           // backgroundWorker1.ReportProgress(i);
        //        }
        //        progressBar1.Visible = false;
        //        //delte entry
        //      //  string code = db.GetData("select top 1 code_entry from entry where attachno='" + txt_serial_string.Text + "' ").Rows[0][0].ToString();
        //      //  db.Run("delete from entry_hd where code_entry='" + code + "' and code_book='" + txt_code_entry_type.Text + "'");
        //      //  db.Run("delete from entry where code_entry='" + code + "' and code_book='" + txt_code_entry_type.Text + "'");
        //        //--------->>>
        //      //  db.Run("delete from purchase_hd where purchase_hd_id='" + txt_serial_string.Text + "'");
        //      //  db.Run("delete from purchase_dt where purchase_hd_id='" + txt_serial_string.Text + "' and code_book='" + txt_code_book.Text + "'");

        //        //delete item_tran
        //        db.Run("delete from items_trans where opening_qty>0");
                            
        //        //============
        //        MessageBox.Show("delete");
        //      //  new_file();
        //    }
        //    else
        //    {
        //        return;
        //    }





        //}



    }
}