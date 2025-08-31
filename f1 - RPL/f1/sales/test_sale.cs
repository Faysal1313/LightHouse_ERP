using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace f1.sales
{
    public partial class test_sale : DevExpress.XtraEditors.XtraForm
    {
        public test_sale()
        {
            InitializeComponent();
            db.Open();
        }
        private void get_data_test(string str, DataGridView dgv, DataTable dt)
        {
            db.GetData_DGV(str, dt);
            dgv.DataSource = dt;
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
                    get_data_test("select * from sale_hd where sale_hd_id = '" + txt_serial.Text + "'", dgv_hd, dt_hd);
                    get_data_test("select * from sale_dt where sale_hd_id = '" + txt_serial.Text + "'", dgv_dt, dt_dt);
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
        private void test_sale_Load(object sender, EventArgs e)
        {
            txt_serial.Text = v.test_sale;
            DataTable dt_hd = new DataTable();
            DataTable dt_dt = new DataTable();
            DataTable dt_ware = new DataTable();
            DataTable dt_exp = new DataTable();
            DataTable dt_entry = new DataTable();
            get_data_test("select * from sale_hd where sale_hd_id = '" + txt_serial.Text + "'", dgv_hd, dt_hd);
            get_data_test("select * from sale_dt where sale_hd_id = '" + txt_serial.Text + "'", dgv_dt, dt_dt);
            get_data_test("select * from wares where qty > 0", dgv_ware, dt_ware);

            get_data_test("select * from exp_date where code = '" + txt_serial.Text + "'", dgv_exp, dt_exp);
            get_data_test("select * from entry where attachno='" + txt_serial.Text + "'", dgv_entry, dt_entry);

        }
    }
}