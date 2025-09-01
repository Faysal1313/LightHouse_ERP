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
using System.Data.OleDb;
using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;

namespace f1.import_excel
{
    public partial class frm_excel_vcs : DevExpress.XtraEditors.XtraForm
    {
        public frm_excel_vcs()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon("f1.exe");
            db.Open();
        }
        int prog1 = 0;
        private void frm_excel_vcs_Load(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            //  valid_barButtonItem3.Enabled = false;
            save_barButtonItem4.Enabled = false;
          
           
        }
        private void open_excel()
        {
            string path = Environment.CurrentDirectory;
            string mysheet = path + "\\Import_Excel\\vcs.xlsx";
            //??????????????????????????????????????????????????????????????????????
            //??????????????????????????????????????????????????????????????????????
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>ERROR >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //??????????????????????????????????????????????????????????????????????

            //var excelapp = new Excel.Application();
            //excelapp.Visible = true;
            //Excel.Workbooks books = excelapp.Workbooks;
            //Excel.Workbook sheet = books.Open(mysheet);
        }
        private void load_excel()
        {
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Import_Excel//vcs.xlsx;Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;MAXSCANROWS=0'");
            OleDbCommand cmd = new OleDbCommand("select * from [vcs$]", conn);
            //  cmd.CommandText = "select * from [Sheet1$] where CategoryID=1";
            DataTable dt = new DataTable();
            //   lbl_1.Text = DateTime.Now.ToString("hh:mm:ss." + DateTime.Now.Ticks);
            conn.Open();
            dt.Load(cmd.ExecuteReader());
            conn.Close();
            dgv.Invoke((MethodInvoker)delegate
            {
                dgv.DataSource = dt;

            });
            //  lbl_1.Text += "\n" + DateTime.Now.ToString("hh:mm:ss." + DateTime.Now.Ticks);
            //  lbl_1.Text += "\n" + (dgv.Rows.Count - 1);

        }
        private void valid() //VALID FOR vcs code items term
        {
            lbl_state_line.Caption = dgv.Rows.Count + "";
            progressBar1.Visible = true;
            //1)found any wares to import items
         
            //2)no reoetation in items 

            int z = 0;
            prog1 = dgv.Rows.Count;//to know progras bar 
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                string old_code = db.GetData("select count( vcs_code) from vcs  where vcs_code='" + dgv.Rows[i].Cells[1].Value + "'").Rows[0][0].ToString();
                if (Convert.ToInt32(old_code) >= 1)
                {
                    XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "الصنف موجد في القاعده  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string x1 = dgv.Rows[i].Cells[1].Value.ToString();
                for (int ii = 0; ii < dgv.Rows.Count; ii++)
                {
                    z += 0;
                    string x3 = dgv.Rows[ii].Cells[1].Value.ToString();
                    if (x1 == x3 && z == 0)
                    {
                        z = 1;
                    }
                    else if (x1 == x3 || z > 1)
                    {
                        XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "الصنف متكرر ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    backgroundWorker1.ReportProgress(i);

                }
                z = 0;
                backgroundWorker1.ReportProgress(i);
            }


            //make null = 0
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                string phone_c = dgv.Rows[i].Cells["phone"].Value.ToString();
                if (phone_c == "")
                {
                    dgv.Rows[i].Cells["phone"].Value = 0;
                }
                string address_c = dgv.Rows[i].Cells["address"].Value.ToString();
                if (address_c == "")
                {
                    dgv.Rows[i].Cells["address"].Value = 0;
                }
                backgroundWorker1.ReportProgress(i);
            }
            prog1 = dgv.Rows.Count;//to know progras bar 

            
            for (int i = 0; i < dgv.Rows.Count; i++)
            {

                string vcs_code_c = dgv.Rows[i].Cells[1].Value.ToString();
                string vcs_name_c = dgv.Rows[i].Cells[2].Value.ToString();
                string mode_c = dgv.Rows[i].Cells[3].Value.ToString();
                string rootlevel_c = dgv.Rows[i].Cells[4].Value.ToString();
                if (vcs_code_c == "" && vcs_name_c == "" && mode_c == "" && rootlevel_c == "")
                {
                    MessageBox.Show("invalid CODE VCS  " + dgv.Rows[i].Cells["vcs_code"].Value.ToString());
                    return;
                }

            }
            save_barButtonItem4.Enabled = true;
            progressBar1.Visible = false;

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Maximum = prog1;
            progressBar1.Value = e.ProgressPercentage;
        }

        private void open_barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            open_excel();

        }

        private void load_barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            load_excel();
        }

        private void valid_barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            valid();
        }

        private async void save_barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            prog1 = dgv.Rows.Count;//to know progras bar 
            //insert into items
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                db.cmd.CommandText = ("insert into vcs (vcs_code, vcs_name, mode, rootlevel, rootlevel_name, type_acc, sort, phone, address) values ('" + dgv.Rows[i].Cells[1].Value + "','" + dgv.Rows[i].Cells[2].Value + "','" + dgv.Rows[i].Cells[3].Value + "',(select RootLevel  from tree where RootID='" + dgv.Rows[i].Cells[4].Value + "'),(select rootname from tree where rootid='" + dgv.Rows[i].Cells[4].Value + "'),'" + dgv.Rows[i].Cells[3].Value + "',(select sort from tree where rootid='" + dgv.Rows[i].Cells[4].Value + "'),'" + dgv.Rows[i].Cells[6].Value + "','" + dgv.Rows[i].Cells[7].Value + "')");
                await db.cmd.ExecuteNonQueryAsync();
            
            
                backgroundWorker1.ReportProgress(i);
            }
            XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "saving ", "save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv);

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("عايز تعمل جديد!!؟؟؟؟ ", "رسال جديد مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                import_excel.frm_excel_vcs frm = new import_excel.frm_excel_vcs();
                this.Close();
                frm.Show();
            }
        }
    }
}