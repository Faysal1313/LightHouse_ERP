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
using System.Threading;
using System.IO;
using Ionic.Zip;

namespace f1.pos
{
    public partial class frm_settings : DevExpress.XtraEditors.XtraForm
    {
        public frm_settings()
        {
            InitializeComponent();
        }

        private void Btn_emp_Click(object sender, EventArgs e)
        {
            frm_emp f = new frm_emp();
            f.Show();
        }

        private void Btn_info_comp_Click(object sender, EventArgs e)
        {
            frm_info_co f = new frm_info_co();
            f.Show();
        }

        private void Btn_pos_settings_Click(object sender, EventArgs e)
        {
            frm_pos_settings_cash f = new frm_pos_settings_cash();
            f.Show();
        }

        private void Btn_desgin_report_Click(object sender, EventArgs e)
        {
            frm_desgin_report_main f = new frm_desgin_report_main();
            f.Show();
        }

        private void Btn_backup_Click(object sender, EventArgs e)
        {
            try
            {
                string namedb = f1.Properties.Settings.Default.db_base;
                string d = DateTime.Now.ToString("yyyy-MM-dd----hh--mm--ss"+namedb);
                SaveFileDialog open = new SaveFileDialog();
                open.Filter = "Backup File(*.back)|*.back";
                open.FileName = "backup_" + d;
                if (open.ShowDialog() == DialogResult.OK)
                {
                    db.Open();
                    db.Run("backup database " + namedb + " to Disk ='" + open.FileName + "'");
                    zip(open.FileName+"");
                    XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "Backup is complet ", "Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    File.Delete(open.FileName + "");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

    //private void zip_saveprogressfile(object sender, SaveProgressEventArgs e)
    //{
    //    if (e.EventType == Ionic.Zip.ZipProgressEventType.Saving_EntryBytesRead)
    //    {
    //            progressBar1.Invoke(new MethodInvoker(delegate {
    //            progressBar1.Maximum = 100;
    //            progressBar1.Value = (int)((e.BytesTransferred * 100) / e.TotalBytesToTransfer);
    //            progressBar1.Update();
    //        }));


    //    }
    //}

    private void btn_permission_Click(object sender, EventArgs e)
        {
            pos.frm_pos_permission f = new frm_pos_permission();
                f.Show();
        }

        private void btn_expenses_employee_Click(object sender, EventArgs e)
        {
            pos.frm_exp_list f = new pos.frm_exp_list();
            f.Show();
        }

        private void btn_opening_bal_Click(object sender, EventArgs e)
        {
           // pos.frm_oepinging f = new frm_oepinging();
           // f.Show();
        }
    }
}