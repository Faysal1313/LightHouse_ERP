using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace f1.opening_closing
{
    public partial class frm_opening_entry : DevExpress.XtraEditors.XtraForm
    {
        public frm_opening_entry()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon("f1.exe");
            db.Open();
        }
       
        //-----------porperty
        bool customer_b = false;
        bool vendor_b = false;


        //-----------------------Function
        private void select_combo_acount_vcs(string txt)
        {
            lbl_code.Text = db.GetData("select vcs_code from vcs where vcs_name='" + txt + "'").Rows[0][0].ToString();
            lbl_name.Text = db.GetData("select vcs_name from vcs where vcs_name='" + txt + "'").Rows[0][0].ToString();
            lbl_rootlevel.Text = db.GetData("select rootlevel from vcs where vcs_name='" + txt + "'").Rows[0][0].ToString();
            lbl_sort.Text = "2";
            lbl_type_acc.Text = db.GetData("select sort from vcs where vcs_name='" + txt + "'").Rows[0][0].ToString();
            lbl_rootlevel_name.Text = db.GetData("select rootlevel_name from vcs where vcs_name='" + txt + "'").Rows[0][0].ToString();
            
        }
        private void add_dgv_in(DataGridView dgv_)
        {
            //for (int i = 0; i < dgv_.Rows.Count; i++)
            //{
            //    if (combo_.Text == dgv_.Rows[i].Cells[2].Value.ToString())
            //    {
            //        MessageBox.Show("douple");
            //        return;
            //    }
            //}
            dgv_.Rows.Add(null, lbl_code.Text, lbl_name.Text, 0, 0, lbl_type_acc.Text, lbl_sort.Text, lbl_rootlevel_name.Text, lbl_rootlevel.Text);

        }
        private void add_dgv_bond(DataGridView dgv_)
        {
            try
            {
               
            {
                DataTable dataTable = (DataTable)dgv_.DataSource;
            DataRow drToAdd = dataTable.NewRow();
            drToAdd[0] = null;
            drToAdd["acc_num"] = lbl_code.Text;
            drToAdd["acc_name"] = lbl_name.Text;
            drToAdd["depit"] = "0";
            drToAdd["credit"] = "0";
            drToAdd["type_acc"] = lbl_type_acc.Text;
            drToAdd["sort"] = lbl_sort.Text;
            drToAdd["rootlevel"] = lbl_rootlevel.Text;
            drToAdd["rootlevel_name"] = lbl_rootlevel_name.Text;

            dataTable.Rows.Add(drToAdd);
            dataTable.AcceptChanges();
        
            }
            }
            catch (Exception)
            {

                MessageBox.Show("اضغط علي احضر الاول");
            }
            
        }


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
                    lbl_def_g.Text = (depit - ceridt).ToString();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void calc_customer()
        {

            try
            {
                double depit = 0;
                double ceridt = 0;
                for (int i = 0; i < dgv_customer.Rows.Count; i++)
                {
                    depit += Convert.ToDouble(dgv_customer.Rows[i].Cells["depit_c"].Value);
                    ceridt += (Convert.ToDouble(dgv_customer.Rows[i].Cells["credit_c"].Value));

                    lbl_depit_c.Text = depit + "";
                    lbl_credit_c.Text = ceridt + "";
                    lbl_def_c.Text = (depit - ceridt).ToString();
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void calc_vendor()
        {

            try
            {
                double depit = 0;
                double ceridt = 0;
                for (int i = 0; i < dgv_vendor.Rows.Count; i++)
                {
                    depit += Convert.ToDouble(dgv_vendor.Rows[i].Cells["depit_v"].Value);
                    ceridt += (Convert.ToDouble(dgv_vendor.Rows[i].Cells["credit_v"].Value));

                    lbl_depit_v.Text = depit + "";
                    lbl_credit_v.Text = ceridt + "";
                    lbl_def_v.Text = (depit - ceridt).ToString();
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void calc_finaly()
        {

            try
            {
                double depit = 0;
                double ceridt = 0;
                for (int i = 0; i < dgv_finaly.Rows.Count; i++)
                {
                    dgv_finaly.Rows[i].Cells["opening_bal"].Value = Convert.ToDecimal(dgv_finaly.Rows[i].Cells["depit_f"].Value) - Convert.ToDecimal(dgv_finaly.Rows[i].Cells["credit_f"].Value);
                    depit += Convert.ToDouble(dgv_finaly.Rows[i].Cells["depit_f"].Value);
                    ceridt += (Convert.ToDouble(dgv_finaly.Rows[i].Cells["credit_f"].Value));

                    lbl_depit_f.Text = depit + "";
                    lbl_credit_f.Text = ceridt + "";
                    lbl_def_f.Text = (depit - ceridt).ToString();
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        
        
        //----------------------------------------------------------
        //dgv_controls

        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)//calc 
        {
            calc_gl();
        }
        private void dgv_customer_CellEndEdit(object sender, DataGridViewCellEventArgs e)//calc
        {
            calc_customer();
        }
        private void dgv_vendor_CellEndEdit(object sender, DataGridViewCellEventArgs e)//calc
        {
            calc_vendor();
        }
        private void dgv_finaly_CellEndEdit(object sender, DataGridViewCellEventArgs e)//calc
        {
            calc_finaly();
        }

        //-----------------------------------------------------

        //combo box controls
        private void combo_add_account_1_Click(object sender, EventArgs e)//get all account type c 
        {
            all_comb.load_account_name_c(combo_add_account_1);
        }
        private void combo_add_vcs_customer_Click(object sender, EventArgs e)//get all account customer
        {
            all_comb.load_customer_only_name(combo_add_vcs_customer);
        }
        private void combo_add_vcs_vendor_Click(object sender, EventArgs e)//get all account vendor
        {
            all_comb.load_vendor_only_name(combo_add_vcs_vendor);
        }
        private void combo_add_account_1_SelectedIndexChanged(object sender, EventArgs e)//select account gl
        {
            lbl_code.Text = db.GetData("select rootid from tree where rootname='" + combo_add_account_1.Text + "'").Rows[0][0].ToString();
            lbl_name.Text = db.GetData("select rootname from tree where rootname='" + combo_add_account_1.Text + "'").Rows[0][0].ToString();
            lbl_rootlevel.Text = db.GetData("select rootlevel from tree where rootname='" + combo_add_account_1.Text + "'").Rows[0][0].ToString();
            lbl_sort.Text = "1";
            lbl_type_acc.Text = db.GetData("select sort from tree where rootname='" + combo_add_account_1.Text + "'").Rows[0][0].ToString();
            lbl_rootlevel_name.Text = "0";
        }
        private void combo_add_vcs_customer_SelectedIndexChanged(object sender, EventArgs e)//select account customer
        {
            select_combo_acount_vcs(combo_add_vcs_customer.Text);
        }
        private void combo_add_vcs_vendor_SelectedIndexChanged(object sender, EventArgs e)//select account vendor
        {
            select_combo_acount_vcs(combo_add_vcs_vendor.Text);
        }
        private void btn_add_account1_Click(object sender, EventArgs e)
        {
            add_dgv_in(dgv);
        }
        private void combo_add_account_1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                 add_dgv_in(dgv);
            }
        }
        private void add_btn_customer_Click(object sender, EventArgs e)
        {
            add_dgv_bond(dgv_customer);
        }
        private void combo_add_vcs_customer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                add_dgv_bond(dgv_customer);
                
            }
        }
        private void add_btn_vendor_Click(object sender, EventArgs e)
        {
            add_dgv_bond(dgv_vendor);
        }
        private void combo_add_vcs_vendor_KeyDown(object sender, KeyEventArgs e) 
        {
            if (e.KeyCode == Keys.Enter)
            {
                add_dgv_bond(dgv_vendor);
            }
        }

       

       
        //----------------------------------------------------

        //simple controls

        private void btn_refresh_customer_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("SELECT   acc_num, acc_name, depit, credit, rootlevel, rootlevel_name, type_acc, sort   FROM    entry WHERE     (code_entry = '-1')",dt);
            dgv_customer.DataSource = dt;
            customer_b = true;
        }

        private void btn_refrsh_vendor_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("SELECT   acc_num, acc_name, depit, credit, rootlevel, rootlevel_name, type_acc, sort FROM         entry WHERE     (code_entry = '-2')", dt);
            dgv_vendor.DataSource = dt;
            vendor_b = true;
        }

        private void btn_refrsh_inventory_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("SELECT   acc_num, acc_name, depit, credit, rootlevel, rootlevel_name, type_acc, sort FROM         entry WHERE     (code_entry = '-3')", dt);
            dgv_inventory.DataSource = dt;
        }

        private void btn_collect_all_entry_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count >0)
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    dgv_finaly.Rows.Add(0, dgv.Rows[i].Cells["acc_num_g"].Value, dgv.Rows[i].Cells["acc_name_g"].Value, dgv.Rows[i].Cells["depit_g"].Value, dgv.Rows[i].Cells["credit_g"].Value, dgv.Rows[i].Cells["type_acc_g"].Value, dgv.Rows[i].Cells["sort_g"].Value, dgv.Rows[i].Cells["rootlevel_name_g"].Value, dgv.Rows[i].Cells["rootlevel_g"].Value);
                }
            
            }
            if (dgv_customer.Rows.Count >0)
            {
                for (int i = 0; i < dgv_customer.Rows.Count; i++)
                {
                    dgv_finaly.Rows.Add(0, dgv_customer.Rows[i].Cells["acc_num_c"].Value, dgv_customer.Rows[i].Cells["acc_name_c"].Value, dgv_customer.Rows[i].Cells["depit_c"].Value, dgv_customer.Rows[i].Cells["credit_c"].Value, dgv_customer.Rows[i].Cells["type_acc_c"].Value, dgv_customer.Rows[i].Cells["sort_c"].Value, dgv_customer.Rows[i].Cells["rootlevel_name_c"].Value, dgv_customer.Rows[i].Cells["rootlevel_c"].Value);
                }
            }
            if (dgv_vendor.Rows.Count > 0)
            {
                for (int i = 0; i < dgv_vendor.Rows.Count; i++)
                {
                    dgv_finaly.Rows.Add(0, dgv_vendor.Rows[i].Cells["acc_num_v"].Value, dgv_vendor.Rows[i].Cells["acc_name_v"].Value, dgv_vendor.Rows[i].Cells["depit_v"].Value, dgv_vendor.Rows[i].Cells["credit_v"].Value, dgv_vendor.Rows[i].Cells["type_acc_v"].Value, dgv_vendor.Rows[i].Cells["sort_v"].Value, dgv_vendor.Rows[i].Cells["rootlevel_name_v"].Value, dgv_vendor.Rows[i].Cells["rootlevel_v"].Value);
                }
            }
            if (dgv_inventory.Rows.Count > 0)
            {
                for (int i = 0; i < dgv_inventory.Rows.Count; i++)
                {
                    dgv_finaly.Rows.Add(0, dgv_inventory.Rows[i].Cells["acc_num_i"].Value, dgv_inventory.Rows[i].Cells["acc_name_i"].Value, dgv_inventory.Rows[i].Cells["depit_i"].Value, dgv_inventory.Rows[i].Cells["credit_i"].Value, dgv_inventory.Rows[i].Cells["type_acc_i"].Value, dgv_inventory.Rows[i].Cells["sort_i"].Value, dgv_inventory.Rows[i].Cells["rootlevel_name_i"].Value, dgv_inventory.Rows[i].Cells["rootlevel_i"].Value);
                }
            }
            calc_finaly();
        }

        private void save_barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dgv_finaly.Rows.Count < 0)
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "لاتوجد قيود محاسبيه ", "warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Convert.ToDouble(lbl_def_f.Text)!=0)
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "القيد غير متزن ", "warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string conferm_openig_entry_is_existing = db.GetData("select ISnull((count(code_entry)),0) from entry where code_entry='-9'").Rows[0][0].ToString();
            if (Convert.ToDouble(conferm_openig_entry_is_existing) != 0)
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "القيد الافتتاحي موجود من قبل من فضلك امسح القيد الافتتاحي ", "warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            for (int i = 0; i < dgv_finaly.Rows.Count; i++)
            {
                db.Run("insert into entry([code_entry],acc_num,acc_name,rootlevel,type_acc,sort,depit,credit,name_book,code_book,dates,rootlevel_name,attachtext,opening_bal)values('-9','" + dgv_finaly.Rows[i].Cells["acc_num_f"].Value + "','" + dgv_finaly.Rows[i].Cells["acc_name_f"].Value + "','" + dgv_finaly.Rows[i].Cells["rootlevel_f"].Value + "','" + dgv_finaly.Rows[i].Cells["type_acc_f"].Value + "','" + dgv_finaly.Rows[i].Cells["sort_f"].Value + "'," + Convert.ToDecimal(dgv_finaly.Rows[i].Cells["depit_f"].Value) + "," + Convert.ToDecimal(dgv_finaly.Rows[i].Cells["credit_f"].Value) + ",'opening Entry','opening Entry','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + dgv_finaly.Rows[i].Cells["rootlevel_name_f"].Value + "','opening Entry','" + dgv_finaly.Rows[i].Cells["opening_bal"].Value + "')");
            }
            db.Run("delete from entry where code_entry='-3'");
            db.Run("delete from entry where code_entry='-2'");
            db.Run("delete from entry where code_entry='-1'");

            string er = db.GetData("select SUM (depit) ,sum(credit) ,isnull((SUM(depit-credit)),0) from entry where code_entry='-3' or code_entry='-2' or code_entry='-1'").Rows[0][2].ToString();
         if (Convert.ToDecimal(er)!=0)
         {
             XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "القيد غير متزن داخل القاعده من فضلك اعد القيد الافتتاحي مره اخره  " + "\n  قيمه الفرق  " + er, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
             v.opening_error = true;
             db.Run("update info_co set entry_error= 'True' ");
             return;
         }
         else
         {
             XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "تم الحفظ لا توجد مشكله   " + "\n  قيمه الفرق  " + er, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

         }
        }

        private void button1_Click(object sender, EventArgs e)
        {
                if (dgv_finaly.Rows.Count > 0)
            {
                MessageBox.Show("Test");
            }
        }

        private void frm_opening_entry_Load(object sender, EventArgs e)
        {
            dt_piker.Text = DateTime.Now.ToString("yyyy/MM/dd");
        }

        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv);
        }

        private void dgv_customer_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv_customer,"no_c");

        }

        private void dgv_vendor_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv_vendor,"no_v");

        }

        private void dgv_inventory_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv_inventory,"no_i");
        }

        private void dgv_finaly_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv_finaly,"no_f");
        }
        //---------------------------------------------------
        //hotkeys
        //----------------------------------------------
















        //==========================
    }
}