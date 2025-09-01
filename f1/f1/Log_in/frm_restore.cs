using DevExpress.XtraEditors;
using System.IO.Compression;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace f1.Log_in
{
    public partial class frm_restore : DevExpress.XtraEditors.XtraForm
    {
        public frm_restore()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
            frm_connection_db f = new frm_connection_db();
            //f.txt_pass_sql.Text;
        }
        private void btn_get_buk_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                //Filter = "ALL files |*.*",
                //"png files (*.png)|*.png|jpg files(*.jpg)|*.jpg|All Files(*.*)|*.*";
                Filter = "back(*.back)|*.back|zip files(*.zip)|*.zip",
                ValidateNames = true,Multiselect = false};
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txt_path.Text = ofd.FileName;
              
            }
        }
      
        private void btn_restore_Click(object sender, EventArgs e)
        {
            string fileName = txt_path.Text;
            FileInfo fi = new FileInfo(fileName);
            //if have extinions zip  go >>> unzip 
            if (fi.Extension==".zip")
            {
                string target_folder = "";
                string source_file = "";
                source_file =txt_path.Text;
                target_folder = fi.DirectoryName;
                ZipFile.ExtractToDirectory(source_file, target_folder);
            }
            frm_connection_db.Open();
            string db_name_read = "";
            try
            {
                db_name_read = frm_connection_db.GetData("use master \n RESTORE HEADERONLY FROM DISK = '" + txt_path.Text + "'").Rows[0][9] + "";
            }
            catch (Exception)
            {
               
            }
            finally { db_name_read = ""; }
            string db_name_in_sql= frm_connection_db.GetData("use master \n SELECT isnull(max(name),0) FROM sys.databases where name='"+db_name_read+"'").Rows[0][0] + "";
            string txt_byuser = frm_connection_db.GetData("use master \n SELECT isnull(max(name),0) FROM sys.databases where name='" +txt_name.Text.Trim() + "'").Rows[0][0] + "";
            if (txt_name.Text=="")
            {
                MessageBox.Show("يجب اختيار اسم للقاعدة");
                return;
            }
            if(txt_byuser!="0")
            {
                MessageBox.Show("القاعده موجوده من قبل ");
                return;
            }
            if (db_name_read==db_name_in_sql)
            {
                MessageBox.Show("القاعده موجوده من قبل ");
                return;
            }
            string nameFileOreginal = txt_path.Text;
            nameFileOreginal = nameFileOreginal.Replace(".zip","");
            frm_connection_db.Run("RESTORE DATABASE " + txt_name.Text + " FROM DISK = '" + nameFileOreginal + "'");
            File.Delete(nameFileOreginal);

            MessageBox.Show("تم عمل استرجاع القاعده بنجاح");


        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string target_folder = "";
            string source_file = "";
            source_file = @"D:\New folder (2)\backup_2022-01-15----11--14--2014araia.back.zip";
            target_folder = @"D:\New folder (2)";
            ZipFile.ExtractToDirectory(source_file, target_folder);
        }
    }
}