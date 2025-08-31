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
    public partial class frm_trial_bal : DevExpress.XtraEditors.XtraForm
    {
        public frm_trial_bal()
        {
            InitializeComponent();
            db.Open();
        }

        private void frm_trial_bal_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            db.GetData_DGV(" select  entry.acc_num, entry.acc_name,rootlevel,type_acc,(sum(entry.depit)) as depitbal,sum(entry.credit) as creditbal,sum(opening_bal) as opening_bal,((sum(entry.depit)) - sum(entry.credit))as d from entry where sort='g' or sort='f' group by entry.acc_num, entry.acc_name,rootlevel ,type_acc  union  select  entry.acc_num, entry.acc_name,rootlevel,type_acc,(sum(entry.depit)) as depitbal,sum(entry.credit) as creditbal,sum(opening_bal) as opening_bal,((sum(entry.depit)) - sum(entry.credit))as d from entry  where   sort='1'    group by entry.acc_num, entry.acc_name,rootlevel ,type_acc     union     select  rootlevel as acc_num ,rootlevel_name, rootlevel, type_acc,(sum(entry.depit)) as depitbal,sum(entry.credit) as creditbal,sum(opening_bal) as opening_bal,((sum(entry.depit)) - sum(entry.credit)) as d from entry      where   sort='2'         group by rootlevel ,type_acc ,rootlevel_name          order by entry.rootlevel asc          ",dt);
            dataGridView1.DataSource = dt;
            calc_all();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                v.num_test_trial = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                frm_statment_test f = new frm_statment_test();
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void calc_all()
        {
            try
            {
                decimal tot_bef = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    tot_bef+= Convert.ToDecimal(dataGridView1.Rows[i].Cells[7].Value);
                }
                label1.Text = Math.Round(tot_bef, 2) + "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
           // calc_all();
        }
    }
}