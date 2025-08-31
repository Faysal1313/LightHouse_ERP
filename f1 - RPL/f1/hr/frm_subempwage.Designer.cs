namespace f1.hr
{
    partial class frm_subempwage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_subempwage));
            this.dgv = new System.Windows.Forms.DataGridView();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpCode_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Empname_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fValue_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btn_save_salary_emp = new DevExpress.XtraEditors.SimpleButton();
            this.btn_add_Emp = new DevExpress.XtraEditors.SimpleButton();
            this.dgv2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emp_no_c = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emp_name_c = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fValue_c = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_del = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.no,
            this.EmpCode_,
            this.Empname_,
            this.fValue_});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgv.Location = new System.Drawing.Point(0, 66);
            this.dgv.Name = "dgv";
            this.dgv.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(724, 224);
            this.dgv.TabIndex = 5;
            // 
            // no
            // 
            this.no.FillWeight = 24.22118F;
            this.no.HeaderText = "م";
            this.no.Name = "no";
            this.no.ReadOnly = true;
            // 
            // EmpCode_
            // 
            this.EmpCode_.DataPropertyName = "emp_no";
            this.EmpCode_.FillWeight = 116.2617F;
            this.EmpCode_.HeaderText = "كود الموظف";
            this.EmpCode_.Name = "EmpCode_";
            this.EmpCode_.ReadOnly = true;
            // 
            // Empname_
            // 
            this.Empname_.DataPropertyName = "emp_name";
            this.Empname_.FillWeight = 116.2617F;
            this.Empname_.HeaderText = "اسم الموظف";
            this.Empname_.Name = "Empname_";
            this.Empname_.ReadOnly = true;
            // 
            // fValue_
            // 
            this.fValue_.DataPropertyName = "fValue";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.fValue_.DefaultCellStyle = dataGridViewCellStyle3;
            this.fValue_.FillWeight = 116.2617F;
            this.fValue_.HeaderText = "المبلغ";
            this.fValue_.Name = "fValue_";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btn_del);
            this.groupControl1.Controls.Add(this.btn_save_salary_emp);
            this.groupControl1.Controls.Add(this.btn_add_Emp);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(724, 62);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "groupControl1";
            // 
            // btn_save_salary_emp
            // 
            this.btn_save_salary_emp.Image = ((System.Drawing.Image)(resources.GetObject("btn_save_salary_emp.Image")));
            this.btn_save_salary_emp.Location = new System.Drawing.Point(325, 22);
            this.btn_save_salary_emp.Name = "btn_save_salary_emp";
            this.btn_save_salary_emp.Size = new System.Drawing.Size(124, 38);
            this.btn_save_salary_emp.TabIndex = 5;
            this.btn_save_salary_emp.Text = "حفظ الرواتب";
            this.btn_save_salary_emp.Click += new System.EventHandler(this.btn_save_salary_emp_Click);
            // 
            // btn_add_Emp
            // 
            this.btn_add_Emp.Image = ((System.Drawing.Image)(resources.GetObject("btn_add_Emp.Image")));
            this.btn_add_Emp.Location = new System.Drawing.Point(195, 22);
            this.btn_add_Emp.Name = "btn_add_Emp";
            this.btn_add_Emp.Size = new System.Drawing.Size(124, 38);
            this.btn_add_Emp.TabIndex = 4;
            this.btn_add_Emp.Text = "إضافه الموظفين";
            this.btn_add_Emp.Click += new System.EventHandler(this.btn_add_Emp_Click);
            // 
            // dgv2
            // 
            this.dgv2.AllowUserToAddRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgv2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.emp_no_c,
            this.emp_name_c,
            this.fValue_c});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv2.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgv2.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgv2.Location = new System.Drawing.Point(0, 309);
            this.dgv2.Name = "dgv2";
            this.dgv2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv2.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgv2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv2.Size = new System.Drawing.Size(724, 99);
            this.dgv2.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 24.22118F;
            this.dataGridViewTextBoxColumn1.HeaderText = "م";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // emp_no_c
            // 
            this.emp_no_c.DataPropertyName = "emp_no";
            this.emp_no_c.FillWeight = 116.2617F;
            this.emp_no_c.HeaderText = "كود الموظف";
            this.emp_no_c.Name = "emp_no_c";
            this.emp_no_c.ReadOnly = true;
            // 
            // emp_name_c
            // 
            this.emp_name_c.DataPropertyName = "emp_name";
            this.emp_name_c.FillWeight = 116.2617F;
            this.emp_name_c.HeaderText = "اسم الموظف";
            this.emp_name_c.Name = "emp_name_c";
            this.emp_name_c.ReadOnly = true;
            // 
            // fValue_c
            // 
            this.fValue_c.DataPropertyName = "fValue";
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.fValue_c.DefaultCellStyle = dataGridViewCellStyle8;
            this.fValue_c.FillWeight = 116.2617F;
            this.fValue_c.HeaderText = "المبلغ";
            this.fValue_c.Name = "fValue_c";
            // 
            // btn_del
            // 
            this.btn_del.Image = ((System.Drawing.Image)(resources.GetObject("btn_del.Image")));
            this.btn_del.Location = new System.Drawing.Point(455, 23);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(124, 38);
            this.btn_del.TabIndex = 6;
            this.btn_del.Text = "حذف موظف";
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // frm_subempwage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 435);
            this.Controls.Add(this.dgv2);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.groupControl1);
            this.Name = "frm_subempwage";
            this.Text = "frm_subempwage";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btn_save_salary_emp;
        private DevExpress.XtraEditors.SimpleButton btn_add_Emp;
        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn emp_no_c;
        private System.Windows.Forms.DataGridViewTextBoxColumn emp_name_c;
        private System.Windows.Forms.DataGridViewTextBoxColumn fValue_c;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpCode_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empname_;
        private System.Windows.Forms.DataGridViewTextBoxColumn fValue_;
        private DevExpress.XtraEditors.SimpleButton btn_del;
    }
}