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

namespace f1.pos
{
    public partial class frm_offer : DevExpress.XtraEditors.XtraForm
    {
        public frm_offer()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(v.ico);
            all_comb.load_wares(combo_wars);
            dt1.Text = DateTime.Now.ToString( "yyyy/MM/dd");
            dt2.Text = DateTime.Now.ToString("yyyy/MM/dd");

        }

        private void Btn_search_items_Click(object sender, EventArgs e)
        {
            all_comb.load_items_for_purchase_name1(combo_name_items);
            all_comb.load_items_code(combo_code_items);
            combo_name_items.Text = "";
            combo_code_items.Text = "";
        }

        private void Combo_code_items_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combo_name_items.Text = db.GetData("select (name_items) from items where code_items='" + combo_code_items.Text + "'").Rows[0][0].ToString();
                lbl_name_items.Text= db.GetData("select (name_items) from items where code_items='" + combo_code_items.Text + "'").Rows[0][0].ToString();
            }
            catch (Exception)
            {
            }
        }

        private void Combo_name_items_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combo_code_items.Text = db.GetData("select (code_items) from items where name_items='" + combo_name_items.Text + "'").Rows[0][0].ToString();
                lbl_code_items.Text= db.GetData("select (code_items) from items where name_items='" + combo_name_items.Text + "'").Rows[0][0].ToString();
            }
            catch (Exception)
            {
            }
        }

        private void Btn_code_items_Click(object sender, EventArgs e)
        {
            if (combo_code_items.Text == "") return;

            for (int i = 0; i < dgv.Rows.Count; ++i)
            {
                if (lbl_name_items.Text == dgv.Rows[i].Cells["name_items"].Value.ToString())
                {
                    MessageBox.Show("الصنف مكرر ");
                    return;
                }
            }
            string price_cost = db.GetData("select isnull(sum(price_buy),0) from items where code_items='" + lbl_code_items.Text + "' ").Rows[0][0].ToString();
            string price_sale = db.GetData("select isnull(sum(price_sale),0) from items where code_items='" + lbl_code_items.Text + "' ").Rows[0][0].ToString();
            string discount_buy = db.GetData("select isnull(sum(discount_buy),0) from items where code_items='" + lbl_code_items.Text + "' ").Rows[0][0].ToString();
            string discount_sale = db.GetData("select isnull(sum(discount_sale),0) from items where code_items='" + lbl_code_items.Text + "' ").Rows[0][0].ToString();
            dgv.Rows.Add("",lbl_code_items.Text,lbl_name_items.Text,price_cost,price_sale,discount_buy,discount_sale);
        }

        private void Btn_del_Click(object sender, EventArgs e)
        {
            try
            {
                combo_code_items.Text = "";
                combo_name_items.Text = "";
                dgv.Rows.Clear();
            }
            catch (Exception)
            {
            }
        }

        private void Btn_add_all_Click(object sender, EventArgs e)
        {
            dgv.Rows.Clear();
            DataTable tb = new DataTable();
            db.GetData_DGV("select code_items,name_items,(select cost from wares where code_items=items.code_items and wares.id_ware='" + this.combo_wars.Text + "')as price_cost,price_sale,discount_buy,discount_sale from items  where price_sale > 0 or price_buy  > 0", tb);
            this.dgv.DataSource = (object)tb;

            combo_name_items.Visible = true;
            combo_code_items.Visible = false;

        }

        private void Dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv, "no");
        }

        private void Btn_sale_profit_Click(object sender, EventArgs e)
        {
            try
            {
               // progressBar1.Visible = true;
                //prog1 = dgv.Rows.Count;
                string message = "";
                for (int i = 0; i < dgv.Rows.Count; ++i)
                {
                    string cost = db.GetData("select isnull(sum(cost),0) from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and id_ware='" + combo_wars.Text + "'").Rows[0][0].ToString();
                    Decimal sale = Convert.ToDecimal(dgv.Rows[i].Cells["price_cost"].Value) * Convert.ToDecimal(dgv.Rows[i].Cells["price_profit"].Value) / new Decimal(100) + Convert.ToDecimal(dgv.Rows[i].Cells["price_cost"].Value);
                    if (Convert.ToDecimal(cost) >= sale)
                    {
                        message = message + "\n" + dgv.Rows[i].Cells["code_items"].Value + "  " + cost + " سعر التكلفة" + dgv.Rows[i].Cells["price_cost"].Value + "سعر الشراء" + "\n";
                    }
                    else
                    {
                        dgv.Rows[i].Cells["price_sale"].Value = sale;//(Convert.ToDecimal(dgv.Rows[i].Cells["price_cost"].Value) * Convert.ToDecimal(dgv.Rows[i].Cells["price_profit"].Value) / new Decimal(100) + Convert.ToDecimal(dgv.Rows[i].Cells["price_cost"].Value));
                    }
                   // backgroundWorker1.ReportProgress(i);

                }
             //   progressBar1.Visible = false;
                if (message.Length >22 )
                {
                    XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "\n سعر البيع يتم تحت التكلفه" + message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void Btn_discount_profit_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dgv.Rows.Count; ++i)
                {
                    Decimal num1 = Convert.ToDecimal(db.GetData("select isnull(sum(cost),0) from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and id_ware='" + combo_wars.Text + "'").Rows[0][0].ToString());
                    Decimal num2 = new Decimal(0);
                    Decimal num3 = num1 * Convert.ToDecimal(dgv.Rows[i].Cells["discount_profit"].Value) + num1;
                    dgv.Rows[i].Cells["discount_sale"].Value = (object)(num3 / Convert.ToDecimal(dgv.Rows[i].Cells["price_cost"].Value));
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void Btn_items_profit_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv.Rows.Count; ++i)
            {
                string str1 = string.Concat(dgv.Rows[i].Cells["price_cost"].Value);
                string str2 = string.Concat(dgv.Rows[i].Cells["price_sale"].Value);
                if (str1 == "")
                    str1 = "0";
                if (str2 == "")
                    str2 = "0";
                double num1 = Convert.ToDouble(str1);
                double num2 = Convert.ToDouble(str2);
                dgv.Rows[i].Cells["price_profit"].Value = (Math.Round(1.0 - num1 / num2, 2) * 100);
            }
        }

        private void Btn_equal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int index = 0; index < this.dgv.Rows.Count; ++index)
                this.dgv.Rows[index].Cells["price_sale"].Value = this.dgv.Rows[index].Cells["price_cost"].Value;
        }

        private async void Save_barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dr;
            dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "سيتم التعديل علي الاسعار  ", "رسال تاكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);


            if (dr == DialogResult.OK)

            {
                progressBar1.Visible = true;

                for (int i = 0; i < dgv.Rows.Count; ++i)
                {
                    for (int ii = 0; ii < dgv.Rows.Count; ++ii)
                    {
                        if (dgv.Rows[ii].Cells["price_cost"].Value.ToString() == "")
                            dgv.Rows[ii].Cells["price_cost"].Value = 0;
                        if (dgv.Rows[ii].Cells["price_sale"].Value.ToString() == "")
                            dgv.Rows[ii].Cells["price_sale"].Value = 0;
                        if (dgv.Rows[ii].Cells["discount_buy"].Value.ToString() == "")
                            dgv.Rows[ii].Cells["discount_buy"].Value = 0;
                        if (dgv.Rows[ii].Cells["discount_sale"].Value.ToString() == "")
                            dgv.Rows[ii].Cells["discount_sale"].Value = 0;
                    }
                    db.cmd.CommandText = ("update items set price_buy='" + dgv.Rows[i].Cells["price_cost"].Value+"" + "',price_sale='" + dgv.Rows[i].Cells["price_sale"].Value+"" + "', discount_buy='" + dgv.Rows[i].Cells["discount_buy"].Value+"" + "',discount_sale='" + dgv.Rows[i].Cells["discount_sale"].Value+"" + "' where code_items='" + dgv.Rows[i].Cells["code_items"].Value+"" + "'");
                    await db.cmd.ExecuteNonQueryAsync();
                }
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "تم التحديث ", "تعديل", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);


            }
            progressBar1.Visible = false;


        }
        private int prog1 = 0;

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Maximum = prog1;
            progressBar1.Value = e.ProgressPercentage;
        }
        //========================================Offer
        private void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Rows.Count == 0) return;
            group_offer.Visible = true;
            lbl_code_main.Text = dgv.CurrentRow.Cells["code_items"].Value+"";
            lbl_name_main.Text = dgv.CurrentRow.Cells["name_items"].Value+"";

            DataTable dt = new DataTable();
            db.GetData_DGV("select sub_code,(select name_items from items where code_items=offer.main_code)as name_items,qty from offer where main_code='" + dgv.CurrentRow.Cells["code_items"].Value + "'",dt);
            dgv_sub.DataSource = dt;
            try
            {
                dt1.Text = db.GetData("select dt1 from offer where main_code='" + dgv.CurrentRow.Cells["code_items"].Value + "'").Rows[0][0].ToString();
                dt2.Text = db.GetData("select dt2 from offer where main_code='" + dgv.CurrentRow.Cells["code_items"].Value + "'").Rows[0][0].ToString();



            }
            catch (Exception ex)
            {
//                MessageBox.Show(ex.Message);

            }




        }

        private void Btn_search_sub_Click(object sender, EventArgs e)
        {
            all_comb.load_items_for_purchase_name1(combo_name_sub);
            all_comb.load_items_code(combo_code_sub);
            combo_name_sub.Text = "";
            combo_code_sub.Text = "";
        }

        private void Btn_add_sub_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dataTable = (DataTable)dgv_sub.DataSource;
                DataRow drToAdd = dataTable.NewRow();
                drToAdd["sub_code"] = lbl_code_sub.Text;
                drToAdd["name_items"] = db.GetData("select (name_items) from items where code_items='" + lbl_code_sub.Text + "'").Rows[0][0].ToString();
                drToAdd["qty"] = "1";
                dataTable.Rows.Add(drToAdd);
                dataTable.AcceptChanges();
            }
            catch (Exception)
            {

            }
        }

        private void Combo_code_sub_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //combo_name_sub.Text = db.GetData("select  (name_items) from items where code_items='" + combo_code_items.Text + "'").Rows[0][0].ToString();
                combo_name_sub.Text = db.GetData("select (name_items) from items where code_items='" + combo_code_sub.Text + "'").Rows[0][0].ToString();

                 lbl_name_sub.Text = db.GetData("select (name_items) from items where code_items='" + combo_code_sub.Text + "'").Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
        }

        private void Combo_main_sub_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combo_code_sub.Text = db.GetData("select (code_items) from items where name_items='" + combo_name_sub.Text + "'").Rows[0][0].ToString();
                lbl_code_sub.Text = db.GetData("select (code_items) from items where name_items='" + combo_name_sub.Text + "'").Rows[0][0].ToString();
            }
            catch (Exception)
            {
            }
        }

        private void Btn_save_offer_Click(object sender, EventArgs e)
        {
            db.Run("delete from offer where main_code='"+lbl_code_main.Text+"'");
            for (int i = 0; i < dgv_sub.Rows.Count; i++)
            {
                db.Run("insert into offer (main_code,sub_code,qty,dt1,dt2) values('"+ lbl_code_main.Text + "','"+ dgv_sub.Rows[i].Cells["sub_code_c"].Value + "','" + dgv_sub.Rows[i].Cells["qty"].Value + "','" + dt1.Value.ToString("MM-dd-yyyy") +"','"+dt2.Value.ToString("MM-dd-yyyy") +"')");
            }
            update_offer_in_items(1);
            XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "تم الحفظ ", "رسالة حفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            group_offer.Visible = false;
        }

        private void update_offer_in_items(int num)
        {
            try
            {
                if (dgv_sub.Rows.Count != 0)
                {
                    if (db.GetData("select isnull((offer),0) from items where code_items='" + lbl_code_main.Text + "'").Rows[0][0].ToString() == "0")
                    {
                        db.Run("update items set offer ='"+num+"' where code_items='" + lbl_code_main.Text + "'");
                    }
                }
            }
            catch (Exception)
            {
            }

        }
        private void Btn_close_offer_Click(object sender, EventArgs e)
        {
            group_offer.Visible = false;
            update_offer_in_items(1);
        }

        private void Dgv_sub_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv_sub,"no2");
        }
        private void Btn_offer_items_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //get offer and give new coler
            progressBar1.Visible = true;
            prog1= dgv.Rows.Count;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
               string offer= db.GetData("select isnull(max(main_code),0) from offer where main_code='"+dgv.Rows[i].Cells["code_items"].Value+""+"'").Rows[0][0].ToString();
                if(offer !="0")
                {
                    dgv.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                }
                backgroundWorker1.ReportProgress(i);
            }
            progressBar1.Visible = false;

        }
        private void dgv_satue_dgv()
        {
            try
            {
                lbl_stat_min_items.Caption = db.GetData("select isnull(min (discount),0) from purchase_dt  where code_items ='" + this.dgv.CurrentRow.Cells["code_items"].Value.ToString() + "'").Rows[0][0].ToString();
                lbl_stat_max_items.Caption = db.GetData("select isnull(max (discount),0) from purchase_dt  where code_items ='" + this.dgv.CurrentRow.Cells["code_items"].Value.ToString() + "'").Rows[0][0].ToString();
                lbl_stat_cost_items.Caption = db.GetData("select cost from wares where code_items='" + this.dgv.CurrentRow.Cells["code_items"].Value.ToString() + "' and id_ware='" + combo_wars.Text + "'").Rows[0][0].ToString();
              //  lbl_state_vcs_bal.Text = db.GetData("select isnull(sum(depit)-sum(credit),0) from entry where acc_num='" + this.combo_code_vcs.Text + "'").Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                db.log_error(string.Concat((object)ex));
            }
        }
        private void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgv_satue_dgv();
        }

        private void Frm_offer_FormClosing(object sender, FormClosingEventArgs e)
        {
            //update_offer_in_items();
        }

        private void btn_del_offer_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "سيتم حذ العرض ", "رسال حذف مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                db.Run("delete from offer where main_code='" + lbl_code_main.Text + "'");
                update_offer_in_items(0);
            }
        }

      
        private void btn_Dell_all_offer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            DialogResult dr;
            dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "سيتم حذف جميع العروض ", "رسال حذف مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                db.Run("delete from offer ");
                db.Run("update items set offer ='null' where code_items='" + lbl_code_main.Text + "'");
            }

        }
    }
}