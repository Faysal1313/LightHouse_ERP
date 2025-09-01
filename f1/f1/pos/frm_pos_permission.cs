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
    public partial class frm_pos_permission : DevExpress.XtraEditors.XtraForm
    {
        public frm_pos_permission()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
        }
        private void frm_pos_permission_Load(object sender, EventArgs e)
        {
            all_comb.load_emp_users_code(combo_empcode);
            combo_empcode.Text = "";
            lbl_name.Text = "";

            pos_t_f.Checked = false;
            pind_inv.Checked = false;
            delet_inv.Checked = false;
            return_inv.Checked = false;
            vcs_code.Checked = false;
            vcs_show.Checked = false;
            sale_price.Checked = false;
            discount_rows.Checked = false;
            discount.Checked = false;
            blow_cost.Checked = false;
            state.Checked = false;
            cash.Checked = false;
            exp.Checked = false;


            c_unit.Checked = false;
            c_price_no_taxes.Checked = false;
            c_price_taxes.Checked = false;
            c_tot_befor_discount.Checked = false;
            c_discount.Checked = false;
            c_tot_after_discount.Checked = false;
            c_taxes.Checked = false;
            c_incloud_taxes.Checked = false;
            c_value_taxes.Checked = false;

            pos_t_f.Checked = false;
            shift.Checked = false;
            state_shift.Checked = false;
            open_shift.Checked = false;
            close_shift.Checked = false;
            det_shift.Checked = false;


            inventroy.Checked = false;
            code_items.Checked = false;
            balance_qty.Checked = false;
            offer.Checked = false;
            barcode.Checked = false;
            adj.Checked = false;


            purchase.Checked = false;
            inv_pur.Checked = false;
            inv_rpur.Checked = false;

            gl.Checked = false;
            recev_cash.Checked = false;
            pay_cash.Checked = false;


            settings.Checked = false;
            report.Checked = false;


        }

        private void combo_empcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_name.Text = db.GetData("select isnull(max([user_name]),0) from emps where emp_no='" + combo_empcode.Text + "'").Rows[0][0].ToString();

                if (combo_empcode.Text != "")
                {
                    pos_t_f.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='pos_t_f' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());
                    pind_inv.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='pind_inv' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());
                    delet_inv.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='delet_inv' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());
                    return_inv.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='return_inv' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());
                    return_inv_without_noinv.Checked= Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='return_inv_without_noinv' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());
                    expensses.Checked=Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='expensses' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());
                    vcs_code.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='vcs_code' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());
                    vcs_show.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='vcs_show' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());
                    sale_price.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='sale_price' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());
                    discount_rows.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='discount_rows' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());
                    discount.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='discount' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());
                    blow_cost.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='blow_cost' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());
                    state.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='state' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());
                    cash.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='cash' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());
                    exp.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='exp' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());


                    c_unit.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='c_unit' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());
                    c_price_no_taxes.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='c_price_no_taxes' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());
                    c_price_taxes.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='c_price_taxes' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());
                    c_tot_befor_discount.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='c_tot_befor_discount' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());
                    c_discount.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='c_discount' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());
                    c_tot_after_discount.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='c_tot_after_discount' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());
                    c_taxes.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='c_taxes' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());
                    c_incloud_taxes.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='c_incloud_taxes' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());
                    c_value_taxes.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='c_value_taxes' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());


                    shift.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='shift' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());
                    state_shift.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='state_shift' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());
                    open_shift.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='open_shift' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());
                    close_shift.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='close_shift' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());
                    det_shift.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='det_shift' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());


                    inventroy.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='inventroy' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());
                    code_items.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='code_items' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());
                    balance_qty.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='balance_qty' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());
                    offer.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='offer' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());
                    barcode.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='barcode' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());
                    adj.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='adj' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());


                    purchase.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='purchase' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());
                    inv_pur.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='inv_pur' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());
                    inv_rpur.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='inv_rpur' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());

                    gl.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='gl' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());
                    recev_cash.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='recev_cash' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());
                    pay_cash.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='pay_cash' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());


                    settings.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='settings' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());
                    report.Checked = Convert.ToBoolean(db.GetData("select torf from pos_permission where unite='report' and user_code='" + combo_empcode.Text + "'").Rows[0][0].ToString());


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btn_save_pos_Click(object sender, EventArgs e)
        {
            if (combo_empcode.Text!="")
            {
                db.Run("update pos_permission set torf='" + pos_t_f.Checked + "' where user_code='" + combo_empcode.Text + "' and unite='pos_t_f' ");
                db.Run("update pos_permission set torf='" + pind_inv.Checked + "' where user_code='" + combo_empcode.Text + "' and  unite='pind_inv'");
                db.Run("update pos_permission set torf='" + delet_inv.Checked + "' where user_code='" + combo_empcode.Text + "' and  unite='delet_inv'");
                db.Run("update pos_permission set torf='" + return_inv.Checked + "' where user_code='" + combo_empcode.Text + "' and unite='return_inv' ");
                db.Run("update pos_permission set torf='" + return_inv_without_noinv.Checked + "' where user_code='" + combo_empcode.Text + "' and unite='return_inv_without_noinv' ");
                db.Run("update pos_permission set torf='" + expensses.Checked + "' where user_code='" + combo_empcode.Text + "' and unite='expensses' ");

                db.Run("update pos_permission set torf='" + vcs_code.Checked + "' where user_code='" + combo_empcode.Text + "' and unite='vcs_code'");
                db.Run("update pos_permission set torf='" + vcs_show.Checked + "' where user_code='" + combo_empcode.Text + "' and unite='vcs_show' ");
                db.Run("update pos_permission set torf='" + sale_price.Checked + "' where user_code='" + combo_empcode.Text + "' and  unite='sale_price'");
                db.Run("update pos_permission set torf='" + discount_rows.Checked + "' where user_code='" + combo_empcode.Text + "' and  unite='discount_rows'");
                db.Run("update pos_permission set torf='" + discount.Checked + "' where user_code='" + combo_empcode.Text + "' and  unite='discount'");
                db.Run("update pos_permission set torf='" + blow_cost.Checked + "'  where user_code='" + combo_empcode.Text + "' and unite='blow_cost'");
                db.Run("update pos_permission set torf='" + state.Checked + "'  where user_code='" + combo_empcode.Text + "' and unite='state'");
                db.Run("update pos_permission set torf='" + cash.Checked + "'  where user_code='" + combo_empcode.Text + "' and unite='cash'");
                db.Run("update pos_permission set torf='" + exp.Checked + "' where user_code='" + combo_empcode.Text + "' and  unite='exp'");

                db.Run("update pos_permission set torf='" + c_unit.Checked + "'  where user_code='" + combo_empcode.Text + "' and unite='c_unit'");
                db.Run("update pos_permission set torf='" + c_price_no_taxes.Checked + "' where user_code='" + combo_empcode.Text + "' and  unite='c_price_no_taxes'");
                db.Run("update pos_permission set torf='" + c_price_taxes.Checked + "' where user_code='" + combo_empcode.Text + "' and  unite='c_price_taxes'");
                db.Run("update pos_permission set torf='" + c_tot_befor_discount.Checked + "' where user_code='" + combo_empcode.Text + "' and unite='c_tot_befor_discount'");
                db.Run("update pos_permission set torf='" + c_discount.Checked + "' where user_code='" + combo_empcode.Text + "' and  unite='c_discount'");
                db.Run("update pos_permission set torf='" + c_tot_after_discount.Checked + "' where user_code='" + combo_empcode.Text + "' and  unite='c_tot_after_discount'");
                db.Run("update pos_permission set torf='" + c_taxes.Checked + "'  where user_code='" + combo_empcode.Text + "' and unite='c_taxes'");
                db.Run("update pos_permission set torf='" + c_incloud_taxes.Checked + "' where user_code='" + combo_empcode.Text + "' and  unite='c_incloud_taxes'");
                db.Run("update pos_permission set torf='" + c_value_taxes.Checked + "'  where user_code='" + combo_empcode.Text + "' and unite='c_value_taxes'");
                MessageBox.Show("تم التعديل");
            }

        }

       
        private void btn_inv_Click(object sender, EventArgs e)
        {
            if (combo_empcode.Text!="")
            {
                db.Run("update pos_permission set torf='" + inventroy.Checked + "' where user_code='" + combo_empcode.Text + "' and unite='inventroy' ");
                db.Run("update pos_permission set torf='" + code_items.Checked + "' where user_code='" + combo_empcode.Text + "' and unite='code_items' ");
                db.Run("update pos_permission set torf='" + balance_qty.Checked + "' where user_code='" + combo_empcode.Text + "' and unite='balance_qty' ");
                db.Run("update pos_permission set torf='" + offer.Checked + "' where user_code='" + combo_empcode.Text + "' and unite='offer' ");
                db.Run("update pos_permission set torf='" + barcode.Checked + "' where user_code='" + combo_empcode.Text + "' and unite='barcode' ");
                db.Run("update pos_permission set torf='" + adj.Checked + "' where user_code='" + combo_empcode.Text + "' and unite='adj' ");
                MessageBox.Show("تم التعديل");
            }
        }

        private void btn_pur_Click(object sender, EventArgs e)
        {
            if (combo_empcode.Text != "")
            {
                db.Run("update pos_permission set torf='" + purchase.Checked + "' where user_code='" + combo_empcode.Text + "' and unite='purchase' ");
                db.Run("update pos_permission set torf='" + inv_pur.Checked + "' where user_code='" + combo_empcode.Text + "' and unite='inv_pur' ");
                db.Run("update pos_permission set torf='" + inv_rpur.Checked + "' where user_code='" + combo_empcode.Text + "' and unite='inv_rpur' ");
                MessageBox.Show("تم التعديل");
            }
        }

        private void xtraTabPage4_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void btn_basec_Click(object sender, EventArgs e)
        {
            if (combo_empcode.Text != "")
            {
                db.Run("update pos_permission set torf='" + settings.Checked + "' where user_code='" + combo_empcode.Text + "' and unite='settings' ");
                db.Run("update pos_permission set torf='" + report.Checked + "' where user_code='" + combo_empcode.Text + "' and unite='report' ");
                MessageBox.Show("تم التعديل");
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (combo_empcode.Text != "")
            {
                //MessageBox.Show(state_shift.Checked+"");
                db.Run("update pos_permission set torf='" + shift.Checked + "' where user_code='" + combo_empcode.Text + "' and unite='shift' ");
                db.Run("update pos_permission set torf='" + state_shift.Checked + "' where user_code='" + combo_empcode.Text + "' and unite='state_shift' ");
                db.Run("update pos_permission set torf='" + open_shift.Checked + "' where user_code='" + combo_empcode.Text + "' and unite='open_shift' ");
                db.Run("update pos_permission set torf='" + close_shift.Checked + "' where user_code='" + combo_empcode.Text + "' and unite='close_shift' ");
                db.Run("update pos_permission set torf='" + det_shift.Checked + "' where user_code='" + combo_empcode.Text + "' and unite='det_shift' ");
                MessageBox.Show("تم التعديل");
            }
        }

        private void btn_gl_Click(object sender, EventArgs e)
        {
            if (combo_empcode.Text != "")
            {
                db.Run("update pos_permission set torf='" + recev_cash.Checked + "' where user_code='" + combo_empcode.Text + "' and unite='recev_cash' ");
                db.Run("update pos_permission set torf='" + pay_cash.Checked + "' where user_code='" + combo_empcode.Text + "' and unite='pay_cash' ");
                MessageBox.Show("تم التعديل");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            pos_t_f.Checked = true;
            pind_inv.Checked= true; 
            delet_inv.Checked= true;
            return_inv.Checked= true;
            return_inv_without_noinv.Checked = true;
            expensses.Checked = true;
            vcs_code.Checked= true; 
            vcs_show.Checked= true; 
            sale_price.Checked= true; 
            discount_rows.Checked= true;
            discount.Checked = true;
            blow_cost.Checked= true; 
            state.Checked= true; 
            cash.Checked= true; 
            exp.Checked= true; 



            c_unit.Checked= true;
            c_price_no_taxes.Checked= true;
            c_price_taxes.Checked= true; 
            c_tot_befor_discount.Checked= true;
            c_discount.Checked= true;
            c_tot_after_discount.Checked= true; 
            c_taxes.Checked= true;
            c_incloud_taxes.Checked= true; 
            c_value_taxes.Checked= true;

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            pos_t_f.Checked = false;
            pind_inv.Checked = false;
            delet_inv.Checked = false;
            return_inv.Checked =  false;
            return_inv_without_noinv.Checked = false;
            expensses.Checked = false;
            vcs_code.Checked = false;
            vcs_show.Checked = false;
            sale_price.Checked = false;
            discount_rows.Checked = false;
            discount.Checked = false;
            blow_cost.Checked = false;
            state.Checked = false;
            cash.Checked = false;
            exp.Checked = false;


            c_unit.Checked = false;
            c_price_no_taxes.Checked = false;
            c_price_taxes.Checked = false;
            c_tot_befor_discount.Checked = false;
            c_discount.Checked = false;
            c_tot_after_discount.Checked = false;
            c_taxes.Checked = false;
            c_incloud_taxes.Checked = false;
            c_value_taxes.Checked = false;

        }

        private void btn_permission_programs_Click(object sender, EventArgs e)
        {
            frm_permissions f = new frm_permissions();
            f.ShowDialog();
        }

        private void btn_trans_permission_Click(object sender, EventArgs e)
        {
            string emp1 = "";
            string emp2 = "";
            emp1 = db.GetData("select isnull(max(emp_no),0) from emps where emp_no='" + txt_main_emp.Text+"'").Rows[0][0].ToString();
            emp2 = db.GetData("select isnull(max(emp_no),0) from emps where emp_no='" + txt_emp2.Text + "'").Rows[0][0].ToString();
            if (emp1 == "0") return;
            if (emp2 == "0") return;

            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            DataTable dt5 = new DataTable();



            db.GetData_DGV("select user_code,name_frm,visible from permission where user_code='" + emp1+"' ", dt1);
            db.Run("delete from permission where user_code='" + emp2 + "'");
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                db.Run("insert into permission (user_code,name_frm,visible)values('"+ emp2  + "','" + dt1.Rows[i][1] + "" + "','" + dt1.Rows[i][2] + "" + "') ");
            }

            db.GetData_DGV("select user_code,user_name,name_frm,[save], [delete], edit_only, add_only, [print] from permission_sub where user_code='" + emp1 + "' ", dt2);
            db.Run("delete from permission_sub where user_code='" + emp2 + "'");
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                db.Run("insert into permission_sub (user_code,user_name,name_frm,[save], [delete], edit_only, add_only, [print]) values ('" + emp2 + "','" + dt2.Rows[i][1]+"" + "','" + dt2.Rows[i][2] + "" + "','" + dt2.Rows[i][3] + "" + "','" + dt2.Rows[i][4] + "" + "','" + dt2.Rows[i][5] + "" + "','" + dt2.Rows[i][6] + "" + "','" + dt2.Rows[i][7] + "" + "')");
            }


            db.GetData_DGV("select user_code,unite,torf from pos_permission where user_code='" + emp1 + "' ", dt3);
            db.Run("delete from pos_permission where user_code='" + emp2 + "'");
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                db.Run("insert into pos_permission (user_code,unite,torf)values('" + emp2 + "','" + dt3.Rows[i][1] + "" + "','" + dt3.Rows[i][2] + "" + "') ");
            }

            db.GetData_DGV("select user_code,name_frm,visible from permission_sub_screen where user_code='" + emp1 + "' ", dt4);
            db.Run("delete from permission_sub_screen where user_code='" + emp2 + "'");
            for (int i = 0; i < dt4.Rows.Count; i++)
            {
                db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + emp2 + "','" + dt4.Rows[i][1] + "" + "','" + dt4.Rows[i][2] + "" + "')");
            }

            db.GetData_DGV("select [medil],[user_code] ,    [cash_main],    [sales_acc],    [re_sales_acc],    [disocount],    [wares],    [code_book],    [cogs],    [def_or_inc],    [cash1_account],    [cash2_account],    [cash3_account],    [cash4_account],    [cash5_account],    [cash6_account],    [cash7_account],    [cash8_account],    [cash9_account],    [cash10_account],    [cash1_name],    [cash2_name],    [cash3_name],    [cash4_name],    [cash5_name],    [cash6_name],    [cash7_name],    [cash8_name],    [cash9_name],    [cash10_name],    [cash1_type],    [cash2_type],   [cash3_type],    [cash4_type],    [cash5_type],    [cash6_type],    [cash7_type],    [cash8_type],    [cash9_type],    [cash10_type],    [cash1_currency],    [cash2_currency],    [cash3_currency],    [cash4_currency],    [cash5_currency],    [cash6_currency],    [cash7_currency],    [cash8_currency],    [cash9_currency],    [cash10_currency] from pos_cash_account where user_code='" + emp1 + "' ", dt5);
            db.Run("delete from pos_cash_account where user_code='" + emp2 + "'");
            for (int i = 0; i < dt5.Rows.Count; i++)
            {
                db.Run("insert into pos_cash_account ([medil],[user_code] ,    [cash_main],    [sales_acc],    [re_sales_acc],    [disocount],    [wares],    [code_book],    [cogs],    [def_or_inc],    [cash1_account],    [cash2_account],    [cash3_account],    [cash4_account],    [cash5_account],    [cash6_account],    [cash7_account],    [cash8_account],    [cash9_account],    [cash10_account],    [cash1_name],    [cash2_name],    [cash3_name],    [cash4_name],    [cash5_name],    [cash6_name],    [cash7_name],    [cash8_name],    [cash9_name],    [cash10_name],    [cash1_type],    [cash2_type],   [cash3_type],    [cash4_type],    [cash5_type],    [cash6_type],    [cash7_type],    [cash8_type],    [cash9_type],    [cash10_type],    [cash1_currency],    [cash2_currency],    [cash3_currency],    [cash4_currency],    [cash5_currency],    [cash6_currency],    [cash7_currency],    [cash8_currency],    [cash9_currency],    [cash10_currency]) values ('" + dt5.Rows[i][0] + "" + "','" + emp2 + "','" + dt5.Rows[i][2] + "" + "','" + dt5.Rows[i][3] + "" + "','" + dt5.Rows[i][4] + "" + "','" + dt5.Rows[i][5] + "" + "','" + dt5.Rows[i][6] + "" + "','" + dt5.Rows[i][7] + "" + "','" + dt5.Rows[i][8] + "" + "','" + dt5.Rows[i][9] + "" + "','" + dt5.Rows[i][10] + "" + "','" + dt5.Rows[i][11] + "" + "','" + dt5.Rows[i][12] + "" + "','" + dt5.Rows[i][13] + "" + "','" + dt5.Rows[i][14] + "" + "','" + dt5.Rows[i][15] + "" + "','" + dt5.Rows[i][16] + "" + "','" + dt5.Rows[i][17] + "" + "','" + dt5.Rows[i][18] + "" + "','" + dt5.Rows[i][19] + "" + "','" + dt5.Rows[i][20] + "" + "','" + dt5.Rows[i][21] + "" + "','" + dt5.Rows[i][22] + "" + "','" + dt5.Rows[i][23] + "" + "','" + dt5.Rows[i][24] + "" + "','" + dt5.Rows[i][25] + "" + "','" + dt5.Rows[i][26] + "" + "','" + dt5.Rows[i][27] + "" + "','" + dt5.Rows[i][28] + "" + "','" + dt5.Rows[i][29] + "" + "','" + dt5.Rows[i][30] + "" + "','" + dt5.Rows[i][31] + "" + "','" + dt5.Rows[i][32] + "" + "','" + dt5.Rows[i][33] + "" + "','" + dt5.Rows[i][34] + "" + "','" + dt5.Rows[i][35] + "" + "','" + dt5.Rows[i][36] + "" + "','" + dt5.Rows[i][37] + "" + "','" + dt5.Rows[i][38] + "" + "','" + dt5.Rows[i][39] + "" + "','" + dt5.Rows[i][40] + "" + "','" + dt5.Rows[i][41] + "" + "','" + dt5.Rows[i][42] + "" + "','" + dt5.Rows[i][43] + "" + "','" + dt5.Rows[i][44] + "" + "','" + dt5.Rows[i][45] + "" + "','" + dt5.Rows[i][46] + "" + "','" + dt5.Rows[i][47] + "" + "','" + dt5.Rows[i][48] + "" + "','" + dt5.Rows[i][49] + "" + "')");
            }
            MessageBox.Show("save");





        }



        //            pos
        //pind_inv
        //delet_inv
        //return_inv
        //vcs_code
        //vcs_show
        //sale_price
        //discount_rows
        //discount
        //blow_cost
        //state
        //cash
        //exp


        //c_unit
        //c_price_no_taxes
        //c_price_taxes
        //c_tot_befor_discount
        //c_discount
        //c_tot_after_discount
        //c_taxes
        //c_incloud_taxes
        //c_value_taxes


        //shift
        //state_shift
        //open_shift
        //close_shift
        //det_shift


        //inventroy
        //code_items
        //balance_qty
        //offer
        //barcode
        //adj


        //purchase
        //inv_pur
        //inv_rpur

        //gl
        //recev_cash
        //pay_cash


        //settings
        //report


    }
}