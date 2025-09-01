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
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Drawing.Printing;
using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;
using f1.Classes;
using f1.Properties;
using System.Text.RegularExpressions;

namespace f1.sales
{
    public partial class frm_rsale : DevExpress.XtraEditors.XtraForm
    {
        public frm_rsale()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(v.ico);

        }

        private void frm_rsale_Load(object sender, EventArgs e)
        {
            this.chk_search_lang.Checked = Settings.Default.chk_search_lang;
            this.chk_bal_ware.Checked = Settings.Default.chk_bal_ware;
            all_comb.load_wares(this.combo_wars);
            this.combo_vcs.Text = (string)null;
            this.combo_vsc_codetree.Text = null;
            //this.dt_piker.MinDate = new DateTime(v.current_yaer, 1, 1);
            //this.dt_piker.MaxDate = new DateTime(v.current_yaer, 12, 31);
            cls_book.loadbook(this.comb_code_name, "سند مردودات مبيعات");
            cls_book.load_from_term(this.combo_type, "سند مردودات مبيعات");
            //this.dt_piker.Text = DateTime.Now.ToString(v.current_yaer +"/MM/dd");
            //this.dt_due_date.Text = DateTime.Now.ToString(v.current_yaer +"/MM/dd");


            this.dt_piker.Text = DateTime.Now.ToString("yyyy/MM/dd");
            this.dt_due_date.Text = DateTime.Now.ToString("yyyy/MM/dd");
            this.dt_f.Text = DateTime.Now.ToString("yyyy/MM/dd");
            this.dt_due_date.Text = DateTime.Now.ToString("yyyy/MM/dd");



            this.combo_type.Text = "";
            this.dgv_term.Rows.Clear();
            this.lbl_tot_befor.Text = "0";
            this.lbl_discount.Text = "0";
            this.lbl_tot_after_dis.Text = "0";
            this.lbl_incloud_taxes.Text = "0";
            this.lbl_serial_P.Text = "0";
            this.progressBar1.Visible = false;
            this.combo_exp.Visible = false;
            this.btn_add_exp.Visible = false;
            this.lbl_exp.Visible = false;
            this.dt_exp.Visible = false;
            this.lbl_knowexp.Visible = false;
            this.btn_del_exp.Visible = false;
            this.dgv_readonly();
            all_comb.load_curracne(this.combo_currance);
            this.lbl_user_code.Text = v.usercode;
            this.lbl_user_name.Text = v.username;
            this.load_permission();
            if (!v.expiry)
            {
                this.dgv.Columns["exp_date"].Visible = false;
                this.btn_add_exp.Visible = false;
                this.lbl_exp.Visible = false;
                this.dt_exp.Visible = false;
                this.labelControl12.Visible = false;
                this.combo_expcost.Visible = false;
                this.btn_cost_exp.Visible = false;
            }
            if (!v.represinttive)
            {
                this.lbl_represintativ.Visible = false;
                this.combo_rebprsentativ.Visible = false;
            }
            if (!v.barcode)
            {
                this.lbl_barcode.Visible = false;
                this.txt_barcode.Visible = false;
            }
            if (!v.currance)
            {
                this.lbl_currance.Visible = false;
                this.btn_currance.Visible = false;
                this.combo_currance.Visible = false;
                this.txt_f_currance.Visible = false;
            }
            if (!v.taxes)
            {
                this.dgv.Columns["taxes_value"].Visible = false;
                this.dgv.Columns["incloud_taxes"].Visible = false;
                this.dgv.Columns["taxes"].Visible = false;
                this.lbl_incloud_taxes.Visible = false;
                this.lbl_taxes_values.Visible = false;
                this.labelControl16.Visible = false;
                this.labelControl19.Visible = false;
            }
            this.printer_direct_barButtonItem11.Enabled = false;
            this.printer_previeew_barButtonItem10.Enabled = false;
            this.btn_barcode.Enabled = false;
        }
        //==============================================fanction
        int prog = 0;
        bool edit = false;
        string numBook_entry = "";
        string numBook_rsale = "";
        string error = "";
        private int num = 0;
        private int num_entry = 0;
        //private void select_type_entry()
        //{
        //    dgv_term.Rows.Clear();
        //    int num1 = Convert.ToInt32(db.GetData("select count(term_id) from term where term_id='" + combo_type.Text + "' and cat_book='سند مردودات مبيعات'").Rows[0][0].ToString());
        //    code_entry = db.GetData("select code_entry from term where term_id='" + combo_type.Text + "' and cat_book='سند مردودات مبيعات'").Rows[0][0].ToString();
        //    db.GetData("select bookname_entry from term where term_id='" + combo_type.Text + "' and cat_book='سند مردودات مبيعات'").Rows[0][0].ToString();
        //    int num2 = 0;
        //    while (num2 < num1)
        //    {
        //        int index = num2++;
        //        string str1 = db.GetData("select term_id from term where term_id='" + combo_type.Text + "'").Rows[index][0].ToString();
        //        string str2 = db.GetData("select rootid from term where term_id='" + combo_type.Text + "'").Rows[index][0].ToString();
        //        string str3 = db.GetData("select rootname from term where term_id='" + combo_type.Text + "'").Rows[index][0].ToString();
        //        string str4 = db.GetData("select depit from term where term_id='" + combo_type.Text + "'").Rows[index][0].ToString();
        //        string str5 = db.GetData("select credit from term where term_id='" + combo_type.Text + "'").Rows[index][0].ToString();
        //        string costcenter_id = db.GetData("select costcenter_id from term where term_id='" + combo_type.Text + "'").Rows[index][0] + "";

        //        if (str3.Length > 52)
        //        {
        //            str2 = db.GetData(str2 + combo_wars.Text).Rows[0][0].ToString();
        //            str3 = db.GetData(str3 + combo_wars.Text).Rows[0][0].ToString();
        //            rootlevel = db.GetData("select rootlevel from tree where rootid='" + str2 + "'").Rows[0][0].ToString();
        //            rootlevel_name = "0";
        //            type_acc = db.GetData("select sort from tree where rootid='" + str2 + "'").Rows[0][0].ToString();
        //            sort = "1";
        //        }
        //        else if (str3.Length > 39)
        //        {
        //            if (combo_vsc_codetree.Text == "")
        //            {
        //                int num3 = (int)MessageBox.Show("اختار مورد او عميل");
        //                break;
        //            }
        //            else
        //            {
        //                str2 = db.GetData(str2 + "'" + combo_vsc_codetree.Text + "'").Rows[0][0].ToString();
        //                str3 = db.GetData(str3 + "'" + combo_vsc_codetree.Text + "'").Rows[0][0].ToString();
        //                rootlevel = db.GetData("select rootlevel from vcs where vcs_code='" + combo_vsc_codetree.Text + "'").Rows[0][0].ToString();
        //                rootlevel_name = db.GetData("select rootlevel_name from vcs where vcs_code='" + combo_vsc_codetree.Text + "'").Rows[0][0].ToString();
        //                type_acc = db.GetData("select sort from vcs where vcs_code='" + combo_vsc_codetree.Text + "'").Rows[0][0].ToString();
        //                sort = "2";
        //            }
        //        }
        //        else
        //        {
        //            rootlevel = db.GetData("select rootlevel from tree where rootid='" + str2 + "'").Rows[0][0].ToString();
        //            rootlevel_name = "0";
        //            type_acc = db.GetData("select sort from tree where rootid='" + str2 + "'").Rows[0][0].ToString();
        //            sort = "1";
        //        }
        //        string str6 = !(str4 == "tot_befor") ? (!(str4 == "tot_after_dis") ? (!(str4 == "discount") ? (!(str4 == "incloud_taxes") ? (!(str4 == "taxtes") ? (!(str4 == "vat_add") ? (!(str4 == "cost") ? "0" : lbl_tot_cost.Text) : lbl_vat_Add.Text) : lbl_taxes_values.Text) : lbl_incloud_taxes.Text) : lbl_discount.Text) : lbl_tot_after_dis.Text) : lbl_tot_befor.Text;
        //        string str7 = !(str5 == "tot_befor") ? (!(str5 == "tot_after_dis") ? (!(str5 == "discount") ? (!(str5 == "incloud_taxes") ? (!(str5 == "taxtes") ? (!(str5 == "vat_add") ? (!(str5 == "cost") ? "0" : lbl_tot_cost.Text) : lbl_vat_Add.Text) : lbl_taxes_values.Text) : lbl_incloud_taxes.Text) : lbl_discount.Text) : lbl_tot_after_dis.Text) : lbl_tot_befor.Text;
        //        dgv_term.Rows.Add(str1, str2, str3, str6, str7, rootlevel, rootlevel_name, sort, type_acc, costcenter_id);
        //    }
        //}
       
        
        private void save()
        {
            calc_all();
            for (int i = 0; i < dgv.Rows.Count; ++i)
            {
                decimal balance_in_our_inv = Convert.ToDecimal(db.GetData("select isnull(sum(qty),0) from purchase_dt where purchase_hd_id='" + lbl_combo_attach.Text + "' and code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'").Rows[0][0].ToString());
                if (Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) <= balance_in_our_inv)
                {
                    MessageBox.Show("يجب ات تكون الكمية مساوية اة او اقل من سند فاتورة المبيعات : " + dgv.Rows[i].Cells["code_items"].Value);
                    return;
                }
               // string str1 = db.GetData("select isnull((sum(qty)),0) from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'").Rows[0][0].ToString();
                Decimal num1 = Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) * Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value);
                // string str2 = num1.ToString();
                //  num1 = Convert.ToDecimal(str1) - Convert.ToDecimal(str2);
                //if (Convert.ToDecimal(num1.ToString()) < 0 && dgv.Rows[i].Cells["type"].Value.ToString() != "2")
                if (num1 < 0 && dgv.Rows[i].Cells["type"].Value.ToString() != "2")
                {
                    MessageBox.Show("مينفعش الرصيد يكون بالسالب   كود الصنف : " + dgv.Rows[i].Cells["code_items"].Value);
                    return;

                }
                else
                {
                    //if (dgv.Rows[i].Cells["exp"].Value.ToString() == "True")
                    //{
                    //    string str3 = db.GetData("select isnull((sum(qty)),0) from exp_date where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "' and exp_date='" + Convert.ToDateTime(dgv.Rows[i].Cells["exp_date"].Value).ToString("MM-dd-yyyy") + "'").Rows[0][0].ToString();
                    //    if (str3 == "")
                    //        str3 = "0";
                    //    if (Convert.ToDecimal(str3) < Convert.ToDecimal(str2))
                    //    {
                    //        MessageBox.Show("مفيش رصيد من تاريخ الصالحيه ...شوف تاريخ صلاحيه تاني ");
                    //        return;
                    //    }
                    //}
                    if (!Convert.ToBoolean(db.GetData("select blow_cost_discount from permission_price_discount where user_code='" + v.usercode + "' ").Rows[0][0].ToString()) || !Convert.ToBoolean(db.GetData("select blow_cost_price from permission_price_discount where user_code='" + v.usercode + "' ").Rows[0][0].ToString()))
                    {
                        double num2 = Convert.ToDouble(db.GetData("select isnull(sum(cost),0) from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value.ToString() + "' and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value.ToString() + "'").Rows[0][0].ToString());
                        if (Convert.ToDouble(dgv.Rows[i].Cells["tot_after_dis"].Value.ToString()) / Convert.ToDouble(dgv.Rows[i].Cells["qty"].Value.ToString()) <= num2)
                        {
                            XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "لايمكن البيع تحت سعر التكلفه \n كود الصنف" + dgv.Rows[i].Cells["code_items"].Value.ToString() + "  " + dgv.Rows[i].Cells["name_items"].Value.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                }
            }
            cogs();
         //   select_type_entry();

            string error = "";
            DataTable dt_term = new DataTable();
            cls_book.Make_entry_type_purchase(ref dt_term, ref error, "سند مردودات مبيعات", combo_type.Text, combo_wars.Text, combo_vsc_codetree.Text, lbl_tot_befor.Text, lbl_tot_after_dis.Text, lbl_discount.Text, lbl_discount.Text, lbl_incloud_taxes.Text, lbl_vat_Add.Text);

            //txt_entry_string.Text = txt_code_entry_type.Text + txt_code_entry.Text;
            //cls_book.selectbook("entry_hd", "سند قيد", txt_code_entry_type.Text, txt_code_entry, "code_entry");
            //txt_entry_string.Text = txt_code_entry_type.Text + txt_code_entry.Text;
            string code_entry_term = (db.GetData("select code_entry from term where term_id='" + combo_type.Text + "' ").Rows[0][0].ToString());
            cls_book.Generat_numBooknum("entry", code_entry_term, ref numBook_entry, ref error, ref num_entry);
            txt_entry_string.Text = numBook_entry;


            txt_code_book.Text = db.GetData("select code_book from book where name_book='" + comb_code_name.Text + "'").Rows[0][0].ToString();
           // cls_book.selectbook("rsale_hd", "سند مردودات مبيعات", txt_code_book.Text, txt_serial, "rsale_hd_id");
            txt_serial_string.Text = txt_code_book.Text + txt_serial.Text;
            cls_book.Generat_numBooknum("rsale_hd", txt_code_book.Text, ref numBook_rsale, ref error, ref num);
            txt_serial_string.Text = numBook_rsale;

            db.Run("insert into entry_hd ([code_entry],code_book) values ('" + txt_entry_string.Text + "','" + txt_code_entry_type.Text + "')");

            //  for (int i = 0; i < dgv_term.Rows.Count; ++i)
            //    db.Run("insert into entry(  [code_entry]                           ,    acc_num                                                   ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                                          ,   type_acc                                                            , sort                                                       ,             depit                                                             ,                credit                                                   ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext,costcenter_code,num_book )values('" + txt_entry_string.Text + "'            ,'" + dgv_term.Rows[i].Cells[1].Value.ToString() + "'     ,'" + dgv_term.Rows[i].Cells[2].Value.ToString() + "'               ,  '" + dgv_term.Rows[i].Cells["rootlevel_"].Value.ToString() + "'    ,  '" + dgv_term.Rows[i].Cells["rootlevel_name_"].Value.ToString() + "', '" + dgv_term.Rows[i].Cells["type_acc_"].Value.ToString() + "'       ,  '" + dgv_term.Rows[i].Cells["sort_"].Value.ToString() + "'  ,  '" + (Convert.ToDecimal(dgv_term.Rows[i].Cells[3].Value.ToString()) * Convert.ToDecimal(txt_f_currance.Text)) + "'      ,'" + (Convert.ToDecimal(dgv_term.Rows[i].Cells[4].Value.ToString()) * Convert.ToDecimal(txt_f_currance.Text)) + "' ,'" + txt_name_book_type.Text + "','" + txt_code_entry_type.Text + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + txt_serial_string.Text + "','" + txt_code_book.Text + "','" + comb_code_name.Text + "','" + txt_note.Text + "','" + dgv_term.Rows[i].Cells["costcenter_term"].Value.ToString() + "','"+num_entry+"')");
            for (int z = 0; z < dt_term.Rows.Count; z++)

            {
                db.Run("insert into entry(  [code_entry]                           ,    acc_num                                                   ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                                          ,   type_acc                                                            , sort                                                       ,             depit                                                             ,                credit                                                                          ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext ,num_book)values('" +
                                    txt_entry_string.Text + "'            ,'" + dt_term.Rows[z][1] + "'     ,'" + dt_term.Rows[z][2] + "'               ,  '" + dt_term.Rows[z][5] + "'    ,                               '" + dt_term.Rows[z][6] + "',                                                         '" + dt_term.Rows[z][8] + "'       ,                        '" + dt_term.Rows[z][7] + "'  ,                               '" + Convert.ToDecimal(dt_term.Rows[z][3]) * Convert.ToDecimal(txt_f_currance.Text) + "'      ,'" + Convert.ToDecimal(dt_term.Rows[z][4]) * Convert.ToDecimal(txt_f_currance.Text) + "' ,'" + txt_name_book_type.Text + "','" + txt_code_entry_type.Text + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + txt_serial_string.Text + "','" + txt_code_book.Text + "','" + comb_code_name.Text + "','" + txt_note.Text + "','" + num_entry + "')");
            }

            // 2) save header:-
            //________________________

            db.Run("insert into rsale_hd(rsale_hd_id ,            code_book               ,name_book                       ,   vcs_code,                       vcs_name           ,           date_P                               ,         term           ,         tot_befor                    ,    discount              , tot_after_dis                          ,           taxes            ,incloud_taxes               ,    id_ware                    ,code_entry              ,book_name_entry                  ,code_book_entry                       ,note_txt                ,user_name               ,user_code,lock,currance,f_currance,due_date,vcs_value,attach_no,num_book)values('"
                                           + txt_serial_string.Text + "', '" + txt_code_book.Text + "' ,'" + comb_code_name.Text + "','" + combo_vsc_codetree.Text + "','" + combo_vcs.Text + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + combo_type.Text + "',    '" + lbl_tot_befor.Text + "'    ,'" + lbl_discount.Text + "' ,      '" + lbl_tot_after_dis.Text + "' ,  '" + lbl_taxes_values.Text + "' ,'" + lbl_incloud_taxes.Text + "','" + combo_wars.Text + "','" + txt_code_entry.Text + "','" + txt_name_book_type.Text + "','" + txt_code_entry_type.Text + "','" + txt_note.Text + "','" + lbl_user_name.Text + "','" + lbl_user_code.Text + "','0','" + combo_currance.Text + "','" + txt_f_currance.Text + "','" + dt_due_date.Value.ToString("MM-dd-yyyy") + "','0','" + lbl_combo_attach.Text + "','"+num+"')");


            prog = dgv.Rows.Count;
            // for (int percentProgress = 0; percentProgress < dgv.Rows.Count; ++percentProgress)
            for (int i = 0; i < dgv.Rows.Count; i++)//loop NO.3
            {
                //3)save detals:=
                //___________________
                //A)items is not expiry
                if (dgv.Rows[i].Cells["exp"].Value.ToString() == "False")
                {
                    db.Run("insert into rsale_dt(rsale_hd_id ,         code_book ,                       name_book         ,                       code_items              ,                        name_items             ,                                         qty             ,                                      item_price                  ,                                         tot_bef             ,                                         discount             ,                                         tot_after_dis             ,                                        taxes              ,                                        incloud_taxes                 ,                                          taxes_value             ,      id_ware         ,                         f_unite,                                   name_unite                                           ,no,                                                           [exp]              ,            exp_date                        ,[type],serial_P,tot_after_dis_forex) values('" +
                                             txt_serial_string.Text + "','" + txt_code_book.Text + "', '" + comb_code_name.Text + "','" + dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["item_price"].Value) + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_bef"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["discount"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["taxes"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["incloud_taxes"].Value) + "','" + Convert.ToDecimal(dgv.Rows[i].Cells["taxes_value"].Value) + "','" + (dgv.Rows[i].Cells["id_ware"].Value) + "','" + (dgv.Rows[i].Cells["f_unite"].Value) + "','" + (dgv.Rows[i].Cells["name_unite"].Value) + "','" + (dgv.Rows[i].Cells["no"].Value) + "','" + Convert.ToBoolean((dgv.Rows[i].Cells["exp"].Value)) + "',            Null              ,'" + (dgv.Rows[i].Cells["type"].Value) + "','" + lbl_serial_P.Text + "','" + Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) * Convert.ToDecimal(txt_f_currance.Text) + "')");
                }
                else
                {
                    //B)items is expiry
                    db.Run("insert into rsale_dt(rsale_hd_id ,         code_book ,                       name_book         ,                       code_items              ,                        name_items             ,                                         qty             ,                                      item_price                  ,                                         tot_bef             ,                                         discount             ,                                         tot_after_dis             ,                                        taxes              ,                                        incloud_taxes                 ,                                          taxes_value             ,      id_ware         ,                         f_unite,                                   name_unite                                           ,no,                                                           [exp]              ,            exp_date                        ,[type],serial_P,tot_after_dis_forex) values('" +
                                             txt_serial_string.Text + "','" + txt_code_book.Text + "', '" + comb_code_name.Text + "','" + dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["item_price"].Value) + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_bef"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["discount"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["taxes"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["incloud_taxes"].Value) + "','" + Convert.ToDecimal(dgv.Rows[i].Cells["taxes_value"].Value) + "','" + (dgv.Rows[i].Cells["id_ware"].Value) + "','" + (dgv.Rows[i].Cells["f_unite"].Value) + "','" + (dgv.Rows[i].Cells["name_unite"].Value) + "','" + (dgv.Rows[i].Cells["no"].Value) + "','" + Convert.ToBoolean((dgv.Rows[i].Cells["exp"].Value)) + "','" + Convert.ToDateTime(dgv.Rows[i].Cells["exp_date"].Value).ToString("MM-dd-yyyy") + "','" + (dgv.Rows[i].Cells["type"].Value) + "','" + lbl_serial_P.Text + "','" + Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) * Convert.ToDecimal(txt_f_currance.Text) + "')");
                }

                //update ware 
                //A)update ware qty:-
                //________________________
                if (dgv.Rows[i].Cells["type"].Value.ToString() == "1")
                {
                    //decimal last_invoice_price = 0;
                    decimal qty_ware_additems = Convert.ToDecimal(db.GetData("select qty from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'").Rows[0][0].ToString());
                    decimal qty_bal = Convert.ToDecimal(qty_ware_additems) - (Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value)) * (Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value));
                    //if (combo_attach.Text == "")
                    //{
                    //    try
                    //    {
                    //        last_invoice_price = Convert.ToDecimal(db.GetData("select (item_price) from sale_dt where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "' order by item_price desc").Rows[0][0] + "");
                    //    }
                    //    catch (Exception)
                    //    {
                    //        last_invoice_price = 0;
                    //    }
                    //}
                    //else
                    //{
                    //    last_invoice_price = Convert.ToDecimal(db.GetData("select (item_price) from sale_dt where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "' and sale_hd_id='" + combo_attach.Text + "' order by item_price desc").Rows[0][0] + "");
                    //}
                   // decimal last_cost = Convert.ToDecimal(db.GetData("select isnull(SUM(cost),0) from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "' ").Rows[0][0].ToString());
                   // last_cost -= last_invoice_price; if (last_cost < 0) last_cost *= -1;
                    db.Run("update wares set qty =(" + Convert.ToDecimal(qty_ware_additems) + " + " + (Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value)) * (Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value)) + ")  where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'");
                    decimal demand_limit = Convert.ToDecimal(db.GetData("select isnull(max(demand_limit),0)  from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'").Rows[0][0].ToString());
                    decimal demand_maximum = Convert.ToDecimal(db.GetData("select isnull(max(demand_maximum),0) from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'").Rows[0][0].ToString());
                    Boolean limit = Convert.ToBoolean(db.GetData("select demand_limit_bit  from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'").Rows[0][0].ToString());
                    Boolean maximum = Convert.ToBoolean(db.GetData("select demand_maximum_bit  from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'").Rows[0][0].ToString());

                    if (limit == true)
                    {
                        if (qty_bal <= demand_limit)
                        {
                            db.Run("insert into center(code_items,date,note,wares) values ('" + dgv.Rows[i].Cells["code_items"].Value + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','Items that have reached the demand limit  ','" + dgv.Rows[i].Cells["id_ware"].Value + "')");
                        }
                    }
                    if (maximum == true)
                    {
                        if (qty_bal >= demand_maximum)
                        {
                            db.Run("insert into center(code_items,date,note,wares) values ('" + dgv.Rows[i].Cells["code_items"].Value + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','Items that have reached the demand maximum  ','" + dgv.Rows[i].Cells["id_ware"].Value + "')");
                        }
                    }


                }
                //c)insert exp_date cost:-
                //_______________________
                if (dgv.Rows[i].Cells["exp"].Value.ToString() == "True")
                {
                    db.Run("insert into exp_date (code_items,name_items,exp_date,qty,cost,id_ware,code,code_book) values('" + dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "','" + Convert.ToDateTime(dgv.Rows[i].Cells["exp_date"].Value).ToString("MM-dd-yyyy") + "','" + (Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value)) * (Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value)) * -1 + "','" + dgv.Rows[i].Cells["tot_after_dis"].Value + "','" + dgv.Rows[i].Cells["id_ware"].Value + "','" + txt_serial_string.Text + "','" + txt_code_book.Text + "')");
                }
                backgroundWorker1.ReportProgress(i);
            }
            bode_of_navigation(txt_serial_string.Text, txt_code_book.Text);
            db.Run("update sale_hd set vcs_value=(select sum(depit)-sum(credit) from entry where acc_num='" + combo_vsc_codetree.Text + "') where sale_hd_id='" + txt_serial_string.Text + "'");

           // edit = true;
            XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "saving ", "save", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            progressBar1.Visible = false;
        }
        private void edite_1()
        {
            for (int index = 0; index < dgv.Rows.Count; ++index)
            {
                try
                {
                    if (dgv.Rows[index].Cells["add_items1"].Value.ToString() == "2" && dgv.Rows[index].Cells["add_items"].Value.ToString() != "1")
                    {
                        dgv_edit.Rows.Add(1, dgv.Rows[index].Cells["code_items"].Value.ToString(), dgv.Rows[index].Cells["name_items"].Value.ToString(), dgv.Rows[index].Cells["name_unite"].Value.ToString(), dgv.Rows[index].Cells["f_unite"].Value.ToString(), dgv.Rows[index].Cells["exp"].Value.ToString(), dgv.Rows[index].Cells["type"].Value.ToString(), dgv.Rows[index].Cells["exp_date_1"].Value.ToString(), dgv.Rows[index].Cells["exp_date"].Value.ToString(), dgv.Rows[index].Cells["qty"].Value.ToString(), dgv.Rows[index].Cells["item_price"].Value.ToString(), dgv.Rows[index].Cells["tot_bef"].Value.ToString(), dgv.Rows[index].Cells["discount"].Value.ToString(), dgv.Rows[index].Cells["tot_after_dis"].Value.ToString(), dgv.Rows[index].Cells["taxes"].Value.ToString(), dgv.Rows[index].Cells["incloud_taxes"].Value.ToString(), dgv.Rows[index].Cells["taxes_value"].Value.ToString(), dgv.Rows[index].Cells["id_ware"].Value.ToString(), dgv.Rows[index].Cells["item_qty1"].Value.ToString(), dgv.Rows[index].Cells["sale_hd_id"].Value.ToString(), dgv.Rows[index].Cells["tot_after_dis1"].Value.ToString(), dgv.Rows[index].Cells["f_unite_1"].Value.ToString(), txt_serial_string.Text, txt_code_book.Text);
                    }
                    else
                    {
                        if (!(dgv.Rows[index].Cells["add_items"].Value.ToString() == "1"))
                            return;
                        dgv_add_items.Rows.Add(dgv.Rows[index].Cells["code_items"].Value.ToString(), dgv.Rows[index].Cells["name_items"].Value.ToString(), dgv.Rows[index].Cells["name_unite"].Value.ToString(), dgv.Rows[index].Cells["f_unite"].Value.ToString(), dgv.Rows[index].Cells["exp"].Value.ToString(), dgv.Rows[index].Cells["type"].Value.ToString(), dgv.Rows[index].Cells["exp_date"].Value.ToString(), 0, dgv.Rows[index].Cells["qty"].Value.ToString(), dgv.Rows[index].Cells["item_price"].Value.ToString(), dgv.Rows[index].Cells["tot_bef"].Value.ToString(), dgv.Rows[index].Cells["discount"].Value.ToString(), dgv.Rows[index].Cells["tot_after_dis"].Value.ToString(), dgv.Rows[index].Cells["taxes"].Value.ToString(), dgv.Rows[index].Cells["incloud_taxes"].Value.ToString(), dgv.Rows[index].Cells["taxes_value"].Value.ToString(), dgv.Rows[index].Cells["id_ware"].Value.ToString(), dgv.Rows[index].Cells["f_unite_1"].Value.ToString());
                    }
                }
                catch (Exception ex)
                {
                    db.log_error(string.Concat(ex));
                }
            }
            string str1 = "0";
            Decimal num1 = new Decimal(0);
            string str2 = "0";
            for (int index = 0; index < dgv.Rows.Count; ++index)
            {
                if (dgv.Rows[index].Cells["type"].Value.ToString() != "2")
                {
                    string str3 = db.GetData("select isnull((sum(qty)),0) from wares where code_items='" + dgv.Rows[index].Cells["code_items"].Value + "'and id_ware='" + dgv.Rows[index].Cells["id_ware"].Value + "'").Rows[0][0].ToString();
                    str1 = (Convert.ToDecimal(dgv.Rows[index].Cells["qty"].Value) * Convert.ToDecimal(dgv.Rows[index].Cells["f_unite"].Value)).ToString();
                    string str4 = (Convert.ToDecimal(dgv.Rows[index].Cells["item_qty1"].Value) * Convert.ToDecimal(dgv.Rows[index].Cells["f_unite_1"].Value)).ToString();
                    str2 = (Convert.ToDecimal(Convert.ToDecimal(str3) + Convert.ToDecimal(str4)) - Convert.ToDecimal(str1)).ToString();
                }
                if (Convert.ToDecimal(str2) < new Decimal(0) && dgv.Rows[index].Cells["type"].Value.ToString() != "2")
                {
                    int num2 = (int)MessageBox.Show("لايمكن الرصيد يكون بالسالب   كود الصنف : " + dgv.Rows[index].Cells["code_items"].Value);
                    return;
                }
                else if (dgv.Rows[index].Cells["exp"].Value.ToString() == "True")
                {
                    string str3 = db.GetData("select isnull((sum(qty)),0) from exp_date where code_items='" + dgv.Rows[index].Cells["code_items"].Value + "'and id_ware='" + dgv.Rows[index].Cells["id_ware"].Value + "' and exp_date='" + Convert.ToDateTime(dgv.Rows[index].Cells["exp_date"].Value).ToString("MM-dd-yyyy") + "'").Rows[0][0].ToString();
                    if (str3 == "")
                        str3 = "0";
                    int num2 = (int)MessageBox.Show(str3 + "  " + dgv.Rows[index].Cells["code_items"].Value);
                    if (Convert.ToDecimal(str3) < Convert.ToDecimal(str1))
                    {
                        int num3 = (int)MessageBox.Show("مفيش رصيد من تاريخ الصالحيه ...شوف تاريخ صلاحيه تاني ");
                        return;
                    }
                }
            }
            cogs();
            if (dgv_edit.Rows.Count > 0)
            {
                detailes_edit_update(dgv_edit, txt_serial_string.Text, txt_code_book.Text, comb_code_name.Text, "code_items_e", "name_items_e", "qty_e", "item_price_e", "tot_bef_e", "discount_e", "tot_after_dis_e", "taxes_e", "incloud_taxes_e", "taxes_value_e", "id_ware_e", "name_unite_e", "f_unite_e", "exp_t_f", "type_e", "dt_e", "exp_date_e");
                ware_edit_update(dgv_edit, "code_items_e", "id_ware_e", "qty_e", "f_unite_e", "f_unite_1_e", "item_qty1_e", "type_e");
                exp_insert_and_delete_edite(dgv_edit, "code_items_e", "name_items_e", "id_ware_e", "qty_e", "f_unite_e", "item_qty1_e", "tot_after_dis1_e", "tot_after_dis_e", "exp_date_1_e", "exp_date_e");
            }
            if (dgv.Rows.Count > 0)
            {
                detailes_edit_insert(dgv);
                ware_edit_update(dgv_add_items, "code_items_ai", "id_ware_ai", "qty_ai", "f_unite_ai", "type_ai");
                exp_insert_edite();
            }
            if (dgv_delete.Rows.Count > 0)
            {
                detailes_edit_delete();
                ware_del_row();
                exp_delete_edite();
            }
            edite_hd();
            string str5 = db.GetData("select top 1 code_entry from entry where attachno='" + txt_serial_string.Text + "' ").Rows[0][0].ToString();
            db.Run("delete from entry_hd where code_entry='" + str5 + "' and code_book='" + txt_code_entry_type.Text + "'");
            db.Run("delete from entry where code_entry='" + str5 + "' and code_book='" + txt_code_entry_type.Text + "'");
          //  select_type_entry();
            string error = "";
            DataTable dt_term = new DataTable();
            cls_book.Make_entry_type_purchase(ref dt_term, ref error, "سند مردودات مبيعات", combo_type.Text, combo_wars.Text, combo_vsc_codetree.Text, lbl_tot_befor.Text, lbl_tot_after_dis.Text, lbl_discount.Text, lbl_discount.Text, lbl_incloud_taxes.Text, lbl_vat_Add.Text);

            //txt_entry_string.Text = txt_code_entry_type.Text + txt_code_entry.Text;
            //cls_book.selectbook("entry_hd", "سند قيد", txt_code_entry_type.Text, txt_code_entry, "code_entry");
            //txt_entry_string.Text = txt_code_entry_type.Text + txt_code_entry.Text;
            string code_entry_term = (db.GetData("select code_entry from term where term_id='" + combo_type.Text + "' ").Rows[0][0].ToString());
            cls_book.Generat_numBooknum("entry", code_entry_term, ref numBook_entry, ref error, ref num_entry);
            txt_entry_string.Text = numBook_entry;


            db.Run("insert into entry_hd ([code_entry],code_book) values ('" + txt_code_entry_type.Text + txt_code_entry.Text + "','" + txt_code_entry_type.Text + "')");
            // for (int index = 0; index < dgv_term.Rows.Count; ++index)
            //   db.Run("insert into entry(  [code_entry]                           ,    acc_num                                                   ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                                          ,   type_acc                                                            , sort                                                       ,             depit                                                             ,                credit                                                   ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext,num_book )values('" + txt_code_entry_type.Text + txt_code_entry.Text + "','" + dgv_term.Rows[index].Cells[1].Value.ToString() + "','" + dgv_term.Rows[index].Cells[2].Value.ToString() + "',  '" + dgv_term.Rows[index].Cells["rootlevel_"].Value.ToString() + "'    ,  '" + dgv_term.Rows[index].Cells["rootlevel_name_"].Value.ToString() + "', '" + dgv_term.Rows[index].Cells["type_acc_"].Value.ToString() + "'       ,  '" + dgv_term.Rows[index].Cells["sort_"].Value.ToString() + "'  ,  '" + Convert.ToDecimal(dgv_term.Rows[index].Cells[3].Value.ToString()) + "'      ,'" + Convert.ToDecimal(dgv_term.Rows[index].Cells[4].Value.ToString()) + "' ,'" + txt_name_book_type.Text + "','" + txt_code_entry_type.Text + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + txt_serial_string.Text + "','" + txt_code_book.Text + "','" + comb_code_name.Text + "','" + txt_note.Text + "','"+num_entry+"')");
            for (int z = 0; z < dt_term.Rows.Count; z++)

            {
                db.Run("insert into entry(  [code_entry]                           ,    acc_num                                                   ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                                          ,   type_acc                                                            , sort                                                       ,             depit                                                             ,                credit                                                                          ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext ,num_book)values('" +
                                    txt_entry_string.Text + "'            ,'" + dt_term.Rows[z][1] + "'     ,'" + dt_term.Rows[z][2] + "'               ,  '" + dt_term.Rows[z][5] + "'    ,                               '" + dt_term.Rows[z][6] + "',                                                         '" + dt_term.Rows[z][8] + "'       ,                        '" + dt_term.Rows[z][7] + "'  ,                               '" + Convert.ToDecimal(dt_term.Rows[z][3]) * Convert.ToDecimal(txt_f_currance.Text) + "'      ,'" + Convert.ToDecimal(dt_term.Rows[z][4]) * Convert.ToDecimal(txt_f_currance.Text) + "' ,'" + txt_name_book_type.Text + "','" + txt_code_entry_type.Text + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + txt_serial_string.Text + "','" + txt_code_book.Text + "','" + comb_code_name.Text + "','" + txt_note.Text + "','" + num_entry + "')");
            }

            dgv_edit.Rows.Clear();
            dgv_delete.Rows.Clear();
            dgv_add_items.Rows.Clear();
            dgv_term.Rows.Clear();
            XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "edite succssfull ", "EDIT", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        private void delete()
        {
            if (!edit)
                return;
            if (txt_serial_string.Text == "")
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "ماشي بس هو مفيش حاجه علشان امسحها دخل كود  طيب !!؟؟؟؟ ", "رسال حذف مستند", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                progressBar1.Visible = true;
                prog = dgv.Rows.Count;
                for (int percentProgress = 0; percentProgress < dgv.Rows.Count; ++percentProgress)
                {
                    if (dgv.Rows[percentProgress].Cells["type"].Value.ToString() != "2")
                    {
                        Decimal num2 = Convert.ToDecimal(db.GetData("select qty from wares where code_items='" + dgv.Rows[percentProgress].Cells["code_items"].Value + "'and id_ware='" + dgv.Rows[percentProgress].Cells["id_ware"].Value + "'").Rows[0][0]) + Convert.ToDecimal(dgv.Rows[percentProgress].Cells["qty"].Value) * Convert.ToDecimal(dgv.Rows[percentProgress].Cells["f_unite"].Value);
                        if (num2 < 0)
                        {
                            MessageBox.Show("لايمكنان يكون  الرصيد يكون بالسالب    Codeitems=" + dgv.Rows[percentProgress].Cells["code_items"].Value);
                            return;
                        }
                        else
                        {
                            db.Run("update wares set qty =" + num2 + " where code_items='" + dgv.Rows[percentProgress].Cells["code_items"].Value + "'and id_ware='" + dgv.Rows[percentProgress].Cells["id_ware"].Value + "'");

                                db.Run("delete from exp_date where code_items='" + dgv.Rows[percentProgress].Cells["code_items"].Value + "' and id_ware='" + dgv.Rows[percentProgress].Cells["id_ware"].Value + "' and code='" + txt_serial_string.Text + "' and code_book='" + txt_code_book.Text + "'");
                        }
                    }
                    backgroundWorker1.ReportProgress(percentProgress);
                }
                progressBar1.Visible = false;
                string str = db.GetData("select top 1 code_entry from entry where attachno='" + txt_serial_string.Text + "' ").Rows[0][0].ToString();
                db.Run("delete from entry_hd where code_entry='" + str + "' ");
                db.Run("delete from entry where code_entry='" + str + "' ");
                db.Run("delete from rsale_hd where rsale_hd_id='" + txt_serial_string.Text + "'");
                db.Run("delete from rsale_dt where rsale_hd_id='" + txt_serial_string.Text + "' and code_book='" + txt_code_book.Text + "'");

                //delete item_tran
                db.Run("delete from items_trans where attachno='" + txt_serial_string.Text + "'");
                MessageBox.Show("delete");
                new_file();
            }
        }
        private void delete_row()
        {
            if (!edit)
            {
                try
                {
                    dgv.Rows.RemoveAt(dgv.SelectedRows[0].Index);
                }
                catch (Exception ex)
                {
                    db.log_error(string.Concat(ex));
                }
            }
            else if (dgv.SelectedRows.Count > 0)
            {
                if (dgv.CurrentRow.Cells["add_items"].Value.ToString() == "1")
                    dgv.Rows.RemoveAt(dgv.SelectedRows[0].Index);
                else if (dgv.CurrentRow.Cells["add_items"].Value.ToString() != "1")
                {
                    Convert.ToDecimal(db.GetData("select isnull(SUM( qty),0) from wares where code_items='" + dgv.CurrentRow.Cells["code_items"].Value + "' and id_ware='" + dgv.CurrentRow.Cells["id_ware"].Value + "'").Rows[0][0].ToString());
                    if (Convert.ToDecimal(dgv.CurrentRow.Cells["qty"].Value) * Convert.ToDecimal(dgv.CurrentRow.Cells["f_unite"].Value) > new Decimal(0))
                    {
                        dgv_delete.Rows.Add(dgv.CurrentRow.Cells["code_items"].Value.ToString(), dgv.CurrentRow.Cells["name_items"].Value.ToString(), dgv.CurrentRow.Cells["name_unite"].Value.ToString(), dgv.CurrentRow.Cells["f_unite"].Value.ToString(), dgv.CurrentRow.Cells["exp"].Value.ToString(), dgv.CurrentRow.Cells["type"].Value.ToString(), dgv.CurrentRow.Cells["exp_date_1"].Value.ToString(), dgv.CurrentRow.Cells["exp_date"].Value.ToString(), dgv.CurrentRow.Cells["qty"].Value.ToString(), dgv.CurrentRow.Cells["item_price"].Value.ToString(), dgv.CurrentRow.Cells["tot_bef"].Value.ToString(), dgv.CurrentRow.Cells["discount"].Value.ToString(), dgv.CurrentRow.Cells["tot_after_dis"].Value.ToString(), dgv.CurrentRow.Cells["taxes"].Value.ToString(), dgv.CurrentRow.Cells["incloud_taxes"].Value.ToString(), dgv.CurrentRow.Cells["taxes_value"].Value.ToString(), dgv.CurrentRow.Cells["id_ware"].Value.ToString(), dgv.CurrentRow.Cells["item_qty1"].Value.ToString(), dgv.CurrentRow.Cells["sale_hd_id"].Value.ToString(), dgv.CurrentRow.Cells["tot_after_dis1"].Value.ToString(), 1, dgv.CurrentRow.Cells["f_unite_1"].Value.ToString());
                        dgv.Rows.RemoveAt(dgv.SelectedRows[0].Index);
                    }
                    else
                    {
                        int num = (int)MessageBox.Show("مفيش رصيد");
                    }
                }
            }
        }
        private void calc_current_user()
        {
            try
            {
                //////////////  cala total =qty* price-des
                //  tot_bef, discount, tot_after_dis, taxes, incloud_taxes
                decimal tot_bef = 0;
                decimal discount = 0;
                decimal tot_after_dis = 0;
                decimal taxes_value = 0;
                decimal incloud_taxes = 0;

                dgv.CurrentRow.Cells["tot_bef"].Value = ((Convert.ToDecimal(dgv.CurrentRow.Cells["qty"].Value)) * (Convert.ToDecimal(dgv.CurrentRow.Cells["f_unite"].Value)) * Convert.ToDecimal(dgv.CurrentRow.Cells["item_price"].Value));
                dgv.CurrentRow.Cells["discount"].Value = Convert.ToDecimal(dgv.CurrentRow.Cells["discount"].Value);
                //calc tot=(qty*price)*(1-discount)
                dgv.CurrentRow.Cells["tot_after_dis"].Value = (Convert.ToDecimal(dgv.CurrentRow.Cells["tot_bef"].Value)) - (Convert.ToDecimal(dgv.CurrentRow.Cells["tot_bef"].Value) * (Convert.ToDecimal(dgv.CurrentRow.Cells["discount"].Value) / 100));
                dgv.CurrentRow.Cells["incloud_taxes"].Value = (Convert.ToDecimal(dgv.CurrentRow.Cells["tot_after_dis"].Value) * (1 + Convert.ToDecimal(dgv.CurrentRow.Cells["taxes"].Value)));
                dgv.CurrentRow.Cells["taxes_value"].Value = (Convert.ToDecimal(dgv.CurrentRow.Cells["tot_after_dis"].Value) * (Convert.ToDecimal(dgv.CurrentRow.Cells["taxes"].Value)));

                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    tot_bef += Convert.ToDecimal(dgv.Rows[i].Cells["tot_bef"].Value);
                    discount += Convert.ToDecimal(dgv.Rows[i].Cells["discount"].Value);
                    tot_after_dis += Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value);
                    incloud_taxes += Convert.ToDecimal(dgv.Rows[i].Cells["incloud_taxes"].Value);
                    taxes_value += Convert.ToDecimal(dgv.Rows[i].Cells["taxes_value"].Value);

                    if (dgv.Rows[i].Cells["exp_date"].Value == null && dgv.Rows[i].Cells["exp"].Value.ToString() == "True")
                    {
                        MessageBox.Show("ادخل تاريخ الصلاحيه");
                        return;
                    }
                }
                lbl_tot_befor.Text = Math.Round(tot_bef, 2) + "";
                // lbl_discount.Text = Math.Round(discount, 2) + "";
                lbl_tot_after_dis.Text = Math.Round(tot_after_dis, 2) + "";
                lbl_taxes_values.Text = Math.Round(taxes_value, 2) + "";
                if (tot_bef > 0)
                {
                    //                    txt_after_taxes.Text = Math.Round(tot_after_taxes, 2) + "";
                    lbl_incloud_taxes.Text = Math.Round(incloud_taxes, 2) + "";
                    lbl_vat_Add.Text = (Math.Round(tot_after_dis, 2) * 1 / 100) + "";
                }
                else
                {
                    MessageBox.Show("مينفعش دخل رقم  اقل من صفر");
                    lbl_tot_befor.Text = "0";
                    lbl_tot_after_dis.Text = "0";
                    lbl_incloud_taxes.Text = "0";
                }
                //taxes state
                bool taxes_taxes = Convert.ToBoolean(db.GetData("select taxes  from term  where term_id ='" + combo_type.Text + "'").Rows[0][0]);
                bool vat_add = Convert.ToBoolean(db.GetData("select vat_add  from term  where term_id ='" + combo_type.Text + "'").Rows[0][0]);
                if (taxes_taxes == true)
                {
                    lbl_taxes_values.Text = "0";
                }
                if (vat_add == true)
                {
                    lbl_vat_Add.Text = "0";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cogs()
        {
            for (int index = 0; index < dgv.Rows.Count; ++index)
            {
                string str = db.GetData("select isnull((sum(cost)),0) from wares where code_items='" + dgv.Rows[index].Cells["code_items"].Value.ToString() + "' and id_ware='" + dgv.Rows[index].Cells["id_ware"].Value.ToString() + "'").Rows[0][0].ToString();
                if (Convert.ToDouble(str) == 0.0 && dgv.Rows[index].Cells["type"].Value.ToString() != "2")
                {
                    int num = (int)MessageBox.Show("cost = 0    كود الصنف " + dgv.Rows[index].Cells["code_items"].Value.ToString());
                }
                dgv_cost.Rows.Add(dgv.Rows[index].Cells["code_items"].Value.ToString(), dgv.Rows[index].Cells["id_ware"].Value.ToString(), (Convert.ToDecimal(str) * Convert.ToDecimal(dgv.Rows[index].Cells["qty"].Value.ToString())));
            }
            Decimal d = new Decimal(0);
            for (int index = 0; index < dgv_cost.Rows.Count; ++index)
                d += Convert.ToDecimal(dgv_cost.Rows[index].Cells["cost_c"].Value);
            lbl_tot_cost.Text = string.Concat(Math.Round(d));
        }
        private void calc_all()
        {
            try
            {
                //////////////  cala total =qty* price-des
                //  tot_bef, discount, tot_after_dis, taxes, incloud_taxes
                decimal tot_bef = 0;
                decimal discount = 0;
                decimal tot_after_dis = 0;
                decimal taxes_value = 0;
                decimal incloud_taxes = 0;
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    dgv.Rows[i].Cells["tot_bef"].Value = ((Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value)) * (Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value)) * Convert.ToDecimal(dgv.Rows[i].Cells["item_price"].Value));
                    dgv.Rows[i].Cells["discount"].Value = Convert.ToDecimal(dgv.Rows[i].Cells["discount"].Value);
                    //calc tot=(qty*price)*(1-discount)
                    dgv.Rows[i].Cells["tot_after_dis"].Value = (Convert.ToDecimal(dgv.Rows[i].Cells["tot_bef"].Value)) - (Convert.ToDecimal(dgv.Rows[i].Cells["tot_bef"].Value) * (Convert.ToDecimal(dgv.Rows[i].Cells["discount"].Value) / 100));

                    dgv.Rows[i].Cells["incloud_taxes"].Value = (Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) * (1 + Convert.ToDecimal(dgv.Rows[i].Cells["taxes"].Value)));
                    dgv.Rows[i].Cells["taxes_value"].Value = (Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) * (Convert.ToDecimal(dgv.Rows[i].Cells["taxes"].Value)));


                    tot_bef += Convert.ToDecimal(dgv.Rows[i].Cells["tot_bef"].Value);
                    discount += Convert.ToDecimal(dgv.Rows[i].Cells["discount"].Value);
                    tot_after_dis += Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value);
                    incloud_taxes += Convert.ToDecimal(dgv.Rows[i].Cells["incloud_taxes"].Value);
                    taxes_value += Convert.ToDecimal(dgv.Rows[i].Cells["taxes_value"].Value);

                    if (dgv.Rows[i].Cells["exp_date"].Value == null && dgv.Rows[i].Cells["exp"].Value.ToString() == "True")
                    {
                        MessageBox.Show("ادخل تاريخ الصلاحيه");
                        return;
                    }
                }
                lbl_tot_befor.Text = Math.Round(tot_bef, 2) + "";
                //      lbl_discount.Text = Math.Round(discount, 2) + "";
                lbl_tot_after_dis.Text = Math.Round(tot_after_dis, 2) + "";
                lbl_taxes_values.Text = Math.Round(taxes_value, 2) + "";
                tot_after_dis -= Convert.ToDecimal(lbl_discount.Text);
                incloud_taxes -= Convert.ToDecimal(lbl_discount.Text);

                if (tot_after_dis > 0)
                {
                    lbl_incloud_taxes.Text = Math.Round(incloud_taxes, 2) + "";
                    lbl_tot_after_dis.Text = (Math.Round(tot_after_dis, 2)) + "";
                    lbl_vat_Add.Text = (Math.Round(tot_after_dis, 2) * 1 / 100) + "";

                }
                if (tot_after_dis < 0)
                {
                    //   MessageBox.Show("مينفعش دخل رقم  اقل من صفر");
                    lbl_tot_befor.Text = "0";
                    lbl_tot_after_dis.Text = "0";
                    lbl_incloud_taxes.Text = "0";
                }
                //taxes state
                bool taxes_taxes = Convert.ToBoolean(db.GetData("select taxes  from term  where term_id ='" + combo_type.Text + "'").Rows[0][0]);
                bool vat_add = Convert.ToBoolean(db.GetData("select vat_add  from term  where term_id ='" + combo_type.Text + "'").Rows[0][0]);
                if (taxes_taxes == true)
                {
                    lbl_taxes_values.Text = "0";
                }
                if (vat_add == true)
                {
                    lbl_vat_Add.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void get_dt(string num, string book)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("SELECT  [no],  code_items, name_items, name_unite, f_unite , exp, type, qty, item_price, tot_bef, discount, tot_after_dis, taxes, incloud_taxes,taxes_value, id_ware,rsale_dt_id  , 0 as add_items,qty as item_qty1 ,exp_date , exp_date as exp_date_1,tot_after_dis as tot_after_dis1 ,f_unite as f_unite_1  FROM   rsale_dt where rsale_hd_id='" + num + "' and code_book='" + book + "'", tb);
            dgv.DataSource = tb;
        }
        private void bode_of_navigation(string num, string book)
        {
            load_permission();
            lbl_stat_min_items.Caption = "0";
            lbl_stat_max_items.Caption = "0";
            lbl_balance_items.Caption = "0";
            lbl_stat_cost_items.Caption = "0";
            lbl_state_vcs_bal.Caption = "0";
            lbl_tot_cost.Text = "0";
            DataTable tb = new DataTable();
            db.GetData_DGV("select code_book from  rsale_hd where rsale_hd_id='" + num + "' and code_book='" + book + "' ", tb);
            if (tb.Rows.Count <= 0)
                return;
            edit = true;
            //  btn_chek_inv_tax.Enabled = true;
            btn_barcode.Enabled = true;
            get_dt(num, book);
            lbl_serial_P.Text = db.GetData("select serial_P from rsale_hd where rsale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            comb_code_name.Text = db.GetData("select name_book from rsale_hd where rsale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            txt_code_book.Text = db.GetData("select code_book from rsale_hd where rsale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            txt_serial_string.Text = db.GetData("select rsale_hd_id from rsale_hd where rsale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            combo_wars.Text = db.GetData("select id_ware from rsale_hd where rsale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            combo_vcs.Text = db.GetData("select vcs_name from rsale_hd where rsale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            combo_vsc_codetree.Text = db.GetData("select vcs_code from rsale_hd where rsale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            combo_type.Text = db.GetData("select term from rsale_hd where rsale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            combo_attach.Text = db.GetData("select attach_no from rsale_hd where rsale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            txt_note.Text = db.GetData("select note_txt from rsale_hd where rsale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            dt_piker.Text = db.GetData("select date_p from rsale_hd where rsale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            dt_due_date.Text = db.GetData("select due_date from rsale_hd where rsale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();

            lbl_user_name.Text = db.GetData("select [user_name] from rsale_hd where rsale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            lbl_user_code.Text = db.GetData("select user_code from rsale_hd where rsale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            lbl_tot_befor.Text = db.GetData("select tot_befor from rsale_hd where rsale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            lbl_tot_after_dis.Text = db.GetData("select tot_after_dis from rsale_hd where rsale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            lbl_discount.Text = db.GetData("select discount from rsale_hd where rsale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            lbl_incloud_taxes.Text = db.GetData("select incloud_taxes from rsale_hd where rsale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            lbl_taxes_values.Text = db.GetData("select taxes from rsale_hd where rsale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();

            //lbl_type.Text = db.GetData("select  type from vcs where vcs_name='" + combo_vcs.Text + "'").Rows[0][0].ToString();
            //lbl_id.Text = db.GetData("select  id from vcs where vcs_name='" + combo_vcs.Text + "'").Rows[0][0].ToString();
            //lbl_name.Text = db.GetData("select  name from vcs where vcs_name='" + combo_vcs.Text + "'").Rows[0][0].ToString();
            //lbl_country.Text = db.GetData("select  country from vcs where vcs_name='" + combo_vcs.Text + "'").Rows[0][0].ToString();
            //lbl_governate.Text = db.GetData("select  governate from vcs where vcs_name='" + combo_vcs.Text + "'").Rows[0][0].ToString();
            //lbl_regionCity.Text = db.GetData("select  regionCity from vcs where vcs_name='" + combo_vcs.Text + "'").Rows[0][0].ToString();
            //lbl_street.Text = db.GetData("select  street from vcs where vcs_name='" + combo_vcs.Text + "'").Rows[0][0].ToString();
            //lbl_buildingNumber.Text = db.GetData("select  buildingNumber from vcs where vcs_name='" + combo_vcs.Text + "'").Rows[0][0].ToString();
            //lbl_postalCode.Text = db.GetData("select  postalCode from vcs where vcs_name='" + combo_vcs.Text + "'").Rows[0][0].ToString();
            //lbl_floor.Text = db.GetData("select  floor from vcs where vcs_name='" + combo_vcs.Text + "'").Rows[0][0].ToString();
            dgv_edit.Rows.Clear();
            dgv_delete.Rows.Clear();
            dgv_add_items.Rows.Clear();
            dgv_cost.Rows.Clear();
            //remov null zer from entry
            //DataTable zerovalue_dt;
            try
            {
                DataTable zerovalue_dt = new DataTable();

                db.GetData_DGV("select depit+credit,attachno,acc_num,id from entry where code_entry<>'-11' and attachno='" + txt_serial_string.Text + "'", zerovalue_dt);
                for (int i = 0; i < zerovalue_dt.Rows.Count; i++)
                {
                    if (Convert.ToDouble(zerovalue_dt.Rows[i][0] + "") == 0)
                    {
                        db.Run("delete from entry where code_entry<>'-11' and attachno='" + zerovalue_dt.Rows[i][1] + "" + "'and acc_num='" + zerovalue_dt.Rows[i][2] + "" + "' and depit='0'and credit='0' and id='" + zerovalue_dt.Rows[i][3] + "" + "'");
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        private void get_dt_invoice(string num, string book)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("SELECT  [no],  code_items, name_items, name_unite, f_unite , exp, type, qty, item_price, tot_bef, discount, tot_after_dis, taxes, incloud_taxes,taxes_value, id_ware,sale_dt_id as rsale_dt_id , 0 as add_items,qty as item_qty1 ,exp_date , exp_date as exp_date_1,tot_after_dis as tot_after_dis1 ,f_unite as f_unite_1  FROM   sale_dt where sale_hd_id='" + num + "' and code_book='" + book + "'", tb);
          //  db.GetData_DGV("SELECT  [no],  code_items, name_items, name_unite, f_unite , exp, type, qty, item_price, tot_bef, discount, tot_after_dis, taxes, incloud_taxes,taxes_value, id_ware,purchase_dt_id as rpurchase_dt_id , 0 as add_items,qty as item_qty1 ,exp_date , exp_date as exp_date_1,tot_after_dis as tot_after_dis1 ,f_unite as f_unite_1  FROM   purchase_dt where purchase_hd_id='" + num + "' and code_book='" + book + "'", tb);

            dgv.DataSource = tb;
        }
        private void bode_of_navigation_get_invoice(string num, string book)
        {
            string str = db.GetData("select isnull(max(attach_no),0) from rsale_hd where rsale_hd_id='" + txt_serial_string.Text + "'").Rows[0][0].ToString();
           // string str = db.GetData("select isnull(max(attach_no),0) from rpurchase_hd where rpurchase_hd_id='" + txt_serial_string.Text + "'").Rows[0][0].ToString();

            if (combo_attach.Text != "")
            {
                combo_attach.Visible = false;
                lbl_combo_attach.Text = str;
            }
            else
            {
                combo_attach.Visible = false;
                lbl_combo_attach.Text = str;
            }
            lbl_stat_min_items.Caption = "0";
            lbl_stat_max_items.Caption = "0";
            lbl_balance_items.Caption = "0";
            lbl_stat_cost_items.Caption = "0";
            lbl_state_vcs_bal.Caption = "0";
            lbl_tot_cost.Text = "0";
            DataTable tb = new DataTable();
            db.GetData_DGV("select code_book from  sale_hd where sale_hd_id='" + num + "' and code_book='" + book + "' ", tb);
            if (tb.Rows.Count <= 0)
                return;
            get_dt_invoice(num, book);
            combo_wars.Text = db.GetData("select id_ware from sale_hd where sale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            combo_vcs.Text = db.GetData("select vcs_name from sale_hd where sale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            combo_vsc_codetree.Text = db.GetData("select vcs_code from sale_hd where sale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            lbl_tot_befor.Text = db.GetData("select tot_befor from sale_hd where sale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            lbl_tot_after_dis.Text = db.GetData("select tot_after_dis from sale_hd where sale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            lbl_discount.Text = db.GetData("select discount from sale_hd where sale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            lbl_incloud_taxes.Text = db.GetData("select incloud_taxes from sale_hd where sale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            lbl_taxes_values.Text = db.GetData("select taxes from sale_hd where sale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            //lbl_type.Text = db.GetData("select  type from vcs where vcs_name='" + combo_vcs.Text + "'").Rows[0][0].ToString();
            //lbl_id.Text = db.GetData("select  id from vcs where vcs_name='" + combo_vcs.Text + "'").Rows[0][0].ToString();
            //lbl_name.Text = db.GetData("select  name from vcs where vcs_name='" + combo_vcs.Text + "'").Rows[0][0].ToString();
            //lbl_country.Text = db.GetData("select  country from vcs where vcs_name='" + combo_vcs.Text + "'").Rows[0][0].ToString();
            //lbl_governate.Text = db.GetData("select  governate from vcs where vcs_name='" + combo_vcs.Text + "'").Rows[0][0].ToString();
            //lbl_regionCity.Text = db.GetData("select  regionCity from vcs where vcs_name='" + combo_vcs.Text + "'").Rows[0][0].ToString();
            //lbl_street.Text = db.GetData("select  street from vcs where vcs_name='" + combo_vcs.Text + "'").Rows[0][0].ToString();
            //lbl_buildingNumber.Text = db.GetData("select  buildingNumber from vcs where vcs_name='" + combo_vcs.Text + "'").Rows[0][0].ToString();
            //lbl_postalCode.Text = db.GetData("select  postalCode from vcs where vcs_name='" + combo_vcs.Text + "'").Rows[0][0].ToString();
            //lbl_floor.Text = db.GetData("select  floor from vcs where vcs_name='" + combo_vcs.Text + "'").Rows[0][0].ToString();
            dgv_edit.Rows.Clear();
            dgv_delete.Rows.Clear();
            dgv_add_items.Rows.Clear();
            dgv_cost.Rows.Clear();
        }
        private void perform_save()
        {
            if (lbl_combo_attach.Text == "" || lbl_combo_attach.Text == "0")
            {
                MessageBox.Show("يجب إختيار فاتوره مبيعات ");
            }
            // else if (!add_permission && !Convert.ToBoolean(db.GetData("select [save] from permission_sub where user_code='" + v.usercode + "' and name_frm ='resale' ").Rows[0][0].ToString()))
            // {
            // save_barButtonItem1.Enabled = true;
            // }
            else
            {
                //try
                //{
                //    if (db.GetData("select lock from sale_hd   where sale_hd_id= '" + txt_serial_string.Text + "'").Rows[0][0].ToString() == "t")
                //    {
                //        save_barButtonItem1.Enabled = false;
                //        btn_delete_file.Enabled = false;
                //        return;
                //    }
                //}
                //catch (Exception ex)
                //{
                //    db.log_error(string.Concat(ex));
                //}
                try
                {
                    //if (db.GetData("select uuid from sale_dt   where sale_hd_id= '" + txt_serial_string.Text + "'").Rows[0][0].ToString() != "0")
                    //{
                    //    save_barButtonItem1.Enabled = false;
                    //    btn_delete_file.Enabled = false;
                    //    return;
                    //}
                }
                catch (Exception ex)
                {
                    db.log_error(string.Concat(ex));
                }
                calc_all();
                if (dgv.Rows.Count ==0)
                {
                    XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "لايمكن الحفظ القيم بالصفر او اقل   ", "رساله تحذير", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                if (Convert.ToDouble(lbl_tot_befor.Text) < 0)
                {
                    XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "لايمكن الحفظ القيم بالصفر او اقل   ", "رساله تحذير", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                else if (combo_type.Text == "")
                {
                    XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "ادخل نوع السند   ", "رساله تحذير", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;

                }
                else if (combo_vcs.Text == "")
                {
                    XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "ادخل المورد او العميل   ", "رساله تحذير", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;

                }
                else if (Convert.ToBoolean(db.GetData("select credit from vcs where vcs_code='" + combo_vsc_codetree.Text + "'").Rows[0][0].ToString()))
                {
                    double num5 = Convert.ToDouble(db.GetData("select credit_limit from vcs where vcs_code='" + combo_vsc_codetree.Text + "'").Rows[0][0]);
                    if (Convert.ToDouble(lbl_incloud_taxes.Text) >= num5)
                    {
                        XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, " لا يوجد ائتمان للعميل الحد المسموح به هو  " + num5, "رساله تحذير", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;

                    }
                }
                else
                {
                   // if (!edit)
                    {
                        // if (add_permission)
                        //     {
                        save();
                        //bode_of_navigation(txt_serial_string.Text, txt_code_book.Text);
                        //   }
                        // else
                        // {
                        //   MessageBox.Show("ملكش صلايحه انك تضيف فاتوره تعدل فقط ");
                        // }
                    }
                    // else if (edit_permission)
                    ////////////else
                    ////////////{
                    ////////////    edite_1();
                    ////////////    bode_of_navigation(txt_serial_string.Text, txt_code_book.Text);
                    ////////////    edit = true;
                    ////////////}
                    //else
                    //{
                    //   MessageBox.Show("ملكش صلايحه انك تعدل علي الفاتوره  ");
                    //}
                    //v.sale_sale_hd_id = txt_serial_string.Text;
                    //v.sale_vcs_name = combo_vcs.Text;
                    //v.sale_vcs_code = combo_vsc_codetree.Text;
                    //v.sale_amount = lbl_incloud_taxes.Text;
                }
            }
        }
        private void add_items_in_dgv()
        {
            if (!edit)
            {
                dgv.Rows.Add(null, code_items_a, name_items_a, name_unite_a, unit1, exp_a, type_a, null, 0, 1, price_items_a, 0, 0, 0, taxes_a, 0, 0, combo_wars.Text);
            }
            else
            {
                DataTable dataTable = (DataTable)dgv.DataSource;
                DataRow row = dataTable.NewRow();
                row["code_items"] = code_items_a;
                row["name_items"] = name_items_a;
                row["name_unite"] = name_unite_a;
                row["f_unite"] = unit1;
                row["exp"] = exp_a;
                row["type"] = type_a;
                row["qty"] = 0;
                row["item_price"] = price_items_a;
                row["tot_bef"] = 0;
                row["discount"] = 0;
                row["tot_after_dis"] = 0;
                row["taxes"] = taxes_a;
                row["incloud_taxes"] = 0;
                row["taxes_value"] = 0;
                row["item_qty1"] = db.GetData("select isnull(sum(qty),0) from wares where code_items='" + code_items_a + "' and id_ware='" + combo_wars.Text + "'").Rows[0][0].ToString();
                row["add_items"] = 1;
                row["id_ware"] = combo_wars.Text;
                dataTable.Rows.Add(row);
                dataTable.AcceptChanges();
                row["f_unite_1"] = 1;
            }
        }
        string code_items_a, name_items_a, name_unite_a, unit1, price_items_a, discount_a, taxes_a, exp_a, type_a;//combo_add_items_SelectedIndexChanged
        private void add_items_in_property_comboadd_items(string find_fild, string code_items)
        {
            code_items_a = db.GetData("select isnull(max(code_items),0) from items where " + find_fild + "='" + code_items + "'").Rows[0][0].ToString();
            lbl_code_items.Text = code_items_a;
            if (chk_search_lang.Checked)
                name_items_a = db.GetData("select isnull(max(name_items),0) from items where " + find_fild + "='" + code_items + "'").Rows[0][0].ToString();
            else
                name_items_a = db.GetData("select isnull(max(name_items2),0) from items where " + find_fild + "='" + code_items + "'").Rows[0][0].ToString();
            name_unite_a = db.GetData("select isnull(max(name_unite),0) from items where code_items='" + code_items_a + "'").Rows[0][0].ToString();
            unit1 = db.GetData("select isnull(max(unit1),0) from items where code_items='" + code_items_a + "'").Rows[0][0].ToString();
            price_items_a = db.GetData("select isnull(max(price_buy),0) from items where code_items='" + code_items_a + "'").Rows[0][0].ToString();
            discount_a = db.GetData("select isnull(avg(discount),0) from sale_dt where code_items='" + code_items_a + "'").Rows[0][0].ToString();
            taxes_a = db.GetData("select isnull(max(taxes),0) from items where code_items='" + code_items_a + "'").Rows[0][0].ToString();
            if (string.Concat(db.GetData("select isnull(count([exp]),0) from items where code_items='" + code_items_a + "'").Rows[0][0]) != "0")
                exp_a = string.Concat(db.GetData("select [exp] from items where code_items='" + code_items_a + "'").Rows[0][0]);
            type_a = db.GetData("select isnull(max([type]),0) from items where code_items='" + code_items_a + "'").Rows[0][0].ToString();
        }
        private void new_file()
        {
            frm_rsale f = new frm_rsale();
            Close();
            f.Show();
        }
        private void add_unite_()
        {
            try
            {
                dgv.CurrentRow.Cells["name_unite"].Value = combo_unit.Text;
                dgv.CurrentRow.Cells["f_unite"].Value = lbl_f_unite.Text;
            }
            catch (Exception ex)
            {
                db.log_error(string.Concat(ex));
            }
        }
        private void load_combo_cost_exp_editmode()
        {
            try
            {
                all_comb.load_cost_items_exp(combo_expcost, dgv.CurrentRow.Cells["code_items"].Value.ToString(), dgv.CurrentRow.Cells["id_ware"].Value.ToString(), Convert.ToDateTime(dgv.CurrentRow.Cells["exp_date"].Value).ToString("MM-dd-yyyy"), txt_serial_string.Text, txt_code_book.Text);
            }
            catch (Exception ex)
            {
                db.log_error(string.Concat(ex));
            }
        }
        private void dgv_readonly()
        {
            dgv.Columns["no"].ReadOnly = true;
            dgv.Columns["code_items"].ReadOnly = true;
            dgv.Columns["name_items"].ReadOnly = true;
            dgv.Columns["f_unite"].ReadOnly = true;
            dgv.Columns["name_unite"].ReadOnly = true;
            dgv.Columns["exp_date"].ReadOnly = true;
            dgv.Columns["tot_bef"].ReadOnly = true;
            dgv.Columns["tot_after_dis"].ReadOnly = true;
            dgv.Columns["incloud_taxes"].ReadOnly = true;
            dgv.Columns["taxes_value"].ReadOnly = true;
            dgv.Columns["taxes"].ReadOnly = true;
            dgv.Columns["id_ware"].ReadOnly = true;
        }
        private void dgv_satue_cost_bal_vcs_dis_min_max()
        {
            try
            {
                lbl_stat_min_items.Caption = db.GetData("select isnull(min (discount),0) from sale_dt  where code_items ='" + dgv.CurrentRow.Cells["code_items"].Value.ToString() + "'").Rows[0][0].ToString();
                lbl_stat_max_items.Caption = db.GetData("select isnull(max (discount),0) from sale_dt  where code_items ='" + dgv.CurrentRow.Cells["code_items"].Value.ToString() + "'").Rows[0][0].ToString();
                lbl_stat_cost_items.Caption = db.GetData("select cost from wares where code_items='" + dgv.CurrentRow.Cells["code_items"].Value.ToString() + "' and id_ware='" + dgv.CurrentRow.Cells["id_ware"].Value.ToString() + "'").Rows[0][0].ToString();
                lbl_balance_items.Caption = db.GetData("select qty from wares where code_items='" + dgv.CurrentRow.Cells["code_items"].Value.ToString() + "' and id_ware='" + dgv.CurrentRow.Cells["id_ware"].Value.ToString() + "'").Rows[0][0].ToString();
                lbl_state_vcs_bal.Caption = db.GetData("select isnull(sum(depit)-sum(credit),0) from entry where acc_num='" + combo_vsc_codetree.Text + "'").Rows[0][0].ToString();
                if (!Convert.ToBoolean(db.GetData("select [show_low_price] from permission_price_discount where user_code='" + v.usercode + "'").Rows[0][0].ToString()))
                    lbl_stat_min_items.Caption = "";
                if (!Convert.ToBoolean(db.GetData("select [show_hight_price] from permission_price_discount where user_code='" + v.usercode + "'").Rows[0][0].ToString()))
                    lbl_stat_max_items.Caption = "";
                if (!Convert.ToBoolean(db.GetData("select [show_avg_cost] from permission_price_discount where user_code='" + v.usercode + "'").Rows[0][0].ToString()))
                    lbl_stat_cost_items.Caption = "";
                if (!Convert.ToBoolean(db.GetData("select [show_qty] from permission_price_discount where user_code='" + v.usercode + "'").Rows[0][0].ToString()))
                    lbl_balance_items.Caption = "";
                if (Convert.ToBoolean(db.GetData("select [show_acc] from permission_price_discount where user_code='" + v.usercode + "'").Rows[0][0].ToString()))
                    return;
                lbl_state_vcs_bal.Caption = "";
            }
            catch (Exception ex)
            {
                db.log_error(string.Concat(ex));
            }
        }
        bool add_permission = true;
        bool edit_permission = true;
        bool contral_sale_price = false;
        bool controal_sale_discount = false;
        bool controal_all_discount = false;
        private void load_permission()
        {
            save_barButtonItem1.Enabled = Convert.ToBoolean(db.GetData("select [add_only] from permission_sub where user_code='" + v.usercode + "' and name_frm ='resale' ").Rows[0][0].ToString());
            btn_delete_file.Enabled = Convert.ToBoolean(db.GetData("select [delete] from permission_sub where user_code='" + v.usercode + "' and name_frm ='resale' ").Rows[0][0].ToString());
            add_permission = Convert.ToBoolean(db.GetData("select [add_only] from permission_sub where user_code='" + v.usercode + "' and name_frm ='resale' ").Rows[0][0].ToString());
            if (add_permission)
                save_barButtonItem1.Enabled = true;
            edit_permission = Convert.ToBoolean(db.GetData("select [edit_only] from permission_sub where user_code='" + v.usercode + "' and name_frm ='resale' ").Rows[0][0].ToString());
            printer_previeew_barButtonItem10.Enabled = Convert.ToBoolean(db.GetData("select [print] from permission_sub where user_code='" + v.usercode + "' and name_frm ='resale' ").Rows[0][0].ToString());
            printer_direct_barButtonItem11.Enabled = Convert.ToBoolean(db.GetData("select [print] from permission_sub where user_code='" + v.usercode + "' and name_frm ='resale' ").Rows[0][0].ToString());
        }
        private void load_permission_price_discount_discount_all()
        {
            contral_sale_price = Convert.ToBoolean(db.GetData("select contral_sale_price from permission_price_discount where user_code='" + v.usercode + "'").Rows[0][0].ToString());
            controal_sale_discount = Convert.ToBoolean(db.GetData("select contral_sale_price from permission_price_discount where user_code='" + v.usercode + "'").Rows[0][0].ToString());
            controal_all_discount = Convert.ToBoolean(db.GetData("select contral_sale_price from permission_price_discount where user_code='" + v.usercode + "'").Rows[0][0].ToString());
            if (!contral_sale_price)
                dgv.Columns["item_price"].ReadOnly = true;
            else
                dgv.Columns["item_price"].ReadOnly = false;
            if (!controal_sale_discount)
                dgv.Columns["discount"].ReadOnly = true;
            else
                dgv.Columns["discount"].ReadOnly = false;
            if (!controal_all_discount)
                lbl_discount.ReadOnly = true;
            else
                lbl_discount.ReadOnly = false;
        }
        //=============Function Edite=============================
        public void cheak_qty(DataGridView dgv_, string code_items_col, string id_ware_col, string qty_col, string f_unite_col, string item_qty1_col)
        {
            for (int index = 0; index < dgv_.Rows.Count; ++index)
            {
                string str1 = db.GetData("select qty from wares where code_items='" + dgv_.Rows[index].Cells[code_items_col].Value + "'and id_ware='" + dgv_.Rows[index].Cells[id_ware_col].Value + "'").Rows[0][0].ToString();
                Decimal num1 = Convert.ToDecimal(dgv_.Rows[index].Cells[qty_col].Value) * Convert.ToDecimal(dgv_.Rows[index].Cells[f_unite_col].Value);
                string str2 = num1.ToString();
                num1 = Convert.ToDecimal(dgv_.Rows[index].Cells[item_qty1_col].Value) * Convert.ToDecimal(dgv_.Rows[index].Cells[f_unite_col].Value);
                string str3 = num1.ToString();
                if (str3 == "")
                    str3 = "0";
                num1 = Convert.ToDecimal(str1) + Convert.ToDecimal(str2) - Convert.ToDecimal(str3);
                if (Convert.ToDecimal(num1.ToString()) < new Decimal(0))
                {
                    int num2 = (int)MessageBox.Show("مينفعش الرصيد يكون بالسالب يا ناصح يا انصح اخواتك ");
                    break;
                }
            }
        }
        public static bool cheak_qty_insert(DataGridView dgv_, string code_items_col, string id_ware_col, string qty_col, string f_unite_col)
        {
            for (int index = 0; index < dgv_.Rows.Count; ++index)
            {
                string str1 = db.GetData("select qty from wares where code_items='" + dgv_.Rows[index].Cells[code_items_col].Value + "'and id_ware='" + dgv_.Rows[index].Cells[id_ware_col].Value + "'").Rows[0][0].ToString();
                Decimal num1 = Convert.ToDecimal(dgv_.Rows[index].Cells[qty_col].Value) * Convert.ToDecimal(dgv_.Rows[index].Cells[f_unite_col].Value);
                string str2 = num1.ToString();
                num1 = Convert.ToDecimal(str1) - Convert.ToDecimal(str2);
                if (Convert.ToDecimal(num1.ToString()) < new Decimal(0))
                {
                    int num2 = (int)MessageBox.Show("مينفعش الرصيد يكون بالسالب يا ناصح يا انصح اخواتك ");
                }
            }
            return false;
        }
        private void edite_hd()
        {
            db.Run("update sale_hd set   vcs_code='" + combo_vsc_codetree.Text + "', vcs_name='" + combo_vcs.Text + "', term='" + combo_type.Text + "',  date_P='" + Convert.ToDateTime(dt_piker.Value).ToString("MM-dd-yyyy") + "',due_date='" + dt_due_date.Value.ToString("MM-dd-yyyy") + "', tot_befor='" + lbl_tot_befor.Text + "', tot_after_dis='" + lbl_tot_after_dis.Text + "', discount='" + lbl_discount.Text + "', incloud_taxes='" + lbl_incloud_taxes.Text + "', taxes_value='" + lbl_taxes_values.Text + "', id_ware='" + combo_wars.Text + "', code_entry='" + txt_code_entry.Text + "', book_name_entry='" + txt_name_book_type.Text + "', code_book_entry='" + txt_code_entry_type.Text + "', note_txt='" + txt_note.Text + "', user_code='" + lbl_user_code.Text + "', user_name='" + lbl_user_name.Text + "',currance='" + combo_currance.Text + "',f_currance='" + txt_f_currance.Text + "'  where sale_hd_id='" + txt_serial_string.Text + "'and  code_book='" + txt_code_book.Text + "'");
            db.Run("update sale_hd set vcs_value=(select sum(depit)-sum(credit) from entry where acc_num='" + combo_vsc_codetree.Text + "') where sale_hd_id='" + txt_serial_string.Text + "'");


            //delete trans

            db.Run("delete from items_trans where attachno='" + txt_serial.Text + "'");


            //insert into trans items
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                //insert into trans_items_trans 
                if (dgv.Rows[i].Cells["exp"].Value.ToString() == "False")
                {
                    db.Run("insert into items_trans (                        code_items,                                name_items,                                                                qty                                                                ,f_unite                                                      ,                        name_unite            ,exp_date                    ,id_ware                            ,attachno                      ,attachbook            ,attachnamebook                    ,vcs_code                           ,vcs_name      ,                 dates       ) values ('" +

                                                     dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "','" + Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) * -1 + "' ,'" + Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value) + "','" + (dgv.Rows[i].Cells["name_unite"].Value) + "',null,'" + (dgv.Rows[i].Cells["id_ware"].Value) + "','" + txt_serial_string.Text + "','" + comb_code_name.Text + "','" + comb_code_name.Text + "','" + combo_vsc_codetree.Text + "','" + combo_vcs.Text + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "')");

                }
                else
                {
                    //B)items is expiry
                    db.Run("insert into items_trans (                                             code_items,                                      name_items,                                                                        qty                                                          ,f_unite,                                                        name_unite                                                        ,exp_date                    ,id_ware                 ,attachno                    ,attachbook                    ,attachnamebook                  ,vcs_code                       ,vcs_name                              ,dates) values ('" +
                                dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "','" + Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) * -1 + "' ,'" + Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value) + "','" + (dgv.Rows[i].Cells["name_unite"].Value) + "','" + Convert.ToDateTime(dgv.Rows[i].Cells["exp_date"].Value).ToString("MM-dd-yyyy") + "','" + (dgv.Rows[i].Cells["id_ware"].Value) + "','" + txt_serial_string.Text + "','" + comb_code_name.Text + "','" + comb_code_name.Text + "','" + combo_vsc_codetree.Text + "','" + combo_vcs.Text + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "')");
                }

            }
        }
        private void detailes_edit_update(DataGridView dgv_, string txt_serial, string txt_code_book, string comb_code_name, string code_items_e_col, string name_items_e_col, string qty_e_col, string item_price_e_col, string tot_bef_e_col, string discount_e_col, string tot_after_dis_e_col, string taxes_e_col, string incloud_taxes_e_col, string taxes_value_e_col, string id_ware_e_col, string name_unite_e_col, string f_unite_e_col, string exp_e_col, string type_e_col, string sale_dt_id_e_col, string exp_date_e_col)
        {
            for (int i = 0; i < dgv_edit.Rows.Count; i++)
            {
                if (dgv_edit.Rows[i].Cells["exp_t_f"].Value.ToString() == "False")
                {
                    db.Run("update sale_dt set  sale_hd_id='" + txt_serial + "', code_book='" + txt_code_book + "', name_book='" + comb_code_name + "',code_items='" + dgv_edit.Rows[i].Cells[code_items_e_col].Value.ToString() + "', name_items='" + dgv_edit.Rows[i].Cells[name_items_e_col].Value.ToString() + "', qty='" + dgv_edit.Rows[i].Cells[qty_e_col].Value.ToString() + "', item_price='" + dgv_edit.Rows[i].Cells[item_price_e_col].Value.ToString() + "', tot_bef='" + dgv_edit.Rows[i].Cells[tot_bef_e_col].Value.ToString() + "', discount='" + dgv_edit.Rows[i].Cells[discount_e_col].Value.ToString() + "', tot_after_dis='" + dgv_edit.Rows[i].Cells[tot_after_dis_e_col].Value.ToString() + "', taxes='" + dgv_edit.Rows[i].Cells[taxes_e_col].Value.ToString() + "', incloud_taxes='" + dgv_edit.Rows[i].Cells[incloud_taxes_e_col].Value.ToString() + "', taxes_value='" + dgv_edit.Rows[i].Cells[taxes_value_e_col].Value.ToString() + "', id_ware='" + dgv_edit.Rows[i].Cells[id_ware_e_col].Value.ToString() + "', name_unite='" + dgv_edit.Rows[i].Cells[name_unite_e_col].Value.ToString() + "', f_unite='" + dgv_edit.Rows[i].Cells[f_unite_e_col].Value.ToString() + "', [exp]='" + dgv_edit.Rows[i].Cells[exp_e_col].Value.ToString() + "', [type]='" + dgv_edit.Rows[i].Cells[type_e_col].Value.ToString() + "',tot_after_dis_forex='" + Convert.ToDecimal(dgv_edit.Rows[i].Cells[tot_after_dis_e_col].Value.ToString()) * Convert.ToDecimal(txt_f_currance.Text) + "' where sale_dt_id='" + dgv_edit.Rows[i].Cells[sale_dt_id_e_col].Value.ToString() + "'");
                    //update items_trans
                    db.Run("update items_trans set  qty   ='" + Convert.ToDecimal(dgv_edit.Rows[i].Cells[qty_e_col].Value) * Convert.ToDecimal(dgv_edit.Rows[i].Cells[f_unite_e_col].Value) * -1 + "'  ,f_unite ='" + Convert.ToDecimal(dgv_edit.Rows[i].Cells[f_unite_e_col].Value) + "'      ,  name_unite ='" + (dgv_edit.Rows[i].Cells[name_unite_e_col].Value) + "'     ,id_ware    ='" + dgv_edit.Rows[i].Cells[id_ware_e_col].Value.ToString() + "' ,attachno  ='" + txt_serial_string.Text + "'   ,attachnamebook  ='edit'   ,vcs_code  ='" + combo_vsc_codetree.Text + "'   ,vcs_name='" + combo_vcs.Text + "' , dates  ='" + Convert.ToDateTime(dt_piker.Value).ToString("MM-dd-yyyy") + "'  where attachno='" + txt_serial_string.Text + "' ");

                }
                else
                {
                    db.Run("update sale_dt set sale_hd_id='" + txt_serial + "', code_book='" + txt_code_book + "', name_book='" + comb_code_name + "',code_items='" + dgv_edit.Rows[i].Cells[code_items_e_col].Value.ToString() + "', name_items='" + dgv_edit.Rows[i].Cells[name_items_e_col].Value.ToString() + "', qty='" + dgv_edit.Rows[i].Cells[qty_e_col].Value.ToString() + "', item_price='" + dgv_edit.Rows[i].Cells[item_price_e_col].Value.ToString() + "', tot_bef='" + dgv_edit.Rows[i].Cells[tot_bef_e_col].Value.ToString() + "', discount='" + dgv_edit.Rows[i].Cells[discount_e_col].Value.ToString() + "', tot_after_dis='" + dgv_edit.Rows[i].Cells[tot_after_dis_e_col].Value.ToString() + "', taxes='" + dgv_edit.Rows[i].Cells[taxes_e_col].Value.ToString() + "', incloud_taxes='" + dgv_edit.Rows[i].Cells[incloud_taxes_e_col].Value.ToString() + "', taxes_value='" + dgv_edit.Rows[i].Cells[taxes_value_e_col].Value.ToString() + "', id_ware='" + dgv_edit.Rows[i].Cells[id_ware_e_col].Value.ToString() + "', exp_date='" + Convert.ToDateTime(dgv_edit.Rows[i].Cells[exp_date_e_col].Value).ToString("MM-dd-yyyy") + "', name_unite='" + dgv_edit.Rows[i].Cells[name_unite_e_col].Value.ToString() + "', f_unite='" + dgv_edit.Rows[i].Cells[f_unite_e_col].Value.ToString() + "', [exp]='" + dgv_edit.Rows[i].Cells[exp_e_col].Value.ToString() + "', [type]='" + dgv_edit.Rows[i].Cells[type_e_col].Value.ToString() + "',tot_after_dis_forex='" + Convert.ToDecimal(dgv_edit.Rows[i].Cells[tot_after_dis_e_col].Value.ToString()) * Convert.ToDecimal(txt_f_currance.Text) + "'   where sale_dt_id='" + dgv_edit.Rows[i].Cells[sale_dt_id_e_col].Value.ToString() + "'");
                    //update items_trans
                    db.Run("update items_trans set  qty   ='" + Convert.ToDecimal(dgv_edit.Rows[i].Cells[qty_e_col].Value) * Convert.ToDecimal(dgv_edit.Rows[i].Cells[f_unite_e_col].Value) * -1 + "'  ,f_unite ='" + Convert.ToDecimal(dgv_edit.Rows[i].Cells[f_unite_e_col].Value) + "'      ,  name_unite ='" + (dgv_edit.Rows[i].Cells[name_unite_e_col].Value) + "'     ,id_ware    ='" + dgv_edit.Rows[i].Cells[id_ware_e_col].Value.ToString() + "' ,attachno  ='" + txt_serial_string.Text + "'   ,attachnamebook  ='edit'   ,vcs_code  ='" + combo_vsc_codetree.Text + "'   ,vcs_name='" + combo_vcs.Text + "' , dates  ='" + Convert.ToDateTime(dt_piker.Value).ToString("MM-dd-yyyy") + "',exp_date='" + Convert.ToDateTime(dgv_edit.Rows[i].Cells[exp_date_e_col].Value).ToString("MM-dd-yyyy") + "'  where attachno='" + txt_serial_string.Text + "' ");
                }


            }
        }
        private void detailes_edit_insert(DataGridView dgv_)
        {
            for (int i = 0; i < dgv_.Rows.Count; i++)
            {
                //  if (dgv_add_items.Rows[i].Cells["add_items_ai"].Value.ToString() == "1")
                {
                    try
                    {
                        //items is not exp
                        if (dgv_add_items.Rows[i].Cells["exp_ai"].Value.ToString() == "False")
                        {
                            db.Run("insert into sale_dt(sale_hd_id ,         code_book ,                       name_book         ,                       code_items              ,                        name_items             ,                                         qty             ,                                      item_price                  ,                                         tot_bef             ,                                         discount             ,                                         tot_after_dis             ,                                        taxes              ,                                        incloud_taxes                 ,                                          taxes_value             ,      id_ware         ,                         f_unite,                                   name_unite                                           ,no,                                                           [exp]              ,            exp_date                        ,[type],serial_P,tot_after_dis_forex) values('" +
                                                     txt_serial_string.Text + "','" + txt_code_book.Text + "', '" + comb_code_name.Text + "','" + dgv_add_items.Rows[i].Cells["code_items_ai"].Value + "','" + dgv_add_items.Rows[i].Cells["name_items_ai"].Value + "'," + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["qty_ai"].Value) + ",'" + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["item_price_ai"].Value) + "'," + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["tot_bef_ai"].Value) + "," + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["discount_ai"].Value) + "," + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["tot_after_dis_ai"].Value) + "," + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["taxes_ai"].Value) + ",'" + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["incloud_taxes_ai"].Value) + "','" + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["taxes_value_ai"].Value) + "','" + combo_wars.Text + "','" + (dgv_add_items.Rows[i].Cells["f_unite_ai"].Value) + "','" + (dgv_add_items.Rows[i].Cells["name_unite_ai"].Value) + "','" + 0 + "','" + Convert.ToBoolean((dgv_add_items.Rows[i].Cells["exp_ai"].Value)) + "',            Null              ,'" + (dgv_add_items.Rows[i].Cells["type_ai"].Value) + "','" + lbl_serial_P.Text + "','" + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["discount_ai"].Value) * Convert.ToDecimal(txt_f_currance.Text) + "')");

                            //insert item_trans
                            db.Run("insert into items_trans (                        code_items,                                name_items,                                                                qty                                                                ,f_unite                                                      ,                        name_unite            ,exp_date                    ,id_ware                            ,attachno                      ,attachbook            ,attachnamebook                    ,vcs_code                           ,vcs_name      ,                 dates       ) values ('" +

                                               dgv_add_items.Rows[i].Cells["code_items_ai"].Value + "','" + dgv_add_items.Rows[i].Cells["name_items_ai"].Value + "','" + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["qty_ai"].Value) * Convert.ToDecimal(dgv_add_items.Rows[i].Cells["f_unite_ai"].Value) * -1 + "' ,'" + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["f_unite_ai"].Value) + "','" + (dgv_add_items.Rows[i].Cells["name_unite_ai"].Value) + "',null,'" + (dgv_add_items.Rows[i].Cells["id_ware_ai"].Value) + "','" + txt_serial_string.Text + "','" + comb_code_name.Text + "','" + comb_code_name.Text + "','" + combo_vsc_codetree.Text + "','" + combo_vcs.Text + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "')");

                        }
                        else //items is exp
                        {
                            db.Run("insert into sale_dt(sale_hd_id ,         code_book ,                       name_book         ,                       code_items              ,                        name_items             ,                                         qty             ,                                      item_price                  ,                                         tot_bef             ,                                         discount             ,                                         tot_after_dis             ,                                        taxes              ,                                        incloud_taxes                 ,                                          taxes_value             ,      id_ware         ,                         f_unite,                                   name_unite                                           ,no,                                                           [exp]              ,            exp_date                        ,[type],serial_P,tot_after_dis_forex) values('" +
                                                     txt_serial_string.Text + "','" + txt_code_book.Text + "', '" + comb_code_name.Text + "','" + dgv_add_items.Rows[i].Cells["code_items_ai"].Value + "','" + dgv_add_items.Rows[i].Cells["name_items_ai"].Value + "'," + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["qty_ai"].Value) + ",'" + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["item_price_ai"].Value) + "'," + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["tot_bef_ai"].Value) + "," + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["discount_ai"].Value) + "," + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["tot_after_dis_ai"].Value) + "," + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["taxes_ai"].Value) + ",'" + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["incloud_taxes_ai"].Value) + "','" + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["taxes_value_ai"].Value) + "','" + combo_wars.Text + "','" + (dgv_add_items.Rows[i].Cells["f_unite_ai"].Value) + "','" + (dgv_add_items.Rows[i].Cells["name_unite_ai"].Value) + "','" + 0 + "','" + Convert.ToBoolean((dgv_add_items.Rows[i].Cells["exp_ai"].Value)) + "','" + Convert.ToDateTime(dgv_add_items.Rows[i].Cells["exp_date_1_ai"].Value).ToString("MM-dd-yyyy") + "','" + (dgv_add_items.Rows[i].Cells["type_ai"].Value) + "','" + lbl_serial_P.Text + "','" + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["discount_ai"].Value) * Convert.ToDecimal(txt_f_currance.Text) + "')");

                            //insert item trasn have exp items
                            db.Run("insert into items_trans (                                             code_items,                                      name_items,                                                                        qty                                                          ,f_unite,                                                        name_unite                                                        ,exp_date                    ,id_ware                 ,attachno                    ,attachbook                    ,attachnamebook                  ,vcs_code                       ,vcs_name                              ,dates) values ('" +
                                         dgv_add_items.Rows[i].Cells["code_items_ai"].Value + "','" + dgv_add_items.Rows[i].Cells["name_items_ai"].Value + "','" + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["qty_ai"].Value) * Convert.ToDecimal(dgv_add_items.Rows[i].Cells["f_unite_ai"].Value) * -1 + "' ,'" + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["f_unite_ai"].Value) + "','" + (dgv_add_items.Rows[i].Cells["name_unite_ai"].Value) + "','" + Convert.ToDateTime(dgv_add_items.Rows[i].Cells["exp_date_1_ai"].Value).ToString("MM-dd-yyyy") + "','" + (dgv_add_items.Rows[i].Cells["id_ware_ai"].Value) + "','" + txt_serial_string.Text + "','" + comb_code_name.Text + "','" + comb_code_name.Text + "','" + combo_vsc_codetree.Text + "','" + combo_vcs.Text + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "')");

                        }
                    }
                    catch (Exception)
                    {


                    }
                }

            }

        }
        private void detailes_edit_delete()
        {
            for (int i = 0; i < dgv_delete.Rows.Count; i++)
            {
                db.Run("delete from sale_dt where code_items='" + dgv_delete.Rows[i].Cells["code_items_de"].Value.ToString() + "' and sale_dt_id='" + dgv_delete.Rows[i].Cells["dt_de"].Value.ToString() + "'");
                //delete from items_trans
                db.Run("delete  from items_trans where attachno='" + txt_serial_string.Text + "' and code_items='" + dgv_delete.Rows[i].Cells["code_items_de"].Value.ToString() + "'");
            }
        }
        private void ware_edit_update(DataGridView dgv_, string code_items_col, string id_ware_col, string qty_col, string f_unite_col, string f_unite_1_col, string item_qty1_col, string type)
        {
            for (int index1 = 0; index1 < dgv_.Rows.Count; ++index1)
            {
                if (dgv_.Rows[index1].Cells[type].Value.ToString() == "1" && dgv_.Rows[index1].Cells[type].Value.ToString() != "2")
                {
                    string str1 = db.GetData("select qty from wares where code_items='" + dgv_.Rows[index1].Cells[code_items_col].Value + "'and id_ware='" + dgv_.Rows[index1].Cells[id_ware_col].Value + "'").Rows[0][0].ToString();
                    Decimal num1 = Convert.ToDecimal(dgv_.Rows[index1].Cells[qty_col].Value) * Convert.ToDecimal(dgv_.Rows[index1].Cells[f_unite_col].Value);
                    string str2 = num1.ToString();
                    num1 = Convert.ToDecimal(dgv_.Rows[index1].Cells[item_qty1_col].Value) * Convert.ToDecimal(dgv_.Rows[index1].Cells[f_unite_1_col].Value);
                    string str3 = num1.ToString();
                    if (str3 == "")
                        str3 = "0";
                    num1 = Convert.ToDecimal(Convert.ToDecimal(str1) + Convert.ToDecimal(str3)) - Convert.ToDecimal(str2);
                    string str4 = num1.ToString();
                    if (Convert.ToDecimal(str4) < new Decimal(0))
                    {
                        int num2 = (int)MessageBox.Show("حدث خطاء والرصيد اصبح بالسالب");
                        break;
                    }
                    else
                    {
                        db.Run("update wares set qty =( " + str4 + ") where code_items='" + dgv_.Rows[index1].Cells[code_items_col].Value + "'and id_ware= '" + dgv_.Rows[index1].Cells[id_ware_col].Value + "'");
                        Decimal num2 = Convert.ToDecimal(db.GetData("select isnull(max(demand_limit),0)  from wares where code_items='" + dgv_.Rows[index1].Cells[code_items_col].Value + "' and id_ware='" + dgv_.Rows[index1].Cells[id_ware_col].Value + "'").Rows[0][0].ToString());
                        Decimal num3 = Convert.ToDecimal(db.GetData("select isnull(max(demand_maximum),0)  from wares where code_items='" + dgv_.Rows[index1].Cells[code_items_col].Value + "' and id_ware='" + dgv_.Rows[index1].Cells[id_ware_col].Value + "'").Rows[0][0].ToString());
                        bool flag1 = Convert.ToBoolean(db.GetData("select demand_limit_bit  from wares where code_items='" + dgv_.Rows[index1].Cells[code_items_col].Value + "' and id_ware='" + dgv_.Rows[index1].Cells[id_ware_col].Value + "'").Rows[0][0].ToString());
                        bool flag2 = Convert.ToBoolean(db.GetData("select demand_maximum_bit  from wares where code_items='" + dgv_.Rows[index1].Cells[code_items_col].Value + "' and id_ware='" + dgv_.Rows[index1].Cells[id_ware_col].Value + "'").Rows[0][0].ToString());
                        DateTime dateTime;
                        if (flag1 && Convert.ToDecimal(str4) <= num2)
                        {
                            object[] objArray1 = new object[7];
                            objArray1[0] = "insert into center(code_items,date,note,wares) values ('";
                            objArray1[1] = dgv_.Rows[index1].Cells[code_items_col].Value;
                            objArray1[2] = "','";
                            object[] objArray2 = objArray1;
                            int index2 = 3;
                            dateTime = dt_piker.Value;
                            string str5 = dateTime.ToString("MM-dd-yyyy");
                            objArray2[index2] = str5;
                            objArray1[4] = "','Items that have reached the demand limit  ','";
                            objArray1[5] = dgv_.Rows[index1].Cells[id_ware_col].Value;
                            objArray1[6] = "')";
                            db.Run(string.Concat(objArray1));
                        }
                        if (flag2 && Convert.ToDecimal(str4) >= num3)
                        {
                            object[] objArray1 = new object[7];
                            objArray1[0] = "insert into center(code_items,date,note,wares) values ('";
                            objArray1[1] = dgv_.Rows[index1].Cells[code_items_col].Value;
                            objArray1[2] = "','";
                            object[] objArray2 = objArray1;
                            int index2 = 3;
                            dateTime = dt_piker.Value;
                            string str5 = dateTime.ToString("MM-dd-yyyy");
                            objArray2[index2] = str5;
                            objArray1[4] = "','Items that have reached the demand maximum  ','";
                            objArray1[5] = dgv_.Rows[index1].Cells[id_ware_col].Value;
                            objArray1[6] = "')";
                            db.Run(string.Concat(objArray1));
                        }
                    }
                }
            }
        }
        private void ware_edit_update(DataGridView dgv_, string code_items_col, string id_ware_col, string qty_col, string f_unite_col, string type)
        {
            for (int index = 0; index < dgv_.Rows.Count; ++index)
            {
                if (dgv_.Rows[index].Cells[type].Value.ToString() == "1")
                {
                    string str = (Convert.ToDecimal(db.GetData("select qty from wares where code_items='" + dgv_.Rows[index].Cells[code_items_col].Value + "'and id_ware='" + dgv_.Rows[index].Cells[id_ware_col].Value + "'").Rows[0][0].ToString()) - Convert.ToDecimal((Convert.ToDecimal(dgv_.Rows[index].Cells[qty_col].Value) * Convert.ToDecimal(dgv_.Rows[index].Cells[f_unite_col].Value)).ToString())).ToString();
                    if (Convert.ToDecimal(str) < new Decimal(0))
                        break;
                    db.Run("update wares set qty =( " + str + ") where code_items='" + dgv_.Rows[index].Cells[code_items_col].Value + "'and id_ware= '" + dgv_.Rows[index].Cells[id_ware_col].Value + "'");
                    Decimal num1 = Convert.ToDecimal(db.GetData("select isnull(max(demand_limit),0)  from wares where code_items='" + dgv_.Rows[index].Cells[code_items_col].Value + "' and id_ware='" + dgv_.Rows[index].Cells[id_ware_col].Value + "'").Rows[0][0].ToString());
                    Decimal num2 = Convert.ToDecimal(db.GetData("select isnull(max(demand_maximum),0)  from wares where code_items='" + dgv_.Rows[index].Cells[code_items_col].Value + "' and id_ware='" + dgv_.Rows[index].Cells[id_ware_col].Value + "'").Rows[0][0].ToString());
                    bool flag1 = Convert.ToBoolean(db.GetData("select demand_limit_bit  from wares where code_items='" + dgv_.Rows[index].Cells[code_items_col].Value + "' and id_ware='" + dgv_.Rows[index].Cells[id_ware_col].Value + "'").Rows[0][0].ToString());
                    bool flag2 = Convert.ToBoolean(db.GetData("select demand_maximum_bit  from wares where code_items='" + dgv_.Rows[index].Cells[code_items_col].Value + "' and id_ware='" + dgv_.Rows[index].Cells[id_ware_col].Value + "'").Rows[0][0].ToString());
                    if (flag1 && Convert.ToDecimal(str) <= num1)
                        db.Run("insert into center(code_items,date,note,wares) values ('" + dgv_.Rows[index].Cells[code_items_col].Value + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','Items that have reached the demand limit  ','" + dgv_.Rows[index].Cells[id_ware_col].Value + "')");
                    if (flag2 && Convert.ToDecimal(str) >= num2)
                        db.Run("insert into center(code_items,date,note,wares) values ('" + dgv_.Rows[index].Cells[code_items_col].Value + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','Items that have reached the demand maximum  ','" + dgv_.Rows[index].Cells[id_ware_col].Value + "')");
                }
            }
        }
        private void ware_del_row()
        {
            string str1 = "0";
            for (int index1 = 0; index1 < dgv_delete.Rows.Count; ++index1)
            {
                if (dgv_delete.Rows[index1].Cells["type_de"].Value.ToString() == "1")
                {
                    string str2 = db.GetData("select qty from wares where code_items='" + dgv_delete.Rows[index1].Cells["code_items_de"].Value + "'and id_ware='" + dgv_delete.Rows[index1].Cells["id_ware_de"].Value + "'").Rows[0][0].ToString();
                    str1 = (Convert.ToDecimal(dgv_delete.Rows[index1].Cells["qty_de"].Value) * Convert.ToDecimal(dgv_delete.Rows[index1].Cells["f_unite_de"].Value)).ToString();
                    string str3 = (Convert.ToDecimal(dgv_delete.Rows[index1].Cells["item_qty1_de"].Value) * Convert.ToDecimal(dgv_delete.Rows[index1].Cells["f_unite_1_de"].Value)).ToString();
                    Decimal num1 = Convert.ToDecimal(str2) + Convert.ToDecimal(str3);
                    db.Run("update wares set qty =( " + num1 + ") where code_items='" + dgv_delete.Rows[index1].Cells["code_items_de"].Value + "'and id_ware= '" + dgv_delete.Rows[index1].Cells["id_ware_de"].Value + "'");
                    Decimal num2 = Convert.ToDecimal(db.GetData("select isnull(max(demand_limit),0)  from wares where code_items='" + dgv_delete.Rows[index1].Cells["code_items_de"].Value + "' and id_ware='" + dgv_delete.Rows[index1].Cells["id_ware_de"].Value + "'").Rows[0][0].ToString());
                    Decimal num3 = Convert.ToDecimal(db.GetData("select isnull(max(demand_maximum),0)  from wares where code_items='" + dgv_delete.Rows[index1].Cells["code_items_de"].Value + "' and id_ware='" + dgv_delete.Rows[index1].Cells["id_ware_de"].Value + "'").Rows[0][0].ToString());
                    bool flag1 = Convert.ToBoolean(db.GetData("select demand_limit_bit  from wares where code_items='" + dgv_delete.Rows[index1].Cells["code_items_de"].Value + "' and id_ware='" + dgv_delete.Rows[index1].Cells["id_ware_de"].Value + "'").Rows[0][0].ToString());
                    bool flag2 = Convert.ToBoolean(db.GetData("select demand_maximum_bit  from wares where code_items='" + dgv_delete.Rows[index1].Cells["code_items_de"].Value + "' and id_ware='" + dgv_delete.Rows[index1].Cells["id_ware_de"].Value + "'").Rows[0][0].ToString());
                    DateTime dateTime;
                    if (flag1 && Convert.ToDecimal(num1) <= num2)
                    {
                        object[] objArray1 = new object[7];
                        objArray1[0] = "insert into center(code_items,date,note,wares) values ('";
                        objArray1[1] = dgv_delete.Rows[index1].Cells["code_items_de"].Value;
                        objArray1[2] = "','";
                        object[] objArray2 = objArray1;
                        int index2 = 3;
                        dateTime = dt_piker.Value;
                        string str4 = dateTime.ToString("MM-dd-yyyy");
                        objArray2[index2] = str4;
                        objArray1[4] = "','Items that have reached the demand limit  ','";
                        objArray1[5] = dgv_delete.Rows[index1].Cells["id_ware_de"].Value;
                        objArray1[6] = "')";
                        db.Run(string.Concat(objArray1));
                    }
                    if (flag2 && Convert.ToDecimal(num1) >= num3)
                    {
                        object[] objArray1 = new object[7];
                        objArray1[0] = "insert into center(code_items,date,note,wares) values ('";
                        objArray1[1] = dgv_delete.Rows[index1].Cells["code_items_de"].Value;
                        objArray1[2] = "','";
                        object[] objArray2 = objArray1;
                        int index2 = 3;
                        dateTime = dt_piker.Value;
                        string str4 = dateTime.ToString("MM-dd-yyyy");
                        objArray2[index2] = str4;
                        objArray1[4] = "','Items that have reached the demand maximum  ','";
                        objArray1[5] = dgv_delete.Rows[index1].Cells["id_ware_de"].Value;
                        objArray1[6] = "')";
                        db.Run(string.Concat(objArray1));
                    }
                }
            }
        }
        private void exp_insert_and_delete_edite(DataGridView dgv_, string code_items_col, string name_items_col, string id_ware_col, string qty_col, string f_unite_col, string item_qty1_col, string tot_after_dis_col_1, string tot_after_dis_col, string exp_date_1_e_col, string exp_date_e_col)
        {
            for (int index1 = 0; index1 < dgv_edit.Rows.Count; ++index1)
            {
                if (dgv_.Rows[index1].Cells["exp_t_f"].Value.ToString() == "True")
                {
                    string[] strArray1 = new string[11]
                    {
            "select id_rows from exp_date where code_items='",
            dgv_.Rows[index1].Cells[code_items_col].Value.ToString(),
            "' and id_ware='",
            dgv_.Rows[index1].Cells[id_ware_col].Value.ToString(),
            "' and code='",
            txt_serial_string.Text,
            "' and code_book='",
            txt_code_book.Text,
            "' and exp_date='",
            null,
            null
                    };
                    string[] strArray2 = strArray1;
                    int index2 = 9;
                    DateTime dateTime = Convert.ToDateTime(dgv_.Rows[index1].Cells[exp_date_1_e_col].Value);
                    string str1 = dateTime.ToString("MM-dd-yyyy");
                    strArray2[index2] = str1;
                    strArray1[10] = "'";
                    string str2 = db.GetData(string.Concat(strArray1)).Rows[0][0].ToString();
                    if (str2 == null)
                    {
                        int num = (int)MessageBox.Show("مفيش رصيد او في حاجه غلط مش عارف ....؟!!بس مش عارف ", "مش عارف والله العظيم");
                        break;
                    }
                    else
                    {
                        object[] objArray1 = new object[13];
                        objArray1[0] = "delete from exp_date where code_items='";
                        objArray1[1] = dgv_.Rows[index1].Cells[code_items_col].Value;
                        objArray1[2] = "' and id_ware='";
                        objArray1[3] = dgv_.Rows[index1].Cells[id_ware_col].Value;
                        objArray1[4] = "' and exp_date='";
                        object[] objArray2 = objArray1;
                        int index3 = 5;
                        dateTime = Convert.ToDateTime(dgv_.Rows[index1].Cells[exp_date_1_e_col].Value);
                        string str3 = dateTime.ToString("MM-dd-yyyy");
                        objArray2[index3] = str3;
                        objArray1[6] = "' and id_rows='";
                        objArray1[7] = str2;
                        objArray1[8] = "' and code='";
                        objArray1[9] = txt_serial_string.Text;
                        objArray1[10] = "' and code_book='";
                        objArray1[11] = txt_code_book.Text;
                        objArray1[12] = "'";
                        db.Run(string.Concat(objArray1));
                        object[] objArray3 = new object[17];
                        objArray3[0] = "insert into exp_date (code_items,name_items,exp_date,qty,cost,id_ware,code,code_book) values('";
                        objArray3[1] = dgv_.Rows[index1].Cells[code_items_col].Value;
                        objArray3[2] = "','";
                        objArray3[3] = dgv_.Rows[index1].Cells[name_items_col].Value;
                        objArray3[4] = "','";
                        object[] objArray4 = objArray3;
                        int index4 = 5;
                        dateTime = Convert.ToDateTime(dgv_.Rows[index1].Cells[exp_date_e_col].Value);
                        string str4 = dateTime.ToString("MM-dd-yyyy");
                        objArray4[index4] = str4;
                        objArray3[6] = "','";
                        objArray3[7] = (Convert.ToDecimal(dgv_.Rows[index1].Cells[qty_col].Value) * Convert.ToDecimal(dgv_.Rows[index1].Cells[f_unite_col].Value) * new Decimal(-1));
                        objArray3[8] = "','";
                        objArray3[9] = dgv_.Rows[index1].Cells[tot_after_dis_col].Value;
                        objArray3[10] = "','";
                        objArray3[11] = dgv_.Rows[index1].Cells[id_ware_col].Value;
                        objArray3[12] = "',('";
                        objArray3[13] = txt_serial_string.Text;
                        objArray3[14] = "'),('";
                        objArray3[15] = txt_code_book.Text;
                        objArray3[16] = "'))";
                        db.Run(string.Concat(objArray3));
                    }
                }
            }
        }
        private void exp_insert_edite()
        {
            for (int index = 0; index < dgv_add_items.Rows.Count; ++index)
            {
                if (dgv_add_items.Rows[index].Cells["type_ai"].Value.ToString() == "1" && dgv_add_items.Rows[index].Cells["exp_ai"].Value.ToString() == "True")
                    db.Run("insert into exp_date (code_items,name_items,exp_date,qty,cost,id_ware,code,code_book) values('" + dgv_add_items.Rows[index].Cells["code_items_ai"].Value + "','" + dgv_add_items.Rows[index].Cells["name_items_ai"].Value + "','" + Convert.ToDateTime(dgv_add_items.Rows[index].Cells["exp_date_1_ai"].Value).ToString("MM-dd-yyyy") + "','" + (Convert.ToDecimal(dgv_add_items.Rows[index].Cells["qty_ai"].Value) * Convert.ToDecimal(dgv_add_items.Rows[index].Cells["f_unite_ai"].Value) * new Decimal(-1)) + "','" + dgv_add_items.Rows[index].Cells["tot_after_dis_ai"].Value + "','" + dgv_add_items.Rows[index].Cells["id_ware_ai"].Value + "',('" + txt_serial_string.Text + "'),('" + txt_code_book.Text + "')) ");
            }
        }
        private void exp_delete_edite()
        {
            for (int index = 0; index < dgv_delete.Rows.Count; ++index)
            {
                if (dgv_delete.Rows[index].Cells["exp_de"].Value.ToString() == "True")
                {
                    string str = db.GetData("select id_rows from exp_date where code_items='" + dgv_delete.Rows[index].Cells["code_items_de"].Value.ToString() + "' and id_ware='" + dgv_delete.Rows[index].Cells["id_ware_de"].Value.ToString() + "' and code='" + txt_serial_string.Text + "' and code_book='" + txt_code_book.Text + "' and exp_date='" + Convert.ToDateTime(dgv_delete.Rows[index].Cells["exp_date_1_de"].Value).ToString("MM-dd-yyyy") + "'").Rows[0][0].ToString();
                    db.Run("delete from exp_date where code_items='" + dgv_delete.Rows[index].Cells["code_items_de"].Value + "' and id_ware='" + dgv_delete.Rows[index].Cells["id_ware_de"].Value + "' and id_rows='" + str + "' and code='" + txt_serial_string.Text + "' and code_book='" + txt_code_book.Text + "'");
                }
            }
        }
        //=========================================
        //====================================controls 
        string code_entry, sort, rootlevel, rootlevel_name, type_acc;
        private void comb_code_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_code_book.Text = db.GetData("select code_book from book where name_book='" + comb_code_name.Text + "'").Rows[0][0].ToString();
            //cls_book.selectbook("rsale_hd", "سند مردودات مبيعات", this.txt_code_book.Text, this.txt_serial, "rsale_hd_id");
            //txt_serial_string.Text = txt_code_book.Text + txt_serial.Text;

            cls_book.Generat_numBooknum("rsale_hd", txt_code_book.Text, ref numBook_rsale, ref error, ref num);
            txt_serial_string.Text = numBook_rsale;

            lbl_comb_code_name.Text = comb_code_name.Text;
        }
        //==============================dgv
        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv);
            calc_all();
        }
        private void dgv_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            Classes.command.LoadSerial(dgv);
            calc_all();


        }
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //  MessageBox.Show(dgv.CurrentRow.Cells["exp"].Value.ToString());
            if ((dgv.CurrentRow.Cells["exp"].Value.ToString()) == "True")
            {
                combo_exp.Visible = true;
                btn_add_exp.Visible = true;
                lbl_exp.Visible = true;
                dt_exp.Visible = true;
                lbl_knowexp.Visible = true;
                btn_del_exp.Visible = true;
                combo_expcost.Visible = true;
                load_combo_cost_exp_editmode();
            }
            else if ((dgv.CurrentRow.Cells["exp"].Value.ToString()) == "False")
            {
                combo_exp.Visible = false;
                btn_add_exp.Visible = false;
                lbl_exp.Visible = false;
                dt_exp.Visible = false;
                lbl_knowexp.Visible = false;
                btn_del_exp.Visible = false;
                combo_expcost.Visible = false;

            }
            dgv_satue_cost_bal_vcs_dis_min_max();

        }
        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (edit == true)
            {
                dgv.CurrentRow.Cells["add_items1"].Value = 2;

                //  if (dgv.CurrentRow.Cells["add_items"].Value.ToString() != "1" && edit== true)
                //{
                //    dgv_edit.Rows.Add(1, dgv.CurrentRow.Cells["code_items"].Value.ToString(), dgv.CurrentRow.Cells["name_items"].Value.ToString(), dgv.CurrentRow.Cells["name_unite"].Value.ToString(), dgv.CurrentRow.Cells["f_unite"].Value.ToString(), dgv.CurrentRow.Cells["exp"].Value.ToString(), dgv.CurrentRow.Cells["type"].Value.ToString(), (dgv.CurrentRow.Cells["exp_date_1"].Value).ToString(), (dgv.CurrentRow.Cells["exp_date"].Value).ToString(), (dgv.CurrentRow.Cells["qty"].Value).ToString(), (dgv.CurrentRow.Cells["item_price"].Value).ToString(), (dgv.CurrentRow.Cells["tot_bef"].Value).ToString(), (dgv.CurrentRow.Cells["discount"].Value).ToString(), (dgv.CurrentRow.Cells["tot_after_dis"].Value).ToString(), (dgv.CurrentRow.Cells["taxes"].Value).ToString(), (dgv.CurrentRow.Cells["incloud_taxes"].Value).ToString(), (dgv.CurrentRow.Cells["taxes_value"].Value).ToString(), (dgv.CurrentRow.Cells["id_ware"].Value).ToString(), (dgv.CurrentRow.Cells["item_qty1"].Value).ToString(), (dgv.CurrentRow.Cells["sale_dt_id"].Value).ToString(),(dgv.CurrentRow.Cells["tot_after_dis1"].Value).ToString(), txt_serial.Text, txt_code_book.Text);
                //    if (dgv.CurrentRow.Cells["exp"].Value.ToString() == "True") load_combo_cost_exp_editmode();
                //}
            }
            calc_current_user();
            dgv_satue_cost_bal_vcs_dis_min_max();
        }
        private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = true;
        }
        private void Column1_KeyPress(object sender, KeyPressEventArgs e)//dgv prevent edit only number
        {
            if (!char.IsControl(e.KeyChar)
                    && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ////cloes edit on discount and qty price
            e.Control.KeyPress -= new KeyPressEventHandler(Column1_KeyPress);

            if (dgv.CurrentCell.ColumnIndex == 9) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
            if (dgv.CurrentCell.ColumnIndex == 10) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
            if (dgv.CurrentCell.ColumnIndex == 12) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }
        }
        //==============================simple controls
        private void combo_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txt_name_book_type.Text = db.GetData("select bookname_entry  from term  where term_id ='" + combo_type.Text + "'").Rows[0][0].ToString();
            //txt_code_entry_type.Text = db.GetData("select code_entry  from term  where term_id ='" + combo_type.Text + "'").Rows[0][0].ToString();
            //cls_book.selectbook("[entry]", "سند قيد", txt_code_entry_type.Text, txt_code_entry, "code_entry");

            string code_entry_term = (db.GetData("select code_entry from term where term_id='" + combo_type.Text + "' ").Rows[0][0].ToString());
            cls_book.Generat_numBooknum("entry", code_entry_term, ref numBook_entry, ref error, ref num_entry);
            txt_entry_string.Text = numBook_entry;

        }
        private void combo_add_items_SelectedIndexChanged(object sender, EventArgs e)
        {
            // add_items_in_property_comboadd_items(); 
            if (!(combo_add_items.Text != ""))
                return;
            try
            {
                if (chk_search_lang.Checked)
                    add_items_in_property_comboadd_items("name_items", combo_add_items.Text);
                else
                    add_items_in_property_comboadd_items("name_items2", combo_add_items.Text);
            }
            catch (Exception ex)
            {
                db.log_error(string.Concat(ex));
            }
        }
        private void save_barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            perform_save();
        }
        private void New_barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("هل تريد عمل سند جديد!!؟؟؟؟ ", "رسال جديد مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                new_file();
            }
        }
        private void add_unite_Click(object sender, EventArgs e)// add unite into dgv 
        {
            add_unite_();
            dgv.CurrentRow.Cells["qty"].Value = 0;
            dgv.CurrentRow.Cells["item_price"].Value = Convert.ToDouble(lbl_f_unite.Text) * Convert.ToDouble(price_items_a);
        }
        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)// to get unite from dgv to combo
        {
            all_comb.load_unite(combo_unit, dgv.CurrentRow.Cells["code_items"].Value.ToString());
            lbl_f_unite.Text = (db.GetData("select (unite) from unite where name_unite='" + combo_unit.Text + "'").Rows[0][0].ToString());
            all_comb.load_exp_date(combo_exp, dgv.CurrentRow.Cells["code_items"].Value.ToString(), dgv.CurrentRow.Cells["id_ware"].Value.ToString());
        }
        private void combo_unit_SelectedIndexChanged(object sender, EventArgs e) //select unite
        {
            lbl_f_unite.Text = (db.GetData("select (unite) from unite where name_unite='" + combo_unit.Text + "'").Rows[0][0].ToString());

        }
        private void btn_add_exp_Click(object sender, EventArgs e)//add exp_Date in dgv 
        {
            if (!Convert.ToBoolean(db.GetData("select [exp] from items where code_items='" + dgv.CurrentRow.Cells["code_items"].Value + "'").Rows[0][0].ToString()))
                return;
            dgv.CurrentRow.Cells["exp_date"].Value = dt_exp.Text;
            dgv.CurrentRow.Cells["add_items1"].Value = 2;



        }
        private void btn_del_exp_Click(object sender, EventArgs e)//clear exp_date from dgv
        {
            dgv.CurrentRow.Cells["exp_date"].Value = "";

        }
        private void combo_exp_SelectedIndexChanged(object sender, EventArgs e)//to know expir date 
        {
            if (dgv.Rows.Count == 0)
                return;
            //all_comb.load_exp_date(dt_exp.ToString(), dgv.CurrentRow.Cells["code_items"].Value.ToString(), combo_wars.Text);
            all_comb.load_exp_date(combo_expcost, dgv.CurrentRow.Cells["code_items"].Value.ToString(), combo_wars.Text);

        }
        private void btn_add_ware_Click(object sender, EventArgs e)//add ware in dt
        {
            if (edit == false)
            {
                dgv.CurrentRow.Cells["id_ware"].Value = combo_wars.Text;
            }
        }
        private void btn_cost_exp_Click(object sender, EventArgs e)//add cost of exp in edit mode
        {
            try
            {
                dgv.CurrentRow.Cells["cost_exp"].Value = combo_expcost.Text;

            }
            catch (Exception)
            {


            }
        }
        private void comob_vsc_codetree_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combo_vcs.Text = db.GetData("select  vcs_name from vcs where vcs_code='" + combo_vsc_codetree.Text + "'").Rows[0][0].ToString();
            }
            catch (Exception)
            {
            }
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
        private void btn_delete_file_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dr;
            dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "هل تريد حذف السند!!؟؟؟؟ ", "رسال حذف مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);


            if (dr == DialogResult.OK)
            {
                delete();
            }

        }
        private void lbl_discount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        //==============================Hotkeys controls 
        private void frm_rsale_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Control)
            {
                perform_save();
            }
            if (e.KeyCode == Keys.N && Control.ModifierKeys == Keys.Control)
            {
                DialogResult dr;
                dr = MessageBox.Show("هل تريد سند جديد!!؟؟؟؟ ", "رسال جديد مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.OK)
                {
                    new_file();
                }
            }
            if (e.KeyCode == Keys.Delete && Control.ModifierKeys == Keys.Control)
            {
                DialogResult dr;
                dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "هل تريد الحذف!!؟؟؟؟ ", "رسال حذف مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (dr == DialogResult.OK)
                {
                    delete();
                }
            }
        }
        private void combo_add_items_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                add_items_in_dgv();
            }
        }
        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                delete_row();
            }
            if (e.KeyCode == Keys.Delete && Control.ModifierKeys == Keys.Control)
            {
                delete();
            }
        }
        private void combo_unit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                add_unite_();
            }
        }
        private void txt_barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return)
                return;
            code_items_a = "";
            string text = txt_barcode.Text;
            string str = Regex.Replace(text, "[+]+", "").Remove(Regex.Replace(text, "[+]+", "").Length - 1, 1);
            code_items_a = db.GetData("select isnull(max(code_items),null) from items where code_items='" + str + "'").Rows[0][0].ToString();
            if (code_items_a == "")
                code_items_a = db.GetData("select isnull(max(code_items),null) from barcode where barcode='" + str + "'").Rows[0][0].ToString();
            if (code_items_a == "")
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "لايوجد صنف  ..يجب تكويد الصنف", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                txt_barcode.Clear();
            }
            else
            {
                name_items_a = !chk_search_lang.Checked ? db.GetData("select isnull(max(name_items2),0) from items where code_items='" + code_items_a + "'").Rows[0][0].ToString() : db.GetData("select isnull(max(name_items),0) from items where code_items='" + code_items_a + "'").Rows[0][0].ToString();
                name_unite_a = db.GetData("select isnull(max(name_unite),0) from items where code_items='" + code_items_a + "'").Rows[0][0].ToString();
                unit1 = db.GetData("select isnull(max(unit1),0) from items where code_items='" + code_items_a + "'").Rows[0][0].ToString();
                price_items_a = db.GetData("select isnull(max(price_sale),0) from items where code_items='" + code_items_a + "'").Rows[0][0].ToString();
                discount_a = db.GetData("select isnull(max(discount_sale),0) from items where code_items='" + code_items_a + "'").Rows[0][0].ToString();
                taxes_a = db.GetData("select isnull(max(taxes),0) from items where code_items='" + code_items_a + "'").Rows[0][0].ToString();
                type_a = db.GetData("select isnull(max([type]),0) from items where code_items='" + code_items_a + "'").Rows[0][0].ToString();
                try
                {
                    exp_a = db.GetData("select [exp] from items where code_items='" + code_items_a + "'").Rows[0][0].ToString();
                }
                catch (Exception ex)
                {
                    db.log_error(string.Concat(ex));
                }
                add_items_in_dgv();
                txt_barcode.Clear();
                ((Control)txt_barcode).Select();
            }
        }
        //===========================================================NAvigation
        private void First_barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!(db.GetData("select min(convert(int,(right(rsale_hd_id,LEN(rsale_hd_id)-3)))) from rsale_hd where  code_book='" + txt_code_book.Text + "' ").Rows[0][0].ToString() != ""))
                    return;
                txt_serial_string.Text = db.GetData("select min(convert(int,(right(rsale_hd_id,LEN(rsale_hd_id)-3)))) from rsale_hd where  code_book='" + txt_code_book.Text + "' ").Rows[0][0].ToString();
                bode_of_navigation(txt_code_book.Text + txt_serial_string.Text, txt_code_book.Text);
            }
            catch (Exception ex)
            {
                db.log_error(string.Concat(ex));
            }
        }
        private void Last_barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!(db.GetData("select max(convert(int,(right(rsale_hd_id,LEN(rsale_hd_id)-3)))) from rsale_hd where  code_book='" + txt_code_book.Text + "'").Rows[0][0].ToString() != ""))
                    return;
                txt_serial_string.Text = db.GetData("select max((convert(int,(right(rsale_hd_id,LEN(rsale_hd_id)-3))))) from rsale_hd where  code_book='" + txt_code_book.Text + "'").Rows[0][0].ToString();
                bode_of_navigation(txt_code_book.Text + txt_serial_string.Text, txt_code_book.Text);
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
                db.log_error(string.Concat(ex));
            }
        }
        private void Back_barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!(db.GetData("select min(convert(int,(right(rsale_hd_id,LEN(rsale_hd_id)-3)))) from rsale_hd  where code_book='" + txt_code_book.Text + "'").Rows[0][0].ToString() != ""))
                    return;
                edit = true;
                new DataTable().Rows.Clear();
                string s1 = db.GetData("select min(convert(int,(right(rsale_hd_id,LEN(rsale_hd_id)-3)))) from rsale_hd  where code_book='" + txt_code_book.Text + "'").Rows[0][0].ToString();
                int.Parse(s1);
                string s2 = txt_serial_string.Text.Remove(0, 1).Remove(0, 2);
                if (int.Parse(s1) >= Convert.ToInt32(s2))
                {
                    int num = (int)MessageBox.Show("اخر ملف");
                }
                else
                {
                    txt_serial_string.Text = txt_code_book.Text + (int.Parse(s2) - 1);
                    bode_of_navigation(txt_serial_string.Text, txt_code_book.Text);
                }
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
                db.log_error(string.Concat(ex));
            }
        }
        private void Next_barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!(db.GetData("select max(convert(int,(right(rsale_hd_id,LEN(rsale_hd_id)-3)))) from rsale_hd  where code_book='" + txt_code_book.Text + "'").Rows[0][0].ToString() != ""))
                    return;
                edit = true;
                new DataTable().Rows.Clear();
                string s1 = db.GetData("select max(convert(int,(right(rsale_hd_id,LEN(rsale_hd_id)-3)))) from rsale_hd  where code_book='" + txt_code_book.Text + "'").Rows[0][0].ToString();
                int.Parse(s1);
                string s2 = txt_serial_string.Text.Remove(0, 1).Remove(0, 2);
                if (int.Parse(s1) <= Convert.ToInt32(s2))
                {
                    int num = (int)MessageBox.Show("اول م ملف");
                }
                else
                {
                    txt_serial_string.Text = txt_code_book.Text + (int.Parse(s2) + 1);
                    bode_of_navigation(txt_serial_string.Text, txt_code_book.Text);
                }
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
                db.log_error(string.Concat(ex));
            }
        }
        //==========================================================END=NAvigation
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Maximum = prog;
            progressBar1.Value = e.ProgressPercentage;
        }
        private void btn_find_items_Click(object sender, EventArgs e)
        {
            all_comb.load_items_for_sale(combo_add_items);
        }
        private void combo_attach_Click(object sender, EventArgs e)
        {
            all_comb.load_invoice_number_sale_r(combo_attach);
        }
        private void combo_attach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return)
                return;
            string book = db.GetData("select isnull(max(code_book),0) from  sale_hd where sale_hd_id='" + combo_attach.Text + "' ").Rows[0][0].ToString();
            string no_inv = db.GetData("select isnull(max(sale_hd_id),0) from  sale_hd where sale_hd_id='" + combo_attach.Text + "' ").Rows[0][0].ToString();

            if (no_inv == "0")
            {
                MessageBox.Show("سند الفاتورة غير موجود");
                return;
            }
            bode_of_navigation_get_invoice(no_inv, book);
            lbl_combo_attach.Text = no_inv ?? "";
        }
        private void btn_search_pur_invoice_Click(object sender, EventArgs e)
        {
            all_comb.load_invoice_number_sale_r(combo_attach);
        }
        private void txt_serial_string_Leave(object sender, EventArgs e)
        {
            bode_of_navigation(txt_serial_string.Text, txt_code_book.Text);
        }

        private void lbl_discount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                calc_all();
            }
            catch (Exception)
            {

            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("select acc_num,acc_name,depit,credit,attachnamebook,attachtext from entry where attachno='" + txt_serial_string.Text + "'or attachno2='" + txt_serial_string.Text + "'", dt);
            dgv_entry.DataSource = dt;
        }

     

        private void combo_currance_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_f_currance.Text = db.GetData("select  isnull(max(f_currance),0) from  currance where currance='" + combo_currance.Text + "'").Rows[0][0].ToString();
        }

        

        private void btn_currance_Click(object sender, EventArgs e)
        {
            dgv.CurrentRow.Cells["currance_c"].Value = combo_currance.Text;
            txt_f_currance.Text = db.GetData("select  isnull(max(f_currance),0) from  currance where currance='" + combo_currance.Text + "'").Rows[0][0].ToString();
            dgv.CurrentRow.Cells["f_currance"].Value = txt_f_currance.Text;
        }
        private void combo_vcs_Click(object sender, EventArgs e)
        {
            if (!Switch_vcs.BindableChecked)
                all_comb.load_vcs_customer(combo_vcs);
            else
                all_comb.load_vcs(combo_vcs);

        }
        private void combo_vsc_codetree_Click(object sender, EventArgs e)
        {
            all_comb.load_code_vcs(combo_vsc_codetree);

        }
        private void printer_previeew_barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraReport xtraReport = XtraReport.FromFile("forms\\sale.repx", true);
            xtraReport.Parameters["parameter1"].Value = txt_serial_string.Text;
            xtraReport.Parameters["parameter1"].Visible = false;
            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
        }
        private void printer_direct_barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraReport xtraReport = XtraReport.FromFile("forms\\sale.repx", true);
            xtraReport.Parameters["parameter1"].Value = txt_serial_string.Text;
            xtraReport.Parameters["parameter1"].Visible = false;
            xtraReport.PrinterName = Settings.Default.printer_a4;
            xtraReport.PrintAsync();

        }
        private void btn_clint_add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_customer f = new frm_customer();
            f.Show();
        }
        private void Btn_barcode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (edit)
            {
                btn_barcode.Enabled = true;
                pos.frm_barcode f = new pos.frm_barcode();
                f.Show();
            }
            else
                btn_barcode.Enabled = false;
        }
        private void Chk_search_lang_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_bal_ware.Checked)
            {
                Settings.Default.chk_bal_ware = true;
                Settings.Default.Save();
            }
            else
            {
                Settings.Default.chk_bal_ware = false;
                Settings.Default.Save();
            }
        }
        private void Chk_bal_ware_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_search_lang.Checked)
            {
                Settings.Default.chk_search_lang = true;
                Settings.Default.Save();
            }
            else
            {
                Settings.Default.chk_search_lang = false;
                Settings.Default.Save();
            }
        }
        private void Combo_wars_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_name_wares.Text = db.GetData("select isnull(max([ware_name]),0) from wares_acc where id_ware='" + combo_wars.Text + "'").Rows[0][0].ToString();

        }
        private void btn_add_items_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_item f = new frm_item();
            f.Show();
        }
        private void txt_serial_string_DoubleClick(object sender, EventArgs e)
        {
            v.search_screen = "rsale";
            frm_search f = new frm_search();
            f.ShowDialog();
            timer1.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (v.search_screen_code != "")
            {
                txt_serial_string.Text = v.search_screen_code;
                txt_serial_string.Select();
                txt_note.Select();
                timer1.Enabled = false;

            }
        }
        }
}