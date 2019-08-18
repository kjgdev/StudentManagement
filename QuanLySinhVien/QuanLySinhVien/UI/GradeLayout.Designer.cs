namespace QuanLySinhVien.UI
{
    partial class GradeLayout
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cbViews = new System.Windows.Forms.ComboBox();
            this.cbSemester = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCourse = new System.Windows.Forms.ComboBox();
            this.cbClass = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gvGrade = new System.Windows.Forms.DataGridView();
            this.MSSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiemGK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiemCK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiemKhac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiemTong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbDau = new System.Windows.Forms.Label();
            this.lbRot = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrade)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbRot);
            this.panel1.Controls.Add(this.lbDau);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbViews);
            this.panel1.Controls.Add(this.cbSemester);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbCourse);
            this.panel1.Controls.Add(this.cbClass);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1178, 128);
            this.panel1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(333, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "Views";
            // 
            // cbViews
            // 
            this.cbViews.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbViews.FormattingEnabled = true;
            this.cbViews.Items.AddRange(new object[] {
            "All",
            "Pass",
            "Fail"});
            this.cbViews.Location = new System.Drawing.Point(468, 73);
            this.cbViews.Name = "cbViews";
            this.cbViews.Size = new System.Drawing.Size(121, 29);
            this.cbViews.TabIndex = 6;
            this.cbViews.SelectedIndexChanged += new System.EventHandler(this.CbViews_SelectedIndexChanged);
            // 
            // cbSemester
            // 
            this.cbSemester.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSemester.FormattingEnabled = true;
            this.cbSemester.Location = new System.Drawing.Point(468, 23);
            this.cbSemester.Name = "cbSemester";
            this.cbSemester.Size = new System.Drawing.Size(121, 29);
            this.cbSemester.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(333, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Semester:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(994, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 40);
            this.button1.TabIndex = 3;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Course:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Class:";
            // 
            // cbCourse
            // 
            this.cbCourse.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCourse.FormattingEnabled = true;
            this.cbCourse.Location = new System.Drawing.Point(112, 73);
            this.cbCourse.Name = "cbCourse";
            this.cbCourse.Size = new System.Drawing.Size(152, 29);
            this.cbCourse.TabIndex = 1;
            // 
            // cbClass
            // 
            this.cbClass.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbClass.FormattingEnabled = true;
            this.cbClass.Location = new System.Drawing.Point(112, 23);
            this.cbClass.Name = "cbClass";
            this.cbClass.Size = new System.Drawing.Size(152, 29);
            this.cbClass.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gvGrade);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 128);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1178, 525);
            this.panel2.TabIndex = 2;
            // 
            // gvGrade
            // 
            this.gvGrade.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvGrade.BackgroundColor = System.Drawing.Color.White;
            this.gvGrade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvGrade.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MSSV,
            this.Name,
            this.DiemGK,
            this.DiemCK,
            this.DiemKhac,
            this.DiemTong});
            this.gvGrade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvGrade.GridColor = System.Drawing.Color.Silver;
            this.gvGrade.Location = new System.Drawing.Point(0, 0);
            this.gvGrade.Name = "gvGrade";
            this.gvGrade.RowHeadersWidth = 51;
            this.gvGrade.RowTemplate.Height = 24;
            this.gvGrade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvGrade.Size = new System.Drawing.Size(1178, 525);
            this.gvGrade.TabIndex = 3;
            this.gvGrade.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GvGrade_CellClick);
            // 
            // MSSV
            // 
            this.MSSV.HeaderText = "MSSV";
            this.MSSV.MinimumWidth = 6;
            this.MSSV.Name = "MSSV";
            this.MSSV.ReadOnly = true;
            // 
            // Name
            // 
            this.Name.HeaderText = "Name";
            this.Name.MinimumWidth = 6;
            this.Name.Name = "Name";
            // 
            // DiemGK
            // 
            this.DiemGK.HeaderText = "DiemGK";
            this.DiemGK.MinimumWidth = 6;
            this.DiemGK.Name = "DiemGK";
            // 
            // DiemCK
            // 
            this.DiemCK.HeaderText = "DiemCK";
            this.DiemCK.MinimumWidth = 6;
            this.DiemCK.Name = "DiemCK";
            // 
            // DiemKhac
            // 
            this.DiemKhac.HeaderText = "DiemKhac";
            this.DiemKhac.MinimumWidth = 6;
            this.DiemKhac.Name = "DiemKhac";
            // 
            // DiemTong
            // 
            this.DiemTong.HeaderText = "DiemTong";
            this.DiemTong.MinimumWidth = 6;
            this.DiemTong.Name = "DiemTong";
            // 
            // lbDau
            // 
            this.lbDau.AutoSize = true;
            this.lbDau.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDau.Location = new System.Drawing.Point(700, 26);
            this.lbDau.Name = "lbDau";
            this.lbDau.Size = new System.Drawing.Size(0, 21);
            this.lbDau.TabIndex = 8;
            // 
            // lbRot
            // 
            this.lbRot.AutoSize = true;
            this.lbRot.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRot.Location = new System.Drawing.Point(700, 81);
            this.lbRot.Name = "lbRot";
            this.lbRot.Size = new System.Drawing.Size(0, 21);
            this.lbRot.TabIndex = 8;
            // 
            // GradeLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Size = new System.Drawing.Size(1178, 653);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvGrade)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbSemester;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCourse;
        private System.Windows.Forms.ComboBox cbClass;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView gvGrade;
        private System.Windows.Forms.DataGridViewTextBoxColumn MSSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiemGK;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiemCK;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiemKhac;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiemTong;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbViews;
        private System.Windows.Forms.Label lbRot;
        private System.Windows.Forms.Label lbDau;
    }
}
