using DevExpress.XtraEditors;
using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace f1.account.report_account
{
    public partial class frm_rpt_report_acc_statment_gl : DevExpress.XtraEditors.XtraForm
    {
        public frm_rpt_report_acc_statment_gl()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
            dt_piker.Text = DateTime.Now.ToString("yyyy/MM/dd");


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\stat_gl.repx", true);


            xtraReport.Parameters["parameter1"].Value = dt_piker.Value.ToString("yyyy/MM/dd");
            xtraReport.Parameters["parameter1"].Visible = false;
            //xtraReport.Parameters["parameter2"].Value = dt_piker2.Value.ToString("yyyy/12/31");
            //xtraReport.Parameters["parameter2"].Visible = false;

            xtraReport.Parameters["parameter2"].Value = lbl_code_vcs.Text;
            xtraReport.Parameters["parameter2"].Visible = false;

            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
        }

        private void combo_vcs_Click(object sender, EventArgs e)
        {
            all_comb.load_account_name_c(combo_vcs);
        }

        private void combo_vcs_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_code_vcs.Text = db.GetData("select rootid from tree where rootname ='" + combo_vcs.Text + "'").Rows[0][0].ToString();

            }
            catch (Exception)
            {


            }
        }
    }
}