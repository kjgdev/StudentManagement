using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.DAL
{
    class DataConnection
    {
        private string strConnect = "Data Source=DESKTOP-UCR1V5D;Database=StudentManagement;User ID=sa;password=123456";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(strConnect);
        }
    }
}
