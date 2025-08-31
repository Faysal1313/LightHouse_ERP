using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace f1.pos
{
    public partial class frm_oepinging : DevExpress.XtraEditors.XtraForm
    {
        public frm_oepinging()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
            dt_piker.Text = DateTime.Now.ToString("yyyy/MM/dd");


        }

        private void frm_oepinging_Load(object sender, EventArgs e)
        {
            all_comb.load_items_for_purchase_name1(combo_name_items);
            all_comb.load_items_code(combo_code_items);
            combo_name_items.Text = "";
            combo_code_items.Text = "";

            all_comb.load_account_name_c_capital(combo_capital);
            combo_capital.Text = "";
            all_comb.load_account_name_c_depit(combo_acc);
            combo_acc.Text = "";
            all_comb.load_vcs_customer(combo_clint);
            combo_clint.Text = "";
            all_comb.load_vcs_vendor(combo_vendor);
            combo_vendor.Text="";
            all_comb.load_wares(combo_wars);




        }

        private void combo_code_items_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combo_name_items.Text = db.GetData("select (name_items) from items where code_items='" + combo_code_items.Text + "'").Rows[0][0].ToString();
            }
            catch (Exception)
            {
            }
        }

        private void combo_name_items_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combo_code_items.Text = db.GetData("select (code_items) from items where name_items='" + combo_name_items.Text + "'").Rows[0][0].ToString();
            }
            catch (Exception)
            {
            }
        }
        private void add_inv()
        {
            if (combo_code_items.Text == "") return;
           //   string str = db.GetData("select isnull(max(barcode),0) from barcode where code_items='" + combo_code_items.Text + "'").Rows[0][0].ToString();
            //if (str == "0")
             //   str = combo_code_items.Text;
            dgv_qty.Rows.Add("", combo_code_items.Text, combo_name_items.Text, 1,0);

        }
        private void calc_wares()
        {
            for (int i = 0; i < dgv_qty.Rows.Count; i++)
            {
                dgv_qty.Rows[i].Cells[5].Value = Convert.ToDouble(dgv_qty.Rows[i].Cells[3].Value) * Convert.ToDouble(dgv_qty.Rows[i].Cells[4].Value);
            }

        }
        private void btn_save_pos_Click(object sender, EventArgs e)
        {
            //validaion ZERO
            if (dgv_qty.Rows.Count > 0)
            {
                for (int i = 0; i < dgv_qty.Rows.Count; i++)
                {
                    string x = (dgv_qty.Rows[i].Cells[5].Value) + "";
                    if (x == "") x = "0";
                    if (Convert.ToDouble(x)<0)
                    {
                        MessageBox.Show("يجب ان تكون القيمة اكبر من صفر"+ dgv_qty.Rows[i].Cells[2].Value+"");
                        return;
                    }
                }
            }
            if (dgv_capital.Rows.Count > 0)
            {
                for (int i = 0; i < dgv_capital.Rows.Count; i++)
                {
                    string x = (dgv_capital.Rows[i].Cells[3].Value) + "";
                    if (x == "") x = "0";
                    if (Convert.ToDouble(x) < 0)
                    {
                        MessageBox.Show("يجب ان تكون القيمة اكبر من صفر" + dgv_qty.Rows[i].Cells[2].Value + "");
                        return;
                    }
                }
            }
            if (dgv_vendor.Rows.Count > 0)
            {
                for (int i = 0; i < dgv_vendor.Rows.Count; i++)
                {
                    string x = (dgv_vendor.Rows[i].Cells[3].Value) + "";
                    if (x == "") x = "0";
                    if (Convert.ToDouble(x) < 0)
                    {
                        MessageBox.Show("يجب ان تكون القيمة اكبر من صفر" + dgv_vendor.Rows[i].Cells[2].Value + "");
                        return;
                    }
                }
            }
            if (dgv_clint.Rows.Count > 0)
            {
                for (int i = 0; i < dgv_clint.Rows.Count; i++)
                {
                    string x = (dgv_clint.Rows[i].Cells[3].Value) + "";
                    if (x == "") x = "0";
                    if (Convert.ToDouble(x) < 0)
                    {
                        MessageBox.Show("يجب ان تكون القيمة اكبر من صفر" + dgv_clint.Rows[i].Cells[2].Value + "");
                        return;
                    }
                }
            }
            if (dgv_acc.Rows.Count > 0)
            {
                for (int i = 0; i < dgv_acc.Rows.Count; i++)
                {
                    string x = (dgv_acc.Rows[i].Cells[3].Value) + "";
                    if (x == "") x = "0";
                    if (Convert.ToDouble(x) < 0)
                    {
                        MessageBox.Show("يجب ان تكون القيمة اكبر من صفر" + dgv_acc.Rows[i].Cells[2].Value + "");
                        return;
                    }
                }
            }
            //==========================================END Validation

            double sum_wares = 0;
            for (int i = 0; i < dgv_qty.Rows.Count; i++)
            {
                sum_wares += Convert.ToDouble(dgv_qty.Rows[i].Cells[5].Value);
            }

            double sum_capital = 0;
            for (int i = 0; i < dgv_capital.Rows.Count; i++)
            {
                sum_capital += Convert.ToDouble(dgv_capital.Rows[i].Cells[3].Value);
            }
            double net_capital = sum_capital * -1;


            double sum_acc = 0;
            for (int i = 0; i < dgv_acc.Rows.Count; i++)
            {
                sum_acc += Convert.ToDouble(dgv_acc.Rows[i].Cells[3].Value);
            }
            double net_acc = sum_acc ;

            double sum_clint = 0;
            for (int i = 0; i < dgv_clint.Rows.Count; i++)
            {
                sum_clint += Convert.ToDouble(dgv_clint.Rows[i].Cells[3].Value);
            }
            double net_clint = sum_clint;

            double sum_vendor = 0;
            for (int i = 0; i < dgv_vendor.Rows.Count; i++)
            {
                sum_vendor += Convert.ToDouble(dgv_vendor.Rows[i].Cells[3].Value);
            }
            double net_vendor = sum_vendor*-1;

            double net_tot = sum_wares + net_capital + net_acc + net_clint + net_vendor;
            // MessageBox.Show(net_tot+"");
            if (net_tot != 0)
            {
                if (net_tot < 0)
                {
                    net_tot *= -1;
                    string rootid = "900001";
                    string rootname = db.GetData("select top 1 rootname from tree where rootid = '" + rootid + "'").Rows[0][0].ToString();
                    string rootlevel = db.GetData("select isnull(max(RootLevel),0) from tree where RootID='" + rootid + "'").Rows[0][0].ToString();
                    string rootsort = db.GetData("select isnull(max(type_acc),0) from tree where RootID='" + rootid + "'").Rows[0][0].ToString();
                    string rootacctype = db.GetData("select isnull(max(sort),0) from tree where RootID='" + rootid + "'").Rows[0][0].ToString();
                    dgv.Rows.Add("", rootid, rootname, net_tot, 0, rootlevel, rootsort, rootacctype, 0);
                }
                else
                {

                    string rootid = "900001";
                    string rootname = db.GetData("select top 1 rootname from tree where rootid = '" + rootid + "'").Rows[0][0].ToString();
                    string rootlevel = db.GetData("select isnull(max(RootLevel),0) from tree where RootID='" + rootid + "'").Rows[0][0].ToString();
                    string rootsort = db.GetData("select isnull(max(type_acc),0) from tree where RootID='" + rootid + "'").Rows[0][0].ToString();
                    string rootacctype = db.GetData("select isnull(max(sort),0) from tree where RootID='" + rootid + "'").Rows[0][0].ToString();
                    dgv.Rows.Add("", rootid, rootname, 0, net_tot, rootlevel, rootsort, rootacctype, 0);

                }
            }

            if (dgv_capital.Rows.Count > 0)
            {
                    string rootid = db.GetData("select top 1 rootid from wares_acc where id_ware = '" + combo_wars.Text + "'").Rows[0][0].ToString();
                    string rootname = db.GetData("select top 1 rootname from tree where rootid = '" + rootid + "'").Rows[0][0].ToString();

                    string rootlevel = db.GetData("select isnull(max(RootLevel),0) from tree where RootID='" + rootid + "'").Rows[0][0].ToString();
                    string rootsort = db.GetData("select isnull(max(type_acc),0) from tree where RootID='" + rootid + "'").Rows[0][0].ToString();
                    string rootacctype = db.GetData("select isnull(max(sort),0) from tree where RootID='" + rootid + "'").Rows[0][0].ToString();
                    dgv.Rows.Add("", rootid, rootname, sum_wares,0, rootlevel, rootsort, rootacctype, 0);

                
            }
            if (dgv_capital.Rows.Count >0)
            {
                for (int i = 0; i < dgv_capital.Rows.Count; i++)
                {
                    string rootid = dgv_capital.Rows[i].Cells[1].Value + "";
                    string rootlevel = db.GetData("select isnull(max(RootLevel),0) from tree where RootID='" + rootid + "'").Rows[0][0].ToString();
                    string rootsort = db.GetData("select isnull(max(type_acc),0) from tree where RootID='" + rootid + "'").Rows[0][0].ToString();
                    string rootacctype = db.GetData("select isnull(max(sort),0) from tree where RootID='" + rootid + "'").Rows[0][0].ToString();
                    dgv.Rows.Add("", dgv_capital.Rows[i].Cells[1].Value, dgv_capital.Rows[i].Cells[2].Value, 0, dgv_capital.Rows[i].Cells[3].Value,rootlevel, rootsort, rootacctype,0);

                }
            }

            if (dgv_acc.Rows.Count >0)
            {
                for (int i = 0; i < dgv_acc.Rows.Count; i++)
                {
                    string rootid = dgv_acc.Rows[i].Cells[1].Value + "";
                    string rootlevel = db.GetData("select isnull(max(RootLevel),0) from tree where RootID='" + rootid + "'").Rows[0][0].ToString();
                    string rootsort = db.GetData("select isnull(max(type_acc),0) from tree where RootID='" + rootid + "'").Rows[0][0].ToString();
                    string rootacctype = db.GetData("select isnull(max(sort),0) from tree where RootID='" + rootid + "'").Rows[0][0].ToString();
                    dgv.Rows.Add("", dgv_acc.Rows[i].Cells[1].Value, dgv_acc.Rows[i].Cells[2].Value, dgv_acc.Rows[i].Cells[3].Value,0,rootlevel, rootsort, rootacctype,0);
                }
            }
            if (dgv_clint.Rows.Count>0)
            {
                for (int i = 0; i < dgv_clint.Rows.Count; i++)
                {
                    string rootid = dgv_clint.Rows[i].Cells[1].Value + "";
                    string rootlevelname = db.GetData("select rootlevel_name from vcs where vcs_code='" + rootid + "'").Rows[0][0].ToString();
                    string rootid_code = db.GetData("select isnull(max(Rootid),0) from tree where RootName='" + rootid + "'").Rows[0][0].ToString();
                    string rootsort = db.GetData("select isnull(max(type_acc),0) from tree where RootName='" + rootlevelname + "'").Rows[0][0].ToString();
                    string rootacctype = db.GetData("select isnull(max(sort),0) from tree where RootName='" + rootlevelname + "'").Rows[0][0].ToString();
                    string rootlevel = db.GetData("select isnull(max(RootLevel),0) from tree where RootName='" + rootlevelname + "'").Rows[0][0].ToString();
                    dgv.Rows.Add("", dgv_clint.Rows[i].Cells[1].Value, dgv_clint.Rows[i].Cells[2].Value,  dgv_clint.Rows[i].Cells[3].Value,0, rootlevel, rootsort, rootacctype, rootlevelname,0);
                }
            }
            if (dgv_vendor.Rows.Count > 0)
            {
                for (int i = 0; i < dgv_vendor.Rows.Count; i++)
                {
                    string rootid = dgv_vendor.Rows[i].Cells[1].Value + "";
                    string rootlevelname = db.GetData("select rootlevel_name from vcs where vcs_code='" + rootid + "'").Rows[0][0].ToString();
                    string rootid_code = db.GetData("select isnull(max(Rootid),0) from tree where RootName='" + rootid + "'").Rows[0][0].ToString();
                    string rootsort = db.GetData("select isnull(max(type_acc),0) from tree where RootName='" + rootlevelname + "'").Rows[0][0].ToString();
                    string rootacctype = db.GetData("select isnull(max(sort),0) from tree where RootName='" + rootlevelname + "'").Rows[0][0].ToString();
                    string rootlevel = db.GetData("select isnull(max(RootLevel),0) from tree where RootName='" + rootlevelname + "'").Rows[0][0].ToString();
                    dgv.Rows.Add("", dgv_vendor.Rows[i].Cells[1].Value, dgv_vendor.Rows[i].Cells[2].Value,  dgv_vendor.Rows[i].Cells[3].Value,0, rootlevel, rootsort, rootacctype, rootlevelname, 0);

                }
            }
            double sum = 0;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                sum += Convert.ToDouble(dgv.Rows[i].Cells[3].Value);
            }
            double credit = 0;

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                credit += Convert.ToDouble(dgv.Rows[i].Cells[4].Value);
            }
            lbl_def.Text = (sum - credit) + "";

            if ((sum-credit)==0)
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    string code_entry = "-7";
                    string acc = dgv.Rows[i].Cells[1].Value+"";
                    db.Run("insert into entry(  [code_entry]                           ,    acc_num             ,     acc_name                                                                ,   rootlevel                                                       ,rootlevel_name                                               ,   sort                                                            , type_acc                                                       ,             depit                                                             ,                credit                 ,           name_book         ,           code_book                     ,  dates                                             ,attachno             , attachbook               ,attachnamebook ,              attachtext )values('" +
                                    code_entry + "'                           ,'" + dgv.Rows[i].Cells[1].Value + "'     ,(select top 1 rootname from tree where rootid='" + acc + "')               ,  (select top 1 RootLevel from tree where rootid='" + acc + "')    ,  (select isnull(max (rootlevel_name),1) from entry where acc_num='" + acc + "'), '"+dgv.Rows[i].Cells[6].Value+"'       ,  (select top 1 type_acc from entry where acc_num='" + acc + "')  ,  '" + Convert.ToDecimal(dgv.Rows[i].Cells[3].Value) + "' ,'"+ Convert.ToDecimal(dgv.Rows[i].Cells[4].Value) + "'  , 'Opening','Opening'     ,'" + dt_piker.Value.ToString("MM-dd-yyyy") + "', 'Opening' ,'Opening','Opening','Opening')");

                }
            }

        }

        private void combo_code_items_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                add_inv();
            }
        }

        private void combo_name_items_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                add_inv();
            }
        }

        private void combo_capital_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (combo_capital.Text == "") return;
                string rootid = db.GetData("select isnull(max(RootID),0) from tree where RootName='" + combo_capital.Text + "'").Rows[0][0].ToString();
                string rootlevel = db.GetData("select isnull(max(RootLevel),0) from tree where RootID='"+rootid+"'").Rows[0][0].ToString();
                string rootsort = db.GetData("select isnull(max(type_acc),0) from tree where RootID='"+rootid + "'").Rows[0][0].ToString();
                string rootacctype = db.GetData("select isnull(max(sort),0) from tree where RootID='"+rootid + "'").Rows[0][0].ToString();
                dgv_capital.Rows.Add("", rootid, combo_capital.Text, "0");
            }
        }

        private void combo_acc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (combo_acc.Text == "") return;
                string rootid = db.GetData("select isnull(max(RootID),0) from tree where RootName='" + combo_acc.Text + "'").Rows[0][0].ToString();
                string rootlevel = db.GetData("select isnull(max(RootLevel),0) from tree where RootID='" + rootid + "'").Rows[0][0].ToString();
                string rootsort = db.GetData("select isnull(max(type_acc),0) from tree where RootID='" + rootid + "'").Rows[0][0].ToString();
                string rootacctype = db.GetData("select isnull(max(sort),0) from tree where RootID='" + rootid + "'").Rows[0][0].ToString();
                dgv_acc.Rows.Add("", rootid, combo_acc.Text, "0");
            }
        }

        private void combo_clint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (combo_clint.Text == "") return;
                string rootid = db.GetData("select vcs_code from vcs where vcs_name='" + combo_clint.Text + "'").Rows[0][0].ToString();
                string rootlevelname = db.GetData("select rootlevel_name from vcs where vcs_code='" + rootid + "'").Rows[0][0].ToString();
                string rootid_code = db.GetData("select isnull(max(Rootid),0) from tree where RootName='" + rootid + "'").Rows[0][0].ToString();
                string rootsort = db.GetData("select isnull(max(type_acc),0) from tree where RootID='" + rootid_code + "'").Rows[0][0].ToString();
                string rootacctype = db.GetData("select isnull(max(sort),0) from tree where RootID='" + rootid_code + "'").Rows[0][0].ToString();
                dgv_clint.Rows.Add("", rootid, combo_clint.Text, "0");
            }
        }

        private void combo_vendor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (combo_vendor.Text == "") return;
                string rootid = db.GetData("select vcs_code from vcs where vcs_name='" + combo_vendor.Text + "'").Rows[0][0].ToString();
                string rootlevelname = db.GetData("select rootlevel_name from vcs where vcs_code='" + rootid + "'").Rows[0][0].ToString();
                string rootid_code = db.GetData("select isnull(max(Rootid),0) from tree where RootName='" + rootid + "'").Rows[0][0].ToString();
                string rootsort = db.GetData("select isnull(max(type_acc),0) from tree where RootID='" + rootid_code + "'").Rows[0][0].ToString();
                string rootacctype = db.GetData("select isnull(max(sort),0) from tree where RootID='" + rootid_code + "'").Rows[0][0].ToString();
                dgv_vendor.Rows.Add("", rootid, combo_vendor.Text, "0");
            }
        }

        private void btn_search_items_Click(object sender, EventArgs e)
        {

        }

        private void dgv_qty_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                calc_wares();
            }
            catch (Exception)
            {
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frm_entry f = new frm_entry();
            f.Show();
        }
    }
}