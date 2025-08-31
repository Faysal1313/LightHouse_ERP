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
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports;

namespace f1.account.report_account
{
    public partial class frm_rbt_Trial_balance_general : DevExpress.XtraEditors.XtraForm
    {
        public frm_rbt_Trial_balance_general()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);

        }

        private void frm_rbt_Trial_balance_general_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
           // db.Open();
            dt_piker.Text = DateTime.Now.ToString("yyyy/MM/dd");
            dt_piker.Text = DateTime.Now.ToString("yyyy/MM/dd");
            rdcustomer.Checked = true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (rdcustomer.Checked==true)
            {
                XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\trial_gl.repx", true);
                xtraReport.Parameters["parameter1"].Value = dt_piker.Text;
                xtraReport.Parameters["parameter1"].Visible = false;
                XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);

            }
            else
            {
                XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\trial_gl_short.repx", true);
                xtraReport.Parameters["parameter1"].Value = dt_piker.Text;
                xtraReport.Parameters["parameter1"].Visible = false;
                XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
            }


        }

        private void combo_vcs_SelectedIndexChanged(object sender, EventArgs e)
        {
               
        }


    }
}