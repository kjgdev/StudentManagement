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
    public partial class Schedule : UserControl
    {
        ManagementBLL mBLL = new ManagementBLL();
        public Schedule()
        {
            InitializeComponent();
            initComboBox();
        }

        public void initComboBox()
        {
            /*----- ComboBox Class ------*/
            cbClass.Items.Clear();
            List<string> list = mBLL.getClassID();
            foreach (string item in list)
            {
                cbClass.Items.Add(item);
            }
            cbClass.SelectedIndex = 0;

            /*----- ComboBox Semester ------*/
            cbSemester.Items.Clear();
            List<string> list2 = mBLL.getSemester();
            foreach (string item in list2)
            {
                cbSemester.Items.Add(item);
            }
            cbSemester.SelectedIndex = 0;
        }

        void insertDataGV()
        {
            gvSchedule.Rows.Clear();
            ManagementBLL mBLL = new ManagementBLL();
            List<Course> courseList = mBLL.GetSchedule(cbClass.SelectedItem.ToString(), cbSemester.SelectedItem.ToString());
            foreach (Course course in courseList)
            {
                int n = gvSchedule.Rows.Add();
                gvSchedule.Rows[n].Cells[0].Value = course.ID;
                gvSchedule.Rows[n].Cells[1].Value = course.Name;
                gvSchedule.Rows[n].Cells[2].Value = course.RoomID;
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            insertDataGV();
        }
    }
}
