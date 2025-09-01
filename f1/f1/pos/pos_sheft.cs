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

namespace f1.pos
{
    public partial class pos_sheft : DevExpress.XtraEditors.XtraForm
    {
        public pos_sheft()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon("f1.exe");
            db.Open();
        }
        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv);
        }
        private void pos_sheft_Load(object sender, EventArgs e)
        {
            all_comb.load_emp_users(combo_emp);
            all_comb.load_emp_no(combo_emp_codetree);
            combo_emp.Text = null;
            combo_emp_codetree.Text = null;
            lbl_shift_no.Caption = get_shift_no();
            load_current_shift();
        }
        bool edit = false;
        private void load_current_shift()
        {
//            string s = db.GetData("select isnull(max(lock),0) from pos_shift where shift_no=(select isnull(max(shift_no),0) from pos_shift)").Rows[0][0].ToString();
            string s = db.GetData("select isnull(max(lock),0) from pos_shift where lock='1'").Rows[0][0].ToString();

                if (s == "1")
                {
                    DataTable dt = new DataTable();
//                    db.GetData_DGV("select shift_no, emp_code, emp_name, date_open_shift, date_cloes_shift, data_def, bal_open, bal_cloes, bal_account, bal_actual,def_bal, cash, credit,tot from pos_shift where lock='1'", dt);
                    db.GetData_DGV("select shift_no, emp_code, emp_name, date_open_shift, date_cloes_shift, data_def, bal_open, bal_cloes, bal_account, bal_actual,def_bal, cash, credit,tot from pos_shift where lock='1'", dt);

                    //select isnull(SUM(incloud_taxes),0) from pos_dt where shift_no='1' and user_code='1'

                    dgv.DataSource = dt;
                    // XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "الورديه مفتواحه بالفعل  ", "Shift", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // return;
                }
        }
        private static string get_shift_no()
        {
            string shift_no = "";
            shift_no = db.GetData("select isnull(max(shift_no),0) from pos_shift ").Rows[0][0].ToString();
            if (shift_no == "0")
            {
                shift_no = "1";
                return shift_no = "1";
            }
            else if (db.GetData("select isnull(max(lock),0) from pos_shift where lock='1'").Rows[0][0].ToString() == "1") // to get last shift open 
            {
                shift_no = db.GetData("select shift_no from pos_shift where lock='1' ").Rows[0][0].ToString();
                return shift_no;
            }
            else
            {
                return shift_no = (Convert.ToInt32(shift_no) + 1) + "";
            }
        }
        private void open_shift()
        {
            if (dgv.Rows.Count < 0)
            {
                MessageBox.Show(dgv.Rows.Count+"");
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "اضف مستخدمين لكي تفتح ورديه  ", "Shift", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lbl_shift_no.Caption = get_shift_no();
            string s = db.GetData("select isnull(max(lock),0) from pos_shift where shift_no=(select isnull(max(shift_no),0) from pos_shift)").Rows[0][0].ToString();
            if (s == "1")
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "الورديه مفتواحه بالفعل  ", "Shift", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    db.Run("insert into pos_shift(shift_no, emp_code, emp_name, date_open_shift, date_cloes_shift, data_def, bal_open, bal_cloes, bal_account, bal_actual,def_bal, cash, credit,tot,lock) values ('" + lbl_shift_no.Caption + "','" + dgv.Rows[i].Cells[2].Value.ToString() + "','" + dgv.Rows[i].Cells[3].Value.ToString() + "','" + dgv.Rows[i].Cells[4].Value.ToString() + "','" + dgv.Rows[i].Cells[5].Value.ToString() + "','" + dgv.Rows[i].Cells[6].Value.ToString() + "','" + dgv.Rows[i].Cells[7].Value.ToString() + "','" + dgv.Rows[i].Cells[8].Value.ToString() + "','" + dgv.Rows[i].Cells[9].Value.ToString() + "','" + dgv.Rows[i].Cells[10].Value.ToString() + "','" + dgv.Rows[i].Cells[11].Value.ToString() + "','" + dgv.Rows[i].Cells[12].Value.ToString() + "','" + dgv.Rows[i].Cells[13].Value.ToString() + "','" + dgv.Rows[i].Cells[14].Value.ToString() + "','1')      ");
                    db.Run("insert into pos_cash(code_cash, name_cash, shift_no, user_code, balance)values('1','cash','" + lbl_shift_no.Caption + "','" + dgv.Rows[i].Cells[2].Value.ToString() + "',0)");
                    db.Run("insert into pos_cash(code_cash, name_cash, shift_no, user_code, balance)values('2','visa','" + lbl_shift_no.Caption + "','" + dgv.Rows[i].Cells[2].Value.ToString() + "',0)");

                }
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "تم فتح الورديه ", "Shift", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        private void cloes_shift()
        {
            if (dgv2.Rows.Count <= 1)
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "تيجب مراجعه الورديه ", "Shift", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string s = db.GetData("select lock from pos_shift where shift_no=(select isnull(max(shift_no),0) from pos_shift)").Rows[0][0].ToString();
            string shift_max = db.GetData("select isnull(max(shift_no),0) from pos_shift").Rows[0][0].ToString();
            //update 

            //update to cloes shift
            db.Run("update pos_shift set lock=0 where shift_no='" + shift_max + "'  ");
            XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "تم اغلاق الورديه  ", "Shift", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void add_emplyee_to_shift()
        {
            if (dgv.Rows.Count > 0)
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if (dgv.Rows[i].Cells["shift_no_c"].Value.ToString() == "0")
                    {
                         db.Run("insert into pos_shift(shift_no, emp_code, emp_name, date_open_shift, date_cloes_shift, data_def, bal_open, bal_cloes, bal_account, bal_actual,def_bal, cash, credit,tot,lock) values ('" + lbl_shift_no.Caption + "','" + dgv.Rows[i].Cells[2].Value.ToString() + "','" + dgv.Rows[i].Cells[3].Value.ToString() + "','" + dgv.Rows[i].Cells[4].Value.ToString() + "','" + dgv.Rows[i].Cells[5].Value.ToString() + "','" + dgv.Rows[i].Cells[6].Value.ToString() + "','" + dgv.Rows[i].Cells[7].Value.ToString() + "','" + dgv.Rows[i].Cells[8].Value.ToString() + "','" + dgv.Rows[i].Cells[9].Value.ToString() + "','" + dgv.Rows[i].Cells[10].Value.ToString() + "','" + dgv.Rows[i].Cells[11].Value.ToString() + "','" + dgv.Rows[i].Cells[12].Value.ToString() + "','" + dgv.Rows[i].Cells[13].Value.ToString() + "','" + dgv.Rows[i].Cells[14].Value.ToString() + "','1')      ");
                         XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "تم التعديل ", "Shift", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }


            }
        }
        private void add_in_dgv_without_repaet()
        {
            string s = db.GetData("select isnull(max(lock),0) from pos_shift where shift_no=(select isnull(max(shift_no),0) from pos_shift)").Rows[0][0].ToString();
            if (s == "1") edit = true;

            if (edit==true)
            {
                MessageBox.Show(dgv.Rows.Count+"");
                //for (int i = 0; i < dgv.Rows.Count; i++)
                //{
                //   // MessageBox.Show(dgv.Rows[i].Cells[1].Value.ToString() + "   " + combo_emp_codetree.Text);

                //    if (combo_emp_codetree.Text == dgv.Rows[i].Cells[2].Value.ToString())
                //    {
                //       // MessageBox.Show("ممكرر");
                //        return;
                //    }
                //    else if (combo_emp_codetree.Text != dgv.Rows[i].Cells[2].Value.ToString())
                //    {
                //        dgv.Rows.Add(0, 0, combo_emp_codetree.Text, combo_emp.Text, lbl_time.Text);
                //    }
                //}
                DataTable dataTable = (DataTable)dgv.DataSource;
                DataRow drToAdd = dataTable.NewRow();
                drToAdd["shift_no"] = 0;
                drToAdd["emp_code"] = combo_emp_codetree.Text;
                drToAdd["emp_name"] = combo_emp.Text;
                drToAdd["date_open_shift"] = lbl_time.Text;
                drToAdd["date_cloes_shift"] = 0;
                drToAdd["data_def"] = 0;
                drToAdd["bal_open"] = 0;
                drToAdd["bal_cloes"] = 0;
                drToAdd["bal_account"] = 0;
                drToAdd["bal_actual"] = 0;
                drToAdd["def_bal"] = 0;
                drToAdd["cash"] = 0;
                drToAdd["credit"] = 0;
                drToAdd["tot"] = 0;
                dataTable.Rows.Add(drToAdd);
                dataTable.AcceptChanges();
            }
            else
            {
                dgv.Rows.Add(0, 0, combo_emp_codetree.Text, combo_emp.Text, lbl_time.Text,0,0,0,0,0,0,0,0,0,0);

            }
            
        }
        private void combo_emp_codetree_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combo_emp.Text = db.GetData("select emp_name from emps where emp_no='" + combo_emp_codetree.Text + "'").Rows[0][0].ToString();
            }
            catch (Exception)
            {
            }
        }
        private void combo_emp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combo_emp_codetree.Text = db.GetData("select  emp_no from emps where emp_name='" + combo_emp.Text + "'").Rows[0][0].ToString();
            }
            catch (Exception)
            {
            }
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            add_in_dgv_without_repaet();
        }
        private void combo_emp_codetree_Enter(object sender, EventArgs e)
        {
           // add_in_dgv_without_repaet();

        }

        private void combo_emp_Enter(object sender, EventArgs e)
        {
           // add_in_dgv_without_repaet();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_time.Text = DateTime.Now.ToString("HHmmss");
            timer_par.Caption = DateTime.Now.ToString("hh:mm:ss ");
            bar_data1.Caption = DateTime.Now.ToString("yyyy:MM:dd ");
           
        }
        
        private void bar_open_shift_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)//scrap
        {
            
        }
        private void bar_cloes_shift_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)//scrap
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                MessageBox.Show(dgv.Rows.Count + "");
                
            }
        }
        

        private void btn_open_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            open_shift();
        }

        private void btn_close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            cloes_shift();
        }

        private void btn_save_edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            add_emplyee_to_shift();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("select shift_no as shift_no , user_code as emp_code,user_name as emp_name,(select isnull(max(bal_open),0) from pos_shift where lock='1' and emp_code='" + combo_code_emp.Text + "') as bal_open ,sum(incloud_taxes) as bal_cloes,SUM(incloud_taxes) as bal_account ,isnull(sum(incloud_taxes),0) as bal_actual ,(select isnull(sum(balance),0) from pos_cash where  shift_no='" + lbl_shift_no.Caption + "' and user_code='" + combo_code_emp.Text + "' and code_cash='1' ) as cash,(select isnull(sum(balance),0) from pos_cash where  shift_no='" + lbl_shift_no.Caption + "' and user_code='" + combo_code_emp.Text + "' and code_cash='2' ) as visa  from pos_dt where shift_no='" + lbl_shift_no.Caption + "' and user_code='" + combo_code_emp.Text + "' group  by shift_no,user_code,user_name", dt);
            dgv2.DataSource = dt;
        }
    }
}