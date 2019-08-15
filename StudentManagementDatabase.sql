CREATE DATABASE StudentManagement

GO
USE StudentManagement

CREATE TABLE Student
(
	STT int IDENTITY,
	MSSV char(7) PRIMARY KEY,
	Name nvarchar(255) NOT NULL,
	Birthday date NOT NULL,
	Gender nvarchar(3) NOT NULL CHECK (Gender = N'Nam' or Gender = N'Nữ'),
	CMND char(9) NOT NULL,
	ClassID char(5) NOT NULL
)

CREATE TABLE Course
(
	STT int IDENTITY,
	ID char(6) PRIMARY KEY,
	Name nvarchar(255) NOT NULL,
	RoomID char(9) NOT NULL,
	ClassID char(5) NOT NULL,
	Semester char(3) NOT NULL CHECK (Semester = 'HK1' or Semester = 'HK2' or Semester = 'HK3'),
	Year char(4)
)

CREATE TABLE Class
(
	STT int IDENTITY,
	ID char(5) PRIMARY KEY,
)

CREATE TABLE Grade
(
	STT int IDENTITY,
	MSSV char(7),
	CourseID char(6),
	Semester char(3),
	DiemGK float,
	DiemCK float,
	DiemKhac float,
	DiemTong float,
	ClassID char(5),
	PRIMARY KEY(MSSV,CourseID,Semester,ClassID)
)

ALTER TABLE Grade
ADD CONSTRAINT FK_GRADE_TO_STUDENT
FOREIGN KEY	(MSSV) REFERENCES Student(MSSV),
CONSTRAINT FK_GRADE_TO_COURSE
FOREIGN KEY (CourseID) REFERENCES Course(ID)

ALTER TABLE Student
ADD CONSTRAINT FK_STUDENT_TO_CLASS
FOREIGN KEY (ClassID) REFERENCES Class(ID)

ALTER TABLE Course
ADD CONSTRAINT FK_COURSE_TO_CLASS
FOREIGN KEY (ClassID) REFERENCES Class(ID)


GO
CREATE PROC sp_addStudent
@MSSV char(7),@Name nvarchar(255),@Birthday date,@Gender nvarchar(3),@CMND char(9),@ClassID char(5)
AS
	IF EXISTS (SELECT * FROM Student WHERE dbo.Student.MSSV = @MSSV)
		THROW 50000,'Duplicate MSSV',1
	ELSE
		INSERT INTO dbo.Student VALUES(@MSSV,@Name,@Birthday,@Gender,@CMND,@ClassID)
GO

CREATE PROC sp_addClass
@ID char(5)
AS
	IF EXISTS (SELECT * FROM Class WHERE ID = @ID)
		THROW 50000,'Duplicate Class ID',1
	ELSE
		INSERT INTO Class VALUES (@ID)
GO

CREATE PROC sp_addSchedule
@ID char(6),@Name nvarchar(255),@RoomID char(9),@Semester char(3),@Year char(4),@ClassID char(5)
AS
	IF EXISTS (SELECT * FROM Course WHERE ID = @ID)
		THROW 50000,'Duplicate Course ID',1
	ELSE
			INSERT INTO Course VALUES (@ID,@Name,@RoomID,@ClassID,@Semester,@Year)
GO

CREATE PROC sp_registrationCourse
@MSSV char(9),@CourseID char(6),@Semester char(3),@ClassID char(5)
AS
	IF EXISTS (SELECT * FROM Grade WHERE @MSSV = MSSV AND @CourseID = CourseID AND @Semester = Semester AND ClassID = @ClassID)
		THROW 50000,'Duplicate registration',1
	ELSE
		INSERT INTO Grade (MSSV,CourseID,Semester,ClassID) VALUES (@MSSV,@CourseID,@Semester,@ClassID)
GO

CREATE PROC sp_addGrade
@MSSV char(7),@CourseID char(6),@Semester char(3),@DiemGK float,@DiemCK float,@DiemKhac float,@DiemTong float,@ClassID char(5)
AS
	IF EXISTS (SELECT * FROM Grade WHERE @MSSV = MSSV AND @CourseID = CourseID AND @Semester = Semester AND @ClassID = ClassID)
		UPDATE Grade SET DiemCK = @DiemCK, DiemGK = @DiemGK, DiemKhac = @DiemKhac,DiemTong = @DiemTong WHERE MSSV = @MSSV AND CourseID = @CourseID AND ClassID = @ClassID AND @Semester = Semester
	ELSE
		INSERT INTO Grade VALUES (@MSSV,@CourseID,@Semester,@DiemGK,@DiemCK,@DiemKhac,@DiemTong,@ClassID)
GO
	

CREATE FUNCTION fn_getStudent(@ClassID char(5))
RETURNS TABLE
AS
	RETURN SELECT MSSV,Name,Birthday,Gender,CMND,ClassID FROM Student WHERE ClassID = @ClassID
GO

CREATE FUNCTION fn_getIDClass()
RETURNS TABLE
AS
	RETURN SELECT ID FROM Class
GO

CREATE FUNCTION fn_getIDCourse()
RETURNS TABLE
AS
	RETURN SELECT ID FROM Course
GO

CREATE FUNCTION fn_getStudentbyCourse(@ClassID char(5),@CourseID char(6),@Semester char(3))
RETURNS TABLE
AS
	RETURN SELECT DISTINCT s.MSSV,s.Name,s.Birthday,s.Gender,s.CMND,s.ClassID FROM Student s, Course c,Grade g WHERE g.ClassID = @ClassID AND g.CourseID = @CourseID AND s.MSSV = g.MSSV AND g.Semester = @Semester
GO

CREATE FUNCTION fn_getSemester()
RETURNS TABLE
AS
	RETURN SELECT DISTINCT Semester FROM Course
GO

CREATE FUNCTION fn_getGrade(@ClassID char(5),@CourseID char(6),@Semester char(3))
RETURNS TABLE
AS
	RETURN SELECT g.MSSV,s.Name,g.DiemGK,g.DiemCK,g.DiemKhac,g.DiemTong FROM Student s, Grade g WHERE g.ClassID = @ClassID AND g.CourseID = @CourseID AND g.Semester = @Semester AND s.MSSV = g.MSSV
GO

CREATE FUNCTION fn_getSchedule(@ClassID char(5),@Semester char(3))
RETURNS TABLE
AS
	RETURN SELECT c.ID,c.Name,c.RoomID FROM Course c WHERE c.ClassID=@ClassID AND c.Semester = @Semester
GO
