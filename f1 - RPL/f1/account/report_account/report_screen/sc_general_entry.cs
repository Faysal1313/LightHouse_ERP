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

namespace f1.account.report_account.report_screen
{
    public partial class sc_general_entry : DevExpress.XtraEditors.XtraForm
    {
        public sc_general_entry()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
            date1.Text = DateTime.Now.ToString("yyyy/01/01");
            date2.Text = DateTime.Now.ToString("yyyy/MM/dd");
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv, "no");
        }

        private void dgv_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            Classes.command.LoadSerial(dgv, "no");
        }

        private void btn_get_Data_Click(object sender, EventArgs e)
        {
            dgv.Rows.Clear();
             string query = "select code_entry,acc_num,acc_name,depit,credit,type_acc,dates from entry where code_book<>'-11' and dates  between '" + date1.Value.ToString("yyyy/MM/dd") + "' and '" + date2.Value.ToString("yyyy/MM/dd") + "'";
            DataTable dt = new DataTable();
            db.GetData_DGV(query, dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv.Rows.Add("", dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3], dt.Rows[i][4], dt.Rows[i][5], dt.Rows[i][6]);
            }
              }

        private void btn_printer_Click(object sender, EventArgs e)
        {
            XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\general_entry.repx", true);
            xtraReport.Parameters["parameter1"].Value = date1.Value.ToString("yyyy/MM/dd");
            xtraReport.Parameters["parameter2"].Value = date2.Value.ToString("yyyy/MM/dd");
            xtraReport.Parameters["parameter1"].Visible = false;
            xtraReport.Parameters["parameter2"].Visible = false;
            //  xtraReport.Parameters["parameter3"].Visible = false;



            //xtraReport.Parameters["parameter1"].Value = date1.Value.ToString("yyyy/MM/dd");
            //xtraReport.Parameters["parameter2"].Value = date2.Value.ToString("yyyy/12/31");
            //xtraReport.Parameters["parameter3"].Value = lbl_code.Text;
            //xtraReport.Parameters["parameter1"].Visible = false;
            //xtraReport.Parameters["parameter2"].Visible = false;
            //xtraReport.Parameters["parameter3"].Visible = false;
            //XtraReportPreviewExtensions.ShowPreview((IReport)xtraRepo
            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex ==2)
                {
                    sc_statment_gl f = new sc_statment_gl();
                    f.Show();
                    f.lbl_code.Text = dgv.CurrentRow.Cells[1].Value + "";
                    f.date1.Text = date1.Text;
                    f.date2.Text = date2.Text;
                    f.date1.Select();
                    f.btn_get_Data.Select();
                    f.btn_get_Data.PerformClick();
                }
                if (e.ColumnIndex==1)
                {
                   
                        frm_entry f = new frm_entry();
                        f.Show();
                        f.txt_serial_string.Text = dgv.CurrentRow.Cells[1].Value + "";
                        f.txt_serial_string.Select();
                        f.txt_note.Select();

                }
               
            }
            catch (Exception)
            {


            }
        }
    }
}