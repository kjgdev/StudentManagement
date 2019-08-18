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
    public partial class ChangePassword : UserControl
    {
        string username;
        public ChangePassword(string user)
        {
            InitializeComponent();
            this.username = user;
            lbUsername.Text = user;
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            if(tbConfirm.Text != tbNewPass.Text)
            {
                MessageBox.Show("Nhập lại mật khẩu sai!");
                new ChangePassword(username);
            }
            ManagementBLL mBLL = new ManagementBLL();
            string oldPass = tbOldPass.Text;
            string newPass = tbNewPass.Text;
            if (!mBLL.updatePass(username, newPass, oldPass))
            {
                new ChangePassword(username);
            }
        }
    }
}
