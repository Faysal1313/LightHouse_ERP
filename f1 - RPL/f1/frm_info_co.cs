using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using System.IO;
using System.Data.SqlClient;

namespace f1
{
    public partial class frm_info_co : DevExpress.XtraEditors.XtraForm
    {
        public frm_info_co()
        {
            db.Open();
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
            load_printer_divec();
            load_printer_divec_barcode();
            load_printer_divec_a4();
            load_printer_divec2();
            load_image();
            all_comb.load_taxes(combo_taxes);

        }

        private void frm_info_co_Load(object sender, EventArgs e)
        {
            //load main
            lbl_period.Text = (v.current_yaer)+"";
            txt_com_name.Text = db.GetData("select name_of_company from info_co").Rows[0][0].ToString();
            txt_tel1.Text = db.GetData("select tel1 from  info_co").Rows[0][0].ToString();
            txt_tel2.Text = db.GetData("select tel2 from  info_co").Rows[0][0].ToString();
            txt_mob1.Text = db.GetData("select mob1 from  info_co").Rows[0][0].ToString();
            txt_mob2.Text = db.GetData("select mob2 from  info_co").Rows[0][0].ToString();
            txt_fax.Text = db.GetData("select fax from  info_co").Rows[0][0].ToString();
            txt_email.Text = db.GetData("select email from  info_co").Rows[0][0].ToString();
            txt_facebook.Text = db.GetData("select facebook from  info_co").Rows[0][0].ToString();
            txt_wep.Text = db.GetData("select wepsite from  info_co").Rows[0][0].ToString();
            txt_address1.Text = db.GetData("select address1 from  info_co").Rows[0][0].ToString();
            txt_address2.Text = db.GetData("select address2 from  info_co").Rows[0][0].ToString();
            txt_address2.Text = db.GetData("select address2 from  info_co").Rows[0][0].ToString();



            num_period_rsal.Value= Convert.ToInt32(db.GetData("select isnull(max(period_time_rsal_pos),0) from info_co").Rows[0][0].ToString());
            num_bonace.Text = Convert.ToString(db.GetData("select isnull(max(bonace),0) from info_co").Rows[0][0].ToString());
            txt_def_nameUnite.Text = db.GetData("select top 1 def_name_unite from info_co").Rows[0][0].ToString();

            //load chk
            chk_expiry.Checked = Convert.ToBoolean(db.GetData("select expiry from info_co").Rows[0][0].ToString());
            chk_represinttive.Checked = Convert.ToBoolean(db.GetData("select representative from info_co").Rows[0][0].ToString());
            chk_barcode.Checked = Convert.ToBoolean(db.GetData("select barcode from info_co").Rows[0][0].ToString());
            chk_currance.Checked = Convert.ToBoolean(db.GetData("select currancey from info_co").Rows[0][0].ToString());
            chk_discount.Checked = Convert.ToBoolean(db.GetData("select discount from info_co").Rows[0][0].ToString());
            chk_taxes.Checked = Convert.ToBoolean(db.GetData("select taxes from info_co").Rows[0][0].ToString());
            chk_cost_Center_mund.Checked= Convert.ToBoolean(db.GetData("select costCenter_mund from info_co").Rows[0][0].ToString());


            txt_cat1.Text = db.GetData("select isnull(max(cat_items1),'-') from info_co").Rows[0][0].ToString();
            txt_cat2.Text = db.GetData("select isnull(max(cat_items2),'-') from info_co").Rows[0][0].ToString();
            txt_cat3.Text = db.GetData("select isnull(max(cat_items3),'-') from info_co").Rows[0][0].ToString();
            txt_cat4.Text = db.GetData("select isnull(max(cat_items4),'-') from info_co").Rows[0][0].ToString();

            num_qty_max_search.Value= Convert.ToInt32(db.GetData("select isnull(max(qty_max_search),'-') from info_co").Rows[0][0].ToString());

            //load printer
            combo_printer_recept1.Text = Properties.Settings.Default.printer_name;
            combo_barcode.Text = Properties.Settings.Default.printer_name_barcode;
            combo_printer_recept2.Text = Properties.Settings.Default.printer_name2;
            combo_printer_a4.Text = Properties.Settings.Default.printer_a4;


            combo_taxes.Text = db.GetData("select def_taxes from info_co").Rows[0][0].ToString();


            txt_id_E.Text = db.GetData("select isnull(max(id),'') from info_co ").Rows[0][0].ToString();
            txt_name_E.Text= db.GetData("select isnull(max(name),'') from info_co ").Rows[0][0].ToString();
            txt_governate_E.Text= db.GetData("select isnull(max( governate ),'') from info_co ").Rows[0][0].ToString();
            txt_regionCity_E.Text = db.GetData("select isnull(max( regionCity ),'') from info_co ").Rows[0][0].ToString();
            txt_street_E.Text = db.GetData("select isnull(max( street ),'') from info_co ").Rows[0][0].ToString();
            txt_buildingNumber_E.Text = db.GetData("select isnull(max( buildingNumber ),'') from info_co ").Rows[0][0].ToString();
            txt_IDno_E.Text = db.GetData("select isnull(max( id_e ),'') from info_co ").Rows[0][0].ToString();
            txt_secretNO_E.Text = db.GetData("select isnull(max( secret_e ),'') from info_co ").Rows[0][0].ToString();
            txt_taxpayerActivityCode_E.Text = db.GetData("select isnull(max( taxpayerActivityCode ),'') from info_co ").Rows[0][0].ToString();
            txt_pin_Token.Text = db.GetData("select isnull(max( pinToken ),'') from info_co ").Rows[0][0].ToString();
       
            bool enviro = Convert.ToBoolean(db.GetData("select (isLive) from info_co ").Rows[0][0] + "");
            if (enviro)
            {
                rdo_life.Checked=true;
                rdo_test.Checked = false;
            }
            else
            {
                rdo_life.Checked = false;
                rdo_test.Checked = true;
            }

        }
        private void backstageViewTabItem1_SelectedChanged(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
          

        }
        private void backstageViewTabItem2_SelectedChanged(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
           

        }
        private void backstageViewTabItem3_SelectedChanged(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
           

        }
        //1)info comapany 
        //___________________________________
        private void btn_save_main_info_Click(object sender, EventArgs e)
        {
            db.Run("update  info_co  set name_of_company='"+txt_com_name.Text+"' , tel1='"+txt_tel1.Text+"', tel2='"+txt_tel2.Text+"' ,mob1='"+txt_mob1.Text+"' ,mob2='"+txt_mob2.Text+"',fax='"+txt_fax.Text+"',email='"+txt_email.Text+"',facebook='"+txt_facebook.Text+"',wepsite='"+txt_wep.Text+"',address1='"+txt_address1.Text+"',address2='"+txt_address2.Text+"' where period='"+lbl_period.Text+"'");
        }
             //insert logo
        string image_loaction = "";
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
        private void btn_Save_image_Click(object sender, EventArgs e)
        {

            byte[] image = null;
            FileStream stream = new FileStream(image_loaction, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(stream);
            image = brs.ReadBytes((int)stream.Length);
            db.cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@img", image));
            db.Run("update info_co set logo = @img");

            MessageBox.Show("successfully");
            db.cmd.Parameters.Clear();
            image = null;

        }
        private void load_image()
        {
            try
            {
                // lbl_number_pic.Text = db.GetData("select logo from info_co where period='"+lbl_period.Text+"'").Rows[0][0].ToString();
                DataTable dt = new DataTable();
                db.GetData_DGV("select logo from info_co", dt);
                // dgv_image.DataSource = dt;
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
                db.GetData_DGV("select logo from info_co where period='" + lbl_period.Text + "'", dt_id);

                // dgv_image.DataSource = dt_id;
            }
            catch (Exception)
            {


            }
        
        }
        private void remove_btn_Click(object sender, EventArgs e)
        {
            db.Run("update info_co set logo ='' where period='"+lbl_period.Text+"'" );
        }
        private void cliar_simpleButton2_Click(object sender, EventArgs e)
        {
            txt_com_name.Text = "";
            txt_facebook.Text = "";
            txt_mob1.Text = "";
            txt_mob2.Text = "";
            txt_tel1.Text = "";
            txt_tel2.Text = "";
            txt_address1.Text = "";
            txt_address2.Text = "";
            txt_email.Text = "";
            txt_wep.Text = "";
            txt_email.Text="";
            txt_fax.Text = "";
        }
        //2)Forms 
        //__________________________
        private void btn_Save_forms_Click(object sender, EventArgs e)
        {

            db.Run("update info_co set expiry='"+chk_expiry.Checked+"' ,representative='"+chk_represinttive.Checked+"' , barcode='"+chk_barcode.Checked+"', currancey='"+chk_currance.Checked+"', discount='"+chk_discount.Checked+"', taxes='"+chk_taxes.Checked+ "',def_taxes='"+combo_taxes.Text+"',def_name_unite='"+txt_def_nameUnite.Text+ "',period_time_rsal_pos='"+num_period_rsal.Value+"',cat_items1='"+txt_cat1.Text+"',cat_items2='"+txt_cat2.Text+ "',cat_items3='" + txt_cat3.Text + "',cat_items4='" + txt_cat4.Text + "',qty_max_search='"+num_qty_max_search.Value+ "',bonace ='"+num_bonace.Text+ "',costCenter_mund='"+chk_cost_Center_mund.Checked+"'");
            MessageBox.Show("تم التعديل");
        }
        //3)printer and devices
        //_________________________________
       
        public static class myPrinters//install printer
        {
            [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool SetDefaultPrinter(string Name);
        }
        private void load_printer_divec()//read printer_devies recept 1 
        {
            DataTable dt = new DataTable();
            foreach (var i in PrinterSettings.InstalledPrinters)
            {
                combo_printer_recept1.Items.Add(i);
            }
        }
        
        private void load_printer_divec2()//read printer_devies recept 12
        {
            DataTable dt = new DataTable();
            foreach (var i in PrinterSettings.InstalledPrinters)
            {
                combo_printer_recept2.Items.Add(i);
            }
        }
        private void load_printer_divec_a4()//read printer_devies A4
        {
            DataTable dt = new DataTable();
            foreach (var i in PrinterSettings.InstalledPrinters)
            {
                combo_printer_a4.Items.Add(i);
            }
        }
        private void load_printer_divec_barcode()//read printer_devies barcode
        {
            DataTable dt = new DataTable();
            foreach (var i in PrinterSettings.InstalledPrinters)
            {
                combo_barcode.Items.Add(i);
                // listBox1.Items.Add(i);
            }
        }
        private void simpleButton3_Click(object sender, EventArgs e)//recept 1
        {
            string pname = combo_printer_recept1.Text;
            myPrinters.SetDefaultPrinter(pname);
            Properties.Settings.Default.printer_name = pname;
            Properties.Settings.Default.Save();
        }
        private void btn_printer_recept2_Click(object sender, EventArgs e)
        {
            string pname = combo_printer_recept2.Text;
            myPrinters.SetDefaultPrinter(pname);
            Properties.Settings.Default.printer_name2 = pname;
            Properties.Settings.Default.Save();
        }

        private void Btn_barcode_Click(object sender, EventArgs e)
        {
            string pname = combo_barcode.Text;
            myPrinters.SetDefaultPrinter(pname);
            Properties.Settings.Default.printer_name_barcode = pname;
            Properties.Settings.Default.Save();

        }

        private void btn_prenter_a4_Click(object sender, EventArgs e)
        {
            string pname = combo_printer_a4.Text;
            myPrinters.SetDefaultPrinter(pname);
            Properties.Settings.Default.printer_name_barcode = pname;
            Properties.Settings.Default.Save();
        }











        //4)Einvoice
        //____________________________________________________
        private void btn_save_env_Click(object sender, EventArgs e)
        {
            db.Run("update info_co set id='" + txt_id_E.Text + "',name='" + txt_name_E.Text + "',governate='" + txt_governate_E.Text + "',regionCity='" + txt_regionCity_E.Text + "',street='" + txt_street_E.Text + "',buildingNumber='" + txt_buildingNumber_E.Text + "',id_e='" + txt_IDno_E.Text + "',secret_e='" + txt_secretNO_E.Text + "',taxpayerActivityCode='" + txt_taxpayerActivityCode_E.Text + "',pinToken='" + txt_pin_Token.Text + "'");


            if (rdo_life.Checked) db.Run("update info_co set isLive=1");
            if (rdo_test.Checked) db.Run("update info_co set isLive=0");


            //txt_id_E.Text = db.GetData("select isnull(max(id),'') from info_co ").Rows[0][0].ToString();
            //txt_name_E.Text = db.GetData("select isnull(max(name),'') from info_co ").Rows[0][0].ToString();
            //txt_governate_E.Text = db.GetData("select isnull(max( governate ),'') from info_co ").Rows[0][0].ToString();
            //txt_regionCity_E.Text = db.GetData("select isnull(max( regionCity ),'') from info_co ").Rows[0][0].ToString();
            //txt_street_E.Text = db.GetData("select isnull(max( street ),'') from info_co ").Rows[0][0].ToString();
            //txt_buildingNumber_E.Text = db.GetData("select isnull(max( buildingNumber ),'') from info_co ").Rows[0][0].ToString();
            //txt_IDno_E.Text = db.GetData("select isnull(max( id_e ),'') from info_co ").Rows[0][0].ToString();
            //txt_secretNO_E.Text = db.GetData("select isnull(max( secret_e ),'') from info_co ").Rows[0][0].ToString();
            //txt_taxpayerActivityCode_E.Text = db.GetData("select isnull(max( taxpayerActivityCode ),'') from info_co ").Rows[0][0].ToString();
            //rdo_life.Checked = Convert.ToBoolean(db.GetData("select (isLive) from info_co "));
            //rdo_test.Checked = Convert.ToBoolean(db.GetData("select (isLive) from info_co "));
        }



    }
}