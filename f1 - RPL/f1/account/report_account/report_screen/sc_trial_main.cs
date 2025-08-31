using DevExpress.XtraEditors;
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
    public partial class sc_trial_main : DevExpress.XtraEditors.XtraForm
    {
        public sc_trial_main()
        {
            InitializeComponent();
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            sc_trial_short f = new sc_trial_short();
            f.Show();
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            sc_trial_long f = new sc_trial_long();
            f.Show();
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            sc_trial_with_costCenter f = new sc_trial_with_costCenter();
            f.Show();
        }
    }
}