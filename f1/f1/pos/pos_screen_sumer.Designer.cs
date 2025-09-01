
namespace f1.pos
{
    partial class pos_screen_sumer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv_inv = new System.Windows.Forms.DataGridView();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pos_inv_no_inv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code_items_inv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_opening = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_discount = new DevExpress.XtraEditors.LabelControl();
            this.lbl_expenses = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_tot = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_sum = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_credit = new DevExpress.XtraEditors.LabelControl();
            this.lbl_credit_name = new DevExpress.XtraEditors.LabelControl();
            this.lbl_gift = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_inv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_inv
            // 
            this.dgv_inv.AllowUserToAddRows = false;
            this.dgv_inv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_inv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_inv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dgv_inv.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_inv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_inv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_inv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.no,
            this.pos_inv_no_inv,
            this.code_items_inv,
            this.dataGridViewTextBoxColumn23,
            this.dataGridViewTextBoxColumn24,
            this.dataGridViewTextBoxColumn25,
            this.dataGridViewTextBoxColumn26,
            this.tot,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn21,
            this.dataGridViewTextBoxColumn16});
            this.dgv_inv.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgv_inv.Location = new System.Drawing.Point(1, -2);
            this.dgv_inv.Name = "dgv_inv";
            this.dgv_inv.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgv_inv.Size = new System.Drawing.Size(922, 266);
            this.dgv_inv.TabIndex = 5;
            this.dgv_inv.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgv_inv_RowsAdded);
            // 
            // no
            // 
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.no.DefaultCellStyle = dataGridViewCellStyle11;
            this.no.FillWeight = 24.22118F;
            this.no.HeaderText = "م";
            this.no.Name = "no";
            this.no.ReadOnly = true;
            // 
            // pos_inv_no_inv
            // 
            this.pos_inv_no_inv.DataPropertyName = "pos_inv_no";
            this.pos_inv_no_inv.HeaderText = "رقم الفاتورة";
            this.pos_inv_no_inv.Name = "pos_inv_no_inv";
            // 
            // code_items_inv
            // 
            this.code_items_inv.DataPropertyName = "code_items";
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.code_items_inv.DefaultCellStyle = dataGridViewCellStyle12;
            this.code_items_inv.HeaderText = "كود الصنف";
            this.code_items_inv.Name = "code_items_inv";
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.DataPropertyName = "name_items";
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridViewTextBoxColumn23.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn23.HeaderText = "اسم الصنف";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.DataPropertyName = "name_unite";
            this.dataGridViewTextBoxColumn24.HeaderText = "اسم الوحدة";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.DataPropertyName = "qty";
            this.dataGridViewTextBoxColumn25.HeaderText = "الكمية";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.DataPropertyName = "item_price";
            this.dataGridViewTextBoxColumn26.HeaderText = "سعر البيع";
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            // 
            // tot
            // 
            this.tot.DataPropertyName = "incloud_taxes";
            this.tot.HeaderText = "الاجمالي";
            this.tot.Name = "tot";
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "discount_all";
            this.dataGridViewTextBoxColumn19.FillWeight = 116.2617F;
            this.dataGridViewTextBoxColumn19.HeaderText = "الخصم الكلي ";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "date_d";
            dataGridViewCellStyle14.Format = "d";
            dataGridViewCellStyle14.NullValue = null;
            this.dataGridViewTextBoxColumn21.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewTextBoxColumn21.HeaderText = "تاريخ ";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "time_h";
            dataGridViewCellStyle15.Format = "t";
            dataGridViewCellStyle15.NullValue = null;
            this.dataGridViewTextBoxColumn16.DefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewTextBoxColumn16.FillWeight = 116.2617F;
            this.dataGridViewTextBoxColumn16.HeaderText = "الوقت ";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            // 
            // labelControl18
            // 
            this.labelControl18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl18.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl18.Appearance.Options.UseFont = true;
            this.labelControl18.Location = new System.Drawing.Point(133, 279);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(110, 17);
            this.labelControl18.TabIndex = 165;
            this.labelControl18.Text = "الرصيد الافتتاحي";
            // 
            // lbl_opening
            // 
            this.lbl_opening.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_opening.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_opening.Appearance.Options.UseFont = true;
            this.lbl_opening.Location = new System.Drawing.Point(27, 280);
            this.lbl_opening.Name = "lbl_opening";
            this.lbl_opening.Size = new System.Drawing.Size(8, 16);
            this.lbl_opening.TabIndex = 164;
            this.lbl_opening.Text = "0";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(692, 350);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(90, 17);
            this.labelControl1.TabIndex = 166;
            this.labelControl1.Text = "الخصم الكلي ";
            // 
            // lbl_discount
            // 
            this.lbl_discount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_discount.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_discount.Appearance.Options.UseFont = true;
            this.lbl_discount.Location = new System.Drawing.Point(586, 350);
            this.lbl_discount.Name = "lbl_discount";
            this.lbl_discount.Size = new System.Drawing.Size(8, 16);
            this.lbl_discount.TabIndex = 167;
            this.lbl_discount.Text = "0";
            // 
            // lbl_expenses
            // 
            this.lbl_expenses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_expenses.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_expenses.Appearance.Options.UseFont = true;
            this.lbl_expenses.Location = new System.Drawing.Point(319, 351);
            this.lbl_expenses.Name = "lbl_expenses";
            this.lbl_expenses.Size = new System.Drawing.Size(8, 16);
            this.lbl_expenses.TabIndex = 169;
            this.lbl_expenses.Text = "0";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(425, 351);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(72, 17);
            this.labelControl3.TabIndex = 168;
            this.labelControl3.Text = "المصروفات";
            // 
            // lbl_tot
            // 
            this.lbl_tot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_tot.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_tot.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lbl_tot.Appearance.Options.UseFont = true;
            this.lbl_tot.Appearance.Options.UseForeColor = true;
            this.lbl_tot.Location = new System.Drawing.Point(12, 383);
            this.lbl_tot.Name = "lbl_tot";
            this.lbl_tot.Size = new System.Drawing.Size(8, 16);
            this.lbl_tot.TabIndex = 171;
            this.lbl_tot.Text = "0";
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Location = new System.Drawing.Point(121, 383);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(92, 17);
            this.labelControl4.TabIndex = 170;
            this.labelControl4.Text = "الرصيد الفعلي";
            // 
            // lbl_sum
            // 
            this.lbl_sum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_sum.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_sum.Appearance.Options.UseFont = true;
            this.lbl_sum.Location = new System.Drawing.Point(586, 280);
            this.lbl_sum.Name = "lbl_sum";
            this.lbl_sum.Size = new System.Drawing.Size(8, 16);
            this.lbl_sum.TabIndex = 173;
            this.lbl_sum.Text = "0";
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(692, 280);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(182, 17);
            this.labelControl5.TabIndex = 172;
            this.labelControl5.Text = "إجمالي الفواتير و المرتجعات";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 50F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(503, 280);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(29, 81);
            this.labelControl2.TabIndex = 174;
            this.labelControl2.Text = "-";
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 50F, System.Drawing.FontStyle.Bold);
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Appearance.Options.UseForeColor = true;
            this.labelControl6.Location = new System.Drawing.Point(239, 343);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(55, 81);
            this.labelControl6.TabIndex = 175;
            this.labelControl6.Text = "=";
            // 
            // lbl_credit
            // 
            this.lbl_credit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_credit.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_credit.Appearance.Options.UseFont = true;
            this.lbl_credit.Location = new System.Drawing.Point(346, 280);
            this.lbl_credit.Name = "lbl_credit";
            this.lbl_credit.Size = new System.Drawing.Size(8, 16);
            this.lbl_credit.TabIndex = 177;
            this.lbl_credit.Text = "0";
            // 
            // lbl_credit_name
            // 
            this.lbl_credit_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_credit_name.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_credit_name.Appearance.Options.UseFont = true;
            this.lbl_credit_name.Location = new System.Drawing.Point(452, 280);
            this.lbl_credit_name.Name = "lbl_credit_name";
            this.lbl_credit_name.Size = new System.Drawing.Size(36, 17);
            this.lbl_credit_name.TabIndex = 176;
            this.lbl_credit_name.Text = "الاجل";
            // 
            // lbl_gift
            // 
            this.lbl_gift.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_gift.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_gift.Appearance.Options.UseFont = true;
            this.lbl_gift.Location = new System.Drawing.Point(451, 411);
            this.lbl_gift.Name = "lbl_gift";
            this.lbl_gift.Size = new System.Drawing.Size(8, 16);
            this.lbl_gift.TabIndex = 179;
            this.lbl_gift.Text = "0";
            // 
            // labelControl8
            // 
            this.labelControl8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(557, 411);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(37, 17);
            this.labelControl8.TabIndex = 178;
            this.labelControl8.Text = "هداية";
            // 
            // pos_screen_sumer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 431);
            this.Controls.Add(this.lbl_gift);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.lbl_credit);
            this.Controls.Add(this.lbl_credit_name);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.lbl_sum);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.lbl_tot);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.lbl_expenses);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.lbl_discount);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl18);
            this.Controls.Add(this.lbl_opening);
            this.Controls.Add(this.dgv_inv);
            this.Name = "pos_screen_sumer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ملخص الرصيد الفعلي";
            this.Load += new System.EventHandler(this.pos_screen_sumer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_inv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_inv;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.LabelControl lbl_opening;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lbl_discount;
        private DevExpress.XtraEditors.LabelControl lbl_expenses;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lbl_tot;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewTextBoxColumn pos_inv_no_inv;
        private System.Windows.Forms.DataGridViewTextBoxColumn code_items_inv;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private System.Windows.Forms.DataGridViewTextBoxColumn tot;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private DevExpress.XtraEditors.LabelControl lbl_sum;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl lbl_credit;
        private DevExpress.XtraEditors.LabelControl lbl_credit_name;
        private DevExpress.XtraEditors.LabelControl lbl_gift;
        private DevExpress.XtraEditors.LabelControl labelControl8;
    }
}