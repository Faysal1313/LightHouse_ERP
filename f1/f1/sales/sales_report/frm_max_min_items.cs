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

namespace f1.sales.sales_report
{
    public partial class frm_max_min_items : DevExpress.XtraEditors.XtraForm
    {
        public frm_max_min_items()
        {
            InitializeComponent();
            db.Open();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
        }

        private void frm_max_min_items_Load(object sender, EventArgs e)
        {
            all_comb.load_name_items(combo_items_name);
            all_comb.load_code_items(combo_code);



            all_comb.load_wares(combo_wars);
            d1.Text = DateTime.Now.ToString(v.current_yaer + "/01/01");
            d2.Text = DateTime.Now.ToString(v.current_yaer + "/MM/dd");

            combo_items_name.Text = "";
            combo_code.Text = "";


        }
     
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            if (radioButton1.Checked==false)
            {
                XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\low_sale_by_period.repx", true);

                xtraReport.Parameters["parameter1"].Value = d1.Value.ToString("yyyy/MM/dd");
                xtraReport.Parameters["parameter1"].Visible = true;
                xtraReport.Parameters["parameter2"].Value = d2.Value.ToString("yyyy/MM/dd");
                xtraReport.Parameters["parameter2"].Visible = true;
                xtraReport.Parameters["parameter3"].Value = combo_wars.Text;
                xtraReport.Parameters["parameter3"].Visible = true;
                XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
            }
            else
            {
                XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\hight_sale_by_period.repx", true);

                xtraReport.Parameters["parameter1"].Value = d1.Value.ToString("yyyy/MM/dd");
                xtraReport.Parameters["parameter1"].Visible = true;
                xtraReport.Parameters["parameter2"].Value = d2.Value.ToString("yyyy/MM/dd");
                xtraReport.Parameters["parameter2"].Visible = true;
                xtraReport.Parameters["parameter3"].Value = combo_wars.Text;
                xtraReport.Parameters["parameter3"].Visible = true;
                XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
            }

         
        }

      

      

        private void combo_code_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combo_items_name.Text = db.GetData("select name_items from items where code_items='" + combo_code.Text + "' ").Rows[0][0].ToString();

            }
            catch (Exception)
            {


            }
        }

        private void combo_items_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combo_code.Text = db.GetData("select code_items from items where name_items='" + combo_items_name.Text + "' ").Rows[0][0].ToString();

            }
            catch (Exception)
            {


            }
        }
    }
}