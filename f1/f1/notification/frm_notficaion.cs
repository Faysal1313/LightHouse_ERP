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
    public partial class frm_notficaion : DevExpress.XtraEditors.XtraForm
    {
        public frm_notficaion()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon("f1.exe");
            db.Open();
        }

        private void frm_notficaion_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("select code_items,date,note from center",dt);
            dgv.DataSource = dt;
        }
        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv);
        }
        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            frm_cogs_adj f = new frm_cogs_adj();
            f.ShowDialog();
        }
    }
}