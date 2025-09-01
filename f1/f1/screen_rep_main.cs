using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace f1
{
    public partial class screen_rep_main : DevExpress.XtraEditors.XtraForm
    {
        public screen_rep_main()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
            this.dt_piker1.Text = DateTime.Now.ToString("yyyy/MM/01");
            this.dt_piker2.Text = DateTime.Now.ToString("yyyy/MM/dd");
            all_comb.load_name_items(combo_name);
            combo_name.Text = "";
            // all_comb.cost_center_name(this.combo_costcenter);
            // lbl_costcenter.Text = db.GetData("select  isnull(max(costcenter_id),0) from  costcenter where costcenter_name='" + combo_costcenter.Text + "'").Rows[0][0].ToString();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //screen purchase
           // v.search_screen = "purchase_rep";
             if(v.search_screen== "purchase_rep")
            {
                if(combo_code.Text=="")
                {
                    XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\purchase1.repx", true);
                    xtraReport.Parameters["date1"].Visible = false;
                    xtraReport.Parameters["date1"].Value = dt_piker1.Value.ToString("yyyy/MM/dd");
                    xtraReport.Parameters["date2"].Visible = false;
                    xtraReport.Parameters["date2"].Value = dt_piker2.Value.ToString("yyyy/12/31");
                  //  xtraReport.Parameters["pr_codeItem"].Visible = false;
                   // xtraReport.Parameters["pr_codeItem"].Value = combo_code.Text;
                    XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
                }
                else
                {
                    XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\purchase2.repx", true);
                    xtraReport.Parameters["date1"].Visible = false;
                    xtraReport.Parameters["date1"].Value = dt_piker1.Value.ToString("yyyy/MM/dd");
                    xtraReport.Parameters["date2"].Visible = false;
                    xtraReport.Parameters["date2"].Value = dt_piker2.Value.ToString("yyyy/12/31");
                    xtraReport.Parameters["pr_codeItem"].Visible = false;
                    xtraReport.Parameters["pr_codeItem"].Value = combo_code.Text;
                    XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);




                }




               // v.search_screen = "";
            }
            else if(v.search_screen== "sales_rep")
            {
                if (combo_code.Text == "")
                {
                    XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\sales1.repx", true);
                    xtraReport.Parameters["date1"].Visible = false;
                    xtraReport.Parameters["date1"].Value = dt_piker1.Value.ToString("yyyy/MM/dd");
                    xtraReport.Parameters["date2"].Visible = false;
                    xtraReport.Parameters["date2"].Value = dt_piker2.Value.ToString("yyyy/12/31");
                    //  xtraReport.Parameters["pr_codeItem"].Visible = false;
                    // xtraReport.Parameters["pr_codeItem"].Value = combo_code.Text;
                    XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
                }
                else
                {
                    XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\sales2.repx", true);
                    xtraReport.Parameters["date1"].Visible = false;
                    xtraReport.Parameters["date1"].Value = dt_piker1.Value.ToString("yyyy/MM/dd");
                    xtraReport.Parameters["date2"].Visible = false;
                    xtraReport.Parameters["date2"].Value = dt_piker2.Value.ToString("yyyy/12/31");
                    xtraReport.Parameters["pr_codeItem"].Visible = false;
                    xtraReport.Parameters["pr_codeItem"].Value = combo_code.Text;
                    XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);




                }


            }

            //screen sales
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            combo_code.Text = "";
            combo_name.Text = "";
        }

        private void combo_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combo_code.Text = db.GetData("select code_items from items where name_items='" + combo_name.Text + "' ").Rows[0][0]+"";
            }
            catch (Exception)
            {

               
            }
        }

        private void screen_rep_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            v.search_screen = "";
        }
    }
}