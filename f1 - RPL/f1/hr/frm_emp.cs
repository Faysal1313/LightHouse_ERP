using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.IO;

namespace f1
{
    public partial class frm_emp : DevExpress.XtraEditors.XtraForm
    {
        public frm_emp()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
        }
        bool edit = false;

        private void frm_emp_Load(object sender, EventArgs e)
        {
            groupControl1.Visible = false;

        }


       //save 
        public void save()
       {
           db.Run("insert into emps (emp_no ,emp_name,user_name,[user])values('" + txt_code_emp.Text + "','" + txt_full_name.Text + "','" + txt_full_name.Text + "','False')");
       }
        public void update()
        {
            db.Run("update emps set emp_name='"+txt_full_name.Text+"', user_name='"+txt_full_name.Text+"' where emp_no='"+txt_code_emp.Text+"' ");
            db.Run("update emps set emp_no='" + txt_code_emp.Text + "' where user_name='" + txt_full_name.Text + "' ");
            if (chk_user.Checked == false)
            {
                db.Run("delete from permission where user_name='"+txt_user_name.Text+"'");
                db.Run("delete from permission_sub where user_name='" + txt_user_name.Text + "'");
                db.Run("update emps set [user]='False' where emp_no='" + txt_code_emp.Text + "' ");


            }
       }

        public void clear ()
    {
        txt_code_emp.Text = "";
        txt_full_name.Text = "";
        txt_address.Text = "";
    }
        public void perform_click()
        {
            if (txt_code_emp.Text =="" || txt_full_name.Text =="")
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "لايمكن الحفظ يجب إدخال البيانات ", "save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (edit == false)
                {
                    save();
                }
                else
                {
                    update();
                }
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "saving ", "save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        
        
        }
        public void perform_delete()
        {
           
            if (txt_code_emp.Text == "")
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "ماشي بس هو مفيش خاجه علشان امسحها دخل كود الموظف طيب !!؟؟؟؟ ", "رسال حذف مستند", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult dr;
                dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "عايز تشيل  من هنا!!؟؟؟؟ ", "رسال حذف مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);


                if (dr == DialogResult.OK)
                {
                    db.Run("delete from emps where emp_no='" + txt_code_emp.Text + "'");
                    db.Run("delete from permission where user_code='" + txt_code_emp.Text + "'");
                    db.Run("delete from permission_sub where user_code='" + txt_code_emp.Text + "'");
                    db.Run("delete from pos_permission where user_code='" + txt_code_emp.Text + "'");
                    db.Run("delete from permission_sub_screen where user_code='" + txt_code_emp.Text + "'");

                    //permission_sub_screen

                    // clear();
                    frm_emp frm = new frm_emp();
                    this.Close();
                    frm.Show();
                }
                else
                {
                    return;
                }
            }
        
        }
        private void savebar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            perform_click();
        }
        private void new_()
        {
            DialogResult dr;
            dr = MessageBox.Show("هل تريد عمل سند جديد تريد عمل سند جديد!!؟؟؟؟ ", "رسال جديد مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                frm_emp frm = new frm_emp();
                this.Close();
                frm.Show();
            }
        
        }
        //====navigation
        /// ///////////////////////////////////////////////////////////////////////////////////END NAvigations
        public void bode_of_navigation()
        {
            try
            {

                txt_code_emp.Text = db.GetData("select emp_no from emps where emp_no='" + txt_code_emp.Text + "' ").Rows[0][0].ToString();
                txt_full_name.Text = db.GetData("select emp_name from emps where emp_no='" + txt_code_emp.Text + "' ").Rows[0][0].ToString();
                edit = true;
                chk_user.Visible = true;
               chk_user.Checked= Convert.ToBoolean(db.GetData("select [user] from emps where emp_no='" + txt_code_emp.Text + "'").Rows[0][0].ToString());
               txt_user_name.Text = db.GetData("select isnull(max([user_name]),0) from emps where emp_no='" + txt_code_emp.Text + "' ").Rows[0][0].ToString();
            }
           catch (Exception)
            {
            }

        }
        private void First_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Rows.Clear();
                txt_code_emp.Text = db.GetData("select min(emp_no) from emps ").Rows[0][0].ToString();
                bode_of_navigation();

               
            }
            catch (Exception)
            {


            }
        }
        private void LastbarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                DataTable dt = new DataTable();
                dt.Rows.Clear();
                txt_code_emp.Text = db.GetData("select max(emp_no) from emps ").Rows[0][0].ToString();
                bode_of_navigation();
            }
            catch (Exception)
            {

            }
           
        }
        private void NextbarButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                {

                    DataTable dt = new DataTable();
                    dt.Rows.Clear();
                    string st = "";
                    st = db.GetData("select min(emp_no) from emps ").Rows[0][0].ToString();
                    int m = int.Parse(st);
                    //clearANDauto();
                    if (int.Parse(txt_code_emp.Text) <= m)
                        MessageBox.Show("اخر ملف");
                    else
                    {
                        int num = +(Int32.Parse(txt_code_emp.Text) - 1);
                        txt_code_emp.Text = num + "";
                        bode_of_navigation();

                    }
                }
            }
            catch (Exception)
            {

            }
        }
        private void BackbarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                DataTable dt = new DataTable();
                dt.Rows.Clear();
                string st = "";
                st = db.GetData("select max(emp_no) from emps ").Rows[0][0].ToString();
                int m = int.Parse(st);
                //clearANDauto();
                edit = true;
                if (int.Parse(txt_code_emp.Text) >= m)
                    MessageBox.Show("اول م ملف");
                else
                {
                    int num = +(Int32.Parse(txt_code_emp.Text) + 1);
                    txt_code_emp.Text = num + "";
                    bode_of_navigation();
                }
            }
            catch (Exception)
            {

            }

        }
        private void txt_code_emp_TextChanged(object sender, EventArgs e)
        {
                bode_of_navigation();
        } 
        /// ///////////////////////////////////////////////////////////////////////////////////END NAvigations
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new_();
        }
        private void deletebutttonbarButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            perform_delete();
        }

        private void frm_emp_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr;

            if (txt_code_emp.Text != "" || txt_full_name.Text != "" )
            {
                dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "سيتم الخروج !!؟؟؟؟ ", "رسال خروج", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
           

        }
        //---------------------------HOTKEYS-------------------------

        private void frm_emp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.S && Control.ModifierKeys==Keys.Control)
            {
                perform_click();
            }
            if (e.KeyCode == Keys.N && Control.ModifierKeys == Keys.Control)
            {
                new_();
            }
            if (e.KeyCode == Keys.Delete && Control.ModifierKeys == Keys.Control)
            {
                perform_delete();
            }
        }

        private void chk_user_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_user.Checked==true)
            {
                groupControl1.Visible = true;
            }
            else if (chk_user.Checked==false)
            {
                groupControl1.Visible = false;
            }
        }

        private void btn_conferm_user_Click(object sender, EventArgs e)
        {
          bool flag = Convert.ToBoolean(db.GetData("select [user] from emps where emp_no='" + this.txt_code_emp.Text + "'").Rows[0][0].ToString());
      if (flag)
      {
        int num1 = (int) XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "المستخدم موجود من قبل ", "warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
      else
      {
        if (flag)
          return;
        if (this.txt_pass2.Text == "")
        {
          int num2 = (int) XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "ادخل الباس ورد ", "warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        else if (this.txt_pass1.Text != this.txt_pass2.Text)
        {
          int num3 = (int) XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "كلمه المرور غير متطابقه ", "warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        else
        {
          db.Run("update emps set password='" + this.txt_pass2.Text + "' where emp_no='" + this.txt_code_emp.Text + "' ");
          db.Run("insert into permission (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','inventory_management','False')");
          db.Run("insert into permission (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','purchase_management','False')");
          db.Run("insert into permission (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','purchase_reports','False')");
          db.Run("insert into permission (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','sales_management','False')");
          db.Run("insert into permission (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','account_management','False')");
          db.Run("insert into permission (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','hr_management','False')");
          db.Run("insert into permission (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','statistics_reports','False')");
          db.Run("insert into permission (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','inventory_reports','False')");
          db.Run("insert into permission (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','sales_reports','False')");
          db.Run("insert into permission (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','account_reports','False')");
          db.Run("insert into permission (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','hr_reports','False')");
          db.Run("insert into permission (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','settings','False')");
          db.Run("insert into permission (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','maintenance','False')");
          db.Run("insert into permission (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','bank_mangement','False')");
          db.Run("insert into permission (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','manf_mangament','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','inv1','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','inv2','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','inv3','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','inv4','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','inv5','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','inv6','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','inv7','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','inv8','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','inv9','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','inv10','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','inv11','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','pur1','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','pur2','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','pur3','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','pur4','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','pur5','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','pur6','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','sal1','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','sal2','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','sal3','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','sal4','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','sal5','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','sal6','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','acc1','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','acc2','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','acc3','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','acc4','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','acc5','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','acc6','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','acc7','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','hr1','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','hr2','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','hr3','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','hr4','False')");
                    db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','hr5','False')");

                    db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','pl1','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','pl2','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','mnf1','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','mnf2','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','mnf3','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','mnf4','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','mnf5','False')");
          db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','mnf6','False')");
          db.Run("insert into permission_sub (user_code,user_name,name_frm,[save], [delete], edit_only, add_only, [print]) values ('" + this.txt_code_emp.Text + "','" + this.txt_user_name.Text + "','purchase','False','False','False','False','False')");
          db.Run("insert into permission_sub (user_code,user_name,name_frm,[save], [delete], edit_only, add_only, [print]) values ('" + this.txt_code_emp.Text + "','" + this.txt_user_name.Text + "','repurchase','False','False','False','False','False')");
          db.Run("insert into permission_sub (user_code,user_name,name_frm,[save], [delete], edit_only, add_only, [print]) values ('" + this.txt_code_emp.Text + "','" + this.txt_user_name.Text + "','sales','False','False','False','False','False')");
          db.Run("insert into permission_sub (user_code,user_name,name_frm,[save], [delete], edit_only, add_only, [print]) values ('" + this.txt_code_emp.Text + "','" + this.txt_user_name.Text + "','resale','False','False','False','False','False')");
          db.Run("insert into permission_sub (user_code,user_name,name_frm,[save], [delete], edit_only, add_only, [print]) values ('" + this.txt_code_emp.Text + "','" + this.txt_user_name.Text + "','items','False','False','False','False','False')");
          db.Run("insert into permission_sub (user_code,user_name,name_frm,[save], [delete], edit_only, add_only, [print]) values ('" + this.txt_code_emp.Text + "','" + this.txt_user_name.Text + "','vendor','False','False','False','False','False')");
          db.Run("insert into permission_sub (user_code,user_name,name_frm,[save], [delete], edit_only, add_only, [print]) values ('" + this.txt_code_emp.Text + "','" + this.txt_user_name.Text + "','customer','False','False','False','False','False')");
          db.Run("insert into permission_sub (user_code,user_name,name_frm,[save], [delete], edit_only, add_only, [print]) values ('" + this.txt_code_emp.Text + "','" + this.txt_user_name.Text + "','trans','False','False','False','False','False')");
          db.Run("insert into permission_sub (user_code,user_name,name_frm,[save], [delete], edit_only, add_only, [print]) values ('" + this.txt_code_emp.Text + "','" + this.txt_user_name.Text + "','entry','False','False','False','False','False')");
          db.Run("insert into permission_sub (user_code,user_name,name_frm,[save], [delete], edit_only, add_only, [print]) values ('" + this.txt_code_emp.Text + "','" + this.txt_user_name.Text + "','pay','False','False','False','False','False')");
          db.Run("insert into permission_sub (user_code,user_name,name_frm,[save], [delete], edit_only, add_only, [print]) values ('" + this.txt_code_emp.Text + "','" + this.txt_user_name.Text + "','recev','False','False','False','False','False')");

          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','pos_t_f','false') ");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "', 'pind_inv','false') ");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','delet_inv','false')  ");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','return_inv','false')  ");
                    db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','return_inv_without_noinv','false')  ");
                    db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','expensses','false')  ");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','vcs_code','false')");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','vcs_show','false')");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','sale_price','false')  ");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','discount_rows','false')");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','discount','false')");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','blow_cost','false')");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','state','false')");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','cash','false')");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','exp','false')");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','c_unit','false')");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','c_price_no_taxes','false')  ");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','c_price_taxes','false')");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','c_tot_befor_discount','false')");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','c_discount','false')");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','c_tot_after_discount','false')");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','c_taxes','false')");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','c_incloud_taxes','false') ");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','c_value_taxes','false') ");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','shift','false')");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','state_shift','false') ");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','open_shift','false')  ");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','close_shift','false')");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','det_shift','false') ");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','inventroy','false')");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','code_items','false')");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','balance_qty','false')");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','offer','false')");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','barcode','false') ");           
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','adj','false')");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','purchase','false')");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','inv_pur','false')");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','inv_rpur','false')");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','gl','false')");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','recev_cash','false')");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','pay_cash','false')");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','settings','false')");
          db.Run("insert into pos_permission (user_code,unite,torf)values ('" + this.txt_code_emp.Text + "','report','false')");

                    ////////////permission ///////Hotel
                    db.Run("insert into permission_hotel_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','hot1','False')");
                    db.Run("insert into permission_hotel_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','hot101','False')");
                    db.Run("insert into permission_hotel_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','hot102','False')");
                    db.Run("insert into permission_hotel_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','hot103','False')");
                    db.Run("insert into permission_hotel_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','hot104','False')");
                    db.Run("insert into permission_hotel_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','hot105','False')");
                    db.Run("insert into permission_hotel_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','hot106','False')");
                    db.Run("insert into permission_hotel_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','hot107','False')");
                    db.Run("insert into permission_hotel_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','hot108','False')");
                    db.Run("insert into permission_hotel_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','hot109','False')");
                    db.Run("insert into permission_hotel_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','hot2','False')");
                    db.Run("insert into permission_hotel_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','hot3','False')");
                    db.Run("insert into permission_hotel_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','hot301','False')");
                    db.Run("insert into permission_hotel_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','hot302','False')");
                    db.Run("insert into permission_hotel_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','hot303','False')");
                    db.Run("insert into permission_hotel_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','hot304','False')");
                    db.Run("insert into permission_hotel_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','hot305','False')");





                    db.Run("insert into permission_sub_screen (user_code,name_frm,visible) values ('" + this.txt_code_emp.Text + "','hr4','False')");



                    db.Run("update emps set [user]='True' where emp_no='" + this.txt_code_emp.Text + "' ");
          if (chk_pos.Checked)
            db.Run("update emps set [user_pos]='True' where emp_no='" + this.txt_code_emp.Text + "' ");
          else if (!chk_pos.Checked)
            db.Run("update emps set [user_pos]='False' where emp_no='" + this.txt_code_emp.Text + "' ");
          db.Run("INSERT INTO [permission_price_discount]   ([user_code]           ,[contral_sale_price]           ,[controal_sale_discount]           ,[controal_all_discount]           ,[blow_cost_price]           ,[blow_cost_discount]           ,[blow_cost_all],show_perfect_cost,show_low_price,show_hight_price,show_avg_cost,show_qty,show_acc)     VALUES           ('" + this.txt_code_emp.Text + "','false','False','False','True','True','True','False','False','False','False','False','True')");
         XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "تم اضافه اليوز بنجاح ", "save", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
      }
        }

        private void btn_Save_image_Click(object sender, EventArgs e)
        {

        }

        private void first_image_btn_Click(object sender, EventArgs e)
        {

        }

        private void back_image_btn_Click(object sender, EventArgs e)
        {

        }

        private void next_image_btn_Click(object sender, EventArgs e)
        {

        }

        private void last_image_btn_Click(object sender, EventArgs e)
        {

        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {

        }

        //----------------------confegration image
        //function
        string image_loaction = "";
        private void load_image(string txt_code_items, string lbl_number_pic_)
        {
            try
            {
                 lbl_number_pic.Text = db.GetData("select top 1 id_image from emps_image where emp_no='" + txt_code_items + "'").Rows[0][0].ToString();
            DataTable dt = new DataTable();
            db.GetData_DGV("select image from emps_image where emp_no='" + txt_code_items + "' and id_image='" + lbl_number_pic_ + "'", dt);
            dgv_image.DataSource = dt;
            var da = new SqlDataAdapter(db.cmd);
            var ds = new DataSet();
            da.Fill(ds);
            int count = ds.Tables[0].Rows.Count;
            if (count > 0)
            {
                var data = (Byte[])ds.Tables[0].Rows[count - 1][0];
                var stream = new MemoryStream(data);
                pictureBox1.Image = Image.FromStream(stream);
            }
            DataTable dt_id = new DataTable();
            db.GetData_DGV("select id_image from emps_image where emp_no='" + txt_code_items + "'", dt_id);
            dgv_image.DataSource = dt_id;
            }
            catch (Exception)
            {
                
              
            }
        }


        private void btn_Save_image_Click_1(object sender, EventArgs e)
        {
            if (txt_code_emp.Text != "")
            {
                byte[] image = null;
                FileStream stream = new FileStream(image_loaction, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(stream);
                image = brs.ReadBytes((int)stream.Length);
                db.cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@img", image));
                db.Run("insert into emps_image(emp_no,image) values ('" + txt_code_emp.Text + "',@img)");

                MessageBox.Show("successfully");
                db.cmd.Parameters.Clear();
                image = null;
            }
        }
        private void btn_refresh_Click_1(object sender, EventArgs e)
        {
         load_image(txt_code_emp.Text, lbl_number_pic.Text);
            first_image_btn.PerformClick();
        }

        private void add_image_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "png files (*.png)|*.png|jpg files(*.jpg)|*.jpg|All Files(*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                image_loaction = ofd.FileName.ToString();
                pictureBox1.ImageLocation = image_loaction;
            }
        }

        private void remove_btn_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "هل تريد الحذف!!؟؟؟؟ ", "رسال حذف مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                db.Run("delete from emps_image from emp_no where emp_no='" + txt_code_emp.Text + "' and id_image='" + lbl_number_pic.Text + "'");
            }
            else
            {
                return;
            }
        }

        private void dgv_image_DoubleClick(object sender, EventArgs e)
        {
            string id = dgv_image.CurrentRow.Cells[0].Value.ToString();
            load_image(txt_code_emp.Text, id);
            lbl_number_pic.Text = id;
        }

        private void first_image_btn_Click_1(object sender, EventArgs e)
        {
            string id = db.GetData("select min (id_image) from emps_image where emp_no='" + txt_code_emp.Text + "'").Rows[0][0].ToString();
            load_image(txt_code_emp.Text, id);
            lbl_number_pic.Text = id;
        }

        private void last_image_btn_Click_1(object sender, EventArgs e)
        {
            string id = db.GetData("select max (id_image) from emps_image where emp_no='" + txt_code_emp.Text + "'").Rows[0][0].ToString();
            load_image(txt_code_emp.Text, id);
            lbl_number_pic.Text = id;
        }

        private void back_image_btn_Click_1(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Rows.Clear();
            string st = "";
            st = db.GetData("select min(id_image) from emps_image ").Rows[0][0].ToString();
            int m = int.Parse(st);
            if (int.Parse(lbl_number_pic.Text) <= m)
                MessageBox.Show("اخر ملف");
            else
            {
                int num = +(Int32.Parse(lbl_number_pic.Text) - 1);
                load_image(txt_code_emp.Text, lbl_number_pic.Text);
                lbl_number_pic.Text = num + "";
            } 
        }

        private void next_image_btn_Click_1(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = new DataTable();
                dt.Rows.Clear();
                string st = "";
                st = db.GetData("select max(id_image) from emps_image ").Rows[0][0].ToString();
                int m = int.Parse(st);
                //clearANDauto();
                edit = true;
                if (int.Parse(lbl_number_pic.Text) >= m)
                    MessageBox.Show("اول م ملف");
                else
                {
                    int num = +(Int32.Parse(lbl_number_pic.Text) + 1);
                    load_image(txt_code_emp.Text, lbl_number_pic.Text);
                    lbl_number_pic.Text = num + "";

                }
            }
            catch (Exception)
            {

            } 
        }

        private void comb_emp_SelectedIndexChanged(object sender, EventArgs e)
        {
           // all_comb.load_emp_name(comb_emp);
            try
            {
                txt_code_emp.Text = db.GetData("select emp_no from emps where emp_name='" + comb_emp.Text + "'").Rows[0][0].ToString();

            }
            catch (Exception)
            {

            }
           // DataTable dt = new DataTable();
           // dt.Rows.Clear();
           // txt_code_emp.Text = db.GetData("select min(emp_no) from emps ").Rows[0][0].ToString();
           ////bode_of_navigation();

           // try
           // {

           //     txt_code_emp.Text = db.GetData("select emp_no from emps where emp_no='" + txt_code_emp.Text + "' ").Rows[0][0].ToString();
           //     txt_full_name.Text = db.GetData("select emp_name from emps where emp_no='" + txt_code_emp.Text + "' ").Rows[0][0].ToString();
           //     edit = true;
           //     chk_user.Visible = true;
           //     chk_user.Checked = Convert.ToBoolean(db.GetData("select [user] from emps where emp_no='" + txt_code_emp.Text + "'").Rows[0][0].ToString());
           //     txt_user_name.Text = db.GetData("select isnull(max([user_name]),0) from emps where emp_no='" + txt_code_emp.Text + "' ").Rows[0][0].ToString();
           // }
           // catch (Exception)
           // {
           // }
        }

        private void comb_emp_Click(object sender, EventArgs e)
        {
            all_comb.load_emp_name(comb_emp);

        }

        private void btn_pass_Del_Click(object sender, EventArgs e)
        {
            if (txt_code_emp.Text=="")
            {
                return;
            }
            if (txt_user_name.Text=="")
            {
                return;
            }
            DialogResult dr;
            dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "سيتم تعديل كلمة المرور الي كلمة المرور الاصلية !!؟؟؟؟ ", "رسال تحزير مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                db.Run("update emps set [password]='123' where emp_no='" + txt_code_emp.Text + "' ");
                db.action_delete(txt_user_name.Text +" "+ "تم حذف كلمة المرور خاصة الموظف ", txt_code_emp.Text);
            }

        }
    }
}