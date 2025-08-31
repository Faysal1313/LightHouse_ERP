using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace f1
{
    public partial class frm_test_report_purchase : DevExpress.XtraEditors.XtraForm
    {
        public frm_test_report_purchase()
        {
            InitializeComponent();
            db.Open();
        }

        private void frm_test_report_purchase_Load(object sender, EventArgs e)
        {
            txt_serial.Text = v.test_pur;
            DataTable dt_hd = new DataTable();
            DataTable dt_dt = new DataTable();
            DataTable dt_ware = new DataTable();
            DataTable dt_exp = new DataTable();
            DataTable dt_entry = new DataTable();
            get_data_test("select * from purchase_hd where purchase_hd_id = '" + txt_serial.Text + "'", dgv_hd, dt_hd);
            get_data_test("select * from purchase_dt where purchase_hd_id = '" + txt_serial.Text + "'", dgv_dt, dt_dt);
            get_data_test("select * from wares where qty > 0", dgv_ware, dt_ware);
            get_data_test("select * from exp_date where code = '" + txt_serial.Text + "'", dgv_exp, dt_exp);
            get_data_test("select * from entry where attachno='" + txt_serial.Text + "'", dgv_entry, dt_entry);

            
        }




        private void get_data_test(string str,DataGridView dgv, DataTable dt)
        {
            db.GetData_DGV(str, dt);
            dgv.DataSource = dt;
        
        }

        private void labelControl4_Click(object sender, EventArgs e)
        {
            DataTable dt_entry = new DataTable();
            get_data_test("select * from entry where attachbook='" + txt_serial.Text + "'", dgv_entry, dt_entry);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                  if (txt_serial.Text != "")
            {
                 DataTable dt_hd = new DataTable();
            DataTable dt_dt = new DataTable();
            DataTable dt_ware = new DataTable();
            DataTable dt_exp = new DataTable();
            DataTable dt_entry = new DataTable();
            get_data_test("select * from purchase_hd where purchase_hd_id = '" + txt_serial.Text + "'", dgv_hd, dt_hd);
            get_data_test("select * from purchase_dt where purchase_hd_id = '" + txt_serial.Text + "'", dgv_dt, dt_dt);
            get_data_test("select * from wares where qty > 0", dgv_ware, dt_ware);

            get_data_test("select * from exp_date where code = '" + txt_serial.Text + "'", dgv_exp, dt_exp);
            get_data_test("select * from entry where attachno='" + txt_serial.Text + "'", dgv_entry, dt_entry);

            }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}