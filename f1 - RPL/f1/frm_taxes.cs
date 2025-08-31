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
    public partial class frm_taxes : DevExpress.XtraEditors.XtraForm
    {
        public frm_taxes()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
        }

        private void frm_taxes_Load(object sender, EventArgs e)
        {
            load_taxe(comboBox1);
            comboBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            txt_subType.Text = "";
            txt_taxType.Text = "";
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            db.Run("insert into taxes (no,taxes_name,taxes,taxType,subType) values('" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','"+txt_taxType.Text+"','"+lbl_subType.Text+"')");
            MessageBox.Show("save");

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            db.Run("delete from taxes where no ='" + comboBox1.Text + "'");
            MessageBox.Show("delete");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = "";
                textBox3.Text = "";
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox2.Text = db.GetData("select taxes_name  from taxes where no ='" + comboBox1.Text + "'").Rows[0][0].ToString();
                textBox3.Text = db.GetData("select taxes from taxes where no ='" + comboBox1.Text + "'").Rows[0][0].ToString();
                txt_taxType.Text= db.GetData("select taxType from taxes where no ='" + comboBox1.Text + "'").Rows[0][0].ToString();
                txt_subType.Text= db.GetData("select subType from taxes where no ='" + comboBox1.Text + "'").Rows[0][0].ToString();
            }
            catch (Exception)
            {
            }
        }

        public void load_taxe(System.Windows.Forms.ComboBox combo)
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("select distinct no from taxes", dt);
            combo.DisplayMember = "no";
            combo.DataSource = dt;

        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            textBox2.Text ="";
            textBox3.Text ="";
            txt_subType.Text = "";
            txt_taxType.Text = "";

            comboBox1.Text ="";
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;


        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

    }
}