using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace f1.inventory
{
    public partial class adjustment_qty_exp : DevExpress.XtraEditors.XtraForm
    {
        public adjustment_qty_exp()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
            db.Open();
        }
        private void adjustment_qty_exp_Load(object sender, EventArgs e)
        {
            rd_dgv.Checked = true;
            cls_book.loadbook(comb_code_name, "سند جرد");
            cls_book.load_from_term(combo_type, "سند جرد");
            dt_piker.Text = DateTime.Now.ToString("yyyy/MM/01");
            dt_piker.Text = DateTime.Now.ToString("yyyy/MM/dd");

           

            progressBar1.Visible = false;
            save_arc_barButtonItem2.Enabled = false;
            excut_barButtonItem1.Enabled = false;
            lbl_wars.Text = v.code_Wares_adj_qty;
        }
        //--------------Function
        private void calc()
        {

            //   try
            {
                if (dgv.Rows.Count > 0)
                {
                    //////////////  cala total =qty* price-des
                    decimal tot_depit = 0;
                    decimal tot_crdit = 0;
                    decimal _min = 0;
                    decimal _plues = 0;

                    dgv.CurrentRow.Cells["net_qty"].Value = (Convert.ToDouble(dgv.CurrentRow.Cells["new_qty"].Value) - Convert.ToDouble(dgv.CurrentRow.Cells["qty"].Value));
                    if ((Convert.ToDouble(dgv.CurrentRow.Cells["net_qty"].Value) < 0))
                    {
                        dgv.CurrentRow.Cells["min"].Value = (Convert.ToDouble(dgv.CurrentRow.Cells["net_qty"].Value) * Convert.ToDouble(-1));
                        dgv.CurrentRow.Cells["plues"].Value = 0;
                        dgv.CurrentRow.Cells["net_plues"].Value = (Convert.ToDouble(dgv.CurrentRow.Cells["min"].Value) * Convert.ToDouble(dgv.CurrentRow.Cells["cost"].Value));
                        dgv.CurrentRow.Cells["net_min"].Value = 0;


                    }
                    if ((Convert.ToDouble(dgv.CurrentRow.Cells["net_qty"].Value) > 0))
                    {
                        dgv.CurrentRow.Cells["plues"].Value = (Convert.ToDouble(dgv.CurrentRow.Cells["net_qty"].Value) * Convert.ToDouble(1));
                        dgv.CurrentRow.Cells["min"].Value = 0;
                        dgv.CurrentRow.Cells["net_min"].Value = (Convert.ToDouble(dgv.CurrentRow.Cells["plues"].Value) * Convert.ToDouble(dgv.CurrentRow.Cells["cost"].Value));
                        dgv.CurrentRow.Cells["net_plues"].Value = 0;

                    }
                    if (Convert.ToDouble(dgv.CurrentRow.Cells["new_qty"].Value) == Convert.ToDouble(dgv.CurrentRow.Cells["qty"].Value))
                    {
                        dgv.CurrentRow.Cells["min"].Value = 0;
                        dgv.CurrentRow.Cells["plues"].Value = 0;
                        dgv.CurrentRow.Cells["net_plues"].Value = 0;
                        dgv.CurrentRow.Cells["net_min"].Value = 0;
                    }
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        _min += Convert.ToDecimal(dgv.Rows[i].Cells["net_plues"].Value);
                        _plues += Convert.ToDecimal(dgv.Rows[i].Cells["net_min"].Value);
                    }

                    lbl_rev.Text = _min + "";
                    lbl_exp.Text = _plues + "";
                }
            }
            // catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
        }
        private void select_type_entry()
        {
            dgv_term.Rows.Clear();

            //book loaded:-
            //cls_book.load_from_terms(comb_type);
            //=============insert in dgv term 
            string term_id, rootid, rootname, depit, credit;

            int count = Convert.ToInt32(db.GetData("select count(term_id) from term where term_id='" + combo_type.Text + "'").Rows[0][0].ToString());
            code_entry = (db.GetData("select code_entry from term where term_id='" + combo_type.Text + "'").Rows[0][0].ToString());
            string bookname_entry = (db.GetData("select bookname_entry from term where term_id='" + combo_type.Text + "'").Rows[0][0].ToString());
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
                    rootid = db.GetData("" + rootid + "" + lbl_wars.Text + "" + "").Rows[0][0].ToString();
                    rootname = db.GetData("" + rootname + "" + lbl_wars.Text + "" + "").Rows[0][0].ToString();
                    rootlevel = db.GetData("select rootlevel from tree where rootid='" + rootid + "'").Rows[0][0].ToString();
                    rootlevel_name = "0";
                    sort_acc = db.GetData("select sort from tree where rootid='" + rootid + "'").Rows[0][0].ToString();
                    sort = "1";
                }

                else //other (fixed account)
                {
                    rootlevel = db.GetData("select rootlevel from tree where rootid='" + rootid + "'").Rows[0][0].ToString();
                    rootlevel_name = "0";
                    sort_acc = db.GetData("select sort from tree where rootid='" + rootid + "'").Rows[0][0].ToString();
                    sort = "1";

                }
                //==================================================

                //========fill field tot or tot_bef or discount=======
                if (depit == "rev")
                {
                    depit = lbl_rev.Text;
                }
                else if (depit == "exp")
                {
                    depit = lbl_exp.Text;
                }
                else
                {
                    depit = "0";
                }
                if (credit == "rev")
                {
                    credit = lbl_rev.Text;
                }
                else if (credit == "exp")
                {
                    credit = lbl_exp.Text;
                }
                else
                {
                    credit = "0";
                }
                //=========================================================
                // dgv_term.Rows.Clear();
                dgv_term.Rows.Add(term_id, rootid, rootname, depit, credit, rootlevel, rootlevel_name, sort, sort_acc);


            }
            //============end of terms        
        }
        private void insert()
        {
            //select entry
            select_type_entry();

            //get only number for one user Entry
            txt_entry_string.Text = txt_code_entry_type.Text + txt_code_entry.Text;
            cls_book.selectbook("entry_hd", "سند قيد", txt_code_entry_type.Text, txt_code_entry, "code_entry");
            txt_entry_string.Text = txt_code_entry_type.Text + txt_code_entry.Text;
            //get only number for one user purchase
            txt_code_book.Text = db.GetData("select code_book from book where name_book='" + comb_code_name.Text + "'").Rows[0][0].ToString();
            cls_book.selectbook("adj_qty_hd", "سند جرد", txt_code_book.Text, txt_serial, "adj_qty_hd_id");
            txt_serial_string.Text = txt_code_book.Text + txt_serial.Text;
            //--------------------------------------------------------------------------------only one user 

            //>>>>>>>>>>>>>>>>>>>>>insert entry
            db.Run("insert into entry_hd ([code_entry],code_book) values ('" + txt_entry_string.Text + "','" + txt_code_entry_type.Text + "')");
            //entry_hd
            for (int z = 0; z < dgv_term.Rows.Count; z++)
            {
                db.Run("insert into entry(  [code_entry]                           ,    acc_num                                                   ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                                          ,   sort                                                            , type_acc                                                       ,             depit                                                             ,                credit                                                   ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext )values('" +
                     txt_entry_string.Text + "','" + dgv_term.Rows[z].Cells[1].Value.ToString() + "','" + dgv_term.Rows[z].Cells[2].Value.ToString() + "',  '" + dgv_term.Rows[z].Cells["rootlevel_"].Value.ToString() + "'    ,  '" + dgv_term.Rows[z].Cells["rootlevel_name_"].Value.ToString() + "', '" + dgv_term.Rows[z].Cells["type_acc_"].Value.ToString() + "'       ,  '" + dgv_term.Rows[z].Cells["sort_"].Value.ToString() + "'  ,  '" + Convert.ToDecimal(dgv_term.Rows[z].Cells[3].Value.ToString()) + "'      ,'" + Convert.ToDecimal(dgv_term.Rows[z].Cells[4].Value.ToString()) + "' ,'" + txt_name_book_type.Text + "','" + txt_code_entry_type.Text + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + txt_serial_string.Text + "','" + txt_code_book.Text + "','" + comb_code_name.Text + "','system adjiustment qty')");
            }
            //inser into  adj_qty_hd
            db.Run("insert into adj_qty_hd (adj_qty_hd_id,code_book,name_book,term,date_P,id_ware,code_entry,book_name_entry,code_book_entry,user_code,user_name) values ('" + txt_serial_string.Text + "','" + txt_code_book.Text + "','" + lbl_comb_code_name.Text + "','" + combo_type.Text + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + lbl_wars.Text + "','" + txt_entry_string.Text + "','" + txt_name_book_type.Text + "','" + txt_code_entry_type.Text + "','" + lbl_user_code.Text + "','" + lbl_user_name.Text + "')");

            //update ware 
            prog = dgv.Rows.Count;
            progressBar1.Visible = true;

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                db.Run("update wares set qty=" + dgv.Rows[i].Cells["new_qty"].Value + " where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "'and id_ware ='" + lbl_wars.Text + "'");
                backgroundWorker1.ReportProgress(i);
            }
            for (int i = 0; i < dgv_exp.Rows.Count; i++)
            {
                db.Run("insert into exp_date (code_items,name_items,exp_date,qty,code,code_book,id_ware) values ('" + dgv_exp.Rows[i].Cells["code_items_e"].Value + "','" + dgv_exp.Rows[i].Cells["name_items_e"].Value + "','" + Convert.ToDateTime(dgv_exp.Rows[i].Cells["exp_date"].Value).ToString("MM-dd-yyyy") + "','" + dgv_exp.Rows[i].Cells["net_qty_e"].Value + "','" + txt_serial_string.Text + "','" + txt_code_book.Text + "','" + lbl_wars.Text + "')");
            }
            progressBar1.Visible = false;
            progressBar1.Visible = false;
            v.adj_complet = true;
            XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "adjustment successfully ", "adjustment", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Close();
        }
        string code_items_a, name_items_a, cost_, qty_;//combo_add_items_SelectedIndexChanged
        string code_entry, sort, rootlevel, rootlevel_name, sort_acc;
        private void add_in_dgv()
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (combo_add_items.Text == dgv.Rows[i].Cells[2].Value.ToString())
                {
                    MessageBox.Show("douple");
                    return;
                }
            }
            dgv.Rows.Add(0, code_items_a, name_items_a, cost_, qty_);
        }
        private void add_in_dgv_with_repetaion()
        {
            dgv_exp.Rows.Add(0, code_items_a, name_items_a, dt_exp.Value, 0, 0,0);
        }
        private void perform_add()
        {
            if (rd_dgv.Checked == true )
            {
                add_in_dgv();
            }
            else if(rd_dgv.Checked==false)
            {
                add_in_dgv_with_repetaion();
            }
        
        }
        private void add_items_in_property_comboadd_items(string find_fild, string code_items)
        {
            code_items_a = db.GetData("select code_items from wares where " + find_fild + "='" + code_items + "'").Rows[0][0].ToString();
            name_items_a = db.GetData("select name_items from wares where " + find_fild + "='" + code_items + "'").Rows[0][0].ToString();
            cost_ = db.GetData("select cost from wares where " + find_fild + "='" + code_items + "'").Rows[0][0].ToString();
            qty_ = db.GetData("select qty from wares where " + find_fild + "='" + code_items + "'").Rows[0][0].ToString();
        }
        private void qty_wares_with_qty_exp()
        {
            //insert into trash to get equation
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                db.Run("insert into trash_adj_exp (code_items,plues_wares,mins_wares)values('" + dgv.Rows[i].Cells[1].Value.ToString() + "','" + dgv.Rows[i].Cells["plues"].Value.ToString() + "','" + dgv.Rows[i].Cells["min"].Value.ToString() + "')");
            }
            for (int i = 0; i < dgv_exp.Rows.Count; i++)
            {
                db.Run("insert into trash_adj_exp (code_items,plues_exp,mins_exp)values('" + dgv_exp.Rows[i].Cells[1].Value.ToString() + "','" + dgv_exp.Rows[i].Cells["plues_exp"].Value.ToString() + "','" + dgv_exp.Rows[i].Cells["min_exp"].Value.ToString() + "')");
            }
            //test qty wares == qty exp
            DataTable dt = new DataTable();
            db.GetData_DGV("select  code_items ,sum(plues_wares) as plues_wares,SUM(plues_exp) as plues_exp ,(sum(plues_wares) ) - (SUM(plues_exp))as def , sum(mins_wares) as mins_wares,SUM(mins_exp) as min_exp ,(sum(mins_wares) ) - (SUM(mins_exp))as def1  from trash_adj_exp group by code_items", dt);
            dgv_r.DataSource = dt;
            decimal def_s = 0;
            decimal def1_s = 0;

            for (int i = 0; i < dgv_r.Rows.Count; i++)
            {
                def_s += Convert.ToDecimal(dgv_r.Rows[i].Cells["def"].Value);
                def1_s += Convert.ToDecimal(dgv_r.Rows[i].Cells["def1"].Value);
            }
            lbl_def.Text = def_s + "";
            lbl_def1.Text = def1_s + "";
            if ((def_s + def1_s) != 0)
            {
                MessageBox.Show(" رصيد الصلاحيات غير متوافق مع المخزون", "فشل الاختبار ");
                excut_barButtonItem1.Enabled = false;
                save_arc_barButtonItem2.Enabled = false;
                db.Run("DELETE FROM [trash_adj_exp]");
                return;
            }
            else
            {
                excut_barButtonItem1.Enabled = true;
                save_arc_barButtonItem2.Enabled = true;
                db.Run("DELETE FROM [trash_adj_exp]");

            }
        }
        //------------Controls
        private void combo_add_items_SelectedIndexChanged(object sender, EventArgs e)
        {
            add_items_in_property_comboadd_items("name_items", combo_add_items.Text);
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            perform_add();
        }
        int prog;
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Maximum = prog;
            progressBar1.Value = e.ProgressPercentage;
        }
        //------------------------hot_keys
        private void combo_add_items_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                perform_add();
            }
        }
        private void txt_barcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    add_items_in_property_comboadd_items("code_items", txt_barcode.Text);
                    perform_add();
                    txt_barcode.Clear();
                    txt_barcode.Select();
                }
                catch (Exception)
                {
                }
            }
        }
        private void combo_add_items_Click(object sender, EventArgs e)
        {
            if (rd_dgv.Checked==true)
            {
                all_comb.load_name_items_normal_only(combo_add_items);
            }
            else
            {
                all_comb.load_name_items_exp(combo_add_items);

            }
        }
        private void btn_add_exp_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_exp.CurrentRow.Cells["exp_date"].Value = dt_exp.Value;

            }
            catch (Exception ex)
            {
                MessageBox.Show("حدد السطر في شاشه الصلاحيات ");
                return;
            }
        }

        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            calc();
        }

        private void btn_add_all_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("select wares.code_items,wares.name_items,wares.cost,wares.qty from wares left join items on wares.code_items=items.code_items  where id_ware='" + lbl_wars.Text + "' and [exp]=1 and wares.name_items like '%" + txt_barcode.Text + "%'", dt);
            dgv.DataSource = dt;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].Cells["new_qty"].Value = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void test_btn_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0 && dgv_exp.Rows.Count >0)
            {
                qty_wares_with_qty_exp();
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "Test is Completed ", "Test", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            
        }

        private void comb_code_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_code_book.Text = db.GetData("select code_book from book where name_book='" + comb_code_name.Text + "'").Rows[0][0].ToString();
            cls_book.selectbook("adj_qty_hd", "سند جرد", txt_code_book.Text, txt_serial, "adj_qty_hd_id");
            txt_serial_string.Text = txt_code_book.Text + txt_serial.Text;
            lbl_comb_code_name.Text = comb_code_name.Text;
        }

        private void combo_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_name_book_type.Text = db.GetData("select bookname_entry  from term  where term_id ='" + combo_type.Text + "'").Rows[0][0].ToString();
            txt_code_entry_type.Text = db.GetData("select code_entry  from term  where term_id ='" + combo_type.Text + "'").Rows[0][0].ToString();
            cls_book.selectbook("entry_hd", "سند قيد", txt_code_entry_type.Text, txt_code_entry, "code_entry");
        }

        private void dgv_exp_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            dgv_exp.CurrentRow.Cells["net_qty_e"].Value = Convert.ToDouble(dgv_exp.CurrentRow.Cells["plues_exp"].Value) - Convert.ToDouble(dgv_exp.CurrentRow.Cells["min_exp"].Value);
           
               
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void excut_barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            insert();
        }

        private void rd_dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                perform_add();
            }
        }

        private void rd_dgv_exp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                perform_add();
            }
        }


       



        //-----------------------------------------------
    }
}