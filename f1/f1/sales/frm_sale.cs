using DevExpress.XtraEditors;
using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;
using f1.Classes;
using f1.Properties;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace f1
{
    public partial class frm_sale : DevExpress.XtraEditors.XtraForm
    {
        public frm_sale()
        {
            InitializeComponent();
            db.Open();
            this.edit = false;
            this.add_permission = true;
            this.edit_permission = true;
            this.contral_sale_price = false;
            this.controal_sale_discount = false;
            this.controal_all_discount = false;
            this.prog = 0;

            //  this.api_e_invoice = "";
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
        }
        bool edit = false;
        //give permission to edite invoice 
        bool add_permission = true;
        bool edit_permission = true;
        bool contral_sale_price = false;
        bool controal_sale_discount = false;
        bool controal_all_discount = false;
        string numBook_entry = "";
        string numBook_sale = "";
        string error = "";
        private int num = 0;
        private int num_entry = 0;
        private void frm_sale_Load(object sender, EventArgs e)
        {
            db.Open();
            this.chk_search_lang.Checked = Settings.Default.chk_search_lang;
            this.chk_bal_ware.Checked = Settings.Default.chk_bal_ware;
            all_comb.load_wares(this.combo_wars);
            this.combo_vcs.Text = (string)null;
            this.combo_vsc_codetree.Text = (string)null;
            //this.dt_piker.MinDate = new DateTime(v.current_yaer, 1, 1);
            //this.dt_piker.MaxDate = new DateTime(v.current_yaer, 12, 31);
            cls_book.loadbook(this.comb_code_name, "سند فاتوره مبيعات");
            cls_book.load_from_term(this.combo_type, "سند فاتوره مبيعات");
            //this.dt_piker.Text = DateTime.Now.ToString(v.current_yaer + "/MM/dd");
            //this.dt_due_date.Text = DateTime.Now.ToString(v.current_yaer + "/MM/dd");
            //this.dt_f.Text = DateTime.Now.ToString(v.current_yaer +"/MM/dd");

            this.dt_piker.Text = DateTime.Now.ToString("yyyy/MM/dd");
            this.dt_due_date.Text = DateTime.Now.ToString("yyyy/MM/dd");
            this.dt_due_date.Text = DateTime.Now.ToString("yyyy/MM/dd");

            this.dgv_term.Rows.Clear();
            this.lbl_tot_befor.Text = "0";
            this.lbl_discount.Text = "0";
            this.lbl_tot_after_dis.Text = "0";
            this.lbl_incloud_taxes.Text = "0";
            this.lbl_serial_P.Text = "0";
            this.progressBar1.Visible = false;
            all_comb.load_curracne(this.combo_currance);
            this.dt_exp.Visible = false;
            this.btn_add_exp.Visible = false;
            this.lbl_exp.Visible = false;
            this.dt_exp.Visible = false;
            this.btn_del_exp.Visible = false;
            this.dgv_readonly();
            this.load_permission();
            // this.load_permission_price_discount_discount_all();
            this.lbl_user_code.Text = v.usercode;
            this.lbl_user_name.Text = v.username;
            if (!v.expiry)
            {
                this.dgv.Columns["exp_date"].Visible = false;
                this.btn_add_exp.Visible = false;
                this.lbl_exp.Visible = false;
                this.dt_exp.Visible = false;
                this.lbl_exp_txt.Visible = false;
                this.combo_expcost.Visible = false;
                this.btn_cost_exp.Visible = false;
                this.combo_expcost.Visible = false;
            }
            else
            {
                this.dgv.Columns["exp_date"].Visible = true;
                this.lbl_exp_txt.Visible = true;
                this.btn_add_exp.Visible = true;
                this.lbl_exp.Visible = true;
                this.dt_exp.Visible = true;
                this.lbl_exp_txt.Visible = true;
                this.combo_expcost.Visible = true;
                this.btn_cost_exp.Visible = true;
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
            if (!v.chk_e_invoice)
            {
                //this.xtraTabPage8.PageVisible = false;
                //this.txt_uuid.Visible = false;
            }
            this.printer_direct_barButtonItem11.Enabled = false;
            this.printer_previeew_barButtonItem10.Enabled = false;
            this.btn_barcode.Enabled = false;
            //   this.btn_chek_inv_tax.Enabled = false;
            this.btn_premiums.Enabled = false;


        }
        //==============================================fanction
        int prog = 0;
        private void save()
        {
            calc_all();
            //0)cheak qty and exp 
            //_______________________
            string qty_old = "0";
            string qty_old_exp = "0";
            string qty_current = "0";
            string qty_new = "0";
            for (int i = 0; i < dgv.Rows.Count; i++) //loop NO.1
            {
                qty_old = db.GetData("select isnull((sum(qty)),0) from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'").Rows[0][0].ToString();
                qty_current = ((Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value)) * (Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value))).ToString();
                qty_new = (Convert.ToDecimal(qty_old) - (Convert.ToDecimal(qty_current))).ToString();
                if (Convert.ToDecimal(qty_new) < 0 && dgv.Rows[i].Cells["type"].Value.ToString() != "2")
                {
                    MessageBox.Show("لايمكن للرصيد يكون بالسالب  " + " كود الصنف : " + dgv.Rows[i].Cells["code_items"].Value);
                    return;
                }

                else
                {
                    if (dgv.Rows[i].Cells["exp"].Value.ToString() == "True")
                    {
                        qty_old_exp = db.GetData("select isnull((sum(qty)),0) from exp_date where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "' and exp_date='" + Convert.ToDateTime(dgv.Rows[i].Cells["exp_date"].Value).ToString("MM-dd-yyyy") + "'").Rows[0][0].ToString(); if (qty_old_exp == "") qty_old_exp = "0";
                        //   MessageBox.Show(qty_old_exp + "  " + dgv.Rows[i].Cells["code_items"].Value);
                        if (Convert.ToDecimal(qty_old_exp) < Convert.ToDecimal(qty_current))
                        {
                            MessageBox.Show("مفيش رصيد من تاريخ الصالحيه ...شوف تاريخ صلاحيه تاني ");
                            return;
                        }
                    }
                }
                //   string permission_blowcost_discount = db.GetData("select blow_cost_discount from permission_price_discount where user_code='"+v.usercode+"' ").Rows[0][0].ToString();
                //  string permission_blowcost_price = db.GetData("select blow_cost_price from permission_price_discount where user_code='" + v.usercode + "' ").Rows[0][0].ToString();
                //     if (Convert.ToBoolean(permission_blowcost_discount) == false || Convert.ToBoolean(permission_blowcost_price) == false)
                //   {
                //privant sale blow cost 
                // double cost = Convert.ToDouble(db.GetData("select isnull(sum(cost),0) from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value.ToString() + "' and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value.ToString() + "'").Rows[0][0].ToString());
                // double real_price_after_discoint = Convert.ToDouble(dgv.Rows[i].Cells["tot_after_dis"].Value.ToString()) / Convert.ToDouble(dgv.Rows[i].Cells["qty"].Value.ToString());
                //       if (real_price_after_discoint <= cost)
                //     {
                //         XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "لايمكن البيع تحت سعر التكلفه ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //       return;
                //   }
                //    }
            }
            //get tot cost (COGS)
            cogs();
            //1)select type of entry and insert entry :=
            //_______________________________________________
           // select_type_entry();


            //select_type_entry();
            //    select_type_entry();
            string error = "";
            DataTable dt_term = new DataTable();
            cls_book.Make_entry_type_purchase(ref dt_term            , ref error, "سند فاتوره مبيعات", combo_type.Text, combo_wars.Text, combo_vsc_codetree.Text, lbl_tot_befor.Text, lbl_tot_after_dis.Text, lbl_discount.Text, lbl_incloud_taxes.Text, lbl_vat_Add.Text, lbl_taxes_values.Text, lbl_tot_cost.Text);
            //                                (ref DataTable dt_term, ref string error, string cat, string term_id, string id_wares, string id_vcs,                 string tot_befor,    string tot_after_dis, string discount,   string incloud_taxes   , string vat_add, string taxes_values, string cogs = "")

            //get only number for one user Entry
            //txt_entry_string.Text = txt_code_entry_type.Text + txt_code_entry.Text;
            //cls_book.selectbook("entry_hd", "سند قيد", txt_code_entry_type.Text, txt_code_entry, "code_entry");


            //txt_entry_string.Text = txt_code_entry_type.Text + txt_code_entry.Text;

            string code_entry_term = (db.GetData("select code_entry from term where term_id='" + combo_type.Text + "' ").Rows[0][0].ToString());
            cls_book.Generat_numBooknum("entry", code_entry_term, ref numBook_entry, ref error, ref num_entry);
            txt_entry_string.Text = numBook_entry;


            //get only number for one user purchase
            txt_code_book.Text = db.GetData("select code_book from book where name_book='" + comb_code_name.Text + "'").Rows[0][0].ToString();
            //cls_book.selectbook("sale_hd", "سند فاتوره مبيعات", txt_code_book.Text, txt_serial, "sale_hd_id");
         //   txt_serial_string.Text = txt_code_book.Text + txt_serial.Text;

            cls_book.Generat_numBooknum("sale_hd", txt_code_book.Text, ref numBook_sale, ref error, ref num);
            txt_serial_string.Text = numBook_sale;


            //link between pay_dt and purchase_hd
            try
            {
                if (db.GetData("select lock from purchase_hd = '" + txt_serial_string.Text + "'").Rows[0][0].ToString() == "t")
                {
                    save_barButtonItem1.Enabled = false;
                    btn_delete_file.Enabled = false;
                    return;
                }
            }
            catch (Exception) { }

            db.Run("insert into entry_hd ([code_entry],code_book) values ('" + txt_entry_string.Text + "','" + txt_code_entry_type.Text + "')");

            //for (int z = 0; z < dgv_term.Rows.Count; z++)
            //{
            //    db.Run("insert into entry(  [code_entry]                           ,    acc_num                                                   ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                                          ,   type_acc                                                            , sort                                                       ,             depit                                                             ,                credit                                                   ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext, costcenter_code,num_book)values('" +
            //                         txt_entry_string.Text + "'            ,'" + dgv_term.Rows[z].Cells[1].Value.ToString() + "'     ,'" + dgv_term.Rows[z].Cells[2].Value.ToString() + "'               ,  '" + dgv_term.Rows[z].Cells["rootlevel_"].Value.ToString() + "'    ,  '" + dgv_term.Rows[z].Cells["rootlevel_name_"].Value.ToString() + "', '" + dgv_term.Rows[z].Cells["type_acc_"].Value.ToString() + "'       ,  '" + dgv_term.Rows[z].Cells["sort_"].Value.ToString() + "'  ,  '" + Convert.ToDecimal(dgv_term.Rows[z].Cells[3].Value.ToString()) * Convert.ToDecimal(txt_f_currance.Text) + "'      ,'" + Convert.ToDecimal(dgv_term.Rows[z].Cells[4].Value.ToString()) * Convert.ToDecimal(txt_f_currance.Text) + "' ,'" + txt_name_book_type.Text + "','" + txt_code_entry_type.Text + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + txt_serial_string.Text + "','" + txt_code_book.Text + "','" + comb_code_name.Text + "','" + txt_note.Text + "','"+ dgv_term.Rows[z].Cells["costcenter_term"].Value.ToString() + "','"+num_entry+"')");
            for (int z = 0; z < dt_term.Rows.Count; z++)

            {
                db.Run("insert into entry(  [code_entry]                           ,    acc_num                                                   ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                                          ,   type_acc                                                            , sort                                                       ,             depit                                                             ,                credit                                                                          ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext ,num_book)values('" +
                                    txt_entry_string.Text + "'            ,'" + dt_term.Rows[z][1] + "'     ,'" + dt_term.Rows[z][2] + "'               ,  '" + dt_term.Rows[z][5] + "'    ,                               '" + dt_term.Rows[z][6] + "',                                                         '" + dt_term.Rows[z][8] + "'       ,                        '" + dt_term.Rows[z][7] + "'  ,                               '" + Convert.ToDecimal(dt_term.Rows[z][3]) * Convert.ToDecimal(txt_f_currance.Text) + "'      ,'" + Convert.ToDecimal(dt_term.Rows[z][4]) * Convert.ToDecimal(txt_f_currance.Text) + "' ,'" + txt_name_book_type.Text + "','" + txt_code_entry_type.Text + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + txt_serial_string.Text + "','" + txt_code_book.Text + "','" + comb_code_name.Text + "','" + txt_note.Text + "','" + num_entry + "')");
            }
            //}
            // 2) save header:-
            //________________________

            db.Run("insert into sale_hd(sale_hd_id ,            code_book               ,name_book                       ,   vcs_code,                       vcs_name           ,           date_P                               ,         term           ,         tot_befor                    ,    discount              , tot_after_dis                          ,           taxes            ,incloud_taxes               ,    id_ware                    ,code_entry              ,book_name_entry                  ,code_book_entry                       ,note_txt                ,user_name               ,user_code,lock,currance,f_currance,due_date,vcs_value,num_book,vat_add)values('"
                                           + txt_serial_string.Text + "', '" + txt_code_book.Text + "' ,'" + comb_code_name.Text + "','" + combo_vsc_codetree.Text + "','" + combo_vcs.Text + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + combo_type.Text + "',    '" + lbl_tot_befor.Text + "'    ,'" + lbl_discount.Text + "' ,      '" + lbl_tot_after_dis.Text + "' ,  '" + lbl_taxes_values.Text + "' ,'" + lbl_incloud_taxes.Text + "','" + combo_wars.Text + "','" + txt_code_entry.Text + "','" + txt_name_book_type.Text + "','" + txt_code_entry_type.Text + "','" + txt_note.Text + "','" + lbl_user_name.Text + "','" + lbl_user_code.Text + "','0','" + combo_currance.Text + "','" + txt_f_currance.Text + "','" + dt_due_date.Value.ToString("MM-dd-yyyy") + "','0','"+num+"','"+lbl_vat_Add.Text+"')");

            //loop detals:=
            prog = dgv.Rows.Count;//to know progras bar 

            for (int i = 0; i < dgv.Rows.Count; i++)//loop NO.3
            {
                //3)save detals:=
                //___________________
                //A)items is not expiry
                if (dgv.Rows[i].Cells["exp"].Value.ToString() == "False")
                {
                    db.Run("insert into sale_dt(sale_hd_id ,         code_book ,                       name_book         ,                       code_items              ,                        name_items             ,                                         qty             ,                                      item_price                  ,                                         tot_bef             ,                                         discount             ,                                         tot_after_dis             ,                                        taxes              ,                                        incloud_taxes                 ,                                          taxes_value             ,      id_ware         ,                         f_unite,                                   name_unite                                           ,no,                                                           [exp]              ,            exp_date                        ,[type],serial_P,tot_after_dis_forex) values('" +
                                             txt_serial_string.Text + "','" + txt_code_book.Text + "', '" + comb_code_name.Text + "','" + dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["item_price"].Value) + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_bef"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["discount"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["taxes"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["incloud_taxes"].Value) + "','" + Convert.ToDecimal(dgv.Rows[i].Cells["taxes_value"].Value) + "','" + (dgv.Rows[i].Cells["id_ware"].Value) + "','" + (dgv.Rows[i].Cells["f_unite"].Value) + "','" + (dgv.Rows[i].Cells["name_unite"].Value) + "','" + (dgv.Rows[i].Cells["no"].Value) + "','" + Convert.ToBoolean((dgv.Rows[i].Cells["exp"].Value)) + "',            Null              ,'" + (dgv.Rows[i].Cells["type"].Value) + "','" + lbl_serial_P.Text + "','" + Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) * Convert.ToDecimal(txt_f_currance.Text) + "')");
                }
                else
                {
                    //B)items is expiry
                    db.Run("insert into sale_dt(sale_hd_id ,         code_book ,                       name_book         ,                       code_items              ,                        name_items             ,                                         qty             ,                                      item_price                  ,                                         tot_bef             ,                                         discount             ,                                         tot_after_dis             ,                                        taxes              ,                                        incloud_taxes                 ,                                          taxes_value             ,      id_ware         ,                         f_unite,                                   name_unite                                           ,no,                                                           [exp]              ,            exp_date                        ,[type],serial_P,tot_after_dis_forex) values('" +
                                             txt_serial_string.Text + "','" + txt_code_book.Text + "', '" + comb_code_name.Text + "','" + dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["item_price"].Value) + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_bef"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["discount"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["taxes"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["incloud_taxes"].Value) + "','" + Convert.ToDecimal(dgv.Rows[i].Cells["taxes_value"].Value) + "','" + (dgv.Rows[i].Cells["id_ware"].Value) + "','" + (dgv.Rows[i].Cells["f_unite"].Value) + "','" + (dgv.Rows[i].Cells["name_unite"].Value) + "','" + (dgv.Rows[i].Cells["no"].Value) + "','" + Convert.ToBoolean((dgv.Rows[i].Cells["exp"].Value)) + "','" + Convert.ToDateTime(dgv.Rows[i].Cells["exp_date"].Value).ToString("MM-dd-yyyy") + "','" + (dgv.Rows[i].Cells["type"].Value) + "','" + lbl_serial_P.Text + "','" + Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) * Convert.ToDecimal(txt_f_currance.Text) + "')");
                }
                //update ware 
                //A)update ware qty:-
                //________________________
                if (dgv.Rows[i].Cells["type"].Value.ToString() == "1")
                {
                    decimal qty_ware_additems = Convert.ToDecimal(db.GetData("select qty from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'").Rows[0][0].ToString());
                    decimal qty_bal = Convert.ToDecimal(qty_ware_additems) - (Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value)) * (Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value));
                    db.Run("update wares set qty =(" + Convert.ToDecimal(qty_ware_additems) + " - " + (Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value)) * (Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value)) + ") where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'");
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
                    //c)insert exp_date cost:-
                    //_______________________
                    if (dgv.Rows[i].Cells["exp"].Value.ToString() == "True")
                    {
                        db.Run("insert into exp_date (code_items,name_items,exp_date,qty,cost,id_ware,code,code_book) values('" + dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "','" + Convert.ToDateTime(dgv.Rows[i].Cells["exp_date"].Value).ToString("MM-dd-yyyy") + "','" + (Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value)) * (Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value)) * -1 + "','" + dgv.Rows[i].Cells["tot_after_dis"].Value + "','" + dgv.Rows[i].Cells["id_ware"].Value + "','" + txt_serial_string.Text + "','" + txt_code_book.Text + "')");
                    }
                }
                ////insert into trans_items_trans 
                //if (dgv.Rows[i].Cells["exp"].Value.ToString() == "False")
                //{
                //    db.Run("insert into items_trans (                        code_items,                                name_items,                                                                qty                                                                ,f_unite                                                      ,                        name_unite            ,exp_date                    ,id_ware                            ,attachno                      ,attachbook            ,attachnamebook                    ,vcs_code                           ,vcs_name      ,                 dates       ) values ('" +

                //                                     dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "','" + Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) * Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value)*-1 + "' ,'" + Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value) + "','" + (dgv.Rows[i].Cells["name_unite"].Value) + "',null,'" + (dgv.Rows[i].Cells["id_ware"].Value) + "','" + txt_serial_string.Text + "','" + comb_code_name.Text + "','" + comb_code_name.Text + "','" + combo_vsc_codetree.Text + "','" + combo_vcs.Text + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "')");

                //}
                //else
                //{
                //    //B)items is expiry
                //    db.Run("insert into items_trans (                                             code_items,                                      name_items,                                                                        qty                                                          ,f_unite,                                                        name_unite                                                        ,exp_date                    ,id_ware                 ,attachno                    ,attachbook                    ,attachnamebook                  ,vcs_code                       ,vcs_name                              ,dates) values ('" +
                //                dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "','" + Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) * Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value)*-1 + "' ,'" + Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value) + "','" + (dgv.Rows[i].Cells["name_unite"].Value) + "','" + Convert.ToDateTime(dgv.Rows[i].Cells["exp_date"].Value).ToString("MM-dd-yyyy") + "','" + (dgv.Rows[i].Cells["id_ware"].Value) + "','" + txt_serial_string.Text + "','" + comb_code_name.Text + "','" + comb_code_name.Text + "','" + combo_vsc_codetree.Text + "','" + combo_vcs.Text + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "')");
                //}


                backgroundWorker1.ReportProgress(i);
            }
            bode_of_navigation(txt_serial_string.Text, txt_code_book.Text);
            db.Run("update sale_hd set vcs_value=(select sum(depit)-sum(credit) from entry where acc_num='" + combo_vsc_codetree.Text + "') where sale_hd_id='" + txt_serial_string.Text + "'");
            edit = true;
            XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "saving ", "save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            progressBar1.Visible = false;
        }
        private void edite_1()
        {
            //lop dgv 
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                //if dgv = 0 
                try
                {
                    //not have add items (add items = 1  not add items = 2)
                    //if (dgv.Rows[i].Cells["add_items1"].Value + "" == "2" && dgv.Rows[i].Cells["add_items"].Value + "" != "1")
                    //{
                    //    dgv_edit.Rows.Add(1, dgv.Rows[i].Cells["code_items"].Value.ToString(), dgv.Rows[i].Cells["name_items"].Value.ToString(), dgv.Rows[i].Cells["name_unite"].Value.ToString(), dgv.Rows[i].Cells["f_unite"].Value.ToString(), dgv.Rows[i].Cells["exp"].Value.ToString(), dgv.Rows[i].Cells["type"].Value.ToString(), dgv.Rows[i].Cells["exp_date_1"].Value.ToString(), dgv.Rows[i].Cells["exp_date"].Value.ToString(), dgv.Rows[i].Cells["qty"].Value.ToString(), dgv.Rows[i].Cells["item_price"].Value.ToString(), dgv.Rows[i].Cells["tot_bef"].Value.ToString(), dgv.Rows[i].Cells["discount"].Value.ToString(), dgv.Rows[i].Cells["tot_after_dis"].Value.ToString(), dgv.Rows[i].Cells["taxes"].Value.ToString(), dgv.Rows[i].Cells["incloud_taxes"].Value.ToString(), dgv.Rows[i].Cells["taxes_value"].Value.ToString(), dgv.Rows[i].Cells["id_ware"].Value.ToString(), dgv.Rows[i].Cells["item_qty1"].Value.ToString(), dgv.Rows[i].Cells["rpurchase_dt_id"].Value.ToString(), dgv.Rows[i].Cells["tot_after_dis1"].Value.ToString(), dgv.Rows[i].Cells["f_unite_1"].Value.ToString(), txt_serial_string.Text, txt_code_book.Text);
                    //}
                    //else
                    //{
                    //    //else if dgv = 1
                    //    //have add items (add items =1)
                    //    if (!(dgv.Rows[i].Cells["add_items"].Value.ToString() == "1"))
                    //        return;
                    //    dgv_add_items.Rows.Add(dgv.Rows[i].Cells["code_items"].Value.ToString(), dgv.Rows[i].Cells["name_items"].Value.ToString(), dgv.Rows[i].Cells["name_unite"].Value.ToString(), dgv.Rows[i].Cells["f_unite"].Value.ToString(), dgv.Rows[i].Cells["exp"].Value.ToString(), dgv.Rows[i].Cells["type"].Value.ToString(), dgv.Rows[i].Cells["exp_date"].Value.ToString(), 0, dgv.Rows[i].Cells["qty"].Value.ToString(), dgv.Rows[i].Cells["item_price"].Value.ToString(), dgv.Rows[i].Cells["tot_bef"].Value.ToString(), dgv.Rows[i].Cells["discount"].Value.ToString(), dgv.Rows[i].Cells["tot_after_dis"].Value.ToString(), dgv.Rows[i].Cells["taxes"].Value.ToString(), dgv.Rows[i].Cells["incloud_taxes"].Value.ToString(), dgv.Rows[i].Cells["taxes_value"].Value.ToString(), dgv.Rows[i].Cells["id_ware"].Value.ToString(), dgv.Rows[i].Cells["f_unite_1"].Value.ToString());
                    //}
                    if (dgv.Rows[i].Cells["add_items1"].Value + "" == "2" && dgv.Rows[i].Cells["add_items"].Value + "" != "1")
                    {
                        //edit 
                        //dgv_edit.Rows.Add(1, dgv.Rows[i].Cells["code_items"].Value.ToString(), dgv.Rows[i].Cells["name_items"].Value.ToString(), dgv.Rows[i].Cells["name_unite"].Value.ToString(), dgv.Rows[i].Cells["f_unite"].Value.ToString(), dgv.Rows[i].Cells["exp"].Value.ToString(), dgv.Rows[i].Cells["type"].Value.ToString(), (dgv.Rows[i].Cells["exp_date_1"].Value).ToString(), (dgv.Rows[i].Cells["exp_date"].Value).ToString(), (dgv.Rows[i].Cells["qty"].Value).ToString(), (dgv.Rows[i].Cells["item_price"].Value).ToString(), (dgv.Rows[i].Cells["tot_bef"].Value).ToString(), (dgv.Rows[i].Cells["discount"].Value).ToString(), (dgv.Rows[i].Cells["tot_after_dis"].Value).ToString(), (dgv.Rows[i].Cells["taxes"].Value).ToString(), (dgv.Rows[i].Cells["incloud_taxes"].Value).ToString(), (dgv.Rows[i].Cells["taxes_value"].Value).ToString(), (dgv.Rows[i].Cells["id_ware"].Value).ToString(), (dgv.Rows[i].Cells["item_qty1"].Value).ToString(), (dgv.Rows[i].Cells["purchase_dt_id"].Value).ToString(), (dgv.Rows[i].Cells["tot_after_dis1"].Value).ToString(), (dgv.Rows[i].Cells["f_unite_1"].Value).ToString(), txt_serial_string.Text, txt_code_book.Text);
                        dgv_edit.Rows.Add(1, dgv.Rows[i].Cells["code_items"].Value.ToString(), dgv.Rows[i].Cells["name_items"].Value.ToString(), dgv.Rows[i].Cells["name_unite"].Value.ToString(), dgv.Rows[i].Cells["f_unite"].Value.ToString(), dgv.Rows[i].Cells["exp"].Value.ToString(), dgv.Rows[i].Cells["type"].Value.ToString(), (dgv.Rows[i].Cells["exp_date_1"].Value).ToString(), (dgv.Rows[i].Cells["exp_date"].Value).ToString(), (dgv.Rows[i].Cells["qty"].Value).ToString(), (dgv.Rows[i].Cells["item_price"].Value).ToString(), (dgv.Rows[i].Cells["tot_bef"].Value).ToString(), (dgv.Rows[i].Cells["discount"].Value).ToString(), (dgv.Rows[i].Cells["tot_after_dis"].Value).ToString(), (dgv.Rows[i].Cells["taxes"].Value).ToString(), (dgv.Rows[i].Cells["incloud_taxes"].Value).ToString(), (dgv.Rows[i].Cells["taxes_value"].Value).ToString(), (dgv.Rows[i].Cells["id_ware"].Value).ToString(), (dgv.Rows[i].Cells["item_qty1"].Value).ToString(), (dgv.Rows[i].Cells["sale_dt_id"].Value).ToString(), (dgv.Rows[i].Cells["tot_after_dis1"].Value).ToString(), (dgv.Rows[i].Cells["f_unite_1"].Value).ToString(), txt_serial_string.Text, txt_code_book.Text);

                    }
                    //else if dgv = 1
                    else if (dgv.Rows[i].Cells["add_items1"].Value + "" == "2" && dgv.Rows[i].Cells["add_items"].Value + "" == "1")
                    {
                        dgv_add_items.Rows.Add(dgv.Rows[i].Cells["code_items"].Value.ToString(), dgv.Rows[i].Cells["name_items"].Value.ToString(), dgv.Rows[i].Cells["name_unite"].Value.ToString(), dgv.Rows[i].Cells["f_unite"].Value.ToString(), dgv.Rows[i].Cells["exp"].Value.ToString(), dgv.Rows[i].Cells["type"].Value.ToString(), dgv.Rows[i].Cells["exp_date"].Value.ToString(), 0, dgv.Rows[i].Cells["qty"].Value.ToString(), dgv.Rows[i].Cells["item_price"].Value.ToString(), dgv.Rows[i].Cells["tot_bef"].Value.ToString(), dgv.Rows[i].Cells["discount"].Value.ToString(), dgv.Rows[i].Cells["tot_after_dis"].Value.ToString(), dgv.Rows[i].Cells["taxes"].Value.ToString(), dgv.Rows[i].Cells["incloud_taxes"].Value.ToString(), dgv.Rows[i].Cells["taxes_value"].Value.ToString(), dgv.Rows[i].Cells["id_ware"].Value.ToString(), (dgv.Rows[i].Cells["f_unite_1"].Value).ToString());
                    }

                }
                catch (Exception)
                { }
            }
            //cheak_+__+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            //0)cheak qty and exp 
            //_______________________
            string qty_old = "0";
            string qty_old_exp = "0";
            string qty_current = "0";
            string qty_current1 = "0";
            decimal qty_new = 0;
            string qty_new_new = "0";

            for (int i = 0; i < dgv.Rows.Count; i++) //loop NO.1
            {
                if (dgv.Rows[i].Cells["type"].Value.ToString() != "2")
                {
                    qty_old = db.GetData("select isnull((sum(qty)),0) from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'").Rows[0][0].ToString();
                    qty_current = ((Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value)) * (Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value))).ToString();
                    qty_current1 = ((Convert.ToDecimal(dgv.Rows[i].Cells["item_qty1"].Value)) * (Convert.ToDecimal(dgv.Rows[i].Cells["f_unite_1"].Value))).ToString();
                    qty_new = (Convert.ToDecimal(qty_old)) + (Convert.ToDecimal(qty_current1));
                    qty_new_new = (Convert.ToDecimal(qty_new) - (Convert.ToDecimal(qty_current))).ToString();
                }
                if (Convert.ToDecimal(qty_new_new) < 0 && dgv.Rows[i].Cells["type"].Value.ToString() != "2")
                {
                    //qty_old = qty_current1;
                    //qty_new = (Convert.ToDecimal(qty_old) - (Convert.ToDecimal(qty_current))).ToString();
                    //if (Convert.ToDecimal(qty_new) < 0)
                    {
                        MessageBox.Show("لايمكن للرصيد يكون بالسالب  " + " كود الصنف : " + dgv.Rows[i].Cells["code_items"].Value);
                        return;
                    }
                }

                else
                {
                    if (dgv.Rows[i].Cells["exp"].Value.ToString() == "True")
                    {
                        qty_old_exp = db.GetData("select isnull((sum(qty)),0) from exp_date where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "' and exp_date='" + Convert.ToDateTime(dgv.Rows[i].Cells["exp_date"].Value).ToString("MM-dd-yyyy") + "'").Rows[0][0].ToString(); if (qty_old_exp == "") qty_old_exp = "0";
                        MessageBox.Show(qty_old_exp + "  " + dgv.Rows[i].Cells["code_items"].Value);
                        if (Convert.ToDecimal(qty_old_exp) < Convert.ToDecimal(qty_current))
                        {
                            MessageBox.Show("مفيش رصيد من تاريخ الصالحيه ...شوف تاريخ صلاحيه تاني ");
                            return;
                        }
                    }
                }


            }


            //get tot cost (COGS)
            cogs();

            //_+++++++++++++++++++++++++++++++++++++++++++++++++++++++__
            //________________________^^^^^^^^^^^^^^^^^^^^^^^^^^^%%%%%%$$$$$$$$***((())))________%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
            //1)edite in current dgv edite
            //_______________________________
            if (dgv_edit.Rows.Count > 0)
            {
                //1-c) edite purchas_dt
                detailes_edit_update(dgv_edit, txt_serial_string.Text, txt_code_book.Text, comb_code_name.Text, "code_items_e", "name_items_e", "qty_e", "item_price_e", "tot_bef_e", "discount_e", "tot_after_dis_e", "taxes_e", "incloud_taxes_e", "taxes_value_e", "id_ware_e", "name_unite_e", "f_unite_e", "exp_t_f", "type_e", "dt_e", "exp_date_e");
                //1-A)cheak and wares
                ware_edit_update(dgv_edit, "code_items_e", "id_ware_e", "qty_e", "f_unite_e", "f_unite_1_e", "item_qty1_e", "type_e");
                //1-B) edite exp :-
                exp_insert_and_delete_edite(dgv_edit, "code_items_e", "name_items_e", "id_ware_e", "qty_e", "f_unite_e", "item_qty1_e", "tot_after_dis1_e", "tot_after_dis_e", "exp_date_1_e", "exp_date_e");

            }

            //2)edite addnew items :-
            //________________________________
            if (dgv.Rows.Count > 0)
            {
                // //2-c) add purchas_dt
                detailes_edit_insert(dgv);
                ////2-A)cheak and wares
                ware_edit_update(dgv_add_items, "code_items_ai", "id_ware_ai", "qty_ai", "f_unite_ai", "type_ai");
                // //2-B) add items exp 
                exp_insert_edite();


            }
            //3)edite delete items :-
            //________________________________
            if (dgv_delete.Rows.Count > 0)
            {
                ////3-c) delete purchas_dt
                detailes_edit_delete();
                //3-A)cheak and wares
                ware_del_row();
                ////when click delete row buton cheak qty 
                ////3-B) delete items exp 
                exp_delete_edite();

            }
            //4)edit_hd:-
            //______________________________
            edite_hd();
            //5)edit entry :-
            //______________________________
            string code = db.GetData("select top 1 code_entry from entry where attachno='" + txt_serial_string.Text + "' ").Rows[0][0].ToString();
            db.Run("delete from entry_hd where code_entry='" + code + "' and code_book='" + txt_code_entry_type.Text + "'");
            db.Run("delete from entry where code_entry='" + code + "' and code_book='" + txt_code_entry_type.Text + "'");
            // select_type_entry();
            //get only number for one user Entry
            //txt_entry_string.Text = txt_code_entry_type.Text + txt_code_entry.Text;
            //cls_book.selectbook("entry_hd", "سند قيد", txt_code_entry_type.Text, txt_code_entry, "code_entry");
            //txt_entry_string.Text = txt_code_entry_type.Text + txt_code_entry.Text;
            string error = "";
            DataTable dt_term = new DataTable();
            cls_book.Make_entry_type_purchase(ref dt_term, ref error, "سند فاتوره مبيعات", combo_type.Text, combo_wars.Text, combo_vsc_codetree.Text, lbl_tot_befor.Text, lbl_tot_after_dis.Text, lbl_discount.Text, lbl_discount.Text, lbl_incloud_taxes.Text, lbl_vat_Add.Text);



            string code_entry_term = (db.GetData("select code_entry from term where term_id='" + combo_type.Text + "' ").Rows[0][0].ToString());
            cls_book.Generat_numBooknum("entry", code_entry_term, ref numBook_entry, ref error, ref num_entry);
            txt_entry_string.Text = numBook_entry;


            db.Run("insert into entry_hd ([code_entry],code_book) values ('" + txt_code_entry_type.Text + txt_code_entry.Text + "','" + txt_code_entry_type.Text + "')");
            //for (int z = 0; z < dgv_term.Rows.Count; z++)
            //{
            //  //  db.Run("insert into entry(  [code_entry]                           ,    acc_num                                                   ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                                          ,   type_acc                                                            , sort                                                       ,             depit                                                             ,                credit                                                   ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext ,num_book)values('" +
            //    //   txt_code_entry_type.Text + txt_code_entry.Text + "','" + dgv_term.Rows[z].Cells[1].Value.ToString() + "','" + dgv_term.Rows[z].Cells[2].Value.ToString() + "',  '" + dgv_term.Rows[z].Cells["rootlevel_"].Value.ToString() + "'    ,  '" + dgv_term.Rows[z].Cells["rootlevel_name_"].Value.ToString() + "', '" + dgv_term.Rows[z].Cells["type_acc_"].Value.ToString() + "'       ,  '" + dgv_term.Rows[z].Cells["sort_"].Value.ToString() + "'  ,  '" + Convert.ToDecimal(dgv_term.Rows[z].Cells[3].Value.ToString()) + "'      ,'" + Convert.ToDecimal(dgv_term.Rows[z].Cells[4].Value.ToString()) + "' ,'" + txt_name_book_type.Text + "','" + txt_code_entry_type.Text + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + txt_serial_string.Text + "','" + txt_code_book.Text + "','" + comb_code_name.Text + "','" + txt_note.Text + "','"+num_entry+"')");



            //}
            for (int z = 0; z < dt_term.Rows.Count; z++)

            {
                db.Run("insert into entry(  [code_entry]                           ,    acc_num                                                   ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                                          ,   type_acc                                                            , sort                                                       ,             depit                                                             ,                credit                                                                          ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext ,num_book)values('" +
                                    txt_entry_string.Text + "'            ,'" + dt_term.Rows[z][1] + "'     ,'" + dt_term.Rows[z][2] + "'               ,  '" + dt_term.Rows[z][5] + "'    ,                               '" + dt_term.Rows[z][6] + "',                                                         '" + dt_term.Rows[z][8] + "'       ,                        '" + dt_term.Rows[z][7] + "'  ,                               '" + Convert.ToDecimal(dt_term.Rows[z][3]) * Convert.ToDecimal(txt_f_currance.Text) + "'      ,'" + Convert.ToDecimal(dt_term.Rows[z][4]) * Convert.ToDecimal(txt_f_currance.Text) + "' ,'" + txt_name_book_type.Text + "','" + txt_code_entry_type.Text + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + txt_serial_string.Text + "','" + txt_code_book.Text + "','" + comb_code_name.Text + "','" + txt_note.Text + "','" + num_entry + "')");
            }
            dgv_edit.Rows.Clear();
            dgv_delete.Rows.Clear();
            dgv_add_items.Rows.Clear();
            dgv_term.Rows.Clear();
            XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "edite succssfull ", "EDIT", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void delete()
        {

            if (edit == true)
            {
                if (txt_serial_string.Text == "")
                {
                    XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "ماشي بس هو مفيش حاجه علشان امسحها دخل كود  طيب !!؟؟؟؟ ", "رسال حذف مستند", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    //============>>>
                    Decimal qty_old, qty_current, qty_new;
                    //  Decimal qty_old_exp, qty_current_exp, qty_current1_exp, qty_new_exp;
                    progressBar1.Visible = true;
                    prog = dgv.Rows.Count;//to know progras bar 
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {

                        if (dgv.Rows[i].Cells["type"].Value.ToString() != "2")
                        {
                            qty_old = Convert.ToDecimal(db.GetData("select qty from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'").Rows[0][0]);
                            qty_current = (Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value)) * (Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value));
                            qty_new = qty_old + qty_current;
                            if (qty_new < 0)
                            {
                                MessageBox.Show("لا يمكن الرصيد يكون بالسالب " + "  Codeitems=" + dgv.Rows[i].Cells["code_items"].Value + "");
                                return;
                            }

                            db.Run("update wares set qty =" + qty_new + " where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'");
                            //B) update cost:= total / QTY  and update cost for ware
                            //_______________________________________________
                            //Decimal totalcost = 0;
                            //Decimal totalqty = 0;
                            //String totalcoststring = "";
                            //string cost = "0";
                            //totalqty = Convert.ToDecimal(db.GetData("select sum(qty * f_unite) from purchase_dt where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'").Rows[0][0].ToString());
                            //if (totalqty == 0) totalqty = 1;
                            //totalcoststring = (Convert.ToString(db.GetData("select sum(tot_after_dis) from purchase_dt where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'").Rows[0][0]));
                            //if (totalcoststring == "") totalcoststring = (Convert.ToString(dgv.Rows[i].Cells["tot_after_dis"].Value));
                            ////MessageBoi.Show(totalcoststring);
                            //totalcost = Convert.ToDecimal(totalcoststring);
                            //cost = (totalcost / totalqty) + "";
                            //  db.Run("update wares set cost =" + (cost) + " where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'");

                            //delete exp_Date
                            if (dgv.Rows[i].Cells["exp"].Value.ToString() == "True")
                            {
                                //delete from wares update:-
                                db.Run("delete from exp_date where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "' and code='" + txt_serial_string.Text + "' and code_book='" + txt_code_book.Text + "'");
                            }

                        }

                        backgroundWorker1.ReportProgress(i);
                    }
                    progressBar1.Visible = false;

                    //delte entry
                    string code = db.GetData("select top 1 code_entry from entry where attachno='" + txt_serial_string.Text + "' ").Rows[0][0].ToString();
                    db.Run("delete from entry_hd where code_entry='" + code + "' ");
                    db.Run("delete from entry where code_entry='" + code + "' ");
                    //--------->>>

                    db.Run("delete from sale_hd where sale_hd_id='" + txt_serial_string.Text + "'");
                    db.Run("delete from sale_dt where sale_hd_id='" + txt_serial_string.Text + "' and code_book='" + txt_code_book.Text + "'");

                    //delete item_tran
                    db.Run("delete from items_trans where attachno='" + txt_serial_string.Text + "'");
                    //============
                    MessageBox.Show("delete");
                    new_file();


                }
            }


        }
        private void delete_row()
        {
            // try
            {
                if (edit == false)
                {
                    try
                    {

                        dgv.Rows.RemoveAt(this.dgv.SelectedRows[0].Index);

                    }
                    catch (Exception) { }

                }
                else
                {
                    if (this.dgv.SelectedRows.Count > 0)
                    {
                        if (dgv.CurrentRow.Cells["add_items"].Value.ToString() == "1")
                        {
                            dgv.Rows.RemoveAt(this.dgv.SelectedRows[0].Index);
                        }
                        else if (dgv.CurrentRow.Cells["add_items"].Value.ToString() != "1")
                        {
                            decimal qty_ware = Convert.ToDecimal(db.GetData("select isnull(SUM( qty),0) from wares where code_items='" + dgv.CurrentRow.Cells["code_items"].Value + "' and id_ware='" + dgv.CurrentRow.Cells["id_ware"].Value + "'").Rows[0][0].ToString());
                            if ((Convert.ToDecimal(dgv.CurrentRow.Cells["qty"].Value)) * (Convert.ToDecimal(dgv.CurrentRow.Cells["f_unite"].Value)) > 0)
                            {
                                //add row in dgv_delete
                                dgv_delete.Rows.Add(dgv.CurrentRow.Cells["code_items"].Value.ToString(), dgv.CurrentRow.Cells["name_items"].Value.ToString(), dgv.CurrentRow.Cells["name_unite"].Value.ToString(), dgv.CurrentRow.Cells["f_unite"].Value.ToString(), dgv.CurrentRow.Cells["exp"].Value.ToString(), dgv.CurrentRow.Cells["type"].Value.ToString(), (dgv.CurrentRow.Cells["exp_date_1"].Value).ToString(), (dgv.CurrentRow.Cells["exp_date"].Value).ToString(), (dgv.CurrentRow.Cells["qty"].Value).ToString(), (dgv.CurrentRow.Cells["item_price"].Value).ToString(), (dgv.CurrentRow.Cells["tot_bef"].Value).ToString(), (dgv.CurrentRow.Cells["discount"].Value).ToString(), (dgv.CurrentRow.Cells["tot_after_dis"].Value).ToString(), (dgv.CurrentRow.Cells["taxes"].Value).ToString(), (dgv.CurrentRow.Cells["incloud_taxes"].Value).ToString(), (dgv.CurrentRow.Cells["taxes_value"].Value).ToString(), (dgv.CurrentRow.Cells["id_ware"].Value).ToString(), (dgv.CurrentRow.Cells["item_qty1"].Value).ToString(), (dgv.CurrentRow.Cells["sale_dt_id"].Value).ToString(), (dgv.CurrentRow.Cells["tot_after_dis1"].Value).ToString(), 1, (dgv.CurrentRow.Cells["f_unite_1"].Value).ToString());
                                dgv.Rows.RemoveAt(this.dgv.SelectedRows[0].Index);
                            }

                            else
                            {
                                MessageBox.Show("لايوجد  رصيد");
                            }
                        }
                    }
                }
            }
            //catch (Exception )
            //{

            //    // MessageBox.Show( Exception);
            //}
        }
        private void calc_current_user()
        {
            if (dgv.Rows.Count == 0) return;
            try
            {
                //////////////  cala total =qty* price-des
                //  tot_bef, discount, tot_after_dis, taxes, incloud_taxes
                decimal tot_bef = 0;
                decimal discount = 0;
                decimal tot_after_dis = 0;
                decimal taxes_value = 0;
                decimal incloud_taxes = 0;
                //taxes state
                bool taxes_taxes = Convert.ToBoolean(db.GetData("select taxes  from term  where term_id ='" + combo_type.Text + "'").Rows[0][0]);
                bool vat_add = Convert.ToBoolean(db.GetData("select vat_add  from term  where term_id ='" + combo_type.Text + "'").Rows[0][0]);

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
                //if found tax 14% 
                //vat ==False==14
                //vat ==true==0

                if (taxes_taxes ==true)
                {
                    lbl_taxes_values.Text = "0";
                }
                else
                {
                    lbl_taxes_values.Text = Math.Round(taxes_value, 2) + "";
                }
                if (tot_bef > 0)
                {
                    lbl_incloud_taxes.Text = Math.Round(incloud_taxes, 2) + "";
                    //if found tax  vat  =1  % 
                    //vat ==False==1
                    //vat ==true==0
                    if (vat_add == true)
                    {
                        lbl_vat_Add.Text = "0";
                    }
                    else
                    {
                        lbl_vat_Add.Text = (Math.Round(tot_after_dis, 2) * 1 / 100) + "";
                    }
                }
                else
                {
                    MessageBox.Show("لايمكن إدخل رقم  اقل من صفر");
                    lbl_tot_befor.Text = "0";
                    lbl_tot_after_dis.Text = "0";
                    lbl_incloud_taxes.Text = "0";
                }
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cogs()
        {
            //get tot cost (COGS)
            for (int x = 0; x < dgv.Rows.Count; x++) //loop NO.2
            {
                string cost = db.GetData("select isnull((sum(cost)),0) from wares where code_items='" + dgv.Rows[x].Cells["code_items"].Value.ToString() + "' and id_ware='" + dgv.Rows[x].Cells["id_ware"].Value.ToString() + "'").Rows[0][0].ToString();
                if (Convert.ToDouble(cost) == 0 && dgv.Rows[x].Cells["type"].Value.ToString() != "2")
                {
                    MessageBox.Show("cost = 0  " + "  كود الصنف " + dgv.Rows[x].Cells["code_items"].Value.ToString());
                }
                dgv_cost.Rows.Add(dgv.Rows[x].Cells["code_items"].Value.ToString(), dgv.Rows[x].Cells["id_ware"].Value.ToString(), (Convert.ToDecimal(cost) * Convert.ToDecimal(dgv.Rows[x].Cells["qty"].Value.ToString())));
            }
            decimal tot_cost = 0;
            for (int tot = 0; tot < dgv_cost.Rows.Count; tot++)
            {
                tot_cost = tot_cost + Convert.ToDecimal(dgv_cost.Rows[tot].Cells["cost_c"].Value);
            }
            lbl_tot_cost.Text = Math.Round(tot_cost) + "";
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
                //taxes state
                bool taxes_taxes = Convert.ToBoolean(db.GetData("select taxes  from term  where term_id ='" + combo_type.Text + "'").Rows[0][0]);
                bool vat_add = Convert.ToBoolean(db.GetData("select vat_add  from term  where term_id ='" + combo_type.Text + "'").Rows[0][0]);

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
                // lbl_discount.Text = Math.Round(discount, 2) + "";
                lbl_tot_after_dis.Text = Math.Round(tot_after_dis, 2) + "";
                //if found tax 14% 
                //vat ==False==14
                //vat ==true==0

                if (taxes_taxes == true)
                {
                    lbl_taxes_values.Text = "0";
                }
                else
                {
                    lbl_taxes_values.Text = Math.Round(taxes_value, 2) + "";
                }
                if (tot_bef > 0)
                {
                    lbl_incloud_taxes.Text = Math.Round(incloud_taxes, 2) + "";
                    //if found tax  vat  =1  % 
                    //vat ==False==1
                    //vat ==true==0
                    if (vat_add == true)
                    {
                        lbl_vat_Add.Text = "0";
                    }
                    else
                    {
                        lbl_vat_Add.Text = (Math.Round(tot_after_dis, 2) * 1 / 100) + "";
                    }
                }
                else
                {
                   // MessageBox.Show("لايمكن إدخل رقم  اقل من صفر");
                    lbl_tot_befor.Text = "0";
                    lbl_tot_after_dis.Text = "0";
                    lbl_incloud_taxes.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void get_dt(string num, string book)//get data detals
        {
            DataTable dt = new DataTable();
            //db.GetData_DGV("SELECT  [no],  code_items, name_items, name_unite, f_unite , exp, type, qty, item_price, tot_bef, discount, tot_after_dis, taxes, incloud_taxes,taxes_value, id_ware,sale_dt_id , 0 as add_items,qty as item_qty1 ,exp_date , exp_date as exp_date_1,tot_after_dis as tot_after_dis1 ,f_unite as f_unite_1  FROM   sale_dt where sale_hd_id='" + num + "' and code_book='" + book + "'", dt);
        //    db.GetData_DGV("SELECT    code_items, name_items, name_unite, f_unite ,    exp, type, qty, item_price, tot_bef, discount, tot_after_dis, taxes, incloud_taxes,taxes_value, id_ware,sale_dt_id , 0 as add_items,qty as item_qty1 ,exp_date , exp_date as exp_date_1,tot_after_dis as tot_after_dis1 ,f_unite as f_unite_1  FROM   sale_dt where sale_hd_id='" + num + "' and code_book='" + book + "'", dt);

            //puchase
            db.GetData_DGV("SELECT    code_items , name_items , name_unite , f_unite , exp , type ,   exp_date as exp_date_1 , qty , item_price , tot_bef , discount , tot_after_dis , taxes , incloud_taxes ,taxes_value , id_ware ,sale_dt_id , 0 as add_items ,qty as item_qty1 ,exp_date , exp_date as exp_date_1 ,tot_after_dis as tot_after_dis1 ,f_unite as f_unite_1  FROM   sale_dt where sale_hd_id='" + num + "' and code_book='" + book + "'", dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv.Rows.Add(null, dt.Rows[i][0] + "", dt.Rows[i][1] + "", dt.Rows[i][2] + "", dt.Rows[i][3] + "", dt.Rows[i][4] + "", dt.Rows[i][5] + "", dt.Rows[i][6] + "", dt.Rows[i][6] + "", dt.Rows[i][7] + "", dt.Rows[i][8] + "", dt.Rows[i][9] + "", dt.Rows[i][10] + "", dt.Rows[i][11] + "", dt.Rows[i][12] + "", dt.Rows[i][13] + "", dt.Rows[i][14] + "", dt.Rows[i][15], dt.Rows[i][7] + "", dt.Rows[i][16] + "", dt.Rows[i][17] + "", dt.Rows[i][21] + "", 0, dt.Rows[i][22] + "");//, dt.Rows[i][18] + "", dt.Rows[i][21] + "",0, dt.Rows[i][20] + "");//, dt.Rows[i][15] + "", dt.Rows[i][16] + "", dt.Rows[i][17] + "", dt.Rows[i][18] + "", dt.Rows[i][19] + "", dt.Rows[i][20] + "", dt.Rows[i][21] + "");//, dt.Rows[i][19]+"", dt.Rows[i][20]+""
            }
            //  dgv.DataSource = dt_dt;
        }
        private void bode_of_navigation(string num, string book)
        {
            dgv.Rows.Clear();

            this.load_permission();
            //  this.api_e_invoice = "";
            this.lbl_stat_min_items.Caption = "0";
            this.lbl_stat_max_items.Caption = "0";
            this.lbl_balance_items.Caption = "0";
            this.lbl_stat_cost_items.Caption = "0";
            this.lbl_state_vcs_bal.Caption = "0";
            this.lbl_tot_cost.Text = "0";
            DataTable tb = new DataTable();
            db.GetData_DGV("select code_book from  sale_hd where sale_hd_id='" + num + "' and code_book='" + book + "' ", tb);
            if (tb.Rows.Count <= 0)
                return;
            this.edit = true;
            this.printer_direct_barButtonItem11.Enabled = true;
            this.printer_previeew_barButtonItem10.Enabled = true;
            // this.btn_chek_inv_tax.Enabled = true;
            this.btn_barcode.Enabled = true;
            this.btn_premiums.Enabled = true;
            this.get_dt(num, book);
            this.lbl_serial_P.Text = db.GetData("select serial_P from sale_hd where sale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            this.comb_code_name.Text = db.GetData("select name_book from sale_hd where sale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            this.txt_code_book.Text = db.GetData("select code_book from sale_hd where sale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            this.txt_serial_string.Text = db.GetData("select sale_hd_id from sale_hd where sale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            this.combo_wars.Text = db.GetData("select id_ware from sale_hd where sale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            this.combo_vcs.Text = db.GetData("select vcs_name from sale_hd where sale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            this.combo_vsc_codetree.Text = db.GetData("select vcs_code from sale_hd where sale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            this.combo_type.Text = db.GetData("select term from sale_hd where sale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            this.txt_note.Text = db.GetData("select note_txt from sale_hd where sale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            this.dt_piker.Text = db.GetData("select date_p from sale_hd where sale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            dt_due_date.Text = db.GetData("select due_date from sale_hd where sale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            this.lbl_user_name.Text = db.GetData("select [user_name] from sale_hd where sale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            this.lbl_user_code.Text = db.GetData("select user_code from sale_hd where sale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            this.lbl_tot_befor.Text = db.GetData("select tot_befor from sale_hd where sale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            this.lbl_tot_after_dis.Text = db.GetData("select tot_after_dis from sale_hd where sale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            this.lbl_discount.Text = db.GetData("select discount from sale_hd where sale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            this.lbl_incloud_taxes.Text = db.GetData("select incloud_taxes from sale_hd where sale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            this.lbl_taxes_values.Text = db.GetData("select taxes from sale_hd where sale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            //this.lbl_e_invoice.Text = db.GetData("select e_invoice from sale_hd where sale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            //this.lbl_type.Text = db.GetData("select  type from vcs where vcs_name='" + this.combo_vcs.Text + "'").Rows[0][0].ToString();
            //this.lbl_id.Text = db.GetData("select  id from vcs where vcs_name='" + this.combo_vcs.Text + "'").Rows[0][0].ToString();
            //this.lbl_name.Text = db.GetData("select  name from vcs where vcs_name='" + this.combo_vcs.Text + "'").Rows[0][0].ToString();
            //this.lbl_country.Text = db.GetData("select  country from vcs where vcs_name='" + this.combo_vcs.Text + "'").Rows[0][0].ToString();
            //this.lbl_governate.Text = db.GetData("select  governate from vcs where vcs_name='" + this.combo_vcs.Text + "'").Rows[0][0].ToString();
            //this.lbl_regionCity.Text = db.GetData("select  regionCity from vcs where vcs_name='" + this.combo_vcs.Text + "'").Rows[0][0].ToString();
            //this.lbl_street.Text = db.GetData("select  street from vcs where vcs_name='" + this.combo_vcs.Text + "'").Rows[0][0].ToString();
            //this.lbl_buildingNumber.Text = db.GetData("select  buildingNumber from vcs where vcs_name='" + this.combo_vcs.Text + "'").Rows[0][0].ToString();
            //this.lbl_postalCode.Text = db.GetData("select  postalCode from vcs where vcs_name='" + this.combo_vcs.Text + "'").Rows[0][0].ToString();
            //this.lbl_floor.Text = db.GetData("select  floor from vcs where vcs_name='" + this.combo_vcs.Text + "'").Rows[0][0].ToString();
            //this.lbl_uuid.Text = db.GetData("select uuid from sale_hd where sale_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            //this.dgv_edit.Rows.Clear();
            this.dgv_delete.Rows.Clear();
            this.dgv_add_items.Rows.Clear();
            this.dgv_cost.Rows.Clear();
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
        private void perform_save()
        {
            if (!this.add_permission && !Convert.ToBoolean(db.GetData("select [add_only] from permission_sub where user_code='" + v.usercode + "' and name_frm ='sales' ").Rows[0][0].ToString()))
            {
                this.save_barButtonItem1.Enabled = true;
            }
            //  else
            {
                this.load_permission();
                try
                {
                    if (db.GetData("select lock from sale_hd   where sale_hd_id= '" + this.txt_serial_string.Text + "'").Rows[0][0].ToString() == "t")
                    {
                        this.save_barButtonItem1.Enabled = false;
                        this.btn_delete_file.Enabled = false;
                        return;
                    }
                }
                catch (Exception ex)
                {
                    db.log_error(string.Concat((object)ex));
                }
                try
                {
                    //if (db.GetData("select uuid from sale_hd   where sale_hd_id= '" + this.txt_serial_string.Text + "'").Rows[0][0].ToString() != "0")
                    //{
                    //    this.save_barButtonItem1.Enabled = false;
                    //    this.btn_delete_file.Enabled = false;
                    //    return;
                    //}
                }
                catch (Exception ex)
                {
                    db.log_error(string.Concat((object)ex));
                }
                this.calc_all();
                if (Convert.ToDouble(this.lbl_tot_befor.Text) <= 0.0)
                {
                    XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "لايمكن الحفظ القيم بالصفر او اقل   ", "رساله تحذير", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (this.combo_type.Text == "")
                {
                    XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "ادخل نوع السند   ", "رساله تحذير", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (this.combo_vcs.Text == "")
                {
                    XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "ادخل المورد او العميل   ", "رساله تحذير", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (Convert.ToBoolean(db.GetData("select credit from vcs where vcs_code='" + this.combo_vsc_codetree.Text + "'").Rows[0][0].ToString()))
                {
                    double num4 = Convert.ToDouble(db.GetData("select credit_limit from vcs where vcs_code='" + this.combo_vsc_codetree.Text + "'").Rows[0][0]);
                    if (Convert.ToDouble(this.lbl_incloud_taxes.Text) >= num4)
                    {
                        XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, " لا يوجد ائتمان للعميل الحد المسموح به هو  " + (object)num4, "رساله تحذير", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                string state_E = db.GetData("select isnull(max(state_e),'') from sale_hd where sale_hd_id='" + txt_serial_string.Text + "'").Rows[0][0] + "";
                //1-if state =0  in progress =lock
                if (state_E == "0") { lock_document(); return; }
                //2-if state =1 had send to portal  =lock
                if (state_E == "1") { lock_document(); return; }
                else
                {
                    if (edit == false)
                    {
                        if (this.add_permission)
                        {
                            save();
                        }
                        else
                        {
                            MessageBox.Show("ملكش صلايحه انك تضيف فاتوره تعدل فقط ");
                        }
                    }
                    //else if (this.edit_permission)
                    //{
                    else
                    {
                        if (this.edit_permission)
                        {
                            this.edite_1();
                            this.bode_of_navigation(this.txt_serial_string.Text, this.txt_code_book.Text);
                            this.edit = true;
                        }
                        else
                        {
                            MessageBox.Show("ملكش صلايحه انك تعدل علي الفاتوره  ");


                        }
                    }

                    v.sale_sale_hd_id = this.txt_serial_string.Text;
                    v.sale_vcs_name = this.combo_vcs.Text;
                    v.sale_vcs_code = this.combo_vsc_codetree.Text;
                    v.sale_amount = this.lbl_incloud_taxes.Text;
                }
            }


        }
        private void add_items_in_dgv()
        {
            if (lbl_code_items.Text == "0") return;

            if (edit == false)
            {
                dgv.Rows.Add(null, code_items_a, name_items_a, name_unite_a, unit1, exp_a, type_a, null, 0, 1, price_items_a, 0, 0, 0, taxes_a, 0, 0, combo_wars.Text);
            }
            else
            {
                dgv.Rows.Add(null, code_items_a, name_items_a, name_unite_a, unit1, exp_a, type_a, null, null, 0, price_items_a, 00, 0, 00, taxes_a, 00, 0, combo_wars.Text, 0, 00, 1, 0, 0, unit1);
            }
            calc_all();
            try
            {
                dgv.CurrentCell = dgv.Rows[dgv.Rows.Count - 1].Cells[0];
            }
            catch (Exception)
            {


            }

        }
        private void add_items_in_dgv(string code_items, double qty, string name_unite, double f_unite)
        {
            if (code_items == "") return;

            code_items_a = code_items;
            name_items_a = !this.chk_search_lang.Checked ? db.GetData("select isnull(max(name_items2),0) from items where code_items='" + code_items + "'").Rows[0][0].ToString() : db.GetData("select isnull(max(name_items),0) from items where code_items='" + code_items + "'").Rows[0][0].ToString();
            name_unite_a = name_unite;//db.GetData("select isnull(max(name_unite),0) from items where code_items='" + code_items + "'").Rows[0][0].ToString();
            unit1 = f_unite + ""; //db.GetData("select isnull(max(unit1),0) from items where code_items='" + code_items + "'").Rows[0][0].ToString();
            price_items_a = db.GetData("select isnull(max(price_buy),0) from items where code_items='" + code_items + "'").Rows[0][0].ToString();
            discount_a = db.GetData("select isnull(max(discount_buy),0) from items where code_items='" + code_items + "'").Rows[0][0].ToString();
            taxes_a = db.GetData("select isnull(max(taxes),0) from items where code_items='" + code_items + "'").Rows[0][0].ToString();
            type_a = db.GetData("select isnull(max([type]),0) from items where code_items='" + code_items + "'").Rows[0][0].ToString();

            try
            {
                this.exp_a = db.GetData("select [exp] from items where code_items='" + code_items + "'").Rows[0][0].ToString();
            }
            catch (Exception)
            {
            }
            if (edit == false)
            {
                dgv.Rows.Add(null, code_items_a, name_items_a, name_unite_a, unit1, exp_a, type_a, null, 0, qty, price_items_a, 0, 0, 0, taxes_a, 0, 0, combo_wars.Text);

                //dgv.Rows.Add(null, code_items_a, name_items_a, name_unite_a, unit1, exp_a, type_a, null, 0, 1, price_items_a, 0, 0, 0, taxes_a, 0, 0, combo_wars.Text);
            }
            calc_all();
            try
            {
                dgv.CurrentCell = dgv.Rows[dgv.Rows.Count - 1].Cells[0];
            }
            catch (Exception)
            {


            }

        }

        private void add_items_in_dgv(int num)
        {
            if (lbl_code_items.Text == "0") return;

            if (edit == false)
            {
                dgv.Rows.Add(null, code_items_a, name_items_a, name_unite_a, unit1, exp_a, type_a, null, 0, num, price_items_a, 0, 0, 0, taxes_a, 0, 0, combo_wars.Text);
            }
            else
            {
                //  dgv.Rows.Add(null, code_items_a, name_items_a, name_unite_a, unit1, exp_a, type_a, null, 0, 0, price_items_a, 0, db.GetData("select isnull(avg(discount),0) from purchase_dt where code_items='" + code_items_a + "' ").Rows[0][0].ToString(), 0, taxes_a, db.GetData("select isnull(sum(qty),0) from wares where code_items='" + code_items_a + "' and id_ware='" + combo_wars.Text + "'").Rows[0][0].ToString(), 1, combo_wars.Text);
                dgv.Rows.Add(null, code_items_a, name_items_a, name_unite_a, unit1, exp_a, type_a, null, null, num, price_items_a, 00, 0, 00, taxes_a, 00, 0, combo_wars.Text, 0, 00, 1, 0, 2, unit1);

            }

            calc_all();
            try
            {
                dgv.CurrentCell = dgv.Rows[dgv.Rows.Count - 1].Cells[0];
            }
            catch (Exception)
            {


            }


            calc_all();

        }

        //private void add_items_in_dgv()
        //{
        //    if (edit == false)
        //    {
        //        dgv.Rows.Add(null, code_items_a, name_items_a, name_unite_a, unit1, exp_a, type_a, null, 0, 1, price_items_a, 0, 0, 0, taxes_a, 0, 0, combo_wars.Text);
        //    }
        //    else
        //    //{
        //    //    //DataTable dataTable = (DataTable)dgv.DataSource;
        //    //    //DataRow drToAdd = dataTable.NewRow();
        //    //    //drToAdd["code_items"] = code_items_a;
        //    //    //drToAdd["name_items"] = name_items_a;
        //    //    //drToAdd["name_unite"] = name_unite_a;
        //    //    //drToAdd["f_unite"] = unit1;
        //    //    //drToAdd["exp"] = exp_a;
        //    //    //drToAdd["type"] = type_a;
        //    //    //// drToAdd["exp_date"] =0;
        //    //    ////drToAdd["mf_unite"] = 0;
        //    //    //drToAdd["qty"] = 0;
        //    //    //drToAdd["item_price"] = price_items_a;
        //    //    //drToAdd["tot_bef"] = 0;
        //    //    //drToAdd["discount"] = 0;
        //    //    //drToAdd["tot_after_dis"] = 0;
        //    //    //drToAdd["taxes"] = taxes_a;
        //    //    //drToAdd["incloud_taxes"] = 0;
        //    //    //drToAdd["taxes_value"] = 0;
        //    //    //drToAdd["item_qty1"] = db.GetData("select isnull(sum(qty),0) from wares where code_items='" + code_items_a + "' and id_ware='" + combo_wars.Text + "'").Rows[0][0].ToString();
        //    //    ////                drToAdd["item_qty1"] = 0;
        //    //    //drToAdd["add_items"] = 1;
        //    //    //drToAdd["id_ware"] = combo_wars.Text;
        //    //    //dataTable.Rows.Add(drToAdd);
        //    //    //dataTable.AcceptChanges();

        //    //}
        //    calc_all();
        //}

        string code_items_a, name_items_a, name_unite_a, unit1, price_items_a, discount_a, taxes_a, exp_a, type_a;//combo_add_items_SelectedIndexChanged
        private void add_items_in_property_comboadd_items(string find_fild, string code_items)
        {


            this.code_items_a = db.GetData("select isnull(max(code_items),0) from items where " + find_fild + "='" + code_items + "'").Rows[0][0].ToString();
            this.lbl_code_items.Text = this.code_items_a;
            if (this.chk_search_lang.Checked)
                this.name_items_a = db.GetData("select isnull(max(name_items),0) from items where " + find_fild + "='" + code_items + "'").Rows[0][0].ToString();
            else
                this.name_items_a = db.GetData("select isnull(max(name_items2),0) from items where " + find_fild + "='" + code_items + "'").Rows[0][0].ToString();
            this.name_unite_a = db.GetData("select isnull(max(name_unite),0) from items where code_items='" + this.code_items_a + "'").Rows[0][0].ToString();
            this.unit1 = db.GetData("select isnull(max(unit1),0) from items where code_items='" + this.code_items_a + "'").Rows[0][0].ToString();
            this.price_items_a = db.GetData("select isnull(max(price_buy),0) from items where code_items='" + this.code_items_a + "'").Rows[0][0].ToString();
            this.discount_a = db.GetData("select isnull(avg(discount),0) from purchase_dt where code_items='" + this.code_items_a + "'").Rows[0][0].ToString();
            this.taxes_a = db.GetData("select isnull(max(taxes),0) from items where code_items='" + this.code_items_a + "'").Rows[0][0].ToString();
            if (string.Concat(db.GetData("select isnull(count([exp]),0) from items where code_items='" + this.code_items_a + "'").Rows[0][0]) != "0")
                this.exp_a = string.Concat(db.GetData("select [exp] from items where code_items='" + this.code_items_a + "'").Rows[0][0]);
            this.type_a = db.GetData("select isnull(max([type]),0) from items where code_items='" + this.code_items_a + "'").Rows[0][0].ToString();



        }

        private void new_file()
        {

            frm_sale frm = new frm_sale();
            this.Close();
            frm.Show();

        }
        private void add_unite_()
        {
            try
            {
                dgv.CurrentRow.Cells["name_unite"].Value = combo_unit.Text;
                dgv.CurrentRow.Cells["f_unite"].Value = lbl_f_unite.Text;

            }
            catch (Exception)
            {
            }
        }
        private void load_combo_cost_exp_editmode()
        {
            try
            {
                all_comb.load_cost_items_exp(combo_expcost, dgv.CurrentRow.Cells["code_items"].Value.ToString(), dgv.CurrentRow.Cells["id_ware"].Value.ToString(), Convert.ToDateTime(dgv.CurrentRow.Cells["exp_date"].Value).ToString("MM-dd-yyyy"), txt_serial_string.Text, txt_code_book.Text);

            }
            catch (Exception)
            {


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

                lbl_stat_min_items.Caption = db.GetData("select isnull(min (discount),0) from purchase_dt  where code_items ='" + dgv.CurrentRow.Cells["code_items"].Value.ToString() + "'").Rows[0][0].ToString();
                lbl_stat_max_items.Caption = db.GetData("select isnull(max (discount),0) from purchase_dt  where code_items ='" + dgv.CurrentRow.Cells["code_items"].Value.ToString() + "'").Rows[0][0].ToString();
                lbl_avg_discount.Caption = db.GetData("select isnull(avg (discount),0) from purchase_dt  where code_items ='" + dgv.CurrentRow.Cells["code_items"].Value.ToString() + "'").Rows[0][0].ToString();
                lbl_stat_cost_items.Caption = db.GetData("select cost from wares where code_items='" + dgv.CurrentRow.Cells["code_items"].Value.ToString() + "' and id_ware='" + dgv.CurrentRow.Cells["id_ware"].Value.ToString() + "'").Rows[0][0].ToString();
                lbl_balance_items.Caption = db.GetData("select qty from wares where code_items='" + dgv.CurrentRow.Cells["code_items"].Value.ToString() + "' and id_ware='" + dgv.CurrentRow.Cells["id_ware"].Value.ToString() + "'").Rows[0][0].ToString();
                lbl_state_vcs_bal.Caption = db.GetData("select isnull(sum(depit)-sum(credit),0) from entry where acc_num='" + combo_vsc_codetree.Text + "'").Rows[0][0].ToString();

            }
            catch (Exception)
            {


            }
        }
        private void load_permission()
        {
            this.save_barButtonItem1.Enabled = Convert.ToBoolean(db.GetData("select [add_only] from permission_sub where user_code='" + v.usercode + "' and name_frm ='sales' ").Rows[0][0].ToString());
            this.btn_delete_file.Enabled = Convert.ToBoolean(db.GetData("select [delete] from permission_sub where user_code='" + v.usercode + "' and name_frm ='sales' ").Rows[0][0].ToString());
            this.add_permission = Convert.ToBoolean(db.GetData("select [add_only] from permission_sub where user_code='" + v.usercode + "' and name_frm ='sales' ").Rows[0][0].ToString());
            if (this.add_permission)
                this.save_barButtonItem1.Enabled = true;
            this.edit_permission = Convert.ToBoolean(db.GetData("select [edit_only] from permission_sub where user_code='" + v.usercode + "' and name_frm ='sales' ").Rows[0][0].ToString());
            this.printer_previeew_barButtonItem10.Enabled = Convert.ToBoolean(db.GetData("select [print] from permission_sub where user_code='" + v.usercode + "' and name_frm ='sales' ").Rows[0][0].ToString());
            this.printer_direct_barButtonItem11.Enabled = Convert.ToBoolean(db.GetData("select [print] from permission_sub where user_code='" + v.usercode + "' and name_frm ='sales' ").Rows[0][0].ToString());

        }
        private void load_permission_price_discount_discount_all()
        {
            this.contral_sale_price = Convert.ToBoolean(db.GetData("select contral_sale_price from permission_price_discount where user_code='" + v.usercode + "'").Rows[0][0].ToString());
            this.controal_sale_discount = Convert.ToBoolean(db.GetData("select contral_sale_price from permission_price_discount where user_code='" + v.usercode + "'").Rows[0][0].ToString());
            this.controal_all_discount = Convert.ToBoolean(db.GetData("select contral_sale_price from permission_price_discount where user_code='" + v.usercode + "'").Rows[0][0].ToString());
            if (!this.contral_sale_price)
                this.dgv.Columns["item_price"].ReadOnly = true;
            else
                this.dgv.Columns["item_price"].ReadOnly = false;
            if (!this.controal_sale_discount)
                this.dgv.Columns["discount"].ReadOnly = true;
            else
                this.dgv.Columns["discount"].ReadOnly = false;
            if (!this.controal_all_discount)
                this.lbl_discount.ReadOnly = true;
            else
                this.lbl_discount.ReadOnly = false;
        }


        //=============Function Edite=============================
        public void cheak_qty(DataGridView dgv_, string code_items_col, string id_ware_col, string qty_col, string f_unite_col, string item_qty1_col)
        {
            string qty_old = "0";
            string qty_current = "0";
            string qty_current1 = "0";
            string qty_new = "0";
            for (int i = 0; i < dgv_.Rows.Count; i++)
            {

                qty_old = db.GetData("select qty from wares where code_items='" + dgv_.Rows[i].Cells[code_items_col].Value + "'and id_ware='" + dgv_.Rows[i].Cells[id_ware_col].Value + "'").Rows[0][0].ToString();
                qty_current = ((Convert.ToDecimal(dgv_.Rows[i].Cells[qty_col].Value)) * (Convert.ToDecimal(dgv_.Rows[i].Cells[f_unite_col].Value))).ToString();
                qty_current1 = ((Convert.ToDecimal(dgv_.Rows[i].Cells[item_qty1_col].Value)) * (Convert.ToDecimal(dgv_.Rows[i].Cells[f_unite_col].Value))).ToString(); if (qty_current1 == "") qty_current1 = "0";

                qty_new = (Convert.ToDecimal(qty_old) + (Convert.ToDecimal(qty_current) - Convert.ToDecimal(qty_current1))).ToString();

                if (Convert.ToDecimal(qty_new) < 0)
                {
                    MessageBox.Show("لايمكن الرصيد يكون بالسالب ");
                    break;
                }
            }


        }
        public static bool cheak_qty_insert(DataGridView dgv_, string code_items_col, string id_ware_col, string qty_col, string f_unite_col)
        {
            string qty_old = "0";
            string qty_current = "0";
            string qty_new = "0";
            for (int i = 0; i < dgv_.Rows.Count; i++)
            {
                qty_old = db.GetData("select qty from wares where code_items='" + dgv_.Rows[i].Cells[code_items_col].Value + "'and id_ware='" + dgv_.Rows[i].Cells[id_ware_col].Value + "'").Rows[0][0].ToString();
                qty_current = ((Convert.ToDecimal(dgv_.Rows[i].Cells[qty_col].Value)) * (Convert.ToDecimal(dgv_.Rows[i].Cells[f_unite_col].Value))).ToString();
                qty_new = (Convert.ToDecimal(qty_old) - (Convert.ToDecimal(qty_current))).ToString();

                if (Convert.ToDecimal(qty_new) < 0)
                {
                    MessageBox.Show("لا يمكن الرصيد يكون بالسالب ");
                }
            }
            return false;
        }
        private void edite_hd()
        {
            db.Run("update sale_hd set   vcs_code='" + combo_vsc_codetree.Text + "', vcs_name='" + combo_vcs.Text + "', term='" + combo_type.Text + "',  date_P='" + Convert.ToDateTime(dt_piker.Value).ToString("MM-dd-yyyy") + "',due_date='" + dt_due_date.Value.ToString("MM-dd-yyyy") + "', tot_befor='" + lbl_tot_befor.Text + "', tot_after_dis='" + lbl_tot_after_dis.Text + "', discount='" + lbl_discount.Text + "', incloud_taxes='" + lbl_incloud_taxes.Text + "', taxes_value='" + lbl_taxes_values.Text + "', vat_add='"+lbl_vat_Add.Text+"',id_ware='" + combo_wars.Text + "', code_entry='" + txt_code_entry.Text + "', book_name_entry='" + txt_name_book_type.Text + "', code_book_entry='" + txt_code_entry_type.Text + "', note_txt='" + txt_note.Text + "', user_code='" + lbl_user_code.Text + "', user_name='" + lbl_user_name.Text + "',currance='" + combo_currance.Text + "',f_currance='" + txt_f_currance.Text + "'  where sale_hd_id='" + txt_serial_string.Text + "'and  code_book='" + txt_code_book.Text + "'");
            db.Run("update sale_hd set vcs_value=(select sum(depit)-sum(credit) from entry where acc_num='" + combo_vsc_codetree.Text + "') where sale_hd_id='" + txt_serial_string.Text + "'");


            //delete trans

            db.Run("delete from items_trans where attachno='" + txt_serial_string.Text + "'");


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

            string qty_old = "0";
            string qty_current = "0";
            string qty_current1 = "0";
            string qty_new = "0";
            for (int i = 0; i < dgv_.Rows.Count; i++)
            {
                if (dgv_.Rows[i].Cells[type].Value.ToString() == "1" && dgv_.Rows[i].Cells[type].Value.ToString() != "2")
                {
                    qty_old = db.GetData("select qty from wares where code_items='" + dgv_.Rows[i].Cells[code_items_col].Value + "'and id_ware='" + dgv_.Rows[i].Cells[id_ware_col].Value + "'").Rows[0][0].ToString();
                    qty_current = ((Convert.ToDecimal(dgv_.Rows[i].Cells[qty_col].Value)) * (Convert.ToDecimal(dgv_.Rows[i].Cells[f_unite_col].Value))).ToString();
                    qty_current1 = ((Convert.ToDecimal(dgv_.Rows[i].Cells[item_qty1_col].Value)) * (Convert.ToDecimal(dgv_.Rows[i].Cells[f_unite_1_col].Value))).ToString();
                    if (qty_current1 == "") qty_current1 = "0";
                    decimal x = (Convert.ToDecimal(qty_old)) + (Convert.ToDecimal(qty_current1));
                    qty_new = ((Convert.ToDecimal(x)) - (Convert.ToDecimal(qty_current))).ToString();
                    if (Convert.ToDecimal(qty_new) < 0) { MessageBox.Show("حدث خطاء والرصيد اصبح بالسالب"); return; }
                    db.Run("update wares set qty =( " + qty_new + ") where code_items='" + dgv_.Rows[i].Cells[code_items_col].Value + "'and id_ware= '" + dgv_.Rows[i].Cells[id_ware_col].Value + "'");
                    //limit and maximum
                    decimal demand_limit = Convert.ToDecimal(db.GetData("select isnull(max(demand_limit),0)  from wares where code_items='" + dgv_.Rows[i].Cells[code_items_col].Value + "' and id_ware='" + dgv_.Rows[i].Cells[id_ware_col].Value + "'").Rows[0][0].ToString());
                    decimal demand_maximum = Convert.ToDecimal(db.GetData("select isnull(max(demand_maximum),0)  from wares where code_items='" + dgv_.Rows[i].Cells[code_items_col].Value + "' and id_ware='" + dgv_.Rows[i].Cells[id_ware_col].Value + "'").Rows[0][0].ToString());
                    Boolean limit = Convert.ToBoolean(db.GetData("select demand_limit_bit  from wares where code_items='" + dgv_.Rows[i].Cells[code_items_col].Value + "' and id_ware='" + dgv_.Rows[i].Cells[id_ware_col].Value + "'").Rows[0][0].ToString());
                    Boolean maximum = Convert.ToBoolean(db.GetData("select demand_maximum_bit  from wares where code_items='" + dgv_.Rows[i].Cells[code_items_col].Value + "' and id_ware='" + dgv_.Rows[i].Cells[id_ware_col].Value + "'").Rows[0][0].ToString());

                    if (limit == true)
                    {
                        if (Convert.ToDecimal(qty_new) <= demand_limit)
                        {
                            db.Run("insert into center(code_items,date,note,wares) values ('" + dgv_.Rows[i].Cells[code_items_col].Value + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','Items that have reached the demand limit  ','" + dgv_.Rows[i].Cells[id_ware_col].Value + "')");
                        }
                    }
                    if (maximum == true)
                    {
                        if (Convert.ToDecimal(qty_new) >= demand_maximum)
                        {
                            db.Run("insert into center(code_items,date,note,wares) values ('" + dgv_.Rows[i].Cells[code_items_col].Value + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','Items that have reached the demand maximum  ','" + dgv_.Rows[i].Cells[id_ware_col].Value + "')");
                        }
                    }
                }
            }
        }
        private void ware_edit_update(DataGridView dgv_, string code_items_col, string id_ware_col, string qty_col, string f_unite_col, string type)//incase of add item in edit mode
        {
            string qty_old = "0";
            string qty_current = "0";
            string qty_new = "0";
            for (int i = 0; i < dgv_.Rows.Count; i++)
            {
                if (dgv_.Rows[i].Cells[type].Value.ToString() == "1")
                {
                    qty_old = db.GetData("select qty from wares where code_items='" + dgv_.Rows[i].Cells[code_items_col].Value + "'and id_ware='" + dgv_.Rows[i].Cells[id_ware_col].Value + "'").Rows[0][0].ToString();
                    qty_current = ((Convert.ToDecimal(dgv_.Rows[i].Cells[qty_col].Value)) * (Convert.ToDecimal(dgv_.Rows[i].Cells[f_unite_col].Value))).ToString();
                    qty_new = (Convert.ToDecimal(qty_old) - (Convert.ToDecimal(qty_current))).ToString(); if (Convert.ToDecimal(qty_new) < 0) return;
                    db.Run("update wares set qty =( " + qty_new + ") where code_items='" + dgv_.Rows[i].Cells[code_items_col].Value + "'and id_ware= '" + dgv_.Rows[i].Cells[id_ware_col].Value + "'");

                    //limit and maximum
                    decimal demand_limit = Convert.ToDecimal(db.GetData("select isnull(max(demand_limit),0)  from wares where code_items='" + dgv_.Rows[i].Cells[code_items_col].Value + "' and id_ware='" + dgv_.Rows[i].Cells[id_ware_col].Value + "'").Rows[0][0].ToString());
                    decimal demand_maximum = Convert.ToDecimal(db.GetData("select isnull(max(demand_maximum),0)  from wares where code_items='" + dgv_.Rows[i].Cells[code_items_col].Value + "' and id_ware='" + dgv_.Rows[i].Cells[id_ware_col].Value + "'").Rows[0][0].ToString());
                    Boolean limit = Convert.ToBoolean(db.GetData("select demand_limit_bit  from wares where code_items='" + dgv_.Rows[i].Cells[code_items_col].Value + "' and id_ware='" + dgv_.Rows[i].Cells[id_ware_col].Value + "'").Rows[0][0].ToString());
                    Boolean maximum = Convert.ToBoolean(db.GetData("select demand_maximum_bit  from wares where code_items='" + dgv_.Rows[i].Cells[code_items_col].Value + "' and id_ware='" + dgv_.Rows[i].Cells[id_ware_col].Value + "'").Rows[0][0].ToString());

                    if (limit == true)
                    {
                        if (Convert.ToDecimal(qty_new) <= demand_limit)
                        {
                            db.Run("insert into center(code_items,date,note,wares) values ('" + dgv_.Rows[i].Cells[code_items_col].Value + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','Items that have reached the demand limit  ','" + dgv_.Rows[i].Cells[id_ware_col].Value + "')");
                        }
                    }
                    if (maximum == true)
                    {
                        if (Convert.ToDecimal(qty_new) >= demand_maximum)
                        {
                            db.Run("insert into center(code_items,date,note,wares) values ('" + dgv_.Rows[i].Cells[code_items_col].Value + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','Items that have reached the demand maximum  ','" + dgv_.Rows[i].Cells[id_ware_col].Value + "')");
                        }
                    }
                }
            }

        }
        private void ware_del_row()
        {
            string qty_old = "0";
            string qty_current = "0";
            string qty_new = "0";
            string qty_current1 = "0";
            for (int i = 0; i < dgv_delete.Rows.Count; i++)
            {
                if (dgv_delete.Rows[i].Cells["type_de"].Value.ToString() == "1")
                {
                    qty_old = db.GetData("select qty from wares where code_items='" + dgv_delete.Rows[i].Cells["code_items_de"].Value + "'and id_ware='" + dgv_delete.Rows[i].Cells["id_ware_de"].Value + "'").Rows[0][0].ToString();
                    qty_current = ((Convert.ToDecimal(dgv_delete.Rows[i].Cells["qty_de"].Value)) * (Convert.ToDecimal(dgv_delete.Rows[i].Cells["f_unite_de"].Value))).ToString();
                    qty_current1 = ((Convert.ToDecimal(dgv_delete.Rows[i].Cells["item_qty1_de"].Value)) * (Convert.ToDecimal(dgv_delete.Rows[i].Cells["f_unite_1_de"].Value))).ToString();
                    decimal x = (Convert.ToDecimal(qty_old)) + (Convert.ToDecimal(qty_current1));
                    //  qty_new = ((Convert.ToDecimal(x)) - (Convert.ToDecimal(qty_current))).ToString();
                    db.Run("update wares set qty =( " + x + ") where code_items='" + dgv_delete.Rows[i].Cells["code_items_de"].Value + "'and id_ware= '" + dgv_delete.Rows[i].Cells["id_ware_de"].Value + "'");

                    //limit and maximum
                    decimal demand_limit = Convert.ToDecimal(db.GetData("select isnull(max(demand_limit),0)  from wares where code_items='" + dgv_delete.Rows[i].Cells["code_items_de"].Value + "' and id_ware='" + dgv_delete.Rows[i].Cells["id_ware_de"].Value + "'").Rows[0][0].ToString());
                    decimal demand_maximum = Convert.ToDecimal(db.GetData("select isnull(max(demand_maximum),0)  from wares where code_items='" + dgv_delete.Rows[i].Cells["code_items_de"].Value + "' and id_ware='" + dgv_delete.Rows[i].Cells["id_ware_de"].Value + "'").Rows[0][0].ToString());
                    Boolean limit = Convert.ToBoolean(db.GetData("select demand_limit_bit  from wares where code_items='" + dgv_delete.Rows[i].Cells["code_items_de"].Value + "' and id_ware='" + dgv_delete.Rows[i].Cells["id_ware_de"].Value + "'").Rows[0][0].ToString());
                    Boolean maximum = Convert.ToBoolean(db.GetData("select demand_maximum_bit  from wares where code_items='" + dgv_delete.Rows[i].Cells["code_items_de"].Value + "' and id_ware='" + dgv_delete.Rows[i].Cells["id_ware_de"].Value + "'").Rows[0][0].ToString());

                    if (limit == true)
                    {
                        if (Convert.ToDecimal(x) <= demand_limit)
                        {
                            db.Run("insert into center(code_items,date,note,wares) values ('" + dgv_delete.Rows[i].Cells["code_items_de"].Value + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','Items that have reached the demand limit  ','" + dgv_delete.Rows[i].Cells["id_ware_de"].Value + "')");
                        }
                    }
                    if (maximum == true)
                    {
                        if (Convert.ToDecimal(x) >= demand_maximum)
                        {
                            db.Run("insert into center(code_items,date,note,wares) values ('" + dgv_delete.Rows[i].Cells["code_items_de"].Value + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','Items that have reached the demand maximum  ','" + dgv_delete.Rows[i].Cells["id_ware_de"].Value + "')");
                        }
                    }
                }
            }
        }
        private void exp_insert_and_delete_edite(DataGridView dgv_, string code_items_col, string name_items_col, string id_ware_col, string qty_col, string f_unite_col, string item_qty1_col, string tot_after_dis_col_1, string tot_after_dis_col, string exp_date_1_e_col, string exp_date_e_col)
        {
            string id_rows = "0";
            for (int i = 0; i < dgv_edit.Rows.Count; i++)
            {

                if (dgv_.Rows[i].Cells["exp_t_f"].Value.ToString() == "True")
                {
                    id_rows = db.GetData("select id_rows from exp_date where code_items='" + dgv_.Rows[i].Cells[code_items_col].Value.ToString() + "' and id_ware='" + dgv_.Rows[i].Cells[id_ware_col].Value.ToString() + "' and code='" + txt_serial_string.Text + "' and code_book='" + txt_code_book.Text + "' and exp_date='" + Convert.ToDateTime(dgv_.Rows[i].Cells[exp_date_1_e_col].Value).ToString("MM-dd-yyyy") + "'").Rows[0][0].ToString();
                    if (id_rows == null) { MessageBox.Show("مفيش رصيد او في حاجه غلط مش عارف ....؟!!بس مش عارف ", "مش عارف والله العظيم"); return; }
                    db.Run("delete from exp_date where code_items='" + dgv_.Rows[i].Cells[code_items_col].Value + "' and id_ware='" + dgv_.Rows[i].Cells[id_ware_col].Value + "' and exp_date='" + Convert.ToDateTime(dgv_.Rows[i].Cells[exp_date_1_e_col].Value).ToString("MM-dd-yyyy") + "' and id_rows='" + id_rows + "' and code='" + txt_serial_string.Text + "' and code_book='" + txt_code_book.Text + "'");
                    db.Run("insert into exp_date (code_items,name_items,exp_date,qty,cost,id_ware,code,code_book) values('" + dgv_.Rows[i].Cells[code_items_col].Value + "','" + dgv_.Rows[i].Cells[name_items_col].Value + "','" + Convert.ToDateTime(dgv_.Rows[i].Cells[exp_date_e_col].Value).ToString("MM-dd-yyyy") + "','" + (Convert.ToDecimal(dgv_.Rows[i].Cells[qty_col].Value)) * (Convert.ToDecimal(dgv_.Rows[i].Cells[f_unite_col].Value)) * -1 + "','" + dgv_.Rows[i].Cells[tot_after_dis_col].Value + "','" + dgv_.Rows[i].Cells[id_ware_col].Value + "',('" + txt_serial_string.Text + "'),('" + txt_code_book.Text + "'))");
                }
            }
        }
        private void exp_insert_edite()
        {
            for (int i = 0; i < dgv_add_items.Rows.Count; i++)
            {
                if (dgv_add_items.Rows[i].Cells["type_ai"].Value.ToString() == "1" && dgv_add_items.Rows[i].Cells["exp_ai"].Value.ToString() == "True")
                {
                    db.Run("insert into exp_date (code_items,name_items,exp_date,qty,cost,id_ware,code,code_book) values('" + dgv_add_items.Rows[i].Cells["code_items_ai"].Value + "','" + dgv_add_items.Rows[i].Cells["name_items_ai"].Value + "','" + Convert.ToDateTime(dgv_add_items.Rows[i].Cells["exp_date_1_ai"].Value).ToString("MM-dd-yyyy") + "','" + (Convert.ToDecimal(dgv_add_items.Rows[i].Cells["qty_ai"].Value)) * (Convert.ToDecimal(dgv_add_items.Rows[i].Cells["f_unite_ai"].Value)) * -1 + "','" + dgv_add_items.Rows[i].Cells["tot_after_dis_ai"].Value + "','" + dgv_add_items.Rows[i].Cells["id_ware_ai"].Value + "',('" + txt_serial_string.Text + "'),('" + txt_code_book.Text + "')) ");
                }
            }
        }
        private void exp_delete_edite()
        {
            for (int i = 0; i < dgv_delete.Rows.Count; i++)
            {
                if (dgv_delete.Rows[i].Cells["exp_de"].Value.ToString() == "True")
                {

                    string id_rows = "0";
                    id_rows = db.GetData("select id_rows from exp_date where code_items='" + dgv_delete.Rows[i].Cells["code_items_de"].Value.ToString() + "' and id_ware='" + dgv_delete.Rows[i].Cells["id_ware_de"].Value.ToString() + "' and code='" + txt_serial_string.Text + "' and code_book='" + txt_code_book.Text + "' and exp_date='" + Convert.ToDateTime(dgv_delete.Rows[i].Cells["exp_date_1_de"].Value).ToString("MM-dd-yyyy") + "'").Rows[0][0].ToString();
                    db.Run("delete from exp_date where code_items='" + dgv_delete.Rows[i].Cells["code_items_de"].Value + "' and id_ware='" + dgv_delete.Rows[i].Cells["id_ware_de"].Value + "' and id_rows='" + id_rows + "' and code='" + txt_serial_string.Text + "' and code_book='" + txt_code_book.Text + "'");
                }
            }
        }
        //=========================================
        //====================================controls 
        private void comb_code_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_code_book.Text = db.GetData("select code_book from book where name_book='" + comb_code_name.Text + "'").Rows[0][0].ToString();
            //cls_book.selectbook("sale_hd", "سند فاتوره مبيعات", txt_code_book.Text, txt_serial, "sale_hd_id");
            //txt_serial_string.Text = txt_code_book.Text + txt_serial.Text;
            lbl_comb_code_name.Text = comb_code_name.Text;

            cls_book.Generat_numBooknum("sale_hd", txt_code_book.Text, ref numBook_sale, ref error, ref num);
            txt_serial_string.Text = numBook_sale;

        }
        string code_entry, sort, rootlevel, rootlevel_name, type_acc;
        //==============================dgv
        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)//to sreal dgv
        {
            //try
            //{
            //    if (frm_entry.ActiveForm.Location.X > 100)
            //    {
            //        using (SolidBrush b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor))
            //        {
            //            e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 875, e.RowBounds.Location.Y + 0);
            //        }
            //    }
            //    else
            //    {
            //        using (SolidBrush b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor))
            //        {
            //            e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 1320, e.RowBounds.Location.Y + 0);
            //        }

            //    }
            //}
            //catch (Exception)
            //{


            //}
        }
        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)//to sreial dgv in gdv
        {
            Classes.command.LoadSerial(dgv);

        }
        private void dgv_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)//to sreial dgv in gdv
        {
            calc_all();
            Classes.command.LoadSerial(dgv);

        }
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)//show and head exp and combo
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
        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)//to wright edit in colm edit_c
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
        private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)// error dgv
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
        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)//dgv prevent edit only number
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
        private void combo_type_SelectedIndexChanged(object sender, EventArgs e)//select code book entry (type)
        {
            txt_name_book_type.Text = db.GetData("select bookname_entry  from term  where term_id ='" + combo_type.Text + "'").Rows[0][0].ToString();
            txt_code_entry_type.Text = db.GetData("select code_entry  from term  where term_id ='" + combo_type.Text + "'").Rows[0][0].ToString();
         //   cls_book.selectbook("[entry]", "سند قيد", txt_code_entry_type.Text, txt_code_entry, "code_entry");
            string code_entry_term = (db.GetData("select code_entry from term where term_id='" + combo_type.Text + "' ").Rows[0][0].ToString());
            cls_book.Generat_numBooknum("entry", code_entry_term, ref numBook_entry, ref error, ref num_entry);
            txt_entry_string.Text = numBook_entry;
            calc_current_user();

        }
        private void simpleButton1_Click(object sender, EventArgs e)//add item in dgv
        {
            add_items_in_dgv();


        }
        private void combo_add_items_SelectedIndexChanged(object sender, EventArgs e)
        {
            // add_items_in_property_comboadd_items(); 
            if (combo_add_items.Text != "")
            {
                // try
                {
                    add_items_in_property_comboadd_items("name_items", combo_add_items.Text);
                }
                //catch (Exception)
                {


                }
            }
            //// add_items_in_property_comboadd_items(); 
            //if (!(this.combo_add_items.Text != ""))
            //    return;
            //try
            //{
            //    if (this.chk_search_lang.Checked)
            //        this.add_items_in_property_comboadd_items("name_items", this.combo_add_items.Text);
            //    else
            //        this.add_items_in_property_comboadd_items("name_items2", this.combo_add_items.Text);
            //}
            //catch (Exception ex)
            //{
            //    db.log_error(string.Concat((object)ex));
            //}
        }
        private void save_barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            perform_save();
        }
        private void New_barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("هل تريد سند جديد!!؟؟؟؟ ", "رسال جديد مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
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
            if (e.ColumnIndex == 0)
            {
                if (dgv.Rows.Count < 0) return;
                frm_item f = new frm_item();
                f.Show();
                f.txt_code_items.Text = dgv.CurrentRow.Cells["code_items"].Value + "";
                f.txt_code_items.Select();
                f.txt_name_items.Select();
            }
            if (e.ColumnIndex == 2)
            {
                pos.frm_items_card f = new pos.frm_items_card();
                f.Show();
                f.combo_code_items.Text = dgv.CurrentRow.Cells["code_items"].Value + "";
                f.btn_serchinv.PerformClick();
            }
        }
        private void combo_unit_SelectedIndexChanged(object sender, EventArgs e) //select unite
        {
            lbl_f_unite.Text = (db.GetData("select (unite) from unite where name_unite='" + combo_unit.Text + "'").Rows[0][0].ToString());

        }
        private void btn_add_exp_Click(object sender, EventArgs e)//add exp_Date in dgv 
        {
            if (!Convert.ToBoolean(db.GetData("select [exp] from items where code_items='" + this.dgv.CurrentRow.Cells["code_items"].Value + "'").Rows[0][0].ToString()))
                return;
            this.dgv.CurrentRow.Cells["exp_date"].Value = (object)this.dt_exp.Text;
            this.dgv.CurrentRow.Cells["add_items1"].Value = (object)2;
          



        }
        private void btn_del_exp_Click(object sender, EventArgs e)//clear exp_date from dgv
        {
            dgv.CurrentRow.Cells["exp_date"].Value = "";

        }
        private void combo_exp_SelectedIndexChanged(object sender, EventArgs e)//to know expir date 
        {
            if (this.dgv.Rows.Count == 0)
                return;
            //all_comb.load_exp_date(dt_exp.ToString(), this.dgv.CurrentRow.Cells["code_items"].Value.ToString(), this.combo_wars.Text);
            all_comb.load_exp_date(combo_expcost, this.dgv.CurrentRow.Cells["code_items"].Value.ToString(), this.combo_wars.Text);

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
            dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "هل تريد الحذف!!؟؟؟؟ ", "رسال حذف مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);


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

        private void frm_sale_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (lockDocument) return;
            if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Control)
            {
                perform_save();
            }
            if (e.KeyCode == Keys.N && Control.ModifierKeys == Keys.Control)
            {
                DialogResult dr;
                dr = MessageBox.Show("هل تريد عمل سند جديد!!؟؟؟؟ ", "رسال جديد مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.OK)
                {
                    new_file();
                }

            }
            if (e.KeyCode == Keys.Delete && Control.ModifierKeys == Keys.Control)
            {
                DialogResult dr;
                dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "هل تريد حذف السند!!؟؟؟؟ ", "رسال حذف مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);


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
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    // return;
                    code_items_a = "";
                    string str1 = txt_barcode.Text;
                    // if (str1.Contains("+") == true)
                    str1 = Regex.Replace(str1, "[+]+", "").Remove(Regex.Replace(str1, "[+]+", "").Length - 1, 1);
                    code_items_a = str1;
                    code_items_a = db.GetData("select isnull(max(code_items),null) from items where code_items='" + str1 + "'").Rows[0][0].ToString();
                   // string type = db.GetData("select isnull(max(type),null) from items where code_items='" + str1 + "'").Rows[0][0].ToString();
                    string menu = db.GetData("select isnull(max(menu),null) from items where code_items='" + str1 + "'").Rows[0][0].ToString();

                    if (code_items_a == "")
                        code_items_a = db.GetData("select isnull(max(code_items),null) from barcode where barcode='" + txt_barcode.Text + "'").Rows[0][0].ToString();
                    if (code_items_a == "")
                    {
                        XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "لايوجد صنف  ..يجب تكويد الصنف", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.txt_barcode.Clear();
                    }

                    else if ( menu == "1")
                    {
                        XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, " الصنف خدمي او الصنف مطاعم ولايمكن استخدامة", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.txt_barcode.Clear();
                    }
                    else
                    {
                        this.name_items_a = !this.chk_search_lang.Checked ? db.GetData("select isnull(max(name_items2),0) from items where code_items='" + this.code_items_a + "'").Rows[0][0].ToString() : db.GetData("select isnull(max(name_items),0) from items where code_items='" + this.code_items_a + "'").Rows[0][0].ToString();
                        this.name_unite_a = db.GetData("select isnull(max(name_unite),0) from items where code_items='" + this.code_items_a + "'").Rows[0][0].ToString();
                        this.unit1 = db.GetData("select isnull(max(unit1),0) from items where code_items='" + this.code_items_a + "'").Rows[0][0].ToString();
                        this.price_items_a = db.GetData("select isnull(max(price_buy),0) from items where code_items='" + this.code_items_a + "'").Rows[0][0].ToString();
                        this.discount_a = db.GetData("select isnull(max(discount_buy),0) from items where code_items='" + this.code_items_a + "'").Rows[0][0].ToString();
                        this.taxes_a = db.GetData("select isnull(max(taxes),0) from items where code_items='" + this.code_items_a + "'").Rows[0][0].ToString();
                        this.type_a = db.GetData("select isnull(max([type]),0) from items where code_items='" + this.code_items_a + "'").Rows[0][0].ToString();
                        try
                        {
                            this.exp_a = db.GetData("select [exp] from items where code_items='" + this.code_items_a + "'").Rows[0][0].ToString();
                        }
                        catch (Exception ex)
                        {
                            db.log_error(string.Concat((object)ex));
                        }
                        lbl_code_items.Text = "1";
                        this.add_items_in_dgv();
                        this.txt_barcode.Clear();
                        ((Control)this.txt_barcode).Select();
                    }

                }

            }
            catch (Exception)
            {


            }

        }
        //===========================================================NAvigation
        private void First_barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!(db.GetData("select min(convert(int,(right(sale_hd_id,LEN(sale_hd_id)-3)))) from sale_hd where  code_book='" + this.txt_code_book.Text + "' ").Rows[0][0].ToString() != ""))
                    return;
                this.txt_serial_string.Text = db.GetData("select min(convert(int,(right(sale_hd_id,LEN(sale_hd_id)-3)))) from sale_hd where  code_book='" + this.txt_code_book.Text + "' ").Rows[0][0].ToString();
                this.bode_of_navigation(txt_code_book.Text + txt_serial_string.Text, this.txt_code_book.Text);
            }
            catch (Exception ex)
            {
                db.log_error(string.Concat((object)ex));
            }
        }
        private void Last_barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!(db.GetData("select max(convert(int,(right(sale_hd_id,LEN(sale_hd_id)-3)))) from sale_hd where  code_book='" + this.txt_code_book.Text + "'").Rows[0][0].ToString() != ""))
                    return;
                this.txt_serial_string.Text = db.GetData("select max((convert(int,(right(sale_hd_id,LEN(sale_hd_id)-3))))) from sale_hd where  code_book='" + this.txt_code_book.Text + "'").Rows[0][0].ToString();
                this.bode_of_navigation(txt_code_book.Text + txt_serial_string.Text, this.txt_code_book.Text);
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
                db.log_error(string.Concat((object)ex));
            }
        }
        private void Back_barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!(db.GetData("select min(convert(int,(right(sale_hd_id,LEN(sale_hd_id)-3)))) from sale_hd  where code_book='" + this.txt_code_book.Text + "'").Rows[0][0].ToString() != ""))
                    return;
                this.edit = true;
                new DataTable().Rows.Clear();
                string s1 = db.GetData("select min(convert(int,(right(sale_hd_id,LEN(sale_hd_id)-3)))) from sale_hd  where code_book='" + this.txt_code_book.Text + "'").Rows[0][0].ToString();
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
                if (!(db.GetData("select max(convert(int,(right(sale,LEN(sale_hd_id)-3)))) from sale_hd  where code_book='" + this.txt_code_book.Text + "'").Rows[0][0].ToString() != ""))
                    return;
                this.edit = true;
                new DataTable().Rows.Clear();
                string s1 = db.GetData("select max(convert(int,(right(sale_hd_id,LEN(sale_hd_id)-3)))) from sale_hd  where code_book='" + this.txt_code_book.Text + "'").Rows[0][0].ToString();
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
        //==========================================================END=NAvigation
        private void button2_Click(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Maximum = prog;
            progressBar1.Value = e.ProgressPercentage;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            v.test_sale = txt_serial_string.Text;
            sales.test_sale f = new sales.test_sale();
            f.Show();
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("select acc_num,acc_name,depit,credit,attachnamebook,attachtext from entry where attachno='" + txt_serial_string.Text + "'or attachno2='" + txt_serial_string.Text + "'", dt);
            dgv_entry.DataSource = dt;
        }
        private void pay_barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_payable f = new frm_payable();
            f.ShowDialog();
        }
        private void recev_barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

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
            v.sale_amount = lbl_incloud_taxes.Text;
            v.privent_select_vcs = false;
            frm_recevable f = new frm_recevable();
            f.ShowDialog();

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
        //load_compoboxes
        private void combo_vcs_Click(object sender, EventArgs e)
        {
            if (!this.Switch_vcs.BindableChecked)
                all_comb.load_vcs_customer(this.combo_vcs);
            else
                all_comb.load_vcs(this.combo_vcs);

        }
        private void combo_vsc_codetree_Click(object sender, EventArgs e)
        {
            all_comb.load_code_vcs(combo_vsc_codetree);

        }
        private void combo_add_items_Click(object sender, EventArgs e)
        {


        }
        private void printer_previeew_barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraReport xtraReport = XtraReport.FromFile("forms\\sale.repx", true);
            xtraReport.Parameters["parameter1"].Value = (object)this.txt_serial_string.Text;
            xtraReport.Parameters["parameter1"].Visible = false;
            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
        }
        private void printer_direct_barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraReport xtraReport = XtraReport.FromFile("forms\\sale.repx", true);
            xtraReport.Parameters["parameter1"].Value = (object)this.txt_serial_string.Text;
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
            if (this.edit)
            {
                this.btn_barcode.Enabled = true;
                pos.frm_barcode f = new pos.frm_barcode();
                f.Show();
            }
            else
                this.btn_barcode.Enabled = false;
        }
        private void Chk_search_lang_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk_bal_ware.Checked)
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
            if (this.chk_search_lang.Checked)
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
            this.lbl_name_wares.Text = db.GetData("select isnull(max([ware_name]),0) from wares_acc where id_ware='" + this.combo_wars.Text + "'").Rows[0][0].ToString();

        }

        private void btn_find_items_Click(object sender, EventArgs e)
        {
            //items have qty 
            if (chk_bal_ware.Checked==true)
            {
                all_comb.load_items_for_sale_have_qty(combo_add_items);
                combo_add_items.Text = "";
            }
            else
            {
                all_comb.load_items_for_sale(combo_add_items);
                combo_add_items.Text = "";
            }

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



        private void button1_Click_1(object sender, EventArgs e)
        {

            //get tot cost (COGS)
            for (int x = 0; x < dgv.Rows.Count; x++) //loop NO.2
            {
                string cost = db.GetData("select isnull((sum(cost)),0) from wares where code_items='" + dgv.Rows[x].Cells["code_items"].Value.ToString() + "' and id_ware='" + dgv.Rows[x].Cells["id_ware"].Value.ToString() + "'").Rows[0][0].ToString();
                if (Convert.ToDouble(cost) == 0 && dgv.Rows[x].Cells["type"].Value.ToString() != "2")
                {
                    MessageBox.Show("cost = 0  " + "  كود الصنف " + dgv.Rows[x].Cells["code_items"].Value.ToString());
                }
                dgv_cost.Rows.Add(dgv.Rows[x].Cells["code_items"].Value.ToString(), dgv.Rows[x].Cells["id_ware"].Value.ToString(), (Convert.ToDecimal(cost) * Convert.ToDecimal(dgv.Rows[x].Cells["qty"].Value.ToString())));
            }
            decimal tot_cost = 0;
            for (int tot = 0; tot < dgv_cost.Rows.Count; tot++)
            {
                tot_cost = tot_cost + Convert.ToDecimal(dgv_cost.Rows[tot].Cells["cost_c"].Value);
            }
            lbl_tot_cost.Text = Math.Round(tot_cost) + "";
        }

        private void combo_add_items_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '\''))
            {
                e.Handled = true;
            }
        }

        private void txt_serial_string_Leave(object sender, EventArgs e)
        {
            try
            {

               
                this.bode_of_navigation( this.txt_serial_string.Text, this.txt_code_book.Text);
            }
            catch (Exception ex)
            {
                db.log_error(string.Concat((object)ex));
            }
        }

      

        private void lbl_state_vcs_bal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (lbl_state_vcs_bal.Caption != "")
            //{
            //    XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\stat_gl.repx", true);
            //    //xtraReport.Parameters["parameter2"].Value = txt_serial_string.Text;
            //    xtraReport.Parameters["parameter2"].Value = combo_vsc_codetree.Text;
            //    xtraReport.Parameters["parameter2"].Visible = false;
            //    XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
            //}
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

        private void Switch_vcs_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

     

        private void btn_add_items_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm_item f = new frm_item();
            f.Show();
        }
        //==============>>>>>>>>>>>>>>>>>>>>>search screen ---------------------------------------------------------
        //--------------------------------------------------------------------
        private void f_barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (group_find.Visible == false)
            //{
            //    group_find.Visible = true;
            //}
            //else
            //{
            //    group_find.Visible = false;

            //}
        }

        private void combo_document_f_Click(object sender, EventArgs e)
        {
            //all_comb.load_invoice_number_sale(combo_document_f);

        }

        private void combo_vcs_name_f_Click(object sender, EventArgs e)
        {
            //all_comb.load_name_vcs(combo_vcs_name_f);

        }

        private void combo_vcs_name_f_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //lbl_vcs_code_f.Text = db.GetData("select vcs_code from vcs where vcs_name ='" + combo_vcs_name_f.Text + "'").Rows[0][0].ToString();

            }
            catch (Exception)
            {


            }
        }

        private void btn_searchin_group_f1_Click(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //db.GetData_DGV("select incloud_taxes,code_book,sale_hd_id,vcs_code,vcs_name,date_P,name_book from sale_hd where sale_hd_id='" + combo_document_f.Text + "'", dt);
            //dgv_f.DataSource = dt;
        }

       

      

        private void dgv_f_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dgv_f_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                //bode_of_navigation(dgv_f.CurrentRow.Cells["sale_hd_id_f"].Value.ToString(), dgv_f.CurrentRow.Cells["code_book_f"].Value.ToString());
                //group_find.Visible = false;

            }
            catch (Exception)
            {


            }
        }

     

        private void txt_serial_string_DoubleClick(object sender, EventArgs e)
        {
            v.search_screen = "sale";
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
        public bool lockDocument = false;
        private void lock_document()
        {
            save_barButtonItem1.Enabled = false;
            btn_delete_file.Enabled = false;
            pay_barButtonItem1.Enabled = false;
            recev_barButtonItem3.Enabled = false;
            lockDocument = true;
        }
        private void sendEinv()
        {
            lock_document();
            db.Run("update sale_hd set state_e='0' where sale_hd_id='" + txt_serial_string.Text + "' ");
        }

        //======Einvoice===========================
        private void btn_seand_einvoice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string doc = db.GetData("select isnull(max(sale_hd_id),0) from sale_hd where sale_hd_id='" + txt_serial_string.Text + "'").Rows[0][0] + "";
            string state_E = db.GetData("select isnull(max(state_e),'') from sale_hd where sale_hd_id='" + txt_serial_string.Text + "'").Rows[0][0] + "";
            //invoce not found
            if (doc == "0") return;
            //1-if state =0  in progress =lock
            if (state_E == "0") { lock_document(); return; }
            //2-if state =1 had send to portal  =lock
            if (state_E == "1"){ lock_document(); return; }
            //3-if state =3   error you have send invoice ageen
            if (state_E == "3") { sendEinv(); return; }
            //4-if state =null  update state by 0 and lock documnet
            if (state_E == "1") { sendEinv(); return; }


            //db.create_txt_inEinv("hellwo", json);
        }
    }

 
}

