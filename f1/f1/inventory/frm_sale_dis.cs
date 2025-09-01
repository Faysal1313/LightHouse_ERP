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

namespace f1.inventory
{
    public partial class frm_sale_dis : DevExpress.XtraEditors.XtraForm
    {
        public frm_sale_dis()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon("f1.exe");
            db.Open();
        }
        private void frm_sale_dis_Load(object sender, EventArgs e)
        {
            all_comb.load_wares(combo_wars);

            DataTable dt = new DataTable();
            db.GetData_DGV("select code_items,name_items,price_buy,price_sale,discount_buy,discount_sale from items  where price_sale > 0 or price_buy  > 0", dt);
            dgv.DataSource = dt;

        }
        private void add_items()
        {
            //if (dgv.Rows.Count == 0)
            //{
            //    MessageBox.Show("no rows to add items");
            //    return;
            //}
           // try
            {
   
            //=======
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (combo_add_items.Text == dgv.Rows[i].Cells["name_items"].Value.ToString())
                {
                    MessageBox.Show("douple");
                    return;
                }
            }
            //========
            DataTable dataTable = (DataTable)dgv.DataSource;
            DataRow drToAdd = dataTable.NewRow();
            drToAdd["code_items"] = (db.GetData("select code_items from items where name_items='" + combo_add_items.Text + "'").Rows[0][0].ToString());
            drToAdd["name_items"] = combo_add_items.Text;
            drToAdd["price_buy"] = db.GetData("select isnull(sum(price_buy),0) from items where name_items='" + combo_add_items.Text + "' ").Rows[0][0].ToString();
            drToAdd["price_sale"] = db.GetData("select isnull(sum(price_sale),0) from items where name_items='" + combo_add_items.Text + "' ").Rows[0][0].ToString();
            drToAdd["discount_buy"] = db.GetData("select isnull(sum(discount_buy),0) from items where name_items='" + combo_add_items.Text + "' ").Rows[0][0].ToString();
            drToAdd["discount_sale"] = db.GetData("select isnull(sum(discount_sale),0) from items where name_items='" + combo_add_items.Text + "' ").Rows[0][0].ToString();


            dataTable.Rows.Add(drToAdd);
            dataTable.AcceptChanges();
            }
          //  catch (Exception)
            {
                
                
            }
        }
        private void btn_save_limit_Click(object sender, EventArgs e)
        {
            
        }
        private void dgv_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv);
        }
        private void btn_same_price_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].Cells["price_sale"].Value = dgv.Rows[i].Cells["price_buy"].Value;
            }
        }
        private void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void price_btn_refersh_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    string cost = "";
                    cost = (db.GetData("select isnull(sum(cost),0) from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and id_ware='"+combo_wars.Text+"'").Rows[0][0].ToString());
                    if (Convert.ToDecimal(cost) >= ((Convert.ToDecimal(dgv.Rows[i].Cells["price_buy"].Value) * ((Convert.ToDecimal(dgv.Rows[i].Cells["profit_sale"].Value) / 100)) + Convert.ToDecimal(dgv.Rows[i].Cells["price_buy"].Value))))
                    {
                        XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "سعر البيع يتم تحت التكلفه" + cost, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dgv.Rows[i].Cells["price_sale"].Value = (Convert.ToDecimal(dgv.Rows[i].Cells["price_buy"].Value) * ((Convert.ToDecimal(dgv.Rows[i].Cells["profit_sale"].Value) / 100)) + Convert.ToDecimal(dgv.Rows[i].Cells["price_buy"].Value));
                    }

                }

            }
            catch (Exception)
            {
                
                
            }
        }
        private void discount_btn_refersh_calc_profit_discount_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
            {
                //edit discount profit
                decimal cogs = Convert.ToDecimal(db.GetData("select isnull(sum(cost),0) from wares where code_items='" + dgv.Rows[i].Cells["code_items"].Value + "' and id_ware='"+combo_wars.Text+"'").Rows[0][0].ToString());
                decimal expect_proft = 0;
                expect_proft = (cogs * Convert.ToDecimal(dgv.Rows[i].Cells["discount_profit"].Value)) + cogs;
                dgv.Rows[i].Cells["discount_sale"].Value = expect_proft / Convert.ToDecimal(dgv.Rows[i].Cells["price_buy"].Value);
            }
            }
            catch (Exception)
            {
                
                
            }
        }

        private void save_barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int x = 0; x < dgv.Rows.Count; x++)
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if (dgv.Rows[i].Cells["price_buy"].Value.ToString() == "")
                    {
                        dgv.Rows[i].Cells["price_buy"].Value = 0;
                    }
                    if (dgv.Rows[i].Cells["price_sale"].Value.ToString() == "")
                    {
                        dgv.Rows[i].Cells["price_sale"].Value = 0;
                    }
                    if (dgv.Rows[i].Cells["discount_buy"].Value.ToString() == "")
                    {
                        dgv.Rows[i].Cells["discount_buy"].Value = 0;
                    }
                    if (dgv.Rows[i].Cells["discount_sale"].Value.ToString() == "")
                    {
                        dgv.Rows[i].Cells["discount_sale"].Value = 0;
                    }
                }
                //========
                db.Run("update items set price_buy='" + dgv.Rows[x].Cells["price_buy"].Value + "',price_sale='" + dgv.Rows[x].Cells["price_sale"].Value + "', discount_buy='" + dgv.Rows[x].Cells["discount_buy"].Value + "',discount_sale='" + dgv.Rows[x].Cells["discount_sale"].Value + "' where code_items='" + dgv.Rows[x].Cells["code_items"].Value + "'");
            }

            XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "update ", "update", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void combo_add_items_Click(object sender, EventArgs e)
        {
            all_comb.load_name_items_have_qty(combo_add_items);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            add_items();
        }

       

        private void combo_add_items_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Enter)
            {
                add_items();
            }
        }
        //====================================BARCODE<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        //------------------------------------------------------------------------------------------
        private void btn_add_barcode_Click(object sender, EventArgs e)
        {
            //-----
            for (int i = 0; i < dgv2.Rows.Count; i++)
            {
                {
                    if (combo_name_barcode.Text == dgv2.Rows[i].Cells["name_items"].Value.ToString())
                    {
                        MessageBox.Show("douple");
                        return;
                    }
                }
                //========
                DataTable dataTable = (DataTable)dgv.DataSource;
                DataRow drToAdd = dataTable.NewRow();
                drToAdd["code_items"] = (db.GetData("select code_items from items where name_items='" + combo_name_barcode.Text + "'").Rows[0][0].ToString());
                drToAdd["name_items"] = combo_add_items.Text;
                drToAdd["price_buy"] = db.GetData("select isnull(sum(price_buy),0) from items where name_items='" + combo_name_barcode.Text + "' ").Rows[0][0].ToString();
                drToAdd["price_sale"] = db.GetData("select isnull(sum(price_sale),0) from items where name_items='" + combo_name_barcode.Text + "' ").Rows[0][0].ToString();
                drToAdd["discount_buy"] = db.GetData("select isnull(sum(discount_buy),0) from items where name_items='" + combo_name_barcode.Text + "' ").Rows[0][0].ToString();
                drToAdd["discount_sale"] = db.GetData("select isnull(sum(discount_sale),0) from items where name_items='" + combo_name_barcode.Text + "' ").Rows[0][0].ToString();


                dataTable.Rows.Add(drToAdd);
                dataTable.AcceptChanges();
            }
         //--------
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            db.GetData_DGV("select distinct items.code_items,items.name_items,barcode.barcode from items right join barcode on items.code_items=barcode.code_items order by items.code_items", dt);
            dgv2.DataSource = dt;
        }

        private void dgv2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv2,"no_barcode");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //inventory.printer_items.frm_printer_barcode f = new printer_items.frm_printer_barcode();
          //  f.ShowDialog();
            //===============
            db.Open();
           // int id = Convert.ToInt32(123);
            DataTable dt = new DataTable();
            dt.Clear();
            db.GetData_DGV(("select info_co.name_of_company,info_co.tel1,barcode.code_items,items.name_items,barcode.barcode,items.price_sale from info_co,barcode left join items on barcode.code_items = items.code_items  where items.code_items='1001'"), dt);


        }

       
    }
}