using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using f1.Classes;

namespace f1
{
    public partial class frm_customer : DevExpress.XtraEditors.XtraForm
    {
        public frm_customer()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);

        }

        private void frm_customer_Load(object sender, EventArgs e)
        {
            all_comb.load_account_sc(combo_vcs_gl);
            load_permission();

            all_comb.load_account_sc(this.combo_vcs_gl);

            combo_vcs_gl.Text = Properties.Settings.Default.clint_acc;
            this.load_permission();
         
            this.num_credit.Visible = false;

            if (v.iam_pos==true)
            {
                txt_name_vcs.Select();

            }
            txt_code_vcs.Text = genrat_code();
        }

        private void combo_vcs_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (combo_vcs_gl.Text != "")
            //{
                
            //}
            //return;
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.clint_acc = combo_vcs_gl.Text;
            Properties.Settings.Default.Save();
        }

        //=-------------------------------------------fanction
        bool edit = false;
        bool add_permission = true;
        bool edit_permission = true;
        private static string genrat_code()
        {
            string str = db.GetData("select max(vcs_code)+1 from vcs where mode='customer'").Rows[0][0].ToString();
            if (str == "")
                str = "900001";
            return str;
        }
        private void save()
        {


            //generat code
            txt_code_vcs.Text = genrat_code();
            db.Run("insert into vcs (vcs_code, vcs_name, mode, rootlevel, rootlevel_name, type_acc, sort, phone, address,credit) values ('" + txt_code_vcs.Text + "','" + txt_name_vcs.Text + "','customer','" + lbl_rootlevel.Text + "','" + lbl_rootlevel_name.Text + "','customer','" + lbl_sort.Text + "','" + txt_phone.Text + "','" + txt_addreess.Text + "','False')");

        }
        private void update()
        {
            db.Run("update vcs set vcs_name='" + txt_name_vcs.Text + "' , rootlevel='" + lbl_rootlevel.Text + "',rootlevel_name='" + lbl_rootlevel_name.Text + "',sort='" + lbl_sort.Text + "',phone='" + txt_phone.Text + "',address='" + txt_addreess.Text + "' where vcs_code='" + txt_code_vcs.Text + "'");
            db.Run("update vcs set vcs_code='" + txt_code_vcs.Text + "'where vcs_name='" + txt_name_vcs.Text + "'");
        }
        private void performsave()
        {
           
            if (save_barButtonItem1.Enabled == false || delete_barButtonItem7.Enabled == false)
                return;
            if (db.GetData("select isnull(max(vcs_code),0) from vcs where vcs_code ='" + txt_code_vcs.Text + "' ").Rows[0][0].ToString() != "0")
            {
               MessageBox.Show("الكود موجود من قبل");
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
                //---------------------
                if (txt_code_vcs.Text == "" || txt_name_vcs.Text == "" || (lbl_rootlevel.Text == "" || lbl_rootlevel_name.Text == "") || lbl_type_acc.Text == "" || lbl_sort.Text == "")
                {
                    MessageBox.Show("في حساب ناقص");
                }
                else if (!edit)
                {
                    if (!edit)
                    {
                        if (add_permission)
                        {
                            save();
                            XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "saving ", "save", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            MessageBox.Show("لايوجد صلاحية للمستخدم ان يضيف فاتوره تعدل فقط ");
                        }
                    }
                }
                else if (edit_permission)
                {
                    update();
                   MessageBox.Show("تم التعديل");
                }
                else
                {
                   MessageBox.Show("لا توجد صلاحية انك تعدل علي الفاتوره  ");
                }
            }
        }
        private void delete()
        {
            if (XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "سيتم حذف السند ", "رسال تاكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
                return;
            db.Run("delete from vcs where vcs_code='" + txt_code_vcs.Text + "'");
            frm_customer frmVendor = new frm_customer();
            Close();
            ((Control)frmVendor).Show();


        }
        private void nav()
        {
            if (Convert.ToInt32(db.GetData("select isnull(count(vcs_code),0) from vcs where mode= 'customer'").Rows[0][0].ToString()) == 0)
                return;
            this.edit = true;
            this.txt_name_vcs.Text = db.GetData("select vcs_name from vcs where vcs_code ='" + this.txt_code_vcs.Text + "'").Rows[0][0].ToString();
            this.txt_phone.Text = db.GetData("select phone from vcs where vcs_code ='" + this.txt_code_vcs.Text + "'").Rows[0][0].ToString();
            this.txt_addreess.Text = db.GetData("select address from vcs where vcs_code ='" + this.txt_code_vcs.Text + "'").Rows[0][0].ToString();
            this.lbl_rootlevel.Text = db.GetData("select rootlevel from vcs where vcs_code ='" + this.txt_code_vcs.Text + "'").Rows[0][0].ToString();
            this.lbl_rootlevel_name.Text = db.GetData("select rootlevel_name from vcs where vcs_code ='" + this.txt_code_vcs.Text + "'").Rows[0][0].ToString();
            this.combo_vcs_gl.Text = db.GetData("select rootlevel_name from vcs where vcs_code ='" + this.txt_code_vcs.Text + "'").Rows[0][0].ToString();
            this.chk_credit.Checked = Convert.ToBoolean(db.GetData("select credit from vcs where vcs_code ='" + this.txt_code_vcs.Text + "'").Rows[0][0].ToString());
            this.num_credit.Text = db.GetData("select credit_limit from vcs where vcs_code ='" + this.txt_code_vcs.Text + "'").Rows[0][0].ToString();

            //this.combo_e_type1.Text = db.GetData("select type from  vcs where vcs_code ='" + this.txt_code_vcs.Text + "'").Rows[0][0].ToString();
            //this.txt_e_rkamtgary1.Text = db.GetData("select id from vcs where vcs_code ='" + this.txt_code_vcs.Text + "'").Rows[0][0].ToString();
            //this.txt_e_name_company1.Text = db.GetData("select name from vcs where vcs_code ='" + this.txt_code_vcs.Text + "'").Rows[0][0].ToString();
            //this.txt_e_country1.Text = db.GetData("select country from  vcs where vcs_code ='" + this.txt_code_vcs.Text + "'").Rows[0][0].ToString();
            //this.txt_e_govern1.Text = db.GetData("select governate from  vcs where vcs_code ='" + this.txt_code_vcs.Text + "'").Rows[0][0].ToString();
            //this.txt_e_city1.Text = db.GetData("select regionCity from  vcs where vcs_code ='" + this.txt_code_vcs.Text + "'").Rows[0][0].ToString();
            //this.txt_e_street1.Text = db.GetData("select street from  vcs where vcs_code ='" + this.txt_code_vcs.Text + "'").Rows[0][0].ToString();
            //this.txt_e_build1.Text = db.GetData("select buildingNumber from  vcs where vcs_code ='" + this.txt_code_vcs.Text + "'").Rows[0][0].ToString();
            //this.txt_e_post1.Text = db.GetData("select postalCode from  vcs where vcs_code ='" + this.txt_code_vcs.Text + "'").Rows[0][0].ToString();
            //this.txt_e_floore1.Text = db.GetData("select floor from  vcs where vcs_code ='" + this.txt_code_vcs.Text + "'").Rows[0][0].ToString();

        }
        private void load_permission()
        {
            this.save_barButtonItem1.Enabled = Convert.ToBoolean(db.GetData("select [add_only] from permission_sub where user_code='" + v.usercode + "' and name_frm ='customer' ").Rows[0][0].ToString());
            this.delete_barButtonItem7.Enabled = Convert.ToBoolean(db.GetData("select [delete] from permission_sub where user_code='" + v.usercode + "' and name_frm ='customer' ").Rows[0][0].ToString());
            this.add_permission = Convert.ToBoolean(db.GetData("select [add_only] from permission_sub where user_code='" + v.usercode + "' and name_frm ='customer' ").Rows[0][0].ToString());
            this.edit_permission = Convert.ToBoolean(db.GetData("select [edit_only] from permission_sub where user_code='" + v.usercode + "' and name_frm ='customer' ").Rows[0][0].ToString());
        }

        private void save_barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            performsave();
        }

        private void new_barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_customer f = new frm_customer();
            this.Close();
            f.Show();
        }

        private void delete_barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            delete();
        }

        //--------------------------------------------controls

        //================================================Navigation=====================
        private void first_barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.txt_code_vcs.Text = db.GetData("select min(vcs_code) from vcs where mode= 'customer'").Rows[0][0].ToString();
            this.nav();
        }

        private void back_barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                new DataTable().Rows.Clear();
                if (int.Parse(this.txt_code_vcs.Text) <= int.Parse(db.GetData("select min(vcs_code) from vcs where mode= 'customer' ").Rows[0][0].ToString()))
                {
                    int num = (int)MessageBox.Show("اخر ملف");
                }
                else
                {
                    this.txt_code_vcs.Text = string.Concat((object)(int.Parse(this.txt_code_vcs.Text) - 1));
                    this.nav();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                new DataTable().Rows.Clear();
                if (int.Parse(this.txt_code_vcs.Text) >= int.Parse(db.GetData("select max(vcs_code) from vcs where mode= 'customer' ").Rows[0][0].ToString()))
                {
                    int num = (int)MessageBox.Show("اول م ملف");
                }
                else
                {
                    this.txt_code_vcs.Text = string.Concat((object)(int.Parse(this.txt_code_vcs.Text) + 1));
                    this.nav();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.txt_code_vcs.Text = db.GetData("select max(vcs_code) from vcs where mode= 'customer'").Rows[0][0].ToString();
            this.nav();
        }

        private void Chk_credit_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk_credit.Checked)
                this.num_credit.Visible = true;
            else
                this.num_credit.Visible = false;
        }

        private void Txt_code_vcs_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(db.GetData("select isnull(max(vcs_code),0) from vcs  where vcs_code='" + this.txt_code_vcs.Text + "'").Rows[0][0].ToString()) == 0)
                    return;
                this.nav();
                this.edit = true;
            }
            catch (Exception ex)
            {
            }
        }

        private void Txt_name_vcs_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_phone.Select();
            }
        }

        private void Txt_phone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_addreess.Select();
            }
        }

        private void Txt_addreess_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (v.iam_pos == true)
                {
                    txt_name_vcs.Select();
                    performsave();
                    v.vcs_code_pos = txt_code_vcs.Text;
                    v.vcs_name_pos = txt_name_vcs.Text;
                    v.vcs_phone_pos = txt_phone.Text;
                    v.vcs_address_pos = txt_addreess.Text;
                    v.iam_posed = true;

                    Close();
                }
            }
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            v.search_screen = "customer";
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
















    }
}