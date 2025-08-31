using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace f1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = "Import_Excel//vcs.xlsx";
            String name = "vcs";
            String constr = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + path + ";Extended Properties='Excel 12.0 XML;HDR=YES;';";
            // String constr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
            //vcs.xlsx

            // strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'";
            //      strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";



            OleDbConnection con = new OleDbConnection(constr);
            //OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", con);
            con.Open();

            //OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
            //DataTable data = new DataTable();
           // sda.Fill(data);

            dgv.Invoke((MethodInvoker)delegate
            {
              //  dgv.DataSource = data;

            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //1-get path ex and mak database file is empty
            string path = @"D:\\Program\\project\\excel_import\\excel_import\\bin\\Debug\\test1.txt";
            File.WriteAllText(path, String.Empty);


            //2-make database file have connectionstring 

            string ip = Properties.Settings.Default.server;
            string db = Properties.Settings.Default.db_base;
            string sql_user = Properties.Settings.Default.sql_name;
            string sql_pass = Properties.Settings.Default.sql_pass;

            string conn_string = "Data Source=" + ip + " ;Initial Catalog=" + db + " ;Integrated Security=False ; USER ID='" + sql_user + "' ; Password='" + sql_pass + "'";


            StreamWriter streamWriter = new StreamWriter(path, true);
            streamWriter.WriteLine(conn_string);
            streamWriter.Close();

            //3-open Aplcations

            Process.Start("D:\\Program\\project\\excel_import\\excel_import\\bin\\Debug\\excel_import.exe");

            // Process.Start("D:\\GAMES\\commands\\Commandos - BEL\\Commandos.exe");


        }
        private void zip(string file)
        {
            string fileName = file;
            Thread thread = new Thread(t =>
            {
                using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile())
                {
                    FileInfo fi = new FileInfo(fileName);
                    zip.AddFile(fileName);
                    System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(fileName);
                    //zip.SaveProgress += zip_saveprogressfile;
                    zip.Save(string.Format("{0}/{1}.zip", di.Parent.FullName, fi.Name));
                }
            });
            //{IsBackground=true };
            thread.Start();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            // zip(@"D:\backup_2022-01-15----10--43--0243araia.back");
           
                File.Delete(@"D:\backup_2022-01-15----11--00--010araia.back");
            
        }
    }
}
