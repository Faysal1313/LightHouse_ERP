using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace f1.opening_closing
{
    public partial class frm_openig_and_close_wizard : Form
    {
        public frm_openig_and_close_wizard()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon("f1.exe");
            db.Open();
        }

        private void btn_open_qty_inv_Click(object sender, EventArgs e)
        {
            opening_closing.frm_opening_qty f = new opening_closing.frm_opening_qty();
            f.ShowDialog();
        }

        private void btn_cus_ven_bal_Click(object sender, EventArgs e)
        {
            opening_closing.frm_opening_vcs f = new opening_closing.frm_opening_vcs();
            f.ShowDialog();
        }

        private void btn_open_finaly_Click(object sender, EventArgs e)
        {
            opening_closing.frm_opening_entry f = new opening_closing.frm_opening_entry();
            f.ShowDialog();
        }

        private void wizardControl1_FinishClick(object sender, CancelEventArgs e)
        {
            string st = db.GetData("select entry_error from info_co").Rows[0][0].ToString();
            string er = db.GetData("select SUM (depit) ,sum(credit) ,isnull((SUM(depit-credit)),0) from entry where code_entry='-3' or code_entry='-2' or code_entry='-1'").Rows[0][2].ToString();
            if (st=="True")
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "القيد غير متزن يجب اعاده ادخال القيد مره اخره  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "القيد غير متزن داخل القاعده من فضلك اعد القيد الافتتاحي مره اخره  " + "\n  قيمه الفرق  " + er, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Close();
            }
        }
    }
}
