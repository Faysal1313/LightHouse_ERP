using DevExpress.XtraEditors;
using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace f1.pos
{
    public partial class pos_screen_sumer : DevExpress.XtraEditors.XtraForm
    {
        public pos_screen_sumer()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
        }

        private void pos_screen_sumer_Load(object sender, EventArgs e)
        {

            lbl_opening.Text = db.GetData("select isnull(max(bal_open),0) from pos_shift where  shift_no='" + v.shift_no + "'").Rows[0][0].ToString();
           // lbl_discount.Text = db.GetData("select max(discount_all) from pos_dt where shift_no='" + v.shift_no + "'").Rows[0][0].ToString();
           // lbl_expenses.Text = db.GetData("select isnull(sum(depit),0) from entry where attachno='" + v.shift_no + "' and acc_name <>''").Rows[0][0].ToString();
            lbl_discount.Text = db.GetData("select isnull(SUM(discount_all),0) from pos_dt where shift_no='" + v.shift_no + "'").Rows[0][0].ToString();
            lbl_expenses.Text = db.GetData("select isnull(SUM(depit),0) from entry where attachno='" + v.shift_no + "'and code_entry <> '002' and attachnamebook <>'POS credit' ").Rows[0][0].ToString();
            lbl_credit.Text= db.GetData("select isnull(SUM(depit),0) from entry where attachno='" + v.shift_no + "' and attachnamebook ='POS credit' ").Rows[0][0].ToString();
           
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();


            db.GetData_DGV("select pos_inv_no,code_items,name_items,name_unite,qty,item_price,incloud_taxes,discount_all,time_h,date_d from pos_dt where shift_no='"+v.shift_no+ "'-- and onRoll ='0'  ", dt);
            //db.GetData_DGV("select pos_inv_no,code_items,name_items,name_unite,qty,item_price,incloud_taxes,discount_all,time_h,date_d from pos_dt where shift_no='" + v.shift_no + "'-- and onRoll ='1'  ", dt2);
            //db.GetData_DGV("select pos_inv_no,code_items,name_items,name_unite,qty,item_price,incloud_taxes,discount_all,time_h,date_d from pos_dt where shift_no='" + v.shift_no + "'-- and onRoll ='2'  ", dt3);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv_inv.Rows.Add("",dt.Rows[i][0]+"", dt.Rows[i][1] + "", dt.Rows[i][2] + "", dt.Rows[i][3] + "", dt.Rows[i][4] + "", dt.Rows[i][5] + "", dt.Rows[i][6] + "", dt.Rows[i][7] + "", dt.Rows[i][8] + "", dt.Rows[i][9] + "");
            }
            dgv_inv.Rows.Add("", "", "فواتير الاجل");
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                dgv_inv.Rows.Add("", dt2.Rows[i][0] + "", dt2.Rows[i][1] + "", dt2.Rows[i][2] + "", dt2.Rows[i][3] + "", dt2.Rows[i][4] + "", dt2.Rows[i][5] + "", dt2.Rows[i][6] + "", dt2.Rows[i][7] + "", dt2.Rows[i][8] + "", dt2.Rows[i][9] + "");
            }
            dgv_inv.Rows.Add("", "", "هداية او ضيافة ");
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                dgv_inv.Rows.Add("", dt3.Rows[i][0] + "", dt3.Rows[i][1] + "", dt3.Rows[i][2] + "", dt3.Rows[i][3] + "", dt3.Rows[i][4] + "", dt3.Rows[i][5] + "", dt3.Rows[i][6] + "", dt3.Rows[i][7] + "", dt3.Rows[i][8] + "", dt3.Rows[i][9] + "");
            }

            // dgv_inv.DataSource = dt;
            calc_all();


        }
        private void calc_all()
        {
            decimal credit = 0;
            credit =Convert.ToDecimal(db.GetData("select isnull(SUM(depit),0) from entry where attachno='" + v.shift_no + "' and attachnamebook ='POS credit' ").Rows[0][0].ToString()) ;
            decimal tot =0;
          
            lbl_gift.Text = db.GetData("select isnull(SUM(incloud_taxes),0) from pos_dt where state='sal' and shift_no='" + v.shift_no + "' --and onRoll='2' ").Rows[0][0].ToString();

            try
            {
                for (int i = 0; i < dgv_inv.Rows.Count; i++)
                {
                    tot += Convert.ToDecimal(dgv_inv.Rows[i].Cells["tot"].Value);
                }
                lbl_sum.Text = Math.Round(tot- credit, 2) + "";
                lbl_tot.Text = (Convert.ToDecimal(Math.Round(tot, 2))-Convert.ToDecimal(lbl_discount.Text)+Convert.ToDecimal(lbl_opening.Text)- Convert.ToDecimal(lbl_expenses.Text)) +"";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                db.log_error(string.Concat(ex));
            }
        }

        private void dgv_inv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv_inv, "no");
        }

       
    }
}