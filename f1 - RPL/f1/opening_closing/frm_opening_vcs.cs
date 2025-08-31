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
    public partial class frm_opening_vcs : DevExpress.XtraEditors.XtraForm
    {
        public frm_opening_vcs()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon("f1.exe");
            db.Open();
        }
        //function-----------------------------------------------------------
        private void add_dgv_in(DataGridView dgv_ , System.Windows.Forms.ComboBox combo_)
        {
            for (int i = 0; i < dgv_.Rows.Count; i++)
            {
                if (combo_.Text == dgv_.Rows[i].Cells[2].Value.ToString())
                {
                    MessageBox.Show("douple");
                    return;
                }
            }
            dgv_.Rows.Add(null, lbl_code.Text, lbl_name.Text, 0, 0, lbl_type_acc.Text, lbl_sort.Text, lbl_rootlevel_name.Text, lbl_rootlevel.Text);
        
        }
        public void calc()
        {
            try
            {
                double depit = 0;
                double ceridt = 0;
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    depit += Convert.ToDouble(dgv.Rows[i].Cells["depit1"].Value);
                    ceridt += (Convert.ToDouble(dgv.Rows[i].Cells["credit1"].Value));

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
        public void calc_2()
        {
            try
            {
                double depit = 0;
                double ceridt = 0;
                for (int i = 0; i < dgv2.Rows.Count; i++)
                {
                    depit += Convert.ToDouble(dgv2.Rows[i].Cells["depit2"].Value);
                    ceridt += (Convert.ToDouble(dgv2.Rows[i].Cells["credit2"].Value));

                    lbl_depit2.Text = depit + "";
                    lbl_credit2.Text = ceridt + "";
                    lbl_def2.Text = (depit - ceridt).ToString();
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void save()
        {
            //inser into entry
            

                for (int i = 0; i < dgv.Rows.Count; i++)//customer
                {

                    db.Run("insert into entry([code_entry],acc_num,acc_name,rootlevel,type_acc,sort,depit,credit,name_book,code_book,dates,rootlevel_name,attachtext)values('-1','" + dgv.Rows[i].Cells["acc_num"].Value + "','" + dgv.Rows[i].Cells["acc_name"].Value + "','" + dgv.Rows[i].Cells["rootlevel"].Value + "','" + dgv.Rows[i].Cells["type_acc"].Value + "','" + dgv.Rows[i].Cells["sort"].Value + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["depit1"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["credit1"].Value) + ",'opening customer','opening customer','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + dgv.Rows[i].Cells["rootlevel_name"].Value + "','opening customer')");
                }
                for (int i = 0; i < dgv2.Rows.Count; i++)//vendor
                {

                    db.Run("insert into entry([code_entry],acc_num,acc_name,rootlevel,type_acc,sort,depit,credit,name_book,code_book,dates,rootlevel_name,attachtext)values('-2','" + dgv2.Rows[i].Cells["acc_num2"].Value + "','" + dgv2.Rows[i].Cells["acc_name2"].Value + "','" + dgv2.Rows[i].Cells["rootlevel2"].Value + "','" + dgv2.Rows[i].Cells["type_acc2"].Value + "','" + dgv2.Rows[i].Cells["sort2"].Value + "'," + Convert.ToDecimal(dgv2.Rows[i].Cells["depit2"].Value) + "," + Convert.ToDecimal(dgv2.Rows[i].Cells["credit2"].Value) + ",'opening vendor','opening vendor','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + dgv2.Rows[i].Cells["rootlevel_name2"].Value + "','opening vendor')");
                }
                db.Run("update info_co set open_vcs='True'");

                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "saving ", "save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (Convert.ToDouble(lbl_def.Text) == 0 && Convert.ToDouble(lbl_def2.Text) == 0)
                {
                
            }
            else
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, " المدين لايساوي الدائن ولاكن يمكن الحفظ موقت و التعديل من شاشه القيد الافتتاحي ", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
            }

        }
        //-------------------

        private void combo_add_items_SelectedIndexChanged(object sender, EventArgs e)
        {
                lbl_code.Text = db.GetData("select vcs_code from vcs where vcs_name='" + combo_add_items.Text + "'").Rows[0][0].ToString();
            lbl_name.Text = db.GetData("select vcs_name from vcs where vcs_name='" + combo_add_items.Text + "'").Rows[0][0].ToString();
            lbl_rootlevel.Text = db.GetData("select rootlevel from vcs where vcs_name='" + combo_add_items.Text + "'").Rows[0][0].ToString();
            lbl_sort.Text = "2";
            lbl_type_acc.Text = db.GetData("select sort from vcs where vcs_name='" + combo_add_items.Text + "'").Rows[0][0].ToString();
            lbl_rootlevel_name.Text = db.GetData("select rootlevel_name from vcs where vcs_name='" + combo_add_items.Text + "'").Rows[0][0].ToString();
            
        }
        private void comob_add_items_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_code.Text = db.GetData("select vcs_code from vcs where vcs_name='" + combo_add_items_2.Text + "'").Rows[0][0].ToString();
            lbl_name.Text = db.GetData("select vcs_name from vcs where vcs_name='" + combo_add_items_2.Text + "'").Rows[0][0].ToString();
            lbl_rootlevel.Text = db.GetData("select rootlevel from vcs where vcs_name='" + combo_add_items_2.Text + "'").Rows[0][0].ToString();
            lbl_sort.Text = "2";
            lbl_type_acc.Text = db.GetData("select sort from vcs where vcs_name='" + combo_add_items_2.Text + "'").Rows[0][0].ToString();
            lbl_rootlevel_name.Text = db.GetData("select rootlevel_name from vcs where vcs_name='" + combo_add_items_2.Text + "'").Rows[0][0].ToString();
            
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            add_dgv_in(dgv,combo_add_items);
        }
        private void add_btn2_Click(object sender, EventArgs e)
        {
            add_dgv_in(dgv2, combo_add_items_2);

        }
        private void combo_add_items_Click(object sender, EventArgs e)
        {
            if (combo_add_items.Text=="")
            {
                
               all_comb.load_customer_only_name(combo_add_items);
            }
        }
        private void combo_add_items_2_Click(object sender, EventArgs e)
        {
            if (combo_add_items_2.Text == "")
            {
                all_comb.load_vendor_only_name(combo_add_items_2);
            }
        }
        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            calc();
        }
        private void dgv2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            calc_2();
        }
        //hotkeys---------------------------------------------
        private void combo_add_items_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Enter)
            {
                add_dgv_in(dgv, combo_add_items);
               
            }
        }
        private void combo_add_items_2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                add_dgv_in(dgv2, combo_add_items_2);
            }
        }
        private void btn_add_all_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("select vcs_code, vcs_name from vcs where mode='customer'", dt);
            dgv.DataSource = dt;

        }
        private void xtraTabPage2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }

        private void save_barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            save();
        }

        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv);
        }

        private void dgv2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv2,"no_v");

        }

        private void dgv_exp_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv_exp,"no_exp");

        }

        private void frm_opening_vcs_Load(object sender, EventArgs e)
        {
            dt_piker.Text = DateTime.Now.ToString("yyyy/MM/dd");
        }

       
        

        

       

       
      

    }
}