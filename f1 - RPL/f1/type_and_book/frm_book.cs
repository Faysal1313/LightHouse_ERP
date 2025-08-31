using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Windows.Forms;
namespace f1
{
    public partial class frm_book : DevExpress.XtraEditors.XtraForm
    {
        public frm_book()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(v.ico);
            db.Open();
        }
        bool edit = false;
        DataTable dt = new DataTable();
        private void frm_book_Load(object sender, EventArgs e)
        {

        }

        //function
        private void load_book(System.Windows.Forms.ComboBox comb)
        {
            try
            {
                db.GetData_DGV("select distinct code_book from book where cat_book='" + com.Text + "' ", dt);
                comb.DisplayMember = "code_book";
                comb.DataSource = dt;
            }
            catch (Exception ex)
            {
                txt_start.Text = "".Trim();
                txt_name_book.Text = "".Trim();
                txt_end.Text = "".Trim();
                // com.Text = "".Trim();
                combo_code_book.Text = "".Trim();
                dt.Rows.Clear();
                MessageBox.Show(ex.Message);
                
            }
        }
        private void save_update()
        {
            if (edit == false)
            {
                if (combo_code_book.Text != "" & txt_name_book.Text != "" & txt_start.Text != "" & txt_end.Text != "")
                {
                    db.Run("insert into book(code_book,name_book, start, [end],cat_book)values('" + combo_code_book.Text + "','" + txt_name_book.Text + "'," + txt_start.Text + "," + txt_end.Text + ",'" + com.Text + "')");
                }
                else
                {
                    MessageBox.Show("filed is Empty");
                    return;
                }

                MessageBox.Show("save");

            }
            else
            {
                //update
                db.Run("update book name_book  where code_book='" + combo_code_book.Text + "' and cat_book='" + com.Text + "'");
                db.Run("update book set start where code_book='" + combo_code_book.Text + "' and cat_book='" + com.Text + "'");
                db.Run("update book set start where code_book='" + combo_code_book.Text + "' and cat_book='" + com.Text + "'");
                MessageBox.Show("update");
            }
           
        }
        private void clera()
        {
            edit = false;
            txt_start.Text = "".Trim();
            txt_name_book.Text = "".Trim();
            txt_end.Text = "".Trim();
           // com.Text = "".Trim();
            combo_code_book.Text = "".Trim();
            dt.Rows.Clear();
        }
        private void delete()
        {
            db.Run("DELETE FROM [book] WHERE [code_book]='" + combo_code_book.Text + "'");

        }
        //===========
        private void search_barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            edit = true;
            save_barButtonItem1.Enabled = false;
            dt.Rows.Clear();
            load_book(combo_code_book);
        }

        private void combo_code_book_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txt_name_book.Text = db.GetData("select name_book from book where code_book='" + combo_code_book.Text + "'").Rows[0][0].ToString();
                txt_start.Text = db.GetData("select start from book where code_book='" + combo_code_book.Text + "'").Rows[0][0].ToString();
                txt_end.Text = db.GetData("select [end] from book where code_book='" + combo_code_book.Text + "'").Rows[0][0].ToString();
            }
            catch (Exception)
            {

            }
        }

        private void new_barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            clera();
        }

        private void save_barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            save_update(); 
        }

        private void delete_barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            delete();
        }

        private void combo_code_book_Click(object sender, EventArgs e)
        {
            try
            {
                txt_name_book.Text = db.GetData("select name_book from book where   cat_book='" + com.Text + "'").Rows[0][0].ToString();
                txt_start.Text = db.GetData("select start from book where  cat_book='" + com.Text + "'").Rows[0][0].ToString();
                txt_end.Text = db.GetData("select [end] from book where  cat_book='" + com.Text + "'").Rows[0][0].ToString();
                combo_code_book.Text=db.GetData("select [code_book] from book where  cat_book='" + com.Text + "'").Rows[0][0].ToString();
                  
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

       

        //---------------------------HOTKEYS------------------------
        private void frm_book_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && Control.ModifierKeys == Keys.Control)
            {
                save_update();
            }
            if (e.KeyCode == Keys.N && Control.ModifierKeys == Keys.Control)
            {
                clera();
            }
            if (e.KeyCode == Keys.Delete && Control.ModifierKeys == Keys.Control)
            {
                delete();
            }
        }













       
    }
}