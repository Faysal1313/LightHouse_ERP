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
    public partial class frm_vendor : DevExpress.XtraEditors.XtraForm
    {
        public frm_vendor()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(v.ico);

        }
        private void frm_vendor_Load(object sender, EventArgs e)
        {
            all_comb.load_account_sc(combo_vcs_gl);
            combo_vcs_gl.Text = "";
            combo_vcs_gl.Text= Properties.Settings.Default.vendor_acc;
            load_permission();
          
        }

        private void combo_vcs_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (combo_vcs_gl.Text != "")
            //{
            //    lbl_rootlevel.Text = db.GetData("select Rootlevel  from tree where rootname='" + combo_vcs_gl.Text + "'").Rows[0][0].ToString();
            //    lbl_rootlevel_name.Text = db.GetData("select Rootname  from tree where rootname='" + combo_vcs_gl.Text + "'").Rows[0][0].ToString();
            //    lbl_sort.Text = db.GetData("select sort  from tree where rootname='" + combo_vcs_gl.Text + "'").Rows[0][0].ToString();
            //    lbl_type_acc.Text = db.GetData("select type_acc  from tree where rootname='" + combo_vcs_gl.Text + "'").Rows[0][0].ToString();
            //    Properties.Settings.Default.vendor_acc = combo_vcs_gl.Text;
            //    Properties.Settings.Default.Save();

            //}
            //return;
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
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.vendor_acc = combo_vcs_gl.Text;
            Properties.Settings.Default.Save();
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
        //=-------------------------------------------fanction
        bool edit = false;
        bool add_permission = true;
        bool edit_permission = true;

        private void save()
        {
            db.Run("insert into vcs (vcs_code, vcs_name, mode, rootlevel, rootlevel_name, type_acc, sort, phone, address,credit) values ('"+txt_code_vcs.Text+"','"+txt_name_vcs.Text+"','vendor','"+lbl_rootlevel.Text+"','"+lbl_rootlevel_name.Text+"','vendor','"+lbl_sort.Text+"','"+txt_phone.Text+"','"+txt_addreess.Text+ "','False')");
        
        }
        private void update()
        {
            db.Run("update vcs set vcs_name='"+txt_name_vcs.Text+"' , rootlevel='"+lbl_rootlevel.Text+"',rootlevel_name='"+lbl_rootlevel_name.Text+"',sort='"+lbl_sort.Text+"',phone='"+txt_phone.Text+"',address='"+txt_addreess.Text+"' where vcs_code='"+txt_code_vcs.Text+"'");
            db.Run("update vcs set vcs_code='" + txt_code_vcs.Text + "'where vcs_name='" + txt_name_vcs.Text + "'");       
        }
        private void load_permission()
        {
            save_barButtonItem1.Enabled = Convert.ToBoolean(db.GetData("select [add_only] from permission_sub where user_code='" + v.usercode + "' and name_frm ='vendor' ").Rows[0][0].ToString());
            delete_barButtonItem7.Enabled = Convert.ToBoolean(db.GetData("select [delete] from permission_sub where user_code='" + v.usercode + "' and name_frm ='vendor' ").Rows[0][0].ToString());
            add_permission = Convert.ToBoolean(db.GetData("select [add_only] from permission_sub where user_code='" + v.usercode + "' and name_frm ='vendor' ").Rows[0][0].ToString());
            edit_permission = Convert.ToBoolean(db.GetData("select [edit_only] from permission_sub where user_code='" + v.usercode + "' and name_frm ='vendor' ").Rows[0][0].ToString());
        }
        private void performsave()
        {
            if (!save_barButtonItem1.Enabled || !delete_barButtonItem7.Enabled)
                return;
            if (db.GetData("select isnull(max(vcs_code),0) from vcs where vcs_code ='" + txt_code_vcs.Text + "' ").Rows[0][0].ToString() != "0")
            {
                int num1 = (int)MessageBox.Show("الكود موجود من قبل   ");
            }
            else
            {
                try
                {
                    string str1 = db.GetData("select isnull(max(vcs_name),0) from vcs where vcs_name='" + txt_name_vcs.Text + "'").Rows[0][0].ToString();
                    if (str1.Length > 0 && str1 == txt_name_vcs.Text)
                    {
                        MessageBox.Show("اسم  مكرر");
                        return;
                    }
                    else
                    {
                        string str2 = db.GetData("select isnull(max(phone),0) from vcs where phone ='" + txt_phone.Text + "' ").Rows[0][0].ToString();
                        if (str2.Length > 0 && str2 == txt_phone.Text)
                        {
                            MessageBox.Show("رقم الهاتف مسجل  ");
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                }
                if (txt_code_vcs.Text == "" || txt_name_vcs.Text == "" || (lbl_rootlevel.Text == "" || lbl_rootlevel_name.Text == "") || lbl_type_acc.Text == "" || lbl_sort.Text == "")
                {
                    int num2 = (int)MessageBox.Show("في حساب ناقص");
                }
                
                else if (!edit)
                {
                    if (!edit)
                    {
                        if (add_permission)
                        {
                            save();
                            int num5 = (int)XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "saving ", "save", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            int num6 = (int)MessageBox.Show("لا توجد صلايحه انك تضيف  تعدل فقط ");
                        }
                    }
                }
                else if (edit_permission)
                {
                    update();
                    int num5 = (int)MessageBox.Show("تم التعديل");
                }
                else
                {
                    int num7 = (int)MessageBox.Show("لا توجد صلايحه انك تعدل   ");
                }
            }
        }
        private void delete()
        {
            if (XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "سيتم حذف السند ", "رسال تاكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
                return;
            db.Run("delete from vcs where vcs_code='" + txt_code_vcs.Text + "'");
            frm_vendor frmVendor = new frm_vendor();
            Close();
            ((Control)frmVendor).Show();


        }
        private void nav()
        {
            if (Convert.ToInt32(db.GetData("select isnull(count(vcs_code),0) from vcs where mode= 'vendor'").Rows[0][0].ToString()) == 0)
                return;
            edit = true;
            txt_name_vcs.Text = db.GetData("select vcs_name from vcs where vcs_code ='" + txt_code_vcs.Text + "'").Rows[0][0].ToString();
            txt_phone.Text = db.GetData("select phone from vcs where vcs_code ='" + txt_code_vcs.Text + "'").Rows[0][0].ToString();
            txt_addreess.Text = db.GetData("select address from vcs where vcs_code ='" + txt_code_vcs.Text + "'").Rows[0][0].ToString();
            lbl_rootlevel.Text = db.GetData("select rootlevel from vcs where vcs_code ='" + txt_code_vcs.Text + "'").Rows[0][0].ToString();
            lbl_rootlevel_name.Text = db.GetData("select rootlevel_name from vcs where vcs_code ='" + txt_code_vcs.Text + "'").Rows[0][0].ToString();
            combo_vcs_gl.Text = db.GetData("select rootlevel_name from vcs where vcs_code ='" + txt_code_vcs.Text + "'").Rows[0][0].ToString();
            //combo_e_type.Text = db.GetData("select type from  vcs where vcs_code ='" + txt_code_vcs.Text + "'").Rows[0][0].ToString();
            //txt_e_rkamtgary.Text = db.GetData("select id from vcs where vcs_code ='" + txt_code_vcs.Text + "'").Rows[0][0].ToString();
            //txt_e_name_company.Text = db.GetData("select name from vcs where vcs_code ='" + txt_code_vcs.Text + "'").Rows[0][0].ToString();
            //txt_e_country.Text = db.GetData("select country from  vcs where vcs_code ='" + txt_code_vcs.Text + "'").Rows[0][0].ToString();
            //txt_e_govern.Text = db.GetData("select governate from  vcs where vcs_code ='" + txt_code_vcs.Text + "'").Rows[0][0].ToString();
            //txt_e_city.Text = db.GetData("select regionCity from  vcs where vcs_code ='" + txt_code_vcs.Text + "'").Rows[0][0].ToString();
            //txt_e_street.Text = db.GetData("select street from  vcs where vcs_code ='" + txt_code_vcs.Text + "'").Rows[0][0].ToString();
            //txt_e_build.Text = db.GetData("select buildingNumber from  vcs where vcs_code ='" + txt_code_vcs.Text + "'").Rows[0][0].ToString();
            //txt_e_post.Text = db.GetData("select postalCode from  vcs where vcs_code ='" + txt_code_vcs.Text + "'").Rows[0][0].ToString();
            //txt_e_floore.Text = db.GetData("select floor from  vcs where vcs_code ='" + txt_code_vcs.Text + "'").Rows[0][0].ToString();
        }
       
        
        //--------------------------------------------controls
        private void save_barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            performsave();
        }
        private void delete_barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            delete();

        }
        private void new_barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_vendor f = new frm_vendor();
            Close();
            f.Show();
        }
        
        //================================================Navigation=====================
        private void first_barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txt_code_vcs.Text = db.GetData("select min(vcs_code) from vcs where mode= 'vendor'").Rows[0][0].ToString();
             nav();
        }
        private void back_barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                new DataTable().Rows.Clear();
                if (int.Parse(txt_code_vcs.Text) <= int.Parse(db.GetData("select min(vcs_code) from vcs where mode= 'vendor' ").Rows[0][0].ToString()))
                {
                    int num = (int)MessageBox.Show("اخر ملف");
                }
                else
                {
                    txt_code_vcs.Text = string.Concat((object)(int.Parse(txt_code_vcs.Text) - 1));
                    nav();
                }
            }
            catch (Exception ex)
            {
                db.log_error(string.Concat((object)ex));
            }
        }
        private void next_barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                new DataTable().Rows.Clear();
                if (int.Parse(txt_code_vcs.Text) >= int.Parse(db.GetData("select max(vcs_code) from vcs where mode= 'vendor' ").Rows[0][0].ToString()))
                {
                    int num = (int)MessageBox.Show("اول م ملف");
                }
                else
                {
                    txt_code_vcs.Text = string.Concat((object)(int.Parse(txt_code_vcs.Text) + 1));
                    nav();
                }
            }
            catch (Exception ex)
            {
                db.log_error(string.Concat((object)ex));
            }

        }
        private void last_barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txt_code_vcs.Text = db.GetData("select max(vcs_code) from vcs where mode= 'vendor'").Rows[0][0].ToString();
            nav();
        }

        private void Txt_code_vcs_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(db.GetData("select isnull(max(vcs_code),0) from vcs  where vcs_code='" + txt_code_vcs.Text + "' and mode ='vendor'").Rows[0][0].ToString()) == 0)
                    return;
                nav();
                edit = true;
            }
            catch (Exception ex)
            {
                db.log_error(string.Concat((object)ex));
            }
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            v.search_screen = "vendor";
            frm_search f = new frm_search();
            f.ShowDialog();
            timer1.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (v.search_screen_code != "")
            {
                txt_code_vcs.Text = v.search_screen_code;
                txt_code_vcs.Select();

                txt_name_vcs.Select();
                timer1.Enabled = false;

            }
        }






        //===============================================endnavigation================================
        // ----------------------------------------hotkeys



    }
}