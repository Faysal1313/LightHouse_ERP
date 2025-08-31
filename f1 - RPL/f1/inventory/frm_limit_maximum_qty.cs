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

namespace f1.inventory
{
    public partial class frm_limit_maximum_qty : DevExpress.XtraEditors.XtraForm
    {
        public frm_limit_maximum_qty()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
        }
        private void frm_limit_maximum_qty_Load(object sender, EventArgs e)
        {

            all_comb.load_wares(combo_wars);
            all_comb.load_name_items(combo_items_name);
            all_comb.load_code_items(combo_code);
            combo_items_name.Text = "";
            combo_code.Text = "";
            load();

        }
        private void load()
        {

            DataTable dt = new DataTable();
            db.GetData_DGV("select code_items,name_items,qty,demand_limit,id_ware from wares where demand_limit_bit='True' and id_ware='" + combo_wars.Text + "'  ", dt);
            //dgv.DataSource = dt;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv.Rows.Add("", dt.Rows[i][0] + "", dt.Rows[i][1] + "", dt.Rows[i][2] + "", dt.Rows[i][3] + "", dt.Rows[i][4] + "");

            }
        }
        private void add_items()
        {

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (combo_code.Text == dgv.Rows[i].Cells["code_items"].Value.ToString())
                {
                    MessageBox.Show("douple");
                    return;
                }
            }
            dgv.Rows.Add("",combo_code.Text,combo_items_name.Text,db.GetData("select max(qty) from wares where id_ware='"+combo_wars.Text+"' and code_items='"+combo_code.Text+"'").Rows[0][0].ToString(),"",combo_wars.Text);
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            add_items();
        }
        private void btn_save_limit_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count == 0)
            {
                return;
            }
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                string dd = dgv.Rows[i].Cells["demand_limit"].Value+"";

                if (dd == "")
                {
                    MessageBox.Show(dd);
                    dd = "0";

                }
               
                db.Run("update wares set demand_limit ='" + Convert.ToDecimal(dd) + "', demand_limit_bit='True' where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'");
            }
            MessageBox.Show("update");
        }

        private void btn_refersh_Click(object sender, EventArgs e)
        {
            //load demand_limit
           
        }

        private void btn_delete_limit_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "هل تريد الحذف!!؟؟؟؟ ", "رسال حذف مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (dr == DialogResult.OK)
            {
                if (dgv.Rows.Count == 0)
                {
                    return;
                }
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    db.Run("update wares set demand_limit='0' , demand_limit_bit='false' where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' ");
                }
               
            }
            dgv.Rows.Clear();
            load();
        }
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                DialogResult dr;
                dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "هل تريد الحذف تريد الحذف!!؟؟؟؟ ", "رسال حذف مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (dr == DialogResult.OK)
                {
                    // MessageBox.Show(e.ColumnIndex + "");

                    dgv.Rows.RemoveAt(e.RowIndex);
                    db.Run("update wares set demand_limit='0' , demand_limit_bit='false' where code_items='" + dgv.CurrentRow.Cells["code_items"].Value + "' ");

                }
            }
        }
        private void combo_add_items_Enter(object sender, EventArgs e)
        {
            add_items();
        }

        private void combo_code_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combo_items_name.Text = db.GetData("select name_items from items where code_items='" + combo_code.Text + "' ").Rows[0][0].ToString();

            }
            catch (Exception)
            {


            }
        }

        private void combo_items_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               combo_code.Text = db.GetData("select code_items from items where name_items='" + combo_items_name.Text + "' ").Rows[0][0].ToString();
               // combo_items_name.Text = db.GetData("select name_items from items where code_items='" + combo_code.Text + "' ").Rows[0][0].ToString();

            }
            catch (Exception)
            {


            }
        }

        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv, "no");
        }

        private void dgv_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            Classes.command.LoadSerial(dgv, "no");

        }

        private void combo_code_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                add_items();

            }
        }

        private void combo_items_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                add_items();

            }
        }

       
    }
}