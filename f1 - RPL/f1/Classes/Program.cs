using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.LookAndFeel;

namespace f1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();

           // Application.Run(new Form2());
             Application.Run(new Log_in.frm_login());
         //   Application.Run(new open());

            //  Application.Run(new ttt());
            // Application.Run(new account.report_account.report_finance_statment.frm_rpt_balance_sheet());

            //  Application.Run(new notification.frm_notif_depit());
            // Application.Run(new inventory.frm_sale_dis());

            //  Application.Run(new trm_start());
            // Application.Run(new pos.pos_main());
            // Application.Run(new pos.frm_pos());
            //  Application.Run(new pos.pos_sheft());

            //  Application.Run(new Classes.test_combo());
            //    Application.Run(new account.frm_currance());
            // Application.Run(new frm_send_email());

            //     Application.Run(new frm_cogs_adj());

            // Application.Run(new Classes.test_Excel());
            //            Application.Run(new Classes.frm_excel_purchase());
            //   Application.Run(new import_excel.frm_excel_vcs());
            // Application.Run(new import_excel.frm_excel_items());
            //    Application.Run(new import_excel.frm_excel_sale());

            //            Application.Run(new frm_payable());
            //   Application.Run(new frm_recevable());
            //   Application.Run(new Classes.test_combo());





            //Application.Run(new frm_sale());
            //    Application.Run(new frm_purchase());
            //    Application.Run(new frm_sale());
            //     Application.Run(new frm_restcost());
            //  Application.Run(new frm_info_co());
            // Application.Run(new Classes.frm_dashpord());

            //  Application.Run(new frm_type());
            //    Application.Run(new opening_closing.frm_openig_and_close_wizard  ());
            //    Application.Run(new opening_closing.frm_opening_entry  ());

            //  Application.Run(new frm_permissions());

            // Application.Run(new frm_main());
            //         Application.Run(new opening_closing.close_db.frm_close_db());

            // Application.Run(new frm_adjustment_qty());
            // Application.Run(new opening_closing.frm_opening_qty());
            //  Application.Run(new inventory.frm_wizard_adjustment_qty());

            // Application.Run(new frm_payable());

            //Application.Run(new frm_item());
            //   Application.Run(new trm_start());

            // Application.Run(new inventory.frm_limit_maximum_qty());

            //  Application.Run(new frm_entry());
            //  Application.Run(new frm_tree());

            //  Application.Run(new Classes.test_combo());
            //              Application.Run(new hr.frm_empwage());
            //      Application.Run(new hr.frm_pay_salary());



            // Application.Run(new frm_purchase());
            //  Application.Run(new hr.frm_test_stats());
            //   Application.Run(new Log_in.frm_change_password());


        }
    }
}

