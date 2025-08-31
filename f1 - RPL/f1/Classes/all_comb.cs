using System;
using System.Data;
using System.Windows.Forms;

namespace f1
{
    internal class all_comb
    {
        public all_comb()
        {
           
        }

        public static void load_sale_hd_id(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select sale_hd_id from sale_hd   ", tb);
            combo.DisplayMember = "sale_hd_id";
            combo.DataSource = (object)tb;
        }

        public static void load_vcs(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select vcs_code,vcs_name,code_tree from vcs  ", tb);
            combo.DisplayMember = "vcs_name";
            combo.DataSource = (object)tb;
        }

        public static void load_vcs_customer(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select vcs_code,vcs_name,code_tree from vcs  where mode='customer'  ", tb);
            combo.DisplayMember = "vcs_name";
            combo.DataSource = (object)tb;
        }
        public static void load_vcs_customer_code(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select vcs_code from vcs  where mode='customer'  ", tb);
            combo.DisplayMember = "vcs_code";
            combo.DataSource = (object)tb;
        }
        public static void load_vcs_vendor(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select vcs_code,vcs_name,code_tree from vcs  where mode='vendor'  ", tb);
            combo.DisplayMember = "vcs_name";
            combo.DataSource = (object)tb;
        }

        public static void load_code_vcs(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select DISTINCT(vcs_code) from vcs  ", tb);
            combo.DisplayMember = "vcs_code";
            combo.DataSource = (object)tb;
        }

        public static void load_name_vcs(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select DISTINCT(vcs_name) from vcs  ", tb);
            combo.DisplayMember = "vcs_name";
            combo.DataSource = (object)tb;
        }

        public static void load_vendor_only_name(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select vcs_code,vcs_name,code_tree from vcs where mode='vendor'", tb);
            combo.DisplayMember = "vcs_name";
            combo.DataSource = (object)tb;
        }

        public static void load_customer_only_name(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select vcs_code,vcs_name,code_tree from vcs where mode='customer'", tb);
            combo.DisplayMember = "vcs_name";
            combo.DataSource = (object)tb;
        }

        public static void load_phone(ComboBox combo, string mode_vcs)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select phone from vcs  where  mode='" + mode_vcs + "'", tb);
            combo.DisplayMember = "phone";
            combo.DataSource = (object)tb;
        }

        public static void load_address(ComboBox combo, string mode_vcs)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select address from vcs  where  mode='" + mode_vcs + "'", tb);
            combo.DisplayMember = "address";
            combo.DataSource = (object)tb;
        }

        public static void load_customer_only_code(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select vcs_code,vcs_name,code_tree from vcs where mode='customer'", tb);
            combo.DisplayMember = "vcs_code";
            combo.DataSource = (object)tb;
        }

        public static void load_customer_only_phone(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select vcs_code,vcs_name,code_tree,phone from vcs where mode='customer'", tb);
            combo.DisplayMember = "phone";
            combo.DataSource = (object)tb;
        }

        public static void load_wares(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select DISTINCT(id_ware) from WARES ", tb);
            combo.DisplayMember = "id_ware";
            combo.DataSource = (object)tb;
        }

        public static void load_unite_id(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select DISTINCT(id) from unite ", tb);
            combo.DisplayMember = "id";
            combo.DataSource = (object)tb;
        }

        public static void load_unite(ComboBox combo, string code_items)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select (name_unite) from unite where code_items='" + code_items + "' order by unite ", tb);
            combo.DisplayMember = "name_unite";
            combo.DataSource = (object)tb;
        }

        public static void load_cat(ComboBox combo, string cat)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct " + cat + " from items_cat where " + cat + " <>''", tb);
            combo.DisplayMember = cat ?? "";
            combo.DataSource = (object)tb;
        }

        public static void load_exp_date(ComboBox combo, string code_items, string id_ware)
        {
            try
            {
                DataTable tb = new DataTable();
                db.GetData_DGV("select distinct(exp_date) from exp_date where code_items='" + code_items + "' and id_ware='" + id_ware + "' order by exp_date ", tb);
                combo.DisplayMember = "exp_date";
                combo.DataSource = (object)tb;
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
            }
        }

        public static void load_main_code(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct main_code from items ", tb);
            combo.DisplayMember = "main_code";
            combo.DataSource = (object)tb;
        }

        public static void load_account_name_c(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select (rootname) from tree where type_acc='c'  and [visable]=1  order by RootID", tb);
            combo.DisplayMember = "rootname";
            combo.DataSource = tb;
        }
        public static void load_account_name_c_capital(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select RootName, RootID from tree  where type_acc = 'c' and RootID between  '3000' and '39999'", tb);
            combo.DisplayMember = "RootName";
            combo.DataSource = tb;
        }
        public static void load_account_name_c_depit(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select RootName, RootID from tree  where type_acc = 'c' and RootID between  '10000' and '12999'", tb);
            combo.DisplayMember = "RootName";
            combo.DataSource = tb;
        }

        public static void cost_center_id(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select DISTINCT(costcenter_id) from costcenter", tb);
            combo.DisplayMember = "costcenter_id";
            combo.DataSource = tb;
        }
        public static void cost_center_name(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select DISTINCT(costcenter_name) from costcenter", tb);
            combo.DisplayMember = "costcenter_name";
            combo.DataSource = tb;
        }

        public static void load_account_name_specific_account(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select (select isnull(max(rootname),'-') from tree where rootid=pos_list_expensses.acc_code)as name,acc_code from pos_list_expensses order by name", tb);
            combo.DisplayMember = "name";
            combo.DataSource = tb;
        }
        public static void load_account_code_c(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select (RootID) from tree where type_acc='c'  and [visable]=1 order by RootID", tb);
            combo.DisplayMember = "RootID";
            combo.DataSource = tb;
        }

        public static void load_account_sc(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select rootname  from tree where type_acc='sc'  order by rootlevel", tb);
            combo.DisplayMember = "rootname";
            combo.DataSource = (object)tb;
        }

        public static void load_all_account_byacc(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct(acc_num) from entry  where sort ='1' or sort ='2'  and [visable]=1 ", tb);
            combo.DisplayMember = "acc_num";
            combo.DataSource = (object)tb;
        }
        public static void load_all_account(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select RootName from tree  where [visable]=1 order by RootLevel", tb);
            combo.DisplayMember = "RootName";
            combo.DataSource =tb;
        }

        public static void load_all_account_byname(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct(acc_name) from entry  where sort ='1' or sort ='2'  and [visable]=1", tb);
            combo.DisplayMember = "acc_name";
            combo.DataSource = (object)tb;
        }
        public static void load_all_account_code_entry(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct(code_entry) from entry  where code_entry<>'-11'and code_entry<>'002' and depit<>'0' ", tb);
            combo.DisplayMember = "code_entry";
            combo.DataSource = (object)tb;
        }
        public static void load_items_code(ComboBox comb)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select  distinct top " + v.qty_max_search + " code_items from items where   menu<>'1'", tb);
            comb.DisplayMember = "code_items";
            comb.DataSource = tb;
        }
        public static void load_items_code_with_menu(ComboBox comb)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select  distinct top " + v.qty_max_search + " code_items from items where   menu='1'", tb);
            comb.DisplayMember = "code_items";
            comb.DataSource = tb;
        }
       
        public static void load_items_for_sale_have_qty(ComboBox comb)
        {
            DataTable tb = new DataTable();
            //db.GetData_DGV("select distinct name_items from wares where qty > 0 union select distinct name_items from items where type=2 ", tb);
               db.GetData_DGV("select distinct i.name_items from wares w left join items i on w.code_items=i.code_items where i.menu<>'1'and  w.qty>0  ", tb);


            comb.DisplayMember = "name_items";
            comb.DataSource = (object)tb;
        }
        public static void load_items_for_sale(ComboBox comb)
        {
            DataTable tb = new DataTable();
          //  db.GetData_DGV("select distinct name_items from wares where qty > 0 union select distinct name_items from items where type=2 ", tb);
               db.GetData_DGV("select distinct i.name_items from wares w left join items i on w.code_items=i.code_items where i.menu<>'1' ", tb);


            comb.DisplayMember = "name_items";
            comb.DataSource = (object)tb;
        }

        public static void load_items_for_sale_eng(ComboBox comb)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select items.name_items2 from  items right join wares  on items.code_items=wares.code_items  where   wares.qty> 0 ", tb);
            comb.DisplayMember = "name_items2";
            comb.DataSource = (object)tb;
        }

        public static void load_items_for_purchase_name1(ComboBox comb)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct top " + v.qty_max_search + " name_items from items where menu<>'1' ", tb);
            //db.GetData_DGV("select name_items+CAST(price_sale as varchar(10)) from items ", tb);

            //select distinct name_items+'           '+CAST(price_sale as varchar(10)) from items
            comb.DisplayMember = "name_items";
            comb.DataSource = (object)tb;
        }

        public static void load_items_for_purchase_name2(ComboBox comb)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct top " + v.qty_max_search + " name_items2 from items where menu<>'1'", tb);
            comb.DisplayMember = "name_items2";
            comb.DataSource = (object)tb;
        }

        public static void load_items_for_have_balance_name1(ComboBox comb)
        {
            DataTable tb = new DataTable();
          //  db.GetData_DGV("select items.code_items as code_items ,items.name_items as name_items,items.name_unite as name_unite ,items.price_sale as price_sale,items.unit1 as unit1,wares.qty,taxes,couta_type from items left join wares on items.code_items=wares.code_items where items.type='1'and qty > 0 and id_ware=(select top 1 id_ware from wares_acc where acc_id='1' and id_ware <>'-9') ", tb);
            db.GetData_DGV("select distinct i.code_items as code_items ,i.name_items as name_items,i.name_unite as name_unite ,i.price_sale as price_sale,i.unit1 as unit1,w.qty,i.taxes,i.couta_type from wares w left join items i on w.code_items=i.code_items where i.menu<>'1'and  w.qty>0 ", tb);

            //select  i.code_items as code_items ,i.name_items as name_items,i.name_unite as name_unite ,i.price_sale as price_sale,i.unit1 as unit1,w.qty,i.taxes,i.couta_type from wares w left join items i on w.code_items=i.code_items where i.menu<>'1'and  w.qty>0 

            comb.DisplayMember = "name_items";
            comb.DataSource = (object)tb;
        }

        public static void load_items_for_have_balance_name2(ComboBox comb)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select items.code_items as code_items ,items.name_items2 as name_items2,items.name_unite as name_unite ,items.price_sale as price_sale,items.unit1 as unit1,wares.qty,taxes,couta_type from items left join wares on items.code_items=wares.code_items where items.type='1'and qty > 0 and id_ware=(select top 1 id_ware from wares_acc where acc_id='1' and id_ware <>'-9') ", tb);
            comb.DisplayMember = "name_items2";
            comb.DataSource = (object)tb;
        }

        public static void load_code_items(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct top " + v.qty_max_search + " (code_items) from items  where  menu<>'1'", tb);
            combo.DisplayMember = "code_items";
            combo.DataSource = (object)tb;
        }

        public static void load_name_items(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct top " + v.qty_max_search + " (name_items) from items where  menu<>'1' ", tb);
            combo.DisplayMember = "name_items";
            combo.DataSource = (object)tb;
        }
        public static void load_name_items_with_menu(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct top " + v.qty_max_search + " (name_items) from items where  menu='1' ", tb);
            combo.DisplayMember = "name_items";
            combo.DataSource = (object)tb;
        }
        public static void load_name_items_have_qty(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct top " + v.qty_max_search + " (name_items)  from items where type <> 2", tb);
            combo.DisplayMember = "name_items";
            combo.DataSource = (object)tb;
        }

        public static void load_name_items_normal_only(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct (name_items) from items where type='1' and  [exp]='0'  and  menu<>'1'", tb);
            combo.DisplayMember = "name_items";
            combo.DataSource = (object)tb;
        }

        public static void load_name_items_exp(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct (name_items) from items where type='1' and  [exp]='0'  and  menu<>'1'", tb);
            combo.DisplayMember = "name_items";
            combo.DataSource = (object)tb;
        }

        public static void load_name_items_exp_and_normal(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct (name_items) from items where type='1'and  menu<>'1'", tb);
            combo.DisplayMember = "name_items";
            combo.DataSource = (object)tb;
        }

        public static void load_cost_items_exp(ComboBox combo, string code_items, string id_ware, string exp_date, string code, string code_book)
        {
            try
            {
                DataTable tb = new DataTable();
                db.GetData_DGV("select (cost) from exp_date where code_items='" + code_items + "' and id_ware='" + id_ware + "' and exp_date='" + exp_date + "' and code='" + code + "' and code_book='" + code_book + "'", tb);
                combo.DisplayMember = "cost";
                combo.DataSource = (object)tb;
            }
            catch (Exception ex)
            {
            }
        }

        public static void Additems_in_edit_mode(ComboBox comb)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct top " + v.qty_max_search + " name_item from items ", tb);
            comb.DisplayMember = "name_item";
            comb.DataSource = (object)tb;
        }

        public static void load_wares_acc(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct acc_name from wares_acc  ", tb);
            combo.DisplayMember = "acc_name";
            combo.DataSource = (object)tb;
        }

        public static void load_code_book_entry(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct code_book from entry where code_book != ''  ", tb);
            combo.DisplayMember = "code_book";
            combo.DataSource = (object)tb;
        }
        public static void load_code_book_entry_from_book(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct code_book from book where cat_book='سند قيد' ", tb);
            combo.DisplayMember = "code_book";
            combo.DataSource = tb;
        }
        //select distinct code_book from book where cat_book='سند قيد'

        public static void load_taxes(ComboBox comb)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select taxes from taxes", tb);
            comb.DisplayMember = "taxes";
            comb.DataSource = (object)tb;
        }

        public static void load_invoice_number_purchase(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct purchase_hd_id from purchase_hd  ", tb);
            combo.DisplayMember = "purchase_hd_id";
            combo.DataSource = (object)tb;
        }
        public static void load_issuer_number(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct issuer_inv_hd_id from issuer_inv_hd", tb);
            combo.DisplayMember = "issuer_inv_hd_id";
            combo.DataSource = (object)tb;
        }
        public static void load_recvever_number(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct recever_hd_id from recever_hd", tb);
            combo.DisplayMember = "recever_hd_id";
            combo.DataSource = (object)tb;
        }
        public static void load_trans_number(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct trans_hd_id from trans_hd", tb);
            combo.DisplayMember = "trans_hd_id";
            combo.DataSource = (object)tb;
        }
        public static void load_invoice_number_purchase_r(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select  purchase_hd_id from purchase_hd where not EXISTS (select attach_no from rpurchase_hd where purchase_hd.purchase_hd_id=rpurchase_hd.attach_no) ", tb);
            combo.DisplayMember = "purchase_hd_id";
            combo.DataSource = (object)tb;
        }
        public static void load_invoice_number_rpurchase(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct rpurchase_hd_id from rpurchase_hd ", tb);
            combo.DisplayMember = "rpurchase_hd_id";
            combo.DataSource = (object)tb;
        }
        public static void load_invoice_number_rsale(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct rsale_hd_id from rsale_hd ", tb);
            combo.DisplayMember = "rsale_hd_id";
            combo.DataSource = (object)tb;
        }
        public static void load_invoice_number_sale(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct sale_hd_id from sale_hd  ", tb);
            combo.DisplayMember = "sale_hd_id";
            combo.DataSource = (object)tb;
        }

        public static void load_invoice_number_sale_r(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select  sale_hd_id from sale_hd where not EXISTS (select attach_no from rsale_hd where sale_hd.sale_hd_id=rsale_hd.attach_no) ", tb);
            combo.DisplayMember = "sale_hd_id";
            combo.DataSource = (object)tb;
        }

        public static void load_invoice_number_trans(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct trans_hd_id from trans_hd  ", tb);
            combo.DisplayMember = "trans_hd_id";
            combo.DataSource = (object)tb;
        }

        public static void load_invoice_number_recev(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct recev_hd_id from recev_hd  ", tb);
            combo.DisplayMember = "recev_hd_id";
            combo.DataSource = (object)tb;
        }

        public static void load_invoice_number_pay(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct pay_hd_id from pay_hd  ", tb);
            combo.DisplayMember = "pay_hd_id";
            combo.DataSource = (object)tb;
        }

        public static void load_emp_Wage(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct WCode FROM    EmpWage  ", tb);
            combo.DisplayMember = "WCode";
            combo.DataSource = (object)tb;
        }

        public static void load_emp_users(ComboBox combo)
        {
            try
            {
                DataTable tb = new DataTable();
                db.GetData_DGV("select [user_name] from emps where [user]='true' ", tb);
                combo.DisplayMember = "user_name";
                combo.DataSource = (object)tb;
            }
            catch (Exception ex)
            {
            }
        }
        public static void load_emp_users_code(ComboBox combo)
        {
            try
            {
                DataTable tb = new DataTable();
                db.GetData_DGV("select [emp_no] from emps where [user]='true' ", tb);
                combo.DisplayMember = "emp_no";
                combo.DataSource = (object)tb;
            }
            catch (Exception ex)
            {
            }
        }

        public static void load_emp_name(ComboBox combo)
        {
            try
            {
                DataTable tb = new DataTable();
                db.GetData_DGV("select distinct emp_name from emps ", tb);
                combo.DisplayMember = "emp_name";
                combo.DataSource = (object)tb;
            }
            catch (Exception ex)
            {
            }
        }

        public static void load_emp_no(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct emp_no from emps where [user]='true' ", tb);
            combo.DisplayMember = "emp_no";
            combo.DataSource = (object)tb;
        }

        public static void load_curracne(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct currance from currance ", tb);
            combo.DisplayMember = "currance";
            combo.DataSource = (object)tb;
        }

     
        public static void load_resource_m_code(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct code_resource from m_resource", tb);
            combo.DisplayMember = "code_resource";
            combo.DataSource = (object)tb;
        }

        public static void load_resource_m_name(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct name_resource from m_resource", tb);
            combo.DisplayMember = "name_resource";
            combo.DataSource = (object)tb;
        }

        public static void m_standard_costs_load_name(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct name_items from m_standard_costs_matrial", tb);
            combo.DisplayMember = "name_items";
            combo.DataSource = (object)tb;
        }

        public static void m_request_production_no(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct m_request_production_hd_id from m_request_production_hd", tb);
            combo.DisplayMember = "m_request_production_hd_id";
            combo.DataSource = (object)tb;
        }

        public static void m_po_no(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct po_id from m_po_hd", tb);
            combo.DisplayMember = "po_id";
            combo.DataSource = (object)tb;
        }

        public static void m_row_matrial(ComboBox combo, string po)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct id from m_row_matrial where po='" + po + "'", tb);
            combo.DisplayMember = "id";
            combo.DataSource = (object)tb;
        }

        public static void m_re_row_matrial(ComboBox combo, string po)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct id from m_re_row_matrial where po='" + po + "'", tb);
            combo.DisplayMember = "id";
            combo.DataSource = (object)tb;
        }

        public static void m_exe(ComboBox combo, string po)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct id from m_exe where po='" + po + "'", tb);
            combo.DisplayMember = "id";
            combo.DataSource = (object)tb;
        }

        public static void purchase_dt_manf(ComboBox combo, string po)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select purchase_hd_id from purchase_dt where code_book='" + po + "'", tb);
            combo.DisplayMember = "purchase_hd_id";
            combo.DataSource = (object)tb;
        }
        //pos
        public static void load_invoice_pos_not_close(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct pos_inv_no from pos_dt left join pos_shift on pos_dt.shift_no=pos_shift.shift_no where pos_shift.lock= '1'  ", tb);
            combo.DisplayMember = "pos_inv_no";
            combo.DataSource =tb;
        }
        public static void load_invoice_pos(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct pos_inv_no from pos_dt  ", tb);
            combo.DisplayMember = "pos_inv_no";
            combo.DataSource = tb;
        }
        public static void load_shift_not_close(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct pos_dt.shift_no from pos_dt left join pos_shift on pos_dt.shift_no=pos_shift.shift_no where pos_shift.lock= '1'", tb);
            //combo.DisplayMember = "pos_dt.shift_no";
            combo.DisplayMember = "shift_no";

            combo.DataSource = tb;
        }
        public static void load_shift_no(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct shift_no from pos_shift", tb);
            //combo.DisplayMember = "pos_dt.shift_no";
            combo.DisplayMember = "shift_no";

            combo.DataSource = tb;
        }
        public static void load_no_statment(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct id from statment ", tb);
            combo.DisplayMember = "id";
            combo.DataSource =tb;
        }

        //jop number
        public static void load_truck_id(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct id from jn_truck", tb);
            combo.DisplayMember = "id";
            combo.DataSource = (object)tb;
        }
        public static void load_truck_name(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct name from jn_truck", tb);
            combo.DisplayMember = "name";
            combo.DataSource = (object)tb;
        }
        public static void load_station_code(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct id from jn_station", tb);
            combo.DisplayMember = "id";
            combo.DataSource = (object)tb;
        }
        public static void load_station_name(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct name from jn_station", tb);
            combo.DisplayMember = "name";
            combo.DataSource = (object)tb;
        }
        public static void load_storhouse_code(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct id from jn_storehouse", tb);
            combo.DisplayMember = "id";
            combo.DataSource = (object)tb;
        }
      
        public static void load_storehouse_name(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct name from jn_storehouse", tb);
            combo.DisplayMember = "name";
            combo.DataSource = (object)tb;
        }
        public static void load_jn_storehouse_docment(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct id from jn_jopnumber", tb);
            combo.DisplayMember = "id";
            combo.DataSource = (object)tb;
        }
        public static void load_jn_con_invoice_docment(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct id from jn_consolidated_invoice", tb);
            combo.DisplayMember = "id";
            combo.DataSource = (object)tb;
        }
        public static void load_room_recereved(ComboBox combo)
        {
            DataTable tb = new DataTable();
            db.GetData_DGV("select distinct  id from room_operation_hot where state=2", tb);
            combo.DisplayMember = "id";
            combo.DataSource = (object)tb;
        }
    }
}
