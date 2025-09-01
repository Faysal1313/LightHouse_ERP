using DevExpress.XtraEditors;
using DevExpress.XtraReports;
using DevExpress.XtraReports.UI;
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
    public partial class sc_trial_with_costCenter : DevExpress.XtraEditors.XtraForm
    {
        public sc_trial_with_costCenter()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
            date1.Text = DateTime.Now.ToString("yyyy/01/01");
            date2.Text = DateTime.Now.ToString("yyyy/MM/dd");
            all_comb.cost_center_name(this.combo_costcenter);
            combo_costcenter.Text = "";

            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void btn_get_Data_Click(object sender, EventArgs e)
        {
            dgv.Rows.Clear();
            string query = "select  entry.acc_num, entry.acc_name,rootlevel,type_acc,(sum(entry.depit)) as depitbal,sum(entry.credit) as creditbal,sum(opening_bal) as opening_bal from entry where sort = '1'   and dates  between '" + date1.Value.ToString("yyyy/MM/dd") + "' and '" + date2.Value.ToString("yyyy/MM/dd") + "' and costcenter_code='" + lbl_costcenter.Text + "' group by entry.acc_num, entry.acc_name,rootlevel ,type_acc  union    select rootlevel as acc_num ,rootlevel_name, rootlevel, type_acc,(sum(entry.depit)) as depitbal,sum(entry.credit) as creditbal,sum(opening_bal) as opening_bal from entry  where sort = '2' and dates between '" + date1.Value.ToString("yyyy/MM/dd") + "' and '" + date2.Value.ToString("yyyy/MM/dd") + "' and costcenter_code='" + lbl_costcenter.Text + "' group by rootlevel ,type_acc ,rootlevel_name   order by entry.rootlevel asc ";
            // string query = "select  entry.acc_num, entry.acc_name,rootlevel,type_acc,(sum(entry.depit)) as depitbal,sum(entry.credit) as creditbal,sum(opening_bal) as opening_bal from entry  where sort = 'g' or sort = 'f' group by entry.acc_num, entry.acc_name,rootlevel ,type_acc  union  select entry.acc_num, entry.acc_name,rootlevel,type_acc,(sum(entry.depit)) as depitbal,sum(entry.credit) as creditbal,sum(opening_bal) as opening_bal from entry where sort = '1'  and dates between '" + date1.Value.ToString("yyyy/MM/dd") + "' and '" + date2.Value.ToString("yyyy/MM/dd") + "' group by entry.acc_num, entry.acc_name,rootlevel ,type_acc  union    select rootlevel as acc_num ,rootlevel_name, rootlevel, type_acc,(sum(entry.depit)) as depitbal,sum(entry.credit) as creditbal,sum(opening_bal) as opening_bal from entry  where sort = '2' and dates between '" + date1.Value.ToString("yyyy/MM/dd") + "' and '" + date2.Value.ToString("yyyy/MM/dd") + "'  group by rootlevel ,type_acc ,rootlevel_name  order by entry.rootlevel asc";
            DataTable dt = new DataTable();
            db.GetData_DGV(query, dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgv.Rows.Add("", dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3], dt.Rows[i][4], dt.Rows[i][5], dt.Rows[i][6]);
            }
            try
            {
                double bal = 0;
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    //bal = bal + (Convert.ToDouble(dgv.Rows[i].Cells[6].Value) - Convert.ToDouble(dgv.Rows[i].Cells[5].Value));
                    if (dgv.Rows[i].Cells[5].Value + "" == "") dgv.Rows[i].Cells[5].Value = "0";
                    if (dgv.Rows[i].Cells[6].Value + "" == "") dgv.Rows[i].Cells[6].Value = "0";

                    double dep_bal = Math.Round(Convert.ToDouble(dgv.Rows[i].Cells[5].Value), 2);
                    double cr_bal = Math.Round(Convert.ToDouble(dgv.Rows[i].Cells[6].Value), 2);
                    double dep = dep_bal - cr_bal;
                    double cr = cr_bal - dep_bal;
                    bal = bal + (dep_bal - cr_bal);
                    lbl_tot.Text = bal + "";
                    dgv.Rows[i].Cells[9].Value = dep_bal - cr_bal;

                    if (dep > 0)
                    {
                        dgv.Rows[i].Cells[7].Value = dep + "";
                        dgv.Rows[i].Cells[8].Value = 0;

                    }
                    else
                    {
                        dgv.Rows[i].Cells[7].Value = 0;

                        dgv.Rows[i].Cells[8].Value = cr + "";

                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv, "no");

        }

        private void dgv_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            Classes.command.LoadSerial(dgv, "no");

        }

        private void btn_printer_Click(object sender, EventArgs e)
        {
            XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("report_sys\\trial_gl_short.repx", true);
            xtraReport.Parameters["parameter1"].Value = date1.Value.ToString("yyyy/MM/dd");
            xtraReport.Parameters["parameter2"].Value = date2.Value.ToString("yyyy/MM/dd");
            xtraReport.Parameters["parameter1"].Visible = false;
            xtraReport.Parameters["parameter2"].Visible = false;
            XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 1)
                {

                    sc_statment_gl f = new sc_statment_gl();

                    //frm_entry f = new frm_entry();
                    f.Show();

                    f.lbl_code.Text = dgv.CurrentRow.Cells[1].Value + "";
                    f.date1.Text = date1.Text;
                    f.date2.Text = date2.Text;
                    f.date1.Select();
                    f.btn_get_Data.Select();
                    f.btn_get_Data.PerformClick();


                    //f.txt_serial_string.Select();
                    //f.txt_note.Select();



                    // dgv.Rows.RemoveAt(e.RowIndex);
                }
            }
            catch (Exception)
            {


            }

        }

        private void combo_costcenter_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl_costcenter.Text=db.GetData("select isnull(max (costcenter_id),'-') from costcenter where costcenter_name='"+combo_costcenter.Text+"'").Rows[0][0]+"";
        }
    }
}