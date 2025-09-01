using DevExpress.XtraEditors;
using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace f1
{
    public partial class frm_report : DevExpress.XtraEditors.XtraForm
    {
        public frm_report()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);

        }
        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            new ReportPrintTool((IReport)XtraReport.FromFile(this.dgv.CurrentRow.Cells[1].Value.ToString(), true), false).ShowRibbonPreviewDialog();
            
        }
        private void frm_report_Load(object sender, EventArgs e)
        {
            FileInfo[] files = new DirectoryInfo(Environment.CurrentDirectory + "\\report_user").GetFiles("*.repx");
            foreach (FileInfo fileInfo in files)
                dgv.Rows.Add(0, fileInfo.FullName, fileInfo.Name);
        }

        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv, "no");

        }
    }
}