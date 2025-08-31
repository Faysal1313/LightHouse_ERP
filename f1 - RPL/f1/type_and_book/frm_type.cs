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
    public partial class frm_type : DevExpress.XtraEditors.XtraForm
    {
        public frm_type()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);

        }
        bool edit = false;
        private void frm_type_Load(object sender, EventArgs e)
        {
            db.Open();
            combo_book_name.Text = "";
            txt_code_book.Text = "";
            comb_depit_name.Text = "";
            all_comb.cost_center_name(this.combo_costcenter);



            cls_book.loadbook(comb_bookname_entry, "سند قيد");
            cls_book.load_wares_acc(combo_depit);
            cls_book.load_wares_acc(combo_credit);
        }

        //--------------------------------------------controls

        private void load_terms_id(System.Windows.Forms.ComboBox comb)
        {
            try
            {
                DataTable dt = new DataTable();
                db.GetData_DGV("select distinct term_id from term where name_book='" + combo_book_name.Text + "' ", dt);
                comb.DisplayMember = "term_id";
                comb.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void com_SelectedIndexChanged(object sender, EventArgs e)
        {
            cls_book.loadbook(combo_book_name, com.Text);
            if (com.Text == "سند فاتوره مشتريات")
            {
                combofield_depit.Items.Clear();
                combofield_depit.Items.Add("tot_befor");
                combofield_depit.Items.Add("tot_after_dis");
                combofield_depit.Items.Add("discount");
                combofield_depit.Items.Add("incloud_taxes");
                combofield_depit.Items.Add("taxtes");
                combofield_depit.Items.Add("vat_add");
                combofield_depit.Items.Add("other");
                combofield_credit.Items.Clear();
                combofield_credit.Items.Add("tot_befor");
                combofield_credit.Items.Add("tot_after_dis");
                combofield_credit.Items.Add("discount");
                combofield_credit.Items.Add("incloud_taxes");
                combofield_credit.Items.Add("taxtes");
                combofield_credit.Items.Add("vat_add");
                combofield_credit.Items.Add("other");
            }
            else if (com.Text == "سند مردودات مشتريات")
            {
                combofield_depit.Items.Clear();
                combofield_depit.Items.Add("tot_befor");
                combofield_depit.Items.Add("tot_after_dis");
                combofield_depit.Items.Add("discount");
                combofield_depit.Items.Add("incloud_taxes");
                combofield_depit.Items.Add("taxtes");
                combofield_depit.Items.Add("vat_add");
                combofield_depit.Items.Add("other");
                combofield_credit.Items.Clear();
                combofield_credit.Items.Add("tot_befor");
                combofield_credit.Items.Add("tot_after_dis");
                combofield_credit.Items.Add("discount");
                combofield_credit.Items.Add("incloud_taxes");
                combofield_credit.Items.Add("taxtes");
                combofield_credit.Items.Add("vat_add");
                combofield_credit.Items.Add("other");
            }
            else if (com.Text == "سند مردودات مبيعات")
            {
                combofield_depit.Items.Clear();
                combofield_depit.Items.Add("tot_befor");
                combofield_depit.Items.Add("tot_after_dis");
                combofield_depit.Items.Add("cost");
                combofield_depit.Items.Add("discount");
                combofield_depit.Items.Add("incloud_taxes");
                combofield_depit.Items.Add("taxtes");
                combofield_depit.Items.Add("vat_add");
                combofield_depit.Items.Add("other");
                combofield_credit.Items.Clear();
                combofield_credit.Items.Add("tot_befor");
                combofield_credit.Items.Add("tot_after_dis");
                combofield_credit.Items.Add("cost");
                combofield_credit.Items.Add("discount");
                combofield_credit.Items.Add("incloud_taxes");
                combofield_credit.Items.Add("taxtes");
                combofield_credit.Items.Add("vat_add");
                combofield_credit.Items.Add("other");
            }
            else if (com.Text == "سند فاتوره مبيعات")
            {
                combofield_depit.Items.Clear();
                combofield_depit.Items.Add("tot_befor");
                combofield_depit.Items.Add("tot_after_dis");
                combofield_depit.Items.Add("discount");
                combofield_depit.Items.Add("incloud_taxes");
                combofield_depit.Items.Add("cost");
                combofield_depit.Items.Add("taxtes");
                combofield_depit.Items.Add("vat_add");
                combofield_depit.Items.Add("other");
                combofield_credit.Items.Clear();
                combofield_credit.Items.Add("tot_befor");
                combofield_credit.Items.Add("tot_after_dis");
                combofield_credit.Items.Add("discount");
                combofield_credit.Items.Add("incloud_taxes");
                combofield_credit.Items.Add("cost");
                combofield_credit.Items.Add("taxtes");
                combofield_credit.Items.Add("vat_add");
                combofield_credit.Items.Add("other");
            }
            else if (com.Text == "سند تحويل مخزني")
            {
                combofield_depit.Items.Clear();
                combofield_depit.Items.Add("tot_befor");
                combofield_depit.Items.Add("tot_after_dis");
                combofield_depit.Items.Add("cost");
                combofield_depit.Items.Add("discount");
                combofield_depit.Items.Add("incloud_taxes");
                combofield_depit.Items.Add("taxtes");
                combofield_depit.Items.Add("vat_add");
                combofield_depit.Items.Add("other");
                combofield_credit.Items.Clear();
                combofield_credit.Items.Add("tot_befor");
                combofield_credit.Items.Add("tot_after_dis");
                combofield_credit.Items.Add("cost");
                combofield_credit.Items.Add("discount");
                combofield_credit.Items.Add("incloud_taxes");
                combofield_credit.Items.Add("taxtes");
                combofield_credit.Items.Add("vat_add");
                combofield_credit.Items.Add("other");
            }
            else if (com.Text == "سند جرد")
            {
                combofield_depit.Items.Clear();
                combofield_depit.Items.Add("rev");
                combofield_depit.Items.Add("exp");
                combofield_credit.Items.Clear();
                combofield_credit.Items.Add("rev");
                combofield_credit.Items.Add("exp");
            }
            else if (com.Text == "سند قبض ")
            {
                combofield_depit.Items.Clear();
                combofield_depit.Items.Add("amount");
                combofield_credit.Items.Clear();
                combofield_credit.Items.Add("amount");
                label1.Visible = true;
                combo_depit.Visible = true;
                comb_depit_name.Visible = true;
                txt_depit_acc.Visible = true;
                txt_depit_acc.Visible = true;
                combofield_depit.Visible = true;
                btn_add_depit.Visible = true;
                label2.Visible = false;
                combo_credit.Visible = false;
                comb_credit_name.Visible = false;
                txt_credit_acc.Visible = false;
                txt_credit_acc.Visible = false;
                combofield_credit.Visible = false;
                btn_add_credit.Visible = false;
                combo_credit.Text = "0";
                comb_credit_name.Text = "0";
                txt_credit_acc.Text = "0";
                txt_credit_acc.Text = "0";
                combofield_credit.Text = "0";
                btn_add_credit.Text = "0";
            }
            //سند امر شغل نقل
            else if(com.Text == "سند امر شغل نقل")
            {
                combofield_depit.Items.Clear();
                combofield_depit.Items.Add("f1");
                combofield_depit.Items.Add("f2");
                combofield_depit.Items.Add("f3");
                combofield_depit.Items.Add("sum");
                combofield_depit.Items.Add("rev");
                combofield_depit.Items.Add("bon");
                combofield_depit.Items.Add("vat");


                combofield_credit.Items.Clear();
                combofield_credit.Items.Add("f1");
                combofield_credit.Items.Add("f2");
                combofield_credit.Items.Add("f3");
                combofield_credit.Items.Add("sum");
                combofield_credit.Items.Add("rev");
                combofield_credit.Items.Add("bon");
                combofield_credit.Items.Add("vat");

            }
            if (com.Text == "سند صرف مخزني")
            {
                combofield_depit.Items.Clear();
                combofield_depit.Items.Add("tot");
                //combofield_depit.Items.Add("tot_after_dis");
                //combofield_depit.Items.Add("discount");
                //combofield_depit.Items.Add("incloud_taxes");
                //combofield_depit.Items.Add("taxtes");
                //combofield_depit.Items.Add("vat_add");
                //combofield_depit.Items.Add("other");
                combofield_credit.Items.Clear();
                combofield_credit.Items.Add("tot");
                //combofield_credit.Items.Add("tot_after_dis");
                //combofield_credit.Items.Add("discount");
                //combofield_credit.Items.Add("incloud_taxes");
                //combofield_credit.Items.Add("taxtes");
                //combofield_credit.Items.Add("vat_add");
                //combofield_credit.Items.Add("other");
            }
            else if (com.Text == "سند توريد مخزني")
            {
                combofield_depit.Items.Clear();
                combofield_depit.Items.Add("tot");
                //combofield_depit.Items.Add("tot_after_dis");
                //combofield_depit.Items.Add("discount");
                //combofield_depit.Items.Add("incloud_taxes");
                //combofield_depit.Items.Add("taxtes");
                //combofield_depit.Items.Add("vat_add");
                //combofield_depit.Items.Add("other");
                combofield_credit.Items.Clear();
                combofield_credit.Items.Add("tot");
                //combofield_credit.Items.Add("tot_after_dis");
                //combofield_credit.Items.Add("discount");
                //combofield_credit.Items.Add("incloud_taxes");
                //combofield_credit.Items.Add("taxtes");
                //combofield_credit.Items.Add("vat_add");
                //combofield_credit.Items.Add("other");
            }
            else
            {
                if (!(com.Text == "سند دفع"))
                    return;
                combofield_depit.Items.Clear();
                combofield_depit.Items.Add("amount");
                combofield_credit.Items.Clear();
                combofield_credit.Items.Add("amount");
                label1.Visible = false;
                combo_depit.Visible = false;
                comb_depit_name.Visible = false;
                txt_depit_acc.Visible = false;
                txt_depit_acc.Visible = false;
                combofield_depit.Visible = false;
                btn_add_depit.Visible = false;
                combo_depit.Text = "0";
                comb_depit_name.Text = "0";
                txt_depit_acc.Text = "0";
                txt_depit_acc.Text = "0";
                combofield_depit.Text = "0";
                btn_add_depit.Text = "0";
                label2.Visible = true;
                combo_credit.Visible = true;
                comb_credit_name.Visible = true;
                txt_credit_acc.Visible = true;
                txt_credit_acc.Visible = true;
                combofield_credit.Visible = true;
                btn_add_credit.Visible = true;
            }
        }

        private void combo_depit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (combo_depit.Text == "حساب")
                {
                    comb_depit_name.Text = "";
                    txt_depit_acc.Text = "";
                    cls_book.load_from_chart_of_account(comb_depit_name);
                    txt_depit_acc.Text = db.GetData("select rootid from tree where rootname ='" + comb_depit_name.Text + "'").Rows[0][0].ToString();
                }
                else if (combo_depit.Text == "ذمم")
                {
                    comb_depit_name.Text = "select vcs_name from vcs where vcs_code=";
                    txt_depit_acc.Text = "select vcs_code from vcs where vcs_code=";
                }
                else
                {
                    lbl_accid_depit.Text = db.GetData("select acc_id from wares_acc where acc_name='" + combo_depit.Text + "'").Rows[0][0].ToString();
                    txt_depit_acc.Text = "select rootid from wares_acc where acc_id=" + lbl_accid_depit.Text + " and id_ware=";
                    comb_depit_name.Text = "select rootname from wares_acc where acc_id=" + lbl_accid_depit.Text + " and id_ware=";
                }
            }
            catch (Exception)
            {


            }
        }//select combo box depit

        private void combo_credit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (combo_credit.Text == "حساب")
                {
                    comb_credit_name.Text = "";
                    txt_credit_acc.Text = "";
                    cls_book.load_from_chart_of_account(comb_credit_name);
                    txt_credit_acc.Text = db.GetData("select rootid from tree where rootname ='" + comb_credit_name.Text + "'").Rows[0][0].ToString();
                }
                else if (combo_credit.Text == "ذمم")
                {
                    comb_credit_name.Text = "select vcs_name from vcs where vcs_code=";
                    txt_credit_acc.Text = "select vcs_code from vcs where vcs_code=";
                }
                else
                {
                    lbl_accidcredit.Text = db.GetData("select acc_id from wares_acc where acc_name='" + combo_credit.Text + "'").Rows[0][0].ToString();
                    txt_credit_acc.Text = "select rootid from wares_acc where acc_id=" + lbl_accidcredit.Text + " and id_ware=";
                    comb_credit_name.Text = "select rootname from wares_acc where acc_id=" + lbl_accidcredit.Text + " and id_ware=";
                }
            }
            catch (Exception)
            {


            }
        }//select combo box credit

        private void comb_depit_name_SelectedIndexChanged(object sender, EventArgs e)//select number account from tree
        {
            txt_depit_acc.Text = db.GetData("select RootID from tree where RootName='" + comb_depit_name.Text + "'").Rows[0][0].ToString();

        }

        private void comb_credit_name_SelectedIndexChanged(object sender, EventArgs e)//select number account from tree
        {
            txt_credit_acc.Text = db.GetData("select RootID from tree where RootName='" + comb_credit_name.Text + "'").Rows[0][0].ToString();

        }

        private void comb_bookname_entry_SelectedIndexChanged(object sender, EventArgs e)//book entry 
        {
            txt_code_entry.Text = db.GetData("select code_book from book where name_book='" + comb_bookname_entry.Text + "'").Rows[0][0].ToString();

        }

        private void terms_id_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            comb_bookname_entry.Text = db.GetData("select bookname_entry from term where term_id ='" + terms_id_combo.Text + "' and name_book ='" + combo_book_name.Text + "'").Rows[0][0].ToString();
            txt_code_entry.Text = db.GetData("select code_entry from term where term_id ='" + terms_id_combo.Text + "' and name_book ='" + combo_book_name.Text + "'").Rows[0][0].ToString();
            DataTable dt = new DataTable();
            db.GetData_DGV("select term_id,rootid,rootname,depit,credit,value,costcenter_id from term where term_id='" + terms_id_combo.Text + "' and name_book='" + combo_book_name.Text + "'", dt);
            dgv.DataSource = dt;
        }

        private void btn_add_depit_Click(object sender, EventArgs e)
        {
            if (edit == false)
            {
                if (terms_id_combo.Text == "" || combofield_depit.Text == "" || comb_depit_name.Text == "" || txt_depit_acc.Text == "")
                {
                    MessageBox.Show("field is Empty");
                }
                else
                {
                    string name_depit;

                    if (combo_depit.Text == "حساب")
                    {
                        name_depit = (combo_depit.Text + "  " + comb_depit_name.Text + " " + txt_depit_acc.Text);
                    }
                    else
                    {
                        name_depit = (combo_depit.Text);
                    }
                    //=======
                    dgv.Rows.Add(terms_id_combo.Text, txt_depit_acc.Text, comb_depit_name.Text, combofield_depit.Text, 0, name_depit);
                    combo_depit.Text = "";
                    txt_depit_acc.Text = "";
                    comb_depit_name.Text = "";
                    combofield_depit.Text = "";

                }
            }
            else { } 

        }

        private void btn_add_credit_Click(object sender, EventArgs e)
        {
            if (edit == false)
            {
                if (terms_id_combo.Text == "" || combofield_credit.Text == "" || comb_credit_name.Text == "" || txt_credit_acc.Text == "")
                {
                    MessageBox.Show("field is Empty");
                }
                else
                {
                    string name_credit;

                    if (combo_credit.Text == "حساب")
                    {
                        name_credit = (combo_credit.Text + "  " + comb_credit_name.Text + " " + txt_credit_acc.Text);
                    }
                    else
                    {
                        name_credit = (combo_credit.Text);
                    }

                    //=======
                    dgv.Rows.Add(terms_id_combo.Text, txt_credit_acc.Text, comb_credit_name.Text, 0, combofield_credit.Text, name_credit);
                    combo_credit.Text = "";
                    txt_credit_acc.Text = "";
                    comb_credit_name.Text = "";
                    combofield_credit.Text = "";
                }
            }
            else { }
        }

        private void btn_searsh_terms_Click(object sender, EventArgs e)
        {
            edit = true;
            if (edit == true)
            {
                if (com.Text != "")
                {
                    load_terms_id(terms_id_combo);
                    groupControl2.Visible = false;

                }
            }
        }

        private void _save_simpleButton1_Click(object sender, EventArgs e)
        {
            if (terms_id_combo.Text == "")
            {
                MessageBox.Show("ادخل كود الترم ");
            }
            else
            {
                if (edit == false)
                {
                    insert();
                    MessageBox.Show("save");
                }
                else
                {
                    db.Run("update term set bookname_entry ='" + comb_bookname_entry.Text + "' , code_entry ='" + txt_code_entry.Text + "' where term_id='" + terms_id_combo.Text + "' and name_book='" + combo_book_name.Text + "'");
                    MessageBox.Show("update");
                }
            }
        }

        private void _new_simpleButton3_Click(object sender, EventArgs e)
        {
            frm_type frm = new frm_type();
            Close();
            frm.Show();
        }
        private void _delete_simpleButton2_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("عايز تشيل من هنا!!؟؟؟؟ ", "رسال حذف مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                db.Run("delete from term where term_id ='" + terms_id_combo.Text + "' and name_book ='" + combo_book_name.Text + "'");
                Close();
                frm_type frm = new frm_type();
                frm.Show();
            }
        }

        //=-------------------------------------------fanction

        private void insert()
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                db.Run("insert into term(cat_book,	term_id	,code_book,	name_book	,rootid	,rootname	,depit	,credit,code_entry,bookname_entry,value,taxes,vat_add,vat_rate,costcenter_id) values ('" +
                                       com.Text + "','" + terms_id_combo.Text + "','" + txt_code_book.Text + "','" + combo_book_name.Text + "','" + dgv.Rows[i].Cells["rootid"].Value.ToString() + "','" + dgv.Rows[i].Cells["rootname"].Value.ToString() + "','" + dgv.Rows[i].Cells["depit"].Value.ToString() + "','" + dgv.Rows[i].Cells["credit"].Value.ToString() + "','" + txt_code_entry.Text + "','" + comb_bookname_entry.Text + "','" + dgv.Rows[i].Cells["value"].Value.ToString() + "','"+chk_taxes.Checked+"','"+chk_add_vat.Checked+"','"+ vat_rate.Text+ "','"+ dgv.Rows[i].Cells["costcenter_term"].Value+"" + "')");

                //db.Run("insert into term(cat_book,\tterm_id\t,code_book,\tname_book\t,rootid\t,rootname\t,depit\t,credit,code_entry,bookname_entry,value,taxes,vat_add,vat_rate) values ('" + (object)this.com.Text + "','" + this.terms_id_combo.Text + "','" + this.txt_code_book.Text + "','" + this.combo_book_name.Text + "','" + this.dgv.Rows[index].Cells["rootid"].Value.ToString() + "','" + this.dgv.Rows[index].Cells["rootname"].Value.ToString() + "','" + this.dgv.Rows[index].Cells["depit"].Value.ToString() + "','" + this.dgv.Rows[index].Cells["credit"].Value.ToString() + "','" + this.txt_code_entry.Text + "','" + this.comb_bookname_entry.Text + "','" + this.dgv.Rows[index].Cells["value"].Value.ToString() + "','" + (string)(object)(bool)(this.chk_taxes.Checked ? 1 : 0) + "','" + (string)(object)(bool)(this.chk_add_vat.Checked ? 1 : 0) + "','" + this.vat_rat.Text + "')");

            }

        }

        private void btn_costcenter_Click(object sender, EventArgs e)
        {
            try
            {
                dgv.CurrentRow.Cells["costcenter_term"].Value = combo_costcenter.Text;
                lbl_costcenter.Text = db.GetData("select  isnull(max(costcenter_id),0) from  costcenter where costcenter_name='" + combo_costcenter.Text + "'").Rows[0][0].ToString();
                dgv.CurrentRow.Cells["costcenter_term"].Value = lbl_costcenter.Text;
            }
            catch (Exception)
            {

              
            }
        }











        //================================================Navigation=====================


        // ----------------------------------------hotkeys







        //====================
    }
}