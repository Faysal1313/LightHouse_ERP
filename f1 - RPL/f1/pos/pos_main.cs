using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace f1.pos
{
    public partial class pos_main : DevExpress.XtraEditors.XtraForm
    {
        public pos_main()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
            db.Open();
            try
            {
                v.current_yaer = Convert.ToInt32(db.GetData("select period from info_co").Rows[0][0].ToString());
                lbl_year.Text = v.current_yaer+"";
            }
            catch (Exception)
            {
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            //GraphicsPath wantedshape = new GraphicsPath();
            //wantedshape.AddPie(10, 10, 1500, 350, 130, 130);
            //int x = 400;
            //int y = 150;
            //this.Location = new Point(x,y);
            //this.Region = new Region(wantedshape);
        }
        private void load_permission()
        {
            btn_pos.Enabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='pos_t_f'").Rows[0][0].ToString());
            btn_sheft.Enabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='shift'").Rows[0][0].ToString());
            btn_items.Enabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='code_items'").Rows[0][0].ToString());
            btn_balance.Enabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='balance_qty'").Rows[0][0].ToString());
            btn_offer.Enabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='offer'").Rows[0][0].ToString());
            btn_barcode.Enabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='barcode'").Rows[0][0].ToString());
            btn_adj.Enabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='adj'").Rows[0][0].ToString());
            btn_purchase.Enabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='inv_pur'").Rows[0][0].ToString());
            btn_retpurchase.Enabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='inv_rpur'").Rows[0][0].ToString());
            btn_sale.Enabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='inv_pur'").Rows[0][0].ToString());
            btn_resale.Enabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='inv_pur'").Rows[0][0].ToString());

            btn_recev.Enabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='recev_cash'").Rows[0][0].ToString());
            btn_pay.Enabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='pay_cash'").Rows[0][0].ToString());
            btn_settings.Enabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='settings'").Rows[0][0].ToString());
            btn_report.Enabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='report'").Rows[0][0].ToString());

            lbl_name.Text = db.GetData("select name_of_company from info_co").Rows[0][0].ToString();
            lbl_db.Text = Properties.Settings.Default.db_base;
            lbl_user_code.Text = v.usercode;
            lbl_user_name.Text = v.username;


            v.expiry = Convert.ToBoolean(db.GetData("select expiry from info_co").Rows[0][0].ToString());
            v.represinttive = Convert.ToBoolean(db.GetData("select representative from info_co").Rows[0][0].ToString());
            v.barcode = Convert.ToBoolean(db.GetData("select barcode from info_co").Rows[0][0].ToString());
            v.currance = Convert.ToBoolean(db.GetData("select currancey from info_co").Rows[0][0].ToString());
            v.discount = Convert.ToBoolean(db.GetData("select discount from info_co").Rows[0][0].ToString());
            v.taxes = Convert.ToBoolean(db.GetData("select taxes from info_co").Rows[0][0].ToString());
            v.qty_max_search = Convert.ToInt32(db.GetData("select isnull(max(qty_max_search),0) from info_co").Rows[0][0].ToString());

        }
        private void pos_main_Load(object sender, EventArgs e)
        {
            
            load_permission();
        }
        private void simpleButton6_Click(object sender, EventArgs e)
        {
            // Application.Exit();
            //import_excel.frm_excel_items f = new import_excel.frm_excel_items();
            //f.Show();
            DialogResult dr;
            dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "سيتم الخروج من البرنامج ", "رسالة تـــاكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);


            if (dr == DialogResult.OK)
            {
                foreach (var process in Process.GetProcessesByName("f1"))
                {
                    process.Kill();
                }
            }


            
        }

        private void btn_pos_Click(object sender, EventArgs e)
        {
            frm_pos f = new frm_pos();
            f.Show();
        }

        private void btn_sheft_Click(object sender, EventArgs e)
        {
            pos.pos_shift1 f = new pos.pos_shift1();
            f.Show();
        }

        private void Btn_settings_Click(object sender, EventArgs e)
        {
            pos.frm_settings f = new frm_settings();
            f.ShowDialog();
        }

        private void Btn_purchase_Click(object sender, EventArgs e)
        {
            frm_purchase f = new frm_purchase();
             f.Show();
        }

        private void Btn_items_Click(object sender, EventArgs e)
        {
            frm_item f = new frm_item();
            f.Show();
        }

        private void Btn_balance_Click(object sender, EventArgs e)
        {
            pos.frm_balance_qty f = new frm_balance_qty();
            f.Show();
        }

        private void Btn_offer_Click(object sender, EventArgs e)
        {
            pos.frm_offer f = new frm_offer();
            f.Show();
        }

        private void Btn_barcode_Click(object sender, EventArgs e)
        {
            pos.frm_barcode f = new frm_barcode();
            f.Show();
        }

        private void Btn_retpurchase_Click(object sender, EventArgs e)
        {
            Purchase.frm_rpurchase f = new Purchase.frm_rpurchase();
            f.Show();
        }

        private void Btn_recev_Click(object sender, EventArgs e)
        {
            frm_recevable f = new frm_recevable();
            f.Show();
        }

        private void Btn_pay_Click(object sender, EventArgs e)
        {
            frm_payable f = new frm_payable();
            f.Show();
        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            //inventory.frm_wizard_adjustment_qty f = new inventory.frm_wizard_adjustment_qty();
            frm_adjustment_qty f = new frm_adjustment_qty();
            f.Show();
        }

        private void btn_report_Click(object sender, EventArgs e)
        {
            pos.frm_pos_screen_rep f = new frm_pos_screen_rep();
            f.Show();
        }

        private void pos_main_FormClosing(object sender, FormClosingEventArgs e)
        {
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

        private void btn_restoran_Click(object sender, EventArgs e)
        {
            rest_frm f = new rest_frm();
            f.Show();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void btn_notf_Click(object sender, EventArgs e)
        {
            pos.frm_note f = new frm_note();
            f.ShowDialog();
        }

        private void btn_sale_Click(object sender, EventArgs e)
        {
            frm_sale f = new frm_sale();
            f.Show();
        }

        private void btn_resale_Click(object sender, EventArgs e)
        {
            sales.frm_rsale f = new sales.frm_rsale();
            f.Show();
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            ship_jop.frm_jop_number f = new ship_jop.frm_jop_number();
            f.Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            ship_jop.frm_consolidated_invoice f = new ship_jop.frm_consolidated_invoice();
            f.Show();
        
    }






        //Application.Exit();
        //DialogResult dr;
        //dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "عايز تشيل  من هنا!!؟؟؟؟ ", "رسال حذف مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);


        //if (dr == DialogResult.OK)
        //{
        //    Application.Exit();
        //}
        //else
        //{
        //    //e.Cancel = true;
        //}

    }
}