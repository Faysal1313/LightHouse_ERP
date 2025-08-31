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
    public partial class frm_rpt_report_acc_statment_vcs : DevExpress.XtraEditors.XtraForm
    {
        public frm_rpt_report_acc_statment_vcs()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
        }
        private void frm_rpt_report_acc_statment_vcs_Load(object sender, EventArgs e)
        {
            combo_vcs.Text = "";
            dt_piker.Text = DateTime.Now.ToString("yyyy/MM/dd");
            //dt_piker2.Text = DateTime.Now.ToString("yyyy/12/31");
        }
        private void combo_gl_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_code_vcs.Text = db.GetData("select vcs_code from vcs where vcs_name ='" + combo_vcs.Text + "'").Rows[0][0].ToString();

            }
            catch (Exception)
            {


            }
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
            all_comb.load_name_vcs(combo_vcs);

        }

       
    }
}