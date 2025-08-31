using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace f1.hr
{
    public partial class frm_pay_salary : DevExpress.XtraEditors.XtraForm
    {
        public frm_pay_salary()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon("f1.exe");
            db.Open();
        }

        private void btn_add_all_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("select  empcode,empname ,wcode , wname,fvalue from empwage  where empcode is not null order by empname asc ", dt);
            dgv.DataSource=dt;
        }

        private void btn_save_salary_emp_Click(object sender, EventArgs e)
        {
           
            if (comob_period.Text == "")
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "لايمكن إصدار مرتبات يجب ادخال فتره الرواتب", "period", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dgv.Rows.Count < 0)
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "ادخل موظفين", "period", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            int conferm_slary_befor = Convert.ToInt32(db.GetData("select isnull((count(empcode)),0) from salary where  period_salary='" + comob_period.Text + "'").Rows[0][0].ToString());
            if (conferm_slary_befor != 0)
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "المرتبات مصدره من قبل ", "period", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                db.Run(" insert into salary (period_salary, empcode, namename, wcode, wname, fvalue,user_code,user_name) values ('" + comob_period.Text + "','" + dgv.Rows[i].Cells["empcode"].Value.ToString() + "','" + dgv.Rows[i].Cells["Empname"].Value.ToString() + "','" + dgv.Rows[i].Cells["WCode"].Value.ToString() + "','" + dgv.Rows[i].Cells["Wname"].Value.ToString() + "','" + dgv.Rows[i].Cells["fValue"].Value.ToString() + "','" + lbl_user_code.Text + "','" + lbl_user_name.Text + "')");
            }
            XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "saving  salary", "save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            db.GetData_DGV("SELECT      empcode, namename,wcode, wname , (fvalue)FROM         salary where  period_salary='" + comob_period.Text + "'", dt2);
            db.GetData_DGV("SELECT      empcode, namename,  sum(fvalue)as fvalue FROM         salary where  period_salary='" + comob_period.Text + "'group by   empcode, namename", dt3);
            dgv2.DataSource = dt2;
            dgv3.DataSource = dt3;

        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            db.Run("delete from salary where period_salary='"+comob_period.Text+"'");
            XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "delete  salary", "delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void btn_salary_statment_Click(object sender, EventArgs e)
        {
            DataTable dt3 = new DataTable();
            db.GetData_DGV("SELECT      empcode, namename,  sum(fvalue)as fvalue FROM         salary where  period_salary='" + comob_period.Text + "'group by   empcode, namename", dt3);
          
            dgv3.DataSource = dt3;
        }


    }
}