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
    public partial class frm_balance_qty : DevExpress.XtraEditors.XtraForm
    {
        public frm_balance_qty()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(v.ico);

            d1.Text = DateTime.Now.ToString( "yyyy/MM/01");
            d2.Text = DateTime.Now.ToString( "yyyy/MM/dd");

        }
        private void Frm_balance_qty_Load(object sender, EventArgs e)
        {
            all_comb.load_wares(this.combo_wars);
          //  all_comb.load_items_for_purchase_name1(combo_name_items);
         //   all_comb.load_items_code(combo_code_items);
            combo_name_items.Text = "";
            combo_code_items.Text = "";

        }
        private void Dgv_2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv, "no2");
        }

        private void Btn_search_items_Click(object sender, EventArgs e)
        {
            all_comb.load_items_for_purchase_name1(combo_name_items);
            all_comb.load_items_code(combo_code_items);
            combo_name_items.Text = "";
            combo_code_items.Text = "";
        }

        private void Btn_del_Click(object sender, EventArgs e)
        {
            combo_name_items.Text = "";
            combo_code_items.Text = "";
        }

        private void Combo_code_items_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                combo_name_items.Text = db.GetData("select (name_items) from items where code_items='" + combo_code_items.Text + "'").Rows[0][0].ToString();
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
            }
            catch (Exception)
            {
            }
        }


        

        
        private void Btn_serchinv_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            if (chk_items2.Checked)
            {
                //dt.Rows.Clear();
                //dgv.Rows.Clear();
                if (combo_code_items.Text == "")
                {
                    db.GetData_DGV("select wares.cost,items.code_items as code_items, items.name_items as name_items, items.name_unite as name_unite, items.price_sale as price_sale, items.unit1 as unit1, wares.qty + ((select isnull(sum(qty*-1),0) from pos_dt p left join pos_shift s  on p.shift_no=s.shift_no where s.lock='1'  and p.code_items=items.code_items)) as qty from items left join wares  on items.code_items = wares.code_items  where items.type = '1' and id_ware = '" + combo_wars.Text + "' and items.cat2='"+combo_items2.Text+"'", dt);
                    dgv.DataSource = dt;

                    return;
                    
                }
                else
                {
                    db.GetData_DGV("select wares.cost,items.code_items as code_items, items.name_items as name_items, items.name_unite as name_unite, items.price_sale as price_sale, items.unit1 as unit1, wares.qty + ((select isnull(sum(qty*-1),0) from pos_dt p left join pos_shift s  on p.shift_no=s.shift_no where s.lock='1'  and p.code_items=items.code_items)) as qty   from items left join wares  on items.code_items = wares.code_items  where items.type = '1' and id_ware = '" + combo_wars.Text + "' and  items.code_items like '" + combo_code_items.Text + "'and items.cat2='" + combo_items2.Text + "'", dt);
                    dgv.DataSource = dt;

                    return;


                }
            }
            if (chk_0.Checked)
            {
                if (combo_code_items.Text == "")
                {
                    db.GetData_DGV("select wares.cost,items.code_items as code_items, items.name_items as name_items, items.name_unite as name_unite, items.price_sale as price_sale, items.unit1 as unit1, wares.qty + ((select isnull(sum(qty*-1),0) from pos_dt p left join pos_shift s  on p.shift_no=s.shift_no where s.lock='1'  and p.code_items=items.code_items)) as qty from items left join wares  on items.code_items = wares.code_items  where items.type = '1' and id_ware = '" + combo_wars.Text + "'", dt);
                }
                else
                {
                    db.GetData_DGV("select wares.cost,items.code_items as code_items, items.name_items as name_items, items.name_unite as name_unite, items.price_sale as price_sale, items.unit1 as unit1, wares.qty + ((select isnull(sum(qty*-1),0) from pos_dt p left join pos_shift s  on p.shift_no=s.shift_no where s.lock='1'  and p.code_items=items.code_items)) as qty   from items left join wares  on items.code_items = wares.code_items  where items.type = '1' and id_ware = '" + combo_wars.Text + "' and  items.code_items like '" + combo_code_items.Text + "'", dt);
                }
            }
            else
            {
                if (combo_code_items.Text == "")
                {
                    db.GetData_DGV("select wares.cost,items.code_items as code_items, items.name_items as name_items, items.name_unite as name_unite, items.price_sale as price_sale, items.unit1 as unit1, wares.qty + ((select isnull(sum(qty*-1),0) from pos_dt p left join pos_shift s  on p.shift_no=s.shift_no where s.lock='1'  and p.code_items=items.code_items)) as qty from items left join wares  on items.code_items = wares.code_items  where items.type = '1'and qty != 0 and id_ware = '" + combo_wars.Text + "'", dt);
                }
                else
                {
                    db.GetData_DGV("select wares.cost,items.code_items as code_items, items.name_items as name_items, items.name_unite as name_unite, items.price_sale as price_sale, items.unit1 as unit1, wares.qty + ((select isnull(sum(qty*-1),0) from pos_dt p left join pos_shift s  on p.shift_no=s.shift_no where s.lock='1'  and p.code_items=items.code_items)) as qty   from items left join wares  on items.code_items = wares.code_items  where items.type = '1'and qty != 0 and id_ware = '" + combo_wars.Text + "' and  items.code_items like '" + combo_code_items.Text + "'", dt);
                }
            }
            dgv.Invoke((MethodInvoker)delegate
            {
                dgv.DataSource = dt;
               // calc();

            });


        }
        
        private void Dgv_2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          
            pos.frm_items_card f = new frm_items_card();
            f.Show();
            f.combo_code_items.Text = dgv.CurrentRow.Cells["code_items"].Value + "";
            f.btn_serchinv.Select();


        }
        private void calc()
        {
           // try
            {
                double q = 0;
                double q2 = 0;
                for (int i = 0; i < dgv.Rows.Count; i++)
                {

                    dgv.Rows[i].Cells["tot_cost"].Value = Convert.ToDouble(dgv.Rows[i].Cells["cost"].Value )* Convert.ToDouble(dgv.Rows[i].Cells["qty"].Value);
                    dgv.Rows[i].Cells["tot_sale"].Value = Convert.ToDouble(dgv.Rows[i].Cells["price_sale"].Value) * Convert.ToDouble(dgv.Rows[i].Cells["qty"].Value);


                    //    bal_q = bal_q + Convert.ToDouble(dgvc.Rows[i].Cells["imp"].Value) - Convert.ToDouble(dgvc.Rows[i].Cells["exp"].Value);
                   q = q+ Convert.ToDouble(dgv.Rows[i].Cells["tot_cost"].Value );
                   q2 = q2+Convert.ToDouble(dgv.Rows[i].Cells["tot_sale"].Value);

                    //-----------------------------
                    string qty_ = dgv.Rows[i].Cells["qty"].Value + "";
                    if (Convert.ToDouble(qty_) < 0)
                    {
                        dgv.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                    }
                }
                lbl_cost_tot_inv.Text = (Math.Round((q), 2)) + "";
                lbl_tot_price_inv.Text = (Math.Round((q2), 2)) + "";

            }
           // catch (Exception)
            {

            }


        }
       

        private void Dgv_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
           // calc();
        }

        private void Dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            calc();
        }

        private void Dgv2_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv2, "no3");

        }

        private void SimpleButton2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //db.GetData_DGV("select d.code_items,d.name_items,sum(d.qty)as qty from pos_dt d left join wares w on d.code_items=w.code_items where w.qty < '"+num.Value+"' and date_d  between '"+d1.Value.ToString("MM-dd-yyyy")+ "' and '"+ d2.Value.ToString("MM-dd-yyyy") + "' group by d.code_items, d.name_items order by qty desc ", dt);
            db.GetData_DGV("select code_items,name_items,count(pos_inv_no)as qty,(select qty  from  wares where code_items=pos_dt.code_items)as qty_2  from pos_dt where  date_d between '" + d1.Value.ToString("MM-dd-yyyy") + "' and '" + d2.Value.ToString("MM-dd-yyyy") + "'            group by code_items,name_items             order by count(pos_inv_no) desc", dt);
            //select code_items,name_items,count(pos_inv_no)as most_sal,(select datediff(day,'2021-09-20',(GETDATE())) )as def from pos_dt where  date_d between '2021-09-20' and '2021-10-05'
            //group by code_items,name_items
            //order by count(pos_inv_no) desc

            dgv2.DataSource = dt;
            //cl();
        }
        private void cl()
        {
            //get offer and give new coler
            progressBar1.Visible = true;
            prog1 = dgv2.Rows.Count;

            for (int i = 0; i < dgv2.Rows.Count; i++)
            {
                string c = dgv2.Rows[i].Cells["code_items_c"].Value.ToString();
                dgv2.Rows[i].Cells["qty_2"].Value = Convert.ToDouble(db.GetData("select isnull(sum(qty),0)-(select isnull(sum(qty),0) from pos_dt p left join pos_shift s  on p.shift_no=s.shift_no   where s.lock= '1' and code_items='" + c + "') from wares where code_items='" + c + "'").Rows[0][0].ToString());
                dgv2.Rows[i].Cells["tot_los"].Value = Convert.ToDouble(dgv2.Rows[i].Cells["qty_2"].Value) - Convert.ToDouble(dgv2.Rows[i].Cells["qty1"].Value);
                if (dgv2.Rows[i].Cells["tot_los"].Value + "" == "") dgv2.Rows[i].Cells["tot_los"].Value = 0;

                if (Convert.ToDouble(dgv2.Rows[i].Cells["tot_los"].Value) < -10)
                {
                    dgv2.Rows[i].Cells["note"].Value = "يجب الشراء وبشدة";
                }
                else if (Convert.ToDouble(dgv2.Rows[i].Cells["tot_los"].Value) < -5)
                {
                    dgv2.Rows[i].Cells["note"].Value = "يجب الشراء";
                }
                else if (Convert.ToDouble(dgv2.Rows[i].Cells["tot_los"].Value) <= 0)
                {
                    dgv2.Rows[i].Cells["note"].Value = "يمكنك الانتظار";
                }
                else if (Convert.ToDouble(dgv2.Rows[i].Cells["tot_los"].Value) > 0)
                {
                    dgv2.Rows[i].Cells["note"].Value = "تمهل لايجب الشراء في الوقت الحالي";
                }
                backgroundWorker1.ReportProgress(i);
            }
            //dgv2.Rows[0].DefaultCellStyle.BackColor = Color.Orange;
            //foreach (DataGridViewRow i in dgv2.Rows)
            //{
            //    if (i.Cells[0].Value.ToString() == "يجب الشراء وبشدة")
            //    {
            //        i.DefaultCellStyle.BackColor = Color.Orange;
            //    }
            //    else if (i.Cells[0].Value.ToString() == "يجب الشراء")
            //    {
            //        i.DefaultCellStyle.BackColor = Color.FloralWhite;
            //    }
            //    else if (i.Cells[0].Value.ToString() == "يمكنك الانتظار")
            //    {
            //        i.DefaultCellStyle.BackColor = Color.Aqua;
            //    }
            //    else if (i.Cells[0].Value.ToString() == "تمهل لايجب الشراء في الوقت الحالي")
            //    {
            //        i.DefaultCellStyle.BackColor = Color.AntiqueWhite;
            //    }
            //}
           
            progressBar1.Visible = false;
        }

        private void btn_purchase_inv_Click(object sender, EventArgs e)
        {
            if (combo_code_items.Text=="")
            {
                return;
            }
            DataTable dt = new DataTable();
            db.GetData_DGV("select d.no,d.purchase_hd_id,code_items,name_items,qty,item_price,d.discount,d.incloud_taxes,d.id_ware,name_unite,h.date_P from purchase_dt d left join purchase_hd h on d.purchase_hd_id=h.purchase_hd_id where d.code_items='" + combo_code_items.Text+ "'", dt);
            dgv_pur.DataSource = dt;
        }

        private void dgv_pur_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv_pur, "no_pur");
        }
        private int prog1 = 0;
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Maximum = prog1;
            progressBar1.Value = e.ProgressPercentage;
        }

        private void dgv_pur_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


            if (dgv_pur.Rows.Count !=0)
            {
                if (db.GetData("select isnull(max(purchase_hd_id),0) from purchase_dt where purchase_hd_id='" + dgv_pur.CurrentRow.Cells["purchase_hd_id"].Value + "" + "'").Rows[0][0] + "" == "0")
                {
                    return;
                }

              
                frm_purchase f = new frm_purchase();
                f.Show();
                //f.numBook_purchase= dgv_pur.CurrentRow.Cells["purchase_hd_id"].Value + "";
                f.txt_serial_string.Select();
                f.txt_barcode.Select();

            }

        }

        private void dgv2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = true;
        }

        private void dgv2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv2.CurrentRow.Cells["code_items_c"].Value+""=="")
            {
                return;
            }
            pos.frm_items_card f = new frm_items_card();
            f.Show();
            f.combo_code_items.Text = dgv2.CurrentRow.Cells["code_items_c"].Value + "";
            f.btn_serchinv.Select();
        }

        private void d1_ValueChanged(object sender, EventArgs e)
        {
        lbl_def_date.Text=    (d1.Value - d2.Value).ToString("dd");
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (dgv2.Rows.Count == 0) return;
            try
            {
                for (int i = 0; i < dgv2.Rows.Count; i++)
                {
                    dgv2.Rows[i].Cells["tot_los"].Value = num.Value + "";

                    dgv2.Rows[i].Cells["bal_b"].Value = Convert.ToDouble(dgv2.Rows[i].Cells["qty_2"].Value) - Convert.ToDouble(dgv2.Rows[i].Cells["tot_los"].Value);
                }
            }
            catch (Exception)
            {

            }
            


        }

        private void dgv2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgv2.CurrentRow.Cells["bal_b"].Value = Convert.ToDouble(dgv2.CurrentRow.Cells["qty_2"].Value) - Convert.ToDouble(dgv2.CurrentRow.Cells["tot_los"].Value);

            }
            catch (Exception)
            {

            }
        }

        private void chk_items2_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_items2.Checked)
            {
                lbl_items2.Visible = true;
                combo_items2.Visible = true;
                lbl_cat2.Visible = true;
                all_comb.load_cat(combo_items2, "cat2");
                combo_items2.Text = "";
                lbl_cat2.Text = "";
            }
            else
            {
                lbl_items2.Visible = false;
                combo_items2.Visible = false;
                lbl_cat2.Visible = false;

            }
        }
    }
}