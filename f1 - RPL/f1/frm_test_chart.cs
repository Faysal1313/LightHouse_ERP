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
    public partial class frm_test_chart : DevExpress.XtraEditors.XtraForm
    {
        public frm_test_chart()
        {
            InitializeComponent();
            db.Open();
        }

        private void frm_test_chart_Load(object sender, EventArgs e)
        {

        }
    }
}