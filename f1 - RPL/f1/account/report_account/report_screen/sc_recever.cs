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
    public partial class sc_recever : DevExpress.XtraEditors.XtraForm
    {
        public sc_recever()
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

        private void dgv_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            Classes.command.LoadSerial(dgv, "no");

        }

        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv, "no");

        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (db.GetData("select isnull(max(recev_hd_id),0) from recev_hd where recev_hd_id='" + dgv.CurrentRow.Cells[1].Value + "" + "'").Rows[0][0] + "" != "0")
                {
                    frm_recevable f = new frm_recevable();
                    f.Show();
                    f.txt_serial_string.Text = dgv.CurrentRow.Cells[1].Value + "";
                    f.txt_serial_string.Select();
                    f.txt_note.Select();




                    // dgv.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void btn_get_Data_Click(object sender, EventArgs e)
        {
            dgv.Rows.Clear();
            string query = "select recev_hd_id,type,amount,note,date_ from recev_hd where date_  between '" + date1.Value.ToString("yyyy/MM/dd") + "' and '" + date2.Value.ToString("yyyy/MM/dd") + "'";
            DataTable dt = new DataTable();
            db.GetData_DGV(query, dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv.Rows.Add("", dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3],  Convert.ToDateTime(dt.Rows[i][4]).ToString("yyyy/MM/dd"));
            }
        }

        private void btn_printer_Click(object sender, EventArgs e)
        {
            XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\recev_voucher.repx", true);
            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
            xtraReport.Parameters["parameter1"].Value = date1.Value.ToString("yyyy/MM/dd");
            xtraReport.Parameters["parameter2"].Value = date2.Value.ToString("yyyy/MM/dd");
            //xtraReport.Parameters["parameter3"].Value = lbl_code.Text;
            xtraReport.Parameters["parameter1"].Visible = false;
            xtraReport.Parameters["parameter2"].Visible = false;
            //XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\stat_gl.repx", true);
            //xtraReport.Parameters["parameter1"].Value = date1.Value.ToString("yyyy/MM/dd");
            //xtraReport.Parameters["parameter1"].Visible = false;
            ////xtraReport.Parameters["parameter2"].Value = dt_piker2.Value.ToString("yyyy/12/31");
            ////xtraReport.Parameters["parameter2"].Visible = false;
            //xtraReport.Parameters["parameter2"].Value = lbl_code.Text;
            //xtraReport.Parameters["parameter2"].Visible = false;
            //XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport)
        }
    }
}