using QuanLySinhVien.BLL;
using QuanLySinhVien.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien.UI
{
    public partial class EditGrade : Form
    {
        Grade grade;
        public EditGrade(Grade grade)
        {
            InitializeComponent();
            this.grade = grade;
            lbMSSV.Text = grade.MSSV;
            lbCourseID.Text = grade.CourseID;
            lbSemester.Text = grade.Semester;
            tbDiemGK.Text = grade.DiemGK.ToString();
            tbDiemCK.Text = grade.DiemCK.ToString();
            tbDiemKhac.Text = grade.DiemKhac.ToString();
            tbDiemTong.Text = grade.DiemTong.ToString();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ManagementBLL mBLL = new ManagementBLL();
            grade.DiemGK = float.Parse(tbDiemGK.Text);
            grade.DiemCK = float.Parse(tbDiemCK.Text);
            grade.DiemKhac = float.Parse(tbDiemKhac.Text);
            grade.DiemTong = float.Parse(tbDiemTong.Text);
            mBLL.updateGrade(grade);
        }
    }
}
