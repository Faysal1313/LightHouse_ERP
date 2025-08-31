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
    public partial class frm_tree : DevExpress.XtraEditors.XtraForm
    {
        public frm_tree()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
            db.Open();
            save_barButtonItem1.Enabled = true;
        //    btn_edit.Enabled = false;

        }
        private void frm_tree_Load(object sender, EventArgs e)
        {
            load();
            coler();
            
            if (combo_type.Text == "")
            {
                comb_parentname.Visible = false;
            }
            clear();
        }
        bool update = false;
        //functions--------------------------------------------------------------------------------------
        private void load()
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("select [RootID] ,[RootName]      ,[ParentID]      ,[Parentname]      ,[RootLevel]      ,[type_acc]      ,[sort]      ,[currance] from tree order by  Rootlevel", dt);
            dgv.DataSource = dt;
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    dgv.Rows.Add(dt.Rows[i][0]+"", dt.Rows[i][1] + "", dt.Rows[i][2] + "", dt.Rows[i][3] + "", dt.Rows[i][4], dt.Rows[i][5] , dt.Rows[i][6] , dt.Rows[i][7]);
            //}
         //   btn_edit.Visible = true;
            all_comb.load_curracne(combo_currence);
        }
        private void clear()
        {
            txt_rootid.Text = "";
            txt_rootname.Text = "";
            txt_parentid.Text = "";
            comb_parentname.Text = "";
            combo_type.Text = "";
            comb_sort.Text = "";
            txt_name_long.Text = "";
            group_edit.Visible = false;
            //  load();

        }
        private void parent()
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("select rootname ,Rootid,rootlevel from tree where type_acc='f' or type_acc='g' order by rootlevel  ", dt);
            comb_parentname.DataSource = dt;
            comb_parentname.DisplayMember = "rootname";
            comb_parentname.ValueMember = "Rootid";
        }
        private void coler()
        {

        //            1 - محجوز
            //2 - مسكون
//3 - متاح
//4 - مغادرة


            try
            {
                dgv.Rows[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#b3b8ba");
                foreach (DataGridViewRow i in dgv.Rows)
                {
                    if (i.Cells[5].Value.ToString() == "g")
                    {
                        i.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#b3b8ba");
                    }
                    else if (i.Cells[5].Value.ToString() == "f")
                    {
                        i.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#3e8ead");
                    }
                    else if (i.Cells[5].Value.ToString() == "c")
                    {
                        // i.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#e1e8ed");
                        i.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#fcfeff");

                    }
                    else if (i.Cells[5].Value.ToString() == "sc")
                    {
                        i.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#bad2e3");
                    }
                }
            }
            catch (Exception)
            {


            }

        }
        private void delete()
        {
            //if havent balance 
            DataTable dt_wares_Acc = new DataTable();
            DataTable dt_depit = new DataTable();
            DataTable dt_credit = new DataTable();
            DataTable dt_f = new DataTable();
            DataTable dt_vcs = new DataTable();
            db.GetData_DGV("select depit from entry where acc_num='" + dgv.CurrentRow.Cells[0].Value.ToString() + "' and depit >0", dt_depit);
            db.GetData_DGV("select credit from entry where acc_num='" + dgv.CurrentRow.Cells[0].Value.ToString() + "' and depit >0", dt_credit);
            db.GetData_DGV("select rootid from wares_acc where rootid='" + dgv.CurrentRow.Cells[0].Value.ToString() + "'", dt_wares_Acc);
            db.GetData_DGV("select ParentID from tree where ParentID='" + dgv.CurrentRow.Cells[0].Value.ToString() + "' and type_acc ='f'", dt_f);
            db.GetData_DGV("select rootlevel from vcs where rootlevel='" + lbl_rootlevel_selction.Text + "'", dt_vcs);
            

            if (dt_depit.Rows.Count > 0 || dt_credit.Rows.Count > 0)
            {
                MessageBox.Show("الحساب عليه حركات لا يمكن حذفه");
            }
            //if haven't acc in ware acc or terms 
            else if (dt_wares_Acc.Rows.Count > 0)
            {
                MessageBox.Show("الحساب عليه حركات لا يمكن حذفه مربوط بالمخازن");
            }
            else if (dt_f.Rows.Count > 0)
            {
                MessageBox.Show("الحساب تحت منه حسابات لايمكن حذف");
            }
            else if (dt_vcs.Rows.Count >0)
            {
                MessageBox.Show("الحساب تحت مربوط بعملاء او موردين لا يمكن حذفه");
                
            }
            else
            {
                db.Run("delete from tree where rootid='" + dgv.CurrentRow.Cells[0].Value.ToString() + "'");
                db.Run("delete from entry where acc_num='" + dgv.CurrentRow.Cells[0].Value.ToString() + "' and code_entry='-11'");
                db.action_delete("تم حذف الحساب رقم " + dgv.CurrentRow.Cells[0].Value + "",""+ dgv.CurrentRow.Cells[0].Value.ToString() +"");
                MessageBox.Show("delete");

            }
        }
       
      
//combobox============================================
        private void combo_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_type.Text == "g")
            {
                txt_parentid.Text = "0";
                lbl_rootname.Text = "0";
                comb_parentname.Visible = false;
                lbl_name_type.Text = "حساب رئيسي";
                lbl_name_type_desc.Text = "الحساب \nهو حساب رئيسي ولايمكن إضافة حساب اعلي منة ويكون في الغالب مثل حساب الاصول او الخصوم او حقوق المليكة او المصروفات";

            }
            else if (combo_type.Text == "") { lbl_name_type.Text = ""; lbl_name_type_desc.Text = ""; }

            else if (combo_type.Text == "f")
            {
                parent();
                comb_parentname.Visible = true;
                lbl_name_type.Text = "حساب ثانوي";
                lbl_name_type_desc.Text = "ثانوي\nالحساب الثانوي هو حساب يتفرع من الحساب الرئيسي ويكون في المرتبة الثانية بعد الرئيسي ويكون مثل الاصول المتداولة او الاصول الثابتة";

            }
            else if (combo_type.Text == "c")
            {
                comb_parentname.Visible = true;
                DataTable dt = new DataTable();
                dt.Rows.Clear();
                db.GetData_DGV("select rootname ,Rootid,rootlevel from tree where type_acc='f'  order by rootlevel  ", dt);
                comb_parentname.DataSource = dt;
                comb_parentname.DisplayMember = "rootname";
                comb_parentname.ValueMember = "Rootid";
                lbl_name_type.Text = "حساب الاخير";
                lbl_name_type_desc.Text = "اخير\nحساب الاخير هو الحساب المتفرع من الثانوي وهو حساب يمكن إجراء علية قيود ويكون مثل ح الخزنة او ح مصروفات مكتبية";

            }
            else if (combo_type.Text == "sc")
            {
                comb_parentname.Visible = true;
                DataTable dt = new DataTable();
                dt.Rows.Clear();
                db.GetData_DGV("select rootname ,Rootid,rootlevel from tree where type_acc='f'  order by rootlevel  ", dt);
                comb_parentname.DataSource = dt;

                comb_parentname.DisplayMember = "rootname";
                comb_parentname.ValueMember = "Rootid";
                lbl_name_type.Text = "حساب تحيليل الاخير";
                lbl_name_type_desc.Text = "حساب اخير تحليلي\nالحساب الاخير تحليلي هو نفس طبيعة الحساب الاخير ولاكن يختلف عنه في انة يحتوي علي اكواد العملاء او اكواد الموردين حيث انة يتم بطة من خلال تكويد عميل او مورد";

            }
        }
        private void comb_parentname_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //label5.Text = comb_parentid.SelectedValue + "";
                txt_parentid.Text = comb_parentname.SelectedValue + "";
                //  label6.Text = comb_parentid.Text + "";
                lbl_rootname.Text = db.GetData("select rootlevel from tree where rootid='" + txt_parentid.Text + "'").Rows[0][0].ToString();
                // lbl_rootlevel_selction.Text = lbl_rootname.Text;
            }
            catch (Exception)
            {
            }
        }
//dgv controls >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                txt_rootid.Text = dgv.CurrentRow.Cells["RootID_"].Value+"";
                txt_rootname.Text = dgv.CurrentRow.Cells["RootName_"].Value+"";
                txt_parentid.Text = dgv.CurrentRow.Cells["ParentID_"].Value+"";
                comb_parentname.Text = dgv.CurrentRow.Cells["Parentname_"].Value+"";
                lbl_rootlevel_selction.Text = dgv.CurrentRow.Cells["RootLevel_"].Value+"";
                combo_type.Text = dgv.CurrentRow.Cells["type_acc_"].Value+"";
                comb_sort.Text = dgv.CurrentRow.Cells["sort_"].Value+"";
                combo_currence.Text = dgv.CurrentRow.Cells["curracne_c"].Value+"";
                txt_name_long.Text = db.GetData("select isnull(max(name_long),'-') from tree where RootID='" + txt_rootid.Text+"' ").Rows[0][0] + "";
                update = true;

            }

        }
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            save_barButtonItem1.Enabled = false;


        }
 
        //--------------------------------------------------------------------------------------------------------------
        private void save_barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (combo_currence.Text=="")
            {
                return;
            }
            coler();
            string conc = lbl_rootname.Text + txt_rootid.Text;
          //  if (update == false)
            {
                if (db.GetData("select isnull(max(rootid),0) from tree where rootid='"+txt_rootid.Text+"'").Rows[0][0].ToString()!="0")
                {
                    MessageBox.Show("كود الحساب موجود من قبل");
                    return;
                }
                if (txt_rootid.Text != "" && txt_rootname.Text != "" && txt_parentid.Text != "" && comb_sort.Text != "" && combo_type.Text != "")
                {
                    db.action_insert("تم إضافة حساب " + txt_rootid.Text + "", "" + txt_rootid.Text + "");

                    //tree table
                    db.Run("insert into tree (Rootid,rootname,parentid,parentname,rootlevel,type_acc,sort,currance,name_long,visable,costcenter) values('" + txt_rootid.Text + "','" + txt_rootname.Text + "','" + txt_parentid.Text + "','" + comb_parentname.Text + "','" + conc + "','" + combo_type.Text + "','" + comb_sort.Text + "','"+ combo_currence.Text+"','"+txt_name_long.Text+"','0','0')");
                    //entery table
                    db.Run("insert into entry (code_entry,acc_num,acc_name ,rootlevel,type_acc,sort) values ('-11','" + txt_rootid.Text + "','" + txt_rootname.Text + "','" + conc + "','" + comb_sort.Text + "','" + combo_type.Text + "')");


                  //  db.action_delete("تم حذف الحساب رقم " + dgv.CurrentRow.Cells[0].Value + "", "" + dgv.CurrentRow.Cells[0].Value.ToString() + "");


                    // clear();
                    load();
                    MessageBox.Show("save");
                    // update = true;
                    save_barButtonItem1.Enabled = false;
                }
                else
                {
                    MessageBox.Show("not save because empty filed");
                }

            }
            //else
            //{
            //    // db.Run("update tree set rootid='" + txt_rootid.Text + "',rootlevel='"+lbl_rootlevel_selction.Text+txt_parentid.Text+"' where rootname='" + dgv.CurrentRow.Cells[1].Value.ToString() + "'");
            //    //// db.Run("update tree set rootname='" + txt_rootname.Text + "' where rootid ='" + dgv.CurrentRow.Cells[0].Value.ToString() + "'");
            //    //db.Run("update tree set parentid='" + txt_parentid.Text + "'where rootid ='" + dgv.CurrentRow.Cells[0].Value.ToString() + "'");
            //    //db.Run("update tree set parentname='" + comb_parentname.Text + "'where rootid ='" + dgv.CurrentRow.Cells[0].Value.ToString() + "'");
            //    //db.Run("update tree set sort='" + comb_sort.Text + "'where rootid ='" + dgv.CurrentRow.Cells[0].Value.ToString() + "'");
            //    ////db.Run("update tree set type_acc='" + combo_type.Text + "'where rootid ='" + dgv.CurrentRow.Cells[0].Value.ToString() + "'");

            //    load();

            //    MessageBox.Show("update");
            //}
        }
        private void new_barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            load();
            clear();
            update = false;
            coler();
            save_barButtonItem1.Enabled = true;
            //btn_edit.Enabled = true;
            btn_edit_currency.Enabled = true;

        }
        private void delete_barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dr;
            dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "عايز تشيل  من هنا!!؟؟؟؟ ", "رسال حذف حساب", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);


            if (dr == DialogResult.OK)
            {
                delete();

            }

            load();
            clear();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (txt_rootid.Text=="")
            {
                return;
            }
            DialogResult dr;
            dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "سيتم التعديل علي اسم الحساب  ", "رسال تعديل مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                string code = dgv.CurrentRow.Cells[0].Value + "";
                db.Run("update tree set RootName='" + txt_rootname.Text + "', name_long='" + txt_name_long.Text+"' where RootID='" + code + "'");
                db.Run("update entry set acc_name='" + txt_rootname.Text + "' where acc_num='" + code + "'");
                load();
                clear();
                update = false;
                coler();
                save_barButtonItem1.Enabled = true;
            }


        }

        private void btn_edit_currency_Click(object sender, EventArgs e)
        {
            if (txt_rootid.Text == "")
            {
                return;
            }
            if (Convert.ToDouble(db.GetData("select isnull(sum(depit),0) from entry where acc_num='" + txt_rootid.Text+"'").Rows[0][0]+"")!=0)
            {
                return;
            }
            DialogResult dr;
            dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "سيتم التعديل علي عملة الحساب  ", "رسال تعديل مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                string code = dgv.CurrentRow.Cells[0].Value + "";
                db.Run("update tree set currance='" + combo_currence.Text + "' where RootID='" + code+ "'");
                db.Run("update entry set currance='" + combo_currence.Text + "' where acc_num='" + code + "'");
                load();
                clear();
                update = false;
                coler();
                save_barButtonItem1.Enabled = true;
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 0)
            {
                group_add_account.Visible = true;
                txt_code_add_account.Text = dgv.CurrentRow.Cells[0].Value + "";
                // dgv.Rows.RemoveAt(e.RowIndex);
            }
            if (e.ColumnIndex != 0)
            {
                group_edit.Visible = true;
                txt_root.Text = dgv.CurrentRow.Cells[0].Value + "";
                txt_name.Text = dgv.CurrentRow.Cells[1].Value + "";
                lbl_costcenter.Text = db.GetData("select costcenter from tree where RootID='"+ dgv.CurrentRow.Cells[0].Value +""+ "'").Rows[0][0] + "";
                if (lbl_costcenter.Text=="0")
                {
                    combo.Text = "مسموح بة";
                }
                else if(lbl_costcenter.Text == "1")
                {
                    combo.Text = "اجباري";

                }
                else
                {
                    combo.Text = "غير مسموح بة";

                }

                chk.Checked = Convert.ToBoolean(db.GetData("select [visable] from tree where RootID='" + txt_root.Text + "'").Rows[0][0] + "");

            }
        }

        private void btn_group_close_Click(object sender, EventArgs e)
        {
            group_edit.Visible = false;

        }

        private void btn_edit_group_edit_Click(object sender, EventArgs e)
        {
            if (txt_root.Text == "")
            {
                return;
            }
            //DialogResult dr;
            //dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "سيتم التعديل علي اسم الحساب  ", "رسال تعديل مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            //if (dr == DialogResult.OK)
            {
                string code = dgv.CurrentRow.Cells[0].Value + "";
                db.Run("update tree set RootName='" + txt_name.Text + "', [visable]='"+chk.Checked+ "',costcenter='" + lbl_costcenter.Text+"' where RootID='" + code + "'");
                db.Run("update entry set acc_name='" + txt_name.Text + "' where acc_num='" + code + "'");
                group_edit.Visible = false;
                //load();
                //clear();
                //update = false;
                //coler();
                //save_barButtonItem1.Enabled = true;
            }

        }
        //=================================================
        private void btn_add_account_save_Click(object sender, EventArgs e)
        {

            string id = txt_code_add_account.Text;
            string rootId = db.GetData("select isnull(max(RootID+1),0) from tree where RootID = '"+ id + "' and type_acc = 'c'").Rows[0][0] + "";
            string Parentname = db.GetData("select Parentname from tree where RootID = '"+ id + "'").Rows[0][0] + ""; ;
            string ParentID = db.GetData("select ParentID from tree where RootID = '"+ id + "'").Rows[0][0] + "";
            string sort = db.GetData("select sort from tree where RootID='"+ id + "'").Rows[0][0] + "";
            string type_acc = db.GetData("select type_acc from tree where RootID='"+ id + "'").Rows[0][0] + "";
            string RootLevel = db.GetData("select RootLevel from tree where RootID='"+ id + "'").Rows[0][0] + "";

            string conc = RootLevel + rootId;
            if (rootId == "0")
            {
                MessageBox.Show("يجب ان يكون نوع الحساب فرعي اخير");
                return;
            }
            if (db.GetData("select isnull(max(rootid),0) from tree where rootid='" + rootId + "'").Rows[0][0].ToString() != "0")
            {
                MessageBox.Show("كود الحساب موجود من قبل");
                return;
            }
            if (rootId != "" && name_add_account.Text != "" && ParentID != "" && sort != "" && type_acc != "")

            {
                db.action_insert("تم إضافة حساب " + rootId + "", "" + txt_rootid.Text + "");

                //tree table
                db.Run("insert into tree (Rootid,rootname,parentid,parentname,rootlevel,type_acc,sort,currance,name_long,visable,costcenter) values('" + rootId + "','" + name_add_account.Text + "','" + ParentID + "','" + Parentname + "','" + conc + "','" + type_acc + "','" + sort + "','" + combo_currence.Text + "','" + txt_name_long.Text + "','0','0')");
                //entery table
                db.Run("insert into entry (code_entry,acc_num,acc_name ,rootlevel,type_acc,sort) values ('-11','" + rootId + "','" + name_add_account.Text + "','" + conc + "','" + sort + "','" + type_acc + "')");


                //  db.action_delete("تم حذف الحساب رقم " + dgv.CurrentRow.Cells[0].Value + "", "" + dgv.CurrentRow.Cells[0].Value.ToString() + "");


                // clear();
                load();
                MessageBox.Show("save");
                // update = true;
                save_barButtonItem1.Enabled = false;
             
            }
            id = "";
            rootId = "";
            Parentname = "";
            ParentID = "";
            sort = "";
            type_acc = "";
            RootLevel = "";
            conc = "";
            group_add_account.Visible = false;

        }

        private void btn_add_account_close_Click(object sender, EventArgs e)
        {
            group_add_account.Visible = false;

        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\tree_acc.repx", true);
            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);

        }

      
        private void combo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (combo.Text == "مسموح بة ")
            {
               lbl_costcenter.Text="0";
            }
            else if (combo.Text == "اجباري ")
            {
                lbl_costcenter.Text = "1";
            }
            else
            {
                lbl_costcenter.Text = "2";

            }
        }

        //test===========================================


    }
}