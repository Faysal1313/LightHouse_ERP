using DevExpress.XtraEditors;
using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;
using f1.Properties;
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
    public partial class frm_consolidated_invoice : DevExpress.XtraEditors.XtraForm
    {
        public frm_consolidated_invoice()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
        }
        private void frm_consolidated_invoice_Load(object sender, EventArgs e)
        {
            cls_book.loadbook(this.comb_code, "سند فاتورة شحن مجمعة");
            dt_due_date.Text = DateTime.Now.ToString("yyyy/MM/dd");
            dt_piker.Text = DateTime.Now.ToString("yyyy/MM/dd");
            d1.Text = DateTime.Now.ToString("yyyy/MM/dd");
            d2.Text = DateTime.Now.ToString("yyyy/MM/dd");
            dt_f.Text = DateTime.Now.ToString("yyyy/MM/dd");
            //load_jo();
            all_comb.load_vcs_customer(combo_vcs);
            all_comb.load_vcs_customer_code(combo_vsc_codetree);
            combo_vsc_codetree.Text = "";
            combo_vcs.Text = "";
        }

        //=============Function
        bool isperformsave = false;
        bool edit = false;
        string numBook_entry = "";
        string numBook = "";
        string error = "";
        private int num = 0;
        private int num_entry = 0;
        private void load_jo()
        {
            if (edit==true)
            {
                MessageBox.Show("لا يمكن التعديل علي الفاتورة");
                return;
            }
            if (combo_vsc_codetree.Text=="")
            {
                MessageBox.Show("يجب اختيار عميل");
                return;
            }
            //to remov effict btn apply colcet hop number voucsher
            for (int i = 0; i < dgv_details.Rows.Count; i++)
            {
                db.Run("update jn_jopnumber set pin ='0' where id='" + dgv_details.Rows[i].Cells[1].Value + "'");
            }
            lbl_nwlon.Text = "0";
            lbl_bonace.Text = "0";
            lbl_bef_vat.Text = "0";
            lbl_vate_value.Text = "0";
            lbl_net.Text = "0";
            dgv_details.Rows.Clear();
            dgv.Rows.Clear();
            dgv_search.Rows.Clear();
            DataTable dt = new DataTable();
            db.GetData_DGV("select id,price_stations*qty as tot,price_stations,qty as qty,station_code,station_name,strohouse_code,strohouse_name,no_voucher,id_truk,date_d from jn_jopnumber  where station_name <> ''and date_d between '" + d1.Value.ToString("yyyy/MM/dd") + "' and '" + d2.Value.ToString("yyyy/MM/dd") + "' and pin = '0' and pin2 = '0' and vcs_code = '" + combo_vsc_codetree.Text + "'group by qty, vcs_code, id, price_stations, price_stations, station_code, station_name, strohouse_code, strohouse_name, no_voucher, id_truk, date_d  ", dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv_search.Rows.Add("",dt.Rows[i][0]+"", dt.Rows[i][1] + "", dt.Rows[i][2] + "", dt.Rows[i][3] + "", dt.Rows[i][4] + "", dt.Rows[i][5] + "", dt.Rows[i][6] + "", dt.Rows[i][7] + "", dt.Rows[i][8] + "", dt.Rows[i][9] + "", Convert.ToDateTime(dt.Rows[i][10]).ToString("yyyy/MM/dd"));
            }
        }
        string pin = "";
        private void colect_jo()
        {
            if (edit == true)
            {
                MessageBox.Show("لا يمكن التعديل علي الفاتورة");
                return;
            }

            pin = DateTime.Now.ToString("yyyymmddhhss");
            //1-transfer data
            dgv_details.Rows.Clear();
            for (int i = 0; i < dgv_search.Rows.Count; i++)
            {
                dgv_details.Rows.Add("", dgv_search.Rows[i].Cells[1].Value, dgv_search.Rows[i].Cells[2].Value, dgv_search.Rows[i].Cells[3].Value, dgv_search.Rows[i].Cells[4].Value, dgv_search.Rows[i].Cells[5].Value, dgv_search.Rows[i].Cells[6].Value, dgv_search.Rows[i].Cells[7].Value, dgv_search.Rows[i].Cells[8].Value, dgv_search.Rows[i].Cells[9].Value, dgv_search.Rows[i].Cells[10].Value, dgv_search.Rows[i].Cells[11].Value);
                //2-update quer
                db.Run("update jn_jopnumber set pin='" + pin + "' where id='" + dgv_search.Rows[i].Cells[1].Value + "'");
            }
            //3-get conslidation invoice
            dgv.Rows.Clear();
            DataTable dt = new DataTable();
            DataTable dtconsolidation = new DataTable();
            DataTable dt_temp_station_disitinct= new DataTable();

            db.GetData_DGV("select sum(price_stations*qty)as tot,qty,station_code,station_name,COUNT(station_name)as trans,(select sum(price_stations) from jn_jopnumber where station_code=s.station_code and pin='" + pin + "' )as price,(qty/51) as qty_div from jn_jopnumber s where qty <>'0'and pin = '" + pin + "'group by station_name, price_stations, station_code,qty", dt);


            //for (int ii = 0; ii < dt.Rows.Count; ii++)
            //{
            //    dgv.Rows.Add("", dt.Rows[ii][0] + "", dt.Rows[ii][1] + "", dt.Rows[ii][2] + "", dt.Rows[ii][3] + "", dt.Rows[ii][4] + "", dt.Rows[ii][5] + "", Convert.ToDecimal(dt.Rows[ii][5])/51 );
            //}
       
           

            for (int i = 0; i < dgv_search.Rows.Count; i++)
            {
                db.Run("INSERT INTO jn_temp ([pin],[station_code])VALUES ('"+pin+"','"+ dgv_search.Rows[i].Cells["col_code_staion"].Value + "" + "')");
            }
            db.GetData_DGV("select distinct (station_code) from jn_temp where pin='"+pin+"'", dt_temp_station_disitinct);
            db.Run("delete from jn_temp where pin='" + pin + "'");
            for (int ii = 0; ii < dt_temp_station_disitinct.Rows.Count; ii++)
            {
                    db.GetData_DGV("select (select sum(qty) from jn_jopnumber where station_code=s.station_code and  pin ='" + pin + "'  )as qty,station_code,station_name,COUNT(station_name)as trans,(select sum(price_stations) from jn_jopnumber where station_code=s.station_code and pin = '" + pin + "'  )as price ,(select sum(qty) from jn_jopnumber where station_code=s.station_code and  pin ='" + pin + "' )*(select sum(price_stations) from jn_jopnumber where station_code=s.station_code  and pin = '" + pin + "' )as tot from jn_jopnumber s where qty <>'0' and station_code='" + dt_temp_station_disitinct.Rows[ii][0] + "" + "'and pin = '" + pin + "' group by station_name, price_stations, station_code", dtconsolidation);
                    dgv.Rows.Add("", dtconsolidation.Rows[ii][1] + "", dtconsolidation.Rows[ii][2] + "", dtconsolidation.Rows[ii][4] + "", dtconsolidation.Rows[ii][0] + "", dtconsolidation.Rows[ii][5] + "", Math.Round(Convert.ToDecimal(dtconsolidation.Rows[ii][0]) / 51,2), dtconsolidation.Rows[ii][0] + "");
                
            }
            calc();
        }
        private void save()
        {


            //get only number for one user purchase
            //txt_code_book.Text = db.GetData("select code_book from book where name_book='" + comb_code.Text + "'").Rows[0][0].ToString();
            //cls_book.selectbook("jn_consolidated_invoice", "سند فاتورة شحن مجمعة", txt_code_book.Text, txt_serial, "id");

            //txt_serial_string.Text = txt_code_book.Text + txt_serial.Text;
            
            cls_book.Generat_numBooknum("jn_consolidated_invoice", txt_code_book.Text, ref numBook, ref error, ref num);
            txt_serial_string.Text = numBook;

            isperformsave = true;
            //insert into einvoice consledions
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                db.Run("INSERT INTO [jn_consolidated_invoice]           (code_book,[id]                            ,[vcs_name]           ,[vcs_code]                                             ,[date_dute]                                 ,[date_p]                                               ,[c_value]                           ,                    [c_qty]                              ,[c_code_stations]                             ,[c_name_stations]                                                ,[c_number_cargo]            ,[c_qty_cargo]      ,num_book ,number_of_cargo_num,cargo_qty_delevery    )     VALUES  ('"+txt_code_book.Text+"','" +
                                                                         txt_serial_string.Text + "'   ,'" + combo_vcs.Text + "','" + combo_vsc_codetree.Text + "'                ,'" + dt_due_date.Value.ToString("yyyy-MM-dd") + "','" + dt_piker.Value.ToString("yyyy-MM-dd") + "','" + dgv.Rows[i].Cells["c_value"].Value + "','" + dgv.Rows[i].Cells["c_qty"].Value + "','" + dgv.Rows[i].Cells["c_code_stations"].Value + "','" + dgv.Rows[i].Cells["c_name_stations"].Value + "','" + dgv.Rows[i].Cells["c_number_cargo"].Value + "','" + dgv.Rows[i].Cells["c_qty_cargo"].Value + "','"+num+"','"+ dgv.Rows[i].Cells["c_number_cargo"].Value + "','"+ dgv.Rows[i].Cells["c_qty_cargo"].Value + "')");
            }
            for (int i = 0; i < dgv_details.Rows.Count; i++)
            {
                db.Run("INSERT INTO [jn_consolidated_invoice_d]           ([id]                            ,[vcs_name]           ,[vcs_code]                                             ,[date_dute]           ,[date_p]                                                        ,[no_jop]                                            ,[d_vale]           ,[d_price]                                                               ,[d_qty]                                     ,[d_code_stations]                                           ,[d_name_stations]                                                                     ,[d_code_stroehouse]                 ,[d_name_stroehouse]                                         ,[d_code_truck],[date_pp])     VALUES  ('" +
                                                                     txt_serial_string.Text + "','" + combo_vcs.Text + "','" + combo_vsc_codetree.Text + "','" + dt_due_date.Value.ToString("yyyy-MM-dd") + "','" + dt_piker.Value.ToString("yyyy-MM-dd") + "','" + dgv_details.Rows[i].Cells["no_jop"].Value + "','" + dgv_details.Rows[i].Cells["d_vale"].Value + "','" + dgv_details.Rows[i].Cells["d_price"].Value + "','" + dgv_details.Rows[i].Cells["d_qty"].Value + "','" + dgv_details.Rows[i].Cells["d_code_stations"].Value + "','" + dgv_details.Rows[i].Cells["d_name_stations"].Value + "','" + dgv_details.Rows[i].Cells["d_code_stroehouse"].Value + "','" + dgv_details.Rows[i].Cells["d_name_stroehouse"].Value + "','" + dgv_details.Rows[i].Cells["d_code_truck"].Value + "','" + dgv_details.Rows[i].Cells["date_pp"].Value + "')");
                //update jop order iitp pin2 by number invoice 
                db.Run("update jn_jopnumber set pin2='" + txt_serial_string.Text + "' where  id='" + dgv_details.Rows[i].Cells["no_jop"].Value + "' ");
            }
            edit = true;
            MessageBox.Show("save");
        }
        private void delete()
        {
            if (edit==false)
            {
                return;
            }
            string rec=db.GetData("select isnull(max(code_entry),0) from recev_dt where attachno2='" + txt_serial_string.Text+"'").Rows[0][0]+"";
            if (rec !="0")
            {
                MessageBox.Show("لا يمكن حذف الفاتورة لانها مربوطة بسند قبض رقم "+"\n"+rec);
                return;
            }



            DialogResult dr;
            dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, " هل تريد حذف السند!!؟؟؟؟ ", "رسال حذف مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                for (int i = 0; i < dgv_details.Rows.Count; i++)
                {
                    db.Run("update jn_jopnumber set pin ='0', pin2='0' where id='" + dgv_details.Rows[i].Cells[1].Value + "'");
                }
                db.Run("delete from jn_consolidated_invoice where id='" + txt_serial_string.Text + "'");
                db.Run("delete from jn_consolidated_invoice_d where id='" + txt_serial_string.Text + "'");
                frm_consolidated_invoice f = new frm_consolidated_invoice();
                this.Close();
                f.Show();
            }
        }
        private  void perform()
        {
            if (dgv.Rows.Count==0 )
            {
                MessageBox.Show("يجب تجميع اوامر شغل");
                return;
            }
            if (dgv_details.Rows.Count == 0)
            {
                MessageBox.Show("يجب تجميع اوامر شغل");
                return;
            }
            if (combo_vsc_codetree.Text=="")
            {
                MessageBox.Show("يجب اختيار عميل");
                return;
            }
            save();
        }
        private void calc()
        {
            try
            {
               // double bonce_from;
                double nwlon = Convert.ToDouble(db.GetData("select  ISNULL(SUM(d_vale),0) from jn_consolidated_invoice_d where id='"+ txt_serial_string.Text+"'").Rows[0][0]+"");
                double bonace =Convert.ToDouble(db.GetData("select ISNULL((SUM(c_qty/51)*(select isnull((bonace),0) from info_co)),0) from jn_consolidated_invoice where id='"+txt_serial_string.Text+"'").Rows[0][0]);
                double bef_vat = 0;
                double vate_value = 0;
                double net = 0;
                //for (int i = 0; i < dgv_details.Rows.Count; i++)
                //{
                //    if (dgv_details.Rows[i].Cells["d_vale"].Value+"" == "") dgv_details.Rows[i].Cells["d_vale"].Value = "0";

                //    nwlon += Convert.ToDouble(dgv_details.Rows[i].Cells["d_vale"].Value);
                //}
                bef_vat = Math.Round((nwlon + bonace), 2);
                vate_value = Math.Round((bef_vat * 0.14), 2);
                net = Math.Round(vate_value + bef_vat, 2);

                lbl_nwlon.Text = Math.Round(nwlon, 2) + "";
                lbl_bonace.Text = bonace + "";
                lbl_bef_vat.Text = bef_vat + "";
                lbl_vate_value.Text = vate_value + "";
                lbl_net.Text = net + "";
            }
            catch (Exception)
            {

                
            }

        }
        private void get_dt(string num)//get data detals
        {
            DataTable dt1 = new DataTable();
            DataTable dt = new DataTable();
            db.GetData_DGV("    SELECT [c_value],[c_qty],[c_code_stations],[c_name_stations],[c_number_cargo],[c_qty_cargo]  FROM [jn_consolidated_invoice] where id='" + num + "" + "'", dt1);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string price = db.GetData("select isnull(MAX(d_price),0) FROM [jn_consolidated_invoice_d] where id='"+ num + "' and d_code_stations='"+ dt1.Rows[i][2] + "'").Rows[0][0] + "";
                //dgv.Rows.Add(null, dt1.Rows[i][0] + "", dt1.Rows[i][1] + "", dt1.Rows[i][2] + "", dt1.Rows[i][3] + "", dt1.Rows[i][4] + "", dt1.Rows[i][5] + "");
                dgv.Rows.Add(null, dt1.Rows[i][2] + "", dt1.Rows[i][3] + "", price , dt1.Rows[i][5] + "", dt1.Rows[i][0] + "", dt1.Rows[i][4] + "");

            }
            db.GetData_DGV("SELECT [no_jop],[d_vale],[d_price],[d_qty],[d_code_stations],[d_name_stations],[d_code_stroehouse],[d_name_stroehouse],[d_novocher_dlv],[d_code_truck],[date_pp]FROM [jn_consolidated_invoice_d]   where id='" + num + "'", dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv_details.Rows.Add(null, dt.Rows[i][0] + "", dt.Rows[i][1] + "", dt.Rows[i][2] + "", dt.Rows[i][3] + "", dt.Rows[i][4] + "", dt.Rows[i][5] + "", dt.Rows[i][6] + "", dt.Rows[i][7] + "", dt.Rows[i][8] + "", dt.Rows[i][9] + "", dt.Rows[i][10] + "");
            }

        }
        private void bode_of_navigation(string num, string book)
        {
            dgv.Rows.Clear();
            dgv_details.Rows.Clear();

            //  load_permission();
            //btn_barcode.Enabled = true;

            DataTable dt = new DataTable();
            db.GetData_DGV("select code_book from  jn_consolidated_invoice  where id='" + num + "' and code_book='" + book + "' ", dt);
            if (dt.Rows.Count > 0)
            {
                edit = true;
                get_dt(num);
                txt_serial_string.Text = db.GetData("select isnull(max(id),'-') from [jn_consolidated_invoice]   where id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
                combo_vcs.Text= db.GetData("select isnull(max(vcs_name),'-') from [jn_consolidated_invoice]   where id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
                combo_vsc_codetree.Text= db.GetData("select isnull(max(vcs_code),'-') from [jn_consolidated_invoice]   where id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
                dt_due_date.Text = db.GetData("select isnull(max(date_dute),'-') from [jn_consolidated_invoice]   where id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
                dt_piker.Text = db.GetData("select isnull(max(date_p),'-') from [jn_consolidated_invoice]   where id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
                calc();

            }

        }
        private void dgv_satue_cost_bal_vcs_dis_min_max()
        {
            try
            {
                lbl_state_vcs_bal.Caption = db.GetData("select isnull(sum(depit)-sum(credit),0) from entry where acc_num='" + combo_vsc_codetree.Text + "'").Rows[0][0] + "";
            }
            catch (Exception)
            {


            }
        }

        //==============================================================================

        private void simpleButton3_Click(object sender, EventArgs e)
        {

            colect_jo();
            group_jo.Visible = false;

        }

        private void dgv_search_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                ship_jop.frm_jop_number f = new frm_jop_number();
                f.Show();
                f.txt_serial_string.Text = dgv_search.CurrentRow.Cells[1].Value + "";
                f.txt_serial_string.Select();
                f.comb_code.Select();
            }
        }

        private void recev_barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (edit != true)
            {
                MessageBox.Show("يجب اختيار الفاتورة");
                return;
            }
            if (db.GetData("select mode from vcs where vcs_code='" + combo_vsc_codetree.Text + "'").Rows[0][0].ToString() == "customer")
            {
                v.sale_c = true;
                v.sale_v = false;
            }
            else
            {
                v.sale_c = false;
                v.sale_v = true;
            }

            v.sale_sale_hd_id = txt_serial_string.Text;
            v.sale_vcs_name = combo_vcs.Text;
            v.sale_vcs_code = combo_vsc_codetree.Text;
            v.sale_amount = lbl_net.Text;
            v.privent_select_vcs = false;
            frm_recevable f = new frm_recevable();
            f.ShowDialog();
        }

        private void combo_vsc_codetree_Click(object sender, EventArgs e)
        {
            all_comb.load_code_vcs(combo_vsc_codetree);
        }

        private void combo_vsc_codetree_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combo_vcs.Text = db.GetData("select  vcs_name from vcs where vcs_code='" + combo_vsc_codetree.Text + "'").Rows[0][0].ToString();
            }
            catch (Exception)
            {
            }
        }

        private void combo_vcs_Click(object sender, EventArgs e)
        {
            if (!this.Switch_vcs.BindableChecked)
                all_comb.load_vcs_customer(this.combo_vcs);
            else
                all_comb.load_vcs(this.combo_vcs);
        }

        private void combo_vcs_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combo_vsc_codetree.Text = db.GetData("select  vcs_code from vcs where vcs_name='" + combo_vcs.Text + "'").Rows[0][0].ToString();
            }
            catch (Exception)
            {


            }
        }

        private void btn_search_no_jop_Click(object sender, EventArgs e)
        {
            load_jo();
        }

        private void save_barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            perform();
        }

        private void frm_consolidated_invoice_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isperformsave==false)
            {
                for (int i = 0; i < dgv_details.Rows.Count; i++)
                {

                    db.Run("update jn_jopnumber set pin ='0' where id='"+dgv_details.Rows[i].Cells[1].Value+"'");
                }
            }
        }

        private void btn_Get_entry_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < dgv_details.Rows.Count; i++)
            {
                dt.Rows.Clear();
                db.GetData_DGV("select acc_num,acc_name,depit,credit,attachnamebook,attachtext from entry where attachno='" + dgv_details.Rows[i].Cells["no_jop"].Value + "'", dt);
                for (int ii = 0; ii < dt.Rows.Count; ii++)
                {
                    dgv_entry.Rows.Add("",dt.Rows[ii][0]+"", dt.Rows[ii][1] + "", dt.Rows[ii][2] + "", dt.Rows[ii][3] + "", dt.Rows[ii][4] + "", dt.Rows[ii][5] + "");
                }
            }
        }
        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv, "no");
        }
        private void dgv_details_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv_details, "no_d");
        }
        private void dgv_entry_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv_entry, "no_e");
        }
        private void dgv_search_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv_search, "no_s");
        }
        private void New_barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("هل تريد سند جديد!!؟؟؟؟ ", "رسال جديد مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                frm_consolidated_invoice f = new frm_consolidated_invoice();
                this.Close();
                f.Show();
            }
        }

        private void comb_code_SelectedIndexChanged(object sender, EventArgs e)
        {
            //load next field from load book "3lsahn el moshklal bta3at el combobox 
            txt_code_book.Text = db.GetData("select code_book from book where name_book='" + comb_code.Text + "'").Rows[0][0].ToString();
            //cls_book.selectbook("jn_consolidated_invoice", "سند فاتورة شحن مجمعة", txt_code_book.Text, txt_serial, "id");
            //txt_serial_string.Text = txt_code_book.Text + txt_serial.Text;


            cls_book.Generat_numBooknum("jn_consolidated_invoice", txt_code_book.Text, ref numBook, ref error, ref num);
            txt_serial_string.Text = numBook;

        }

        private void btn_delete_file_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            delete();
        }
        private void dgv_details_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void First_barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!(db.GetData("select min(convert(int,(right(id,LEN(id)-3)))) from jn_consolidated_invoice where  code_book='" + txt_code_book.Text + "' ").Rows[0][0].ToString() != ""))
                    return;

                txt_serial_string.Text = db.GetData("select min(convert(int,(right(id,LEN(id)-3)))) from jn_consolidated_invoice where  code_book='" + txt_code_book.Text + "' ").Rows[0][0].ToString();
                bode_of_navigation(txt_code_book.Text + txt_serial_string.Text, txt_code_book.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void Last_barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!(db.GetData("select max(convert(int,(right(id,LEN(id)-3)))) from jn_consolidated_invoice where  code_book='" + txt_code_book.Text + "' ").Rows[0][0].ToString() != ""))
                    return;
              

                txt_serial_string.Text = db.GetData("select max(convert(int,(right(id,LEN(id)-3)))) from jn_consolidated_invoice where  code_book='" + txt_code_book.Text + "' ").Rows[0][0].ToString();
                this.bode_of_navigation(this.txt_code_book.Text + this.txt_serial_string.Text, this.txt_code_book.Text);
            }
            catch (Exception)
            {


            }
        }

        private void Back_barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!(db.GetData("select min(convert(int,(right(id,LEN(id)-3)))) from jn_consolidated_invoice where  code_book='" + txt_code_book.Text + "' ").Rows[0][0].ToString() != ""))
                    return;
               
                new DataTable().Rows.Clear();
                string s1 = db.GetData("select min(convert(int,(right(id,LEN(id)-3)))) from jn_consolidated_invoice where  code_book='" + txt_code_book.Text + "' ").Rows[0][0].ToString();

                int.Parse(s1);
                string s2 = this.txt_serial_string.Text.Remove(0, 1).Remove(0, 2);
                if (int.Parse(s1) >= Convert.ToInt32(s2))
                {
                    int num = (int)MessageBox.Show("اخر ملف");
                }
                else
                {
                    this.txt_serial_string.Text = this.txt_code_book.Text + (object)(int.Parse(s2) - 1);
                    this.bode_of_navigation(this.txt_serial_string.Text, this.txt_code_book.Text);
                }
            }
            catch (Exception)
            {

            }
        }

        private void Next_barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!(db.GetData("select max(convert(int,(right(id,LEN(id)-3)))) from jn_consolidated_invoice where  code_book='" + txt_code_book.Text + "' ").Rows[0][0].ToString() != ""))
                    return;
                new DataTable().Rows.Clear();
                string s1 = db.GetData("select max(convert(int,(right(id,LEN(id)-3)))) from jn_consolidated_invoice where  code_book='" + txt_code_book.Text + "' ").Rows[0][0].ToString();
                int.Parse(s1);
                string s2 = this.txt_serial_string.Text.Remove(0, 1).Remove(0, 2);
                if (int.Parse(s1) <= Convert.ToInt32(s2))
                {
                    int num = (int)MessageBox.Show("اول م ملف");
                }
                else
                {
                    this.txt_serial_string.Text = this.txt_code_book.Text + (object)(int.Parse(s2) + 1);
                    this.bode_of_navigation(this.txt_serial_string.Text, this.txt_code_book.Text);
                }

            }
            catch (Exception)
            {

            }

        }

        

        private void btn_get_jopvoucher_Click(object sender, EventArgs e)
        {
            group_jo.Visible = true;

        }

        private void btn_pending_close_Click(object sender, EventArgs e)
        {
            group_jo.Visible = false;
        }

        private void lbl_state_vcs_bal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lbl_state_vcs_bal.Caption != "")
            {
                //XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\stat_gl.repx", true);
                ////xtraReport.Parameters["parameter2"].Value = txt_serial_string.Text;
                //xtraReport.Parameters["parameter2"].Value = combo_vsc_codetree.Text;
                //xtraReport.Parameters["parameter2"].Visible = false;
                //XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
                account.report_account.report_screen.sc_statment_gl f = new account.report_account.report_screen.sc_statment_gl();
                f.Show();
                f.lbl_code.Text = combo_vsc_codetree.Text;
                //f.date1.Text = date1.Text;
                //f.date2.Text = date2.Text;
                f.date1.Select();
                f.btn_get_Data.Select();
                f.btn_get_Data.PerformClick();
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv_satue_cost_bal_vcs_dis_min_max();
        }

        private void f_barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            group_ff.Visible = true;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            all_comb.load_jn_con_invoice_docment(combo1_doc_F);
            combo1_doc_F.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_ff.Rows.Count == 0) return;

                bode_of_navigation(dgv_ff.CurrentRow.Cells["id_f"].Value.ToString(), dgv_ff.CurrentRow.Cells["code_ff"].Value.ToString());
                group_ff.Visible = false;

            }
            catch (Exception)
            {


            }
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            group_ff.Visible = false;

        }

        private void labelControl26_Click(object sender, EventArgs e)
        {

        }
        private void printer_previeew_barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraReport xtraReport = XtraReport.FromFile("forms\\invoice_h.repx", true);
            xtraReport.Parameters["parameter1"].Value = txt_serial_string.Text;
            xtraReport.Parameters["parameter1"].Visible = false;
            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
        }

        private void printer_direct_barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraReport xtraReport = XtraReport.FromFile("forms\\invoice_d.repx", true);
            xtraReport.Parameters["parameter1"].Value = txt_serial_string.Text;
            xtraReport.Parameters["parameter1"].Visible = false;
            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);

            //xtraReport.PrinterName = Settings.Default.printer_a4;
            //xtraReport.PrintAsync();
        }
        private void btn_printer_Click(object sender, EventArgs e)
        {
            XtraReport xtraReport = XtraReport.FromFile("forms\\invoice_jn.repx", true);
            xtraReport.Parameters["parameter1"].Value = txt_serial_string.Text;
            xtraReport.Parameters["parameter1"].Visible = false;
            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);

            //xtraReport.PrinterName = Settings.Default.printer_a4;
            //xtraReport.PrintAsync()
        }

        private void dgv_details_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_details.Rows.Count == 0) return;
                if (e.ColumnIndex == 1)
                {
                    ship_jop.frm_jop_number f = new frm_jop_number();
                    f.Show();
                    f.txt_serial_string.Text = dgv_details.CurrentRow.Cells[1].Value + "";
                    f.txt_serial_string.Select();
                    f.comb_code.Select();


                    //===============

                    //account.report_account.report_screen.sc_statment_gl f = new account.report_account.report_screen.sc_statment_gl();
                    //f.Show();
                    //f.lbl_code.Text = dgv.CurrentRow.Cells["acc_num"].Value + "";
                    //f.date1.Select();
                    //f.btn_get_Data.Select();
                    //f.btn_get_Data.PerformClick();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}