using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;

namespace f1
{
    public partial class open : SplashScreen
    {
        public open()
        {
            InitializeComponent();
            this.labelCopyright.Text = "Copyright © 2020-" + DateTime.Now.Year.ToString() + " all rights reserved";
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ((Control)new Log_in.frm_login()).Show();
           
            this.Visible = false;
            this.timer1.Enabled = false;
            this.timer2.Enabled = false;
            
           // this.Close();
        }
        private double c = 0.4;
        private void timer2_Tick(object sender, EventArgs e)
        {
            c = c + 0.01;
            Opacity = c;
            lbl_start.Text = c+"";
            if (!(lbl_start.Text == 1.0 + ""))
                return;
                timer1.Enabled = false;
                timer1.Stop();
            

        }
    }
}