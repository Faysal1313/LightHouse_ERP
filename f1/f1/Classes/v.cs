

using System;
using System.Data;
using System.Windows.Forms;

namespace f1
{
    internal class v
    {
        public static FormWindowState formCurrentstat;
        public static string usercode;
        public static string username;
        public static string username_full;
        public static int current_yaer;
        public static string ico;
        public static string usedb;
        public static DataTable dtaa;
        public static string close;
        public static string customer_id;
        public static Decimal lbl_point;
        public static string search_rsale;
        public static int rep;
        public static string test;
        public static string vsc_account;
        public static string parentid;
        public static string parentname;
        public static string rootlevel;
        public static string type_acc;
        public static string sort;
        public static string test_pur;
        public static string test_sale;
        public static bool purchase_v;
        public static bool purchase_c;
        public static string purchase_purchase_hd_id;
        public static string purchase_vcs_code;
        public static string purchase_vcs_name;
        public static string purchase_amount;
        public static bool sale_v;
        public static bool sale_c;
        public static string sale_sale_hd_id;
        public static string sale_vcs_code;
        public static string sale_vcs_name;
        public static string sale_amount;
        public static string premium;
        public static bool privent_select_vcs;
        public static string code_Wares_adj_qty;
        public static bool adj_complet;
        public static bool opening_error;
        public static string WCode;
        public static string Wname;
        public static string period_salary;
        public static string num_test_trial;
        public static double net_recev;
        public static double cash;
        public static double visa;
        public static bool revec_mony;
        public static bool expiry;
        public static bool represinttive;
        public static bool barcode;
        public static bool currance;
        public static bool discount;
        public static bool taxes;
        public static bool chk_e_invoice;
        public static string combo_e_type;
        public static string txt_e_rkamtgary;
        public static string txt_e_name_company;
        public static string txt_e_addrees;
        public static string txt_e_br_taxes;
        public static string txt_e_country;
        public static string txt_e_govern;
        public static string txt_e_city;
        public static string txt_e_street;
        public static string txt_e_build;
        public static string txt_e_post;
        public static string txt_e_floore;
        public static string txt_id;
        public static string txt_secret;
        public static string combo_e_typecodeitems;
        public static string txt_activity;
        public static string vcs_code;
        public static string vcs_name;
        public static string invoice_no;
        public static double amount;
        public static string po_no;
        public static string rq_no;
        public static string qty_rq;
        public static int qty_max_search;
        public static string code_item_come_itmes="";
        public static string search_adv = "";
        public static string search_screen= "";
        public static string search_screen_code = "";



        //pos to move vcs screen to pos
        public static string vcs_code_pos;
        public static string vcs_name_pos;
        public static string vcs_phone_pos;
        public static string vcs_address_pos;
        public static bool iam_pos;
        public static bool iam_posed = false;

        public static string code_come_adv_search="";

        public static string shift_no;
        //==============security

        public static string sec ="";
        
        static v()
        {
            v.formCurrentstat = FormWindowState.Normal;
            v.usercode = "";
            v.username = "";
            v.username_full = "";
            v.current_yaer = 0;
            v.ico = "f1.ico";
            v.usedb = "";
            v.dtaa = new DataTable();
            v.close = "";
            v.customer_id = "";
            v.lbl_point = new Decimal(0);
            v.search_rsale = "";
            v.rep = 0;
            v.test = "";
            v.vsc_account = "";
            v.parentid = "";
            v.parentname = "";
            v.rootlevel = "";
            v.type_acc = "";
            v.sort = "";
            v.test_pur = "";
            v.test_sale = "";
            v.purchase_purchase_hd_id = "";
            v.purchase_vcs_code = "";
            v.purchase_vcs_name = "";
            v.purchase_amount = "";
            v.sale_sale_hd_id = "";
            v.sale_vcs_code = "";
            v.sale_vcs_name = "";
            v.sale_amount = "";
            v.premium = "";
            v.privent_select_vcs = true;
            v.code_Wares_adj_qty = "";
            v.adj_complet = true;
            v.opening_error = false;
            v.WCode = "";
            v.Wname = "";
            v.period_salary = "";
            v.num_test_trial = "";
            v.net_recev = 0.0;
            v.cash = 0.0;
            v.visa = 0.0;
            v.revec_mony = false;
           

           
        }

       

        public static string auto_Entry()
        {
            string str = db.GetData("select max(code_entry)+1 from entry").Rows[0][0].ToString();
            if (str == "")
                str = "1";
            return str;
        }
    }
}
