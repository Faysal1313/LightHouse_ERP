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
    public partial class frm_subempwage : DevExpress.XtraEditors.XtraForm
    {
        public frm_subempwage()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
            db.Open();
        

        }
        bool edit = false;
        private void inser_salary_emp()
        {
            if (dgv.Rows.Count < 0)
            {
                MessageBox.Show("لاتوجد موظفين ");
                return;
            }
           
            else
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    db.Run("update Empwage set  EmpCode='" + dgv.Rows[i].Cells["EmpCode_"].Value.ToString() + "', Empname='" + dgv.Rows[i].Cells["Empname_"].Value.ToString() + "', fValue='" + dgv.Rows[i].Cells["fValue_"].Value.ToString() + "' where WCode='" + v.WCode + "'and EmpCode='" + dgv.Rows[i].Cells["EmpCode_"].Value.ToString() + "'");
                }
                for (int i = 0; i < dgv2.Rows.Count; i++)
                {
                    if (dgv2.Rows.Count > 0)
                    {
                        db.Run("insert into EmpWage ( WCode, Wname,EmpCode, Empname, fValue) values ('" + v.WCode + "','" + v.Wname + "','" + dgv2.Rows[i].Cells["emp_no_c"].Value.ToString() + "','" + dgv2.Rows[i].Cells["emp_name_c"].Value.ToString() + "','" + dgv2.Rows[i].Cells["fValue_c"].Value.ToString() + "')");
                        
                    }
                }
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "saving  salary", "save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                edit = true;
            }
        }
        private void btn_save_salary_emp_Click(object sender, EventArgs e)
        {
            inser_salary_emp();
        }

      //==================simple controls
        private void btn_add_Emp_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            db.GetData_DGV("SELECT  EmpCode as emp_no, Empname as emp_name, fValue FROM EmpWage where EmpCode is not null and WCode='" + v.WCode + "'  ", dt);
            dgv.DataSource = dt;

            DataTable dtee = new DataTable();
            db.GetData_DGV("SELECT emps.emp_no, emps.emp_name FROM emps left join EmpWage on emps.emp_no = EmpWage.EmpCode where EmpWage.EmpCode is null  ", dtee);
            dgv2.DataSource = dtee;

            DataTable dt_count = new DataTable();
            db.GetData_DGV("select * from empwage where WCode='" + v.WCode + "'", dt_count);
            int x = Convert.ToInt32(db.GetData("select isnull((count(EmpCode)),0) from empwage where  WCode='" + v.WCode + "'").Rows[0][0].ToString());

            if (x ==0)
            {
                DataTable dtem = new DataTable();
                db.GetData_DGV("SELECT  emp_no as emp_no_c,  emp_name as emp_name_c  FROM emps  ", dtem);
                dgv2.DataSource = dtem;
            }
        }
        private void btn_del_Click(object sender, EventArgs e)
        {
            db.Run("delete from EmpWage where EmpCode='" + dgv.CurrentRow.Cells["EmpCode_"].Value.ToString() + "'");
        }















        //====================================================
    }
}