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
    public partial class frm_sub_ledger_wares : DevExpress.XtraEditors.XtraForm
    {
        public frm_sub_ledger_wares()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon("f1.exe");

        }




        private void getdata()
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("select acc_id ,acc_name from wares_acc where id_ware=-9 order by acc_id", dt);
            dgv_acc.DataSource = dt;

        }
        private void delete_simpleButton2_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("هل تريد الحذف!!؟؟؟؟ ", "رسال حذف مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                db.Run("delete from wares_acc where id_ware=-9 and acc_id='" + dgv_acc.CurrentRow.Cells[0].Value + "'");
                getdata();

            }
            else
            {

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            db.Run("insert into wares_acc (id_ware,acc_id,acc_name) values(-9,'" + txt_acc_id.Text + "','" + txt_acc_name.Text + "' )");
            getdata();
        }
    }
}