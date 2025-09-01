using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace f1
{
    public partial class frm_cogs_adj : DevExpress.XtraEditors.XtraForm
    {
        public frm_cogs_adj()
        {
            InitializeComponent();
            db.Open();
        }
        //====Function
          string code_entry, sort, rootlevel, rootlevel_name, type_acc;
        private void calc_all()
        {
            try
            {
                decimal tot_bef = 0;
                decimal discount = 0;
                decimal tot_after_dis = 0;
                decimal taxes_value = 0;
                decimal incloud_taxes = 0;
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    tot_bef += Convert.ToDecimal(dgv.Rows[i].Cells["tot_bef"].Value);
                    discount += Convert.ToDecimal(dgv.Rows[i].Cells["discount"].Value);
                    tot_after_dis += Convert.ToDecimal(dgv.Rows[i].Cells["tot_after_dis"].Value);
                    incloud_taxes += Convert.ToDecimal(dgv.Rows[i].Cells["incloud_taxes"].Value);
                    taxes_value += Convert.ToDecimal(dgv.Rows[i].Cells["taxes_value"].Value);
                }
                lbl_tot_befor.Text = Math.Round(tot_bef, 2) + "";
                //      lbl_discount.Text = Math.Round(discount, 2) + "";
                lbl_tot_after_dis.Text = Math.Round(tot_after_dis, 2) + "";
                lbl_taxes_values.Text = Math.Round(taxes_value, 2) + "";
                if (tot_bef > 0)
                {
                    //                    txt_after_taxes.Text = Math.Round(tot_after_taxes, 2) + "";
                    lbl_incloud_taxes.Text = Math.Round(incloud_taxes, 2) + "";
                }
                else
                {
                    MessageBox.Show("مينفعش دخل رقم  اقل من صفر");
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
        private void select_type_entry()
        {
            dgv_term.Rows.Clear();

            //book loaded:-
            //cls_book.load_from_terms(comb_type);
            //=============insert in dgv term 
            string term_id, rootid, rootname, depit, credit;

            int count = Convert.ToInt32(db.GetData("select count(term_id) from term where term_id='" + txt_type.Text + "' and cat_book='سند فاتوره مبيعات'").Rows[0][0].ToString());
            code_entry = (db.GetData("select code_entry from term where term_id='" + txt_type.Text + "' and cat_book='سند فاتوره مبيعات'").Rows[0][0].ToString());
            string bookname_entry = (db.GetData("select bookname_entry from term where term_id='" + txt_type.Text + "' and cat_book='سند فاتوره مبيعات'").Rows[0][0].ToString());
            int c = 0;
            while (c < count)
            {
                int i = c++;
                term_id = db.GetData("select term_id from term where term_id='" + txt_type.Text + "'").Rows[i][0].ToString();
                rootid = db.GetData("select rootid from term where term_id='" + txt_type.Text + "'").Rows[i][0].ToString();
                rootname = db.GetData("select rootname from term where term_id='" + txt_type.Text + "'").Rows[i][0].ToString();
                depit = db.GetData("select depit from term where term_id='" + txt_type.Text + "'").Rows[i][0].ToString();
                credit = db.GetData("select credit from term where term_id='" + txt_type.Text + "'").Rows[i][0].ToString();
                //==============================================

                if (rootname.Length > 52)//wares
                {
                    rootid = db.GetData("" + rootid + "" + txt_ware.Text + "" + "").Rows[0][0].ToString();
                    rootname = db.GetData("" + rootname + "" + txt_ware.Text + "" + "").Rows[0][0].ToString();
                    rootlevel = db.GetData("select rootlevel from tree where rootid='" + rootid + "'").Rows[0][0].ToString();
                    rootlevel_name = "0";
                    type_acc = db.GetData("select sort from tree where rootid='" + rootid + "'").Rows[0][0].ToString();
                    sort = "1";
                }
                else if (rootname.Length > 39)//vendor or clint 
                {
                    if (combo_vsc_codetree.Text == "") { MessageBox.Show("اختار مورد او عميل"); return; }
                    rootid = db.GetData("" + rootid + "" + combo_vsc_codetree.Text + "" + "").Rows[0][0].ToString();
                    rootname = db.GetData("" + rootname + "" + combo_vsc_codetree.Text + "" + "").Rows[0][0].ToString();
                    rootlevel = db.GetData("select rootlevel from vcs where vcs_code='" + combo_vsc_codetree.Text + "'").Rows[0][0].ToString();
                    rootlevel_name = db.GetData("select rootlevel_name from vcs where vcs_code='" + combo_vsc_codetree.Text + "'").Rows[0][0].ToString();
                    type_acc = db.GetData("select sort from vcs where vcs_code='" + combo_vsc_codetree.Text + "'").Rows[0][0].ToString();

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
                    depit = lbl_tot_befor.Text;
                }
                else if (depit == "tot_after_dis")
                {
                    depit = lbl_tot_after_dis.Text;
                }
                else if (depit == "discount")
                {
                    depit = lbl_discount.Text;
                }
                else if (depit == "incloud_taxes")
                {
                    depit = lbl_incloud_taxes.Text;
                }
                else if (depit == "taxtes")
                {
                    depit = lbl_taxes_values.Text;
                }
                else if (depit == "cost")
                {
                    depit = lbl_tot_cost.Text;
                }
                else
                {
                    depit = "0";
                }
                if (credit == "tot_befor")
                {
                    credit = lbl_tot_befor.Text;
                }
                else if (credit == "tot_after_dis")
                {
                    credit = lbl_tot_after_dis.Text;
                }
                else if (credit == "discount")
                {
                    credit = lbl_discount.Text;
                }
                else if (credit == "incloud_taxes")
                {
                    credit = lbl_incloud_taxes.Text;
                }
                else if (credit == "taxtes")
                {
                    credit = lbl_taxes_values.Text;
                }
                else if (credit == "cost")
                {
                    credit = lbl_tot_cost.Text;
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
        private void count_items_invoice()
        {
            for (int i = 0; i < dgv_items.Rows.Count; i++)
            {
                lbl_c_items.Text = dgv_items.Rows.Count+"";
            }
            for (int x = 0; x < dgv_invoice.Rows.Count; x++)
            {
                lbl_c_invoice.Text = dgv_invoice.Rows.Count + "";
            }
        }
      
        //=======
        private void simpleButton1_Click(object sender, EventArgs e)
        {
             //1)get specific items code from center 
            //________________________________________
             DataTable dtx = new DataTable();
            db.GetData_DGV("select code_items,date from center",dtx);
            dgv_items.DataSource=dtx;
            count_items_invoice();

            //2)get  specific invoice sale number from table sale_dt 
            //________________________________________
            for (int j = 0; j < dgv_items.Rows.Count; j++)
            {
                DataTable dt_wa = new DataTable();
                db.GetData_DGV("select sale_dt.code_items,sale_hd.sale_hd_id,sale_hd.date_P FROM  sale_hd LEFT OUTER JOIN sale_dt ON sale_hd.sale_hd_id = sale_dt.sale_hd_id where date_P >= '" + Convert.ToDateTime(dgv_items.Rows[j].Cells[1].Value).ToString("MM-dd-yyyy") + "' ", dt_wa);
                dgv_invoice.DataSource = dt_wa;
                 //3)get specific header and details  invoice sale from table sale_hd and dt
                //________________________________________
                for (int i = 0; i < dgv_invoice.Rows.Count; i++)
                {
                    string currance, f_currance;
                    string number_invoice = (dgv_invoice.Rows[i].Cells["sale_hd_id"].Value.ToString());
                    DataTable dt = new DataTable();
                    db.GetData_DGV("select sale_dt.code_items,sale_dt.id_ware,sale_dt.qty,sale_dt.discount,sale_dt.item_price,sale_dt.incloud_taxes,sale_dt.tot_bef,sale_dt.tot_after_dis,sale_dt.taxes_value,sale_dt.taxes FROM  sale_hd LEFT OUTER JOIN sale_dt ON sale_hd.sale_hd_id = sale_dt.sale_hd_id where  sale_hd.sale_hd_id='" + number_invoice + "'", dt);
                    dgv.DataSource = dt;
                    txt_type.Text = db.GetData("select term from sale_hd where sale_hd_id='" + number_invoice + "'").Rows[0][0].ToString();
                    txt_ware.Text = db.GetData("select id_ware from sale_hd where sale_hd_id='" + number_invoice + "'").Rows[0][0].ToString();
                    combo_vcs.Text = db.GetData("select vcs_name from sale_hd where sale_hd_id='" + number_invoice + "' ").Rows[0][0].ToString();
                    combo_vsc_codetree.Text = db.GetData("select vcs_code from sale_hd where sale_hd_id='" + number_invoice + "' ").Rows[0][0].ToString();
                    txt_entry_string.Text = db.GetData("select code_book_entry+convert(nvarchar (50),code_entry)  from sale_hd where sale_hd_id='" + number_invoice + "' ").Rows[0][0].ToString();
                    comb_code_name.Text = db.GetData("select name_book from sale_hd where sale_hd_id='" + number_invoice + "' ").Rows[0][0].ToString();
                    txt_code_book.Text = db.GetData("select code_book from sale_hd where sale_hd_id='" + number_invoice + "' ").Rows[0][0].ToString();
                    txt_serial_string.Text = db.GetData("select sale_hd_id from sale_hd where sale_hd_id='" + number_invoice + "'").Rows[0][0].ToString();
                    txt_note.Text = db.GetData("select note_txt from sale_hd where sale_hd_id='" + number_invoice + "'").Rows[0][0].ToString();
                    dt_piker.Text = db.GetData("select date_p from sale_hd where sale_hd_id='" + number_invoice + "'").Rows[0][0].ToString();
                    currance = db.GetData("select currance from sale_hd where sale_hd_id='" + number_invoice + "'").Rows[0][0].ToString();
                    f_currance = db.GetData("select f_currance from sale_hd where sale_hd_id='" + number_invoice + "'").Rows[0][0].ToString();

                    calc_all();

                    //4)get all items in invoice items code COGS 
                    //________________________________________
                    dgv_cost.Rows.Clear();
                    for (int x = 0; x < dgv.Rows.Count; x++) //loop NO.2
                    {
                        Decimal totalcost = 0;
                        Decimal totalqty = 0;
                        String totalcoststring = "";
                        string cost = "0";
                        totalqty = Convert.ToDecimal(db.GetData("select sum(qty * f_unite) from purchase_dt where code_items='" + dgv.Rows[x].Cells["code_items"].Value + "' and id_ware='" + dgv.Rows[x].Cells["id_ware"].Value + "'").Rows[0][0].ToString());
                        if (totalqty == 0) totalqty = 1;
                        totalcoststring = (Convert.ToString(db.GetData("select sum(tot_after_dis_forex) from purchase_dt where code_items='" + dgv.Rows[x].Cells["code_items"].Value + "' and id_ware='" + dgv.Rows[x].Cells["id_ware"].Value + "'").Rows[0][0]));
                        if (totalcoststring == "") totalcoststring = (Convert.ToString(dgv.Rows[x].Cells["tot_after_dis"].Value));
                        totalcost = Convert.ToDecimal(totalcoststring);
                        cost = (totalcost / totalqty) + "";

                        //===========
                        dgv_cost.Rows.Add(dgv.Rows[x].Cells["code_items"].Value.ToString(), dgv.Rows[x].Cells["id_ware"].Value.ToString(), (Convert.ToDecimal(cost) * Convert.ToDecimal(dgv.Rows[x].Cells["qty"].Value.ToString())));
                    }
                    decimal tot_cost = 0;
                    for (int tot = 0; tot < dgv_cost.Rows.Count; tot++)
                    {
                        tot_cost = tot_cost + Convert.ToDecimal(dgv_cost.Rows[tot].Cells["cost_c"].Value);
                    }
                    lbl_tot_cost.Text = Math.Round(tot_cost) + "";

                    select_type_entry();
                   // MessageBox.Show(txt_entry_string.Text);

                    //update
                    db.Run("delete from entry where code_entry='" + txt_entry_string.Text + "'");
                    for (int z = 0; z < dgv_term.Rows.Count; z++)
                    {
                        progressBar1.Visible = true;
                        prog = dgv.Rows.Count;//to know progras bar 
                        db.Run("insert into entry(  [code_entry]                           ,    acc_num                                                   ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                                          ,   type_acc                                                            , sort                                                       ,             depit                                                             ,                credit                                                                                  ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext )values('" +
                                                   txt_entry_string.Text + "'            ,'" + dgv_term.Rows[z].Cells[1].Value.ToString() + "'     ,'" + dgv_term.Rows[z].Cells[2].Value.ToString() + "'               ,  '" + dgv_term.Rows[z].Cells["rootlevel_"].Value.ToString() + "'    ,  '" + dgv_term.Rows[z].Cells["rootlevel_name_"].Value.ToString() + "', '" + dgv_term.Rows[z].Cells["type_acc_"].Value.ToString() + "'       ,  '" + dgv_term.Rows[z].Cells["sort_"].Value.ToString() + "'  ,  '" + Convert.ToDecimal(dgv_term.Rows[z].Cells[3].Value.ToString()) * Convert.ToDecimal(f_currance) + "'      ,'" + Convert.ToDecimal(dgv_term.Rows[z].Cells[4].Value.ToString()) * Convert.ToDecimal(f_currance) + "' ,'" + txt_name_book_type.Text + "','" + txt_code_entry_type.Text + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + txt_serial_string.Text + "','" + txt_code_book.Text + "','" + comb_code_name.Text + "','COGS Calc')");

                    }

                    //Error cost inventory
                    db.Run("delete from center where note='Error cost inventory'");
                    backgroundWorker1.ReportProgress(i);
                }
            }
            MessageBox.Show("cost changed");
        }
        int prog = 0;
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Maximum = prog;
            progressBar1.Value = e.ProgressPercentage;
        }

       
    }
}