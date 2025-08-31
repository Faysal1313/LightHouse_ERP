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
using f1.Classes;

namespace f1
{
    public partial class frm_permissions : DevExpress.XtraEditors.XtraForm
    {
        public frm_permissions()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
            db.Open();
            
        }
        private void frm_permissions_Load(object sender, EventArgs e)
        {
            group_discount.Visible = false;
            group_price.Visible = false;
            group_discount_all.Visible = false;
        }
        private void combo_users_Click(object sender, EventArgs e)
        {
            all_comb.load_emp_users(combo_users);
        }
        private void combo_users_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_user_code.Text = db.GetData("select emp_no from emps where user_name='" + combo_users.Text + "'").Rows[0][0].ToString();

                chk_price.Checked = Convert.ToBoolean(db.GetData("select contral_sale_price from permission_price_discount where user_code='"+lbl_user_code.Text+"'").Rows[0][0].ToString());
                chk_discount.Checked=Convert.ToBoolean(db.GetData("select controal_sale_discount from permission_price_discount where user_code='"+lbl_user_code.Text+"'").Rows[0][0].ToString());
                chk_discount_all.Checked = Convert.ToBoolean(db.GetData("select controal_all_discount from permission_price_discount where user_code='" + lbl_user_code.Text + "'").Rows[0][0].ToString());

                chk_prevent_blowcost.Checked = Convert.ToBoolean(db.GetData("select blow_cost_price from permission_price_discount where user_code='" + lbl_user_code.Text + "'").Rows[0][0].ToString());
                chk_dis_privent_cost.Checked = Convert.ToBoolean(db.GetData("select blow_cost_discount from permission_price_discount where user_code='" + lbl_user_code.Text + "'").Rows[0][0].ToString());
                rdo_discount_all.Checked = Convert.ToBoolean(db.GetData("select blow_cost_all from permission_price_discount where user_code='" + lbl_user_code.Text + "'").Rows[0][0].ToString());
 


            }
           catch (Exception)
            {

            }
        }

        //1)-load first page load main 
        //_______________________________________________

            //function 


           //simple controls
        private void btn_get_permission_Click(object sender, EventArgs e)
        {
            if (combo_users.Text=="")
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default,  "اختار مستخدم", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable dt = new DataTable();
            //if (v.sec== "05111504se")
            //{
                db.GetData_DGV("select name_frm,visible from permission where  name_frm <> 'bank_mangement' and name_frm<>'manf_mangament'  and name_frm<>'inventory_management'  and name_frm<>'purchase_management'   and name_frm<>'sales_management'  and name_frm<>'account_management' and name_frm<>'hr_management'and user_code='" + lbl_user_code.Text + "'", dt);
            //}
            //else if(v.sec == "05111504ba")
            //{
            //    db.GetData_DGV("select name_frm,visible from permission where  name_frm <> 'bank_mangement' and name_frm<>'manf_mangament' and user_code='" + lbl_user_code.Text + "'", dt);
            //}
            //else if (true)
            //{
            //    db.GetData_DGV("select name_frm,visible from permission where  name_frm <> 'bank_mangement' and name_frm<>'manf_mangament' and user_code='" + lbl_user_code.Text + "'", dt);
            //}
            dgv_permission.DataSource = dt;
        }
        private void btn_save_permission_Click(object sender, EventArgs e)
        {
            if (combo_users.Text == "")
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "اختار مستخدم", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 0; i < dgv_permission.Rows.Count; i++)
            {
                db.Run("update permission set visible = '" + dgv_permission.Rows[i].Cells["visible_c"].Value.ToString() + "' where name_frm ='" + dgv_permission.Rows[i].Cells["name_frm_cc"].Value.ToString() + "' and  user_code='" + lbl_user_code.Text + "'");
            }
            MessageBox.Show("update");
        }
        private void chik_all_Click(object sender, EventArgs e)
        {
            if (combo_users.Text == "")
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "اختار مستخدم", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 0; i < dgv_permission.Rows.Count; i++)
            {
                dgv_permission.Rows[i].Cells["visible_c"].Value = true;

            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (combo_users.Text == "")
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "اختار مستخدم", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 0; i < dgv_permission.Rows.Count; i++)
            {
                dgv_permission.Rows[i].Cells["visible_c"].Value = false;

            }
        }



        //2)-load seconf page load sub main
        //_______________________________________________


        //3)-load therd page load screen 
        //_______________________________________________


          //function 


          //simple controls
        private void btn_get_sub_permission_Click(object sender, EventArgs e)
        {
            if (combo_users.Text == "")
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "اختار مستخدم", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable dt = new DataTable();
            db.GetData_DGV("select name_frm,[save],[delete],[edit_only],[add_only],[print] from permission_sub where user_code='" + lbl_user_code.Text + "'", dt);
            dgv.DataSource = dt;
        }
        private void btn_save_sub_permission_Click(object sender, EventArgs e)
        {
            if (combo_users.Text == "")
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "اختار مستخدم", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                db.Run("update permission_sub set [save] = '" + dgv.Rows[i].Cells["save_c"].Value.ToString() + "',[delete] = '" + dgv.Rows[i].Cells["delete_c"].Value.ToString() + "',edit_only = '" + dgv.Rows[i].Cells["edit_only_c"].Value.ToString() + "',add_only = '" + dgv.Rows[i].Cells["add_only_c"].Value.ToString() + "',[print] = '" + dgv.Rows[i].Cells["print_c"].Value.ToString() + "' where name_frm ='" + dgv.Rows[i].Cells["name_frm_c"].Value.ToString() + "' and  user_code='" +lbl_user_code.Text + "'");
            }
            MessageBox.Show("update");
        }

        
        //--------------------------------------------------
        //4)-load forth page police price and discount 
        //_______________________________________________
        private void chk_price_CheckedChanged(object sender, EventArgs e)
        {
            if (combo_users.Text == "")
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "اختار مستخدم", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (chk_price.Checked == true)
            {
                group_price.Visible = true;
            }
            else
            {
                group_price.Visible = false;
            }
        }
        private void chk_discount_CheckedChanged(object sender, EventArgs e)
        {
            if (combo_users.Text == "")
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "اختار مستخدم", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (chk_discount.Checked == true)
            {
                group_discount.Visible = true;
            }
            else
            {
                group_discount.Visible = false;
            }
        }
        private void chk_discount_all_CheckedChanged(object sender, EventArgs e)
        {
            if (combo_users.Text == "")
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "اختار مستخدم", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (chk_discount_all.Checked==true)
            {
                group_discount_all.Visible = true;
            }
            else
            {
                group_discount_all.Visible = false;
            }
        }
        private void btn_save_price_discount_Click(object sender, EventArgs e)
        {
            if (combo_users.Text == "")
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "اختار مستخدم", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            db.Run("update permission_price_discount set contral_sale_price = '" + chk_price.Checked + "',controal_sale_discount='" + chk_discount.Checked + "',controal_all_discount='" + chk_discount_all.Checked + "',blow_cost_price='" + chk_prevent_blowcost.Checked + "',blow_cost_discount='" + chk_dis_privent_cost.Checked+ "' where user_code='" + lbl_user_code.Text + "'");
        }

        private void dgv_permission_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv_permission, "no1");
        }

        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv, "no2");

        }

        
        

        private void btn_dgv_se_Click(object sender, EventArgs e)
        {
            
            if (combo_users.Text == "")
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "اختار مستخدم", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable dt = new DataTable();
            db.GetData_DGV("select name_frm,visible from permission_sub_screen where  user_code='" + lbl_user_code.Text + "'", dt);
            dgv_sc.DataSource = dt;
        }

        private void btn_save_se_Click(object sender, EventArgs e)
        {
            if (combo_users.Text == "")
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "اختار مستخدم", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 0; i < dgv_sc.Rows.Count; i++)
            {
                db.Run("update permission_sub_screen set visible = '" + dgv_sc.Rows[i].Cells["visible_sc"].Value.ToString() + "' where name_frm ='" + dgv_sc.Rows[i].Cells["name_frmsc"].Value.ToString() + "' and  user_code='" + lbl_user_code.Text + "'");
            }
            MessageBox.Show("update");

        }

        private void btn_ch_se_true_Click(object sender, EventArgs e)
        {
            if (combo_users.Text == "")
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "اختار مستخدم", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 0; i < dgv_sc.Rows.Count; i++)
            {
                dgv_sc.Rows[i].Cells["visible_sc"].Value = true;

            }
        }

        private void btn_sc_false_Click(object sender, EventArgs e)
        {
            if (combo_users.Text == "")
            {//visible_sc
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "اختار مستخدم", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 0; i < dgv_sc.Rows.Count; i++)
            {
                dgv_sc.Rows[i].Cells["visible_sc"].Value = false;

            }
        }

        private void dgv_sc_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv_sc, "no3");
        }

        private void btn_trans_permission_Click(object sender, EventArgs e)
        {
            string emp1 = "";
            string emp2 = "";
            emp1 = db.GetData("select isnull(max(emp_no),0) from emps where emp_no='" + txt_main_emp.Text + "'").Rows[0][0].ToString();
            emp2 = db.GetData("select isnull(max(emp_no),0) from emps where emp_no='" + txt_emp2.Text + "'").Rows[0][0].ToString();
            if (emp1 == "0") return;
            if (emp2 == "0") return;

            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            DataTable dt5 = new DataTable();



            db.GetData_DGV("select user_code,name_frm,visible from permission where user_code='" + emp1 + "' ", dt1);
            db.Run("delete from permission where user_code='" + emp2 + "'");
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                db.Run("insert into permission (user_code,name_frm,visible)values('" + emp2 + "','" + dt1.Rows[i][1] + "" + "','" + dt1.Rows[i][2] + "" + "') ");
            }

            db.GetData_DGV("select user_code,user_name,name_frm,[save], [delete], edit_only, add_only, [print] from permission_sub where user_code='" + emp1 + "' ", dt2);
            db.Run("delete from permission_sub where user_code='" + emp2 + "'");
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                db.Run("insert into permission_sub (user_code,user_name,name_frm,[save], [delete], edit_only, add_only, [print]) values ('" + emp2 + "','" + dt2.Rows[i][1] + "" + "','" + dt2.Rows[i][2] + "" + "','" + dt2.Rows[i][3] + "" + "','" + dt2.Rows[i][4] + "" + "','" + dt2.Rows[i][5] + "" + "','" + dt2.Rows[i][6] + "" + "','" + dt2.Rows[i][7] + "" + "')");
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
    }
}