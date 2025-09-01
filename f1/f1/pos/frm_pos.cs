using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using f1.Properties;
using System.Text.RegularExpressions;
using System.Globalization;
using DevExpress.XtraReports.UI;

namespace f1.pos
{
    public partial class frm_pos : DevExpress.XtraEditors.XtraForm
    {
        public frm_pos()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(v.ico);
            db.Open();
        }
        //1)load form   cash bal , visa bal ,permission , inv no 
        //__________________________________________________________
        private void frm_pos_Load(object sender, EventArgs e)
        {
            dt_piker.Text = DateTime.Now.ToString("yyyy/MM/dd");
            lbl_user_code.Text = v.usercode;
            lbl_user_name.Text = v.username;
            if (db.GetData("select isnull(max(emp_code),0) from pos_shift where lock='1' and emp_code='" + v.usercode + "'").Rows[0][0].ToString() != v.usercode)
            {
                xtraTabControl1.Visible = false;
                //btn_refresh.Enabled = false;
            }
            else
            {
                string shift_numer = db.GetData("select shift_no from pos_shift where lock='1' and emp_code='" + v.usercode + "' ").Rows[0][0].ToString();
                ++g;
                lbl_invoice_number.Text = shift_numer + lbl_user_code.Text + DateTime.Now.ToString("HHmmss") + g + "";
                lbl_shift_no.Caption = shift_numer;

                Decimal cash_bal = Convert.ToDecimal(db.GetData("select isnull(sum(balance),0) from pos_cash where  shift_no='" + lbl_shift_no.Caption + "' and user_code='" + v.usercode + "' and code_cash='1'").Rows[0][0].ToString());
                Decimal visa_bal = Convert.ToDecimal(db.GetData("select isnull(sum(balance),0) from pos_cash where  shift_no='" + lbl_shift_no.Caption + "' and user_code='" + v.usercode + "' and code_cash='2'").Rows[0][0].ToString());
                lbl_cash_balance.Text = cash_bal + "";
                lbl_visa_bal.Text = visa_bal + "";
                txt_barcode.Select();
                if (chk_sales.Checked)
                {
                    combo_code_vcs.Visible = true;
                    combo_name_vcs.Visible = true;
                    combo_phone_vcs.Visible = true;
                }
                else
                {
                    combo_code_vcs.Visible = false;
                    combo_name_vcs.Visible = false;
                    combo_phone_vcs.Visible = false;
                    combo_code_vcs.Text = "";
                    combo_name_vcs.Text = "";
                    combo_phone_vcs.Text = "";
                }
                chk_bal_ware.Checked = Settings.Default.chk_bal_ware;
                chk_search_lang.Checked = Settings.Default.chk_search_lang;
                chk_sales.Checked = Settings.Default.chk_sales;
                chk_no_taxes.Checked = Settings.Default.no_taxes;
               // btn_print_last.PerformClick();
                load_permission();
                cash_balance();
            }

        }
        private void cash_balance()
        {
            lbl_cash_1.Text = db.GetData("select isnull(SUM(balance),0) from pos_cash where shift_no='"+lbl_shift_no.Caption+"'and code_cash='1' ").Rows[0][0].ToString();

        }
        private static bool return_inv_without_noinv = false;
        private static bool blow_cost = false;
        private void load_permission()
        {
            //// lbl_over_draft.Text = db.GetData("select over_draft from info_co").Rows[0][0].ToString();
            btn_inv_pending.Enabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='pind_inv'").Rows[0][0].ToString());
            btn_pinding.Enabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='pind_inv'").Rows[0][0].ToString());
            btn_del_delete_invoice.Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='delet_inv'").Rows[0][0].ToString());
            page_delete.PageEnabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='delet_inv'").Rows[0][0].ToString());
            page_delete.PageEnabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='delet_inv'").Rows[0][0].ToString());
            page_expenses.PageEnabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='expensses'").Rows[0][0].ToString());

            btn_resale_2.Enabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='return_inv'").Rows[0][0].ToString());
            return_inv_without_noinv = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='return_inv_without_noinv'").Rows[0][0].ToString());
            btn_add_customer.Enabled= Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='vcs_code'").Rows[0][0].ToString());
            chk_sales.Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='vcs_show'").Rows[0][0].ToString());
            dgv.Columns["price_inc_tax"].ReadOnly= Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='sale_price'").Rows[0][0].ToString());
            dgv.Columns["item_price"].ReadOnly = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='sale_price'").Rows[0][0].ToString());
            dgv.Columns["discount"].ReadOnly= Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='discount_rows'").Rows[0][0].ToString());
            txt_discount_all.ReadOnly= Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='discount'").Rows[0][0].ToString());
            txt_pres_descount_all.ReadOnly = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='discount'").Rows[0][0].ToString());

            blow_cost = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='blow_cost'").Rows[0][0].ToString());
            //page_expenses.PageEnabled = false;
            //page_delete.PageEnabled = false;

            //blow_cost >>>not complit
            //for (int i = 0; i < dgv.Rows.Count; i++)
            //{
            //    double cost = Convert.ToDouble(db.GetData("select isnull(max(cost),0) from wares where code_items='"+dgv.Rows[i].Cells["code_items"].Value+""+"'").Rows[0][0].ToString());
            //    if (Convert.ToDouble(dgv.Rows[i].Cells[0].Value + "") < cost) MessageBox.Show("لايمكن البيع تحت سعر التكلفة");
            //}

            lbl_stat_cost_items_n.Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='state'").Rows[0][0].ToString());
            lbl_stat_min_items_n.Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='state'").Rows[0][0].ToString());
            lbl_stat_max_items_n.Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='state'").Rows[0][0].ToString());
            lbl_state_vcs_bal_n.Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='state'").Rows[0][0].ToString());
            lbl_cash_1.Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='cash'").Rows[0][0].ToString());
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



            //btn_add_customer.Enabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='code_customer'").Rows[0][0].ToString());
            //btn_add_items.Enabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='items'").Rows[0][0].ToString());
            //btn_open_shift.Enabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='shift'").Rows[0][0].ToString());
            ////chk_sales.Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='pos_show_customer'").Rows[0][0].ToString());
            //// dgv.Columns["discount"].ReadOnly = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='discount_rows'").Rows[0][0].ToString());
//            dgv.Columns["name_unite"].ReadOnly = true;
            //dgv.Columns["name_unite"].Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='dgv_unite'").Rows[0][0].ToString());
            //dgv.Columns["item_price"].Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='dgv_price'").Rows[0][0].ToString());
            //dgv.Columns["price_inc_tax"].Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='dgv_price_incl'").Rows[0][0].ToString());
            //dgv.Columns["tot_bef"].Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='dgv_tot_bef_discount'").Rows[0][0].ToString());
            //// dgv.Columns["discount"].Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='dgv_discount'").Rows[0][0].ToString());
            //dgv.Columns["tot_after_dis"].Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='dgv_after_diescount'").Rows[0][0].ToString());
            //dgv.Columns["taxes"].Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='dgv_taxes'").Rows[0][0].ToString());
            //dgv.Columns["incloud_taxes"].Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='dgv_incloud_taxes_tot'").Rows[0][0].ToString());
            //dgv.Columns["taxes_value"].Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='dgv_taxes_value'").Rows[0][0].ToString());
            //dgv.Columns["exp_date"].Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='dgv_exp_date'").Rows[0][0].ToString());
            ////dt_exp.Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='dgv_exp_date'").Rows[0][0].ToString());
            ////btn_add_exp.Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='dgv_exp_date'").Rows[0][0].ToString());
            ////lbl_exp.Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='dgv_exp_date'").Rows[0][0].ToString());
            //xtraTabPage2.PageVisible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='del_inv'").Rows[0][0].ToString());


            //----------------------
            // lbl_over_draft.Text = db.GetData("select over_draft from info_co").Rows[0][0].ToString();
            //btn_inv_pending.Enabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='peniding_inv'").Rows[0][0].ToString());
            //btn_pinding.Enabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='peniding_inv'").Rows[0][0].ToString());
            //// btn_delete_inv.Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='del_inv'").Rows[0][0].ToString());
            //chk_sales.Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='code_customer'").Rows[0][0].ToString());
            //btn_add_customer.Enabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='code_customer'").Rows[0][0].ToString());
            //btn_add_items.Enabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='items'").Rows[0][0].ToString());
            //btn_open_shift.Enabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='shift'").Rows[0][0].ToString());
            //btn_resale_2.Enabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='pos_retuern_inv'").Rows[0][0].ToString());
            ////lbl_stat_cost_items_n.Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='pos_state'").Rows[0][0].ToString());
            ////lbl_stat_min_items_n.Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='pos_state'").Rows[0][0].ToString());
            //lbl_stat_max_items_n.Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='pos_state'").Rows[0][0].ToString());
            //lbl_state_vcs_bal_n.Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='pos_state'").Rows[0][0].ToString());
            //lbl_cash_s.Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='pos_cash'").Rows[0][0].ToString());
            //lbl_visa_s.Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='pos_visa'").Rows[0][0].ToString());
            //chk_sales.Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='pos_show_customer'").Rows[0][0].ToString());
            // dgv.Columns["discount"].ReadOnly = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='discount_rows'").Rows[0][0].ToString());
            //dgv.Columns["name_unite"].ReadOnly = true;
            //dgv.Columns["name_unite"].Visible = true;
            //dgv.Columns["item_price"].Visible = true;
            //dgv.Columns["price_inc_tax"].Visible = true;
            //dgv.Columns["tot_bef"].Visible = false;
            //dgv.Columns["discount"].Visible = false;
            //dgv.Columns["tot_after_dis"].Visible = false;
            //dgv.Columns["taxes"].Visible = false;
            //dgv.Columns["incloud_taxes"].Visible = true;
            //dgv.Columns["taxes_value"].Visible = false;
            //dgv.Columns["exp_date"].Visible = false;
            //dt_exp.Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='dgv_exp_date'").Rows[0][0].ToString());
            //btn_add_exp.Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='dgv_exp_date'").Rows[0][0].ToString());
            //lbl_exp.Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='dgv_exp_date'").Rows[0][0].ToString());

        }
        private void btn_last_invoice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string str = db.GetData("select isnull(max(pos_inv_no),0) from pos_dt where pos_dt_id='" + db.GetData("select isnull(max(pos_dt_id),0) from pos_dt where shift_no='" + this.lbl_shift_no.Caption + "'").Rows[0][0].ToString() + "'").Rows[0][0].ToString();
            XtraReport xtraReport = XtraReport.FromFile("forms\\receipt_printer_pos.repx", true);
            xtraReport.Parameters["parameter1"].Value = str;
           // xtraReport.Parameters["parameter2"].Value = lbl_shift_no.Caption;
           xtraReport.Parameters["parameter1"].Visible = false;
          //  xtraReport.Parameters["parameter2"].Visible = false;
            XtraReportPreviewExtensions.ShowPreview(xtraReport);
            

        }
        //====================function
        private void clear()
        {

            dgv.Rows.Clear();
            //   dgv_search.Rows.Clear();

            lbl_discount.Text = "0";
            lbl_requer.Text = "0";
            lbl_tot.Text = "0";

            //txt_calc.Text = "";
            //txt_search.Text = "";
            txt_barcode.Text = "";
            txt_resale.Text = "";
            v.net_recev = 0;
            lbl_visa.Text = "0";
            lbl_cash.Text = "0";

            txt_cash.Text = "0";
            txt_visa.Text = "0";
            
                lbl_reqer_mony.Text = "0";
            lbl_remind.Text = "0";

            combo_code_vcs.Text = "";
            combo_name_vcs.Text = "";
            combo_phone_vcs.Text = "";
            lbl_vcs_address.Text = ",,,";
            txt_discount_all.Text = "";
            txt_pres_descount_all.Text = "";


            //  numericUpDown1.Value = 0;
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
        private string generat_invoice_number_ret()
        {
            string str = db.GetData("select shift_no from pos_shift where lock='1' ").Rows[0][0].ToString();
            ++g;
            return  2+ str + v.usercode + DateTime.Now.ToString("HHmmss") + g;
        }
        private void add_in_dgv()
        {
            try
            {
                    string main_code = dgv_search.CurrentRow.Cells["code_items_s"].Value + "";
                    if ("1" == db.GetData("select isnull(max(couta_type),0) from items where code_items='" + dgv_search.CurrentRow.Cells["couta_type_s"].Value.ToString() + "'").Rows[0][0].ToString())
                    {
                        if (Convert.ToInt32(db.GetData("select isnull( COUNT( datediff(day,last_date,(GETDATE())) ),0) from couta where vcs_code='" + combo_code_vcs.Text + "' ").Rows[0][0].ToString()) != 0 && Convert.ToInt32(db.GetData("select isnull(max(couta_date_select),null) from couta where code_items='" + dgv_search.CurrentRow.Cells["couta_type_s"].Value.ToString() + "'").Rows[0][0].ToString()) < Convert.ToInt32(db.GetData("select top 1 datediff(day,last_date,(GETDATE())) from couta where vcs_code='" + combo_code_vcs.Text + "' order by last_date desc").Rows[0][0].ToString()))
                        {
                            XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "رصيد خلص من الكوتة  او يجب تكويد عميل في الاول لكي يتم صرف نظام الكوتة", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            txt_barcode.Clear();
                            return;
                        }
                        else
                        {
                            double num1 = Convert.ToDouble(db.GetData("select isnull(max((couta_qty-couta_bal)),null) from couta where code_items='" + dgv_search.CurrentRow.Cells["couta_type_s"].Value.ToString() + "' and vcs_code='" + combo_code_vcs.Text + "'").Rows[0][0].ToString());
                            int num2 = 0;
                            if (Convert.ToDouble(txt_qty.Text) > num1)
                            {
                                try
                                {
                                    num2 = Convert.ToInt32(db.GetData("select  datediff(day,last_date,(GETDATE())) from couta where vcs_code='" + combo_code_vcs.Text + "' order by last_date desc").Rows[0][0].ToString());
                                }
                                catch (Exception ex)
                                {
                                }
                                if (num2 >= 1)
                                {
                                    db.Run("update couta set couta_bal='0' where code_items='" + dgv_search.CurrentRow.Cells["couta_type_s"].Value.ToString() + "' and vcs_code='" + combo_code_vcs.Text + "'");
                                }
                                else
                                {
                                    XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, num1 + " \n  الرصيد اقل من الكوتة   ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    txt_barcode.Text = "";
                                    return;
                                }
                            }
                        }
                    }
                    if (lbl_over_draft.Text == "1")
                    {
                        dgv.Rows.Add(null, main_code, dgv_search.CurrentRow.Cells["name_items_s"].Value, dgv_search.CurrentRow.Cells["name_unite_s"].Value, dgv_search.CurrentRow.Cells["unit1_c"].Value, db.GetData("select [exp] from items where code_items='" + main_code + "'").Rows[0][0].ToString(), db.GetData("select type from items where code_items='" + main_code + "'").Rows[0][0].ToString(), null, 0, 1, dgv_search.CurrentRow.Cells["price_sale"].Value, 0, 0, 0, 0, dgv_search.CurrentRow.Cells["taxes_c"].Value, 0, 0, lbl_wares.Text, dgv_search.CurrentRow.Cells["couta_type_s"].Value);
                        //cheak >> addd offer if 1  mean yas found  offer else not found offer
                        if (db.GetData("select offer from items where code_items='" + main_code + "'").Rows[0][0].ToString() == "1")
                        {
                            //chaek is offer in date
                            if (db.GetData("select isnull(max(main_code),0) from offer where main_code='" + main_code + "' and dt1<= '" + DateTime.Now.ToString("MM-dd-yyyy") + "' and dt2>= '" + DateTime.Now.ToString("MM-dd-yyyy") + "'").Rows[0][0].ToString() == "0") return;
                            //1-get count offer
                            //2- get items sub items 
                            if (lbl_resale_tit.Visible == true) return;

                            DataTable dt_offer = new DataTable();
                            db.GetData_DGV("select sub_code,qty from offer where main_code='" + main_code + "'", dt_offer);

                            //3- add items 
                            for (int i = 0; i < dt_offer.Rows.Count; i++)
                            {
                                string sub_code = dt_offer.Rows[i][0] + "";
                                string name_code = db.GetData("select name_items from items where code_items='" + sub_code + "'").Rows[0][0].ToString();
                                string name_unite = db.GetData("select name_unite from items where code_items='" + sub_code + "'").Rows[0][0].ToString();
                                string unit1 = db.GetData("select unit1 from items where code_items='" + sub_code + "'").Rows[0][0].ToString();
                                string taxes = db.GetData("select taxes from items where code_items='" + sub_code + "'").Rows[0][0].ToString();
                                string couta_type = db.GetData("select couta_type from items where code_items='" + sub_code + "'").Rows[0][0].ToString();

                                dgv.Rows.Add(null, sub_code, name_code, name_unite, unit1, db.GetData("select [exp] from items where code_items='" + sub_code + "'").Rows[0][0].ToString(), db.GetData("select type from items where code_items='" + sub_code + "'").Rows[0][0].ToString(), null, 0, dt_offer.Rows[i][1] + "", 0, 0, 0, 0, 0, taxes, 0, 0, lbl_wares.Text, couta_type);
                            }

                        }
                    }
                    else
                    {
                        double num1 = 0.0;
                        try
                        {
                            num1 = Convert.ToDouble(db.GetData("select ((select isnull(sum(d.qty),0) from pos_dt as d left join pos_shift as s on d.shift_no=s.shift_no where s.lock='1'  and d.state ='sal' and d.code_items=items.code_items)-(select isnull(sum(d.qty),0) from pos_dt as d left join pos_shift as s on d.shift_no=s.shift_no where s.lock='1'  and d.state ='re' and d.code_items=items.code_items))  from items left join wares on items.code_items=wares.code_items where items.type='1'and qty > 0 and id_ware='" + lbl_wares.Text + "' and items.code_items='" + (string)main_code + "'").Rows[0][0].ToString());

                        }
                        catch (Exception ex)
                        {
                            db.log_error(string.Concat(ex));
                        }
                        if (lbl_over_draft.Text == "2")
                        {
                            if (lbl_over_draft.Text == "2" && num1 <= 0.0)
                            {
                                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "لايوجد رصيد من الصنف ", "رصيد", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                dgv.Rows.Add(null, main_code, dgv_search.CurrentRow.Cells["name_items_s"].Value, dgv_search.CurrentRow.Cells["name_unite_s"].Value, dgv_search.CurrentRow.Cells["unit1_c"].Value, db.GetData("select [exp] from items where code_items='" + main_code + "'").Rows[0][0].ToString(), db.GetData("select type from items where code_items='" + main_code + "'").Rows[0][0].ToString(), null, 0, 1, dgv_search.CurrentRow.Cells["price_sale"].Value, 0, 0, 0, 0, dgv_search.CurrentRow.Cells["taxes_c"].Value, 0, 0, lbl_wares.Text, dgv_search.CurrentRow.Cells["couta_type_s"].Value);
                                //offer
                                //cheak >> addd offer if 1  mean yas found  offer else not found offer
                                if (lbl_resale_tit.Visible == true) return;
                                if (db.GetData("select offer from items where code_items='" + main_code + "'").Rows[0][0].ToString() == "1")
                                {
                                    //chaek is offer in date
                                    if (db.GetData("select isnull(max(main_code),0) from offer where main_code='" + main_code + "' and dt1<= '" + DateTime.Now.ToString("MM-dd-yyyy") + "' and dt2>= '" + DateTime.Now.ToString("MM-dd-yyyy") + "'").Rows[0][0].ToString() == "0") return;
                                    //1-get count offer
                                    //2- get items sub items 
                                    DataTable dt_offer = new DataTable();
                                    db.GetData_DGV("select sub_code,qty from offer where main_code='" + main_code + "'", dt_offer);

                                    //3- add items 
                                    for (int i = 0; i < dt_offer.Rows.Count; i++)
                                    {
                                        string sub_code = dt_offer.Rows[i][0] + "";
                                        string name_code = db.GetData("select name_items from items where code_items='" + sub_code + "'").Rows[0][0].ToString();
                                        string name_unite = db.GetData("select name_unite from items where code_items='" + sub_code + "'").Rows[0][0].ToString();
                                        string unit1 = db.GetData("select unit1 from items where code_items='" + sub_code + "'").Rows[0][0].ToString();
                                        string taxes = db.GetData("select taxes from items where code_items='" + sub_code + "'").Rows[0][0].ToString();
                                        string couta_type = db.GetData("select couta_type from items where code_items='" + sub_code + "'").Rows[0][0].ToString();

                                        dgv.Rows.Add(null, sub_code, name_code, name_unite, unit1, db.GetData("select [exp] from items where code_items='" + sub_code + "'").Rows[0][0].ToString(), db.GetData("select type from items where code_items='" + sub_code + "'").Rows[0][0].ToString(), null, 0, dt_offer.Rows[i][1] + "", 0, 0, 0, 0, 0, taxes, 0, 0, lbl_wares.Text, couta_type);
                                    }

                                }

                                //offer

                                return;
                            }
                            else if (lbl_over_draft.Text == "2" || num1 >= 1.0)
                            {
                                dgv.Rows.Add(null, main_code, dgv_search.CurrentRow.Cells["name_items_s"].Value, dgv_search.CurrentRow.Cells["name_unite_s"].Value, dgv_search.CurrentRow.Cells["unit1_c"].Value, db.GetData("select [exp] from items where code_items='" + main_code + "'").Rows[0][0].ToString(), db.GetData("select type from items where code_items='" + main_code + "'").Rows[0][0].ToString(), null, 0, 1, dgv_search.CurrentRow.Cells["price_sale"].Value, 0, 0, 0, 0, dgv_search.CurrentRow.Cells["taxes_c"].Value, 0, 0, lbl_wares.Text, dgv_search.CurrentRow.Cells["couta_type_s"].Value);
                                //offer
                                //cheak >> addd offer if 1  mean yas found  offer else not found offer
                                if (lbl_resale_tit.Visible == true) return;

                                if (db.GetData("select offer from items where code_items='" + main_code + "'").Rows[0][0].ToString() == "1")
                                {
                                    //chaek is offer in date
                                    if (db.GetData("select isnull(max(main_code),0) from offer where main_code='" + main_code + "' and dt1<= '" + DateTime.Now.ToString("MM-dd-yyyy") + "' and dt2>= '" + DateTime.Now.ToString("MM-dd-yyyy") + "'").Rows[0][0].ToString() == "0") return;
                                    //1-get count offer
                                    //2- get items sub items 
                                    DataTable dt_offer = new DataTable();
                                    db.GetData_DGV("select sub_code,qty from offer where main_code='" + main_code + "'", dt_offer);

                                    //3- add items 
                                    for (int i = 0; i < dt_offer.Rows.Count; i++)
                                    {
                                        string sub_code = dt_offer.Rows[i][0] + "";
                                        string name_code = db.GetData("select name_items from items where code_items='" + sub_code + "'").Rows[0][0].ToString();
                                        string name_unite = db.GetData("select name_unite from items where code_items='" + sub_code + "'").Rows[0][0].ToString();
                                        string unit1 = db.GetData("select unit1 from items where code_items='" + sub_code + "'").Rows[0][0].ToString();
                                        string taxes = db.GetData("select taxes from items where code_items='" + sub_code + "'").Rows[0][0].ToString();
                                        string couta_type = db.GetData("select couta_type from items where code_items='" + sub_code + "'").Rows[0][0].ToString();

                                        dgv.Rows.Add(null, sub_code, name_code, name_unite, unit1, db.GetData("select [exp] from items where code_items='" + sub_code + "'").Rows[0][0].ToString(), db.GetData("select type from items where code_items='" + sub_code + "'").Rows[0][0].ToString(), null, 0, dt_offer.Rows[i][1] + "", 0, 0, 0, 0, 0, taxes, 0, 0, lbl_wares.Text, couta_type);
                                    }

                                }

                                //offer

                                return;
                            }
                        }
                        if (lbl_over_draft.Text == "3" && num1 <= 1.0)
                        {
                            XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "لايوجد رصيد من الصنف ", "رصيد", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                dgv.CurrentCell = dgv.Rows[dgv.Rows.Count - 1].Cells[0];
                calc_all();
            }
            catch (Exception ex)
            {
            //    db.log_error(string.Concat(ex));
            }
        }
        private void add_in_dgv_with_virber(string code_item_x)
        {
            if (this.txt_qty.Text == "")
                txt_qty.Text = "1";
            dgv.Rows.Add(null, code_items_a, name_items_a, name_unite_a, unit1, db.GetData("select [exp] from items where code_items='" + code_item_x + "'").Rows[0][0].ToString(), db.GetData("select type from items where code_items='" + code_item_x + "'").Rows[0][0].ToString(), null, 0, txt_qty.Text, price_items_a, 0, 0, 0, 0, taxes_a, 0, 0, lbl_wares.Text, couta_type_items_a);

            txt_qty.Text = "1";

            //offer
            string main_code = code_item_x;
            //cheak >> addd offer if 1  mean yas found  offer else not found offer
            if (db.GetData("select offer from items where code_items='" + main_code + "'").Rows[0][0].ToString() == "1")
            {
                //chaek is offer in date
                if (db.GetData("select isnull(max(main_code),0) from offer where main_code='" + main_code + "' and dt1<= '" + DateTime.Now.ToString("MM-dd-yyyy") + "' and dt2>= '" + DateTime.Now.ToString("MM-dd-yyyy") + "'").Rows[0][0].ToString() == "0") return;

                        if (lbl_resale_tit.Visible == true)  return;


                //1-get count offer
                //2- get items sub items 
                DataTable dt_offer = new DataTable();
                db.GetData_DGV("select sub_code,qty from offer where main_code='" + main_code + "'", dt_offer);

                //3- add items 
                for (int i = 0; i < dt_offer.Rows.Count; i++)
                {
                    string sub_code = dt_offer.Rows[i][0] + "";
                    string name_code = db.GetData("select name_items from items where code_items='" + sub_code + "'").Rows[0][0].ToString();
                    string name_unite = db.GetData("select name_unite from items where code_items='" + sub_code + "'").Rows[0][0].ToString();
                    string unit1 = db.GetData("select unit1 from items where code_items='" + sub_code + "'").Rows[0][0].ToString();
                    string taxes = db.GetData("select taxes from items where code_items='" + sub_code + "'").Rows[0][0].ToString();
                    string couta_type = db.GetData("select couta_type from items where code_items='" + sub_code + "'").Rows[0][0].ToString();

                    dgv.Rows.Add(null, sub_code, name_code, name_unite, unit1, db.GetData("select [exp] from items where code_items='" + sub_code + "'").Rows[0][0].ToString(), db.GetData("select type from items where code_items='" + sub_code + "'").Rows[0][0].ToString(), null, 0, dt_offer.Rows[i][1] + "", 0, 0, 0, 0, 0, taxes, 0, 0, lbl_wares.Text, couta_type);
                }

            }

            //offer
        }
        private void calc_current_user()
        {
            try
            {
                Decimal d1 = new Decimal(0);
                Decimal num1 = new Decimal(0);
                Decimal d2 = new Decimal(0);
                Decimal d3 = new Decimal(0);
                Decimal d4 = new Decimal(0);
                dgv.CurrentRow.Cells["tot_bef"].Value = (Convert.ToDecimal(dgv.CurrentRow.Cells["qty"].Value) * Convert.ToDecimal(dgv.CurrentRow.Cells["f_unite"].Value) * Convert.ToDecimal(dgv.CurrentRow.Cells["item_price"].Value));
                dgv.CurrentRow.Cells["discount"].Value = Convert.ToDecimal(dgv.CurrentRow.Cells["discount"].Value);
                dgv.CurrentRow.Cells["tot_after_dis"].Value = (Convert.ToDecimal(dgv.CurrentRow.Cells["tot_bef"].Value) - Convert.ToDecimal(dgv.CurrentRow.Cells["discount"].Value));
                dgv.CurrentRow.Cells["incloud_taxes"].Value = (Convert.ToDecimal(dgv.CurrentRow.Cells["tot_after_dis"].Value) * (1 + Convert.ToDecimal(dgv.CurrentRow.Cells["taxes"].Value)));
                dgv.CurrentRow.Cells["taxes_value"].Value = (Convert.ToDecimal(dgv.CurrentRow.Cells["tot_after_dis"].Value) * Convert.ToDecimal(dgv.CurrentRow.Cells["taxes"].Value));
                dgv.CurrentRow.Cells["price_inc_tax"].Value = (Convert.ToDecimal(dgv.CurrentRow.Cells["item_price"].Value) * Convert.ToDecimal(dgv.CurrentRow.Cells["taxes"].Value) + Convert.ToDecimal(dgv.CurrentRow.Cells["item_price"].Value));

                if (dgv.CurrentRow.Cells["coute_type_c"].Value.ToString() == "1")
                {
                    double num2 = Convert.ToDouble(db.GetData("select isnull(max((couta_qty-couta_bal)),null) from couta where code_items='" + dgv.CurrentRow.Cells["code_items"].Value + "' and vcs_code='" + combo_code_vcs.Text + "'").Rows[0][0].ToString());
                    if (Convert.ToDouble(dgv.CurrentRow.Cells["qty"].Value.ToString()) > num2)
                    {
                        dgv.Rows.Clear();
                        XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, " " + num2 + "الرصيد من الكوتة+\nالرصيد اقل من الكوتة ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                }
                for (int index = 0; index < dgv.Rows.Count; ++index)
                {
                    d1 += Convert.ToDecimal(dgv.Rows[index].Cells["tot_bef"].Value);
                  //  num1 += Convert.ToDecimal(dgv.Rows[index].Cells["discount"].Value);
                    d2 += Convert.ToDecimal(dgv.Rows[index].Cells["tot_after_dis"].Value);
                    d4 += Convert.ToDecimal(dgv.Rows[index].Cells["incloud_taxes"].Value);
                    d3 += Convert.ToDecimal(dgv.Rows[index].Cells["taxes_value"].Value);
                }
                if (txt_discount_all.Text == "") txt_discount_all.Text = "0";
                num1 = Convert.ToDecimal(txt_discount_all.Text);

                lbl_tot_befor.Text = string.Concat(Math.Round(d1, 2));
                lbl_tot_after_dis.Text = string.Concat(Math.Round(d2, 2));
                lbl_taxes_values.Text = string.Concat(Math.Round(d3, 2));
                if (d1 > new Decimal(0))
                {
                    lbl_tot_befor.Text = string.Concat(Math.Round(d1, 2));
                    lbl_tot_after_dis.Text = string.Concat(Math.Round(d2, 2));
                    lbl_taxes_values.Text = string.Concat(Math.Round(d3, 2));
                    lbl_incloud_taxes.Text = string.Concat(Math.Round(d4, 2));
                    lbl_requer.Text = string.Concat(Math.Round(d4 - num1, 2));
                    lbl_tot.Text = string.Concat(Math.Round(d4, 2));
                    lbl_discount.Text = string.Concat(Math.Round(num1, 2));

                }
                else
                {
                    XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "لايمكن إدخل رقم  اقل من صفر ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    lbl_tot_befor.Text = "0";
                    lbl_tot_after_dis.Text = "0";
                    lbl_incloud_taxes.Text = "0";
                    lbl_requer.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                db.log_error(string.Concat(ex));
            }
        }
        private void calc_all()
        {
             try
            {
                Decimal d1 =0;
                Decimal num1 = 0;
                Decimal d2 = 0;
                Decimal d3 = 0;
                Decimal d4 = 0;
                for (int i = 0; i < dgv.Rows.Count; ++i)
                {
                    if (chk_no_taxes.Checked)
                        dgv.Rows[i].Cells["taxes"].Value = "0";
                    if (dgv.Rows[i].Cells["coute_type_c"].Value + "" == "1")
                    {
                        double num2 = Convert.ToDouble(db.GetData("select isnull(max((couta_qty-couta_bal)),null) from couta where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and vcs_code='" + combo_code_vcs.Text + "'").Rows[0][0].ToString());
                        if (Convert.ToDouble(dgv.Rows[i].Cells["qty"].Value.ToString()) > num2)
                        {
                            dgv.Rows.Clear();
                            XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, " " + num2 + "الرصيد من الكوتة+\nالرصيد اقل من الكوتة ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            return;
                        }
                    }
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
        private void dgv_satue_dgv()
        {
            try
            {
               // lbl_state_vcs_bal_n.Text = db.GetData("select isnull(sum(depit)-sum(credit),0) from entry where acc_num='" + this.combo_code_vcs.Text + "'").Rows[0][0]+"";
                lbl_balance_items.Text = db.GetData("(select isnull(sum(qty),0)-(select isnull(sum(qty),0) from pos_dt p left join pos_shift s  on p.shift_no=s.shift_no   where s.lock= '1' and code_items='" + dgv.CurrentRow.Cells["code_items"].Value+"" + "') from wares where code_items='"+ dgv.CurrentRow.Cells["code_items"].Value+"" + "')").Rows[0][0]+"";
                lbl_cash_1.Text = db.GetData("select isnull(SUM(balance),0) from pos_cash where shift_no='" + lbl_shift_no.Caption + "'and code_cash='1' ").Rows[0][0]+"";

                lbl_stat_cost_items_n.Text = db.GetData("select cost from wares where code_items='" + dgv.CurrentRow.Cells["code_items"].Value+"" + "' and id_ware='" + lbl_wares.Text + "'").Rows[0][0]+"";

                lbl_stat_min_items_n.Text = db.GetData("select isnull(min (discount),0) from purchase_dt  where code_items ='" + this.dgv.CurrentRow.Cells["code_items"].Value+"" + "'").Rows[0][0]+"";
                lbl_stat_max_items_n.Text = db.GetData("select isnull(max (discount),0) from purchase_dt  where code_items ='" + this.dgv.CurrentRow.Cells["code_items"].Value+"" + "'").Rows[0][0]+"";

            }
            catch (Exception ex)
            {
                db.log_error(string.Concat((object)ex));
            }
        }
        //======================dgv
        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv);
           

        }
        //===================simple controls
        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 26)
            {
                dgv.Rows.RemoveAt(e.RowIndex);
            }
           // MessageBox.Show(e.ColumnIndex + "");
            dgv_satue_dgv();
           // calc_discount_pres();
            clac_discount_all();
        }
        private string code_items_a, name_items_a, name_unite_a, unit1, price_items_a, taxes_a, exp_a, type_a;//combo_add_items_SelectedIndexChanged
        private string couta_type_items_a;
        private void dgv_search_Click(object sender, EventArgs e)
        {
           
            //add_in_dgv();
        }
        private void dgv_search_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex != 1)
            //{
            //     if (btn_resale_2.Checked == false)
            //    {
            //        add_in_dgv();
            //    }
            //    else if(btn_resale_2.Checked == true && return_inv_without_noinv)
            //    {
            //        add_in_dgv();
            //    }
            //}



            //if (e.ColumnIndex == 26)
            //{
            //    dgv.Rows.RemoveAt(e.RowIndex);
            //}
            // MessageBox.Show(e.ColumnIndex + "");

        }
        private void btn_receve_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            string shift_state_valid = db.GetData("select isnull(max(lock ),0)from pos_shift where emp_code='"+v.usercode+"'").Rows[0][0].ToString();
            if (blow_cost == true)
            {
                string message_cost = "";
                //blow_cost >>>not complit
                bool is_true_ = true;
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if (dgv.Rows[i].Cells["item_price"].Value+"" == "") dgv.Rows[i].Cells["item_price"].Value = "0";
                    if (dgv.Rows[i].Cells["discount"].Value + "" == "") dgv.Rows[i].Cells["discount"].Value = "0";

                    double cost = Convert.ToDouble(db.GetData("select isnull(max(cost),0) from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "" + "' and id_ware='" + lbl_wares.Text + "'").Rows[0][0].ToString());
                    int count = dgv.Rows.Count;
                    double items_price = Convert.ToDouble(dgv.Rows[i].Cells["item_price"].Value.ToString()) - Convert.ToDouble(dgv.Rows[i].Cells["discount"].Value.ToString());
                    double discount_all=Convert.ToDouble(txt_discount_all.Text);
                    items_price = items_price - (discount_all / count);

                    if (Convert.ToDouble(items_price + "") < cost)
                    {
                        message_cost += "\n"+dgv.Rows[i].Cells["code_items"].Value + "  لايمكن البيع تحت سعر التلكفة لكود صنف ";
                        is_true_ = false;
                    }
                }
                if (is_true_==false)
                {
                    XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, message_cost, "رسالة منع بيع تحت تكلفة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (Convert.ToDouble(lbl_tot.Text)<=Convert.ToDouble(txt_discount_all.Text))
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "لايجب ان يكون الخصم اكبر من قيمة الفاتورة", "رسالة خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (shift_state_valid == "0")
                {
                    MessageBox.Show("تم إغلاق الوردية ....يجب فتح وردية جيدة");
                    return;
                }
            
            receve_mony_screen();
          //  calc_discount_pres();
            clac_discount_all();

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
                       //if txt inv ="" 
           //else 
        }
        private void btn_add_items_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_item f = new frm_item();
            f.ShowDialog();
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
        private void btn_cloes_shift_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void txt_barcode_TextChanged(object sender, EventArgs e)
        {
          //lbl_requer.Text=txt_barcode.Text;
            calc_all();
           
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //1-TO Get Clothes Search 
            //if (v.code_come_adv_search != "")
            //{
            //    txt_barcode.Text = v.code_come_adv_search;
            //    v.code_come_adv_search = "";
            //    add_barcode();
            //}
            //2-To Close Shift had been Closed
            string state_lock = db.GetData_for_log("select isnull(max(lock),0) from pos_shift where emp_code='" + v.usercode + "' and shift_no='" + lbl_shift_no.Caption + "'").Rows[0][0].ToString();
            if (state_lock == "0")
                 Close();
            //3-To Get VCS Name Data .......
            //if (v.iam_posed == true)
            //{
            //      combo_code_vcs.Text = v.vcs_code_pos;
            //      combo_name_vcs.Text= v.vcs_name_pos;
            //      combo_phone_vcs.Text= v.vcs_phone_pos;
            //      lbl_vcs_address.Text = v.vcs_address_pos;
            //      v.iam_posed = false;
            //}


            timer_par.Caption = DateTime.Now.ToString("HHmmss");
            bar_data1.Caption = DateTime.Now.ToString("yyyy: MM:dd");
        }
        private void simpleButton22_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Btn_min_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void lbl_invoice_number_TextChanged(object sender, EventArgs e)
        {
            barCodeControl1.Text = lbl_invoice_number.Text;
        }
        private void Dgv_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            calc_all();
           // calc_discount_pres();
            clac_discount_all();
            Classes.command.LoadSerial(dgv);

        }
        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            all_comb.load_unite(combo_unit, dgv.CurrentRow.Cells["code_items"].Value.ToString());
            lbl_f_unite.Text = (db.GetData("select (unite) from unite where name_unite='" + combo_unit.Text + "'").Rows[0][0].ToString());
           // all_comb.load_exp_date(combo_exp, dgv.CurrentRow.Cells["code_items"].Value.ToString(), dgv.CurrentRow.Cells["id_ware"].Value.ToString());

        }
        private void add_unite_()
        {
            try
            {
                dgv.CurrentRow.Cells["name_unite"].Value = combo_unit.Text;
                dgv.CurrentRow.Cells["f_unite"].Value = lbl_f_unite.Text;

            }
            catch (Exception)
            {
            }
        }
        private void Add_unite_Click(object sender, EventArgs e)
        {
            if (combo_unit.Text != "")
            {
                add_unite_();
                // dgv.CurrentRow.Cells["type"].Value = 2;
                dgv.CurrentRow.Cells["qty"].Value = 0;
                dgv.CurrentRow.Cells["item_price"].Value = Convert.ToDouble(lbl_f_unite.Text) * Convert.ToDouble(price_items_a);
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
                if (dgv_recv.Rows.Count==0) return;
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
                group_pending.Visible = false;
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
                            dgv_recv.Rows.Add("", dt.Rows[i][0].ToString(), f_currency,"","", dt.Rows[i][1].ToString().Trim());
                        }
                        if (dt.Rows[i][1].ToString().Trim() == "currency")
                        {
                            double f_currency = Convert.ToDouble(db.GetData("SELECT max (f_currance) FROM   currance where currance='"+ dt.Rows[i][2].ToString().Trim() + "'").Rows[0][0].ToString());
                            dgv_recv.Rows.Add("", dt.Rows[i][0].ToString(),f_currency, "", "", dt.Rows[i][1].ToString().Trim());
                        }
                        else if (dt.Rows[i][1].ToString().Trim() == "vcs")//not work right now credit vcs 
                        {
                            dgv_recv.Rows.Add("", dt.Rows[i][0].ToString(), "", "", dt.Rows[i][1].ToString().Trim());
                        }
                    }
                    if (dgv_recv.Rows.Count==0)
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
                if (i ==0)
                {
                  dis = Convert.ToDecimal(txt_discount_all.Text);
                }
                else
                {
                    dis = 0;
                }
                //     DateTime dateTime;
                if (!Convert.ToBoolean(dgv.Rows[i].Cells["exp"].Value))
                {
                    db.Run("insert into pos_dt(pos_inv_no            ,         shift_no            ,                       code_items              ,                        name_items             ,                                         qty             ,                                      item_price                  ,                                         tot_bef             ,                                         discount             ,                                         tot_after_dis             ,                                        taxes              ,                                        incloud_taxes                 ,                                          taxes_value             ,      id_ware                                   ,                         f_unite,                                   name_unite                                           ,no,                                                           [exp]              ,            exp_date                        ,[type]                    ,     user_code    ,      user_name           ,vcs_code                  ,vcs_name,                       phone_vcs                 ,delivery_code             ,delivery_name,                time_h                                          ,date_d                                         ,cash_bal   ,visa_bal  ,opening_bal,state,discount_all) values('" +
                                            lbl_invoice_number.Text + "','" + lbl_shift_no.Caption + "','" + dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["item_price"].Value) + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_bef"].Value) + "         ," + Convert.ToDecimal(dgv.Rows[i].Cells["discount"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["taxes"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["incloud_taxes"].Value) + "'         ,'" + Convert.ToDecimal(dgv.Rows[i].Cells["taxes_value"].Value) + "','" + lbl_wares.Text + "'                           ,'" + dgv.Rows[i].Cells["f_unite"].Value + "'  ,'" + dgv.Rows[i].Cells["name_unite"].Value + "'         ,'" + dgv.Rows[i].Cells["no"].Value + "','" + (Convert.ToBoolean(dgv.Rows[i].Cells["exp"].Value)) + "',            Null              ,'" + dgv.Rows[i].Cells["type"].Value + "','" + v.usercode + "','" + lbl_user_name.Text + "','" + combo_code_vcs.Text + "','" + combo_name_vcs.Text + "','" + combo_phone_vcs.Text + "','" + combo_code_emp.Text + "','" + combo_name_emp.Text + "','" + DateTime.Now.ToString("hh:mm:ss") + "'        ,'" + DateTime.Now.ToString("MM-dd-yyyy") + "'     ,'" + v.cash + "'       ,'" + v.visa + "'     ,null       ,'sal','"+dis+"')");

                }
                else if (Convert.ToBoolean(dgv.Rows[i].Cells["exp"].Value))
                {
                    db.Run("insert into pos_dt(pos_inv_no            ,         shift_no            ,                       code_items              ,                        name_items             ,                                         qty             ,                                      item_price                  ,                                         tot_bef             ,                                         discount             ,                                         tot_after_dis             ,                                        taxes              ,                                        incloud_taxes                 ,                                          taxes_value             ,      id_ware                                   ,                         f_unite,                                   name_unite                                           ,no,                                                           [exp]              ,            exp_date                        ,[type]                    ,     user_code    ,      user_name           ,vcs_code                  ,vcs_name,                       phone_vcs                 ,delivery_code             ,delivery_name,                time_h                                          ,date_d                                         ,cash_bal   ,visa_bal  ,opening_bal,state,discount_all) values('" +
                                           lbl_invoice_number.Text + "','" + lbl_shift_no.Caption + "','" + dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["item_price"].Value) + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_bef"].Value) + "         ," + Convert.ToDecimal(dgv.Rows[i].Cells["discount"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["taxes"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["incloud_taxes"].Value) + "'         ,'" + Convert.ToDecimal(dgv.Rows[i].Cells["taxes_value"].Value) + "','" + lbl_wares.Text + "'                           ,'" + dgv.Rows[i].Cells["f_unite"].Value + "'  ,'" + dgv.Rows[i].Cells["name_unite"].Value + "'         ,'" + dgv.Rows[i].Cells["no"].Value + "','" + (Convert.ToBoolean(dgv.Rows[i].Cells["exp"].Value)) + "',            '" + dgv.Rows[i].Cells["exp_date"].Value.ToString() + "'              ,'" + dgv.Rows[i].Cells["type"].Value + "','" + v.usercode + "','" + lbl_user_name.Text + "','" + combo_code_vcs.Text + "','" + combo_name_vcs.Text + "','" + combo_phone_vcs.Text + "','" + combo_code_emp.Text + "','" + combo_name_emp.Text + "','" + DateTime.Now.ToString("hh:mm:ss") + "'        ,'" + DateTime.Now.ToString("MM-dd-yyyy") + "'     ,'" + v.cash + "'       ,'" + v.visa + "'     ,null       ,'sal','"+ dis + "')");

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
            if (Convert.ToDouble(txt_visa.Text) == 0)
            {//update lbl_inv
                db.Run("update pos_cash set balance ='" + (Convert.ToDouble(lbl_reqer_mony.Text) + Convert.ToDouble(bal_cash)) + "' where shift_no='" + lbl_shift_no.Caption + "' and user_code='" + v.usercode + "' and code_cash='1'");
            }
            else
            {  //update from cash
                db.Run("update pos_cash set balance ='" + (Convert.ToDouble(txt_cash.Text) + Convert.ToDouble(bal_cash)) + "' where shift_no='" + lbl_shift_no.Caption + "' and user_code='" + v.usercode + "' and code_cash='1'");

                DataTable dt = new DataTable();
                db.GetData_DGV("select balance ,code_cash from pos_cash where shift_no='" + lbl_shift_no.Caption + "' and user_code='" + v.usercode + "' and len(code_cash)>=2 order by code_cash", dt);
                for (int i = 0; i < dt.Rows.Count; i++)

                    {
                    string balance = dt.Rows[i][0].ToString().Trim();
                    string code = dt.Rows[i][1].ToString().Trim();
                    string balance_dgv = dgv_recv.Rows[i].Cells[3].Value+"".Trim();
                    if (balance=="") balance = "0"; if (balance_dgv == "") balance_dgv = "0";
                    db.Run("update pos_cash set balance ='" + (Convert.ToDouble(balance_dgv) + Convert.ToDouble(balance)) + "' where shift_no='" + lbl_shift_no.Caption + "' and user_code='" + v.usercode + "' and code_cash='"+ code + "'");
                }
                cash_balance();

                //insert into entry  from vcs or visa 
                DataTable dt_visa = new DataTable();
                db.GetData_DGV("select type,cash_account_user from pos_cash where len(code_cash)>=2 and len(name_cash)>=1 and shift_no='" + lbl_shift_no.Caption + "' and user_code='" + v.usercode + "' and type='visa'", dt_visa);
                if (dt_visa.Rows[0][0].ToString().Trim()== "visa")
                {
                    for (int i = 0; i < dt_visa.Rows.Count; i++)
                    {
                        string cash5_account = dt_visa.Rows[i][1]+"".Trim();
                        string cash6_account = db.GetData("select medil from pos_cash_account where user_code='"+lbl_user_code.Text+"' ").Rows[0][0].ToString().Trim();
                        string x = "001";
                        string amount_visa = dgv_recv.Rows[i].Cells[3].Value + ""; if (amount_visa == "") amount_visa = "0";
                        if (dgv_recv.Rows[i].Cells[5].Value.ToString().Trim() == "visa" && Convert.ToDouble(amount_visa)> 0)
                        {
                            db.Run("insert into entry(  [code_entry]                           ,    acc_num             ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                               ,   sort                                                            , type_acc                                                       ,             depit                                                             ,                credit                 ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext )values('" +
                                               x + "'                           ,'" + cash5_account + "'     ,(select top 1 rootname from tree where rootid='" + cash5_account + "')               ,  (select top 1 RootLevel from tree where rootid='" + cash5_account + "')    ,  0, '1'       ,  (select top 1 type_acc from entry where acc_num='" + cash5_account + "')  ,  '" + Convert.ToDecimal(dgv_recv.Rows[i].Cells[3].Value) + "' ,0  , 'POS','POS'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','"+lbl_shift_no.Caption+"','POS','POS','قيد مؤقت لحين إغلاق الوردية ')");
                            db.Run("insert into entry(  [code_entry]                           ,    acc_num             ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                               ,   sort                                                            , type_acc                                                       ,             depit                                                             ,                credit                 ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext )values('" +
                                             x + "'                           ,'" + cash6_account + "'     ,(select top 1 rootname from tree where rootid='" + cash6_account + "')               ,  (select top 1 RootLevel from tree where rootid='" + cash6_account + "')    ,  0, '1'       ,  (select top 1 type_acc from entry where acc_num='" + cash6_account + "')  ,0,  '" + Convert.ToDecimal(dgv_recv.Rows[i].Cells[3].Value) + "'   , 'POS','POS'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','"+ lbl_shift_no.Caption + "','POS','POS','قيد مؤقت لحين إغلاق الوردية ')");
                        }
                    }
                }

            }
            if (no_invoice_pending!="")
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

                if (!Convert.ToBoolean(dgv.Rows[i].Cells["exp"].Value))
                {
                    db.Run("insert into pos_dt(pos_inv_no            ,         shift_no            ,                       code_items              ,                        name_items             ,                                         qty             ,                                      item_price                  ,                                         tot_bef             ,                                         discount             ,                                         tot_after_dis             ,                                        taxes              ,                                        incloud_taxes                 ,                                          taxes_value             ,      id_ware                                   ,                         f_unite,                                   name_unite                                           ,no,                                                           [exp]              ,            exp_date                        ,[type]                    ,     user_code    ,      user_name           ,vcs_code                  ,vcs_name,                       phone_vcs                 ,delivery_code             ,delivery_name,                time_h                                          ,date_d                                         ,cash_bal   ,visa_bal  ,opening_bal,re_pos_inv_no,state,discount_all) values('" +
                                            lbl_invoice_number.Text + "','" + lbl_shift_no.Caption + "','" + dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) * -1 + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["item_price"].Value) + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_bef"].Value) * -1 + "         ," + Convert.ToDecimal(dgv.Rows[i].Cells["discount"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) * -1 + "," + Convert.ToDecimal(dgv.Rows[i].Cells["taxes"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["incloud_taxes"].Value) * -1 + "'         ,'" + Convert.ToDecimal(dgv.Rows[i].Cells["taxes_value"].Value) + "','" + lbl_wares.Text + "'                           ,'" + dgv.Rows[i].Cells["f_unite"].Value + "'  ,'" + dgv.Rows[i].Cells["name_unite"].Value + "'         ,'" + dgv.Rows[i].Cells["no"].Value + "','" + (Convert.ToBoolean(dgv.Rows[i].Cells["exp"].Value)) + "',            Null              ,'" + dgv.Rows[i].Cells["type"].Value + "','" + v.usercode + "','" + lbl_user_name.Text + "','" + combo_code_vcs.Text + "','" + combo_name_vcs.Text + "','" + combo_phone_vcs.Text + "','" + combo_code_emp.Text + "','" + combo_name_emp.Text + "','" + DateTime.Now.ToString("hh:mm:ss") + "'        ,'" + DateTime.Now.ToString("MM-dd-yyyy") + "'     ,'"+(Convert.ToDouble(v.cash)*-1)+"'       ,'"+ (Convert.ToDouble(v.visa) * -1) + "'      ,null      ,'"+txt_resale.Text+"' ,'re','"+dis*-1+"')");

                }
                else if (Convert.ToBoolean(dgv.Rows[i].Cells["exp"].Value))
                {
                    db.Run("insert into pos_dt(pos_inv_no            ,         shift_no            ,                       code_items              ,                        name_items             ,                                         qty             ,                                      item_price                  ,                                         tot_bef             ,                                         discount             ,                                         tot_after_dis             ,                                        taxes              ,                                        incloud_taxes                 ,                                          taxes_value             ,      id_ware                                   ,                         f_unite,                                   name_unite                                           ,no,                                                           [exp]              ,            exp_date                        ,[type]                    ,     user_code    ,      user_name           ,vcs_code                  ,vcs_name,                       phone_vcs                 ,delivery_code             ,delivery_name,                time_h                                          ,date_d                                         ,cash_bal   ,visa_bal  ,opening_bal,re_pos_inv_no,state,discount_all) values('" +
                                           lbl_invoice_number.Text + "','" + lbl_shift_no.Caption + "','" + dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) * -1 + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["item_price"].Value) + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_bef"].Value) * -1 + "         ," + Convert.ToDecimal(dgv.Rows[i].Cells["discount"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) * -1 + "," + Convert.ToDecimal(dgv.Rows[i].Cells["taxes"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["incloud_taxes"].Value) * -1 + "'         ,'" + Convert.ToDecimal(dgv.Rows[i].Cells["taxes_value"].Value) + "','" + lbl_wares.Text + "'                           ,'" + dgv.Rows[i].Cells["f_unite"].Value + "'  ,'" + dgv.Rows[i].Cells["name_unite"].Value + "'         ,'" + dgv.Rows[i].Cells["no"].Value + "','" + (Convert.ToBoolean(dgv.Rows[i].Cells["exp"].Value)) + "',            '" + dgv.Rows[i].Cells["exp_date"].Value.ToString() + "'              ,'" + dgv.Rows[i].Cells["type"].Value + "','" + v.usercode + "','" + lbl_user_name.Text + "','" + combo_code_vcs.Text + "','" + combo_name_vcs.Text + "','" + combo_phone_vcs.Text + "','" + combo_code_emp.Text + "','" + combo_name_emp.Text + "','" + DateTime.Now.ToString("hh:mm:ss") + "'        ,'" + DateTime.Now.ToString("MM-dd-yyyy") + "'     ,'" + (Convert.ToDouble(v.cash) * -1) + "'       ,'" + (Convert.ToDouble(v.visa) * -1) + "' ,null     ,'"+ txt_resale.Text + "'  ,'re','"+dis*-1+"')");

                }

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
            Double red = Convert.ToDouble(lbl_reqer_mony.Text) - (Convert.ToDouble(txt_cash.Text) + Convert.ToDouble(txt_visa.Text));
            if (red>0)
            {
                return;
            }
            if (Convert.ToDecimal(lbl_remind.Text) <= 0 )
            {
                v.cash = !(txt_cash.Text == "0") && !(txt_cash.Text == "") ? Convert.ToDouble(txt_cash.Text) + Convert.ToDouble(lbl_remind.Text) : Convert.ToDouble(txt_cash.Text);
                v.visa = !(txt_visa.Text == "0") && !(txt_visa.Text == "") ? Convert.ToDouble(txt_visa.Text) + Convert.ToDouble(lbl_remind.Text) : Convert.ToDouble(txt_visa.Text);

            }
            //===============insert invoice and print 
            lbl_invoice_number.Text =generat_invoice_number();
            barCodeControl1.Text =generat_invoice_number();
          
            insert_receve();
            if (chk_print_inv.Checked==false)
            {
                XtraReport xtraReport = XtraReport.FromFile("forms\\receipt_printer_pos.repx", true);
                xtraReport.Parameters["parameter1"].Value = lbl_invoice_number.Text;
               // xtraReport.Parameters["parameter2"].Value = lbl_shift_no.Caption;
                xtraReport.Parameters["parameter1"].Visible = false;
               // xtraReport.Parameters["parameter2"].Visible = false;
                xtraReport.PrinterName = Settings.Default.printer_name;
                xtraReport.PrintAsync("");





            }
            clear();
            group_recev.Visible = false;
            txt_cash.Text = "0";
            txt_visa.Text = "0";
            dgv_recv.Rows.Clear();
            //---------------------------
            txt_barcode.Select();
           // v.revec_mony = false;
           
           //cash_visa_bal();
            //----------------------------------
            group_recev.Visible = false;

            // v.revec_mony = true;
            //Close();
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
            lbl_invoice_number.Text = generat_invoice_number_ret();
            barCodeControl1.Text = generat_invoice_number_ret();
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
            txt_barcode.Select();

            
            //----------------------------------
            group_recev.Visible = false;


        }
        private void perform_cash()
        {
            if (btn_resale_2.Checked==false && btn_receve.Enabled == true)
            {
                
                calc_recev();
                recev_cash();
            }
            else if(btn_resale_2.Checked == true && btn_receve.Enabled == false)
            {
                calc_recev();
                pay_cash();
                clear();
                btn_resale_2.Checked = false; btn_receve.Enabled = true;
            }
        }
        private void Dgv_recv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //no_recev
            Classes.command.LoadSerial(dgv_recv, "no_recev");
        }
        private void Txt_cash_TextChanged(object sender, EventArgs e)
        {
            calc_recev();
        }
        private void Txt_visa_TextChanged(object sender, EventArgs e)
        {
            calc_recev();
        }
        private void Btn_recev_Click(object sender, EventArgs e)
        {
            perform_cash();
        }
        private void Txt_cash_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgv_recv.Rows.Count!=0)
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

        private void Txt_visa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
               recev_cash();
            if (e.KeyCode == Keys.Up)
                ((Control)this.txt_cash).Select();
            if (this.txt_visa == null)
               txt_visa.Text = string.Concat(0);
            if (e.KeyCode != Keys.Escape)
                return;
          // Close();
        }
        private void Dgv_recv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                double sum = 0;
                for (int i = 0; i < dgv_recv.Rows.Count; i++)
                {
                    sum += Convert.ToDouble(dgv_recv.Rows[i].Cells[2].Value);
                    //                    dgv_recv.Rows[i].Cells[3].Value= Convert.ToDouble(lbl_remind)-Convert.ToDouble(dgv_recv.Rows[i].Cells[2].Value)

                }
                txt_visa.Text = sum + "";
            }
            catch (Exception)
            {

            }
        }

        private void Txt_cash_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (int)e.KeyChar != 46)
                e.Handled = true;
            if ((int)e.KeyChar != 46 || (sender as TextBox).Text.IndexOf('.') <= -1)
                return;
            e.Handled = true;
        }
        private void Txt_visa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (int)e.KeyChar != 46)
                e.Handled = true;
            if ((int)e.KeyChar != 46 || (sender as TextBox).Text.IndexOf('.') <= -1)
                return;
            e.Handled = true;
        }
        private void Btn_cloes_Click(object sender, EventArgs e)
        {
            group_recev.Visible = false;
            txt_cash.Text = "0";
            txt_visa.Text = "0";
            dgv_recv.Rows.Clear();
        }
        //resal invoice 
        //____________________________
        private void Btn_resale_1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lbl_resale.Visible = true;
            lbl_resale_tit.Visible = true;
            txt_resale.Visible = true;
            btn_receve.Enabled = false;
            btn_pay.Enabled = true;
        }
        private void Btn_resale_2_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (btn_resale_2.Checked==true)
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
                    txt_pres_descount_all.ReadOnly =false;
                }
            }
        }
        private void get_re_invoice ()
        {
            if (db.GetData("select isnull(max(pos_inv_no),0) from pos_dt where pos_inv_no='" + txt_resale.Text + "' and state='sal'").Rows[0][0].ToString() == "0")
            {
                MessageBox.Show("الفاتوره غير موجودة");
                return;
            }
            combo_code_vcs.Text = db.GetData("select isnull(max(vcs_code),0) from pos_dt where pos_inv_no='" + txt_resale.Text+"'").Rows[0][0].ToString();
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
        private void Txt_resale_KeyDown(object sender, KeyEventArgs e)
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
                        MessageBox.Show("يوم "+ c +"\n" +"لايمكن استرجاع الفاتوره لانقضاء اكثر من ");
                    }

                }
                else
                {
                    XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "تم ارتجاع الفاتورة من قبل       \n لايمكن استرجاع الفاتورة مرتين", "رسالة خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }

        }
        private void Txt_resale_Leave(object sender, EventArgs e)
        {
            //get_re_invoice();
        }
        //pending invoice
        //___________________________
        private static string no_invoice_pending = "";
        private void Btn_inv_pending_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lbl_invoice_number.Text= generat_invoice_number();
            if (dgv.Rows.Count == 0) return;
            //inser into pending invoice
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (!Convert.ToBoolean(dgv.Rows[i].Cells["exp"].Value))
                {
                    db.Run("insert into pos_pending(pos_inv_no            ,         shift_no            ,                       code_items              ,                        name_items             ,                                         qty             ,                                      item_price                  ,                                         tot_bef             ,                                         discount             ,                                         tot_after_dis             ,                                        taxes              ,                                        incloud_taxes                 ,                                          taxes_value             ,      id_ware                                   ,                         f_unite,                                   name_unite                                           ,no,                                                           [exp]              ,            exp_date                        ,[type]                    ,     user_code    ,      user_name           ,vcs_code                  ,vcs_name,                       phone_vcs                 ,delivery_code             ,delivery_name,                time_h                                          ,date_d                                         ,cash_bal   ,visa_bal  ,opening_bal,discount_all) values('" +
                                            lbl_invoice_number.Text + "','" + lbl_shift_no.Caption + "','" + dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["item_price"].Value) + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_bef"].Value) + "         ," + Convert.ToDecimal(dgv.Rows[i].Cells["discount"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["taxes"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["incloud_taxes"].Value) + "'         ,'" + Convert.ToDecimal(dgv.Rows[i].Cells["taxes_value"].Value) + "','" + lbl_wares.Text + "'                           ,'" + dgv.Rows[i].Cells["f_unite"].Value + "'  ,'" + dgv.Rows[i].Cells["name_unite"].Value + "'         ,'" + dgv.Rows[i].Cells["no"].Value + "','" + (Convert.ToBoolean(dgv.Rows[i].Cells["exp"].Value)) + "',            Null              ,'" + dgv.Rows[i].Cells["type"].Value + "','" + v.usercode + "','" + lbl_user_name.Text + "','" + combo_code_vcs.Text + "','" + combo_name_vcs.Text + "','" + combo_phone_vcs.Text + "','" + combo_code_emp.Text + "','" + combo_name_emp.Text + "','" + DateTime.Now.ToString("hh:mm:ss") + "'        ,'" + DateTime.Now.ToString("MM-dd-yyyy") + "'     ,null       ,null      ,null       ,'"+txt_discount_all.Text+"')");

                }
                else if (Convert.ToBoolean(dgv.Rows[i].Cells["exp"].Value))
                {
                    db.Run("insert into pos_pending(pos_inv_no            ,         shift_no            ,                       code_items              ,                        name_items             ,                                         qty             ,                                      item_price                  ,                                         tot_bef             ,                                         discount             ,                                         tot_after_dis             ,                                        taxes              ,                                        incloud_taxes                 ,                                          taxes_value             ,      id_ware                                   ,                         f_unite,                                   name_unite                                           ,no,                                                           [exp]              ,            exp_date                        ,[type]                    ,     user_code    ,      user_name           ,vcs_code                  ,vcs_name,                       phone_vcs                 ,delivery_code             ,delivery_name,                time_h                                          ,date_d                                         ,cash_bal   ,visa_bal  ,opening_bal,discount_all) values('" +
                                           lbl_invoice_number.Text + "','" + lbl_shift_no.Caption + "','" + dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["item_price"].Value) + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_bef"].Value) + "         ," + Convert.ToDecimal(dgv.Rows[i].Cells["discount"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["taxes"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["incloud_taxes"].Value) + "'         ,'" + Convert.ToDecimal(dgv.Rows[i].Cells["taxes_value"].Value) + "','" + lbl_wares.Text + "'                           ,'" + dgv.Rows[i].Cells["f_unite"].Value + "'  ,'" + dgv.Rows[i].Cells["name_unite"].Value + "'         ,'" + dgv.Rows[i].Cells["no"].Value + "','" + (Convert.ToBoolean(dgv.Rows[i].Cells["exp"].Value)) + "',            '" + dgv.Rows[i].Cells["exp_date"].Value.ToString() + "'              ,'" + dgv.Rows[i].Cells["type"].Value + "','" + v.usercode + "','" + lbl_user_name.Text + "','" + combo_code_vcs.Text + "','" + combo_name_vcs.Text + "','" + combo_phone_vcs.Text + "','" + combo_code_emp.Text + "','" + combo_name_emp.Text + "','" + DateTime.Now.ToString("hh:mm:ss") + "'        ,'" + DateTime.Now.ToString("MM-dd-yyyy") + "'     ,null       ,null      ,null      ,'" + txt_discount_all.Text + "' )");

                }
            }
            generat_invoice_number();
            clear();
            dgv.Rows.Clear();

        }
        private void Btn_pinding_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            group_pending.Visible = true;
            DataTable dt = new DataTable();
//            db.GetData_DGV("select 0 as no_pen,pos_inv_no  as inv from pos_pending  where shift_no='"+lbl_shift_no.Caption+"'", dt);
            db.GetData_DGV("select distinct pos_inv_no  as inv from pos_pending  where shift_no='" + lbl_shift_no.Caption+"'", dt);
         //   db.GetData_DGV("select distinct pos_inv_no  as inv from pos_pending  ", dt);

            dgv_pending.DataSource = dt;
        }

        private void Dgv_pending_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv_pending, "no_pen");
        }
        private void Btn_pending_close_Click(object sender, EventArgs e)
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
        private void Dgv_pending_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }
        private void Dgv_pending_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //get invoice in dgv
            //clear();
            dgv.Rows.Clear();
            DataTable dt = new DataTable();
            db.GetData_DGV("select code_items ,name_items ,name_unite ,f_unite ,[exp] ,[type] ,null , 0 , qty ,item_price ,0 , 0 , discount , 0 ,taxes ,0 ,0 ,id_ware ,(select isnull(max(couta_type) ,0 ) from items where code_items=pos_pending.code_items),discount_all from pos_pending where pos_inv_no='" + dgv_pending.CurrentRow.Cells[1].Value + "'", dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv.Rows.Add(null, dt.Rows[i][0] + "", dt.Rows[i][1] + "", dt.Rows[i][2] + "", dt.Rows[i][3] + "", dt.Rows[i][4] + "", dt.Rows[i][5] + "", dt.Rows[i][6] + "", dt.Rows[i][7] + "", dt.Rows[i][8] + "", dt.Rows[i][9] + "", dt.Rows[i][10] + "", dt.Rows[i][11] + "", dt.Rows[i][12] + "", dt.Rows[i][13] + "", dt.Rows[i][14] + "", dt.Rows[i][15] + "", dt.Rows[i][16] + "", dt.Rows[i][17] + "", dt.Rows[i][18] + "");//, dt.Rows[i][19]+"", dt.Rows[i][20]+""
            }
            txt_discount_all.Text = dt.Rows[0][19] + "";
            no_invoice_pending = dgv_pending.CurrentRow.Cells[1].Value+"";

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
        
        //======================================================End peinding
        //delete invoice
        //___________________________
        private void Btn_del_search_inv_Click(object sender, EventArgs e)
        {
            all_comb.load_invoice_pos_not_close(combo_del_inv);
            combo_del_inv.Text = "";
        }
        private void Btn_del_search_shift_Click(object sender, EventArgs e)
        {
            all_comb.load_shift_not_close(combo_shift_no);
            combo_shift_no.Text = "";
        }
        private void Combo_del_inv_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_del_no_invoice.Text = db.GetData("select isnull(max(pos_inv_no),0) from pos_dt where pos_inv_no='"+combo_del_inv.Text+"'").Rows[0][0].ToString();
            lbl_state.Text= db.GetData("select isnull(max(state),0) from pos_dt where pos_inv_no='" + lbl_del_no_invoice.Text + "'").Rows[0][0].ToString();
            if (lbl_state.Text== "sal")
            {
                lbl_del_title_state.Text = "فاتورة مبيعات";
            }
            else
            {
                lbl_del_title_state.Text = "مرتجع مبيعات";

            }
        }
        private void Combo_shift_no_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_del_no_shift.Text= db.GetData("select isnull(max(shift_no),0) from pos_dt where shift_no='" + combo_shift_no.Text + "'").Rows[0][0].ToString();
        }
        private void Btn_del_search_user_code_Click(object sender, EventArgs e)
        {
            all_comb.load_emp_users_code(combo_del_user_code);
            combo_del_user_code.Text = "";

        }
        private void Combo_del_user_code_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_del_user_code.Text = db.GetData("select isnull(max(emp_no),0) from emps where emp_no='" + combo_del_user_code.Text + "'").Rows[0][0].ToString();
        }
        private void Btn_del_show_invoice_Click(object sender, EventArgs e)
        {
            if (lbl_del_no_invoice.Text=="0" || lbl_del_no_invoice.Text == "")
            {
                MessageBox.Show("يجب اختيار فاتورة في وردية مفتوحة");
                return;
            }
            if (lbl_del_no_shift.Text == "0" || lbl_del_no_shift.Text == "")
            {
                MessageBox.Show("يجب اختيار وردية وتكون مفتوحة");
                return;
            }
            if (lbl_del_user_code.Text== "0" || lbl_del_user_code.Text == "")
            {
                MessageBox.Show("يجب اختيار الموظف");
                return;
            }
            if (db.GetData("select isnull(max(pos_inv_no),0) from pos_dt where pos_inv_no='" + lbl_del_no_invoice.Text + "' and  shift_no='" + lbl_shift_no.Caption + "' and user_code='" + lbl_del_user_code.Text + "'").Rows[0][0].ToString() == "0")
            {
                MessageBox.Show("الفاتورة غير موجودة");
                return;
            }
            DataTable dt = new DataTable();
            db.GetData_DGV("select code_items ,name_items ,name_unite ,f_unite ,[exp] ,[type] ,null , 0 , 1 ,item_price ,0 , 0 , 0 , 0 ,taxes ,0 ,0 ,id_ware ,(select isnull(max(couta_type) ,0 ) from items where code_items=pos_dt.code_items) from pos_dt where pos_inv_no='" + lbl_del_no_invoice.Text + "'", dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv.Rows.Add(null, dt.Rows[i][0] + "", dt.Rows[i][1] + "", dt.Rows[i][2] + "", dt.Rows[i][3] + "", dt.Rows[i][4] + "", dt.Rows[i][5] + "", dt.Rows[i][6] + "", dt.Rows[i][7] + "", dt.Rows[i][8] + "", dt.Rows[i][9] + "", dt.Rows[i][10] + "", dt.Rows[i][11] + "", dt.Rows[i][12] + "", dt.Rows[i][13] + "", dt.Rows[i][14] + "", dt.Rows[i][15] + "", dt.Rows[i][16] + "", dt.Rows[i][17] + "", dt.Rows[i][18] + "");//, dt.Rows[i][19]+"", dt.Rows[i][20]+""
            }
            calc_all();
        }
        private void Btn_del_delete_invoice_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count==0)
            {
                MessageBox.Show("يجب عرض فاتورة لكي تم حذفها");
            }
            if (lbl_del_no_invoice.Text == "0" || lbl_del_no_invoice.Text == "")
            {
                MessageBox.Show("يجب اختيار فاتورة في وردية مفتوحة");
                return;
            }
            if (lbl_del_no_shift.Text == "0" || lbl_del_no_shift.Text == "")
            {
                MessageBox.Show("يجب اختيار وردية وتكون مفتوحة");
                return;
            }
            if (lbl_del_user_code.Text == "0" || lbl_del_user_code.Text == "")
            {
                MessageBox.Show("يجب اختيار الموظف");
                return;
            }
            if (db.GetData("select isnull(max(pos_inv_no),0) from pos_dt where pos_inv_no='" + lbl_del_no_invoice.Text + "' and  shift_no='" + lbl_shift_no.Caption + "' and user_code='" + lbl_del_user_code.Text + "'").Rows[0][0].ToString() == "0")
            {
                MessageBox.Show("الفاتورة غير موجودة");
                return;
            }

            DialogResult dr;
            dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "سيتم حذف الفاتورة  ", "رسال حذف مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                double cash = Convert.ToDouble(db.GetData("select isnull(max(cash_bal),0) from pos_dt  where  pos_inv_no='" + lbl_del_no_invoice.Text + "'").Rows[0][0].ToString());
                double visa = Convert.ToDouble(db.GetData("select  isnull(max(visa_bal),0) from pos_dt  where  pos_inv_no='" + lbl_del_no_invoice.Text + "'").Rows[0][0].ToString());

                db.Run("delete from pos_dt where  pos_inv_no='" + lbl_del_no_invoice.Text + "' ");

                double bal_cash = Convert.ToDouble(db.GetData("select isnull(sum(balance),0) from pos_cash where code_cash='1' and shift_no='" + lbl_shift_no.Caption + "' and user_code='" + v.usercode + "'").Rows[0][0].ToString());
                double bal_visa = Convert.ToDouble(db.GetData("select isnull(sum(balance),0) from pos_cash where code_cash='2' and shift_no='" + lbl_shift_no.Caption + "' and user_code='" + v.usercode + "'").Rows[0][0].ToString());

                db.Run("update pos_cash set balance ='" + (Convert.ToDouble(bal_cash) - Convert.ToDouble(cash)) + "' where shift_no='" + lbl_shift_no.Caption + "' and user_code='" + lbl_del_user_code.Text + "' and code_cash='1'");
                db.Run("update pos_cash set balance ='" + (Convert.ToDouble(bal_visa) - Convert.ToDouble(visa)) + "' where shift_no='" + lbl_shift_no.Caption + "' and user_code='" + lbl_del_user_code.Text + "' and code_cash='2'");
                clear();
                dgv.Rows.Clear();
            }
        }

        //vcs Data
        //____________________________
        private void Combo_code_vcs_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combo_name_vcs.Text = db.GetData("select vcs_name from vcs where vcs_code='" + combo_code_vcs.Text + "'").Rows[0][0].ToString();
                combo_phone_vcs.Text = db.GetData("select phone from vcs where vcs_code='" + combo_code_vcs.Text + "'").Rows[0][0].ToString();
                lbl_vcs_address.Text = db.GetData("select address from vcs where vcs_code='" + combo_code_vcs.Text + "'").Rows[0][0].ToString();
                lbl_state_vcs_bal_n.Text = db.GetData("select isnull(sum(depit)-sum(credit),0) from entry where acc_num='" + this.combo_code_vcs.Text + "'").Rows[0][0]+"";


            }
            catch (Exception)
            {
            }

        }
        private void Combo_name_vcs_SelectedIndexChanged(object sender, EventArgs e)
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
        private void Combo_phone_vcs_SelectedIndexChanged(object sender, EventArgs e)
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
        private void Btn_search_allvcs_Click(object sender, EventArgs e)
        {
            all_comb.load_code_vcs(combo_code_vcs);
            all_comb.load_name_vcs(combo_name_vcs);
            all_comb.load_phone(combo_phone_vcs, "customer");
            combo_code_vcs.Text = "";
            combo_name_vcs.Text = "";
            combo_phone_vcs.Text = "";
            lbl_vcs_address.Text = "";

        }
        private void Btn_vcs_clear_Click(object sender, EventArgs e)
        {
            combo_code_vcs.Text = "";
            combo_name_vcs.Text = "";
            lbl_vcs_address.Text = ",,.";
            combo_code_emp.Text = "";
            combo_name_emp.Text = "";
        }
        private void Combo_code_emp_Click(object sender, EventArgs e)
        {
            all_comb.load_emp_no(combo_code_emp);
        }
        private void Combo_name_emp_Click(object sender, EventArgs e)
        {
            all_comb.load_emp_name(combo_code_emp);
        }
        private void Combo_code_emp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combo_name_emp.Text = db.GetData("select emp_name from emps where emp_no='" + combo_code_emp.Text + "'").Rows[0][0].ToString();
            }
            catch (Exception)
            {
            }
        }
        private void Chk_sales_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_sales.Checked)
            {
                combo_code_vcs.Visible = true;
                combo_name_vcs.Visible = true;
                combo_phone_vcs.Visible = true;
                Settings.Default.chk_sales = true;
                Settings.Default.Save();
            }
            else
            {
                combo_code_vcs.Visible = false;
                combo_name_vcs.Visible = false;
                combo_phone_vcs.Visible = false;
                combo_code_vcs.Text = "";
                combo_name_vcs.Text = "";
                combo_phone_vcs.Text = "";
                Settings.Default.chk_sales = false;
                Settings.Default.Save();
            }
        }
        //1calculator
        //_____________________________
        private double value;
        private string operat;
        private bool operation_press;
        private void btn_click(object sender, EventArgs e)
        {
            if (txt_calc.Text == "0" || operation_press)
                txt_calc.Clear();
            operation_press = false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (this.txt_calc.Text.Contains("."))
                    return;
                txt_calc.Text = txt_calc.Text + button.Text;
            }
            else
                txt_calc.Text = txt_calc.Text + button.Text;
        }
        private void btn_perf_cal(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (value != 0.0)
            {
                btn_equal.PerformClick();
                operation_press = true;
                operat = button.Text;
                lbl_equation.Text = value + operat;
            }
            else
            {
                operat = button.Text;
                value = Convert.ToDouble(txt_calc.Text);
                operation_press = true;
                lbl_equation.Text = value + operat;
            }
        }

        private void Btn_equal_Click(object sender, EventArgs e)
        {
            lbl_equation.Text = "";
            switch (operat)
            {
                case "+":
                    txt_calc.Text = (value + Convert.ToDouble(txt_calc.Text)).ToString();
                    break;
                case "-":
                    txt_calc.Text = (value - Convert.ToDouble(txt_calc.Text)).ToString();
                    break;
                case "*":
                    txt_calc.Text = (value * Convert.ToDouble(txt_calc.Text)).ToString();
                    break;
                case "/":
                    txt_calc.Text = (value / Convert.ToDouble(txt_calc.Text)).ToString();
                    break;
            }
            value = Convert.ToDouble(txt_calc.Text);
            operat = "";
        }
        private void Btn_c_Click(object sender, EventArgs e)
        {
            txt_calc.Text = "0";
            value = 0.0;
            operat = "0";
            lbl_equation.Text = "";
            operation_press = false;
        }
        private void Txt_calc_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar.ToString())
            {
                case "c":
                    this.btn_c.PerformClick();
                    break;
                case "0":
                    this.zero.PerformClick();
                    break;
                case "1":
                    this.one.PerformClick();
                    break;
                case "2":
                    this.two.PerformClick();
                    break;
                case "3":
                    this.three.PerformClick();
                    break;
                case "4":
                    this.foure.PerformClick();
                    break;
                case "5":
                    this.five.PerformClick();
                    break;
                case "6":
                    this.six.PerformClick();
                    break;
                case "7":
                    this.seven.PerformClick();
                    break;
                case "8":
                    this.eight.PerformClick();
                    break;
                case "9":
                    this.nine.PerformClick();
                    break;
                case "+":
                    this.add.PerformClick();
                    break;
                case "-":
                    this.min.PerformClick();
                    break;
                case "/":
                    this.div.PerformClick();
                    break;
                case "*":
                    this.time.PerformClick();
                    break;
                case ".":
                    this.dot.PerformClick();
                    break;
                case "=":
                    this.btn_equal.PerformClick();
                    break;
                case "ENTER":
                    this.btn_equal.PerformClick();
                    break;
            }
        }
        private void Txt_calc_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Return)
                    btn_equal.PerformClick();
            }
            catch (Exception)
            {

               
            }
            //if (e.KeyCode != Keys.Back)
            //    return;
            //btn_c.PerformClick();
        }
        private void Txt_barcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //to make language keybord English 
            CultureInfo TypeOfLanguage = CultureInfo.CreateSpecificCulture("en-US");
            System.Threading.Thread.CurrentThread.CurrentCulture = TypeOfLanguage;
            InputLanguage l = InputLanguage.FromCulture(TypeOfLanguage);
            InputLanguage.CurrentInputLanguage = l;
           

        }
        private void Chk_bal_ware_CheckedChanged(object sender, EventArgs e)
        {
            //chk_bal_ware
            if (chk_bal_ware.Checked == true)
            {
                Properties.Settings.Default.chk_bal_ware = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.chk_bal_ware = false;
                Properties.Settings.Default.Save();
            }
        }
        private void Chk_search_lang_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_search_lang.Checked == true)
            {
                Properties.Settings.Default.chk_search_lang = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.chk_search_lang = false;
                Properties.Settings.Default.Save();
            }
        }
        private void Dgv_recv_RowsAdded_1(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv_recv, "no_recev");
        }
        private void Dgv_recv_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                double sum = 0;
                for (int i = 0; i < dgv_recv.Rows.Count; i++)
                {
                    string dgv_null = dgv_recv.Rows[i].Cells[3].Value+"";
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
        private void txt_discount_all_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void txt_pres_descount_all_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void txt_discount_all_Leave(object sender, EventArgs e)
        {
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
                if (dgv.Rows.Count==0)
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
        private void txt_pres_descount_all_Leave(object sender, EventArgs e)
        {
            calc_discount_pres();
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
        private void Combo_name_emp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combo_code_emp.Text = db.GetData("select emp_name from emps where emp_no='" + combo_name_emp.Text + "'").Rows[0][0].ToString();
            }
            catch (Exception)
            {
            }
        }
        //================================hotkeys========================================
        private void add_barcode()
        {
            //to make language keybord English 
            CultureInfo TypeOfLanguage = CultureInfo.CreateSpecificCulture("en-US");
            System.Threading.Thread.CurrentThread.CurrentCulture = TypeOfLanguage;
            InputLanguage l = InputLanguage.FromCulture(TypeOfLanguage);
            InputLanguage.CurrentInputLanguage = l;

            code_items_a = "";
            string str1 = txt_barcode.Text;
            /*if (str1.Contains("+") == true)*/ 
            str1 = Regex.Replace(str1, "[+]+", "").Remove(Regex.Replace(str1, "[+]+", "").Length - 1, 1);

            code_items_a = db.GetData("select isnull(max(code_items),null) from items where code_items='" + str1 + "'").Rows[0][0].ToString();
            string str2 = db.GetData("select isnull(max(couta_type),0) from items where code_items='" + code_items_a + "'").Rows[0][0].ToString();
            if (code_items_a == "")
                code_items_a = db.GetData("select isnull(max(code_items),null) from barcode where barcode='" + txt_barcode.Text + "'").Rows[0][0].ToString();
            if (code_items_a == "")
            {
                XtraMessageBox.Show(combo_name_emp, "لايوجد صنف  ..يجب تكويد الصنف", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txt_barcode.Clear();
                return;
            }
            else
            {
                if ("1" == str2)
                {
                    if (Convert.ToInt32(db.GetData("select isnull( COUNT( datediff(day,last_date,(GETDATE())) ),0) from couta where vcs_code='" + combo_code_vcs.Text + "' ").Rows[0][0].ToString()) != 0 && Convert.ToInt32(db.GetData("select isnull(max(couta_date_select),null) from couta where code_items='" + code_items_a + "'").Rows[0][0].ToString()) < Convert.ToInt32(db.GetData("select top 1 datediff(day,last_date,(GETDATE())) from couta where vcs_code='" + combo_code_vcs.Text + "' order by last_date desc").Rows[0][0].ToString()))
                    {
                        XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "رصيد خلص من الكوتة  او يجب تكويد عميل في الاول لكي يتم صرف نظام الكوتة", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        txt_barcode.Clear();
                        return;
                    }
                    else
                    {
                        double num2 = Convert.ToDouble(db.GetData("select isnull(max((couta_qty-couta_bal)),null) from couta where code_items='" + code_items_a + "' and vcs_code='" + combo_code_vcs.Text + "'").Rows[0][0].ToString());
                        int num3 = 0;
                        if (Convert.ToDouble(this.txt_qty.Text) > num2)
                        {
                            try
                            {
                                num3 = Convert.ToInt32(db.GetData("select  datediff(day,last_date,(GETDATE())) from couta where vcs_code='" + combo_code_vcs.Text + "' order by last_date desc").Rows[0][0].ToString());
                            }
                            catch (Exception ex)
                            {
                            }
                            if (num3 >= 1)
                            {
                                db.Run("update couta set couta_bal='0' where code_items='" + code_items_a + "' and vcs_code='" + combo_code_vcs.Text + "'");
                            }
                            else
                            {
                                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, num2 + " \n  الرصيد اقل من الكوتة   ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                txt_barcode.Text = "";
                                return;
                            }
                        }
                    }
                }
                name_items_a = db.GetData("select isnull(max(name_items),0) from items where code_items='" + code_items_a + "'").Rows[0][0].ToString();
                name_unite_a = db.GetData("select isnull(max(name_unite),0) from items where code_items='" + code_items_a + "'").Rows[0][0].ToString();
                unit1 = db.GetData("select isnull(max(unit1),0) from items where code_items='" + code_items_a + "'").Rows[0][0].ToString();
                price_items_a = db.GetData("select isnull(max(price_sale),0) from items where code_items='" + code_items_a + "'").Rows[0][0].ToString();
                taxes_a = db.GetData("select isnull(max(taxes),0) from items where code_items='" + code_items_a + "'").Rows[0][0].ToString();
                type_a = db.GetData("select isnull(max([type]),0) from items where code_items='" + code_items_a + "'").Rows[0][0].ToString();
                couta_type_items_a = str2;
                try
                {
                    exp_a = db.GetData("select [exp] from items where code_items='" + code_items_a + "'").Rows[0][0].ToString();
                }
                catch (Exception ex)
                {
                    db.log_error(string.Concat(ex));
                }
                if (this.lbl_over_draft.Text == "1")
                {
                    add_in_dgv_with_virber(this.code_items_a);
                    txt_barcode.Text = "";
                    return;
                }
                else
                {
                    double num2 = 0.0;
                    try
                    {
                        num2 = Convert.ToDouble(db.GetData("select ((select isnull(sum(d.qty),0) from pos_dt as d left join pos_shift as s on d.shift_no=s.shift_no where s.lock='1'  and d.state ='sal' and d.code_items=items.code_items)-(select isnull(sum(d.qty),0) from pos_dt as d left join pos_shift as s on d.shift_no=s.shift_no where s.lock='1'  and d.state ='re' and d.code_items=items.code_items))  from items left join wares on items.code_items=wares.code_items where items.type='1'and qty > 0 and id_ware='" + lbl_wares.Text + "' and items.code_items='" + code_items_a + "'").Rows[0][0].ToString());
                    }
                    catch (Exception ex)
                    {
                    }
                    if (this.lbl_over_draft.Text == "2")
                    {
                        if (this.lbl_over_draft.Text == "2" && num2 <= 0.0)
                        {
                            XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "لايوجد رصيد من الصنف ", "رصيد", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            add_in_dgv_with_virber(this.code_items_a);
                            txt_barcode.Text = "";
                            return;
                        }
                        else if (this.lbl_over_draft.Text == "2" || num2 >= 1.0)
                        {
                            add_in_dgv_with_virber(this.code_items_a);
                            txt_barcode.Text = "";
                            return;
                        }
                    }
                    if (this.lbl_over_draft.Text == "3" && num2 <= 1.0)
                    {
                        XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "لايوجد رصيد من الصنف ", "رصيد", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        txt_barcode.Text = "";
                        return;
                    }
                    else
                    {

                        calc_all();
                        txt_barcode.Clear();
                        txt_barcode.Select();
                        txt_qty.Text = "1";
                    }
                }
            }

        }
        private void txt_barcode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F1)
                {
                    int num1 = (int)((Form)new frm_customer()).ShowDialog();
                }
                if (e.KeyCode == Keys.F2)
                {
                    all_comb.load_customer_only_name(this.combo_name_vcs);
                   combo_name_vcs.Text = "";
                    ((Control)this.combo_name_vcs).Select();
                }
                ////if (e.KeyCode == Keys.T)
                ////{
                ////    all_comb.load_phone(this.combo_phone_vcs, "customer");
                ////   combo_phone_vcs.Text = "";
                ////    ((Control)this.combo_phone_vcs).Select();
                ////}
                if (e.KeyCode == Keys.F3)
                {
                    all_comb.load_emp_name(this.combo_name_emp);
                    combo_name_emp.Text = "";
                    combo_name_emp.Select();
                }
                if (e.KeyCode == Keys.F7)
                    btn_pinding.PerformClick();
                if (e.KeyCode == Keys.Escape)
                    txt_search.Select();
                if (e.KeyCode == Keys.F5)
                    btn_receve.PerformClick();
                if (e.KeyCode == Keys.Return)
                {
                    if (btn_resale_2.Checked == false)
                    {
                        add_barcode();
                        dgv.CurrentCell = dgv.Rows[dgv.Rows.Count - 1].Cells[0];

                    }
                    else if (btn_resale_2.Checked == true && return_inv_without_noinv)
                    {
                        add_barcode();
                        dgv.CurrentCell = dgv.Rows[dgv.Rows.Count - 1].Cells[0];

                    }
                }
                if (e.KeyCode == Keys.Left)
                {
                    ((Control)this.txt_qty).Select();
                   txt_qty.Text = "";
                }
                if (e.KeyCode == Keys.Right)
                {
                    ((Control)this.txt_qty).Select();
                   txt_qty.Text = "";
                }
            }
            catch (Exception ex)
            {
                db.log_error(string.Concat(ex));
            }
        }
        private void txt_qty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                txt_barcode.Select();
            }
            if (e.KeyCode == Keys.Right)
            {
                txt_barcode.Select();
            }
            if (e.KeyCode == Keys.F1)
            {
                txt_search.Select();
            }
        }
        private void txt_search_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
               
                 if (e.KeyCode == Keys.Left)
                {
                    txt_barcode.Select();
                }
                if (e.KeyCode == Keys.Right)
                {
                    txt_barcode.Select();
                }
                if (e.KeyCode == Keys.Down)
                {
                    dgv_search.Select();
                }
                if (e.KeyCode == Keys.Up)
                {
                    dgv_search.Select();
                }
              
            }
            catch (Exception)
            {
            }
        }
        private void dgv_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (btn_resale_2.Checked == false)
                {
                    add_in_dgv();
                }
                else if (btn_resale_2.Checked == true && return_inv_without_noinv)
                {
                    add_in_dgv();
                }
            }
            if (e.KeyCode == Keys.Right)
            {
                dgv.Select();
            }
            if (e.KeyCode == Keys.Left)
            {
                dgv.Select();
            }
        }
        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                dgv_search.Select();
            }
            if (e.KeyCode == Keys.Delete)
            {
                calc_all();
            }
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

        private void dgv_search_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 1)
            {
                if (btn_resale_2.Checked == false)
                {
                    add_in_dgv();
                }
                else if (btn_resale_2.Checked == true && return_inv_without_noinv)
                {
                    add_in_dgv();
                }
            }
        }

        private void txt_search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '\'') )
            {
                e.Handled = true;
            }
          
        }
        private void txt_search_Click(object sender, EventArgs e)
        {
                if (!ckk_lang_write.Checked)
                {
                    //to make language keybord Arabic
                    CultureInfo TypeOfLanguage = CultureInfo.CreateSpecificCulture("ar-EG");
                    System.Threading.Thread.CurrentThread.CurrentCulture = TypeOfLanguage;
                    InputLanguage l = InputLanguage.FromCulture(TypeOfLanguage);
                    InputLanguage.CurrentInputLanguage = l;
                }
        }
        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            if (!ckk_lang_write.Checked)
            {
                //to make language keybord Arabic
                CultureInfo TypeOfLanguage = CultureInfo.CreateSpecificCulture("ar-EG");
                System.Threading.Thread.CurrentThread.CurrentCulture = TypeOfLanguage;
                InputLanguage l = InputLanguage.FromCulture(TypeOfLanguage);
                InputLanguage.CurrentInputLanguage = l;
            }

            DataTable tb = new DataTable();
            if (!chk_bal_ware.Checked)
            {
                if (chk_search_lang.Checked)
                    db.GetData_DGV("select top "+v.qty_max_search+" code_items,name_items,name_unite,price_sale,unit1,taxes,couta_type from items where type='1'and name_items like '%" + txt_search.Text + "%'", tb);
                else if (!chk_search_lang.Checked)
                    db.GetData_DGV("select top " + v.qty_max_search + " code_items,name_items2 as name_items ,name_unite,price_sale,unit1,taxes,couta_type from items where type='1'and name_items2 like '%" + txt_search.Text + "%'", tb);
                dgv_search.DataSource = tb;
            }
            else if (chk_search_lang.Checked || chk_search_lang.Checked && !chk_search_lang.Checked)
            {
                // db.GetData_DGV("select items.code_items as code_items ,items.name_items as name_items,items.name_unite as name_unite ,items.price_sale as price_sale,items.unit1 as unit1,wares.qty+((select isnull(sum(d.qty*-1),0) from pos_dt as d left join pos_shift as s on d.shift_no=s.shift_no where s.lock='1'  and d.code_items=items.code_items)-(select isnull(sum(d.qty),0) from pos_dt as d left join pos_shift as s on d.shift_no=s.shift_no where s.lock='1'  and d.code_items=items.code_items))as qty,taxes,couta_type from items left join wares on items.code_items=wares.code_items where items.type='1'and qty != 0 and id_ware='"+lbl_wares.Text+"' and items.name_items like '%" + txt_search.Text + "%'", tb);


                // db.GetData_DGV("select items.code_items as code_items ,items.name_items as name_items,items.name_unite as name_unite ,taxes,couta_type,items.price_sale as price_sale,items.unit1 as unit1, wares.qty +((select isnull(sum(qty*-1),0) from pos_dt  where  code_items=items.code_items)) as qty from items left join wares  on items.code_items=wares.code_items   where items.type='1'and qty != 0 and id_ware='" + lbl_wares.Text+ "' and items.name_items like'%" + txt_search.Text + "%'", tb);

                db.GetData_DGV("select top " + v.qty_max_search + " items.code_items as code_items ,items.name_items as name_items,items.name_unite as name_unite ,taxes,couta_type,items.price_sale as price_sale,items.unit1 as unit1, wares.qty +((select isnull(sum(qty*-1),0) from pos_dt p left join pos_shift s  on p.shift_no=s.shift_no where s.lock='1'  and p.code_items=items.code_items)) as qty from items left join wares  on items.code_items=wares.code_items   where items.type='1'and qty != 0 and id_ware='" + lbl_wares.Text + "' and items.name_items like'%" + txt_search.Text + "%'", tb);

                dgv_search.DataSource = tb;
            }
            else
            {
                if (!chk_search_lang.Checked && chk_search_lang.Checked && !chk_search_lang.Checked)
                    return;
                //db.GetData_DGV("select items.code_items as code_items ,items.name_items2 as name_items,items.name_unite as name_unite ,items.price_sale as price_sale,items.unit1 as unit1,wares.qty+((select isnull(sum(d.qty*-1),0) from pos_dt as d left join pos_shift as s on d.shift_no=s.shift_no where s.lock='1'  and d.code_items=items.code_items)-(select isnull(sum(d.qty),0) from pos_dt as d left join pos_shift as s on d.shift_no=s.shift_no where s.lock='1'  and d.code_items=items.code_items))as qty,taxes,couta_type from items left join wares on items.code_items=wares.code_items where items.type='1'and qty != 0 and id_ware='"+lbl_wares.Text+"'  and items.name_items2 like '%" + txt_search.Text + "%'", tb);

                db.GetData_DGV("select top " + v.qty_max_search + " items.code_items as code_items ,items.name_items2 as name_items,items.name_unite as name_unite ,taxes,couta_type,items.price_sale as price_sale,items.unit1 as unit1, wares.qty +((select isnull(sum(qty*-1),0) from pos_dt p left join pos_shift s  on p.shift_no=s.shift_no where s.lock='1'  and p.code_items=items.code_items)) as qty from items left join wares  on items.code_items=wares.code_items   where items.type='1'and qty != 0 and id_ware='" + lbl_wares.Text + "' and items.name_items like '%" + txt_search.Text + "%'", tb);

                dgv_search.DataSource = tb;
            }
        }

        private void lbl_stat_cost_items_n_HyperlinkClick(object sender, DevExpress.Utils.HyperlinkClickEventArgs e)
        {
            pos.frm_items_card f = new frm_items_card();
            f.Show();
            f.combo_code_items.Text = dgv.CurrentRow.Cells[1].Value + "";
            f.btn_serchinv.PerformClick();
        }

        private void lbl_stat_cost_items_n_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv.Rows.Count == 0) return;
                pos.frm_items_card f = new frm_items_card();
                f.Show();
                f.combo_code_items.Text = dgv.CurrentRow.Cells[1].Value + "";
                f.btn_serchinv.PerformClick();
                lbl_stat_cost_items_n.ForeColor = Color.Blue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void txt_desc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '\''))
            {
                e.Handled = true;
            }
        }

        private void btn_adv_search_Click(object sender, EventArgs e)
        {
            pos.frm_matrex_search f = new frm_matrex_search();
            f.ShowDialog();
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

        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            calc_current_user();
        }
        private void Column1_KeyPress(object sender, KeyPressEventArgs e)//dgv prevent edit only number
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)//dgv prevent edit only number
        {
            ////cloes edit on discount and qty price
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);
            if (dgv.CurrentCell.ColumnIndex == 9) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }

            if (dgv.CurrentCell.ColumnIndex == 10) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
            if (dgv.CurrentCell.ColumnIndex == 11) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
            if (dgv.CurrentCell.ColumnIndex == 13) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }

        }
        //-------------------------EXPENSESS
        private void btn_search_Expensses_Click(object sender, EventArgs e)
        {
            //combo_add_account.DataSource = null;
            //combo_add_account.Items.Clear();

            //if (rdcustomer.Checked == true)
            //{
            //    f1.all_comb.load_customer_only_name(combo_add_account);
            //}
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
        private void combo_acc_expenss_SelectedIndexChanged(object sender, EventArgs e)
        {
           
               
           
        }
        private void btn_del_expenses_Click(object sender, EventArgs e)
        {
            combo_acc_expenss.Text = "";
            lbl_acc_expensses.Text = "";
            txt_desc.Text = "";
            num_amount_exp.Value = 0;
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
            if (num_amount_exp.Value==0)
            {
                MessageBox.Show("يجب ادخال مبلغ");
                return;
            }
            if (txt_desc.Text=="")
            {
                MessageBox.Show("يجب ادخال وصف للمصروف");
                return;
            }
            if ("0"==db.GetData("select isnull(max(rootid),0) from tree where rootid='"+lbl_acc_expensses.Text+ "' and type_acc='c'").Rows[0][0].ToString())
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
            string cash = num_amount_exp.Value+""; 
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
            if (db.GetData("select isnull(max(depit),0) from entry where code_entry='"+code_entry+"'").Rows[0][0]+""!="0")
            {
                MessageBox.Show("تم حفظ ");

            }
            num_amount_exp.Value = 0;
            txt_desc.Text = "";
            combo_acc_expenss.Text = "";
            lbl_acc_expensses.Text = "0";

            //==============
        }

    }
}