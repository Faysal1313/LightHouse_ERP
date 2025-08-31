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

namespace f1.notification
{
    public partial class frm_notif_depit : DevExpress.XtraEditors.XtraForm
    {
        public frm_notif_depit()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon("f1.exe");
            db.Open();
        }
        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv);
        }
        private void frm_notif_depit_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("select  vcs.phone,purchase_hd_id,incloud_taxes,purchase_hd.vcs_code,purchase_hd.vcs_name ,due_Date,(DATEDIFF(day, date_P , due_date ))as days from  purchase_hd left join  vcs  on purchase_hd.vcs_code = vcs.vcs_code where (DATEDIFF(day, date_P , due_date ))<=5 ", dt);
            dgv.DataSource = dt;
        }
    }
}