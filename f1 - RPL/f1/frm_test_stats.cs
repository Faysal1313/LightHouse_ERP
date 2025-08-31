using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace f1.hr
{
    public partial class frm_test_stats : DevExpress.XtraEditors.XtraForm
    {
        public frm_test_stats()
        {
            InitializeComponent();
            db.Open();
        }

        private void frm_test_stats_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'f1DataSet.v_expensses_vs_revenue' table. You can move, or remove it, as needed.
            this.v_expensses_vs_revenueTableAdapter.Fill(this.f1DataSet.v_expensses_vs_revenue);
            

        }
    }
}