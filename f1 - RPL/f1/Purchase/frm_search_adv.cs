using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace f1.Purchase
{
    public partial class frm_search_adv : DevExpress.XtraEditors.XtraForm
    {
        public frm_search_adv()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(v.ico);
        }
        private void frm_search_adv_Load(object sender, EventArgs e)
        {
            all_comb.load_wares(combo_wars);
            lbl_cat1.Text = db.GetData("select isnull(max(cat_items1),'-') from info_co").Rows[0][0].ToString();
            lbl_cat2.Text = db.GetData("select isnull(max(cat_items2),'-') from info_co").Rows[0][0].ToString();
            lbl_cat3.Text = db.GetData("select isnull(max(cat_items3),'-') from info_co").Rows[0][0].ToString();
            lbl_cat4.Text = db.GetData("select isnull(max(cat_items4),'-') from info_co").Rows[0][0].ToString();

            dgv.Columns["catmx1"].HeaderText = lbl_cat1.Text;
            dgv.Columns["catmx2"].HeaderText = lbl_cat2.Text;
            dgv.Columns["catmx3"].HeaderText = lbl_cat3.Text;
            dgv.Columns["catmx4"].HeaderText = lbl_cat4.Text;


            all_comb.load_cat(combo_cat1, "cat1");
            combo_cat1.Text = "";
            all_comb.load_cat(combo_cat2, "cat2");
            combo_cat2.Text = "";
            all_comb.load_cat(combo_cat3, "cat3");
            combo_cat3.Text = "";
            all_comb.load_cat(combo_cat4, "cat4");
            combo_cat4.Text = "";
            all_comb.load_main_code(combo_main_items);
            combo_main_items.Text = "";
        }
        private void btn_adv_search_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("select w.code_items,i.main_code,i.name_unite,i.name_items,w.qty,w.cost,i.price_sale,i.cat1,i.cat2,i.cat3,i.cat4 from wares w left join items i on i.code_items=w.code_items where i.cat1 = '" + combo_cat1.Text + "' or cat2 = '" + combo_cat2.Text + "' or cat3 = '" + combo_cat3.Text + "' or cat4 = '" + combo_cat4.Text + "' or price_sale = '" + txt_sale_price.Text + "' or main_code = '" + combo_main_items.Text + "'  and id_ware='" + combo_wars.Text + "' ", dt);
            dgv.DataSource = dt;
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.ColumnIndex + "");

            if (e.ColumnIndex == 0)
            {
                if (dgv.Rows.Count < 0) return;
                frm_item f = new frm_item();
                f.Show();
                f.txt_code_items.Text = dgv.CurrentRow.Cells["code_items_s"].Value + "";
                f.txt_code_items.Select();
                f.txt_name_items.Select();
            }
            ////MessageBox.Show(e.ColumnIndex + "");
            if (e.ColumnIndex == 1)
            {
                v.search_adv = dgv.CurrentRow.Cells[0].Value + "+g";
                lbl_message.Text = dgv.CurrentRow.Cells[0].Value + " تم إضافة الصنف ";
            }
            //    if (dgv.Rows.Count < 0) return;
            //    frm_item f = new frm_item();
            //    f.Show();
            //    f.txt_code_items.Text = dgv.CurrentRow.Cells["code_items_s"].Value + "";
            //    f.txt_code_items.Select();
            //    f.txt_name_items.Select();
            //}
            if (e.ColumnIndex == 5)
            {
                group_price.Visible = true;
                DataTable dt = new DataTable();
                db.GetData_DGV("select distinct d.item_price,h.date_P,h.vcs_code,h.vcs_name, h.purchase_hd_id,h.inv_no_manual from purchase_dt d left join purchase_hd h on d.purchase_hd_id=h.purchase_hd_id where  code_items='" + dgv.CurrentRow.Cells["code_items_s"].Value + "" + "' order by h.date_P", dt);
                dgv_pending.DataSource = dt;
            }
            if (e.ColumnIndex == 4)
            {
                pos.frm_items_card f = new pos.frm_items_card();
                f.Show();
                f.combo_code_items.Text = dgv.CurrentRow.Cells["code_items_s"].Value + "";
                f.btn_serchinv.PerformClick();
            }
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgv.Rows.Count == 0)
            {
                return;
            }
            if (e.KeyCode == Keys.Enter)
            {

                v.search_adv = dgv.CurrentRow.Cells[0].Value + "+g";
                lbl_message.Text = dgv.CurrentRow.Cells[0].Value + " تم إضافة الصنف ";
                //  Close();
            }
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //db.GetData_DGV("select w.code_items,i.main_code,i.name_unite,i.name_items,w.qty,w.cost,i.price_sale,i.cat1,i.cat2,i.cat3,i.cat4 from wares w left join items i on i.code_items=w.code_items where i.cat1 = '" + combo_cat1.Text + "' or cat2 = '" + combo_cat2.Text + "' or cat3 = '" + combo_cat3.Text + "' or cat4 = '" + combo_cat4.Text + "' or price_sale = '" + txt_sale_price.Text + "' or main_code = '" + combo_main_items.Text + "' and i.name_items like'%" + txt_search.Text + "%'  and id_ware='" + combo_wars.Text + "' ", dt);
            db.GetData_DGV("select w.code_items,i.main_code,i.name_unite,i.name_items,w.qty,w.cost,i.price_sale,i.cat1,i.cat2,i.cat3,i.cat4 from wares w left join items i on i.code_items=w.code_items where  i.name_items like'%" + txt_search.Text + "%'  and id_ware='" + combo_wars.Text + "' ", dt);
            dgv.DataSource = dt;
        }

        private void txt_search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '\''))
            {
                e.Handled = true;
            }
        }

        private void btn_last_price_Click(object sender, EventArgs e)
        {
            group_price.Visible = false;
        }

        private void dgv_pending_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 4)
            {
                if (db.GetData("select isnull(max(purchase_hd_id),0) from purchase_dt where purchase_hd_id='" + dgv_pending.CurrentRow.Cells["Column4"].Value + "" + "'").Rows[0][0] + "" != "0")
                {
                    frm_purchase f = new frm_purchase();
                    f.Show();
                    f.txt_serial_string.Text = dgv_pending.CurrentRow.Cells["Column4"].Value + "";
                    f.txt_serial_string.Select();
                    f.txt_barcode.Select();
                }
            }
            if (e.ColumnIndex == 5)
            {
                if (db.GetData("select isnull(max(purchase_hd_id),0) from purchase_dt where purchase_hd_id='" + dgv_pending.CurrentRow.Cells["Column4"].Value + "" + "'").Rows[0][0] + "" != "0")
                {
                    frm_purchase f = new frm_purchase();
                    f.Show();
                    f.txt_serial_string.Text = dgv_pending.CurrentRow.Cells["Column4"].Value + "";
                    f.txt_serial_string.Select();
                    f.txt_barcode.Select();
                }
            }
        }

        private void txt_search_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    dgv.Select();
                }
                if (e.KeyCode == Keys.Up)
                {
                    dgv.Select();
                }
            }
            catch (Exception)
            {


            }
        }
    }
}