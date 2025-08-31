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
using f1.Classes;
using f1.Properties;
using DevExpress.XtraReports.UI;

namespace f1.pos
{
   
    public partial class frm_barcode : DevExpress.XtraEditors.XtraForm
    {
        public frm_barcode()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
        }
        public static string database = "";
        private void frm_barcode_Load(object sender, EventArgs e)
        {
            all_comb.load_invoice_number_purchase(combo_invoice_no);
            combo_invoice_no.Text = "";
            all_comb.load_items_for_purchase_name1(combo_name_items);
            all_comb.load_items_code(combo_code_items);
            combo_name_items.Text = "";
            combo_code_items.Text = "";

            if (v.purchase_purchase_hd_id != "")
            {
                combo_invoice_no.Text = v.purchase_purchase_hd_id;
            }
        }
        private void Dgv1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            command.LoadSerial(dgv1, "no1");
        }
        private void Dgv_inv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            command.LoadSerial(dgv_inv, "no_inv");
        }
        private void Dgv_2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            command.LoadSerial(dgv_2, "no2");
        }
        private void Btn_search_inv_Click(object sender, EventArgs e)
        {
            all_comb.load_invoice_number_purchase(combo_invoice_no);
            combo_invoice_no.Text = "";
        }
        private void Btn_search_items_Click(object sender, EventArgs e)
        {
            all_comb.load_items_for_purchase_name1(combo_name_items);
            all_comb.load_items_code(combo_code_items);
            combo_name_items.Text = "";
            combo_code_items.Text = "";

        }

        private void Btn_show_inv_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_inv.Rows.Clear();
                DataTable dt = new DataTable();
                db.GetData_DGV("select code_items,name_items,qty,item_price from purchase_dt where purchase_hd_id='" + this.combo_invoice_no.Text + "'", dt);
               // this.dgv_inv.DataSource =dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgv_inv.Rows.Add("",dt.Rows[i][0]+"", dt.Rows[i][1] + "", dt.Rows[i][2] + "", dt.Rows[i][3] + "");
                }
            }
            catch (Exception ex)
            {
            }
        }

      

        private void Btn_show_barcode_items_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dgv_2.Rows.Count; ++i)
                {
                    int num = Convert.ToInt32(dgv_2.Rows[i].Cells[4].Value);
                    for (int ii = 0; ii < num; ++ii)
                    {
                        string str = db.GetData("select isnull(max(barcode),0) from barcode where code_items='" + dgv_2.Rows[i].Cells[1].Value + "'").Rows[0][0].ToString();
                        if (str == "0")
                            str = string.Concat(dgv_2.Rows[i].Cells[1].Value);
                        dgv1.Rows.Add("", dgv_2.Rows[i].Cells[1].Value,str);
                    }
                }
            }
            catch (Exception ex)
            {
                db.log_error(string.Concat((object)ex));
            }
        }

        private void Btn_show_barcode_inv_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_inv.Rows.Count; ++i)
            {
                double num = Convert.ToDouble(dgv_inv.Rows[i].Cells["qty"].Value);
                string str1 = dgv_inv.Rows[i].Cells["code"].Value.ToString();
                string str2 = dgv_inv.Rows[i].Cells["name"].Value.ToString();
                for (int ii = 0; ii < num; ++ii)
                    dgv_2.Rows.Add("0", str1, str2, 0, 1);
            }
            try
            {
                for (int i = 0; i < dgv_2.Rows.Count; ++i)
                {
                    int num = Convert.ToInt32(dgv_2.Rows[i].Cells[4].Value);
                    for (int ii = 0; ii < num; ++ii)
                    {
                        string str = db.GetData("select isnull(max(barcode),0) from barcode where code_items='" + dgv_2.Rows[i].Cells[1].Value + "'").Rows[0][0].ToString();
                        if (str == "0")
                            str = string.Concat(dgv_2.Rows[i].Cells[1].Value);
                        dgv1.Rows.Add("", dgv_2.Rows[i].Cells[1].Value, str);
                    }
                }
            }
            catch (Exception ex)
            {
                db.log_error(string.Concat((object)ex));
            }
        }
        //------------------------------------------------------------------------------------------------
        // if (e.KeyCode == Keys.Enter)
      
        private void Combo_code_items_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combo_name_items.Text = db.GetData("select (name_items) from items where code_items='" + combo_code_items.Text + "'").Rows[0][0].ToString();
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
            }
            catch (Exception)
            {
            }
        }
        private void add_inv()
        {
            if (combo_code_items.Text == "") return;
            string str = db.GetData("select isnull(max(barcode),0) from barcode where code_items='" + combo_code_items.Text + "'").Rows[0][0].ToString();
            if (str == "0")
                str = combo_code_items.Text;
             dgv_2.Rows.Add("", combo_code_items.Text, combo_name_items.Text, str,1);

        }
        private void Btn_code_items_Click(object sender, EventArgs e)
        {
            add_inv();
        }
        private void Combo_code_items_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                add_inv();
            }
        }
        private void Combo_name_items_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                add_inv();
            }
        }
        private int prog1 = 0;
        private string id = "";
        private  void Btn_show_print_Click(object sender, EventArgs e)
        {
            // progressBar1.Visible = true;
            // db.cmd.CommandText=("delete from barcode_temp where id='"+id+"'");
            // await db.cmd.ExecuteNonQueryAsync();

            // id = v.usercode + DateTime.Now.ToString("yyMMddhhmmss");
            // prog1 = dgv1.Rows.Count;
            // //1)insert
            // //________________________

            // for (int i = 0; i < dgv1.Rows.Count; i++)
            // {
            //     db.cmd.CommandText = ("insert into barcode_temp (code,id) values ('"+dgv1.Rows[i].Cells[1].Value+"','"+id+"') ");
            //     await db.cmd.ExecuteNonQueryAsync();
            //     backgroundWorker1.ReportProgress(i);
            // }

            // //2)preview report
            // //______________________
            //// string str = db.GetData("select * from barcode_temp  where id='"+id+"'  ").Rows[0][0].ToString();
            // XtraReport xtraReport = XtraReport.FromFile("forms\\preview_barcode.repx", true);
            // xtraReport.Parameters["parameter1"].Value = id;
            // xtraReport.Parameters["parameter1"].Visible = false;
            // XtraReportPreviewExtensions.ShowPreview(xtraReport);
            // progressBar1.Visible = false;

            progressBar1.Value = 0;
            if (dgv1.Rows.Count == 0)
            {
                return;
            }
            else
            {
                timer1.Enabled = true;
                timer2.Enabled = true;
                //timer1.Start();
                //timer2.Start();
                // btn_show_print.Enabled = false;

            }

        }

       
        private void Btn_del_Click(object sender, EventArgs e)
        {
            combo_code_items.Text = "";
            combo_name_items.Text = "";
            dgv1.Rows.Clear();
            dgv_2.Rows.Clear();

        }

        private void Frm_barcode_FormClosing(object sender, FormClosingEventArgs e)
        {
            db.Run("delete from barcode_temp where id='" + id + "'");
            v.purchase_purchase_hd_id = "";
        }

      
        public int count = 0;
        private void Btn_direct_print_Click(object sender, EventArgs e)
        {

            if (dgv1.Rows.Count < 0)
                return;
            for (int i = 0; i < dgv1.Rows.Count; ++i)
            {
                
                    XtraReport xtraReport = XtraReport.FromFile("forms\\barcode_code.repx", true);
                    xtraReport.Parameters["parameter1"].Value = dgv1.Rows[i].Cells[1].Value;
                    xtraReport.Parameters["parameter1"].Visible = false;
                    xtraReport.PrinterName = Settings.Default.printer_name_barcode;
                    xtraReport.RollPaper = true;
                    xtraReport.PrintAsync();
                
            }
           
        }
        public int row = 0;
        private void print_barcode(string code)
        {

            XtraReport xtraReport = XtraReport.FromFile("forms\\barcode_code.repx", true);
            ////    xtraReport.Parameters["parameter1"].Value = dgv1.Rows[i].Cells[1].Value;
            xtraReport.Parameters["parameter1"].Value = code;

            xtraReport.Parameters["parameter1"].Visible = false;
            xtraReport.PrinterName = Settings.Default.printer_name_barcode;
            xtraReport.RollPaper = true;
            xtraReport.PrintAsync();



            // MessageBox.Show("Test  "+ code);




        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dgv1.Rows.Count == 0)
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                //timer1.Stop();
                //timer2.Stop();
                // btn_show_print.Enabled = false;
                progressBar1.Value = 0;
                return;

            }
            else
            {
                timer1.Start();
                progressBar1.Increment(1);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            // simpleButton1.PerformClick();
            if (dgv1.Rows.Count < row)
            {
                row = 0;
                return;
            }
            else
            {
                if (dgv1.Rows.Count <= row)
                {

                    return;
                }

                if (progressBar1.Value == 100)
                {
                    progressBar1.Value = 0;
                    timer1.Enabled = false;
                    print_barcode(dgv1.Rows[row].Cells[1].Value + "");
                    timer1.Enabled = true;
                    row = row + 1;

                }


            }

        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            pos.frm_barcode f = new frm_barcode();
            Close();
            f.Show();
        }
    }
}