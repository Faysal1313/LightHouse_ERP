using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace f1
{
    public partial class frm_picture : DevExpress.XtraEditors.XtraForm
    {
        public frm_picture()
        {
            InitializeComponent();
        }

        private void btn_Save_image_Click(object sender, EventArgs e)
        {

        }

        private void first_image_btn_Click(object sender, EventArgs e)
        {

        }

        private void back_image_btn_Click(object sender, EventArgs e)
        {

        }

        private void next_image_btn_Click(object sender, EventArgs e)
        {

        }

        private void last_image_btn_Click(object sender, EventArgs e)
        {

        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {

        }

        private void remove_btn_Click(object sender, EventArgs e)
        {

        }

        private void add_image_simpleButton1_Click(object sender, EventArgs e)
        {

        }
        private void load_image(string lbl_doc_no, string lbl_number_pic_)
        {
            try
            {
                lbl_number_pic.Text = db.GetData("select top 1 id_image from doc_image where id_doc='" + lbl_doc_no + "'").Rows[0][0].ToString();
                DataTable dt = new DataTable();
                db.GetData_DGV("select image from doc_image where id_doc='" + lbl_doc_no + "' and id_image='" + lbl_number_pic_ + "'", dt);
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
                db.GetData_DGV("select id_image from doc_image where id_doc='" + lbl_doc_no + "'", dt_id);
                dgv_image.DataSource = dt_id;
            }
            catch (Exception)
            {


            }
        }
        string image_loaction = "";
        private void btn_Save_image_Click_1(object sender, EventArgs e)
        {
            if (lbl_doc_no.Text != "")
            {
                byte[] image = null;
                FileStream stream = new FileStream(image_loaction, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(stream);
                image = brs.ReadBytes((int)stream.Length);
                db.cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@img", image));
               db.Run("insert into doc_image(id_doc,image) values ('" + lbl_doc_no.Text + "',@img)");

                MessageBox.Show("successfully");
                db.cmd.Parameters.Clear();
                image = null;
            }
        }

        private void btn_refresh_Click_1(object sender, EventArgs e)
        {
            load_image(lbl_doc_no.Text, lbl_number_pic.Text);
            first_image_btn.PerformClick();
        }

        private void add_image_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "png files (*.png)|*.png|jpg files(*.jpg)|*.jpg|All Files(*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                image_loaction = ofd.FileName.ToString();
                pictureBox1.ImageLocation = image_loaction;
            }
        }

        private void remove_btn_Click_1(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = XtraMessageBox.Show(DevExpress.LookAndFeel.UserLookAndFeel.Default, "هل تريد الحذف!!؟؟؟؟ ", "رسال حذف مستند", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                db.Run("delete from doc_image  where id_doc='" + lbl_doc_no.Text + "' and id_image='" + lbl_number_pic.Text + "'");
            }
            else
            {
                return;
            }
        }

        private void frm_picture_Load(object sender, EventArgs e)
        {
          

        }

        private void dgv_image_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string id = dgv_image.CurrentRow.Cells[0].Value.ToString();
                load_image(lbl_doc_no.Text, id);
                lbl_number_pic.Text = id;
            }
            catch (Exception)
            {

              
            }
        }

        private void dgv_image_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = true;
        }
    }
}