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
    public partial class frm_rpt_costcenter_statment : DevExpress.XtraEditors.XtraForm
    {
        public frm_rpt_costcenter_statment()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
            this.dt_piker.Text = DateTime.Now.ToString("yyyy/MM/dd");
            this.dt_piker2.Text = DateTime.Now.ToString("yyyy/MM/dd");
            all_comb.cost_center_name(this.combo_costcenter);
            lbl_costcenter.Text = db.GetData("select  isnull(max(costcenter_id),0) from  costcenter where costcenter_name='" + combo_costcenter.Text + "'").Rows[0][0].ToString();


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\costcenter.repx", true);


            xtraReport.Parameters["pr1"].Value = lbl_costcenter.Text;
            //xtraReport.Parameters["pr1"].Visible = false;
            
            xtraReport.Parameters["date1"].Value = dt_piker.Value.ToString("yyyy/MM/dd");
            //xtraReport.Parameters["date1"].Visible = false;
            xtraReport.Parameters["date2"].Value = dt_piker2.Value.ToString("yyyy/12/31");
            //xtraReport.Parameters["date2"].Visible = false;

         

            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
        }

        private void combo_costcenter_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_costcenter.Text = db.GetData("select  isnull(max(costcenter_id),0) from  costcenter where costcenter_name='" + combo_costcenter.Text + "'").Rows[0][0].ToString();

        }
    }
}