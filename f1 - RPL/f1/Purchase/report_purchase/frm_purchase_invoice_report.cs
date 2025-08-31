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

namespace f1.Purchase.report_purchase
{
    public partial class frm_purchase_invoice_report : DevExpress.XtraEditors.XtraForm
    {
        public frm_purchase_invoice_report()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
            db.Open();
            dt1.Text = DateTime.Now.ToString(v.current_yaer + "/MM/dd");
            dt2.Text = DateTime.Now.ToString(v.current_yaer + "/MM/dd");
        }
        private void frm_purchase_invoice_report_Load(object sender, EventArgs e)
        {
            all_comb.load_name_vcs(combo_vcs);
            all_comb.load_name_items(combo_name);
            all_comb.load_items_code(combo_items);

            combo_items.Text = "";
            combo_name.Text = "";

            combo_vcs.Text = "";
          

        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (rdo_vendor.Checked)
            {
                //1-must be enter vendor 
                if (ch_all.Checked)
                {
                    //report without vendor params 
                }
                else
                {
                    //report without vendor 



                }



            }
            else
            {

            }
        }
        private void combo_vcs_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            lbl_code_vcs.Text = db.GetData("select vcs_code from vcs where vcs_name ='"+combo_vcs.Text+"'").Rows[0][0].ToString();

            }
            catch (Exception)
            {
                
                
            }
        }
        private void combo_items_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
             combo_name.Text = db.GetData("select name_items from items where code_items='"+combo_items.Text+"' ").Rows[0][0].ToString();

            }
            catch (Exception)
            {
                
                
            }
        }

        private void combo_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combo_items.Text = db.GetData("select code_items from items where name_items='" + combo_name.Text + "' ").Rows[0][0].ToString();

            }
            catch (Exception)
            {

            }
        }
        
        private void btn_add_Click(object sender, EventArgs e)
        {
            txt_to_items.Text = combo_items.Text;
        }

        private void btn_add2_Click(object sender, EventArgs e)
        {
            txt_from_items.Text = combo_items.Text;
        }

        private void ch_all_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_all.Checked)
            {
                label1.Visible = true;
                lbl_code_vcs.Visible = true;
                combo_vcs.Visible = true;
            }
            else
            {

                label1.Visible = false;
                lbl_code_vcs.Visible = false;
                combo_vcs.Visible = false;
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            combo_items.Text = "";
            combo_name.Text = "";

        }
    }
}