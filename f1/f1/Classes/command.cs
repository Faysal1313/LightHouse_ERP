using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace f1.Classes
{
    class command
    {
        public static void LoadSerial(DataGridView dgv)
        {
            int i = 1;
            foreach (DataGridViewRow row in dgv.Rows)
            { row.Cells["No"].Value = i; i++; }
        }
        public static void LoadSerial(DataGridView dgv,string name_col)
        {
            int i = 1;
            foreach (DataGridViewRow row in dgv.Rows)
            { row.Cells[name_col].Value = i; i++; }
        }

        public static void perform_delete(string txt_code, string query)
        {
            if (txt_code == "")
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "ماشي بس هو مفيش حاجه علشان امسحها دخل كود  طيب !!؟؟؟؟ ", "رسال حذف مستند", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult dr;
                dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "سيتم حذف السند!!؟؟؟؟ ", "رسال حذف مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);


                if (dr == DialogResult.OK)
                {
                    db.Run(query);
                    // clear();
                }
                else
                {
                    return;
                }
            }

        }

        public static void perform_delete(string txt_code, string query1, string query2, string query3, string query4)
        {
            if (txt_code == "")
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "ماشي بس هو مفيش حاجه علشان امسحها دخل كود  طيب !!؟؟؟؟ ", "رسال حذف مستند", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult dr;
                dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "سيتم حذف السند!!؟؟؟؟ ", "رسال حذف مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);


                if (dr == DialogResult.OK)
                {
                    db.Run(query1);
                    db.Run(query2);
                    db.Run(query3);
                    db.Run(query4);
                    
                    // clear();
                }
                else
                {
                    return;
                }
            }

        }



        public static string get_time(ref string time)
        {
            //string loc = "";

            try
            {
                var client = new TcpClient("time.nist.gov", 13);
                using (var streamReader = new StreamReader(client.GetStream()))
                {
                    var response = streamReader.ReadToEnd();
                    var utcDateTimeString = response.Substring(7, 17);
                    DateTime dt = DateTime.ParseExact(utcDateTimeString, "yy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
                    time = Convert.ToDateTime(dt + "").ToString("-yyyy-MM");
                    //-2023-01
                }
            }
            catch (Exception)
            {

                time = "";
            }


            return time;
        }
    }
}
