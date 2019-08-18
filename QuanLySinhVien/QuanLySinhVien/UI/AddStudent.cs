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
    public partial class AddStudent : UserControl
    {
        public AddStudent()
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
            try
            {
                cbClass.SelectedIndex = 0;
            }
            catch { MessageBox.Show("No Data"); }
        }


        Student insertStudent()
        {
            Student student = new Student();
            if (tbMSSV.Text == "" || tbName.Text == "" || tbDay.Text == "" || tbMonth.Text == "" || tbYear.Text == "" ||
                tbCMND.Text == "")
            {
                MessageBox.Show("Nhập thiếu");
                new AddStudent();
            }
            else
            {
               
                student.MSSV = tbMSSV.Text;
                student.Name = tbName.Text;
                student.Birthday = new DateTime(int.Parse(tbYear.Text), int.Parse(tbMonth.Text), int.Parse(tbDay.Text));
                if (rbMale.Checked) student.Gender = "Nam";
                else student.Gender = "Nữ";
                student.CMND = tbCMND.Text;
                student.ClassID = cbClass.SelectedItem.ToString();
            }

            return student;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ManagementBLL mBLL = new ManagementBLL();
            mBLL.insertStudent(insertStudent());
        }

    }
}
