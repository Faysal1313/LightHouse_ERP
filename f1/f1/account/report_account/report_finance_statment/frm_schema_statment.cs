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

namespace f1.account.report_account.report_finance_statment
{
    public partial class frm_schema_statment : DevExpress.XtraEditors.XtraForm
    {
        public frm_schema_statment()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
            db.Open();
        }
        bool edit = false;
        private void dgv_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            Classes.command.LoadSerial(dgv, "no");
        }
        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // account.report_account.report_finance_statment.frm_schema_statment 
            Classes.command.LoadSerial(dgv, "no");
        }
        private void btn_add_account_Click(object sender, EventArgs e)
        {
            dgv.Rows.Add("");
        }
        public static string auto_no()
        {
            string str = db.GetData("select isnull(max((id)+1),0) from statment").Rows[0][0].ToString();
            if (str == "0")
                str = "10";
            return str;
        }
        private void clear()
        {
            dgv.Rows.Clear();
            auto_no();
            dgv_code.Rows.Clear();
            dgv_sum.Rows.Clear();
            group_plue_mins.Visible = false;
            combo_id.Text = "";
            txt_name.Text = "";
        }
      
        private void frm_schema_statment_Load(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            db.GetData_DGV("select RootID,rootname,type_acc,sort,'' as b1 , '' as b2 from tree order by RootLevel", dt);
            dgv_tree.DataSource = dt;
            lbl_id.Text = auto_no();
            coler();

        }


        private void calc_eButton1_Click(object sender, EventArgs e)
        {
            string id_ = "";
            if (dgv.Rows.Count == 0) return;
          //  dgv_code.Rows.Clear();
            if (edit == true)
            {
                id_ = combo_id.Text;
               // load_code(id_);
                //dgv_code.Rows.Clear();

            }
            else
            {
                id_ = lbl_id.Text;
                dgv_code.Rows.Clear();

            }
            db.Run("delete from statment where id='" + id_ + "' and plues='0' or mins='0'");

            for (int i = 0; i < dgv_code.Rows.Count; i++)
            {
                string c1 = ""; string c2 = "";
                c1 = dgv_code.Rows[i].Cells[1].Value+"";  c2 = dgv_code.Rows[i].Cells[2].Value+"";
                if (c1 == "") c1 = "0";                             if (c2 == "") c2 = "0"; 
                db.Run("INSERT INTO statment([id],[no],[plues],[mins])values('"+id_+"','" + dgv_code.Rows[i].Cells[0].Value + "','" + c1 + "','" + c2 + "')");
            }

            //get calc
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                string s1 = dgv.Rows[i].Cells["s1"].Value+"";
                string s2= dgv.Rows[i].Cells["s2"].Value + "";
                string p1 = dgv.Rows[i].Cells["p1"].Value + "";
                string p2 = dgv.Rows[i].Cells["p2"].Value + "";

                dgv.Rows[i].Cells["s_tot"].Value = db.GetData("select isnull((SUM(depit)-SUM(credit)),0) from entry where code_entry <> '-11'and rootlevel_name='0'and acc_num between '" + s1+"' and '"+s2+"'").Rows[0][0].ToString();
                dgv.Rows[i].Cells["p_tot"].Value = db.GetData("select isnull((SUM(depit)),0) from entry where code_entry <> '-11'and rootlevel_name='0'and acc_num between '" + p1+"' and '"+p2+"'").Rows[0][0].ToString();
                
                bool isIntString = s1.All(char.IsDigit);
                if (!isIntString)
                {
                    dgv.Rows[i].Cells["s_tot"].Value = db.GetData("select SUM(depit)-sum(credit) from entry where code_entry <> '-11'and rootlevel_name between '" + s1 + "' and '" + s2 + "'").Rows[0][0].ToString();
                }

            }

            //1) get table plues and mins  
            for (int x = 0; x < dgv_code.Rows.Count; x++)
            {
                string ac =dgv_code.Rows[x].Cells[0].Value+"";

                DataTable dt = new DataTable();
                db.GetData_DGV("select plues,mins from statment where no='"+ac+"' and id='"+lbl_id.Text+"' and plues<>''", dt);
                double sum = 0;
                double min = 0;
                //start load table code to calc
               
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //cheak if rootid is sc or not 
                    if (db.GetData("select ISNULL( max(type_acc),0) from tree where RootID='" + dt.Rows[i][0].ToString() + "'").Rows[0][0].ToString().Trim()=="sc" || db.GetData("select ISNULL( max(type_acc),0) from tree where RootID='" + dt.Rows[i][1].ToString() + "'").Rows[0][0].ToString().Trim() == "sc")
                    {
                        string Get_rootname_add = db.GetData("select ISNULL( max(RootName),0) from tree where RootID='" + dt.Rows[i][0].ToString() + "'").Rows[0][0].ToString().Trim();
                        string Get_rootname_min = db.GetData("select ISNULL( max(RootName),0) from tree where RootID='" + dt.Rows[i][1].ToString() + "'").Rows[0][0].ToString().Trim();

                        sum += Convert.ToDouble(db.GetData("select isnull((SUM(depit)-SUM(credit)),0) from entry where rootlevel_name='"+Get_rootname_add+"'").Rows[0][0].ToString());
                        min += Convert.ToDouble(db.GetData("select isnull((SUM(depit)-SUM(credit)),0) from entry where rootlevel_name='" + Get_rootname_min + "'").Rows[0][0].ToString());
                    }
                    else
                    {
                        sum += Convert.ToDouble(db.GetData("select isnull((SUM(depit)-SUM(credit)),0) from entry where acc_num='" + dt.Rows[i][0].ToString() + "'").Rows[0][0].ToString());
                        min += Convert.ToDouble(db.GetData("select isnull((SUM(depit)-SUM(credit)),0) from entry where acc_num='" + dt.Rows[i][1].ToString() + "'").Rows[0][0].ToString());
                    }
                }

                //3-end result of all code
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if (dgv.Rows[i].Cells[0].Value+""==ac)
                    {
                        dgv.Rows[i].Cells["p_tot"].Value =Convert.ToDouble(dgv.Rows[i].Cells["p_tot"].Value)+ sum - min;
                    }
                }
            }
            group_plue_mins.Visible = false;
           
        }
        private void insert_tton2_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count == 0) return;
            if (lbl_id.Text == "") return;
            if (txt_name.Text == "")
            {
                MessageBox.Show("يجب اختيرا اسم للقائمة ");
                return;
            }
            if (edit == true)
            {
                db.Run("delete from statment where id='" + lbl_id.Text + "'");
                // clear();
                //return;
            }
            if (edit == false)
            {
                lbl_id.Text = auto_no();

            }
            else
            {
                lbl_id.Text = combo_id.Text;
            }
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                db.Run("INSERT INTO statment([no],[name_acc],[s1],[s2],[p1],[p2],[id] ,[name_statmen],[s_tot],[p_tot],level)VALUES ('" +
                                                  dgv.Rows[i].Cells["no"].Value + "','" + dgv.Rows[i].Cells["name_acc"].Value + "','" + dgv.Rows[i].Cells["s1"].Value + "','" + dgv.Rows[i].Cells["s2"].Value + "','" + dgv.Rows[i].Cells["p1"].Value + "','" + dgv.Rows[i].Cells["p2"].Value + "','" + lbl_id.Text + "','" + txt_name.Text + "','" + dgv.Rows[i].Cells["s_tot"].Value + "','" + dgv.Rows[i].Cells["p_tot"].Value + "','" + dgv.Rows[i].Cells["level"].Value + "')");
            }
            for (int i = 0; i < dgv_code.Rows.Count; i++)
            {
                db.Run("INSERT INTO statment([no],[plues],[mins])values('" + dgv_code.Rows[i].Cells[0].Value + "','" + dgv_code.Rows[i].Cells[1].Value + "','" + dgv_code.Rows[i].Cells[2].Value + "')");
            }
            MessageBox.Show("save");



        }

        private void dgv_tree_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.ColumnIndex + "");

            try
            {
                if (dgv.Rows.Count == 0) return;

                string s1 = dgv.CurrentRow.Cells["s1"].Value + "";
                string s2 = dgv.CurrentRow.Cells["s2"].Value + "";

                bool isIntString = s1.All(char.IsDigit);
                bool isIntString2 = s2.All(char.IsDigit);

                if (e.ColumnIndex == 4)
                {
                    if (dgv_tree.CurrentRow.Cells["type_acc"].Value + "" == "g")
                    {
                        MessageBox.Show("يجب اختيرا حساب تفصيلي ولا يجب اختيرا حساب رئيسي ");
                        return;
                    }
                    else if (dgv_tree.CurrentRow.Cells["type_acc"].Value + "" == "f")
                    {
                        MessageBox.Show("يجب اختيرا حساب تفصيلي ولا يجب اختيرا حساب الاب");
                        return;
                    }
                    else if (dgv_tree.CurrentRow.Cells["type_acc"].Value + "" == "sc")
                    {
                        MessageBox.Show("يجب اختيرا حساب تفصيلي ولا يجب اختيار حساب تحليل تفصيلي");
                        return;
                    }
                    else if (!isIntString)
                    {
                        MessageBox.Show(" لا يجب اختيار علي حساب التحليلي");
                        return;

                    }
                    else
                    {
                        dgv.CurrentRow.Cells["s1"].Value = dgv_tree.CurrentRow.Cells["RootID"].Value + "";
                    }

                }
                if (e.ColumnIndex == 5)

                {
                    if (dgv_tree.CurrentRow.Cells["type_acc"].Value + "" == "g")
                    {
                        MessageBox.Show("يجب اختيرا حساب تفصيلي ولا يجب اختيرا حساب رئيسي ");
                        return;
                    }
                    else if (dgv_tree.CurrentRow.Cells["type_acc"].Value + "" == "f")
                    {
                        MessageBox.Show("يجب اختيرا حساب تفصيلي ولا يجب اختيرا حساب الاب");
                        return;
                    }
                    else if (dgv_tree.CurrentRow.Cells["type_acc"].Value + "" == "sc")
                    {
                        MessageBox.Show("يجب اختيرا حساب تفصيلي ولا يجب اختيار حساب تحليل تفصيلي");
                        return;
                    }
                    else if (!isIntString2)
                    {
                        MessageBox.Show(" لا يجب اختيار علي حساب التحليلي");
                        return;

                    }
                    else
                    {
                        dgv.CurrentRow.Cells["s2"].Value = dgv_tree.CurrentRow.Cells["RootID"].Value + "";
                    }


                }
            }
            catch (Exception)
            {
            }
        }

        private void dgv_tree_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                if (dgv.Rows.Count == 0) return;
                if (e.ColumnIndex == 1)
                {
                    string rootname = db.GetData("select type_acc from tree where rootid='" + dgv_tree.CurrentRow.Cells["rootid"].Value + "'").Rows[0][0].ToString().Trim();
                    if (rootname=="c")
                    {
                        dgv.CurrentRow.Cells["name_acc"].Value = dgv_tree.CurrentRow.Cells["rootname"].Value + "";
                        dgv.CurrentRow.Cells["s1"].Value = dgv_tree.CurrentRow.Cells["RootID"].Value + "";
                        dgv.CurrentRow.Cells["s2"].Value = dgv_tree.CurrentRow.Cells["RootID"].Value + "";

                    }
                    else if (rootname == "sc")
                    {
                        dgv.CurrentRow.Cells["name_acc"].Value = dgv_tree.CurrentRow.Cells["rootname"].Value + "";
                        dgv.CurrentRow.Cells["s1"].Value = dgv_tree.CurrentRow.Cells["rootname"].Value + "";
                        dgv.CurrentRow.Cells["s2"].Value = dgv_tree.CurrentRow.Cells["rootname"].Value + "";

                    }
                    else
                    {
                        dgv.CurrentRow.Cells["name_acc"].Value = dgv_tree.CurrentRow.Cells["rootname"].Value + "";
                        dgv.CurrentRow.Cells["p1"].Value = dgv_tree.CurrentRow.Cells["RootID"].Value + "";
                        dgv.CurrentRow.Cells["p2"].Value = dgv_tree.CurrentRow.Cells["RootID"].Value + "";
                    }
                }
            }
            catch (Exception)
            {
            }
        }


        private void btn_del_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count == 0) return;

            //if (lbl_id.Text == 0) return;
            DialogResult dr;
            dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "هل تريد حذف السند!!؟؟؟؟ ", "رسال حذف مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);


            if (dr == DialogResult.OK)
            {
                db.Run("delete from statment where id='" + lbl_id.Text + "'");
                clear();
                edit = false;
            }

        }

        private void id_Leave(object sender, EventArgs e)
        {
            
        }
        private void load (string id)
        {

            try
            {
                dgv_code.Rows.Clear();
                dgv_sum.Rows.Clear();
                DataTable dt1 = new DataTable();
                db.GetData_DGV("select [no],plues,mins from statment where id='" + id + "' and plues <> '' OR mins <>''", dt1);
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    dgv_code.Rows.Add(dt1.Rows[i][0] + "", dt1.Rows[i][1] + "", dt1.Rows[i][2] + "");
                }

                DataTable dt = new DataTable();
                db.GetData_DGV(" select [no],[name_acc],[s1] ,[s2],[p1],[p2],s_tot,p_tot,level from statment where [ID]='" + id + "' and name_acc <>''", dt);
                // dgv.DataSource = dt;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgv.Rows.Add("", dt.Rows[i][1] + "", dt.Rows[i][2] + "", dt.Rows[i][3] + "", dt.Rows[i][4] + "", dt.Rows[i][5] + "", dt.Rows[i][6] + "", dt.Rows[i][7] + "", dt.Rows[i][8] + "");
                }
                
                lbl_id.Text = db.GetData("select [id] from statment where [id] ='" + id + "'").Rows[0][0].ToString();
                txt_name.Text = db.GetData("select name_statmen from statment where [id]='" + lbl_id.Text + "' ").Rows[0][0].ToString();
                

               

            }
            catch (Exception ex)
            {
             //   MessageBox.Show(ex.Message);

            }
        }

        private void load_code(string id)
        {
           // string id = "101";
            DataTable dt1 = new DataTable();
            db.GetData_DGV("select [no],plues,mins from statment where id='" + id + "' and plues <> '' OR mins <>''", dt1);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                dgv_code.Rows.Add(dt1.Rows[i][0] + "", dt1.Rows[i][1] + "", dt1.Rows[i][2] + "");
            }


        }
        private void btn_search_items_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                DialogResult dr;
                dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "سيتم حذف كل التعديلات هل تود الحذف!!؟؟؟؟ ", "رسال تنبية", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (dr == DialogResult.OK)
                {
                    lbl_id.Text = auto_no();
                    dgv_code.Rows.Clear();
                    all_comb.load_no_statment(combo_id);
                    // combo_id.Text = "";
                    dgv_code.Rows.Clear();
                    dgv.Rows.Clear();
                    txt_name.Text = "";
                }
            }
            else
            {
                lbl_id.Text = auto_no();
                dgv_code.Rows.Clear();
                all_comb.load_no_statment(combo_id);
                // combo_id.Text = "";
                dgv_code.Rows.Clear();
                dgv.Rows.Clear();
                txt_name.Text = "";
            }
        }

        private void btn_preview_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count == 0) return;
            XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\statment_templet.repx", true);
            xtraReport.Parameters["parameter1"].Value = lbl_id.Text;
            xtraReport.Parameters["parameter1"].Visible = false;
            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);

        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            group_plue_mins.Visible = true;
            group_plue_mins.Text = dgv.CurrentRow.Cells[0].Value+"";
            DataTable dt = new DataTable();
            db.GetData_DGV("select plues,mins from statment where id='" + combo_id.Text+"'   and [no] ='"+dgv.CurrentRow.Cells[0].Value+"'",dt);
            //if (dt.Rows.Count == 0) return;
            // if (dt.Rows[0][0]+"" =="") return;

            try
            {
                for (int i = 0; i < dgv_sum.Rows.Count; i++)
                {
                    dgv_sum.Rows.Add(dt.Rows[i][0] + "", dt.Rows[i][1] + "");
                }

            }
            catch (Exception)
            {
            }
        }

        private void add_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < dgv_sum.Rows.Count-1; i++)
            {
                dgv_code.Rows.Add(group_plue_mins.Text,dgv_sum.Rows[i].Cells[0].Value, dgv_sum.Rows[i].Cells[1].Value);
            }
            dgv_sum.Rows.Clear();
            group_plue_mins.Visible = false;

        }

        private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = true;

        }

        private void dgv_code_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = true;

        }

        private void dgv_sum_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = true;

        }

       

        private void dgv_sum_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToDouble(dgv_sum.CurrentRow.Cells[0].Value) > 0)
            {
                dgv_sum.CurrentRow.Cells[1].Value = 0;
            }
            if (Convert.ToDouble(dgv_sum.CurrentRow.Cells[1].Value) > 0)
            {
                dgv_sum.CurrentRow.Cells[0].Value = 0;
            }
        }

        private void btn_pending_close_Click(object sender, EventArgs e)
        {
            group_plue_mins.Visible = false;
            dgv_sum.Rows.Clear();
        }

        private void combo_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            {
                lbl_id.Text = combo_id.Text;
                dgv.Rows.Clear();
                dgv_code.Rows.Clear();
                dgv_sum.Rows.Clear();
                load(combo_id.Text);
                txt_name.Text = db.GetData("select isnull(max([name_statmen]),0) from statment where [ID]='"+combo_id.Text+"'").Rows[0][0].ToString();
                //dgv.Rows.Clear();
                //dgv_code.Rows.Clear();
                //dgv_sum.Rows.Clear();
                //txt_name.Text = "";
                edit = true;


            }
          //  catch (Exception)
            {

            }
        }

        private void btn_add_level_Click(object sender, EventArgs e)
        {
            dgv.CurrentRow.Cells["level"].Value = combo_level.Text;
        }
        private void btn_clear_cell_Click(object sender, EventArgs e)
        {
            dgv.CurrentRow.Cells["s1"].Value = "";
        }
        private void btn_clear_2_cel_Click(object sender, EventArgs e)
        {
            dgv.CurrentRow.Cells["s2"].Value = "";
        }
        private void coler()
        {
          
            try
            {
                dgv_tree.Rows[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#b3b8ba");
                foreach (DataGridViewRow i in dgv_tree.Rows)
                {
                    if (i.Cells[2].Value.ToString() == "g")
                    {
                        i.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#b3b8ba");
                    }
                    else if (i.Cells[2].Value.ToString() == "f")
                    {
                        i.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#3e8ead");
                    }
                    else if (i.Cells[2].Value.ToString() == "c")
                    {
                        i.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#e1e8ed");
                    }
                    else if (i.Cells[2].Value.ToString() == "sc")
                    {
                        i.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#c9abf5");
                    }
                }
            }
            catch (Exception)
            {


            }

        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            clear();
            edit = false;

            coler();
            //dgv_code.Rows.Clear();
            //load_code(lbl_id.Text);
            ////db.Run("delete from statment where id='" + lbl_id.Text + "' and plues='0' or mins='0'");
            //for (int i = 0; i < dgv_code.Rows.Count; i++)
            //{
            //    string c1 = ""; string c2 = "";
            //    c1 = dgv_code.Rows[i].Cells[1].Value + ""; c2 = dgv_code.Rows[i].Cells[2].Value + "";
            //    if (c1 == "") c1 = "0"; if (c2 == "") c2 = "0";
            //   // db.Run("INSERT INTO statment([id],[no],[plues],[mins])values('" + lbl_id.Text + "','" + dgv_code.Rows[i].Cells[0].Value + "','" + c1 + "','" + c2 + "')");
            //}

        }
    }
}