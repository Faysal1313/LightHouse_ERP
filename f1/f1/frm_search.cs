using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace f1
{
    public partial class frm_search : DevExpress.XtraEditors.XtraForm
    {
        public frm_search()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(v.ico);
            this.Date1.Text = DateTime.Now.ToString("yyyy/MM/01");
            this.Date2.Text = DateTime.Now.ToString("yyyy/MM/dd");
        }

        private void combo_type_items_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (combo_type_items.Text == "مخزون")
            //{
            //    lbl_type_items.Text = "1";
            //}
            //else if (combo_type_items.Text == "خدمي")
            //{
            //    lbl_type_items.Text = "2";
            //}
        }

        private void frm_search_Load(object sender, EventArgs e)
        {
            if (v.search_screen=="items")
            {
                dgv.Columns[0].HeaderText = "رقم";
                dgv.Columns[1].HeaderText = "الكود";
                dgv.Columns[2].HeaderText = "اسم ";
                dgv.Columns[3].HeaderText = "الوحده";
                dgv.Columns[4].HeaderText = "سعر الشراء";
                dgv.Columns[5].HeaderText = "سعر البيع";
                dgv.Columns[6].HeaderText = "";
                dgv.Columns[7].HeaderText = "";
                dgv.Columns[6].Visible = false;
                dgv.Columns[7].Visible = false;


                Date1.Visible = true;
                Date2.Visible = true;
                chk_rest.Visible = true;
                lbl_date1.Visible = false;
                lbl_date2.Visible = false;
                combo_name.Visible = true;

                if (chk_rest.Checked==false)
                {
                    all_comb.load_items_code(combo_code);
                    all_comb.load_name_items(combo_name);
                }
                else
                {
                    all_comb.load_items_code_with_menu(combo_code);
                    all_comb.load_name_items_with_menu(combo_name);
                }
                all_comb.load_items_code_with_menu(combo_code);
                all_comb.load_name_items_with_menu(combo_name);
            }
            else if (v.search_screen == "vendor")
            {
                dgv.Columns[0].HeaderText = "رقم";
                dgv.Columns[1].HeaderText = "الكود";
                dgv.Columns[2].HeaderText = "اسم ";
                dgv.Columns[3].HeaderText = "الوحده";
                dgv.Columns[4].HeaderText = "";
                dgv.Columns[5].HeaderText = "";
                dgv.Columns[6].HeaderText = "";
                dgv.Columns[7].HeaderText = "";
                dgv.Columns[3].Visible = false;
                dgv.Columns[4].Visible = false;
                dgv.Columns[5].Visible = false;
                dgv.Columns[6].Visible = false;
                dgv.Columns[7].Visible = false;
                Date1.Visible = false;
                Date2.Visible = false;
                lbl_date1.Visible = false;
                lbl_date2.Visible = false;
                chk_rest.Visible = false;
                combo_name.Visible = true;

                all_comb.load_code_vcs(combo_code);
                all_comb.load_vendor_only_name(combo_name);
                   
            }
            else if (v.search_screen == "customer")
            {
                dgv.Columns[0].HeaderText = "رقم";
                dgv.Columns[1].HeaderText = "الكود";
                dgv.Columns[2].HeaderText = "اسم ";
                dgv.Columns[3].HeaderText = "الوحده";
                dgv.Columns[4].HeaderText = "";
                dgv.Columns[5].HeaderText = "";
                dgv.Columns[6].HeaderText = "";
                dgv.Columns[7].HeaderText = "";
                dgv.Columns[3].Visible = false;
                dgv.Columns[4].Visible = false;
                dgv.Columns[5].Visible = false;
                dgv.Columns[6].Visible = false;
                dgv.Columns[7].Visible = false;
                Date1.Visible = false;
                Date2.Visible = false;
                lbl_date1.Visible = false;
                lbl_date2.Visible = false;
                chk_rest.Visible = false;
                combo_name.Visible = true;

                all_comb.load_code_vcs(combo_code);
                all_comb.load_customer_only_name(combo_name);

            }
            else if (v.search_screen == "recevable")
            {
                dgv.Columns[0].HeaderText = "رقم";
                dgv.Columns[1].HeaderText = "رقم السند";
                dgv.Columns[2].HeaderText = "النوع";
                dgv.Columns[3].HeaderText = "المبلغ";
                dgv.Columns[4].HeaderText = "التاريخ";
                dgv.Columns[5].HeaderText = "";
                dgv.Columns[6].HeaderText = "";
                dgv.Columns[7].HeaderText = "";
                dgv.Columns[3].Visible = true;
                dgv.Columns[4].Visible = true;
                dgv.Columns[5].Visible = false;
                dgv.Columns[6].Visible = false;
                dgv.Columns[7].Visible = false;
                Date1.Visible = true;
                Date2.Visible = true;
                lbl_date1.Visible = true;
                lbl_date2.Visible = true;
                chk_rest.Visible = false;
                combo_name.Visible = false;
                all_comb.load_invoice_number_recev(combo_code);
              //  all_comb.load_customer_only_name(combo_name);

            }
            else if (v.search_screen == "payable")
            {
                dgv.Columns[0].HeaderText = "رقم";
                dgv.Columns[1].HeaderText = "رقم السند";
                dgv.Columns[2].HeaderText = "النوع";
                dgv.Columns[3].HeaderText = "المبلغ";
                dgv.Columns[4].HeaderText = "التاريخ";
                dgv.Columns[5].HeaderText = "";
                dgv.Columns[6].HeaderText = "";
                dgv.Columns[7].HeaderText = "";
                dgv.Columns[3].Visible = true;
                dgv.Columns[4].Visible = true;
                dgv.Columns[5].Visible = false;
                dgv.Columns[6].Visible = false;
                dgv.Columns[7].Visible = false;
                Date1.Visible = true;
                Date2.Visible = true;
                lbl_date1.Visible = true;
                lbl_date2.Visible = true;
                chk_rest.Visible = false;
                combo_name.Visible = false;
                all_comb.load_invoice_number_recev(combo_code);
                //  all_comb.load_customer_only_name(combo_name);

            }
            else if (v.search_screen == "entry")
            {
                dgv.Columns[0].HeaderText = "رقم";
                dgv.Columns[1].HeaderText = "رقم السند";
                dgv.Columns[2].HeaderText = "المبلغ";
                dgv.Columns[3].HeaderText = "التاريخ";
                dgv.Columns[4].HeaderText = "";
                dgv.Columns[5].HeaderText = "";
                dgv.Columns[6].HeaderText = "";
                dgv.Columns[7].HeaderText = "";
                dgv.Columns[3].Visible = true;
                dgv.Columns[4].Visible = false;
                dgv.Columns[5].Visible = false;
                dgv.Columns[6].Visible = false;
                dgv.Columns[7].Visible = false;
                Date1.Visible = true;
                Date2.Visible = true;
                lbl_date1.Visible = true;
                lbl_date2.Visible = true;
                chk_rest.Visible = false;
                combo_name.Visible = false;
                all_comb.load_all_account_code_entry(combo_code);
                //  all_comb.load_customer_only_name(combo_name);

            }
            else if (v.search_screen == "purchase")
            {
                dgv.Columns[0].HeaderText = "رقم";
                dgv.Columns[1].HeaderText = "رقم السند";
                dgv.Columns[2].HeaderText = "كود المورد او العميل";
                dgv.Columns[3].HeaderText = "اسم المورد او العميل";
                dgv.Columns[4].HeaderText = "المبلغ";
                dgv.Columns[5].HeaderText = "كود المخزن";
                dgv.Columns[6].HeaderText = "التاريخ";
                dgv.Columns[7].HeaderText = "";
                dgv.Columns[3].Visible = true;
                dgv.Columns[4].Visible = true;
                dgv.Columns[5].Visible = true;
                dgv.Columns[6].Visible = false;
                dgv.Columns[7].Visible = false;
                Date1.Visible = true;
                Date2.Visible = true;
                lbl_date1.Visible = true;
                lbl_date2.Visible = true;
                chk_rest.Visible = false;
                combo_name.Visible = false;
                all_comb.load_invoice_number_purchase(combo_code);
                //  all_comb.load_customer_only_name(combo_name);

            }
            else if (v.search_screen == "rpurchase")
            {
                dgv.Columns[0].HeaderText = "رقم";
                dgv.Columns[1].HeaderText = "رقم السند";
                dgv.Columns[2].HeaderText = "كود المورد او العميل";
                dgv.Columns[3].HeaderText = "اسم المورد او العميل";
                dgv.Columns[4].HeaderText = "المبلغ";
                dgv.Columns[5].HeaderText = "كود المخزن";
                dgv.Columns[6].HeaderText = "التاريخ";
                dgv.Columns[7].HeaderText = "";
                dgv.Columns[3].Visible = true;
                dgv.Columns[4].Visible = true;
                dgv.Columns[5].Visible = true;
                dgv.Columns[6].Visible = false;
                dgv.Columns[7].Visible = false;
                Date1.Visible = true;
                Date2.Visible = true;
                lbl_date1.Visible = true;
                lbl_date2.Visible = true;
                chk_rest.Visible = false;
                combo_name.Visible = false;
                all_comb.load_invoice_number_rpurchase(combo_code);
                //  all_comb.load_customer_only_name(combo_name);

            }
            else if (v.search_screen == "sales")
            {
                dgv.Columns[0].HeaderText = "رقم";
                dgv.Columns[1].HeaderText = "رقم السند";
                dgv.Columns[2].HeaderText = "كود المورد او العميل";
                dgv.Columns[3].HeaderText = "اسم المورد او العميل";
                dgv.Columns[4].HeaderText = "المبلغ";
                dgv.Columns[5].HeaderText = "كود المخزن";
                dgv.Columns[6].HeaderText = "التاريخ";
                dgv.Columns[7].HeaderText = "";
                dgv.Columns[3].Visible = true;
                dgv.Columns[4].Visible = true;
                dgv.Columns[5].Visible = true;
                dgv.Columns[6].Visible = false;
                dgv.Columns[7].Visible = false;
                Date1.Visible = true;
                Date2.Visible = true;
                lbl_date1.Visible = true;
                lbl_date2.Visible = true;
                chk_rest.Visible = false;
                combo_name.Visible = false;
                all_comb.load_invoice_number_sale(combo_code);
                //  all_comb.load_customer_only_name(combo_name);

            }
            else if (v.search_screen == "rsale")
            {
                dgv.Columns[0].HeaderText = "رقم";
                dgv.Columns[1].HeaderText = "رقم السند";
                dgv.Columns[2].HeaderText = "كود المورد او العميل";
                dgv.Columns[3].HeaderText = "اسم المورد او العميل";
                dgv.Columns[4].HeaderText = "المبلغ";
                dgv.Columns[5].HeaderText = "كود المخزن";
                dgv.Columns[6].HeaderText = "التاريخ";
                dgv.Columns[7].HeaderText = "";
                dgv.Columns[3].Visible = true;
                dgv.Columns[4].Visible = true;
                dgv.Columns[5].Visible = true;
                dgv.Columns[6].Visible = false;
                dgv.Columns[7].Visible = false;
                Date1.Visible = true;
                Date2.Visible = true;
                lbl_date1.Visible = true;
                lbl_date2.Visible = true;
                chk_rest.Visible = false;
                combo_name.Visible = false;
                all_comb.load_invoice_number_rsale(combo_code);
                //  all_comb.load_customer_only_name(combo_name);

            }
            else if (v.search_screen == "issuer")
            {
                dgv.Columns[0].HeaderText = "رقم";
                dgv.Columns[1].HeaderText = "رقم السند";
                dgv.Columns[2].HeaderText = "كود المورد او العميل";
                dgv.Columns[3].HeaderText = "اسم المورد او العميل";
                dgv.Columns[4].HeaderText = "المبلغ";
                dgv.Columns[5].HeaderText = "كود المخزن";
                dgv.Columns[6].HeaderText = "التاريخ";
                dgv.Columns[7].HeaderText = "";
                dgv.Columns[3].Visible = true;
                dgv.Columns[4].Visible = true;
                dgv.Columns[5].Visible = true;
                dgv.Columns[6].Visible = false;
                dgv.Columns[7].Visible = false;
                Date1.Visible = true;
                Date2.Visible = true;
                lbl_date1.Visible = true;
                lbl_date2.Visible = true;
                chk_rest.Visible = false;
                combo_name.Visible = false;
                all_comb.load_issuer_number(combo_code);
                //  all_comb.load_customer_only_name(combo_name);

            }
            else if (v.search_screen == "recever")
            {
                dgv.Columns[0].HeaderText = "رقم";
                dgv.Columns[1].HeaderText = "رقم السند";
                dgv.Columns[2].HeaderText = "كود المورد او العميل";
                dgv.Columns[3].HeaderText = "اسم المورد او العميل";
                dgv.Columns[4].HeaderText = "المبلغ";
                dgv.Columns[5].HeaderText = "كود المخزن";
                dgv.Columns[6].HeaderText = "التاريخ";
                dgv.Columns[7].HeaderText = "";
                dgv.Columns[3].Visible = true;
                dgv.Columns[4].Visible = true;
                dgv.Columns[5].Visible = true;
                dgv.Columns[6].Visible = false;
                dgv.Columns[7].Visible = false;
                Date1.Visible = true;
                Date2.Visible = true;
                lbl_date1.Visible = true;
                lbl_date2.Visible = true;
                chk_rest.Visible = false;
                combo_name.Visible = false;
                all_comb.load_recvever_number(combo_code);
                //  all_comb.load_customer_only_name(combo_name);

            }
            else if (v.search_screen == "trans")
            {
                dgv.Columns[0].HeaderText = "رقم";
                dgv.Columns[1].HeaderText = "رقم السند";
                dgv.Columns[2].HeaderText = "كود المورد او العميل";
                dgv.Columns[3].HeaderText = "اسم المورد او العميل";
                dgv.Columns[4].HeaderText = "المبلغ";
                dgv.Columns[5].HeaderText = "كود المخزن";
                dgv.Columns[6].HeaderText = "التاريخ";
                dgv.Columns[7].HeaderText = "";
                dgv.Columns[3].Visible = true;
                dgv.Columns[4].Visible = true;
                dgv.Columns[5].Visible = true;
                dgv.Columns[6].Visible = false;
                dgv.Columns[7].Visible = false;
                Date1.Visible = true;
                Date2.Visible = true;
                lbl_date1.Visible = true;
                lbl_date2.Visible = true;
                chk_rest.Visible = false;
                combo_name.Visible = false;
                all_comb.load_trans_number(combo_code);
                //  all_comb.load_customer_only_name(combo_name);

            }

            combo_code.Text = "";
            combo_name.Text = "";
        }

        private void combo_code_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (v.search_screen == "items")
            {
                if (chk_rest.Checked)
                {
                    db.GetData_DGV("select top " + v.qty_max_search + " code_items,name_items,name_unite,price_buy,price_sale from items where name_items like '%" + combo_code.Text + "%' and menu='1'", dt);
                }
                else
                {
                    db.GetData_DGV("select top " + v.qty_max_search + " code_items,name_items,name_unite,price_buy,price_sale from items where name_items like '%" + combo_code.Text + "%' and menu<>'1'", dt);
                }
                dgv.Invoke((MethodInvoker)delegate
                {
                    dgv.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv.Rows.Add("", dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3], dt.Rows[i][4]);
                    }
                });
            }
            else if (v.search_screen == "vendor")
            {
                db.GetData_DGV("select top " + v.qty_max_search + " vcs_code,vcs_name,phone,address from vcs where vcs_code like '%" + combo_code.Text + "%' and mode='vendor'", dt);
                dgv.Invoke((MethodInvoker)delegate
                {
                    dgv.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv.Rows.Add("", dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3]);
                    }
                });
            }
            else if (v.search_screen == "customer")
            {
                db.GetData_DGV("select top " + v.qty_max_search + " vcs_code,vcs_name,phone,address from vcs where vcs_code like '%" + combo_code.Text + "%' and mode='customer'", dt);
                dgv.Invoke((MethodInvoker)delegate
                {
                    dgv.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv.Rows.Add("", dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3]);
                    }
                });
            }
            else if (v.search_screen == "recevable")
            {
                db.GetData_DGV("select top " + v.qty_max_search + " recev_hd_id,amount,type,date_ from recev_hd where recev_hd_id like '%" + combo_code.Text + "%' and date_ between'"+Date1.Value.ToString("yyyy-MM-dd") +"' and '"+ Date2.Value.ToString("yyyy-MM-dd") + "' ", dt);

                dgv.Invoke((MethodInvoker)delegate
                {
                    dgv.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv.Rows.Add("", dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], Convert.ToDateTime(dt.Rows[i][3]+"").ToString("yyyy-MM-dd"));
                    }
                });
            }
            else if (v.search_screen == "payable")
            {
                db.GetData_DGV("select top " + v.qty_max_search + " pay_hd_id,amount,type,date_ from pay_hd where pay_hd_id like '%" + combo_code.Text + "%' and date_ between'" + Date1.Value.ToString("yyyy-MM-dd") + "' and '" + Date2.Value.ToString("yyyy-MM-dd") + "' ", dt);

                dgv.Invoke((MethodInvoker)delegate
                {
                    dgv.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv.Rows.Add("", dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], Convert.ToDateTime(dt.Rows[i][3] + "").ToString("yyyy-MM-dd"));
                    }
                });
            }
            else if (v.search_screen == "entry")
            {
                db.GetData_DGV("select distinct top " + v.qty_max_search + " code_entry,depit,dates from entry where code_entry like '%" + combo_code.Text + "%' and dates between'" + Date1.Value.ToString("yyyy-MM-dd") + "' and '" + Date2.Value.ToString("yyyy-MM-dd") + "'and code_entry<>'-11'and code_entry<>'002' and depit<>'0' ", dt);
                dgv.Invoke((MethodInvoker)delegate
                {
                    dgv.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv.Rows.Add("", dt.Rows[i][0], dt.Rows[i][1],  Convert.ToDateTime(dt.Rows[i][2] + "").ToString("yyyy-MM-dd"));
                    }
                });
            }
            else if (v.search_screen == "purchase")
            {
                db.GetData_DGV("select distinct top " + v.qty_max_search + " purchase_hd_id,vcs_code,vcs_name,incloud_taxes,id_ware,date_P from purchase_hd where purchase_hd_id like '%" + combo_code.Text + "%' and date_P between'" + Date1.Value.ToString("yyyy-MM-dd") + "' and '" + Date2.Value.ToString("yyyy-MM-dd") + "' ", dt);
                dgv.Invoke((MethodInvoker)delegate
                {
                    dgv.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv.Rows.Add("", dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3], dt.Rows[i][4], Convert.ToDateTime(dt.Rows[i][5] + "").ToString("yyyy-MM-dd"));
                    }
                });
            }
            else if (v.search_screen == "rpurchase")
            {
                db.GetData_DGV("select distinct top " + v.qty_max_search + " rpurchase_hd_id,vcs_code,vcs_name,incloud_taxes,id_ware,date_P from rpurchase_hd where rpurchase_hd_id like '%" + combo_code.Text + "%' and date_P between'" + Date1.Value.ToString("yyyy-MM-dd") + "' and '" + Date2.Value.ToString("yyyy-MM-dd") + "' ", dt);
                dgv.Invoke((MethodInvoker)delegate
                {
                    dgv.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv.Rows.Add("", dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3], dt.Rows[i][4], Convert.ToDateTime(dt.Rows[i][5] + "").ToString("yyyy-MM-dd"));
                    }
                });
            }
            else if (v.search_screen == "sale")
            {
                db.GetData_DGV("select distinct top " + v.qty_max_search + " sale_hd_id,vcs_code,vcs_name,incloud_taxes,id_ware,date_P from sale_hd where sale_hd_id like '%" + combo_code.Text + "%' and date_P between'" + Date1.Value.ToString("yyyy-MM-dd") + "' and '" + Date2.Value.ToString("yyyy-MM-dd") + "' ", dt);
                dgv.Invoke((MethodInvoker)delegate
                {
                    dgv.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv.Rows.Add("", dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3], dt.Rows[i][4], Convert.ToDateTime(dt.Rows[i][5] + "").ToString("yyyy-MM-dd"));
                    }
                });
            }
            else if (v.search_screen == "rsale")
            {
                db.GetData_DGV("select distinct top " + v.qty_max_search + " rsale_hd_id,vcs_code,vcs_name,incloud_taxes,id_ware,date_P from rsale_hd where rsale_hd_id like '%" + combo_code.Text + "%' and date_P between'" + Date1.Value.ToString("yyyy-MM-dd") + "' and '" + Date2.Value.ToString("yyyy-MM-dd") + "' ", dt);
                dgv.Invoke((MethodInvoker)delegate
                {
                    dgv.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv.Rows.Add("", dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3], dt.Rows[i][4], Convert.ToDateTime(dt.Rows[i][5] + "").ToString("yyyy-MM-dd"));
                    }
                });
            }
            else if (v.search_screen == "issuer")
            {
                db.GetData_DGV("select distinct top " + v.qty_max_search + " issuer_inv_hd_id,vcs_code,vcs_name,incloud_taxes,id_ware,date_P from issuer_inv_hd where issuer_inv_hd_id like '%" + combo_code.Text + "%' and date_P between'" + Date1.Value.ToString("yyyy-MM-dd") + "' and '" + Date2.Value.ToString("yyyy-MM-dd") + "' ", dt);
                dgv.Invoke((MethodInvoker)delegate
                {
                    dgv.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv.Rows.Add("", dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3], dt.Rows[i][4], Convert.ToDateTime(dt.Rows[i][5] + "").ToString("yyyy-MM-dd"));
                    }
                });
            }
            else if (v.search_screen == "recever")
            {
                db.GetData_DGV("select distinct top " + v.qty_max_search + " recever_hd_id,vcs_code,vcs_name,incloud_taxes,id_ware,date_P from recever_hd where recever_hd_id like '%" + combo_code.Text + "%' and date_P between'" + Date1.Value.ToString("yyyy-MM-dd") + "' and '" + Date2.Value.ToString("yyyy-MM-dd") + "' ", dt);
                dgv.Invoke((MethodInvoker)delegate
                {
                    dgv.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv.Rows.Add("", dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3], dt.Rows[i][4], Convert.ToDateTime(dt.Rows[i][5] + "").ToString("yyyy-MM-dd"));
                    }
                });
            }
            else if (v.search_screen == "trans")
            {
                db.GetData_DGV("select distinct top " + v.qty_max_search + " trans_hd_id,vcs_code,vcs_name,incloud_taxes,id_ware,date_P from trans_hd where trans_hd_id like '%" + combo_code.Text + "%' and date_P between'" + Date1.Value.ToString("yyyy-MM-dd") + "' and '" + Date2.Value.ToString("yyyy-MM-dd") + "' ", dt);
                dgv.Invoke((MethodInvoker)delegate
                {
                    dgv.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv.Rows.Add("", dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3], dt.Rows[i][4], Convert.ToDateTime(dt.Rows[i][5] + "").ToString("yyyy-MM-dd"));
                    }
                });
            }
        }

        private void combo_name_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            if (v.search_screen == "items")
            {
                if (chk_rest.Checked)
                {
                    db.GetData_DGV("select top " + v.qty_max_search + " code_items,name_items,name_unite,price_buy,price_sale from items where name_items like '%" + combo_name.Text + "%' and menu='1'", dt);
                }
                else
                {
                    db.GetData_DGV("select top " + v.qty_max_search + " code_items,name_items,name_unite,price_buy,price_sale from items where name_items like '%" + combo_name.Text + "%' and menu<>'1'", dt);
                }
                dgv.Invoke((MethodInvoker)delegate
                {
                    dgv.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv.Rows.Add("", dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3], dt.Rows[i][4]);

                    }

                });
            }
            else if (v.search_screen == "vendor")
            {
                db.GetData_DGV("select top " + v.qty_max_search + " vcs_code,vcs_name,phone,address from vcs where vcs_name like '%" + combo_name.Text + "%' and mode='vendor'", dt);
                dgv.Invoke((MethodInvoker)delegate
                {
                    dgv.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv.Rows.Add("", dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3]);
                    }
                });
            }
            else if (v.search_screen == "customer")
            {
                db.GetData_DGV("select top " + v.qty_max_search + " vcs_code,vcs_name,phone,address from vcs where vcs_name like '%" + combo_name.Text + "%' and mode='customer'", dt);
                dgv.Invoke((MethodInvoker)delegate
                {
                    dgv.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv.Rows.Add("", dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3]);
                    }
                });
            }
            //non recevable name
            //non pay name

        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           v.search_screen_code = dgv.CurrentRow.Cells[1].Value+"";
            this.Close();
        }

        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv);
        }

        private void dgv_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            Classes.command.LoadSerial(dgv);
        }
    }
}