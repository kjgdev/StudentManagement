namespace QuanLySinhVien.UI
{
    partial class GradeStudent
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
            this.cbSemester = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gvGrade = new System.Windows.Forms.DataGridView();
            this.CourseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiemGK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiemCK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiemKhac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiemTong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrade)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.cbYear);
            this.panel1.Controls.Add(this.cbSemester);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1178, 128);
            this.panel1.TabIndex = 0;
            // 
            // cbSemester
            // 
            this.cbSemester.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSemester.FormattingEnabled = true;
            this.cbSemester.Location = new System.Drawing.Point(491, 78);
            this.cbSemester.Name = "cbSemester";
            this.cbSemester.Size = new System.Drawing.Size(152, 29);
            this.cbSemester.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(374, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 21);
            this.label3.TabIndex = 14;
            this.label3.Text = "Semester:";
            // 
            // gvGrade
            // 
            this.gvGrade.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvGrade.BackgroundColor = System.Drawing.Color.White;
            this.gvGrade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvGrade.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CourseID,
            this.DiemGK,
            this.DiemCK,
            this.DiemKhac,
            this.DiemTong});
            this.gvGrade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvGrade.GridColor = System.Drawing.Color.Silver;
            this.gvGrade.Location = new System.Drawing.Point(0, 128);
            this.gvGrade.Name = "gvGrade";
            this.gvGrade.RowHeadersWidth = 51;
            this.gvGrade.RowTemplate.Height = 24;
            this.gvGrade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvGrade.Size = new System.Drawing.Size(1178, 525);
            this.gvGrade.TabIndex = 4;
            // 
            // CourseID
            // 
            this.CourseID.HeaderText = "Course ID";
            this.CourseID.MinimumWidth = 6;
            this.CourseID.Name = "CourseID";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(374, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 21);
            this.label1.TabIndex = 14;
            this.label1.Text = "Year:";
            // 
            // cbYear
            // 
            this.cbYear.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbYear.FormattingEnabled = true;
            this.cbYear.Items.AddRange(new object[] {
            "1617",
            "1718",
            "1819",
            "1920",
            "2021"});
            this.cbYear.Location = new System.Drawing.Point(491, 27);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(152, 29);
            this.cbYear.TabIndex = 15;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(951, 35);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(150, 50);
            this.btnSearch.TabIndex = 16;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // GradeStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gvGrade);
            this.Controls.Add(this.panel1);
            this.Name = "GradeStudent";
            this.Size = new System.Drawing.Size(1178, 653);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvGrade)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbSemester;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView gvGrade;
        private System.Windows.Forms.DataGridViewTextBoxColumn CourseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiemGK;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiemCK;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiemKhac;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiemTong;
        private System.Windows.Forms.ComboBox cbYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
    }
}
