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

namespace f1.ship_jop
{
    public partial class frm_storehouse : DevExpress.XtraEditors.XtraForm
    {
        public frm_storehouse()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(v.ico);

        }
        private void frm_storehouse_Load(object sender, EventArgs e)
        {
            all_comb.load_account_sc(combo_vcs_gl);
            all_comb.load_account_sc(this.combo_vcs_gl);
            combo_vcs_gl.Text = Properties.Settings.Default.clint_acc;
            txt_code_vcs.Text = genrat_code();
        }
        private static string genrat_code()
        {
            string str = db.GetData("select max(id)+1 from jn_storehouse where mode='customer'").Rows[0][0].ToString();
            if (str == "")
                str = "700001";
            return str;
        }
        private void save()
        {
            txt_code_vcs.Text = genrat_code();
            db.Run("insert into jn_storehouse (id, name, mode, rootlevel, rootlevel_name, type_acc, sort,  address) values ('" + txt_code_vcs.Text + "','" + txt_name_vcs.Text + "','customer','" + lbl_rootlevel.Text + "','" + lbl_rootlevel_name.Text + "','customer','" + lbl_sort.Text + "','" + txt_addreess.Text + "')");
            MessageBox.Show("save");
        }
        private void delete()
        {
            db.Run("delete from jn_storehouse where id='" + txt_code_vcs.Text + "'");

        }
        private bool edit = false;
        private void clear()
        {
            txt_code_vcs.Text = "";
            txt_name_vcs.Text = "";
            txt_addreess.Text = "";
            edit = false;
        }
        private void perform_Save()
        {
            if (edit == false)
            {

                if (db.GetData("select isnull(max(id),0) from jn_storehouse where id ='" + txt_code_vcs.Text + "' ").Rows[0][0].ToString() != "0")
                {
                    int num1 = (int)MessageBox.Show("الكود موجود من قبل   ");
                    return;
                }
                else
                {
                    try
                    {
                        string str1 = db.GetData("select isnull(max(name),0) from jn_storehouse where name='" + txt_name_vcs.Text + "'").Rows[0][0].ToString();
                        if (str1.Length > 0 && str1 == txt_name_vcs.Text)
                        {
                            MessageBox.Show("اسم  مكرر");
                            return;
                        }

                    }
                    catch (Exception ex)
                    {
                    }
                    if (txt_code_vcs.Text == "" || txt_name_vcs.Text == "" || (lbl_rootlevel.Text == "" || lbl_rootlevel_name.Text == "") || lbl_type_acc.Text == "" || lbl_sort.Text == "")
                    {
                        int num2 = (int)MessageBox.Show("في حساب ناقص");
                        return;
                    }
                }
                //===========================================================


                save();
            }
            else
            {
                try
                {
                    string str1 = db.GetData("select isnull(max(name),0) from jn_storehouse where name='" + txt_name_vcs.Text + "'").Rows[0][0].ToString();
                    if (str1.Length > 0 && str1 == txt_name_vcs.Text)
                    {
                        MessageBox.Show("اسم  مكرر");
                        return;
                    }

                }
                catch (Exception ex)
                {
                }
                if (txt_code_vcs.Text == "" || txt_name_vcs.Text == "" || (lbl_rootlevel.Text == "" || lbl_rootlevel_name.Text == "") || lbl_type_acc.Text == "" || lbl_sort.Text == "")
                {
                    int num2 = (int)MessageBox.Show("في حساب ناقص");
                    return;
                }
                delete();
                save();
                MessageBox.Show("تم التعديل");
            }

        }
        private void Txt_name_vcs_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Txt_addreess_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Txt_phone_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Chk_credit_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Txt_code_vcs_Leave(object sender, EventArgs e)
        {

        }

        private void save_barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            perform_Save();
        }

        private void delete_barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "سيتم حذف السند ", "رسال تاكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
                return;
            delete();
            ship_jop.frm_storehouse f = new frm_storehouse();
            Close();
            ((Control)f).Show();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ship_jop.frm_storehouse f = new frm_storehouse();
            Close();
            ((Control)f).Show();
        }

        private void btn_pending_close_Click(object sender, EventArgs e)
        {
            group_find.Visible = false;

        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            dgv_f.Rows.Clear();
            DataTable dt = new DataTable();
            db.GetData_DGV("select id,name from jn_storehouse where id='" + combo1.Text + "'", dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv_f.Rows.Add("", dt.Rows[i][0] + "", dt.Rows[i][1] + "");
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            dgv_f.Rows.Clear();
            DataTable dt = new DataTable();
            db.GetData_DGV("select id,name from jn_storehouse where name='" + combo2.Text + "'", dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv_f.Rows.Add("", dt.Rows[i][0] + "", dt.Rows[i][1] + "");
            }
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            group_find.Visible = true;
            dgv_f.Rows.Clear();
            DataTable dt = new DataTable();
            db.GetData_DGV("select id,name from jn_storehouse", dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv_f.Rows.Add("", dt.Rows[i][0] + "", dt.Rows[i][1] + "");
            }

            all_comb.load_storhouse_code(combo1);
            all_comb.load_storehouse_name(combo2);
            combo1.Text = "";
            combo2.Text = "";
        }

        private void dgv_f_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                edit = true;
                txt_code_vcs.Text = dgv_f.CurrentRow.Cells[1].Value + "";
                txt_name_vcs.Text = dgv_f.CurrentRow.Cells[2].Value + "";
                group_find.Visible = false;

            }
            catch (Exception)
            {
            }
        }
    }
}