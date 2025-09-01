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

namespace f1.inventory.printer_items.report_items
{
    public partial class frm_rbt_trial_item_cost_and_sale_value : DevExpress.XtraEditors.XtraForm
    {
        public frm_rbt_trial_item_cost_and_sale_value()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
            db.Open();
            d1.Text = DateTime.Now.ToString(v.current_yaer + "/01/01");
            d2.Text = DateTime.Now.ToString(v.current_yaer + "/MM/dd");
        }

        private void frm_rbt_trial_item_cost_and_sale_value_Load(object sender, EventArgs e)
        {
            
            all_comb.load_wares(combo_wars);
            all_comb.load_unite_id(combo_unite);
            all_comb.load_name_items(combo_items_name);
            all_comb.load_code_items(combo_code);
            combo_items_name.Text = "";
            combo_code.Text = "";
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

        private void btn_del_inv_Click(object sender, EventArgs e)
        {
            combo_code.Text = "";
           
            combo_items_name.Text = "";
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {

            pos.frm_balance_qty f = new pos.frm_balance_qty();
            f.Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\trial_item_cost_and_sale_value.repx", true);
            xtraReport.Parameters["parameter1"].Value = combo_wars.Text;
            xtraReport.Parameters["parameter1"].Visible = false;
            xtraReport.Parameters["parameter2"].Value = combo_unite.Text;
            xtraReport.Parameters["parameter2"].Visible = false;
            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\trial_item_cost_and_sale_value_with_codeItems.repx", true);
            xtraReport.Parameters["parameter1"].Value = combo_wars.Text;
            xtraReport.Parameters["parameter1"].Visible = true;
            xtraReport.Parameters["parameter2"].Value = combo_unite.Text;
            xtraReport.Parameters["parameter2"].Visible = true;
            xtraReport.Parameters["parameter3"].Value = combo_code.Text;
            xtraReport.Parameters["parameter3"].Visible = true;
            xtraReport.Parameters["parameter4"].Value = db.GetData("select max(code_items) from items").Rows[0][0].ToString();
            xtraReport.Parameters["parameter4"].Visible = true;
            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\trial_item_cost_and_sale_value_Date.repx", true);
            xtraReport.Parameters["parameter1"].Value = combo_wars.Text;
            xtraReport.Parameters["parameter1"].Visible = true;
            
            xtraReport.Parameters["parameter2"].Value = d1.Value.ToString("yyyy/MM/dd");
            xtraReport.Parameters["parameter2"].Visible = true;
            xtraReport.Parameters["parameter3"].Value = d2.Value.ToString("yyyy/MM/dd");
            xtraReport.Parameters["parameter3"].Visible = true;
            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
        }
    }
}