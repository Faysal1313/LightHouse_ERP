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
    public partial class frm_station : DevExpress.XtraEditors.XtraForm
    {
        public frm_station()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(v.ico);

        }
        private void frm_station_Load(object sender, EventArgs e)
        {
            all_comb.load_account_sc(combo_vcs_gl);
            all_comb.load_account_sc(this.combo_vcs_gl);
            combo_vcs_gl.Text = Properties.Settings.Default.clint_acc;
            txt_code_vcs.Text = genrat_code();
        }
        private static string genrat_code()
        {

            string str = db.GetData("select max(id)+1 from jn_station ").Rows[0][0].ToString();
            if (str == "")
                str = "800001";
            return str;
        }

        //=================================Function
        private bool edit = false;
        private void save()
        {
            if (txt_price.Text=="")
            {
                MessageBox.Show("يجب ان يكون السعر اكبر من صفر");
                return;
            }
            txt_code_vcs.Text = genrat_code();
            db.Run("insert into jn_station (id, name, mode, rootlevel, rootlevel_name, type_acc, sort,  address,price,kilometers) values ('" + txt_code_vcs.Text + "','" + txt_name_vcs.Text + "','customer','" + lbl_rootlevel.Text + "','" + lbl_rootlevel_name.Text + "','customer','" + lbl_sort.Text + "','" + txt_addreess.Text + "','" + txt_price.Text + "','" + txt_kilometers.Text + "')");

        }
        private void delete()
        {
            db.Run("delete from jn_station where id='" + txt_code_vcs.Text + "'");
        }
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

                if (db.GetData("select isnull(max(id),0) from jn_station where id ='" + txt_code_vcs.Text + "' ").Rows[0][0].ToString() != "0")
                {
                    int num1 = (int)MessageBox.Show("الكود موجود من قبل   ");
                    return;
                }
                else
                {
                    try
                    {
                        string str1 = db.GetData("select isnull(max(name),0) from jn_station where name='" + txt_name_vcs.Text + "'").Rows[0][0].ToString();
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
                MessageBox.Show("تم الحفظ");

            }
            else
            {
                try
                {
                    string str1 = db.GetData("select isnull(max(name),0) from jn_station where name='" + txt_name_vcs.Text + "'").Rows[0][0].ToString();
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
        private void combo_vcs_gl_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_rootlevel.Text = db.GetData("select Rootlevel  from tree where rootname='" + combo_vcs_gl.Text + "'").Rows[0][0].ToString();
                lbl_rootlevel_name.Text = db.GetData("select Rootname  from tree where rootname='" + combo_vcs_gl.Text + "'").Rows[0][0].ToString();
                lbl_sort.Text = db.GetData("select sort  from tree where rootname='" + combo_vcs_gl.Text + "'").Rows[0][0].ToString();
                lbl_type_acc.Text = db.GetData("select type_acc  from tree where rootname='" + combo_vcs_gl.Text + "'").Rows[0][0].ToString();

            }
            catch (Exception)
            {


            }
        }
        private void btn_search_items_Click(object sender, EventArgs e)
        {
            if (combo_vcs_gl.Text != "")
            {
                lbl_rootlevel.Text = db.GetData("select Rootlevel  from tree where rootname='" + combo_vcs_gl.Text + "'").Rows[0][0].ToString();
                lbl_rootlevel_name.Text = db.GetData("select Rootname  from tree where rootname='" + combo_vcs_gl.Text + "'").Rows[0][0].ToString();
                lbl_sort.Text = db.GetData("select sort  from tree where rootname='" + combo_vcs_gl.Text + "'").Rows[0][0].ToString();
                lbl_type_acc.Text = db.GetData("select type_acc  from tree where rootname='" + combo_vcs_gl.Text + "'").Rows[0][0].ToString();
            }
            return;
        }

        private void save_barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            perform_Save();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.clint_acc = combo_vcs_gl.Text;
            Properties.Settings.Default.Save();
        }

        private void delete_barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "سيتم حذف السند ", "رسال تاكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
                return;
            delete();
            ship_jop.frm_station f = new frm_station();
            Close();
            ((Control)f).Show();
        }

        private void btn_new_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ship_jop.frm_station f = new frm_station();
            this.Close();
            f.Show();
        }

        private void btn_search_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            group_find.Visible = true;
            dgv_f.Rows.Clear();
            DataTable dt = new DataTable();
            db.GetData_DGV("select id,name,price from jn_station", dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv_f.Rows.Add("", dt.Rows[i][0] + "", dt.Rows[i][1] + "", dt.Rows[i][2] + "");
            }

            all_comb.load_station_code(combo1);
            all_comb.load_station_name(combo2);
            combo1.Text = "";
            combo2.Text = "";

        }

        private void btn_pending_close_Click(object sender, EventArgs e)
        {
            group_find.Visible = false;
        }

        private void dgv_f_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                edit = true;
                txt_code_vcs.Text = dgv_f.CurrentRow.Cells[1].Value + "";
                txt_name_vcs.Text = dgv_f.CurrentRow.Cells[2].Value + "";
                txt_price.Text = dgv_f.CurrentRow.Cells[3].Value + "";
                group_find.Visible = false;

            }
            catch (Exception)
            {
            }
        }

        private void dgv_f_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv_f, "no");
        }
        private void dgv_f_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            Classes.command.LoadSerial(dgv_f, "no");

        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            dgv_f.Rows.Clear();
            DataTable dt = new DataTable();
            db.GetData_DGV("select id,name,price from jn_station where id='" + combo1.Text + "'", dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv_f.Rows.Add("", dt.Rows[i][0] + "", dt.Rows[i][1] + "", dt.Rows[i][2] + "");
            }

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            dgv_f.Rows.Clear();
            DataTable dt = new DataTable();
            db.GetData_DGV("select id,name,price from jn_station where name='" + combo2.Text + "'", dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv_f.Rows.Add("", dt.Rows[i][0] + "", dt.Rows[i][1] + "", dt.Rows[i][2] + "");
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (txt_code_vcs.Text == "") return;
            db.Run("update jn_station set price ='"+ txt_price.Text + "' where id='"+ txt_code_vcs.Text+ "'");
            MessageBox.Show("تم تعديل السعر ");
        }
    }

}