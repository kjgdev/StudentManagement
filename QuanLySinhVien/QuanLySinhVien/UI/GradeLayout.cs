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
    public partial class GradeLayout : UserControl
    {
        public GradeLayout()
        {
            InitializeComponent();
            initComboBox();
        }

        public void initComboBox()
        {
            try
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
                cbViews.SelectedIndex = 0;
            }
            catch { MessageBox.Show("No Data"); }
        }

        void insertDataGrade()
        {
            gvGrade.Rows.Clear();
            ManagementBLL mBLL = new ManagementBLL();
            List<Entity.Grade> gradeList = mBLL.getGradeList(cbClass.SelectedItem.ToString(), cbSemester.SelectedItem.ToString(), cbCourse.SelectedItem.ToString());
            foreach (Entity.Grade grade in gradeList)
            {
                int n;
                switch (cbViews.Text)
                {
                    case "Pass":
                        {
                            if (grade.DiemTong >= 5)
                            {
                                n = gvGrade.Rows.Add();
                                gvGrade.Rows[n].Cells[0].Value = grade.MSSV;
                                gvGrade.Rows[n].Cells[1].Value = grade.Name;
                                gvGrade.Rows[n].Cells[2].Value = grade.DiemGK;
                                gvGrade.Rows[n].Cells[3].Value = grade.DiemCK;
                                gvGrade.Rows[n].Cells[4].Value = grade.DiemKhac;
                                gvGrade.Rows[n].Cells[5].Value = grade.DiemTong;
                            }
                            break;

                        }
                    case "Fail":
                        {
                            if (grade.DiemTong < 5)
                            {
                                n = gvGrade.Rows.Add();
                                gvGrade.Rows[n].Cells[0].Value = grade.MSSV;
                                gvGrade.Rows[n].Cells[1].Value = grade.Name;
                                gvGrade.Rows[n].Cells[2].Value = grade.DiemGK;
                                gvGrade.Rows[n].Cells[3].Value = grade.DiemCK;
                                gvGrade.Rows[n].Cells[4].Value = grade.DiemKhac;
                                gvGrade.Rows[n].Cells[5].Value = grade.DiemTong;
                            }
                            break;
                            
                        }
                    default:
                        n = gvGrade.Rows.Add();
                        gvGrade.Rows[n].Cells[0].Value = grade.MSSV;
                        gvGrade.Rows[n].Cells[1].Value = grade.Name;
                        gvGrade.Rows[n].Cells[2].Value = grade.DiemGK;
                        gvGrade.Rows[n].Cells[3].Value = grade.DiemCK;
                        gvGrade.Rows[n].Cells[4].Value = grade.DiemKhac;
                        gvGrade.Rows[n].Cells[5].Value = grade.DiemTong;
                        break;
                }
            }
            int pass = 0;
            int fail = 0;
            foreach (Entity.Grade grade in gradeList)
            {
                if (grade.DiemTong >= 5) pass++;
                else if (grade.DiemTong < 5) fail++;
            }
            double lenght = gradeList.Count;
            double Pass = pass / lenght * 100;
            double Fail = fail / lenght * 100;
            lbDau.Text = $"Pass:{pass}/{Pass} %";
            lbRot.Text = $"Fail: {fail}/{Fail} %";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            insertDataGrade();
        }

        private void GvGrade_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Entity.Grade grade = new Entity.Grade();
            int index = e.RowIndex;

            DataGridViewRow row = gvGrade.Rows[index];
            TextBox textBox = new TextBox();
            grade.MSSV = row.Cells[0].Value.ToString();
            grade.DiemGK = float.Parse(row.Cells[2].Value.ToString());
            grade.DiemCK = float.Parse(row.Cells[3].Value.ToString());
            grade.DiemKhac = float.Parse(row.Cells[4].Value.ToString());
            grade.DiemTong = float.Parse(row.Cells[5].Value.ToString());
            grade.Semester = cbSemester.SelectedItem.ToString();
            grade.ClassID = cbClass.SelectedItem.ToString();
            grade.CourseID = cbCourse.SelectedItem.ToString();

            EditGrade layoutEdit = new EditGrade(grade);
            layoutEdit.Show();
        }

        private void CbViews_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
