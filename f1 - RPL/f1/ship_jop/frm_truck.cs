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
    public partial class frm_truck : DevExpress.XtraEditors.XtraForm
    {
        public frm_truck()
        {
            InitializeComponent();
        }

        //=================================Function
        private bool edit = false;
        private void save()
        {
            db.Run("insert into jn_truck(id,name,model,tank)values('" + txt_code_vcs.Text + "','" + txt_name_vcs.Text + "','" + txt_model.Text + "'," + txt_qty.Value + ")");
        }
        private void delete()
        {
            db.Run("delete from jn_truck where id='" + txt_code_vcs.Text+"'");
        }
       private  void clear()
        {
            txt_code_vcs.Text = "";
            txt_model.Text = "";
            txt_qty.Text = "";
            txt_name_vcs.Text = "";
            edit = false;
        }
      
        private void perform_Save()
        {
            if (edit == false)
            {

                if (db.GetData("select isnull(max(id),0) from jn_truck where id ='" + txt_code_vcs.Text + "' ").Rows[0][0].ToString() != "0")
                {
                    int num1 = (int)MessageBox.Show("الكود موجود من قبل   ");
                    return;
                }
                else
                {
                    try
                    {
                        string str1 = db.GetData("select isnull(max(name),0) from jn_truck where name='" + txt_name_vcs.Text + "'").Rows[0][0].ToString();
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
                    string str1 = db.GetData("select isnull(max(name),0) from jn_truck where name='" + txt_name_vcs.Text + "'").Rows[0][0].ToString();
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
        private void save_barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txt_code_vcs.Text == "") 
            {
                // XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "قق", "رسال حذف مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                MessageBox.Show("يجب اختيار كود للشاحنة");
                return;
            }
            if (edit==false)
            {
                save();
                MessageBox.Show("save");
            }
            else
            {
                delete();
                save();
                MessageBox.Show("edite");

            }

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ship_jop.frm_truck f = new frm_truck();
            Close();
            ((Control)f).Show();
        }

        private void delete_barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dr;
            dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "هل ترد الحذف!!؟؟؟؟ ", "رسال حذف مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);


            if (dr == DialogResult.OK)
            {
                delete();
                ship_jop.frm_truck f = new frm_truck();
                Close();
                ((Control)f).Show();
            }

        }

        private void txt_code_vcs_Leave(object sender, EventArgs e)
        {
            try
            {
                if (db.GetData("select isnull (max (id),'0') from jn_truck where id='" + txt_code_vcs.Text + "' ").Rows[0][0].ToString() != "0")
                {
                    edit = true;
                    txt_name_vcs.Text= db.GetData("select isnull (max (name),0) from jn_truck where id='" + txt_code_vcs.Text + "' ").Rows[0][0].ToString();
                    txt_model.Text = db.GetData("select isnull (max (model),0) from jn_truck where id='" + txt_code_vcs.Text + "' ").Rows[0][0].ToString();
                    txt_qty.Value = Convert.ToDecimal(db.GetData("select isnull (max (tank),0) from jn_truck where id='" + txt_code_vcs.Text + "' ").Rows[0][0].ToString());


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_pending_close_Click(object sender, EventArgs e)
        {
            group_find.Visible = false;

        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            dgv_f.Rows.Clear();
            DataTable dt = new DataTable();
            db.GetData_DGV("select id,name from jn_truck where id='" + combo1.Text + "'", dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv_f.Rows.Add("", dt.Rows[i][0] + "", dt.Rows[i][1] + "");
            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            dgv_f.Rows.Clear();
            DataTable dt = new DataTable();
            db.GetData_DGV("select id,name from jn_truck where name='" + combo2.Text + "'", dt);
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
            db.GetData_DGV("select id,name from jn_truck", dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv_f.Rows.Add("", dt.Rows[i][0] + "", dt.Rows[i][1] + "");
            }

            all_comb.load_truck_id(combo1);
            all_comb.load_truck_name(combo2);
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