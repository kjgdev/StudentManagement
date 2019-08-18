using QuanLySinhVien.BLL;
using QuanLySinhVien.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class Form1 : Form
    {
        private ManagementBLL mBLL;
        string user;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mBLL = new ManagementBLL();
            processLogin();
            pnContent.Controls.Clear();
            ImportData layout = new ImportData();
            pnContent.Controls.Add(layout);
            layout.Dock = DockStyle.Fill;
        }

        void processLogin()
        {
            LoginLayout loginLayout = new LoginLayout();

            loginLayout.ShowDialog();

            string type = loginLayout.type;
            user = loginLayout.username;

            if (type == "0")
            {
                pnControls.Controls.Clear();
                pnControls.Controls.Add(btnLogOut);
                pnControls.Controls.Add(btnChangePass);
                pnControls.Controls.Add(btnImport);
                pnControls.Controls.Add(bntBroadGrade);
                pnControls.Controls.Add(btnTKB);
                pnControls.Controls.Add(btnListCourse);
                pnControls.Controls.Add(bntAddStudent);
                pnControls.Controls.Add(lbLogo);
            }
            else if (type == "1")
            {
                pnControls.Controls.Clear();
                pnControls.Controls.Add(btnLogOut);
                pnControls.Controls.Add(btnChangePass);
                pnControls.Controls.Add(btnGradeStudent);
                pnControls.Controls.Add(lbLogo);
            }
            else Close();
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            //Import import = new Import();
            //import.Show();
            //-----------------
            pnContent.Controls.Clear();
            ImportData layout = new ImportData();
            pnContent.Controls.Add(layout);
            layout.Dock = DockStyle.Fill;

        }

        private void BntAddStudent_Click(object sender, EventArgs e)
        {
            pnContent.Controls.Clear();
            AddStudent layout = new AddStudent();
            pnContent.Controls.Add(layout);
            layout.Dock = DockStyle.Fill;
        }

        private void BtnListCourse_Click(object sender, EventArgs e)
        {
            pnContent.Controls.Clear();
            StudentLayout layout = new StudentLayout();
            pnContent.Controls.Add(layout);
            layout.Dock = DockStyle.Fill;
        }

        private void BtnTKB_Click(object sender, EventArgs e)
        {
            pnContent.Controls.Clear();
            Schedule layout = new Schedule();
            pnContent.Controls.Add(layout);
            layout.Dock = DockStyle.Fill;
        }

        private void BntBroadGrade_Click(object sender, EventArgs e)
        {
            pnContent.Controls.Clear();
            GradeLayout layout = new GradeLayout();
            pnContent.Controls.Add(layout);
            layout.Dock = DockStyle.Fill;
        }

        private void BtnGradeStudent_Click(object sender, EventArgs e)
        {
            pnContent.Controls.Clear();
            GradeStudent layout = new GradeStudent(user);
            pnContent.Controls.Add(layout);
            layout.Dock = DockStyle.Fill;
        }

        private void BtnChangePass_Click(object sender, EventArgs e)
        {
            pnContent.Controls.Clear();
            ChangePassword layout = new ChangePassword(user);
            pnContent.Controls.Add(layout);
            layout.Dock = DockStyle.Fill;
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            pnContent.Controls.Clear();
            new Form1();
            processLogin();
        }
    }
}
