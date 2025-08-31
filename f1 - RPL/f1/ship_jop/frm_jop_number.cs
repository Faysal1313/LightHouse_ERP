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
    public partial class frm_jop_number : DevExpress.XtraEditors.XtraForm
    {
        public frm_jop_number()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
        }
        bool edite = false;
        string numBook_entry = "";
        string numBook = "";
        string error = "";
        private int num = 0;
        private int num_entry = 0;
        private void frm_jop_number_Load(object sender, EventArgs e)
        {
            all_comb.load_truck_id(combo_truck);
            all_comb.load_station_name(combo_stations);
            all_comb.load_storehouse_name(combo_storehouse);
            all_comb.load_emp_name(combo_emp);
            all_comb.load_vcs_customer(combo_vcs_name);
            combo_truck.Text = "";
            combo_stations.Text = "";
            combo_storehouse.Text = "";
            combo_emp.Text = "";
            lbl_code_truck.Text = "";
            lbl_code_storehouse.Text = "";
            lbl_code_stations.Text = "";
            lbl_code_emp.Text = "";
            combo_vcs_name.Text = "";
            lbl_vcs.Text = "";
            txt_trip_counter_after.Text = "";
            txt_trip_counter_befor.Text = "";
            dtto.Text = DateTime.Now.ToString("yyyy/MM/dd");
            dtfrom.Text = DateTime.Now.ToString("yyyy/MM/dd");

            this.dt_piker.Text = DateTime.Now.ToString("yyyy/MM/dd");
            cls_book.loadbook(this.comb_code, "سند امر شغل نقل");
            cls_book.load_from_term(combo_type, "سند امر شغل نقل");
            dgv.Rows.Add("1", "1001", "سولار");
            dgv.Rows.Add("2", "1002", "بنزين 95");
            dgv.Rows.Add("3", "1003", "بنزين 92");
            dgv.Rows.Add("4", "1004", "بنزين 80");

            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void find(string key, string id)
        {
            dgv_f.Rows.Clear();
            DataTable dt = new DataTable();
            db.GetData_DGV("select distinct id,qty,strohouse_name,station_name,date_d,name_driver,code_book from  jn_jopnumber  where "+key+"='" + id + "'", dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv_f.Rows.Add("", dt.Rows[i][0] + "", dt.Rows[i][1] + "", dt.Rows[i][2] + "", dt.Rows[i][3] + "", dt.Rows[i][4] + "", dt.Rows[i][5] + "", dt.Rows[i][6] + "");
            }

        }
      //---------------Function

        public void calc()
        {
            try
            {
                double qty_truk = 0;
                double f1 = 0;
                double f2 = 0;
                double f3 = 0;
                double f4 = 0;
                double f5 = 0;

                double rev = 0;
                double bonace = 0;
                double net_rev = 0;
                double vat_Value = 0;
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if (dgv.Rows[i].Cells["qty_truk_c"].Value+""=="") dgv.Rows[i].Cells["qty_truk_c"].Value = "0";
                    qty_truk += Convert.ToDouble(dgv.Rows[i].Cells["qty_truk_c"].Value);
                    if (dgv.Rows[i].Cells["f1c"].Value+"" == "") dgv.Rows[i].Cells["f1c"].Value = "0";
                    if (dgv.Rows[i].Cells["f2c"].Value + "" == "") dgv.Rows[i].Cells["f2c"].Value = "0";
                    if (dgv.Rows[i].Cells["f3c"].Value + "" == "") dgv.Rows[i].Cells["f3c"].Value = "0";
                    if (dgv.Rows[i].Cells["f4c"].Value + "" == "") dgv.Rows[i].Cells["f4c"].Value = "0";
                    if (dgv.Rows[i].Cells["f5c"].Value + "" == "") dgv.Rows[i].Cells["f5c"].Value = "0";


                    f1 += Convert.ToDouble(dgv.Rows[i].Cells["f1c"].Value);
                    f2 += Convert.ToDouble(dgv.Rows[i].Cells["f2c"].Value);
                    f3 += Convert.ToDouble(dgv.Rows[i].Cells["f3c"].Value);
                    f4 += Convert.ToDouble(dgv.Rows[i].Cells["f4c"].Value);
                    f5 += Convert.ToDouble(dgv.Rows[i].Cells["f5c"].Value);


                    //rev = Math.Round((Convert.ToDouble(db.GetData("select isnull(max(price),'0') from jn_station where id='"+ dgv.Rows[i].Cells["col_code_station"].Value + "'").Rows[0][0].ToString()) * Convert.ToDouble(dgv.Rows[i].Cells["qty_truk_c"].Value)), 2);
                    rev += Math.Round((Convert.ToDouble(db.GetData("select isnull(max(price),'0') from jn_station where id='" + dgv.Rows[i].Cells["col_code_station"].Value + "'").Rows[0][0].ToString()) * Convert.ToDouble(dgv.Rows[i].Cells["qty_truk_c"].Value)), 2);

                }

                lbl_qty_truk.Text = qty_truk + "";
                lbl_f1.Text = f1 + "";
                lbl_f2.Text = f2 + "";
                lbl_f3.Text = f3 + "";
                lbl_f4.Text = f4 + "";
                lbl_f5.Text = f5 + "";

                lbl_sum.Text = (f1 + f2 + f3+f4+f5)+"";
                if (lbl_price.Text == "") lbl_price.Text = "0";
                if (lbl_qty_truk.Text == "") lbl_qty_truk.Text = "0";
                //rev = Math.Round((Convert.ToDouble(lbl_price.Text) * Convert.ToDouble(lbl_qty_truk.Text)), 2);

                //lbl_code_stations
                lbl_rev.Text = rev+ "";
                bonace = Convert.ToDouble(db.GetData("select isnull(max(bonace),'0') from info_co").Rows[0][0].ToString());
                net_rev = bonace + rev;
                vat_Value = net_rev * 0.14;
                lbl_boncae.Text = bonace + "";
                lbl_vat.Text = Math.Round(vat_Value,2)+"";

                
                if (qty_truk > 51) MessageBox.Show("الكمية اكبر من السعة التخزينة");

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
     //   string code_entry, sort, rootlevel, rootlevel_name, type_acc,desc;
   
      
        private void save()
        {
           // select_type_entry();

            string error = "";
            DataTable dt_term = new DataTable();
            cls_book.Make_entry_type_jop_number(ref dt_term, ref error, "سند امر شغل نقل", combo_type.Text,"",lbl_vcs.Text,lbl_f1.Text,lbl_f2.Text,lbl_f3.Text, lbl_f4.Text, lbl_f5.Text, lbl_sum.Text,lbl_rev.Text,lbl_boncae.Text,lbl_vat.Text);

            //get Entry GL
            //txt_entry_string.Text = txt_code_entry_type.Text + txt_code_entry.Text;
            //cls_book.selectbook("entry_hd", "سند قيد", txt_code_entry_type.Text, txt_code_entry, "code_entry");
            //txt_entry_string.Text = txt_code_entry_type.Text + txt_code_entry.Text;
            txt_code_book.Text = db.GetData("select code_book from book where name_book='" + comb_code.Text + "'").Rows[0][0].ToString();
            string code_entry_term = (db.GetData("select code_entry from term where term_id='" + combo_type.Text + "' ").Rows[0][0].ToString());

            cls_book.Generat_numBooknum("entry", code_entry_term, ref numBook_entry, ref error, ref num_entry);
            txt_entry_string.Text = numBook_entry;
            //get only number for one user purchase
            //cls_book.selectbook("jn_jopnumber", "سند امر شغل نقل", txt_code_book.Text, txt_serial, "id");
            //txt_serial_string.Text = txt_code_book.Text + txt_serial.Text;

            cls_book.Generat_numBooknum("jn_jopnumber", txt_code_book.Text, ref numBook, ref error, ref num);
            txt_serial_string.Text = numBook;
            double sum_term = 0;
            bool is_greatthan0 = false;
            //for (int i = 0; i < dgv_term.Rows.Count; i++)
            //{
            //    if (dgv_term.Rows[i].Cells["depit"].Value + "" == "") dgv_term.Rows[i].Cells["depit"].Value = "0";
            //    sum_term += Convert.ToDouble(dgv_term.Rows[i].Cells["depit"].Value);
            //}
           // if (sum_term > 0) is_greatthan0 = true;
          //  if (is_greatthan0==true)
            {
                //1)insert into Entry
                //------------------
                string code_entry_dt = db.GetData("select (max(convert(int,(right( CODE_ENTRY , len(CODE_ENTRY)-3))))) from entry ").Rows[0][0].ToString();
                string code_entry_hd = db.GetData("select (max(convert(int,(right( CODE_ENTRY , len(CODE_ENTRY)-3))))) from entry_hd ").Rows[0][0].ToString();
                if (code_entry_dt != code_entry_hd)
                {
                    //string error_code = db.GetData("select (max(convert(int,(right( CODE_ENTRY , len(CODE_ENTRY)-3))))) from entry_hd ").Rows[0][0].ToString();
                    db.Run("delete from entry_hd where code_entry ='" + code_entry_hd + "'");
                }
                //entry_hd
                db.Run("insert into entry_hd ([code_entry],code_book) values ('" + txt_entry_string.Text + "','" + txt_code_entry_type.Text + "')");

                try
                {
                    //for (int z = 0; z < dgv_term.Rows.Count; z++)
                    //{
                    //    db.Run("insert into entry(  [code_entry]                           ,    acc_num                                                   ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                                          ,   type_acc                                                            , sort                                                       ,             depit                                                             ,                credit                                                   ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext,num_book )values('" +
                    //                              txt_entry_string.Text + "'            ,'" + dgv_term.Rows[z].Cells[1].Value.ToString() + "'     ,'" + dgv_term.Rows[z].Cells[2].Value.ToString() + "'               ,  '" + dgv_term.Rows[z].Cells["rootlevel_"].Value.ToString() + "'    ,  '" + dgv_term.Rows[z].Cells["rootlevel_name_"].Value.ToString() + "', '" + dgv_term.Rows[z].Cells["type_acc_"].Value.ToString() + "'       ,  '" + dgv_term.Rows[z].Cells["sort_"].Value.ToString() + "'  ,  '" + Convert.ToDecimal(dgv_term.Rows[z].Cells[3].Value.ToString()) + "'      ,'" + Convert.ToDecimal(dgv_term.Rows[z].Cells[4].Value.ToString()) + "' ,'" + txt_name_book_type.Text + "','" + txt_code_entry_type.Text + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + txt_serial_string.Text + "','" + txt_code_book.Text + "','','" + dgv_term.Rows[z].Cells["desc_type"].Value.ToString() + "','"+num_entry+"')");
                    //}
                    for (int z = 0; z < dt_term.Rows.Count; z++)

                    {
                        db.Run("insert into entry(  [code_entry]                           ,    acc_num                                                   ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                                          ,   type_acc                                                            , sort                                                       ,             depit                                                             ,                credit                                                                          ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext ,num_book)values('" +
                                            txt_entry_string.Text + "'            ,'" + dt_term.Rows[z][1] + "'     ,'" + dt_term.Rows[z][2] + "'               ,  '" + dt_term.Rows[z][5] + "'    ,                               '" + dt_term.Rows[z][6] + "',                                                         '" + dt_term.Rows[z][8] + "'       ,                        '" + dt_term.Rows[z][7] + "'  ,                               '" + Convert.ToDecimal(dt_term.Rows[z][3]) * Convert.ToDecimal(1) + "'      ,'" + Convert.ToDecimal(dt_term.Rows[z][4]) * Convert.ToDecimal(1) + "' ,'" + txt_name_book_type.Text + "','" + code_entry_term + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + txt_serial_string.Text + "','" + txt_code_book.Text + "','','','" + num_entry + "')");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

            }
            //1)insert into JOP_NUMBER
            //--------------------------
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                db.Run("INSERT INTO jn_jopnumber (pin2,pin,price_stations,vcs_name,vcs_code,name_driver,code_driver,[code_book],[id]                      ,[id_truk]           ,[name_truck]               ,[date_from]                          ,[date_to]                      ,[time_to]                                 ,[time_from]                           ,[trip_counter_befor]                  ,[trip_counter_after]                                     ,[code_items]                           ,[name_items]                             ,[qty]                                   ,[strohouse_name]                                  ,[strohouse_code]                                   ,[station_name]                                  ,[station_code]                                ,[no_voucher],[Loaded_distance],[unLoaded_distance]           ,[fess1]           ,[fess2]           ,[fess3]          ,[date_d],[user_code],[user_name],[destance],num_book,[fess4],[fess5]) values ('0','0','" + db.GetData("select isnull(max(price),'0') from jn_station where id='" + dgv.Rows[i].Cells["col_code_station"].Value + "'").Rows[0][0].ToString()+"','"+combo_vcs_name.Text+"','"+lbl_vcs.Text+"','"+combo_emp.Text+"','"+lbl_code_emp.Text+"','" + txt_code_book.Text + "','" +
                                             txt_serial_string.Text + "','" + combo_truck.Text + "','"+lbl_code_truck.Text+"','" + dtto.Value.ToString("MM-dd-yyyy") + "','" + dtfrom.Value.ToString("MM-dd-yyyy") + "','" + dttimeto.Value.ToString("HH:mm") + "','" + dttimefrom.Value.ToString("HH:mm") + "','" + txt_trip_counter_befor.Text + "','" + txt_trip_counter_after.Text + "','"+dgv.Rows[i].Cells["code_items"].Value+"','"+ dgv.Rows[i].Cells["name_items"].Value + "','"+ dgv.Rows[i].Cells["qty_truk_c"].Value + "','"+ dgv.Rows[i].Cells["strohouse_name"].Value + "','" + dgv.Rows[i].Cells["strohouse_code"].Value + "','"+ dgv.Rows[i].Cells["station_name"].Value + "','"+ dgv.Rows[i].Cells["station_code"].Value + "','"+ dgv.Rows[i].Cells["no_voucher"].Value + "','"+ dgv.Rows[i].Cells["Loaded_distance"].Value + "','"+ dgv.Rows[i].Cells["unLoaded_distance"].Value + "','"+ dgv.Rows[i].Cells["f1c"].Value + "','"+ dgv.Rows[i].Cells["f2c"].Value + "','"+ dgv.Rows[i].Cells["f3c"].Value + "','"+ dt_piker.Value.ToString("MM-dd-yyyy") + "','"+v.usercode+"','"+v.username+"','"+ txt_destance.Text+ "','"+ num+ "','"+ dgv.Rows[i].Cells["f4c"].Value + "','"+ dgv.Rows[i].Cells["f5c"].Value + "')");
            }
        }


        private void save(String num_doc ,int numid)
        {
            // select_type_entry();

            string error = "";
            DataTable dt_term = new DataTable();
            cls_book.Make_entry_type_jop_number(ref dt_term, ref error, "سند امر شغل نقل", combo_type.Text, "", lbl_vcs.Text, lbl_f1.Text, lbl_f2.Text, lbl_f3.Text, lbl_f4.Text, lbl_f5.Text, lbl_sum.Text, lbl_rev.Text, lbl_boncae.Text, lbl_vat.Text);

            //get Entry GL
            txt_code_book.Text = db.GetData("select code_book from book where name_book='" + comb_code.Text + "'").Rows[0][0].ToString();
            string code_entry_term = (db.GetData("select code_entry from term where term_id='" + combo_type.Text + "' ").Rows[0][0].ToString());

            cls_book.Generat_numBooknum("entry", code_entry_term, ref numBook_entry, ref error, ref num_entry);
            txt_entry_string.Text = numBook_entry;

          //  cls_book.Generat_numBooknum("jn_jopnumber", txt_code_book.Text, ref numBook, ref error, ref num);
            txt_serial_string.Text = num_doc;
            double sum_term = 0;
            bool is_greatthan0 = false;
            {
                //1)insert into Entry
                //------------------
                string code_entry_dt = db.GetData("select (max(convert(int,(right( CODE_ENTRY , len(CODE_ENTRY)-3))))) from entry ").Rows[0][0].ToString();
                string code_entry_hd = db.GetData("select (max(convert(int,(right( CODE_ENTRY , len(CODE_ENTRY)-3))))) from entry_hd ").Rows[0][0].ToString();
                if (code_entry_dt != code_entry_hd)
                {
                    //string error_code = db.GetData("select (max(convert(int,(right( CODE_ENTRY , len(CODE_ENTRY)-3))))) from entry_hd ").Rows[0][0].ToString();
                    db.Run("delete from entry_hd where code_entry ='" + code_entry_hd + "'");
                }
                //entry_hd
                db.Run("insert into entry_hd ([code_entry],code_book) values ('" + txt_entry_string.Text + "','" + txt_code_entry_type.Text + "')");

                try
                {
                    //for (int z = 0; z < dgv_term.Rows.Count; z++)
                    //{
                    //    db.Run("insert into entry(  [code_entry]                           ,    acc_num                                                   ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                                          ,   type_acc                                                            , sort                                                       ,             depit                                                             ,                credit                                                   ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext,num_book )values('" +
                    //                              txt_entry_string.Text + "'            ,'" + dgv_term.Rows[z].Cells[1].Value.ToString() + "'     ,'" + dgv_term.Rows[z].Cells[2].Value.ToString() + "'               ,  '" + dgv_term.Rows[z].Cells["rootlevel_"].Value.ToString() + "'    ,  '" + dgv_term.Rows[z].Cells["rootlevel_name_"].Value.ToString() + "', '" + dgv_term.Rows[z].Cells["type_acc_"].Value.ToString() + "'       ,  '" + dgv_term.Rows[z].Cells["sort_"].Value.ToString() + "'  ,  '" + Convert.ToDecimal(dgv_term.Rows[z].Cells[3].Value.ToString()) + "'      ,'" + Convert.ToDecimal(dgv_term.Rows[z].Cells[4].Value.ToString()) + "' ,'" + txt_name_book_type.Text + "','" + txt_code_entry_type.Text + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + txt_serial_string.Text + "','" + txt_code_book.Text + "','','" + dgv_term.Rows[z].Cells["desc_type"].Value.ToString() + "','"+num_entry+"')");
                    //}
                    for (int z = 0; z < dt_term.Rows.Count; z++)

                    {
                        db.Run("insert into entry(  [code_entry]                           ,    acc_num                                                   ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                                          ,   type_acc                                                            , sort                                                       ,             depit                                                             ,                credit                                                                          ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext ,num_book)values('" +
                                            txt_entry_string.Text + "'            ,'" + dt_term.Rows[z][1] + "'     ,'" + dt_term.Rows[z][2] + "'               ,  '" + dt_term.Rows[z][5] + "'    ,                               '" + dt_term.Rows[z][6] + "',                                                         '" + dt_term.Rows[z][8] + "'       ,                        '" + dt_term.Rows[z][7] + "'  ,                               '" + Convert.ToDecimal(dt_term.Rows[z][3]) * Convert.ToDecimal(1) + "'      ,'" + Convert.ToDecimal(dt_term.Rows[z][4]) * Convert.ToDecimal(1) + "' ,'" + txt_name_book_type.Text + "','" + code_entry_term + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + txt_serial_string.Text + "','" + txt_code_book.Text + "','','','" + num_entry + "')");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }

            }
            //1)insert into JOP_NUMBER
            //--------------------------
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                db.Run("INSERT INTO jn_jopnumber (pin2,pin,price_stations,vcs_name,vcs_code,name_driver,code_driver,[code_book],[id]                      ,[id_truk]           ,[name_truck]               ,[date_from]                          ,[date_to]                      ,[time_to]                                 ,[time_from]                           ,[trip_counter_befor]                  ,[trip_counter_after]                                     ,[code_items]                           ,[name_items]                             ,[qty]                                   ,[strohouse_name]                                  ,[strohouse_code]                                   ,[station_name]                                  ,[station_code]                                ,[no_voucher],[Loaded_distance],[unLoaded_distance]           ,[fess1]           ,[fess2]           ,[fess3]          ,[date_d],[user_code],[user_name],[destance],num_book,[fess4],[fess5]) values ('0','0','" + db.GetData("select isnull(max(price),'0') from jn_station where id='" + dgv.Rows[i].Cells["col_code_station"].Value + "'").Rows[0][0].ToString() + "','" + combo_vcs_name.Text + "','" + lbl_vcs.Text + "','" + combo_emp.Text + "','" + lbl_code_emp.Text + "','" + txt_code_book.Text + "','" +
                                             txt_serial_string.Text + "','" + combo_truck.Text + "','" + lbl_code_truck.Text + "','" + dtto.Value.ToString("MM-dd-yyyy") + "','" + dtfrom.Value.ToString("MM-dd-yyyy") + "','" + dttimeto.Value.ToString("HH:mm") + "','" + dttimefrom.Value.ToString("HH:mm") + "','" + txt_trip_counter_befor.Text + "','" + txt_trip_counter_after.Text + "','" + dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "','" + dgv.Rows[i].Cells["qty_truk_c"].Value + "','" + dgv.Rows[i].Cells["strohouse_name"].Value + "','" + dgv.Rows[i].Cells["strohouse_code"].Value + "','" + dgv.Rows[i].Cells["station_name"].Value + "','" + dgv.Rows[i].Cells["station_code"].Value + "','" + dgv.Rows[i].Cells["no_voucher"].Value + "','" + dgv.Rows[i].Cells["Loaded_distance"].Value + "','" + dgv.Rows[i].Cells["unLoaded_distance"].Value + "','" + dgv.Rows[i].Cells["f1c"].Value + "','" + dgv.Rows[i].Cells["f2c"].Value + "','" + dgv.Rows[i].Cells["f3c"].Value + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + v.usercode + "','" + v.username + "','" + txt_destance.Text + "','" + numid + "','" + dgv.Rows[i].Cells["f4c"].Value + "','" + dgv.Rows[i].Cells["f5c"].Value + "')");
            }
        }

        private void delete()
        {
            //1-if doc lint with einvoice 
            if (db.GetData("select ISNULL(MAX(pin2),'0') from jn_jopnumber where id='" + txt_serial_string.Text + "'").Rows[0][0] + "" != "0")
            {
                string pin2 = db.GetData("select ISNULL(MAX(pin2),'') from jn_jopnumber where id='" + txt_serial_string.Text + "'").Rows[0][0] + "";
                MessageBox.Show(pin2 + " \n " + "لايمكن التعديل او الحذف علي المستندات حيث انة مربوط بفاتورة رقم  ");
                return;
            }
            //string inv = db.GetData("select isnull(max(pin2),'0') from jn_jopnumber where id='" + txt_serial_string.Text + "'").Rows[0][0] + "";
            //if (inv!="0")
            //{
            //    MessageBox.Show(inv+"  لا يمكن التعديل او حذف السند لانة مربوط بفاتورة مجمعة ");
            //    return;
            //}
            if (edite == true)
            {
                if (txt_serial_string.Text == "")
                {
                    XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "ماشي بس هو مفيش حاجه علشان امسحها دخل كود  طيب !!؟؟؟؟ ", "رسال حذف مستند", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    DialogResult dr;
                    dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, " هل تريد حذف السند!!؟؟؟؟ ", "رسال حذف مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (dr == DialogResult.OK)
                    {
                        //delte entry
                        DataTable codeEntry_tbl = new DataTable();
                        db.GetData_DGV("select code_entry from entry where code_entry<>'-11' and attachno='"+ txt_serial_string.Text+ "'", codeEntry_tbl);
                        for (int i = 0; i < codeEntry_tbl.Rows.Count; i++)
                        {
                            db.Run("delete from entry_hd where code_entry='" + codeEntry_tbl.Rows[i][0] + "'");
                            db.Run("delete from entry where code_entry='" + codeEntry_tbl.Rows[i][0] + "'");
                        }

                        //--------->>>
                        db.Run("delete from jn_jopnumber where id='" + txt_serial_string.Text + "'");
                        clear();
                    }
                }
            }

        }
        private void perform_save()
        {
         
            if (Convert.ToDouble(lbl_qty_truk.Text)!=51)
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "يجب ان تكون الكمية 51  ", "رسال خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (combo_emp.Text=="")
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "يجب اختيار السائق", "رسال خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (combo_truck.Text=="")
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "يجب اختيار رقم الشاحنة  ", "رسال خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txt_serial_string.Text=="")
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "لا يوجد رقم للدفتر  ", "رسال خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv.Rows[i].Cells[5].Value + "" == "" && Convert.ToInt32(dgv.Rows[i].Cells["qty_truk_c"].Value) > 1)
                {
                    MessageBox.Show("يجب اختيار المستودع ");
                    return;
                }
            }
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv.Rows[i].Cells[7].Value + "" == "" && Convert.ToInt32(dgv.Rows[i].Cells["qty_truk_c"].Value) > 1)
                {
                    MessageBox.Show("يجب اختيار محطة ");
                    return;
                }
            }

            if (edite==false)
            {
                
                save();
                MessageBox.Show("تم الحفظ");
                edite = true;

            }
            else
            {
                int numid = Convert.ToInt32(db.GetData("select isnull(max(num_book),'0') from jn_jopnumber where id='" + txt_serial_string.Text + "'").Rows[0][0] + "");
                if (numid == 0)
                {
                    XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "لا يمكن التعديل علي السند ", "رسال خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //1-if doc lint with einvoice 
                if (db.GetData("select ISNULL(MAX(pin2),'0') from jn_jopnumber where id='"+ txt_serial_string.Text+"'").Rows[0][0]+""!="0")
                {
                    string pin2 = db.GetData("select ISNULL(MAX(pin2),'') from jn_jopnumber where id='" + txt_serial_string.Text + "'").Rows[0][0] + "";
                    MessageBox.Show(pin2+" \n "+"لايمكن التعديل علي المستندات حيث انة مربوط بفاتورة رقم  ");
                    return;
                }

                //if (db.GetData("select ISNULL(MAX(pin2),'0') from jn_jopnumber where id='" + txt_entry_string.Text + "'").Rows[0][0] + "" == "0")
                //{
                //    string pin2 = db.GetData("select ISNULL(MAX(pin),'') from jn_jopnumber where id='" + txt_entry_string.Text + "'").Rows[0][0] + "";
                //    MessageBox.Show(pin2 + " \n " + "لايمكن التعديل علي المستندات حيث انة مربوط بفاتورة رقم  ");
                //    return;
                //}
                string inv = db.GetData("select isnull(max(pin),'0') from jn_jopnumber where id='" + txt_serial_string.Text + "'").Rows[0][0] + "";
                if (inv != "0")
                {
                    MessageBox.Show(inv + "  لايمكن التعديل علي السند لانة مستخدم  ");
                    return;
                }
                //delete
                //delte entry

                //string code = db.GetData("select top 1 code_entry from entry where attachno='" + txt_serial_string.Text + "' ").Rows[0][0].ToString();
                //db.Run("delete from entry_hd where code_entry='" + code + "'");
                //db.Run("delete from entry where code_entry='" + code + "'");
                //delte entry
                DataTable codeEntry_tbl = new DataTable();
                db.GetData_DGV("select code_entry from entry where code_entry<>'-11' and attachno='" + txt_serial_string.Text + "'", codeEntry_tbl);
                for (int i = 0; i < codeEntry_tbl.Rows.Count; i++)
                {
                    db.Run("delete from entry_hd where code_entry='" + codeEntry_tbl.Rows[i][0] + "'");
                    db.Run("delete from entry where code_entry='" + codeEntry_tbl.Rows[i][0] + "'");
                }

                //--------->>>
                db.Run("delete from jn_jopnumber where id='" + txt_serial_string.Text + "'");
                //  clear();
                save(txt_serial_string.Text, numid);
                MessageBox.Show("تم التعديل");
            }
        }
        private void clear()
        {
            edite = false;
            dgv.Rows.Clear();
            combo_truck.Text = "";
            combo_stations.Text = "";
            combo_storehouse.Text = "";
            combo_emp.Text = "";
            lbl_code_truck.Text = "";
            lbl_code_storehouse.Text = "";
            lbl_code_stations.Text = "";
            lbl_code_emp.Text = "";
            combo_vcs_name.Text = "";
            lbl_vcs.Text = "";
            lbl_qty_truk.Text = "0";
            txt_trip_counter_after.Text = "";
            txt_trip_counter_befor.Text = "";
            txt_destance.Text = "";
            dtto.Text = DateTime.Now.ToString("yyyy/MM/dd");
            dtfrom.Text = DateTime.Now.ToString("yyyy/MM/dd");

            dt_piker.Text = DateTime.Now.ToString("yyyy/MM/dd");
            cls_book.loadbook(this.comb_code, "سند امر شغل نقل");
            cls_book.load_from_term(combo_type, "سند امر شغل نقل");
            dgv.Rows.Add("1", "1001", "سولار");
            dgv.Rows.Add("2", "1002", "بنزين 95");
            dgv.Rows.Add("3", "1003", "بنزين 92");
            dgv.Rows.Add("4", "1004", "بنزين 80");
        }
        private void get_dt(string num)//get data detals
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("SELECT    code_items,name_items,qty,strohouse_code,strohouse_name,station_code,station_name,no_voucher,Loaded_distance,unLoaded_distance,fess1,fess2,fess3,fess4,fess5 FROM   jn_jopnumber where id='" + num + "'", dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv.Rows.Add(null, dt.Rows[i][0] + "", dt.Rows[i][1] + "",dt.Rows[i][2]+"", dt.Rows[i][3] + "", dt.Rows[i][4] + "", dt.Rows[i][5] + "", dt.Rows[i][6] + "", dt.Rows[i][7] + "", dt.Rows[i][8] + "", dt.Rows[i][9] + "", dt.Rows[i][10] + "", dt.Rows[i][11] + "", dt.Rows[i][12] + "",0, dt.Rows[i][13] + "", dt.Rows[i][14] + "");
            }
        }
        private void bode_of_navigation(string num, string book)
        {
            dgv.Rows.Clear();
          //  load_permission();
            //btn_barcode.Enabled = true;
            
           DataTable dt = new DataTable();
            db.GetData_DGV("select code_book from  jn_jopnumber  where id='" + num + "' and code_book='" + book + "' ", dt);
            if (dt.Rows.Count > 0)
            {
               // edit = true;
                get_dt(num);
                txt_serial_string.Text= db.GetData("select isnull(max(id),'-') from jn_jopnumber  where id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
                combo_truck.Text= db.GetData("select isnull(max(id_truk),'-') from jn_jopnumber  where id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
                combo_emp.Text=db.GetData("select isnull(max(name_driver),'-') from jn_jopnumber  where id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
                dtto.Text = db.GetData("select isnull(max(date_to),'-') from jn_jopnumber  where id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
                dtfrom.Text = db.GetData("select isnull(max(date_from),'-') from jn_jopnumber  where id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
                dttimeto.Text = db.GetData("select isnull(max(time_to),'-') from jn_jopnumber  where id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
                dttimefrom.Text = db.GetData("select isnull(max(time_from),'-') from jn_jopnumber  where id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
                txt_trip_counter_after.Text = db.GetData("select isnull(max(trip_counter_after),'-') from jn_jopnumber  where id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
                txt_trip_counter_befor.Text= db.GetData("select isnull(max(trip_counter_befor),'-') from jn_jopnumber  where id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
                txt_destance.Text = db.GetData("select isnull(max(destance),'-') from jn_jopnumber  where id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();

                combo_storehouse.Text= db.GetData("select isnull(max(strohouse_name),'-') from jn_jopnumber  where id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
                combo_stations.Text = db.GetData("select isnull(max(station_name),'-') from jn_jopnumber  where id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
                dt_piker.Text = db.GetData("select isnull(max(date_d),'-') from jn_jopnumber  where id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
                combo_vcs_name.Text= db.GetData("select isnull(max(vcs_name),'-') from jn_jopnumber  where id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
                lbl_vcs.Text = db.GetData("select isnull(max(vcs_code),'-') from jn_jopnumber  where id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();

                calc();
            
            }

        }
        //-------------Controla
        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            calc();
        }
        private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void labelControl9_Click(object sender, EventArgs e)
        {
            ship_jop.frm_storehouse f = new frm_storehouse();
            f.Show();
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {
            ship_jop.frm_station f = new frm_station();
            f.Show();
        }

        private void lbl_tot_price_inv_Click(object sender, EventArgs e)
        {
            ship_jop.frm_truck f = new frm_truck();
            f.Show();
        }

        private void btn_add_warehouse_Click(object sender, EventArgs e)
        {
            if (combo_storehouse.Text == "") return;
            if (dgv.Rows.Count < 0) return;

            dgv.CurrentRow.Cells[4].Value = lbl_code_storehouse.Text;
            dgv.CurrentRow.Cells[5].Value=combo_storehouse.Text;
        }

        private void btn_add_station_Click(object sender, EventArgs e)
        {
            if (combo_stations.Text == "") return;
            if (dgv.Rows.Count < 0) return;
            dgv.CurrentRow.Cells[6].Value = lbl_code_stations.Text;
            dgv.CurrentRow.Cells[7].Value = combo_stations.Text;
            dgv.CurrentRow.Cells["col_code_station"].Value = lbl_code_stations.Text;
            calc();

            //col_code_station

        }

        private void comb_code_SelectedIndexChanged(object sender, EventArgs e)
        {
            //load next field from load book "3lsahn el moshklal bta3at el combobox 
            txt_code_book.Text = db.GetData("select code_book from book where name_book='" + comb_code.Text + "'").Rows[0][0].ToString();
            //cls_book.selectbook("jn_jopnumber", "سند امر شغل نقل", txt_code_book.Text, txt_serial, "id");
            //txt_serial_string.Text = txt_code_book.Text + txt_serial.Text;
            cls_book.Generat_numBooknum("jn_jopnumber", txt_code_book.Text, ref numBook, ref error, ref num);
            txt_serial_string.Text = numBook;

        }

   

        private void label1_Click(object sender, EventArgs e)
        {
            frm_emp f = new frm_emp();
            f.Show();
        }

        private void combo_truck_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_code_truck.Text = db.GetData("select ISNULL(max(name),'0') from jn_truck where id='"+combo_truck.Text+"'").Rows[0][0].ToString();
        }

        private void combo_emp_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_code_emp.Text = db.GetData("select ISNULL(max(emp_no),'0') from emps where emp_name='" + combo_emp.Text + "'").Rows[0][0].ToString();
        }

        private void combo_warehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_code_storehouse.Text = db.GetData("select ISNULL(max(id),'0') from jn_storehouse where name='" + combo_storehouse.Text + "'").Rows[0][0].ToString();
        }

        private void comob_stations_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_code_stations.Text = db.GetData("select ISNULL(max(id),'0') from jn_station where name='" + combo_stations.Text + "'").Rows[0][0].ToString();
            lbl_price.Text = db.GetData("select ISNULL(max(price),'0') from jn_station where name='" + combo_stations.Text + "'").Rows[0][0].ToString();
        }
        private void combo_vcs_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_vcs.Text = db.GetData("select ISNULL(max(vcs_code),'0') from vcs where vcs_name='" + combo_vcs_name.Text + "'").Rows[0][0].ToString();

        }

        private void New_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //string num = "";
            //cls_book.Generat_numBook("سند امر شغل نقل", "id", "jn_jopnumber", ref num);
            //MessageBox.Show(num);
            DialogResult dr;
            dr = MessageBox.Show("هل تريد سند جديد!!؟؟؟؟ ", "رسال جديد مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                clear();
            }
        }


        private void combo_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            // txt_name_book_type.Text = db.GetData("select bookname_entry  from term  where term_id ='" + combo_type.Text + "'").Rows[0][0].ToString();
            //txt_code_entry_type.Text = db.GetData("select code_entry  from term  where term_id ='" + combo_type.Text + "'").Rows[0][0].ToString();
            //cls_book.selectbook("[entry]", "سند قيد", txt_code_entry_type.Text, txt_code_entry, "code_entry");

            string code_entry_term = (db.GetData("select code_entry from term where term_id='" + combo_type.Text + "' ").Rows[0][0].ToString());
            cls_book.Generat_numBooknum("entry", code_entry_term, ref numBook_entry, ref error, ref num_entry);
            txt_entry_string.Text = numBook_entry;
        }

      

        private void save_barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            perform_save();
        }

       

        private void btn_serchinv_Click(object sender, EventArgs e)
        {
            

        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
           

        }

        private void btn_delete_file_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            delete();
        }

       

        private void btn_first_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!(db.GetData("select min(convert(int,(right(id,LEN(id)-3)))) from jn_jopnumber where  code_book='" + txt_code_book.Text + "' ").Rows[0][0].ToString() != ""))
                    return;
                edite = true;

                txt_serial_string.Text = db.GetData("select min(convert(int,(right(id,LEN(id)-3)))) from jn_jopnumber where  code_book='" + txt_code_book.Text + "' ").Rows[0][0].ToString();
                bode_of_navigation(txt_code_book.Text + txt_serial_string.Text, txt_code_book.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btn_refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            all_comb.load_truck_id(combo_truck);
            all_comb.load_station_name(combo_stations);
            all_comb.load_storehouse_name(combo_storehouse);
            all_comb.load_emp_name(combo_emp);
            all_comb.load_name_vcs(combo_vcs_name);
            combo_vcs_name.Text = "";
            lbl_vcs.Text = "";
            combo_truck.Text = "";
            combo_stations.Text = "";
            combo_storehouse.Text = "";
            combo_emp.Text = "";
            lbl_code_truck.Text = "";
            lbl_code_storehouse.Text = "";
            lbl_code_stations.Text = "";
            lbl_code_emp.Text = "";
        }

     

        private void btn_last_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!(db.GetData("select max(convert(int,(right(id,LEN(id)-3)))) from jn_jopnumber where  code_book='" + txt_code_book.Text + "' ").Rows[0][0].ToString() != ""))
                    return;
                edite = true;

                txt_serial_string.Text = db.GetData("select max(convert(int,(right(id,LEN(id)-3)))) from jn_jopnumber where  code_book='" + txt_code_book.Text + "' ").Rows[0][0].ToString();
                this.bode_of_navigation(this.txt_code_book.Text + this.txt_serial_string.Text, this.txt_code_book.Text);
            }
            catch (Exception)
            {


            }
        }

     

        private void btn_back_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                    if (!(db.GetData("select min(convert(int,(right(id,LEN(id)-3)))) from jn_jopnumber where  code_book='" + txt_code_book.Text + "' ").Rows[0][0].ToString() != ""))
                        return;
                edite = true;
                new DataTable().Rows.Clear();
                string s1 = db.GetData("select min(convert(int,(right(id,LEN(id)-3)))) from jn_jopnumber where  code_book='" + txt_code_book.Text + "' ").Rows[0][0].ToString();

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
        private void btn_next_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                    if (!(db.GetData("select max(convert(int,(right(id,LEN(id)-3)))) from jn_jopnumber where  code_book='" + txt_code_book.Text + "' ").Rows[0][0].ToString() != ""))
                        return;
                edite = true;
                new DataTable().Rows.Clear();
                string s1 = db.GetData("select max(convert(int,(right(id,LEN(id)-3)))) from jn_jopnumber where  code_book='" + txt_code_book.Text + "' ").Rows[0][0].ToString();
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

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            group_find.Visible = true;
          

        }
        private void btn_close_f_Click_1(object sender, EventArgs e)
        {
            group_find.Visible =false;
        }
        private void btn_searchin_group_f1_Click(object sender, EventArgs e)
        {
            all_comb.load_jn_storehouse_docment(combo_document_f);
            combo_document_f.Text = "";
        }
        private void btn_searchin_group_f2_Click_1(object sender, EventArgs e)
        {
            all_comb.load_truck_id(combo_truck_f);
            combo_truck_f.Text = "";

        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            all_comb.load_storehouse_name(combo_storhose_f);
            combo_storhose_f.Text = "";

        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            all_comb.load_station_name(combo_stations_f);
            combo_stations_f.Text = "";

        }
        private void combo_document_f_SelectedIndexChanged(object sender, EventArgs e)
        {
            find("id", combo_document_f.Text);


        }
        private void combo_truck_f_SelectedIndexChanged(object sender, EventArgs e)
        {
            find("id_truk", combo_truck_f.Text);

        }

        private void combo_storhose_f_SelectedIndexChanged(object sender, EventArgs e)
        {
            find("strohouse_name", combo_storhose_f.Text);

        }
        private void combo_stations_f_SelectedIndexChanged(object sender, EventArgs e)
        {
            find("station_name", combo_stations_f.Text);
        }
        private void btn_searchin_group_f3_Click(object sender, EventArgs e)
        {

        }

        private void btn_searchin_group_f2_Click(object sender, EventArgs e)
        {

        }

        private void btn_close_f_Click(object sender, EventArgs e)
        {

        }

        private void combo_vcs_name_f_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void combo_vcs_name_f_Click(object sender, EventArgs e)
        {

        }

        private void btn_searchin_group_f_Click(object sender, EventArgs e)
        {

        }

        private void combo_document_f_Click(object sender, EventArgs e)
        {

        }

        
        private void dgv_f_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (dgv_f.Rows.Count == 0) return;
               
                bode_of_navigation(dgv_f.CurrentRow.Cells["id_f"].Value.ToString(), dgv_f.CurrentRow.Cells["code_book_f"].Value.ToString());
                group_find.Visible = false;

            }
            catch (Exception)
            {


            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            frm_customer f = new frm_customer();
            f.Show();
        }

        
        private void txt_serial_string_Leave(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    if (!(db.GetData("select max(convert(int,(right(id,LEN(id)-3)))) from jn_jopnumber where  code_book='" + txt_code_book.Text + "' ").Rows[0][0].ToString() != ""))
                        return;
                    bode_of_navigation(txt_serial_string.Text, txt_code_book.Text);
                    edite = true;
                }
                catch (Exception)
                {


                }
            }
            catch (Exception)
            {

            }
        }

        private void dgv_entry_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv_entry, "no_e"); 
        }

       

        private void btn_getEntry_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("select acc_num,acc_name,depit,credit,attachnamebook,attachtext from entry where attachno='" + txt_serial_string.Text + "'or attachno2='" + txt_serial_string.Text + "'", dt);
            dgv_entry.DataSource = dt;
        }

        private void btn_remove_station_Click(object sender, EventArgs e)
        {
            if (combo_stations.Text == "") return;
            if (dgv.Rows.Count < 0) return;
            dgv.CurrentRow.Cells[6].Value = "";
            dgv.CurrentRow.Cells[7].Value = "";
        }

        private void btn_pending_close_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {

        }

        private void btn_searchin_group_f3_Click_1(object sender, EventArgs e)
        {

        }

        private void simpleButton4_Click_1(object sender, EventArgs e)
        {
           // select_type_entry();
            string error = "";
            DataTable dt_term = new DataTable();
            cls_book.Make_entry_type_jop_number(ref dt_term, ref error, "سند امر شغل نقل", combo_type.Text, "", lbl_vcs.Text, lbl_f1.Text, lbl_f2.Text, lbl_f3.Text, lbl_f4.Text, lbl_f5.Text ,lbl_sum.Text, lbl_rev.Text, lbl_boncae.Text, lbl_vat.Text);

        }

        private void printer_previeew_barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            XtraReport xtraReport = XtraReport.FromFile("forms\\jopnumber.repx", true);
            xtraReport.Parameters["parameter1"].Value = txt_serial_string.Text;
            xtraReport.Parameters["parameter1"].Visible = false;
            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
        }
        private void printer_direct_barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraReport xtraReport = XtraReport.FromFile("forms\\jopnumber.repx", true);
            xtraReport.Parameters["parameter1"].Value = txt_serial_string.Text;
            xtraReport.Parameters["parameter1"].Visible = false;
            xtraReport.PrinterName = Settings.Default.printer_a4;
            xtraReport.PrintAsync();
        }
        private void btn_remove_warehouse_Click(object sender, EventArgs e)
        {
            if (combo_storehouse.Text == "") return;
            if (dgv.Rows.Count < 0) return;

            dgv.CurrentRow.Cells[4].Value = "";
            dgv.CurrentRow.Cells[5].Value = "";
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv.Rows[i].Cells[5].Value+""=="" && Convert.ToInt32(dgv.Rows[i].Cells["qty_truk_c"].Value) >1)
                {
                    MessageBox.Show("يجب اختيار المستودع ");
                    return;
                }
            }
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv.Rows[i].Cells[7].Value + "" == "" && Convert.ToInt32(dgv.Rows[i].Cells["qty_truk_c"].Value) > 1)
                {
                    MessageBox.Show("يجب اختيار محطة ");
                    return;
                }
            }
        }

    }
}