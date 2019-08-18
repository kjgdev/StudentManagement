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
    public partial class LoginLayout : Form
    {
        public string type { get; set; }
        public string username { get; set; }
        public LoginLayout()
        {
            InitializeComponent();
            MessageBox.Show("Import data trước khi sử dụng các chức năng\n-- Connect sever qua file App.config -- ");
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (processLogin() == "-1")
            {
                DialogResult result = MessageBox.Show("Đăng nhập thất bại", "Sign in", MessageBoxButtons.RetryCancel);
                if (result == DialogResult.Retry) new LoginLayout();
                else if (result == DialogResult.Cancel) Application.Exit();
            }
            else {
                MessageBox.Show("Đăng nhập thành công", "Sign in ");
                type = processLogin();
                username = tbUsername.Text;
                Close();
            }
        }

        string processLogin()
        {
            ManagementBLL mBLL = new ManagementBLL();
            List<LoginData> loginList = mBLL.getLogin();
            foreach (LoginData login in loginList)
            {
                if (login.UsernameL == tbUsername.Text && login.PasswordL == tbPassword.Text) {
                    return login.TypeL;
                   
                };
            }
            return "-1";
        }


    }
}
