using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.OleDb;
using Microsoft.Office.Interop;
//using Excel = Microsoft.Office.Interop.Excel;
namespace f1.import_excel
{
    public partial class frm_excel_items : DevExpress.XtraEditors.XtraForm
    {
        public frm_excel_items()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
            db.Open();
        }

        private void frm_excel_items_Load(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
          //  valid_barButtonItem3.Enabled = false;
            save_barButtonItem4.Enabled = false;
            DataTable dt = db.GetData("select id_ware from wares");
            if (dt.Rows.Count < 1)
            {
                MessageBox.Show("يجب تكويد مخزن واحد علي الاقل");
                return;
            }
          //  load_excel();
        }
        int prog1 = 0;
        int prog2 = 0;
        private void open_excel()
        {
            string path = Environment.CurrentDirectory;
            string mysheet = path + "\\Import_Excel\\items.xlsx";
            //??????????????????????????????????????????????????????????????????????
            //??????????????????????????????????????????????????????????????????????
            //>>>>>>>>>>>>>>>>>>>>>>>>>>>ERROR >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //??????????????????????????????????????????????????????????????????????
            //var excelapp = new Excel.Application();
            //excelapp.Visible = true;
            //Excel.Workbooks books = excelapp.Workbooks;
            //Excel.Workbook sheet = books.Open(mysheet);
            //000208D5-0000-0000-C000-000000000046
        }
        private void load_excel()
        {
            string path = "Import_Excel//vcs.xlsx";
            String name = "vcs";
            String constr = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + path + ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

            OleDbConnection con = new OleDbConnection(constr);
            OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", con);
            con.Open();

            OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
            DataTable data = new DataTable();
            sda.Fill(data);

            dgv.Invoke((MethodInvoker)delegate
            {
                dgv.DataSource = data;

            });

        }
        private void valid() //VALID FOR vcs code items term
        {
            lbl_state_line.Caption = dgv.Rows.Count + "";
            progressBar1.Visible = true;
            //1)found any wares to import items
            DataTable dt = db.GetData("select id_ware from wares");
            if (dt.Rows.Count < 1)
            {
                MessageBox.Show("يجب تكويد مخزن واحد علي الاقل");
                return;
            }
            //2)no reoetation in items 
                      
                                    int z = 0;
                                    prog1 = dgv.Rows.Count;//to know progras bar 
                                    for (int i = 0; i < dgv.Rows.Count; i++)
                                    {
                                        string old_code = db.GetData("select count( code_items) from items  where code_items='" + dgv.Rows[i].Cells[1].Value + "'").Rows[0][0].ToString();
                                        if (Convert.ToInt32(old_code) >= 1)
                                        {
                                            XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "الصنف موجد في القاعده  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            return;
                                        }
                                        string x1 = dgv.Rows[i].Cells[1].Value.ToString();
                                        for (int ii = 0; ii < dgv.Rows.Count; ii++)
                                        {
                                            z += 0;
                                            string x3 = dgv.Rows[ii].Cells[1].Value.ToString();
                                            if (x1 == x3 && z == 0)
                                            {
                                                z = 1;
                                            }
                                            else if (x1 == x3 || z > 1)
                                            {
                                                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "الصنف متكرر ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                return;
                                            }
                                            backgroundWorker1.ReportProgress(i);

                                        }
                                        z = 0;
                                        backgroundWorker1.ReportProgress(i);
                                    }       
           

            //make null = 0
            prog1 = dgv.Rows.Count;//to know progras bar 

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                string x = dgv.Rows[i].Cells["price_for_all"].Value.ToString();
                if (x == "")
                {
                    dgv.Rows[i].Cells["price_for_all"].Value = 0;
                }
                backgroundWorker1.ReportProgress(i);
            }
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv.Rows[i].Cells["code_items"].Value == null && dgv.Rows[i].Cells["name_items"].Value == null && dgv.Rows[i].Cells["name_unite"].Value == null && dgv.Rows[i].Cells["unite1"].Value == null && dgv.Rows[i].Cells["unite1"].Value == null && dgv.Rows[i].Cells["taxes"].Value == null && dgv.Rows[i].Cells["[exp]"].Value == null && dgv.Rows[i].Cells["type"].Value == null)
                {
                    MessageBox.Show("invalid CODE ITEM  " + dgv.Rows[i].Cells["code_items"].Value.ToString());
                    return;
                }

            }
            save_barButtonItem4.Enabled = true;
            progressBar1.Visible = false;

        }
        private void open_barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            open_excel();
        }
        private void load_barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            load_excel();
        }
        private void valid_barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            valid();
        }
        private async void save_barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            prog1 = dgv.Rows.Count;//to know progras bar 
            //insert into items
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                db.cmd.CommandText = ("insert into items (code_items,name_items,name_unite,unit1,price_buy,taxes,[exp],[type],price_sale,discount_buy,discount_sale)values('" + dgv.Rows[i].Cells["code_items"].Value.ToString() + "','" + dgv.Rows[i].Cells["name_items"].Value.ToString() + "','" + dgv.Rows[i].Cells["name_unite"].Value.ToString() + "',1,'" + dgv.Rows[i].Cells["price_for_all"].Value.ToString() + "','" + dgv.Rows[i].Cells["taxes"].Value.ToString() + "','" + dgv.Rows[i].Cells["exp"].Value.ToString() + "','" + dgv.Rows[i].Cells["type"].Value.ToString() + "','0','0','0')");
                await db.cmd.ExecuteNonQueryAsync();
               //insert into unite
                db.cmd.CommandText = ("insert into unite (id,name_unite,code_items,unite)values('1','" + (dgv.Rows[i].Cells["name_unite"].Value.ToString()) + "','" + dgv.Rows[i].Cells["code_items"].Value.ToString() + "','1')");
                await db.cmd.ExecuteNonQueryAsync();
                string unite2=dgv.Rows[i].Cells["unit2"].Value.ToString();
                if (unite2 != "")
                {
                    db.cmd.CommandText = ("insert into unite (id,name_unite,code_items,unite)values('2','" + (dgv.Rows[i].Cells["name_unite2"].Value.ToString()) + "','" + dgv.Rows[i].Cells["code_items"].Value.ToString() + "','" + (dgv.Rows[i].Cells["unit2"].Value.ToString()) + "')");
                    await db.cmd.ExecuteNonQueryAsync();
                }
                string unite3=dgv.Rows[i].Cells["unit3"].Value.ToString();
                if (unite3 != "")
                {
                    db.cmd.CommandText = ("insert into unite (id,name_unite,code_items,unite)values('3','" + (dgv.Rows[i].Cells["name_unite3"].Value.ToString()) + "','" + dgv.Rows[i].Cells["code_items"].Value.ToString() + "','" + (dgv.Rows[i].Cells["unit3"].Value.ToString()) + "')");
                    await db.cmd.ExecuteNonQueryAsync();
                }
                //insert barcode
                string barcode1=dgv.Rows[i].Cells["barcode1"].Value.ToString();
                if (barcode1 != "")
                {
                    db.cmd.CommandText = ("insert into barcode (barcode,code_items)values('" + (dgv.Rows[i].Cells["barcode1"].Value.ToString()) + "','" + dgv.Rows[i].Cells["code_items"].Value.ToString() + "')");
                    await db.cmd.ExecuteNonQueryAsync();
                }
                string barcode2=dgv.Rows[i].Cells["barcode2"].Value.ToString();
                if (barcode2 != "")
                {
                    db.cmd.CommandText = ("insert into barcode (barcode,code_items)values('" + (dgv.Rows[i].Cells["barcode2"].Value.ToString()) + "','" + dgv.Rows[i].Cells["code_items"].Value.ToString() + "')");
                    await db.cmd.ExecuteNonQueryAsync();
                }
                string barcode3=dgv.Rows[i].Cells["barcode3"].Value.ToString();
                if (barcode3 != "")
                {
                    db.cmd.CommandText = ("insert into barcode (barcode,code_items)values('" + (dgv.Rows[i].Cells["barcode3"].Value.ToString()) + "','" + dgv.Rows[i].Cells["code_items"].Value.ToString() + "')");
                    await db.cmd.ExecuteNonQueryAsync();
                }
                //insert into wars
                DataTable dtwares = new DataTable();
                DataTable dtacc = new DataTable();
                db.GetData_DGV("select DISTINCT(id_ware) from wares", dtwares);
                prog2 = dtwares.Rows.Count;//to know progras bar 
                for (int ii = 0; ii < dtwares.Rows.Count; ii++)
                {
                    db.cmd.CommandText = ("insert into wares (id_ware,code_items,name_items,qty,cost,tot,acc,demand_limit,demand_maximum,demand_limit_bit,demand_maximum_bit)values('" + (dtwares.Rows[ii][0].ToString()) + "','" + dgv.Rows[ii].Cells["code_items"].Value.ToString() + "','" + dgv.Rows[ii].Cells["name_items"].Value.ToString() + "',0,0,0,0,0,0,'False','False')");
                    await db.cmd.ExecuteNonQueryAsync();
                    backgroundWorker1.ReportProgress(ii);
                }
                backgroundWorker1.ReportProgress(i);
            }
            XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "saving ", "save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Maximum = prog1;
            progressBar1.Value = e.ProgressPercentage;
            //progressBar2.Maximum = prog1;
            //progressBar2.Value = e.ProgressPercentage;
        }


        

        private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=ex1.xlsx;Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;MAXSCANROWS=0'");
            OleDbCommand cmd = new OleDbCommand("select * from [Sheet1$]", conn);
            //  cmd.CommandText = "select * from [Sheet1$] where CategoryID=1";
            DataTable dt = new DataTable();
            //   lbl_1.Text = DateTime.Now.ToString("hh:mm:ss." + DateTime.Now.Ticks);
            conn.Open();
            dt.Load(cmd.ExecuteReader());
            conn.Close();
            dgv.Invoke((MethodInvoker)delegate
            {
                dgv.DataSource = dt;

            });

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int z = 0;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                string x1 = dgv.Rows[i].Cells[1].Value.ToString();
                for (int ii = 0; ii < dgv.Rows.Count; ii++)
                {
                    z += 0;
                    string x3 = dgv.Rows[ii].Cells[1].Value.ToString();
                    if (x1==x3 && z==0)
                    {
                        z = 1;
                    }
                    else if (x1==x3 || z > 1)
                    {
                        MessageBox.Show("doublicat");
                        return;
                    }
                }
                z = 0;
            }

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("عايز تعمل جديد!!؟؟؟؟ ", "رسال جديد مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                import_excel.frm_excel_items frm = new import_excel.frm_excel_items();
                this.Close();
                frm.Show();
            }
        }
        
    }
}