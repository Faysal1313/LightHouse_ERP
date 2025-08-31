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

namespace f1.pos
{
    public partial class frm_exp_list : DevExpress.XtraEditors.XtraForm
    {
        public frm_exp_list()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(v.ico);
        }

        private void frm_exp_list_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("select RootID,RootName,name_long,sort from tree where type_acc='c' ", dt);
            dgv1.DataSource = dt;

            DataTable dt1 = new DataTable();
            db.GetData_DGV("select acc_code,(select isnull(max(rootname),'-') from tree where rootid=pos_list_expensses.acc_code) from pos_list_expensses", dt1);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                dgv2.Rows.Add("",dt1.Rows[i][0]+"", dt1.Rows[i][1]+"");
            }
        }

        private void dgv1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv1, "no");

        }

        private void dgv2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv2, "no2");
        }

        private void dgv2_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            Classes.command.LoadSerial(dgv2, "no2");
        }

        private void dgv1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv2.Rows.Add("",dgv1.CurrentRow.Cells["imp"].Value, db.GetData("select isnull(max(rootname),'-') from tree where rootid='" + dgv1.CurrentRow.Cells["imp"].Value+"' ").Rows[0][0]+"");
            
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            db.Run("delete from pos_list_expensses");
            for (int i = 0; i < dgv2.Rows.Count; i++)
            {
                db.Run("insert into pos_list_expensses (acc_code)values('" + dgv2.Rows[i].Cells["acc"].Value + "')");

            }
            MessageBox.Show("تم الحفظ");
        }
    }
}