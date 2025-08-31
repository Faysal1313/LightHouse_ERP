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

namespace f1.account
{
    public partial class frm_costcenter : DevExpress.XtraEditors.XtraForm
    {
        public frm_costcenter()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(v.ico);

        }
        private void delete()
        {
            db.Run("delete from costcenter where costcenter_id='" + txt_costcenter_id.Text + "'");
        }
        private void insert()
        {
            db.Run("INSERT INTO [costcenter] ([costcenter_id]  ,[costcenter_name])values('" + txt_costcenter_id.Text + "','" + txt_costcenter_name.Text + "')");

        }
        private void edit()
        {
            db.Run("update   costcenter set costcenter_name ='"+ txt_costcenter_name.Text + "' where costcenter_id='"+txt_costcenter_id.Text+"'");
            MessageBox.Show("تم تعديل الاسم ");
        }


        private void save_barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void delete_barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btn_save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txt_costcenter_id.Text=="")
            {
                MessageBox.Show("لا يوجد كود لمركز التكلفة ");
                return;

            }
            if (txt_costcenter_name.Text == "")
            {
                MessageBox.Show("لا يوجد اسم  لمركز التكلفة ");
                return;

            }
            String id=  db.GetData("select isnull (max(costcenter_id),0) from costcenter where costcenter_id='"+txt_costcenter_id.Text+"'").Rows[0][0].ToString();
          String name = db.GetData("select isnull (max(costcenter_name),0) from costcenter where costcenter_id='" + txt_costcenter_id.Text + "'").Rows[0][0].ToString();
            if (id != "0")
            {
                MessageBox.Show("موجود من قبل");
                return;
            }
          else if (name != "0")
            {
                MessageBox.Show("موجود من قبل");
                return;
            }
            else
            {
                insert();
                MessageBox.Show("تم الحفظ");
            }
        }

        private void btn_search_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            group_search.Visible = true;
            dgv_search.Rows.Clear();
            DataTable dt = new DataTable();
            db.GetData_DGV("select costcenter_id,costcenter_name from costcenter", dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv_search.Rows.Add("", dt.Rows[i][0] + "", dt.Rows[i][1] + "");
            }

            all_comb.cost_center_id(combo1);
            all_comb.cost_center_name(combo2);
            combo1.Text = "";
            combo2.Text = "";
        }

        private void btn_close_group_search_Click(object sender, EventArgs e)
        {
            group_search.Visible = false;

        }

        private void btn_new_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            account.frm_costcenter f = new frm_costcenter();
            Close();
            ((Control)f).Show();
        }

        private void btn_del_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dr;
            dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "هل ترد الحذف!!؟؟؟؟ ", "رسال حذف ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);


            if (dr == DialogResult.OK)
            {
                delete();
              
                account.frm_costcenter f = new frm_costcenter();

                Close();
                ((Control)f).Show();
            }
        }

        private void dgv_search_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                
                txt_costcenter_id.Text = dgv_search.CurrentRow.Cells[1].Value + "";
                txt_costcenter_name.Text = dgv_search.CurrentRow.Cells[2].Value + "";
                group_find.Visible = false;

            }
            catch (Exception)
            {
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (txt_costcenter_id.Text == "")
            {
                MessageBox.Show("لا يوجد كود لمركز التكلفة ");
                return;
            }
            if (txt_costcenter_name.Text == "")
            {
                MessageBox.Show("لا يوجد اسم  لمركز التكلفة ");
                return;

            }
            String name = db.GetData("select isnull (max(costcenter_name),0) from costcenter where costcenter_id='" + txt_costcenter_id.Text + "'").Rows[0][0].ToString();
           // MessageBox.Show(name);

            if (name != txt_costcenter_name.Text)
            {
                MessageBox.Show("موجود من قبل");
                return;
            }
            edit();
        }
    }
}