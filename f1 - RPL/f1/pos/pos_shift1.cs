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
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports;

namespace f1.pos
{
    public partial class pos_shift1 : DevExpress.XtraEditors.XtraForm
    {
        public pos_shift1()
        {
            InitializeComponent();
          //  this.edit = false;
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
            db.Open();
           
            
        }
        private void Pos_shift1_Load(object sender, EventArgs e)
        {
          //  try
            {
                d1.Text = DateTime.Now.ToString(v.current_yaer + "/01/01");
                d2.Text = DateTime.Now.ToString(v.current_yaer + "/MM/dd");

                dt1_inv.Text = DateTime.Now.ToString(v.current_yaer + "/01/01");
                dt2_inv.Text = DateTime.Now.ToString(v.current_yaer + "/MM/dd");

                all_comb.load_emp_users(this.combo_empname);
                all_comb.load_emp_no(this.combo_empcode);
                this.combo_empname.Text = "";
                this.combo_empcode.Text = "";
                // this.lbl_shift_no.Caption = pos_sheft.get_shift_no();

                //state_shift
                //open_shift
                //close_shift
                //det_shift
                this.group_state.Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='state_shift'").Rows[0][0].ToString());

                this.group_open_shift.Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='open_shift'").Rows[0][0].ToString());
                this.group_close.Visible = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='close_shift'").Rows[0][0].ToString());
                this.xtraTabPage2.PageEnabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='det_shift'").Rows[0][0].ToString());
                this.xtraTabPage4.PageEnabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='det_shift'").Rows[0][0].ToString());
                this.xtraTabPage3.PageEnabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='det_shift'").Rows[0][0].ToString());
                this.xtraTabPage5.PageEnabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='det_shift'").Rows[0][0].ToString());

                //   this.xtraTabPage4.PageEnabled = Convert.ToBoolean(db.GetData("select torf from pos_permission where user_code='" + v.usercode + "' and unite='shift_detials'").Rows[0][0].ToString());
                this.dt_piker.Text = DateTime.Now.ToString(Convert.ToInt32(db.GetData("select period from info_co").Rows[0][0].ToString()) + "/MM/dd");
                //  this.lbl_user_code.Text = v.usercode;
                //  this.lbl_user_name.Text = v.username;

              
            }
            //catch (Exception)
            //{


            //}
        }

        //no dgv
        //_________________
        private void Dgv_state_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv_state,"no_state");

        }

        private void Dgv_open_shift_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv_open_shift,"no_open");

        }

        private void Dgv_close_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv_close,"no_close");

        }

       

       

        //add employee to open shift
        //_________________________________
        private void Btn_add_Click(object sender, EventArgs e)
        {
           dgv_open_shift.Rows.Add(0,0, combo_empcode.Text, combo_empname.Text,DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),0, "اضغط لاضافه وردية");
        }
        private static string get_shift_no()
        {
            string str2 = db.GetData("select isnull(max(shift_no),0) from pos_shift ").Rows[0][0].ToString();
            if (str2 != "0")
                return str2 = (Convert.ToInt64(str2)+1)+"";
            else
            {
                return str2 = "1";
            }
           
        }
        private void Dgv_open_shift_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 6)
                return;
            if (dgv_open_shift.Rows.Count < 0)
            {
               XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "اضف مستخدمين لكي تفتح ورديه  ", "Shift", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                string cash_account_user = "";
                 cash_account_user = db.GetData("select isnull(max(cash_main),0) from pos_cash_account where user_code='" + this.dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "'").Rows[0][0].ToString();
                if (cash_account_user == "0")
                {
                    XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "يجب ربط المستخدم بحساب  ", "Shift", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else if (db.GetData("select isnull(max(lock),0) from pos_shift where emp_code='" + this.dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "'").Rows[0][0].ToString() == "1")
                {
                    XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "الورديه مفتواحه بالفعل  ", "Shift", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    dgv_open_shift.CurrentRow.Cells[6].Value = "الورديه مفتواحه بالفعل";
                }
                else
                {
                    string shiftNo = get_shift_no();
                    db.Run("insert into pos_shift(shift_no, emp_code, emp_name, date_open_shift, date_cloes_shift, data_def, bal_open, bal_cloes, bal_account, bal_actual,def_bal, cash, credit,tot,lock) values ('" + shiftNo + "','" + this.dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value.ToString() + "','" + this.dgv_open_shift.CurrentRow.Cells["emp_name_o"].Value.ToString() + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','0','" + this.dgv_open_shift.CurrentRow.Cells["bal_open_o"].Value.ToString() + "','0','0','0','0','0','0','0','1')      ");
                    db.Run("insert into pos_cash(code_cash, name_cash, shift_no, user_code, balance, cash_account_user,type,currency_name)values('1','cash','" + shiftNo + "','" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value.ToString() + "','"+ dgv_open_shift.CurrentRow.Cells["bal_open_o"].Value.ToString() + "','null','null',(select top 1 currance from currance))");

                    //                    db.Run("insert into pos_cash(code_cash, name_cash, shift_no, user_code, balance,cash_account_user)values('1','cash','" + shiftNo + "','" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value.ToString() + "','" + dgv_open_shift.CurrentRow.Cells["bal_open_o"].Value.ToString() + "','" + cash_account_user + "')");
                    //add visa 
                    try
                    {
                        string name_cash21 = db.GetData("select isnull(max(cash1_name),0) from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                        string name_cash22 = db.GetData("select isnull(max(cash2_name),0) from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                        string name_cash23 = db.GetData("select isnull(max(cash3_name),0) from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                        string name_cash24 = db.GetData("select isnull(max(cash4_name),0) from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                        string name_cash25 = db.GetData("select isnull(max(cash5_name),0) from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                        string name_cash26 = db.GetData("select isnull(max(cash6_name),0) from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                        string name_cash27 = db.GetData("select isnull(max(cash7_name),0) from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                        string name_cash28 = db.GetData("select isnull(max(cash8_name),0) from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                        string name_cash29 = db.GetData("select isnull(max(cash9_name),0) from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                        string name_cash210 = db.GetData("select isnull(max(cash10_name),0) from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                        //==============================
                        if ( name_cash21 != "0" && name_cash21 != "")
                        {
                            string cash_account_user21 = db.GetData("select cash1_account from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                            string type21 = db.GetData("select cash1_type from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                            string currency_name21 = db.GetData("select cash1_currency from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                            db.Run("insert into pos_cash(code_cash, name_cash, shift_no, user_code, balance, cash_account_user,type,currency_name)values('21','" + name_cash21 + "','" + shiftNo + "','" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value.ToString().Trim() + "',0,'" + cash_account_user21 + "','" + type21 + "','" + currency_name21 + "')");
                        }
                        if ( name_cash22 != "0" && name_cash22 != "")
                        {
                            string cash_account_user22 = db.GetData("select cash2_account from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                            string type22 = db.GetData("select cash2_type from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                            string currency_name22 = db.GetData("select cash2_currency from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                            db.Run("insert into pos_cash(code_cash, name_cash, shift_no, user_code, balance, cash_account_user,type,currency_name)values('22','" + name_cash22 + "','" + shiftNo + "','" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value.ToString().Trim() + "',0,'" + cash_account_user22 + "','" + type22 + "','" + currency_name22 + "')");
                        }
                        if ( name_cash23 != "0" && name_cash23 != "")
                        {
                            string cash_account_user23 = db.GetData("select cash3_account from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                            string type23 = db.GetData("select cash3_type from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                            string currency_name23 = db.GetData("select cash3_currency from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                            db.Run("insert into pos_cash(code_cash, name_cash, shift_no, user_code, balance, cash_account_user,type,currency_name)values('23','" + name_cash23 + "','" + shiftNo + "','" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value.ToString().Trim() + "',0,'" + cash_account_user23 + "','" + type23 + "','" + currency_name23 + "')");
                        }
                        if ( name_cash24 != "0" && name_cash24 != "")
                        {
                            string cash_account_user24 = db.GetData("select cash4_account from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                            string type24 = db.GetData("select cash4_type from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                            string currency_name24 = db.GetData("select cash4_currency from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                            db.Run("insert into pos_cash(code_cash, name_cash, shift_no, user_code, balance, cash_account_user,type,currency_name)values('24','" + name_cash24 + "','" + shiftNo + "','" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value.ToString().Trim() + "',0,'" + cash_account_user24 + "','" + type24 + "','" + currency_name24 + "')");
                        }
                        if ( name_cash25 != "0" && name_cash25 != "")
                        {
                            string cash_account_user25 = db.GetData("select cash5_account from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                            string type25 = db.GetData("select cash5_type from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                            string currency_name25 = db.GetData("select cash5_currency from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                            db.Run("insert into pos_cash(code_cash, name_cash, shift_no, user_code, balance, cash_account_user,type,currency_name)values('25','" + name_cash25 + "','" + shiftNo + "','" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value.ToString().Trim() + "',0,'" + cash_account_user25 + "','" + type25 + "','" + currency_name25 + "')");
                        }
                        if ( name_cash26 != "0" && name_cash26 != "")
                        {
                            string cash_account_user26 = db.GetData("select cash6_account from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                            string type26 = db.GetData("select cash6_type from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                            string currency_name26 = db.GetData("select cash6_currency from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                            db.Run("insert into pos_cash(code_cash, name_cash, shift_no, user_code, balance, cash_account_user,type,currency_name)values('26','" + name_cash26 + "','" + shiftNo + "','" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value.ToString().Trim() + "',0,'" + cash_account_user26 + "','" + type26 + "','" + currency_name26 + "')");
                        }
                        if ( name_cash27!= "0" && name_cash27 != "")
                        {
                            string cash_account_user27 = db.GetData("select cash7_account from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                            string type27 = db.GetData("select cash7_type from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                            string currency_name27 = db.GetData("select cash7_currency from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                            db.Run("insert into pos_cash(code_cash, name_cash, shift_no, user_code, balance, cash_account_user,type,currency_name)values('27','" + name_cash27 + "','" + shiftNo + "','" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value.ToString().Trim() + "',0,'" + cash_account_user27 + "','" + type27 + "','" + currency_name27 + "')");
                        }
                        if (name_cash28 != "0" && name_cash28 != "")
                        {
                            string cash_account_user28 = db.GetData("select cash8_account from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                            string type28 = db.GetData("select cash8_type from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                            string currency_name28 = db.GetData("select cash8_currency from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                            db.Run("insert into pos_cash(code_cash, name_cash, shift_no, user_code, balance, cash_account_user,type,currency_name)values('28','" + name_cash28 + "','" + shiftNo + "','" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value.ToString().Trim() + "',0,'" + cash_account_user28 + "','" + type28 + "','" + currency_name28 + "')");
                        }
                        if ( name_cash29 != "0" && name_cash29 != "")
                        {
                            string cash_account_user29 = db.GetData("select cash9_account from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                            string type29 = db.GetData("select cash9_type from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                            string currency_name29 = db.GetData("select cash9_currency from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                            db.Run("insert into pos_cash(code_cash, name_cash, shift_no, user_code, balance, cash_account_user,type,currency_name)values('29','" + name_cash29 + "','" + shiftNo + "','" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value.ToString().Trim() + "',0,'" + cash_account_user29 + "','" + type29 + "','" + currency_name29 + "')");
                        }
                        if ( name_cash210 != "0" && name_cash210 != "")
                        {
                            string cash_account_user210 = db.GetData("select cash10_account from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                            string type210 = db.GetData("select cash10_type from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                            string currency_name210 = db.GetData("select cash10_currency from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value + "' ").Rows[0][0].ToString().Trim();
                            db.Run("insert into pos_cash(code_cash, name_cash, shift_no, user_code, balance, cash_account_user,type,currency_name)values('210','" + name_cash210 + "','" + shiftNo + "','" + dgv_open_shift.CurrentRow.Cells["emp_code_o"].Value.ToString().Trim() + "',0,'" + cash_account_user210 + "','" + type210 + "','" + currency_name210 + "')");
                        }
                        //========================================
                        //entry 

                        //insert Entry to take mony from main cash
                        //_________________________________________________
                        string cash_main = db.GetData("select cash_main from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells[2].Value + "' ").Rows[0][0].ToString();
                        string medil = db.GetData("select medil from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells[2].Value + "' ").Rows[0][0].ToString();
                        string code_book = db.GetData("select code_book from pos_cash_account where user_code='" + dgv_open_shift.CurrentRow.Cells[2].Value + "' ").Rows[0][0].ToString();
                        string open_shift = dgv_open_shift.CurrentRow.Cells["bal_open_o"].Value.ToString();



                        //entry dt
                        string cash = open_shift;
                        string x = "002";  //OPINING CASH 002
                        if (Convert.ToDouble(cash) != 0)
                        {
                            db.Run("insert into entry(  [code_entry]                           ,    acc_num             ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                               ,   sort                                                            , type_acc                                                       ,             depit                                                             ,                credit                 ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext )values('" +
                                                    x + "'                           ,'" + medil + "'     ,(select top 1 rootname from tree where rootid='" + medil + "')               ,  (select top 1 RootLevel  from tree where rootid='" + medil + "')    ,  (select top 1 rootlevel_name from entry where acc_num='" + medil + "'), (select top 1 sort from entry where acc_num='" + medil + "')       ,  (select top 1 type_acc from entry where acc_num='" + medil + "')  ,  '" + Convert.ToDecimal(cash) + "'  ,0 , 'POS','" + code_book + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + shiftNo + "','POS','POS','POS ')");

                            db.Run("insert into entry(  [code_entry]                           ,    acc_num             ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                               ,   sort                                                            , type_acc                                                       ,             depit                                                             ,                credit                 ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext )values('" +
                                                     x + "'                           ,'" + cash_main + "'     ,(select top 1 rootname from tree where rootid='" + cash_main + "')               ,  (select top 1 RootLevel  from tree where rootid='" + cash_main + "')    ,  (select top 1 rootlevel_name from entry where acc_num='" + cash_main + "'), (select top 1 sort from entry where acc_num='" + cash_main + "')       ,  (select top 1 type_acc from entry where acc_num='" + cash_main + "')  ,0,  '" + Convert.ToDecimal(cash) + "'   , 'POS','" + code_book + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + shiftNo + "','POS','POS','POS ')");
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                    db.Run("insert into action(emp_code,user_name,action,[state],[date],[time])values('" +v.usercode + "','" + v.usercode + "','open shift  opening bal shift +" + dgv_open_shift.CurrentRow.Cells["bal_open_o"].Value + "','insert',getdate(),CAST(GETDATE() AS TIME))");
                    XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "تم فتح الورديه ", "Shift", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    dgv_open_shift.CurrentRow.Cells[6].Value = "الوردية تم فتحها";
                }
            }
        }

        private void Combo_empcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo_empname.Text = db.GetData("select isnull(max(emp_name),0) from emps where emp_no='"+combo_empcode.Text+"'").Rows[0][0].ToString();

        }

        private void Combo_empname_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo_empcode.Text = db.GetData("select isnull(max(emp_no),0) from emps where emp_name='"+combo_empname.Text+"'").Rows[0][0].ToString();

        }
        //state shift 
        //________________________
     
        private void load_sheft()
        {
            DataTable tb = new DataTable();
            string q = db.GetData("select isnull(max(lock),0) from pos_shift where shift_no=(select isnull(max(shift_no),0) from pos_shift)").Rows[0][0].ToString();
            if (q == "1")
            {
                db.GetData_DGV("select shift_no, emp_code, emp_name, date_open_shift,CONVERT(nvarchar(5),datediff(HOUR,date_open_shift,GETDATE()))+':'+CONVERT(nvarchar(5),datediff(MINUTE,date_open_shift,GETDATE())) as hh ,  bal_account,(select sum(balance) from pos_cash where shift_no=pos_shift.shift_no and user_code=pos_shift.emp_code and code_cash='1') as cash,(select sum(balance) from pos_cash where shift_no=pos_shift.shift_no and user_code=pos_shift.emp_code and code_cash='21') as visa from pos_shift where lock='1'", tb);
                this.dgv_state.DataSource = tb;
            }
            else
            {
                db.GetData_DGV("select shift_no, emp_code, emp_name, date_open_shift,CONVERT(nvarchar(5),datediff(HOUR,date_open_shift,GETDATE()))+':'+CONVERT(nvarchar(5),datediff(MINUTE,date_open_shift,GETDATE())) as hh ,  bal_account,(select sum(balance) from pos_cash where shift_no=pos_shift.shift_no and user_code=pos_shift.emp_code and code_cash='1') as cash,(select sum(balance) from pos_cash where shift_no=pos_shift.shift_no and user_code=pos_shift.emp_code and code_cash='21') as visa from pos_shift where lock='1'", tb);
                this.dgv_state.DataSource = tb;
            }
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            //this.lbl_time.Text = DateTime.Now.ToString("HHmmss");
            //this.timer_par.Caption = DateTime.Now.ToString("hh:mm:ss ");
            //this.bar_data1.Caption = DateTime.Now.ToString("yyyy:MM:dd ");
           load_sheft();
        }
        //convert shift from state to close 
        //________________________________________
        private void Dgv_state_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgv_close.Rows.Count >= 1)
                return;
            string open_shift = db.GetData("select isnull(max(bal_open),0) from pos_shift where  shift_no='"+ dgv_state.CurrentRow.Cells["shift_no_s"].Value.ToString() + "'").Rows[0][0].ToString();
            string clos_shift = db.GetData("select isnull(max(balance),0) from pos_cash where user_code='" + dgv_state.CurrentRow.Cells["emp_code_s"].Value.ToString() + "'and shift_no='"+ dgv_state.CurrentRow.Cells["shift_no_s"].Value.ToString() + "'").Rows[0][0].ToString();


            dgv_close.Rows.Add(0 ,dgv_state.CurrentRow.Cells["shift_no_s"].Value ,dgv_state.CurrentRow.Cells["emp_code_s"].Value , dgv_state.CurrentRow.Cells["emp_name_s"].Value , dgv_state.CurrentRow.Cells["date_open_shift_s"].Value , dgv_state.CurrentRow.Cells["hh_s"].Value , open_shift ,clos_shift , clos_shift ,0  , dgv_state.CurrentRow.Cells["cash_s"].Value, dgv_state.CurrentRow.Cells["visa_s"].Value);
            calc_all();

           
        }
        string numBook_entry = "";
        string error = "";
        private int num_entry = 0;
        private void Btn_clos_shift_Click(object sender, EventArgs e)
        {
            string pind_invoice = db.GetData("select   ISNULL(MAX(shift_no),'0') from pos_pending where shift_no='" + dgv_close.Rows[0].Cells["shift_no_c"].Value+"'").Rows[0][0] + "";
            if (dgv_close.Rows.Count < 1)
            {
                 MessageBox.Show("يجب اختيار وردية ليتم إغلاقها");
            }
            else if (pind_invoice!="0")
            {
                MessageBox.Show(pind_invoice + " هناك فواتير معلقة لم تغلق في وردية");
                return;
            }
            else
            {
                if (XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "سينم إغلاق الوردية ", "رسال تاكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
                    return;

                //1)
                //1-EGB  main cash 
                //2-VISA 
                //3-USD Other Currency
                //4-Credit VCS
                //revenue sales 

                //2)
                //cogs 
                //inventory

               // string menu_items = db.GetData("select code_items from pos_dt where shift_no=''").Rows[0][0].ToString();
                
                string cash_main= db.GetData("select cash_main from pos_cash_account where user_code='" + dgv_close.Rows[0].Cells["emp_code_c"].Value + "' ").Rows[0][0].ToString();
                string sales_acc = db.GetData("select sales_acc from pos_cash_account where user_code='" + dgv_close.Rows[0].Cells["emp_code_c"].Value + "' ").Rows[0][0].ToString();
                string re_sales_acc= db.GetData("select re_sales_acc from pos_cash_account where user_code='" + dgv_close.Rows[0].Cells["emp_code_c"].Value + "' ").Rows[0][0].ToString();
                string disocount = db.GetData("select disocount from pos_cash_account where user_code='" + dgv_close.Rows[0].Cells["emp_code_c"].Value + "' ").Rows[0][0].ToString();
                string wares= db.GetData("select wares from pos_cash_account where user_code='" + dgv_close.Rows[0].Cells["emp_code_c"].Value + "' ").Rows[0][0].ToString();
                string wares_gl = db.GetData("select rootid from wares_acc where id_ware='"+wares+"' and acc_id='1'").Rows[0][0].ToString();
                string code_book= db.GetData("select code_book from pos_cash_account where user_code='" + dgv_close.Rows[0].Cells["emp_code_c"].Value + "' ").Rows[0][0].ToString();
                string cogs = db.GetData("select cogs from pos_cash_account where user_code='" + dgv_close.Rows[0].Cells["emp_code_c"].Value + "' ").Rows[0][0].ToString();
                string def_or_inc= db.GetData("select def_or_inc from pos_cash_account where user_code='" + dgv_close.Rows[0].Cells["emp_code_c"].Value + "' ").Rows[0][0].ToString();
                string code_book_term = db.GetData("select code_book from pos_cash_account where user_code='" + dgv_close.Rows[0].Cells["emp_code_c"].Value + "' ").Rows[0][0].ToString();

                //                string medil = db.GetData("select medil from pos_cash_account where user_code='" + dgv_close.Rows[0].Cells["emp_code_c"].Value + "' ").Rows[0][0].ToString();


                string cash1_account =db.GetData("select cash1_account from pos_cash_account where user_code='" + dgv_close.Rows[0].Cells["emp_code_c"].Value + "' ").Rows[0][0].ToString();
                string cash2_account = db.GetData("select cash2_account from pos_cash_account where user_code='" + dgv_close.Rows[0].Cells["emp_code_c"].Value + "' ").Rows[0][0].ToString();
                string cash3_account = db.GetData("select cash3_account from pos_cash_account where user_code='" + dgv_close.Rows[0].Cells["emp_code_c"].Value + "' ").Rows[0][0].ToString();
                string cash4_account = db.GetData("select cash4_account from pos_cash_account where user_code='" + dgv_close.Rows[0].Cells["emp_code_c"].Value + "' ").Rows[0][0].ToString();
                string cash5_account = db.GetData("select cash5_account from pos_cash_account where user_code='" + dgv_close.Rows[0].Cells["emp_code_c"].Value + "' ").Rows[0][0].ToString();
                string cash6_account = db.GetData("select cash6_account from pos_cash_account where user_code='" + dgv_close.Rows[0].Cells["emp_code_c"].Value + "' ").Rows[0][0].ToString();
                string cash7_account = db.GetData("select cash7_account from pos_cash_account where user_code='" + dgv_close.Rows[0].Cells["emp_code_c"].Value + "' ").Rows[0][0].ToString();
                string cash8_account = db.GetData("select cash8_account from pos_cash_account where user_code='" + dgv_close.Rows[0].Cells["emp_code_c"].Value + "' ").Rows[0][0].ToString();
                string cash9_account = db.GetData("select cash9_account from pos_cash_account where user_code='" + dgv_close.Rows[0].Cells["emp_code_c"].Value + "' ").Rows[0][0].ToString();
                string cash10_account = db.GetData("select cash10_account from pos_cash_account where user_code='" + dgv_close.Rows[0].Cells["emp_code_c"].Value + "' ").Rows[0][0].ToString();

                string costcenter_id = db.GetData("select isnull(max(costcenter_id),'NULL')  from pos_cash_account where user_code='" + dgv_close.Rows[0].Cells["emp_code_c"].Value + "' ").Rows[0][0].ToString();

                string open_shift = db.GetData("select isnull(max(bal_open),0) from pos_shift where  shift_no='" + dgv_state.CurrentRow.Cells["shift_no_s"].Value.ToString() + "'").Rows[0][0].ToString();

                string o_s = dgv_close.Rows[0].Cells["shift_no_c"].Value.ToString();
                //insert entry_hd
                string code_entry_dt = db.GetData("select (max(convert(int,(right( CODE_ENTRY , len(CODE_ENTRY)-3)))))+1 from entry WHERE code_book='" + code_book + "'").Rows[0][0].ToString();
                string code_entry_hd = db.GetData("select (max(convert(int,(right( CODE_ENTRY , len(CODE_ENTRY)-3)))))+1 from entry_hd WHERE code_book='" + code_book + "'").Rows[0][0].ToString();

                   if (code_entry_dt != code_entry_hd)
                   {
                    string error_code= db.GetData("select (max(convert(int,(right( CODE_ENTRY , len(CODE_ENTRY)-3))))) from entry_hd WHERE code_book='" + code_book + "'").Rows[0][0].ToString();
                    db.Run("delete from entry_hd where code_entry ='"+code_book+error_code+"'");
                   }
          
//                string text_code = code_book + code_entry_dt;
  //              string code_entry = text_code;

               
                string code_entry ="";


               // string code_entry_term = (db.GetData("select code_entry from term where term_id='" + combo_type.Text + "' ").Rows[0][0].ToString());
                cls_book.Generat_numBooknum("entry", code_book_term, ref numBook_entry, ref error, ref num_entry);
                code_entry = numBook_entry;
                db.Run("insert into entry_hd ([code_entry],code_book) values ('" + code_entry + "','" + code_book + "')");

                //1*)EXPENSSEs pos
                //__________________________
                db.Run("update entry set code_entry='" + code_entry + "' ,  num_book='"+num_entry+"' where  attachno='" + o_s + "' and attachbook='POS exp' and code_entry='003'");
                //entry_dt
                //to remove temprrery entry of visa  and open balance decres cash 
                db.Run("delete from entry where code_entry='001'and attachno='"+ dgv_close.Rows[0].Cells["shift_no_c"].Value.ToString() + "'");
                db.Run("delete from entry where code_entry='002'and attachno='" + dgv_close.Rows[0].Cells["shift_no_c"].Value.ToString() + "'"); //OPENING CASH
                db.Run("delete from entry where code_entry='003'and attachno='" + dgv_close.Rows[0].Cells["shift_no_c"].Value.ToString() + "' and attachbook='POS exp cash'"); //EXPENSSE POS
                //DELETE EXP
                db.Run("delete from entry where attachno='" + o_s + "'and attachbook='pos' and attachnamebook<>'POS credit' ");
                //2*)MAIN CASH 
                //__________________________
                string cash = db.GetData("select isnull(max(balance* c.f_currance),0) from pos_cash  p left join currance c on p.currency_name=c.currance where user_code='" + dgv_close.Rows[0].Cells["emp_code_c"].Value.ToString() + "' and shift_no='" + dgv_close.Rows[0].Cells["shift_no_c"].Value.ToString() + "' and code_cash='1'").Rows[0][0].ToString();
                cash = (Convert.ToDouble(cash) - Convert.ToDouble(open_shift) + "");
                if (Convert.ToDouble(cash) > 0 )
                {
                    db.Run("insert into entry(  [code_entry]                           ,    acc_num             ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                               ,   sort                                                            , type_acc                                                       ,             depit                                                             ,                credit                 ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext ,num_book)values('" +
                                             code_entry + "'                           ,'" + cash_main + "'     ,(select top 1 rootname from tree where rootid='" + cash_main + "')               ,  (select top 1 RootLevel from tree where rootid='" + cash_main + "')    ,  (select top 1 rootlevel_name from entry where acc_num='" + cash_main + "'), (select top 1 sort from entry where acc_num='" + cash_main + "')       ,  (select top 1 type_acc from entry where acc_num='" + cash_main + "')  ,  '" + Convert.ToDecimal(cash) + "' ,0  , 'POS','" + code_book + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','"+o_s+"','POS','POS','POS ','"+num_entry+"')");
                }
               
                //2)cash1_account
                //__________________________
                string cash1_account_mony = db.GetData("select isnull(max(balance* c.f_currance),0) from pos_cash  p left join currance c on p.currency_name=c.currance where user_code='" + dgv_close.Rows[0].Cells["emp_code_c"].Value.ToString() + "' and shift_no='" + dgv_close.Rows[0].Cells["shift_no_c"].Value.ToString() + "' and code_cash='21'").Rows[0][0].ToString();
                if (Convert.ToDouble(cash1_account_mony) > 0)
                {
                    db.Run("insert into entry(  [code_entry]                           ,    acc_num             ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                               ,   sort                                                            , type_acc                                                       ,             depit                                                             ,                credit                 ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext,num_book )values('" +
                                             code_entry + "'                           ,'" + cash1_account + "'     ,(select top 1 rootname from tree where rootid='" + cash1_account + "')               ,  (select top 1 RootLevel from tree where rootid='" + cash1_account + "')    ,  (select top 1 rootlevel_name from entry where acc_num='" + cash1_account + "'), (select top 1 sort from entry where acc_num='" + cash1_account + "')       ,  (select top 1 type_acc from entry where acc_num='" + cash1_account + "')  ,  '" + Convert.ToDecimal(cash1_account_mony) + "' ,0  , 'POS','"+code_book+"'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','"+o_s+ "','POS','POS','POS ','" + num_entry + "')");
                }
                //3)cash2_account
                //__________________________
                string cash2_account_mony = db.GetData("select isnull(max(balance* c.f_currance),0) from pos_cash  p left join currance c on p.currency_name=c.currance where user_code='" + dgv_close.Rows[0].Cells["emp_code_c"].Value.ToString() + "' and shift_no='" + dgv_close.Rows[0].Cells["shift_no_c"].Value.ToString() + "' and code_cash='22'").Rows[0][0].ToString();
                if (Convert.ToDouble(cash2_account_mony) > 0)
                {
                    db.Run("insert into entry(  [code_entry]                           ,    acc_num             ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                               ,   sort                                                            , type_acc                                                       ,             depit                                                             ,                credit                 ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext ,num_book)values('" +
                                             code_entry + "'                           ,'" + cash2_account + "'     ,(select top 1 rootname from tree where rootid='" + cash2_account + "')               ,  (select top 1 RootLevel from tree where rootid='" + cash2_account + "')    ,  (select top 1 rootlevel_name from entry where acc_num='" + cash2_account + "'), (select top 1 sort from entry where acc_num='" + cash2_account + "')       ,  (select top 1 type_acc from entry where acc_num='" + cash2_account + "')  ,  '" + Convert.ToDecimal(cash2_account_mony) + "' ,0  , 'POS','"+code_book+"'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','"+o_s+ "','POS','POS','POS ','" + num_entry + "')");
                }
                //4)cash3_account
                //__________________________
                string cash3_account_mony = db.GetData("select isnull(max(balance* c.f_currance),0) from pos_cash  p left join currance c on p.currency_name=c.currance where user_code='" + dgv_close.Rows[0].Cells["emp_code_c"].Value.ToString() + "' and shift_no='" + dgv_close.Rows[0].Cells["shift_no_c"].Value.ToString() + "' and code_cash='23'").Rows[0][0].ToString();
                if (Convert.ToDouble(cash3_account_mony) > 0)
                {
                    db.Run("insert into entry(  [code_entry]                           ,    acc_num             ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                               ,   sort                                                            , type_acc                                                       ,             depit                                                             ,                credit                 ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext ,num_book)values('" +

                                             code_entry + "'                           ,'" + cash3_account + "'     ,(select top 1 rootname from tree where rootid='" + cash3_account + "')               ,  (select top 1 RootLevel from tree where rootid='" + cash3_account + "')    ,  (select top 1 rootlevel_name from entry where acc_num='" + cash3_account + "'), (select top 1 sort from entry where acc_num='" + cash3_account + "')       ,  (select top 1 type_acc from entry where acc_num='" + cash3_account + "')  ,  '" + Convert.ToDecimal(cash3_account_mony) + "' ,0  , 'POS','"+code_book+"'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','"+o_s+ "','POS','POS','POS ','" + num_entry + "')");
                }
                //5)cash4_account
                //__________________________
                string cash4_account_mony = db.GetData("select isnull(max(balance* c.f_currance),0) from pos_cash  p left join currance c on p.currency_name=c.currance where user_code='" + dgv_close.Rows[0].Cells["emp_code_c"].Value.ToString() + "' and shift_no='" + dgv_close.Rows[0].Cells["shift_no_c"].Value.ToString() + "' and code_cash='24'").Rows[0][0].ToString();
                if (Convert.ToDouble(cash4_account_mony) > 0)
                {
                    db.Run("insert into entry(  [code_entry]                           ,    acc_num             ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                               ,   sort                                                            , type_acc                                                       ,             depit                                                             ,                credit                 ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext ,num_book)values('" +

                                             code_entry + "'                           ,'" + cash4_account + "'     ,(select top 1 rootname from tree where rootid='" + cash4_account + "')               ,  (select top 1 RootLevel from tree where rootid='" + cash4_account + "')    ,  (select top 1 rootlevel_name from entry where acc_num='" + cash4_account + "'), (select top 1 sort from entry where acc_num='" + cash4_account + "')       ,  (select top 1 type_acc from entry where acc_num='" + cash4_account + "')  ,  '" + Convert.ToDecimal(cash4_account_mony) + "' ,0  , 'POS','"+code_book+"'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','"+o_s+ "','POS','POS','POS ','" + num_entry + "')");
                }
                //6)cash5_account
                //__________________________
                string cash5_account_mony = db.GetData("select isnull(max(balance* c.f_currance),0) from pos_cash  p left join currance c on p.currency_name=c.currance where user_code='" + dgv_close.Rows[0].Cells["emp_code_c"].Value.ToString() + "' and shift_no='" + dgv_close.Rows[0].Cells["shift_no_c"].Value.ToString() + "' and code_cash='25'").Rows[0][0].ToString();
                if (Convert.ToDouble(cash5_account_mony) > 0) 
                {
                    db.Run("insert into entry(  [code_entry]                           ,    acc_num             ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                               ,   sort                                                            , type_acc                                                       ,             depit                                                             ,                credit                 ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext ,num_book)values('" +

                                             code_entry + "'                           ,'" + cash5_account + "'     ,(select top 1 rootname from tree where rootid='" + cash5_account + "')               ,  (select top 1 RootLevel from tree where rootid='" + cash5_account + "')    ,  (select top 1 rootlevel_name from entry where acc_num='" + cash5_account + "'), (select top 1 sort from entry where acc_num='" + cash5_account + "')       ,  (select top 1 type_acc from entry where acc_num='" + cash5_account + "')  ,  '" + Convert.ToDecimal(cash5_account_mony) + "' ,0  , 'POS','"+code_book+"'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','"+o_s+ "','POS','POS','POS ','" + num_entry + "')");
                }
                //7)cash6_account
                //__________________________
                //8)cash7_account
                //__________________________
                //9)cash8_account
                //__________________________
                //10)cash9_account
                //__________________________
                //11)cash10_account
                //__________________________

                //3*)DISCOUNT
                //__________________________________
                //1)discount
                string x = db.GetData("select isnull(sum(discount_all),0)   from pos_dt  where user_code='" + dgv_close.Rows[0].Cells["emp_code_c"].Value.ToString() + "' and shift_no='" + dgv_close.Rows[0].Cells["shift_no_c"].Value.ToString() + "' ").Rows[0][0].ToString();
                double tot_discount = 0;
                tot_discount = Convert.ToDouble(x);

                if (tot_discount > 0)
                {
                    db.Run("insert into entry(  [code_entry]                           ,    acc_num             ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                               ,   sort                                                            , type_acc                                                       ,             depit                                                             ,                credit                 ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext,num_book )values('" +

                                      code_entry + "'                           ,'" + disocount + "'     ,(select top 1 rootname from tree where rootid='" + disocount + "')               ,  (select top 1 RootLevel from tree where rootid='" + disocount + "')    ,  (select top 1 rootlevel_name from entry where acc_num='" + disocount + "'), (select top 1 sort from entry where acc_num='" + disocount + "')       ,  (select top 1 type_acc from entry where acc_num='" + disocount + "')  ,  '" + Convert.ToDecimal(tot_discount) + "'  ,'0', 'POS','" + code_book + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + o_s + "','POS','POS','Allaw Discount ','" + num_entry + "')");
                }
                //4*)inc and def
                //___________________________________
                if (dgv_close.Rows[0].Cells["def_c"].Value.ToString() == "") dgv_close.Rows[0].Cells["def_c"].Value = "0";

                double d_f = Convert.ToDouble(dgv_close.Rows[0].Cells["def_c"].Value);
                if (d_f < 0)
                {
                    //increse
                    //1-cash +
                    if (d_f != 0)
                    {
                        d_f *= -1;
                        db.Run("insert into entry(  [code_entry]                           ,    acc_num             ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                               ,   sort                                                            , type_acc                                                       ,             depit                                                             ,                credit                 ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext,num_book )values('" +
                                            code_entry + "'                           ,'" + cash_main + "'     ,(select top 1 rootname from tree where rootid='" + cash_main + "')               ,  (select top 1 RootLevel from tree where rootid='" + cash_main + "')    ,  (select top 1 rootlevel_name from entry where acc_num='" + cash_main + "'), (select top 1 sort from entry where acc_num='" + cash_main + "')       ,  (select top 1 type_acc from entry where acc_num='" + cash_main + "')  ,  '" + Convert.ToDecimal(d_f) + "'  ,'0', 'POS','" + code_book + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + o_s + "','POS','POS','dec and inc ','" + num_entry + "')");
                        //2-ربح و الخساره -
                        db.Run("insert into entry(  [code_entry]                           ,    acc_num             ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                               ,   sort                                                            , type_acc                                                       ,             depit                                                             ,                credit                 ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext ,costcenter_code,num_book)values('" +
                                         code_entry + "'                           ,'" + def_or_inc + "'     ,(select top 1 rootname from tree where rootid='" + def_or_inc + "')               ,  (select top 1 RootLevel from tree where rootid='" + def_or_inc + "')    ,  (select top 1 rootlevel_name from entry where acc_num='" + def_or_inc + "'), (select top 1 sort from entry where acc_num='" + def_or_inc + "')       ,  (select top 1 type_acc from entry where acc_num='" + def_or_inc + "')  , 0, '" + Convert.ToDecimal(d_f) + "'  , 'POS','" + code_book + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + o_s + "','POS','POS','dec and inc ','"+costcenter_id+ "','" + num_entry + "')");

                    }
                }
                else
                {
                    //descres
                    //2-ربح و الخساره -
                    if (d_f != 0)
                    {
                        db.Run("insert into entry(  [code_entry]                           ,    acc_num             ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                               ,   sort                                                            , type_acc                                                       ,             depit                                                             ,                credit                 ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext,costcenter_code,num_book )values('" +
                                     code_entry + "'                           ,'" + def_or_inc + "'     ,(select top 1 rootname from tree where rootid='" + def_or_inc + "')               ,  (select top 1 RootLevel from tree where rootid='" + def_or_inc + "')    ,  (select top 1 rootlevel_name from entry where acc_num='" + def_or_inc + "'), (select top 1 sort from entry where acc_num='" + def_or_inc + "')       ,  (select top 1 type_acc from entry where acc_num='" + def_or_inc + "')  ,  '" + Convert.ToDecimal(d_f) + "'  ,'0', 'POS','" + code_book + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + o_s + "','POS','POS','dec and inc ','"+costcenter_id+ "','" + num_entry + "')");
                        db.Run("insert into entry(  [code_entry]                           ,    acc_num             ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                               ,   sort                                                            , type_acc                                                       ,             depit                                                             ,                credit                 ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext ,num_book)values('" +
                                          code_entry + "'                           ,'" + cash_main + "'     ,(select top 1 rootname from tree where rootid='" + cash_main + "')               ,  (select top 1 RootLevel from tree where rootid='" + cash_main + "')    ,  (select top 1 rootlevel_name from entry where acc_num='" + cash_main + "'), (select top 1 sort from entry where acc_num='" + cash_main + "')       ,  (select top 1 type_acc from entry where acc_num='" + cash_main + "')  ,'0',  '" + Convert.ToDecimal(d_f) + "'  , 'POS','" + code_book + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + o_s + "','POS','POS','dec and inc ','" + num_entry + "')");
                    }
                }
                //5*)SALES 
                //____________________________
                DataTable dt = new DataTable();
                //db.GetData_DGV("select balance* c.f_currance ,currency_name from  pos_cash p left join currance c on p.currency_name =c.currance  where user_code='"+ dgv_close.Rows[0].Cells["emp_code_c"].Value + "'and shift_no='" + dgv_close.Rows[0].Cells["shift_no_c"].Value + "'   ", dt);
                db.GetData_DGV("select isnull(sum(incloud_taxes),0),(select top 1 f_currance from currance),(select top 1 currance from currance) from pos_dt where shift_no='" + dgv_close.Rows[0].Cells["shift_no_c"].Value + "'  and state='sal' and onRoll<>'1' ", dt);

                double sum = Convert.ToDouble(dt.Rows[0][0] + "");
                if (sum>0)
                {
                    sum = Convert.ToDouble(dt.Rows[0][0] + "");
                    db.Run("insert into entry(  [code_entry]                           ,    acc_num             ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                               ,   sort                                                            , type_acc                                                       ,             depit                                                             ,                credit                 ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext,costcenter_code ,num_book)values('" +
                                         code_entry + "'                           ,'" + sales_acc + "'     ,(select top 1 rootname from tree where rootid='" + sales_acc + "')               ,  (select top 1 RootLevel from tree where rootid='" + sales_acc + "')    ,  (select top 1 rootlevel_name from entry where acc_num='" + sales_acc + "'), (select top 1 sort from entry where acc_num='" + sales_acc + "')       ,  (select top 1 type_acc from entry where acc_num='" + sales_acc + "')  ,  '0' ,'" + Convert.ToDecimal(sum) + "'  , 'POS','" + code_book + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + o_s + "','POS','POS','POS ','"+costcenter_id+ "','" + num_entry + "')");
                }


                //6*)COGS
                //__________________________________
                DataTable dt_cogs = new DataTable();
                db.GetData_DGV("select p.code_items,isnull(sum(p.qty* f_unite),0),isnull((c.cost),0) as cost ,isnull((c.qty),0) from pos_dt p left join wares c on p.code_items=c.code_items where shift_no='" + dgv_close.Rows[0].Cells["shift_no_c"].Value + "' and p.id_ware='"+wares+ "' and p.state='sal' group by p.code_items, p.name_items, c.cost,c.qty,p.qty", dt_cogs);
                double tot_cogs = 0;
                for (int i = 0; i < dt_cogs.Rows.Count; i++)
                {
                    tot_cogs += Convert.ToDouble(dt_cogs.Rows[i][2] + "")* Convert.ToDouble(dt_cogs.Rows[i][1] + "");
                   
                   
                    //update qty in wares
                    // mins war qty - pos
                    double new_qty = (Convert.ToDouble(dt_cogs.Rows[i][3])) - (Convert.ToDouble(dt_cogs.Rows[i][1]));
                    //insert qty + in wares and make entry <<< <<< insert qty - in item draft
                    if (new_qty >= 0)
                    {
                        db.Run("update wares set qty ='" + new_qty + "' where code_items='" + dt_cogs.Rows[i][0] + "" + "'and id_ware='" + wares + "'");


                        //insert into itesm trans
                        // db.Run()

                        if (tot_cogs != 0)
                        {
                            if (tot_cogs < 0) tot_cogs = tot_cogs * -1;
                            db.Run("insert into entry(  [code_entry]                           ,    acc_num             ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                               ,   sort                                                            , type_acc                                                       ,             depit                                                             ,                credit                 ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext ,costcenter_code,num_book)values('" +
                                               code_entry + "'                           ,'" + cogs + "'     ,(select top 1 rootname from tree where rootid='" + cogs + "')               ,  (select top 1 RootLevel from tree where rootid='" + cogs + "')    ,  (select top 1 rootlevel_name from entry where acc_num='" + cogs + "'), (select top 1 sort from entry where acc_num='" + cogs + "')       ,  (select top 1 type_acc from entry where acc_num='" + cogs + "')   ,'" + Convert.ToDecimal(tot_cogs) + "'  ,'0', 'POS','" + code_book + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + o_s + "','POS','COGS','POS ','"+costcenter_id+ "','" + num_entry + "')");
                            db.Run("insert into entry(  [code_entry]                           ,    acc_num             ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                               ,   sort                                                            , type_acc                                                       ,             depit                                                             ,                credit                 ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext ,num_book)values('" +
                                                                    code_entry + "'                           ,'" + wares_gl + "'     ,(select top 1 rootname from tree where rootid='" + wares_gl + "')               ,  (select top 1 RootLevel from tree where rootid='" + wares_gl + "')    ,  (select top 1 rootlevel_name from entry where acc_num='" + wares_gl + "'), (select top 1 sort from entry where acc_num='" + wares_gl + "')       ,  (select top 1 type_acc from entry where acc_num='" + wares_gl + "')  ,  '0' ,'" + Convert.ToDecimal(tot_cogs) + "'  , 'POS','" + code_book + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + o_s + "','POS','COGS','POS ','" + num_entry + "')");
                            tot_cogs = 0;
                        }
                    }
                    else  //wares_overdraft
                    {
                        db.Run("INSERT INTO [wares_overdraft]([id_ware],[code_items],[qty],[shift_no])values('" + wares + "','" + dt_cogs.Rows[i][0] + "" + "','" + Convert.ToDouble(dt_cogs.Rows[i][1])*-1+"" + "','" + o_s + "')");
                        tot_cogs = 0;
                    }
                }
                

              
                //5)Rsale
                //__________________________
                //1-resale
                string resal= db.GetData("select isnull((SUM(incloud_taxes))*-1,0) from pos_dt where state='re' and shift_no='" + dgv_close.Rows[0].Cells["shift_no_c"].Value + "' and onRoll<>'1'").Rows[0][0].ToString();

                double resum = Convert.ToDouble(resal);
                if (Convert.ToDouble(cash) < 0)
                {
                    db.Run("insert into entry(  [code_entry]                           ,    acc_num             ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                               ,   sort                                                            , type_acc                                                       ,             depit                                                             ,                credit                 ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext,num_book )values('" +
                                             code_entry + "'                           ,'" + cash_main + "'     ,(select top 1 rootname from tree where rootid='" + cash_main + "')               ,  (select top 1 RootLevel from tree where rootid='" + cash_main + "')    ,  (select top 1 rootlevel_name from entry where acc_num='" + cash_main + "'), (select top 1 sort from entry where acc_num='" + cash_main + "')       ,  (select top 1 type_acc from entry where acc_num='" + cash_main + "')  , 0, '" + Convert.ToDecimal(cash)*-1 + "'   , 'POS','" + code_book + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + o_s + "','POS','POS','POS ','" + num_entry + "')");
                }
                if (resum > 0)
                {
                    db.Run("insert into entry(  [code_entry]                           ,    acc_num             ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                               ,   sort                                                            , type_acc                                                       ,             depit                                                             ,                credit                 ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext,costcenter_code,num_book )values('" +
                                         code_entry + "'                           ,'" + re_sales_acc + "'     ,(select top 1 rootname from tree where rootid='" + re_sales_acc + "')               ,  (select top 1 RootLevel from tree where rootid='" + re_sales_acc + "')    ,  (select top 1 rootlevel_name from entry where acc_num='" + re_sales_acc + "'), (select top 1 sort from entry where acc_num='" + re_sales_acc + "')       ,  (select top 1 type_acc from entry where acc_num='" + re_sales_acc + "')   ,'" + Convert.ToDecimal(resum) + "' ,  '0' , 'POS','" + code_book + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','"+o_s+"','POS','POS','POS ','"+costcenter_id+ "','" + num_entry + "')");
                }
                //3-inv   //4-cogs
                DataTable dt_cogsre = new DataTable();
                db.GetData_DGV("select p.code_items,isnull(sum(p.qty* f_unite),0),isnull((c.cost),0) as cost ,isnull((c.qty),0) from pos_dt p left join wares c on p.code_items=c.code_items where shift_no='" + dgv_close.Rows[0].Cells["shift_no_c"].Value + "' and p.id_ware='" + wares + "' and p.state='re' group by p.code_items, p.name_items, c.cost,c.qty,p.qty", dt_cogsre);
                double tot_cogsre = 0;
                for (int i = 0; i < dt_cogsre.Rows.Count; i++)
                {
                    tot_cogsre += Convert.ToDouble(dt_cogsre.Rows[i][2] + "")*Convert.ToDouble(dt_cogsre.Rows[i][1] + "");
                  
                    //update qty in wares
                    double new_qty = (Convert.ToDouble(dt_cogsre.Rows[i][3])) - (Convert.ToDouble(dt_cogsre.Rows[i][1]));
                    if (new_qty > 0)
                    {
                        db.Run("update wares set qty ='" + new_qty + "' where code_items='" + dt_cogsre.Rows[i][0] + "" + "'and id_ware='" + wares + "'");
                        if (tot_cogsre != 0)
                        {
                            if (tot_cogsre < 0) tot_cogsre = tot_cogsre * -1;
                            db.Run("insert into entry(  [code_entry]                           ,    acc_num             ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                               ,   sort                                                            , type_acc                                                       ,             depit                                                             ,                credit                 ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext ,num_book)values('" +
                                                       code_entry + "'                           ,'" + wares_gl + "'     ,(select top 1 rootname from tree where rootid='" + wares_gl + "')               ,  (select top 1 RootLevel from tree where rootid='" + wares_gl + "')    ,  (select top 1 rootlevel_name from entry where acc_num='" + wares_gl + "'), (select top 1 sort from entry where acc_num='" + wares_gl + "')       ,  (select top 1 type_acc from entry where acc_num='" + wares_gl + "')  ,   '" + Convert.ToDecimal(tot_cogsre) + "' ,'0' , 'POS','" + code_book + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + o_s + "','POS','COGS','POS ','" + num_entry + "')");
                            db.Run("insert into entry(  [code_entry]                           ,    acc_num             ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                               ,   sort                                                            , type_acc                                                       ,             depit                                                             ,                credit                 ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext,costcenter_code ,num_book)values('" +
                                                    code_entry + "'                           ,'" + cogs + "'     ,(select top 1 rootname from tree where rootid='" + cogs + "')               ,  (select top 1 RootLevel from tree where rootid='" + cogs + "')    ,  (select top 1 rootlevel_name from entry where acc_num='" + cogs + "'), (select top 1 sort from entry where acc_num='" + cogs + "')       ,  (select top 1 type_acc from entry where acc_num='" + cogs + "')  ,'0' ,'" + Convert.ToDecimal(tot_cogsre) + "'  , 'POS','" + code_book + "'    ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "','" + o_s + "','POS','COGS','POS ','"+costcenter_id+ "','" + num_entry + "')");
                            tot_cogsre = 0;

                        }
                    }
                    else  //wares_overdraft
                    {
                        //db.Run("INSERT INTO [wares_overdraft]([id_ware],[code_items],[qty],[shift_no])values('" + wares + "','" + dt_cogs.Rows[i][0] + "" + "','" + new_qty + "','" + o_s + "')");
                        db.Run("INSERT INTO [wares_overdraft]([id_ware],[code_items],[qty],[shift_no])values('" + wares + "','" + dt_cogs.Rows[i][0] + "" + "','" + Convert.ToDouble(dt_cogs.Rows[i][1]) * -1 + "" + "" + "','" + o_s + "')");
                        tot_cogsre = 0;

                    }
                }
                




                //insert item trans
                //-------------------------------------------
                DataTable dtpos = new DataTable();
                db.GetData_DGV("select code_items,name_items,sum(qty),f_unite,name_unite,exp_date,id_ware,vcs_code,vcs_name,date_d,item_price,shift_no   ,incloud_taxes,discount,discount_all from pos_dt where state='sal' and shift_no='"+ dgv_close.CurrentRow.Cells["shift_no_c"].Value.ToString() + "' and date_d>='"+ Convert.ToDateTime(dgv_close.CurrentRow.Cells["date_open_no_c"].Value).ToString("yyyy-MM-dd") + "' group by code_items, name_items, shift_no, f_unite, name_unite, item_price, incloud_taxes, discount, discount_all, date_d, id_ware, exp_date, vcs_code, vcs_name ", dtpos);
                for (int i = 0; i < dtpos.Rows.Count; i++)
                {
                    db.Run("insert into items_trans (code_items ,name_items ,qty,f_unite ,name_unite ,exp_date ,id_ware ,vcs_code ,vcs_name ,dates ,old_cost ,attachno ,attachbook,attachnamebook) values ('" + dtpos.Rows[i][0] + "" + "','" + dtpos.Rows[i][1] + "" + "','" + dtpos.Rows[i][2] + "" + "','" + dtpos.Rows[i][3] + "" + "','" + dtpos.Rows[i][4] + "" + "','" + dtpos.Rows[i][5] + "" + "','" + dtpos.Rows[i][6] + "" + "','" + dtpos.Rows[i][7] + "" + "','" + dtpos.Rows[i][8] + "" + "','" + Convert.ToDateTime(dtpos.Rows[i][9].ToString()).ToString("MM-dd-yyyy") + "" + "','" + dtpos.Rows[i][10] + "" + "','" + dtpos.Rows[i][11] + "" + "','pos','pos')");
                }

                DataTable dtpos_r = new DataTable();
                db.GetData_DGV("select code_items,name_items,sum(qty),f_unite,name_unite,exp_date,id_ware,vcs_code,vcs_name,date_d,item_price,shift_no   ,incloud_taxes,discount,discount_all from pos_dt where state='re' and shift_no='"+ dgv_close.CurrentRow.Cells["shift_no_c"].Value.ToString() + "' and date_d>='"+ Convert.ToDateTime(dgv_close.CurrentRow.Cells["date_open_no_c"].Value).ToString("yyyy-MM-dd") + "' group by code_items, name_items, shift_no, f_unite, name_unite, item_price, incloud_taxes, discount, discount_all, date_d, id_ware, exp_date, vcs_code, vcs_name ", dtpos_r);
                for (int i = 0; i < dtpos_r.Rows.Count; i++)
                {
                    db.Run("insert into items_trans (code_items ,name_items ,qty,f_unite ,name_unite ,exp_date ,id_ware ,vcs_code ,vcs_name ,dates ,old_cost ,attachno ,attachbook,attachnamebook) values ('" + dtpos_r.Rows[i][0] + "" + "','" + dtpos_r.Rows[i][1] + "" + "','" + dtpos_r.Rows[i][2] + "" + "','" + dtpos_r.Rows[i][3] + "" + "','" + dtpos_r.Rows[i][4] + "" + "','" + dtpos_r.Rows[i][5] + "" + "','" + dtpos_r.Rows[i][6] + "" + "','" + dtpos_r.Rows[i][7] + "" + "','" + dtpos_r.Rows[i][8] + "" + "','" + Convert.ToDateTime(dtpos_r.Rows[i][9].ToString()).ToString("MM-dd-yyyy") + "" + "','" + dtpos_r.Rows[i][10] + "" + "','" + dtpos_r.Rows[i][11] + "" + "','pos','pos')");
                }


                db.Run("insert into action(emp_code,user_name,action,[state],[date],[time],number_record)values('" + v.usercode + "','" + v.usercode + "','  shift mumber:  "+ o_s+ "  ','insert',getdate(),CAST(GETDATE() AS TIME),'" + o_s + "')");
                db.Run("update pos_shift set lock=0 , date_cloes_shift='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',bal_drawer='" + dgv_close.Rows[0].Cells["drawres_c"].Value + "' where shift_no='" + dgv_close.Rows[0].Cells[1].Value + "' and emp_code ='" + dgv_close.Rows[0].Cells["emp_code_c"].Value + "'  ");

                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "تم اغلاق الورديه  ", "Shift", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                dgv_close.Rows.Clear();
            }
        }


        private void Dgv_close_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            calc_current_user();
        }

        //Calc
        //=========
        private void calc_current_user()
        {
            try
            {
                dgv_close.CurrentRow.Cells["def_c"].Value = (Convert.ToDecimal(dgv_close.CurrentRow.Cells["close_c"].Value)) - (Convert.ToDecimal(dgv_close.CurrentRow.Cells["drawres_c"].Value)) ;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                db.log_error(string.Concat(ex));
            }
        }
        private void calc_all()
        {
            try
            {
                for (int i = 0; i < dgv_close.Rows.Count; i++)
                {
                    dgv_close.Rows[i].Cells["def_c"].Value = (Convert.ToDecimal(dgv_close.Rows[i].Cells["close_c"].Value)) - (Convert.ToDecimal(dgv_close.Rows[i].Cells["drawres_c"].Value));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                db.log_error(string.Concat(ex));
            }
        }
        //=========================================================================================
        //--------------report get total sale---------------------------------------------------
        //============================================================================================

        private void Btn_clear_all_Click(object sender, EventArgs e)
        {
            combo_empcode.Text = "";
            combo_empname.Text = "";
            combo_shift_no.Text = "";
            combo_vcs_name.Text = "";
            lbl_code_vcs.Text = "0";

            combo_code_items.Text = "";
            combo_name_items.Text = "";
        }
        private void Btn_tot_shift_Click(object sender, EventArgs e)
        {
            string s = combo_shift_no.Text;
            string emp = combo_code_emp.Text;
            string vcs = lbl_code_vcs.Text;
            DataTable dt = new DataTable();


            //1)emp_code =null and shift =null and vcs=null
            if (combo_code_emp.Text == "" && combo_shift_no.Text == "" && combo_vcs_name.Text == "")
            {
                //    MessageBox.Show("1");
                db.GetData_DGV("select user_code,user_name,shift_no,SUM(incloud_taxes) as 'sale',(select max(date_open_shift) from pos_shift where shift_no=pos_dt.shift_no) as date_opening_bal,(select sum(bal_open) from pos_shift where shift_no=pos_dt.shift_no) as opening_bal from pos_dt where state = 'sal' and date_d between '" + d1.Value.ToString("MM-dd-yyyy") + "' and '" + d2.Value.ToString("MM-dd-yyyy") + "' group by user_code, user_name, shift_no ", dt);
                dgv_tot.Columns["re"].Visible = false;
                dgv_tot.Columns["code_vcs_c"].Visible = false;
                dgv_tot.Columns["name_vcs_c"].Visible = false;

            }
            //2)emp_code =data and shift =null and vcs=null
            else if (combo_code_emp.Text != "" && combo_shift_no.Text == "" && combo_vcs_name.Text == "")
            {
              //  MessageBox.Show("2");
                db.GetData_DGV("select user_code,user_name,shift_no,SUM(incloud_taxes) as 'sale',(select max(date_open_shift) from pos_shift where shift_no=pos_dt.shift_no) as date_opening_bal,(select sum(bal_open) from pos_shift where shift_no=pos_dt.shift_no) as opening_bal from pos_dt where state = 'sal' and user_code='"+emp+"' and date_d between '" + d1.Value.ToString("MM-dd-yyyy") + "' and '" + d2.Value.ToString("MM-dd-yyyy") + "' group by user_code, user_name, shift_no ", dt);
                dgv_tot.Columns["re"].Visible = false;
                dgv_tot.Columns["code_vcs_c"].Visible = false;
                dgv_tot.Columns["name_vcs_c"].Visible = false;



            }
            //3)emp_code =data and shift =data and vcs=null
            else if (combo_code_emp.Text != "" && combo_shift_no.Text != "" && combo_vcs_name.Text == "")
            { //MessageBox.Show("3"); 
               db.GetData_DGV("select (select max(date_open_shift) from pos_shift where shift_no='"+s+"') as date_opening_bal,(select sum(bal_open) from pos_shift where shift_no='"+s+"') as opening_bal,(select SUM(incloud_taxes) from pos_dt where state='sal' and shift_no='"+s+"' and user_code='"+emp+"' and date_d between '"+d1.Value.ToString("MM-dd-yyyy") +"' and '"+d2.Value.ToString("MM-dd-yyyy") +"') as sale,(select SUM(incloud_taxes) from pos_dt where  state='re' and shift_no='"+s+ "' and user_code='"+emp+"'and date_d between '" + d1.Value.ToString("MM-dd-yyyy") + "' and '" + d2.Value.ToString("MM-dd-yyyy") + "') as re,user_code,user_name,shift_no  from pos_dt where shift_no='"+s+"' and user_code='"+emp+"'and date_d between '" + d1.Value.ToString("MM-dd-yyyy") + "' and '" + d2.Value.ToString("MM-dd-yyyy") + "' group by user_code, user_name, shift_no ", dt);
                dgv_tot.Columns["re"].Visible = true;
                dgv_tot.Columns["code_vcs_c"].Visible = false;
                dgv_tot.Columns["name_vcs_c"].Visible = false;

            }
            //4)emp_code =data and shift =data and vcs=data
            else if (combo_code_emp.Text != "" && combo_shift_no.Text != "" && combo_vcs_name.Text != "")
            {
                // MessageBox.Show("4");
                db.GetData_DGV("select vcs_code,vcs_name,(select max(date_open_shift) from pos_shift where shift_no='" + s + "') as date_opening_bal,(select sum(bal_open) from pos_shift where shift_no='" + s + "') as opening_bal,(select SUM(incloud_taxes) from pos_dt where state='sal' and shift_no='" + s + "' and user_code='" + emp + "' and date_d between '" + d1.Value.ToString("MM-dd-yyyy") + "' and '" + d2.Value.ToString("MM-dd-yyyy") + "') as sale,(select SUM(incloud_taxes) from pos_dt where  state='re' and shift_no='" + s + "' and user_code='" + emp + "'and date_d between '" + d1.Value.ToString("MM-dd-yyyy") + "' and '" + d2.Value.ToString("MM-dd-yyyy") + "') as re,user_code,user_name,shift_no  from pos_dt where shift_no='" + s + "' and user_code='" + emp + "'and date_d between '" + d1.Value.ToString("MM-dd-yyyy") + "' and '" + d2.Value.ToString("MM-dd-yyyy") + "' group by user_code, user_name, shift_no,vcs_code,vcs_name ", dt);
                dgv_tot.Columns["re"].Visible = true;
                dgv_tot.Columns["code_vcs_c"].Visible =true;
                dgv_tot.Columns["name_vcs_c"].Visible = true;


            }
            else if (combo_code_emp.Text == "" && combo_shift_no.Text == "" && combo_vcs_name.Text != "")
            {
                // MessageBox.Show("5");
             //   db.GetData_DGV("select vcs_code,vcs_name,(select max(date_open_shift) from pos_shift where shift_no='" + s + "') as date_opening_bal,(select sum(bal_open) from pos_shift where shift_no='" + s + "') as opening_bal,(select SUM(incloud_taxes) from pos_dt where state='sal' and shift_no='" + s + "' and user_code='" + emp + "' and date_d between '" + d1.Value.ToString("MM-dd-yyyy") + "' and '" + d2.Value.ToString("MM-dd-yyyy") + "') as sale,(select SUM(incloud_taxes) from pos_dt where  state='re' and shift_no='" + s + "' and user_code='" + emp + "'and date_d between '" + d1.Value.ToString("MM-dd-yyyy") + "' and '" + d2.Value.ToString("MM-dd-yyyy") + "') as re,user_code,user_name,shift_no  from pos_dt where shift_no='" + s + "' and user_code='" + emp + "'and date_d between '" + d1.Value.ToString("MM-dd-yyyy") + "' and '" + d2.Value.ToString("MM-dd-yyyy") + "' group by user_code, user_name, shift_no,vcs_code,vcs_name ", dt);
                db.GetData_DGV("select vcs_code,vcs_name, user_code,user_name,shift_no,SUM(incloud_taxes) as 'sale',(select max(date_open_shift) from pos_shift where shift_no=pos_dt.shift_no) as date_opening_bal,(select sum(bal_open) from pos_shift where shift_no=pos_dt.shift_no) as opening_bal from pos_dt where state = 'sal' and vcs_code='" + vcs + "' and date_d between '" + d1.Value.ToString("MM-dd-yyyy") + "' and '" + d2.Value.ToString("MM-dd-yyyy") + "' group by user_code, user_name, shift_no ,vcs_code,vcs_name", dt);

                dgv_tot.Columns["re"].Visible = true;
                dgv_tot.Columns["code_vcs_c"].Visible = true;
                dgv_tot.Columns["name_vcs_c"].Visible = true;

            }





            dgv_tot.DataSource = dt;
        }

        private void Combo_code_emp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_name_emp.Text = db.GetData("select user_name from emps where emp_no ='" + combo_empcode.Text + "'").Rows[0][0].ToString();

            }
            catch (Exception)
            {

                
            }
        }

        private void Combo_shift_no_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Combo_vcs_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_code_vcs.Text = db.GetData("select vcs_code from vcs where vcs_name='" + combo_vcs_name.Text + "'").Rows[0][0].ToString();

            }
            catch (Exception)
            {
            }
        }

        private void Btn_search_Click(object sender, EventArgs e)
        {
            all_comb.load_emp_users_code(combo_code_emp);
            all_comb.load_shift_no(combo_shift_no);
            all_comb.load_vcs_customer(combo_vcs_name);

            all_comb.load_items_code(combo_code_items);
            all_comb.load_name_items(combo_name_items);

            combo_code_emp.Text = "";
            combo_shift_no.Text = "";
            combo_vcs_name.Text = "";
            combo_vcs_name.Text = "";
            
            lbl_code_vcs.Text = "0";
            lbl_name_emp.Text = "0";
        }

        private void Btn_detils_Click(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            string it = combo_code_items.Text;
            //1- code items ==null and name items 
            if (combo_code_items.Text=="")
            {
                db.GetData_DGV("select code_items, name_items, item_price,qty, incloud_taxes, shift_no, pos_inv_no, name_unite, user_name,[state] from pos_dt where  date_d between '" + d1.Value.ToString("MM-dd-yyyy") + "' and '" + d2.Value.ToString("MM-dd-yyyy") + "'", dt2);
               
            }
            else
            {
                db.GetData_DGV("select code_items, name_items, item_price,qty, incloud_taxes, shift_no, pos_inv_no, name_unite, user_name,[state] from pos_dt where  date_d between '" + d1.Value.ToString("MM-dd-yyyy") + "' and '" + d2.Value.ToString("MM-dd-yyyy") + "' and code_items='"+it+"'", dt2);
            }

            dgv_detils.DataSource = dt2;
            for (int i = 0; i < dgv_detils.Rows.Count; i++)
            {
                if (dgv_detils.Rows[i].Cells["state_d"].Value + "" == "re")
                {
                    dgv_detils.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                }
            }
        }


        private void Combo_code_items_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combo_name_items.Text = db.GetData("select name_items from items where code_items='" + combo_code_items.Text + "'").Rows[0][0].ToString();

            }
            catch (Exception)
            {

            }
        }

        private void Combo_name_items_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combo_code_items.Text = db.GetData("select code_items from items where name_items='" + combo_name_items.Text + "'").Rows[0][0].ToString();
            }
            catch (Exception)
            {
            }
        }

        private void Dgv_state_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           // try
            {
                lbl_sales.Text = db.GetData("select isnull(SUM(incloud_taxes),0) from pos_dt where state='sal' and shift_no='" + dgv_state.CurrentRow.Cells["shift_no_s"].Value+ "' and date_d>='"+ Convert.ToDateTime(dgv_state.CurrentRow.Cells["date_open_shift_s"].Value).ToString("yyyy-MM-dd") + "'--and onRoll='0' and onRoll!='2' ").Rows[0][0].ToString();
                lbl_resale.Text = db.GetData("select isnull(SUM(incloud_taxes),0)*-1 from pos_dt where state='re' and shift_no='" + dgv_state.CurrentRow.Cells["shift_no_s"].Value + "' and date_d>='" + Convert.ToDateTime(dgv_state.CurrentRow.Cells["date_open_shift_s"].Value).ToString("yyyy-MM-dd") + "' --and onRoll='0' and onRoll!='2' ").Rows[0][0].ToString();
                lbl_discount_tot.Text=db.GetData("select isnull(SUM(discount_all),0) from pos_dt where shift_no='" + dgv_state.CurrentRow.Cells["shift_no_s"].Value + "' and date_d>='" + Convert.ToDateTime(dgv_state.CurrentRow.Cells["date_open_shift_s"].Value).ToString("yyyy-MM-dd") + "'").Rows[0][0].ToString();
                lbl_expensses.Text = db.GetData("select isnull(SUM(depit),0) from entry where attachno='"+ dgv_state.CurrentRow.Cells["shift_no_s"].Value + "'and code_entry <> '002' and  attachnamebook <>'POS credit'").Rows[0][0].ToString();
                lbl_credit.Text = db.GetData("select isnull(SUM(depit),0) from entry where attachno='" + dgv_state.CurrentRow.Cells["shift_no_s"].Value + "' and attachnamebook ='POS credit' ").Rows[0][0].ToString();
                lbl_gift.Text = db.GetData("select isnull(SUM(incloud_taxes),0) from pos_dt where state='sal' and shift_no='" + dgv_state.CurrentRow.Cells["shift_no_s"].Value + "' and date_d>='" + Convert.ToDateTime(dgv_state.CurrentRow.Cells["date_open_shift_s"].Value).ToString("yyyy-MM-dd") + "'and onRoll='2' ").Rows[0][0].ToString();


                lbl_netsale.Text = (Convert.ToDouble(lbl_sales.Text) - Convert.ToDouble(lbl_resale.Text)- Convert.ToDouble(lbl_discount_tot.Text) - Convert.ToDouble(lbl_expensses.Text)) + "";


                lbl_other1n.Caption= db.GetData("select cash1_name from pos_cash_account where user_code='" + dgv_state.CurrentRow.Cells["emp_code_s"].Value + "'").Rows[0][0].ToString();
                other1num.Caption = db.GetData("select isnull(sum(balance),0) from pos_cash where user_code='" + dgv_state.CurrentRow.Cells["emp_code_s"].Value + "' and shift_no='" + dgv_state.CurrentRow.Cells["shift_no_s"].Value + "' and name_cash='" + lbl_other1n.Caption + "'").Rows[0][0].ToString();

                lbl_other2n.Caption = db.GetData("select cash2_name from pos_cash_account where user_code='" + dgv_state.CurrentRow.Cells["emp_code_s"].Value + "'").Rows[0][0].ToString();
                other2num.Caption = db.GetData("select isnull(sum(balance),0) from pos_cash where user_code='" + dgv_state.CurrentRow.Cells["emp_code_s"].Value + "' and shift_no='" + dgv_state.CurrentRow.Cells["shift_no_s"].Value + "' and name_cash='" + lbl_other1n.Caption + "'").Rows[0][0].ToString();

                lbl_other3n.Caption = db.GetData("select cash3_name from pos_cash_account where user_code='" + dgv_state.CurrentRow.Cells["emp_code_s"].Value + "'").Rows[0][0].ToString();
                other3num.Caption = db.GetData("select isnull(sum(balance),0) from pos_cash where user_code='" + dgv_state.CurrentRow.Cells["emp_code_s"].Value + "' and shift_no='" + dgv_state.CurrentRow.Cells["shift_no_s"].Value + "' and name_cash='" + lbl_other1n.Caption + "'").Rows[0][0].ToString();

                lbl_other4n.Caption = db.GetData("select cash4_name from pos_cash_account where user_code='" + dgv_state.CurrentRow.Cells["emp_code_s"].Value + "'").Rows[0][0].ToString();
                other4num.Caption = db.GetData("select isnull(sum(balance),0) from pos_cash where user_code='" + dgv_state.CurrentRow.Cells["emp_code_s"].Value + "' and shift_no='" + dgv_state.CurrentRow.Cells["shift_no_s"].Value + "' and name_cash='" + lbl_other1n.Caption + "'").Rows[0][0].ToString();

                lbl_other5n.Caption = db.GetData("select cash5_name from pos_cash_account where user_code='" + dgv_state.CurrentRow.Cells["emp_code_s"].Value + "'").Rows[0][0].ToString();
                other5num.Caption = db.GetData("select isnull(sum(balance),0) from pos_cash where user_code='" + dgv_state.CurrentRow.Cells["emp_code_s"].Value + "' and shift_no='" + dgv_state.CurrentRow.Cells["shift_no_s"].Value + "' and name_cash='" + lbl_other1n.Caption + "'").Rows[0][0].ToString();



            }
           // catch (Exception)
            {
            }
        }

        private void Dgv_detils_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string x = dgv_detils.CurrentRow.Cells["code_items_d"].Value + "";
                lbl_stat_min_items_n.Text = db.GetData("select isnull(min (discount),0) from purchase_dt  where code_items ='" + x + "'").Rows[0][0].ToString();
                lbl_stat_max_items_n.Text = db.GetData("select isnull(max (discount),0) from purchase_dt  where code_items ='" +x + "'").Rows[0][0].ToString();
                lbl_stat_cost_items_n.Text = db.GetData("select cost from wares where code_items='" + x + "' and id_ware='10'").Rows[0][0].ToString();
                lbl_balance_items.Text = db.GetData("(select sum(qty)-(select sum(qty) from pos_dt where code_items='" + x + "') from wares where code_items='" +x + "')").Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                db.log_error(string.Concat((object)ex));
            }
        }
        //-----------------------------------------------------------------------------------dgv invoice=----------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void Btn_serchinv_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            //if inv =null and emp_code =null
            if (combo_inv.Text=="" && combo_emp_inv.Text=="")
            {
                db.GetData_DGV("select code_items, name_items, item_price,date_d, incloud_taxes, shift_no, pos_inv_no, name_unite, user_name from pos_dt where  date_d between '" + dt1_inv.Value.ToString("MM-dd-yyyy") + "' and '"+ dt2_inv.Value.ToString("MM-dd-yyyy") + "'", dt);

            }


            //if inv =data  and emp_code =null
            else if (combo_inv.Text != "" && combo_emp_inv.Text == "")
            {
                db.GetData_DGV("select code_items, name_items, item_price,date_d, incloud_taxes, shift_no, pos_inv_no, name_unite, user_name from pos_dt where  date_d between '" + dt1_inv.Value.ToString("MM-dd-yyyy") + "' and '" + dt2_inv.Value.ToString("MM-dd-yyyy") + "'and pos_inv_no='"+combo_inv.Text+"'", dt);
            }
            //if inv =null and emp_code =data
            else if (combo_inv.Text == "" && combo_emp_inv.Text != "")
            {
                db.GetData_DGV("select code_items, name_items, item_price,date_d, incloud_taxes, shift_no, pos_inv_no, name_unite, user_name from pos_dt where  date_d between '" + dt1_inv.Value.ToString("MM-dd-yyyy") + "' and '" + dt2_inv.Value.ToString("MM-dd-yyyy") + "'and user_code='" + combo_emp_inv.Text + "'", dt);

            }
            //if inv =data and emp_code =data
            else if (combo_inv.Text != "" && combo_emp_inv.Text != "")
            {
                db.GetData_DGV("select code_items, name_items, item_price,date_d, incloud_taxes, shift_no, pos_inv_no, name_unite, user_name from pos_dt where  date_d between '" + dt1_inv.Value.ToString("MM-dd-yyyy") + "' and '" + dt2_inv.Value.ToString("MM-dd-yyyy") + "' and pos_inv_no='" + combo_inv.Text + "' and user_code='" + combo_emp_inv.Text + "'", dt);

            }



            dgv_inv.DataSource = dt;


        }

        private void Btn_search_inv_Click(object sender, EventArgs e)
        {
            all_comb.load_emp_users_code(combo_emp_inv);
            all_comb.load_vcs_customer(combo_vcs_inv);
            all_comb.load_invoice_pos(combo_inv);

            all_comb.load_items_code(combo_items_code_inv);
            all_comb.load_name_items(combo_name_code_inv);


            combo_emp_inv.Text = "";
            combo_vcs_inv.Text = "";
            combo_inv.Text = "";
            combo_name_code_inv.Text = "";
            combo_items_code_inv.Text = "";

            lbl_name_emp_inv.Text = "";
            lbl_vcs_code_inv.Text = "";
            lbl_state.Text = "";

        }
        private void Btn_del_inv_Click(object sender, EventArgs e)
        {
            combo_emp_inv.Text = "";
            combo_vcs_inv.Text = "";
            combo_inv.Text = "";

            lbl_name_emp_inv.Text = "";
            lbl_vcs_code_inv.Text = "";
            lbl_state.Text = "";

            combo_name_code_inv.Text = "";
            combo_items_code_inv.Text = "";

        }
        private void Combo_emp_inv_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_name_emp_inv.Text = db.GetData("select user_name from emps where emp_no ='" + combo_emp_inv.Text + "'").Rows[0][0].ToString();

            }
            catch (Exception)
            {


            }
        }

        private void Combo_vcs_inv_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_code_vcs.Text = db.GetData("select vcs_code from vcs where vcs_name='" + combo_vcs_name.Text + "'").Rows[0][0].ToString();

            }
            catch (Exception)
            {
            }
        }

        private void Combo_inv_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_state.Text= db.GetData("select [state] from pos_dt where pos_inv_no='" + combo_inv.Text + "'").Rows[0][0].ToString();
            }
            catch (Exception)
            {
            }
        }

        private void Btn_print_Click(object sender, EventArgs e)
        {
            if (combo_inv.Text !="")
            {
                string str = combo_inv.Text;
                string shift_no= db.GetData("select shift_no from pos_dt where pos_inv_no='" + combo_inv.Text + "'").Rows[0][0].ToString();
                XtraReport xtraReport = XtraReport.FromFile("forms\\receipt_printer_pos.repx", true);
                xtraReport.Parameters["parameter1"].Value = str;
                xtraReport.Parameters["parameter2"].Value = shift_no;
                xtraReport.Parameters["parameter1"].Visible = false;
                xtraReport.Parameters["parameter2"].Visible = false;
                XtraReportPreviewExtensions.ShowPreview(xtraReport);
            }
        }

        private void dgv_state_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void combo_empcode_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                dgv_open_shift.Rows.Add(0, 0, combo_empcode.Text, combo_empname.Text, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), 0, "اضغط لاضافه وردية");
            }
        }

        private void combo_items_code_inv_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combo_name_code_inv.Text = db.GetData("select name_items from items where code_items='" + combo_items_code_inv.Text + "'").Rows[0][0].ToString();

            }
            catch (Exception)
            {

            }
        }

        private void combo_name_code_inv_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combo_items_code_inv.Text = db.GetData("select code_items from items where name_items='" + combo_name_code_inv.Text + "'").Rows[0][0].ToString();
            }
            catch (Exception)
            {
            }
        }

        private void btn_color_Click(object sender, EventArgs e)
        {
            //progressBar1.Visible = true;
            // prog1 = dgv.Rows.Count;
            if (dgv_inv.Rows.Count == 0) return;
            for (int i = 0; i < dgv_inv.Rows.Count; i++)
            {
                // string offer = db.GetData("select isnull(max(main_code),0) from offer where main_code='" + dgv_inv.Rows[i].Cells["code_items_inv"].Value + "" + "'").Rows[0][0].ToString();
                string offer = dgv_inv.Rows[i].Cells["code_items_inv"].Value + "";
                if (offer == combo_items_code_inv.Text)
                {
                    dgv_inv.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                }
             //   backgroundWorker1.ReportProgress(i);
            }
           // progressBar1.Visible = false;

        }

        private void dgv_close_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            v.shift_no = dgv_close.CurrentRow.Cells["shift_no_c"].Value + "";
            pos.pos_screen_sumer f = new pos_screen_sumer();
            f.Show();
        }

        private void btn_print_shift_Click(object sender, EventArgs e)
        {
            try
            {
                XtraReport xtraReport = DevExpress.XtraReports.UI.XtraReport.FromFile("forms\\print_by_shift_no.repx", true);
                xtraReport.Parameters["parameter1"].Value = dgv_close.Rows[0].Cells["shift_no_c"].Value + "";
                xtraReport.Parameters["parameter1"].Visible = true;
                XtraReportPreviewExtensions.ShowPreview((IReport)xtraReport);
            }
            catch (Exception)
            {

                
            }
        }

        private void btn_entry_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("select acc_num,acc_name,depit,credit,dates,attachnamebook,attachtext from entry where attachno='" + combo_shift_no.Text + "'", dt);
            dgv_entry.DataSource = dt;
        }

        private void dgv_entry_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv_entry, "no_e");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            load_sheft();
        }
    }
}