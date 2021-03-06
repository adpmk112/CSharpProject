USE [master]
GO
/****** Object:  Database [HMS]    Script Date: 1/22/2021 9:28:32 PM ******/
CREATE DATABASE [HMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HMS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\HMS.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'HMS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\HMS_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HMS] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [HMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HMS] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [HMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HMS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HMS] SET RECOVERY FULL 
GO
ALTER DATABASE [HMS] SET  MULTI_USER 
GO
ALTER DATABASE [HMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HMS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [HMS]
GO
/****** Object:  StoredProcedure [dbo].[SP_Insert_Booking]    Script Date: 1/22/2021 9:28:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_Insert_Booking]
@BookingID		int				=0,
@BookingDate	nvarchar(10)	='',
@PatientID		int				=0,
@UserID			int				=0,
@action			int				=0

As
Begin

If @action=0
	Insert into Booking Values(@BookingDate,@PatientID,@UserID)
If	@action=1
	Update Booking Set BookingDate=@BookingDate,PatientID=@PatientID,UserID=@UserID where BookingID=@BookingID
If @action=2
	Delete From Booking Where BookingID=@BookingID
End
GO
/****** Object:  StoredProcedure [dbo].[SP_Insert_BookingDetail]    Script Date: 1/22/2021 9:28:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_Insert_BookingDetail]
@BookingID			int				=0,
@ScheduleID			int				=0,
@action			int				=0

As
Begin

If @action=0
	Insert Into BookingDetail Values(@BookingID,@ScheduleID)

If @action=1
	Update BookingDetail Set BookingID=@BookingID,ScheduleID=@ScheduleID
	 Where BookingID=@BookingID and ScheduleID=@ScheduleID

If @action=2	
	Delete From BookingDetail Where BookingID=@BookingID
End

GO
/****** Object:  StoredProcedure [dbo].[SP_Insert_Doctor]    Script Date: 1/22/2021 9:28:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_Insert_Doctor]

@DoctorID			int				=0,
@DoctorName			nvarchar(20)         	='',
@Gender		       nvarchar(8)		       ='',
@Age				int				=0,
@Phone				nvarchar(30)	              ='',
@Email				nvarchar(20)	              ='',
@Fees				int				=0,
@SpecialistID		       int				=0,
@action			int				=0	

As
Begin	
if @action=0
	Insert into Doctor Values (@DoctorName,@Gender,@Age,@Phone,@Email,@Fees,@SpecialistID)
if @action=1
	Update Doctor Set DoctorName=@DoctorName,Gender=@Gender,Age=@Age,Phone=@Phone,Email=@Email,
	Fees=@Fees,SpecialistID=@SpecialistID where DoctorID=@DoctorID
if @action=2
	Delete From Doctor Where DoctorID=@DoctorID
End
GO
/****** Object:  StoredProcedure [dbo].[SP_Insert_Patient]    Script Date: 1/22/2021 9:28:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_Insert_Patient]


@PatientID			int					=0,
@PatientName		nvarchar(20)		='',
@Age				int					=0,
@Gender				nvarchar(8)			='',
@Disease			nvarchar(50)		='',
@Phone				nvarchar(50)		=0,
@Address			nvarchar(100)		='',
@Date				nvarchar(10)		='',
@action				int					=0

As
Begin

If @action=0
	Insert Into Patient Values(@PatientName,@Age,@Gender,@Disease,@Phone,@Address,@Date)
If @action=1
	Update Patient Set PatientName=@PatientName,Age=@Age,Gender=@Gender,Disease=@Disease,Phone=@Phone,
	Address=@Address,Date=@Date where PatientID=@PatientID
If @action=2
	Delete From Patient Where PatientID=@PatientID
End
GO
/****** Object:  StoredProcedure [dbo].[SP_Insert_Schedule]    Script Date: 1/22/2021 9:28:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_Insert_Schedule]

@ScheduleID				int				=0,
@StartTime				nvarchar(15)	='',
@EndTime				nvarchar(15)	='',
@Day					nvarchar(20)	='',
@AcceptedPatient		int				=0,
@DoctorID				int				=0,
@action					int				=0

As
Begin

If @action=0
	Insert Into Schedule Values(@StartTime,@EndTime,@Day,@AcceptedPatient,@DoctorID)
If @action=1
	Update Schedule Set StartTime=@StartTime,EndTime=@EndTime,Day=@Day,AcceptedPatient=@AcceptedPatient,DoctorID=@DoctorID 
	where ScheduleID=@ScheduleID
If @action=2
	Delete From Schedule Where ScheduleID=@ScheduleID
End
GO
/****** Object:  StoredProcedure [dbo].[SP_Insert_Specialist]    Script Date: 1/22/2021 9:28:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_Insert_Specialist]

@SpecialistID			int				=0,
@SpecialistType		nvarchar(20)			='',
@action			int				=0

As
Begin

If @action=0
	Insert Into Specialist Values (@SpecialistType)
If @action=1
	Update Specialist Set SpecialistType=@SpecialistType where SpecialistID=@SpecialistID
If @action=2
	Delete From Specialist Where SpecialistID=@SpecialistID
End

GO
/****** Object:  StoredProcedure [dbo].[SP_Insert_UserSetting]    Script Date: 1/22/2021 9:28:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_Insert_UserSetting]

@UserID				int					=0,
@UserName			nvarchar(20)		='',
@Password			nvarchar(15)		='',
@ConfirmPassword	nvarchar(15)		='',
@ContactNo			nvarchar(15)		='',
@Email              nvarchar(50)       ='',
@action				int					=0

As
Begin

if @action=0
	Insert Into UserSetting Values(@UserName,@Password,@ConfirmPassword,@ContactNo,@Email)
if @action=1
	Delete From UserSetting Where UserID=@UserID
End
GO
/****** Object:  StoredProcedure [dbo].[SP_Select_Booking]    Script Date: 1/22/2021 9:28:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_Select_Booking]
@para1		nvarchar(100)		='',
@para2		nvarchar(100)		='',
@action		int					=0

As
Begin

If @action=0
	Select * from Booking 
if @action=1
	Select DATEDIFF(D,GetDate(),@para1)As Date
if @action=2
	Select * from Booking where BookingDate=@para1 and PatientID=@para2
End

GO
/****** Object:  StoredProcedure [dbo].[SP_Select_BookingDetail]    Script Date: 1/22/2021 9:28:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_Select_BookingDetail]
@para1		nvarchar(100)		='',
@para2		nvarchar(100)		='',
@action		int					=0

As
Begin

If @action=0
	Select * from BookingDetail Where BookingID=@para1 and ScheduleID=@para2

IF @action=1
	Select ROW_NUMBER()Over(Order By CASE
          WHEN Day = 'Sunday' THEN 1
          WHEN Day = 'Monday' THEN 2
          WHEN Day = 'Tuesday' THEN 3
          WHEN Day = 'Wednesday' THEN 4
          WHEN Day = 'Thursday' THEN 5
          WHEN Day = 'Friday' THEN 6
          WHEN Day = 'Saturday' THEN 7
     END ASC,[Start Time] ASC,[End Time] ASC) As No, * from vi_BookingDetail Order By CASE
          WHEN Day = 'Sunday' THEN 1
          WHEN Day = 'Monday' THEN 2
          WHEN Day = 'Tuesday' THEN 3
          WHEN Day = 'Wednesday' THEN 4
          WHEN Day = 'Thursday' THEN 5
          WHEN Day = 'Friday' THEN 6
          WHEN Day = 'Saturday' THEN 7
     END ASC,[Start Time] ASC,[End Time] ASC 

If @action=2
	Select * from vi_Schedule_PL

If @action=3
	Select * from vi_Schedule_PL where ScheduleID=@para1

if @action=4
	Select * from vi_BookingPatient 

if @action=5
	Select * from vi_BookingPatient where BookingID=@para1


End
GO
/****** Object:  StoredProcedure [dbo].[SP_Select_Doctor]    Script Date: 1/22/2021 9:28:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_Select_Doctor]
@para1		nvarchar(100)  	='',
@para2		nvarchar(100)   ='',
@para3		nvarchar(100)   ='',
@action       int			 =0

As
Begin

If @action=0
	Select ROW_NUMBER()Over(Order By DoctorName) As No, * from vi_Doctor Order By DoctorName

if @action=1
	Select ROW_NUMBER()Over(Order By DoctorName) As No, * from vi_Doctor where DoctorName Like @para1+'%'  Order By DoctorName

if @action=2
	Select ROW_NUMBER()Over(Order By DoctorName) As No, * from vi_Doctor where SpecialistType Like @para1+'%'  Order By DoctorName

if @action=3
	Select * from Doctor where DoctorName=@para1 And Age=@para2 And SpecialistID=@para3

if @action=4
	Select ROW_NUMBER()Over(Order By DoctorName) As No, * from Doctor Order By DoctorName

End
GO
/****** Object:  StoredProcedure [dbo].[SP_Select_Patient]    Script Date: 1/22/2021 9:28:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_Select_Patient]


@para1		nvarchar(50)	='',
@para2		nvarchar(30)	='',
@para3		nvarchar(100)	='',
@action		int				=0

As
Begin

If @action=0	
	Select * From Patient Order By Date DESC
If @action=1
	Select * From Patient Where PatientName=@para1 And Phone=@para2 And Address=@para3 
If @action=2
	Select MAX(PatientID) As PatientID From Patient 
If @action=3
	Select ROW_NUMBER()Over(ORDER BY CONVERT(DateTime, Date,101) DESC) As No,* From Patient 
	ORDER BY CONVERT(DateTime, Date,101)  DESC
If @action=4
	Select ROW_NUMBER()Over(ORDER BY CONVERT(DateTime, Date,101) DESC) As No,
	* From Patient Where Date Like @para1 +'%' Order By Date DESC
If @action=5
	Select ROW_NUMBER()Over(ORDER BY CONVERT(DateTime, Date,101) DESC) As No,
	* From Patient Where PatientName Like @para1 +'%' Order By Date DESC
If @action=6
	Select PatientID As PatientID From Patient Where PatientID=@para1
End
GO
/****** Object:  StoredProcedure [dbo].[SP_Select_Schedule]    Script Date: 1/22/2021 9:28:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_Select_Schedule]
@para1		nvarchar(100)	='',
@para2		nvarchar(100)	='',
@para3		nvarchar(100)	='',
@para4		nvarchar(100)   ='',
@action		int				=0

As
Begin

If @action=0
	Select * from Schedule Where ScheduleID=@para1
If @action=1
	Select MAX(ScheduleID) AS ScheduleID From Schedule
If @action=2
	Select ROW_NUMBER()Over(ORDER BY 
     CASE
          WHEN Day = 'Sunday' THEN 1
          WHEN Day = 'Monday' THEN 2
          WHEN Day = 'Tuesday' THEN 3
          WHEN Day = 'Wednesday' THEN 4
          WHEN Day = 'Thursday' THEN 5
          WHEN Day = 'Friday' THEN 6
          WHEN Day = 'Saturday' THEN 7
     END ASC, StartTime ASC,EndTime ASC) As No,
	* From vi_Schedule ORDER BY CASE
          WHEN Day = 'Sunday' THEN 1
          WHEN Day = 'Monday' THEN 2
          WHEN Day = 'Tuesday' THEN 3
          WHEN Day = 'Wednesday' THEN 4
          WHEN Day = 'Thursday' THEN 5
          WHEN Day = 'Friday' THEN 6
          WHEN Day = 'Saturday' THEN 7
     END ASC, StartTime ASC ,EndTime ASC
IF @action=3
	Select v.* From vi_Schedule v,Schedule s Where v.Day=@para1 And v.DoctorID=@para2 
	And s.StartTime<=@para3 and s.EndTime>=@para4 
IF @action=4
	Select ScheduleID As ScheduleID From vi_Schedule Where ScheduleID=@para1
If @action=5
	Select ROW_NUMBER()Over(ORDER BY 
     CASE
          WHEN Day = 'Sunday' THEN 1
          WHEN Day = 'Monday' THEN 2
          WHEN Day = 'Tuesday' THEN 3
          WHEN Day = 'Wednesday' THEN 4
          WHEN Day = 'Thursday' THEN 5
          WHEN Day = 'Friday' THEN 6
          WHEN Day = 'Saturday' THEN 7
     END ASC, StartTime ASC,EndTime ASC) As No,* from vi_Schedule where SpecialistType Like @para1+'%'  Order By DoctorName 
End
GO
/****** Object:  StoredProcedure [dbo].[SP_Select_Specialist]    Script Date: 1/22/2021 9:28:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_Select_Specialist]
@para1		nvarchar(100)	='',
@para2		nvarchar(100)	='',
@action		int				=0

As
Begin

If @action=0
	Select ROW_NUMBER()Over(Order By SpecialistID)As No,*From Specialist Order By SpecialistID
If @action=1
	Select *From Specialist Where SpecialistType=@para1
If @action=2
	Select *From Specialist
End
GO
/****** Object:  StoredProcedure [dbo].[SP_Select_UserSetting]    Script Date: 1/22/2021 9:28:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[SP_Select_UserSetting]
@para1      nvarchar(100)   ='',
@para2      nvarchar(100)   ='',
@para3      nvarchar(100)   ='',
@para4      nvarchar(100)   ='',
@action     int             =0
As
Begin
If @action=0
    Select * From UserSetting 
If @action=1
    Select * From UserSetting Where UserName=@para1 And Password=@para2 And ContactNo=@para3  And Email=@para4
If @action=2
	Select * From UserSetting Where UserName=@para1 And Password=@para2
If @action=3
	Select UserName From UserSetting Where UserID=@para1
End

GO
/****** Object:  Table [dbo].[Booking]    Script Date: 1/22/2021 9:28:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[BookingID] [int] IDENTITY(1,1) NOT NULL,
	[BookingDate] [nvarchar](10) NULL,
	[PatientID] [int] NULL,
	[UserID] [int] NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[BookingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BookingDetail]    Script Date: 1/22/2021 9:28:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingDetail](
	[BookingID] [int] NOT NULL,
	[ScheduleID] [int] NOT NULL,
 CONSTRAINT [PK_BookingDetail] PRIMARY KEY CLUSTERED 
(
	[BookingID] ASC,
	[ScheduleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Doctor]    Script Date: 1/22/2021 9:28:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctor](
	[DoctorID] [int] IDENTITY(1,1) NOT NULL,
	[DoctorName] [nvarchar](20) NULL,
	[Gender] [nvarchar](8) NULL,
	[Age] [int] NULL,
	[Phone] [nvarchar](15) NULL,
	[Email] [nvarchar](20) NULL,
	[Fees] [int] NULL,
	[SpecialistID] [int] NULL,
 CONSTRAINT [PK_Doctor] PRIMARY KEY CLUSTERED 
(
	[DoctorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Patient]    Script Date: 1/22/2021 9:28:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[PatientID] [int] IDENTITY(1,1) NOT NULL,
	[PatientName] [nvarchar](20) NULL,
	[Age] [int] NULL,
	[Gender] [nvarchar](8) NULL,
	[Disease] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Address] [nvarchar](100) NULL,
	[Date] [nvarchar](10) NULL,
 CONSTRAINT [PK_Patient] PRIMARY KEY CLUSTERED 
(
	[PatientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Schedule]    Script Date: 1/22/2021 9:28:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schedule](
	[ScheduleID] [int] IDENTITY(1,1) NOT NULL,
	[StartTime] [nvarchar](15) NULL,
	[EndTime] [nvarchar](15) NULL,
	[Day] [nvarchar](20) NULL,
	[AcceptedPatient] [int] NULL,
	[DoctorID] [int] NULL,
 CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED 
(
	[ScheduleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Specialist]    Script Date: 1/22/2021 9:28:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Specialist](
	[SpecialistID] [int] IDENTITY(1,1) NOT NULL,
	[SpecialistType] [nvarchar](20) NULL,
 CONSTRAINT [PK_Specialist] PRIMARY KEY CLUSTERED 
(
	[SpecialistID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserSetting]    Script Date: 1/22/2021 9:28:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSetting](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](20) NULL,
	[Password] [nvarchar](15) NULL,
	[ConfirmPassword] [nvarchar](15) NULL,
	[ContactNo] [nvarchar](15) NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_UserSetting] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[vi_BookingDetail]    Script Date: 1/22/2021 9:28:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vi_BookingDetail]
AS
SELECT        dbo.BookingDetail.BookingID AS [Booking ID], dbo.Doctor.DoctorName AS [Doctor Name], dbo.Doctor.Phone AS [Contact No], dbo.Specialist.SpecialistType AS [Specialist Type], 
                         dbo.Patient.PatientName AS [Patient Name], dbo.Patient.Disease, dbo.Patient.Phone AS [Patient Contact], dbo.Schedule.Day, dbo.Schedule.StartTime AS [Start Time], dbo.Schedule.EndTime AS [End Time], 
                         dbo.BookingDetail.ScheduleID
FROM            dbo.BookingDetail INNER JOIN
                         dbo.Booking ON dbo.BookingDetail.BookingID = dbo.Booking.BookingID INNER JOIN
                         dbo.Schedule ON dbo.BookingDetail.ScheduleID = dbo.Schedule.ScheduleID INNER JOIN
                         dbo.Patient ON dbo.Booking.PatientID = dbo.Patient.PatientID INNER JOIN
                         dbo.Doctor ON dbo.Schedule.DoctorID = dbo.Doctor.DoctorID INNER JOIN
                         dbo.Specialist ON dbo.Doctor.SpecialistID = dbo.Specialist.SpecialistID

GO
/****** Object:  View [dbo].[vi_BookingPatient]    Script Date: 1/22/2021 9:28:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vi_BookingPatient]
AS
SELECT        dbo.Booking.BookingID, dbo.Patient.PatientName, dbo.Patient.Disease, dbo.Booking.PatientID
FROM            dbo.Booking INNER JOIN
                         dbo.Patient ON dbo.Booking.PatientID = dbo.Patient.PatientID

GO
/****** Object:  View [dbo].[vi_Doctor]    Script Date: 1/22/2021 9:28:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vi_Doctor]
AS
SELECT        dbo.Doctor.DoctorID, dbo.Doctor.DoctorName, dbo.Doctor.Gender, dbo.Doctor.Age, dbo.Doctor.Phone, dbo.Doctor.Email, dbo.Doctor.Fees, dbo.Doctor.SpecialistID, dbo.Specialist.SpecialistType
FROM            dbo.Doctor INNER JOIN
                         dbo.Specialist ON dbo.Doctor.SpecialistID = dbo.Specialist.SpecialistID

GO
/****** Object:  View [dbo].[vi_Schedule]    Script Date: 1/22/2021 9:28:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vi_Schedule]
AS
SELECT        dbo.Schedule.ScheduleID, dbo.Schedule.Day, dbo.Schedule.StartTime, dbo.Schedule.EndTime, dbo.Schedule.DoctorID, dbo.Doctor.DoctorName, dbo.Specialist.SpecialistType, 
                         dbo.Schedule.AcceptedPatient
FROM            dbo.Schedule INNER JOIN
                         dbo.Doctor ON dbo.Schedule.DoctorID = dbo.Doctor.DoctorID INNER JOIN
                         dbo.Specialist ON dbo.Doctor.SpecialistID = dbo.Specialist.SpecialistID

GO
/****** Object:  View [dbo].[vi_Schedule_PL]    Script Date: 1/22/2021 9:28:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vi_Schedule_PL]
AS
SELECT        dbo.Schedule.ScheduleID, dbo.Doctor.DoctorName, dbo.Specialist.SpecialistType, dbo.Doctor.DoctorID AS [Doctor ID], dbo.Doctor.SpecialistID
FROM            dbo.Schedule INNER JOIN
                         dbo.Doctor ON dbo.Schedule.DoctorID = dbo.Doctor.DoctorID INNER JOIN
                         dbo.Specialist ON dbo.Doctor.SpecialistID = dbo.Specialist.SpecialistID

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "BookingDetail"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 102
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Booking"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Schedule"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 136
               Right = 630
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "Patient"
            Begin Extent = 
               Top = 6
               Left = 668
               Bottom = 136
               Right = 838
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "Doctor"
            Begin Extent = 
               Top = 102
               Left = 38
               Bottom = 232
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "Specialist"
            Begin Extent = 
               Top = 138
               Left = 246
               Bottom = 234
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vi_BookingDetail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'Alias = 1560
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vi_BookingDetail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vi_BookingDetail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Booking"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Patient"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vi_BookingPatient'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vi_BookingPatient'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[42] 2[5] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Doctor_1"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 4
         End
         Begin Table = "Specialist"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 102
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vi_Doctor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vi_Doctor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[21] 2[14] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Schedule"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 214
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "Doctor"
            Begin Extent = 
               Top = 6
               Left = 252
               Bottom = 136
               Right = 422
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Specialist"
            Begin Extent = 
               Top = 6
               Left = 460
               Bottom = 102
               Right = 630
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vi_Schedule'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vi_Schedule'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[29] 2[12] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Schedule"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 214
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Doctor"
            Begin Extent = 
               Top = 6
               Left = 252
               Bottom = 136
               Right = 422
            End
            DisplayFlags = 280
            TopColumn = 4
         End
         Begin Table = "Specialist"
            Begin Extent = 
               Top = 6
               Left = 460
               Bottom = 102
               Right = 630
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vi_Schedule_PL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vi_Schedule_PL'
GO
USE [master]
GO
ALTER DATABASE [HMS] SET  READ_WRITE 
GO
