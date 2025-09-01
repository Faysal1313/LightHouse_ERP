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

namespace f1.account.report_account.report_screen
{
    public partial class sc_statment_gl : DevExpress.XtraEditors.XtraForm
    {
        public sc_statment_gl()
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
            date1.Text = DateTime.Now.ToString("yyyy/01/01");
            date2.Text = DateTime.Now.ToString("yyyy/MM/dd");

            combo.Text = "";
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void btn_printer_Click(object sender, EventArgs e)
        {

            XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\stat_gl.repx", true);
            //xtraReport.Parameters["parameter2"].Value = txt_serial_string.Text;
            // xtraReport.Parameters["parameter1"].Value = date1.Value;
            //3/23/2023
            xtraReport.Parameters["parameter1"].Value = date1.Value.ToString("yyyy/MM/dd");
            xtraReport.Parameters["parameter2"].Value = date2.Value.ToString("yyyy/MM/dd");
            xtraReport.Parameters["parameter3"].Value = lbl_code.Text;
            xtraReport.Parameters["parameter1"].Visible = false;
            xtraReport.Parameters["parameter2"].Visible = false;
            xtraReport.Parameters["parameter3"].Visible = false;
            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);

            //XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\stat_gl.repx", true);
            //xtraReport.Parameters["parameter1"].Value = date1.Value.ToString("yyyy/MM/dd");
            //xtraReport.Parameters["parameter1"].Visible = false;
            ////xtraReport.Parameters["parameter2"].Value = dt_piker2.Value.ToString("yyyy/12/31");
            ////xtraReport.Parameters["parameter2"].Visible = false;
            //xtraReport.Parameters["parameter2"].Value = lbl_code.Text;
            //xtraReport.Parameters["parameter2"].Visible = false;
            //XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
        }

        private void rdcustomer_CheckedChanged(object sender, EventArgs e)
        {
            combo.DataSource = null;
            combo.Items.Clear();

            if (rdcustomer.Checked == true)
            {
                f1.all_comb.load_customer_only_name(combo);
            }
        }

        private void rdvendor_CheckedChanged(object sender, EventArgs e)
        {
            combo.DataSource = null;
            combo.Items.Clear();

            if (rdvendor.Checked == true)
            {
                f1.all_comb.load_vendor_only_name(combo);
            }
        }

        private void rd_account_CheckedChanged(object sender, EventArgs e)
        {
            combo.DataSource = null;
            combo.Items.Clear();

            if (rd_account.Checked == true)
            {
                f1.all_comb.load_account_name_c(combo);
            }
        }

        private void combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdcustomer.Checked || rdvendor.Checked)
                {
                    lbl_code.Text = db.GetData("select vcs_code from vcs where vcs_name='" + combo.Text + "'").Rows[0][0].ToString();

                }
                else
                {
                    lbl_code.Text = db.GetData("select rootid from tree where rootname='" + combo.Text + "'").Rows[0][0].ToString();

                }
            }
            catch (Exception)
            {
            }
        }

        private void btn_get_Data_Click(object sender, EventArgs e)
        {
            dgv.Rows.Clear();
            string query = "select code_entry,attachno as ref,txt_desc,(select top 1 acc_num from entry where code_entry=e.code_entry and acc_num<> '"+lbl_code.Text+"') as code,(select top 1 acc_name from entry where code_entry=e.code_entry and acc_num<> '"+lbl_code.Text+"') as name ,opening_bal ,depit,credit, depit-credit as def,dates from entry e where code_entry<>'-11' and acc_num='"+lbl_code.Text+"' and dates between '"+ date1.Value.ToString("yyyy/MM/dd") + "' and '" + date2.Value.ToString("yyyy/MM/dd") + "' and  code_entry<>'002' and code_entry<>'001'";
            DataTable dt = new DataTable();
            db.GetData_DGV(query, dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv.Rows.Add("",dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3], dt.Rows[i][4], dt.Rows[i][5], dt.Rows[i][6], dt.Rows[i][7], dt.Rows[i][8], 0, Convert.ToDateTime(dt.Rows[i][9]).ToString("yyyy/MM/dd"));
            }
            double bal = 0;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                bal = bal + Convert.ToDouble(dgv.Rows[i].Cells[9].Value);
                dgv.Rows[i].Cells[10].Value = bal;
            }

        }

        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv,"no");

        }

        private void dgv_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            Classes.command.LoadSerial(dgv, "no");


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            double bal = 0;//Convert.ToDouble(dgv.Rows[0].Cells[9].Value);
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                bal = bal + Convert.ToDouble(dgv.Rows[i].Cells[9].Value);
                dgv.Rows[i].Cells[11].Value = bal;

            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1)
                {
                    frm_entry f = new frm_entry();
                    f.Show();
                    f.txt_serial_string.Text = dgv.CurrentRow.Cells[1].Value + "";
                    f.txt_serial_string.Select();
                    f.txt_note.Select();
                  
                 


                    // dgv.Rows.RemoveAt(e.RowIndex);
                }
                if (e.ColumnIndex == 2)
                {
                    if (db.GetData("select isnull(max(purchase_hd_id),0) from purchase_dt where purchase_hd_id='" + dgv.CurrentRow.Cells[2].Value + "" + "'").Rows[0][0] + "" != "0")
                    {
                        frm_purchase f = new frm_purchase();
                        f.Show();
                        f.txt_serial_string.Text = dgv.CurrentRow.Cells[2].Value + "";
                        f.txt_serial_string.Select();
                        f.txt_barcode.Select();
                    }
                    else if (db.GetData("select isnull(max(code_entry),0) from pay_dt where code_entry='" + dgv.CurrentRow.Cells[2].Value + "" + "'").Rows[0][0] + "" != "0")
                    {
                        frm_payable f = new frm_payable();
                        f.Show();
                        f.txt_serial_string.Text = dgv.CurrentRow.Cells[2].Value + "";
                        f.txt_serial_string.Select();
                        f.txt_note.Select();

                    }
                    else if (db.GetData("select isnull(max(code_entry),0) from recev_dt where code_entry='" + dgv.CurrentRow.Cells[2].Value + "" + "'").Rows[0][0] + "" != "0")
                    {
                        frm_recevable f = new frm_recevable();
                        f.Show();
                        f.txt_serial_string.Text = dgv.CurrentRow.Cells[2].Value + "";
                        f.txt_serial_string.Select();
                        f.txt_note.Select();


                    }
                    else if (db.GetData("select isnull(max(sale_hd_id),0) from sale_dt where sale_hd_id='" + dgv.CurrentRow.Cells[2].Value + "" + "'").Rows[0][0] + "" != "0")
                    {
                        frm_sale f = new frm_sale();
                        f.Show();
                        f.txt_serial_string.Text = dgv.CurrentRow.Cells[2].Value + "";
                        f.txt_serial_string.Select();
                        f.txt_barcode.Select();
                    }
                    else if (db.GetData("select isnull(max(rsale_hd_id),0) from rsale_dt where rsale_hd_id='" + dgv.CurrentRow.Cells[2].Value + "" + "'").Rows[0][0] + "" != "0")
                    {
                        sales.frm_rsale f = new sales.frm_rsale();
                        f.Show();
                        f.txt_serial_string.Text = dgv.CurrentRow.Cells[2].Value + "";
                        f.txt_serial_string.Select();
                        f.txt_note.Select();
                    }
                    else if (db.GetData("select isnull(max(rpurchase_hd_id),0) from rpurchase_dt where rpurchase_hd_id='" + dgv.CurrentRow.Cells[2].Value + "" + "'").Rows[0][0] + "" != "0")
                    {
                        Purchase.frm_rpurchase f = new Purchase.frm_rpurchase();
                        f.Show();
                        f.txt_serial_string.Text = dgv.CurrentRow.Cells[2].Value + "";
                        f.txt_serial_string.Select();
                        f.txt_note.Select();
                    }
                    else if (db.GetData("select isnull(max(id),0) from jn_jopnumber where id='" + dgv.CurrentRow.Cells[2].Value + "" + "'").Rows[0][0] + "" != "0")
                    {
                        ship_jop.frm_jop_number f = new ship_jop.frm_jop_number();
                        f.Show();
                        f.txt_serial_string.Text = dgv.CurrentRow.Cells[2].Value + "";
                        f.txt_serial_string.Select();
                        f.txt_trip_counter_befor.Select();
                    }
                    else if (db.GetData("select isnull(max(pos_inv_no),0) from pos_dt where pos_inv_no='" + dgv.CurrentRow.Cells[2].Value + "" + "'").Rows[0][0] + "" != "0")
                    {
                        XtraReport xtraReport = XtraReport.FromFile("forms\\receipt_printer_pos.repx", true);
                        xtraReport.Parameters["parameter1"].Value = dgv.CurrentRow.Cells[2].Value + "";
                        xtraReport.Parameters["parameter1"].Visible = false;
                        XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);



                    }
                }

            }
            catch (Exception)
            {

               
            }
        }
    }
}