using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLySinhVien.BLL;
using QuanLySinhVien.Entity;

namespace QuanLySinhVien.UI
{
    public partial class Grade : UserControl
    {
        public Grade()
        {
            InitializeComponent();
            initComboBox();
        }

        public void initComboBox()
        {
            ManagementBLL mBLL = new ManagementBLL();
            /*----- ComboBox Class ------*/
            cbClass.Items.Clear();
            List<string> list = mBLL.getClassID();
            foreach (string item in list)
            {
                cbClass.Items.Add(item);
            }
            cbClass.SelectedIndex = 0;

            /*----- ComboBox Course ------*/
            cbCourse.Items.Clear();
            List<string> list1 = mBLL.getCourseID();
            foreach (string item in list1)
            {
                cbCourse.Items.Add(item);
            }
            cbCourse.SelectedIndex = 0;

            /*----- ComboBox Semester ------*/
            cbSemester.Items.Clear();
            List<string> list2 = mBLL.getSemester();
            foreach (string item in list2)
            {
                cbSemester.Items.Add(item);
            }
            cbSemester.SelectedIndex = 0;
        }

        void insertDataGrade()
        {
            gvGrade.Rows.Clear();
            ManagementBLL mBLL = new ManagementBLL();
            List<Entity.Grade> gradeList = mBLL.getGradeList(cbClass.SelectedItem.ToString(), cbSemester.SelectedItem.ToString(), cbCourse.SelectedItem.ToString());
            foreach(Entity.Grade grade in gradeList)
            {
                int n = gvGrade.Rows.Add();
                gvGrade.Rows[n].Cells[0].Value = grade.MSSV;
                gvGrade.Rows[n].Cells[1].Value = grade.Name;
                gvGrade.Rows[n].Cells[2].Value = grade.DiemGK;
                gvGrade.Rows[n].Cells[3].Value = grade.DiemCK;
                gvGrade.Rows[n].Cells[4].Value = grade.DiemKhac;
                gvGrade.Rows[n].Cells[5].Value = grade.DiemTong;
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            insertDataGrade();
        }
    }
}
