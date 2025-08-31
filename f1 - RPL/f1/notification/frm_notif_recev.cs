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
    public partial class frm_notif_recev : DevExpress.XtraEditors.XtraForm
    {
        public frm_notif_recev()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
            db.Open();
        }

        private void frm_notif_recev_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("select  vcs.phone,sale_hd_id,incloud_taxes,sale_hd.vcs_code,sale_hd.vcs_name ,due_Date,(DATEDIFF(day, date_P , due_date ))as days from  sale_hd left join  vcs  on sale_hd.vcs_code = vcs.vcs_code where (DATEDIFF(day, date_P , due_date ))<=5 --and sale_hd.vcs_value < 0", dt);
            dgv.DataSource = dt;
        }

        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv);

        }
    }
}