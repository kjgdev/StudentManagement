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
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mBLL = new ManagementBLL();
            //DataTable dataTable = mBLL.getAllListStudent();
            //gvTable.DataSource = dataTable;
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            Import import = new Import();
            import.Show();
            //-----------------
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
            Grade layout = new Grade();
            pnContent.Controls.Add(layout);
            layout.Dock = DockStyle.Fill;
        }
    }
}
