using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Entity
{
   public class Grade
    {
        public string MSSV { get; set; }
        public string CourseID { get; set; }
        public string Name { get; set; }
        public string Semester { get; set; }
        public float DiemGK { get; set; }
        public float DiemCK { get; set; }
        public float DiemKhac { get; set; }
        public float DiemTong { get; set; }
        public string ClassID { get; set; }
    }
}
