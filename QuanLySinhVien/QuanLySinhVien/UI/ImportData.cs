using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLySinhVien.Entity;
using QuanLySinhVien.BLL;
using System.IO;

namespace QuanLySinhVien.UI
{
    public partial class ImportData : UserControl
    {
        public ImportData()
        {
            InitializeComponent();
        }

        string getFile()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Text files (*.csv)|*.csv|All files (*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                return fileDialog.FileName;
            }
            return null;
        }

        void importDataStudent(string path)
        {
            List<Student> studentList = new List<Student>();
            List<LoginData> loginList = new List<LoginData>();
            string classID = "";
            int rows = 0;
            try
            {
                var reader = new StreamReader(@path);
                while (!reader.EndOfStream)
                {
                    Student student = new Student();
                    LoginData login = new LoginData();
                    var line = reader.ReadLine();
                    var value = line.Split(',');
                    if (rows == 0) { classID = value[0]; }
                    else if (rows > 1)
                    {
                        student.MSSV = value[1];
                        student.Name = value[2];
                        student.Birthday = DateTime.Parse(value[3]);
                        student.Gender = value[4];
                        student.CMND = value[5];
                        student.ClassID = classID;

                        login.UsernameL = student.MSSV;
                        login.TypeL = "1";
                        string str = value[3];
                        var temp = str.Split('/');
                        //login.Password =
                        foreach (string s in temp) login.PasswordL += s;
                        loginList.Add(login);

                        studentList.Add(student);
                    }
                    rows++;
                }
                ManagementBLL mBLL = new ManagementBLL();

                mBLL.insertClass(studentList[0].ClassID);
                mBLL.insertStudent(studentList);
                mBLL.insertLogin(loginList);
            }
            catch { }
        }

        void importDataSchedule(string path)
        {
            List<Course> courseList = new List<Course>();

            string namefile = path.Substring(path.LastIndexOf("\\") + 1);
            var str = namefile.Split('-');

            var reader = new StreamReader(@path);
            int rows = 0;
            try
            {
                while (!reader.EndOfStream)
                {
                    Course course = new Course();
                    var line = reader.ReadLine();
                    var value = line.Split(',');
                    if (rows > 1)
                    {
                        course.ID = value[1];
                        course.Name = value[2];
                        course.RoomID = value[3];
                        course.Year = str[1];
                        course.ClassID = str[2];
                        course.Semester = str[0];

                        courseList.Add(course);
                    }
                    rows++;
                }

                ManagementBLL mBLL = new ManagementBLL();
                mBLL.insertClass(courseList[0].ClassID);
                mBLL.insertSchedule(courseList);
            }
            catch { }
        }

        void importDataGrade(string path)
        {
            List<Entity.Grade> gradeList = new List<Entity.Grade>();

            string namefile = path.Substring(path.LastIndexOf("\\") + 1);
            var str = namefile.Split('-');

            var reader = new StreamReader(@path);
            int rows = 0;
            try
            {
                while (!reader.EndOfStream)
                {
                    Entity.Grade grade = new Entity.Grade();
                    var line = reader.ReadLine();
                    var value = line.Split(',');
                    if (rows > 1)
                    {
                        grade.MSSV = value[1];
                        grade.CourseID = str[1];
                        grade.DiemGK = float.Parse(value[3]);
                        grade.DiemCK = float.Parse(value[4]);
                        grade.DiemKhac = float.Parse(value[5]);
                        grade.DiemTong = float.Parse(value[6]);
                        grade.Semester = str[0];
                        grade.ClassID = str[2];

                        gradeList.Add(grade);
                    }
                    rows++;
                }
                ManagementBLL mBLL = new ManagementBLL();
                mBLL.insertGrade(gradeList);
            }
            catch
            {

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            importDataStudent(getFile());
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            importDataSchedule(getFile());
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            importDataGrade(getFile());
        }
    }
}
