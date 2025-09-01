using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using f1.Properties;
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
    public partial class rest_frm : DevExpress.XtraEditors.XtraForm
    {
        public rest_frm()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(v.ico);
            db.Open();
        }
        private bool credit = false;
        private bool gift = false;
        private bool visa = false;


        private void rest_frm_Load(object sender, EventArgs e)
        {

            if (rd_bavrage.Checked == true)
            {
                DataTable dt = new DataTable();
                db.GetData_DGV("select distinct cat1 from items where cat1 <> '' and menu_name = 'مشروبات'", dt);
                dgv1.DataSource = dt;
            }
            else
            {
                DataTable dt = new DataTable();
                db.GetData_DGV("select distinct cat1 from items where cat1 <> '' and menu_name <> 'مشروبات'", dt);
                dgv1.DataSource = dt;
            }
            rd_account.Checked = true;
            //DataTable dt = new DataTable();
            //db.GetData_DGV("select distinct cat1 from items where cat1 <>''", dt);
            //dgv1.DataSource = dt;
            DataTable dt2 = new DataTable();
            db.GetData_DGV("select code_items,name_items,price_sale from items where menu_name='إضافات'", dt2);
            dgv2.DataSource = dt2;

            DataTable dt3 = new DataTable();
            db.GetData_DGV("select name_items from items where menu_name='ملحوظات'", dt3);
            dgv3.DataSource = dt3;

            //----------------------------------------------
            dt_piker.Text = DateTime.Now.ToString(Convert.ToInt32(db.GetData("select period from info_co").Rows[0][0].ToString()) + "/MM/dd");
            lbl_user_code.Text = v.usercode;
            lbl_user_name.Text = v.username;
            if (db.GetData("select isnull(max(emp_code),0) from pos_shift where lock='1' and emp_code='" + v.usercode + "'").Rows[0][0].ToString() != v.usercode)
            {
                xtraTabControl1.Visible = false;
            }
            else
            {
                string shift_numer = db.GetData("select shift_no from pos_shift where lock='1' and emp_code='" + v.usercode + "' ").Rows[0][0].ToString();
                ++g;
                //lbl_invoice_number.Text = shift_numer + lbl_user_code.Text + DateTime.Now.ToString("HHmmss") + g + "";
                lbl_shift_no.Caption = shift_numer;

                Decimal cash_bal = Convert.ToDecimal(db.GetData("select isnull(sum(balance),0) from pos_cash where  shift_no='" + lbl_shift_no.Caption + "' and user_code='" + v.usercode + "' and code_cash='1'").Rows[0][0].ToString());
                Decimal visa_bal = Convert.ToDecimal(db.GetData("select isnull(sum(balance),0) from pos_cash where  shift_no='" + lbl_shift_no.Caption + "' and user_code='" + v.usercode + "' and code_cash='2'").Rows[0][0].ToString());
                //   lbl_cash_balance.Text = cash_bal + "";
                //  lbl_visa_bal.Text = visa_bal + "";
                //  txt_barcode.Select();

                //chk_bal_ware.Checked = Settings.Default.chk_bal_ware;
                //chk_search_lang.Checked = Settings.Default.chk_search_lang;
                //chk_sales.Checked = Settings.Default.chk_sales;
                //chk_no_taxes.Checked = Settings.Default.no_taxes;
                // btn_print_last.PerformClick();
                load_permission();
                 cash_balance();
            }
            combo_type.Text = "تيك اواي";

        }
        private void cash_balance()
        {
            lbl_cash_1.Text = db.GetData("select isnull(SUM(balance),0) from pos_cash where shift_no='" + lbl_shift_no.Caption + "'and code_cash='1' ").Rows[0][0].ToString();

        }
        private void load_permission()
        {
            //// lbl_over_draft.Text = db.GetData("select over_draft from info_co").Rows[0][0].ToString();
           // btn_inv_pending.Enabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='pind_inv'").Rows[0][0].ToString());
           // btn_pinding.Enabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='pind_inv'").Rows[0][0].ToString());
            btn_del_delete_invoice.Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='delet_inv'").Rows[0][0].ToString());
            page_delete.PageEnabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='delet_inv'").Rows[0][0].ToString());
            page_delete.PageEnabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='delet_inv'").Rows[0][0].ToString());
            page_expenses.PageEnabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='expensses'").Rows[0][0].ToString());

            btn_resale_2.Enabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='return_inv'").Rows[0][0].ToString());
           // return_inv_without_noinv = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='return_inv_without_noinv'").Rows[0][0].ToString());
            btn_add_customer.Enabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='vcs_code'").Rows[0][0].ToString());
           // chk_sales.Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='vcs_show'").Rows[0][0].ToString());
            dgv.Columns["price_inc_tax"].ReadOnly = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='sale_price'").Rows[0][0].ToString());
            dgv.Columns["item_price"].ReadOnly = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='sale_price'").Rows[0][0].ToString());
            dgv.Columns["discount"].ReadOnly = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='discount_rows'").Rows[0][0].ToString());
            txt_discount_all.ReadOnly = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='discount'").Rows[0][0].ToString());
            txt_pres_descount_all.ReadOnly = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='discount'").Rows[0][0].ToString());

           // blow_cost = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='blow_cost'").Rows[0][0].ToString());
            //page_expenses.PageEnabled = false;
            //page_delete.PageEnabled = false;

            //blow_cost >>>not complit
            //for (int i = 0; i < dgv.Rows.Count; i++)
            //{
            //    double cost = Convert.ToDouble(db.GetData("select isnull(max(cost),0) from wares where code_items='"+dgv.Rows[i].Cells["code_items"].Value+""+"'").Rows[0][0].ToString());
            //    if (Convert.ToDouble(dgv.Rows[i].Cells[0].Value + "") < cost) MessageBox.Show("لايمكن البيع تحت سعر التكلفة");
            //}

           // lbl_stat_cost_items_n.Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='state'").Rows[0][0].ToString());
           // lbl_stat_min_items_n.Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='state'").Rows[0][0].ToString());
           // lbl_stat_max_items_n.Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='state'").Rows[0][0].ToString());
           // lbl_state_vcs_bal_n.Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='state'").Rows[0][0].ToString());
           // lbl_cash_1.Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='cash'").Rows[0][0].ToString());
            //expiry
            dgv.Columns["exp_date"].Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='exp'").Rows[0][0].ToString());

            dgv.Columns["name_unite"].Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='c_unit'").Rows[0][0].ToString());
            dgv.Columns["item_price"].Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='c_price_no_taxes'").Rows[0][0].ToString());
            dgv.Columns["price_inc_tax"].Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='c_price_taxes'").Rows[0][0].ToString());
            dgv.Columns["tot_bef"].Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='c_tot_befor_discount'").Rows[0][0].ToString());
            dgv.Columns["discount"].Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='c_discount'").Rows[0][0].ToString());
            dgv.Columns["tot_after_dis"].Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='c_tot_after_discount'").Rows[0][0].ToString());
            dgv.Columns["taxes"].Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='c_taxes'").Rows[0][0].ToString());
            dgv.Columns["incloud_taxes"].Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='c_incloud_taxes'").Rows[0][0].ToString());


        }
        //====================function
        private decimal get_balance_cash()
        {
            decimal cash_table = Convert.ToDecimal(db.GetData("select isnull(sum(balance),0) from pos_cash where  shift_no='" + lbl_shift_no.Caption + "' and user_code='" + lbl_user_code.Text + "' and code_cash='1'").Rows[0][0].ToString());
            decimal open_cash = Convert.ToDecimal(db.GetData("select isnull(sum(bal_open),0) from pos_shift where lock=1 and shift_no='" + lbl_shift_no.Caption + "' and emp_code='" + lbl_user_code.Text + "'").Rows[0][0].ToString());
            decimal net_cash = 0;
            net_cash = open_cash + cash_table;
            return net_cash;
        }
        private decimal get_balance_visa()
        {
            decimal visa_table = Convert.ToDecimal(db.GetData("select isnull(sum(balance),0) from pos_cash where  shift_no='" + lbl_shift_no.Caption + "' and user_code='" + lbl_user_code.Text + "' and code_cash='2'").Rows[0][0].ToString());
            return visa_table;
        }
        private static string no_invoice_pending = "";
        private void clear()
        {

            dgv.Rows.Clear();
            //   dgv_search.Rows.Clear();

            lbl_discount.Text = "0";
            lbl_requer.Text = "0";
            lbl_tot.Text = "0";

            txt_calc.Text = "";
           // txt_search.Text = "";
           // txt_barcode.Text = "";
            txt_resale.Text = "";
            v.net_recev = 0;
            lbl_visa.Text = "0";
            lbl_cash.Text = "0";

            txt_cash.Text = "0";
            txt_visa.Text = "0";
            lbl_reqer_mony.Text = "0";
            lbl_remind.Text = "0";
            lbl_count_dgv.Text = "0";

            combo_code_vcs.Text = "";
            combo_name_vcs.Text = "";
            combo_phone_vcs.Text = "";
            lbl_vcs_address.Text = ",,,";
            num_table.Value = 0;
            txt_discount_all.Text = "";
            txt_pres_descount_all.Text = "";

            //clear 
            combo_RoomNO.Text = "";
            lbl_idkey.Text = "..";
            lbl_id_comapny.Text = "..";
            lbl_id_guest.Text = "..";
            lbl_name_guest.Text = "..";
            lbl_dateIn.Text = "..";
            lbl_dateOut.Text = "..";

            credit = false;
            gift = false;


        }
        int g = 0;
        private string generat_invoice_number()
        {
            string shift_numer, invoice_number;
            shift_numer = db.GetData("select shift_no from pos_shift where lock='1' ").Rows[0][0].ToString();
            ++g;
            invoice_number = shift_numer + lbl_user_code.Text + DateTime.Now.ToString("HHmmss") + g + "";

            return invoice_number;
        }
       
        private void dgv1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("select  name_items,price_sale,[desc],code_items from items where cat1='" + dgv1.CurrentRow.Cells[0].Value + "'", dt);
            dgv4.DataSource = dt;
        }
        private void simpleButton22_Click(object sender, EventArgs e)
        {

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_min_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;

        }

        private void dgv4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // MessageBox.Show(e.ColumnIndex+"");

            if (dgv4.Rows.Count == 0) return;
            if (e.ColumnIndex == 1)
            {
                string main_code = dgv4.CurrentRow.Cells["code_items_4"].Value + "";
                dgv.Rows.Add(null, main_code, dgv4.CurrentRow.Cells["name_items_4"].Value, db.GetData("select isnull(max(name_unite),0) from items where code_items='" + main_code + "'").Rows[0][0].ToString(), "1", db.GetData("select [exp] from items where code_items='" + main_code + "'").Rows[0][0].ToString(), db.GetData("select type from items where code_items='" + main_code + "'").Rows[0][0].ToString(), null, 0, numqty.Value, dgv4.CurrentRow.Cells["price_sale_4"].Value + "", 0, 0, 0, 0, db.GetData("select isnull(max(taxes),0) from items where code_items='" + main_code + "'").Rows[0][0].ToString(), 0, 0, lbl_wares.Text, 0);
                calc_all();
                numqty.Value = 1;

            }
        }
        private void dgv2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv2.Rows.Count == 0) return;
            if (e.ColumnIndex == 1)
            {
                string main_code = dgv2.CurrentRow.Cells["code_items_2"].Value + "";
                dgv.Rows.Add(null, main_code, dgv2.CurrentRow.Cells["name_items_2"].Value, db.GetData("select isnull(max(name_unite),0) from items where code_items='" + main_code + "'").Rows[0][0].ToString(), "1", db.GetData("select [exp] from items where code_items='" + main_code + "'").Rows[0][0].ToString(), db.GetData("select type from items where code_items='" + main_code + "'").Rows[0][0].ToString(), null, 0, numqty.Value, dgv2.CurrentRow.Cells["price_sale_2"].Value + "", 0, 0, 0, 0, db.GetData("select isnull(max(taxes),0) from items where code_items='" + main_code + "'").Rows[0][0].ToString(), 0, 0, lbl_wares.Text, 0);
                calc_all();
                numqty.Value = 1;

            }
        }
        private void dgv3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Rows.Count > 0)
            dgv.Rows.Add(null, 0, dgv3.CurrentRow.Cells["name_items_3"].Value,0, "1",0, 0, null, 0, 0, 0+ "", 0, 0, 0, 0, 0, 0, 0, 0, 0);

        }

        private void calc_all()
        {
            try
            {
                Decimal d1 = 0;
                Decimal num1 = 0;
                Decimal d2 = 0;
                Decimal d3 = 0;
                Decimal d4 = 0;
                for (int i = 0; i < dgv.Rows.Count; ++i)
                {
                    // if (chk_no_taxes.Checked)
                    //   dgv.Rows[i].Cells["taxes"].Value = "0";
                    // if (dgv.Rows[i].Cells["coute_type_c"].Value + "" == "1")
                    //{
                    //    double num2 = Convert.ToDouble(db.GetData("select isnull(max((couta_qty-couta_bal)),null) from couta where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and vcs_code='" + combo_code_vcs.Text + "'").Rows[0][0].ToString());
                    //    if (Convert.ToDouble(dgv.Rows[i].Cells["qty"].Value.ToString()) > num2)
                    //    {
                    //        dgv.Rows.Clear();
                    //        XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, " " + num2 + "الرصيد من الكوتة+\nالرصيد اقل من الكوتة ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    //        return;
                    //    }
                    //}

                    lbl_count_dgv.Text = dgv.Rows.Count+"";
                    dgv.Rows[i].Cells["tot_bef"].Value = (Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) * Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value) * Convert.ToDecimal(dgv.Rows[i].Cells["item_price"].Value));
                    dgv.Rows[i].Cells["discount"].Value = Convert.ToDecimal(dgv.Rows[i].Cells["discount"].Value);
                    dgv.Rows[i].Cells["tot_after_dis"].Value = (Convert.ToDecimal(dgv.Rows[i].Cells["tot_bef"].Value) - Convert.ToDecimal(dgv.Rows[i].Cells["discount"].Value));
                    dgv.Rows[i].Cells["incloud_taxes"].Value = (Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) * (1 + Convert.ToDecimal(dgv.Rows[i].Cells["taxes"].Value)));
                    dgv.Rows[i].Cells["taxes_value"].Value = (Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) * Convert.ToDecimal(dgv.Rows[i].Cells["taxes"].Value));
                    dgv.Rows[i].Cells["price_inc_tax"].Value = (Convert.ToDecimal(dgv.Rows[i].Cells["item_price"].Value) * Convert.ToDecimal(dgv.Rows[i].Cells["taxes"].Value) + Convert.ToDecimal(dgv.Rows[i].Cells["item_price"].Value));
                    d1 += Convert.ToDecimal(dgv.Rows[i].Cells["tot_bef"].Value);
                    // num1 += Convert.ToDecimal(dgv.Rows[i].Cells["discount"].Value);


                    d2 += Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value);
                    d4 += Convert.ToDecimal(dgv.Rows[i].Cells["incloud_taxes"].Value);
                    d3 += Convert.ToDecimal(dgv.Rows[i].Cells["taxes_value"].Value);
                }
                if (txt_discount_all.Text == "") txt_discount_all.Text = "0.0";
                num1 = Convert.ToDecimal(txt_discount_all.Text);

                lbl_tot_befor.Text = string.Concat(Math.Round(d1, 2));
                lbl_discount.Text = string.Concat(Math.Round(num1, 2));
                lbl_tot_after_dis.Text = string.Concat(Math.Round(d2, 2));
                lbl_taxes_values.Text = string.Concat(Math.Round(d3, 2));
                lbl_incloud_taxes.Text = string.Concat(Math.Round(d4, 2));
                lbl_requer.Text = string.Concat(Math.Round(d4 - num1, 2));
                lbl_tot.Text = string.Concat(Math.Round(d4, 2));

                //lbl_requer
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                //db.log_error(ex+"");
            }


        }

        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            calc_all();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Rows.Count == 0) return;
            if (e.ColumnIndex == 25)
            {
                dgv.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void btn_up_Click(object sender, EventArgs e)
        {
            numqty.Value += 1;
        }

        private void btn_dowen_Click(object sender, EventArgs e)
        {
            if ((numqty.Value > 1) == false) return;
            numqty.Value -= 1;
        }

        private void btn_up_t_Click(object sender, EventArgs e)
        {
            num_table.Value += 1;
        }

        private void btn_dow_t_Click(object sender, EventArgs e)
        {
            if ((num_table.Value > 1) == false) return;
            num_table.Value -= 1;
        }

        private void combo_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_type.Text== "تيك اواي")
            {
                lbl_table_no_txt.Visible = false;
                num_table.Visible = false;
                btn_up_t.Visible = false;
                btn_dow_t.Visible = false;

                lbl_delever_txt.Visible = false;
                combo_name_emp.Visible = false;
                combo_code_emp.Visible = false;

            }
            else if(combo_type.Text == "دلفري")
            {
                lbl_table_no_txt.Visible = false;
                num_table.Visible = false;
                btn_up_t.Visible = false;
                btn_dow_t.Visible = false;

                lbl_delever_txt.Visible = true;
                combo_name_emp.Visible = true;
                combo_code_emp.Visible = true;
            }
            else
            {
                lbl_table_no_txt.Visible = true;
                num_table.Visible = true;
                btn_up_t.Visible = true;
                btn_dow_t.Visible = true;

                lbl_delever_txt.Visible = false;
                combo_name_emp.Visible = false;
                combo_code_emp.Visible = false;
            }
            
        }

        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv, "no");
            calc_all();
        }

        private void dgv_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            Classes.command.LoadSerial(dgv, "no");
            calc_all();

        }

        private void dgv4_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv4, "no_4");
            //int i = 1;
            //foreach (DataGridViewRow row in dgv4.Rows)
            //{ row.Cells[0].Value = i; i++; }
            calc_all();

        }

        private void dgv4_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            Classes.command.LoadSerial(dgv4, "no_4");
            calc_all();

        }

        private void dgv1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = true;

        }

        private void dgv2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = true;

        }

        private void dgv3_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = true;

        }

        private void dgv4_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = true;

        }

        private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = true;
        }

        private void comob_delever_no_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combo_name_emp.Text = db.GetData("select emp_name from emps where emp_no='" + combo_code_emp.Text + "'").Rows[0][0].ToString();
            }
            catch (Exception)
            {
            }
        }

        private void combo_code_vcs_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combo_name_vcs.Text = db.GetData("select vcs_name from vcs where vcs_code='" + combo_code_vcs.Text + "'").Rows[0][0].ToString();
                combo_phone_vcs.Text = db.GetData("select phone from vcs where vcs_code='" + combo_code_vcs.Text + "'").Rows[0][0].ToString();
                lbl_vcs_address.Text = db.GetData("select address from vcs where vcs_code='" + combo_code_vcs.Text + "'").Rows[0][0].ToString();

            }
            catch (Exception)
            {
            }

        }

        private void combo_name_vcs_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combo_code_vcs.Text = db.GetData("select vcs_code from vcs where vcs_name='" + combo_name_vcs.Text + "'").Rows[0][0].ToString();
                combo_phone_vcs.Text = db.GetData("select phone from vcs where vcs_name='" + combo_name_vcs.Text + "'").Rows[0][0].ToString();
                lbl_vcs_address.Text = db.GetData("select address from vcs where vcs_name='" + combo_name_vcs.Text + "'").Rows[0][0].ToString();

            }
            catch (Exception)
            {
            }
        }

        private void combo_phone_vcs_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combo_code_vcs.Text = db.GetData("select vcs_code from vcs where phone='" + combo_phone_vcs.Text + "'").Rows[0][0].ToString();
                combo_name_vcs.Text = db.GetData("select vcs_name from vcs where phone='" + combo_phone_vcs.Text + "'").Rows[0][0].ToString();
                lbl_vcs_address.Text = db.GetData("select address from vcs where phone='" + combo_phone_vcs.Text + "'").Rows[0][0].ToString();

            }
            catch (Exception)
            {
            }
        }

        private void btn_seaerch_all_vcs_Click(object sender, EventArgs e)
        {
            all_comb.load_code_vcs(combo_code_vcs);
            all_comb.load_name_vcs(combo_name_vcs);
            all_comb.load_phone(combo_phone_vcs, "customer");
            combo_code_vcs.Text = "";
            combo_name_vcs.Text = "";
            combo_phone_vcs.Text = "";
            lbl_vcs_address.Text = "";
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            combo_code_vcs.Text = "";
            combo_name_vcs.Text = "";
            lbl_vcs_address.Text = ",,.";
            combo_code_emp.Text = "";
            combo_name_emp.Text = "";
        }

        private void combo_name_emp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combo_code_emp.Text = db.GetData("select emp_name from emps where emp_no='" + combo_name_emp.Text + "'").Rows[0][0].ToString();
            }
            catch (Exception)
            {
            }
        }
        //======================================================================================main bar

        private void btn_receve_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string shift_state_valid = db.GetData("select isnull(max(lock ),0)from pos_shift where emp_code='" + v.usercode + "'").Rows[0][0].ToString();
            if (shift_state_valid == "0")
            {
                MessageBox.Show("تم إغلاق الوردية ....يجب فتح وردية جيدة");
                return;
            }

            receve_mony_screen();
           // calc_discount_pres();
            clac_discount_all();

        }
        private void clac_discount_all()
        {
            try
            {
                calc_all();
                double x = 0;
                x = Convert.ToDouble(txt_discount_all.Text) / (Convert.ToDouble(lbl_tot.Text)) * 100;
                txt_pres_descount_all.Text = Math.Round(x, 5) + "";
                if (dgv.Rows.Count == 0)
                {
                    txt_discount_all.Text = "0";
                    txt_pres_descount_all.Text = "0";
                }
            }
            catch (Exception)
            {
                txt_discount_all.Text = "0";
                txt_pres_descount_all.Text = "0";

            }

        }
        private void calc_discount_pres()
        {
            try
            {
                double x = 0;
                x = Convert.ToDouble(txt_pres_descount_all.Text) * (Convert.ToDouble(lbl_tot.Text)) / 100;
                txt_discount_all.Text = Math.Round(x, 2) + "";
                if (dgv.Rows.Count == 0)
                {
                    txt_discount_all.Text = "0";
                    txt_pres_descount_all.Text = "0";
                }
            }
            catch (Exception)
            {
                txt_discount_all.Text = "0";
                txt_pres_descount_all.Text = "0";
            }

        }
        private void btn_pay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string shift_state_valid = db.GetData("select isnull(max(lock ),0)from pos_shift where emp_code='" + v.usercode + "'").Rows[0][0].ToString();
            if (shift_state_valid == "0")
            {
                MessageBox.Show("تم إغلاق الوردية ....يجب فتح وردية جيدة");
                return;
            }

            pay_mony_screen();
        }

        private void btn_add_customer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            v.iam_pos = true;
            //MessageBox.Show(v.iam_pos+"");
            frm_customer f = new frm_customer();
            f.ShowDialog();
        }

        private void btn_open_shift_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            pos.pos_shift1 f = new pos_shift1();
            f.Show();
        }

        private void btn_print_last_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string str = db.GetData("select isnull(max(pos_inv_no),0) from pos_dt where pos_dt_id='" + db.GetData("select isnull(max(pos_dt_id),0) from pos_dt where shift_no='" + this.lbl_shift_no.Caption + "'").Rows[0][0].ToString() + "'").Rows[0][0].ToString();
            //XtraReport xtraReport = XtraReport.FromFile("forms\\receipt_printer_pos.repx", true);
            //xtraReport.Parameters["parameter1"].Value = str;
            //xtraReport.Parameters["parameter2"].Value = lbl_shift_no.Caption;
            //xtraReport.Parameters["parameter1"].Visible = false;
            //xtraReport.Parameters["parameter2"].Visible = false;
            //XtraReportPreviewExtensions.ShowPreview(xtraReport);


            XtraReport xtraReport = XtraReport.FromFile("forms\\receipt_printer_pos.repx", true);
            xtraReport.Parameters["parameter1"].Value = str;//lbl_invoice_number.Text;
            // xtraReport.Parameters["parameter2"].Value = lbl_shift_no.Caption;
            xtraReport.Parameters["parameter1"].Visible = false;
            // xtraReport.Parameters["parameter2"].Visible = false;
            xtraReport.PrinterName = Settings.Default.printer_name;
            xtraReport.PrintAsync("");
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            string state_lock = db.GetData_for_log("select isnull(max(lock),0) from pos_shift where emp_code='" + v.usercode + "' and shift_no='" + lbl_shift_no.Caption + "'").Rows[0][0].ToString();
            if (state_lock == "0")
                Close();


           
            //lbl_state_lock.Text = db.GetData_for_log("select isnull(max(lock),0) from pos_shift where emp_code='" + v.usercode + "' and shift_no='" +lbl_shift_no.Caption + "'").Rows[0][0].ToString();
            // if (this.lbl_state_lock.Text == "0")
            //    Close();
            // lbl_time.Text = DateTime.Now.ToString("HHmmss");
            timer_par.Caption = DateTime.Now.ToString("HHmmss");
            bar_data1.Caption = DateTime.Now.ToString("yyyy: MM:dd");
            // BarStaticItem barStaticItem1 =timer_par;
            // DateTime now = DateTime.Now;
            // string str1 = now.ToString("hh:mm:ss ");
            // barStaticItem1.Caption = str1;
            // BarStaticItem barStaticItem2 =bar_data1;
            // now = DateTime.Now;
            // string str2 = now.ToString("yyyy:MM:dd ");
            // barStaticItem2.Caption = str2;
            //lbl_visa.Text = string.Concat(v.visa);
            //lbl_cash.Text = string.Concat(v.cash);
            //lbl_pay.Text = string.Concat(v.pay);
            // if (this.lbl_title.Visible)
            //     v.amount_invoice = Convert.ToDouble(this.lbl_requer.Text);
            // if (v.bool_vcs)
            // {
            //    combo_code_vcs.Text = v.code_vcs;
            //    combo_name_vcs.Text = v.name_vcs;
            //    combo_phone_vcs.Text = v.phone_vcs;
            //     v.bool_vcs = false;
            // }
            // if (v.revec_mony)
            // {
            //    lbl_invoice_number.Text =generat_invoice_number();
            //    barCodeControl1.Text =generat_invoice_number();
            //    insert_receve();
            //     XtraReport xtraReport = XtraReport.FromFile("forms\\receipt_printer_pos.repx", true);
            //     xtraReport.Parameters["parameter1"].Value =lbl_invoice_number.Text;
            //     xtraReport.Parameters["parameter2"].Value =lbl_shift_no.Caption;
            //     xtraReport.Parameters["parameter1"].Visible = false;
            //     xtraReport.Parameters["parameter2"].Visible = false;
            //     xtraReport.PrinterName = Settings.Default.printer_name;
            //     xtraReport.PrintAsync("", new CancellationToken());
            //    clear();
            //     ((Control)this.txt_barcode).Select();
            //     v.revec_mony = false;
            //     v.visa = 0.0;
            //     v.cash = 0.0;
            //    cash_visa_bal();
            // }
            // if (!v.pay_mony)
            //     return;
            //lbl_invoice_number.Text =generat_invoice_number_ret();
            //barCodeControl1.Text =generat_invoice_number_ret();
            //insert_pay();
            //clear();
            // ((Control)this.txt_barcode).Select();
            // v.pay_mony = false;
            // v.pay = 0.0;
            //txt_resale_invno.Text = "";
            //btn_refresh.PerformClick();
            //btn_resale_1.PerformClick();
            //cash_visa_bal();
            if (v.iam_posed == true)
            {
                combo_code_vcs.Text = v.vcs_code_pos;
                combo_name_vcs.Text = v.vcs_name_pos;
                combo_phone_vcs.Text = v.vcs_phone_pos;
                lbl_vcs_address.Text = v.vcs_address_pos;
                v.iam_posed = false;
            }
        }
        //1)recev group
        //_________________
        private void calc_recev()
        {
            try
            {
                //lbl_remind.Text = (Convert.ToDecimal(lbl_reqer_mony.Text) - Convert.ToDecimal(txt_cash.Text) - Convert.ToDecimal(txt_visa.Text)) + "";
                lbl_remind.Text = string.Concat(Math.Round(Convert.ToDecimal(lbl_reqer_mony.Text) - Convert.ToDecimal(txt_cash.Text) - Convert.ToDecimal(txt_visa.Text), 2));
               
            }
            catch (Exception)
            {
            }

        }
        private void calc_remind()
        {
            try
            {
                if (dgv_recv.Rows.Count == 0) return;
                for (int i = 0; i < dgv_recv.Rows.Count; i++)
                {
                    double no = Convert.ToDouble(lbl_reqer_mony.Text) / Convert.ToDouble(dgv_recv.Rows[i].Cells[2].Value);
                    dgv_recv.Rows[i].Cells[4].Value = Math.Round(no, 2) + "";
                }

            }

            catch (Exception)
            {
            }

        }
        private void receve_mony_screen()
        {
            // v.net_recev = Convert.ToDouble(lbl_requer.Text);
            if (dgv.Rows.Count > 0)
            {
            //    group_pending.Visible = false;
                if (Convert.ToDouble(lbl_requer.Text) > 0)
                {
                    lbl_reqer_mony.Text = lbl_requer.Text;
                    group_recev.Visible = true;
                    txt_cash.Select();
                    group_recev.Text = "متحصلات ";
                    txt_visa.Visible = false;
                    //add dgv_recv from other cash
                    DataTable dt = new DataTable();
                    db.GetData_DGV("select name_cash,type,currency_name from pos_cash where len(code_cash)>=2 and len(name_cash)>=1 and shift_no='" + lbl_shift_no.Caption + "' and user_code='" + v.usercode + "' order by code_cash", dt);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][0].ToString().Trim() == "") { dgv_recv.Visible = false; return; }
                        if (dt.Rows[i][1].ToString().Trim() == "visa")
                        {
                            double f_currency = Convert.ToDouble(db.GetData("SELECT max (f_currance) FROM   currance where currance='" + dt.Rows[i][2].ToString().Trim() + "'").Rows[0][0].ToString());
                            dgv_recv.Rows.Add("", dt.Rows[i][0].ToString(), f_currency, "", "", dt.Rows[i][1].ToString().Trim());
                        }
                        if (dt.Rows[i][1].ToString().Trim() == "currency")
                        {
                            double f_currency = Convert.ToDouble(db.GetData("SELECT max (f_currance) FROM   currance where currance='" + dt.Rows[i][2].ToString().Trim() + "'").Rows[0][0].ToString());
                            dgv_recv.Rows.Add("", dt.Rows[i][0].ToString(), f_currency, "", "", dt.Rows[i][1].ToString().Trim());
                        }
                        else if (dt.Rows[i][1].ToString().Trim() == "vcs")//not work right now credit vcs 
                        {
                            dgv_recv.Rows.Add("", dt.Rows[i][0].ToString(), "", "", dt.Rows[i][1].ToString().Trim());
                        }
                    }
                    if (dgv_recv.Rows.Count == 0)
                    {
                        dgv_recv.Visible = false;
                    }
                    else
                    {
                        dgv_recv.Visible = true;
                    }
                }
                txt_calc.Text = lbl_tot.Text;
                calc_remind();
            }
        }
        private void pay_mony_screen()
        {
            if (dgv.Rows.Count > 0)
            {
                if (Convert.ToDouble(lbl_requer.Text) > 0)
                {
                    lbl_reqer_mony.Text = lbl_requer.Text;
                    group_recev.Visible = true;
                    txt_cash.Select();
                    group_recev.Text = "المدفوع ";
                    txt_visa.Visible = false;
                }
            }
            txt_calc.Text = lbl_reqer_mony.Text;
            min.PerformClick();//CALCULATOR
        }
        private void insert_receve()
        {

            for (int i = 0; i < dgv.Rows.Count; ++i)
            {
                decimal dis = 0;
                if (txt_discount_all.Text == "") txt_discount_all.Text = "0";
                if (i == 0)
                {
                    dis = Convert.ToDecimal(txt_discount_all.Text);
                }
                else
                {
                    dis = 0;
                }
                //     DateTime dateTime;
                //normal mode not expire and not hotel 
                //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                // state normal =0     on roll in state booking in hotel =1    gift =2           +
                //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                if (gift == true)
                {
                    db.Run("insert into pos_dt(pos_inv_no            ,onRoll ,        shift_no            ,                       code_items              ,                        name_items             ,                                         qty             ,                                      item_price                  ,                                         tot_bef             ,                                         discount             ,                                         tot_after_dis             ,                                        taxes              ,                                        incloud_taxes                 ,                                          taxes_value             ,      id_ware                                   ,                         f_unite,                                   name_unite                                           ,no,                                                           [exp]              ,            exp_date                        ,[type]                    ,     user_code    ,      user_name           ,vcs_code                  ,vcs_name,                       phone_vcs                 ,delivery_code             ,delivery_name,                time_h                                          ,date_d                                         ,cash_bal   ,visa_bal  ,opening_bal,state,discount_all) values('" +
                    lbl_invoice_number.Text + "',2,'" + lbl_shift_no.Caption + "','" + dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["item_price"].Value) + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_bef"].Value) + "         ," + Convert.ToDecimal(dgv.Rows[i].Cells["discount"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["taxes"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["incloud_taxes"].Value) + "'         ,'" + Convert.ToDecimal(dgv.Rows[i].Cells["taxes_value"].Value) + "','" + lbl_wares.Text + "'                           ,'" + dgv.Rows[i].Cells["f_unite"].Value + "'  ,'" + dgv.Rows[i].Cells["name_unite"].Value + "'         ,'" + dgv.Rows[i].Cells["no"].Value + "','" + (Convert.ToBoolean(dgv.Rows[i].Cells["exp"].Value)) + "',            Null              ,'" + dgv.Rows[i].Cells["type"].Value + "','" + v.usercode + "','" + lbl_user_name.Text + "','" + combo_code_vcs.Text + "','" + combo_name_vcs.Text + "','" + combo_phone_vcs.Text + "','" + combo_code_emp.Text + "','" + combo_name_emp.Text + "','" + DateTime.Now.ToString("hh:mm:ss") + "'        ,'" + DateTime.Now.ToString("MM-dd-yyyy") + "'     ,'" + v.cash + "'       ,'" + v.visa + "'     ,null       ,'sal','" + dis + "')");
                }
                if (!Convert.ToBoolean(dgv.Rows[i].Cells["exp"].Value) && combo_RoomNO.Text == "" && gift ==false)
                {
                    db.Run("insert into pos_dt(pos_inv_no            ,  onRoll ,       shift_no            ,                       code_items              ,                        name_items             ,                                         qty             ,                                      item_price                  ,                                         tot_bef             ,                                         discount             ,                                         tot_after_dis             ,                                        taxes              ,                                        incloud_taxes                 ,                                          taxes_value             ,      id_ware                                   ,                         f_unite,                                   name_unite                                           ,no,                                                           [exp]              ,            exp_date                        ,[type]                    ,     user_code    ,      user_name           ,vcs_code                  ,vcs_name,                       phone_vcs                 ,delivery_code             ,delivery_name,                time_h                                          ,date_d                                         ,cash_bal   ,visa_bal  ,opening_bal,state,discount_all) values('" +
                                            lbl_invoice_number.Text + "',0,'" + lbl_shift_no.Caption + "','" + dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["item_price"].Value) + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_bef"].Value) + "         ," + Convert.ToDecimal(dgv.Rows[i].Cells["discount"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["taxes"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["incloud_taxes"].Value) + "'         ,'" + Convert.ToDecimal(dgv.Rows[i].Cells["taxes_value"].Value) + "','" + lbl_wares.Text + "'                           ,'" + dgv.Rows[i].Cells["f_unite"].Value + "'  ,'" + dgv.Rows[i].Cells["name_unite"].Value + "'         ,'" + dgv.Rows[i].Cells["no"].Value + "','" + (Convert.ToBoolean(dgv.Rows[i].Cells["exp"].Value)) + "',            Null              ,'" + dgv.Rows[i].Cells["type"].Value + "','" + v.usercode + "','" + lbl_user_name.Text + "','" + combo_code_vcs.Text + "','" + combo_name_vcs.Text + "','" + combo_phone_vcs.Text + "','" + combo_code_emp.Text + "','" + combo_name_emp.Text + "','" + DateTime.Now.ToString("hh:mm:ss") + "'        ,'" + DateTime.Now.ToString("MM-dd-yyyy") + "'     ,'" + v.cash + "'       ,'" + v.visa + "'     ,null       ,'sal','" + dis + "')");
                }
                //hotel mode not expir but found room to add in guest_records hotel

                else if (!Convert.ToBoolean(dgv.Rows[i].Cells["exp"].Value) && combo_RoomNO.Text !="" )
                {

                    //3)insert into hotel table " guest_records "  
                   
                  
                    if (credit==true)
                    {
                        
                        db.Run("insert into pos_dt(pos_inv_no            ,onRoll ,        shift_no            ,                       code_items              ,                        name_items             ,                                         qty             ,                                      item_price                  ,                                         tot_bef             ,                                         discount             ,                                         tot_after_dis             ,                                        taxes              ,                                        incloud_taxes                 ,                                          taxes_value             ,      id_ware                                   ,                         f_unite,                                   name_unite                                           ,no,                                                           [exp]              ,            exp_date                        ,[type]                    ,     user_code    ,      user_name           ,vcs_code                  ,vcs_name,                       phone_vcs                 ,delivery_code             ,delivery_name,                time_h                                          ,date_d                                         ,cash_bal   ,visa_bal  ,opening_bal,state,discount_all) values('" +
                                            lbl_invoice_number.Text + "',1,'" + lbl_shift_no.Caption + "','" + dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["item_price"].Value) + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_bef"].Value) + "         ," + Convert.ToDecimal(dgv.Rows[i].Cells["discount"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["taxes"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["incloud_taxes"].Value) + "'         ,'" + Convert.ToDecimal(dgv.Rows[i].Cells["taxes_value"].Value) + "','" + lbl_wares.Text + "'                           ,'" + dgv.Rows[i].Cells["f_unite"].Value + "'  ,'" + dgv.Rows[i].Cells["name_unite"].Value + "'         ,'" + dgv.Rows[i].Cells["no"].Value + "','" + (Convert.ToBoolean(dgv.Rows[i].Cells["exp"].Value)) + "',            Null              ,'" + dgv.Rows[i].Cells["type"].Value + "','" + v.usercode + "','" + lbl_user_name.Text + "','" + combo_code_vcs.Text + "','" + combo_name_vcs.Text + "','" + combo_phone_vcs.Text + "','" + combo_code_emp.Text + "','" + combo_name_emp.Text + "','" + DateTime.Now.ToString("hh:mm:ss") + "'        ,'" + DateTime.Now.ToString("MM-dd-yyyy") + "'     ,'" + v.cash + "'       ,'" + v.visa + "'     ,null       ,'sal','" + dis + "')");
                        db.Run("insert into servies_records_hot (idkey                 ,id_guest               ,id_comapny,                      id_room,id_item,name_item,qty,price,tot,date_in,date_out,date_issue,credit,type_food_beverage,type_food)values ('" +
                                                                     lbl_idkey.Text+"','"+lbl_id_guest.Text+"','"+lbl_id_comapny.Text+"','"+combo_RoomNO.Text+"','"+ dgv.Rows[i].Cells["code_items"].Value + "','"+ dgv.Rows[i].Cells["name_items"].Value + "','" + Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) + "','" + Convert.ToDecimal(dgv.Rows[i].Cells["item_price"].Value) + "','"+ Convert.ToDecimal(dgv.Rows[i].Cells["incloud_taxes"].Value) + "','"+Convert.ToDateTime(lbl_dateIn.Text).ToString("MM-dd-yyyy") +"','"+ Convert.ToDateTime(lbl_dateOut.Text).ToString("MM-dd-yyyy") + "','" + DateTime.Now.ToString("MM-dd-yyyy") + "','1','1','f')");
                    }
                    else
                    {
                        db.Run("insert into pos_dt(pos_inv_no            ,onRoll ,        shift_no            ,                       code_items              ,                        name_items             ,                                         qty             ,                                      item_price                  ,                                         tot_bef             ,                                         discount             ,                                         tot_after_dis             ,                                        taxes              ,                                        incloud_taxes                 ,                                          taxes_value             ,      id_ware                                   ,                         f_unite,                                   name_unite                                           ,no,                                                           [exp]              ,            exp_date                        ,[type]                    ,     user_code    ,      user_name           ,vcs_code                  ,vcs_name,                       phone_vcs                 ,delivery_code             ,delivery_name,                time_h                                          ,date_d                                         ,cash_bal   ,visa_bal  ,opening_bal,state,discount_all) values('" +
                                            lbl_invoice_number.Text + "',0,'" + lbl_shift_no.Caption + "','" + dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["item_price"].Value) + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_bef"].Value) + "         ," + Convert.ToDecimal(dgv.Rows[i].Cells["discount"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["taxes"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["incloud_taxes"].Value) + "'         ,'" + Convert.ToDecimal(dgv.Rows[i].Cells["taxes_value"].Value) + "','" + lbl_wares.Text + "'                           ,'" + dgv.Rows[i].Cells["f_unite"].Value + "'  ,'" + dgv.Rows[i].Cells["name_unite"].Value + "'         ,'" + dgv.Rows[i].Cells["no"].Value + "','" + (Convert.ToBoolean(dgv.Rows[i].Cells["exp"].Value)) + "',            Null              ,'" + dgv.Rows[i].Cells["type"].Value + "','" + v.usercode + "','" + lbl_user_name.Text + "','" + combo_code_vcs.Text + "','" + combo_name_vcs.Text + "','" + combo_phone_vcs.Text + "','" + combo_code_emp.Text + "','" + combo_name_emp.Text + "','" + DateTime.Now.ToString("hh:mm:ss") + "'        ,'" + DateTime.Now.ToString("MM-dd-yyyy") + "'     ,'" + v.cash + "'       ,'" + v.visa + "'     ,null       ,'sal','" + dis + "')");
                        db.Run("insert into servies_records_hot (idkey                 ,id_guest               ,id_comapny,                      id_room,id_item,name_item,qty,price,tot,date_in,date_out,date_issue,credit,type_food_beverage,type_food)values ('" +
                                                                     lbl_idkey.Text + "','" + lbl_id_guest.Text + "','" + lbl_id_comapny.Text + "','" + combo_RoomNO.Text + "','" + dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "','" + Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) + "','" + Convert.ToDecimal(dgv.Rows[i].Cells["item_price"].Value) + "','" + Convert.ToDecimal(dgv.Rows[i].Cells["incloud_taxes"].Value) + "','" + Convert.ToDateTime(lbl_dateIn.Text).ToString("MM-dd-yyyy") + "','" + Convert.ToDateTime(lbl_dateOut.Text).ToString("MM-dd-yyyy") + "','" + DateTime.Now.ToString("MM-dd-yyyy") + "','0','1','f')");
                    }

                }
                else if (Convert.ToBoolean(dgv.Rows[i].Cells["exp"].Value))
                {
                    db.Run("insert into pos_dt(pos_inv_no            ,  onRoll ,       shift_no            ,                       code_items              ,                        name_items             ,                                         qty             ,                                      item_price                  ,                                         tot_bef             ,                                         discount             ,                                         tot_after_dis             ,                                        taxes              ,                                        incloud_taxes                 ,                                          taxes_value             ,      id_ware                                   ,                         f_unite,                                   name_unite                                           ,no,                                                           [exp]              ,            exp_date                        ,[type]                    ,     user_code    ,      user_name           ,vcs_code                  ,vcs_name,                       phone_vcs                 ,delivery_code             ,delivery_name,                time_h                                          ,date_d                                         ,cash_bal   ,visa_bal  ,opening_bal,state,discount_all) values('" +
                                           lbl_invoice_number.Text + "',0,'" + lbl_shift_no.Caption + "','" + dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["item_price"].Value) + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_bef"].Value) + "         ," + Convert.ToDecimal(dgv.Rows[i].Cells["discount"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["taxes"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["incloud_taxes"].Value) + "'         ,'" + Convert.ToDecimal(dgv.Rows[i].Cells["taxes_value"].Value) + "','" + lbl_wares.Text + "'                           ,'" + dgv.Rows[i].Cells["f_unite"].Value + "'  ,'" + dgv.Rows[i].Cells["name_unite"].Value + "'         ,'" + dgv.Rows[i].Cells["no"].Value + "','" + (Convert.ToBoolean(dgv.Rows[i].Cells["exp"].Value)) + "',            '" + dgv.Rows[i].Cells["exp_date"].Value.ToString() + "'              ,'" + dgv.Rows[i].Cells["type"].Value + "','" + v.usercode + "','" + lbl_user_name.Text + "','" + combo_code_vcs.Text + "','" + combo_name_vcs.Text + "','" + combo_phone_vcs.Text + "','" + combo_code_emp.Text + "','" + combo_name_emp.Text + "','" + DateTime.Now.ToString("hh:mm:ss") + "'        ,'" + DateTime.Now.ToString("MM-dd-yyyy") + "'     ,'" + v.cash + "'       ,'" + v.visa + "'     ,null       ,'sal','" + dis + "')");
                }
                if (dgv.Rows[i].Cells["coute_type_c"].Value.ToString() == "1")
                {
                    double couta_bal = Convert.ToDouble(db.GetData("select isnull(sum(couta_bal),0) from couta where vcs_code='" + combo_code_vcs.Text + "' and code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'").Rows[0][0].ToString());
                    db.Run("update couta  set couta_bal='" + (couta_bal + Convert.ToDouble(dgv.Rows[i].Cells["qty"].Value) * Convert.ToDouble(dgv.Rows[i].Cells["f_unite"].Value)) + "'  ,last_date='" + DateTime.Now.ToString("MM-dd-yyyy") + "' where vcs_code='" + combo_code_vcs.Text + "' and code_items ='" + dgv.Rows[i].Cells["code_items"].Value + "'");
                }
            }
            v.cash = 0.0;
            v.visa = 0.0;
            double bal_cash = Convert.ToDouble(db.GetData("select isnull(sum(balance),0) from pos_cash where code_cash='1' and shift_no='" + lbl_shift_no.Caption + "' and user_code='" + v.usercode + "'").Rows[0][0].ToString());
            //double bal_other = Convert.ToDouble(db.GetData("select isnull(sum(balance),0) from pos_cash where code_cash='2' and shift_no='" + lbl_shift_no.Caption + "' and user_code='" + v.usercode + "'").Rows[0][0].ToString());
            if (Convert.ToDouble(txt_visa.Text) == 0 &&  credit==false && gift ==false) 
            {//update lbl_inv
                db.Run("update pos_cash set balance ='" + (Convert.ToDouble(lbl_reqer_mony.Text) + Convert.ToDouble(bal_cash)) + "' where shift_no='" + lbl_shift_no.Caption + "' and user_code='" + v.usercode + "' and code_cash='1'");
            }
            else if (combo_RoomNO.Text != "" && credit ==true && gift ==false )
            {
                //1-insert entry 
                //2-close and clear
                //insert into entry  from room to sales account
                //room 101   by amount 30 EGP
                //    sales   by amount 30 EGP



                //insert entry_hd
                string code_book = db.GetData("select code_book from pos_cash_account where user_code='" + v.usercode + "' ").Rows[0][0].ToString();
                string sales_acc = db.GetData("select sales_acc from pos_cash_account where user_code='" + v.usercode + "' ").Rows[0][0].ToString();
                string costcenter = db.GetData("select isnull(MAX(costcenter_id),'-') from pos_cash_account where user_code='" + v.usercode + "' ").Rows[0][0].ToString();

                string code_entry_dt = db.GetData("select (max(convert(int,(right( CODE_ENTRY , len(CODE_ENTRY)-3)))))+1 from entry WHERE code_book='" + code_book + "'").Rows[0][0].ToString();
                string code_entry_hd = db.GetData("select (max(convert(int,(right( CODE_ENTRY , len(CODE_ENTRY)-3)))))+1 from entry_hd WHERE code_book='" + code_book + "'").Rows[0][0].ToString();
                //string acc_num = "120501";
                string acc_num = db.GetData("select top 1 res_credit from implemint_entry_hot where user_code='"+v.usercode+"' ").Rows[0][0]+"";

                string code_entry = "";
                string error = "";
                int num_entry=0;

                cls_book.Generat_numBooknum("entry", code_book, ref code_entry, ref error, ref num_entry);
                //if error event between entry_dt and entry_hd make this method
                if (code_entry_dt != code_entry_hd)
                {
                    string error_code = db.GetData("select (max(convert(int,(right( CODE_ENTRY , len(CODE_ENTRY)-3))))) from entry_hd WHERE code_book='" + code_book + "'").Rows[0][0].ToString();
                    db.Run("delete from entry_hd where code_entry ='" + code_book + error_code + "'");
                }
                //insert entry_dt
                //1)Room Account like vcs 
                    db.Run("insert into entry(  [code_entry]                           ,    acc_num             ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                               ,   sort                                                            , type_acc                                                       ,             depit                                                             ,                credit                 ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext ,num_book,attachno2)values('" +
                                                code_entry + "'                       ,'" + acc_num + "'     ,(select top 1 rootname from tree where rootid='" + acc_num + "')               ,  (select top 1 RootLevel from tree where rootid='" + acc_num + "')    ,  (select top 1 rootlevel_name from entry where acc_num='" + acc_num + "'), (select top 1 sort from entry where acc_num='" + acc_num + "')       ,  (select top 1 type_acc from entry where acc_num='" + acc_num + "')  ,  '" + Convert.ToDecimal(lbl_reqer_mony.Text) + "' ,0  , 'POS','" + code_book + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + lbl_shift_no.Caption + "','"+ lbl_idkey.Text + "','POS credit','"+ combo_RoomNO.Text+"','" + num_entry + "','"+lbl_id_guest.Text+"')");
                //2)Sales account  
                    db.Run("insert into entry(  [code_entry]                           ,    acc_num             ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                               ,   sort                                                            , type_acc                                                       ,             depit                                                             ,                credit                 ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext,costcenter_code ,num_book,attachno2)values('" +
                                         code_entry + "'                           ,'" + sales_acc + "'     ,(select top 1 rootname from tree where rootid='" + sales_acc + "')               ,  (select top 1 RootLevel from tree where rootid='" + sales_acc + "')    ,  (select top 1 rootlevel_name from entry where acc_num='" + sales_acc + "'), (select top 1 sort from entry where acc_num='" + sales_acc + "')       ,  (select top 1 type_acc from entry where acc_num='" + sales_acc + "')  ,  '0' ,'" + Convert.ToDecimal(lbl_reqer_mony.Text) + "'  , 'POS','" + code_book + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + lbl_shift_no.Caption + "','"+ lbl_idkey.Text+"','POS credit','"+ combo_RoomNO.Text+"','" + costcenter + "','" + num_entry + "','"+lbl_id_guest.Text+"')");

            }
            //make entry to gift
            //else if ( credit == false && gift ==true )
            //{

            //    //insert entry_hd
            //    string code_book = db.GetData("select code_book from pos_cash_account where user_code='" + v.usercode + "' ").Rows[0][0].ToString();
            //    string sales_acc = db.GetData("select sales_acc from pos_cash_account where user_code='" + v.usercode + "' ").Rows[0][0].ToString();
            //    string costcenter = db.GetData("select isnull(MAX(costcenter_id),'-') from pos_cash_account where user_code='" + v.usercode + "' ").Rows[0][0].ToString();

            //    string code_entry_dt = db.GetData("select (max(convert(int,(right( CODE_ENTRY , len(CODE_ENTRY)-3)))))+1 from entry WHERE code_book='" + code_book + "'").Rows[0][0].ToString();
            //    string code_entry_hd = db.GetData("select (max(convert(int,(right( CODE_ENTRY , len(CODE_ENTRY)-3)))))+1 from entry_hd WHERE code_book='" + code_book + "'").Rows[0][0].ToString();
            //    //string acc_num = "120501";
            //    string acc_num = db.GetData("select top 1 gift from pos_cash_account where user_code='" + v.usercode + "' ").Rows[0][0] + "";

            //    string code_entry = "";
            //    string error = "";
            //    int num_entry = 0;

            //    cls_book.Generat_numBooknum("entry", code_book, ref code_entry, ref error, ref num_entry);
            //    //if error event between entry_dt and entry_hd make this method
            //    if (code_entry_dt != code_entry_hd)
            //    {
            //        string error_code = db.GetData("select (max(convert(int,(right( CODE_ENTRY , len(CODE_ENTRY)-3))))) from entry_hd WHERE code_book='" + code_book + "'").Rows[0][0].ToString();
            //        db.Run("delete from entry_hd where code_entry ='" + code_book + error_code + "'");
            //    }
            //    //insert entry_dt
            //    //1)Room Account like vcs 
            //    db.Run("insert into entry(  [code_entry]                           ,    acc_num             ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                               ,   sort                                                            , type_acc                                                       ,             depit                                                             ,                credit                 ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext ,num_book,attachno2)values('" +
            //                                code_entry + "'                       ,'" + acc_num + "'     ,(select top 1 rootname from tree where rootid='" + acc_num + "')               ,  (select top 1 RootLevel from tree where rootid='" + acc_num + "')    ,  (select top 1 rootlevel_name from entry where acc_num='" + acc_num + "'), (select top 1 sort from entry where acc_num='" + acc_num + "')       ,  (select top 1 type_acc from entry where acc_num='" + acc_num + "')  ,  '" + Convert.ToDecimal(lbl_reqer_mony.Text) + "' ,0  , 'POS','" + code_book + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + lbl_shift_no.Caption + "','" + lbl_idkey.Text + "','POS credit','" + combo_RoomNO.Text + "','" + num_entry + "','" + lbl_id_guest.Text + "')");
            //    //2)Sales account  
            //    db.Run("insert into entry(  [code_entry]                           ,    acc_num             ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                               ,   sort                                                            , type_acc                                                       ,             depit                                                             ,                credit                 ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext,costcenter_code ,num_book,attachno2)values('" +
            //                         code_entry + "'                           ,'" + sales_acc + "'     ,(select top 1 rootname from tree where rootid='" + sales_acc + "')               ,  (select top 1 RootLevel from tree where rootid='" + sales_acc + "')    ,  (select top 1 rootlevel_name from entry where acc_num='" + sales_acc + "'), (select top 1 sort from entry where acc_num='" + sales_acc + "')       ,  (select top 1 type_acc from entry where acc_num='" + sales_acc + "')  ,  '0' ,'" + Convert.ToDecimal(lbl_reqer_mony.Text) + "'  , 'POS','" + code_book + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + lbl_shift_no.Caption + "','" + lbl_idkey.Text + "','POS credit','" + combo_RoomNO.Text + "','" + costcenter + "','" + num_entry + "','" + lbl_id_guest.Text + "')");

            //}
            else if(visa ==true)
            {  //update from cash
                db.Run("update pos_cash set balance ='" + (Convert.ToDouble(txt_cash.Text) + Convert.ToDouble(bal_cash)) + "' where shift_no='" + lbl_shift_no.Caption + "' and user_code='" + v.usercode + "' and code_cash='1'");
                DataTable dt = new DataTable();
                db.GetData_DGV("select balance ,code_cash from pos_cash where shift_no='" + lbl_shift_no.Caption + "' and user_code='" + v.usercode + "' and len(code_cash)>=2 order by code_cash", dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string balance = dt.Rows[i][0].ToString().Trim();
                    string code = dt.Rows[i][1].ToString().Trim();
                    string balance_dgv = dgv_recv.Rows[i].Cells[3].Value + "".Trim();
                    if (balance == "") balance = "0"; if (balance_dgv == "") balance_dgv = "0";
                    db.Run("update pos_cash set balance ='" + (Convert.ToDouble(balance_dgv) + Convert.ToDouble(balance)) + "' where shift_no='" + lbl_shift_no.Caption + "' and user_code='" + v.usercode + "' and code_cash='" + code + "'");
                }
                cash_balance();
                //insert into entry  from vcs or visa 
                DataTable dt_visa = new DataTable();
                db.GetData_DGV("select type,cash_account_user from pos_cash where len(code_cash)>=2 and len(name_cash)>=1 and shift_no='" + lbl_shift_no.Caption + "' and user_code='" + v.usercode + "' and type='visa'", dt_visa);
                if (dt_visa.Rows[0][0].ToString().Trim() == "visa")
                {
                    for (int i = 0; i < dt_visa.Rows.Count; i++)
                    {
                        string cash5_account = dt_visa.Rows[i][1] + "".Trim();
                        string cash6_account = db.GetData("select medil from pos_cash_account where user_code='" + lbl_user_code.Text + "' ").Rows[0][0].ToString().Trim();
                        string x = "001";
                        string amount_visa = dgv_recv.Rows[i].Cells[3].Value + ""; if (amount_visa == "") amount_visa = "0";
                        if (dgv_recv.Rows[i].Cells[5].Value.ToString().Trim() == "visa" && Convert.ToDouble(amount_visa) > 0)
                        {
                            db.Run("insert into entry(  [code_entry]                           ,    acc_num             ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                               ,   sort                                                            , type_acc                                                       ,             depit                                                             ,                credit                 ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext )values('" +
                                               x + "'                           ,'" + cash5_account + "'     ,(select top 1 rootname from tree where rootid='" + cash5_account + "')               ,  (select top 1 RootLevel from tree where rootid='" + cash5_account + "')    ,  0, '1'       ,  (select top 1 type_acc from entry where acc_num='" + cash5_account + "')  ,  '" + Convert.ToDecimal(dgv_recv.Rows[i].Cells[3].Value) + "' ,0  , 'POS','POS'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + lbl_shift_no.Caption + "','POS','POS','قيد مؤقت لحين إغلاق الوردية ')");
                            db.Run("insert into entry(  [code_entry]                           ,    acc_num             ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                               ,   sort                                                            , type_acc                                                       ,             depit                                                             ,                credit                 ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext )values('" +
                                             x + "'                           ,'" + cash6_account + "'     ,(select top 1 rootname from tree where rootid='" + cash6_account + "')               ,  (select top 1 RootLevel from tree where rootid='" + cash6_account + "')    ,  0, '1'       ,  (select top 1 type_acc from entry where acc_num='" + cash6_account + "')  ,0,  '" + Convert.ToDecimal(dgv_recv.Rows[i].Cells[3].Value) + "'   , 'POS','POS'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + lbl_shift_no.Caption + "','POS','POS','قيد مؤقت لحين إغلاق الوردية ')");
                        }
                    }
                }

            }
            else
            {

            }
            if (no_invoice_pending != "")
            {
                db.Run("delete from pos_pending where pos_inv_no='" + no_invoice_pending + "'");
            }
            no_invoice_pending = "";
        }
        private void insert_pay()
        {
            if (dgv.Rows.Count == 0)
            {
                return;
            }
            for (int i = 0; i < dgv.Rows.Count; ++i)
            {
                decimal dis = 0;
                if (txt_discount_all.Text == "") txt_discount_all.Text = "0";
                if (i == 0)
                {
                    dis = Convert.ToDecimal(txt_discount_all.Text);
                }
                else
                {
                    dis = 0;
                }

                //if (!Convert.ToBoolean(dgv.Rows[i].Cells["exp"].Value))
                //{
                //    db.Run("insert into pos_dt(pos_inv_no            ,         shift_no            ,                       code_items              ,                        name_items             ,                                         qty             ,                                      item_price                  ,                                         tot_bef             ,                                         discount             ,                                         tot_after_dis             ,                                        taxes              ,                                        incloud_taxes                 ,                                          taxes_value             ,      id_ware                                   ,                         f_unite,                                   name_unite                                           ,no,                                                           [exp]              ,            exp_date                        ,[type]                    ,     user_code    ,      user_name           ,vcs_code                  ,vcs_name,                       phone_vcs                 ,delivery_code             ,delivery_name,                time_h                                          ,date_d                                         ,cash_bal   ,visa_bal  ,opening_bal,re_pos_inv_no,state,discount_all) values('" +
                //                            lbl_invoice_number.Text + "','" + lbl_shift_no.Caption + "','" + dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) * -1 + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["item_price"].Value) + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_bef"].Value) * -1 + "         ," + Convert.ToDecimal(dgv.Rows[i].Cells["discount"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) * -1 + "," + Convert.ToDecimal(dgv.Rows[i].Cells["taxes"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["incloud_taxes"].Value) * -1 + "'         ,'" + Convert.ToDecimal(dgv.Rows[i].Cells["taxes_value"].Value) + "','" + lbl_wares.Text + "'                           ,'" + dgv.Rows[i].Cells["f_unite"].Value + "'  ,'" + dgv.Rows[i].Cells["name_unite"].Value + "'         ,'" + dgv.Rows[i].Cells["no"].Value + "','" + (Convert.ToBoolean(dgv.Rows[i].Cells["exp"].Value)) + "',            Null              ,'" + dgv.Rows[i].Cells["type"].Value + "','" + v.usercode + "','" + lbl_user_name.Text + "','" + combo_code_vcs.Text + "','" + combo_name_vcs.Text + "','" + combo_phone_vcs.Text + "','" + combo_code_emp.Text + "','" + combo_name_emp.Text + "','" + DateTime.Now.ToString("hh:mm:ss") + "'        ,'" + DateTime.Now.ToString("MM-dd-yyyy") + "'     ,'" + (Convert.ToDouble(v.cash) * -1) + "'       ,'" + (Convert.ToDouble(v.visa) * -1) + "'      ,null      ,'" + txt_resale.Text + "' ,'re','" + dis * -1 + "')");

                //}
                //else if (Convert.ToBoolean(dgv.Rows[i].Cells["exp"].Value))
                //{
                //    db.Run("insert into pos_dt(pos_inv_no            ,         shift_no            ,                       code_items              ,                        name_items             ,                                         qty             ,                                      item_price                  ,                                         tot_bef             ,                                         discount             ,                                         tot_after_dis             ,                                        taxes              ,                                        incloud_taxes                 ,                                          taxes_value             ,      id_ware                                   ,                         f_unite,                                   name_unite                                           ,no,                                                           [exp]              ,            exp_date                        ,[type]                    ,     user_code    ,      user_name           ,vcs_code                  ,vcs_name,                       phone_vcs                 ,delivery_code             ,delivery_name,                time_h                                          ,date_d                                         ,cash_bal   ,visa_bal  ,opening_bal,re_pos_inv_no,state,discount_all) values('" +
                //                           lbl_invoice_number.Text + "','" + lbl_shift_no.Caption + "','" + dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) * -1 + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["item_price"].Value) + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_bef"].Value) * -1 + "         ," + Convert.ToDecimal(dgv.Rows[i].Cells["discount"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) * -1 + "," + Convert.ToDecimal(dgv.Rows[i].Cells["taxes"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["incloud_taxes"].Value) * -1 + "'         ,'" + Convert.ToDecimal(dgv.Rows[i].Cells["taxes_value"].Value) + "','" + lbl_wares.Text + "'                           ,'" + dgv.Rows[i].Cells["f_unite"].Value + "'  ,'" + dgv.Rows[i].Cells["name_unite"].Value + "'         ,'" + dgv.Rows[i].Cells["no"].Value + "','" + (Convert.ToBoolean(dgv.Rows[i].Cells["exp"].Value)) + "',            '" + dgv.Rows[i].Cells["exp_date"].Value.ToString() + "'              ,'" + dgv.Rows[i].Cells["type"].Value + "','" + v.usercode + "','" + lbl_user_name.Text + "','" + combo_code_vcs.Text + "','" + combo_name_vcs.Text + "','" + combo_phone_vcs.Text + "','" + combo_code_emp.Text + "','" + combo_name_emp.Text + "','" + DateTime.Now.ToString("hh:mm:ss") + "'        ,'" + DateTime.Now.ToString("MM-dd-yyyy") + "'     ,'" + (Convert.ToDouble(v.cash) * -1) + "'       ,'" + (Convert.ToDouble(v.visa) * -1) + "' ,null     ,'" + txt_resale.Text + "'  ,'re','" + dis * -1 + "')");

                //}

                //if (dgv.Rows[i].Cells["coute_type_c"].Value.ToString() == "1")
                //{
                //    double couta_bal = Convert.ToDouble(db.GetData("select isnull(sum(couta_bal),0) from couta where vcs_code='" + combo_code_vcs.Text + "' and code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'").Rows[0][0].ToString());
                //    db.Run("update couta  set couta_bal='" + (couta_bal + Convert.ToDouble(dgv.Rows[i].Cells["qty"].Value) * Convert.ToDouble(dgv.Rows[i].Cells["f_unite"].Value)) + "'  ,last_date='" + DateTime.Now.ToString("MM-dd-yyyy") + "' where vcs_code='" + combo_code_vcs.Text + "' and code_items ='" + dgv.Rows[i].Cells["code_items"].Value + "'");
                //}
            }
            v.cash = 0.0;
            v.visa = 0.0;
            //select_entry();
            double balance_cuuren_cash = Convert.ToDouble(db.GetData("select isnull(sum(balance),0) from pos_cash where code_cash='1' and shift_no='" + lbl_shift_no.Caption + "' and user_code='" + v.usercode + "'").Rows[0][0].ToString());
            // double num2 = Convert.ToDouble(db.GetData("select isnull(sum(balance),0) from pos_cash where code_cash='2' and shift_no='" + lbl_shift_no.Caption + "' and user_code='" + v.usercode + "'").Rows[0][0].ToString());
            // if (Convert.ToDouble(txt_visa.Text) == 0)
            // {//update lbl_inv
            db.Run("update pos_cash set balance ='" + (Convert.ToDouble(balance_cuuren_cash) - Convert.ToDouble(lbl_reqer_mony.Text)) + "' where shift_no='" + lbl_shift_no.Caption + "' and user_code='" + v.usercode + "' and code_cash='1'");
            // }
            //else
            //{  //update from cash
            //    db.Run("update pos_cash set balance ='" + (Convert.ToDouble(num1) - Convert.ToDouble(txt_cash.Text)) + "' where shift_no='" + lbl_shift_no.Caption + "' and user_code='" + v.usercode + "' and code_cash='1'");
            //    db.Run("update pos_cash set balance ='" + (Convert.ToDouble(num2) - Convert.ToDouble(txt_visa.Text)) + "' where shift_no='" + lbl_shift_no.Caption + "' and user_code='" + v.usercode + "' and code_cash='2'");
            //}
            cash_balance();

        }
        private void recev_cash()
        {
            if (txt_visa.Text == "")
                txt_visa.Text = "0";
            if (txt_cash.Text == "")
                txt_cash.Text = "0";
            if (Convert.ToDouble(lbl_remind.Text) > 0.0 || Convert.ToDouble(txt_visa.Text) != 0.0 && Convert.ToDouble(lbl_remind.Text) != 0.0)
                return;
            if (Convert.ToDecimal(lbl_remind.Text) <= 0)
            {
                v.cash = !(txt_cash.Text == "0") && !(txt_cash.Text == "") ? Convert.ToDouble(txt_cash.Text) + Convert.ToDouble(lbl_remind.Text) : Convert.ToDouble(txt_cash.Text);
                v.visa = !(txt_visa.Text == "0") && !(txt_visa.Text == "") ? Convert.ToDouble(txt_visa.Text) + Convert.ToDouble(lbl_remind.Text) : Convert.ToDouble(txt_visa.Text);
            }
            //===============insert invoice and print 
            lbl_invoice_number.Text = generat_invoice_number();

            insert_receve();
            if (chk_print_inv.Checked == false)
            {
                XtraReport xtraReport = XtraReport.FromFile("forms\\receipt_printer_pos.repx", true);
                xtraReport.Parameters["parameter1"].Value = lbl_invoice_number.Text;
                xtraReport.Parameters["parameter1"].Visible = false;
                xtraReport.PrinterName = Settings.Default.printer_name;
                xtraReport.PrintAsync("");
            }
            clear();
            group_recev.Visible = false;
            txt_cash.Text = "0";
            txt_visa.Text = "0";
            dgv_recv.Rows.Clear();
            group_recev.Visible = false;
        }
        private void pay_cash()
        {
            if (txt_visa.Text == "")
                txt_visa.Text = "0";
            if (txt_cash.Text == "")
                txt_cash.Text = "0";
            if (Convert.ToDouble(lbl_remind.Text) > 0.0 || Convert.ToDouble(txt_visa.Text) != 0.0 && Convert.ToDouble(lbl_remind.Text) != 0.0)
                return;
            if (Convert.ToDecimal(lbl_remind.Text) <= 0)
            {
                v.cash = !(txt_cash.Text == "0") && !(txt_cash.Text == "") ? Convert.ToDouble(txt_cash.Text) + Convert.ToDouble(lbl_remind.Text) : Convert.ToDouble(txt_cash.Text);
                v.visa = !(txt_visa.Text == "0") && !(txt_visa.Text == "") ? Convert.ToDouble(txt_visa.Text) + Convert.ToDouble(lbl_remind.Text) : Convert.ToDouble(txt_visa.Text);
            }
            //===============insert invoice and print 
            //lbl_invoice_number.Text = generat_invoice_number_ret();
            //barCodeControl1.Text = generat_invoice_number_ret();
            insert_pay();
            //XtraReport xtraReport = XtraReport.FromFile("forms\\receipt_printer_pos.repx", true);
            //xtraReport.Parameters["parameter1"].Value =lbl_invoice_number.Text;
            //xtraReport.Parameters["parameter2"].Value =lbl_shift_no.Caption;
            //xtraReport.Parameters["parameter1"].Visible = false;
            //xtraReport.Parameters["parameter2"].Visible = false;
            //xtraReport.PrinterName = Settings.Default.printer_name;
            //xtraReport.PrintAsync("");
            txt_calc.Text = lbl_reqer_mony.Text;
            clear();
            btn_resale_2.Checked = false;
           


            //----------------------------------
            group_recev.Visible = false;


        }
        private void perform_cash()
        {
            if (btn_resale_2.Checked == false && btn_receve.Enabled == true)
            {
                credit = false;
                calc_recev();
                recev_cash();
            }
            else if (btn_resale_2.Checked == true && btn_receve.Enabled == false)
            {
                credit = false;
                calc_recev();
                pay_cash();
                clear();
                btn_resale_2.Checked = false; btn_receve.Enabled = true;
            }
        }
        private void txt_discount_all_Leave(object sender, EventArgs e)
        {
            calc_discount_pres();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");



        }

        private void btn_recev_Click(object sender, EventArgs e)
        {
            perform_cash();
        }

        private void btn_cloes_Click(object sender, EventArgs e)
        {

            group_recev.Visible = false;
            txt_cash.Text = "0";
            txt_visa.Text = "0";
            dgv_recv.Rows.Clear();
        }

        private void txt_cash_TextChanged(object sender, EventArgs e)
        {
            calc_recev();
        }

        private void txt_cash_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgv_recv.Rows.Count != 0)
            {
                if (e.KeyCode == Keys.Down)
                    //    txt_visa.Select();
                    dgv_recv.Select();
                dgv_recv.Rows[0].Cells[3].Selected = true;
                if (e.KeyCode == Keys.Enter)
                {
                    recev_cash();
                }
                if (e.KeyCode == Keys.Escape)
                {
                    group_recev.Visible = false;
                    txt_visa.Text = "";
                    txt_cash.Text = "";
                    lbl_remind.Text = "";
                    dgv_recv.Rows.Clear();
                }
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    perform_cash();
                }
            }
            if (e.KeyCode != Keys.Escape)
                return;
            group_recev.Visible = false;
            txt_visa.Text = "";
            txt_cash.Text = "";
            lbl_remind.Text = "";
            dgv_recv.Rows.Clear();
        }

        private void txt_cash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (int)e.KeyChar != 46)
                e.Handled = true;
            if ((int)e.KeyChar != 46 || (sender as TextBox).Text.IndexOf('.') <= -1)
                return;
            e.Handled = true;
        }

        private void dgv_recv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                double sum = 0;
                for (int i = 0; i < dgv_recv.Rows.Count; i++)
                {
                    string dgv_null = dgv_recv.Rows[i].Cells[3].Value + "";
                    if (dgv_null == "") dgv_null = "0";
                    sum += Convert.ToDouble(dgv_null) * Convert.ToDouble(dgv_recv.Rows[i].Cells[2].Value);
                    //                    dgv_recv.Rows[i].Cells[3].Value= Convert.ToDouble(lbl_remind)-Convert.ToDouble(dgv_recv.Rows[i].Cells[2].Value)



                }
                txt_visa.Text = sum + "";


                if (dgv_recv.Rows.Count == 0) return;
                for (int i = 0; i < dgv_recv.Rows.Count; i++)
                {
                    string dgv_null = dgv_recv.Rows[i].Cells[3].Value + "";
                    if (dgv_null == "") dgv_null = "0";
                    double no = (Convert.ToDouble(lbl_reqer_mony.Text) / Convert.ToDouble(dgv_recv.Rows[i].Cells[2].Value)) - Convert.ToDouble(dgv_null);
                    dgv_recv.Rows[i].Cells[4].Value = Math.Round(no, 2) + "";
                }
                dgv_recv.CurrentRow.Cells[4].Value = Convert.ToDouble(lbl_remind.Text) / Convert.ToDouble(dgv_recv.CurrentRow.Cells[2].Value);
            }
            catch (Exception)
            {

            }
        }

        private void dgv_recv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv_recv, "no_recev");

        }

      

        private void rd_bavrage_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_bavrage.Checked==true)
            {
                DataTable dt = new DataTable();
                db.GetData_DGV("select distinct cat1 from items where cat1 <> '' and menu_name = 'مشروبات'", dt);
                dgv1.DataSource = dt;
            }
            else
            {
                DataTable dt = new DataTable();
                db.GetData_DGV("select distinct cat1 from items where cat1 <> '' and menu_name <> 'مشروبات'", dt);
                dgv1.DataSource = dt;
            }
        }

        private void btn_bend_barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lbl_invoice_number.Text = generat_invoice_number();
            if (dgv.Rows.Count == 0) return;
            //inser into pending invoice
            //num_table
            if(num_table.Value==0)
            {
                MessageBox.Show("يجب اختيار رقم السفرة");
                return;
            }
            //if num table == num table in database 
            // add to pos_pending 
            int num_table_in_db = Convert.ToInt32(db.GetData("select ISNULL(MAX(table_pos),0) from  pos_pending where table_pos='"+num_table.Value.ToString()+"'").Rows[0][0]+"");
            if (num_table_in_db != 0)
            {
                //update

                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    String old_inv = db.GetData("select ISNULL(MAX(pos_inv_no),0) from  pos_pending where table_pos='" + num_table.Value.ToString() + "'").Rows[0][0] + "";

                    if (!Convert.ToBoolean(dgv.Rows[i].Cells["exp"].Value))
                    {
                        db.Run("insert into pos_pending(pos_inv_no            ,         shift_no            ,                       code_items              ,                        name_items             ,                                         qty             ,                                      item_price                  ,                                         tot_bef             ,                                         discount             ,                                         tot_after_dis             ,                                        taxes              ,                                        incloud_taxes                 ,                                          taxes_value             ,      id_ware                                   ,                         f_unite,                                   name_unite                                           ,no,                                                           [exp]              ,            exp_date                        ,[type]                    ,     user_code    ,      user_name           ,vcs_code                  ,vcs_name,                       phone_vcs                 ,delivery_code             ,delivery_name,                time_h                                          ,date_d                                         ,cash_bal   ,visa_bal  ,opening_bal,discount_all,table_pos ) values('" +
                                                old_inv + "','" + lbl_shift_no.Caption + "','" + dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["item_price"].Value) + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_bef"].Value) + "         ," + Convert.ToDecimal(dgv.Rows[i].Cells["discount"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["taxes"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["incloud_taxes"].Value) + "'         ,'" + Convert.ToDecimal(dgv.Rows[i].Cells["taxes_value"].Value) + "','" + lbl_wares.Text + "'                           ,'" + dgv.Rows[i].Cells["f_unite"].Value + "'  ,'" + dgv.Rows[i].Cells["name_unite"].Value + "'         ,'" + dgv.Rows[i].Cells["no"].Value + "','" + (Convert.ToBoolean(dgv.Rows[i].Cells["exp"].Value)) + "',            Null              ,'" + dgv.Rows[i].Cells["type"].Value + "','" + v.usercode + "','" + lbl_user_name.Text + "','" + combo_code_vcs.Text + "','" + combo_name_vcs.Text + "','" + combo_phone_vcs.Text + "','" + combo_code_emp.Text + "','" + combo_name_emp.Text + "','" + DateTime.Now.ToString("hh:mm:ss") + "'        ,'" + DateTime.Now.ToString("MM-dd-yyyy") + "'     ,null       ,null      ,null       ,'" + txt_discount_all.Text + "','" + num_table.Value.ToString() + "')");

                    }
                    else if (Convert.ToBoolean(dgv.Rows[i].Cells["exp"].Value))
                    {
                        db.Run("insert into pos_pending(pos_inv_no            ,         shift_no            ,                       code_items              ,                        name_items             ,                                         qty             ,                                      item_price                  ,                                         tot_bef             ,                                         discount             ,                                         tot_after_dis             ,                                        taxes              ,                                        incloud_taxes                 ,                                          taxes_value             ,      id_ware                                   ,                         f_unite,                                   name_unite                                           ,no,                                                           [exp]              ,            exp_date                        ,[type]                    ,     user_code    ,      user_name           ,vcs_code                  ,vcs_name,                       phone_vcs                 ,delivery_code             ,delivery_name,                time_h                                          ,date_d                                         ,cash_bal   ,visa_bal  ,opening_bal,discount_all,table_pos) values('" +
                                               old_inv + "','" + lbl_shift_no.Caption + "','" + dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["item_price"].Value) + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_bef"].Value) + "         ," + Convert.ToDecimal(dgv.Rows[i].Cells["discount"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["taxes"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["incloud_taxes"].Value) + "'         ,'" + Convert.ToDecimal(dgv.Rows[i].Cells["taxes_value"].Value) + "','" + lbl_wares.Text + "'                           ,'" + dgv.Rows[i].Cells["f_unite"].Value + "'  ,'" + dgv.Rows[i].Cells["name_unite"].Value + "'         ,'" + dgv.Rows[i].Cells["no"].Value + "','" + (Convert.ToBoolean(dgv.Rows[i].Cells["exp"].Value)) + "',            '" + dgv.Rows[i].Cells["exp_date"].Value.ToString() + "'              ,'" + dgv.Rows[i].Cells["type"].Value + "','" + v.usercode + "','" + lbl_user_name.Text + "','" + combo_code_vcs.Text + "','" + combo_name_vcs.Text + "','" + combo_phone_vcs.Text + "','" + combo_code_emp.Text + "','" + combo_name_emp.Text + "','" + DateTime.Now.ToString("hh:mm:ss") + "'        ,'" + DateTime.Now.ToString("MM-dd-yyyy") + "'     ,null       ,null      ,null      ,'" + txt_discount_all.Text + "','" + num_table.Value.ToString() + "')");

                    }
                }
            }
            //new table 
            else
            {

                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if (!Convert.ToBoolean(dgv.Rows[i].Cells["exp"].Value))
                    {
                        db.Run("insert into pos_pending(pos_inv_no            ,         shift_no            ,                       code_items              ,                        name_items             ,                                         qty             ,                                      item_price                  ,                                         tot_bef             ,                                         discount             ,                                         tot_after_dis             ,                                        taxes              ,                                        incloud_taxes                 ,                                          taxes_value             ,      id_ware                                   ,                         f_unite,                                   name_unite                                           ,no,                                                           [exp]              ,            exp_date                        ,[type]                    ,     user_code    ,      user_name           ,vcs_code                  ,vcs_name,                       phone_vcs                 ,delivery_code             ,delivery_name,                time_h                                          ,date_d                                         ,cash_bal   ,visa_bal  ,opening_bal,discount_all,table_pos ) values('" +
                                                lbl_invoice_number.Text + "','" + lbl_shift_no.Caption + "','" + dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["item_price"].Value) + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_bef"].Value) + "         ," + Convert.ToDecimal(dgv.Rows[i].Cells["discount"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["taxes"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["incloud_taxes"].Value) + "'         ,'" + Convert.ToDecimal(dgv.Rows[i].Cells["taxes_value"].Value) + "','" + lbl_wares.Text + "'                           ,'" + dgv.Rows[i].Cells["f_unite"].Value + "'  ,'" + dgv.Rows[i].Cells["name_unite"].Value + "'         ,'" + dgv.Rows[i].Cells["no"].Value + "','" + (Convert.ToBoolean(dgv.Rows[i].Cells["exp"].Value)) + "',            Null              ,'" + dgv.Rows[i].Cells["type"].Value + "','" + v.usercode + "','" + lbl_user_name.Text + "','" + combo_code_vcs.Text + "','" + combo_name_vcs.Text + "','" + combo_phone_vcs.Text + "','" + combo_code_emp.Text + "','" + combo_name_emp.Text + "','" + DateTime.Now.ToString("hh:mm:ss") + "'        ,'" + DateTime.Now.ToString("MM-dd-yyyy") + "'     ,null       ,null      ,null       ,'" + txt_discount_all.Text + "','" + num_table.Value.ToString() + "')");

                    }
                    else if (Convert.ToBoolean(dgv.Rows[i].Cells["exp"].Value))
                    {
                        db.Run("insert into pos_pending(pos_inv_no            ,         shift_no            ,                       code_items              ,                        name_items             ,                                         qty             ,                                      item_price                  ,                                         tot_bef             ,                                         discount             ,                                         tot_after_dis             ,                                        taxes              ,                                        incloud_taxes                 ,                                          taxes_value             ,      id_ware                                   ,                         f_unite,                                   name_unite                                           ,no,                                                           [exp]              ,            exp_date                        ,[type]                    ,     user_code    ,      user_name           ,vcs_code                  ,vcs_name,                       phone_vcs                 ,delivery_code             ,delivery_name,                time_h                                          ,date_d                                         ,cash_bal   ,visa_bal  ,opening_bal,discount_all,table_pos) values('" +
                                               lbl_invoice_number.Text + "','" + lbl_shift_no.Caption + "','" + dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["item_price"].Value) + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_bef"].Value) + "         ," + Convert.ToDecimal(dgv.Rows[i].Cells["discount"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["taxes"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["incloud_taxes"].Value) + "'         ,'" + Convert.ToDecimal(dgv.Rows[i].Cells["taxes_value"].Value) + "','" + lbl_wares.Text + "'                           ,'" + dgv.Rows[i].Cells["f_unite"].Value + "'  ,'" + dgv.Rows[i].Cells["name_unite"].Value + "'         ,'" + dgv.Rows[i].Cells["no"].Value + "','" + (Convert.ToBoolean(dgv.Rows[i].Cells["exp"].Value)) + "',            '" + dgv.Rows[i].Cells["exp_date"].Value.ToString() + "'              ,'" + dgv.Rows[i].Cells["type"].Value + "','" + v.usercode + "','" + lbl_user_name.Text + "','" + combo_code_vcs.Text + "','" + combo_name_vcs.Text + "','" + combo_phone_vcs.Text + "','" + combo_code_emp.Text + "','" + combo_name_emp.Text + "','" + DateTime.Now.ToString("hh:mm:ss") + "'        ,'" + DateTime.Now.ToString("MM-dd-yyyy") + "'     ,null       ,null      ,null      ,'" + txt_discount_all.Text + "','" + num_table.Value.ToString() + "')");

                    }
                }
            }
            generat_invoice_number();
            clear();
            dgv.Rows.Clear();
        }

        private void btn_pinding_list_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            group_pending.Visible = true;
            DataTable dt = new DataTable();
            //            db.GetData_DGV("select 0 as no_pen,pos_inv_no  as inv from pos_pending  where shift_no='"+lbl_shift_no.Caption+"'", dt);
            db.GetData_DGV("select distinct pos_inv_no  as inv,table_pos from pos_pending  where shift_no='" + lbl_shift_no.Caption + "'", dt);
            //   db.GetData_DGV("select distinct pos_inv_no  as inv from pos_pending  ", dt);

            dgv_pending.DataSource = dt;
        }

        private void btn_pending_close_Click(object sender, EventArgs e)
        {
            group_pending.Visible = false;
        }

        private void btn_del_pending_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                db.Run("delete from pos_pending where pos_inv_no='" + dgv_pending.CurrentRow.Cells[1].Value + "'");
                db.GetData_DGV("select distinct pos_inv_no  as inv from pos_pending  where shift_no='" + lbl_shift_no.Caption + "'", dt);
                dgv_pending.DataSource = dt;
            }
            catch (Exception)
            {
            }
        }

        private void dgv_pending_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //get invoice in dgv
            //clear();
            dgv.Rows.Clear();
            DataTable dt = new DataTable();
            num_table.Value = Convert.ToInt32(db.GetData("select table_pos from  pos_pending  where  pos_inv_no='" + dgv_pending.CurrentRow.Cells[1].Value + "'").Rows[0][0] + "");
            db.GetData_DGV("select code_items ,name_items ,name_unite ,f_unite ,[exp] ,[type] ,null , 0 , qty ,item_price ,0 , 0 , discount , 0 ,taxes ,0 ,0 ,id_ware ,(select isnull(max(couta_type) ,0 ) from items where code_items=pos_pending.code_items),discount_all from pos_pending where pos_inv_no='" + dgv_pending.CurrentRow.Cells[1].Value + "'", dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv.Rows.Add(null, dt.Rows[i][0] + "", dt.Rows[i][1] + "", dt.Rows[i][2] + "", dt.Rows[i][3] + "", dt.Rows[i][4] + "", dt.Rows[i][5] + "", dt.Rows[i][6] + "", dt.Rows[i][7] + "", dt.Rows[i][8] + "", dt.Rows[i][9] + "", dt.Rows[i][10] + "", dt.Rows[i][11] + "", dt.Rows[i][12] + "", dt.Rows[i][13] + "", dt.Rows[i][14] + "", dt.Rows[i][15] + "", dt.Rows[i][16] + "", dt.Rows[i][17] + "", dt.Rows[i][18] + "");//, dt.Rows[i][19]+"", dt.Rows[i][20]+""
            }
            txt_discount_all.Text = dt.Rows[0][19] + "";
            no_invoice_pending = dgv_pending.CurrentRow.Cells[1].Value + "";

            calc_all();
            //----------------delete pend invoice
            try
            {
                DataTable dtt = new DataTable();
                db.Run("delete from pos_pending where pos_inv_no='" + dgv_pending.CurrentRow.Cells[1].Value + "'");
                db.GetData_DGV("select distinct pos_inv_no  as inv from pos_pending  where shift_no='" + lbl_shift_no.Caption + "'", dtt);
                dgv_pending.DataSource = dtt;
                group_pending.Visible = true;
            }
            catch (Exception)
            {
            }
        }

        private void dgv_pending_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void dgv_pending_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv_pending, "no_pen");

        }

     
      
      

       
        private void txt_discount_all_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txt_discount_all_Leave_1(object sender, EventArgs e)
        {
            clac_discount_all();
        }

        private void txt_pres_descount_all_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txt_pres_descount_all_Leave(object sender, EventArgs e)
        {
            calc_discount_pres();
        }
        //=================================================
        private void btn_resale_2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (btn_resale_2.Checked == true)
            {
                //if (dgv.Rows.Count>0)
                {
                    clear();
                    dgv.Rows.Clear();
                    lbl_resale.Visible = true;
                    lbl_resale_tit.Visible = true;
                    txt_resale.Visible = true;
                    btn_receve.Enabled = false;
                    btn_pay.Enabled = true;
                    lbl_reqer_mony.Text = lbl_tot.Text;
                    txt_cash.Select();
                    txt_discount_all.ReadOnly = true;
                    txt_pres_descount_all.ReadOnly = true;
                }

            }
            else if (btn_resale_2.Checked == false)
            {
                //if (dgv.Rows.Count > 0)
                {
                    clear();
                    dgv.Rows.Clear();

                    lbl_resale.Visible = false;
                    lbl_resale_tit.Visible = false;
                    txt_resale.Visible = false;
                    btn_receve.Enabled = true;
                    btn_pay.Enabled = false;
                    txt_discount_all.ReadOnly = false;
                    txt_pres_descount_all.ReadOnly = false;
                }
            }
        }
        private void get_re_invoice()
        {
            if (db.GetData("select isnull(max(pos_inv_no),0) from pos_dt where pos_inv_no='" + txt_resale.Text + "' and state='sal'").Rows[0][0].ToString() == "0")
            {
                MessageBox.Show("الفاتوره غير موجودة");
                return;
            }
            combo_code_vcs.Text = db.GetData("select isnull(max(vcs_code),0) from pos_dt where pos_inv_no='" + txt_resale.Text + "'").Rows[0][0].ToString();
            combo_name_vcs.Text = db.GetData("select isnull(max(vcs_name),0) from pos_dt where pos_inv_no='" + txt_resale.Text + "'").Rows[0][0].ToString();
            combo_phone_vcs.Text = db.GetData("select isnull(max(phone_vcs),0) from pos_dt where pos_inv_no='" + txt_resale.Text + "'").Rows[0][0].ToString();
            lbl_vcs_address.Text = db.GetData("select isnull(max([address]),'-') from vcs where vcs_code='" + combo_code_vcs.Text + "'").Rows[0][0].ToString();
            txt_discount_all.Text = db.GetData("select isnull(max([discount_all]),0) from pos_dt where pos_inv_no='" + txt_resale.Text + "'").Rows[0][0].ToString();

            DataTable dt = new DataTable();
            db.GetData_DGV("select code_items ,name_items ,name_unite ,f_unite ,[exp] ,[type] ,null , 0 , qty ,item_price ,0 , 0 , discount , 0 ,taxes ,0 ,0 ,id_ware ,(select isnull(max(couta_type) ,0 ) from items where code_items=pos_dt.code_items) from pos_dt where pos_inv_no='" + txt_resale.Text + "'", dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv.Rows.Add(null, dt.Rows[i][0] + "", dt.Rows[i][1] + "", dt.Rows[i][2] + "", dt.Rows[i][3] + "", dt.Rows[i][4] + "", dt.Rows[i][5] + "", dt.Rows[i][6] + "", dt.Rows[i][7] + "", dt.Rows[i][8] + "", dt.Rows[i][9] + "", dt.Rows[i][10] + "", dt.Rows[i][11] + "", dt.Rows[i][12] + "", dt.Rows[i][13] + "", dt.Rows[i][14] + "", dt.Rows[i][15] + "", dt.Rows[i][16] + "", dt.Rows[i][17] + "", dt.Rows[i][18] + "");//, dt.Rows[i][19]+"", dt.Rows[i][20]+""
            }
            calc_all();
        }

        private void txt_resale_KeyDown(object sender, KeyEventArgs e)
        {
            //1- found invoice if invoice founded == true     contune
            //2-not found invoice 
            // 2-1 not found new return 
            //2-2 double return
            if (e.KeyCode == Keys.Enter)
            {
                if (db.GetData("select isnull(MAX(pos_inv_no),0) from pos_dt where pos_inv_no='" + txt_resale.Text + "' and state='sal'").Rows[0][0].ToString() != "0")
                {
                    //if more 3 days

                    int c = Convert.ToInt32(db.GetData("select isnull(max(period_time_rsal_pos),0) from info_co").Rows[0][0].ToString());
                    int dp = Convert.ToInt32(db.GetData("select top 1 Day(date_d) from pos_dt where pos_inv_no='" + txt_resale.Text + "'").Rows[0][0].ToString());
                    int mp = Convert.ToInt32(db.GetData("select top 1 Month(date_d) from pos_dt where pos_inv_no='" + txt_resale.Text + "'").Rows[0][0].ToString());
                    int yp = Convert.ToInt32(db.GetData("select top 1 Year(date_d) from pos_dt where pos_inv_no='" + txt_resale.Text + "'").Rows[0][0].ToString());

                    int d = Convert.ToInt32(DateTime.Now.ToString("dd"));
                    int m = Convert.ToInt32(DateTime.Now.ToString("MM"));
                    int y = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
                    DateTime firstDate = new DateTime(yp, mp, dp);
                    DateTime secondDate = new DateTime(y, m, d);

                    TimeSpan diff1 = secondDate - firstDate;
                    string def = diff1 + "";
                    string def_newString = def.Replace(":", "0");
                    double def_double = Convert.ToDouble(def_newString);

                    if (def_double < c)
                    {
                        txt_discount_all.Text = "0";
                        txt_pres_descount_all.Text = "0";
                        //MessageBox.Show("yes return");
                        dgv.Rows.Clear();
                        get_re_invoice();
                        //calc_discount_pres();
                        clac_discount_all();

                    }
                    else
                    {
                        MessageBox.Show("يوم " + c + "\n" + "لايمكن استرجاع الفاتوره لانقضاء اكثر من ");
                    }

                }
                else
                {
                    XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "تم ارتجاع الفاتورة من قبل       \n لايمكن استرجاع الفاتورة مرتين", "رسالة خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
        }

        private void btn_search_Expensses_Click(object sender, EventArgs e)
        {
            if (rdcustomer.Checked)
            {
                all_comb.load_customer_only_name(combo_acc_expenss);

                combo_acc_expenss.Text = "";
                lbl_acc_expensses.Text = "0";
            }
            if (rdvendor.Checked)
            {
                all_comb.load_vendor_only_name(combo_acc_expenss);
                combo_acc_expenss.Text = "";
                lbl_acc_expensses.Text = "0";
            }
            if (rd_account.Checked)
            {
                all_comb.load_account_name_specific_account(combo_acc_expenss);

                combo_acc_expenss.Text = "";
                lbl_acc_expensses.Text = "0";
            }
        }

        private void btn_conferm_Click(object sender, EventArgs e)
        {
            //1- get data to make insert Entry

            //2-get current balance from pos cash and update current cash 

            //3-make entry dt and hd 

            //4-claer all field 

            //=====================
            string shift_state_valid = db.GetData("select isnull(max(lock ),0)from pos_shift where emp_code='" + v.usercode + "'").Rows[0][0].ToString();
            if (shift_state_valid == "0")
            {
                MessageBox.Show("تم إغلاق الوردية ....يجب فتح وردية جيدة");
                return;
            }
            if (num_amount_exp.Value == 0)
            {
                MessageBox.Show("يجب ادخال مبلغ");
                return;
            }
            if (txt_desc.Text == "")
            {
                MessageBox.Show("يجب ادخال وصف للمصروف");
                return;
            }
            if ("0" == db.GetData("select isnull(max(rootid),0) from tree where rootid='" + lbl_acc_expensses.Text + "' and type_acc='c'").Rows[0][0].ToString())
            {
                MessageBox.Show("يجب إختيار حساب");
                return;
            }

            string cash_main = db.GetData("select cash_main from pos_cash_account where user_code='" + v.usercode + "' ").Rows[0][0].ToString();
            string code_book = db.GetData("select code_book from pos_cash_account where user_code='" + v.usercode + "' ").Rows[0][0].ToString();


            //insert entry_hd
            string code_entry_dt = db.GetData("select (max(convert(int,(right( CODE_ENTRY , len(CODE_ENTRY)-3)))))+1 from entry WHERE code_book='" + code_book + "'").Rows[0][0].ToString();
            string code_entry_hd = db.GetData("select (max(convert(int,(right( CODE_ENTRY , len(CODE_ENTRY)-3)))))+1 from entry_hd WHERE code_book='" + code_book + "'").Rows[0][0].ToString();

            if (code_entry_dt != code_entry_hd)
            {
                string error_code = db.GetData("select (max(convert(int,(right( CODE_ENTRY , len(CODE_ENTRY)-3))))) from entry_hd WHERE code_book='" + code_book + "'").Rows[0][0].ToString();
                db.Run("delete from entry_hd where code_entry ='" + code_book + error_code + "'");
            }
            string text_code = code_book + code_entry_dt;

            db.Run("insert into entry_hd ([code_entry],code_book) values ('" + text_code + "','" + code_book + "')");
            //entry_dt



            //1)MAIN CASH 
            //__________________________
            string cash = num_amount_exp.Value + "";
            string expenss = lbl_acc_expensses.Text;
            string code_entry = text_code;
            string x = "003";
            string x2 = "003";


            //1-expensse
            db.Run("insert into entry(  [code_entry]                           ,    acc_num             ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                               ,   sort                                                            , type_acc                                                       ,             depit                                                             ,                credit                 ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext )values('" +
                                     x + "'                           ,'" + expenss + "'     ,(select top 1 rootname from tree where rootid='" + expenss + "')               ,  (select top 1 RootLevel from tree where rootid='" + expenss + "')    ,  (select top 1 rootlevel_name from entry where acc_num='" + expenss + "'), (select top 1 sort from entry where acc_num='" + expenss + "')       ,  (select top 1 type_acc from entry where acc_num='" + expenss + "')  ,  '" + Convert.ToDecimal(cash) + "' ,0  , 'POS','" + code_book + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + lbl_shift_no.Caption + "','POS exp','POS','" + txt_desc.Text + " ')");

            //2-cash
            db.Run("insert into entry(  [code_entry]                           ,    acc_num             ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                               ,   sort                                                            , type_acc                                                       ,             depit                                                             ,                credit                 ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext )values('" +
                                     x + "'                           ,'" + cash_main + "'     ,(select top 1 rootname from tree where rootid='" + cash_main + "')               ,  (select top 1 RootLevel  from tree where rootid='" + cash_main + "')    ,  (select top 1 rootlevel_name from entry where acc_num='" + cash_main + "'), (select top 1 sort from entry where acc_num='" + cash_main + "')       ,  (select top 1 type_acc from entry where acc_num='" + cash_main + "')  , 0  , '" + Convert.ToDecimal(cash) + "' , 'POS','" + code_book + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + lbl_shift_no.Caption + "','POS exp cash','POS','" + txt_desc.Text + " ')"); ;


            //double cuurent_bal
            double bal_cash = Convert.ToDouble(db.GetData("select isnull(sum(balance),0) from pos_cash where code_cash='1' and shift_no='" + lbl_shift_no.Caption + "' and user_code='" + v.usercode + "'").Rows[0][0].ToString());
            db.Run("update pos_cash set balance ='" + (Convert.ToDouble(bal_cash) - (Convert.ToDouble(cash)) + "' where shift_no='" + lbl_shift_no.Caption + "' and user_code='" + v.usercode + "' and code_cash='1'"));
            if (db.GetData("select isnull(max(depit),0) from entry where code_entry='" + code_entry + "'").Rows[0][0] + "" != "0")
            {
                MessageBox.Show("تم حفظ ");

            }
            num_amount_exp.Value = 0;
            txt_desc.Text = "";
            combo_acc_expenss.Text = "";
            lbl_acc_expensses.Text = "0";

            //==============
        }

        private void combo_acc_expenss_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_acc_expensses.Text = db.GetData("select  RootID from tree where RootName='" + combo_acc_expenss.Text + "'").Rows[0][0].ToString();
            }
            catch (Exception)
            {
            }
        }

        private void btn_collect_roomNo_Click(object sender, EventArgs e)
        {
            credit = true;
            calc_recev();
            recev_cash();
        }
        private void btn_search_roomNo_Click(object sender, EventArgs e)
        {
            all_comb.load_room_recereved(combo_RoomNO);
               combo_RoomNO.Text = "";
            lbl_idkey.Text = "..";
            lbl_id_comapny.Text = "..";
            lbl_id_guest.Text = "..";
            lbl_name_guest.Text = "..";
            lbl_dateIn.Text = "..";
            lbl_dateOut.Text = "..";
        }
        private void btn_reset_roomNo_Click(object sender, EventArgs e)
        {
            combo_RoomNO.Text = "";
            lbl_idkey.Text = "..";
            lbl_id_comapny.Text = "..";
            lbl_id_guest.Text = "..";
            lbl_name_guest.Text = "..";
            lbl_dateIn.Text = "..";
            lbl_dateOut.Text = "..";
        }

        private void combo_RoomNO_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                db.GetData_DGV("select idkey,idComapny,id_guest,name,dateIn,dateOut from room_operation_hot where state=2 and id='" + combo_RoomNO.Text + "'", dt);
                lbl_idkey.Text = dt.Rows[0][0] + "";
                lbl_id_comapny.Text = dt.Rows[0][1] + "";
                lbl_id_guest.Text = dt.Rows[0][2] + "";
                lbl_name_guest.Text = dt.Rows[0][3] + "";
                lbl_dateIn.Text = Convert.ToDateTime(dt.Rows[0][4] + "").ToString("yyyy/MM/dd");
                lbl_dateOut.Text = Convert.ToDateTime(dt.Rows[0][5] + "").ToString("yyyy/MM/dd");
            }
            catch (Exception)
            {
                combo_RoomNO.Text = "";
                lbl_idkey.Text = "..";
                lbl_id_comapny.Text = "..";
                lbl_id_guest.Text = "..";
                lbl_name_guest.Text = "..";
                lbl_dateIn.Text = "..";
                lbl_dateOut.Text = "..";
            }
        }

        private void btn_hosptalty_Click(object sender, EventArgs e)
        {
            //credit = true;
            gift = true;
            calc_recev();
            recev_cash();
        }
    }
}