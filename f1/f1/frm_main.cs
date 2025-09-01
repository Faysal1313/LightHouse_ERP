using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using Microsoft.Win32;
using DevExpress.XtraEditors;
using Microsoft.SqlServer.Management.Smo;
using f1.Classes;
using System.Diagnostics;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports;
using System.IO;
using System.Threading;
using f1.pos;

namespace f1
{
    public partial class frm_main : RibbonForm
    {
        public frm_main()
        {
            InitializeComponent();
            InitSkinGallery();
            db.Open();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
           
        }
        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }
        //===============function 
        private void load_permission_main()
        {
            //inventory_managment.Visible= (Convert.ToBoolean(db.GetData("select  visible from permission where name_frm='inventory_management' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            //purchase_managment.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission where name_frm='purchase_management' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            //sales_management.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission where name_frm='sales_management' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            //account_management.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission where name_frm='account_management' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            //hr_management.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission where name_frm='hr_management' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            a.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission where name_frm='statistics_reports' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            inventory_reports.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission where name_frm='inventory_reports' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            purchase_reports.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission where name_frm='purchase_reports' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            sales_reports.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission where name_frm='sales_reports' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            account_reports.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission where name_frm='account_reports' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            hr_reports.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission where name_frm='hr_reports' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            settings.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission where name_frm='settings' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            maintenance.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission where name_frm='maintenance' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            //bank_mangement.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission where name_frm='bank_mangement' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            //manf_mangament.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission where name_frm='manf_mangament' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            //plan_mangement.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission where name_frm='manf_mangament' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            inv1.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='inv1' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            inv2.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='inv2' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            inv3.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='inv3' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            inv4.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='inv4' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            inv5.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='inv5' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            inv6.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='inv6' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            inv7.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='inv7' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            inv8.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='inv8' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            inv9.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='inv9' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            inv10.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='inv10' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            inv11.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='inv11' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            pur1.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='pur1' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            pur2.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='pur2' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            pur3.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='pur3' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            pur4.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='pur4' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            pur5.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='pur5' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            pur6.Visible = (Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='pur6' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));

            sal1.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='sal1' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            sal2.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='sal2' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            sal3.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='sal3' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            sal4.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='sal4' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            sal5.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='sal5' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            sal6.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='sal6' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            acc1.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='acc1' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            acc2.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='acc2' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            acc3.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='acc3' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            acc4.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='acc4' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            acc5.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='acc5' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
          // acc.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='acc6' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
          // acc7.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='acc7' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            hr1.Visible=  (Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='hr1' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            hr2.Visible = (Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='hr2' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            hr3.Visible = (Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='hr3' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            hr4.Visible = (Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='hr4' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            hr5.Visible = (Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='hr5' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));

            // hr2.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='acc2' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            // hr3.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='acc3' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            // hr4.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='acc4' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            pl1.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='pl1' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
           pl2.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='pl2' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
           mnf1.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='mnf1' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
           mnf2.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='mnf2' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
           mnf3.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='mnf3' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            mnf4.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='mnf4' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            mnf5.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='mnf5' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            mnf6.Visible=(Convert.ToBoolean(db.GetData("select  visible from permission_sub_screen where name_frm='mnf6' and  user_code='" + v.usercode + "' ").Rows[0][0].ToString()));
            v.expiry = Convert.ToBoolean(db.GetData("select expiry from info_co").Rows[0][0].ToString());
            v.represinttive = Convert.ToBoolean(db.GetData("select representative from info_co").Rows[0][0].ToString());
            v.barcode = Convert.ToBoolean(db.GetData("select barcode from info_co").Rows[0][0].ToString());
            v.currance = Convert.ToBoolean(db.GetData("select currancey from info_co").Rows[0][0].ToString());
            v.discount = Convert.ToBoolean(db.GetData("select discount from info_co").Rows[0][0].ToString());
            v.taxes = Convert.ToBoolean(db.GetData("select taxes from info_co").Rows[0][0].ToString());
            v.chk_e_invoice = Convert.ToBoolean(db.GetData("select invoice_taxes from info_co").Rows[0][0].ToString());
            v.combo_e_type = db.GetData("select type from info_co").Rows[0][0].ToString();
            v.txt_e_rkamtgary = db.GetData("select id from info_co").Rows[0][0].ToString();
            v.txt_e_name_company = db.GetData("select name from  info_co").Rows[0][0].ToString();
            v.txt_e_addrees = db.GetData("select address from  info_co").Rows[0][0].ToString();
            v.txt_e_br_taxes = db.GetData("select branchId from  info_co").Rows[0][0].ToString();
            v.txt_e_country = db.GetData("select country from  info_co").Rows[0][0].ToString();
            v.txt_e_govern = db.GetData("select governate from  info_co").Rows[0][0].ToString();
            v.txt_e_city = db.GetData("select regionCity from  info_co").Rows[0][0].ToString();
            v.txt_e_street = db.GetData("select street from  info_co").Rows[0][0].ToString();
            v.txt_e_build = db.GetData("select buildingNumber from  info_co").Rows[0][0].ToString();
            v.txt_e_post = db.GetData("select postalCode from  info_co").Rows[0][0].ToString();
            v.txt_e_floore = db.GetData("select floor from  info_co").Rows[0][0].ToString();
            v.txt_id = db.GetData("select id_e from  info_co").Rows[0][0].ToString();
            v.txt_secret = db.GetData("select secret_e from  info_co").Rows[0][0].ToString();
            v.combo_e_typecodeitems = db.GetData("select itemType from  info_co").Rows[0][0].ToString();
            v.txt_activity = db.GetData("select taxpayerActivityCode from  info_co").Rows[0][0].ToString();
            v.qty_max_search = Convert.ToInt32(db.GetData("select isnull(max(qty_max_search),0) from info_co").Rows[0][0].ToString());

        }
        private void incode_key()
        {
            if (f1.Properties.Settings.Default.su_hash == secy.decoder((secy.secu2() + "05111504se").Trim()))
            {
                //inventory_managment.Visible=(false);
                //purchase_managment.Visible=(false);
                //sales_management.Visible = false;
                //account_management.Visible=(false);
                //hr_management.Visible=(false);
                ////////statistics_reports.Visible = (false);
                ////////inventory_reports.Visible = (false);
                ////////purchase_reports.Visible = (false);
                ////////sales_reports.Visible = (false);
                ////////account_reports.Visible = (false);
                ////////hr_reports.Visible = (false);
                settings.Visible = true;
                maintenance.Visible = true;
                //bank_mangement.Visible=(false);
                //manf_mangament.Visible=(false);
                //plan_mangement.Visible=(false);

                btn_notification_vendor.Visible = false;
                btn_notification_customer.Visible = false;
            }
            else if (f1.Properties.Settings.Default.su_hash == secy.decoder((secy.secu2() + "05111504ba").Trim()))
            {
                inventory_managment.Visible=(true);
                purchase_managment.Visible=(true);
                sales_management.Visible=(true);
                account_management.Visible=(true);
                hr_management.Visible=(true);
                ////////////statistics_reports.Visible = (true);
                ////////////inventory_reports.Visible = (true);
                ////////////purchase_reports.Visible = (true);
                ////////////sales_reports.Visible = (true);
                ////////////account_reports.Visible = (true);
                ////////////hr_reports.Visible = (true);
                ////////////settings.Visible = (true);
                ////////////maintenance.Visible = (true);

                //  bank_mangement.Visible=(false);
                //  manf_mangament.Visible=(false);
                // plan_mangement.Visible=(false);
                //  navBarGroup1.Visible=(false);

            }
            else if (f1.Properties.Settings.Default.su_hash == secy.decoder((secy.secu2() + "05111504gl").Trim()))
            {
                //inventory_managment.Visible = (false);
                //purchase_managment.Visible = (false);
                //sales_management.Visible = (false);
                //account_management.Visible = (false);
                //hr_management.Visible = (false);
                //statistics_reports.Visible = (false);
                //inventory_reports.Visible = (false);
                //purchase_reports.Visible = (false);
                //sales_reports.Visible = (false);
                account_reports.Visible = (true);
                hr_reports.Visible = (false);
                settings.Visible = (true);
                maintenance.Visible = (true);
                //bank_mangement.Visible = (false);
                //manf_mangament.Visible = (false);
                //plan_mangement.Visible = (false);
            }
            else if (f1.Properties.Settings.Default.su_hash == secy.decoder((secy.secu2() + "05111504pu").Trim()))
            {
               
                //inventory_managment.Visible = (false);
                //purchase_managment.Visible = (false);
                //sales_management.Visible = (false);
                //account_management.Visible = (false);
                //hr_management.Visible = (false);
                //statistics_reports.Visible = (false);
                //inventory_reports.Visible = (false);
                purchase_reports.Visible = (true);
                //sales_reports.Visible = (false);
                account_reports.Visible = (true);
               // hr_reports.Visible = (false);
                settings.Visible = (true);
                maintenance.Visible = (true);
               // bank_mangement.Visible = (false);
               // manf_mangament.Visible = (false);
               // plan_mangement.Visible = (false);
            }
            else if (f1.Properties.Settings.Default.su_hash == secy.decoder((secy.secu2() + "05111504sa").Trim()))
            {
              
                //inventory_managment.Visible = (false);
                //purchase_managment.Visible = (false);
                //sales_management.Visible = (false);
                //account_management.Visible = (false);
                //hr_management.Visible = (false);
                //statistics_reports.Visible = (false);
                //inventory_reports.Visible = (false);
                //purchase_reports.Visible = (false);
                //sales_reports.Visible = (false);
                //account_reports.Visible = (false);
                //hr_reports.Visible = (false);
                settings.Visible = (true);
                maintenance.Visible = (true);
                //bank_mangement.Visible = (false);
                //manf_mangament.Visible = (false);
                //plan_mangement.Visible = (false);
            }
            else if (f1.Properties.Settings.Default.su_hash == secy.decoder((secy.secu2() + "05111504ma").Trim()))
            {

          

                inventory_managment.Visible = (true);
                purchase_managment.Visible = (true);
                sales_management.Visible = (true);
                account_management.Visible = (true);
                hr_management.Visible = (true);
                a.Visible = (true);
                inventory_reports.Visible = (true);
                purchase_reports.Visible = (true);
                sales_reports.Visible = (true);
                account_reports.Visible = (true);
                hr_reports.Visible = (true);
                settings.Visible = (true);
                maintenance.Visible = (true);
                bank_mangement.Visible = (true);
                manf_mangament.Visible = (true);
                plan_mangement.Visible = (true);
            }
            //else
            //{
            //    if (!(f1.Properties.Settings.Default.su_hash == secy.decoder((secy.secu2() + "05111504tr").Trim())))
            //        return;
            //    if (f1.Properties.Settings.Default.trial == 0)
            //        db.Run("Update info_co set t1='" + (object)(Convert.ToInt32(db.GetData("select  t1 from info_co").Rows[0][0].ToString()) + 1) + "'");
            //    if (Convert.ToInt32(db.GetData("select  t1 from info_co").Rows[0][0].ToString()) == 1)
            //    {
            //        int num = (int)MessageBox.Show("تم انتهاء التراخيص البرنامج ");
            //        Application.Exit();
            //    }
            //    this.load_permission_main();
             
            //}
        }

        private void frm_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            RegistryKey SkinName = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\\WINREGISTRY");
            SkinName .SetValue("SkinName",DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName.ToString());
            SkinName.Close();
            // Application.Exit();
            DialogResult dr;
            dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "سيتم الخروج من البرنامج ", "رسالة تـــاكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);


            if (dr == DialogResult.OK)
            {
                foreach (var process in Process.GetProcessesByName("f1"))
                {
                    process.Kill();
                }
            }
            else
            {
                e.Cancel = true;
            }




        }

        private void frm_main_Load(object sender, EventArgs e)
        {
            //to work dashbord or Dataset 
            Properties.Settings.Default["f1ConnectionString"] = db.DBxx;
            Properties.Settings.Default.Save();
            try
            {
                RegistryKey SkinName = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\\WINREGISTRY");
            if (SkinName != null)
            {
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = SkinName.GetValue("SkinName").ToString();
            }

                //RegistryKey subKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\\\\WINREGISTRY");
                //if (subKey != null)
                //    UserLookAndFeel.get_Default().set_SkinName(subKey.GetValue("SkinName").ToString());
                v.current_yaer = Convert.ToInt32(db.GetData("select period  from info_co").Rows[0][0].ToString());

                lbl_user_name.Caption = (v.username);
                lbl_user_code.Caption = (v.usercode);
                lbl_database_name.Caption = (f1.Properties.Settings.Default.db_base);
                //load_permission_main();
                load_permission_main();
                incode_key();

            }
            catch (Exception)
            {
               
                
            }
        }
        private void navBarItem16_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frm_purchase frm = new frm_purchase();
            frm.Show();
        }
        private void navBarItem22_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frm_sale frm = new frm_sale();
            frm.Show();
        }
        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frm_item frm = new frm_item();
            frm.Show();
        }
        private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frm_wares frm = new frm_wares();
            frm.Show();
        }
        private void navBarItem12_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frm_vendor frm = new frm_vendor();
            frm.Show();
        }
        private void navBarItem18_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frm_customer frm = new frm_customer();
            frm.Show();
        }
        private void navBarItem27_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frm_recevable frm = new frm_recevable();
            frm.Show();
        }
        private void navBarItem28_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frm_payable frm = new frm_payable();
            frm.Show();
        }
        private void navBarItem29_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frm_entry frm = new frm_entry();
            frm.Show();
        }
        private void navBarItem30_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frm_emp frm = new frm_emp();
            frm.Show();
        }
        private void navBarItem32_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            hr.frm_empwage frm = new hr.frm_empwage();
            frm.Show();
        }
        private void navBarItem33_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            hr.frm_pay_salary frm = new hr.frm_pay_salary();
            frm.Show();
        }
        private void navBarItem25_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frm_tree frm = new frm_tree();
            frm.Show();
        }
        private void barButtonItem56_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_book frm = new frm_book();
            frm.ShowDialog();
        }
        private void barButtonItem72_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_taxes frm = new frm_taxes();
            frm.Show();
        }
        private void barButtonItem57_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_type frm = new frm_type();
            frm.Show();
        }
        private void combo_qrl_KeyDown(object sender, KeyEventArgs e)//hot keys QRL
        {
            try
            {
                if (combo_qrl.Text == "pu")
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        frm_purchase f = new frm_purchase();
                        f.Show();
                        combo_qrl.Items.Add("pu");
                    }   
                }
                else if (combo_qrl.Text == "ent")
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        frm_entry f = new frm_entry();
                        f.Show();
                        combo_qrl.Items.Add("ent");
                    }   
                }
                else if (combo_qrl.Text == "emp")
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        frm_emp f = new frm_emp();
                        f.Show();
                        combo_qrl.Items.Add("emp");
                    }
                }
                else if (combo_qrl.Text == "sal")
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        frm_sale f = new frm_sale();
                        f.Show();
                        combo_qrl.Items.Add("sal");
                    }
                }
                else if (combo_qrl.Text == "pay")
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        frm_payable f = new frm_payable();
                        f.Show();
                        combo_qrl.Items.Add("pay");
                    }
                }
                else if (combo_qrl.Text == "rec")
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        frm_recevable f = new frm_recevable();
                        f.Show();
                        combo_qrl.Items.Add("rec");
                    }

                }
                else if (combo_qrl.Text == "adjqty")
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        inventory.frm_wizard_adjustment_qty f = new inventory.frm_wizard_adjustment_qty();
                        f.ShowDialog();
                        combo_qrl.Items.Add("adjqty");
                    }
                }
                else if (combo_qrl.Text == "trial")
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        account.frm_trial_bal f = new account.frm_trial_bal();
                        f.ShowDialog();
                        combo_qrl.Items.Add("trial");
                    }

                }
                else if (combo_qrl.Text == "cogs")
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        frm_cogs_adj f = new frm_cogs_adj();
                        f.ShowDialog();
                        combo_qrl.Items.Add("cogs");
                    }
                }
                else if (combo_qrl.Text == "pos")
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        pos.pos_main f = new pos.pos_main();
                        f.Show();
                        combo_qrl.Items.Add("pos");
                    }
                }
                
            }
            catch (Exception)
            {
            }
        }
        private void navBarItem7_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            inventory.frm_wizard_adjustment_qty f = new inventory.frm_wizard_adjustment_qty();
            f.ShowDialog();
        }
        private void barButtonItem65_ItemClick(object sender, ItemClickEventArgs e)
        {
            opening_closing.frm_openig_and_close_wizard f = new opening_closing.frm_openig_and_close_wizard();
            f.ShowDialog();
        }
        private void barButtonItem61_ItemClick(object sender, ItemClickEventArgs e)
        {
            opening_closing.close_db.frm_close_db f = new opening_closing.close_db.frm_close_db();
            f.ShowDialog();
        }
        private void barButtonItem66_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult dr;
            dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "سيتم حذف القيد الافتتاحي !!؟؟؟؟ ", "رسال حذف مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                db.Run("delete from entry where code_entry='-9'");
                // clear();
            }
            else
            {
                return;
            }
        }
        private void barButtonItem74_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult dr;
            dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "سيتم حذف قيد  الاغلاق!!؟؟؟؟ ", "رسال حذف مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                db.Run("delete   from entry where code_entry='-8'");
                db.Run("delete  from entry_trash");
                db.Run("delete from entry_opening_new_years");
                // clear();
            }
            else
            {
                return;
            }
        }
        private void barButtonItem62_ItemClick(object sender, ItemClickEventArgs e)
        {
            opening_closing.frm_opening_qty f = new opening_closing.frm_opening_qty();
            f.ShowDialog();
        }
        private void barButtonItem63_ItemClick(object sender, ItemClickEventArgs e)
        {
            opening_closing.frm_opening_vcs f = new opening_closing.frm_opening_vcs();
            f.ShowDialog();
        }
        private void barButtonItem64_ItemClick(object sender, ItemClickEventArgs e)
        {
            opening_closing.frm_opening_entry f = new opening_closing.frm_opening_entry();
            f.ShowDialog();
        }
        private void barButtonItem58_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_permissions f = new frm_permissions();
            f.ShowDialog();
        }
        private void barButtonItem68_ItemClick(object sender, ItemClickEventArgs e)//backup
        {
            //    string namedb = f1.Properties.Settings.Default.db_base;
            //    string d = DateTime.Now.ToString("yyyy-MM-dd----hh--mm--ss" + namedb);
            //    SaveFileDialog open = new SaveFileDialog();
            //    open.Filter = "Backup File(*.back)|*.back";
            //    open.FileName = "backup_" + d;
            //    if (open.ShowDialog() == DialogResult.OK)
            //    {
            //        db.Open();
            //        //db.Run("backup database " + db.dbname + " to Disk ='" + open.FileName + "'");
            //        db.Run("backup database " + namedb + " to Disk ='" + open.FileName + "'");

            //        XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "Backup is complet ", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            try
            {
                string namedb = f1.Properties.Settings.Default.db_base;
                string d = DateTime.Now.ToString("yyyy-MM-dd----hh--mm--ss" + namedb);
                SaveFileDialog open = new SaveFileDialog();
                open.Filter = "Backup File(*.back)|*.back";
                open.FileName = "backup_" + d;
                if (open.ShowDialog() == DialogResult.OK)
                {
                    db.Open();
                    db.Run("backup database " + namedb + " to Disk ='" + open.FileName + "'");
                    zip(open.FileName + "");
                    XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "Backup is complet ", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    File.Delete(open.FileName + "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void zip(string file)
        {
            string fileName = file;
            Thread thread = new Thread(t =>
            {
                using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile())
                {
                    FileInfo fi = new FileInfo(fileName);
                    zip.AddFile(fileName);
                    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(fileName);
                    //zip.SaveProgress += zip_saveprogressfile;
                    zip.Save(string.Format("{0}/{1}.zip", di.Parent.FullName, fi.Name));
                }
            });
            //{IsBackground=true };
            thread.Start();
        }
        private void barButtonItem67_ItemClick(object sender, ItemClickEventArgs e)//restor database
        {
            string db_smo = "";
            db_smo = lbl_user_code.Caption;
          //  MessageBox.Show(db_smo);
            Server server = new Server(Properties.Settings.Default.server);
            Microsoft.SqlServer.Management.Smo.Database db = server.Databases[db_smo];
            if (db != null)
            {
                server.KillAllProcesses(db.Name);
                //server.KillAllProcesses("f1");

            }
            Microsoft.SqlServer.Management.Smo.Restore restore = new Microsoft.SqlServer.Management.Smo.Restore();
           restore.Database = db.Name;
          //  restore.Database = "f1";

            restore.Action = RestoreActionType.Database;

            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Backup File(*.back)|*.back";
            if (open.ShowDialog() == DialogResult.OK)
            {
                restore.Devices.AddDevice(open.FileName, DeviceType.File);
                restore.ReplaceDatabase = true;
                restore.NoRecovery = false;
                restore.SqlRestore(server);
                MessageBox.Show("restore is complet");
            }
        }
        private void barButtonItem77_ItemClick(object sender, ItemClickEventArgs e)
        {
            Process.Start("Autobackup\\Form_autobakup.exe");
        }

        private void barButtonItem71_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_info_co f = new frm_info_co();
            f.ShowDialog();
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            frm_recevable f = new frm_recevable();
            f.Show();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frm_payable f = new frm_payable();
            f.Show();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                int c = Convert.ToInt16(db.GetData("select isnull(count(code_items),0) from center ").Rows[0][0].ToString());
                if (c > 0)
                {
                    btn_notficaion.Visible = true;
                }
                else
                {
                    btn_notficaion.Visible = false;
                }
                //====pay monye from vendor
                int v = Convert.ToInt16(db.GetData("select isnull(count(due_Date),0) from purchase_hd where (DATEDIFF(day, date_P , due_date ))<=5 ").Rows[0][0].ToString());
                if (v > 0)
                {
                    btn_notification_vendor.Visible = true;
                }
                else
                {
                    btn_notification_vendor.Visible = false;
                }
                //====colect mony for customer
                int cu = Convert.ToInt16(db.GetData("select isnull(count(due_Date),0) from sale_hd where (DATEDIFF(day, date_P , due_date ))<=5 --and sale_hd.vcs_value < 0 ").Rows[0][0].ToString());
                if (cu > 0)
                {
                    btn_notification_customer.Visible = true;
                }
                else
                {
                    btn_notification_customer.Visible = false;
                }
            }
            catch (Exception)
            {
            }
        }
        
        private void barButtonItem80_ItemClick(object sender, ItemClickEventArgs e)
        {
            db.Run("delete  from entry where code_entry >'-11' delete from entry_hd \n delete from exp_date \n delete from pay_dt \n delete from pay_hd \n delete from purchase_dt \n delete from purchase_hd \n delete from sale_dt \n delete from sale_hd \n delete from items_trans \n delete from opening_qty  \n  update wares set qty ='0'  \n update wares set cost='0' \n delete from center  \n  delete from recev_hd  \n  delete from recev_dt \n delete from pay_dt  \n  delete from pay_hd \n  delete from trans_dt \n delete  from trans_hd");
            MessageBox.Show("record has benn deleted");
        }
        private void barButtonItem88_ItemClick(object sender, ItemClickEventArgs e)
        {
            Classes.frm_excel_purchase f= new Classes.frm_excel_purchase();
            f.ShowDialog();
        }
        private void barButtonItem89_ItemClick(object sender, ItemClickEventArgs e)
        {
            //import_excel.frm_excel_sale f = new import_excel.frm_excel_sale();
            //f.ShowDialog();
            //Form2 f = new Form2();
            //f.Show();
            //1-get path ex and mak database file is empty
            //string path = @"D:\\Program\\project\\excel_import\\excel_import\\bin\\Debug\\test1.txt";
            string path = @"Import Excelapp\test1.txt";
            File.WriteAllText(path, String.Empty);

            //2-make database file have connectionstring 

            string ip = Properties.Settings.Default.server;
            string db = Properties.Settings.Default.db_base;
            string sql_user = Properties.Settings.Default.sql_name;
            string sql_pass = Properties.Settings.Default.sql_pass;

            string conn_string = "Data Source=" + ip + " ;Initial Catalog=" + db + " ;Integrated Security=False ; USER ID='" + sql_user + "' ; Password='" + sql_pass + "'";


            StreamWriter streamWriter = new StreamWriter(path, true);
            streamWriter.WriteLine(conn_string);
            streamWriter.Close();

            //3-open Aplcations

            Process.Start(@"Import Excelapp\excel_import.exe");
           

        }
        private void barButtonItem85_ItemClick(object sender, ItemClickEventArgs e)
        {
            import_excel.frm_excel_items f = new import_excel.frm_excel_items();
            f.ShowDialog();
        }
        private void barButtonItem87_ItemClick(object sender, ItemClickEventArgs e)
        {
            import_excel.frm_excel_vcs f = new import_excel.frm_excel_vcs();
            f.ShowDialog();
        }

        private void btn_currance_ItemClick(object sender, ItemClickEventArgs e)
        {
            account.frm_currance f = new account.frm_currance();
            f.ShowDialog();
        }

        private void navBarItem11_ItemChanged(object sender, EventArgs e)
        {
          
        }

        private void navBarItem11_ItemChanged(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            inventory.frm_limit_maximum_qty f = new inventory.frm_limit_maximum_qty();
            f.Show();
        }
        //========notification
        private void btn_notification_vendor_Click(object sender, EventArgs e)
        {
            notification.frm_notif_depit f = new notification.frm_notif_depit();
            f.Show();
        }

        private void btn_notification_customer_Click(object sender, EventArgs e)
        {
            notification.frm_notif_recev f = new notification.frm_notif_recev();
            f.Show();
        }
        private void btn_notficaion_Click(object sender, EventArgs e)
        {
            frm_notficaion f = new frm_notficaion();
            f.ShowDialog();
        }
        //=====================

        private void barButtonItem27_ItemClick(object sender, ItemClickEventArgs e)
        {
            Purchase.report_purchase.frm_purchase_invoice_report f = new Purchase.report_purchase.frm_purchase_invoice_report();
            f.Show();
        }

        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void barButtonItem12_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            inventory.printer_items.report_items.frm_rep_items_card f = new inventory.printer_items.report_items.frm_rep_items_card();
           f.ShowDialog();

        }

        private void barButtonItem22_ItemClick(object sender, ItemClickEventArgs e)
        {
            //  inventory.printer_items.report_items.frm_rbt_trial_item_cost_and_sale_value f = new inventory.printer_items.report_items.frm_rbt_trial_item_cost_and_sale_value();
            pos.frm_balance_qty f = new pos.frm_balance_qty();
            //frm_rbt_trial_item_cost_and_sale_value
            f.ShowDialog();
        }

        private void barButtonItem42_ItemClick(object sender, ItemClickEventArgs e)
        {
            //account.report_account.frm_rbt_Trial_balance_general f = new account.report_account.frm_rbt_Trial_balance_general();
            //f.ShowDialog();
            account.report_account.report_screen.sc_trial_main f = new account.report_account.report_screen.sc_trial_main();
            f.ShowDialog();
        }

        private void barButtonItem43_ItemClick(object sender, ItemClickEventArgs e)
        {
            account.report_account.frm_rpt_Trial_balance_customer f = new account.report_account.frm_rpt_Trial_balance_customer();
            f.ShowDialog();
        }

        private void barButtonItem44_ItemClick(object sender, ItemClickEventArgs e)
        {
            account.report_account.frm_rpt_Trial_balance_vendor f = new account.report_account.frm_rpt_Trial_balance_vendor();
            f.ShowDialog();
        }

        private void barButtonItem41_ItemClick(object sender, ItemClickEventArgs e)
        {
            //account.report_account.frm_rpt_report_acc_statment_gl f = new account.report_account.frm_rpt_report_acc_statment_gl();
            //f.ShowDialog();
            account.report_account.report_screen.sc_general_entry f = new account.report_account.report_screen.sc_general_entry();
            f.Show();
        }

        private void barButtonItem90_ItemClick(object sender, ItemClickEventArgs e)
        {
            //account.report_account.frm_rpt_report_acc_statment_vcs f = new account.report_account.frm_rpt_report_acc_statment_vcs();
            //f.ShowDialog();

            account.report_account.report_screen.sc_statment_gl f = new account.report_account.report_screen.sc_statment_gl();
            f.ShowDialog();



        }

        private void barButtonItem91_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\action.repx", true);
            //xtraReport.Parameters["parameter1"].Value = "102";
            //xtraReport.Parameters["parameter1"].Visible = false;
            //xtraReport.Parameters["parameter1"].Value = dt_piker.Value.ToString("yyyy/MM/dd");
            //xtraReport.Parameters["parameter1"].Visible = false;
            //xtraReport.Parameters["parameter2"].Value = dt_piker2.Value.ToString("yyyy/12/31");
            //xtraReport.Parameters["parameter2"].Visible = false;
            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
        }

        private void barButtonItem35_ItemClick(object sender, ItemClickEventArgs e)
        {

            v.search_screen = "sales_rep";
            screen_rep_main f = new screen_rep_main();
            f.Show();
            ////Purchase.report_purchase.frm_purchase_invoice_report f= new Purchase.report_purchase.frm_purchase_invoice_report();
            ////f.Show();
            //XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\sales_tot.repx", true);
            ////xtraReport.Parameters["parameter1"].Value = "102";
            ////xtraReport.Parameters["parameter1"].Visible = false;
            ////xtraReport.Parameters["parameter1"].Value = dt_piker.Value.ToString("yyyy/MM/dd");
            ////xtraReport.Parameters["parameter1"].Visible = false;
            ////xtraReport.Parameters["parameter2"].Value = dt_piker2.Value.ToString("yyyy/12/31");
            ////xtraReport.Parameters["parameter2"].Visible = false;
            //XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
        }

        private void barButtonItem31_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\items_profit.repx", true);
            //xtraReport.Parameters["parameter1"].Value = "102";
            //xtraReport.Parameters["parameter1"].Visible = false;
            //xtraReport.Parameters["parameter1"].Value = dt_piker.Value.ToString("yyyy/MM/dd");
            //xtraReport.Parameters["parameter1"].Visible = false;
            //xtraReport.Parameters["parameter2"].Value = dt_piker2.Value.ToString("yyyy/12/31");
            //xtraReport.Parameters["parameter2"].Visible = false;
            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
        }

        private void barButtonItem34_ItemClick(object sender, ItemClickEventArgs e)
        {
            sales.sales_report.sale_forms.frm_rbt_sales_invoice_profit f = new sales.sales_report.sale_forms.frm_rbt_sales_invoice_profit();
            f.ShowDialog();
            
        }
        private void barButtonItem32_ItemClick(object sender, ItemClickEventArgs e)//items max or min
        {
            sales.sales_report.frm_max_min_items frm = new sales.sales_report.frm_max_min_items();
            frm.ShowDialog();
        }
        private void barButtonItem47_ItemClick(object sender, ItemClickEventArgs e)//income
        {
            //==
            db.Run("delete from main_sub");
            DataTable dtt = new DataTable();
            db.GetData_DGV("select  entry.acc_num,entry.rootlevel from entry where  sort='f'  group by entry.acc_num, entry.acc_name,rootlevel ,type_acc ", dtt);
            //    db.GetData_DGV("select  entry.acc_num,entry.rootlevel from entry where  sort='f'  group by entry.acc_num, entry.acc_name,rootlevel ,type_acc ", dt);

            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                db.Run("insert into main_sub(acc_num,acc_name,value,rootlevel) values('" + dtt.Rows[i][0] + "',(select acc_name from entry where acc_num='" + dtt.Rows[i][0] + "'),(select  sum(depit-credit) from entry where SUBSTRING(rootlevel, 1, 4)='" + dtt.Rows[i][1] + "'),(select rootlevel from entry where acc_num='" + dtt.Rows[i][0] + "'))");
            }

            //=============================================
            DataTable dt = new DataTable();

            // db.cmd.Parameters.Add("2020-01-06");
            db.GetData_DGV(("  select  main_sub.value as tot_sub ,entry.acc_num, entry.acc_name,entry.rootlevel,entry.type_acc,(sum(entry.depit)) as depitbal,sum(entry.credit) as creditbal,(sum(entry.depit)) -sum(entry.credit) as def,sum(opening_bal) as opening_bal from entry  left join main_sub on entry.acc_num= main_sub.acc_num left join tree on entry.acc_num = tree.rootid where  tree.sort='قائمه دخل' group by entry.acc_num, entry.acc_name,entry.rootlevel ,entry.type_acc ,main_sub.value,main_sub.acc_name order by entry.rootlevel "), dt);

            
           
        }
        private void barButtonItem48_ItemClick(object sender, ItemClickEventArgs e)//blance_sheet
        {
            //=============================================
            db.Run("delete from main_sub");
            DataTable dtt = new DataTable();
            db.GetData_DGV("select  entry.acc_num,entry.rootlevel from entry where  sort='f'  group by entry.acc_num, entry.acc_name,rootlevel ,type_acc ", dtt);
            //    db.GetData_DGV("select  entry.acc_num,entry.rootlevel from entry where  sort='f'  group by entry.acc_num, entry.acc_name,rootlevel ,type_acc ", dt);

            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                db.Run("insert into main_sub(acc_num,acc_name,value,rootlevel) values('" + dtt.Rows[i][0] + "',(select acc_name from entry where acc_num='" + dtt.Rows[i][0] + "'),(select  sum(depit-credit) from entry where SUBSTRING(rootlevel, 1, 4)='" + dtt.Rows[i][1] + "'),(select rootlevel from entry where acc_num='" + dtt.Rows[i][0] + "'))");
            }

            //=============================================
            DataTable dt = new DataTable();

            db.GetData_DGV((" select  main_sub.value as tot_sub ,entry.acc_num, entry.acc_name,entry.rootlevel,entry.type_acc,(sum(entry.depit)) as depitbal,sum(entry.credit) as creditbal,(sum(entry.depit)) -sum(entry.credit) as def,sum(opening_bal) as opening_bal from entry  left join main_sub on entry.acc_num= main_sub.acc_num left join tree on entry.acc_num = tree.rootid where  tree.sort='ميزانيه' group by entry.acc_num, entry.acc_name,entry.rootlevel ,entry.type_acc ,main_sub.value,main_sub.acc_name order by entry.rootlevel  "), dt);

           
        }

        private void barButtonItem25_ItemClick(object sender, ItemClickEventArgs e)//vendor
        {
            XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\vendor.repx", true);


            

            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);




        }

        private void barButtonItem30_ItemClick(object sender, ItemClickEventArgs e)//clint
        {
            XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\customer.repx", true);

            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);

        }

        private void barButtonItem37_ItemClick(object sender, ItemClickEventArgs e)//tree
        {
            XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\tree_acc.repx", true);
            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);

        }

        private void barButtonItem53_ItemClick(object sender, ItemClickEventArgs e)//emp
        {
            XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\emp_list.repx", true);
            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
        }

        private void barButtonItem38_ItemClick(object sender, ItemClickEventArgs e)//recev
        {
            //recev
            //XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\recev_voucher.repx", true);
            //XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
            account.report_account.report_screen.sc_recever f = new account.report_account.report_screen.sc_recever();
            f.Show();
        }

        private void barButtonItem39_ItemClick(object sender, ItemClickEventArgs e)//payable
        {
            //XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\pay_voucher.repx", true);
            //XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);

            account.report_account.report_screen.sc_payable f = new account.report_account.report_screen.sc_payable();
            f.Show();
        }

        private void barButtonItem46_ItemClick(object sender, ItemClickEventArgs e)//taxes on clint or vendor
        {
            account.report_account.frm_rpt_costcenter_statment f = new account.report_account.frm_rpt_costcenter_statment();
            f.Show();
        }

        private void barButtonItem93_ItemClick(object sender, ItemClickEventArgs e)//items
        {
            XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\item.repx", true);
            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            sales.sales_report.frm_max_min_items frm = new sales.sales_report.frm_max_min_items();
            frm.ShowDialog();
        }

        private void barButtonItem18_ItemClick(object sender, ItemClickEventArgs e)
        {
            sales.sales_report.frm_max_min_items frm = new sales.sales_report.frm_max_min_items();
            frm.ShowDialog();
        }

        private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            inventory.frm_trans_items f = new inventory.frm_trans_items();
            f.Show();
        }

        private void pur6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Purchase.frm_rpurchase f = new Purchase.frm_rpurchase();
            f.Show();
        }

        private void sal6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            sales.frm_rsale f = new sales.frm_rsale();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pos.pos_main f = new pos.pos_main();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_emp f = new frm_emp();
            f.Show();
        }

        private void barButtonItem95_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_desgin_report_main f = new frm_desgin_report_main();
            f.Show();
        }

        private void barButtonItem94_ItemClick(object sender, ItemClickEventArgs e)
        {
           // Process.Start("https://www.ad4sas.com/");
        }

        private void barButtonItem98_ItemClick(object sender, ItemClickEventArgs e)
        {
            Process.Start("https://www.ad4sas.com/");

        }

        private void barButtonItem103_ItemClick(object sender, ItemClickEventArgs e)
        {
            account.report_account.report_finance_statment.frm_schema_statment f = new account.report_account.report_finance_statment.frm_schema_statment();
            f.Show();
        }

        private void barButtonItem104_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_report f = new frm_report();
            f.Show();
        }

        private void barButtonItem47_incom_stat_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\statment_templet.repx", true);
            xtraReport.Parameters["parameter1"].Value ="101";
            xtraReport.Parameters["parameter1"].Visible = false;
            //xtraReport.Parameters["parameter1"].Value = dt_piker.Value.ToString("yyyy/MM/dd");
            //xtraReport.Parameters["parameter1"].Visible = false;
            //xtraReport.Parameters["parameter2"].Value = dt_piker2.Value.ToString("yyyy/12/31");
            //xtraReport.Parameters["parameter2"].Visible = false;
            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);

        }

        private void barButtonItem106_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\statment_templet.repx", true);
            xtraReport.Parameters["parameter1"].Value = "102";
            xtraReport.Parameters["parameter1"].Visible = false;
            //xtraReport.Parameters["parameter1"].Value = dt_piker.Value.ToString("yyyy/MM/dd");
            //xtraReport.Parameters["parameter1"].Visible = false;
            //xtraReport.Parameters["parameter2"].Value = dt_piker2.Value.ToString("yyyy/12/31");
            //xtraReport.Parameters["parameter2"].Visible = false;
            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);

        }

        private void barButtonItem105_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\statment_templet.repx", true);
            xtraReport.Parameters["parameter1"].Value = "103";
            xtraReport.Parameters["parameter1"].Visible = false;
            //xtraReport.Parameters["parameter1"].Value = dt_piker.Value.ToString("yyyy/MM/dd");
            //xtraReport.Parameters["parameter1"].Visible = false;
            //xtraReport.Parameters["parameter2"].Value = dt_piker2.Value.ToString("yyyy/12/31");
            //xtraReport.Parameters["parameter2"].Visible = false;
            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);

        }

        private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem47_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            // inventory.printer_items.report_items.frm_rep_items_card f = new inventory.printer_items.report_items.frm_rep_items_card();
            pos.frm_items_card f = new pos.frm_items_card();
            f.ShowDialog();

        }

        private void barButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\dash1.repx", true);
            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\dash2.repx", true);
            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
        }
        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\dash3.repx", true);
            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\dash4.repx", true);
            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\dash5.repx", true);
            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\dash6.repx", true);
            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
        }

        private void barButtonItem108_ItemClick(object sender, ItemClickEventArgs e)
        {
            ((Control)new pos.pos_main()).Show();
        }

        private void iHelp_ItemClick(object sender, ItemClickEventArgs e)
        {
            Process.Start("https://www.youtube.com/playlist?list=PLYYCXuplKeU3dNfvA_xB9PdSHfulQkyZ9");
        }

        private void inv10_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            pos.frm_offer f = new pos.frm_offer();
            f.Show();
        }

        private void barButtonItem19_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\demand_limit.repx", true);
            //xtraReport.Parameters["parameter1"].Value = combo_code_items.Text;
            //xtraReport.Parameters["parameter1"].Visible = true;
            //xtraReport.Parameters["parameter2"].Value = combo_wars.Text;
            //xtraReport.Parameters["parameter2"].Visible = true;
            //xtraReport.Parameters["parameter3"].Value = combo_unite.Text;
            //xtraReport.Parameters["parameter3"].Visible = true;
            //xtraReport.Parameters["parameter5"].Value = d1.Value.ToString("yyyy/MM/dd");
            //xtraReport.Parameters["parameter5"].Visible = true;
            //xtraReport.Parameters["parameter6"].Value = d2.Value.ToString("yyyy/MM/dd");
            //xtraReport.Parameters["parameter6"].Visible = true;

            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
        }

        private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
        {
            pos.frm_balance_qty f = new pos.frm_balance_qty();
            f.Show();
        }

        private void barButtonItem26_ItemClick(object sender, ItemClickEventArgs e)
        {
            v.search_screen = "purchase_rep";
            screen_rep_main f = new screen_rep_main();
            f.Show();

            //XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\purchase_tot.repx", true);
            ////xtraReport.Parameters["parameter1"].Value = "102";
            ////xtraReport.Parameters["parameter1"].Visible = false;
            ////xtraReport.Parameters["parameter1"].Value = dt_piker.Value.ToString("yyyy/MM/dd");
            ////xtraReport.Parameters["parameter1"].Visible = false;
            ////xtraReport.Parameters["parameter2"].Value = dt_piker2.Value.ToString("yyyy/12/31");
            ////xtraReport.Parameters["parameter2"].Visible = false;
            //XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
        }

        private void barButtonItem33_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\sales_invoice_profit.repx", true);
            //xtraReport.Parameters["parameter1"].Value = "102";
            //xtraReport.Parameters["parameter1"].Visible = false;
            //xtraReport.Parameters["parameter1"].Value = dt_piker.Value.ToString("yyyy/MM/dd");
            //xtraReport.Parameters["parameter1"].Visible = false;
            //xtraReport.Parameters["parameter2"].Value = dt_piker2.Value.ToString("yyyy/12/31");
            //xtraReport.Parameters["parameter2"].Visible = false;
            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
        }

        private void barButtonItem24_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\items_opening.repx", true);
            //xtraReport.Parameters["parameter1"].Value = "102";
            //xtraReport.Parameters["parameter1"].Visible = false;
            //xtraReport.Parameters["parameter1"].Value = dt_piker.Value.ToString("yyyy/MM/dd");
            //xtraReport.Parameters["parameter1"].Visible = false;
            //xtraReport.Parameters["parameter2"].Value = dt_piker2.Value.ToString("yyyy/12/31");
            //xtraReport.Parameters["parameter2"].Visible = false;
            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
        }

        private void barButtonItem96_ItemClick(object sender, ItemClickEventArgs e)
        {
            Process.Start("https://www.youtube.com/playlist?list=PLYYCXuplKeU3dNfvA_xB9PdSHfulQkyZ9");
        }

        private void navBarItem1_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ship_jop.frm_truck f = new ship_jop.frm_truck();
            f.Show();
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ship_jop.frm_storehouse f = new ship_jop.frm_storehouse();
            f.Show();
        }

        private void navBarItem3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ship_jop.frm_station f = new ship_jop.frm_station();
            f.Show();
        }

        private void navBarItem5_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ship_jop.frm_jop_number f = new ship_jop.frm_jop_number();
            f.Show();
        }

        private void navBarItem6_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ship_jop.frm_consolidated_invoice f = new ship_jop.frm_consolidated_invoice();
            f.Show();
        }

        private void acc2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            account.frm_costcenter f = new account.frm_costcenter();
            f.Show();

        }

        private void inv4_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            inventory.frm_issuer f = new inventory.frm_issuer();
            
            f.Show();
        }

        private void inv3_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            inventory.frm_recever f = new inventory.frm_recever();
            f.Show();
        }

        private void barButtonItem79_ItemClick(object sender, ItemClickEventArgs e)
        {
            frm_imliment_hotel f = new frm_imliment_hotel();
            f.Show();
        }
    }
}