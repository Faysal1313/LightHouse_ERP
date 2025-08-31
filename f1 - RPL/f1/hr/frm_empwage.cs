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
    public partial class frm_empwage : DevExpress.XtraEditors.XtraForm
    {
        public frm_empwage()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon("f1.exe");
            db.Open();
        }
        bool edit = false;

        //function -------------------------
        private void insert()
        {
            db.Run("insert into EmpWage (WCode,Wname) values('" + comob_wcode.Text + "','" + txt_wname.Text + "')");
            XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "saving ", "save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
        }
        private void update()
        {
            db.Run("update  EmpWage set Wname ='"+txt_wname.Text+"'  where Wcode='"+comob_wcode.Text+"' ");
            XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "Update ", "update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void delete()
        {
            if (edit == true)
            {
                if (comob_wcode.Text == "")
                {
                    XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "ماشي بس هو مفيش حاجه علشان امسحها دخل كود  طيب !!؟؟؟؟ ", "رسال حذف مستند", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult dr;
                    dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "سيتم حذف!!؟؟؟؟ ", "رسال حذف مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);


                    if (dr == DialogResult.OK)
                    {
                        db.Run("delete from EmpWage where Wcode='" + comob_wcode.Text + "' ");
                        XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "deleted ", "delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                }
            }
        }
        private void perfom_save()
        {
            if (edit ==false)
            {
                insert();
            }
            else
            {
                update();
            }
        }
        private void inser_salary_emp()
        {
            if (dgv.Rows.Count < 0)
            {
                MessageBox.Show("لاتوجد موظفين ");
                return;
            }
            else if (comob_wcode.Text == "" && txt_wname.Text == "")
            {
                MessageBox.Show("يجب ادخال كود المفرد راتب او الاسم ");
                return;
            }
            else
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    db.Run("insert into EmpWage ( WCode, Wname,EmpCode, Empname, fValue) values ('" + comob_wcode.Text + "','" + txt_wname.Text + "','" + dgv.Rows[i].Cells["EmpCode"].Value.ToString() + "','" + dgv.Rows[i].Cells["Empname"].Value.ToString() + "','" + dgv.Rows[i].Cells["fValue"].Value.ToString() + "')");
                }
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "saving  salary", "save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                edit = true;
            }
        }
        private void update_salary_emp()
        {
              if (dgv.Rows.Count < 0)
            {
                MessageBox.Show("لاتوجد موظفين ");
                return;
            }
              else if (comob_wcode.Text == "" && txt_wname.Text == "")
              {
                  MessageBox.Show("يجب ادخال كود المفرد راتب او الاسم ");
                  return;
              }
              else
              {
                  for (int i = 0; i < dgv.Rows.Count; i++)
                  {
                      db.Run("update Empwage set   Wname='" + txt_wname.Text + "',EmpCode='" + dgv.Rows[i].Cells["EmpCode"].Value.ToString() + "', Empname='" + dgv.Rows[i].Cells["Empname"].Value.ToString() + "', fValue='" + dgv.Rows[i].Cells["fValue"].Value.ToString() + "' where WCode='" + comob_wcode.Text + "'");
                  }

                  XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "Updated salary ", "update", MessageBoxButtons.OK, MessageBoxIcon.Information);
              }
        }
        private void perfrorm_slalry()
        {
            if (edit==false)
            {
                inser_salary_emp();
            }
            else
            {
                update_salary_emp();
            }
        
        }
        //simple controls ----------------------------------------------------------------------------


        private void save_barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            perfom_save();
        }

        private void delete_barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            delete();
        }

        private void btn_add_Emp_Click(object sender, EventArgs e)//when add emp in dgv
        {
            if (comob_wcode.Text !="" && txt_wname.Text !="")
            {
                if (edit==false)
                {
                    DataTable dt = new DataTable();
                        db.GetData_DGV("SELECT  emp_no, emp_name FROM emps ", dt);
                        dgv.DataSource = dt;
                }
                else
                {
                    DataTable dtee = new DataTable();
                    db.GetData_DGV("SELECT  EmpCode as emp_no, Empname as emp_name, fValue FROM EmpWage ", dtee);
                    dgv.DataSource = dtee;
                }
            }
            
        }

        private void btn_save_salary_emp_Click(object sender, EventArgs e)
        {
            perfrorm_slalry();
        }

        private void btn_saerch_wage_Click(object sender, EventArgs e)
        {
            try
            {
                all_comb.load_emp_Wage(comob_wcode);
                edit = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void comob_wcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txt_wname.Text = db.GetData("select  Wname  FROM EmpWage where WCode='" + comob_wcode.Text + "'").Rows[0][0].ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btn_new_combo_Click(object sender, EventArgs e)
        {
            txt_wname.Text = "";
            comob_wcode.Text = "";
            edit = false;
        }

        private void frm_emp_salary_Click(object sender, EventArgs e)
        {
            if (comob_wcode.Text=="" && txt_wname.Text=="")
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "ادخل كود المفرد ", "تحزير", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comob_period.Text == "")
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "ادخل الفتره ", "تحزير", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                v.WCode = comob_wcode.Text;
                v.Wname = txt_wname.Text;
                v.period_salary = comob_period.Text;

                hr.frm_subempwage f = new frm_subempwage();
                f.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }



    }
}