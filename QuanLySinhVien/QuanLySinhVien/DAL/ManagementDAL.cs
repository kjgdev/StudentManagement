using QuanLySinhVien.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLySinhVien.DAL
{
    class ManagementDAL
    {
        DataConnection connection;
        SqlDataAdapter adapter;
        SqlCommand cmd;

        public ManagementDAL()
        {
            connection = new DataConnection();
        }

        public List<string> getClassID()
        {
            List<string> classList = new List<string>();
            string sql = "SELECT * FROM fn_getIDClass();";
            SqlConnection conc = connection.GetConnection();
            cmd = new SqlCommand(sql, conc);

            try
            {
                conc.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        String id = rd.GetString(0);
                        classList.Add(id);
                    }

                }

                rd.Close();
                conc.Close();
            }
            catch { conc.Close(); }
            return classList;
        }

        public List<string> getCourseID()
        {
            List<string> courseIDList = new List<string>();
            string sql = "SELECT * FROM fn_getIDCourse();";
            SqlConnection conc = connection.GetConnection();
            cmd = new SqlCommand(sql, conc);

            try
            {
                conc.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        String id = rd.GetString(0);
                        id = id.Trim();
                        courseIDList.Add(id);
                    }

                }

                rd.Close();
                conc.Close();
            }
            catch { conc.Close(); }
            return courseIDList;
        }

        public List<string> getSemester()
        {
            List<string> semesterList = new List<string>();
            string sql = "SELECT * FROM fn_getSemester();";
            SqlConnection conc = connection.GetConnection();
            cmd = new SqlCommand(sql, conc);

            try
            {
                conc.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        String id = rd.GetString(0);
                        id = id.Trim();
                        semesterList.Add(id);
                    }

                }

                rd.Close();
                conc.Close();
            }
            catch { conc.Close(); }
            return semesterList;
        }

        public List<Student> getStudentList(string classID, string courseID,string semester)
        {
            List<Student> studentsList = new List<Student>();
            string strDefault = "----------";
            string sql = "";
            if (courseID == strDefault || semester == strDefault)
                sql = $"SELECT * FROM fn_getStudent(\'{classID}\');";
            else
                sql = $"SELECT * FROM fn_getStudentbyCourse(\'{classID}\',\'{courseID}\',\'{semester}\');";
           
            SqlConnection conc = connection.GetConnection();
            cmd = new SqlCommand(sql, conc);

            try
            {
                conc.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        Student student = new Student();
                        student.MSSV = rd.GetString(0);
                        student.Name = rd.GetString(1);
                        student.Birthday = rd.GetDateTime(2).ToString();
                        student.Gender = rd.GetString(3);
                        student.CMND = rd.GetString(4);
                        student.ClassID = rd.GetString(5);
                        studentsList.Add(student);
                    }

                }

                rd.Close();
                conc.Close();
            }
            catch { conc.Close(); }
            return studentsList;
        }

        public List<Grade> getGradeList(string classID, string semester,string courseID)
        {
            List<Grade> gradeList = new List<Grade>();
            string sql = $"SELECT * FROM fn_getGrade(\'{classID}\',\'{courseID}\',\'{semester}\');";
            SqlConnection conc = connection.GetConnection();
            cmd = new SqlCommand(sql, conc);

            try
            {
                conc.Open();
                SqlDataReader rd = cmd.ExecuteReader(); 
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        Grade grade = new Grade();
                        grade.MSSV = rd.GetString(0);
                        grade.Name = rd.GetString(1);
                        grade.DiemGK = float.Parse(rd.GetValue(2).ToString());
                        grade.DiemCK = float.Parse(rd.GetValue(3).ToString());
                        grade.DiemKhac = float.Parse(rd.GetValue(4).ToString());
                        grade.DiemTong = float.Parse(rd.GetValue(5).ToString());
                        gradeList.Add(grade);
                    }

                }

                rd.Close();
                conc.Close();
            }
            catch { conc.Close(); }
            return gradeList;
        }

        public List<Course> GetSchedule(string classID,string semester)
        {
            List<Course> courseList = new List<Course>();
            string sql = $"SELECT * FROM fn_getSchedule(\'{classID}\',\'{semester}\');";
            SqlConnection conc = connection.GetConnection();
            cmd = new SqlCommand(sql, conc);

            try
            {
                conc.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        Course course = new Course();
                        course.ID = rd.GetString(0);
                        course.Name = rd.GetString(1);
                        course.RoomID = rd.GetString(2);
                        courseList.Add(course);
                    }

                }

                rd.Close();
                conc.Close();
            }
            catch { conc.Close(); }
            return courseList;
        }

        public bool insertStudent(List<Student> studentsList)
        {
            SqlConnection conc = connection.GetConnection();

            foreach (Student item in studentsList)
            {
                string sql = "EXEC sp_addStudent \'" + item.MSSV + "\',N\'" + item.Name + "\',\'" + item.Birthday + "\',N\'" + item.Gender +
                    "\',\'" + item.CMND + "\',\'" + item.ClassID + "\';";
                cmd = new SqlCommand(sql, conc);

                try
                {
                    conc.Open();
                    cmd.ExecuteNonQuery();
                    conc.Close();
                }
                catch (Exception o)
                {
                    MessageBox.Show(o.Message + " " + item.MSSV, "Error Insert");
                    conc.Close();
                    return false;
                }
            }
            return true;
        }

        public bool insertStudent(Student student)
        {
            SqlConnection conc = connection.GetConnection();

            string sql = "EXEC sp_addStudent \'" + student.MSSV + "\',N\'" + student.Name + "\',\'" + student.Birthday + "\',N\'" + student.Gender +
                "\',\'" + student.CMND + "\',\'" + student.ClassID + "\';";
            cmd = new SqlCommand(sql, conc);

            try
            {
                conc.Open();
                cmd.ExecuteNonQuery();
                conc.Close();
            }
            catch (Exception o)
            {
                MessageBox.Show(o.Message + " " + student.MSSV, "Error Insert");
                conc.Close();
                return false;
            }
            return true;
        }

        public bool insertClass(string classID)
        {
            SqlConnection conc = connection.GetConnection();

            string sql = "EXEC sp_addClass \'" + classID + "\';";
            cmd = new SqlCommand(sql, conc);
            try
            {
                conc.Open();
                cmd.ExecuteNonQuery();
                conc.Close();
            }
            catch (Exception o)
            {
                //MessageBox.Show(o.ToString() + classID);
                conc.Close();
                return false;
            }
            return true;
        }

        public bool insertSchedule(List<Course> courseList)
        {
            SqlConnection conc = connection.GetConnection();

            foreach (Course item in courseList)
            {
                string sql = "EXEC sp_addSchedule \'" + item.ID + "\',N\'" + item.Name + "\',\'" + item.RoomID + "\',\'" + item.Semester +
                    "\',\'" + item.Year + "\',\'" + item.ClassID + "\';";
                cmd = new SqlCommand(sql, conc);

                try
                {
                    conc.Open();
                    cmd.ExecuteNonQuery();
                    conc.Close();
                }
                catch (Exception o)
                {
                    MessageBox.Show(o.Message + " " + item.ID, "Error Insert");
                    conc.Close();
                    return false;
                }
            }
            foreach (Course item in courseList)
            {
                List<Student> studentList = getStudentList(item.ClassID, "----------", "----------");
                foreach (Student student in studentList)
                {
                    string sql = "EXEC sp_registrationCourse \'" + student.MSSV + "\',\'" + item.ID + "\',\'" + item.Semester + "\',\'" + item.ClassID + "\';";
                    cmd = new SqlCommand(sql, conc);

                    try
                    {
                        conc.Open();
                        cmd.ExecuteNonQuery();
                        conc.Close();
                    }
                    catch (Exception o)
                    {
                        MessageBox.Show(o.Message + " " + item.ID, "Error Insert");
                        conc.Close();
                        return false;
                    }
                }
            }
            return true;
        }

        public bool insertGrade(List<Grade> gradeList)
        {
            SqlConnection conc = connection.GetConnection();

            foreach (Grade item in gradeList)
            {
                string sql = "EXEC sp_addGrade \'" + item.MSSV + "\',N\'" + item.CourseID + "\',\'" + item.Semester + "\'," + item.DiemGK +
                   "," + item.DiemCK + "," + item.DiemKhac + "," + item.DiemTong + ",\'" + item.ClassID + "\';";
                cmd = new SqlCommand(sql, conc);
                try
                {
                    conc.Open();
                    cmd.ExecuteNonQuery();
                    conc.Close();
                }
                catch (Exception o)
                {
                    MessageBox.Show(o.Message + " " + item.MSSV, "Error Insert");
                    conc.Close();
                    return false;
                }
            }
            return true;

        }
    }
}
