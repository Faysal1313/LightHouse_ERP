using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports;

namespace f1
{
    public partial class frm_entry : DevExpress.XtraEditors.XtraForm
    {
        public frm_entry()
        {
            InitializeComponent();
            this.add_permission = true;
            this.edit_permission = true;
            this.edit = false;
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
           
        }
        private void load_permission()
        {
           
            this.save_barButtonItem1.Enabled = Convert.ToBoolean(db.GetData("select [add_only] from permission_sub where user_code='" + v.usercode + "' and name_frm ='entry' ").Rows[0][0].ToString());
            this.btn_delete_file.Enabled = Convert.ToBoolean(db.GetData("select [delete] from permission_sub where user_code='" + v.usercode + "' and name_frm ='entry' ").Rows[0][0].ToString());
            this.add_permission = Convert.ToBoolean(db.GetData("select [add_only] from permission_sub where user_code='" + v.usercode + "' and name_frm ='entry' ").Rows[0][0].ToString());
            if (this.add_permission)
                this.save_barButtonItem1.Enabled = true;
            this.edit_permission = Convert.ToBoolean(db.GetData("select [edit_only] from permission_sub where user_code='" + v.usercode + "' and name_frm ='entry' ").Rows[0][0].ToString());
            this.printer_previeew_barButtonItem10.Enabled = Convert.ToBoolean(db.GetData("select [print] from permission_sub where user_code='" + v.usercode + "' and name_frm ='entry' ").Rows[0][0].ToString());
            this.printer_direct_barButtonItem11.Enabled = Convert.ToBoolean(db.GetData("select [print] from permission_sub where user_code='" + v.usercode + "' and name_frm ='entry' ").Rows[0][0].ToString());
        }
        private void frm_entry_Load(object sender, EventArgs e)
        {
            db.Open();
            all_comb.load_account_name_c(this.combo_add_account);
            this.combo_add_account.Text = "";
            //this.dt_piker.MinDate = new DateTime(v.current_yaer, 1, 1);
            //this.dt_piker.MaxDate = new DateTime(v.current_yaer, 12, 31);
            //this.dt_piker.Text = DateTime.Now.ToString(v.current_yaer + "/MM/dd");
            //this.dt_search.Text = DateTime.Now.ToString(v.current_yaer + "/MM/dd");
            //this.dt_piker.Text = DateTime.Now.ToString(v.current_yaer + "/MM/dd");

            this.dt_piker.Text  = DateTime.Now.ToString("yyyy/MM/dd");
            this.dt_piker.Text = DateTime.Now.ToString("yyyy/MM/dd");
            this.dt_piker.Text = DateTime.Now.ToString( "yyyy/MM/dd");
         //   this.dt_search.Text = DateTime.Now.ToString( "yyyy/MM/dd");
            this.dt_piker.Text = DateTime.Now.ToString( "yyyy/MM/dd");


            cls_book.loadbook(this.comb_code, "سند قيد");
           // cls_book.loadbook(this.combo_name_searsh, "سند قيد");
           // this.groupControl5.Visible = false;
            all_comb.load_curracne(this.combo_currance);
            all_comb.cost_center_name(this.combo_costcenter);
            this.load_permission();
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        //===========function and vriable
        private bool add_permission;
        private bool edit_permission;
        private bool edit;
        private string numBook_entry,error;
        private int num;
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
                   

                    //lbl_depit.Text=string.Format("{0:C2}", depit.ToString());
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public void add_account()
        {
            if (combo_add_account.Text!="" ||lbl_code.Text !="" || lbl_name.Text!="" || lbl_type_acc.Text !=""|| lbl_sort.Text !="" || lbl_rootlevel.Text !="")
            {
                if (rd_gl.Checked)
                {
                    all_comb.load_account_name_c(combo_add_account);
                }
                else if (rdvendor.Checked)
                {
                    all_comb.load_vendor_only_name(combo_add_account);
                }
                else if (rdcustomer.Checked)
                {
                    all_comb.load_customer_only_name(combo_add_account);
                }
            
                
            }
        }
        public void save()
        {
            txt_code_book.Text = db.GetData("select code_book from book where name_book='" + comb_code.Text + "'").Rows[0][0].ToString();
          //  string code_entry_term = (db.GetData("select code_entry from term where term_id='" + combo_type.Text + "' ").Rows[0][0].ToString());
            cls_book.Generat_numBooknum("entry", txt_code_book.Text, ref numBook_entry, ref error, ref num);
            txt_serial_string.Text = numBook_entry;

            //insert into entry_hd
            db.Run("insert into entry_hd ([code_entry],code_book) values ('"+txt_serial_string.Text+"','"+txt_code_book.Text+"')");

            //inser into entry
        if (Convert.ToDouble(lbl_def.Text.ToString()) == 0)
              {

                  for (int i = 0; i < dgv.Rows.Count; i++)
                  {

                    //  db.Run("insert into entry([code_entry],acc_num,acc_name,rootlevel,type_acc,sort,depit,credit,name_book,code_book,dates,rootlevel_name,txt_desc,depit_cur, credit_cur, currance, f_currance,costcenter_code,num_book)values('" + txt_serial_string.Text + "','" + dgv.Rows[i].Cells["acc_num"].Value + "','" + dgv.Rows[i].Cells["acc_name"].Value + "','" + dgv.Rows[i].Cells["rootlevel"].Value + "','" + dgv.Rows[i].Cells["type_acc"].Value + "','" + dgv.Rows[i].Cells["sort"].Value + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["depit"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["credit"].Value) + ",'" + comb_code.Text + "','" + txt_code_book.Text + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + dgv.Rows[i].Cells["rootlevel_name"].Value + "','" + txt_note.Text + "','" + dgv.Rows[i].Cells["depit_cur"].Value + "','" + dgv.Rows[i].Cells["credit_cur"].Value + "','" + dgv.Rows[i].Cells["currance_c"].Value + "','" + dgv.Rows[i].Cells["f_currance"].Value + "','" + dgv.Rows[i].Cells["costcenter"].Value + "','"+num+"')");
                    db.Run("insert into entry([code_entry],acc_num,acc_name,depit,credit,rootlevel,rootlevel_name,type_acc,sort,currance,f_currance,depit_cur, credit_cur,costcenter_code,name_book,code_book,dates,txt_desc,num_book)values('" + txt_serial_string.Text + "','" + dgv.Rows[i].Cells["acc_num"].Value + "','" + dgv.Rows[i].Cells["acc_name"].Value + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["depit"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["credit"].Value) + ",'" + dgv.Rows[i].Cells["rootlevel"].Value + "','" + dgv.Rows[i].Cells["rootlevel_name"].Value + "','" + dgv.Rows[i].Cells["type_acc"].Value + "','" + dgv.Rows[i].Cells["sort"].Value + "','" + dgv.Rows[i].Cells["currance_c"].Value + "','" + dgv.Rows[i].Cells["f_currance"].Value + "','" + dgv.Rows[i].Cells["depit_cur"].Value + "','" + dgv.Rows[i].Cells["credit_cur"].Value + "','" + dgv.Rows[i].Cells["costcenter"].Value + "','" + comb_code.Text + "','" + txt_code_book.Text + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + txt_note.Text + "','" + num + "')");

                }
                // MessageBox.Show("save");


            }
              else
              {
                  MessageBox.Show("المدين لا يساوي الدائن");
                  return;
              }
          }
        public void update()
        {
         //   int old_code_entry = 0;
          //  string old_code_book = "";
           // old_code_entry = Convert.ToInt32(txt_serial.Text);
           // old_code_book = txt_code_book.Text;
            db.Run("delete from entry_hd where code_entry='" + txt_serial_string.Text + "' and code_book='" + txt_code_book.Text + "' ");
            db.Run("delete from entry where code_entry='" + txt_serial_string.Text + "' and code_book='"+txt_code_book.Text+"' ");

            //delete from pay_hd and pay_dt
            db.Run("delete from pay_hd where pay_hd_id ='"+txt_serial_string.Text+"'");
            db.Run("delete from pay_dt where code_entry ='" + txt_serial_string.Text + "'");

            save();

        }
        private void perform_save_update()
        {
            if (!this.add_permission && !Convert.ToBoolean(db.GetData("select [add_only] from permission_sub where user_code='" + v.usercode + "' and name_frm ='entry' ").Rows[0][0].ToString()))
            {
                this.save_barButtonItem1.Enabled = true;
            }
            else
            {
                this.load_permission();
                if (db.GetData("select isnull(max(attachno),0) from entry where code_entry='" + this.txt_serial_string.Text + "' ").Rows[0][0].ToString() != "0")
                {
                   MessageBox.Show("لايمكن التعديل علي مستندات اصدرها النظام");
                    return;
                }
                if (Convert.ToDouble(lbl_def.Text) != 0)
                {
                    MessageBox.Show("المدين لا يساوي الدائن");
                    return;
                }
                else if (!this.edit)
                {
                    if (this.add_permission)
                    {
                        //ifcost center 0 or 1 or 2
                        for (int i = 0; i < dgv.Rows.Count; i++)
                        {
                            string rootid = dgv.Rows[i].Cells[1].Value + "";
                            string costcenter = db.GetData("select isnull(max(costcenter),'0')  from tree where rootid='" + rootid + "'").Rows[0][0] + "";
                            if (dgv.Rows[i].Cells["costcenter"].Value + "" == "") dgv.Rows[i].Cells["costcenter"].Value = "0";
                            if (costcenter == "1" && dgv.Rows[i].Cells["costcenter"].Value.ToString() == "0")
                            {
                                MessageBox.Show(rootid + "يجب اختيار مركز تكلفة");
                                return;
                            }
                            if (costcenter == "2" && dgv.Rows[i].Cells["costcenter"].Value.ToString() == "0")
                            {
                                MessageBox.Show(rootid + "غير مسموح مركز تكلفة ");
                                return;
                            }
                        }


                        this.save();
                    XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "saving ", "save", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                 MessageBox.Show("لايوجد صلاحية لاضافة   تعدل فقط ");
                        return;

                    }
                }
                else if (this.edit_permission)
                {
                    if (this.edit)
                    {
                        //ifcost center 0 or 1 or 2
                        for (int i = 0; i < dgv.Rows.Count; i++)
                        {
                            string rootid = dgv.Rows[i].Cells[1].Value + "";
                            string costcenter = db.GetData("select isnull(max(costcenter),'0') from tree where rootid='" + rootid + "'").Rows[0][0] + "";
                            if (costcenter == "1")
                            {
                                MessageBox.Show(rootid + "يجب اختيار مركز تكلفة");
                                return;
                            }
                        }


                        this.update();
                     XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "updating ", "update", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    this.edit = true;
                }
                else
                {
                    int num4 = (int)MessageBox.Show("لا توجد صلاحيات للتعديل ");
                    return;

                }
            }
        }
        private void delete()
        {
            if (db.GetData("select isnull(max(attachno),0) from entry where code_entry='" + this.txt_serial_string.Text + "' ").Rows[0][0].ToString() != "0")
            {
                MessageBox.Show("لايمكن التعديل علي مستندات اصدرها النظام");
                return;
            }
            Classes.command.perform_delete(txt_serial_string.Text, "delete from entry where code_entry='" + txt_serial_string.Text + "' and code_book='" + txt_code_book.Text+ "'");
            Classes.command.perform_delete(txt_serial_string.Text, "delete from entry_hd where code_entry='" + txt_serial_string.Text + "' and code_book='" + txt_code_book.Text + "'");
            db.action_delete("تم حذف سند القيد برقم" + txt_serial_string.Text+ "  بمبلغ "+lbl_depit.Text + "", txt_serial_string.Text);
            frm_entry frm = new frm_entry();
            this.Close();
            frm.Show();
        }
        private void load_code_book(System.Windows.Forms.ComboBox combo )
        {
            //DataTable dt = new DataTable();
            //db.GetData_DGV("select distinct code_book from entry isnotnull where name_book ='"+combo_name_searsh.Text+"' ", dt);
            //combo.DisplayMember = "code_book";
            //combo.DataSource = dt;
        }
        private void load_code_entry(System.Windows.Forms.ComboBox combo)
        {
            //DataTable dt = new DataTable();
            //db.GetData_DGV("select distinct code_entry from entry isnotnull where code_book ='" + combo_code_book_search.Text + "' ", dt);
            //combo.DisplayMember = "code_entry";
            //combo.DataSource = dt;
        }
        private void add_account_in_dgv()
        {

          
            dgv.Rows.Add(null, lbl_code.Text, lbl_name.Text, 0, 0, lbl_type_acc.Text, lbl_sort.Text, lbl_rootlevel_name.Text, lbl_rootlevel.Text, lbl_currance_code.Text, lbl_currance_factor.Text, 0, 0, 0);

            //if (edit == false)
            //{
            //dgv.Rows.Add(null, lbl_code.Text, lbl_name.Text, 0, 0, lbl_type_acc.Text, lbl_sort.Text, lbl_rootlevel_name.Text, lbl_rootlevel.Text, lbl_currance_code.Text, lbl_currance_factor.Text, 0, 0, 0);
            
            //}
            //else if (edit == true)
            //{
            //    DataTable dataTable = (DataTable)dgv.DataSource;
            //    DataRow drToAdd = dataTable.NewRow();
            //    if (rd_gl.Checked == true)
            //    {
            //        drToAdd[0] = null;
            //        drToAdd["acc_num"] = lbl_code.Text;
            //        drToAdd["acc_name"] = lbl_name.Text;
            //        drToAdd["depit"] = "0";
            //        drToAdd["credit"] = "0";
            //        drToAdd["type_acc"] = lbl_type_acc.Text;
            //        drToAdd["sort"] = lbl_sort.Text;
            //        drToAdd["rootlevel"] = lbl_rootlevel.Text;
            //        drToAdd["rootlevel_name"] = lbl_rootlevel_name.Text;
            //        drToAdd["currance"] = lbl_currance_code.Text;
            //        drToAdd["f_currance"] = lbl_currance_factor.Text;
            //        drToAdd["depit_cur"] = 0;
            //        drToAdd["credit_cur"] = 0;
            //        drToAdd["costcenter_code"] = 0;
            //        dataTable.Rows.Add(drToAdd);
            //        dataTable.AcceptChanges();

            //    }
            //}
        }
        private void new_()
        {
            DialogResult dr;
            dr = MessageBox.Show("هل تريد سند جديد!!؟؟؟؟ ", "رسال جديد مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                frm_entry frm = new frm_entry();
                this.Close();
                frm.Show();
            }
        }
        //===========================contoals
        private void combo_add_items_Click(object sender, EventArgs e)
        {
            add_account();
        }
        private void btn_add_account_Click(object sender, EventArgs e)
        {
            add_account_in_dgv();
        }
        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

           // try
           // {
           //     if (frm_entry.ActiveForm.Location.X > 100)
           // {
           //     using (SolidBrush b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor))
           //     {
           //         e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 875, e.RowBounds.Location.Y + 0);
           //     }
           
           // }
           //else
           // {
           //     using (SolidBrush b = new SolidBrush(((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor))
           //     {
           //         e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 1320, e.RowBounds.Location.Y + 0);
           //     }
           
           // }
           // }
           // catch (Exception)
           // {
                
                
           // }
        }
        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv);
        }
        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //==========local currance 
                if (Convert.ToDouble(dgv.CurrentRow.Cells["depit"].Value) > 0)
                {
                    dgv.CurrentRow.Cells["credit"].Value = 0;
                }
                if (Convert.ToDouble(dgv.CurrentRow.Cells["credit"].Value) > 0)
                {
                    dgv.CurrentRow.Cells["depit"].Value = 0;
                }
                //=========forgent currance 
                if (Convert.ToDecimal(dgv.CurrentRow.Cells["f_currance"].Value) != 1)
                {
                    dgv.CurrentRow.Cells["credit"].Value = 0;
                    dgv.CurrentRow.Cells["depit"].Value = 0;
                }
                if (Convert.ToDecimal(dgv.CurrentRow.Cells["f_currance"].Value) == 1)
                {
                    dgv.CurrentRow.Cells["credit_cur"].Value = 0;
                    dgv.CurrentRow.Cells["depit_cur"].Value = 0;
                }
                if (Convert.ToDouble(dgv.CurrentRow.Cells["depit_cur"].Value) > 0)
                {
                    dgv.CurrentRow.Cells["credit_cur"].Value = 0;
                    dgv.CurrentRow.Cells["credit"].Value = (Convert.ToDecimal(dgv.CurrentRow.Cells["credit_cur"].Value) * Convert.ToDecimal(dgv.CurrentRow.Cells["f_currance"].Value));
                    dgv.CurrentRow.Cells["depit"].Value = (Convert.ToDecimal(dgv.CurrentRow.Cells["depit_cur"].Value) * Convert.ToDecimal(dgv.CurrentRow.Cells["f_currance"].Value));
                }
                if (Convert.ToDouble(dgv.CurrentRow.Cells["credit_cur"].Value) > 0)
                {
                    dgv.CurrentRow.Cells["depit_cur"].Value = 0;
                    dgv.CurrentRow.Cells["credit"].Value = (Convert.ToDecimal(dgv.CurrentRow.Cells["credit_cur"].Value) * Convert.ToDecimal(dgv.CurrentRow.Cells["f_currance"].Value));
                    dgv.CurrentRow.Cells["depit"].Value = (Convert.ToDecimal(dgv.CurrentRow.Cells["depit_cur"].Value) * Convert.ToDecimal(dgv.CurrentRow.Cells["f_currance"].Value));
                }
                calc();
            }
            catch (Exception ex)
            {
            }    
        }
        private void comb_code_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            //load next field from load book "3lsahn el moshklal bta3at el combobox 

            txt_code_book.Text = db.GetData("select code_book from book where name_book='" + comb_code.Text + "'").Rows[0][0].ToString();
            //  string code_entry_term = (db.GetData("select code_entry from term where term_id='" + combo_type.Text + "' ").Rows[0][0].ToString());
            cls_book.Generat_numBooknum("entry", txt_code_book.Text, ref numBook_entry, ref error, ref num);
            txt_serial_string.Text = numBook_entry;

          

        }
        private void combo_add_account_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rd_gl.Checked)
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
                else
                {
                    lbl_code.Text = db.GetData("select vcs_code from vcs where vcs_name='" + combo_add_account.Text + "'").Rows[0][0].ToString();
                    lbl_name.Text = db.GetData("select vcs_name from vcs where vcs_name='" + combo_add_account.Text + "'").Rows[0][0].ToString();
                    lbl_rootlevel.Text = db.GetData("select rootlevel from vcs where vcs_name='" + combo_add_account.Text + "'").Rows[0][0].ToString();
                    lbl_sort.Text = "2";
                    lbl_type_acc.Text = db.GetData("select sort from vcs where vcs_name='" + combo_add_account.Text + "'").Rows[0][0].ToString();
                    lbl_rootlevel_name.Text = db.GetData("select rootlevel_name from vcs where vcs_name='" + combo_add_account.Text + "'").Rows[0][0].ToString();

                    lbl_currance_code.Text = db.GetData("select currance from tree where rootname='" + combo_add_account.Text + "'").Rows[0][0].ToString();
                    lbl_currance_factor.Text = db.GetData("select isnull(max (f_currance),0) from currance where currance='" + lbl_currance_code.Text + "'").Rows[0][0].ToString();
                }
            }
            catch (Exception)
            {
                
                
            }
        }
        private void save_barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            perform_save_update();
        }
        private void delete_barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            delete();

        }
        //--------------------------------navigation
        //function
        private void get_dt(string num)//get data detals
        {
            DataTable dt_dt = new DataTable();
           // db.GetData_DGV("SELECT  [no],  code_items, name_items, name_unite, f_unite , exp, type, qty, item_price, tot_bef, discount, tot_after_dis, taxes, incloud_taxes,taxes_value, id_ware,sale_dt_id , 0 as add_items,qty as item_qty1 ,exp_date , exp_date as exp_date_1,tot_after_dis as tot_after_dis1 ,f_unite as f_unite_1  FROM   sale_dt where sale_hd_id='" + num + "' and code_book='" + book + "'", dt_dt);
            db.GetData_DGV("SELECT acc_num,acc_name, depit, credit, type_acc,sort,rootlevel_name,rootlevel,currance,f_currance,depit_cur,credit_cur,costcenter_code FROM [entry] where code_entry='" + num + "'", dt_dt);

            for (int i = 0; i < dt_dt.Rows.Count; i++)
            {
                dgv.Rows.Add("", dt_dt.Rows[i][0], dt_dt.Rows[i][1], dt_dt.Rows[i][2], dt_dt.Rows[i][3], dt_dt.Rows[i][4], dt_dt.Rows[i][5], dt_dt.Rows[i][6], dt_dt.Rows[i][7], dt_dt.Rows[i][8], dt_dt.Rows[i][9], dt_dt.Rows[i][10], dt_dt.Rows[i][11], dt_dt.Rows[i][12]);
            }


           // dgv.DataSource = dt_dt;
        }
        private void bode_of_navigation(string num, string book)
        {
            dgv.Rows.Clear();
                     this.edit = true;
            this.printer_direct_barButtonItem11.Enabled = true;
            this.printer_previeew_barButtonItem10.Enabled = true;
        
            this.get_dt(num);
            this.txt_code_book.Text = db.GetData("select code_book from entry where code_entry='" + num + "'").Rows[0][0].ToString();
            this.txt_serial_string.Text = db.GetData("select code_entry from entry where code_entry='" + num + "' ").Rows[0][0].ToString();
            this.txt_note.Text = db.GetData("select txt_desc from entry where code_entry='" + num + "' ").Rows[0][0].ToString();
            this.dt_piker.Text = db.GetData("select dates from entry where code_entry='" + num + "' ").Rows[0][0].ToString();
        
        }
        //controsl
        private void first_barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                if (!(db.GetData("select min(convert(int,(right(code_entry,LEN(code_entry)-3)))) from entry_hd where  code_book='" + this.txt_code_book.Text + "' ").Rows[0][0].ToString() != ""))
                    return;
                this.txt_serial_string.Text = db.GetData("select min(convert(int,(right(code_entry,LEN(code_entry)-3)))) from entry_hd where  code_book='" + this.txt_code_book.Text + "' ").Rows[0][0].ToString();
                this.bode_of_navigation(this.txt_code_book.Text + this.txt_serial_string.Text, this.txt_code_book.Text);

            }
            catch (Exception)
            {

                
            }

          
        }
        private void last_barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


            try
            {
                if (!(db.GetData("select max(convert(int,(right(code_entry,LEN(code_entry)-3)))) from entry_hd where  code_book='" + this.txt_code_book.Text + "' ").Rows[0][0].ToString() != ""))
                    return;
                this.txt_serial_string.Text = db.GetData("select max(convert(int,(right(code_entry,LEN(code_entry)-3)))) from entry_hd where  code_book='" + this.txt_code_book.Text + "'  ").Rows[0][0].ToString();
                this.bode_of_navigation(this.txt_code_book.Text + this.txt_serial_string.Text, this.txt_code_book.Text);
            }
            catch (Exception ex)
            {
                db.log_error(string.Concat((object)ex));
            }

        }
        private void back_barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!(db.GetData("select min(convert(int,(right(code_entry,LEN(code_entry)-3)))) from entry_hd where  code_book='" + this.txt_code_book.Text + "'").Rows[0][0].ToString() != ""))
                    return;
                new DataTable().Rows.Clear();
                string s1 = db.GetData("select min(convert(int,(right(code_entry,LEN(code_entry)-3)))) from entry_hd where  code_book='" + this.txt_code_book.Text + "'").Rows[0][0].ToString();
                int.Parse(s1);
                string s2 = this.txt_serial_string.Text.Remove(0, 1).Remove(0, 2);
                if (int.Parse(s1) >= Convert.ToInt32(s2))
                {
                    int num = (int)MessageBox.Show("اخر ملف");
                }
                else
                {
                    this.txt_serial_string.Text = this.txt_code_book.Text + (object)(int.Parse(s2) - 1);
                    this.bode_of_navigation(this.txt_serial_string.Text, this.txt_code_book.Text);
                }
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
                db.log_error(string.Concat((object)ex));
            }

        }
        private void next_barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (!(db.GetData("select max(convert(int,(right(code_entry,LEN(code_entry)-3)))) from entry_hd where  code_book='" + this.txt_code_book.Text + "'").Rows[0][0].ToString() != ""))
                    return;
                new DataTable().Rows.Clear();
                string s1 = db.GetData("select max(convert(int,(right(code_entry,LEN(code_entry)-3)))) from entry_hd where  code_book='" + this.txt_code_book.Text + "'").Rows[0][0].ToString();
                int.Parse(s1);
                string s2 = this.txt_serial_string.Text.Remove(0, 1).Remove(0, 2);
                if (int.Parse(s1) <= Convert.ToInt32(s2))
                {
                    int num = (int)MessageBox.Show("اول م ملف");
                }
                else
                {
                    this.txt_serial_string.Text = this.txt_code_book.Text + (object)(int.Parse(s2) + 1);
                    this.bode_of_navigation(this.txt_serial_string.Text, this.txt_code_book.Text);
                }
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
                db.log_error(string.Concat((object)ex));
            }

        }
        private void txt_serial_string_Leave(object sender, EventArgs e)
        {
            try
            {
                this.bode_of_navigation(this.txt_serial_string.Text, this.txt_code_book.Text);

            }
            catch (Exception)
            {

            }
        }
        private void combo_code_book_search_Click(object sender, EventArgs e)
        {
            
        }
        private void comb__code_entrysearsh_Click(object sender, EventArgs e)
        {
           
        }
        private void btn_searchin_group_Click(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            //db.GetData_DGV("select code_entry,code_book,name_book,dates,SUM(depit)as depit , SUM (credit) as credit  from entry where dates <='" + dt_search.Value.ToString("yyyy-MM-dd") + "'   and code_entry <> '-11' and code_entry <>'002' and code_entry <>'001' and code_entry <>'-7'  group by code_entry,code_book,name_book,dates ", dt);
            //dgv_search.DataSource = dt;
        }
        private void dgv_search_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //edit = true;
            ////DataTable dtl = new DataTable();
            //txt_serial_string.Text = dgv_search.CurrentRow.Cells["code_entry_c"].Value + ""; //db.GetData("select (code_entry)from entry where code_entry >0 and code_book='" + dgv_search.CurrentRow.Cells["code_book_c"].Value.ToString() + "' and code_entry='" + dgv_search.CurrentRow.Cells["code_entry_c"].Value.ToString() + "'").Rows[0][0].ToString();
            ////MessageBox.Show(dgv_search.CurrentRow.Cells["code_entry_c"].Value + "");
            //groupControl5.Visible = false;
            //txt_serial_string.Select();
            //combo_add_account.Select();
        }
        private void searsh_barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            v.search_screen = "entry";
            frm_search f = new frm_search();
            f.ShowDialog();
            timer1.Enabled = true;
        }
        private void close_shearch_simpleButton1_Click(object sender, EventArgs e)
        {
           
        }
        private void new_barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new_();
        }

        //------------------------------------End navigator-------------------------
        //---------------------------HOTKEYS------------------------
        private void combo_add_account_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                add_account_in_dgv();
            }
        }
        private void frm_entry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Control)
            {
                perform_save_update();
            }
            if (e.KeyCode == Keys.N && Control.ModifierKeys == Keys.Control)
            {
                new_();
            }
            if (e.KeyCode == Keys.Delete && Control.ModifierKeys == Keys.Control)
            {
                delete();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
        private void btn_currance_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count == 0) return;

            dgv.CurrentRow.Cells["currance_c"].Value = combo_currance.Text;
            lbl_f_currance.Text = db.GetData("select  isnull(max(f_currance),0) from  currance where currance='" + combo_currance.Text + "'").Rows[0][0].ToString();
            dgv.CurrentRow.Cells["f_currance"].Value = lbl_f_currance.Text;
        }
        private void btn_costcenter_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count == 0) return;
            dgv.CurrentRow.Cells["costcenter"].Value = combo_costcenter.Text;
            lbl_costcenter.Text = db.GetData("select  isnull(max(costcenter_id),0) from  costcenter where costcenter_name='" + combo_costcenter.Text + "'").Rows[0][0].ToString();
            dgv.CurrentRow.Cells["costcenter"].Value = lbl_costcenter.Text;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                lbl_acc_bal.Caption = db.GetData("select isnull(sum(depit)-sum(credit),0) from entry where acc_num='" + dgv.CurrentRow.Cells["acc_num"].Value + "" + "'").Rows[0][0] + "";
                //lbl_balance_items.Text = db.GetData("(select isnull(sum(qty),0)-(select isnull(sum(qty),0) from pos_dt p left join pos_shift s  on p.shift_no=s.shift_no   where s.lock= '1' and code_items='" + dgv.CurrentRow.Cells["code_items"].Value + "" + "') from wares where code_items='" + dgv.CurrentRow.Cells["code_items"].Value + "" + "')").Rows[0][0] + "";
                //lbl_cash_1.Text = db.GetData("select isnull(SUM(balance),0) from pos_cash where shift_no='" + lbl_shift_no.Caption + "'and code_cash='1' ").Rows[0][0] + "";

                //lbl_stat_cost_items_n.Text = db.GetData("select cost from wares where code_items='" + dgv.CurrentRow.Cells["code_items"].Value + "" + "' and id_ware='" + lbl_wares.Text + "'").Rows[0][0] + "";

                //lbl_stat_min_items_n.Text = db.GetData("select isnull(min (discount),0) from purchase_dt  where code_items ='" + this.dgv.CurrentRow.Cells["code_items"].Value + "" + "'").Rows[0][0] + "";
                //lbl_stat_max_items_n.Text = db.GetData("select isnull(max (discount),0) from purchase_dt  where code_items ='" + this.dgv.CurrentRow.Cells["code_items"].Value + "" + "'").Rows[0][0] + "";

            }
            catch (Exception ex)
            {
                db.log_error(string.Concat((object)ex));
            }
        }

        private void lbl_acc_bal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
                //XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\stat_gl.repx", true);
                ////xtraReport.Parameters["parameter2"].Value = txt_serial_string.Text;
                //xtraReport.Parameters["parameter2"].Value = dgv.CurrentRow.Cells["acc_num"].Value+"" ;
                //xtraReport.Parameters["parameter2"].Visible = false;
                //XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);

            account.report_account.report_screen.sc_statment_gl f = new account.report_account.report_screen.sc_statment_gl();
            f.Show();
            f.lbl_code.Text = dgv.CurrentRow.Cells["acc_num"].Value + "";
            //f.date1.Text = date1.Text;
            //f.date2.Text = date2.Text;
            f.date1.Select();
            f.btn_get_Data.Select();
            f.btn_get_Data.PerformClick();
        }

        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (v.search_screen_code != "")
            {
                txt_serial_string.Text = v.search_screen_code;
                txt_serial_string.Select();
                txt_note.Select();
                timer1.Enabled = false;

            }
        }
    }
}