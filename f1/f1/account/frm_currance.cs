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

namespace f1.account
{
    public partial class frm_currance : DevExpress.XtraEditors.XtraForm
    {
        public frm_currance()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon("f1.exe");
            db.Open();
           
        }
        private void frm_currance_Load(object sender, EventArgs e)
        {
            
            all_comb.load_account_name_c(combo_add_account);
            combo_add_account.Text = "";
           // dt_piker.MinDate = new DateTime(2020, 01, 01);
           // dt_piker.MaxDate = new DateTime(2020, 12, 31);
           // dt_piker.Text = DateTime.Now.ToString("yyyy/MM/dd");
            dt_piker.MinDate = new DateTime(v.current_yaer, 1, 1);
            dt_piker.MaxDate = new DateTime(v.current_yaer, 12, 31);
            // dt_search.Text = DateTime.Now.ToString("yyyy/MM/dd");
            cls_book.loadbook(comb_code, "سند قيد");
           // cls_book.loadbook(combo_name_searsh, "سند قيد");
          //  groupControl5.Visible = false;
            all_comb.load_curracne(combo_currance);
            groupControl1.Visible = false;
            btn_generat_forex.Enabled = true;
            btn_show.Enabled = false;
            btn_save.Enabled = false;
            txt_main_curance.Text = db.GetData("SELECT currance FROM   currance where f_currance=1").Rows[0][0].ToString();

            //=============
           
                  DataTable dt = new DataTable();
                  db.GetData_DGV("SELECT currance, f_currance, main FROM currance where  main=2", dt);
                  dgv_main.DataSource = dt;
        }
       
        //===================function
        //forex 
        private void calc_forex()
        {
            double proft = 0;
            double loss = 0;
            for (int i = 0; i < dgv_forex.Rows.Count; i++)
            {
                proft += Convert.ToDouble(dgv_forex.Rows[i].Cells["profit"].Value);
                loss += (Convert.ToDouble(dgv_forex.Rows[i].Cells["lose"].Value));
                lbl_prof.Text = proft + "";
                lbl_loss.Text = loss + "";
                lbl_def_forex.Text = (proft - loss).ToString();
            }
        }
        private void net_currance_local_forgen()
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("select acc_num,acc_name,(sum(depit)-sum(credit))as net_local,(sum(depit_cur)-sum(credit_cur))as net_forgen from entry where f_currance > 1 and type_acc='ميزانية'  group by acc_num,acc_name,currance   ", dt);
         //   db.GetData_DGV("select acc_num,acc_name,(sum(depit)-sum(credit))as net_local,(sum(depit_cur)-sum(credit_cur))as net_forgen from entry where f_currance > 1   group by acc_num,acc_name,currance   ", dt);
            dgv_net_forgen_local.DataSource = dt;
        }
        private void get_forex()
        {
            if (txt_rate.Text == "")
            {
                MessageBox.Show("enter currance rate");
                return;

            }
            else if (txt_rate.Text == "0")
            {
                MessageBox.Show("enter currance rate");
                return;
            }
            //control 
            btn_generat_forex.Enabled = false;
            btn_show.Enabled = true;
            btn_save.Enabled = false;
            //--------------------------------------
                net_currance_local_forgen();
                decimal get_loacl_value = 0;
                decimal get_forex_value = 0;
                for (int i = 0; i < dgv_net_forgen_local.Rows.Count; i++)
                {
                    get_loacl_value = Convert.ToDecimal(dgv_net_forgen_local.Rows[i].Cells["net_forgen"].Value) * Convert.ToDecimal(txt_rate.Text);
                    get_forex_value = get_loacl_value - Convert.ToDecimal(dgv_net_forgen_local.Rows[i].Cells["net_local"].Value);
                    if (get_forex_value > 0)
                    {
                        dgv_forex.Rows.Add(dgv_net_forgen_local.Rows[i].Cells["acc_num"].Value, dgv_net_forgen_local.Rows[i].Cells["acc_name"].Value, get_forex_value, 0);
                    }
                    else
                    {
                        dgv_forex.Rows.Add(dgv_net_forgen_local.Rows[i].Cells["acc_num"].Value, dgv_net_forgen_local.Rows[i].Cells["acc_name"].Value, 0, (get_forex_value) * -1);
                    }
                }
                calc_forex();
            
        }
        //add dgv 
        private void add_dgv()
        {
            btn_generat_forex.Enabled = false;
            btn_show.Enabled = false;
            btn_save.Enabled = true;
            groupControl1.Visible = true;
                 for (int i = 0; i < dgv_forex.Rows.Count; i++)
            {
                string lbl_code_, lbl_name_, lbl_rootlevel_, lbl_sort_, lbl_type_acc_, lbl_rootlevel_name_, lbl_currance_code_, lbl_currance_factor_;

                lbl_code_ = db.GetData("select rootid from tree where rootname='" + dgv_forex.Rows[i].Cells[1].Value + "'").Rows[0][0].ToString();
                lbl_name_ = db.GetData("select rootname from tree where rootname='" + dgv_forex.Rows[i].Cells[1].Value + "'").Rows[0][0].ToString();
                lbl_rootlevel_ = db.GetData("select rootlevel from tree where rootname='" + dgv_forex.Rows[i].Cells[1].Value + "'").Rows[0][0].ToString();
                lbl_sort_ = "1";
                lbl_type_acc_ = db.GetData("select sort from tree where rootname='" + dgv_forex.Rows[i].Cells[1].Value + "'").Rows[0][0].ToString();
                lbl_rootlevel_name_ = "0";
                lbl_currance_code_ = db.GetData("select currance from tree where rootname='" + dgv_forex.Rows[i].Cells[1].Value + "'").Rows[0][0].ToString();
              //  lbl_currance_factor_ = db.GetData("select isnull(max (f_currance),0) from currance where currance='" + dgv_forex.Rows[i].Cells[1].Value + "'").Rows[0][0].ToString();

                dgv.Rows.Add(0, dgv_forex.Rows[i].Cells[0].Value, dgv_forex.Rows[i].Cells[1].Value, dgv_forex.Rows[i].Cells[2].Value, dgv_forex.Rows[i].Cells[3].Value, lbl_type_acc_, lbl_sort_, lbl_rootlevel_name_, lbl_rootlevel_, lbl_currance_code_, txt_rate.Text, 0, 0, 0);
            }
            if (Convert.ToDouble(lbl_def_forex.Text) > 0)
            {
                dgv.Rows.Add(null, lbl_code.Text, lbl_name.Text,0, lbl_def_forex.Text, lbl_type_acc.Text, lbl_sort.Text, lbl_rootlevel_name.Text, lbl_rootlevel.Text, lbl_currance_code.Text, lbl_currance_factor.Text, 0, 0, 0);
            }
            else
            {
                dgv.Rows.Add(null, lbl_code.Text, lbl_name.Text, Convert.ToDecimal(lbl_def_forex.Text)*-1,0, lbl_type_acc.Text, lbl_sort.Text, lbl_rootlevel_name.Text, lbl_rootlevel.Text, lbl_currance_code.Text, lbl_currance_factor.Text, 0, 0, 0);
            }
            
        }
        //save
        public void calc()
        {
            try
            {
                double depit = 0;
                double ceridt = 0;
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    depit += Convert.ToDouble(dgv.Rows[i].Cells["depit"].Value);
                    ceridt += (Convert.ToDouble(dgv.Rows[i].Cells["credit"].Value));
                    lbl_depit.Text = depit + "";
                    lbl_credit.Text = ceridt + "";
                    lbl_def.Text = (depit - ceridt).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void save()
        {
            calc();
            if (Convert.ToDouble(lbl_def.Text.ToString()) != 0)
            {
                MessageBox.Show("المدين لا يساوي الدائن");
                return;
            }
            //contol
            btn_generat_forex.Enabled = false;
            btn_show.Enabled = false;
            btn_save.Enabled = false;
            //------------
            txt_code_book.Text = db.GetData("select code_book from book where name_book='" + comb_code.Text + "'").Rows[0][0].ToString();
            cls_book.selectbook("entry", "سند قيد", txt_code_book.Text, txt_serial, "code_entry");
            txt_serial_string.Text = txt_code_book.Text + txt_serial.Text;
            //insert into entry_hd
            db.Run("insert into entry_hd ([code_entry],code_book) values ('"+txt_serial_string.Text+"','"+txt_code_book.Text+"')");
            //inser into entry
                  for (int i = 0; i < dgv.Rows.Count; i++)
                  {
                      db.Run("insert into entry([code_entry],acc_num,acc_name,rootlevel,type_acc,sort,depit,credit,name_book,code_book,dates,rootlevel_name,attachtext,depit_cur, credit_cur, currance, f_currance,costcenter_code)values('" + txt_serial_string.Text + "','" + dgv.Rows[i].Cells["acc_num_s"].Value + "','" + dgv.Rows[i].Cells["acc_name_s"].Value + "','" + dgv.Rows[i].Cells["rootlevel"].Value + "','" + dgv.Rows[i].Cells["type_acc"].Value + "','" + dgv.Rows[i].Cells["sort"].Value + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["depit"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["credit"].Value) + ",'" + comb_code.Text + "','" + txt_code_book.Text + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + dgv.Rows[i].Cells["rootlevel_name"].Value + "','forex change currance','" + dgv.Rows[i].Cells["depit_cur"].Value + "','" + dgv.Rows[i].Cells["credit_cur"].Value + "','" + dgv.Rows[i].Cells["currance_c"].Value + "','" + dgv.Rows[i].Cells["f_currance"].Value + "','" + dgv.Rows[i].Cells["costcenter"].Value + "')");

                  }
                 // MessageBox.Show("save");
            
        }
        //controls
        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv);
        }
        private void comb_code_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_code_book.Text = db.GetData("select code_book from book where name_book='" + comb_code.Text + "'").Rows[0][0].ToString();
            cls_book.selectbook("entry", "سند قيد", txt_code_book.Text, txt_serial, "code_entry");
            txt_serial_string.Text = txt_code_book.Text + txt_serial.Text;
        }
        private void combo_add_account_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_code.Text = db.GetData("select rootid from tree where rootname='" + combo_add_account.Text + "'").Rows[0][0].ToString();
            lbl_name.Text = db.GetData("select rootname from tree where rootname='" + combo_add_account.Text + "'").Rows[0][0].ToString();
            lbl_rootlevel.Text = db.GetData("select rootlevel from tree where rootname='" + combo_add_account.Text + "'").Rows[0][0].ToString();
            lbl_sort.Text = "1";
            lbl_type_acc.Text = db.GetData("select sort from tree where rootname='" + combo_add_account.Text + "'").Rows[0][0].ToString();
            lbl_rootlevel_name.Text = "0";
            lbl_currance_code.Text = db.GetData("select currance from tree where rootname='" + combo_add_account.Text + "'").Rows[0][0].ToString();
            lbl_currance_factor.Text = db.GetData("select isnull(max (f_currance),0) from currance where currance='" + lbl_currance_code.Text + "'").Rows[0][0].ToString();
        }
        private void btn_generat_forex_Click(object sender, EventArgs e)
        {
            get_forex();
           
        }
        private void btn_show_Click(object sender, EventArgs e)
        {
            add_dgv();
            
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            save();
            MessageBox.Show("save");
           
        }
        private void btn_add_fogrn_currance_Click(object sender, EventArgs e)
        {
            if (txt_rate_submain.Text =="" || txt_current_forgen_submain.Text=="")
            {
                MessageBox.Show("العملات الاجنبيه ");
                return;
            }
            db.Run("insert into currance (currance, f_currance, main) values('" + txt_current_forgen_submain.Text + "','" + txt_rate_submain.Text + "',2)");
            DataTable dt = new DataTable();
            db.GetData_DGV("SELECT currance, f_currance, main FROM   currance",dt);
            dgv_main.DataSource = dt;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("هل تريد عمل سند جديد!!؟؟؟؟ ", "رسال جديد مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                account.frm_currance frm = new frm_currance();
                this.Close();
                frm.Show();
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("هل تريد عمل سند جديد!!؟؟؟؟ ", "رسال جديد مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                db.Run("delete from currance where currance='" + dgv_main.CurrentRow.Cells["currance"].Value.ToString() + "'");
                DataTable dt = new DataTable();
                db.GetData_DGV("SELECT currance, f_currance, main FROM   currance", dt);
                dgv_main.DataSource = dt;
            }
            
        }
    }
}