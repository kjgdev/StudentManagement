using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.Entity
{
   public class Course
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string RoomID { get; set; }
        public string ClassID { get; set; }
        public string Semester { get; set; }
        public string Year { get; set; }
    }
}
