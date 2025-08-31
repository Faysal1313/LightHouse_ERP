using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using f1.Properties;

namespace f1.Log_in
{
    public partial class frm_change_password : DevExpress.XtraEditors.XtraForm
    {
        public frm_change_password()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
         
       
        }
        private void btn_exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void btn_Save_Click(object sender, EventArgs e)
        {
            db.Open();
            Log_in.frm_login f = new frm_login();
            string x = "";//f.txt_code.Text;
            x = frm_login.emp_no;
           
            string lenth = "";
            lenth = txt_pass1.Text;
            if (lenth.Length <3)
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "يجب ان يكون كلمة المرور اكبر من 3 حروف ", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txt_pass1.Text != txt_pass2.Text)
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "كلمه المرور غير متطابقه ", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txt_pass1.Text=="" || txt_pass2.Text=="")
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "يجب إدخال كلمة المرور ", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
          
            
                db.Run("use " + Settings.Default.db_base + " \n update emps set password='" + txt_pass2.Text + "' where emp_no='" + x + "' ");
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "تم تغير كلمة المرور ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frm_login.emp_no = txt_pass1.Text;

        }


    }
}