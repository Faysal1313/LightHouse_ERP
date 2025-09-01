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

namespace f1.pos
{
    public partial class frm_pos_screen_rep : DevExpress.XtraEditors.XtraForm
    {
        public frm_pos_screen_rep()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);

        }

        private void dgv_pending_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv, "no");
        }

        private void frm_pos_screen_rep_Load(object sender, EventArgs e)
        {
            FileInfo[] files = new DirectoryInfo(Environment.CurrentDirectory + "\\report_pos").GetFiles("*.repx");
            foreach (FileInfo fileInfo in files)
                dgv.Rows.Add(0, fileInfo.FullName, fileInfo.Name);
        }

        private void dgv_pending_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //new ReportPrintTool((IReport)XtraReport.FromFile(this.dgv.CurrentRow.Cells[1].Value.ToString(), true), false).ShowRibbonPreviewDialog();
            new ReportPrintTool((IReport)XtraReport.FromFile(this.dgv.CurrentRow.Cells[1].Value.ToString(), true), false).ShowRibbonPreview();

        }
    }
}