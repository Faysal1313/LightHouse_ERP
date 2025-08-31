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

namespace f1.pos
{
    public partial class frm_items_card : DevExpress.XtraEditors.XtraForm
    {
        public frm_items_card()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(v.ico);
            //string y = db.GetData("select year_card from info_co").Rows[0][0] + "";
            string y = db.GetData("select period from info_co").Rows[0][0] + "";

            date1.Text = DateTime.Now.ToString(""+y+"/01/01");
            //d1.Text = DateTime.Now.ToString("2021/01/01");

            date2.Text = DateTime.Now.ToString("yyyy/MM/dd");

            //all_comb.load_items_for_purchase_name1(combo_name_items);
            //all_comb.load_items_code(combo_code_items);
            combo_name_items.Text = "";
            combo_code_items.Text = "";
            combo_name_items.Text = "";
            combo_code_items.Text = "";
            all_comb.load_wares(this.combo_wars);
            compo_unite.Text = "1";

        }

        private void Btn_search_items_Click(object sender, EventArgs e)
        {
            all_comb.load_items_for_purchase_name1(combo_name_items);
            all_comb.load_items_code(combo_code_items);
            combo_name_items.Text = "";
            combo_code_items.Text = "";

        }

        private void Btn_del_Click(object sender, EventArgs e)
        {
            combo_name_items.Text = "";
            combo_code_items.Text = "";
            c = "";
        }

        private void Combo_code_items_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combo_name_items.Text = db.GetData("select (name_items) from items where code_items='" + combo_code_items.Text + "'").Rows[0][0].ToString();
                lbl_name.Text = db.GetData("select (name_items) from items where code_items='" + combo_code_items.Text + "'").Rows[0][0].ToString();
                // c = "";
                // pos.frm_balance_qty.code = "";
            }
            catch (Exception)
            {
            }
        }

        private void Combo_name_items_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combo_code_items.Text = db.GetData("select (code_items) from items where name_items='" + combo_name_items.Text + "'").Rows[0][0].ToString();
               // c = "";
               // pos.frm_balance_qty.code = "";
            }
            catch (Exception)
            {
            }
        }

        
         private string c = "";
        private void Btn_serchinv_Click(object sender, EventArgs e)
        {
            c = combo_code_items.Text;
            int u = 1;
            DataTable dt = new DataTable();
            string query = "select '' as time,'' as nam_doc,'0'  as    [no],   '' as no_inv,qty*f_unite/'" + u + "' as qty,old_cost as item_price,code_items,name_items,dates as date,vcs_name,vcs_code,name_unite from items_trans where code_items='" + c + "' and  dates between '" + date1.Value.ToString("MM-dd-yyyy") + "' and '" + date2.Value.ToString("MM-dd-yyyy") + "' and id_ware='" + combo_wars.Text + "' and opening_qty <>'0' union all  select  '' as time, h.name_book as nam_doc,[no],d.purchase_hd_id as no_inv,d.qty*d.f_unite/'" + u+"' as qty,(select cost from wares where code_items='" + c + "' and id_ware='" + combo_wars.Text + "') as item_price,code_items,name_items,h.date_P as [date],h.vcs_name,h.vcs_code,name_unite from purchase_dt d left join purchase_hd h on d.purchase_hd_id=h.purchase_hd_id  where d.code_items='" + c + "'  and  h.date_P between '" + date1.Value.ToString("MM-dd-yyyy") + "' and '" + date2.Value.ToString("MM-dd-yyyy") + "' and h.id_ware='" + combo_wars.Text + "'  union all   select time_h as time,'POS ' +[state] as nam_doc,'0' as [no], pos_inv_no as no_inv, (qty* f_unite/'" + u + "') *-1 as qty , item_price, code_items, name_items, date_d as [date], vcs_name, vcs_code, name_unite from pos_dt where code_items = '" + c + "' and date_d between '" + date1.Value.ToString("MM-dd-yyyy") + "' and '" + date2.Value.ToString("MM-dd-yyyy") + "'  and id_ware = '" + combo_wars.Text + "'    union all     select   '' as time,attachnamebook as nam_doc,'' as [no], attachno as no_inv, qty * f_unite/'" + u + "', 0 as item_price, code_items, name_items, dates as [date], vcs_name, vcs_code, name_unite from items_trans where code_items = '" + c + "' and attachbook = 'سند جرد مخزني' and dates between '" + date1.Value.ToString("MM-dd-yyyy") + "' and '" + date2.Value.ToString("MM-dd-yyyy") + "'  and id_ware = '" + combo_wars.Text + "'     union all      select   '' as time,h.name_book as nam_doc ,'' as [no], d.rpurchase_hd_id as no_inv, (qty* f_unite/'" + u + "')-1 as qty, 0 as item_price, code_items, name_items, h.date_P as [date], vcs_name, vcs_code, name_unite from rpurchase_dt d left join rpurchase_hd h on d.rpurchase_hd_id = h.rpurchase_hd_id  where code_items = '" + c + "' and date_P between '" + date1.Value.ToString("MM-dd-yyyy") + "' and '" + date2.Value.ToString("MM-dd-yyyy") + "' and h.id_ware = '" + combo_wars.Text + "'       union all       select  '' as time,h.name_book as nam_doc,'' as [no], d.sale_hd_id as no_inv, (qty* f_unite/'" + u + "')*-1 as qty, 0 as item_price, code_items, name_items, h.date_P as [date], vcs_name, vcs_code, name_unite from sale_dt d left join sale_hd h on d.sale_hd_id = h.sale_hd_id  where code_items = '" + c + "' and date_P between '" + date1.Value.ToString("MM-dd-yyyy") + "' and '" + date2.Value.ToString("MM-dd-yyyy") + "'  and h.id_ware = '" + combo_wars.Text + "'        union all        select  '' as time,h.name_book as nam_doc,'' as [no], d.rsale_hd_id as no_inv, qty*f_unite/'" + u + "', 0 as item_price, code_items, name_items, h.date_P as [date], vcs_name, vcs_code, name_unite from rsale_dt d left join rsale_hd h on d.rsale_hd_id = h.rsale_hd_id  where code_items = '" + c + "' and date_P between '" + date1.Value.ToString("MM-dd-yyyy") + "' and '" + date2.Value.ToString("MM-dd-yyyy") + "' and h.id_ware = '" + combo_wars.Text + "'        union all        select  '' as time,h.name_book as nam_doc,'' as [no], d.issuer_inv_hd_id as no_inv, d.qty* d.f_unite/'"+u+"' * -1 as qty, 0 as item_price, d.code_items, d.name_items, h.date_P as [date], vcs_name, vcs_code, name_unite from issuer_inv_dt d left join issuer_inv_hd h on d.issuer_inv_hd_id = h.issuer_inv_hd_id  where d.code_items = '" + c + "' and h.date_P between '" + date1.Value.ToString("MM-dd-yyyy") + "' and '" + date2.Value.ToString("MM-dd-yyyy") + "' and h.id_ware = '" + combo_wars.Text + "' union all select  '' as time,h.name_book as nam_doc,'' as [no], d.trans_hd_id as no_inv, (d.qty* d.f_unite/'"+u+"') * -1 as qty, 0 as item_price, d.code_items, d.name_items, h.date_P as [date], vcs_name, vcs_code, name_unite from trans_dt d left join trans_hd h on d.trans_hd_id = h.trans_hd_id  where d.code_items = '"+c+"' and h.date_P between '" + date1.Value.ToString("MM-dd-yyyy") + "' and '" + date2.Value.ToString("MM-dd-yyyy") + "' and h.id_ware = '"+combo_wars.Text+ "'  union all select  '' as time,h.name_book as nam_doc,'' as [no], d.trans_hd_id as no_inv, (d.qty* d.f_unite/'"+u+"')  as qty, 0 as item_price, d.code_items, d.name_items, h.date_P as [date], vcs_name, vcs_code, name_unite from trans_dt d left join trans_hd h on d.trans_hd_id = h.trans_hd_id  where d.code_items = '" + c + "' and h.date_P between '" + date1.Value.ToString("MM-dd-yyyy") + "' and '" + date2.Value.ToString("MM-dd-yyyy") + "' and h.id_ware2 = '" + combo_wars.Text + "' order by date ";
            db.GetData_DGV(query, dt);
            //db.GetData_DGV("select  '' as time, h.name_book as nam_doc,[no],d.purchase_hd_id as no_inv,d.qty*d.f_unite as qty,(select cost from wares where code_items='" + c + "' and id_ware='" + combo_wars.Text + "') as item_price,code_items,name_items,h.date_P as [date],h.vcs_name,h.vcs_code,name_unite from purchase_dt d left join purchase_hd h on d.purchase_hd_id=h.purchase_hd_id  where d.code_items='" + c + "'  and  h.date_P between '" + d1.Value.ToString("MM-dd-yyyy") + "' and '" + d2.Value.ToString("MM-dd-yyyy") + "' union all select  time_h as time,'POS '+[state] as nam_doc,'0' as [no], pos_inv_no as no_inv, qty * -1, item_price, code_items, name_items, date_d as [date], vcs_name, vcs_code, name_unite from pos_dt where code_items = '" + c + "' and date_d between '" + d1.Value.ToString("MM-dd-yyyy") + "' and '" + d2.Value.ToString("MM - dd - yyyy") + "' union all select   '' as time,attachnamebook as nam_doc,'' as [no], attachno as no_inv, qty, 0 as item_price, code_items, name_items, dates as [date], vcs_name, vcs_code, name_unite from items_trans where code_items = '" + c + "' and attachbook = 'سند جرد مخزني' and  dates between '" + d1.Value.ToString("MM-dd-yyyy") + "' and '" + d2.Value.ToString("MM - dd - yyyy") + "' union all select   '' as time,h.name_book as nam_doc ,'' as [no], d.rpurchase_hd_id as no_inv, qty*-1, 0 as item_price, code_items, name_items, h.date_P as [date], vcs_name, vcs_code, name_unite from rpurchase_dt d left join rpurchase_hd h on d.rpurchase_hd_id = h.rpurchase_hd_id  where code_items = '" + c + "' and date_P between '" + d1.Value.ToString("MM-dd-yyyy") + "' and '" + d2.Value.ToString("MM - dd - yyyy") + "' union all select  '' as time,h.name_book as nam_doc,'' as [no], d.sale_hd_id as no_inv, qty*-1, 0 as item_price, code_items, name_items, h.date_P as [date], vcs_name, vcs_code, name_unite from sale_dt d left join sale_hd h on d.sale_hd_id = h.sale_hd_id  where code_items = '" + c + "' and date_P between '" + d1.Value.ToString("MM-dd-yyyy") + "' and '" + d2.Value.ToString("MM - dd - yyyy") + "' union all select  '' as time,h.name_book  as nam_doc,'' as [no], d.rsale_hd_id as no_inv, qty, 0 as item_price, code_items, name_items, h.date_P as [date], vcs_name, vcs_code, name_unite from rsale_dt d left join rsale_hd h on d.rsale_hd_id = h.rsale_hd_id  where code_items = '" + c + "' and date_P between '" + d1.Value.ToString("MM-dd-yyyy") + "' and '" + d2.Value.ToString("MM-dd-yyyy") + "' union all  select  '' as time,h.name_book  as nam_doc,'' as [no], d.issuer_inv_hd_id as no_inv, d.qty*d.f_unite*-1, 0 as item_price, d.code_items, d.name_items, h.date_P as [date], vcs_name, vcs_code, name_unite from issuer_inv_dt d left join issuer_inv_hd h on d.issuer_inv_hd_id = h.issuer_inv_hd_id  where d.code_items ='" + c + "' and h.date_P between '" + d1.Value.ToString("MM-dd-yyyy") + "' and '" + d2.Value.ToString("MM-dd-yyyy") + "' order by date ", dt);

            dgvc.DataSource = dt;
            calc();
            calc_bal();
        }

       private void calc_bal()
        {
            try
            {
                double q1 = 0;
                double q2 = 0;
                double q3 = 0;

                for (int i = 0; i < dgvc.Rows.Count; i++)
                {
                    q1 += Convert.ToDouble(dgvc.Rows[i].Cells["imp"].Value + "");
                    q2 += Convert.ToDouble(dgvc.Rows[i].Cells["exp"].Value + "");

                }

                q3 = q1 - q2;

                lbl_bal.Text = Math.Round(q3, 3) + "";
                lbl_imp.Text = Math.Round(q1, 3) + "";
                lbl_exp.Text = Math.Round(q2, 3) + "";
            }
            catch (Exception)
            {

            }
        }

        private void calc()
        {
            try
            {
                double q = 0;
                double q2 = 0;

                double bal_q = 0;
                for (int i = 0; i < dgvc.Rows.Count; i++)
                {
                    if (Convert.ToDouble(dgvc.Rows[i].Cells["qty_c"].Value) >0)
                    {
                        dgvc.Rows[i].Cells["imp"].Value = dgvc.Rows[i].Cells["qty_c"].Value;
                        dgvc.Rows[i].Cells["exp"].Value = 0;
                    }
                    else
                    {
                        dgvc.Rows[i].Cells["exp"].Value = Convert.ToDouble(dgvc.Rows[i].Cells["qty_c"].Value)*-1;
                        dgvc.Rows[i].Cells["imp"].Value = 0;
                    }
                    bal_q= bal_q+Convert.ToDouble(dgvc.Rows[i].Cells["imp"].Value) - Convert.ToDouble(dgvc.Rows[i].Cells["exp"].Value);
                    dgvc.Rows[i].Cells["bal_c"].Value = bal_q;

                }
                lbl_bal.Text = (Math.Round((q - q2), 3)) + "";
            }
            catch (Exception)
            {

            }


        }

       
        private void Frm_items_card_Load(object sender, EventArgs e)
        {
            //all_comb.load_items_for_purchase_name1(combo_name_items);
            //all_comb.load_items_code(combo_code_items);
            combo_name_items.Text = "";
            combo_code_items.Text = "";
        }

        private void Dgvc_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
            Classes.command.LoadSerial(dgvc, "no3");

        }

        private void dgvc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           // MessageBox.Show(e.ColumnIndex+"");
            if (e.ColumnIndex == 8)
            {
                if (db.GetData("select isnull(max(purchase_hd_id),0) from purchase_dt where purchase_hd_id='" + dgvc.CurrentRow.Cells["doc_id"].Value + "" + "'").Rows[0][0] + "" != "0")
                {
                    frm_purchase f = new frm_purchase();
                    f.Show();
                    f.txt_serial_string.Text = dgvc.CurrentRow.Cells["doc_id"].Value + "";
                    f.txt_serial_string.Select();
                    f.txt_barcode.Select();
                }
                else if (db.GetData("select isnull(max(sale_hd_id),0) from sale_dt where sale_hd_id='" + dgvc.CurrentRow.Cells["doc_id"].Value + "" + "'").Rows[0][0] + "" != "0")
                {
                    frm_sale f = new frm_sale();
                    f.Show();
                    f.txt_serial_string.Text = dgvc.CurrentRow.Cells["doc_id"].Value + "";
                    f.txt_serial_string.Select();
                    f.txt_barcode.Select();
                }
                else if (db.GetData("select isnull(max(rsale_hd_id),0) from rsale_dt where rsale_hd_id='" + dgvc.CurrentRow.Cells["doc_id"].Value + "" + "'").Rows[0][0] + "" != "0")
                {
                    sales.frm_rsale f = new sales.frm_rsale();
                    f.Show();
                    f.txt_serial_string.Text = dgvc.CurrentRow.Cells["doc_id"].Value + "";
                    f.txt_serial_string.Select();
                    f.txt_note.Select();
                }

                else if (db.GetData("select isnull(max(rpurchase_hd_id),0) from rpurchase_dt where rpurchase_hd_id='" + dgvc.CurrentRow.Cells["doc_id"].Value + "" + "'").Rows[0][0] + "" != "0")
                {
                    Purchase.frm_rpurchase f = new Purchase.frm_rpurchase();
                    f.Show();
                    f.txt_serial_string.Text = dgvc.CurrentRow.Cells["doc_id"].Value + "";
                    f.txt_serial_string.Select();
                    f.txt_note.Select();
                }
                else if (db.GetData("select isnull(max(issuer_inv_hd_id),0) from issuer_inv_dt where issuer_inv_hd_id='" + dgvc.CurrentRow.Cells["doc_id"].Value + "" + "'").Rows[0][0] + "" != "0")
                {
                    inventory.frm_issuer f = new inventory.frm_issuer();
                    f.Show();
                    f.txt_serial_string.Text = dgvc.CurrentRow.Cells["doc_id"].Value + "";
                    f.txt_serial_string.Select();
                    f.txt_barcode.Select();
                }
                else if (db.GetData("select isnull(max(trans_hd_id),0) from trans_dt where trans_hd_id='" + dgvc.CurrentRow.Cells["doc_id"].Value + "" + "'").Rows[0][0] + "" != "0")
                {
                    inventory.frm_trans_items f = new inventory.frm_trans_items();
                    f.Show();
                    f.txt_serial_string.Text = dgvc.CurrentRow.Cells["doc_id"].Value + "";
                    f.txt_serial_string.Select();
                    f.txt_barcode.Select();
                }
                else if (db.GetData("select isnull(max(pos_inv_no),0) from pos_dt where pos_inv_no='" + dgvc.CurrentRow.Cells["doc_id"].Value + "" + "'").Rows[0][0] + "" != "0")
                {
                    XtraReport xtraReport = XtraReport.FromFile("forms\\receipt_printer_pos.repx", true);
                    xtraReport.Parameters["parameter1"].Value = dgvc.CurrentRow.Cells["doc_id"].Value + "";
                    xtraReport.Parameters["parameter1"].Visible = false;
                    XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);



                }
            }
        }

        private void lbl_code_items_Click(object sender, EventArgs e)
        {
            frm_item f = new frm_item();
            f.Show();
            f.txt_code_items.Text = combo_code_items.Text + "";
            f.txt_code_items.Select();
            f.txt_name_items.Select();
        }

        private void combo_code_items_TextChanged(object sender, EventArgs e)
        {
            try
            {
              //  combo_name_items.Text = db.GetData("select (name_items) from items where code_items='" + combo_code_items.Text + "'").Rows[0][0].ToString();
                lbl_name.Text = db.GetData("select (name_items) from items where code_items='" + combo_code_items.Text + "'").Rows[0][0].ToString();
                // c = "";
                // pos.frm_balance_qty.code = "";
            }
            catch (Exception)
            {
            }
        }

        private void btn_printer_Click(object sender, EventArgs e)
        {
            XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\items_normal_card.repx", true);
            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
            xtraReport.Parameters["parameter1"].Value = date1.Value.ToString("yyyy/MM/dd");
            xtraReport.Parameters["parameter2"].Value = date2.Value.ToString("yyyy/MM/dd");
            xtraReport.Parameters["parameter3"].Value = combo_code_items.Text;
            xtraReport.Parameters["parameter4"].Value =  combo_wars.Text;
            xtraReport.Parameters["parameter5"].Value =compo_unite.Text;

            //xtraReport.Parameters["parameter1"].Visible = false;
            //xtraReport.Parameters["parameter2"].Visible = false;
            //xtraReport.Parameters["parameter3"].Visible = false;
            //xtraReport.Parameters["parameter4"].Visible = false;
            //xtraReport.Parameters["parameter5"].Visible = false;

        }
    }
}