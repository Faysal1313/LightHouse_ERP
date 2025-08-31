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

namespace f1
{
    public partial class frm_desgin_report_main : DevExpress.XtraEditors.XtraForm
    {
        public frm_desgin_report_main()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(v.ico);

        }
    }
}