using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace f1
{
    class cls_book
    {
        public static void loadbook(ComboBox comb, string catbook)
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("select name_book  from book where cat_book= '" + catbook + "'", dt);
            comb.DisplayMember = "name_book";
            comb.DataSource = dt;
        }
        public static void load_wares_acc(ComboBox combo)
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("select distinct acc_name from wares_acc  ", dt);
            combo.DisplayMember = "acc_name";
            combo.DataSource = dt;
        }

        public static void selectbook(string table, string catbook, string txt_code_book_control, TextBox txt_serial_control, string code_entry_max)
        {
            string code_book, get_first_number_in_book, get_last_number_in_book;
            int get_max_number_in_book_and_add_1_int = 0;
            string get_max_number_in_book_and_add_1 = "0";
            try
            {

                get_max_number_in_book_and_add_1 = db.GetData("select max(convert(int,(right(" + code_entry_max + ", len(" + code_entry_max + ")-3)))) from " + (table) + " where code_book='" + txt_code_book_control + "'").Rows[0][0].ToString();
                // get_max_number_in_book_and_add_1 = get_max_number_in_book_and_add_1.Remove(0, 1);
                // get_max_number_in_book_and_add_1 = get_max_number_in_book_and_add_1.Remove(0, 2);
                get_max_number_in_book_and_add_1_int = Convert.ToInt32(get_max_number_in_book_and_add_1) + 1;
                code_book = db.GetData("select (code_book)from " + (table) + " where code_book='" + txt_code_book_control + "'").Rows[0][0].ToString();
                get_first_number_in_book = db.GetData("select (start)from book where code_book='" + txt_code_book_control + "' and cat_book='" + catbook + "'").Rows[0][0].ToString();
                get_last_number_in_book = db.GetData("select [end] from book where code_book='" + txt_code_book_control + "' and cat_book='" + catbook + "'").Rows[0][0].ToString();

                //if found book 
                if (code_book != "")
                {
                    //get max number in book and add +1
                    //{cheak is not last number in book}
                    if (Convert.ToInt32(get_last_number_in_book) < Convert.ToInt32(get_max_number_in_book_and_add_1))
                    {
                        MessageBox.Show("last number in book"); txt_serial_control.Text = ""; return;
                    }
                    //ok print
                    txt_serial_control.Text = get_max_number_in_book_and_add_1_int.ToString();
                }
                //if not found book
                else
                {
                    //get first number in book 
                    //{cheak is not last number in book}
                    if (Convert.ToInt32(get_last_number_in_book) < (get_max_number_in_book_and_add_1_int))
                    {
                        MessageBox.Show("last number in book"); txt_serial_control.Text = ""; return;
                    }
                }

            }
            catch (Exception m)
            {
                ////steal not found it resalt 
                // MessageBox.Show(m.Message + "مش موجود ");
                get_first_number_in_book = db.GetData("select (start)from book where code_book='" + txt_code_book_control + "' and cat_book='" + catbook + "'").Rows[0][0].ToString();
                txt_serial_control.Text = get_first_number_in_book;
            }

        }

        public static string Generat_numBook(string cat, string tbl_id, string tbl_name, ref string numBook)
        {
            string get_first_number_in_book, get_last_number_in_book;
            string MAX_id, code_book;

            code_book = db.GetData("select isnull(max(code_book),'')from book where cat_book='" + cat + "'").Rows[0][0].ToString();
            MAX_id = db.GetData("select ISNULL(max(convert(int,(right(" + tbl_id + ", len(" + tbl_id + ")-3))))+1,'0') from " + (tbl_name) + " where code_book='" + code_book + "'").Rows[0][0].ToString();
            get_first_number_in_book = db.GetData("select (start)from book where code_book='" + code_book + "'").Rows[0][0].ToString();
            get_last_number_in_book = db.GetData("select [end] from book where code_book='" + code_book + "'").Rows[0][0].ToString();

            //if not found Document (id ) in table  
            if (MAX_id == "0")
            {
                numBook = code_book + 1;
            }
            //if  found Document (id ) in table  
            else
            {
                numBook = code_book + MAX_id;
            }

            return numBook;
        }

        public static string Generat_numBooknum(string tbl_name,string code_book, ref string numBook ,ref string error,ref int num)
        {
            double MAX_id,get_first_number_in_book, get_last_number_in_book;

           // code_book = db.GetData("select isnull(max(code_book),'')from book where cat_book='" + cat + "'").Rows[0][0].ToString();
            //MAX_id = db.GetData("select ISNULL(max(convert(int,(right(" + tbl_id + ", len(" + tbl_id + ")-3))))+1,'0') from " + (tbl_name) + " where code_book='" + code_book + "'").Rows[0][0].ToString();
            MAX_id = Convert.ToDouble(db.GetData("select isnull((max(num_book)),'0') from " + (tbl_name) + " where code_book='" + code_book + "'").Rows[0][0].ToString());
            get_last_number_in_book = Convert.ToDouble(db.GetData("select isnull(max([end]),'0') from book where code_book='" + code_book + "'").Rows[0][0].ToString());

            //if not found Document (id ) in table  
            if (MAX_id == 0)
            {
                get_first_number_in_book = Convert.ToDouble(db.GetData("select isnull(max(start),'0') from book where code_book='" + code_book + "'").Rows[0][0].ToString());
                numBook = code_book + (MAX_id + 1);
                num = Convert.ToInt32(MAX_id + 1);
            }
            else if ((MAX_id + 1)> get_last_number_in_book)
            {
                error = "last number in book";

            }
            //if  found Document (id ) in table  
            else
            {
                numBook = code_book + (MAX_id+1);
                num = Convert.ToInt32(MAX_id + 1);

            }

            return numBook;
        }
        public static void Make_entry_type_purchase(ref DataTable dt_term, ref string error, string cat, string term_id, string id_wares, string id_vcs, string tot_befor, string tot_after_dis, string discount, string incloud_taxes, string vat_add, string taxes_values,  string cogs="")
        {
            // DataTable dt_term= new DataTable();
            dt_term.Rows.Clear();
            dt_term.Columns.Add("term_id");
            dt_term.Columns.Add("rootid");
            dt_term.Columns.Add("rootname");
            dt_term.Columns.Add("depit");
            dt_term.Columns.Add("credit");
            dt_term.Columns.Add("rootlevel");
            dt_term.Columns.Add("rootlevel_name");
            dt_term.Columns.Add("sort");
            dt_term.Columns.Add("type_acc");
            string code_entry, sort, rootlevel, rootlevel_name, type_acc;


            //book loaded:-
            //cls_book.load_from_terms(comb_type);
            //=============insert in dgv term 
            string rootid , rootname , depit, credit;
            int term_type;
            //  DataTable dt_term = new DataTable();

            //int count = Convert.ToInt32(db.GetData("select count(term_id) from term where term_id='" + combo_type.Text + "' and cat_book='سند فاتوره مشتريات'").Rows[0][0].ToString());
            int count = Convert.ToInt32(db.GetData("select count(term_id) from term where term_id='" + term_id + "' and cat_book='" + cat + "'").Rows[0][0].ToString());

            //code_entry = (db.GetData("select code_entry from term where term_id='" + combo_type.Text + "' and cat_book='سند فاتوره مشتريات'").Rows[0][0].ToString());
            code_entry = (db.GetData("select code_entry from term where term_id='" + term_id + "' and cat_book='" + cat + "'").Rows[0][0].ToString());

            //string bookname_entry = (db.GetData("select bookname_entry from term where term_id='" + combo_type.Text + "' and cat_book='سند فاتوره مشتريات'").Rows[0][0].ToString());
            int c = 0;
            while (c < count)
            {
                int i = c++;
                 term_id = db.GetData("select term_id from term where term_id='" + term_id + "' and cat_book='" + cat + "'").Rows[i][0].ToString();
                term_type = Convert.ToInt32(db.GetData("select term_type from term where term_id='" + term_id + "'and cat_book='" + cat + "'").Rows[i][0] + "");
              //  rootid="";
               // string x = db.GetData2("select  rootid from term where term_id='" + term_id + "'and cat_book='" + cat + "'").Rows[i][0] + "";
                rootid = db.GetData("select  rootid from term where term_id='" + term_id + "'and cat_book='" + cat + "'").Rows[i][0]+"";
                rootname = db.GetData("select rootname from term where term_id='" + term_id + "'and cat_book='" + cat + "'").Rows[i][0].ToString();
                depit = db.GetData("select depit from term where term_id='" + term_id + "'and cat_book='" + cat + "'").Rows[i][0].ToString();
                credit = db.GetData("select credit from term where term_id='" + term_id + "'and cat_book='" + cat + "'").Rows[i][0].ToString();

                //==============================================

                if (term_type == 1)//wares

                {
                    rootid = db.GetData("" + rootid + "" + id_wares + "" + "").Rows[0][0].ToString();
                    rootname = db.GetData("" + rootname + "" + id_wares + "" + "").Rows[0][0].ToString();
                    rootlevel = db.GetData("select rootlevel from tree where rootid='" + rootid + "'").Rows[0][0].ToString();
                    rootlevel_name = "0";
                    type_acc = db.GetData("select sort from tree where rootid='" + rootid + "'").Rows[0][0].ToString();
                    sort = "1";
                }
                else if (term_type == 2)//vendor or clint 
                {
                    if (id_vcs == "") { error = "vcs not found"; return; }
                    rootid = db.GetData("" + rootid + "" + id_vcs + "" + "").Rows[0][0].ToString();
                    rootname = db.GetData("" + rootname + "" + id_vcs + "" + "").Rows[0][0].ToString();
                    rootlevel = db.GetData("select rootlevel from vcs where vcs_code='" + id_vcs + "'").Rows[0][0].ToString();
                    rootlevel_name = db.GetData("select rootlevel_name from vcs where vcs_code='" + id_vcs + "'").Rows[0][0].ToString();
                    type_acc = db.GetData("select sort from vcs where vcs_code='" + id_vcs + "'").Rows[0][0].ToString();

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
                    depit = tot_befor;
                    if (depit == "") depit = "0";

                }
                else if (depit == "tot_after_dis")
                {
                    depit = tot_after_dis;
                    if (depit == "") depit = "0";

                }
                else if (depit == "discount")
                {
                    depit = discount;
                    if (depit == "") depit = "0";

                }
                else if (depit == "incloud_taxes")
                {
                    depit = incloud_taxes;
                    if (depit == "") depit = "0";

                }
                else if (depit == "vat_add")
                {
                    depit = vat_add;
                    if (depit == "") depit = "0";

                }
                else if (depit == "taxtes")
                {
                    depit = taxes_values;
                    if (depit == "") depit = "0";

                }
                else if (depit == "cost")
                {
                    depit = cogs;
                    if (depit == "") depit = "0";
                }
                else
                {
                    depit = "0";
                    if (depit == "") depit = "0";

                }
                if (credit == "tot_befor")
                {
                    credit = tot_befor;
                    if (credit == "") credit = "0";

                }
                else if (credit == "tot_after_dis")
                {
                    credit = tot_after_dis;
                    if (credit == "") credit = "0";

                }
                else if (credit == "discount")
                {
                    credit = discount;
                    if (credit == "") credit = "0";

                }
                else if (credit == "incloud_taxes")
                {
                    credit = incloud_taxes;
                    if (credit == "") credit = "0";

                }
                else if (credit == "taxtes")
                {
                    credit = taxes_values;
                    if (credit == "") credit = "0";

                }
                else if (credit == "vat_add")
                {
                    credit = vat_add;
                    if (credit == "") credit = "0";

                }
                else if (credit == "cost")
                {
                    credit = cogs;
                    if (credit == "") credit = "0";

                }
                else
                {
                    credit = "0";
                    if (credit == "") credit = "0";

                }

                if (depit != "0" || credit != "0")
                {
                    dt_term.Rows.Add(term_id, rootid, rootname, depit, credit, rootlevel, rootlevel_name, sort, type_acc);

                }


            }

            //============end of terms        
        }
        public static void Make_entry_type_issue(ref DataTable dt_term, ref string error, string cat, string term_id, string id_wares, string id_vcs, string tot)
        {
            // DataTable dt_term= new DataTable();
            dt_term.Rows.Clear();
            dt_term.Columns.Add("term_id");
            dt_term.Columns.Add("rootid");
            dt_term.Columns.Add("rootname");
            dt_term.Columns.Add("depit");
            dt_term.Columns.Add("credit");
            dt_term.Columns.Add("rootlevel");
            dt_term.Columns.Add("rootlevel_name");
            dt_term.Columns.Add("sort");
            dt_term.Columns.Add("type_acc");
            string code_entry, sort, rootlevel, rootlevel_name, type_acc;


            //book loaded:-
            //cls_book.load_from_terms(comb_type);
            //=============insert in dgv term 
            string rootid, rootname, depit, credit;
            int term_type;
            //  DataTable dt_term = new DataTable();

            //int count = Convert.ToInt32(db.GetData("select count(term_id) from term where term_id='" + combo_type.Text + "' and cat_book='سند فاتوره مشتريات'").Rows[0][0].ToString());
            int count = Convert.ToInt32(db.GetData("select count(term_id) from term where term_id='" + term_id + "' and cat_book='" + cat + "'").Rows[0][0].ToString());

            //code_entry = (db.GetData("select code_entry from term where term_id='" + combo_type.Text + "' and cat_book='سند فاتوره مشتريات'").Rows[0][0].ToString());
            code_entry = (db.GetData("select code_entry from term where term_id='" + term_id + "' and cat_book='" + cat + "'").Rows[0][0].ToString());

            //string bookname_entry = (db.GetData("select bookname_entry from term where term_id='" + combo_type.Text + "' and cat_book='سند فاتوره مشتريات'").Rows[0][0].ToString());
            int c = 0;
            while (c < count)
            {
                int i = c++;
            term_id = db.GetData("select term_id from term where term_id='" + term_id + "'").Rows[i][0].ToString();
                term_type = Convert.ToInt32(db.GetData("select term_type from term where term_id='" + term_id + "'").Rows[i][0] + "");
                rootid = db.GetData("select rootid from term where term_id='" + term_id + "'").Rows[i][0].ToString();
                rootname = db.GetData("select rootname from term where term_id='" + term_id + "'").Rows[i][0].ToString();
                depit = db.GetData("select depit from term where term_id='" + term_id + "'").Rows[i][0].ToString();
                credit = db.GetData("select credit from term where term_id='" + term_id + "'").Rows[i][0].ToString();

                //==============================================

                if (term_type == 1)//wares

                {
                    rootid = db.GetData("" + rootid + "" + id_wares + "" + "").Rows[0][0].ToString();
                    rootname = db.GetData("" + rootname + "" + id_wares + "" + "").Rows[0][0].ToString();
                    rootlevel = db.GetData("select rootlevel from tree where rootid='" + rootid + "'").Rows[0][0].ToString();
                    rootlevel_name = "0";
                    type_acc = db.GetData("select sort from tree where rootid='" + rootid + "'").Rows[0][0].ToString();
                    sort = "1";
                }
                else if (term_type == 2)//vendor or clint 
                {
                    if (id_vcs == "") { error = "vcs not found"; return; }
                    rootid = db.GetData("" + rootid + "" + id_vcs + "" + "").Rows[0][0].ToString();
                    rootname = db.GetData("" + rootname + "" + id_vcs + "" + "").Rows[0][0].ToString();
                    rootlevel = db.GetData("select rootlevel from vcs where vcs_code='" + id_vcs + "'").Rows[0][0].ToString();
                    rootlevel_name = db.GetData("select rootlevel_name from vcs where vcs_code='" + id_vcs + "'").Rows[0][0].ToString();
                    type_acc = db.GetData("select sort from vcs where vcs_code='" + id_vcs + "'").Rows[0][0].ToString();

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
                if (depit == "tot")
                {
                    depit = tot;
                }
                else
                {
                    depit = "0";
                }
                if (credit == "tot")
                {
                    credit = tot;
                }
                else
                {
                    credit = "0";
                }

                if (depit != "0" || credit != "0")
                {
                    dt_term.Rows.Add(term_id, rootid, rootname, depit, credit, rootlevel, rootlevel_name, sort, type_acc);

                }


            }

            //============end of terms        
        }
        public static void Make_entry_type_recevr(ref DataTable dt_term, ref string error, string cat, string term_id, string id_wares, string id_vcs, string tot)
        {
            // DataTable dt_term= new DataTable();
            dt_term.Rows.Clear();
            dt_term.Columns.Add("term_id");
            dt_term.Columns.Add("rootid");
            dt_term.Columns.Add("rootname");
            dt_term.Columns.Add("depit");
            dt_term.Columns.Add("credit");
            dt_term.Columns.Add("rootlevel");
            dt_term.Columns.Add("rootlevel_name");
            dt_term.Columns.Add("sort");
            dt_term.Columns.Add("type_acc");
            string code_entry, sort, rootlevel, rootlevel_name, type_acc;

            //book loaded:-
            //cls_book.load_from_terms(comb_type);
            //=============insert in dgv term 
            string rootid, rootname, depit, credit;
            int term_type;
            //  DataTable dt_term = new DataTable();

            //int count = Convert.ToInt32(db.GetData("select count(term_id) from term where term_id='" + combo_type.Text + "' and cat_book='سند فاتوره مشتريات'").Rows[0][0].ToString());
            int count = Convert.ToInt32(db.GetData("select count(term_id) from term where term_id='" + term_id + "' and cat_book='" + cat + "'").Rows[0][0].ToString());

            //code_entry = (db.GetData("select code_entry from term where term_id='" + combo_type.Text + "' and cat_book='سند فاتوره مشتريات'").Rows[0][0].ToString());
            code_entry = (db.GetData("select code_entry from term where term_id='" + term_id + "' and cat_book='" + cat + "'").Rows[0][0].ToString());

            //string bookname_entry = (db.GetData("select bookname_entry from term where term_id='" + combo_type.Text + "' and cat_book='سند فاتوره مشتريات'").Rows[0][0].ToString());
            int c = 0;
            while (c < count)
            {
                int i = c++;
                term_id = db.GetData("select term_id from term where term_id='" + term_id + "' and cat_book='" + cat + "'").Rows[i][0].ToString();
                term_type = Convert.ToInt32(db.GetData("select term_type from term where term_id='" + term_id + "'and cat_book='" + cat + "'").Rows[i][0] + "");
                rootid = db.GetData("select rootid from term where term_id='" + term_id + "'and cat_book='" + cat + "'").Rows[i][0].ToString();
                rootname = db.GetData("select rootname from term where term_id='" + term_id + "'and cat_book='" + cat + "'").Rows[i][0].ToString();
                depit = db.GetData("select depit from term where term_id='" + term_id + "'and cat_book='" + cat + "'").Rows[i][0].ToString();
                credit = db.GetData("select credit from term where term_id='" + term_id + "'and cat_book='" + cat + "'").Rows[i][0].ToString();

                //==============================================

                if (term_type == 1)//wares

                {
                    rootid = db.GetData("" + rootid + "" + id_wares + "" + "").Rows[0][0].ToString();
                    rootname = db.GetData("" + rootname + "" + id_wares + "" + "").Rows[0][0].ToString();
                    rootlevel = db.GetData("select rootlevel from tree where rootid='" + rootid + "'").Rows[0][0].ToString();
                    rootlevel_name = "0";
                    type_acc = db.GetData("select sort from tree where rootid='" + rootid + "'").Rows[0][0].ToString();
                    sort = "1";
                }
                else if (term_type == 2)//vendor or clint 
                {
                    if (id_vcs == "") { error = "vcs not found"; return; }
                    rootid = db.GetData("" + rootid + "" + id_vcs + "" + "").Rows[0][0].ToString();
                    rootname = db.GetData("" + rootname + "" + id_vcs + "" + "").Rows[0][0].ToString();
                    rootlevel = db.GetData("select rootlevel from vcs where vcs_code='" + id_vcs + "'").Rows[0][0].ToString();
                    rootlevel_name = db.GetData("select rootlevel_name from vcs where vcs_code='" + id_vcs + "'").Rows[0][0].ToString();
                    type_acc = db.GetData("select sort from vcs where vcs_code='" + id_vcs + "'").Rows[0][0].ToString();

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
                if (depit == "amount")
                {
                    depit = tot;
                }
                else
                {
                    depit = "0";
                }
                //if (credit =="amount")
                //{
                //    credit = tot;
                //}
                //else
                //{
                //    credit = "0";
                //}

                if (depit != "0" || credit != "0")
                {
                    dt_term.Rows.Add(term_id, rootid, rootname, depit, credit, rootlevel, rootlevel_name, sort, type_acc);

                }


            }

            //============end of terms        
        }
        public static void Make_entry_type_pay(ref DataTable dt_term, ref string error, string cat, string term_id, string id_wares, string id_vcs, string tot)
        {
            // DataTable dt_term= new DataTable();
            dt_term.Rows.Clear();
            dt_term.Columns.Add("term_id");
            dt_term.Columns.Add("rootid");
            dt_term.Columns.Add("rootname");
            dt_term.Columns.Add("depit");
            dt_term.Columns.Add("credit");
            dt_term.Columns.Add("rootlevel");
            dt_term.Columns.Add("rootlevel_name");
            dt_term.Columns.Add("sort");
            dt_term.Columns.Add("type_acc");
            string code_entry, sort, rootlevel, rootlevel_name, type_acc;

            //book loaded:-
            //cls_book.load_from_terms(comb_type);
            //=============insert in dgv term 
            string rootid, rootname, depit, credit;
            int term_type;
            //  DataTable dt_term = new DataTable();

            //int count = Convert.ToInt32(db.GetData("select count(term_id) from term where term_id='" + combo_type.Text + "' and cat_book='سند فاتوره مشتريات'").Rows[0][0].ToString());
            int count = Convert.ToInt32(db.GetData("select count(term_id) from term where term_id='" + term_id + "' and cat_book='" + cat + "'").Rows[0][0].ToString());

            //code_entry = (db.GetData("select code_entry from term where term_id='" + combo_type.Text + "' and cat_book='سند فاتوره مشتريات'").Rows[0][0].ToString());
            code_entry = (db.GetData("select code_entry from term where term_id='" + term_id + "' and cat_book='" + cat + "'").Rows[0][0].ToString());

            //string bookname_entry = (db.GetData("select bookname_entry from term where term_id='" + combo_type.Text + "' and cat_book='سند فاتوره مشتريات'").Rows[0][0].ToString());
            int c = 0;
            while (c < count)
            {
                int i = c++;
                term_id = db.GetData("select term_id from term where term_id='" + term_id + "' and cat_book='" + cat + "'").Rows[i][0].ToString();
                term_type = Convert.ToInt32(db.GetData("select term_type from term where term_id='" + term_id + "'and cat_book='" + cat + "'").Rows[i][0] + "");
                rootid = db.GetData("select rootid from term where term_id='" + term_id + "'and cat_book='" + cat + "'").Rows[i][0].ToString();
                rootname = db.GetData("select rootname from term where term_id='" + term_id + "'and cat_book='" + cat + "'").Rows[i][0].ToString();
                depit = db.GetData("select depit from term where term_id='" + term_id + "'and cat_book='" + cat + "'").Rows[i][0].ToString();
                credit = db.GetData("select credit from term where term_id='" + term_id + "'and cat_book='" + cat + "'").Rows[i][0].ToString();

                //==============================================

                if (term_type == 1)//wares

                {
                    rootid = db.GetData("" + rootid + "" + id_wares + "" + "").Rows[0][0].ToString();
                    rootname = db.GetData("" + rootname + "" + id_wares + "" + "").Rows[0][0].ToString();
                    rootlevel = db.GetData("select rootlevel from tree where rootid='" + rootid + "'").Rows[0][0].ToString();
                    rootlevel_name = "0";
                    type_acc = db.GetData("select sort from tree where rootid='" + rootid + "'").Rows[0][0].ToString();
                    sort = "1";
                }
                else if (term_type == 2)//vendor or clint 
                {
                    if (id_vcs == "") { error = "vcs not found"; return; }
                    rootid = db.GetData("" + rootid + "" + id_vcs + "" + "").Rows[0][0].ToString();
                    rootname = db.GetData("" + rootname + "" + id_vcs + "" + "").Rows[0][0].ToString();
                    rootlevel = db.GetData("select rootlevel from vcs where vcs_code='" + id_vcs + "'").Rows[0][0].ToString();
                    rootlevel_name = db.GetData("select rootlevel_name from vcs where vcs_code='" + id_vcs + "'").Rows[0][0].ToString();
                    type_acc = db.GetData("select sort from vcs where vcs_code='" + id_vcs + "'").Rows[0][0].ToString();

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
                //if (depit == "amount")
                //{
                //    depit = tot;
                //}
                //else
                //{
                //    depit = "0";
                //}
                if (credit == "amount")
                {
                    credit = tot;
                }
                else
                {
                    credit = "0";
                }

                if (depit != "0" || credit != "0")
                {
                    dt_term.Rows.Add(term_id, rootid, rootname, depit,credit, rootlevel, rootlevel_name, sort, type_acc);

                }


            }

            //============end of terms        
        }
       
    public static void Make_entry_type_jop_number(ref DataTable dt_term, ref string error, string cat, string term_id, string id_wares, string id_vcs, string f1, string f2, string f3, string f4, string f5, string sum, string rev, string bon,string vat)
        {
            // DataTable dt_term= new DataTable();
            dt_term.Rows.Clear();
            dt_term.Columns.Add("term_id");
            dt_term.Columns.Add("rootid");
            dt_term.Columns.Add("rootname");
            dt_term.Columns.Add("depit");
            dt_term.Columns.Add("credit");
            dt_term.Columns.Add("rootlevel");
            dt_term.Columns.Add("rootlevel_name");
            dt_term.Columns.Add("sort");
            dt_term.Columns.Add("type_acc");
            string code_entry, sort, rootlevel, rootlevel_name, type_acc;


            //book loaded:-
            //cls_book.load_from_terms(comb_type);
            //=============insert in dgv term 
            string rootid, rootname, depit, credit;
            int term_type;
            //  DataTable dt_term = new DataTable();

            //int count = Convert.ToInt32(db.GetData("select count(term_id) from term where term_id='" + combo_type.Text + "' and cat_book='سند فاتوره مشتريات'").Rows[0][0].ToString());
            int count = Convert.ToInt32(db.GetData("select count(term_id) from term where term_id='" + term_id + "' and cat_book='" + cat + "'").Rows[0][0].ToString());

            //code_entry = (db.GetData("select code_entry from term where term_id='" + combo_type.Text + "' and cat_book='سند فاتوره مشتريات'").Rows[0][0].ToString());
            code_entry = (db.GetData("select code_entry from term where term_id='" + term_id + "' and cat_book='" + cat + "'").Rows[0][0].ToString());

            //string bookname_entry = (db.GetData("select bookname_entry from term where term_id='" + combo_type.Text + "' and cat_book='سند فاتوره مشتريات'").Rows[0][0].ToString());
            int c = 0;
            while (c < count)
            {
                int i = c++;
                term_id = db.GetData("select term_id from term where term_id='" + term_id + "' and cat_book='" + cat + "'").Rows[i][0].ToString();
                term_type = Convert.ToInt32(db.GetData("select term_type from term where term_id='" + term_id + "'and cat_book='" + cat + "'").Rows[i][0] + "");
                rootid = db.GetData("select rootid from term where term_id='" + term_id + "'and cat_book='" + cat + "'").Rows[i][0].ToString();
                rootname = db.GetData("select rootname from term where term_id='" + term_id + "'and cat_book='" + cat + "'").Rows[i][0].ToString();
                depit = db.GetData("select depit from term where term_id='" + term_id + "'and cat_book='" + cat + "'").Rows[i][0].ToString();
                credit = db.GetData("select credit from term where term_id='" + term_id + "'and cat_book='" + cat + "'").Rows[i][0].ToString();

                //==============================================

                if (term_type == 1)//wares

                {
                    rootid = db.GetData("" + rootid + "" + id_wares + "" + "").Rows[0][0].ToString();
                    rootname = db.GetData("" + rootname + "" + id_wares + "" + "").Rows[0][0].ToString();
                    rootlevel = db.GetData("select rootlevel from tree where rootid='" + rootid + "'").Rows[0][0].ToString();
                    rootlevel_name = "0";
                    type_acc = db.GetData("select sort from tree where rootid='" + rootid + "'").Rows[0][0].ToString();
                    sort = "1";
                }
                else if (term_type == 2)//vendor or clint 
                {
                    if (id_vcs == "") { error = "vcs not found"; return; }
                    rootid = db.GetData("" + rootid + "" + id_vcs + "" + "").Rows[0][0].ToString();
                    rootname = db.GetData("" + rootname + "" + id_vcs + "" + "").Rows[0][0].ToString();
                    rootlevel = db.GetData("select rootlevel from vcs where vcs_code='" + id_vcs + "'").Rows[0][0].ToString();
                    rootlevel_name = db.GetData("select rootlevel_name from vcs where vcs_code='" + id_vcs + "'").Rows[0][0].ToString();
                    type_acc = db.GetData("select sort from vcs where vcs_code='" + id_vcs + "'").Rows[0][0].ToString();

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
                if (depit == "f1")
                {
                    depit = f1;
                }
                else if (depit == "f2")
                {
                    depit = f2;
                }
                else if (depit == "f3")
                {
                    depit = f3;
                }
                else if (depit == "f4")
                {
                    depit = f4;
                }
                else if (depit == "f5")
                {
                    depit = f5;
                }
                else if (depit == "vat")
                {
                    depit = vat;
                }
                else if (depit == "rev")
                {
                    depit = rev;
                }
                else if (depit == "sum")
                {
                    depit = sum;
                }
                else if (depit == "bon")
                {
                    depit = bon;
                }
              
                else
                {
                    depit = "0";
                }
                if (credit == "f1")
                {
                    credit = f1;
                }
                else if (credit == "f2")
                {
                    credit = f2;
                }
                else if (credit == "f3")
                {
                    credit = f3;
                }
                else if (credit == "f4")
                {
                    credit = f4;
                }
                else if (credit == "f5")
                {
                    credit = f5;
                }
                else if (credit == "vat")
                {
                    credit = vat;
                }
                else if (credit == "rev")
                {
                    credit = rev;
                }
                else if (credit == "sum")
                {
                    credit = sum;
                }
                else if (credit == "bon")
                {
                    credit = bon;
                }
              
                else
                {
                    credit = "0";
                }

                if (depit != "0" || credit != "0")
                {
                    dt_term.Rows.Add(term_id, rootid, rootname, depit, credit, rootlevel, rootlevel_name, sort, type_acc);

                }


            }

            //============end of terms        
        }


        public static void load_from_chart_of_account(ComboBox comb)
        {
            DataTable dt = new DataTable();

            db.GetData_DGV("select RootName from tree where type_acc ='c'", dt);
            comb.DisplayMember = "RootName";
            comb.DataSource = dt;
        }
        public static void load_from_terms(ComboBox comb)
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("select term_id from terms where cat_book='سند فاتوره مشتريات'", dt);
            comb.DisplayMember = "term_id";
            comb.DataSource = dt;
        }
        public static void load_from_term(ComboBox comb, string cat_book)
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("select distinct term_id from term where cat_book='" + cat_book + "'", dt);
            comb.DisplayMember = "term_id";
            comb.DataSource = dt;

        }
      


        //=========================================
    }
}
