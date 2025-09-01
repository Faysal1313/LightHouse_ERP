using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace f1.inventory
{
    public partial class frm_wizard_adjustment_qty : DevExpress.XtraEditors.XtraForm
    {
        public frm_wizard_adjustment_qty()
        {
            InitializeComponent();
            db.Open();
        }

        private void frm_wizard_adjustment_qty_Load(object sender, EventArgs e)
        {
            all_comb.load_wares(combo_wars);
            rdo_adj_without_exp.Checked = true;
        }

        private void combo_wars_SelectedIndexChanged(object sender, EventArgs e)
        {
           v.code_Wares_adj_qty=combo_wars.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(v.code_Wares_adj_qty+"Test");
        }

        private void rdo_adj_without_exp_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_adj_without_exp.Checked==true)
            {
                rdo_with_exp_excel.Visible = false;
                rdo_with_exp_manual.Visible = false;

                rdo_with_excel.Visible = true;
                rdo_manual.Visible = true;
            }
        }

        private void rdo_adj_with_exp_CheckedChanged(object sender, EventArgs e)
        {
            rdo_with_excel.Visible = false;
            rdo_manual.Visible = false;

            rdo_with_exp_excel.Visible = true;
            rdo_with_exp_manual.Visible = true;
        }
        private void test_btn_Click(object sender, EventArgs e)
        {
            if (rdo_manual.Checked==true)
            {
                frm_adjustment_qty f = new frm_adjustment_qty();
                f.ShowDialog();
            }
            else if (rdo_with_excel.Checked==true)
            {
                MessageBox.Show("excel normal");
            }
            else if (rdo_with_exp_manual.Checked == true)
            {
                inventory.adjustment_qty_exp f = new adjustment_qty_exp();
                f.ShowDialog();
            }
            else if (rdo_with_exp_excel.Checked==true)
            {
                MessageBox.Show("excel expiry");
                
            }
        }

        private void wizardControl1_NextClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
            if (chk_intro.Checked == false)
            {
                e.Handled = true;
            }
            //else if (rdo_manual.Checked==true || rdo_with_excel.Checked==true || rdo_with_exp_manual.Checked == true ||rdo_with_exp_excel.Checked==true)
            //{
            //    e.Handled = true;
                
            //}
           //  if (chk_complet.Checked == false)
            {
               // e.Handled = true;
            }
            complet= v.adj_complet;
            
        }
        bool complet = false;
        private void wizardControl1_FinishClick(object sender, CancelEventArgs e)
        {
            if (complet == true)
            {
                db.Run("update info_co set stop_qty_move='False'");
                Close();
            }
        }

        private void chk_intro_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_intro.Checked==true)
            {
                db.Run("update info_co set stop_qty_move='True'");
            }
            else
            {
                db.Run("update info_co set stop_qty_move='False'");

            }
        }

        private void wizardControl1_CancelClick(object sender, CancelEventArgs e)
        {
            e.Cancel = false;

        }


    }
}