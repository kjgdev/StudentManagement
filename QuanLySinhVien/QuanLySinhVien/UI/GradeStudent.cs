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

namespace QuanLySinhVien.UI
{
    public partial class GradeStudent : UserControl
    {
        string MSSV;
        public GradeStudent(string MSSV)
        {
            InitializeComponent();
            initComboBox();
            this.MSSV = MSSV;
        }

        public void initComboBox()
        {
            try
            {
                ManagementBLL mBLL = new ManagementBLL();
                /*----- ComboBox Semester ------*/
                cbSemester.Items.Clear();
                List<string> list2 = mBLL.getSemester();
                foreach (string item in list2)
                {
                    cbSemester.Items.Add(item);
                }
                cbSemester.SelectedIndex = 0;

                cbYear.SelectedIndex = 2;
            }
            catch { MessageBox.Show("No Data"); }
        }

        void insertDataGrade()
        {
            gvGrade.Rows.Clear();
            ManagementBLL mBLL = new ManagementBLL();
            
            List<Entity.Grade> list = mBLL.getGradeStudent(MSSV,cbYear.SelectedItem.ToString(),cbSemester.SelectedItem.ToString());
            foreach(Entity.Grade item in list)
            {
                int n = gvGrade.Rows.Add();
                gvGrade.Rows[n].Cells[0].Value = item.CourseID;
                gvGrade.Rows[n].Cells[1].Value = item.DiemGK;
                gvGrade.Rows[n].Cells[2].Value = item.DiemCK;
                gvGrade.Rows[n].Cells[3].Value = item.DiemKhac;
                gvGrade.Rows[n].Cells[4].Value = item.DiemTong;
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            insertDataGrade();
        }
    }
}
