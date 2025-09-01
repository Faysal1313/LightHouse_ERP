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

namespace f1.account.report_account.report_finance_statment
{
    public partial class frm_rpt_balance_sheet : DevExpress.XtraEditors.XtraForm
    {
        public frm_rpt_balance_sheet()
        {
            InitializeComponent();
            db.Open();
        }

        private void frm_rpt_balance_sheet_Load(object sender, EventArgs e)
        {
         
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            //=============================================
            db.Run("delete from main_sub");
            DataTable dtt = new DataTable();
            db.GetData_DGV("select  entry.acc_num,entry.rootlevel from entry where  sort='f'  group by entry.acc_num, entry.acc_name,rootlevel ,type_acc ", dtt);
            //    db.GetData_DGV("select  entry.acc_num,entry.rootlevel from entry where  sort='f'  group by entry.acc_num, entry.acc_name,rootlevel ,type_acc ", dt);

            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                db.Run("insert into main_sub(acc_num,acc_name,value,rootlevel) values('" + dtt.Rows[i][0] + "',(select acc_name from entry where acc_num='" + dtt.Rows[i][0] + "'),(select  sum(depit-credit) from entry where SUBSTRING(rootlevel, 1, 4)='" + dtt.Rows[i][1] + "'),(select rootlevel from entry where acc_num='" + dtt.Rows[i][0] + "'))");
            }

            //=============================================
            DataTable dt = new DataTable();

           // db.cmd.Parameters.Add("2020-01-06");
         //   db.GetData_DGV(("select  main_sub.value as tot_sub ,entry.dates,entry.acc_num, entry.acc_name,entry.rootlevel,entry.type_acc,(sum(entry.depit)) as depitbal,sum(entry.credit) as creditbal,(sum(entry.depit)) -sum(entry.credit) as def,sum(opening_bal) as opening_bal from entry  left join main_sub on entry.acc_num= main_sub.acc_num left join tree on entry.acc_num = tree.rootid where  tree.sort='ميزانيه' or entry.dates <='2020-01-06' group by entry.acc_num, entry.acc_name,entry.rootlevel ,entry.type_acc ,main_sub.value,main_sub.acc_name ,entry.dates order by entry.rootlevel  "), dt);
            db.GetData_DGV((" select  main_sub.value as tot_sub ,entry.acc_num, entry.acc_name,entry.rootlevel,entry.type_acc,(sum(entry.depit)) as depitbal,sum(entry.credit) as creditbal,(sum(entry.depit)) -sum(entry.credit) as def,sum(opening_bal) as opening_bal from entry  left join main_sub on entry.acc_num= main_sub.acc_num left join tree on entry.acc_num = tree.rootid where  tree.sort='ميزانيه' group by entry.acc_num, entry.acc_name,entry.rootlevel ,entry.type_acc ,main_sub.value,main_sub.acc_name order by entry.rootlevel  "), dt);

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            db.Run("delete from main_sub");
            DataTable dtt = new DataTable();
            db.GetData_DGV("select  entry.acc_num,entry.rootlevel from entry where  sort='f'  group by entry.acc_num, entry.acc_name,rootlevel ,type_acc ", dtt);
            //    db.GetData_DGV("select  entry.acc_num,entry.rootlevel from entry where  sort='f'  group by entry.acc_num, entry.acc_name,rootlevel ,type_acc ", dt);

            for (int i = 0; i < dtt.Rows.Count; i++)
            {
                db.Run("insert into main_sub(acc_num,acc_name,value,rootlevel) values('" + dtt.Rows[i][0] + "',(select acc_name from entry where acc_num='" + dtt.Rows[i][0] + "'),(select  sum(depit-credit) from entry where SUBSTRING(rootlevel, 1, 4)='" + dtt.Rows[i][1] + "'),(select rootlevel from entry where acc_num='" + dtt.Rows[i][0] + "'))");
            }

            //=============================================
            DataTable dt = new DataTable();

            // db.cmd.Parameters.Add("2020-01-06");
            db.GetData_DGV(("  select  main_sub.value as tot_sub ,entry.acc_num, entry.acc_name,entry.rootlevel,entry.type_acc,(sum(entry.depit)) as depitbal,sum(entry.credit) as creditbal,(sum(entry.depit)) -sum(entry.credit) as def,sum(opening_bal) as opening_bal from entry  left join main_sub on entry.acc_num= main_sub.acc_num left join tree on entry.acc_num = tree.rootid where  tree.sort='قائمه دخل' group by entry.acc_num, entry.acc_name,entry.rootlevel ,entry.type_acc ,main_sub.value,main_sub.acc_name order by entry.rootlevel "), dt);

        }


    }
}