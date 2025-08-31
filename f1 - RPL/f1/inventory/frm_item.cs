using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using f1.Classes;
using DevExpress.LookAndFeel;
using System.Data.Common;

namespace f1
{
    public partial class frm_item : DevExpress.XtraEditors.XtraForm
    {
        public frm_item()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(v.ico);

        }
        private void frm_item_Load(object sender, EventArgs e)
        {
            //db.Open();
            //all_comb.load_taxes(combo_taxes);
            //combo_type_items.Text = "مخزون";
            //lbl_type_items.Text = "1";
            //txt_code_items.Select();
            //load_permission();
            //----------------------------------
            db.Open();

            lbl_cat1.Text = db.GetData("select isnull(max(cat_items1),'-') from info_co").Rows[0][0].ToString();
            lbl_cat2.Text = db.GetData("select isnull(max(cat_items2),'-') from info_co").Rows[0][0].ToString();
            lbl_cat3.Text = db.GetData("select isnull(max(cat_items3),'-') from info_co").Rows[0][0].ToString();
            lbl_cat4.Text = db.GetData("select isnull(max(cat_items4),'-') from info_co").Rows[0][0].ToString();

            lbl_catm1.Text = lbl_cat1.Text;
            lbl_catm2.Text = lbl_cat2.Text;
            lbl_catm3.Text = lbl_cat3.Text;
            lbl_catm4.Text = lbl_cat4.Text;

            dgv_show_matrix.Columns["cat1"].HeaderText=lbl_cat1.Text;
            dgv_show_matrix.Columns["cat2"].HeaderText = lbl_cat2.Text;
            dgv_show_matrix.Columns["cat3"].HeaderText = lbl_cat3.Text;
            dgv_show_matrix.Columns["cat4"].HeaderText = lbl_cat4.Text;

            dgv_matrix.Columns["catmx1"].HeaderText = lbl_cat1.Text;
            dgv_matrix.Columns["catmx2"].HeaderText = lbl_cat2.Text;
            dgv_matrix.Columns["catmx3"].HeaderText = lbl_cat3.Text;
            dgv_matrix.Columns["catmx4"].HeaderText = lbl_cat4.Text;

            
            all_comb.load_taxes(combo_taxes);
            combo_type_items.Text = "مخزون";
            lbl_type_items.Text = "1";
            //txt_code_items.Select();
            txt_name_items.Select();
            load_permission();
            
            string def_name_unite = db.GetData("select def_name_unite from info_co").Rows[0][0].ToString();
            dgv_unit.Rows.Add("", def_name_unite, "1");
            combo_taxes.Text = db.GetData("select def_taxes from info_co").Rows[0][0].ToString();

            chk_exp.Visible = Convert.ToBoolean(db.GetData("select expiry from info_co").Rows[0][0].ToString());
            if (!chk_generat_code.Checked)
                return;
            bool flag = false;
            try
            {
                string input = db.GetData("select code_items from items where serial=(select (isnull(max(serial),0)) from items)").Rows[0][0].ToString();
                try
                {
                    double num1 = Convert.ToDouble(input) / 1.0 + 1.0;
                    if (db.GetData("select isnull(max(code_items),0) from items where code_items='" + (object)num1 + "'").Rows[0][0].ToString() != "0")
                    {
                        ++num1;
                        if (db.GetData("select isnull(max(code_items),0) from items where code_items='" + (object)num1 + "'").Rows[0][0].ToString() != "0")
                        {
                            int num2 = (int)MessageBox.Show("يجب التكويد الصنف يدوي ");
                            txt_code_items.Text = "";
                            return;
                        }
                    }
                    txt_code_items.Text = string.Concat((object)num1);
                }
                catch (Exception ex)
                {
                    flag = true;
                }
                if (flag)
                    txt_code_items.Text = string.Concat((object)(Convert.ToDouble(Regex.Replace(input, "[^0-9]+", "")) + 1.0));
            }
            catch (Exception ex)
            {
                txt_code_items.Text = "";
            }
        }


        //=-------------------------------------------fanction
        bool edit = false;
        bool add_permission = true;
        bool edit_permission = true;
        private void load_permission()
        {
            save_barButtonItem_save.Enabled = Convert.ToBoolean(db.GetData("select [add_only] from permission_sub where user_code='" + v.usercode + "' and name_frm ='items' ").Rows[0][0].ToString());
            delete_barButtonItem7_delete.Enabled = Convert.ToBoolean(db.GetData("select [delete] from permission_sub where user_code='" + v.usercode + "' and name_frm ='items' ").Rows[0][0].ToString());
            add_permission = Convert.ToBoolean(db.GetData("select [add_only] from permission_sub where user_code='" + v.usercode + "' and name_frm ='items' ").Rows[0][0].ToString());
            edit_permission = Convert.ToBoolean(db.GetData("select [edit_only] from permission_sub where user_code='" + v.usercode + "' and name_frm ='items' ").Rows[0][0].ToString());
        }

        string image_loaction = "";
        private void clear()
        {
            txt_code_items.Text = "";
            txt_name_items.Text = "";
        }
        private void save()
        {
            if (txt_discount_buy.Text == "")
                txt_discount_buy.Text = "0";
            if (txt_discount_sale.Text == "")
                txt_discount_sale.Text = "0";
            if (txt_price_buy.Text == "0")
                txt_price_buy.Text = "0";
            if (txt_price_sale.Text == "0")
                txt_price_sale.Text = "0";
            db.Run("insert into items (code_items,name_items,name_items2,name_unite,unit1,price_buy,price_sale,discount_buy,discount_sale,taxes,[exp],[type],couta_type,menu,menu_name,cat1,cat2,cat3,cat4,[desc],itemType ,itemCode)values('" + txt_code_items.Text + "','" + txt_name_items.Text + "','" + txt_name_items2.Text + "','" + dgv_unit.Rows[0].Cells["name_unite"].Value.ToString() + "',1,'" + txt_price_buy.Text + "','" + txt_price_sale.Text + "','" + txt_discount_buy.Text + "','" + txt_discount_sale.Text + "','" + combo_taxes.Text + "','" + (Convert.ToBoolean(chk_exp.Checked ? 1 : 0) + "','" + ((Control)lbl_type_items).Text + "','0','" + ((Control)lbl_menu).Text + "','" + combo_menu.Text + "','" + combo_cat1.Text + "','" + combo_cat2.Text + "','" + combo_cat3.Text + "','" + combo_cat4.Text + "','" + txt_desc.Text + "','" + txt_itemType.Text + "','" + txt_itemCode.Text + "')"));
            for (int i = 0; i < dgv_unit.Rows.Count - 1; ++i)
                db.Run("insert into unite (id,name_unite,code_items,unite)values('" + dgv_unit.Rows[i].Cells["No"].Value.ToString() + "','" + dgv_unit.Rows[i].Cells["name_unite"].Value.ToString() + "','" + txt_code_items.Text + "','" + Convert.ToDecimal(dgv_unit.Rows[i].Cells["unite"].Value) + "')");
            for (int i = 0; i < dgv_barcode.Rows.Count; ++i)
                db.Run("insert into barcode (barcode,code_items,id)values('" + dgv_barcode.Rows[i].Cells["barcode"].Value + "','" + txt_code_items.Text + "','" + dgv_barcode.Rows[i].Cells[0].Value + "')");
            DataTable tb = new DataTable();
            DataTable dataTable = new DataTable();
            db.GetData_DGV("select DISTINCT(id_ware) from wares", tb);
            for (int i = 0; i < tb.Rows.Count; ++i)
                db.Run("insert into wares (id_ware,code_items,name_items,qty,cost,tot,acc,demand_limit,demand_maximum,demand_limit_bit,demand_maximum_bit)values('" + tb.Rows[i][0].ToString() + "','" + txt_code_items.Text + "','" + txt_name_items.Text + "',0,0,0,0,0,0,'False','False')");

        }
        private void update()
        {
            try
            {
                string str1 = db.GetData("select (name_items) from items where name_items='" + txt_name_items.Text + "'").Rows[1][0].ToString();
                if (str1.Length > 0 && str1 == txt_name_items.Text)
                {
                    MessageBox.Show("اسم الصنف مكرر");
                    return;
                }
                else
                {
                    string str2 = db.GetData("select (name_items2) from items where name_items2='" + txt_name_items2.Text + "'").Rows[1][0].ToString();
                    if (str2.Length > 0 && str2 == txt_name_items2.Text)
                    {
                        MessageBox.Show("اسم الصنف مكرر");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            db.Run("update items set name_items='" + txt_name_items.Text + "' where code_items='" + txt_code_items.Text + "'");
            db.Run("update items set name_items2='" + txt_name_items2.Text + "' where code_items='" + txt_code_items.Text + "'");
            db.Run("update wares set name_items='" + txt_name_items.Text + "' where code_items='" + txt_code_items.Text + "'");
            db.Run("update items set  price_buy= '" + txt_price_buy.Text + "',price_sale='" + txt_price_sale.Text + "',discount_buy='" + txt_discount_buy.Text + "',discount_sale='" + txt_discount_sale.Text + "' where code_items ='" + txt_code_items.Text + "'");
            db.Run("update items set taxes = '" + combo_taxes.Text + "' where code_items ='" + txt_code_items.Text + "'");
            db.Run("update items set [exp] = '" + Convert.ToBoolean(chk_exp.Checked ? 1 : 0) + "' where code_items ='" + txt_code_items.Text + "'");
            db.Run("update items set [type] = '" + (lbl_type_items).Text + "' where code_items ='" + txt_code_items.Text + "'");
            db.Run("update items set [cat1] = '" + combo_cat1.Text + "' where code_items ='" + txt_code_items.Text + "'");
            db.Run("update items set [cat2] = '" + combo_cat2.Text + "' where code_items ='" + txt_code_items.Text + "'");
            db.Run("update items set [cat3] = '" + combo_cat3.Text + "' where code_items ='" + txt_code_items.Text + "'");
            db.Run("update items set [cat4] = '" + combo_cat4.Text + "' where code_items ='" + txt_code_items.Text + "'");
            db.Run("update items set [menu] = '" + lbl_menu.Text + "' where code_items ='" + txt_code_items.Text + "'");
            db.Run("update items set [menu_name] = '" + combo_menu.Text + "' where code_items ='" + txt_code_items.Text + "'");
            db.Run("update items set [desc] = '" + txt_desc.Text + "' where code_items ='" + txt_code_items.Text + "'");
            db.Run("update items set [itemType] = '" + txt_itemType.Text + "' where code_items ='" + txt_code_items.Text + "'");
            db.Run("update items set [itemCode] = '" + txt_itemCode.Text + "' where code_items ='" + txt_code_items.Text + "'");


            //MessageBox.Show(dgv_unit.Rows[0].Cells["name_unite"].Value.ToString());
            db.Run("update items set name_unite='" + dgv_unit.Rows[0].Cells["name_unite"].Value + "' where code_items ='" + txt_code_items.Text + "'");
            db.Run("delete from unite where code_items='" + txt_code_items.Text + "'");
            for (int i = 0; i < dgv_unit.Rows.Count - 1; ++i)
                db.Run("insert into unite (id ,name_unite ,code_items , unite)values('" + dgv_unit.Rows[i].Cells["No"].Value.ToString() + "','" + dgv_unit.Rows[i].Cells["name_unite"].Value.ToString() + "','" + txt_code_items.Text + "','" + Convert.ToDecimal(dgv_unit.Rows[i].Cells["unite"].Value) + "')");
            db.Run("delete from barcode where code_items='" + txt_code_items.Text + "'");
            for (int i = 0; i < dgv_barcode.Rows.Count ; ++i)
                db.Run("insert into barcode (barcode,code_items,id)values('" + dgv_barcode.Rows[i].Cells["barcode"].Value.ToString() + "','" + txt_code_items.Text + "','" + dgv_barcode.Rows[i].Cells[0].Value + "')");
            MessageBox.Show("update complet");
        }
        private void delete()
        {
            command.perform_delete(txt_code_items.Text, "delete from items where code_items='" + txt_code_items.Text + "'", "delete from unite where code_items='" + txt_code_items.Text + "'", "delete from barcode where code_items='" + txt_code_items.Text + "'", "delete from wares where code_items='" + txt_code_items.Text + "'");
            frm_item f = new frm_item();
            Close();
            f.Show();
        }
        private void preform_save()
        {
            if (save_barButtonItem_save.Enabled == false || delete_barButtonItem7_delete.Enabled == false)
                return;
            try
            {
                string str1 = db.GetData("select (name_items) from items where name_items='" + txt_name_items.Text + "'").Rows[0][0].ToString();
                if (str1.Length > 0 && str1 == txt_name_items.Text)
                {
                    MessageBox.Show("اسم الصنف مكرر");
                    return;
                }
                else
                {
                    string str2 = db.GetData("select (name_items2) from items where name_items2='" + txt_name_items2.Text + "'").Rows[0][0].ToString();
                    if (str2.Length > 0 && str2 == txt_name_items2.Text)
                    {
                        MessageBox.Show("اسم الصنف مكرر");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            if (db.GetData("select id_ware from wares").Rows.Count < 1)
            {
                MessageBox.Show("يجب تكويد مخزن واحد علي الاقل");
            }
            else if (txt_code_items.Text == "")
            {
                int num2 = (int)MessageBox.Show("لايوجد كود صنف");
            }
            else if (txt_name_items.Text == "")
            {
                int num3 = (int)MessageBox.Show("لايوجد اسم للصنف");
                ((Control)txt_name_items).Select();
            }
            else if (chk_menu.Checked && combo_menu.Text == "")
            {
                int num3 = (int)MessageBox.Show("يجب اختيار القائمة");
                ((Control)combo_menu).Select();
            }
            else if (chk_menu.Checked && combo_menu.Text == "رئيسي" && combo_cat1.Text == "")
            {
                MessageBox.Show("يجب اختيار ");
                ((BaseButton)btn_find_cat1).PerformClick();
                ((Control)combo_cat1).Select();
            }
            else if (txt_price_buy.Text == "")
            {
                MessageBox.Show("لايوجد سعر لصنف");
                ((Control)txt_price_buy).Select();
            }
            else if (combo_taxes.Text == "")
            {
                int num3 = (int)MessageBox.Show("لايوجد ضريبه محدده");
                ((Control)combo_taxes).Select();
            }
            else if (combo_type_items.Text == "")
            {
                int num3 = (int)MessageBox.Show("دخل نوع الصنف");
                ((Control)combo_taxes).Select();
            }
            else if (dgv_unit.Rows.Count == 0)
            {
                int num3 = (int)MessageBox.Show("دخل نوع الصنف");
                ((Control)combo_taxes).Select();
            }
            else if (dgv_unit.Rows.Count < 2)
            {
                int num4 = (int)MessageBox.Show("ادخل وحده واحده علي الاقل");
            }
            else if (!edit)
            {
                save();
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "saving ", "save", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //clear();
                //bool flag = false;
                //try
                //{
                //    string input = db.GetData("select code_items from items where serial=(select (isnull(max(serial),0)) from items)").Rows[0][0].ToString();
                //    try
                //    {
                //        double num1 = Convert.ToDouble(input) / 1.0 + 1.0;
                //        if (db.GetData("select isnull(max(code_items),0) from items where code_items='" + (object)num1 + "'").Rows[0][0].ToString() != "0")
                //        {
                //            ++num1;
                //            if (db.GetData("select isnull(max(code_items),0) from items where code_items='" + (object)num1 + "'").Rows[0][0].ToString() != "0")
                //            {
                //                int num2 = (int)MessageBox.Show("يجب التكويد الصنف يدوي ");
                //                txt_code_items.Text = "";
                //                return;
                //            }
                //        }
                //        txt_code_items.Text = string.Concat((object)num1);
                //    }
                //    catch (Exception ex)
                //    {
                //        flag = true;
                //    }
                //    if (flag)
                //        txt_code_items.Text = string.Concat((object)(Convert.ToDouble(Regex.Replace(input, "[^0-9]+", "")) + 1.0));
                //}
                //catch (Exception ex)
                //{
                //    txt_code_items.Text = "";
                //}
            }
            else if (edit)
            {
                update();
                MessageBox.Show("تم التعديل");
            }

        }
        private void new_items()
        {
            frm_item f = new frm_item();
            Close();
            f.Show();
        }
        private void nav()
        {
            // if (edit == true)
            //{
            //  //  btn_pur_items.Enabled = true;
            //}
            edit = true;
            txt_code_items.Text = db.GetData("select code_items from items where code_items ='" + txt_code_items.Text + "'").Rows[0][0].ToString();
            txt_price_buy.Text = db.GetData("select price_buy from items where code_items ='" + txt_code_items.Text + "'").Rows[0][0].ToString();
            txt_name_items.Text = db.GetData("select name_items from items where code_items ='" + txt_code_items.Text + "'").Rows[0][0].ToString();
            txt_name_items2.Text = db.GetData("select name_items2 from items where code_items ='" + txt_code_items.Text + "'").Rows[0][0].ToString();
            txt_price_sale.Text = db.GetData("select price_sale from items where code_items ='" + txt_code_items.Text + "'").Rows[0][0].ToString();
            txt_discount_buy.Text = db.GetData("select discount_buy from items where code_items ='" + txt_code_items.Text + "'").Rows[0][0].ToString();
            txt_discount_sale.Text = db.GetData("select discount_sale from items where code_items ='" + txt_code_items.Text + "'").Rows[0][0].ToString();
            txt_desc.Text = db.GetData("select  [desc]  from items where code_items ='" + txt_code_items.Text + "'").Rows[0][0].ToString();
            combo_taxes.Text = db.GetData("select taxes from items where code_items ='" + txt_code_items.Text + "'").Rows[0][0].ToString();
            combo_cat1.Text = db.GetData("select cat1 from items where code_items ='" + txt_code_items.Text + "'").Rows[0][0].ToString();
            combo_cat2.Text = db.GetData("select cat2 from items where code_items ='" + txt_code_items.Text + "'").Rows[0][0].ToString();
            combo_cat3.Text = db.GetData("select cat3 from items where code_items ='" + txt_code_items.Text + "'").Rows[0][0].ToString();
            combo_cat4.Text = db.GetData("select cat4 from items where code_items ='" + txt_code_items.Text + "'").Rows[0][0].ToString();
            chk_exp.Checked = Convert.ToBoolean(db.GetData("select exp from items where code_items ='" + txt_code_items.Text + "'").Rows[0][0].ToString());
            lbl_menu.Text = db.GetData("select isnull(max(menu),0) from items where code_items ='" + txt_code_items.Text + "'").Rows[0][0].ToString();
            lbl_type_items.Text= db.GetData("select isnull(max(type),0) from items where code_items ='" + txt_code_items.Text + "'").Rows[0][0].ToString();
            txt_itemType.Text = db.GetData("select isnull(max(itemType),0) from items where code_items ='" + txt_code_items.Text + "'").Rows[0][0].ToString();
            txt_itemCode.Text = db.GetData("select isnull(max(itemCode),0) from items where code_items ='" + txt_code_items.Text + "'").Rows[0][0].ToString();


            if (lbl_type_items.Text == "1") combo_type_items.Text = "مخزون"; else if (lbl_type_items.Text == "2") combo_type_items.Text = "خدمي";
            if (lbl_menu.Text == "1") chk_menu.Checked = true; else chk_menu.Checked = false;
            combo_menu.Text = db.GetData("select isnull(max(menu_name),0) from items where code_items ='" + txt_code_items.Text + "'").Rows[0][0].ToString();
            DataTable tb1 = new DataTable();
            db.GetData_DGV("select id,name_unite,unite from unite where code_items='" + txt_code_items.Text + "'", tb1);
            dgv_unit.DataSource = tb1;
            DataTable tb2 = new DataTable();
            db.GetData_DGV("select id,barcode from barcode where code_items='" + txt_code_items.Text + "'", tb2);
            dgv_barcode.DataSource = (object)tb2;
            if (Convert.ToDouble(db.GetData("select isnull(sum(qty),0) from purchase_dt where code_items='" + txt_code_items.Text + "' ").Rows[0][0].ToString()) != 0.0)
            {
                delete_barButtonItem7_delete.Enabled = (false);
                save_barButtonItem_save.Enabled = (false);
            }
            else
            {
                delete_barButtonItem7_delete.Enabled = (true);
                save_barButtonItem_save.Enabled = (true);
            }
            dgv_unit.Columns["unite"].ReadOnly = false;
            btn_edit.Enabled = (true);

        }
        //--------------------------------------------controls
        private void save_barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            preform_save();



        }
        private void delete_barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            delete();

        }
        private void new_barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new_items();
        }
        //================================================Navigation=====================

        private void first_barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                txt_code_items.Text = db.GetData("select isnull(max(code_items),null) from items where serial=(select min(serial) from items)").Rows[0][0].ToString();
                if (txt_code_items.Text == "") return;

                edit = true;
                nav();
            }
            catch (Exception ex)
            {
                db.log_error(string.Concat((object)ex));
            }
        }
        private void last_barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                txt_code_items.Text = db.GetData("select isnull(max(code_items),null) from items where serial=(select max(serial) from items)").Rows[0][0].ToString();
                if (txt_code_items.Text == "") return;
                edit = true;
                nav();
            }
            catch (Exception ex)
            {
                db.log_error(string.Concat((object)ex));
            }
        }
        private void next_barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (txt_code_items.Text != "")
                {
                    int num1 = Convert.ToInt32(db.GetData("select isnull(max(serial),0) from items where code_items='" + txt_code_items.Text + "' ").Rows[0][0].ToString()) - 1;
                    if (num1 == -1)
                    {
                        //  MessageBox.Show("اخر ملف");
                        string str = db.GetData("select isnull(max(code_items),0) from items  ").Rows[0][0].ToString();
                        if (str == "0")
                            str = db.GetData("select isnull(max(code_items),0) from items where serial='" + (object)(num1 - 2) + "' ").Rows[0][0].ToString();
                        txt_code_items.Text = str;
                        nav();
                    }
                    else
                    {
                        string str = db.GetData("select isnull(max(code_items),0) from items where serial='" + (object)num1 + "' ").Rows[0][0].ToString();
                        if (str == "0")
                            str = db.GetData("select isnull(max(code_items),0) from items where serial='" + (object)(num1 - 2) + "' ").Rows[0][0].ToString();
                        txt_code_items.Text = str;
                        nav();
                    }
                }
            }
            catch (Exception ex)
            {
                db.log_error(string.Concat((object)ex));
            }
        }
        private void back_barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (txt_code_items.Text != "")
                {
                    int num1 = Convert.ToInt32(db.GetData("select isnull(min(serial),0) from items where code_items='" + txt_code_items.Text + "' ").Rows[0][0].ToString()) - 1;
                    if (num1 == -1)
                    {
                        //  MessageBox.Show("اخر ملف");
                        string str = db.GetData("select isnull(min(code_items),0) from items  ").Rows[0][0].ToString();
                        if (str == "0")
                            str = db.GetData("select isnull(min(code_items),0) from items where serial='" + (object)(num1 + 2) + "' ").Rows[0][0].ToString();
                        txt_code_items.Text = str;
                        nav();
                    }
                    else
                    {
                        string str = db.GetData("select isnull(min(code_items),0) from items where serial='" + (object)num1 + "' ").Rows[0][0].ToString();
                        if (str == "0")
                            str = db.GetData("select isnull(min(code_items),0) from items where serial='" + (object)(num1 + 2) + "' ").Rows[0][0].ToString();
                        txt_code_items.Text = str;
                        nav();
                    }
                }
            }
            catch (Exception ex)
            {
                db.log_error(string.Concat((object)ex));
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {


        }



        private void button2_Click(object sender, EventArgs e)
        {


        }


        private void combo_type_items_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_type_items.Text == "مخزون")
            {
                lbl_type_items.Text = "1";
            }
            else if (combo_type_items.Text == "خدمي")
            {
                lbl_type_items.Text = "2";
            }
        }





        //----------------------confegration image
        //function
        private void load_image(string txt_code_items, string lbl_number_pic_)
        {
            try
            {
                lbl_number_pic.Text = db.GetData("select top 1 id_image from items_image where code_items='" + txt_code_items + "'").Rows[0][0].ToString();
                DataTable dt = new DataTable();
                db.GetData_DGV("select image from items_image where code_items='" + txt_code_items + "' and id_image='" + lbl_number_pic_ + "'", dt);
                dgv_image.DataSource = dt;
                var da = new SqlDataAdapter(db.cmd);
                var ds = new DataSet();
                da.Fill(ds);
                int count = ds.Tables[0].Rows.Count;
                if (count > 0)
                {
                    var data = (Byte[])ds.Tables[0].Rows[count - 1][0];
                    var stream = new MemoryStream(data);
                    pictureBox1.Image = Image.FromStream(stream);
                }
                DataTable dt_id = new DataTable();
                db.GetData_DGV("select id_image from items_image where code_items='" + txt_code_items + "'", dt_id);
                dgv_image.DataSource = dt_id;
            }
            catch (Exception)
            {


            }
        }
        //save image
        private void btn_Save_image_Click(object sender, EventArgs e)
        {
            if (txt_code_items.Text != "")
            {
                byte[] image = null;
                FileStream stream = new FileStream(image_loaction, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(stream);
                image = brs.ReadBytes((int)stream.Length);
                db.cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@img", image));
                db.Run("insert into items_image(code_items,image) values ('" + txt_code_items.Text + "',@img)");

                MessageBox.Show("successfully");
                db.cmd.Parameters.Clear();
                image = null;
            }
        }
        //restore image 
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            load_image(txt_code_items.Text, lbl_number_pic.Text);
            first_image_btn.PerformClick();
        }
        private void add_image_simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "png files (*.png)|*.png|jpg files(*.jpg)|*.jpg|All Files(*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                image_loaction = ofd.FileName.ToString();
                pictureBox1.ImageLocation = image_loaction;
            }
        }
        //delete image
        private void remove_btn_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "هل تريد الحذف!!؟؟؟؟ ", "رسال حذف مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                db.Run("delete from items_image from items_image where code_items='" + txt_code_items.Text + "' and id_image='" + lbl_number_pic.Text + "'");
            }
            else
            {
                return;
            }
        }

        private void first_image_btn_Click(object sender, EventArgs e)
        {
            string id = db.GetData("select min (id_image) from items_image where code_items='" + txt_code_items.Text + "'").Rows[0][0].ToString();
            load_image(txt_code_items.Text, id);
            lbl_number_pic.Text = id;
        }
        private void last_image_btn_Click(object sender, EventArgs e)
        {
            string id = db.GetData("select max (id_image) from items_image where code_items='" + txt_code_items.Text + "'").Rows[0][0].ToString();
            load_image(txt_code_items.Text, id);
            lbl_number_pic.Text = id;
        }

        private void back_image_btn_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Rows.Clear();
            string st = "";
            st = db.GetData("select min(id_image) from items_image ").Rows[0][0].ToString();
            int m = int.Parse(st);
            if (int.Parse(lbl_number_pic.Text) <= m)
                MessageBox.Show("اخر ملف");
            else
            {
                int num = +(Int32.Parse(lbl_number_pic.Text) - 1);
                load_image(txt_code_items.Text, lbl_number_pic.Text);
                lbl_number_pic.Text = num + "";
            }
        }

        private void next_image_btn_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = new DataTable();
                dt.Rows.Clear();
                string st = "";
                st = db.GetData("select max(id_image) from items_image ").Rows[0][0].ToString();
                int m = int.Parse(st);
                //clearANDauto();
                edit = true;
                if (int.Parse(lbl_number_pic.Text) >= m)
                    MessageBox.Show("اول م ملف");
                else
                {
                    int num = +(Int32.Parse(lbl_number_pic.Text) + 1);
                    load_image(txt_code_items.Text, lbl_number_pic.Text);
                    lbl_number_pic.Text = num + "";

                }
            }
            catch (Exception)
            {

            }


        }

        private void dgv_image_DoubleClick(object sender, EventArgs e)
        {
            string id = dgv_image.CurrentRow.Cells[0].Value.ToString();
            load_image(txt_code_items.Text, id);
            lbl_number_pic.Text = id;
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            string x = db.GetData("select isnull(max(code_items),0) from items  where code_items='" + txt_code_items.Text + "'").Rows[0][0].ToString();

            if (Convert.ToInt32(x) != 0)
            {
                nav();
                //  edit = true;  
            }
        }
        //===============================Hotkeys=========================
        //=====================================================================
        private void txt_code_items_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(db.GetData("select isnull(max(serial),0) from items  where code_items='" + txt_code_items.Text + "'").Rows[0][0].ToString()) == 0)
                return;
            nav();
            edit = true;
        }

        
        //hot keys by arrange 
        private void txt_code_items_KeyDown_1(object sender, KeyEventArgs e)
        {

        }
        private void txt_name_items_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_name_items2.Select();
            }
            if (e.KeyCode == Keys.Down)
            {
                txt_name_items2.Select();
            }
            if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Control)
            {
                preform_save();
            }
            if (e.KeyCode == Keys.N && Control.ModifierKeys == Keys.Control)
            {
                new_items();
            }
            if (e.KeyCode == Keys.Delete && Control.ModifierKeys == Keys.Control)
            {
                delete();
            }

        }
        private void Txt_name_items2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_price_buy.Select();
            }
            if (e.KeyCode == Keys.Up)
            {
                txt_name_items.Select();
            }
            if (e.KeyCode == Keys.Down)
            {
                txt_price_buy.Select();
            }
            if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Control)
            {
                preform_save();
            }
            if (e.KeyCode == Keys.N && Control.ModifierKeys == Keys.Control)
            {
                new_items();
            }
            if (e.KeyCode == Keys.Delete && Control.ModifierKeys == Keys.Control)
            {
                delete();
            }
        }
        private void Txt_price_sale_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_discount_sale.Select();
            }
            if (e.KeyCode == Keys.Up)
            {
                txt_name_items.Select();
            }
            if (e.KeyCode == Keys.Down)
            {
                txt_price_buy.Select();
            }
            if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Control)
            {
                preform_save();
            }
            if (e.KeyCode == Keys.N && Control.ModifierKeys == Keys.Control)
            {
                new_items();
            }
            if (e.KeyCode == Keys.Delete && Control.ModifierKeys == Keys.Control)
            {
                delete();
            }
        }

        private void Txt_discount_buy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                num_percent.Select();


            }
            if (e.KeyCode == Keys.Up)
            {
                txt_name_items.Select();
            }
            if (e.KeyCode == Keys.Down)
            {
                txt_price_buy.Select();
            }
            if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Control)
            {
                preform_save();
            }
            if (e.KeyCode == Keys.N && Control.ModifierKeys == Keys.Control)
            {
                new_items();
            }
            if (e.KeyCode == Keys.Delete && Control.ModifierKeys == Keys.Control)
            {
                delete();
            }
        }

        private void Txt_discount_sale_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_name_items.Select();
            }
            if (e.KeyCode == Keys.Up)
            {
                txt_name_items.Select();
            }
            if (e.KeyCode == Keys.Down)
            {
                txt_price_buy.Select();
            }
            if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Control)
            {
                preform_save();
            }
            if (e.KeyCode == Keys.N && Control.ModifierKeys == Keys.Control)
            {
                new_items();
            }
            if (e.KeyCode == Keys.Delete && Control.ModifierKeys == Keys.Control)
            {
                delete();
            }
        }
        private void num_percent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // num_percent.Select();
                txt_price_sale.Select();

            }
        }

        private void txt_price_price_for_all_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_discount_buy.Select();
            }
            if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Control)
            {
                preform_save();
            }
            if (e.KeyCode == Keys.N && Control.ModifierKeys == Keys.Control)
            {
                new_items();
            }
            if (e.KeyCode == Keys.Delete && Control.ModifierKeys == Keys.Control)
            {
                delete();
            }
        }
        private void dgv_unit_Enter(object sender, EventArgs e)
        {
            //  chk_exp.Select();
        }
        private void chk_exp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // txt_price_buy.Select();
            }
            if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Control)
            {
                preform_save();
            }
            if (e.KeyCode == Keys.N && Control.ModifierKeys == Keys.Control)
            {
                new_items();
            }
            if (e.KeyCode == Keys.Delete && Control.ModifierKeys == Keys.Control)
            {
                delete();
            }
        }

        private void combo_taxes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // txt_code_items.Select();
            }
        }

        private void dgv_unit_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                Classes.command.LoadSerial(dgv_unit, "No");

            }
            catch (Exception)
            {
            }
        }

        private void Dgv_barcode_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!(db.GetData("select isnull(max(barcode),0) from barcode where barcode='" + dgv_barcode.CurrentRow.Cells["barcode"].Value + "'").Rows[0][0].ToString() != "0"))
                return;
            MessageBox.Show("الباركود مكرر");
            dgv_barcode.CurrentRow.Cells["barcode"].Value = "";
        }

        private void F_barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if (!((Control)group_find).Visible)
            //    ((Control)group_find).Visible = true;
            //else
            //    ((Control)group_find).Visible = false;
            v.search_screen = "items";
            frm_search f = new frm_search();
            f.ShowDialog();
            timer1.Enabled = true;
        }

        private void Chk_generat_code_CheckedChanged(object sender, EventArgs e)
        {
            if (!chk_generat_code.Checked)
                return;
            bool flag = false;
            try
            {
                string input = db.GetData("select code_items from items where serial=(select (isnull(max(serial),0)) from items)").Rows[0][0].ToString();
                try
                {
                    double num1 = Convert.ToDouble(input) / 1.0 + 1.0;
                    if (db.GetData("select isnull(max(code_items),0) from items where code_items='" + (object)num1 + "'").Rows[0][0].ToString() != "0")
                    {
                        ++num1;
                        if (db.GetData("select isnull(max(code_items),0) from items where code_items='" + (object)num1 + "'").Rows[0][0].ToString() != "0")
                        {
                            int num2 = (int)MessageBox.Show("يجب التكويد الصنف يدوي ");
                            txt_code_items.Text = "";
                            return;
                        }
                    }
                    txt_code_items.Text = string.Concat((object)num1);
                }
                catch (Exception ex)
                {
                    flag = true;
                }
                if (flag)
                    txt_code_items.Text = string.Concat((object)(Convert.ToDouble(Regex.Replace(input, "[^0-9]+", "")) + 1.0));
            }
            catch (Exception ex)
            {
                txt_code_items.Text = "";
            }
        }

        private void Btn_find_cat1_Click(object sender, EventArgs e)
        {
            all_comb.load_cat(combo_cat1, "cat1");

            combo_cat1.Text = "";
            txt_c1.Text = "";
        }

        private void Btn_find_cat2_Click(object sender, EventArgs e)
        {
            all_comb.load_cat(combo_cat2, "cat2");
            combo_cat2.Text = "";
            txt_c2.Text = "";


        }

        private void Btn_find_cat3_Click(object sender, EventArgs e)
        {
            all_comb.load_cat(combo_cat3, "cat3");
            combo_cat3.Text = "";
            txt_c3.Text = "";

        }

        private void Btn_find_cat4_Click(object sender, EventArgs e)
        {
            all_comb.load_cat(combo_cat4, "cat4");
            combo_cat4.Text = "";
            txt_c4.Text = "";

        }
        private void insert_cat(string cat, string target, string code_feild, string code)
        {
            if (code=="")
            {
                MessageBox.Show("يجب ادخال كود للتصنيف");
                return;
            }
            if (target == "" || target == "0" || target == null)
                return;
            try
            {
                string str = db.GetData("select (" + cat + ") from items_cat where " + cat + "='" + target + "'").Rows[0][0].ToString();
                if (str.Length > 0 && str == target)
                {
                    MessageBox.Show("اسم الصنف مكرر");
                    return;
                }
               
            }
            catch (Exception ex)
            {
            }
            if (!(db.GetData("select isnull(max(" + cat + "),0) from items_cat where " + cat + " ='" + target + "'  ").Rows[0][0].ToString() == "0"))
                return;
            db.Run("insert into items_cat (" + cat + ","+ code_feild + ") values ('" + target + "','"+code+"')");
            MessageBox.Show("تم إضافة المجموعة");
        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            if (db.GetData("select isnull(max(c1),'0') from items_cat  where c1='"+ txt_c1.Text+"'").Rows[0][0]+""!="0")
            {
                MessageBox.Show("الكود موجود من قبل");
                return;
            }
            insert_cat("cat1", combo_cat1.Text,"c1",txt_c1.Text);
        }

        private void SimpleButton3_Click(object sender, EventArgs e)
        {
            if (db.GetData("select isnull(max(c2),'0') from items_cat  where c2='" + txt_c2.Text + "'").Rows[0][0] + "" != "0")
            {
                MessageBox.Show("الكود موجود من قبل");
                return;
            }
            insert_cat("cat2", combo_cat2.Text, "c2", txt_c2.Text);

        }

        private void SimpleButton4_Click(object sender, EventArgs e)
        {
            if (db.GetData("select isnull(max(c3),'0') from items_cat  where c3='" + txt_c3.Text + "'").Rows[0][0] + "" != "0")
            {
                MessageBox.Show("الكود موجود من قبل");
                return;
            }
            insert_cat("cat3", combo_cat3.Text, "c3", txt_c3.Text);

        }

        private void SimpleButton5_Click(object sender, EventArgs e)
        {
            if (db.GetData("select isnull(max(c4),'0') from items_cat  where c4='" + txt_c4.Text + "'").Rows[0][0] + "" != "0")
            {
                MessageBox.Show("الكود موجود من قبل");
                return;
            }
            insert_cat("cat4", combo_cat4.Text, "c4", txt_c4.Text);
        }
        private void del_Cat(string cat, string target, System.Windows.Forms.ComboBox com,TextBox txt)
        {
            if (XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "سينم حذف المجموعة ", "رسال تاكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
                return;
            // db.Run("update  items_cat set " + cat + "=Null where " + cat + "='" + target + "'");

            db.Run("delete from items_cat where "+cat+" ='"+target+"'");
            all_comb.load_cat(com, cat);
            com.Text = "";
            txt.Text = "";
        }

        private void Btn_del_cat1_Click(object sender, EventArgs e)
        {
            del_Cat("cat1", combo_cat1.Text, combo_cat1,txt_c1);
        }

        private void Btn_del_cat2_Click(object sender, EventArgs e)
        {
            del_Cat("cat2", combo_cat2.Text, combo_cat2, txt_c2);
        }

        private void Btn_del_cat3_Click(object sender, EventArgs e)
        {
            del_Cat("cat3", combo_cat3.Text, combo_cat3, txt_c3);
        }

        private void Btn_del_cat4_Click(object sender, EventArgs e)
        {
            del_Cat("cat4", combo_cat4.Text, combo_cat4, txt_c4);
        }

        private void Chk_menu_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_menu.Checked)
            {
                ((Control)lbl_menu).Text = "1";
                combo_menu.Visible = true;
            }
            else
            {
                ((Control)lbl_menu).Text = "0";
                combo_menu.Visible = false;
            }
        }

        private void Lbl_menu_Click(object sender, EventArgs e)
        {
            if (((Control)lbl_menu).Text == "1")
                chk_menu.Checked = true;
            else
                chk_menu.Checked = false;
        }

        private void Btn_edit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string str1 = db.GetData("select (name_items) from items where name_items='" + txt_name_items.Text + "'").Rows[1][0].ToString();
                if (str1.Length > 0 && str1 == txt_name_items.Text)
                {
                    MessageBox.Show("اسم الصنف مكرر");
                    return;
                }
                else
                {
                    string str2 = db.GetData("select (name_items2) from items where name_items2='" + txt_name_items2.Text + "'").Rows[1][0].ToString();
                    if (str2.Length > 0 && str2 == txt_name_items2.Text)
                    {
                        MessageBox.Show("اسم الصنف مكرر");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            update();
        }

        private void Dgv_unit_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Convert.ToDouble(db.GetData("select isnull (max(f_unite),0) from purchase_dt where code_items='" + txt_code_items.Text + "'").Rows[0][0].ToString()) <= 1.0 || dgv_unit.Rows.Count <= 2)
                return;
            MessageBox.Show("يجب مسح فواتير المشنريات المتعلقة بالصنف لكي يتم تعديل في الوحدة");
            for (int index = 0; index < dgv_unit.Rows.Count - 1; ++index)
            {
                if (dgv_unit.Rows.Count > 1)
                {
                    dgv_unit.Columns["unite"].ReadOnly = true;
                    btn_edit.Enabled = (false);
                }
            }
        }

        private void Dgv_barcode_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //  id_barcode
            Classes.command.LoadSerial(dgv_barcode, "id_barcode");

        }

        private void Frm_item_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Control)
            {
                preform_save();
            }
            if (e.KeyCode == Keys.N && Control.ModifierKeys == Keys.Control)
            {
                new_items();
            }
            if (e.KeyCode == Keys.Delete && Control.ModifierKeys == Keys.Control)
            {
                delete();
            }
        }

        private void btn_pur_items_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (db.GetData("select isnull(max(code_items),0) from items where code_items ='"+txt_code_items.Text+"'").Rows[0][0]+""=="0")
            {
                XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "يجب تكويد الصنف!!؟؟؟؟ ", "رسال تحزير مستند", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            v.code_item_come_itmes = txt_code_items.Text + "f";
            Close();

        }

        private void num_percent_ValueChanged(object sender, EventArgs e)
        {

            // num_percent.Select();
            try
            {
                txt_price_sale.Text = (Convert.ToDouble((num_percent.Value / 100) + 1) * Convert.ToDouble(txt_price_buy.Text)) + "";
            }
            catch (Exception)
            {
            }

            
        }

        private void txt_barcode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string str2 = db.GetData("select isnull(max(barcode),0) from barcode where barcode='" + txt_barcode.Text + "'").Rows[0][0].ToString();
                    if (str2 != "0") { MessageBox.Show("باركود متكرر من قبل "); return; }

                    for (int i = 0; i < dgv_barcode.Rows.Count; i++)
                    {
                        if (txt_barcode.Text == dgv_barcode.Rows[i].Cells["barcode"].Value.ToString())
                        {
                            MessageBox.Show("الباركود مكرر ");
                            return;
                        }
                    }

                    if (edit == false)
                    {
                        dgv_barcode.Rows.Add("", txt_barcode.Text);
                        txt_barcode.Text = "";
                    }
                    else
                    {
                        DataTable dataTable = (DataTable)dgv_barcode.DataSource;
                        DataRow drToAdd = dataTable.NewRow();
                        drToAdd["id"] = "0";
                        drToAdd["barcode"] = txt_barcode.Text;
                        dataTable.Rows.Add(drToAdd);
                        dataTable.AcceptChanges();
                        txt_barcode.Text = "";
                    }

                }
            }
            catch (Exception)
            {

            }
          //  finally { txt_barcode.Text = ""; }
        
    }

        private void btn_generat_Code_Click(object sender, EventArgs e)
        {
            if (txt_main_code.Text == "")
            {
              MessageBox.Show("يجب عمل كود رئيسي ");
            }
            else
            {
                
                string str1 = "";
                if (radioButton1.Checked)
                {
                    for (int index = 0; index < dgv_matrix.Rows.Count ; ++index)
                    {
                        string snamc1 = db.GetData("select isnull(max(cat1),'-') from items_cat  where c1='" + dgv_matrix.Rows[index].Cells[0].Value+"" + "' ").Rows[0][0] + "";

                        dgv_show_matrix.Rows.Add(0, txt_main_code.Text + dgv_matrix.Rows[index].Cells[0].Value, dgv_unit.Rows[0].Cells[1].Value, dgv_unit.Rows[0].Cells[2].Value, snamc1);// dgv_matrix.Rows[index].Cells["catmx1"].Value, dgv_matrix.Rows[index].Cells["catmx2"].Value, dgv_matrix.Rows[index].Cells["catmx3"].Value, dgv_matrix.Rows[index].Cells["catmx4"].Value);
                        str1 = "";
                    }
                }
                else if (radioButton2.Checked)
                {
                    for (int index1 = 0; index1 < dgv_matrix.Rows.Count ; ++index1)
                    {
                        string str2 = dgv_matrix.Rows[index1].Cells[0].Value+"";
                        

                        for (int index2 = 0; index2 < dgv_matrix.Rows.Count ; ++index2)
                        {
                            if (str2 != "")
                            {
                                string str3 = dgv_matrix.Rows[index2].Cells[1].Value+"";

                                if (str3 != "")
                                {
                                    string snamc1 = db.GetData("select isnull(max(cat1),'-') from items_cat  where c1='" + str2 + "' ").Rows[0][0] + "";
                                    string snamc2 = db.GetData("select isnull(max(cat2),'-') from items_cat  where c2='" + str3 + "' ").Rows[0][0] + "";

                                    //dgv_show_matrix.Rows.Add(0, (txt_main_code.Text + str2 + str3), dgv_unit.Rows[0].Cells[1].Value, dgv_unit.Rows[0].Cells[2].Value, dgv_matrix.Rows[index1].Cells["catmx1"].Value, dgv_matrix.Rows[index1].Cells["catmx2"].Value, dgv_matrix.Rows[index1].Cells["catmx3"].Value, dgv_matrix.Rows[index1].Cells["catmx4"].Value);
                                    dgv_show_matrix.Rows.Add(0, (txt_main_code.Text + str2 + str3), dgv_unit.Rows[0].Cells[1].Value, dgv_unit.Rows[0].Cells[2].Value, snamc1,snamc2);//dgv_matrix.Rows[index1].Cells["catmx1"].Value, dgv_matrix.Rows[index1].Cells["catmx2"].Value, dgv_matrix.Rows[index1].Cells["catmx3"].Value, dgv_matrix.Rows[index1].Cells["catmx4"].Value);


                                    str1 = "";
                                }
                            }
                        }
                    }
                }
                else if (radioButton3.Checked)
                {
                    for (int index1 = 0; index1 < dgv_matrix.Rows.Count ; ++index1)
                    {
                        string str2 = string.Concat(dgv_matrix.Rows[index1].Cells[0].Value);

                        for (int index2 = 0; index2 < dgv_matrix.Rows.Count ; ++index2)
                        {
                            if (str2 != "")
                            {
                                string str3 = string.Concat(dgv_matrix.Rows[index2].Cells[1].Value);

                                if (str3 != "")
                                {
                                    for (int index3 = 0; index3 < dgv_matrix.Rows.Count ; ++index3)
                                    {
                                        if (str3 != "")
                                        {
                                            string str4 = string.Concat(dgv_matrix.Rows[index3].Cells[2].Value);

                                            if (str4 != "")
                                            {
                                                string snamc1 = db.GetData("select isnull(max(cat1),'-') from items_cat  where c1='" + str2 + "' ").Rows[0][0] + "";
                                                string snamc2 = db.GetData("select isnull(max(cat2),'-') from items_cat  where c2='" + str3 + "' ").Rows[0][0] + "";
                                                string snamc3 = db.GetData("select isnull(max(cat3),'-') from items_cat  where c3='" + str4 + "' ").Rows[0][0] + "";

                                                //dgv_show_matrix.Rows.Add(0, (txt_main_code.Text + str2 + str3 + str4), dgv_unit.Rows[0].Cells[1].Value, dgv_unit.Rows[0].Cells[2].Value, dgv_matrix.Rows[index1].Cells["catmx1"].Value, dgv_matrix.Rows[index1].Cells["catmx2"].Value, dgv_matrix.Rows[index1].Cells["catmx3"].Value, dgv_matrix.Rows[index1].Cells["catmx4"].Value);
                                                dgv_show_matrix.Rows.Add(0, (txt_main_code.Text + str2 + str3 + str4), dgv_unit.Rows[0].Cells[1].Value, dgv_unit.Rows[0].Cells[2].Value, snamc1, snamc2, snamc3);//dgv_matrix.Rows[index1].Cells["catmx1"].Value, dgv_matrix.Rows[index1].Cells["catmx2"].Value, dgv_matrix.Rows[index1].Cells["catmx3"].Value, dgv_matrix.Rows[index1].Cells["catmx4"].Value);

                                                str1 = "";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (!radioButton4.Checked)
                        return;
                    for (int index1 = 0; index1 < dgv_matrix.Rows.Count ; ++index1)
                    {
                        string str2 = string.Concat(dgv_matrix.Rows[index1].Cells[0].Value);

                        for (int index2 = 0; index2 < dgv_matrix.Rows.Count ; ++index2)
                        {
                            if (str2 != "")
                            {
                                string str3 = string.Concat(dgv_matrix.Rows[index2].Cells[1].Value);

                                if (str3 != "")
                                {
                                    for (int index3 = 0; index3 < dgv_matrix.Rows.Count ; ++index3)
                                    {
                                        if (str3 != "")
                                        {
                                            string str4 = string.Concat(dgv_matrix.Rows[index3].Cells[2].Value);

                                            if (str4 != "")
                                            {
                                                for (int index4 = 0; index4 < dgv_matrix.Rows.Count ; ++index4)
                                                {
                                                    string str5 = string.Concat(dgv_matrix.Rows[index4].Cells[3].Value);

                                                    if (str5 != "")
                                                    {
                                                        //dgv_show_matrix.Rows.Add(0, (txt_main_code.Text + str2 + str3 + str4 + str5), dgv_unit.Rows[0].Cells[1].Value, dgv_unit.Rows[0].Cells[2].Value, dgv_matrix.Rows[index1].Cells["catmx1"].Value, dgv_matrix.Rows[index1].Cells["catmx2"].Value, dgv_matrix.Rows[index1].Cells["catmx3"].Value, dgv_matrix.Rows[index1].Cells["catmx4"].Value);
                                                        string snamc1 = db.GetData("select isnull(max(cat1),'-') from items_cat  where c1='"+str2+"' ").Rows[0][0] + "";
                                                        string snamc2 = db.GetData("select isnull(max(cat2),'-') from items_cat  where c2='" + str3 + "' ").Rows[0][0] + "";
                                                        string snamc3 = db.GetData("select isnull(max(cat3),'-') from items_cat  where c3='" + str4 + "' ").Rows[0][0] + "";
                                                        string snamc4 = db.GetData("select isnull(max(cat4),'-') from items_cat  where c4='" + str5 + "' ").Rows[0][0] + "";

                                                        dgv_show_matrix.Rows.Add(0, (txt_main_code.Text + str2 + str3 + str4 + str5), dgv_unit.Rows[0].Cells[1].Value, dgv_unit.Rows[0].Cells[2].Value, snamc1, snamc2, snamc3, snamc4);

                                                        str1 = "";
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btn_vreify_matrix_Click(object sender, EventArgs e)
        {
            int z = 0;
            prog1 = dgv_show_matrix.Rows.Count;//to know progras bar 
            for (int i = 0; i < dgv_show_matrix.Rows.Count; i++)
            {
                string old_code = db.GetData("select count( code_items) from items  where code_items='" + dgv_show_matrix.Rows[i].Cells[1].Value + "'").Rows[0][0].ToString();
                if (Convert.ToInt32(old_code) >= 1)
                {
                    XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "الصنف موجد في القاعده  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btn_save_matrix.Visible = false;
                    return;
                }
                string x1 = dgv_show_matrix.Rows[i].Cells[1].Value.ToString();
                for (int ii = 0; ii < dgv_show_matrix.Rows.Count; ii++)
                {
                    z += 0;
                    string x3 = dgv_show_matrix.Rows[ii].Cells[1].Value.ToString();
                    if (x1 == x3 && z == 0)
                    {
                        z = 1;
                    }
                    else if (x1 == x3 || z > 1)
                    {
                        XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "الصنف متكرر ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btn_save_matrix.Visible = false;
                        return;
                    }
                    backgroundWorker1.ReportProgress(i);

                }
                z = 0;
                backgroundWorker1.ReportProgress(i);
            }

            for (int i = 0; i < dgv_matrix.Rows.Count; i++)
            {
                string first_line = dgv_matrix.Rows[i].Cells[0].Value + "";
                if (first_line=="")
                {
                    MessageBox.Show("هناك سطر لا توجد بيانات بة");
                    btn_save_matrix.Visible = false;

                    return;

                }
            }
            for (int index = 0; index < dgv_show_matrix.Rows.Count; ++index)
            {

                if (dgv_show_matrix.Rows[index].Cells["cat1"].Value+""=="-")
                {
                    MessageBox.Show("هناك عناصر لم تدخل بعد");
                    btn_save_matrix.Visible = false;
                    return;
                }
                if (dgv_show_matrix.Rows[index].Cells["cat2"].Value + "" == "-")
                {
                    MessageBox.Show("هناك عناصر لم تدخل بعد");
                    btn_save_matrix.Visible = false;
                    return;
                }
                if (dgv_show_matrix.Rows[index].Cells["cat3"].Value + "" == "-")
                {
                    MessageBox.Show("هناك عناصر لم تدخل بعد");
                    btn_save_matrix.Visible = false;
                    return;
                }
                if (dgv_show_matrix.Rows[index].Cells["cat4"].Value + "" == "-")
                {
                    MessageBox.Show("هناك عناصر لم تدخل بعد");
                    btn_save_matrix.Visible = false;
                    return;
                }
                if ((dgv_show_matrix.Rows[index].Cells["discount_buy_m"].Value)+"" == "")
                    dgv_show_matrix.Rows[index].Cells["discount_buy_m"].Value = "0";
                if ((dgv_show_matrix.Rows[index].Cells["discount_sale_m"].Value)+"" == "")
                    dgv_show_matrix.Rows[index].Cells["discount_sale_m"].Value = "0";
                if ((dgv_show_matrix.Rows[index].Cells["price_buy_m"].Value)+"" == "")
                    dgv_show_matrix.Rows[index].Cells["price_buy_m"].Value = "0";
                if ((dgv_show_matrix.Rows[index].Cells["price_sale_m"].Value)+"" == "")
                    dgv_show_matrix.Rows[index].Cells["price_sale_m"].Value = "0";
                if (db.GetData("select isnull(max (main_code),0) from items where main_code='" + txt_main_code.Text + "'").Rows[0][0].ToString() != "0")
                {
                    // XtraMessageBox.Show(UserLookAndFeel.Default,  {"الكود موجود من قبل  \n",dgv_matrix.Rows[index].Cells[1].Value, "\nسطر  ", dgv_matrix.Rows[index].Cells[0].Value}), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "الكود موجود من قبل  ", "رسال خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btn_save_matrix.Visible = false;

                    return;
                }
                String st_code = "";
                st_code = dgv_show_matrix.Rows[index].Cells["code_items_m"].Value + "";
                if (st_code.Length > 50)
                {
                    XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "لايجب ان يزيد الكود عن 50  ", "رسال خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btn_save_matrix.Visible = false;

                    return;
                }
                else if (db.GetData("select isnull(max (code_items),0) from items where code_items='" + dgv_show_matrix.Rows[index].Cells[1].Value + "'").Rows[0][0].ToString() != "0")
                {
                    XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "الكود موجود من قبل  ", "رسال خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btn_save_matrix.Visible = false;
                    return;
                }
            }
            btn_save_matrix.Visible = true;
        }
        int prog1 = 0;
        private async void  btn_save_matrix_Click(object sender, EventArgs e)
        {
           
            int count = dgv_show_matrix.Rows.Count;
            progressBar1.Visible = true;
            prog1 = dgv_show_matrix.Rows.Count;
            for (int i = 0; i < dgv_show_matrix.Rows.Count; ++i)
            {
                count = i + 1;
                lbl_number_of_loop.Text = string.Concat((object)count);
                lbl_remin_loop.Text = string.Concat((object)(dgv_show_matrix.Rows.Count - count));
                db.cmd.CommandText = "insert into items (code_items,name_items,name_items2,name_unite,unit1,price_buy,price_sale,taxes,[exp],[type],discount_buy,discount_sale,main_code,couta_type,cat1,cat2,cat3,cat4 )values('" + dgv_show_matrix.Rows[i].Cells["code_items_m"].Value.ToString() + "','" + txt_name_items.Text + "','" + txt_name_items2.Text + " " + dgv_show_matrix.Rows[i].Cells["code_items_m"].Value.ToString() + "','" + dgv_show_matrix.Rows[i].Cells["name_unite_m1"].Value.ToString() + "',1,'" + dgv_show_matrix.Rows[i].Cells["price_buy_m"].Value.ToString() + "','" + dgv_show_matrix.Rows[i].Cells["price_sale_m"].Value.ToString() + "','" + combo_taxes.Text + "','False','" + lbl_type_items.Text + "','" + dgv_show_matrix.Rows[i].Cells["discount_buy_m"].Value.ToString() + "','" + dgv_show_matrix.Rows[i].Cells["discount_sale_m"].Value.ToString() + "','" + txt_main_code.Text + "','0','"+ dgv_show_matrix.Rows[i].Cells["cat1"].Value+"" + "','" + dgv_show_matrix.Rows[i].Cells["cat2"].Value+"" + "','" + dgv_show_matrix.Rows[i].Cells["cat3"].Value+"" + "','" + dgv_show_matrix.Rows[i].Cells["cat4"].Value+"" + "')";
                int num1 = await((DbCommand)db.cmd).ExecuteNonQueryAsync();
                db.cmd.CommandText = "insert into unite (id,name_unite,code_items,unite)values('1','" + dgv_show_matrix.Rows[i].Cells["name_unite_m1"].Value.ToString() + "','" + dgv_show_matrix.Rows[i].Cells["code_items_m"].Value.ToString() + "','1')";
                int num2 = await((DbCommand)db.cmd).ExecuteNonQueryAsync();
                string unite2 = string.Concat(dgv_show_matrix.Rows[i].Cells["f_unite_m2"].Value);
                if (unite2 != "")
                {
                    db.cmd.CommandText = "insert into unite (id,name_unite,code_items,unite)values('2','" + dgv_show_matrix.Rows[i].Cells["name_unite2"].Value.ToString() + "','" + dgv_show_matrix.Rows[i].Cells["code_items_m"].Value.ToString() + "','" + dgv_show_matrix.Rows[i].Cells["f_unite_m2"].Value.ToString() + "')";
                    int num3 = await((DbCommand)db.cmd).ExecuteNonQueryAsync();
                }
                string barcode1 = string.Concat(dgv_show_matrix.Rows[i].Cells["barcode_m"].Value);
                if (barcode1 != "")
                {
                    db.cmd.CommandText = "insert into barcode (id,barcode,code_items)values('1','" + dgv_show_matrix.Rows[i].Cells["barcode_m"].Value.ToString() + "','" + dgv_show_matrix.Rows[i].Cells["code_items_m"].Value.ToString() + "')";
                    int num3 = await((DbCommand)db.cmd).ExecuteNonQueryAsync();
                }
                backgroundWorker1.ReportProgress(i);
            }
            DataTable dtwares = new DataTable();
            DataTable dtacc = new DataTable();
            db.GetData_DGV("select DISTINCT(id_ware) from wares", dtwares);
            for (int i = 0; i < dtwares.Rows.Count; ++i)
            {
                int id_wares = 0;
                id_wares = Convert.ToInt32(dtwares.Rows[i][0].ToString());
                for (int ii = 0; ii < dgv_show_matrix.Rows.Count; ++ii)
                {
                    count = ii + 1;
                    lbl_number_of_loop.Text = count+"";
                    lbl_remin_loop.Text =dgv_show_matrix.Rows.Count - count+"";
                    db.cmd.CommandText = "insert into wares (id_ware,code_items,name_items,qty,cost,tot,acc,demand_limit,demand_maximum,demand_limit_bit,demand_maximum_bit)values('" + id_wares + "','" + dgv_show_matrix.Rows[ii].Cells["code_items_m"].Value.ToString() + "','" + txt_name_items.Text + "',0,0,0,0,0,0,'False','False')";
                    int num = await((DbCommand)db.cmd).ExecuteNonQueryAsync();
                    backgroundWorker1.ReportProgress(ii);
                }
                backgroundWorker1.ReportProgress(i);
            }
            progressBar1.Visible = false;
            XtraMessageBox.Show(UserLookAndFeel.Default, "saving ", "save", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Maximum = dgv_show_matrix.Rows.Count;
            progressBar1.Value = e.ProgressPercentage;
        }

        private void dgv_show_matrix_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv_show_matrix, "no1");
        }

        private void dgv_show_matrix_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            Classes.command.LoadSerial(dgv_show_matrix, "no1");

        }

        private void dgv_matrix_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Classes.command.LoadSerial(dgv_matrix, "no_recev");

        }

        private void dgv_matrix_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            Classes.command.LoadSerial(dgv_matrix, "no_recev");

        }

        private void btn_search_cat_Click(object sender, EventArgs e)
        {
            all_comb.load_cat(combm1, "cat1");
            combm1.Text = "";
            txtc1.Text = "";
            all_comb.load_cat(combm2, "cat2");
            combm2.Text = "";
            txtc2.Text = "";

            all_comb.load_cat(combm3, "cat3");
            combm3.Text = "";
            txtc3.Text = "";

            all_comb.load_cat(combm4, "cat4");
            combm4.Text = "";
            txtc4.Text = "";

        }

        private void btn1_add_m_Click(object sender, EventArgs e)
        {
            if (dgv_matrix.Rows.Count==0)
            {
                return;
            }
            if (txtc1.Text=="")
            {
                MessageBox.Show("يجب اختيار تصنيف ");
                return;
            }
            if (combm1.Text == "") return;
            dgv_matrix.CurrentRow.Cells["catmx1"].Value = combm1.Text;
            dgv_matrix.CurrentRow.Cells[0].Value = txtc1.Text;
        }

        private void btn2_add_m_Click(object sender, EventArgs e)
        {
            if (txtc2.Text == "")
            {
                MessageBox.Show("يجب اختيار تصنيف ");
                return;
            }
            if (combm2.Text == "") return;
            dgv_matrix.CurrentRow.Cells["catmx2"].Value = combm2.Text;
            dgv_matrix.CurrentRow.Cells[1].Value = txtc2.Text;

        }

        private void btn3_add_m_Click(object sender, EventArgs e)
        {
            if (txtc3.Text == "")
            {
                MessageBox.Show("يجب اختيار تصنيف ");
                return;
            }
            if (combm3.Text == "") return;
            dgv_matrix.CurrentRow.Cells["catmx3"].Value = combm3.Text;
            dgv_matrix.CurrentRow.Cells[2].Value = txtc3.Text;
        }

        private void btn4_add_m_Click(object sender, EventArgs e)
        {
            if (txtc4.Text == "")
            {
                MessageBox.Show("يجب اختيار تصنيف ");
                return;
            }
            if (combm4.Text == "") return;
            dgv_matrix.CurrentRow.Cells["catmx4"].Value = combm4.Text;
            dgv_matrix.CurrentRow.Cells[3].Value = txtc4.Text;
        }

        private void txt_name_items_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '\''))
            {
                e.Handled = true;
            }
        }

        private void txt_name_items2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '\''))
            {
                e.Handled = true;
            }
        }

        private void txt_barcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '\''))
            {
                e.Handled = true;
            }
        }

        private void txt_main_code_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '\''))
            {
                e.Handled = true;
            }
        }

        private void read_code_cat(TextBox txt,string number_of_filed_code,string cat_tab,string target)
        {
            //select ISNULL(MAX(c1),'-') from items_cat where cat1=''
            try
            {
                txt.Text = db.GetData("select ISNULL(MAX(" + number_of_filed_code + "),'-') from items_cat where " + cat_tab + "='" + target + "'").Rows[0][0] + "";
            }
            catch (Exception)
            {
            }
        }
      
        private void combo_cat1_SelectedIndexChanged(object sender, EventArgs e)
        {
            read_code_cat(txt_c1,"c1","cat1",combo_cat1.Text);
        }

        private void combo_cat2_SelectedIndexChanged(object sender, EventArgs e)
        {
            read_code_cat(txt_c2, "c2", "cat2", combo_cat2.Text);

        }

        private void combo_cat3_SelectedIndexChanged(object sender, EventArgs e)
        {
            read_code_cat(txt_c3, "c3", "cat3", combo_cat3.Text);

        }

        private void combo_cat4_SelectedIndexChanged(object sender, EventArgs e)
        {
            read_code_cat(txt_c4, "c4", "cat4", combo_cat4.Text);

        }

        private void combm1_SelectedIndexChanged(object sender, EventArgs e)
        {
            read_code_cat(txtc1, "c1", "cat1", combm1.Text);
            
        }

        private void combm2_SelectedIndexChanged(object sender, EventArgs e)
        {
            read_code_cat(txtc2, "c2", "cat2", combm2.Text);

        }

        private void combm3_SelectedIndexChanged(object sender, EventArgs e)
        {
            read_code_cat(txtc3, "c3", "cat3", combm3.Text);

        }

        private void combm4_SelectedIndexChanged(object sender, EventArgs e)
        {
            read_code_cat(txtc4, "c4", "cat4", combm4.Text);

        }

        private void btn_add_line_Click(object sender, EventArgs e)
        {
            dgv_matrix.Rows.Add("");
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (v.search_screen_code != "")
            {
                txt_code_items.Text = v.search_screen_code;
                txt_code_items.Select();
                txt_name_items.Select();
                timer1.Enabled = false;

            }
        }








        //===============================================endnavigation================================
        // ----------------------------------------hotkeys













        //===================
    }
}