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

        public List<Student> getStudentList(string classID, string courseID, string semester)
        {
            List<Student> studentsList = new List<Student>();
            string strDefault = "----------";
            string sql = "";
            if (courseID == strDefault || semester == strDefault)
                sql = $"SELECT * FROM fn_getStudent(@ClassID);";
            else
                sql = $"SELECT * FROM fn_getStudentbyCourse(@ClassID,@CourseID,@Semester);";

            SqlConnection conc = connection.GetConnection();
            cmd = new SqlCommand(sql, conc);

            try
            {
                conc.Open();
                if (courseID == strDefault || semester == strDefault)
                    cmd.Parameters.Add("@ClassID", SqlDbType.Char).Value = classID;
                else
                {
                    cmd.Parameters.Add("@ClassID", SqlDbType.Char).Value = classID;
                    cmd.Parameters.Add("@CourseID", SqlDbType.Char).Value = courseID;
                    cmd.Parameters.Add("@Semester", SqlDbType.Char).Value = semester;
                }
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        Student student = new Student();
                        student.MSSV = rd.GetString(0);
                        student.Name = rd.GetString(1);
                        student.Birthday = DateTime.Parse(rd.GetDateTime(2).ToString());
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

        public List<Grade> getGradeList(string classID, string semester, string courseID)
        {
            List<Grade> gradeList = new List<Grade>();
            //string sql = $"SELECT * FROM fn_getGrade(\'{classID}\',\'{courseID}\',\'{semester}\');";
            string sql = "SELECT * FROM fn_getGrade(@ClassID,@CourseID,@Semester);";
            SqlConnection conc = connection.GetConnection();
            cmd = new SqlCommand(sql, conc);

            try
            {
                conc.Open();
                cmd.Parameters.Add("@ClassID", SqlDbType.Char).Value = classID;
                cmd.Parameters.Add("@CourseID", SqlDbType.Char).Value = courseID;
                cmd.Parameters.Add("@Semester", SqlDbType.Char).Value = semester;
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

        public List<Course> GetSchedule(string classID, string semester)
        {
            List<Course> courseList = new List<Course>();
            string sql = $"SELECT * FROM fn_getSchedule(@ClassID,@Semester);";
            SqlConnection conc = connection.GetConnection();
            cmd = new SqlCommand(sql, conc);

            try
            {
                conc.Open();
                cmd.Parameters.Add("@ClassID", SqlDbType.Char).Value = classID;
                cmd.Parameters.Add("@Semester", SqlDbType.Char).Value = semester;
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

        public List<LoginData> getLogin()
        {
            List<LoginData> list = new List<LoginData>();
            string sql = "SELECT * FROM fn_getLogin()";

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
                        LoginData login = new LoginData();
                        login.UsernameL = rd.GetString(0);
                        login.UsernameL = login.UsernameL.Trim();
                        login.PasswordL = rd.GetString(1);
                        login.PasswordL = login.PasswordL.Trim();
                        login.TypeL = rd.GetString(2);
                        list.Add(login);
                    }
                }
                conc.Close();
            }
            catch
            {
                conc.Close();
            }
            return list;
        }

        public List<Grade> getGradeStudent(string MSSV, string year, string semester)
        {
            List<Grade> listGrade = new List<Grade>();
            string sql = $"SELECT * FROM fn_getGradeStudent(@MSSV,@Year,@Semester);";
            SqlConnection conc = connection.GetConnection();
            cmd = new SqlCommand(sql, conc);

            try
            {
                conc.Open();
                cmd.Parameters.Add("@MSSV", SqlDbType.Char).Value = MSSV;
                cmd.Parameters.Add("@Year", SqlDbType.Char).Value = year;
                cmd.Parameters.Add("@Semester", SqlDbType.Char).Value = semester;
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        Grade grade = new Grade();
                        grade.CourseID = rd.GetString(0);
                        grade.DiemGK = float.Parse(rd.GetValue(1).ToString());
                        grade.DiemCK = float.Parse(rd.GetValue(2).ToString());
                        grade.DiemKhac = float.Parse(rd.GetValue(3).ToString());
                        grade.DiemTong = float.Parse(rd.GetValue(4).ToString());
                        listGrade.Add(grade);
                    }

                }

                rd.Close();
                conc.Close();
            }
            catch (Exception o)
            {
                //MessageBox.Show(o.Message + " " + MSSV, "Error get grade student");
                conc.Close();
            }
            return listGrade;
        }

        public bool insertStudent(List<Student> studentsList)
        {
            SqlConnection conc = connection.GetConnection();

            foreach (Student item in studentsList)
            {
                string sql = "EXEC sp_addStudent @MSSV,@Name,@Birthday,@Gender,@CMND,@ClassID";
                cmd = new SqlCommand(sql, conc);

                try
                {
                    conc.Open();
                    cmd.Parameters.Add("@MSSV", SqlDbType.Char).Value = item.MSSV;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = item.Name;
                    cmd.Parameters.Add("@Birthday", SqlDbType.Date).Value = item.Birthday;
                    cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = item.Gender;
                    cmd.Parameters.Add("@CMND", SqlDbType.Char).Value = item.CMND;
                    cmd.Parameters.Add("@ClassID", SqlDbType.Char).Value = item.ClassID;
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
            MessageBox.Show("Thành công!");
            return true;
        }

        public bool insertStudent(Student student)
        {
            SqlConnection conc = connection.GetConnection();

            string sql = "EXEC sp_addStudent @MSSV,@Name,@Birthday,@Gender,@CMND,@ClassID";
            cmd = new SqlCommand(sql, conc);

            try
            {
                conc.Open();
                cmd.Parameters.Add("@MSSV", SqlDbType.Char).Value = student.MSSV;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = student.Name;
                cmd.Parameters.Add("@Birthday", SqlDbType.Date).Value = student.Birthday;
                cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = student.Gender;
                cmd.Parameters.Add("@CMND", SqlDbType.Char).Value = student.CMND;
                cmd.Parameters.Add("@ClassID", SqlDbType.Char).Value = student.ClassID;
                cmd.ExecuteNonQuery();
                conc.Close();
            }
            catch (Exception o)
            {
                MessageBox.Show(o.Message + " " + student.MSSV, "Error Insert");
                conc.Close();
                return false;
            }
            MessageBox.Show("Thành công!");
            return true;
        }

        public bool insertClass(string classID)
        {
            SqlConnection conc = connection.GetConnection();

            string sql = "EXEC sp_addClass @ClassID;";
            cmd = new SqlCommand(sql, conc);
            try
            {
                conc.Open();
                cmd.Parameters.Add("@ClassID", SqlDbType.Char).Value = classID;
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
                string sql = "EXEC sp_addSchedule @ID,@Name,@RoomID ,@Semester ,@Year,@ClassID";
                cmd = new SqlCommand(sql, conc);

                try
                {
                    conc.Open();
                    cmd.Parameters.Add("@ID", SqlDbType.Char).Value = item.ID;
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = item.Name;
                    cmd.Parameters.Add("@RoomID", SqlDbType.Char).Value = item.RoomID;
                    cmd.Parameters.Add("@Semester", SqlDbType.Char).Value = item.Semester;
                    cmd.Parameters.Add("@Year", SqlDbType.Char).Value = item.Year;
                    cmd.Parameters.Add("@ClassID", SqlDbType.Char).Value = item.ClassID;
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
            MessageBox.Show("Thành công!");
            return true;
        }

        public bool insertGrade(List<Grade> gradeList)
        {
            SqlConnection conc = connection.GetConnection();

            foreach (Grade item in gradeList)
            {
                string sql = "EXEC sp_addGrade @MSSV ,@CourseID ,@Semester ,@DiemGK ,@DiemCK,@DiemKhac,@DiemTong,@ClassID";
                cmd = new SqlCommand(sql, conc);
                try
                {
                    conc.Open();
                    cmd.Parameters.Add("@MSSV", SqlDbType.Char).Value = item.MSSV;
                    cmd.Parameters.Add("@CourseID", SqlDbType.Char).Value = item.CourseID;
                    cmd.Parameters.Add("@Semester", SqlDbType.Char).Value = item.Semester;
                    cmd.Parameters.Add("@DiemGK", SqlDbType.Float).Value = item.DiemGK;
                    cmd.Parameters.Add("@DiemCK", SqlDbType.Float).Value = item.DiemCK;
                    cmd.Parameters.Add("@DiemKhac", SqlDbType.Float).Value = item.DiemKhac;
                    cmd.Parameters.Add("@DiemTong", SqlDbType.Float).Value = item.DiemTong;
                    cmd.Parameters.Add("@ClassID", SqlDbType.Char).Value = item.ClassID;
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
            MessageBox.Show("Thành công!");
            return true;

        }

        public bool insertLogin(List<LoginData> loginList)
        {
            SqlConnection conc = connection.GetConnection();

            foreach (LoginData item in loginList)
            {
                string sql = "EXEC sp_addLoginL @UsernameL,@PasswordL ,@TypeL";
                cmd = new SqlCommand(sql, conc);
                try
                {
                    conc.Open();
                    cmd.Parameters.Add("@UsernameL", SqlDbType.Char).Value = item.UsernameL;
                    cmd.Parameters.Add("@PasswordL", SqlDbType.Char).Value = item.PasswordL;
                    cmd.Parameters.Add("@TypeL", SqlDbType.Char).Value = item.TypeL;
                    cmd.ExecuteNonQuery();
                    conc.Close();
                }
                catch (Exception o)
                {
                    MessageBox.Show(o.Message + " " + item.UsernameL, "Error Insert Login");
                    conc.Close();
                    //return false;
                }

            }
            MessageBox.Show("Thành công!");
            return true;

        }

        public bool updatePass(string user, string pass, string oldPass)
        {
            SqlConnection conc = connection.GetConnection();

            string sql = "EXEC sp_updatePas @Username,@NewPass,@OldPass";
            cmd = new SqlCommand(sql, conc);
            try
            {
                conc.Open();
                cmd.Parameters.Add("@Username", SqlDbType.Char).Value = user;
                cmd.Parameters.Add("@NewPass", SqlDbType.Char).Value = pass;
                cmd.Parameters.Add("@OldPass", SqlDbType.Char).Value = oldPass;
                cmd.ExecuteNonQuery();
                conc.Close();
            }
            catch (Exception o)
            {
                MessageBox.Show(o.Message + " " + user, "Sai mật khẩu");
                conc.Close();
                return false;
            }
            MessageBox.Show("Thành công!");
            return true;
        }

        public bool updateGrade(Grade grade)
        {
            SqlConnection conc = connection.GetConnection();

            Grade item = grade;
            string sql = "EXEC sp_addGrade @MSSV ,@CourseID ,@Semester ,@DiemGK ,@DiemCK,@DiemKhac,@DiemTong,@ClassID";
            cmd = new SqlCommand(sql, conc);
            try
            {
                conc.Open();
                cmd.Parameters.Add("@MSSV", SqlDbType.Char).Value = item.MSSV;
                cmd.Parameters.Add("@CourseID", SqlDbType.Char).Value = item.CourseID;
                cmd.Parameters.Add("@Semester", SqlDbType.Char).Value = item.Semester;
                cmd.Parameters.Add("@DiemGK", SqlDbType.Float).Value = item.DiemGK;
                cmd.Parameters.Add("@DiemCK", SqlDbType.Float).Value = item.DiemCK;
                cmd.Parameters.Add("@DiemKhac", SqlDbType.Float).Value = item.DiemKhac;
                cmd.Parameters.Add("@DiemTong", SqlDbType.Float).Value = item.DiemTong;
                cmd.Parameters.Add("@ClassID", SqlDbType.Char).Value = item.ClassID;
                cmd.ExecuteNonQuery();
                conc.Close();
            }
            catch (Exception o)
            {
                MessageBox.Show(o.Message + " " + item.MSSV, "Lỗi edit");
                conc.Close();
                return false;
            }

            MessageBox.Show("Thành công!");
            return true;
        }
    }
}
