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

namespace f1.hr.report_hr
{
    public partial class frm_rpt_Action : DevExpress.XtraEditors.XtraForm
    {
        public frm_rpt_Action()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon("f1.exe");

        }

        private void frm_rpt_Action_Load(object sender, EventArgs e)
        {
            all_comb.load_emp_users(combo_items);
            combo_items.Text = "";
            dt_piker.Text = DateTime.Now.ToString("yyyy/MM/dd");

        }

        private void combo_items_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_num.Text = db.GetData("select emp_no from emps where emp_name='" + combo_items.Text + "' ").Rows[0][0].ToString();

            }
            catch (Exception)
            {


            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Clear();

            db.GetData_DGV(("select * from action where emp_code='" + lbl_num.Text + "' and date<='" + dt_piker.Value.ToString("MM-dd-yyyy") + "'  "), dt);
            hr.report_hr.frm_hr_report_view frm = new hr.report_hr.frm_hr_report_view();
            hr.report_hr.rpt_Action rpt = new hr.report_hr.rpt_Action();
            rpt.SetDataSource(dt);
            frm.crystalReportViewer1.RefreshReport();
            rpt.DataSourceConnections[0].IntegratedSecurity = false;
            rpt.DataSourceConnections[0].SetConnection(db.ip, db.dbname, db.sql_user, db.sql_pass);
            //  rpt.SetParameterValue("id", id);
            frm.crystalReportViewer1.ReportSource = rpt;
          
            frm.ShowDialog();
        }
    }
}