using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLySinhVien.Entity;
using QuanLySinhVien.BLL;

namespace QuanLySinhVien.UI
{
    public partial class StudentLayout : UserControl
    {
        ManagementBLL mBLL = new ManagementBLL();
        
        public StudentLayout()
        {
            InitializeComponent();
            initComboBox();
        }

        public void initComboBox()
        {
            try
            {
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
                string strDefault = "----------";
                cbCourse.Items.Add(strDefault);
                List<string> list1 = mBLL.getCourseID();
                foreach (string item in list1)
                {
                    cbCourse.Items.Add(item);
                }
                cbCourse.SelectedIndex = 0;

                /*----- ComboBox Semester ------*/
                cbSemester.Items.Clear();
                cbSemester.Items.Add(strDefault);
                List<string> list2 = mBLL.getSemester();
                foreach (string item in list2)
                {
                    cbSemester.Items.Add(item);
                }
                cbSemester.SelectedIndex = 0;
            }
            catch {
                MessageBox.Show("No Data");
                
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            gvStudent.DataSource = mBLL.getStudentList(cbClass.SelectedItem.ToString(), cbCourse.SelectedItem.ToString(), cbSemester.SelectedItem.ToString());
        }
    }
}
