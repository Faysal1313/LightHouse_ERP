
namespace f1
{
    partial class frm_picture
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_picture));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgv_image = new System.Windows.Forms.DataGridView();
            this.id_image_c = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Save_image = new DevExpress.XtraEditors.SimpleButton();
            this.first_image_btn = new DevExpress.XtraEditors.SimpleButton();
            this.back_image_btn = new DevExpress.XtraEditors.SimpleButton();
            this.next_image_btn = new DevExpress.XtraEditors.SimpleButton();
            this.last_image_btn = new DevExpress.XtraEditors.SimpleButton();
            this.btn_refresh = new DevExpress.XtraEditors.SimpleButton();
            this.remove_btn = new DevExpress.XtraEditors.SimpleButton();
            this.add_image_btn = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_number_pic = new DevExpress.XtraEditors.LabelControl();
            this.labelControl31 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_doc_no = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_image)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(264, 462);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // dgv_image
            // 
            this.dgv_image.AllowUserToAddRows = false;
            this.dgv_image.AllowUserToDeleteRows = false;
            this.dgv_image.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_image.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_image.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_image.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_image.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_image_c});
            this.dgv_image.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_image.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_image.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgv_image.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_image.Location = new System.Drawing.Point(690, 0);
            this.dgv_image.MultiSelect = false;
            this.dgv_image.Name = "dgv_image";
            this.dgv_image.ReadOnly = true;
            this.dgv_image.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_image.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_image.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_image.Size = new System.Drawing.Size(150, 462);
            this.dgv_image.TabIndex = 135;
            this.dgv_image.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_image_CellClick);
            this.dgv_image.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_image_DataError);
            // 
            // id_image_c
            // 
            this.id_image_c.DataPropertyName = "id_image";
            this.id_image_c.HeaderText = "id_image";
            this.id_image_c.Name = "id_image_c";
            this.id_image_c.ReadOnly = true;
            // 
            // btn_Save_image
            // 
            this.btn_Save_image.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn_Save_image.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save_image.ImageOptions.Image")));
            this.btn_Save_image.Location = new System.Drawing.Point(339, 216);
            this.btn_Save_image.Name = "btn_Save_image";
            this.btn_Save_image.Size = new System.Drawing.Size(124, 38);
            this.btn_Save_image.TabIndex = 150;
            this.btn_Save_image.Text = "Save Image";
            this.btn_Save_image.Click += new System.EventHandler(this.btn_Save_image_Click_1);
            // 
            // first_image_btn
            // 
            this.first_image_btn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.first_image_btn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("first_image_btn.ImageOptions.Image")));
            this.first_image_btn.Location = new System.Drawing.Point(500, 346);
            this.first_image_btn.Name = "first_image_btn";
            this.first_image_btn.Size = new System.Drawing.Size(41, 31);
            this.first_image_btn.TabIndex = 149;
            this.first_image_btn.Text = "Next";
            // 
            // back_image_btn
            // 
            this.back_image_btn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.back_image_btn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("back_image_btn.ImageOptions.Image")));
            this.back_image_btn.Location = new System.Drawing.Point(458, 346);
            this.back_image_btn.Name = "back_image_btn";
            this.back_image_btn.Size = new System.Drawing.Size(41, 31);
            this.back_image_btn.TabIndex = 148;
            this.back_image_btn.Text = "Next";
            // 
            // next_image_btn
            // 
            this.next_image_btn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.next_image_btn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("next_image_btn.ImageOptions.Image")));
            this.next_image_btn.Location = new System.Drawing.Point(415, 346);
            this.next_image_btn.Name = "next_image_btn";
            this.next_image_btn.Size = new System.Drawing.Size(41, 31);
            this.next_image_btn.TabIndex = 147;
            this.next_image_btn.Text = "Next";
            // 
            // last_image_btn
            // 
            this.last_image_btn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.last_image_btn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("last_image_btn.ImageOptions.Image")));
            this.last_image_btn.Location = new System.Drawing.Point(372, 346);
            this.last_image_btn.Name = "last_image_btn";
            this.last_image_btn.Size = new System.Drawing.Size(41, 31);
            this.last_image_btn.TabIndex = 146;
            this.last_image_btn.Text = "Next";
            // 
            // btn_refresh
            // 
            this.btn_refresh.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btn_refresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_refresh.ImageOptions.Image")));
            this.btn_refresh.Location = new System.Drawing.Point(465, 216);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(124, 38);
            this.btn_refresh.TabIndex = 145;
            this.btn_refresh.Text = "Refresh";
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click_1);
            // 
            // remove_btn
            // 
            this.remove_btn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.remove_btn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("remove_btn.ImageOptions.Image")));
            this.remove_btn.Location = new System.Drawing.Point(465, 255);
            this.remove_btn.Name = "remove_btn";
            this.remove_btn.Size = new System.Drawing.Size(124, 38);
            this.remove_btn.TabIndex = 144;
            this.remove_btn.Text = "Remove Image";
            this.remove_btn.Click += new System.EventHandler(this.remove_btn_Click_1);
            // 
            // add_image_btn
            // 
            this.add_image_btn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.add_image_btn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("add_image_btn.ImageOptions.Image")));
            this.add_image_btn.Location = new System.Drawing.Point(339, 255);
            this.add_image_btn.Name = "add_image_btn";
            this.add_image_btn.Size = new System.Drawing.Size(124, 38);
            this.add_image_btn.TabIndex = 143;
            this.add_image_btn.Text = "Add Image";
            this.add_image_btn.Click += new System.EventHandler(this.add_image_btn_Click);
            // 
            // labelControl16
            // 
            this.labelControl16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl16.Location = new System.Drawing.Point(476, 129);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(49, 13);
            this.labelControl16.TabIndex = 152;
            this.labelControl16.Text = "رقم الصوره";
            // 
            // lbl_number_pic
            // 
            this.lbl_number_pic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_number_pic.Location = new System.Drawing.Point(410, 129);
            this.lbl_number_pic.Name = "lbl_number_pic";
            this.lbl_number_pic.Size = new System.Drawing.Size(18, 13);
            this.lbl_number_pic.TabIndex = 151;
            this.lbl_number_pic.Text = "000";
            // 
            // labelControl31
            // 
            this.labelControl31.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl31.Location = new System.Drawing.Point(476, 71);
            this.labelControl31.Name = "labelControl31";
            this.labelControl31.Size = new System.Drawing.Size(48, 13);
            this.labelControl31.TabIndex = 154;
            this.labelControl31.Text = "رقم السند";
            // 
            // lbl_doc_no
            // 
            this.lbl_doc_no.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_doc_no.Location = new System.Drawing.Point(410, 71);
            this.lbl_doc_no.Name = "lbl_doc_no";
            this.lbl_doc_no.Size = new System.Drawing.Size(18, 13);
            this.lbl_doc_no.TabIndex = 153;
            this.lbl_doc_no.Text = "000";
            // 
            // frm_picture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 462);
            this.Controls.Add(this.labelControl31);
            this.Controls.Add(this.lbl_doc_no);
            this.Controls.Add(this.labelControl16);
            this.Controls.Add(this.lbl_number_pic);
            this.Controls.Add(this.btn_Save_image);
            this.Controls.Add(this.first_image_btn);
            this.Controls.Add(this.back_image_btn);
            this.Controls.Add(this.next_image_btn);
            this.Controls.Add(this.last_image_btn);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.remove_btn);
            this.Controls.Add(this.add_image_btn);
            this.Controls.Add(this.dgv_image);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_picture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Picture";
            this.Load += new System.EventHandler(this.frm_picture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgv_image;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_image_c;
        private DevExpress.XtraEditors.SimpleButton btn_Save_image;
        private DevExpress.XtraEditors.SimpleButton first_image_btn;
        private DevExpress.XtraEditors.SimpleButton back_image_btn;
        private DevExpress.XtraEditors.SimpleButton next_image_btn;
        private DevExpress.XtraEditors.SimpleButton last_image_btn;
        private DevExpress.XtraEditors.SimpleButton btn_refresh;
        private DevExpress.XtraEditors.SimpleButton remove_btn;
        private DevExpress.XtraEditors.SimpleButton add_image_btn;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.LabelControl lbl_number_pic;
        private DevExpress.XtraEditors.LabelControl labelControl31;
        public DevExpress.XtraEditors.LabelControl lbl_doc_no;
    }
}