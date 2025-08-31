namespace f1
{
    partial class frm_sub_ledger_wares
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_sub_ledger_wares));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txt_acc_name = new System.Windows.Forms.TextBox();
            this.txt_acc_id = new System.Windows.Forms.TextBox();
            this.dgv_acc = new System.Windows.Forms.DataGridView();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.acc_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acc_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_acc)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_acc_name
            // 
            this.txt_acc_name.Location = new System.Drawing.Point(12, 12);
            this.txt_acc_name.Name = "txt_acc_name";
            this.txt_acc_name.Size = new System.Drawing.Size(100, 20);
            this.txt_acc_name.TabIndex = 0;
            // 
            // txt_acc_id
            // 
            this.txt_acc_id.Location = new System.Drawing.Point(195, 12);
            this.txt_acc_id.Name = "txt_acc_id";
            this.txt_acc_id.Size = new System.Drawing.Size(100, 20);
            this.txt_acc_id.TabIndex = 1;
            // 
            // dgv_acc
            // 
            this.dgv_acc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_acc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_acc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_acc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_acc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.acc_id,
            this.acc_name});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_acc.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_acc.Location = new System.Drawing.Point(0, 38);
            this.dgv_acc.Name = "dgv_acc";
            this.dgv_acc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_acc.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_acc.Size = new System.Drawing.Size(324, 243);
            this.dgv_acc.TabIndex = 2;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButton1.Location = new System.Drawing.Point(152, 285);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(38, 36);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.Image")));
            this.simpleButton2.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.simpleButton2.Location = new System.Drawing.Point(88, 285);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(41, 36);
            this.simpleButton2.TabIndex = 4;
            this.simpleButton2.Click += new System.EventHandler(this.delete_simpleButton2_Click);
            // 
            // acc_id
            // 
            this.acc_id.DataPropertyName = "acc_id";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.acc_id.DefaultCellStyle = dataGridViewCellStyle2;
            this.acc_id.HeaderText = "رقم";
            this.acc_id.Name = "acc_id";
            // 
            // acc_name
            // 
            this.acc_name.DataPropertyName = "acc_name";
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.acc_name.DefaultCellStyle = dataGridViewCellStyle3;
            this.acc_name.HeaderText = "اسم الرابط";
            this.acc_name.Name = "acc_name";
            // 
            // frm_sub_ledger_wares
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 323);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.dgv_acc);
            this.Controls.Add(this.txt_acc_id);
            this.Controls.Add(this.txt_acc_name);
            this.Name = "frm_sub_ledger_wares";
            this.Text = "frm_sub_ledger_wares";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_acc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_acc_name;
        private System.Windows.Forms.TextBox txt_acc_id;
        private System.Windows.Forms.DataGridView dgv_acc;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private System.Windows.Forms.DataGridViewTextBoxColumn acc_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn acc_name;
    }
}