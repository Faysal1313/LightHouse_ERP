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
    public partial class frm_wares : DevExpress.XtraEditors.XtraForm
    {
        public frm_wares()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
            db.Open();
        }
        private void frm_wares_Load(object sender, EventArgs e)
        {
           all_comb.load_account_name_c(comb_acc_name);
            get_sub_gl();
            comb_acc_name.Text = "";
            txt_acc.Text = "";
            btn_Edit_acc.Visible = false;
            all_comb.load_wares(combo_copy);
            combo_copy.Text = "";
            combo_txt_code_wars.Select();
        }
        //fancation===========================================
        public void insert()
        {
            //cheack for items 
            // if found items >>> get item and insert into wares 
            DataTable dt = new DataTable();
            db.GetData_DGV("SELECT  code_items, name_items FROM items ", dt);
            if (dt.Rows.Count > 1)
            {
                // dgv_acc.DataSource = dt;
                //if found item in wares not add item twice 
                if (db.GetData("select isnull(max(id_ware),0) from wares where id_ware='"+combo_txt_code_wars.Text+"' ").Rows[0][0] + "" == "0")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        db.Run("insert wares( id_ware, code_items, name_items, qty, cost, tot,demand_limit,demand_maximum,demand_limit_bit,demand_maximum_bit) values (" + combo_txt_code_wars.Text + ",'" + dt.Rows[i][0].ToString() + "','" + dt.Rows[i][1].ToString() + "',0,0,0,0,0,'False','False')");
                    }
                }
            }
            else //if not found items insert zero value
            {
                db.Run("insert wares( id_ware, code_items, name_items, qty, cost, tot,demand_limit,demand_maximum,demand_limit_bit,demand_maximum_bit) values (" + combo_txt_code_wars.Text + ",'0','0',0,0,0,0,0,'False','False')");
            }
            //insert acc wares
            db.Run("delete from wares_acc where id_ware='" + combo_txt_code_wars.Text + "'");
            for (int i = 0; i < dgv2.Rows.Count; i++)
            {
                db.Run("insert into wares_acc (id_ware,acc_id, acc_name,rootid, rootname) values ('" + combo_txt_code_wars.Text + "','" + dgv2.Rows[i].Cells["acc__id"].Value.ToString() + "','" + dgv2.Rows[i].Cells["acc__name"].Value.ToString() + "','" + dgv2.Rows[i].Cells["rootid"].Value.ToString() + "','" + dgv2.Rows[i].Cells["rootname"].Value.ToString() + "')");
            }
            db.Run("delete from wares_acc where  acc_name IS  NULL and id_ware <> -9");
        }
        private void get_sub_gl()
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("select acc_id ,acc_name,rootname,rootid from wares_acc where  acc_id IS not NULL and id_ware=-9", dt);
            dgv_acc.DataSource = dt;
        }
        private void load_wares()
        {
            try
            {
                DataTable dt = new DataTable();
                db.GetData_DGV("select distinct  id_ware  from wares_acc where id_ware >0 ", dt);
                combo_txt_code_wars.DisplayMember = "id_ware";
                combo_txt_code_wars.DataSource = dt;
            }
            catch (Exception)
            {
            }
        }
        //controls================================================
        private void comb_acc_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_acc.Text = db.GetData("select RootID from tree where RootName='" + comb_acc_name.Text + "'").Rows[0][0].ToString();
        }
        private void add_items_in_dgv()
        {
            //if (edit == false)
            //{
            //    dgv2.Rows.Add(txt_num.Text, txt_acc_name.Text, comb_acc_name.Text, txt_acc.Text);
            //}
            //else
            //{
            for (int i = 0; i < dgv2.Rows.Count; i++)
            {
                if (txt_num.Text == dgv2.Rows[i].Cells["acc__id"].Value.ToString())
                {
                    MessageBox.Show("douple");
                    return;
                }
            }
                DataTable dataTable = (DataTable)dgv2.DataSource;
                DataRow drToAdd = dataTable.NewRow();
                drToAdd["acc_id"] = txt_num.Text;
                drToAdd["acc_name"] = txt_acc_name.Text;
                drToAdd["rootid"] = txt_acc.Text;
                drToAdd["rootname"] = comb_acc_name.Text;
                dataTable.Rows.Add(drToAdd);
                dataTable.AcceptChanges();
           // }
        }
        private void dgv_acc_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_acc.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgv_acc.CurrentRow.Selected = true;
                    txt_num.Text = dgv_acc.Rows[e.RowIndex].Cells["acc_id"].FormattedValue.ToString();
                    txt_acc_name.Text = dgv_acc.Rows[e.RowIndex].Cells["acc_name"].FormattedValue.ToString();
                }
            }
            catch (Exception)
            {
            }
        }
        private void dgv2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btn_Edit_acc.Visible = true;
                if (dgv2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgv2.CurrentRow.Selected = true;
                    comb_acc_name.Text = dgv2.Rows[e.RowIndex].Cells["rootname"].FormattedValue.ToString();
                    txt_acc.Text = dgv2.Rows[e.RowIndex].Cells["rootid"].FormattedValue.ToString();
                }
            }
            catch (Exception)
            {
            }
        }
        private void btn_copy_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
       
            db.GetData_DGV("select acc_id ,acc_name,rootname,rootid from wares_acc where id_ware ='" + combo_copy.Text + "'", dt);
       
                dgv2.DataSource = dt;
       
        }
        private void combo_txt_code_wars_Leave(object sender, EventArgs e)
        {
            string str = db.GetData("select distinct isnull((min(id_ware)),0) from wares where id_ware ='" + combo_txt_code_wars.Text + "' ").Rows[0][0].ToString();
            if (str != "0")
            {
                load_wares();
                return;
            }
        }
        private void barButton_Save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable dt_wares = db.GetData("select id_ware from wares where id_ware='" + combo_txt_code_wars.Text + "'");
            DataTable dt_wares_GL = db.GetData("select id_ware from wares_acc where id_ware='" + combo_txt_code_wars.Text + "'");
            if (combo_txt_code_wars.Text == "")
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "دخل كود المخزن ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
          
        
            else
            {
                insert();
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "saving ", "save", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        private void barButtonI_new_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_wares f = new frm_wares();
            Close();
            f.Show();
        }
        private void barButtonItem7_delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          string old_data=  db.GetData("select isnull(SUM(qty),0) from wares where id_ware='10'").Rows[0][0].ToString();
          if (Convert.ToDouble(old_data) != 0)
          {
              XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "هناك كميه موجوده بالمخزن لايمكن حذف المخزن  ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
              return;
          }

            DialogResult dr;
            dr = MessageBox.Show("هل تريد الحذف!!؟؟؟؟ ", "رسال حذف مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                db.Run("delete from wares_acc where id_ware='" + combo_txt_code_wars.Text + "'");
                db.Run("delete from wares where id_ware='" + combo_txt_code_wars.Text + "'");
                frm_wares f = new frm_wares();
                Close();
                f.Show();
            }
            else
            {
            }
        }
        private void barButton_searsh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          //  edit = true;
            load_wares();
        }
       
        private void combo_txt_code_wars_Leave_1(object sender, EventArgs e)
        {
            txt_num.Text = "";
            txt_acc.Text = "";
            txt_acc_name.Text = "";
            txt_acc.Text = "";
            DataTable dt = new DataTable();

            get_sub_gl();
            db.GetData_DGV("select rootid ,rootname,acc_id,acc_name from wares_acc where id_ware='" + combo_txt_code_wars.Text + "'", dt);
            dgv2.DataSource = dt;
        }
        private void btn_add_account_Click(object sender, EventArgs e)
        {
            if (comb_acc_name.Text == "" || combo_txt_code_wars.Text == "" || txt_acc.Text == "" || txt_num.Text == "")
            {
                MessageBox.Show("اختار حساب اولا");
                return;
            }
            else
            {
                string x = "";
                try
                {
                    x = db.GetData("select acc_id from wares_acc where id_ware='" + combo_txt_code_wars.Text + "' and acc_id='" + txt_num.Text + "'").Rows[0][0].ToString();
                }
                catch (Exception)
                {
                    x = "";
                }
                if (x != "")
                {
                    MessageBox.Show("موجود من قبل");
                    return;
                }
                else
                {
                    add_items_in_dgv();
                }
            }
        }
        private void btn_Edit_acc_Click(object sender, EventArgs e)
        {
            if (comb_acc_name.Text == "" || txt_acc.Text == "" || combo_txt_code_wars.Text == "")
            {
                MessageBox.Show("اختار رقم ");
            }
            else
            {
                dgv2.CurrentRow.Cells["rootname"].Value = comb_acc_name.Text;
                dgv2.CurrentRow.Cells["rootid"].Value = txt_acc.Text;
            }
        }
        private void btn_add_fixed_acc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_sub_ledger_wares f = new frm_sub_ledger_wares();
            f.Show();
        }
        //hotkeys================================================



        //=========
    }
}