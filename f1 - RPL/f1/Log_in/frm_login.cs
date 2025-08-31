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
using f1.Properties;
using System.Diagnostics;

namespace f1.Log_in
{
    public partial class frm_login : DevExpress.XtraEditors.XtraForm
    {
        public frm_login()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(v.ico);

        }
        public static string strdb = "";
        private void Frm_login_Load(object sender, EventArgs e)
        {
            
            try
            {
                incode();
                lbl_db.Text = Settings.Default.db_base;
                txt_code.Select();
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }
        //incode 
        private void incode()
        {
            string time = "";
            command.get_time(ref time);
          //  MessageBox.Show(time);
            string suHash = "";
            suHash=Settings.Default.su_hash;
            if (suHash == Classes.secy.decoder((Classes.secy.secu2() + "05111504se").Trim()) || suHash == Classes.secy.decoder((secy.secu2() + "05111504ba").Trim()) || (suHash == Classes.secy.decoder((Classes.secy.secu2() + "05111504gl").Trim()) || suHash == Classes.secy.decoder((secy.secu2() + "05111504pu").Trim())) || suHash == Classes.secy.decoder((Classes.secy.secu2() + "05111504sa").Trim()) || suHash == Classes.secy.decoder((Classes.secy.secu2() + "05111504ma").Trim()))
            {
             

                lbl_hash.Text = "app licensed";
                txt_incode.Visible = false;
                btn_Save_key.Visible = false;
            }
            else if (suHash == Classes.secy.decoder(Classes.secy.secu2().Trim() + "05111504tr"+time+""))
            {
                lbl_hash.Text = "app licensed Trial-نسخة تجريبية";
                txt_incode.Visible = false;
                ////-2023-01
                // btn_login.Visible = false;
                //WQ94LNA105111504tr-2023-04
                btn_Save_key.Visible = false;
                //if (Settings.Default.trial == 15)
                //{
                //    lbl_hash.Text = "تم الانتهاء من فترة السماح\n لاستخدام البرنامج ! يجب شراء رخصة جديدة";
                //    btn_login.Visible = false;
                //}
                //else
                //{
                //    Settings.Default.trial = Settings.Default.trial + 1;
                //    Settings.Default.Save();
                //}
            }
            else
            {
                //db.log_error("+" + suHash + "+");
                //db.log_error("+" + (Classes.secy.secu2() + "05111504se").Trim() + "+");
                //db.log_error("+" + Classes.secy.decoder((Classes.secy.secu2() + "05111504se").Trim()) + "+");
                //db.log_error("+"+ Classes.secy.decoder(Classes.secy.secu2().Trim() + "05111504tr" + time + "")+"+");
                lbl_hash.Text = "app unlicensed";
                txt_incode.Visible = true;
            //    txt_incode.Text = Classes.secy.secu2().Trim();
              txt_incode.Text = Classes.secy.secu2();
                btn_Save_key.Visible = true;

            }
        }

        private void Lbl_clear_DoubleClick(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("عايز تحذف مفتاح الحمايه  من هنا!!؟؟؟؟ ", "رسال حذف ", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
                return;
            Settings.Default.su_hash = txt_incode.Text;
            Settings.Default.Reset();
            Application.Exit();
        }

        private void Btn_Save_key_Click(object sender, EventArgs e)
        {
            Settings.Default.su_hash = txt_incode.Text;
            Settings.Default.Save();
        }

        private void Btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public static string emp_no = "";
        public static string emp_pass = "";
        public void name_emp()
        {
            //lbl_user_name
            db.Open();
            lbl_user_name.Text=db.GetData("use " + Settings.Default.db_base + " \n select isnull(max(emp_name),'-') from emps where emp_no='" + txt_code.Text+"'").Rows[0][0].ToString();
        }

        private void Lbl_changepasword_Click(object sender, EventArgs e)
        {
            db.Open();
            string emp_code = "";
            string pass = "";
            DataTable dt1 = new DataTable();
            emp_code=db.GetData("use " + Settings.Default.db_base + " \n  select isnull(MAX(emp_no),0) from emps where emp_no='" + txt_code.Text + "'").Rows[0][0].ToString();
            pass = db.GetData_for_log("use " + Settings.Default.db_base + " \n select isnull(MAX(password),0) from emps where password='" + txt_pass.Text + "' ").Rows[0][0].ToString();
            if (emp_code=="0")
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "المستخدم غير موجود ", "رسالة تنبية ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (pass == "0")
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "يجب اداخال كلمة المرور ", "رسالة تنبية ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            emp_no = txt_code.Text;
            emp_pass = txt_pass.Text;
            frm_change_password f = new frm_change_password();
            f.ShowDialog();
        }

        private void Lbl_connectionString_Click(object sender, EventArgs e)
        {
            Log_in.frm_connection_db f = new frm_connection_db();
            f.ShowDialog();
        }

        private void Btn_login_Click(object sender, EventArgs e)
        {
            if (lbl_hash.Text == "app unlicensed")
            {
                MessageBox.Show("unlicensed");
            }
            else
            {
                try
                {
                    db.Open();
                    txt_code.Text = db.GetData("use " + Settings.Default.db_base + " \n   select emp_no from  emps where  emp_no='" + txt_code.Text + "'").Rows[0][0].ToString();
                }
                catch (Exception ex)
                {
                    txt_code.Text = "";
                    txt_pass.Text = "";
                    db.log_error(string.Concat((object)ex));
                }
                if (lbl_db.Text == "0")
                {
                   XtraMessageBox.Show("اختار قاعده بيانات", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else if (txt_pass.Text != "")
                {
                    db.Open();
                    DataTable dataForLog = db.GetData_for_log("select emp_no,user_name from emps where emp_no='" + txt_code.Text.Replace("'", "") + "'and password='" + txt_pass.Text.Replace("'", "") + "'");
                    if (dataForLog.Rows.Count > 0)
                    {
                        v.usercode = dataForLog.Rows[0][0].ToString();
                        v.username = dataForLog.Rows[0][1].ToString();
                        name_emp();

                        ((Control)new frm_main()).Show();

                        //((Control)new pos.pos_main()).Show();
                        Visible = false;
                    }
                    else
                    {
                       XtraMessageBox.Show("Password or User Name ! False", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                else
                {
                    XtraMessageBox.Show("select Data base first ! False", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
       
        
        }

        private void Txt_code_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    name_emp();
                    txt_pass.Select();

                }
            }
            catch (Exception)
            {

              
            }
        }

        private void Txt_pass_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    name_emp();
                    btn_login.PerformClick();
                }
            }
            catch (Exception)
            {

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.ad4sas.com/");
        }

        private void txt_code_Leave(object sender, EventArgs e)
        {
            try
            {
                name_emp();
            }
            catch (Exception)
            {

            }
        }

        private void lbl_user_name_TextChanged(object sender, EventArgs e)
        {
            if (lbl_user_name.Text=="-")
            {
                XtraMessageBox.Show("المستخدم غير موجود", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
    }
}