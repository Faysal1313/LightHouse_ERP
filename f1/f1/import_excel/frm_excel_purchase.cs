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
using System.Data.OleDb;
using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;

namespace f1.Classes
{
    public partial class frm_excel_purchase : DevExpress.XtraEditors.XtraForm
    {
        public frm_excel_purchase()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon("f1.exe");
            db.Open();
        }
        private void frm_excel_purchase_Load(object sender, EventArgs e)
        {
            cls_book.loadbook(comb_code_name, "سند فاتوره مشتريات");
            cls_book.load_from_term(combo_type, "سند فاتوره مشتريات");
            progressBar1.Visible = false;
            valid_barButtonItem3.Enabled=false;
            save_barButtonItem4.Enabled = false;

        }
        //Function
        //-----------------------------------------------------------------------
        int prog = 0;
        private void open_excel()
        {
            string path = Environment.CurrentDirectory;
            string mysheet = path + "\\Import_Excel\\purchase.xlsx";
            //??????????????????????????????????????????????????????????????????????
            //??????????????????????????????????????????????????????????????????????
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>ERROR >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //??????????????????????????????????????????????????????????????????????

            //var excelapp = new Excel.Application();
            //excelapp.Visible = true;
            //Excel.Workbooks books = excelapp.Workbooks;
            //Excel.Workbook sheet = books.Open(mysheet);
        }
        private void load_excel()
        {
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Import_Excel//purchase.xlsx;Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;MAXSCANROWS=0'");
            OleDbCommand cmd = new OleDbCommand("select * from [purchase$]", conn);
            //  cmd.CommandText = "select * from [Sheet1$] where CategoryID=1";
            DataTable dt = new DataTable();
            conn.Open();
            dt.Load(cmd.ExecuteReader());
            conn.Close();
            dgv.Invoke((MethodInvoker)delegate
            {
                dgv.DataSource = dt;
            });
          //  lbl_1.Text += "\n" + DateTime.Now.ToString("hh:mm:ss." + DateTime.Now.Ticks);
          //  lbl_1.Text += "\n" + (dgv.Rows.Count - 1);
        
        }
        private  void valid() //VALID FOR vcs code items term
        {
            progressBar1.Visible = true;
            //get last no in excel
            txt_last_number.Text = dgv.Rows[dgv.Rows.Count - 1].Cells[0].Value.ToString();
            lbl_state_line.Caption = dgv.Rows.Count+"";
            //make null = 0
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].Cells["tot_bef"].Value = 0;
                dgv.Rows[i].Cells["discount"].Value = 0;
                dgv.Rows[i].Cells["tot_after_dis"].Value = 0;
                dgv.Rows[i].Cells["incloud_taxes"].Value = 0;
                dgv.Rows[i].Cells["taxes_value"].Value = 0;
                dgv.Rows[i].Cells["taxes"].Value = 0;

            }

            string code_vcs = "";
            string code_items = "";
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                prog = dgv.Rows.Count;//to know progras bar 

                code_vcs = db.GetData("select isnull(max(vcs_name),0) from vcs where vcs_code='" + dgv.Rows[i].Cells["vcs_code"].Value.ToString() + "' ").Rows[0][0].ToString();
               // dgv2.Rows.Add(code_vcs);
                if (code_vcs=="0")
                {
                    MessageBox.Show("invalid CODE VCS  "+dgv.Rows[i].Cells["vcs_code"].Value.ToString());
                    return;
                }
                code_items = db.GetData("select isnull(max(name_items),0) from items where code_items='" + dgv.Rows[i].Cells["code_items"].Value.ToString() + "' ").Rows[0][0].ToString();

                if (code_items== "0")
                {
                    MessageBox.Show("invalid CODE ITEM  " + dgv.Rows[i].Cells["code_items"].Value.ToString());
                    return;
                }

                dgv_valid.Rows.Add(code_vcs, code_items);
                backgroundWorker1.ReportProgress(i);
                
            }
            calc_all();
            save_barButtonItem4.Enabled = true;
            progressBar1.Visible = false;

        }
        private void calc_all()//calc qty price taxes totbef 
        {
            try
            {
                //////////////  cala total =qty* price-des
                //  tot_bef, discount, tot_after_dis, taxes, incloud_taxes
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    dgv.Rows[i].Cells["tot_bef"].Value = ((Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value)) * (Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value)) * Convert.ToDecimal(dgv.Rows[i].Cells["item_price"].Value));
                    dgv.Rows[i].Cells["discount"].Value = Convert.ToDecimal(dgv.Rows[i].Cells["discount"].Value);
                    //calc tot=(qty*price)*(1-discount)
                    dgv.Rows[i].Cells["tot_after_dis"].Value = (Convert.ToDecimal(dgv.Rows[i].Cells["tot_bef"].Value)) - ((Convert.ToDecimal(dgv.Rows[i].Cells["discount"].Value)));
                    dgv.Rows[i].Cells["incloud_taxes"].Value = (Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) * (1 + Convert.ToDecimal(dgv.Rows[i].Cells["taxes"].Value)));
                    dgv.Rows[i].Cells["taxes_value"].Value = (Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) * (Convert.ToDecimal(dgv.Rows[i].Cells["taxes"].Value)));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        string code_entry, sort, rootlevel, rootlevel_name, type_acc;
        private void select_type_entry(string combo_wars, string combo_vsc_codetree, string lbl_tot_befor_, string lbl_tot_after_dis_, string lbl_discount_, string lbl_incloud_taxes_,  string lbl_taxes_values_)
        {
            dgv_term.Rows.Clear();

            //book loaded:-
            //cls_book.load_from_terms(comb_type);
            //=============insert in dgv term 
            string term_id, rootid, rootname, depit, credit;

            int count = Convert.ToInt32(db.GetData("select count(term_id) from term where term_id='" + combo_type.Text + "' and cat_book='سند فاتوره مشتريات'").Rows[0][0].ToString());
            code_entry = (db.GetData("select code_entry from term where term_id='" + combo_type.Text + "' and cat_book='سند فاتوره مشتريات'").Rows[0][0].ToString());
            string bookname_entry = (db.GetData("select bookname_entry from term where term_id='" + combo_type.Text + "' and cat_book='سند فاتوره مشتريات'").Rows[0][0].ToString());
            int c = 0;
            while (c < count)
            {
                int i = c++;
                term_id = db.GetData("select term_id from term where term_id='" + combo_type.Text + "'").Rows[i][0].ToString();
                rootid = db.GetData("select rootid from term where term_id='" + combo_type.Text + "'").Rows[i][0].ToString();
                rootname = db.GetData("select rootname from term where term_id='" + combo_type.Text + "'").Rows[i][0].ToString();
                depit = db.GetData("select depit from term where term_id='" + combo_type.Text + "'").Rows[i][0].ToString();
                credit = db.GetData("select credit from term where term_id='" + combo_type.Text + "'").Rows[i][0].ToString();
                //==============================================

                if (rootname.Length > 52)//wares
                {
                    rootid = db.GetData("" + rootid + "" + combo_wars + "" + "").Rows[0][0].ToString();
                    rootname = db.GetData("" + rootname + "" + combo_wars + "" + "").Rows[0][0].ToString();
                    rootlevel = db.GetData("select rootlevel from tree where rootid='" + rootid + "'").Rows[0][0].ToString();
                    rootlevel_name = "0";
                    type_acc = db.GetData("select sort from tree where rootid='" + rootid + "'").Rows[0][0].ToString();
                    sort = "1";
                }
                else if (rootname.Length > 39)//vendor or clint 
                {
                    if (combo_vsc_codetree == "") { MessageBox.Show("اختار مورد او عميل"); return; }
                    rootid = db.GetData("" + rootid + "" + combo_vsc_codetree+ "" + "").Rows[0][0].ToString();
                    rootname = db.GetData("" + rootname + "" + combo_vsc_codetree + "" + "").Rows[0][0].ToString();
                    rootlevel = db.GetData("select rootlevel from vcs where vcs_code='" + combo_vsc_codetree + "'").Rows[0][0].ToString();
                    rootlevel_name = db.GetData("select rootlevel_name from vcs where vcs_code='" + combo_vsc_codetree + "'").Rows[0][0].ToString();
                    type_acc = db.GetData("select sort from vcs where vcs_code='" + combo_vsc_codetree+ "'").Rows[0][0].ToString();

                    sort = "2";

                    //       MessageBox.Show(sort + "");
                }
                else //other (fixed account)
                {
                    rootlevel = db.GetData("select rootlevel from tree where rootid='" + rootid + "'").Rows[0][0].ToString();
                    rootlevel_name = "0";
                    type_acc = db.GetData("select sort from tree where rootid='" + rootid + "'").Rows[0][0].ToString();

                    sort = "1";

                }
                //==================================================

                //========fill field tot or tot_bef or discount=======
                if (depit == "tot_befor")
                {
                    depit = lbl_tot_befor_;
                }
                else if (depit == "tot_after_dis")
                {
                    depit = lbl_tot_after_dis_;
                }
                else if (depit == "discount")
                {
                    depit = lbl_discount_;
                }
                else if (depit == "incloud_taxes")
                {
                    depit = lbl_incloud_taxes_;
                }
                else if (depit == "taxtes")
                {
                    depit = lbl_taxes_values_;
                }
                else
                {
                    depit = "0";
                }
                if (credit == "tot_befor")
                {
                    credit = lbl_tot_befor_;
                }
                else if (credit == "tot_after_dis")
                {
                    credit = lbl_tot_after_dis_;
                }
                else if (credit == "discount")
                {
                    credit = lbl_discount_;
                }
                else if (credit == "incloud_taxes")
                {
                    credit = lbl_incloud_taxes_;
                }
                else if (credit == "taxtes")
                {
                    credit = lbl_taxes_values_;
                }
                else
                {
                    credit = "0";
                }
                //=========================================================
                // dgv_term.Rows.Clear();
                dgv_term.Rows.Add(term_id, rootid, rootname, depit, credit, rootlevel, rootlevel_name, sort, type_acc);


            }
            //============end of terms        
        }
        private void generat_get_book()
        {
            txt_code_book.Text = db.GetData("select code_book from book where name_book='" + comb_code_name.Text + "'").Rows[0][0].ToString();
            cls_book.selectbook("purchase_hd", "سند فاتوره مشتريات", txt_code_book.Text, txt_serial, "purchase_hd_id");
            txt_serial_string.Text = txt_code_book.Text + txt_serial.Text;
        }
        private void generat_entry_book()
        {
            //get only number for one user Entry
            txt_entry_string.Text = txt_code_entry_type.Text + txt_code_entry.Text;
            cls_book.selectbook("entry_hd", "سند قيد", txt_code_entry_type.Text, txt_code_entry, "code_entry");
            txt_entry_string.Text = txt_code_entry_type.Text + txt_code_entry.Text;
        
        
        }
        //simle contols
        private void open_barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            open_excel();
        }
        private void combo_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_name_book_type.Text = db.GetData("select bookname_entry  from term  where term_id ='" + combo_type.Text + "'").Rows[0][0].ToString();
            txt_code_entry_type.Text = db.GetData("select code_entry  from term  where term_id ='" + combo_type.Text + "'").Rows[0][0].ToString();
            cls_book.selectbook("entry_hd", "سند قيد", txt_code_entry_type.Text, txt_code_entry, "code_entry");
        }
        private void delete_btn_Click(object sender, EventArgs e)
        {
            db.Run("delete  from entry where code_entry >'-11' delete from entry_hd \n delete from exp_date \n delete from pay_dt \n delete from pay_hd \n delete from purchase_dt \n delete from purchase_hd \n delete from sale_dt \n delete from sale_hd \n delete from items_trans \n delete from opening_qty  \n  update wares set qty ='0'  \n update wares set cost='0' \n delete from center");
            MessageBox.Show("delete files");
        }
        private async void load_barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            save_barButtonItem4.Enabled = false;
            await Task.Run(new Action(load_excel));
            if (dgv.Rows.Count >0)
            {
                  valid_barButtonItem3.Enabled=true;

            }
        }
        private  void valid_barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            valid();
        }
        private async void save_barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txt_last_number.Text == "")
            {
                MessageBox.Show("wright last invoice number ");
                return;
            }
            valid_barButtonItem3.Enabled=false;
            save_barButtonItem4.Enabled = false;
            load_barButtonItem2.Enabled = false;
            string x_string = "";
            int n = 0;
            //vriable getbook
            string vriable_book = "";
            string vriable_book_entry = "";
            decimal qty_ware_additems = 0;
            Decimal totalcost = 0;
            Decimal totalqty = 0;
            String totalcoststring = "";
            int count_1 = 0;
            int count = dgv.Rows.Count ;
            int count_last=0;
            int number_of_loop = 0;
            //generat get book 
            generat_get_book();
            generat_entry_book();
            //vriable =generat_book
            vriable_book = txt_serial_string.Text;
            vriable_book_entry = txt_entry_string.Text;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                progressBar1.Visible = true;
                prog = dgv.Rows.Count;//to know progras bar 
                number_of_loop += 1;
                lbl_number_of_loop.Caption = number_of_loop + "";
                lbl_remin_loop.Caption = count - number_of_loop + "";
                int x = Convert.ToInt32(dgv.Rows[i].Cells[0].Value);
                //int x_old = 0;
                //...................................................................(1).............................................................................................................
                if (x == 1 + n)
                {
                    count_1 += 1;
                    dgv4.Rows.Add(x, dgv.Rows[i].Cells["code_items"].Value.ToString(), dgv.Rows[i].Cells["name_items"].Value.ToString(), dgv.Rows[i].Cells["name_unite"].Value.ToString(), dgv.Rows[i].Cells["f_unite"].Value.ToString(), dgv.Rows[i].Cells["exp"].Value.ToString(), dgv.Rows[i].Cells["type"].Value.ToString(), (dgv.Rows[i].Cells["exp_date"].Value).ToString(), (dgv.Rows[i].Cells["qty"].Value).ToString(), (dgv.Rows[i].Cells["item_price"].Value).ToString(), (dgv.Rows[i].Cells["tot_bef"].Value).ToString(), (dgv.Rows[i].Cells["discount"].Value).ToString(), (dgv.Rows[i].Cells["tot_after_dis"].Value).ToString(), (dgv.Rows[i].Cells["taxes"].Value).ToString(), (dgv.Rows[i].Cells["incloud_taxes"].Value).ToString(), (dgv.Rows[i].Cells["taxes_value"].Value).ToString(), (dgv.Rows[i].Cells["id_ware"].Value).ToString(), dgv.Rows[i].Cells["vcs_code"].Value.ToString(), dgv.Rows[i].Cells["vcs_name"].Value.ToString(), dgv.Rows[i].Cells["date_p"].Value.ToString());

                    //insert purchas_dt
                    db.cmd.CommandText=("insert into purchase_dt(purchase_hd_id ,         code_book ,                       name_book         ,                       code_items              ,                        name_items             ,                                         qty             ,                                      item_price                  ,                                         tot_bef             ,                                         discount             ,                                         tot_after_dis             ,                                        taxes              ,                                        incloud_taxes                 ,                                          taxes_value             ,                                                         id_ware                   ,                 f_unite              ,                                                    name_unite                                                                                              ,                                      [exp]                                    ,            exp_date          ,[type]) values('" +
                                        txt_serial_string.Text + "','" + txt_code_book.Text + "', '" + comb_code_name.Text + "','" + dgv.Rows[i].Cells["code_items"].Value + "','" + dgv_valid.Rows[i].Cells["name_items_c"].Value + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["item_price"].Value) + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_bef"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["discount"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["taxes"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["incloud_taxes"].Value) + "',(select taxes from items where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'),'" + (dgv.Rows[i].Cells["id_ware"].Value) + "','" + (dgv.Rows[i].Cells["f_unite"].Value) + "',(select name_unite from unite where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and unite='" + (dgv.Rows[i].Cells["f_unite"].Value) + "')   ,                   '" + Convert.ToBoolean((dgv.Rows[i].Cells["exp"].Value)) + "',            Null              ,'" + (dgv.Rows[i].Cells["type"].Value) + "')");
                    await db.cmd.ExecuteNonQueryAsync();

                    //\\cost....................
                    //A)update ware qty:-
                    //________________________
                    if (dgv.Rows[i].Cells["type"].Value.ToString() == "1")
                    {
                        //update wares
                        qty_ware_additems = Convert.ToDecimal(db.GetData("select isnull((sum(qty)),0) from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'").Rows[0][0].ToString());
                        db.cmd.CommandText = ("update wares set qty =(" + Convert.ToDecimal(qty_ware_additems) + " + " + (Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value)) * (Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value)) + ") where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'");
                        await db.cmd.ExecuteNonQueryAsync();

                        //B) update cost:= total / QTY  and update cost for ware
                        //_______________________________________________

                        //qty from wares =0
                        if (qty_ware_additems == 0)
                        {
                            //update cost direct from price purchase 
                            db.cmd.CommandText = ("update wares set cost =" + Convert.ToDecimal((dgv.Rows[i].Cells["tot_after_dis"].Value)) / Convert.ToDecimal((dgv.Rows[i].Cells["qty"].Value)) + " where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'");
                            await db.cmd.ExecuteNonQueryAsync();

                        }
                        //qty from wares != 0
                        else if (qty_ware_additems != 0)
                        {
                            totalqty = Convert.ToDecimal(db.GetData("select sum(qty * f_unite) from purchase_dt where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'").Rows[0][0].ToString());
                            if (totalqty == 0) totalqty = 1;
                            totalcoststring = (Convert.ToString(db.GetData("select sum(tot_after_dis) from purchase_dt where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'").Rows[0][0]));
                            if (totalcoststring == "") totalcoststring = (Convert.ToString(dgv.Rows[i].Cells["tot_after_dis"].Value));
                            //MessageBox.Show(totalcoststring);
                            totalcost = Convert.ToDecimal(totalcoststring);
                            db.cmd.CommandText = ("update wares set cost =" + (totalcost / totalqty) + " where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'");
                            await db.cmd.ExecuteNonQueryAsync();

                        }
                        //c)insert exp_date cost:-
                        //_______________________
                        if (dgv.Rows[i].Cells["exp"].Value.ToString() == "True")
                        {
                            db.cmd.CommandText = ("insert into exp_date (code_items,name_items,exp_date,qty,cost,id_ware,code,code_book) values('" + dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "','" + Convert.ToDateTime(dgv.Rows[i].Cells["exp_date"].Value).ToString("MM-dd-yyyy") + "','" + (Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value)) * (Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value)) + "','" + dgv.Rows[i].Cells["tot_after_dis"].Value + "','" + dgv.Rows[i].Cells["id_ware"].Value + "','" + txt_serial_string.Text + "','" + txt_code_book.Text + "')");
                            await db.cmd.ExecuteNonQueryAsync();

                        }
                        if (count == Convert.ToInt32(count_1))
                        {
                            //x_old for loop
                            decimal tot_bef = 0;
                            decimal discount = 0;
                            decimal tot_after_dis = 0;
                            decimal taxes_value = 0;
                            decimal incloud_taxes = 0;
                            for (int ii = 0; ii < dgv4.Rows.Count; ii++)
                            {
                                //========to get calc

                                dgv4.Rows[ii].Cells["tot_bef_de"].Value = ((Convert.ToDecimal(dgv4.Rows[ii].Cells["qty_de"].Value)) * (Convert.ToDecimal(dgv4.Rows[ii].Cells["f_unite_de"].Value)) * Convert.ToDecimal(dgv4.Rows[ii].Cells["item_price_de"].Value));
                                dgv4.Rows[ii].Cells["discount_de"].Value = Convert.ToDecimal(dgv4.Rows[ii].Cells["discount_de"].Value);
                                //calc tot=(qty*price)*(1-discount)
                                dgv4.Rows[ii].Cells["tot_after_dis_de"].Value = (Convert.ToDecimal(dgv4.Rows[ii].Cells["tot_bef_de"].Value)) - ((Convert.ToDecimal(dgv4.Rows[ii].Cells["discount_de"].Value)));
                                dgv4.Rows[ii].Cells["incloud_taxes_de"].Value = (Convert.ToDecimal(dgv4.Rows[ii].Cells["tot_after_dis_de"].Value) * (1 + Convert.ToDecimal(dgv4.Rows[ii].Cells["taxes_de"].Value)));
                                dgv4.Rows[ii].Cells["taxes_value_de"].Value = (Convert.ToDecimal(dgv4.Rows[ii].Cells["tot_after_dis_de"].Value) * (Convert.ToDecimal(dgv4.Rows[ii].Cells["taxes_de"].Value)));


                                tot_bef += Convert.ToDecimal(dgv4.Rows[ii].Cells["tot_bef_de"].Value);
                                discount += Convert.ToDecimal(dgv4.Rows[ii].Cells["discount_de"].Value);
                                tot_after_dis += Convert.ToDecimal(dgv4.Rows[ii].Cells["tot_after_dis_de"].Value);
                                incloud_taxes += Convert.ToDecimal(dgv4.Rows[ii].Cells["incloud_taxes_de"].Value);
                                taxes_value += Convert.ToDecimal(dgv4.Rows[ii].Cells["taxes_value_de"].Value);
                                //========
                            }
                            //insert hd:-
                            db.cmd.CommandText = ("insert into purchase_hd(purchase_hd_id              ,            code_book         ,name_book                          ,   vcs_code                                                ,      vcs_name                                                                                  ,           date_P                                                                                   ,         term           ,         tot_befor                                    ,           discount               ,               tot_after_dis                 ,           taxes                        ,incloud_taxes                                     ,    id_ware                                                   ,code_entry                     ,book_name_entry                     ,code_book_entry                     ,note_txt                        ,           user_name        ,  user_code                   ,lock)values('"
                                                        + txt_serial_string.Text + "', '" + txt_code_book.Text + "' ,'" + comb_code_name.Text + "'      ,'" + dgv4.Rows[0].Cells["vcs_code"].Value.ToString() + "',(select vcs_name from vcs where vcs_code='" + dgv4.Rows[0].Cells["vcs_code"].Value.ToString() + "'),'" + Convert.ToDateTime(dgv4.Rows[0].Cells["date_p"].Value).ToString("MM-dd-yyyy") + "'             ,'" + combo_type.Text + "',    '" + Math.Round(tot_bef, 2) + "'                  ,'" + Math.Round(discount, 2) + "' ,      '" + Math.Round(tot_after_dis, 2) + "' ,    '" + Math.Round(taxes_value, 2) + "','" + Math.Round(incloud_taxes, 2) + "'           ,'" + dgv4.Rows[0].Cells["id_ware_de"].Value.ToString() + "'   ,'" + 0 + "'                   ,'" + txt_name_book_type.Text + "','" + txt_code_entry_type.Text + "','" + "import purchase by Excel" + "','" + "lbl_user_name.Text" + "','" + "lbl_user_code.Text" + "','0')");
                            await db.cmd.ExecuteNonQueryAsync();

                            //entry_hd and dt
                            select_type_entry(dgv4.Rows[0].Cells["id_ware_de"].Value.ToString(), dgv4.Rows[0].Cells["vcs_code"].Value.ToString(), tot_bef + "", tot_after_dis + "", discount + "", incloud_taxes + "", taxes_value + "");
                            db.cmd.CommandText = ("insert into entry_hd ([code_entry],code_book) values ('" + txt_entry_string.Text + "','" + txt_code_entry_type.Text + "')");
                            for (int z = 0; z < dgv_term.Rows.Count; z++)
                            {
                                db.cmd.CommandText = ("insert into entry(  [code_entry]                           ,    acc_num                                                   ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                                          ,   type_acc                                                            , sort                                                       ,             depit                                                             ,                credit                                                   ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext )values('" +
                                                          txt_entry_string.Text + "'            ,'" + dgv_term.Rows[z].Cells[1].Value.ToString() + "'     ,'" + dgv_term.Rows[z].Cells[2].Value.ToString() + "'               ,  '" + dgv_term.Rows[z].Cells["rootlevel_"].Value.ToString() + "'    ,  '" + dgv_term.Rows[z].Cells["rootlevel_name_"].Value.ToString() + "', '" + dgv_term.Rows[z].Cells["type_acc_"].Value.ToString() + "'       ,  '" + dgv_term.Rows[z].Cells["sort_"].Value.ToString() + "'  ,  '" + Convert.ToDecimal(dgv_term.Rows[z].Cells[3].Value.ToString()) + "'      ,'" + Convert.ToDecimal(dgv_term.Rows[z].Cells[4].Value.ToString()) + "' ,'" + txt_name_book_type.Text + "','" + txt_code_entry_type.Text + "'    ,'" + Convert.ToDateTime(dgv4.Rows[0].Cells["date_p"].Value).ToString("MM-dd-yyyy") + "','" + txt_serial_string.Text + "','" + txt_code_book.Text + "','" + comb_code_name.Text + "','" + "insert purchase by Excel" + "')");
                                await db.cmd.ExecuteNonQueryAsync();

                            }
                        }
                    }
                    //\\end cost................

                }
                //...................................................................................(2)...........................................
                else if (x_string == "" && x == Convert.ToInt32(txt_last_number.Text))//last count number in invoice
                {
                    count_last += 1;
                   //count 10-number of loop-1
                    int remaind_loop = count - (number_of_loop );
                    dgv4.Rows.Add(x, dgv.Rows[i].Cells["code_items"].Value.ToString(), dgv.Rows[i].Cells["name_items"].Value.ToString(), dgv.Rows[i].Cells["name_unite"].Value.ToString(), dgv.Rows[i].Cells["f_unite"].Value.ToString(), dgv.Rows[i].Cells["exp"].Value.ToString(), dgv.Rows[i].Cells["type"].Value.ToString(), (dgv.Rows[i].Cells["exp_date"].Value).ToString(), (dgv.Rows[i].Cells["qty"].Value).ToString(), (dgv.Rows[i].Cells["item_price"].Value).ToString(), (dgv.Rows[i].Cells["tot_bef"].Value).ToString(), (dgv.Rows[i].Cells["discount"].Value).ToString(), (dgv.Rows[i].Cells["tot_after_dis"].Value).ToString(), (dgv.Rows[i].Cells["taxes"].Value).ToString(), (dgv.Rows[i].Cells["incloud_taxes"].Value).ToString(), (dgv.Rows[i].Cells["taxes_value"].Value).ToString(), (dgv.Rows[i].Cells["id_ware"].Value).ToString(), dgv.Rows[i].Cells["vcs_code"].Value.ToString(), dgv.Rows[i].Cells["vcs_name"].Value.ToString(), dgv.Rows[i].Cells["date_p"].Value.ToString());
                    //insert purchas_dt
                    db.cmd.CommandText = ("insert into purchase_dt(purchase_hd_id ,         code_book ,                       name_book         ,                       code_items              ,                        name_items             ,                                         qty             ,                                      item_price                  ,                                         tot_bef             ,                                         discount             ,                                         tot_after_dis             ,                                        taxes              ,                                        incloud_taxes                 ,                                          taxes_value             ,                                                         id_ware                   ,                 f_unite              ,                                                    name_unite                                                                                              ,                                      [exp]                                    ,            exp_date          ,[type]) values('" +
                                        txt_serial_string.Text + "','" + txt_code_book.Text + "', '" + comb_code_name.Text + "','" + dgv.Rows[i].Cells["code_items"].Value + "','" + dgv_valid.Rows[i].Cells["name_items_c"].Value + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["item_price"].Value) + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_bef"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["discount"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["taxes"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["incloud_taxes"].Value) + "',(select taxes from items where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'),'" + (dgv.Rows[i].Cells["id_ware"].Value) + "','" + (dgv.Rows[i].Cells["f_unite"].Value) + "',(select name_unite from unite where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and unite='" + (dgv.Rows[i].Cells["f_unite"].Value) + "')   ,                   '" + Convert.ToBoolean((dgv.Rows[i].Cells["exp"].Value)) + "',            Null              ,'" + (dgv.Rows[i].Cells["type"].Value) + "')");
                    await db.cmd.ExecuteNonQueryAsync();

                    //\\cost....................
                    //A)update ware qty:-
                    //________________________
                    if (dgv.Rows[i].Cells["type"].Value.ToString() == "1")
                    {
                        //update wares
                        qty_ware_additems = Convert.ToDecimal(db.GetData("select isnull((sum(qty)),0) from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'").Rows[0][0].ToString());
                        db.cmd.CommandText = ("update wares set qty =(" + Convert.ToDecimal(qty_ware_additems) + " + " + (Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value)) * (Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value)) + ") where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'");
                        await db.cmd.ExecuteNonQueryAsync();

                        //B) update cost:= total / QTY  and update cost for ware
                        //_______________________________________________

                        //qty from wares =0
                        if (qty_ware_additems == 0)
                        {
                            //update cost direct from price purchase 
                            db.cmd.CommandText = ("update wares set cost =" + Convert.ToDecimal((dgv.Rows[i].Cells["tot_after_dis"].Value)) / Convert.ToDecimal((dgv.Rows[i].Cells["qty"].Value)) + " where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'");
                            await db.cmd.ExecuteNonQueryAsync();

                        }
                        //qty from wares != 0
                        else if (qty_ware_additems != 0)
                        {
                            totalqty = Convert.ToDecimal(db.GetData("select sum(qty * f_unite) from purchase_dt where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'").Rows[0][0].ToString());
                            if (totalqty == 0) totalqty = 1;
                            totalcoststring = (Convert.ToString(db.GetData("select sum(tot_after_dis) from purchase_dt where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'").Rows[0][0]));
                            if (totalcoststring == "") totalcoststring = (Convert.ToString(dgv.Rows[i].Cells["tot_after_dis"].Value));
                            //MessageBox.Show(totalcoststring);
                            totalcost = Convert.ToDecimal(totalcoststring);
                            db.cmd.CommandText = ("update wares set cost =" + (totalcost / totalqty) + " where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'");
                            await db.cmd.ExecuteNonQueryAsync();

                        }
                        //c)insert exp_date cost:-
                        //_______________________
                        if (dgv.Rows[i].Cells["exp"].Value.ToString() == "True")
                        {
                            db.cmd.CommandText = ("insert into exp_date (code_items,name_items,exp_date,qty,cost,id_ware,code,code_book) values('" + dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "','" + Convert.ToDateTime(dgv.Rows[i].Cells["exp_date"].Value).ToString("MM-dd-yyyy") + "','" + (Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value)) * (Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value)) + "','" + dgv.Rows[i].Cells["tot_after_dis"].Value + "','" + dgv.Rows[i].Cells["id_ware"].Value + "','" + txt_serial_string.Text + "','" + txt_code_book.Text + "')");
                            await db.cmd.ExecuteNonQueryAsync();
                        }

                    }
                    //\\end cost................


                    if (remaind_loop == count_last || remaind_loop==0)
                    {
                        decimal tot_bef = 0;
                        decimal discount = 0;
                        decimal tot_after_dis = 0;
                        decimal taxes_value = 0;
                        decimal incloud_taxes = 0;
                        for (int ii = 0; ii < dgv4.Rows.Count; ii++)
                        {
                            //========to get calc

                            dgv4.Rows[ii].Cells["tot_bef_de"].Value = ((Convert.ToDecimal(dgv4.Rows[ii].Cells["qty_de"].Value)) * (Convert.ToDecimal(dgv4.Rows[ii].Cells["f_unite_de"].Value)) * Convert.ToDecimal(dgv4.Rows[ii].Cells["item_price_de"].Value));
                            dgv4.Rows[ii].Cells["discount_de"].Value = Convert.ToDecimal(dgv4.Rows[ii].Cells["discount_de"].Value);
                            //calc tot=(qty*price)*(1-discount)
                            dgv4.Rows[ii].Cells["tot_after_dis_de"].Value = (Convert.ToDecimal(dgv4.Rows[ii].Cells["tot_bef_de"].Value)) - ((Convert.ToDecimal(dgv4.Rows[ii].Cells["discount_de"].Value)));
                            dgv4.Rows[ii].Cells["incloud_taxes_de"].Value = (Convert.ToDecimal(dgv4.Rows[ii].Cells["tot_after_dis_de"].Value) * (1 + Convert.ToDecimal(dgv4.Rows[ii].Cells["taxes_de"].Value)));
                            dgv4.Rows[ii].Cells["taxes_value_de"].Value = (Convert.ToDecimal(dgv4.Rows[ii].Cells["tot_after_dis_de"].Value) * (Convert.ToDecimal(dgv4.Rows[ii].Cells["taxes_de"].Value)));

                            tot_bef += Convert.ToDecimal(dgv4.Rows[ii].Cells["tot_bef_de"].Value);
                            discount += Convert.ToDecimal(dgv4.Rows[ii].Cells["discount_de"].Value);
                            tot_after_dis += Convert.ToDecimal(dgv4.Rows[ii].Cells["tot_after_dis_de"].Value);
                            incloud_taxes += Convert.ToDecimal(dgv4.Rows[ii].Cells["incloud_taxes_de"].Value);
                            taxes_value += Convert.ToDecimal(dgv4.Rows[ii].Cells["taxes_value_de"].Value);
                            //========
                        }
                        db.cmd.CommandText = ("insert into purchase_hd(purchase_hd_id              ,            code_book         ,name_book                          ,   vcs_code                                                ,      vcs_name                                                                                  ,           date_P                                                                                   ,         term           ,         tot_befor                                    ,           discount               ,               tot_after_dis                 ,           taxes                        ,incloud_taxes                                     ,    id_ware                                                   ,code_entry                     ,book_name_entry                     ,code_book_entry                     ,note_txt                        ,           user_name        ,  user_code                   ,lock)values('"
                                                       + txt_serial_string.Text + "', '" + txt_code_book.Text + "' ,'" + comb_code_name.Text + "'      ,'" + dgv4.Rows[0].Cells["vcs_code"].Value.ToString() + "',(select vcs_name from vcs where vcs_code='" + dgv4.Rows[0].Cells["vcs_code"].Value.ToString() + "'),'" + Convert.ToDateTime(dgv4.Rows[0].Cells["date_p"].Value).ToString("MM-dd-yyyy") + "'             ,'" + combo_type.Text + "',    '" + Math.Round(tot_bef, 2) + "'                  ,'" + Math.Round(discount, 2) + "' ,      '" + Math.Round(tot_after_dis, 2) + "' ,    '" + Math.Round(taxes_value, 2) + "','" + Math.Round(incloud_taxes, 2) + "'           ,'" + dgv4.Rows[0].Cells["id_ware_de"].Value.ToString() + "'   ,'" + 0 + "'                   ,'" + txt_name_book_type.Text + "','" + txt_code_entry_type.Text + "','" + "import purchase by Excel" + "','" + "lbl_user_name.Text" + "','" + "lbl_user_code.Text" + "','0')");
                        await db.cmd.ExecuteNonQueryAsync();

                        select_type_entry(dgv4.Rows[0].Cells["id_ware_de"].Value.ToString(), dgv4.Rows[0].Cells["vcs_code"].Value.ToString(), tot_bef + "", tot_after_dis + "", discount + "", incloud_taxes + "", taxes_value + "");
                        //entry_hd and dt
                        db.cmd.CommandText = ("insert into entry_hd ([code_entry],code_book) values ('" + txt_entry_string.Text + "','" + txt_code_entry_type.Text + "')");
                        await db.cmd.ExecuteNonQueryAsync();

                        for (int z = 0; z < dgv_term.Rows.Count; z++)
                        {
                            db.cmd.CommandText = ("insert into entry(  [code_entry]                           ,    acc_num                                                   ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                                          ,   type_acc                                                            , sort                                                       ,             depit                                                             ,                credit                                                   ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext )values('" +
                                                      txt_entry_string.Text + "'            ,'" + dgv_term.Rows[z].Cells[1].Value.ToString() + "'     ,'" + dgv_term.Rows[z].Cells[2].Value.ToString() + "'               ,  '" + dgv_term.Rows[z].Cells["rootlevel_"].Value.ToString() + "'    ,  '" + dgv_term.Rows[z].Cells["rootlevel_name_"].Value.ToString() + "', '" + dgv_term.Rows[z].Cells["type_acc_"].Value.ToString() + "'       ,  '" + dgv_term.Rows[z].Cells["sort_"].Value.ToString() + "'  ,  '" + Convert.ToDecimal(dgv_term.Rows[z].Cells[3].Value.ToString()) + "'      ,'" + Convert.ToDecimal(dgv_term.Rows[z].Cells[4].Value.ToString()) + "' ,'" + txt_name_book_type.Text + "','" + txt_code_entry_type.Text + "'    ,'" + Convert.ToDateTime(dgv4.Rows[0].Cells["date_p"].Value).ToString("MM-dd-yyyy") + "','" + txt_serial_string.Text + "','" + txt_code_book.Text + "','" + comb_code_name.Text + "','" + "insert purchase by Excel" + "')");
                            await db.cmd.ExecuteNonQueryAsync();

                        }

                    }
                }
                

                
                //..............................................................................(4)......................................................................
                else if (x != 1 + n)
                {

                    //x_old for loop
                    decimal tot_bef = 0;
                    decimal discount = 0;
                    decimal tot_after_dis = 0;
                    decimal taxes_value = 0;
                    decimal incloud_taxes = 0;
                    for (int ii = 0; ii < dgv4.Rows.Count; ii++)
                    {
                        //========to get calc

                        dgv4.Rows[ii].Cells["tot_bef_de"].Value = ((Convert.ToDecimal(dgv4.Rows[ii].Cells["qty_de"].Value)) * (Convert.ToDecimal(dgv4.Rows[ii].Cells["f_unite_de"].Value)) * Convert.ToDecimal(dgv4.Rows[ii].Cells["item_price_de"].Value));
                        dgv4.Rows[ii].Cells["discount_de"].Value = Convert.ToDecimal(dgv4.Rows[ii].Cells["discount_de"].Value);
                        //calc tot=(qty*price)*(1-discount)
                        dgv4.Rows[ii].Cells["tot_after_dis_de"].Value = (Convert.ToDecimal(dgv4.Rows[ii].Cells["tot_bef_de"].Value)) - ((Convert.ToDecimal(dgv4.Rows[ii].Cells["discount_de"].Value)));
                        dgv4.Rows[ii].Cells["incloud_taxes_de"].Value = (Convert.ToDecimal(dgv4.Rows[ii].Cells["tot_after_dis_de"].Value) * (1 + Convert.ToDecimal(dgv4.Rows[ii].Cells["taxes_de"].Value)));
                        dgv4.Rows[ii].Cells["taxes_value_de"].Value = (Convert.ToDecimal(dgv4.Rows[ii].Cells["tot_after_dis_de"].Value) * (Convert.ToDecimal(dgv4.Rows[ii].Cells["taxes_de"].Value)));


                        tot_bef += Convert.ToDecimal(dgv4.Rows[ii].Cells["tot_bef_de"].Value);
                        discount += Convert.ToDecimal(dgv4.Rows[ii].Cells["discount_de"].Value);
                        tot_after_dis += Convert.ToDecimal(dgv4.Rows[ii].Cells["tot_after_dis_de"].Value);
                        incloud_taxes += Convert.ToDecimal(dgv4.Rows[ii].Cells["incloud_taxes_de"].Value);
                        taxes_value += Convert.ToDecimal(dgv4.Rows[ii].Cells["taxes_value_de"].Value);
                        //========
                    }
                    //insert hd:-
                    db.cmd.CommandText = ("insert into purchase_hd(purchase_hd_id              ,            code_book         ,name_book                          ,   vcs_code                                                ,      vcs_name                                                                                  ,           date_P                                                                                   ,         term           ,         tot_befor                                    ,           discount               ,               tot_after_dis                 ,           taxes                        ,incloud_taxes                                     ,    id_ware                                                   ,code_entry                     ,book_name_entry                     ,code_book_entry                     ,note_txt                        ,           user_name        ,  user_code                   ,lock)values('"
                                                + txt_serial_string.Text + "', '" + txt_code_book.Text + "' ,'" + comb_code_name.Text + "'      ,'" + dgv4.Rows[0].Cells["vcs_code"].Value.ToString() + "',(select vcs_name from vcs where vcs_code='" + dgv4.Rows[0].Cells["vcs_code"].Value.ToString() + "'),'" + Convert.ToDateTime(dgv4.Rows[0].Cells["date_p"].Value).ToString("MM-dd-yyyy") + "'             ,'" + combo_type.Text + "',    '" + Math.Round(tot_bef, 2) + "'                  ,'" + Math.Round(discount, 2) + "' ,      '" + Math.Round(tot_after_dis, 2) + "' ,    '" + Math.Round(taxes_value, 2) + "','" + Math.Round(incloud_taxes, 2) + "'           ,'" + dgv4.Rows[0].Cells["id_ware_de"].Value.ToString() + "'   ,'" + 0 + "'                   ,'" + txt_name_book_type.Text + "','" + txt_code_entry_type.Text + "','" + "import purchase by Excel" + "','" + "lbl_user_name.Text" + "','" + "lbl_user_code.Text" + "','0')");
                    await db.cmd.ExecuteNonQueryAsync();

                    //entry_hd and dt
                    select_type_entry(dgv4.Rows[0].Cells["id_ware_de"].Value.ToString(), dgv4.Rows[0].Cells["vcs_code"].Value.ToString(), tot_bef + "", tot_after_dis + "", discount + "", incloud_taxes + "", taxes_value + "");
                    db.cmd.CommandText = ("insert into entry_hd ([code_entry],code_book) values ('" + txt_entry_string.Text + "','" + txt_code_entry_type.Text + "')");
                    await db.cmd.ExecuteNonQueryAsync();

                    for (int z = 0; z < dgv_term.Rows.Count; z++)
                    {
                        db.cmd.CommandText = ("insert into entry(  [code_entry]                           ,    acc_num                                                   ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                                          ,   type_acc                                                            , sort                                                       ,             depit                                                             ,                credit                                                   ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext )values('" +
                                                  txt_entry_string.Text + "'            ,'" + dgv_term.Rows[z].Cells[1].Value.ToString() + "'     ,'" + dgv_term.Rows[z].Cells[2].Value.ToString() + "'               ,  '" + dgv_term.Rows[z].Cells["rootlevel_"].Value.ToString() + "'    ,  '" + dgv_term.Rows[z].Cells["rootlevel_name_"].Value.ToString() + "', '" + dgv_term.Rows[z].Cells["type_acc_"].Value.ToString() + "'       ,  '" + dgv_term.Rows[z].Cells["sort_"].Value.ToString() + "'  ,  '" + Convert.ToDecimal(dgv_term.Rows[z].Cells[3].Value.ToString()) + "'      ,'" + Convert.ToDecimal(dgv_term.Rows[z].Cells[4].Value.ToString()) + "' ,'" + txt_name_book_type.Text + "','" + txt_code_entry_type.Text + "'    ,'" + Convert.ToDateTime(dgv4.Rows[0].Cells["date_p"].Value).ToString("MM-dd-yyyy") + "','" + txt_serial_string.Text + "','" + txt_code_book.Text + "','" + comb_code_name.Text + "','" + "insert purchase by Excel" + "')");
                        await db.cmd.ExecuteNonQueryAsync();

                    }
                    count_1 = 0;
                    n += 1;
                    //clearbook
                    //txt_serial_string.Text = "";
                    generat_get_book();
                    generat_entry_book();
                    dgv4.Rows.Clear();
                    dgv_term.Rows.Clear();
                    tot_bef = 0;
                    discount = 0;
                    tot_after_dis = 0;
                    incloud_taxes = 0;
                    taxes_value = 0;
                    //insert purchas_dt
                    db.cmd.CommandText = ("insert into purchase_dt(purchase_hd_id ,         code_book ,                       name_book         ,                       code_items              ,                        name_items             ,                                         qty             ,                                      item_price                  ,                                         tot_bef             ,                                         discount             ,                                         tot_after_dis             ,                                        taxes              ,                                        incloud_taxes                 ,                                          taxes_value             ,                                                         id_ware                   ,                 f_unite              ,                                                    name_unite                                                                                              ,                                      [exp]                                    ,            exp_date          ,[type]) values('" +
                                        txt_serial_string.Text + "','" + txt_code_book.Text + "', '" + comb_code_name.Text + "','" + dgv.Rows[i].Cells["code_items"].Value + "','" + dgv_valid.Rows[i].Cells["name_items_c"].Value + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["item_price"].Value) + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_bef"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["discount"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["taxes"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["incloud_taxes"].Value) + "',(select taxes from items where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'),'" + (dgv.Rows[i].Cells["id_ware"].Value) + "','" + (dgv.Rows[i].Cells["f_unite"].Value) + "',(select name_unite from unite where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and unite='" + (dgv.Rows[i].Cells["f_unite"].Value) + "')   ,                   '" + Convert.ToBoolean((dgv.Rows[i].Cells["exp"].Value)) + "',            Null              ,'" + (dgv.Rows[i].Cells["type"].Value) + "')");
                    await db.cmd.ExecuteNonQueryAsync();


                    dgv4.Rows.Add(x, dgv.Rows[i].Cells["code_items"].Value.ToString(), dgv.Rows[i].Cells["name_items"].Value.ToString(), dgv.Rows[i].Cells["name_unite"].Value.ToString(), dgv.Rows[i].Cells["f_unite"].Value.ToString(), dgv.Rows[i].Cells["exp"].Value.ToString(), dgv.Rows[i].Cells["type"].Value.ToString(), (dgv.Rows[i].Cells["exp_date"].Value).ToString(), (dgv.Rows[i].Cells["qty"].Value).ToString(), (dgv.Rows[i].Cells["item_price"].Value).ToString(), (dgv.Rows[i].Cells["tot_bef"].Value).ToString(), (dgv.Rows[i].Cells["discount"].Value).ToString(), (dgv.Rows[i].Cells["tot_after_dis"].Value).ToString(), (dgv.Rows[i].Cells["taxes"].Value).ToString(), (dgv.Rows[i].Cells["incloud_taxes"].Value).ToString(), (dgv.Rows[i].Cells["taxes_value"].Value).ToString(), (dgv.Rows[i].Cells["id_ware"].Value).ToString(), dgv.Rows[i].Cells["vcs_code"].Value.ToString(), dgv.Rows[i].Cells["vcs_name"].Value.ToString(), dgv.Rows[i].Cells["date_p"].Value.ToString());

                    //\\cost....................
                    //A)update ware qty:-
                    //________________________
                    if (dgv.Rows[i].Cells["type"].Value.ToString() == "1")
                    {
                        //update wares
                        qty_ware_additems = Convert.ToDecimal(db.GetData("select isnull((sum(qty)),0) from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'").Rows[0][0].ToString());
                        db.cmd.CommandText = ("update wares set qty =(" + Convert.ToDecimal(qty_ware_additems) + " + " + (Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value)) * (Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value)) + ") where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'");
                        await db.cmd.ExecuteNonQueryAsync();

                        //B) update cost:= total / QTY  and update cost for ware
                        //_______________________________________________

                        //qty from wares =0
                        if (qty_ware_additems == 0)
                        {
                            //update cost direct from price purchase 
                            db.cmd.CommandText = ("update wares set cost =" + Convert.ToDecimal((dgv.Rows[i].Cells["tot_after_dis"].Value)) / Convert.ToDecimal((dgv.Rows[i].Cells["qty"].Value)) + " where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'");
                            await db.cmd.ExecuteNonQueryAsync();

                        }
                        //qty from wares != 0
                        else if (qty_ware_additems != 0)
                        {
                            totalqty = Convert.ToDecimal(db.GetData("select sum(qty * f_unite) from purchase_dt where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'").Rows[0][0].ToString());
                            if (totalqty == 0) totalqty = 1;
                            totalcoststring = (Convert.ToString(db.GetData("select sum(tot_after_dis) from purchase_dt where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'").Rows[0][0]));
                            if (totalcoststring == "") totalcoststring = (Convert.ToString(dgv.Rows[i].Cells["tot_after_dis"].Value));
                            //MessageBox.Show(totalcoststring);
                            totalcost = Convert.ToDecimal(totalcoststring);
                            db.cmd.CommandText = ("update wares set cost =" + (totalcost / totalqty) + " where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'");
                            await db.cmd.ExecuteNonQueryAsync();

                        }
                        //c)insert exp_date cost:-
                        //_______________________
                        if (dgv.Rows[i].Cells["exp"].Value.ToString() == "True")
                        {
                            db.cmd.CommandText = ("insert into exp_date (code_items,name_items,exp_date,qty,cost,id_ware,code,code_book) values('" + dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "','" + Convert.ToDateTime(dgv.Rows[i].Cells["exp_date"].Value).ToString("MM-dd-yyyy") + "','" + (Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value)) * (Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value)) + "','" + dgv.Rows[i].Cells["tot_after_dis"].Value + "','" + dgv.Rows[i].Cells["id_ware"].Value + "','" + txt_serial_string.Text + "','" + txt_code_book.Text + "')");
                            await db.cmd.ExecuteNonQueryAsync();

                        }
                    }
                    //\\end cost................

                }

                backgroundWorker1.ReportProgress(i);
            }
            progressBar1.Visible = false;
            XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "saving ", "save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            load_barButtonItem2.Enabled = true;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Maximum = prog;
            progressBar1.Value = e.ProgressPercentage;
        }
        private void entry_barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("select code_entry,acc_num,acc_name,depit,credit,attachnamebook,attachtext from entry where attachtext='insert purchase by Excel'", dt);
            dgv_entry.DataSource = dt;
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("عايز تعمل جديد!!؟؟؟؟ ", "رسال جديد مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                frm_excel_purchase frm = new frm_excel_purchase();
                this.Close();
                frm.Show();
            }
        }
        private void comb_code_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_code_book.Text = db.GetData("select code_book from book where name_book='" + comb_code_name.Text + "'").Rows[0][0].ToString();
            cls_book.selectbook("purchase_hd", "سند فاتوره مشتريات", txt_code_book.Text, txt_serial, "purchase_hd_id");
            txt_serial_string.Text = txt_code_book.Text + txt_serial.Text;
        }

       



    }
}