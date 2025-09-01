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

namespace f1.sales.sales_report.sale_forms
{
    public partial class frm_rbt_sales_invoice_profit : DevExpress.XtraEditors.XtraForm
    {
        public frm_rbt_sales_invoice_profit()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon("f1.exe");
        }

        private void frm_rbt_sales_invoice_profit_Load(object sender, EventArgs e)
        {
            all_comb.load_sale_hd_id(combo_id_sale);
            combo_id_sale.Text = "";
            all_comb.load_wares(combo_wars);
            all_comb.load_name_vcs(combo_vcs);
            combo_vcs.Text = "";
            dt_piker.Text = DateTime.Now.ToString("yyyy/MM/dd");
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Clear();

            if (combo_id_sale.Text=="" && combo_vcs.Text=="")
            {
               db.GetData_DGV(("select sale_hd.date_P,sale_dt .sale_hd_id,sum(sale_dt .incloud_taxes) as net_sale,sum(wares.cost * sale_dt.qty)as net_cost,sum(sale_dt .incloud_taxes) - sum(wares.cost * sale_dt.qty) as profit from sale_dt left join wares on wares.code_items =sale_dt.code_items  left join sale_hd on sale_dt.sale_hd_id=sale_hd.sale_hd_id  where  wares.id_ware='"+combo_wars.Text+"' and date_P <='"+dt_piker.Value.ToString("yyyy/MM/dd")+"' group by sale_hd.date_P,sale_dt .sale_hd_id,sale_hd.date_P order by sale_hd.date_P "), dt);
            }
            else if (combo_id_sale.Text != "" && combo_vcs.Text == "")
            {
                db.GetData_DGV(("select sale_hd.date_P,sale_dt .sale_hd_id,sum(sale_dt .incloud_taxes) as net_sale,sum(wares.cost * sale_dt.qty)as net_cost,sum(sale_dt .incloud_taxes) - sum(wares.cost * sale_dt.qty) as profit from sale_dt left join wares on wares.code_items =sale_dt.code_items  left join sale_hd on sale_dt.sale_hd_id=sale_hd.sale_hd_id  where  wares.id_ware='" + combo_wars.Text + "' and date_P <='" + dt_piker.Value.ToString("yyyy/MM/dd") + "' and sale_hd.sale_hd_id='"+combo_id_sale.Text+"' group by sale_hd.date_P,sale_dt .sale_hd_id,sale_hd.date_P order by sale_hd.date_P "), dt);
            }
            else if (combo_id_sale.Text == "" && combo_vcs.Text != "")
            {
                db.GetData_DGV(("select sale_hd.date_P,sale_dt .sale_hd_id,sum(sale_dt .incloud_taxes) as net_sale,sum(wares.cost * sale_dt.qty)as net_cost,sum(sale_dt .incloud_taxes) - sum(wares.cost * sale_dt.qty) as profit from sale_dt left join wares on wares.code_items =sale_dt.code_items  left join sale_hd on sale_dt.sale_hd_id=sale_hd.sale_hd_id  where  wares.id_ware='" + combo_wars.Text + "' and date_P <='" + dt_piker.Value.ToString("yyyy/MM/dd") + "' and sale_hd.vcs_code='"+lbl_code_vcs.Text+"' group by sale_hd.date_P,sale_dt .sale_hd_id,sale_hd.date_P order by sale_hd.date_P "), dt);
            
            }
            else if (combo_id_sale.Text != "" && combo_vcs.Text != "")
            {
                db.GetData_DGV(("select sale_hd.date_P,sale_dt .sale_hd_id,sum(sale_dt .incloud_taxes) as net_sale,sum(wares.cost * sale_dt.qty)as net_cost,sum(sale_dt .incloud_taxes) - sum(wares.cost * sale_dt.qty) as profit from sale_dt left join wares on wares.code_items =sale_dt.code_items  left join sale_hd on sale_dt.sale_hd_id=sale_hd.sale_hd_id  where  wares.id_ware='" + combo_wars.Text + "' and date_P <='" + dt_piker.Value.ToString("yyyy/MM/dd") + "' and sale_hd.vcs_code='" + lbl_code_vcs.Text + "' and sale_hd.sale_hd_id='" + combo_id_sale.Text + "' and sale_hd.sale_hd_id='" + combo_id_sale.Text + "' group by sale_hd.date_P,sale_dt .sale_hd_id,sale_hd.date_P order by sale_hd.date_P "), dt);
            
            }

           
            
        }
    }
}