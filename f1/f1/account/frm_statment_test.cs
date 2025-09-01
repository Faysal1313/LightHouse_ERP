using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace f1.account
{
    public partial class frm_statment_test : DevExpress.XtraEditors.XtraForm
    {
        public frm_statment_test()
        {
            InitializeComponent();
        }

        private void frm_statment_test_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("SELECT     code_entry, code_book, acc_num, acc_name, depit, credit, opening_bal, dates, rootlevel, rootlevel_name, type_acc, sort, attachno, attachbook, attachnamebook,                       attachtext, attachno2 FROM         entry WHERE     (acc_num = '" + v.num_test_trial + "') AND (code_entry <> '-11')ORDER BY code_entry", dt);
            dataGridView1.DataSource = dt;
        }
    }
}