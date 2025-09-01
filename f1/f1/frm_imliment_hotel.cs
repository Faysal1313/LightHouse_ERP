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

namespace f1
{
    public partial class frm_imliment_hotel : DevExpress.XtraEditors.XtraForm
    {
        public frm_imliment_hotel()
        {
            InitializeComponent();
        }
        private void frm_imliment_hotel_Load(object sender, EventArgs e)
        {
            load_combo();
        }
        private void load_combo()
        {
            all_comb.load_emp_users_code(combo_user);
            all_comb.load_account_code_c(combo_code_acc);
            all_comb.load_account_name_c(combo_name_acc);
          
            all_comb.cost_center_name(this.combo_costcenter);

            all_comb.load_code_book_entry_from_book(combo_entry_code);

            combo_name_acc.Text = "";
            combo_code_acc.Text = "";
            combo_user.Text = "";
            lbl_user_name.Text = "0";


     
  

        }
        private void clear()
        {
            combo_name_acc.Text = "";
            combo_code_acc.Text = "";
            combo_user.Text = "";
            lbl_user_name.Text = "0";

            lbl1.Text = "";
            lbl2.Text = "";
            lbl3.Text = "";
            lbl4.Text = "";
            lbl5.Text = "";
            lbl6.Text = "";
            lbl7.Text = "";
            lbl8.Text = "";
            lbl9.Text = "";
            lbl10.Text = "";
            lbl11.Text = "";
            lbl12.Text = "";


        }

        private void btn_load_user_Click(object sender, EventArgs e)
        {
            //1= not found user mbox
            if (db.GetData("select isnull(max(emp_no),0) from emps").Rows[0][0].ToString() == "0")
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

                    lbl1.Text = db.GetData("select [res_credit] from implemint_entry_hot where user_code='"+combo_user.Text+"'").Rows[0][0].ToString();
                    lbl2.Text = db.GetData("select [rest_revenu] from implemint_entry_hot where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    lbl3.Text = db.GetData("select [servies_cash_reception] from implemint_entry_hot where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    lbl4.Text = db.GetData("select [servies_visa_reception] from implemint_entry_hot where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    lbl5.Text = db.GetData("select [servies_revenu]  from implemint_entry_hot where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    lbl6.Text = db.GetData("select [servies_credit] from implemint_entry_hot where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    lbl7.Text = db.GetData("select [servies_revenu2] from implemint_entry_hot where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    lbl8.Text = db.GetData("select [exit_cash]  from implemint_entry_hot where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    lbl9.Text = db.GetData("select [exit_visa] from implemint_entry_hot where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    lbl10.Text = db.GetData("select [res_credit2] from implemint_entry_hot where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    lbl11.Text = db.GetData("select [res_credit2] from implemint_entry_hot where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                    lbl12.Text = db.GetData("select [hotel_revenu] from implemint_entry_hot where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();

                    combo_entry_code.Text= db.GetData("select [code_book] from implemint_entry_hot where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                }
                catch (Exception)
                {


                }
            }

        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            load_combo();
        }

        private void combo_user_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_user_name.Text = db.GetData("select isnull(max(emp_no),0) from emps where emp_no='" + combo_user.Text + "'").Rows[0][0].ToString();
            }
            catch (Exception)
            {
            }
        }

        private void combo_code_acc_SelectedIndexChanged(object sender, EventArgs e)
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

        private void combo_name_acc_SelectedIndexChanged(object sender, EventArgs e)
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

        private void btn1_Click(object sender, EventArgs e)
        {
            lbl1.Text = lbl_acc_code.Text;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            lbl2.Text = lbl_acc_code.Text;

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            lbl3.Text = lbl_acc_code.Text;

        }

        private void btn4_Click(object sender, EventArgs e)
        {
            lbl4.Text = lbl_acc_code.Text;

        }

        private void btn5_Click(object sender, EventArgs e)
        {
            lbl5.Text = lbl_acc_code.Text;

        }

        private void btn6_Click(object sender, EventArgs e)
        {
            lbl6.Text = lbl_acc_code.Text;

        }

        private void btn7_Click(object sender, EventArgs e)
        {
            lbl7.Text = lbl_acc_code.Text;

        }

        private void btn8_Click(object sender, EventArgs e)
        {
            lbl8.Text = lbl_acc_code.Text;

        }

        private void btn9_Click(object sender, EventArgs e)
        {
            lbl9.Text = lbl_acc_code.Text;

        }

        private void btn10_Click(object sender, EventArgs e)
        {
            lbl10.Text = lbl_acc_code.Text;

        }

        private void btn11_Click(object sender, EventArgs e)
        {
            lbl11.Text = lbl_acc_code.Text;

        }

        private void btn12_Click(object sender, EventArgs e)
        {
            lbl12.Text = lbl_acc_code.Text;

        }
        private void btn13_Click(object sender, EventArgs e)
        {
            lbl13.Text = lbl_acc_code.Text;
        }

        private void btn14_Click(object sender, EventArgs e)
        {
            lbl14.Text = lbl_acc_code.Text;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (lbl_user_name.Text == "" || lbl_user_name.Text == "0")
            {
                MessageBox.Show("يجب اختيار موظف");
                return;
            }


            //1- found valied user name and user code

            //2- if found old pos_cash_account in table >>>>load data

            //3- if not found old pos_cash insert into 
            //3-1 if found empty filed 
           
            db.Run("delete from implemint_entry_hot where user_code='" + combo_user.Text + "'");
            db.Run("insert into implemint_entry_hot (res_credit,rest_revenu,servies_cash_reception,servies_visa_reception,servies_revenu,servies_credit,servies_revenu2,exit_cash,exit_visa,res_credit2,res_credit3,hotel_revenu,code_book,user_code,vat,vat_discount) values ('" + lbl1.Text + "','" + lbl2.Text + "','" + lbl3.Text + "','" + lbl4.Text + "','" + lbl5.Text + "','" + lbl6.Text + "','" + lbl7.Text + "','" + lbl8.Text + "','" + lbl9.Text + "','" + lbl10.Text + "','" + lbl11.Text + "','" + lbl12.Text + "','" + combo_entry_code.Text + "','" + combo_user.Text +  "','"+lbl13.Text+"','"+lbl14.Text+"')");

            MessageBox.Show("save");
        }

        private void btn_del_sub_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btn_loadlike_emp_Click(object sender, EventArgs e)
        {
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
                lbl1.Text = db.GetData("select [res_credit] from implemint_entry_hot where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                lbl2.Text = db.GetData("select [rest_revenu] from implemint_entry_hot where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                lbl3.Text = db.GetData("select [servies_cash_reception] from implemint_entry_hot where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                lbl4.Text = db.GetData("select [servies_visa_reception] from implemint_entry_hot where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                lbl5.Text = db.GetData("select [servies_revenu]  from implemint_entry_hot where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                lbl6.Text = db.GetData("select [servies_credit] from implemint_entry_hot where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                lbl7.Text = db.GetData("select [servies_revenu2] from implemint_entry_hot where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                lbl8.Text = db.GetData("select [exit_cash]  from implemint_entry_hot where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                lbl9.Text = db.GetData("select [exit_visa] from implemint_entry_hot where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                lbl10.Text = db.GetData("select [res_credit2] from implemint_entry_hot where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                lbl11.Text = db.GetData("select [res_credit2] from implemint_entry_hot where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                lbl12.Text = db.GetData("select [hotel_revenu] from implemint_entry_hot where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();
                combo_entry_code.Text = db.GetData("select [code_book] from implemint_entry_hot where user_code='" + combo_user.Text + "'").Rows[0][0].ToString();

            }
        }

      
    }
}