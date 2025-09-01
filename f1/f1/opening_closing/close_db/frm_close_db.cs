using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Data.SqlClient;

namespace f1.opening_closing.close_db
{
    public partial class frm_close_db : DevExpress.XtraEditors.XtraForm
    {
        public frm_close_db()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon("f1.exe");
            db.Open();
        }
        //function 
        private void calc_gl()
        {

            try
            {
                double depit = 0;
                double ceridt = 0;
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    depit += Convert.ToDouble(dgv.Rows[i].Cells["depit_g"].Value);
                    ceridt += (Convert.ToDouble(dgv.Rows[i].Cells["credit_g"].Value));
                    lbl_depit_g.Text = depit + "";
                    lbl_credit_g.Text = ceridt + "";
                    //lbl_def_g.Text = (depit - ceridt).ToString();
                    lbl_def_g.Text = Math.Round((depit - ceridt), 2) + "";
                   // lbl_incloud_taxes.Text = Math.Round(incloud_taxes, 2) + "";

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void calc_gl2()
        {

            try
            {
                double depit = 0;
                double ceridt = 0;
                for (int i = 0; i < dgv2.Rows.Count; i++)
                {
                    depit += Convert.ToDouble(dgv2.Rows[i].Cells["depit_2"].Value);
                    ceridt += (Convert.ToDouble(dgv2.Rows[i].Cells["credit_2"].Value));
                    lbl_depit_2.Text = depit + "";
                    lbl_credit_2.Text = ceridt + "";
                    lbl_def_2.Text = (depit - ceridt).ToString();

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void wright(string txt)
        {
            //to wright in txt
            StreamWriter str = new StreamWriter("data.txt", true);
            str.WriteLine(txt);
            str.Close();
        }
        private void select_account(System.Windows.Forms.ComboBox combo_)//function to select gl in comob
        {
            lbl_code.Text = db.GetData("select rootid from tree where rootname='" + combo_.Text + "'").Rows[0][0].ToString();
            lbl_name.Text = db.GetData("select rootname from tree where rootname='" + combo_.Text + "'").Rows[0][0].ToString();
            lbl_rootlevel.Text = db.GetData("select rootlevel from tree where rootname='" + combo_.Text + "'").Rows[0][0].ToString();
            lbl_sort.Text = "1";
            lbl_type_acc.Text = db.GetData("select sort from tree where rootname='" + combo_.Text + "'").Rows[0][0].ToString();
            lbl_rootlevel_name.Text = "0";
        }
        string code, name, rootlevel, sort, type_acc, rootlevel_name;
        private void select_account_next_year(System.Windows.Forms.ComboBox combo_)//function to select gl in comob
        {
            code = db.GetData("select rootid from tree where rootname='" + combo_.Text + "'").Rows[0][0].ToString();
            name = db.GetData("select rootname from tree where rootname='" + combo_.Text + "'").Rows[0][0].ToString();
            rootlevel = db.GetData("select rootlevel from tree where rootname='" + combo_.Text + "'").Rows[0][0].ToString();
            sort = "1";
            type_acc = db.GetData("select sort from tree where rootname='" + combo_.Text + "'").Rows[0][0].ToString();
            rootlevel_name = "0";
        }
//controls 
        private void combo_net_loss_this_years_Click(object sender, EventArgs e)
        {
            all_comb.load_account_name_c(combo_net_loss_this_years);
        }
        private void btn_open_finaly_Click(object sender, EventArgs e)//generat close entry and pright proft or loss
        {
            
            DataTable dt = new DataTable();
            db.GetData_DGV("select acc_num,acc_name,sum (depit)as depit,SUM (credit) as credit,(SUM(depit)-SUM(credit)) as tot,rootlevel,rootlevel_name,type_acc,sort from entry where code_entry <> '-11' and type_acc ='ميزانيه' group by acc_num,acc_name,rootlevel,rootlevel_name,type_acc,sort",dt);
            dgv.DataSource = dt;
            //add line close 

            decimal ammunt_of_close = Convert.ToDecimal(db.GetData("select isnull(SUM(credit)-SUM(depit ),0) from entry where type_acc='قائمه دخل'").Rows[0][0].ToString());
            decimal dep, cr;
            if (ammunt_of_close > 0)
            {
                dep = 0;
                cr = ammunt_of_close;
            }
            else
            {
                dep = ammunt_of_close*-1 ;
                cr = 0;
            }
            DataTable dataTable = (DataTable)dgv.DataSource;
            DataRow drToAdd = dataTable.NewRow();
            drToAdd[0] = null;
            drToAdd["acc_num"] = lbl_code.Text;
            drToAdd["acc_name"] = lbl_name.Text;
            drToAdd["depit"] = dep.ToString();
            drToAdd["credit"] = cr.ToString();
            drToAdd["type_acc"] = lbl_type_acc.Text;
            drToAdd["sort"] = lbl_sort.Text;
            drToAdd["rootlevel"] = lbl_rootlevel.Text;
            drToAdd["rootlevel_name"] = lbl_rootlevel_name.Text;
            drToAdd["tot"] = "0";

            dataTable.Rows.Add(drToAdd);
            dataTable.AcceptChanges();

            calc_gl();
            //=====================creat new entry new yaers
            //btn_creat_entry_in_dgv2.PerformClick();

           
        }
        private void combo_next_years_Click(object sender, EventArgs e)//click to get gl
        {
            all_comb.load_account_name_c(combo_next_years);
        }
        private void combo_net_loss_this_years_SelectedIndexChanged(object sender, EventArgs e)//select account
        {
            select_account(combo_net_loss_this_years);
        }
        private void combo_next_years_SelectedIndexChanged(object sender, EventArgs e)
        {
            select_account_next_year(combo_next_years);

        }
        private void btn_save_cloes_Click(object sender, EventArgs e)
        {
            //===mew yaers  show in dgv2
            DataTable dt = new DataTable();
            db.GetData_DGV("select acc_num,acc_name,sum (depit)as depit,SUM (credit) as credit,(SUM(depit)-SUM(credit)) as tot,rootlevel,rootlevel_name,type_acc,sort from entry where code_entry <> '-11' and type_acc ='ميزانيه' group by acc_num,acc_name,rootlevel,rootlevel_name,type_acc,sort", dt);
            dgv2.DataSource = dt;
            //add line close 

            decimal ammunt_of_close = Convert.ToDecimal(db.GetData("select isnull(SUM(credit)-SUM(depit ),0) from entry where type_acc='قائمه دخل'").Rows[0][0].ToString());
            decimal dep, cr;
            if (ammunt_of_close > 0)
            {
                dep = 0;
                cr = ammunt_of_close;
            }
            else
            {
                dep = ammunt_of_close * -1;
                cr = 0;
            }
            DataTable dataTable = (DataTable)dgv2.DataSource;
            DataRow drToAdd = dataTable.NewRow();
            drToAdd[0] = null;
            drToAdd["acc_num"] = code;
            drToAdd["acc_name"] = name;
            drToAdd["depit"] = dep.ToString();
            drToAdd["credit"] = cr.ToString();
            drToAdd["type_acc"] = type_acc;
            drToAdd["sort"] = sort;
            drToAdd["rootlevel"] = rootlevel;
            drToAdd["rootlevel_name"] = rootlevel_name;
            drToAdd["tot"] = "0";

            dataTable.Rows.Add(drToAdd);
            dataTable.AcceptChanges();

            calc_gl2();

            //==========
             if (Convert.ToDouble(lbl_def_g.Text.ToString()) == 0)
              {

                  for (int i = 0; i < dgv.Rows.Count; i++)
                  {
                      db.Run("insert into entry([code_entry],acc_num,acc_name,rootlevel,type_acc,sort,depit,credit,name_book,code_book,dates,rootlevel_name,attachtext,opening_bal)values('-8','" + dgv.Rows[i].Cells["acc_num_g"].Value + "','" + dgv.Rows[i].Cells["acc_name_g"].Value + "','" + dgv.Rows[i].Cells["rootlevel_g"].Value + "','" + dgv.Rows[i].Cells["type_acc_g"].Value + "','" + dgv.Rows[i].Cells["sort_g"].Value + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["depit_g"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["credit_g"].Value) + ",'closing Entry ','closing Entry','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + dgv.Rows[i].Cells["rootlevel_name_g"].Value + "','closing Entry','" + dgv.Rows[i].Cells["tot"].Value + "')");
                  }
                 

              }
              else
              {
                  MessageBox.Show("المدين لا يساوي الدائن" + lbl_def_g.Text.ToString());
                  return;
              }
          //insert oepng entry new yar in trash and entry new yare
             if (Convert.ToDouble(lbl_def_g.Text.ToString()) == 0)
             {

                 for (int i = 0; i < dgv.Rows.Count; i++)
                 {
                     db.Run("insert entry_opening_new_years ([code_entry],acc_num,acc_name,rootlevel,type_acc,sort,depit,credit,name_book,code_book,dates,rootlevel_name,attachtext,opening_bal)values('-9','" + dgv2.Rows[i].Cells["acc_num_2"].Value + "','" + dgv2.Rows[i].Cells["acc_name_2"].Value + "','" + dgv2.Rows[i].Cells["rootlevel_2"].Value + "','" + dgv2.Rows[i].Cells["type_acc_2"].Value + "','" + dgv2.Rows[i].Cells["sort_2"].Value + "'," + Convert.ToDecimal(dgv2.Rows[i].Cells["depit_2"].Value) + "," + Convert.ToDecimal(dgv2.Rows[i].Cells["credit_2"].Value) + ",'opening Entry in new year ','opening Entry in new year','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + dgv2.Rows[i].Cells["rootlevel_name_2"].Value + "','opening Entry in new year','" + dgv2.Rows[i].Cells["tot_2"].Value + "')");
                 }
                 db.Run("insert into entry_trash select * from entry where code_entry='-11'");
                 for (int i = 0; i < dgv2.Rows.Count; i++)
                 {
                     db.Run("insert entry_trash ([code_entry],acc_num,acc_name,rootlevel,type_acc,sort,depit,credit,name_book,code_book,dates,rootlevel_name,attachtext,opening_bal)values('-9','" + dgv2.Rows[i].Cells["acc_num_2"].Value + "','" + dgv2.Rows[i].Cells["acc_name_2"].Value + "','" + dgv2.Rows[i].Cells["rootlevel_2"].Value + "','" + dgv2.Rows[i].Cells["type_acc_2"].Value + "','" + dgv2.Rows[i].Cells["sort_2"].Value + "'," + Convert.ToDecimal(dgv2.Rows[i].Cells["depit_2"].Value) + "," + Convert.ToDecimal(dgv2.Rows[i].Cells["credit_2"].Value) + ",'opening Entry in new year ','opening Entry in new year','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + dgv2.Rows[i].Cells["rootlevel_name_2"].Value + "','opening Entry in new year','" + dgv2.Rows[i].Cells["tot_2"].Value + "')");

                     //   db.Run("insert entry_trash ([code_entry],acc_num,acc_name,rootlevel,type_acc,sort,depit,credit,name_book,code_book,dates,rootlevel_name,attachtext,opening_bal)values('-9','" + dgv.Rows[i].Cells["acc_num_g"].Value + "','" + dgv.Rows[i].Cells["acc_name_g"].Value + "','" + dgv.Rows[i].Cells["rootlevel_g"].Value + "','" + dgv.Rows[i].Cells["type_acc_g"].Value + "','" + dgv.Rows[i].Cells["sort_g"].Value + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["depit_g"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["credit_g"].Value) + ",'closing Entry ','closing Entry','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + dgv.Rows[i].Cells["rootlevel_name_g"].Value + "','closing Entry','" + dgv.Rows[i].Cells["tot"].Value + "')");

                 }
                 MessageBox.Show("save");
             }
             else
             {
                 MessageBox.Show("المدين لا يساوي الدائن" + lbl_def_g.Text.ToString());
                 return;
             }
             btn_creat_db.Visible = true;
          
        }
        private void btn_creat_db_Click(object sender, EventArgs e)
        {
            marqueeProgressBarControl1.Visible = true;
            wright(txt_db_new.Text);
            string dbtxt = "";
            dbtxt = txt_db_new.Text;
            //creat data base 
            db.Run("create database " + dbtxt + "");
            MessageBox.Show("data base has been Created ");

            //take tables from current data base 

            //=====
            db.Run(" select * into " + dbtxt + ".dbo.entry from " + db.dbname + ".dbo.entry_trash "); 
            //db.Run(" select * into " + dbtxt + ".dbo.accounts from point.dbo.accounts");
            //db.Run("select * into " + dbtxt + ".dbo.action from point.dbo.action");
            //db.Run("select * into " + dbtxt + ".dbo.book from point.dbo.book");
            //db.Run("select * into " + dbtxt + ".dbo.chart from point.dbo.chart");
            //db.Run("select * into " + dbtxt + ".dbo.close_entry from point.dbo.close_entry");
            //db.Run("select * into " + dbtxt + ".dbo.emp from point.dbo.emp");
            //db.Run("select * into " + dbtxt + ".dbo.entry from point.dbo.entry");
            //db.Run("select * into " + dbtxt + ".dbo.items from point.dbo.items");
            //db.Run("select * into " + dbtxt + ".dbo.pay from point.dbo.pay");
            //db.Run("select * into " + dbtxt + ".dbo.rec from point.dbo.rec");
            //db.Run("select * into " + dbtxt + ".dbo.rec_inv_dt from point.dbo.rec_inv_dt");
            //db.Run("select * into " + dbtxt + ".dbo.rec_inv_hd from point.dbo.rec_inv_hd");
            //db.Run("select * into " + dbtxt + ".dbo.sale_dt from point.dbo.sale_dt");
            //db.Run("select * into " + dbtxt + ".dbo.sale_hd from point.dbo.sale_hd");
            //db.Run("select * into " + dbtxt + ".dbo.terms from point.dbo.terms");
            //db.Run("select * into " + dbtxt + ".dbo.tree from point.dbo.tree");
            //db.Run("select * into " + dbtxt + ".dbo.unit from point.dbo.unit");
            //db.Run("select * into " + dbtxt + ".dbo.vcs from point.dbo.vcs");
            //db.Run("select * into " + dbtxt + ".dbo.wares from point.dbo.wares");
            //db.Run("select * into " + dbtxt + ".dbo.info_co from point.dbo.info_co");
            //=====

            MessageBox.Show("table inserted");

            //delete scrap data table 
            //db.Run("use " + dbtxt + " delete from action");
            //MessageBox.Show("table scrap delelted");


            ////tabel inesrt 
            ////insert beging balance in Entry -3
            //for (int i = 0; i < dgv_close.Rows.Count; i++)
            //{
            //    db.Run("use " + dbtxt + " insert into entry(code_entry,acc_num,acc_name,opening_bal,date_p ,rootlevel,sort_acc,depit,crdit) values('-3','" + dgv_close.Rows[i].Cells["c_acc_num"].Value + "','" + dgv_close.Rows[i].Cells["c_acc_name"].Value + "','" + dgv_close.Rows[i].Cells["c_opening_bal"].Value + "','" + dt_piker.Text + "',(select RootLevel from tree where RootID='" + dgv_close.Rows[i].Cells["c_acc_num"].Value + "'),(select sort from tree where RootID='" + dgv_close.Rows[i].Cells["c_acc_num"].Value + "'),0,0 ) ");
            //}
            ////table update
            //db.Run("update info_co set period ='" + v.current_yaer + 1 + "'");
            //MessageBox.Show("table updated");

            //MessageBox.Show("data base creatred");

            ////get net profit or net loss 

            ////get closeing Entry
           // backgroundWorker1.ReportProgress(i);

            //insert into new entry -9

          
            marqueeProgressBarControl1.Visible = false;

        }

        private void wizardControl1_FontChanged(object sender, EventArgs e)
        {
            Close();
        }

        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv,"no");
        }

        private void dgv2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv2, "no2");
        }

        private void frm_close_db_Load(object sender, EventArgs e)
        {
            dt_piker.Text = DateTime.Now.ToString("yyyy/MM/dd");
        }

      
        

    }
}