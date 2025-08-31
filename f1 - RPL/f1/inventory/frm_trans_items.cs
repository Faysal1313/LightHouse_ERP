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
using System.Text.RegularExpressions;

namespace f1.inventory
{
    public partial class frm_trans_items : DevExpress.XtraEditors.XtraForm
    {
        public frm_trans_items()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon("f1.exe");
            db.Open();
        }
        bool edit = false;
        bool add_permission = true;
        bool edit_permission = true;
        int prog = 0;
        string numBook_entry = "";
        string numBook = "";
        string error = "";
        private int num = 0;
        private int num_entry = 0;
        private void frm_trans_items_Load(object sender, EventArgs e)
        {
            all_comb.load_wares(combo_wars);
            all_comb.load_wares(combo_wars2);
            combo_vcs.Text = null;
            combo_vsc_codetree.Text = null;
         //   dt_piker.MinDate = new DateTime(v.current_yaer, 01, 01);
         //   dt_piker.MaxDate = new DateTime(v.current_yaer, 12, 31);
            cls_book.loadbook(comb_code_name, "سند تحويل مخزني");
            cls_book.load_from_term(combo_type, "سند تحويل مخزني");
            dt_piker.Text = DateTime.Now.ToString("yyyy/MM/dd");
            combo_type.Text = "";
            dgv_term.Rows.Clear();
            lbl_tot_befor.Text = "0";
            lbl_discount.Text = "0";
            lbl_tot_after_dis.Text = "0";
            lbl_incloud_taxes.Text = "0";
            lbl_serial_P.Text = "0";
            progressBar1.Visible = false;



            combo_exp.Visible = false;
            btn_add_exp.Visible = false;
            lbl_exp.Visible = false;
            dt_exp.Visible = false;
            lbl_knowexp.Visible = false;
            btn_del_exp.Visible = false;
            dgv_readonly();
            all_comb.load_curracne(combo_currance);
            /////////////////permission
            lbl_user_code.Text = v.usercode;
            lbl_user_name.Text = v.username;
            load_permission();
            /////////////////load police
            if (v.expiry == false)
            {
                dgv.Columns["exp_date"].Visible = false;
                btn_add_exp.Visible = false;
                lbl_exp.Visible = false;
                dt_exp.Visible = false;
                labelControl12.Visible = false;
                combo_expcost.Visible = false;
                btn_cost_exp.Visible = false;
            }
           
            if (v.barcode == false)
            {
                lbl_barcode.Visible = false;
                txt_barcode.Visible = false;
            }
            if (v.currance == false)
            {
                lbl_currance.Visible = false;
                btn_currance.Visible = false;
                combo_currance.Visible = false;
                txt_f_currance.Visible = false;
            }
            if (v.taxes == false)
            {
                dgv.Columns["taxes_value"].Visible = false;
                dgv.Columns["incloud_taxes"].Visible = false;
                dgv.Columns["taxes"].Visible = false;

                lbl_incloud_taxes.Visible = false;
                lbl_taxes_values.Visible = false;
                labelControl16.Visible = false;
                labelControl19.Visible = false;
            }
            //printer
            printer_dirict_barButtonItem11.Enabled = false;
            printer_prevew_barButtonItem10.Enabled = false;
        }
        //==============================================fanction
        private void select_type_entry()
        {
            dgv_term.Rows.Clear();

            ////book loaded:-
            ////cls_book.load_from_terms(comb_type);
            ////=============insert in dgv term 
           // string term_id, rootid, rootname, depit, credit;

            //int count = Convert.ToInt32(db.GetData("select count(term_id) from term where term_id='" + combo_type.Text + "' and cat_book='سند فاتوره مشتريات'").Rows[0][0].ToString());
            //code_entry = (db.GetData("select code_entry from term where term_id='" + combo_type.Text + "' and cat_book='سند فاتوره مشتريات'").Rows[0][0].ToString());
            //string bookname_entry = (db.GetData("select bookname_entry from term where term_id='" + combo_type.Text + "' and cat_book='سند فاتوره مشتريات'").Rows[0][0].ToString());
            //int c = 0;
            //==================
            // book loaded:-
            // cls_book.load_from_terms(combo_type);
            // =============insert in dgv term 
            string term_id, rootid1, rootname1, depit1, credit1, type_acc1, sort_1, rootlevel1;
            string rootid2, rootname2, depit2, credit2, type_acc2, sort_2, rootlevel2;


            rootid2 = db.GetData("select rootid from wares_acc where id_ware='" + combo_wars2.Text + "' ").Rows[0][0].ToString();
            rootname2 = db.GetData("select rootname from wares_acc where id_ware='" + combo_wars2.Text + "' ").Rows[0][0].ToString();
            depit2 = db.GetData("select depit from term where cat_book='سند تحويل مخزني' and term_id='" + combo_type.Text + "'").Rows[0][0].ToString();
            credit2 = db.GetData("select credit from term where cat_book='سند تحويل مخزني' ").Rows[1][0].ToString();
            type_acc2 = db.GetData("select sort from tree where rootid='" + rootid2 + "' ").Rows[0][0].ToString();
            rootlevel2 = db.GetData("select rootlevel from tree where rootid='" + rootid2 + "' ").Rows[0][0].ToString();

            sort_2 = "1";
            //==============

            rootid1 = db.GetData("select rootid from wares_acc where id_ware='" + combo_wars.Text + "' ").Rows[0][0].ToString();
            rootname1 = db.GetData("select rootname from wares_acc where id_ware='" + combo_wars.Text + "' ").Rows[0][0].ToString();
            depit1 = db.GetData("select depit from term where cat_book='سند تحويل مخزني' and term_id='" + combo_type.Text + "'").Rows[0][0].ToString();
            credit1 = db.GetData("select credit from term where cat_book='سند تحويل مخزني' ").Rows[1][0].ToString();
            type_acc1 = db.GetData("select sort from tree where rootid='" + rootid1 + "' ").Rows[0][0].ToString();
            rootlevel1 = db.GetData("select rootlevel from tree where rootid='" + rootid1 + "' ").Rows[0][0].ToString();

            sort_1 = "1";


            //    //==================================================

            //========fill field tot or tot_bef or discount=======
            if (depit1 == "tot_befor")
            {
                depit1 = lbl_tot_befor.Text;
            }
            else if (depit1 == "tot_after_dis")
            {
                depit1 = lbl_tot_after_dis.Text;
            }
            else if (depit1 == "discount")
            {
                depit1 = lbl_discount.Text;
            }
            else if (depit1 == "incloud_taxes")
            {
                depit1 = lbl_incloud_taxes.Text;
            }
            else if (depit1 == "vat_add")
            {
                depit1 = lbl_vat_add.Text;
            }
            else if (depit1 == "taxtes")
            {
                depit1 = lbl_taxes_values.Text;
            }
            else
            {
                depit1 = "0";
            }
            if (credit1 == "tot_befor")
            {
                credit1 = lbl_tot_befor.Text;
            }
            else if (credit1 == "tot_after_dis")
            {
                credit1 = lbl_tot_after_dis.Text;
            }
            else if (credit1 == "discount")
            {
                credit1 = lbl_discount.Text;
            }
            else if (credit1 == "incloud_taxes")
            {
                credit1 = lbl_incloud_taxes.Text;
            }
            else if (credit1 == "taxtes")
            {
                credit1 = lbl_taxes_values.Text;
            }
            else if (credit1 == "vat_add")
            {
                credit1 = lbl_vat_add.Text;
            }
            else
            {
                credit1 = "0";
            }
            //=======================================
            if (depit2 == "tot_befor")
            {
                depit2 = lbl_tot_befor.Text;
            }
            else if (depit2 == "tot_after_dis")
            {
                depit2 = lbl_tot_after_dis.Text;
            }
            else if (depit2 == "discount")
            {
                depit2 = lbl_discount.Text;
            }
            else if (depit2 == "incloud_taxes")
            {
                depit2 = lbl_incloud_taxes.Text;
            }
            else if (depit2 == "vat_add")
            {
                depit2 = lbl_vat_add.Text;
            }
            else if (depit2 == "taxtes")
            {
                depit2 = lbl_taxes_values.Text;
            }
            else
            {
                depit2 = "0";
            }
            if (credit2 == "tot_befor")
            {
                credit2 = lbl_tot_befor.Text;
            }
            else if (credit2 == "tot_after_dis")
            {
                credit2 = lbl_tot_after_dis.Text;
            }
            else if (credit2 == "discount")
            {
                credit2 = lbl_discount.Text;
            }
            else if (credit2 == "incloud_taxes")
            {
                credit2 = lbl_incloud_taxes.Text;
            }
            else if (credit2 == "taxtes")
            {
                credit2 = lbl_taxes_values.Text;
            }
            else if (credit2 == "vat_add")
            {
                credit2 = lbl_vat_add.Text;
            }
            else
            {
                credit2 = "0";
            }
            ////////////////////  =========================================================
            dgv_term.Rows.Add(0, rootid2, rootname2, depit2, 0, rootlevel2, 0, sort_2, type_acc2);
            dgv_term.Rows.Add(0, rootid1, rootname1, 0, credit1, rootlevel1, 0, sort_1, type_acc1);

           
            //============end of terms   
     
        }
        private void save()
        {
            if (combo_wars.Text==combo_wars2.Text)
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "لايمكن تحويل المخزن في نفسه", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
             //0)cheak qty and exp 
            //_______________________
            string qty_old = "0";
            string qty_old_exp = "0";
            string qty_current = "0";
            string qty_new = "0";
            for (int i = 0; i < dgv.Rows.Count; i++) //loop NO.1
            {
                qty_old = db.GetData("select isnull((sum(qty)),0) from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware='" + combo_wars.Text + "'").Rows[0][0].ToString();
                qty_current = ((Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value)) * (Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value))).ToString();
                qty_new = (Convert.ToDecimal(qty_old) - (Convert.ToDecimal(qty_current))).ToString();
                if (Convert.ToDecimal(qty_new) < 0 && dgv.Rows[i].Cells["type"].Value.ToString() != "2")
                {
                    MessageBox.Show("لا يمكن الرصيد يكون بالسالب  " + " كود الصنف : " + dgv.Rows[i].Cells["code_items"].Value);
                    return;
                }

                else
                {
                    if (dgv.Rows[i].Cells["exp"].Value.ToString() == "True")
                    {
                        qty_old_exp = db.GetData("select isnull((sum(qty)),0) from exp_date where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware='" + combo_wars.Text + "' and exp_date='" + Convert.ToDateTime(dgv.Rows[i].Cells["exp_date"].Value).ToString("MM-dd-yyyy") + "'").Rows[0][0].ToString(); if (qty_old_exp == "") qty_old_exp = "0";
                        //   MessageBox.Show(qty_old_exp + "  " + dgv.Rows[i].Cells["code_items"].Value);
                        if (Convert.ToDecimal(qty_old_exp) < Convert.ToDecimal(qty_current))
                        {
                            MessageBox.Show("لا يمكن رصيد من تاريخ الصالحيه ...شوف تاريخ صلاحيه تاني ");
                            return;
                        }
                    }
                }
            }
            //=========================================
            // try
            {
                progressBar1.Visible = true;
                calc_all();
                //cheak is exp_date entry
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if (dgv.Rows[i].Cells["exp"].Value.ToString() == "True" && dgv.Rows[i].Cells["exp_date"].Value.ToString() == "")
                    {
                        MessageBox.Show("يجب ادخال تاريخ صلاحيه للصنف ");
                        return;
                    }
                }

                //1)select type of entry and insert entry :=
                //_______________________________________________
                select_type_entry();
                //get only number for one user Entry
                //txt_entry_string.Text = txt_code_entry_type.Text + txt_code_entry.Text;
                //cls_book.selectbook("entry_hd", "سند قيد", txt_code_entry_type.Text, txt_code_entry, "code_entry");
                //txt_entry_string.Text = txt_code_entry_type.Text + txt_code_entry.Text;

                string code_entry_term = (db.GetData("select code_entry from term where term_id='" + combo_type.Text + "' ").Rows[0][0].ToString());
                cls_book.Generat_numBooknum("entry", code_entry_term, ref numBook_entry, ref error, ref num_entry);
                txt_entry_string.Text = numBook_entry;

                //get only number for one user trans
                txt_code_book.Text = db.GetData("select code_book from book where name_book='" + comb_code_name.Text + "'").Rows[0][0].ToString();
                //cls_book.selectbook("trans_hd", "سند تحويل مخزني", txt_code_book.Text, txt_serial, "trans_hd_id");
                //txt_serial_string.Text = txt_code_book.Text + txt_serial.Text;


                cls_book.Generat_numBooknum("trans_hd", txt_code_book.Text, ref numBook, ref error, ref num);
                txt_serial_string.Text = numBook;

                db.Run("insert into entry_hd ([code_entry],code_book) values ('" + txt_entry_string.Text + "','" + txt_code_entry_type.Text + "')");
                //entry_hd
                for (int z = 0; z < dgv_term.Rows.Count; z++)
                {
                    //  cls_book.selectbook("entry", "سند قيد", txt_code_book.Text, txt_serial, "code_entry");
                    //  txt_serial_string.Text = txt_code_book.Text + txt_serial.Text;
                    db.Run("insert into entry(  [code_entry]                           ,    acc_num                                                   ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                                          ,   type_acc                                                            , sort                                                       ,             depit                                                             ,                credit                                                   ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext,num_book )values('" +
                                              txt_entry_string.Text + "'            ,'" + dgv_term.Rows[z].Cells[1].Value.ToString() + "'     ,'" + dgv_term.Rows[z].Cells[2].Value.ToString() + "'               ,  '" + dgv_term.Rows[z].Cells["rootlevel_"].Value.ToString() + "'    ,  '" + dgv_term.Rows[z].Cells["rootlevel_name_"].Value.ToString() + "', '" + dgv_term.Rows[z].Cells["type_acc_"].Value.ToString() + "'       ,  '" + dgv_term.Rows[z].Cells["sort_"].Value.ToString() + "'  ,  '" + Convert.ToDecimal(dgv_term.Rows[z].Cells[3].Value.ToString()) * Convert.ToDecimal(txt_f_currance.Text) + "'      ,'" + Convert.ToDecimal(dgv_term.Rows[z].Cells[4].Value.ToString()) * Convert.ToDecimal(txt_f_currance.Text) + "' ,'" + txt_name_book_type.Text + "','" + txt_code_entry_type.Text + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + txt_serial_string.Text + "','" + txt_code_book.Text + "','" + comb_code_name.Text + "','" + txt_note.Text + "','"+num_entry+"')");
                }
                // 2) save header:-
                //________________________
                db.Run("insert into trans_hd(trans_hd_id ,            code_book               ,name_book                       ,   vcs_code,                       vcs_name           ,           date_P                               ,         term           ,         tot_befor                    ,    discount              , tot_after_dis                          ,           taxes            ,incloud_taxes               ,    id_ware                  ,id_ware2  ,code_entry              ,book_name_entry                  ,code_book_entry                       ,note_txt                ,user_name               ,user_code,lock,currance,f_currance,due_date,num_book)values('"
                                                + txt_serial_string.Text + "', '" + txt_code_book.Text + "' ,'" + comb_code_name.Text + "','" + combo_vsc_codetree.Text + "','" + combo_vcs.Text + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + combo_type.Text + "',    '" + lbl_tot_befor.Text + "'    ,'" + lbl_discount.Text + "' ,      '" + lbl_tot_after_dis.Text + "' ,  '" + lbl_taxes_values.Text + "' ,'" + lbl_incloud_taxes.Text + "','" + combo_wars.Text + "','"+combo_wars2.Text+"','" + txt_code_entry.Text + "','" + txt_name_book_type.Text + "','" + txt_code_entry_type.Text + "','" + txt_note.Text + "','" + lbl_user_name.Text + "','" + lbl_user_code.Text + "','0','" + combo_currance.Text + "','" + txt_f_currance.Text + "','" + dt_due_date.Value.ToString("MM-dd-yyyy") + "','"+num+"')");
                //loop detals:=
                prog = dgv.Rows.Count;//to know progras bar 

                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    //3)save detals:=
                    //___________________
                    //A)items is not expiry
                    if (dgv.Rows[i].Cells["exp"].Value.ToString() == "False")
                    {
                        db.Run("insert into trans_dt(trans_hd_id ,         code_book ,                       name_book         ,                       code_items              ,                        name_items             ,                                         qty             ,                                      item_price                  ,                                         tot_bef             ,                                         discount             ,                                         tot_after_dis             ,                                        taxes              ,                                        incloud_taxes                 ,                                          taxes_value             ,      id_ware         ,id_ware2,                         f_unite,                                   name_unite                                           ,no,                                                           [exp]              ,            exp_date                        ,[type],serial_P, tot_after_dis_forex) values('" +
                                                 txt_serial_string.Text + "','" + txt_code_book.Text + "', '" + lbl_comb_code_name.Text + "','" + dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["item_price"].Value) + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_bef"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["discount"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["taxes"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["incloud_taxes"].Value) + "','" + Convert.ToDecimal(dgv.Rows[i].Cells["taxes_value"].Value) + "','" + combo_wars.Text + "','"+combo_wars2.Text+"','" + (dgv.Rows[i].Cells["f_unite"].Value) + "','" + (dgv.Rows[i].Cells["name_unite"].Value) + "','" + (dgv.Rows[i].Cells["no"].Value) + "','" + Convert.ToBoolean((dgv.Rows[i].Cells["exp"].Value)) + "',            Null              ,'" + (dgv.Rows[i].Cells["type"].Value) + "','" + lbl_serial_P.Text + "','" + Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) * Convert.ToDecimal(txt_f_currance.Text) + "')");
                    }
                    else
                    {
                        //B)items is expiry
                        db.Run("insert into trans_dt(trans_hd_id ,         code_book ,                       name_book         ,                       code_items              ,                        name_items             ,                                         qty             ,                                      item_price                  ,                                         tot_bef             ,                                         discount             ,                                         tot_after_dis             ,                                        taxes              ,                                        incloud_taxes                 ,                                          taxes_value             ,      id_ware        ,id_ware2 ,                         f_unite,                                   name_unite                                           ,no,                                                           [exp]              ,            exp_date                        ,[type],serial_P,tot_after_dis_forex) values('" +
                                                 txt_serial_string.Text + "','" + txt_code_book.Text + "', '" + lbl_comb_code_name.Text + "','" + dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["item_price"].Value) + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_bef"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["discount"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["taxes"].Value) + ",'" + Convert.ToDecimal(dgv.Rows[i].Cells["incloud_taxes"].Value) + "','" + Convert.ToDecimal(dgv.Rows[i].Cells["taxes_value"].Value) + "','" + combo_wars.Text + "','"+combo_wars2.Text+"','" + (dgv.Rows[i].Cells["f_unite"].Value) + "','" + (dgv.Rows[i].Cells["name_unite"].Value) + "','" + (dgv.Rows[i].Cells["no"].Value) + "','" + Convert.ToBoolean((dgv.Rows[i].Cells["exp"].Value)) + "','" + Convert.ToDateTime(dgv.Rows[i].Cells["exp_date"].Value).ToString("MM-dd-yyyy") + "','" + (dgv.Rows[i].Cells["type"].Value) + "','" + lbl_serial_P.Text + "','" + Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) * Convert.ToDecimal(txt_f_currance.Text) + "')");
                    }
                    //update ware 
                    //A)update ware qty:-
                    //________________________
                    if (dgv.Rows[i].Cells["type"].Value.ToString() == "1")
                    {
                        decimal qty_ware_old1 = Convert.ToDecimal(db.GetData("select isnull((sum(qty)),0) from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and id_ware='" + combo_wars.Text + "'").Rows[0][0].ToString());
                        decimal qty_ware_old2 = Convert.ToDecimal(db.GetData("select isnull((sum(qty)),0) from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and id_ware='" + combo_wars2.Text + "'").Rows[0][0].ToString());

                        decimal qty_bal_1 = (Convert.ToDecimal(qty_ware_old1)) - ((Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value)) * (Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value)));
                        decimal qty_bal_2 = (Convert.ToDecimal(qty_ware_old2)) + ((Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value)) * (Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value)));

                        db.Run("update wares set qty =(" + Convert.ToDecimal(qty_bal_1) + ") where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware='" + combo_wars.Text + "'");
                        db.Run("update wares set qty =(" + Convert.ToDecimal(qty_bal_2) + "  ) where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware='" + combo_wars2.Text + "'");



                        //cost:=
                        decimal cost_ware_old1 = Convert.ToDecimal(db.GetData("select isnull((sum(cost)),0) from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and id_ware='" + combo_wars.Text + "'").Rows[0][0].ToString());
                        decimal cost_ware_old2 = Convert.ToDecimal(db.GetData("select isnull((sum(cost)),0) from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and id_ware='" + combo_wars2.Text + "'").Rows[0][0].ToString());

                      //  decimal cost_bal_1 = (Convert.ToDecimal(cost_ware_old1)) - ((Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value)) * (Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value)));
                       // decimal cost_bal_1 = (Convert.ToDecimal(cost_ware_old1)) - (Convert.ToDecimal(cost_ware_old2)); if (cost_bal_1 < 0) cost_bal_1=cost_bal_1 * -1;
                       // decimal cost_bal_2 = (Convert.ToDecimal(cost_ware_old2)) + (Convert.ToDecimal(cost_ware_old1)); if (cost_bal_2 < 0) cost_bal_2 = cost_bal_2 * -1;
                        
                        db.Run("update wares set cost =(" + cost_ware_old1 + ") where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware='" + combo_wars.Text + "'");
                        db.Run("update wares set cost =(" + cost_ware_old1 + ") where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware='" + combo_wars2.Text + "'");
                        // maximum

                        decimal demand_maximum = Convert.ToDecimal(db.GetData("select isnull(max(demand_maximum),0)  from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and id_ware='" + combo_wars2.Text + "'").Rows[0][0].ToString());
                        Boolean maximum = Convert.ToBoolean(db.GetData("select demand_maximum_bit  from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and id_ware='" + combo_wars2.Text + "'").Rows[0][0].ToString());
                        if (maximum == true)
                        {
                            if (Convert.ToDecimal(qty_bal_2) >= demand_maximum)
                            {
                                db.Run("insert into center(code_items,date,note,wares) values ('" + dgv.Rows[i].Cells["code_items"].Value + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','Items that have reached the demand maximum  ','" + combo_wars2.Text + "')");
                            }
                        }
                        
                        //c)insert exp_date cost:-
                        //_______________________
                        if (dgv.Rows[i].Cells["exp"].Value.ToString() == "True")
                        {
                            db.Run("insert into exp_date (code_items,name_items,exp_date,qty,cost,id_ware,code,code_book) values('" + dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "','" + Convert.ToDateTime(dgv.Rows[i].Cells["exp_date"].Value).ToString("MM-dd-yyyy") + "','" + (Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value)) * (Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value))*-1 + "','" + dgv.Rows[i].Cells["tot_after_dis"].Value + "','" + combo_wars.Text + "','" + txt_serial_string.Text + "','" + txt_code_book.Text + "')");
                            db.Run("insert into exp_date (code_items,name_items,exp_date,qty,cost,id_ware,code,code_book) values('" + dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "','" + Convert.ToDateTime(dgv.Rows[i].Cells["exp_date"].Value).ToString("MM-dd-yyyy") + "','" + (Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value)) * (Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value)) + "','" + dgv.Rows[i].Cells["tot_after_dis"].Value + "','" + combo_wars2.Text+ "','" + txt_serial_string.Text + "','" + txt_code_book.Text + "')");

                        }
                    }


                    //insert into trans_items_trans 
                    if (combo_vsc_codetree.Text == "")
                    {
                        combo_vsc_codetree.Text = "";
                        combo_vcs.Text = "";
                    }
                    if (dgv.Rows[i].Cells["exp"].Value.ToString() == "False")
                    {
                        //cancel old balance effict
                        db.Run("insert into items_trans (                        code_items,                                name_items,                                                                qty                                                                ,f_unite                                                      ,                        name_unite            ,exp_date                    ,id_ware                            ,attachno                      ,attachbook            ,attachnamebook                    ,vcs_code                           ,vcs_name      ,                 dates       ) values ('" +

                                                         dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "','" + Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) * Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value)*-1 + "' ,'" + Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value) + "','" + (dgv.Rows[i].Cells["name_unite"].Value) + "',null,'" + combo_wars.Text + "','" + txt_serial_string.Text + "','" + comb_code_name.Text + "','" + comb_code_name.Text + "','" + combo_vsc_codetree.Text + "','" + combo_vcs.Text + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "')");

                        db.Run("insert into items_trans (                        code_items,                                name_items,                                                                qty                                                                ,f_unite                                                      ,                        name_unite            ,exp_date                    ,id_ware                            ,attachno                      ,attachbook            ,attachnamebook                    ,vcs_code                           ,vcs_name      ,                 dates       ) values ('" +

                                                        dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "','" + Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) * Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value) + "' ,'" + Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value) + "','" + (dgv.Rows[i].Cells["name_unite"].Value) + "',null,'" + combo_wars2.Text + "','" + txt_serial_string.Text + "','" + comb_code_name.Text + "','" + comb_code_name.Text + "','" + combo_vsc_codetree.Text + "','" + combo_vcs.Text + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "')");

                    }
                    else
                    {
                        //B)items is expiry
                        db.Run("insert into items_trans (                                             code_items,                                      name_items,                                                                        qty                                                          ,f_unite,                                                        name_unite                                                        ,exp_date                    ,id_ware                 ,attachno                    ,attachbook                    ,attachnamebook                  ,vcs_code                       ,vcs_name                              ,dates) values ('" +
                                    dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "','" + Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) * Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value)*-1 + "' ,'" + Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value) + "','" + (dgv.Rows[i].Cells["name_unite"].Value) + "','" + Convert.ToDateTime(dgv.Rows[i].Cells["exp_date"].Value).ToString("MM-dd-yyyy") + "','" + combo_wars.Text + "','" + txt_serial_string.Text + "','" + comb_code_name.Text + "','" + comb_code_name.Text + "','" + combo_vsc_codetree.Text + "','" + combo_vcs.Text + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "')");
                        db.Run("insert into items_trans (                                             code_items,                                      name_items,                                                                        qty                                                          ,f_unite,                                                        name_unite                                                        ,exp_date                    ,id_ware                 ,attachno                    ,attachbook                    ,attachnamebook                  ,vcs_code                       ,vcs_name                              ,dates) values ('" +
                                 dgv.Rows[i].Cells["code_items"].Value + "','" + dgv.Rows[i].Cells["name_items"].Value + "','" + Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value) * Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value)  + "' ,'" + Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value) + "','" + (dgv.Rows[i].Cells["name_unite"].Value) + "','" + Convert.ToDateTime(dgv.Rows[i].Cells["exp_date"].Value).ToString("MM-dd-yyyy") + "','" + combo_wars.Text + "','" + txt_serial_string.Text + "','" + comb_code_name.Text + "','" + comb_code_name.Text + "','" + combo_vsc_codetree.Text + "','" + combo_vcs.Text + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "')");
                    }
                    backgroundWorker1.ReportProgress(i);
                }

                bode_of_navigation(txt_serial_string.Text, txt_code_book.Text);
                edit = true;
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "saving ", "save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                progressBar1.Visible = false;
            }
            // catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }


        }
        private void edite_1()
        {
            cogs_edit_calc();
            //lop dgv 
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                //chek qty 
                Decimal qty_old, qty_current, qty_new;
                qty_old = Convert.ToDecimal(db.GetData("select qty from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'").Rows[0][0]);
                qty_current = (Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value)) * (Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value));
                qty_new = qty_old - qty_current;
                //   if (qty_new < 0)
                {
                    //dgv.Rows[i].Cells["chk"].Value="1";
                    //  MessageBox.Show("مينفعش مفيش رصيد من الصنف  والفتوره مغلقه ويجب توريد او مسح فاتوره مبيعات  " + "  Codeitems=" + dgv.Rows[i].Cells["code_items"].Value + "");
                    //   XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "مينفعش مفيش رصيد من الصنف  والفتوره مغلقه ويجب توريد او مسح فاتوره مبيعات  " + "  Codeitems=" + dgv.Rows[i].Cells["code_items"].Value + "", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //  return;
                }
                //===================================================================
                //cheak exp_date is entry
                if (dgv.Rows[i].Cells["exp"].Value.ToString() == "True" && dgv.Rows[i].Cells["exp_date"].Value.ToString() == "")
                {
                    MessageBox.Show("يجب ادخال تاريخ صلاحيه للصنف ");
                    return;
                }
                //if dgv = 0 
                try
                {
                    if (dgv.Rows[i].Cells["add_items1"].Value.ToString() == "2" && dgv.Rows[i].Cells["add_items"].Value.ToString() != "1")
                    {
                        //edit 
                        dgv_edit.Rows.Add(1, dgv.Rows[i].Cells["code_items"].Value.ToString(), dgv.Rows[i].Cells["name_items"].Value.ToString(), dgv.Rows[i].Cells["name_unite"].Value.ToString(), dgv.Rows[i].Cells["f_unite"].Value.ToString(), dgv.Rows[i].Cells["exp"].Value.ToString(), dgv.Rows[i].Cells["type"].Value.ToString(), (dgv.Rows[i].Cells["exp_date_1"].Value).ToString(), (dgv.Rows[i].Cells["exp_date"].Value).ToString(), (dgv.Rows[i].Cells["qty"].Value).ToString(), (dgv.Rows[i].Cells["item_price"].Value).ToString(), (dgv.Rows[i].Cells["tot_bef"].Value).ToString(), (dgv.Rows[i].Cells["discount"].Value).ToString(), (dgv.Rows[i].Cells["tot_after_dis"].Value).ToString(), (dgv.Rows[i].Cells["taxes"].Value).ToString(), (dgv.Rows[i].Cells["incloud_taxes"].Value).ToString(), (dgv.Rows[i].Cells["taxes_value"].Value).ToString(), (dgv.Rows[i].Cells["id_ware"].Value).ToString(), (dgv.Rows[i].Cells["item_qty1"].Value).ToString(), (dgv.Rows[i].Cells["trans_dt_id"].Value).ToString(), (dgv.Rows[i].Cells["tot_after_dis1"].Value).ToString(), (dgv.Rows[i].Cells["f_unite_1"].Value).ToString(), txt_serial_string.Text, txt_code_book.Text);
                    }
                    //else if dgv = 1
                    else if (dgv.Rows[i].Cells["add_items"].Value.ToString() == "1")
                    {
                        dgv_add_items.Rows.Add(dgv.Rows[i].Cells["code_items"].Value.ToString(), dgv.Rows[i].Cells["name_items"].Value.ToString(), dgv.Rows[i].Cells["name_unite"].Value.ToString(), dgv.Rows[i].Cells["f_unite"].Value.ToString(), dgv.Rows[i].Cells["exp"].Value.ToString(), dgv.Rows[i].Cells["type"].Value.ToString(), dgv.Rows[i].Cells["exp_date"].Value.ToString(), 0, dgv.Rows[i].Cells["qty"].Value.ToString(), dgv.Rows[i].Cells["item_price"].Value.ToString(), dgv.Rows[i].Cells["tot_bef"].Value.ToString(), dgv.Rows[i].Cells["discount"].Value.ToString(), dgv.Rows[i].Cells["tot_after_dis"].Value.ToString(), dgv.Rows[i].Cells["taxes"].Value.ToString(), dgv.Rows[i].Cells["incloud_taxes"].Value.ToString(), dgv.Rows[i].Cells["taxes_value"].Value.ToString(), dgv.Rows[i].Cells["id_ware"].Value.ToString(), (dgv.Rows[i].Cells["f_unite_1"].Value).ToString());
                    }
                    else
                    {
                        return;
                    }
                }
                catch (Exception)
                { }
            }

            //________________________^^^^^^^^^^^^^^^^^^^^^^^^^^^%%%%%%$$$$$$$$***((())))________%%%%%%%%%%%%%%%%%%%%%%%%%%%%%


            //1)edite in current dgv edite
            //_______________________________
            if (dgv_edit.Rows.Count > 0)
            {
                //1-c) edite purchas_dt 
                detailes_edit_update(dgv_edit, txt_serial_string.Text, txt_code_book.Text, comb_code_name.Text, "code_items_e", "name_items_e", "qty_e", "item_price_e", "tot_bef_e", "discount_e", "tot_after_dis_e", "taxes_e", "incloud_taxes_e", "taxes_value_e", "id_ware_e", "name_unite_e", "f_unite_e", "exp_t_f", "type_e", "dt_e", "exp_date_e");
                //1-A)cheak and wares
                ware_edit_update(dgv_edit, "code_items_e", "id_ware_e", "qty_e", "f_unite_e", "f_unite_1_e", "item_qty1_e", "type_e", "tot_after_dis_e");
                //1-B) edite exp :-
                exp_insert_and_delete_edite(dgv_edit, "code_items_e", "name_items_e", "id_ware_e", "qty_e", "f_unite_e", "item_qty1_e", "tot_after_dis1_e", "tot_after_dis_e", "exp_date_1_e", "exp_date_e");
            }
            //2)edite addnew items :-
            //________________________________
            if (dgv_add_items.Rows.Count > 0)
            {
                // //2-c) add purchas_dt
                detailes_edit_insert(dgv_add_items);
                ////2-A)cheak and wares
                ware_edit_update(dgv_add_items, "code_items_ai", "id_ware_ai", "qty_ai", "f_unite_ai", "type_ai", "tot_after_dis_ai");
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
            //4)edit entry :-
            //______________________________
            string code = db.GetData("select top 1 code_entry from entry where attachno='" + txt_serial_string.Text + "' ").Rows[0][0].ToString();
            db.Run("delete from entry_hd where code_entry='" + code + "' and code_book='" + txt_code_entry_type.Text + "'");
            db.Run("delete from entry where code_entry='" + code + "' and code_book='" + txt_code_entry_type.Text + "'");
            select_type_entry();
            //get only number for one user Entry
            txt_entry_string.Text = txt_code_entry_type.Text + txt_code_entry.Text;
            //cls_book.selectbook("entry_hd", "سند قيد", txt_code_entry_type.Text, txt_code_entry, "code_entry");
            //txt_entry_string.Text = txt_code_entry_type.Text + txt_code_entry.Text;
            string code_entry_term = (db.GetData("select code_entry from term where term_id='" + combo_type.Text + "' ").Rows[0][0].ToString());
            cls_book.Generat_numBooknum("entry", code_entry_term, ref numBook_entry, ref error, ref num_entry);
            txt_entry_string.Text = numBook_entry;


            db.Run("insert into entry_hd ([code_entry],code_book) values ('" + txt_code_entry_type.Text + txt_code_entry.Text + "','" + txt_code_entry_type.Text + "')");
            for (int z = 0; z < dgv_term.Rows.Count; z++)
            {
                db.Run("insert into entry(  [code_entry]                           ,    acc_num                                                   ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                                          ,   type_acc                                                            , sort                                                       ,             depit                                                             ,                credit                                                   ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext )values('" +
                   txt_code_entry_type.Text + txt_code_entry.Text + "','" + dgv_term.Rows[z].Cells[1].Value.ToString() + "','" + dgv_term.Rows[z].Cells[2].Value.ToString() + "',  '" + dgv_term.Rows[z].Cells["rootlevel_"].Value.ToString() + "'    ,  '" + dgv_term.Rows[z].Cells["rootlevel_name_"].Value.ToString() + "', '" + dgv_term.Rows[z].Cells["type_acc_"].Value.ToString() + "'       ,  '" + dgv_term.Rows[z].Cells["sort_"].Value.ToString() + "'  ,  '" + Convert.ToDecimal(dgv_term.Rows[z].Cells[3].Value.ToString()) * Convert.ToDecimal(txt_f_currance.Text) + "'      ,'" + Convert.ToDecimal(dgv_term.Rows[z].Cells[4].Value.ToString()) * Convert.ToDecimal(txt_f_currance.Text) + "' ,'" + txt_name_book_type.Text + "','" + txt_code_entry_type.Text + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + txt_serial_string.Text + "','" + txt_code_book.Text + "','" + comb_code_name.Text + "','" + txt_note.Text + "')");
            }
            dgv_edit.Rows.Clear();
            dgv_delete.Rows.Clear();
            dgv_add_items.Rows.Clear();
            dgv_term.Rows.Clear();

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
                    DialogResult dr;
                    dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "هل تريد الحذف!!؟؟؟؟ ", "رسال حذف مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (dr == DialogResult.OK)
                    {
                        //============>>>
                        Decimal qty_old_1, qty_old_2, qty_current, qty_new1, qty_new2;
                        //  Decimal qty_old_exp, qty_current_exp, qty_current1_exp, qty_new_exp;
                        progressBar1.Visible = true;
                        prog = dgv.Rows.Count;//to know progras bar 
                        for (int i = 0; i < dgv.Rows.Count; i++)
                        {
                            if (dgv.Rows[i].Cells["type"].Value.ToString() != "2")
                            {
                                qty_old_1 = Convert.ToDecimal(db.GetData("select qty from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware='" +combo_wars.Text + "'").Rows[0][0]);
                                qty_old_2 = Convert.ToDecimal(db.GetData("select qty from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware='" + combo_wars2.Text + "'").Rows[0][0]);

                                qty_current = (Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value)) * (Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value));
                                qty_new1 = qty_old_1 + qty_current;
                                qty_new2 = qty_old_2 - qty_current;
                                if (qty_new2 < 0)
                                {
                                    XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "مينفعش مفيش رصيد من الصنف    " + "  Codeitems=" + dgv.Rows[i].Cells["code_items"].Value + "", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                //qty 
                                db.Run("update wares set qty =(" + Convert.ToDecimal(qty_new1) + " ) where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware='" + combo_wars.Text + "'");
                                db.Run("update wares set qty =(" + Convert.ToDecimal(qty_new2) + ") where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware='" + combo_wars2.Text + "'");


                                //cost
                                //delete from wares update:-
                                   //cost:=
                                   decimal cost_ware_old1 = Convert.ToDecimal(db.GetData("select isnull((sum(cost)),0) from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and id_ware='" + combo_wars.Text + "'").Rows[0][0].ToString());
                                   decimal cost_ware_old2 = Convert.ToDecimal(db.GetData("select isnull((sum(cost)),0) from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and id_ware='" + combo_wars2.Text + "'").Rows[0][0].ToString());

                                   //  decimal cost_bal_1 = (Convert.ToDecimal(cost_ware_old1)) - ((Convert.ToDecimal(dgv.Rows[i].Cells["qty"].Value)) * (Convert.ToDecimal(dgv.Rows[i].Cells["f_unite"].Value)));
                                  // decimal cost_bal_1 = (Convert.ToDecimal(cost_ware_old1)) + (Convert.ToDecimal(cost_ware_old1)); if (cost_bal_1 < 0) cost_bal_1 = cost_bal_1 * -1;
                                  // decimal cost_bal_2 = (Convert.ToDecimal(cost_ware_old2)) - (Convert.ToDecimal(cost_ware_old1)); if (cost_bal_2 < 0) cost_bal_2 = cost_bal_1 * -1;

                                   db.Run("update wares set cost =(" + cost_ware_old1 + ") where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware='" + combo_wars.Text + "'");
                                   db.Run("update wares set cost =(" + cost_ware_old1 + ") where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware='" + combo_wars2.Text + "'");


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
                        db.Run("delete from entry_hd where code_entry='" + code + "' and code_book='" + txt_code_entry_type.Text + "'");
                        db.Run("delete from entry where code_entry='" + code + "' and code_book='" + txt_code_entry_type.Text + "'");
                        //--------->>>
                        db.Run("delete from trans_hd where trans_hd_id='" + txt_serial_string.Text + "'");
                        db.Run("delete from trans_dt where trans_hd_id='" + txt_serial_string.Text + "' and code_book='" + txt_code_book.Text + "'");
                        //--------->>>>
                        db.Run("delete from items_trans where attachno='"+txt_serial_string.Text+"' ");
                        //============
                        MessageBox.Show("delete");
                        new_file();
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
        private void delete_row_and_move_to_dgv_Delete()
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
                            decimal qty_ware = Convert.ToDecimal(db.GetData("select qty from wares where code_items='" + dgv.CurrentRow.Cells["code_items"].Value + "' and id_ware='" + dgv.CurrentRow.Cells["id_ware"].Value + "'").Rows[0][0].ToString());
                            if ((Convert.ToDecimal(dgv.CurrentRow.Cells["qty"].Value)) * (Convert.ToDecimal(dgv.CurrentRow.Cells["f_unite"].Value)) > 0)
                            {
                                //add row in dgv_delete
                                //           dgv_delete.Rows.Add(dgv.CurrentRow.Cells["code_items"].Value, dgv.CurrentRow.Cells["trans_dt_id"].Value, dgv.CurrentRow.Cells["id_ware"].Value, (Convert.ToDecimal(dgv.CurrentRow.Cells["qty"].Value)) * (Convert.ToDecimal(dgv.CurrentRow.Cells["f_unite"].Value)), dgv.CurrentRow.Cells["exp"].Value.ToString());
                                dgv_delete.Rows.Add(dgv.CurrentRow.Cells["code_items"].Value.ToString(), dgv.CurrentRow.Cells["name_items"].Value.ToString(), dgv.CurrentRow.Cells["name_unite"].Value.ToString(), dgv.CurrentRow.Cells["f_unite"].Value.ToString(), dgv.CurrentRow.Cells["exp"].Value.ToString(), dgv.CurrentRow.Cells["type"].Value.ToString(), (dgv.CurrentRow.Cells["exp_date_1"].Value).ToString(), (dgv.CurrentRow.Cells["exp_date"].Value).ToString(), (dgv.CurrentRow.Cells["qty"].Value).ToString(), (dgv.CurrentRow.Cells["item_price"].Value).ToString(), (dgv.CurrentRow.Cells["tot_bef"].Value).ToString(), (dgv.CurrentRow.Cells["discount"].Value).ToString(), (dgv.CurrentRow.Cells["tot_after_dis"].Value).ToString(), (dgv.CurrentRow.Cells["taxes"].Value).ToString(), (dgv.CurrentRow.Cells["incloud_taxes"].Value).ToString(), (dgv.CurrentRow.Cells["taxes_value"].Value).ToString(), (dgv.CurrentRow.Cells["id_ware"].Value).ToString(), (dgv.CurrentRow.Cells["item_qty1"].Value).ToString(), (dgv.CurrentRow.Cells["trans_dt_id"].Value).ToString(), (dgv.CurrentRow.Cells["tot_after_dis1"].Value).ToString(), txt_serial_string.Text, txt_code_book.Text);

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
                    lbl_vat_add.Text = (Math.Round(tot_after_dis, 2) * 1 / 100) + "";

                }
                else
                {
                    MessageBox.Show("يجب إدخل رقم  اقل من صفر");
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
                    lbl_vat_add.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                if (tot_bef > 0)
                {
                    //                    txt_after_taxes.Text = Math.Round(tot_after_taxes, 2) + "";
                    lbl_incloud_taxes.Text = Math.Round(incloud_taxes, 2) + "";
                    lbl_vat_add.Text = (Math.Round(tot_after_dis, 2) * 1 / 100) + "";

                }
                else
                {
                    MessageBox.Show("يجب إدخل رقم  اقل من صفر");
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
                    lbl_vat_add.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void get_dt(string num, string book)//get data detals
        {
            DataTable dt_dt = new DataTable();
            db.GetData_DGV("SELECT  [no],  code_items, name_items, name_unite, f_unite , exp, type, qty, item_price, tot_bef, discount, tot_after_dis, taxes, incloud_taxes,taxes_value, id_ware,trans_dt_id , 0 as add_items,qty as item_qty1 ,exp_date , exp_date as exp_date_1,tot_after_dis as tot_after_dis1 ,f_unite as f_unite_1  FROM   trans_dt where trans_hd_id='" + num + "' and code_book='" + book + "'", dt_dt);
            dgv.DataSource = dt_dt;
        }
        private void bode_of_navigation(string num, string book)
        {
            printer_dirict_barButtonItem11.Enabled = true;
            printer_prevew_barButtonItem10.Enabled = true;
            lbl_stat_min_items.Caption = "0";
            lbl_stat_max_items.Caption = "0";
            lbl_balance_items.Caption = "0";
            lbl_stat_cost_items.Caption = "0";
            lbl_state_vcs_bal.Caption = "0";
            DataTable dt = new DataTable();
            db.GetData_DGV("select code_book from  trans_hd where trans_hd_id='" + num + "' and code_book='" + book + "' ", dt);
            if (dt.Rows.Count > 0)
            {
                edit = true;
                get_dt(num, book);
                lbl_serial_P.Text = db.GetData("select serial_P from trans_hd where trans_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
                comb_code_name.Text = db.GetData("select name_book from trans_hd where trans_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
                txt_code_book.Text = db.GetData("select code_book from trans_hd where trans_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
                txt_serial_string.Text = db.GetData("select trans_hd_id from trans_hd where trans_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
                combo_wars.Text = db.GetData("select id_ware from trans_hd where trans_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
                combo_wars2.Text = db.GetData("select id_ware2 from trans_hd where trans_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
                combo_vcs.Text = db.GetData("select vcs_name from trans_hd where trans_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
                combo_vsc_codetree.Text = db.GetData("select vcs_code from trans_hd where trans_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
                combo_type.Text = db.GetData("select term from trans_hd where trans_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
                txt_note.Text = db.GetData("select note_txt from trans_hd where trans_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
                dt_piker.Text = db.GetData("select date_p from trans_hd where trans_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
                lbl_user_name.Text = db.GetData("select user_name from trans_hd where trans_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
                lbl_user_code.Text = db.GetData("select user_code from trans_hd where trans_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
                combo_currance.Text = db.GetData("select currance from trans_hd where trans_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
                txt_f_currance.Text = db.GetData("select f_currance from trans_hd where trans_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();

                lbl_tot_befor.Text = db.GetData("select tot_befor from trans_hd where trans_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
                lbl_tot_after_dis.Text = db.GetData("select tot_after_dis from trans_hd where trans_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString(); ;
                lbl_discount.Text = db.GetData("select discount from trans_hd where trans_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString(); ;
                lbl_incloud_taxes.Text = db.GetData("select incloud_taxes from trans_hd where trans_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
                lbl_taxes_values.Text = db.GetData("select taxes from trans_hd where trans_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();


                dgv_edit.Rows.Clear();
                dgv_delete.Rows.Clear();
                dgv_add_items.Rows.Clear();
                calc_all();
                //link between pay_dt and trans_hd
                try
                {
                    if (db.GetData("select lock from trans_hd   where trans_hd_id= '" + txt_serial_string.Text + "'").Rows[0][0].ToString() == "t")
                    {
                        save_barButtonItem1.Enabled = false;
                        btn_delete_file.Enabled = false;
                        return;
                    }
                    else
                    {
                        save_barButtonItem1.Enabled = true;
                        btn_delete_file.Enabled = true;
                    }
                }
                catch (Exception) { }
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

        }
        private void perform_save()
        {
            //prevent keypord use 
            if (save_barButtonItem1.Enabled == false || btn_delete_file.Enabled == false)
            {
                return;
            }
            
            //  else
            {
                calc_all();
                if (Convert.ToDouble(lbl_tot_befor.Text) <= 0)
                {
                    XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "لايمكن الحفظ القيم بالصفر او اقل   ", "رساله تحذير", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (combo_type.Text == "")
                {
                    XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "ادخل نوع السند   ", "رساله تحذير", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
               
                else
                {
                    if (edit == false)
                    {
                        if (add_permission == true)
                        {
                            save();
                        }
                        else
                        {
                            MessageBox.Show("لاتوجد  صلايحه انك تضيف فاتوره تعدل فقط ");
                        }
                    }
                    else
                    {
                        if (edit_permission == true)
                        {
                           // edite_1();
                            bode_of_navigation(txt_serial_string.Text, txt_code_book.Text);
                            edit = true;
                            MessageBox.Show("edite succssfull");
                        }
                        else
                        {
                            MessageBox.Show("لاتوجد صلايحه انك تعدل علي الفاتوره  ");

                        }
                    }
                    

                }

            }

        }
        private void add_items_in_dgv()
        {
            if (edit == false)
            {
                dgv.Rows.Add(null, code_items_a, name_items_a, name_unite_a, unit1, exp_a, type_a, null, 0, 1, price_items_a, 0, 0, 0, taxes_a, 0, 0, combo_wars.Text);
            }
            else
            {
                DataTable dataTable = (DataTable)dgv.DataSource;
                DataRow drToAdd = dataTable.NewRow();
                drToAdd["code_items"] = code_items_a;
                drToAdd["name_items"] = name_items_a;
                drToAdd["name_unite"] = name_unite_a;
                drToAdd["f_unite"] = unit1;
                drToAdd["exp"] = exp_a;
                drToAdd["type"] = type_a;
                // drToAdd["exp_date"] =0;
                //drToAdd["mf_unite"] = 0;
                drToAdd["qty"] = 0;
                drToAdd["item_price"] = price_items_a;
                drToAdd["tot_bef"] = 0;
                drToAdd["discount"] = db.GetData("select isnull(avg(discount),0) from trans_dt where code_items='" + code_items_a + "' ").Rows[0][0].ToString(); ;
                drToAdd["tot_after_dis"] = 0;
                drToAdd["taxes"] = taxes_a;
                drToAdd["incloud_taxes"] = 0;
                drToAdd["taxes_value"] = 0;
                drToAdd["item_qty1"] = db.GetData("select isnull(sum(qty),0) from wares where code_items='" + code_items_a + "' and id_ware='" + combo_wars.Text + "'").Rows[0][0].ToString();
                drToAdd["add_items"] = 1;
                drToAdd["id_ware"] = combo_wars.Text;
                dataTable.Rows.Add(drToAdd);
                dataTable.AcceptChanges();
                //  dgv.CurrentRow.Cells["add_items1"].Value = 2;

            }
        }
        string code_items_a, name_items_a, name_unite_a, unit1, price_items_a, discount_a, taxes_a, exp_a, type_a;//combo_add_items_SelectedIndexChanged
        private void add_items_in_property_comboadd_items(string find_fild, string code_items)
        {

            code_items_a = db.GetData("select isnull(max(code_items),0) from items where " + find_fild + "='" + code_items + "'").Rows[0][0].ToString();
            name_items_a = db.GetData("select isnull(max(name_items),0) from items where " + find_fild + "='" + code_items + "'").Rows[0][0].ToString();
            name_unite_a = db.GetData("select isnull(max(name_unite),0) from items where " + find_fild + "='" + code_items + "'").Rows[0][0].ToString();
            unit1 = db.GetData("select isnull(max(unit1),0) from items where " + find_fild + "='" + code_items + "'").Rows[0][0].ToString();
            price_items_a = db.GetData("select isnull(max(price_buy),0) from items where code_items='" + code_items_a + "'").Rows[0][0].ToString();
            discount_a = db.GetData("select isnull(avg(discount),0) from trans_dt where code_items='" + code_items_a + "'").Rows[0][0].ToString();
            taxes_a = db.GetData("select isnull(max(taxes),0) from items where " + find_fild + "='" + code_items + "'").Rows[0][0].ToString();
            exp_a = db.GetData("select [exp] from items where " + find_fild + "='" + code_items + "'").Rows[0][0].ToString();
            type_a = db.GetData("select isnull(max([type]),0) from items where " + find_fild + "='" + code_items + "'").Rows[0][0].ToString();


        }
        private void new_file()
        {

            frm_trans_items frm = new frm_trans_items();
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
        private void cogs_edit_calc()
        {
            if (dgv.Rows.Count < 0) return;

            string note = "";
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                double price_cogs = 0;
                double discount_cogs = 0;
                price_cogs = Convert.ToDouble((db.GetData("select isnull(sum(item_price),0) from trans_dt where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and trans_dt_id='" + dgv.Rows[i].Cells["trans_dt_id"].Value + "'").Rows[0][0].ToString()));
                discount_cogs = (Convert.ToDouble(db.GetData("select isnull(sum(discount),0) from trans_dt where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and trans_dt_id='" + dgv.Rows[i].Cells["trans_dt_id"].Value + "'").Rows[0][0].ToString()));
                //     MessageBox.Show(Convert.ToDouble(dgv.Rows[i].Cells["item_price"].Value) + "   " + Convert.ToDouble(dgv.Rows[i].Cells["discount"].Value)+"");

                if (Convert.ToDouble(dgv.Rows[i].Cells["item_price"].Value) != price_cogs || Convert.ToDouble(dgv.Rows[i].Cells["discount"].Value) != discount_cogs)
                {
                    note = db.GetData("select isnull(sum(sale_dt.qty),0) FROM  sale_hd LEFT OUTER JOIN sale_dt ON sale_hd.sale_hd_id = sale_dt.sale_hd_id where date_P <= '" + dt_piker.Value.ToString("MM-dd-yyyy") + "' and sale_dt.code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'").Rows[0][0].ToString();
                    if (Convert.ToDouble(note) != 0)
                    {
                        db.Run("insert into center (code_items,date,note) values ('" + dgv.Rows[i].Cells["code_items"].Value + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','Error cost inventory')");

                        MessageBox.Show(dgv.Rows[i].Cells["code_items"].Value + "  \n  " + dt_piker.Value.ToString("MM-dd-yyyy") + "\n " + txt_serial_string.Text);
                    }
                }
            }
        }
        private void dgv_satue_cost_bal_vcs_dis_min_max()
        {
            try
            {
                lbl_stat_min_items.Caption = db.GetData("select isnull(min (discount),0) from trans_dt  where code_items ='" + dgv.CurrentRow.Cells["code_items"].Value.ToString() + "'").Rows[0][0].ToString();
                lbl_stat_max_items.Caption = db.GetData("select isnull(max (discount),0) from trans_dt  where code_items ='" + dgv.CurrentRow.Cells["code_items"].Value.ToString() + "'").Rows[0][0].ToString();
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
            save_barButtonItem1.Enabled = Convert.ToBoolean(db.GetData("select [save] from permission_sub where user_name='" + v.username + "' and name_frm ='trans' ").Rows[0][0].ToString());
            btn_delete_file.Enabled = Convert.ToBoolean(db.GetData("select [delete] from permission_sub where user_name='" + v.username + "' and name_frm ='trans' ").Rows[0][0].ToString());
            add_permission = Convert.ToBoolean(db.GetData("select [add_only] from permission_sub where user_name='" + v.username + "' and name_frm ='trans' ").Rows[0][0].ToString());
            edit_permission = Convert.ToBoolean(db.GetData("select [edit_only] from permission_sub where user_name='" + v.username + "' and name_frm ='trans' ").Rows[0][0].ToString());
        }

        //=============Function Edite=============================
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
                    MessageBox.Show("لا يمكن رصيد يكون بالسالب  ");
                    break;
                }
            }


        }
        private void edite_hd()
        {
            db.Run("update trans_hd set   vcs_code='" + combo_vsc_codetree.Text + "', vcs_name='" + combo_vcs.Text + "', term='" + combo_type.Text + "',  date_P='" + Convert.ToDateTime(dt_piker.Value).ToString("MM-dd-yyyy") + "',due_date='" + Convert.ToDateTime(dt_due_date.Value).ToString("MM-dd-yyyy") + "', tot_befor='" + lbl_tot_befor.Text + "', tot_after_dis='" + lbl_tot_after_dis.Text + "', discount='" + lbl_discount.Text + "', incloud_taxes='" + lbl_incloud_taxes.Text + "', taxes_value='" + lbl_taxes_values.Text + "', id_ware='" + combo_wars.Text + "', code_entry='" + txt_code_entry.Text + "', book_name_entry='" + txt_name_book_type.Text + "', code_book_entry='" + txt_code_entry_type.Text + "', note_txt='" + txt_note.Text + "', user_code='" + lbl_user_code.Text + "', user_name='" + lbl_user_name.Text + "',currance='" + combo_currance.Text + "',f_currance ='" + txt_f_currance.Text + "' where trans_hd_id='" + txt_serial_string.Text + "'and  code_book='" + txt_code_book.Text + "'");
        }
        private void detailes_edit_update(DataGridView dgv_, string txt_serial_string_, string txt_code_book, string comb_code_name, string code_items_e_col, string name_items_e_col, string qty_e_col, string item_price_e_col, string tot_bef_e_col, string discount_e_col, string tot_after_dis_e_col, string taxes_e_col, string incloud_taxes_e_col, string taxes_value_e_col, string id_ware_e_col, string name_unite_e_col, string f_unite_e_col, string exp_e_col, string type_e_col, string trans_dt_id_e_col, string exp_date_e_col)
        {
            for (int i = 0; i < dgv_edit.Rows.Count; i++)
            {



                if (dgv_edit.Rows[i].Cells["exp_t_f"].Value.ToString() == "False")
                {
                    db.Run("update trans_dt set  trans_hd_id='" + txt_serial_string_ + "', code_book='" + txt_code_book + "', name_book='" + comb_code_name + "',code_items='" + dgv_edit.Rows[i].Cells[code_items_e_col].Value.ToString() + "', name_items='" + dgv_edit.Rows[i].Cells[name_items_e_col].Value.ToString() + "', qty='" + dgv_edit.Rows[i].Cells[qty_e_col].Value.ToString() + "', item_price='" + dgv_edit.Rows[i].Cells[item_price_e_col].Value.ToString() + "', tot_bef='" + dgv_edit.Rows[i].Cells[tot_bef_e_col].Value.ToString() + "', discount='" + dgv_edit.Rows[i].Cells[discount_e_col].Value.ToString() + "', tot_after_dis='" + dgv_edit.Rows[i].Cells[tot_after_dis_e_col].Value.ToString() + "', taxes='" + dgv_edit.Rows[i].Cells[taxes_e_col].Value.ToString() + "', incloud_taxes='" + dgv_edit.Rows[i].Cells[incloud_taxes_e_col].Value.ToString() + "', taxes_value='" + dgv_edit.Rows[i].Cells[taxes_value_e_col].Value.ToString() + "', id_ware='" + dgv_edit.Rows[i].Cells[id_ware_e_col].Value.ToString() + "', name_unite='" + dgv_edit.Rows[i].Cells[name_unite_e_col].Value.ToString() + "', f_unite='" + dgv_edit.Rows[i].Cells[f_unite_e_col].Value.ToString() + "', [exp]='" + dgv_edit.Rows[i].Cells[exp_e_col].Value.ToString() + "', [type]='" + dgv_edit.Rows[i].Cells[type_e_col].Value.ToString() + "', tot_after_dis_forex='" + (Convert.ToDecimal(dgv_edit.Rows[i].Cells[tot_after_dis_e_col].Value.ToString()) * Convert.ToDecimal(txt_f_currance.Text)) + "' where trans_dt_id='" + dgv_edit.Rows[i].Cells[trans_dt_id_e_col].Value.ToString() + "'");
                    //update items_trans
                    db.Run("update items_trans set  qty   ='" + Convert.ToDecimal(dgv_edit.Rows[i].Cells[qty_e_col].Value) * Convert.ToDecimal(dgv_edit.Rows[i].Cells[f_unite_e_col].Value) + "'  ,f_unite ='" + Convert.ToDecimal(dgv_edit.Rows[i].Cells[f_unite_e_col].Value) + "'      ,  name_unite ='" + (dgv_edit.Rows[i].Cells[name_unite_e_col].Value) + "'     ,id_ware    ='" + dgv_edit.Rows[i].Cells[id_ware_e_col].Value.ToString() + "' ,attachno  ='" + txt_serial_string.Text + "'   ,attachnamebook  ='edit'   ,vcs_code  ='" + combo_vsc_codetree.Text + "'   ,vcs_name='" + combo_vcs.Text + "' , dates  ='" + Convert.ToDateTime(dt_piker.Value).ToString("MM-dd-yyyy") + "'  where attachno='" + txt_serial_string.Text + "' ");
                }
                else
                {
                    db.Run("update trans_dt set trans_hd_id='" + txt_serial_string_ + "', code_book='" + txt_code_book + "', name_book='" + comb_code_name + "',code_items='" + dgv_edit.Rows[i].Cells[code_items_e_col].Value.ToString() + "', name_items='" + dgv_edit.Rows[i].Cells[name_items_e_col].Value.ToString() + "', qty='" + dgv_edit.Rows[i].Cells[qty_e_col].Value.ToString() + "', item_price='" + dgv_edit.Rows[i].Cells[item_price_e_col].Value.ToString() + "', tot_bef='" + dgv_edit.Rows[i].Cells[tot_bef_e_col].Value.ToString() + "', discount='" + dgv_edit.Rows[i].Cells[discount_e_col].Value.ToString() + "', tot_after_dis='" + dgv_edit.Rows[i].Cells[tot_after_dis_e_col].Value.ToString() + "', taxes='" + dgv_edit.Rows[i].Cells[taxes_e_col].Value.ToString() + "', incloud_taxes='" + dgv_edit.Rows[i].Cells[incloud_taxes_e_col].Value.ToString() + "', taxes_value='" + dgv_edit.Rows[i].Cells[taxes_value_e_col].Value.ToString() + "', id_ware='" + dgv_edit.Rows[i].Cells[id_ware_e_col].Value.ToString() + "', exp_date='" + Convert.ToDateTime(dgv_edit.Rows[i].Cells[exp_date_e_col].Value).ToString("MM-dd-yyyy") + "', name_unite='" + dgv_edit.Rows[i].Cells[name_unite_e_col].Value.ToString() + "', f_unite='" + dgv_edit.Rows[i].Cells[f_unite_e_col].Value.ToString() + "', [exp]='" + dgv_edit.Rows[i].Cells[exp_e_col].Value.ToString() + "', [type]='" + dgv_edit.Rows[i].Cells[type_e_col].Value.ToString() + "' ,tot_after_dis_forex='" + Convert.ToDecimal(dgv_edit.Rows[i].Cells[tot_after_dis_e_col].Value.ToString()) * Convert.ToDecimal(txt_f_currance.Text) + "'  where trans_dt_id='" + dgv_edit.Rows[i].Cells[trans_dt_id_e_col].Value.ToString() + "'");
                    //update items_trans
                    db.Run("update items_trans set  qty   ='" + Convert.ToDecimal(dgv_edit.Rows[i].Cells[qty_e_col].Value) * Convert.ToDecimal(dgv_edit.Rows[i].Cells[f_unite_e_col].Value) + "'  ,f_unite ='" + Convert.ToDecimal(dgv_edit.Rows[i].Cells[f_unite_e_col].Value) + "'      ,  name_unite ='" + (dgv_edit.Rows[i].Cells[name_unite_e_col].Value) + "'     ,id_ware    ='" + dgv_edit.Rows[i].Cells[id_ware_e_col].Value.ToString() + "' ,attachno  ='" + txt_serial_string.Text + "'   ,attachnamebook  ='edit'   ,vcs_code  ='" + combo_vsc_codetree.Text + "'   ,vcs_name='" + combo_vcs.Text + "' , dates  ='" + Convert.ToDateTime(dt_piker.Value).ToString("MM-dd-yyyy") + "',exp_date='" + Convert.ToDateTime(dgv_edit.Rows[i].Cells[exp_date_e_col].Value).ToString("MM-dd-yyyy") + "'  where attachno='" + txt_serial_string.Text + "' ");

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
                            db.Run("insert into trans_dt(trans_hd_id ,         code_book ,                       name_book         ,                       code_items              ,                        name_items             ,                                         qty             ,                                      item_price                  ,                                         tot_bef             ,                                         discount             ,                                         tot_after_dis             ,                                        taxes              ,                                        incloud_taxes                 ,                                          taxes_value             ,      id_ware         ,                         f_unite,                                   name_unite                                           ,no,                                                           [exp]              ,            exp_date                        ,[type],serial_P,tot_after_dis_forex) values('" +
                                                     txt_serial_string.Text + "','" + txt_code_book.Text + "', '" + comb_code_name.Text + "','" + dgv_add_items.Rows[i].Cells["code_items_ai"].Value + "','" + dgv_add_items.Rows[i].Cells["name_items_ai"].Value + "'," + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["qty_ai"].Value) + ",'" + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["item_price_ai"].Value) + "'," + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["tot_bef_ai"].Value) + "," + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["discount_ai"].Value) + "," + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["tot_after_dis_ai"].Value) + "," + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["taxes_ai"].Value) + ",'" + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["incloud_taxes_ai"].Value) + "','" + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["taxes_value_ai"].Value) + "','" + combo_wars.Text + "','" + (dgv_add_items.Rows[i].Cells["f_unite_ai"].Value) + "','" + (dgv_add_items.Rows[i].Cells["name_unite_ai"].Value) + "','" + 0 + "','" + Convert.ToBoolean((dgv_add_items.Rows[i].Cells["exp_ai"].Value)) + "',            Null              ,'" + (dgv_add_items.Rows[i].Cells["type_ai"].Value) + "','" + lbl_serial_P.Text + "','" + Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) * Convert.ToDecimal(txt_f_currance.Text) + "')");
                            //insert item_trans
                            db.Run("insert into items_trans (                        code_items,                                name_items,                                                                qty                                                                ,f_unite                                                      ,                        name_unite            ,exp_date                    ,id_ware                            ,attachno                      ,attachbook            ,attachnamebook                    ,vcs_code                           ,vcs_name      ,                 dates       ) values ('" +

                                               dgv_add_items.Rows[i].Cells["code_items_ai"].Value + "','" + dgv_add_items.Rows[i].Cells["name_items_ai"].Value + "','" + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["qty_ai"].Value) * Convert.ToDecimal(dgv_add_items.Rows[i].Cells["f_unite_ai"].Value) + "' ,'" + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["f_unite_ai"].Value) + "','" + (dgv_add_items.Rows[i].Cells["name_unite_ai"].Value) + "',null,'" + (dgv_add_items.Rows[i].Cells["id_ware_ai"].Value) + "','" + txt_serial_string.Text + "','" + comb_code_name.Text + "','" + comb_code_name.Text + "','" + combo_vsc_codetree.Text + "','" + combo_vcs.Text + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "')");


                        }
                        else //items is exp
                        {
                            db.Run("insert into trans_dt(trans_hd_id ,         code_book ,                       name_book         ,                       code_items              ,                        name_items             ,                                         qty             ,                                      item_price                  ,                                         tot_bef             ,                                         discount             ,                                         tot_after_dis             ,                                        taxes              ,                                        incloud_taxes                 ,                                          taxes_value             ,      id_ware         ,                         f_unite,                                   name_unite                                           ,no,                                                           [exp]              ,            exp_date                        ,[type],serial_P,tot_after_dis_forex) values('" +
                                                     txt_serial_string.Text + "','" + txt_code_book.Text + "', '" + comb_code_name.Text + "','" + dgv_add_items.Rows[i].Cells["code_items_ai"].Value + "','" + dgv_add_items.Rows[i].Cells["name_items_ai"].Value + "'," + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["qty_ai"].Value) + ",'" + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["item_price_ai"].Value) + "'," + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["tot_bef_ai"].Value) + "," + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["discount_ai"].Value) + "," + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["tot_after_dis_ai"].Value) + "," + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["taxes_ai"].Value) + ",'" + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["incloud_taxes_ai"].Value) + "','" + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["taxes_value_ai"].Value) + "','" + combo_wars.Text + "','" + (dgv_add_items.Rows[i].Cells["f_unite_ai"].Value) + "','" + (dgv_add_items.Rows[i].Cells["name_unite_ai"].Value) + "','" + 0 + "','" + Convert.ToBoolean((dgv_add_items.Rows[i].Cells["exp_ai"].Value)) + "','" + Convert.ToDateTime(dgv_add_items.Rows[i].Cells["exp_date_1_ai"].Value).ToString("MM-dd-yyyy") + "','" + (dgv_add_items.Rows[i].Cells["type_ai"].Value) + "','" + lbl_serial_P.Text + "','" + Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value) * Convert.ToDecimal(txt_f_currance.Text) + "')");

                            //insert item trasn have exp items
                            db.Run("insert into items_trans (                                             code_items,                                      name_items,                                                                        qty                                                          ,f_unite,                                                        name_unite                                                        ,exp_date                    ,id_ware                 ,attachno                    ,attachbook                    ,attachnamebook                  ,vcs_code                       ,vcs_name                              ,dates) values ('" +
                                         dgv_add_items.Rows[i].Cells["code_items_ai"].Value + "','" + dgv_add_items.Rows[i].Cells["name_items_ai"].Value + "','" + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["qty_ai"].Value) * Convert.ToDecimal(dgv_add_items.Rows[i].Cells["f_unite_ai"].Value) + "' ,'" + Convert.ToDecimal(dgv_add_items.Rows[i].Cells["f_unite_ai"].Value) + "','" + (dgv_add_items.Rows[i].Cells["name_unite_ai"].Value) + "','" + Convert.ToDateTime(dgv_add_items.Rows[i].Cells["exp_date_1_ai"].Value).ToString("MM-dd-yyyy") + "','" + (dgv_add_items.Rows[i].Cells["id_ware_ai"].Value) + "','" + txt_serial_string.Text + "','" + comb_code_name.Text + "','" + comb_code_name.Text + "','" + combo_vsc_codetree.Text + "','" + combo_vcs.Text + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "')");

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
                db.Run("delete from trans_dt where code_items='" + dgv_delete.Rows[i].Cells["code_items_de"].Value.ToString() + "' and trans_dt_id='" + dgv_delete.Rows[i].Cells["dt_de"].Value.ToString() + "'");
                //delete from items_trans
                db.Run("delete  from items_trans where attachno='" + txt_serial_string.Text + "' and code_items='" + dgv_delete.Rows[i].Cells["code_items_de"].Value.ToString() + "'");
            }
        }
        private void ware_edit_update(DataGridView dgv_, string code_items_col, string id_ware_col, string qty_col, string f_unite_col, string f_unite_1_col, string item_qty1_col, string type, string tot_after_dis_e_col)
        {

            string qty_old = "0";
            string qty_sales = "0";
            string qty_current = "0";
            string qty_current1 = "0";
            string qty_new = "0";
            for (int i = 0; i < dgv_.Rows.Count; i++)
            {

                if (dgv_.Rows[i].Cells[type].Value.ToString() == "1")
                {
                    qty_old = db.GetData("select isnull((sum(qty)),0) from wares where code_items='" + dgv_.Rows[i].Cells[code_items_col].Value + "'and id_ware='" + dgv_.Rows[i].Cells[id_ware_col].Value + "'").Rows[0][0].ToString();
                    qty_current = ((Convert.ToDecimal(dgv_.Rows[i].Cells[qty_col].Value)) * (Convert.ToDecimal(dgv_.Rows[i].Cells[f_unite_col].Value))).ToString();
                    qty_current1 = ((Convert.ToDecimal(dgv_.Rows[i].Cells[item_qty1_col].Value)) * (Convert.ToDecimal(dgv_.Rows[i].Cells[f_unite_1_col].Value))).ToString();
                    if (qty_current1 == "") qty_current1 = "0";
                    qty_new = (Convert.ToDecimal(qty_old) + (Convert.ToDecimal(qty_current) - Convert.ToDecimal(qty_current1))).ToString();
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

                    qty_sales = db.GetData("select isnull(sum(sale_dt.qty),0) FROM  sale_hd LEFT OUTER JOIN sale_dt ON sale_hd.sale_hd_id = sale_dt.sale_hd_id where date_P >= '" + dt_piker.Value.ToString("MM-dd-yyyy") + "' and sale_dt.code_items='" + dgv_.Rows[i].Cells[code_items_col].Value + "'").Rows[0][0].ToString();

                    //*) update cost:= total / QTY  and update cost for ware
                    //_______________________________________________
                    Decimal totalcost = 0;
                    Decimal totalqty = 0;
                    String totalcoststring = "";
                    //1-qty sale > 0 same date and  great than date 
                    if (Convert.ToDecimal(qty_sales) > 0)
                    {
                        totalqty = Convert.ToDecimal(db.GetData("select isnull(sum(qty * f_unite),0)  from trans_dt where code_items='" + dgv_.Rows[i].Cells[code_items_col].Value + "' and id_ware='" + dgv_.Rows[i].Cells[id_ware_col].Value + "'").Rows[0][0].ToString());
                        if (totalqty == 0) totalqty = 1;
                        totalcoststring = (Convert.ToString(db.GetData("select isnull(sum(tot_after_dis_forex),0) from trans_dt where code_items='" + dgv_.Rows[i].Cells[code_items_col].Value + "' and id_ware='" + dgv_.Rows[i].Cells[id_ware_col].Value + "'").Rows[0][0]));
                        if (Convert.ToDecimal(totalcoststring) == 0) totalcoststring = (Convert.ToString(dgv_.Rows[i].Cells[tot_after_dis_e_col].Value));
                        //MessageBox.Show(totalcoststring);
                        totalcost = Convert.ToDecimal(totalcoststring);
                        db.Run("update wares set cost =" + (totalcost / totalqty) + " where code_items='" + dgv_.Rows[i].Cells[code_items_col].Value + "'and id_ware='" + dgv_.Rows[i].Cells[id_ware_col].Value + "'");
                        return;
                    }
                    //2-qty from wares =0
                    else if (Convert.ToDecimal(qty_old) == 0)
                    {
                        //update cost direct from price trans 
                        db.Run("update wares set cost =" + (Convert.ToDecimal((dgv_.Rows[i].Cells[tot_after_dis_e_col].Value)) * Convert.ToDecimal(combo_currance.Text)) / Convert.ToDecimal((dgv_.Rows[i].Cells[qty_col].Value)) + " where code_items='" + dgv_.Rows[i].Cells[code_items_col].Value + "'and id_ware='" + dgv_.Rows[i].Cells[id_ware_col].Value + "'");
                        return;
                    }
                    //3-qty from wares != 0
                    else if (Convert.ToDecimal(qty_old) != 0)
                    {
                        totalqty = Convert.ToDecimal(db.GetData("select isnull(sum(qty * f_unite),0)  from trans_dt where code_items='" + dgv_.Rows[i].Cells[code_items_col].Value + "' and id_ware='" + dgv_.Rows[i].Cells[id_ware_col].Value + "'").Rows[0][0].ToString());
                        if (totalqty == 0) totalqty = 1;
                        totalcoststring = (Convert.ToString(db.GetData("select isnull(sum(tot_after_dis),0) from trans_dt where code_items='" + dgv_.Rows[i].Cells[code_items_col].Value + "' and id_ware='" + dgv_.Rows[i].Cells[id_ware_col].Value + "'").Rows[0][0]));
                        if (Convert.ToDecimal(totalcoststring) == 0) totalcoststring = (Convert.ToString(dgv_.Rows[i].Cells[tot_after_dis_e_col].Value));
                        //MessageBox.Show(totalcoststring);
                        totalcost = Convert.ToDecimal(totalcoststring);
                        db.Run("update wares set cost =" + (totalcost / totalqty) + " where code_items='" + dgv_.Rows[i].Cells[code_items_col].Value + "'and id_ware='" + dgv_.Rows[i].Cells[id_ware_col].Value + "'");
                        return;

                    }




                }
            }

        }
        private void ware_edit_update(DataGridView dgv_, string code_items_col, string id_ware_col, string qty_col, string f_unite_col, string type, string tot_after_dis_ai_col)//incase of add item in edit mode
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
                    qty_new = (Convert.ToDecimal(qty_old) + (Convert.ToDecimal(qty_current))).ToString(); if (Convert.ToDecimal(qty_new) < 0) return;
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
                            db.Run("insert into center(code_items,date,note,wares) values ('" + dgv_delete.Rows[i].Cells[code_items_col].Value + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','Items that have reached the demand limit  ','" + dgv_delete.Rows[i].Cells[id_ware_col].Value + "')");
                        }
                    }
                    if (maximum == true)
                    {
                        if (Convert.ToDecimal(qty_new) >= demand_maximum)
                        {
                            db.Run("insert into center(code_items,date,note,wares) values ('" + dgv_delete.Rows[i].Cells[code_items_col].Value + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','Items that have reached the demand maximum  ','" + dgv_delete.Rows[i].Cells[id_ware_col].Value + "')");
                        }
                    }


                    //*) update cost:= total / QTY  and update cost for ware
                    //_______________________________________________
                    Decimal totalcost = 0;
                    Decimal totalqty = 0;
                    String totalcoststring = "";
                    //qty from wares =0
                    if (Convert.ToDecimal(qty_old) == 0)
                    {
                        //update cost direct from price trans 
                        db.Run("update wares set cost =" + (Convert.ToDecimal((dgv_.Rows[i].Cells[tot_after_dis_ai_col].Value)) * Convert.ToDecimal(txt_f_currance.Text)) / Convert.ToDecimal((dgv_.Rows[i].Cells[qty_col].Value)) + " where code_items='" + dgv_.Rows[i].Cells[code_items_col].Value + "'and id_ware='" + dgv_.Rows[i].Cells[id_ware_col].Value + "'");
                    }
                    //qty from wares != 0
                    else if (Convert.ToDecimal(qty_old) != 0)
                    {
                        totalqty = Convert.ToDecimal(db.GetData("select isnull(sum(qty * f_unite),0)  from trans_dt where code_items='" + dgv_.Rows[i].Cells[code_items_col].Value + "' and id_ware='" + dgv_.Rows[i].Cells[id_ware_col].Value + "'").Rows[0][0].ToString());
                        if (totalqty == 0) totalqty = 1;
                        totalcoststring = (Convert.ToString(db.GetData("select isnull(sum(tot_after_dis_forex),0) from trans_dt where code_items='" + dgv_.Rows[i].Cells[code_items_col].Value + "' and id_ware='" + dgv_.Rows[i].Cells[id_ware_col].Value + "'").Rows[0][0]));
                        if (Convert.ToDecimal(totalcoststring) == 0) totalcoststring = (Convert.ToString(dgv_.Rows[i].Cells[tot_after_dis_ai_col].Value));
                        //MessageBox.Show(totalcoststring);
                        totalcost = Convert.ToDecimal(totalcoststring);
                        db.Run("update wares set cost =" + (totalcost / totalqty) + " where code_items='" + dgv_.Rows[i].Cells[code_items_col].Value + "'and id_ware='" + dgv_.Rows[i].Cells[id_ware_col].Value + "'");
                    }

                }
            }

        }
        private void ware_del_row()
        {
            string qty_old = "0";
            string qty_current = "0";
            string qty_new = "0";
            for (int i = 0; i < dgv_delete.Rows.Count; i++)
            {
                if (dgv_delete.Rows[i].Cells["type_de"].Value.ToString() == "1")
                {
                    qty_old = db.GetData("select qty from wares where code_items='" + dgv_delete.Rows[i].Cells["code_items_de"].Value + "'and id_ware='" + dgv_delete.Rows[i].Cells["id_ware_de"].Value + "'").Rows[0][0].ToString();
                    qty_current = ((Convert.ToDecimal(dgv_delete.Rows[i].Cells["qty_de"].Value)) * (Convert.ToDecimal(dgv_delete.Rows[i].Cells["f_unite_de"].Value))).ToString();
                    qty_new = (Convert.ToDecimal(qty_old) - (Convert.ToDecimal(qty_current))).ToString(); if (Convert.ToDecimal(qty_new) < 0) return;
                    db.Run("update wares set qty =( " + qty_new + ") where code_items='" + dgv_delete.Rows[i].Cells["code_items_de"].Value + "'and id_ware= '" + dgv_delete.Rows[i].Cells["id_ware_de"].Value + "'");

                    //limit and maximum
                    decimal demand_limit = Convert.ToDecimal(db.GetData("select isnull(max(demand_limit),0)  from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'").Rows[0][0].ToString());
                    decimal demand_maximum = Convert.ToDecimal(db.GetData("select isnull(max(demand_maximum),0)  from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'").Rows[0][0].ToString());
                    Boolean limit = Convert.ToBoolean(db.GetData("select demand_limit_bit  from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'").Rows[0][0].ToString());
                    Boolean maximum = Convert.ToBoolean(db.GetData("select demand_maximum_bit  from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and id_ware='" + dgv.Rows[i].Cells["id_ware"].Value + "'").Rows[0][0].ToString());

                    if (limit == true)
                    {
                        if (Convert.ToDecimal(qty_new) <= demand_limit)
                        {
                            db.Run("insert into center(code_items,date,note,wares) values ('" + dgv_delete.Rows[i].Cells["code_items_de"].Value + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','Items that have reached the demand limit  ','" + dgv_delete.Rows[i].Cells["id_ware_de"].Value + "')");
                        }
                    }
                    if (maximum == true)
                    {
                        if (Convert.ToDecimal(qty_new) >= demand_maximum)
                        {
                            db.Run("insert into center(code_items,date,note,wares) values ('" + dgv_delete.Rows[i].Cells["code_items_de"].Value + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','Items that have reached the demand maximum  ','" + dgv_delete.Rows[i].Cells["id_ware_de"].Value + "')");
                        }
                    }

                    //*) update cost:= total / QTY  and update cost for ware
                    //_______________________________________________
                    decimal total_cost = Convert.ToDecimal(db.GetData("select isnull(sum(tot_after_dis_forex),0) from trans_dt where  code_items='" + dgv_delete.Rows[i].Cells["code_items_de"].Value + "' and id_ware='" + dgv_delete.Rows[i].Cells["id_ware_de"].Value + "'").Rows[0][0]);
                    decimal total_specfic = Convert.ToDecimal(db.GetData("select isnull(sum(tot_after_dis_forex),0) from trans_dt where code_items='" + dgv_delete.Rows[i].Cells["code_items_de"].Value + "' and  trans_hd_id='" + txt_serial_string.Text + "'and code_book='" + txt_code_book.Text + "' and id_ware='" + dgv_delete.Rows[i].Cells["id_ware_de"].Value + "'").Rows[0][0]);
                    decimal qty_trans_tot = Convert.ToDecimal(db.GetData("select isnull(sum(qty),0) from trans_dt where  code_items='" + dgv_delete.Rows[i].Cells["code_items_de"].Value + "' and id_ware='" + dgv_delete.Rows[i].Cells["id_ware_de"].Value + "'").Rows[0][0]);
                    decimal qty_trans_specific = Convert.ToDecimal(db.GetData("select isnull(sum(qty),0) from trans_dt where code_items='" + dgv_delete.Rows[i].Cells["code_items_de"].Value + "' and  trans_hd_id='" + txt_serial_string.Text + "'and code_book='" + txt_code_book.Text + "' and id_ware='" + dgv_delete.Rows[i].Cells["id_ware_de"].Value + "'").Rows[0][0]);
                    decimal new_total_cost = 0;
                    decimal cost = 0;

                    new_total_cost = (total_cost - total_specfic);
                    if ((qty_trans_tot - qty_trans_specific) == 0)
                    {
                        cost = (new_total_cost / (1));
                    }
                    else
                    {
                        cost = (new_total_cost / (qty_trans_tot - qty_trans_specific));
                    }
                    db.Run("update wares set cost =" + cost + " where code_items='" + dgv_delete.Rows[i].Cells["code_items_de"].Value + "'and id_ware='" + dgv_delete.Rows[i].Cells["id_ware_de"].Value + "'");
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
                    id_rows = db.GetData("select id_rows from exp_date where code_items='" + dgv_.Rows[i].Cells[code_items_col].Value.ToString() + "' and id_ware='" + dgv_.Rows[i].Cells[id_ware_col].Value.ToString() + "' and code='" + txt_serial_string.Text + "' and code_book='" + txt_code_book.Text + "' and exp_date='" + Convert.ToDateTime(dgv_.Rows[i].Cells[exp_date_1_e_col].Value).ToString("MM-dd-yyyy") + "' and cost='" + dgv_.Rows[i].Cells[tot_after_dis_col_1].Value + "'").Rows[0][0].ToString();
                    if (id_rows == null) { MessageBox.Show("مفيش رصيد او في حاجه غلط مش عارف ....؟!!بس مش عارف ", "مش عارف والله العظيم"); return; }
                    db.Run("delete from exp_date where code_items='" + dgv_.Rows[i].Cells[code_items_col].Value + "' and id_ware='" + dgv_.Rows[i].Cells[id_ware_col].Value + "' and cost='" + dgv_.Rows[i].Cells[tot_after_dis_col_1].Value + "' and exp_date='" + Convert.ToDateTime(dgv_.Rows[i].Cells[exp_date_1_e_col].Value).ToString("MM-dd-yyyy") + "' and id_rows='" + id_rows + "' and code='" + txt_serial_string.Text + "' and code_book='" + txt_code_book.Text + "'");
                    db.Run("insert into exp_date (code_items,name_items,exp_date,qty,cost,id_ware,code,code_book) values('" + dgv_.Rows[i].Cells[code_items_col].Value + "','" + dgv_.Rows[i].Cells[name_items_col].Value + "','" + Convert.ToDateTime(dgv_.Rows[i].Cells[exp_date_e_col].Value).ToString("MM-dd-yyyy") + "','" + (Convert.ToDecimal(dgv_.Rows[i].Cells[qty_col].Value)) * (Convert.ToDecimal(dgv_.Rows[i].Cells[f_unite_col].Value)) + "','" + dgv_.Rows[i].Cells[tot_after_dis_col].Value + "','" + dgv_.Rows[i].Cells[id_ware_col].Value + "',('" + txt_serial_string.Text + "'),('" + txt_code_book.Text + "'))");
                }
            }
        }
        private void exp_insert_edite()
        {
            for (int i = 0; i < dgv_add_items.Rows.Count; i++)
            {
                if (dgv_add_items.Rows[i].Cells["type_ai"].Value.ToString() == "1" && dgv_add_items.Rows[i].Cells["exp_ai"].Value.ToString() == "True")
                {
                    db.Run("insert into exp_date (code_items,name_items,exp_date,qty,cost,id_ware,code,code_book) values('" + dgv_add_items.Rows[i].Cells["code_items_ai"].Value + "','" + dgv_add_items.Rows[i].Cells["name_items_ai"].Value + "','" + Convert.ToDateTime(dgv_add_items.Rows[i].Cells["exp_date_1_ai"].Value).ToString("MM-dd-yyyy") + "','" + (Convert.ToDecimal(dgv_add_items.Rows[i].Cells["qty_ai"].Value)) * (Convert.ToDecimal(dgv_add_items.Rows[i].Cells["f_unite_ai"].Value)) + "','" + dgv_add_items.Rows[i].Cells["tot_after_dis_ai"].Value + "','" + dgv_add_items.Rows[i].Cells["id_ware_ai"].Value + "',('" + txt_serial_string.Text + "'),('" + txt_code_book.Text + "')) ");
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
                    id_rows = db.GetData("select id_rows from exp_date where code_items='" + dgv_delete.Rows[i].Cells["code_items_de"].Value.ToString() + "' and id_ware='" + dgv_delete.Rows[i].Cells["id_ware_de"].Value.ToString() + "' and code='" + txt_serial_string.Text + "' and code_book='" + txt_code_book.Text + "' and exp_date='" + Convert.ToDateTime(dgv_delete.Rows[i].Cells["exp_date_1_de"].Value).ToString("MM-dd-yyyy") + "' and cost='" + dgv_delete.Rows[i].Cells["tot_after_dis1_de"].Value + "'").Rows[0][0].ToString();
                    db.Run("delete from exp_date where code_items='" + dgv_delete.Rows[i].Cells["code_items_de"].Value + "' and id_ware='" + dgv_delete.Rows[i].Cells["id_ware_de"].Value + "' and id_rows='" + id_rows + "' and code='" + txt_serial_string.Text + "' and code_book='" + txt_code_book.Text + "'");
                }

            }
        }
        //====================================controls 

        string code_entry, sort, rootlevel, rootlevel_name, type_acc;
        private void comb_code_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_code_book.Text = db.GetData("select code_book from book where name_book='" + comb_code_name.Text + "'").Rows[0][0].ToString();
            //cls_book.selectbook("trans_hd", "سند تحويل مخزني", txt_code_book.Text, txt_serial, "trans_hd_id");
            //txt_serial_string.Text = txt_code_book.Text + txt_serial.Text;
            //lbl_comb_code_name.Text = comb_code_name.Text;

            cls_book.Generat_numBooknum("trans_hd", txt_code_book.Text, ref numBook, ref error, ref num);
            txt_serial_string.Text = numBook;
        }

       
        //=========================================
        //==============================dgv
        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv);
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
                // load_combo_cost_exp_editmode();
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
            try
            {
                if (edit == true)
                {
                    dgv.CurrentRow.Cells["add_items1"].Value = 2;

                    //////////////////////  if (dgv.CurrentRow.Cells["add_items"].Value.ToString() != "1" && edit== true)
                    //////////////////////{
                    //////////////////////    dgv_edit.Rows.Add(1, dgv.CurrentRow.Cells["code_items"].Value.ToString(), dgv.CurrentRow.Cells["name_items"].Value.ToString(), dgv.CurrentRow.Cells["name_unite"].Value.ToString(), dgv.CurrentRow.Cells["f_unite"].Value.ToString(), dgv.CurrentRow.Cells["exp"].Value.ToString(), dgv.CurrentRow.Cells["type"].Value.ToString(), (dgv.CurrentRow.Cells["exp_date_1"].Value).ToString(), (dgv.CurrentRow.Cells["exp_date"].Value).ToString(), (dgv.CurrentRow.Cells["qty"].Value).ToString(), (dgv.CurrentRow.Cells["item_price"].Value).ToString(), (dgv.CurrentRow.Cells["tot_bef"].Value).ToString(), (dgv.CurrentRow.Cells["discount"].Value).ToString(), (dgv.CurrentRow.Cells["tot_after_dis"].Value).ToString(), (dgv.CurrentRow.Cells["taxes"].Value).ToString(), (dgv.CurrentRow.Cells["incloud_taxes"].Value).ToString(), (dgv.CurrentRow.Cells["taxes_value"].Value).ToString(), (dgv.CurrentRow.Cells["id_ware"].Value).ToString(), (dgv.CurrentRow.Cells["item_qty1"].Value).ToString(), (dgv.CurrentRow.Cells["purchase_dt_id"].Value).ToString(),(dgv.CurrentRow.Cells["tot_after_dis1"].Value).ToString(), txt_serial.Text, txt_code_book.Text);
                    //////////////////////    if (dgv.CurrentRow.Cells["exp"].Value.ToString() == "True") load_combo_cost_exp_editmode();
                    //////////////////////}
                }
                calc_current_user();
                dgv_satue_cost_bal_vcs_dis_min_max();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            all_comb.load_unite(combo_unit, dgv.CurrentRow.Cells["code_items"].Value.ToString());
            lbl_f_unite.Text = (db.GetData("select (unite) from unite where name_unite='" + combo_unit.Text + "'").Rows[0][0].ToString());
            all_comb.load_exp_date(combo_exp, dgv.CurrentRow.Cells["code_items"].Value.ToString(), dgv.CurrentRow.Cells["id_ware"].Value.ToString());
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
            if (dgv.CurrentCell.ColumnIndex == 8) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(Column1_KeyPress);
                }
            }

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
        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (dgv.Rows.Count <= 0)
                {
                    MessageBox.Show("لازم يكون في سطر واحد علي الاقل ");
                    return;
                }
                //chek qty 
                Decimal qty_old, qty_current, qty_new;
                qty_old = Convert.ToDecimal(db.GetData("select qty from wares where code_items='" + dgv.CurrentRow.Cells["code_items"].Value + "'and id_ware='" + dgv.CurrentRow.Cells["id_ware"].Value + "'").Rows[0][0]);
                qty_current = (Convert.ToDecimal(dgv.CurrentRow.Cells["qty"].Value)) * (Convert.ToDecimal(dgv.CurrentRow.Cells["f_unite"].Value));
                qty_new = qty_old - qty_current;
                if (edit == true)
                {
                    if (qty_new < 0)
                    {
                      //  XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "مينفعش مفيش رصيد من الصنف  والفتوره مغلقه ويجب توريد او مسح فاتوره مبيعات  " + "  Codeitems=" + dgv.CurrentRow.Cells["code_items"].Value + "", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
               // delete_row_and_move_to_dgv_Delete();
            }
            if (e.KeyCode == Keys.Delete && Control.ModifierKeys == Keys.Control)
            {
               // delete();
            }
        }
        //==============================simple controls
        private void combo_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_name_book_type.Text = db.GetData("select bookname_entry  from term  where term_id ='" + combo_type.Text + "'").Rows[0][0].ToString();
            txt_code_entry_type.Text = db.GetData("select code_entry  from term  where term_id ='" + combo_type.Text + "'").Rows[0][0].ToString();
            cls_book.selectbook("entry_hd", "سند قيد", txt_code_entry_type.Text, txt_code_entry, "code_entry");
           
            
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

        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            add_items_in_dgv();
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (combo_unit.Text != "")
            {
                add_unite_();
                // dgv.CurrentRow.Cells["type"].Value = 2;
                dgv.CurrentRow.Cells["qty"].Value = 0;
                dgv.CurrentRow.Cells["item_price"].Value = Convert.ToDouble(lbl_f_unite.Text) * Convert.ToDouble(price_items_a);
            }
        }
        private void btn_add_exp_Click(object sender, EventArgs e)
        {
            dgv.CurrentRow.Cells["exp_date"].Value = dt_exp.Value;
            dgv.CurrentRow.Cells["add_items1"].Value = 2;
        }
        private void combo_add_items_Click(object sender, EventArgs e)
        {
            all_comb.load_items_for_sale(combo_add_items);

        }
        private void combo_vsc_codetree_Click(object sender, EventArgs e)
        {
            all_comb.load_code_vcs(combo_vsc_codetree);

        }
        private void combo_vcs_Click(object sender, EventArgs e)
        {
            all_comb.load_vcs(combo_vcs);

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
        //==============================Hotkeys controls
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
                     string  type = db.GetData("select isnull(max(type),null) from items where code_items='" + str1 + "'").Rows[0][0].ToString();
                     string menu = db.GetData("select isnull(max(menu),null) from items where code_items='" + str1 + "'").Rows[0][0].ToString();

                    if (code_items_a == "")
                        code_items_a = db.GetData("select isnull(max(code_items),null) from barcode where barcode='" + txt_barcode.Text + "'").Rows[0][0].ToString();
                    if (code_items_a == "")
                    {
                        XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "لايوجد صنف  ..يجب تكويد الصنف", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.txt_barcode.Clear();
                    }
                 
                    else if (type=="2" || menu=="1")
                    {
                        XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, " الصنف خدمي او الصنف مطاعم ولايمكن استخدامة", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.txt_barcode.Clear();
                    }
                    else
                    {
                        //  this.name_items_a = !this.chk_search_lang.Checked ? db.GetData("select isnull(max(name_items2),0) from items where code_items='" + this.code_items_a + "'").Rows[0][0].ToString() : db.GetData("select isnull(max(name_items),0) from items where code_items='" + this.code_items_a + "'").Rows[0][0].ToString();
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
                       // lbl_code_items.Text = "1";
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
        private void btn_delete_file_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            delete();
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
        private void combo_add_items_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                add_items_in_dgv();
            }
        }
        private void frm_trans_items_KeyDown(object sender, KeyEventArgs e)
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
                delete();
            }
        }
        //===========================================================NAvigation

        private void First_barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                string s = "";
                s = db.GetData("select min(trans_hd_id) from trans_hd where  code_book='" + txt_code_book.Text + "' ").Rows[0][0].ToString();
                if (s != "")
                {
                    txt_serial_string.Text = db.GetData("select min(trans_hd_id) from trans_hd where  code_book='" + txt_code_book.Text + "' ").Rows[0][0].ToString();
                    bode_of_navigation(txt_serial_string.Text, txt_code_book.Text);
                }
            }
            catch (Exception)
            {


            }
        }
        private void Last_barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string s = "";
                s = db.GetData("select max(trans_hd_id) from trans_hd where  code_book='" + txt_code_book.Text + "'").Rows[0][0].ToString();
                if (s != "")
                {
                    txt_serial_string.Text = db.GetData("select max(trans_hd_id) from trans_hd where  code_book='" + txt_code_book.Text + "'").Rows[0][0].ToString();
                    bode_of_navigation(txt_serial_string.Text, txt_code_book.Text);
                }
            }
            catch (Exception)
            {


            }
        }
        private void Back_barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string s = "";
                s = db.GetData("select min(trans_hd_id) from trans_hd where code_book='" + txt_code_book.Text + "'").Rows[0][0].ToString();
                if (s != "")
                {
                    edit = true;
                    {

                        DataTable dt = new DataTable();
                        dt.Rows.Clear();
                        string st = "";
                        st = db.GetData("select min(trans_hd_id) from trans_hd where code_book='" + txt_code_book.Text + "'").Rows[0][0].ToString();
                        st = st.Remove(0, 1);
                        st = st.Remove(0, 2);

                        int m = int.Parse(st);
                        string num_without;
                        num_without = txt_serial_string.Text;
                        num_without = num_without.Remove(0, 1);
                        num_without = num_without.Remove(0, 2);

                        //clearANDauto();
                        if (int.Parse(num_without) <= m)
                            MessageBox.Show("اخر ملف");
                        else
                        {
                            int num = +(Int32.Parse(num_without) - 1);
                            txt_serial_string.Text = txt_code_book.Text + num;
                            bode_of_navigation(txt_serial_string.Text, txt_code_book.Text);
                        }
                    }
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
                string s = "";
                s = db.GetData("select max(trans_hd_id) from trans_hd where code_book='" + txt_code_book.Text + "'").Rows[0][0].ToString();
                if (s != "")
                {
                    edit = true;

                    // lbl_state.t
                    DataTable dt = new DataTable();
                    dt.Rows.Clear();
                    string st = "";

                    st = db.GetData("select max(trans_hd_id) from trans_hd where code_book='" + txt_code_book.Text + "'").Rows[0][0].ToString();
                    st = st.Remove(0, 1);
                    st = st.Remove(0, 2);

                    int m = int.Parse(st);
                    string num_without;
                    num_without = txt_serial_string.Text;
                    num_without = num_without.Remove(0, 1);
                    num_without = num_without.Remove(0, 2);
                    //clearANDauto();
                    if (int.Parse(num_without) >= m)
                        MessageBox.Show("اول م ملف");
                    else
                    {
                        int num = +(Int32.Parse(num_without) + 1);
                        txt_serial_string.Text = txt_code_book.Text + num;
                        bode_of_navigation(txt_serial_string.Text, txt_code_book.Text);
                    }
                }

            }
            catch (Exception)
            {

            }
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
           // book loaded:-
           // cls_book.load_from_terms(combo_type);
           // =============insert in dgv term 
            string term_id, rootid1, rootname1, depit1, credit1,type_acc1,sort_1,rootlevel1;
            string rootid2, rootname2, depit2, credit2, type_acc2, sort_2, rootlevel2;

      
            rootid2 = db.GetData("select rootid from wares_acc where id_ware='" + combo_wars2.Text + "' ").Rows[0][0].ToString();
            rootname2 = db.GetData("select rootname from wares_acc where id_ware='" + combo_wars2.Text + "' ").Rows[0][0].ToString();
            depit2 = db.GetData("select depit from term where cat_book='سند تحويل مخزني' and term_id='" + combo_type.Text + "'").Rows[0][0].ToString();
            credit2 = db.GetData("select credit from term where cat_book='سند تحويل مخزني' ").Rows[1][0].ToString();
            type_acc2 = db.GetData("select sort from tree where rootid='" + rootid2 + "' ").Rows[0][0].ToString();
            rootlevel2 = db.GetData("select rootlevel from tree where rootid='" + rootid2 + "' ").Rows[0][0].ToString();

            sort_2 = "1";
            //==============

            rootid1 = db.GetData("select rootid from wares_acc where id_ware='" + combo_wars.Text + "' ").Rows[0][0].ToString();
            rootname1 = db.GetData("select rootname from wares_acc where id_ware='" + combo_wars.Text + "' ").Rows[0][0].ToString();
            depit1 = db.GetData("select depit from term where cat_book='سند تحويل مخزني' and term_id='" + combo_type.Text + "'").Rows[0][0].ToString();
            credit1 = db.GetData("select credit from term where cat_book='سند تحويل مخزني' ").Rows[1][0].ToString();
            type_acc1 = db.GetData("select sort from tree where rootid='" + rootid1 + "' ").Rows[0][0].ToString();
            rootlevel1 = db.GetData("select rootlevel from tree where rootid='" + rootid1 + "' ").Rows[0][0].ToString();

            sort_1 = "1";


            //    //==================================================

                //========fill field tot or tot_bef or discount=======
                if (depit1 == "tot_befor")
                {
                    depit1 = lbl_tot_befor.Text;
                }
                else if (depit1 == "tot_after_dis")
                {
                    depit1 = lbl_tot_after_dis.Text;
                }
                else if (depit1 == "discount")
                {
                    depit1 = lbl_discount.Text;
                }
                else if (depit1 == "incloud_taxes")
                {
                    depit1 = lbl_incloud_taxes.Text;
                }
                else if (depit1 == "vat_add")
                {
                    depit1 = lbl_vat_add.Text;
                }
                else if (depit1 == "taxtes")
                {
                    depit1 = lbl_taxes_values.Text;
                }
                else
                {
                    depit1 = "0";
                }
                if (credit1 == "tot_befor")
                {
                    credit1 = lbl_tot_befor.Text;
                }
                else if (credit1 == "tot_after_dis")
                {
                    credit1 = lbl_tot_after_dis.Text;
                }
                else if (credit1 == "discount")
                {
                    credit1 = lbl_discount.Text;
                }
                else if (credit1 == "incloud_taxes")
                {
                    credit1 = lbl_incloud_taxes.Text;
                }
                else if (credit1 == "taxtes")
                {
                    credit1 = lbl_taxes_values.Text;
                }
                else if (credit1 == "vat_add")
                {
                    credit1 = lbl_vat_add.Text;
                }
                else
                {
                    credit1 = "0";
                }
            //=======================================
                if (depit2 == "tot_befor")
                {
                    depit2 = lbl_tot_befor.Text;
                }
                else if (depit2 == "tot_after_dis")
                {
                    depit2 = lbl_tot_after_dis.Text;
                }
                else if (depit2 == "discount")
                {
                    depit2 = lbl_discount.Text;
                }
                else if (depit2 == "incloud_taxes")
                {
                    depit2 = lbl_incloud_taxes.Text;
                }
                else if (depit2 == "vat_add")
                {
                    depit2 = lbl_vat_add.Text;
                }
                else if (depit2 == "taxtes")
                {
                    depit2 = lbl_taxes_values.Text;
                }
                else
                {
                    depit2 = "0";
                }
                if (credit2 == "tot_befor")
                {
                    credit2 = lbl_tot_befor.Text;
                }
                else if (credit2 == "tot_after_dis")
                {
                    credit2 = lbl_tot_after_dis.Text;
                }
                else if (credit2 == "discount")
                {
                    credit2 = lbl_discount.Text;
                }
                else if (credit2 == "incloud_taxes")
                {
                    credit2 = lbl_incloud_taxes.Text;
                }
                else if (credit2 == "taxtes")
                {
                    credit2 = lbl_taxes_values.Text;
                }
                else if (credit2 == "vat_add")
                {
                    credit2 = lbl_vat_add.Text;
                }
                else
                {
                    credit2 = "0";
                }
          ////////////////////  =========================================================
            dgv_term.Rows.Add(0, rootid2, rootname2,depit2,    0   ,rootlevel2 ,0  ,sort_2 ,type_acc2);
            dgv_term.Rows.Add(0, rootid1, rootname1, 0    , credit1,rootlevel1 , 0 ,sort_1 , type_acc1);

           
        }

     

        private void button1_Click(object sender, EventArgs e)
        {
            select_type_entry();
            //get only number for one user Entry
            txt_entry_string.Text = txt_code_entry_type.Text + txt_code_entry.Text;
            cls_book.selectbook("entry_hd", "سند قيد", txt_code_entry_type.Text, txt_code_entry, "code_entry");
            txt_entry_string.Text = txt_code_entry_type.Text + txt_code_entry.Text;

            //get only number for one user trans
            txt_code_book.Text = db.GetData("select code_book from book where name_book='" + comb_code_name.Text + "'").Rows[0][0].ToString();
            cls_book.selectbook("trans_hd", "سند تحويل مخزني", txt_code_book.Text, txt_serial, "trans_hd_id");
            txt_serial_string.Text = txt_code_book.Text + txt_serial.Text;


            db.Run("insert into entry_hd ([code_entry],code_book) values ('" + txt_entry_string.Text + "','" + txt_code_entry_type.Text + "')");
            //entry_hd
            for (int z = 0; z < dgv_term.Rows.Count; z++)
            {
                //  cls_book.selectbook("entry", "سند قيد", txt_code_book.Text, txt_serial, "code_entry");
                //  txt_serial_string.Text = txt_code_book.Text + txt_serial.Text;
            //    db.Run("insert into entry(  [code_entry]                           ,    acc_num                                                   ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                                          ,   type_acc                                                            , sort                                                       ,             depit                                                             ,                credit                                                   ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext )values('" +
              //                            txt_entry_string.Text + "'            ,'" + dgv_term.Rows[z].Cells[1].Value.ToString() + "'     ,'" + dgv_term.Rows[z].Cells[2].Value.ToString() + "'               ,  '" + dgv_term.Rows[z].Cells["rootlevel_"].Value.ToString() + "'    ,  '" + dgv_term.Rows[z].Cells["rootlevel_name_"].Value.ToString() + "', '" + dgv_term.Rows[z].Cells["type_acc_"].Value.ToString() + "'       ,  '" + dgv_term.Rows[z].Cells["sort_"].Value.ToString() + "'  ,  '" + Convert.ToDecimal(dgv_term.Rows[z].Cells[3].Value.ToString()) * Convert.ToDecimal(txt_f_currance.Text) + "'      ,'" + Convert.ToDecimal(dgv_term.Rows[z].Cells[4].Value.ToString()) * Convert.ToDecimal(txt_f_currance.Text) + "' ,'" + txt_name_book_type.Text + "','" + txt_code_entry_type.Text + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + txt_serial_string.Text + "','" + txt_code_book.Text + "','" + comb_code_name.Text + "','" + txt_note.Text + "')");

                    db.Run("insert into entry(  [code_entry]                           ,    acc_num                                                   ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                                          ,   type_acc                                                            , sort                                                       ,             depit                                                                                 ,                credit                                                   ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext )values('" +
                                          txt_entry_string.Text + "'            ,'" + dgv_term.Rows[z].Cells[1].Value.ToString() + "'     ,'" + dgv_term.Rows[z].Cells[2].Value.ToString() + "'               ,  '" + dgv_term.Rows[z].Cells["rootlevel_"].Value.ToString() + "'    ,  '" + dgv_term.Rows[z].Cells["rootlevel_name_"].Value.ToString() + "', '" + dgv_term.Rows[z].Cells["type_acc_"].Value.ToString() + "'       ,  '" + dgv_term.Rows[z].Cells["sort_"].Value.ToString() + "'  ,  '" + Convert.ToDecimal(dgv_term.Rows[z].Cells[3].Value.ToString()) * Convert.ToDecimal(txt_f_currance.Text) + "'      ,'" + Convert.ToDecimal(dgv_term.Rows[z].Cells[4].Value.ToString()) * Convert.ToDecimal(txt_f_currance.Text) + "' ,'" + txt_name_book_type.Text + "','" + txt_code_entry_type.Text + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + txt_serial_string.Text + "','" + txt_code_book.Text + "','" + comb_code_name.Text + "','" + txt_note.Text + "')");
            
            }
        }

       

        private void combo_vcs_name_f_Click_1(object sender, EventArgs e)
        {

        }

     
        private void combo_vcs_name_f_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

     

        private void btn_searchin_group_f3_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_searchin_group_f1_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_searchin_group_f2_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_close_f_Click(object sender, EventArgs e)
        {
        }

        private void dgv_f_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
        }

        private void dgv_f_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }

        private void combo_document_f_Click(object sender, EventArgs e)
        {

        }

        private void f_barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


        }
            private void txt_serial_Leave(object sender, EventArgs e)
            {

        }

        private void txt_serial_DoubleClick(object sender, EventArgs e)
        {
           

        }
        private void txt_serial_string_Leave(object sender, EventArgs e)
        {
            bode_of_navigation(txt_serial_string.Text, txt_code_book.Text);
        }
        private void txt_serial_string_DoubleClick(object sender, EventArgs e)
        {

            v.search_screen = "trans";
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