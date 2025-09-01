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
    public partial class frm_rep_items_card : DevExpress.XtraEditors.XtraForm
    {
        public frm_rep_items_card()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
            db.Open();
            d1.Text = DateTime.Now.ToString(v.current_yaer + "/01/01");
            d2.Text = DateTime.Now.ToString(v.current_yaer + "/MM/dd");
            //yyyy/12/31
        }
        private void frm_rep_items_card_Load(object sender, EventArgs e)
        {
            all_comb.load_name_items(combo_items_name);
            all_comb.load_code_items(combo_code_items);

            all_comb.load_name_vcs(combo_vcs);

          
            all_comb.load_wares(combo_wars);
            all_comb.load_unite_id(combo_unite);

            combo_items_name.Text = "";
            combo_code_items.Text = "";

            combo_vcs.Text = "";
        }
        

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //dt.Clear();
            //if (combo_items.Text != "" && combo_vcs.Text == "")
            //{
            //    db.GetData_DGV(("select items_trans.code_items,items_trans.name_items,(items_trans.qty /unite.unite) as qty,items_trans.id_ware ,items_trans.dates,items_trans.attachbook,items_trans.attachnamebook ,items_trans.name_unite,items_trans.f_unite,items_trans.vcs_code,items_trans.vcs_name,attachno,info_co.name_of_company,info_co.address1,.info_co.tel1,info_co.logo from info_co,items_trans  left join unite on items_trans.code_items=unite.code_items  where items_trans.code_items='" + lbl_num.Text + "' and items_trans.id_ware='"+combo_wars.Text+"' and unite.id='"+combo_unite.Text+"'  order by  items_trans.dates   "), dt);
            //}

            //if (combo_items.Text == "" && combo_vcs.Text != "")
            //{
            //    db.GetData_DGV(("select items_trans.code_items,items_trans.name_items,(items_trans.qty /unite.unite) as qty,items_trans.id_ware ,items_trans.dates,items_trans.attachbook,items_trans.attachnamebook ,items_trans.name_unite,items_trans.f_unite,items_trans.vcs_code,items_trans.vcs_name,attachno,info_co.name_of_company,info_co.address1,.info_co.tel1,info_co.logo from info_co,items_trans  left join unite on items_trans.code_items=unite.code_items  where items_trans.vcs_code='" + lbl_code_vcs.Text + "' and items_trans.id_ware='" + combo_wars.Text + "' and unite.id='" + combo_unite.Text + "' order by  items_trans.dates "), dt);
            //}
            //if (combo_items.Text != "" && combo_vcs.Text != "")
            //{
            //    db.GetData_DGV(("select items_trans.code_items,items_trans.name_items,(items_trans.qty /unite.unite) as qty,items_trans.id_ware ,items_trans.dates,items_trans.attachbook,items_trans.attachnamebook ,items_trans.name_unite,items_trans.f_unite,items_trans.vcs_code,items_trans.vcs_name,attachno,info_co.name_of_company,info_co.address1,.info_co.tel1,info_co.logo from info_co,items_trans  left join unite on items_trans.code_items=unite.code_items  where items_trans.code_items='" + lbl_num.Text + "' and  items_trans.vcs_code='" + lbl_code_vcs.Text + "' and items_trans.id_ware='" + combo_wars.Text + "' and unite.id='" + combo_unite.Text + "' order by  items_trans.dates "), dt);

            //}
            XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\items_normal_card.repx", true);
            xtraReport.Parameters["parameter1"].Value = combo_code_items.Text;
            xtraReport.Parameters["parameter1"].Visible = true;
            xtraReport.Parameters["parameter2"].Value =combo_wars.Text;
            xtraReport.Parameters["parameter2"].Visible = true;
            xtraReport.Parameters["parameter3"].Value = combo_unite.Text;
            xtraReport.Parameters["parameter3"].Visible = true;
            xtraReport.Parameters["parameter5"].Value = d1.Value.ToString("yyyy/MM/dd");
            xtraReport.Parameters["parameter5"].Visible = true;
            xtraReport.Parameters["parameter6"].Value = d2.Value.ToString("yyyy/MM/dd");
            xtraReport.Parameters["parameter6"].Visible = true;

            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);



        }
        private void combo_code_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combo_items_name.Text = db.GetData("select name_items from items where code_items='" + combo_code_items.Text + "' ").Rows[0][0].ToString();

            }
            catch (Exception)
            {


            }
        }
        private void combo_items_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combo_code_items.Text = db.GetData("select code_items from items where name_items='" + combo_items_name.Text + "' ").Rows[0][0].ToString();

            }
            catch (Exception)
            {


            }
        }
        private void combo_vcs_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_code_vcs.Text = db.GetData("select vcs_code from vcs where vcs_name ='" + combo_vcs.Text + "'").Rows[0][0].ToString();
              

            }
            catch (Exception)
            {


            }
        }
     
        private void combo_items_Click(object sender, EventArgs e)
        {
            
        }

        private void combo_vcs_Click(object sender, EventArgs e)
        {
            

        }

        private void btn_del_inv_Click(object sender, EventArgs e)
        {
            combo_code_items.Text = "";
            combo_vcs.Text = "";
            combo_items_name.Text = "";
        }
    }
}