using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Drawing.Printing;
using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;
namespace f1
{
    public partial class frm_recevable : DevExpress.XtraEditors.XtraForm
    {
        public frm_recevable()
        {
            this.edit = false;
            this.add_permission = true;
            this.edit_permission = true;
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
            db.Open();
            combo_type.Text = "";

        }
        private bool edit;
        private bool add_permission;
        private bool edit_permission;
        private int prog;
        private string numBook_entry,numBook,error;
        private double amount = 0;
        private int num = 0;
        private int num_entry = 0;

        private void load_permission()
        {
            this.save_barButtonItem1.Enabled = Convert.ToBoolean(db.GetData("select [add_only] from permission_sub where user_code='" + v.usercode + "' and name_frm ='recev' ").Rows[0][0].ToString());
            this.delete_barButtonItem7.Enabled = Convert.ToBoolean(db.GetData("select [delete] from permission_sub where user_code='" + v.usercode + "' and name_frm ='recev' ").Rows[0][0].ToString());
            this.add_permission = Convert.ToBoolean(db.GetData("select [add_only] from permission_sub where user_code='" + v.usercode + "' and name_frm ='recev' ").Rows[0][0].ToString());
            if (this.add_permission)
                this.save_barButtonItem1.Enabled = true;
            this.edit_permission = Convert.ToBoolean(db.GetData("select [edit_only] from permission_sub where user_code='" + v.usercode + "' and name_frm ='recev' ").Rows[0][0].ToString());
            this.print_preview_barButtonItem10.Enabled = Convert.ToBoolean(db.GetData("select [print] from permission_sub where user_code='" + v.usercode + "' and name_frm ='recev' ").Rows[0][0].ToString());
            this.print_direct_barButtonItem11.Enabled = Convert.ToBoolean(db.GetData("select [print] from permission_sub where user_code='" + v.usercode + "' and name_frm ='recev' ").Rows[0][0].ToString());
        }
        private void frm_recevable_Load(object sender, EventArgs e)
        {
            cls_book.loadbook(this.comb_code_name, "سند قبض");
            cls_book.load_from_term(this.combo_type, "سند قبض");
            //this.dt_piker.MinDate = new DateTime(v.current_yaer, 1, 1);
            //this.dt_piker.MaxDate = new DateTime(v.current_yaer, 12, 31);
            //this.dt_piker.Text = DateTime.Now.ToString(v.current_yaer + "/MM/dd");
            //this.dt_f.Text = DateTime.Now.ToString(v.current_yaer + "/MM/dd");


            this.dt_piker.Text = DateTime.Now.ToString("yyyy/MM/dd");
            this.dt_piker.Text = DateTime.Now.ToString("yyyy/MM/dd");
            this.dt_piker.Text = DateTime.Now.ToString("yyyy/MM/dd");
            this.dt_f.Text = DateTime.Now.ToString("yyyy/MM/dd");
            this.dt_piker.Text = DateTime.Now.ToString("yyyy/MM/dd");

            all_comb.cost_center_name(this.combo_costcenter);


            this.group_find.Visible = false;
            all_comb.load_curracne(this.combo_currance);
            this.rdvendor.Checked = true;
            this.rdcustomer.Checked = v.sale_c;
            this.rdvendor.Checked = v.sale_v;
            this.combo_attach.Text = v.sale_sale_hd_id;
            this.combo_add_account.Text = v.sale_vcs_name;
            this.txt_amount.Text = v.sale_amount;
            this.combo_add_account.Enabled = v.privent_select_vcs;
            if (v.premium == "1")
            {
                //this.lbl_premiums.Text = v.premium;
                this.add_items();
                this.txt_amount.ReadOnly = true;
            }
            this.load_permission();
            this.rdcustomer.Checked = true;
            combo_type.Text = "";
            bool visable = Convert.ToBoolean(db.GetData("select currancey from info_co").Rows[0][0] + "");
            if (visable == false)
            {
                lbl_currance.Visible = false;
                combo_currance.Visible = false;
                txt_f_currance.Visible = false;
                btn_currance.Visible = false;
            }

        }
        //=========================Function



        DataTable dt_term;
        private void select_type()
        {
            calc();
            string error = "";
            dt_term = new DataTable();
            cls_book.Make_entry_type_recevr(ref dt_term, ref error, "سند قبض", combo_type.Text, combo_wars.Text, lbl_code.Text, amount+"");

        
            for (int i = 0; i < dt_term.Rows.Count; i++)
            {
                    dgv.Rows.Add(null, dt_term.Rows[i][1], dt_term.Rows[i][2], dt_term.Rows[i][3], dt_term.Rows[i][4], dt_term.Rows[i][8], dt_term.Rows[i][7], dt_term.Rows[i][6], dt_term.Rows[i][5]);
                    txt_amount.Text = "";
                    combo_add_account.Text = "";
                    combo_add_account.Select();
            }
        }

        private void add_items()
        {
            if (edit == false)
            {
                dgv.Rows.Add(null, lbl_code.Text, lbl_name.Text, 0, txt_amount.Text, lbl_type_acc.Text, lbl_sort.Text, lbl_rootlevel_name.Text, lbl_rootlevel.Text);
                txt_amount.Text = "";
                combo_add_account.Text = "";
                combo_add_account.Select();
            }
            else if (edit == true)
            {
                dgv.Rows.RemoveAt(dgv.Rows.Count - 1);
                dgv.Rows.Add(null, lbl_code.Text, lbl_name.Text, 0, txt_amount.Text, lbl_type_acc.Text, lbl_sort.Text, lbl_rootlevel_name.Text, lbl_rootlevel.Text);
                txt_amount.Text = "";
                combo_add_account.Text = "";
                combo_add_account.Select();


            }

            }
        private void new_()
        {
            DialogResult dr;
            dr = MessageBox.Show("هل تريد عمل سند جديد!!؟؟؟؟ ", "رسال جديد مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                v.privent_select_vcs = true;
                frm_recevable frm = new frm_recevable();
                this.Close();
                frm.Show();
            }
        }
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
                if (depit!=0)
                {
                    amount = depit;
                }
                else
                {
                    amount = ceridt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void save()
        {
            select_type();
            progressBar1.Visible = true;
            //1)select type of entry and insert entry :=
            //_______________________________________________
            calc();

            if (Convert.ToDouble(lbl_def.Text) != 0 || Convert.ToDouble(lbl_def.Text) > 0)
            {
                MessageBox.Show("القيد غير متزن"); return;
            }
            else
            {
                //get only number for one user Entry
                string code_entry_term = (db.GetData("select code_entry from term where term_id='" + combo_type.Text + "' ").Rows[0][0].ToString());
                cls_book.Generat_numBooknum("entry", code_entry_term, ref numBook_entry, ref error, ref num_entry);
                txt_entry_string.Text = numBook_entry;
               //get only number for one user purchase
                txt_code_book.Text = db.GetData("select code_book from book where name_book='" + comb_code_name.Text + "'").Rows[0][0].ToString();
                cls_book.Generat_numBooknum("recev_hd", txt_code_book.Text, ref numBook, ref error,ref num);
                txt_serial_string.Text = numBook;
                //inser Entry_hd
                db.Run("insert into entry_hd ([code_entry],code_book) values ('" + txt_entry_string.Text + "','" + txt_code_entry_type.Text + "')");
                //entry_dt
                prog = dgv.Rows.Count;
                for (int z = 0; z < dgv.Rows.Count; z++)
                {
                    db.Run("insert into entry([code_entry],acc_num,acc_name,rootlevel,sort,type_acc,depit,credit,name_book,code_book,dates,rootlevel_name,attachno,attachbook,attachnamebook,attachtext,attachno2,costcenter_code,num_book)values('" + txt_entry_string.Text + "','" + dgv.Rows[z].Cells["acc_num"].Value + "','" + dgv.Rows[z].Cells["acc_name"].Value + "','" + dgv.Rows[z].Cells["rootlevel"].Value + "','" + dgv.Rows[z].Cells["sort"].Value + "','" + dgv.Rows[z].Cells["type_acc"].Value + "'," + Convert.ToDecimal(dgv.Rows[z].Cells["depit"].Value) + "," + Convert.ToDecimal(dgv.Rows[z].Cells["credit"].Value) + ",'" + txt_name_book_type.Text + "','" + code_entry_term + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + dgv.Rows[z].Cells["rootlevel_name"].Value + "','" + txt_serial_string.Text + "','" + txt_code_book.Text + "','" + lbl_comb_code_name.Text + "','system','" + combo_attach.Text + "','"+ dgv.Rows[z].Cells["costcenter"].Value + "','"+num_entry+"')");
                    backgroundWorker1.ReportProgress(z);
                }
                //insert recev_hd
                db.Run("insert into recev_hd(recev_hd_id,code_book,name_book,type,amount,date_,user_name,user_code,note,num_book) values ('" + txt_serial_string.Text + "','" + txt_code_book.Text + "','" + lbl_comb_code_name.Text + "','" + combo_type.Text + "','" + lbl_depit.Text + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + v.username + "','" + v.usercode + "','"+txt_note.Text+"','"+num+"')");
                //insert recev_dt
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    db.Run("insert into recev_dt([code_entry],acc_num,acc_name,rootlevel,type_acc,sort,depit,credit,name_book,code_book,dates,rootlevel_name,attachtext,attachno2,costcenter_id)values('" + txt_serial_string.Text + "','" + dgv.Rows[i].Cells["acc_num"].Value + "','" + dgv.Rows[i].Cells["acc_name"].Value + "','" + dgv.Rows[i].Cells["rootlevel"].Value + "','" + dgv.Rows[i].Cells["type_acc"].Value + "','" + dgv.Rows[i].Cells["sort"].Value + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["depit"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["credit"].Value) + ",'" + lbl_comb_code_name.Text + "','" + txt_code_book.Text + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + dgv.Rows[i].Cells["rootlevel_name"].Value + "','system','" + combo_attach.Text + "','" + dgv.Rows[i].Cells["costcenter"].Value + "')");
                }
                //update sales lack to link sales to recev_dt

                db.Run("update sale_hd set lock ='t' where sale_hd_id='" + combo_attach.Text + "'");

                progressBar1.Visible = false;
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "saving ", "save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bode_of_navigation(txt_serial_string.Text, txt_code_book.Text);
              //  save_barButtonItem1.Enabled = false;
            }
        }
        public void update()
        {

            progressBar1.Visible = true;
            //1)select type of entry and insert entry :=
            //_______________________________________________
            select_type();
            calc();


            if (Convert.ToDouble(lbl_def.Text) != 0 || Convert.ToDouble(lbl_def.Text) > 0)
            {
                MessageBox.Show("القيد غير متزن"); return;
            }
            else
            {
                //delete entry 
                string code_entry_edit= db.GetData("select  code_entry from entry where code_entry<>'-11' and attachno='"+txt_serial_string.Text+"'").Rows[0][0] + "";
                string recev_hd_id_edit = txt_serial_string.Text;
                db.Run("delete from entry where code_entry<>'-11' and attachno='"+ txt_serial_string.Text+ "'");
                db.Run("delete from entry_hd where code_entry='"+ code_entry_edit + "'");

               
                //   MessageBox.Show(code);
                //delete from pay_hd
                //delete receve hd and dt 

                db.Run("delete from recev_hd where recev_hd_id='" + txt_serial_string.Text + "'");
                //delte from pay_dt
                db.Run("delete from recev_dt where code_entry='" + txt_serial_string.Text + "'");



                //get only number for one user Entry

                string code_entry_term = (db.GetData("select code_entry from term where term_id='" + combo_type.Text + "' ").Rows[0][0].ToString());
                cls_book.Generat_numBooknum("entry", code_entry_term, ref numBook_entry, ref error, ref num_entry);
                txt_entry_string.Text = numBook_entry;
                //get only number for one user recev_hd
               // txt_code_book.Text = db.GetData("select code_book from book where name_book='" + comb_code_name.Text + "'").Rows[0][0].ToString();
               // cls_book.Generat_numBooknum("recev_hd", txt_code_book.Text, ref numBook, ref error);
               // txt_serial_string.Text = numBook;

                //inser Entry_hd
                db.Run("insert into entry_hd ([code_entry],code_book) values ('" + txt_entry_string.Text + "','" + txt_code_entry_type.Text + "')");
                //entry_dt
                prog = dgv.Rows.Count;
                for (int z = 0; z < dgv.Rows.Count; z++)
                {
                    db.Run("insert into entry([code_entry],acc_num,acc_name,rootlevel,sort,type_acc,depit,credit,name_book,code_book,dates,rootlevel_name,attachno,attachbook,attachnamebook,attachtext,attachno2,costcenter_code,num_book)values('" + txt_entry_string.Text + "','" + dgv.Rows[z].Cells["acc_num"].Value + "','" + dgv.Rows[z].Cells["acc_name"].Value + "','" + dgv.Rows[z].Cells["rootlevel"].Value + "','" + dgv.Rows[z].Cells["sort"].Value + "','" + dgv.Rows[z].Cells["type_acc"].Value + "'," + Convert.ToDecimal(dgv.Rows[z].Cells["depit"].Value) + "," + Convert.ToDecimal(dgv.Rows[z].Cells["credit"].Value) + ",'" + txt_name_book_type.Text + "','" + code_entry_term + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + dgv.Rows[z].Cells["rootlevel_name"].Value + "','" + txt_serial_string.Text + "','" + txt_code_book.Text + "','" + lbl_comb_code_name.Text + "','system','" + combo_attach.Text + "','" + dgv.Rows[z].Cells["costcenter"].Value + "','"+num_entry+"')");
                    backgroundWorker1.ReportProgress(z);
                }
                //insert recev_hd
                db.Run("insert into recev_hd(recev_hd_id,code_book,name_book,type,amount,date_,user_name,user_code,note,num_book) values ('" + txt_serial_string.Text + "','" + txt_code_book.Text + "','" + lbl_comb_code_name.Text + "','" + combo_type.Text + "','" + lbl_depit.Text + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + v.username + "','" + v.usercode + "','" + txt_note.Text + "','"+num+"')");
                //insert recev_dt
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    db.Run("insert into recev_dt([code_entry],acc_num,acc_name,rootlevel,type_acc,sort,depit,credit,name_book,code_book,dates,rootlevel_name,attachtext,attachno2,costcenter_id)values('" + txt_serial_string.Text + "','" + dgv.Rows[i].Cells["acc_num"].Value + "','" + dgv.Rows[i].Cells["acc_name"].Value + "','" + dgv.Rows[i].Cells["rootlevel"].Value + "','" + dgv.Rows[i].Cells["type_acc"].Value + "','" + dgv.Rows[i].Cells["sort"].Value + "'," + Convert.ToDecimal(dgv.Rows[i].Cells["depit"].Value) + "," + Convert.ToDecimal(dgv.Rows[i].Cells["credit"].Value) + ",'" + lbl_comb_code_name.Text + "','" + txt_code_book.Text + "','" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + dgv.Rows[i].Cells["rootlevel_name"].Value + "','system','" + combo_attach.Text + "','" + dgv.Rows[i].Cells["costcenter"].Value + "')");
                }
                //update sales lack to link sales to recev_dt

                db.Run("update sale_hd set lock ='t' where sale_hd_id='" + combo_attach.Text + "'");


                progressBar1.Visible = false;
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "saving ", "save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bode_of_navigation(txt_serial_string.Text, txt_code_book.Text);
            }



            }
        public void delete()
        {
            if (edit == true)
            {
                if (txt_serial_string.Text == "")
                {
                    XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "ماشي بس هو مفيش حاجه علشان امسحها دخل كود  طيب !!؟؟؟؟ ", "رسال حذف مستند", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult dr;
                    dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "هل تريد حذف السند!!؟؟؟؟ ", "رسال حذف مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);


                    if (dr == DialogResult.OK)
                    {
                        //delete entry
                        string code = db.GetData("select top 1 code_entry from entry where attachno='" + txt_serial_string.Text + "' ").Rows[0][0].ToString();
                        // MessageBox.Show(code);
                        string code_book = db.GetData("select top 1 code_book from entry where attachno='" + txt_serial_string.Text + "' ").Rows[0][0].ToString();

                        db.Run("delete from entry_hd where code_entry='" + code + "'  ");
                        //MessageBox.Show(code);
                        db.Run("delete from entry where code_entry='" + code + "'  ");
                        //   MessageBox.Show(code);
                        //delete from pay_hd
                        db.Run("delete from recev_hd where recev_hd_id='" + txt_serial_string.Text + "' and code_book='" + txt_code_book.Text + "' ");
                        //delte from pay_dt
                        db.Run("delete from recev_dt where code_entry='" + txt_serial_string.Text + "' and code_book='" + txt_code_book.Text + "' ");
                        //update sales lack to link sales to recev_dt

                        db.Run("update sale_hd set lock ='0' where sale_hd_id='" + combo_attach.Text + "'");

                        db.action_delete("تم حذف سند القيد برقم" + txt_serial_string.Text + "  بمبلغ " + lbl_depit.Text + "", txt_serial_string.Text);

                        update_vcs_value_in_sale();
                        XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "deleted ", "delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frm_recevable frm = new frm_recevable();
                        this.Close();
                        frm.Show();
                    }

                }
            }
        }
        public void update_vcs_value_in_sale()
        {
            string vcs_code = db.GetData("select isnull(max(vcs_code),0) from sale_hd where sale_hd_id='" + combo_attach.Text + "'").Rows[0][0].ToString();
            db.Run("update sale_hd set vcs_value=(select sum(depit)-sum(credit) from entry where acc_num='" + vcs_code + "') where sale_hd_id='" + combo_attach.Text + "'");

        }
        public void perform_save_update()
        {
            if (dgv.Rows.Count == 0) return;

            if (combo_type.Text == "")
            {
                MessageBox.Show("يجب اختيار نوع السند");
                combo_type.Select();
                return;
            }
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


            //if cost center mood is active
            bool costCenter_mund = Convert.ToBoolean(db.GetData("select costCenter_mund from info_co").Rows[0][0].ToString());
            if (costCenter_mund)
            {
                if (rd_account.Checked)
                {
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        if (dgv.Rows[i].Cells["costcenter"].Value + "" == "")
                        {
                            MessageBox.Show("يجب اخيتار مركز تكلفة");
                            return;
                        }
                    }
                }
            }
                //to Conferm  fount purchase id in table 
                if (!this.add_permission && !Convert.ToBoolean(db.GetData("select [add_only] from permission_sub where user_code='" + v.usercode + "' and name_frm ='recev' ").Rows[0][0].ToString()))
            {
                this.save_barButtonItem1.Enabled = true;
            }
            else
            {
                try
                {
                    if (db.GetData("select sale_hd_id from sale_hd   where sale_hd_id= '" + this.txt_serial_string.Text + "'").Rows[0][0].ToString() == "")
                    {
                        XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "الفاتوره غير موجوده ", "warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    db.log_error(string.Concat((object)ex));
                }
                if (this.dgv.Rows.Count == 0)
                {
                    XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "ضيف حساب حتي يظهر لك القيد ", "warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    this.calc();
                    if (this.edit)
                        update();
                    else
                    {
                        this.save();

                    }
                }
            }
        }
        private void get_dt(string num, string book)//get data detals
        {
            DataTable dt_dt = new DataTable();
            db.GetData_DGV("SELECT  acc_num, acc_name, depit, credit,type_acc,sort,rootlevel_name, rootlevel,costcenter_id  FROM   recev_dt where code_entry='" + num + "' and code_book='" + book + "'", dt_dt);
            //dgv.DataSource = dt_dt;
            for (int i = 0; i < dt_dt.Rows.Count; i++)
            {
                dgv.Rows.Add("",dt_dt.Rows[i][0], dt_dt.Rows[i][1], dt_dt.Rows[i][2], dt_dt.Rows[i][3], dt_dt.Rows[i][4], dt_dt.Rows[i][5], dt_dt.Rows[i][6], dt_dt.Rows[i][7], dt_dt.Rows[i][8]);
            }
        }
        private void bode_of_navigation(string num, string book)
        {
            this.edit = true;

            dgv.Rows.Clear();

            this.load_permission();
            //this.save_barButtonItem1.Enabled = true;
            this.dataGridView1.Rows.Clear();
            DataTable tb = new DataTable();
            db.GetData_DGV("select recev_hd_id from  recev_hd where recev_hd_id='" + num + "' and code_book='" + book + "' ", tb);
            if (tb.Rows.Count <= 0)
                return;
            this.combo_attach.Text = db.GetData("select attachno2 from recev_dt where code_entry='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            this.get_dt(num, book);
            this.comb_code_name.Text = db.GetData("select name_book from recev_hd where recev_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            this.txt_code_book.Text = db.GetData("select code_book from recev_hd where recev_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            this.txt_serial_string.Text = db.GetData("select recev_hd_id from recev_hd where recev_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
           // this.combo_type.Text = db.GetData("select type from recev_hd where recev_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            this.dt_piker.Text = db.GetData("select date_ from recev_hd where recev_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            this.lbl_user_name.Text = db.GetData("select user_name from recev_hd where recev_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            this.lbl_user_code.Text = db.GetData("select user_code from recev_hd where recev_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            txt_note.Text= db.GetData("select note from recev_hd where recev_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();
            // this.lbl_premiums.Text = db.GetData("select premiums from recev_hd where recev_hd_id='" + num + "' and code_book='" + book + "'").Rows[0][0].ToString();

            combo_type.Text = "";

        }
        //==============dgv controls 
        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv);

        }
        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            calc();

        }
        //===============simble controls
        private void rd_account_CheckedChanged(object sender, EventArgs e)
        {
            combo_add_account.DataSource = null;
            combo_add_account.Items.Clear();

            if (rd_account.Checked == true)
            {
                f1.all_comb.load_account_name_c(combo_add_account);
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            add_items();
        }
        private void rdvendor_CheckedChanged(object sender, EventArgs e)
        {
            combo_add_account.DataSource = null;
            combo_add_account.Items.Clear();

            if (rdvendor.Checked == true)
            {
                f1.all_comb.load_vendor_only_name(combo_add_account);
            }
        }
        private void rdcustomer_CheckedChanged(object sender, EventArgs e)
        {
            combo_add_account.DataSource = null;
            combo_add_account.Items.Clear();

            if (rdcustomer.Checked == true)
            {
                f1.all_comb.load_customer_only_name(combo_add_account);
            }
        }
        private void combo_add_account_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rd_account.Checked)
                {
                    lbl_code.Text = db.GetData("select rootid from tree where rootname='" + combo_add_account.Text + "'").Rows[0][0].ToString();
                    lbl_name.Text = db.GetData("select rootname from tree where rootname='" + combo_add_account.Text + "'").Rows[0][0].ToString();
                    lbl_rootlevel.Text = db.GetData("select rootlevel from tree where rootname='" + combo_add_account.Text + "'").Rows[0][0].ToString();
                    lbl_sort.Text = "1";
                    lbl_type_acc.Text = db.GetData("select sort from tree where rootname='" + combo_add_account.Text + "'").Rows[0][0].ToString();
                    lbl_rootlevel_name.Text = "0";

                }
                else
                {
                    lbl_code.Text = db.GetData("select vcs_code from vcs where vcs_name='" + combo_add_account.Text + "'").Rows[0][0].ToString();
                    lbl_name.Text = db.GetData("select vcs_name from vcs where vcs_name='" + combo_add_account.Text + "'").Rows[0][0].ToString();
                    lbl_rootlevel.Text = db.GetData("select rootlevel from vcs where vcs_name='" + combo_add_account.Text + "'").Rows[0][0].ToString();
                    lbl_sort.Text = "2";
                    lbl_type_acc.Text = db.GetData("select sort from vcs where vcs_name='" + combo_add_account.Text + "'").Rows[0][0].ToString();
                    lbl_rootlevel_name.Text = db.GetData("select rootlevel_name from vcs where vcs_name='" + combo_add_account.Text + "'").Rows[0][0].ToString();

                }
            }
            catch (Exception)
            {


            }
        }
        private void comb_code_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_code_book.Text = db.GetData("select code_book from book where name_book='" + comb_code_name.Text + "'").Rows[0][0].ToString();

            //cls_book.selectbook("recev_hd", "سند قبض", txt_code_book.Text, txt_serial, "recev_hd_id");
            //txt_serial_string.Text = txt_code_book.Text + txt_serial.Text;
            //cls_book.Generat_numBooknum("سند قبض", "recev_hd_id", "recev_hd", ref numBook);
            //txt_serial_string.Text = numBook;
            //lbl_comb_code_name.Text = comb_code_name.Text;


            //string code_entry_term = (db.GetData("select code_entry from term where term_id='" + combo_type.Text + "' ").Rows[0][0].ToString());
            //cls_book.Generat_numBooknum("entry", code_entry_term, ref numBook, ref error);
            //txt_entry_string.Text = numBook_entry;
            //get only number for one user purchase
            txt_code_book.Text = db.GetData("select code_book from book where name_book='" + comb_code_name.Text + "'").Rows[0][0].ToString();
            cls_book.Generat_numBooknum("recev_hd", txt_code_book.Text, ref numBook, ref error, ref num );
            txt_serial_string.Text = numBook;
        }
        private void txt_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        //============Navigation
        private void privint()
        {
            if (combo_attach.Text != "")
            {
                combo_add_account.Enabled = false;
            }
            else if (combo_attach.Text == "")
            {
                combo_add_account.Enabled = true;
            }
            btn_edit.Visible = true;
        }
        private void save_barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            perform_save_update();

            update_vcs_value_in_sale();
        
        v.sale_sale_hd_id = "";
        v. sale_vcs_code = "";
        v. sale_vcs_name = "";
        v.sale_amount = "";
        }
        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            delete();
        }
        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //  try
            {
                privint();
                string s = "";
                s = db.GetData("select min(recev_hd_id) from recev_hd where  code_book='" + txt_code_book.Text + "' ").Rows[0][0].ToString();
                if (s != "")
                {
                    txt_serial_string.Text = db.GetData("select min(recev_hd_id) from recev_hd where  code_book='" + txt_code_book.Text + "' ").Rows[0][0].ToString();
                    bode_of_navigation(txt_serial_string.Text, txt_code_book.Text);
                }
            }
            //    catch (Exception)
            {

            }
        }
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                privint();

                string s = "";
                s = db.GetData("select max(recev_hd_id) from recev_hd where  code_book='" + txt_code_book.Text + "'").Rows[0][0].ToString();
                if (s != "")
                {
                    txt_serial_string.Text = db.GetData("select max(recev_hd_id) from recev_hd where  code_book='" + txt_code_book.Text + "'").Rows[0][0].ToString();
                    bode_of_navigation(txt_serial_string.Text, txt_code_book.Text);
                }
            }
            catch (Exception)
            {


            }
        }
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                privint();

                string s = "";
                s = db.GetData("select min(recev_hd_id) from recev_hd where code_book='" + txt_code_book.Text + "'").Rows[0][0].ToString();
                if (s != "")
                {
                    edit = true;
                    {

                        DataTable dt = new DataTable();
                        dt.Rows.Clear();
                        string st = "";
                        st = db.GetData("select min(recev_hd_id) from recev_hd where code_book='" + txt_code_book.Text + "'").Rows[0][0].ToString();
                        st = st.Remove(0, 1);
                        st = st.Remove(0, 2);

                        int m = int.Parse(st);
                        string num_without;
                        num_without = txt_serial_string.Text;
                        num_without = num_without.Remove(0, 1);
                        num_without = num_without.Remove(0, 2);

                        //clearANDauto();
                        if (int.Parse(num_without) <= m)
                            MessageBox.Show("اخر ملف");
                        else
                        {
                            int num = +(Int32.Parse(num_without) - 1);
                            txt_serial_string.Text = txt_code_book.Text + num;
                            bode_of_navigation(txt_serial_string.Text, txt_code_book.Text);
                        }
                    }
                }

            }
            catch (Exception)
            {

            }

        }
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                privint();

                string s = "";
                s = db.GetData("select max(recev_hd_id) from recev_hd where code_book='" + txt_code_book.Text + "'").Rows[0][0].ToString();
                if (s != "")
                {
                    edit = true;

                    // lbl_state.t
                    DataTable dt = new DataTable();
                    dt.Rows.Clear();
                    string st = "";

                    st = db.GetData("select max(recev_hd_id) from recev_hd where code_book='" + txt_code_book.Text + "'").Rows[0][0].ToString();
                    st = st.Remove(0, 1);
                    st = st.Remove(0, 2);

                    int m = int.Parse(st);
                    string num_without;
                    num_without = txt_serial_string.Text;
                    num_without = num_without.Remove(0, 1);
                    num_without = num_without.Remove(0, 2);
                    //clearANDauto();
                    if (int.Parse(num_without) >= m)
                        MessageBox.Show("اول م ملف");
                    else
                    {
                        int num = +(Int32.Parse(num_without) + 1);
                        txt_serial_string.Text = txt_code_book.Text + num;
                        bode_of_navigation(txt_serial_string.Text, txt_code_book.Text);
                    }
                }

            }
            catch (Exception)
            {

            }
        }
        //===============HotKeys====

        private void txt_amount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && Convert.ToDouble(txt_amount.Text) > 0 && txt_amount.Text != "" && combo_add_account.Text != "")
                {
                    add_items();
                }
                else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                {
                    combo_add_account.Select();
                }
            }
            catch (Exception)
            {
            }
        }
        private void combo_add_account_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txt_amount.Select();
                }
            }
            catch (Exception)
            {


            }
        }
        private void combo_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_name_book_type.Text = db.GetData("select bookname_entry  from term  where term_id ='" + combo_type.Text + "'").Rows[0][0].ToString();
            txt_code_entry_type.Text = db.GetData("select code_entry  from term  where term_id ='" + combo_type.Text + "'").Rows[0][0].ToString();
            //cls_book.selectbook("entry_hd", "سند قيد", txt_code_entry_type.Text, txt_code_entry, "code_entry");
            //  cls_book.Generat_numBook("سند قيد", "code_entry", "entry_hd", ref numBook_entry);
            string code_entry_term = (db.GetData("select code_entry from term where term_id='" + combo_type.Text + "' ").Rows[0][0].ToString());
            cls_book.Generat_numBooknum("entry", code_entry_term, ref numBook_entry, ref error, ref num_entry);
            txt_entry_string.Text = numBook_entry;
            //get only number for one user purchase
            //txt_code_book.Text = db.GetData("select code_book from book where name_book='" + comb_code_name.Text + "'").Rows[0][0].ToString();
            //cls_book.Generat_numBooknum("recev_hd", txt_code_book.Text, ref numBook, ref error);
            //txt_serial_string.Text = numBook;
            txt_code_entry_type.Text = numBook_entry;
        }
      
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Maximum = prog;
            progressBar1.Value = e.ProgressPercentage;
        }

        private void combo_attach_SelectedIndexChanged(object sender, EventArgs e)
        {
            all_comb.load_invoice_number_sale(combo_attach);

        }

        private void frm_recevable_KeyDown(object sender, KeyEventArgs e)
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
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new_();

  

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                for (int x = 0; x < dgv.Rows.Count+1; x++)
                {
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        dgv.Rows.RemoveAt(dgv.Rows[i].Index);
                    }
                }
               
            }
            catch (Exception) { }
        }

        private void combo_add_account_Click(object sender, EventArgs e)
        {
            privint();
        }

        private void print_preview_barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            XtraReport xtraReport = XtraReport.FromFile("forms\\recev.repx", true);
            xtraReport.Parameters["parameter1"].Value = (object)this.txt_serial_string.Text;
            xtraReport.Parameters["parameter1"].Visible = false;
            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (edit == true)
            {
                if (dgv.Rows.Count > 0)
                {
                      txt_amount.Text = dgv.CurrentRow.Cells["depit"].Value.ToString();
                }
            
            }
        }
        private void edite_simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                string am = txt_amount.Text;
                for (int x = 0; x < dgv.Rows.Count + 1; x++)
                {
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        dgv.Rows.RemoveAt(dgv.Rows[i].Index);
                    }
                }
                txt_amount.Text = am;
            }
            catch (Exception) { }
        }

        private void frm_recevable_FormClosing(object sender, FormClosingEventArgs e)
        {
            v.sale_sale_hd_id = "";
            v.sale_vcs_code = "";
            v.sale_vcs_name = "";
            v.sale_amount = "";
        }
        //==============>>>>>>>>>>>>>>>>>>>>>search screen ---------------------------------------------------------
        //--------------------------------------------------------------------
      
        private void f_barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (group_find.Visible == false)
            //{
            //    group_find.Visible = true;
            //}
            //else
            //{
            //    group_find.Visible = false;

            //}
            v.search_screen = "recevable";
            frm_search f = new frm_search();
            f.ShowDialog();
            timer1.Enabled = true;
        }

        private void combo_document_f_Click(object sender, EventArgs e)
        {
            all_comb.load_invoice_number_recev(combo_document_f);

        }

        private void combo_vcs_name_f_Click(object sender, EventArgs e)
        {
            all_comb.load_name_vcs(combo_vcs_name_f);

        }

        private void btn_searchin_group_f3_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("select incloud_taxes,code_book,recev_hd_id,vcs_code,vcs_name,date_P,name_book from recev_hd where date_P='" + dt_f.Value.ToString("yyyy/MM/dd") + "'", dt);
            dgv_f.DataSource = dt;
        }

        private void btn_searchin_group_f1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("select incloud_taxes,code_book,recev_hd_id,vcs_code,vcs_name,date_P,name_book from recev_hd where recev_hd_id='" + combo_document_f.Text + "'", dt);
            dgv_f.DataSource = dt;
        }

        private void btn_searchin_group_f2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("select incloud_taxes,code_book,recev_hd_id,vcs_code,vcs_name,date_P,name_book from recev_hd where vcs_code='" + lbl_vcs_code_f.Text + "'", dt);
            dgv_f.DataSource = dt;
        }

        private void btn_close_f_Click(object sender, EventArgs e)
        {
            group_find.Visible = false;

        }

        private void combo_vcs_name_f_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_vcs_code_f.Text = db.GetData("select vcs_code from vcs where vcs_name ='" + combo_vcs_name_f.Text + "'").Rows[0][0].ToString();

            }
            catch (Exception)
            {


            }
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
            //xtraReport.Parameters["parameter2"].Value = dgv.CurrentRow.Cells["acc_num"].Value + "";
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

        private void btn_costcenter_Click(object sender, EventArgs e)
        {

            if (dgv.Rows.Count == 0) return;

            dgv.CurrentRow.Cells["costcenter"].Value = combo_costcenter.Text;
            lbl_costcenter.Text = db.GetData("select  isnull(max(costcenter_id),0) from  costcenter where costcenter_name='" + combo_costcenter.Text + "'").Rows[0][0].ToString();
            dgv.CurrentRow.Cells["costcenter"].Value = lbl_costcenter.Text;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (v.search_screen_code != "")
            {
                txt_serial_string.Text = v.search_screen_code;
                txt_serial_string.Select();

                textBox2.Select();
                timer1.Enabled = false;

            }
        }

        private void txt_serial_string_Leave(object sender, EventArgs e)
        {
            try
            {
                bode_of_navigation(txt_serial_string.Text, txt_code_book.Text);

            }
            catch (Exception)
            {

                
            }
        }
    }
}