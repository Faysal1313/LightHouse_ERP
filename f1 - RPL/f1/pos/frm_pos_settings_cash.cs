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

namespace f1.pos
{
    public partial class frm_pos_settings_cash : DevExpress.XtraEditors.XtraForm
    {
        public frm_pos_settings_cash()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(v.ico);

        }

        private void Frm_pos_settings_cash_Load(object sender, EventArgs e)
        {
            load_combo();
        }
        private void load_combo()
        {
            all_comb.load_emp_users_code(combo_user);
            all_comb.load_account_code_c(combo_code_acc);
            all_comb.load_account_name_c(combo_name_acc);
            all_comb.load_wares(combo_wars);
            all_comb.cost_center_name(this.combo_costcenter);

            all_comb.load_code_book_entry_from_book(combo_entry_code);
            
            combo_name_acc.Text = "";
            combo_code_acc.Text = "";
            combo_user.Text = "";
            lbl_user_name.Text = "0";


            //-----------load currency
            all_comb.load_curracne(cur1);
            all_comb.load_curracne(cur2);
            all_comb.load_curracne(cur3);
            all_comb.load_curracne(cur4);
            all_comb.load_curracne(cur5);
            all_comb.load_curracne(cur6);
            all_comb.load_curracne(cur7);
            all_comb.load_curracne(cur8);
            all_comb.load_curracne(cur9);
            all_comb.load_curracne(cur10);

            cur1.Text = "";
            cur2.Text = "";
            cur3.Text = "";
            cur4.Text = "";
            cur5.Text = "";
            cur6.Text = "";
            cur7.Text = "";
            cur8.Text = "";
            cur9.Text = "";
            cur10.Text = "";

        }
        private void clear()
        {
            combo_name_acc.Text = "";
            combo_code_acc.Text = "";
            combo_user.Text = "";
            lbl_user_name.Text = "0";


        }
        private void Btn_del_sub_Click(object sender, EventArgs e)
        {

            lbl_other1.Text = "";
            lbl_other2.Text = "";
            lbl_other3.Text = "";
            lbl_other4.Text = "";
            lbl_other5.Text = "";
            lbl_other6.Text = "";
            lbl_other7.Text = "";
            lbl_other8.Text = "";
            lbl_other9.Text = "";
            lbl_other10.Text = "";


            lbl_acc_code.Text = "";
            lbl_def_and_inc.Text = "";
            lbl_cash_main.Text = "";
            lbl_sale.Text = "";
            lbl_resale.Text = "";
            lbl_discount.Text = "";
            lbl_cogs.Text = "";
            lbl_medil.Text = "";
        }
        private void Btn_search_Click(object sender, EventArgs e)
        {
            load_combo();

        }
        private void Btn_del_Click(object sender, EventArgs e)
        {
            clear();
        }
        private void Combo_code_acc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combo_name_acc.Text = db.GetData("select RootName from tree where RootID='" + combo_code_acc.Text + "'").Rows[0][0].ToString();
                lbl_acc_name.Text = db.GetData("select RootName from tree where RootID='" + combo_code_acc.Text + "'").Rows[0][0].ToString();
            }
            catch (Exception)
            {
            }
        }

        private void Combo_name_acc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combo_code_acc.Text = db.GetData("select RootID from tree where RootName='" + combo_name_acc.Text + "'").Rows[0][0].ToString();
                lbl_acc_code.Text = db.GetData("select RootID from tree where RootName='" + combo_name_acc.Text + "'").Rows[0][0].ToString();

            }
            catch (Exception)
            {
            }
        }

        private void Combo_user_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_user_name.Text = db.GetData("select isnull(max(emp_no),0) from emps where emp_no='" + combo_user.Text + "'").Rows[0][0].ToString();
            }
            catch (Exception)
            {
            }
        }

        private void Combo_wars_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.lbl_name_wares.Text = db.GetData("select isnull(max([ware_name]),0) from wares_acc where id_ware='" + this.combo_wars.Text + "'").Rows[0][0].ToString();

            }
            catch (Exception)
            {
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                cur1.Text = db.GetData("select top 1 currance from currance ").Rows[0][0].ToString();
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
                cur2.Text = db.GetData("select top 1 currance from currance ").Rows[0][0].ToString();

        }

        private void ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
                cur3.Text = db.GetData("select top 1 currance from currance ").Rows[0][0].ToString();

        }

        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
                cur4.Text = db.GetData("select top 1 currance from currance ").Rows[0][0].ToString();

        }

        private void ComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
                cur4.Text = db.GetData("select top 1 currance from currance ").Rows[0][0].ToString();

        }

        private void ComboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
                cur6.Text = db.GetData("select top 1 currance from currance ").Rows[0][0].ToString();

        }

        private void ComboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
                cur7.Text = db.GetData("select top 1 currance from currance ").Rows[0][0].ToString();

        }

        private void ComboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            cur8.Text = db.GetData("select top 1 currance from currance ").Rows[0][0].ToString();

        }
        private void ComboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
                cur9.Text = db.GetData("select top 1 currance from currance ").Rows[0][0].ToString();

        }

        private void ComboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
                cur10.Text = db.GetData("select top 1 currance from currance ").Rows[0][0].ToString();

        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            lbl_def_and_inc.Text = lbl_acc_code.Text;
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            lbl_cash_main.Text = lbl_acc_code.Text;

        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            lbl_sale.Text = lbl_acc_code.Text;

        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            lbl_resale.Text = lbl_acc_code.Text;

        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            lbl_discount.Text = lbl_acc_code.Text;

        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            lbl_cogs.Text = lbl_acc_code.Text;

        }
        private void btn7_Click(object sender, EventArgs e)
        {
            lbl_medil.Text = lbl_acc_code.Text;
        }
        private void O1_Click(object sender, EventArgs e)
        {
            lbl_other1.Text = lbl_acc_code.Text;
        }

        private void O2_Click(object sender, EventArgs e)
        {
            lbl_other2.Text = lbl_acc_code.Text;

        }

        private void O3_Click(object sender, EventArgs e)
        {
            lbl_other3.Text = lbl_acc_code.Text;

        }

        private void O4_Click(object sender, EventArgs e)
        {
            lbl_other4.Text = lbl_acc_code.Text;

        }

        private void O5_Click(object sender, EventArgs e)
        {
            lbl_other5.Text = lbl_acc_code.Text;

        }

        private void O6_Click(object sender, EventArgs e)
        {
            lbl_other6.Text = lbl_acc_code.Text;

        }

        private void O7_Click(object sender, EventArgs e)
        {
            lbl_other7.Text = lbl_acc_code.Text;

        }

        private void O8_Click(object sender, EventArgs e)
        {
            lbl_other8.Text = lbl_acc_code.Text;

        }

        private void O9_Click(object sender, EventArgs e)
        {
            lbl_other9.Text = lbl_acc_code.Text;

        }

        private void O10_Click(object sender, EventArgs e)
        {
            lbl_other10.Text = lbl_acc_code.Text;

        }
        //=======================================================insert or update 
        private void Btn_save_Click(object sender, EventArgs e)
        {

            if (lbl_user_name.Text=="" || lbl_user_name.Text=="0")
            {
                MessageBox.Show("يجب اختيار موظف");
                return;
            }


            //1- found valied user name and user code
           
            //2- if found old pos_cash_account in table >>>>load data

            //3- if not found old pos_cash insert into 
            //3-1 if found empty filed 
            if (lbl_def_and_inc.Text == "" && lbl_cash_main.Text == "" && lbl_sale.Text == "" && lbl_resale.Text == "" && lbl_discount.Text == "" && lbl_cogs.Text=="" && combo_wars.Text == "" && combo_entry_code.Text=="")
            {
                MessageBox.Show("يجب ملئ جميع الحقول الحسابات لاستكمال اضافة النقطة بشكل سليم");
                return;
            }
            if (lbl_def_and_inc.Text == "-" && lbl_cash_main.Text == "-" && lbl_sale.Text == "-" && lbl_resale.Text == "-" && lbl_discount.Text == "-" && lbl_cogs.Text == "-" && combo_wars.Text == "-" && combo_entry_code.Text == "-")
            {
                MessageBox.Show("يجب ملئ جميع الحقول الحسابات لاستكمال اضافة النقطة بشكل سليم");
                return;

            }
            db.Run("delete from pos_cash_account where user_code='" + combo_user.Text+"'");
            db.Run("insert into pos_cash_account ([medil],[user_code] ,    [cash_main],    [sales_acc],    [re_sales_acc],    [disocount],    [wares],    [code_book],    [cogs],    [def_or_inc],    [cash1_account],    [cash2_account],    [cash3_account],    [cash4_account],    [cash5_account],    [cash6_account],    [cash7_account],    [cash8_account],    [cash9_account],    [cash10_account],    [cash1_name],    [cash2_name],    [cash3_name],    [cash4_name],    [cash5_name],    [cash6_name],    [cash7_name],    [cash8_name],    [cash9_name],    [cash10_name],    [cash1_type],    [cash2_type],   [cash3_type],    [cash4_type],    [cash5_type],    [cash6_type],    [cash7_type],    [cash8_type],    [cash9_type],    [cash10_type],    [cash1_currency],    [cash2_currency],    [cash3_currency],    [cash4_currency],    [cash5_currency],    [cash6_currency],    [cash7_currency],    [cash8_currency],    [cash9_currency],    [cash10_currency],[costcenter_id]) values ('"+lbl_medil.Text+"','"+combo_user.Text+"','"+lbl_cash_main.Text+"','"+lbl_sale.Text+"','"+lbl_resale.Text+"','"+lbl_discount.Text+"','"+combo_wars.Text+"','"+combo_entry_code.Text+"','"+lbl_cogs.Text+"','"+lbl_def_and_inc.Text+"','"+lbl_other1.Text+ "','" + lbl_other2.Text + "','" + lbl_other3.Text + "','" + lbl_other4.Text + "','" + lbl_other5.Text + "','" + lbl_other6.Text + "','" + lbl_other7.Text + "','" + lbl_other8.Text + "','" + lbl_other9.Text + "','" + lbl_other10.Text + "','"+txt1.Text+ "','" + txt2.Text + "','" + txt3.Text + "','" + txt4.Text + "','" + txt5.Text + "','" + txt6.Text + "','" + txt7.Text + "','" + txt8.Text + "','" + txt9.Text + "','" + txt10.Text + "','"+ comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + comboBox4.Text + "','" + comboBox5.Text + "','" + comboBox6.Text + "','" + comboBox7.Text + "','" + comboBox8.Text + "','" + comboBox9.Text + "','" + comboBox10.Text + "','"+cur1.Text+ "','" + cur2.Text + "','" + cur3.Text + "','" + cur4.Text + "','" + cur5.Text + "','" + cur6.Text + "','" + cur7.Text + "','" + cur8.Text + "','" + cur9.Text + "','" + cur10.Text + "','"+lbl_costcenter.Text+"')");

            MessageBox.Show("save");
        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            //1= not found user mbox
            if (db.GetData("select isnull(max(user_code),0) from pos_cash_account").Rows[0][0].ToString()=="0" )
            {
                MessageBox.Show("يجب عمل حفظ للموظف الاول لكي يتم تحميلة");
                groupControl1.Visible = false;
                return;

            }
            //2= found user groub box visable = true and load data
            else
            {
                try
                {
                    groupControl1.Visible = true;

                    lbl_def_and_inc.Text = db.GetData("select isnull(max(def_or_inc),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    lbl_cash_main.Text = db.GetData("select isnull(max(cash_main),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    lbl_sale.Text = db.GetData("select isnull(max(sales_acc),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    lbl_resale.Text = db.GetData("select isnull(max(re_sales_acc),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    lbl_discount.Text = db.GetData("select isnull(max(disocount),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    combo_wars.Text = db.GetData("select isnull(max(wares),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    combo_entry_code.Text = db.GetData("select isnull(max(code_book),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    lbl_cogs.Text = db.GetData("select isnull(max(cogs),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    lbl_medil.Text = db.GetData("select isnull(max(medil),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();


                    lbl_other1.Text = db.GetData("select isnull(max(cash1_account),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    lbl_other2.Text = db.GetData("select isnull(max(cash2_account),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    lbl_other3.Text = db.GetData("select isnull(max(cash3_account),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    lbl_other4.Text = db.GetData("select isnull(max(cash4_account),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    lbl_other5.Text = db.GetData("select isnull(max(cash5_account),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    lbl_other6.Text = db.GetData("select isnull(max(cash6_account),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    lbl_other7.Text = db.GetData("select isnull(max(cash7_account),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    lbl_other8.Text = db.GetData("select isnull(max(cash8_account),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    lbl_other9.Text = db.GetData("select isnull(max(cash9_account),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    lbl_other10.Text = db.GetData("select isnull(max(cash10_account),0) from pos_cash_account where user_code = '" + combo_user.Text + "'").Rows[0][0].ToString();
                    lbl_costcenter.Text= db.GetData("select isnull(max([costcenter_id]),0) from pos_cash_account where user_code = '" + combo_user.Text + "'").Rows[0][0].ToString();


                    txt1.Text = db.GetData("select isnull(max(cash1_name),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    txt2.Text = db.GetData("select isnull(max(cash2_name),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    txt3.Text = db.GetData("select isnull(max(cash3_name),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    txt4.Text = db.GetData("select isnull(max(cash4_name),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    txt5.Text = db.GetData("select isnull(max(cash5_name),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    txt6.Text = db.GetData("select isnull(max(cash6_name),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    txt7.Text = db.GetData("select isnull(max(cash7_name),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    txt8.Text = db.GetData("select isnull(max(cash8_name),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    txt9.Text = db.GetData("select isnull(max(cash9_name),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    txt10.Text = db.GetData("select isnull(max(cash10_name),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();


                    comboBox1.Text = db.GetData("select isnull(max(cash1_type),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    comboBox2.Text = db.GetData("select isnull(max(cash2_type),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    comboBox3.Text = db.GetData("select isnull(max(cash3_type),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    comboBox4.Text = db.GetData("select isnull(max(cash4_type),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    comboBox5.Text = db.GetData("select isnull(max(cash5_type),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    comboBox6.Text = db.GetData("select isnull(max(cash6_type),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    comboBox7.Text = db.GetData("select isnull(max(cash7_type),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    comboBox8.Text = db.GetData("select isnull(max(cash8_type),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    comboBox9.Text = db.GetData("select isnull(max(cash9_type),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    comboBox10.Text = db.GetData("select isnull(max(cash10_type),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();

                    cur1.Text = db.GetData("select isnull(max(cash1_currency),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    cur2.Text = db.GetData("select isnull(max(cash2_currency),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    cur3.Text = db.GetData("select isnull(max(cash3_currency),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    cur4.Text = db.GetData("select isnull(max(cash4_currency),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    cur5.Text = db.GetData("select isnull(max(cash5_currency),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    cur6.Text = db.GetData("select isnull(max(cash6_currency),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    cur7.Text = db.GetData("select isnull(max(cash7_currency),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    cur8.Text = db.GetData("select isnull(max(cash8_currency),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    cur9.Text = db.GetData("select isnull(max(cash9_currency),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    cur10.Text = db.GetData("select isnull(max(cash10_currency),0) from pos_cash_account where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();

                }
                catch (Exception)
                {

                   
                }
            }
        
        }

        private void Btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "هل تريد حذف السند!!؟؟؟؟ ", "رسال حذف مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);


            if (dr == DialogResult.OK)
            {
                db.Run("delete from pos_cash where user_code='" + combo_user.Text + "'");

            }

        }

        private void btn_loadlike_emp_Click(object sender, EventArgs e)
        {
            if (txt_like_emp.Text=="")
            {
                MessageBox.Show("يجب كتابة كود موظف");return;
            }
            //1= not found user mbox
            if (db.GetData("select isnull(max(user_code),0) from pos_cash_account").Rows[0][0].ToString() == "0")
            {
                MessageBox.Show("يجب عمل حفظ للموظف الاول لكي يتم تحميلة");
                groupControl1.Visible = false;
                return;
            }
            //2= found user groub box visable = true and load data
            else
            {
                try
                {
                    groupControl1.Visible = true;

                    lbl_def_and_inc.Text = db.GetData("select isnull(max(def_or_inc),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    lbl_cash_main.Text = db.GetData("select isnull(max(cash_main),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    lbl_sale.Text = db.GetData("select isnull(max(sales_acc),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    lbl_resale.Text = db.GetData("select isnull(max(re_sales_acc),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    lbl_discount.Text = db.GetData("select isnull(max(disocount),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    combo_wars.Text = db.GetData("select isnull(max(wares),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    combo_entry_code.Text = db.GetData("select isnull(max(code_book),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    lbl_cogs.Text = db.GetData("select isnull(max(cogs),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    lbl_medil.Text = db.GetData("select isnull(max(medil),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();


                    lbl_other1.Text = db.GetData("select isnull(max(cash1_account),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    lbl_other2.Text = db.GetData("select isnull(max(cash2_account),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    lbl_other3.Text = db.GetData("select isnull(max(cash3_account),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    lbl_other4.Text = db.GetData("select isnull(max(cash4_account),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    lbl_other5.Text = db.GetData("select isnull(max(cash5_account),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    lbl_other6.Text = db.GetData("select isnull(max(cash6_account),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    lbl_other7.Text = db.GetData("select isnull(max(cash7_account),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    lbl_other8.Text = db.GetData("select isnull(max(cash8_account),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    lbl_other9.Text = db.GetData("select isnull(max(cash9_account),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    lbl_other10.Text = db.GetData("select isnull(max(cash10_account),0) from pos_cash_account where user_code = '" + txt_like_emp.Text + "'").Rows[0][0].ToString();

                    txt1.Text = db.GetData("select isnull(max(cash1_name),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    txt2.Text = db.GetData("select isnull(max(cash2_name),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    txt3.Text = db.GetData("select isnull(max(cash3_name),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    txt4.Text = db.GetData("select isnull(max(cash4_name),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    txt5.Text = db.GetData("select isnull(max(cash5_name),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    txt6.Text = db.GetData("select isnull(max(cash6_name),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    txt7.Text = db.GetData("select isnull(max(cash7_name),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    txt8.Text = db.GetData("select isnull(max(cash8_name),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    txt9.Text = db.GetData("select isnull(max(cash9_name),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    txt10.Text = db.GetData("select isnull(max(cash10_name),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();


                    comboBox1.Text = db.GetData("select isnull(max(cash1_type),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    comboBox2.Text = db.GetData("select isnull(max(cash2_type),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    comboBox3.Text = db.GetData("select isnull(max(cash3_type),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    comboBox4.Text = db.GetData("select isnull(max(cash4_type),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    comboBox5.Text = db.GetData("select isnull(max(cash5_type),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    comboBox6.Text = db.GetData("select isnull(max(cash6_type),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    comboBox7.Text = db.GetData("select isnull(max(cash7_type),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    comboBox8.Text = db.GetData("select isnull(max(cash8_type),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    comboBox9.Text = db.GetData("select isnull(max(cash9_type),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    comboBox10.Text = db.GetData("select isnull(max(cash10_type),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();

                    cur1.Text = db.GetData("select isnull(max(cash1_currency),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    cur2.Text = db.GetData("select isnull(max(cash2_currency),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    cur3.Text = db.GetData("select isnull(max(cash3_currency),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    cur4.Text = db.GetData("select isnull(max(cash4_currency),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    cur5.Text = db.GetData("select isnull(max(cash5_currency),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    cur6.Text = db.GetData("select isnull(max(cash6_currency),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    cur7.Text = db.GetData("select isnull(max(cash7_currency),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    cur8.Text = db.GetData("select isnull(max(cash8_currency),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    cur9.Text = db.GetData("select isnull(max(cash9_currency),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();
                    cur10.Text = db.GetData("select isnull(max(cash10_currency),0) from pos_cash_account where user_code='" + txt_like_emp.Text + "'").Rows[0][0].ToString();

                }
                catch (Exception)
                {


                }
            }
        }

        private void btn_costcenter_Click(object sender, EventArgs e)
        {
            //dgv.CurrentRow.Cells["costcenter"].Value = combo_costcenter.Text;
            lbl_costcenter.Text = db.GetData("select  isnull(max(costcenter_id),0) from  costcenter where costcenter_name='" + combo_costcenter.Text + "'").Rows[0][0].ToString();
          //  dgv.CurrentRow.Cells["costcenter"].Value = lbl_costcenter.Text;
        }
    }
}