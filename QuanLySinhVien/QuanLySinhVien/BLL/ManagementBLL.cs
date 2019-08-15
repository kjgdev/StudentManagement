using QuanLySinhVien.DAL;
using QuanLySinhVien.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySinhVien.BLL
{
  
    class ManagementBLL
    {
        private ManagementDAL mDAL = new ManagementDAL();

        public List<Student> getStudentList(string classID,string courseID,string semester)
        {
            return mDAL.getStudentList(classID,courseID,semester);
        }

        public List<string> getClassID()
        {
            return mDAL.getClassID();
        }

        public List<string> getCourseID()
        {
            return mDAL.getCourseID();
        }

        public List<string> getSemester()
        {
            return mDAL.getSemester();
        }

        public List<Grade> getGradeList(string classID, string semester, string courseID)
        {
            return mDAL.getGradeList(classID, semester, courseID);
        }

        public List<Course> GetSchedule(string classID, string semester)
        {
            return mDAL.GetSchedule(classID,semester);
        }

        public bool insertStudent(List<Student> studentsList)
        {
            return mDAL.insertStudent(studentsList);
        }

        public bool insertStudent(Student student)
        {
            return mDAL.insertStudent(student);
        }

        public bool insertClass(string classID)
        {
            return mDAL.insertClass(classID);
        }

        public bool insertSchedule(List<Course> courseList)
        {
            return mDAL.insertSchedule(courseList);
        }

        public bool insertGrade(List<Grade> gradeList)
        {
            return mDAL.insertGrade(gradeList);
        }


    }
}
