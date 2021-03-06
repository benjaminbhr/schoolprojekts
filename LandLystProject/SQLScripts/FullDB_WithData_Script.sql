USE [Landlyst]
GO
/****** Object:  User [Lis]    Script Date: 11/12/2020 12.14.24 ******/
CREATE USER [Lis] FOR LOGIN [Lis] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [Poul]    Script Date: 11/12/2020 12.14.24 ******/
CREATE USER [Poul] FOR LOGIN [Poul] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  DatabaseRole [db_Lis]    Script Date: 11/12/2020 12.14.24 ******/
CREATE ROLE [db_Lis]
GO
ALTER ROLE [db_Lis] ADD MEMBER [Lis]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 11/12/2020 12.14.24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[Room_No] [int] NOT NULL,
	[Status] [varchar](100) NULL,
	[Cost] [int] NULL,
	[Condition] [varchar](100) NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[Room_No] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Rooms]    Script Date: 11/12/2020 12.14.24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Rooms]
AS
SELECT Room_No, Condition
FROM   dbo.Room
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 11/12/2020 12.14.24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[Customer_ID] [int] NOT NULL,
	[Booking_ID] [int] IDENTITY(1,1) NOT NULL,
	[Room_No] [int] NOT NULL,
	[CheckIn_Date] [date] NOT NULL,
	[CheckOut_Date] [date] NOT NULL,
	[Reservation_Date] [date] NOT NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[Booking_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[ReservationView]    Script Date: 11/12/2020 12.14.24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ReservationView]
AS
SELECT * FROM Booking
GO
/****** Object:  Table [dbo].[Billing]    Script Date: 11/12/2020 12.14.24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Billing](
	[Billing_ID] [int] IDENTITY(1,1) NOT NULL,
	[Customer_ID] [int] NOT NULL,
	[Charge] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Billing] PRIMARY KEY CLUSTERED 
(
	[Billing_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Booking_Audit]    Script Date: 11/12/2020 12.14.24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking_Audit](
	[Customer_ID] [int] NOT NULL,
	[Booking_ID] [int] NOT NULL,
	[Room_No] [int] NOT NULL,
	[CheckIn_Date] [date] NOT NULL,
	[CheckOut_Date] [date] NOT NULL,
	[Reservation_Date] [date] NOT NULL,
	[Username] [varchar](50) NULL,
	[audit_action] [varchar](50) NULL,
	[audit_timestamp] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 11/12/2020 12.14.24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Phone_Nr] [int] NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NOT NULL,
	[PostalCode] [int] NOT NULL,
	[StreetName] [varchar](100) NOT NULL,
	[HouseNumber] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Phone_Nr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Features]    Script Date: 11/12/2020 12.14.24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Features](
	[Feature_ID] [int] NOT NULL,
	[Feature] [varchar](100) NULL,
	[Cost] [int] NULL,
 CONSTRAINT [PK_Features] PRIMARY KEY CLUSTERED 
(
	[Feature_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room_Features]    Script Date: 11/12/2020 12.14.24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room_Features](
	[Room_No] [int] NOT NULL,
	[Feature_ID] [int] NOT NULL,
 CONSTRAINT [PK_Room_Features] PRIMARY KEY CLUSTERED 
(
	[Room_No] ASC,
	[Feature_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZipCodes]    Script Date: 11/12/2020 12.14.24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZipCodes](
	[ZipCode] [int] NOT NULL,
	[Name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_ZipCodes] PRIMARY KEY CLUSTERED 
(
	[ZipCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Billing] ON 

INSERT [dbo].[Billing] ([Billing_ID], [Customer_ID], [Charge]) VALUES (12, 25944701, CAST(25120 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Billing] OFF
GO
SET IDENTITY_INSERT [dbo].[Booking] ON 

INSERT [dbo].[Booking] ([Customer_ID], [Booking_ID], [Room_No], [CheckIn_Date], [CheckOut_Date], [Reservation_Date]) VALUES (25944701, 1033, 305, CAST(N'2020-12-02' AS Date), CAST(N'2020-12-18' AS Date), CAST(N'2020-12-11' AS Date))
SET IDENTITY_INSERT [dbo].[Booking] OFF
GO
INSERT [dbo].[Booking_Audit] ([Customer_ID], [Booking_ID], [Room_No], [CheckIn_Date], [CheckOut_Date], [Reservation_Date], [Username], [audit_action], [audit_timestamp]) VALUES (83719362, 1031, 400, CAST(N'2020-11-18' AS Date), CAST(N'2020-11-19' AS Date), CAST(N'2020-12-11' AS Date), N'sa', N'deleted_old', CAST(N'2020-12-11T11:45:20.010' AS DateTime))
INSERT [dbo].[Booking_Audit] ([Customer_ID], [Booking_ID], [Room_No], [CheckIn_Date], [CheckOut_Date], [Reservation_Date], [Username], [audit_action], [audit_timestamp]) VALUES (92837451, 1030, 305, CAST(N'2020-12-02' AS Date), CAST(N'2020-12-29' AS Date), CAST(N'2020-12-11' AS Date), N'sa', N'deleted_old', CAST(N'2020-12-11T11:45:20.010' AS DateTime))
INSERT [dbo].[Booking_Audit] ([Customer_ID], [Booking_ID], [Room_No], [CheckIn_Date], [CheckOut_Date], [Reservation_Date], [Username], [audit_action], [audit_timestamp]) VALUES (73827163, 1032, 309, CAST(N'2020-12-02' AS Date), CAST(N'2020-12-24' AS Date), CAST(N'2020-12-11' AS Date), N'sa', N'inserted_new', CAST(N'2020-12-11T11:47:08.200' AS DateTime))
INSERT [dbo].[Booking_Audit] ([Customer_ID], [Booking_ID], [Room_No], [CheckIn_Date], [CheckOut_Date], [Reservation_Date], [Username], [audit_action], [audit_timestamp]) VALUES (73827163, 1032, 309, CAST(N'2020-12-02' AS Date), CAST(N'2020-12-24' AS Date), CAST(N'2020-12-11' AS Date), N'sa', N'updated_old', CAST(N'2020-12-11T11:48:28.653' AS DateTime))
INSERT [dbo].[Booking_Audit] ([Customer_ID], [Booking_ID], [Room_No], [CheckIn_Date], [CheckOut_Date], [Reservation_Date], [Username], [audit_action], [audit_timestamp]) VALUES (73827163, 1032, 402, CAST(N'2020-12-02' AS Date), CAST(N'2020-12-24' AS Date), CAST(N'2020-12-11' AS Date), N'sa', N'updated_new', CAST(N'2020-12-11T11:48:28.653' AS DateTime))
INSERT [dbo].[Booking_Audit] ([Customer_ID], [Booking_ID], [Room_No], [CheckIn_Date], [CheckOut_Date], [Reservation_Date], [Username], [audit_action], [audit_timestamp]) VALUES (25944701, 1033, 305, CAST(N'2020-12-02' AS Date), CAST(N'2020-12-18' AS Date), CAST(N'2020-12-11' AS Date), N'sa', N'inserted_new', CAST(N'2020-12-11T11:53:01.630' AS DateTime))
INSERT [dbo].[Booking_Audit] ([Customer_ID], [Booking_ID], [Room_No], [CheckIn_Date], [CheckOut_Date], [Reservation_Date], [Username], [audit_action], [audit_timestamp]) VALUES (73827163, 1032, 402, CAST(N'2020-12-02' AS Date), CAST(N'2020-12-24' AS Date), CAST(N'2020-12-11' AS Date), N'sa', N'deleted_old', CAST(N'2020-12-11T11:50:14.227' AS DateTime))
GO
INSERT [dbo].[Customer] ([Phone_Nr], [Email], [FirstName], [LastName], [PostalCode], [StreetName], [HouseNumber]) VALUES (25944701, N'benjaminroesdal@hotmail.com', N'Benjamin', N'Roesdal', 4220, N'Algade', N'44')
GO
INSERT [dbo].[Features] ([Feature_ID], [Feature], [Cost]) VALUES (1, N'Balcony', 150)
INSERT [dbo].[Features] ([Feature_ID], [Feature], [Cost]) VALUES (2, N'DoubleBed', 200)
INSERT [dbo].[Features] ([Feature_ID], [Feature], [Cost]) VALUES (3, N'Bathtub', 50)
INSERT [dbo].[Features] ([Feature_ID], [Feature], [Cost]) VALUES (4, N'Jacuzzi', 175)
INSERT [dbo].[Features] ([Feature_ID], [Feature], [Cost]) VALUES (5, N'Kitchen', 350)
INSERT [dbo].[Features] ([Feature_ID], [Feature], [Cost]) VALUES (6, N'TwoSingleBeds', 200)
INSERT [dbo].[Features] ([Feature_ID], [Feature], [Cost]) VALUES (7, N'SingleBed', 0)
GO
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (100, N'Available', 695, N'Dirty')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (101, N'Available', 695, N'Dirty')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (102, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (103, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (104, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (105, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (106, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (107, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (108, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (109, N'Available', 695, N'Dirty')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (110, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (200, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (201, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (202, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (203, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (204, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (205, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (206, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (207, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (208, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (209, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (300, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (301, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (302, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (303, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (304, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (305, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (306, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (307, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (308, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (309, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (400, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (401, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (402, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (403, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (404, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (405, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (406, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (407, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (408, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (409, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (500, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (501, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (502, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (503, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (504, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (506, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (507, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (508, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (509, N'Available', 695, N'Clean')
INSERT [dbo].[Room] ([Room_No], [Status], [Cost], [Condition]) VALUES (510, N'Available', 695, N'Clean')
GO
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (100, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (100, 3)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (101, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (102, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (102, 3)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (103, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (104, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (104, 3)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (105, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (105, 3)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (106, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (106, 3)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (107, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (107, 3)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (108, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (108, 3)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (109, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (110, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (110, 3)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (200, 1)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (200, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (200, 4)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (201, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (201, 3)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (202, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (202, 3)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (203, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (204, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (204, 3)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (205, 1)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (205, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (205, 4)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (205, 5)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (206, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (206, 3)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (207, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (207, 3)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (208, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (208, 3)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (209, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (209, 3)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (209, 4)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (300, 1)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (300, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (300, 4)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (301, 3)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (301, 6)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (302, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (302, 3)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (303, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (303, 3)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (304, 3)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (304, 6)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (305, 1)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (305, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (305, 4)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (305, 5)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (306, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (306, 3)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (307, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (307, 3)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (308, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (308, 3)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (309, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (309, 3)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (309, 4)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (400, 1)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (400, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (400, 4)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (401, 1)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (401, 3)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (401, 7)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (402, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (402, 3)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (403, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (403, 3)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (404, 3)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (404, 7)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (405, 1)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (405, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (405, 4)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (405, 5)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (406, 1)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (406, 7)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (407, 1)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (407, 7)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (408, 7)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (409, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (409, 3)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (409, 4)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (500, 1)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (500, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (500, 4)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (501, 3)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (501, 6)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (502, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (502, 3)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (503, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (503, 3)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (504, 3)
GO
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (504, 7)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (506, 1)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (506, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (507, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (507, 3)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (508, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (508, 3)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (509, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (509, 3)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (510, 2)
INSERT [dbo].[Room_Features] ([Room_No], [Feature_ID]) VALUES (510, 3)
GO
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (783, N'Facility')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (785, N'Bestseller ')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (800, N'Høje Taastrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (877, N'København C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (892, N'Sjælland USF P')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (893, N'Sjælland USF B')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (900, N'København C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (929, N'København C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (999, N'København C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1001, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1002, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1003, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1004, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1005, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1006, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1007, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1008, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1009, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1010, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1011, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1012, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1013, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1014, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1015, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1016, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1017, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1018, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1019, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1020, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1021, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1022, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1023, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1024, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1025, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1026, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1045, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1050, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1051, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1052, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1053, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1054, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1055, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1056, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1057, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1058, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1059, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1060, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1061, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1062, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1063, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1064, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1065, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1066, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1067, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1068, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1069, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1070, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1071, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1072, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1073, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1074, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1092, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1093, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1095, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1098, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1100, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1101, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1102, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1103, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1104, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1105, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1106, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1107, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1110, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1111, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1112, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1113, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1114, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1115, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1116, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1117, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1118, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1119, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1120, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1121, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1122, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1123, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1124, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1125, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1126, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1127, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1128, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1129, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1130, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1131, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1140, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1147, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1148, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1150, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1151, N'København K')
GO
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1152, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1153, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1154, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1155, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1156, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1157, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1158, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1159, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1160, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1161, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1162, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1164, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1165, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1166, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1167, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1168, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1169, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1170, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1171, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1172, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1173, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1174, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1175, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1200, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1201, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1202, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1203, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1204, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1205, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1206, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1207, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1208, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1209, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1210, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1211, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1212, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1213, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1214, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1215, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1216, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1217, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1218, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1219, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1220, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1221, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1240, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1250, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1251, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1252, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1253, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1254, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1255, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1256, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1257, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1259, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1260, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1261, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1263, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1264, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1265, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1266, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1267, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1268, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1270, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1271, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1300, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1301, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1302, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1303, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1304, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1306, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1307, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1308, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1309, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1310, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1311, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1312, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1313, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1314, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1315, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1316, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1317, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1318, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1319, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1320, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1321, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1322, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1323, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1324, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1325, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1326, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1327, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1328, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1329, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1350, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1352, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1353, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1354, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1355, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1356, N'København K')
GO
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1357, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1358, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1359, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1360, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1361, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1362, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1363, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1364, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1365, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1366, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1367, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1368, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1369, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1370, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1371, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1400, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1401, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1402, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1403, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1406, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1407, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1408, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1409, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1410, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1411, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1412, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1413, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1414, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1415, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1416, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1417, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1418, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1419, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1420, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1421, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1422, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1423, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1424, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1425, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1426, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1427, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1428, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1429, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1430, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1432, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1433, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1434, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1435, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1436, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1437, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1438, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1439, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1440, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1441, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1448, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1450, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1451, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1452, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1453, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1454, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1455, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1456, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1457, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1458, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1459, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1460, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1461, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1462, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1463, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1464, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1465, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1466, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1467, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1468, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1470, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1471, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1472, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1473, N'København K')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1500, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1501, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1502, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1503, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1504, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1505, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1506, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1507, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1508, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1509, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1510, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1532, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1533, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1550, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1551, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1552, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1553, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1554, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1555, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1556, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1557, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1558, N'København V')
GO
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1559, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1560, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1561, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1562, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1563, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1564, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1567, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1568, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1569, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1570, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1571, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1572, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1573, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1574, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1575, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1576, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1577, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1592, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1599, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1600, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1601, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1602, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1603, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1604, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1605, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1606, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1607, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1608, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1609, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1610, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1611, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1612, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1613, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1614, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1615, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1616, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1617, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1618, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1619, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1620, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1621, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1622, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1623, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1624, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1630, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1631, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1632, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1633, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1634, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1635, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1650, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1651, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1652, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1653, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1654, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1655, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1656, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1657, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1658, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1659, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1660, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1661, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1662, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1663, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1664, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1665, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1666, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1667, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1668, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1669, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1670, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1671, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1672, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1673, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1674, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1675, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1676, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1677, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1699, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1700, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1701, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1702, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1703, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1704, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1705, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1706, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1707, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1708, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1709, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1710, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1711, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1712, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1714, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1715, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1716, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1717, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1718, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1719, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1720, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1721, N'København V')
GO
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1722, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1723, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1724, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1725, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1726, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1727, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1728, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1729, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1730, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1731, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1732, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1733, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1734, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1735, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1736, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1737, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1738, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1739, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1749, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1750, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1751, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1752, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1753, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1754, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1755, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1756, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1757, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1758, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1759, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1760, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1761, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1762, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1763, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1764, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1765, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1766, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1770, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1771, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1772, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1773, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1774, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1775, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1777, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1780, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1782, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1785, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1786, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1787, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1790, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1799, N'København V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1800, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1801, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1802, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1803, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1804, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1805, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1806, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1807, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1808, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1809, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1810, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1811, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1812, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1813, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1814, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1815, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1816, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1817, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1818, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1819, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1820, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1822, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1823, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1824, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1825, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1826, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1827, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1828, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1829, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1835, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1850, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1851, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1852, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1853, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1854, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1855, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1856, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1857, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1860, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1861, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1862, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1863, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1864, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1865, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1866, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1867, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1868, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1870, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1871, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1872, N'Frederiksberg C')
GO
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1873, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1874, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1875, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1876, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1877, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1878, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1879, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1900, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1901, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1902, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1903, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1904, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1905, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1906, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1908, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1909, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1910, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1911, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1912, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1913, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1914, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1915, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1916, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1917, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1920, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1921, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1922, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1923, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1924, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1925, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1926, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1927, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1928, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1931, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1950, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1951, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1952, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1953, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1954, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1955, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1956, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1957, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1958, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1959, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1960, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1961, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1962, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1963, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1964, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1965, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1966, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1967, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1970, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1971, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1972, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1973, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (1974, N'Frederiksberg C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2000, N'Frederiksberg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2100, N'København Ø')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2150, N'Nordhavn')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2200, N'København N')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2300, N'København S')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2400, N'København NV')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2450, N'København SV')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2500, N'Valby')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2600, N'Glostrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2605, N'Brøndby')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2610, N'Rødovre')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2620, N'Albertslund')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2625, N'Vallensbæk')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2630, N'Taastrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2635, N'Ishøj')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2640, N'Hedehusene')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2650, N'Hvidovre')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2660, N'Brøndby Strand')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2665, N'Vallensbæk Strand')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2670, N'Greve')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2680, N'Solrød Strand')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2690, N'Karlslunde')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2700, N'Brønshøj')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2720, N'Vanløse')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2730, N'Herlev')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2740, N'Skovlunde')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2750, N'Ballerup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2760, N'Måløv')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2765, N'Smørum')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2770, N'Kastrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2791, N'Dragør')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2800, N'Kongens Lyngby')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2820, N'Gentofte')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2830, N'Virum')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2840, N'Holte')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2850, N'Nærum')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2860, N'Søborg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2870, N'Dyssegård')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2880, N'Bagsværd')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2900, N'Hellerup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2920, N'Charlottenlund')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2930, N'Klampenborg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2942, N'Skodsborg')
GO
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2950, N'Vedbæk')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2960, N'Rungsted Kyst')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2970, N'Hørsholm')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2980, N'Kokkedal')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (2990, N'Nivå')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3000, N'Helsingør')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3050, N'Humlebæk')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3060, N'Espergærde')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3070, N'Snekkersten')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3080, N'Tikøb')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3100, N'Hornbæk')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3120, N'Dronningmølle')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3140, N'Ålsgårde')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3150, N'Hellebæk')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3200, N'Helsinge')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3210, N'Vejby')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3220, N'Tisvildeleje')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3230, N'Græsted')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3250, N'Gilleleje')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3300, N'Frederiksværk')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3310, N'Ølsted')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3320, N'Skævinge')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3330, N'Gørløse')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3360, N'Liseleje')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3370, N'Melby')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3390, N'Hundested')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3400, N'Hillerød')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3450, N'Allerød')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3460, N'Birkerød')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3480, N'Fredensborg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3490, N'Kvistgård')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3500, N'Værløse')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3520, N'Farum')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3540, N'Lynge')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3550, N'Slangerup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3600, N'Frederikssund')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3630, N'Jægerspris')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3650, N'Ølstykke')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3660, N'Stenløse')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3670, N'Veksø Sjælland')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3700, N'Rønne')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3720, N'Aakirkeby')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3730, N'Nexø')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3740, N'Svaneke')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3751, N'Østermarie')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3760, N'Gudhjem')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3770, N'Allinge')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3782, N'Klemensker')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (3790, N'Hasle')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4000, N'Roskilde')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4030, N'Tune')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4040, N'Jyllinge')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4050, N'Skibby')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4060, N'Kirke Såby')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4070, N'Kirke Hyllinge')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4100, N'Ringsted')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4129, N'Ringsted')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4130, N'Viby Sjælland')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4140, N'Borup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4160, N'Herlufmagle')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4171, N'Glumsø')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4173, N'Fjenneslev')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4174, N'Jystrup Midtsj')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4180, N'Sorø')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4190, N'Munke Bjergby')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4200, N'Slagelse')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4220, N'Korsør')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4230, N'Skælskør')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4241, N'Vemmelev')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4242, N'Boeslunde')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4243, N'Rude')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4244, N'Agersø')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4245, N'Omø')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4250, N'Fuglebjerg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4261, N'Dalmose')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4262, N'Sandved')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4270, N'Høng')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4281, N'Gørlev')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4291, N'Ruds Vedby')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4293, N'Dianalund')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4295, N'Stenlille')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4296, N'Nyrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4300, N'Holbæk')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4305, N'Orø')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4320, N'Lejre')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4330, N'Hvalsø')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4340, N'Tølløse')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4350, N'Ugerløse')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4360, N'Kirke Eskilstrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4370, N'Store Merløse')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4390, N'Vipperød')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4400, N'Kalundborg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4420, N'Regstrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4440, N'Mørkøv')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4450, N'Jyderup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4460, N'Snertinge')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4470, N'Svebølle')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4480, N'Store Fuglede')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4490, N'Jerslev Sjælland')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4500, N'Nykøbing Sj')
GO
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4520, N'Svinninge')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4532, N'Gislinge')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4534, N'Hørve')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4540, N'Fårevejle')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4550, N'Asnæs')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4560, N'Vig')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4571, N'Grevinge')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4572, N'Nørre Asmindrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4573, N'Højby')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4581, N'Rørvig')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4583, N'Sjællands Odde')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4591, N'Føllenslev')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4592, N'Sejerø')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4593, N'Eskebjerg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4600, N'Køge')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4621, N'Gadstrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4622, N'Havdrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4623, N'Lille Skensved')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4632, N'Bjæverskov')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4640, N'Faxe')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4652, N'Hårlev')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4653, N'Karise')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4654, N'Faxe Ladeplads')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4660, N'Store Heddinge')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4671, N'Strøby')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4672, N'Klippinge')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4673, N'Rødvig Stevns')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4681, N'Herfølge')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4682, N'Tureby')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4683, N'Rønnede')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4684, N'Holmegaard')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4690, N'Haslev')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4700, N'Næstved')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4720, N'Præstø')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4733, N'Tappernøje')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4735, N'Mern')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4736, N'Karrebæksminde')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4750, N'Lundby')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4760, N'Vordingborg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4771, N'Kalvehave')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4772, N'Langebæk')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4773, N'Stensved')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4780, N'Stege')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4791, N'Borre')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4792, N'Askeby')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4793, N'Bogø By')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4800, N'Nykøbing F')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4840, N'Nørre Alslev')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4850, N'Stubbekøbing')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4862, N'Guldborg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4863, N'Eskilstrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4871, N'Horbelev')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4872, N'Idestrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4873, N'Væggerløse')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4874, N'Gedser')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4880, N'Nysted')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4891, N'Toreby L')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4892, N'Kettinge')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4894, N'Øster Ulslev')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4895, N'Errindlev')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4900, N'Nakskov')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4912, N'Harpelunde')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4913, N'Horslunde')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4920, N'Søllested')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4930, N'Maribo')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4941, N'Bandholm')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4942, N'Askø og Lilleø')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4943, N'Torrig L')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4944, N'Fejø')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4945, N'Femø')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4951, N'Nørreballe')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4952, N'Stokkemarke')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4953, N'Vesterborg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4960, N'Holeby')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4970, N'Rødby')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4983, N'Dannemare')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4990, N'Sakskøbing')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (4992, N'Midtsjælland USF P')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5000, N'Odense C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5029, N'Odense C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5100, N'Odense C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5200, N'Odense V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5210, N'Odense NV')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5220, N'Odense SØ')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5230, N'Odense M')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5240, N'Odense NØ')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5250, N'Odense SV')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5260, N'Odense S')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5270, N'Odense N')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5290, N'Marslev')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5300, N'Kerteminde')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5320, N'Agedrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5330, N'Munkebo')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5350, N'Rynkeby')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5370, N'Mesinge')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5380, N'Dalby')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5390, N'Martofte')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5400, N'Bogense')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5450, N'Otterup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5462, N'Morud')
GO
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5463, N'Harndrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5464, N'Brenderup Fyn')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5466, N'Asperup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5471, N'Søndersø')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5474, N'Veflinge')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5485, N'Skamby')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5491, N'Blommenslyst')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5492, N'Vissenbjerg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5500, N'Middelfart')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5540, N'Ullerslev')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5550, N'Langeskov')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5560, N'Aarup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5580, N'Nørre Aaby')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5591, N'Gelsted')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5592, N'Ejby')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5600, N'Faaborg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5601, N'Lyø')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5602, N'Avernakø')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5603, N'Bjørnø')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5610, N'Assens')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5620, N'Glamsbjerg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5631, N'Ebberup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5642, N'Millinge')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5672, N'Broby')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5683, N'Haarby')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5690, N'Tommerup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5700, N'Svendborg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5750, N'Ringe')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5762, N'Vester Skerninge')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5771, N'Stenstrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5772, N'Kværndrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5792, N'Årslev')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5800, N'Nyborg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5853, N'Ørbæk')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5854, N'Gislev')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5856, N'Ryslinge')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5863, N'Ferritslev Fyn')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5871, N'Frørup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5874, N'Hesselager')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5881, N'Skårup Fyn')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5882, N'Vejstrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5883, N'Oure')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5884, N'Gudme')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5892, N'Gudbjerg Sydfyn')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5900, N'Rudkøbing')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5932, N'Humble')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5935, N'Bagenkop')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5943, N'Strynø')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5953, N'Tranekær')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5960, N'Marstal')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5965, N'Birkholm')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5970, N'Ærøskøbing')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (5985, N'Søby Ærø')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6000, N'Kolding')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6040, N'Egtved')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6051, N'Almind')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6052, N'Viuf')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6064, N'Jordrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6070, N'Christiansfeld')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6091, N'Bjert')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6092, N'Sønder Stenderup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6093, N'Sjølund')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6094, N'Hejls')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6100, N'Haderslev')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6200, N'Aabenraa')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6210, N'Barsø')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6230, N'Rødekro')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6240, N'Løgumkloster')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6261, N'Bredebro')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6270, N'Tønder')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6280, N'Højer')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6300, N'Gråsten')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6310, N'Broager')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6320, N'Egernsund')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6330, N'Padborg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6340, N'Kruså')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6360, N'Tinglev')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6372, N'Bylderup-Bov')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6392, N'Bolderslev')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6400, N'Sønderborg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6430, N'Nordborg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6440, N'Augustenborg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6470, N'Sydals')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6500, N'Vojens')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6510, N'Gram')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6520, N'Toftlund')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6534, N'Agerskov')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6535, N'Branderup J')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6541, N'Bevtoft')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6560, N'Sommersted')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6580, N'Vamdrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6600, N'Vejen')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6621, N'Gesten')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6622, N'Bække')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6623, N'Vorbasse')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6630, N'Rødding')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6640, N'Lunderskov')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6650, N'Brørup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6660, N'Lintrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6670, N'Holsted')
GO
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6682, N'Hovborg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6683, N'Føvling')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6690, N'Gørding')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6700, N'Esbjerg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6701, N'Esbjerg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6705, N'Esbjerg Ø')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6710, N'Esbjerg V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6715, N'Esbjerg N')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6720, N'Fanø')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6731, N'Tjæreborg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6740, N'Bramming')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6752, N'Glejbjerg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6753, N'Agerbæk')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6760, N'Ribe')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6771, N'Gredstedbro')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6780, N'Skærbæk')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6792, N'Rømø')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6800, N'Varde')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6818, N'Årre')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6823, N'Ansager')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6830, N'Nørre Nebel')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6840, N'Oksbøl')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6851, N'Janderup Vestj')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6852, N'Billum')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6853, N'Vejers Strand')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6854, N'Henne')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6855, N'Outrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6857, N'Blåvand')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6862, N'Tistrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6870, N'Ølgod')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6880, N'Tarm')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6893, N'Hemmet')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6900, N'Skjern')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6920, N'Videbæk')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6933, N'Kibæk')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6940, N'Lem St')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6950, N'Ringkøbing')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6960, N'Hvide Sande')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6971, N'Spjald')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6973, N'Ørnhøj')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6980, N'Tim')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (6990, N'Ulfborg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7000, N'Fredericia')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7007, N'Fredericia')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7017, N'Taulov Pakkecenter')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7018, N'Pakker TLP')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7029, N'Fredericia')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7080, N'Børkop')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7100, N'Vejle')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7120, N'Vejle Øst')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7130, N'Juelsminde')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7140, N'Stouby')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7150, N'Barrit')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7160, N'Tørring')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7171, N'Uldum')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7173, N'Vonge')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7182, N'Bredsten')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7183, N'Randbøl')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7184, N'Vandel')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7190, N'Billund')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7200, N'Grindsted')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7250, N'Hejnsvig')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7260, N'Sønder Omme')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7270, N'Stakroge')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7280, N'Sønder Felding')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7300, N'Jelling')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7321, N'Gadbjerg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7323, N'Give')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7330, N'Brande')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7361, N'Ejstrupholm')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7362, N'Hampen')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7400, N'Herning')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7429, N'Herning')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7430, N'Ikast')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7441, N'Bording')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7442, N'Engesvang')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7451, N'Sunds')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7470, N'Karup J')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7480, N'Vildbjerg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7490, N'Aulum')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7500, N'Holstebro')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7540, N'Haderup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7550, N'Sørvad')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7560, N'Hjerm')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7570, N'Vemb')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7600, N'Struer')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7620, N'Lemvig')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7650, N'Bøvlingbjerg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7660, N'Bækmarksbro')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7673, N'Harboøre')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7680, N'Thyborøn')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7700, N'Thisted')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7730, N'Hanstholm')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7741, N'Frøstrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7742, N'Vesløs')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7752, N'Snedsted')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7755, N'Bedsted Thy')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7760, N'Hurup Thy')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7770, N'Vestervig')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7790, N'Thyholm')
GO
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7800, N'Skive')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7830, N'Vinderup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7840, N'Højslev')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7850, N'Stoholm Jyll')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7860, N'Spøttrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7870, N'Roslev')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7884, N'Fur')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7900, N'Nykøbing M')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7950, N'Erslev')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7960, N'Karby')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7970, N'Redsted M')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7980, N'Vils')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7990, N'Øster Assels')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7992, N'Sydjylland/Fyn USF P')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (7993, N'Sydjylland/Fyn USF B')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8000, N'Aarhus C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8100, N'Aarhus C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8200, N'Aarhus N')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8210, N'Aarhus V')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8220, N'Brabrand')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8229, N'Risskov Ø')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8230, N'Åbyhøj')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8240, N'Risskov')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8245, N'Risskov Ø')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8250, N'Egå')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8260, N'Viby J')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8270, N'Højbjerg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8300, N'Odder')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8305, N'Samsø')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8310, N'Tranbjerg J')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8320, N'Mårslet')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8330, N'Beder')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8340, N'Malling')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8350, N'Hundslund')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8355, N'Solbjerg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8361, N'Hasselager')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8362, N'Hørning')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8370, N'Hadsten')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8380, N'Trige')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8381, N'Tilst')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8382, N'Hinnerup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8400, N'Ebeltoft')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8410, N'Rønde')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8420, N'Knebel')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8444, N'Balle')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8450, N'Hammel')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8462, N'Harlev J')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8464, N'Galten')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8471, N'Sabro')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8472, N'Sporup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8500, N'Grenaa')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8520, N'Lystrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8530, N'Hjortshøj')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8541, N'Skødstrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8543, N'Hornslet')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8544, N'Mørke')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8550, N'Ryomgård')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8560, N'Kolind')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8570, N'Trustrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8581, N'Nimtofte')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8585, N'Glesborg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8586, N'Ørum Djurs')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8592, N'Anholt')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8600, N'Silkeborg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8620, N'Kjellerup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8632, N'Lemming')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8641, N'Sorring')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8643, N'Ans By')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8653, N'Them')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8654, N'Bryrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8660, N'Skanderborg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8670, N'Låsby')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8680, N'Ry')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8700, N'Horsens')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8721, N'Daugård')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8722, N'Hedensted')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8723, N'Løsning')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8732, N'Hovedgård')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8740, N'Brædstrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8751, N'Gedved')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8752, N'Østbirk')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8762, N'Flemming')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8763, N'Rask Mølle')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8765, N'Klovborg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8766, N'Nørre Snede')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8781, N'Stenderup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8783, N'Hornsyld')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8789, N'Endelave')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8799, N'Tunø')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8800, N'Viborg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8830, N'Tjele')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8831, N'Løgstrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8832, N'Skals')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8840, N'Rødkærsbro')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8850, N'Bjerringbro')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8860, N'Ulstrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8870, N'Langå')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8881, N'Thorsø')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8882, N'Fårvang')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8883, N'Gjern')
GO
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8900, N'Randers C')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8920, N'Randers NV')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8930, N'Randers NØ')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8940, N'Randers SV')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8950, N'Ørsted')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8960, N'Randers SØ')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8961, N'Allingåbro')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8963, N'Auning')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8970, N'Havndal')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8981, N'Spentrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8983, N'Gjerlev J')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (8990, N'Fårup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9000, N'Aalborg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9029, N'Aalborg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9100, N'Aalborg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9200, N'Aalborg SV')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9210, N'Aalborg SØ')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9220, N'Aalborg Øst')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9230, N'Svenstrup J')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9240, N'Nibe')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9260, N'Gistrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9270, N'Klarup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9280, N'Storvorde')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9293, N'Kongerslev')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9300, N'Sæby')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9310, N'Vodskov')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9320, N'Hjallerup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9330, N'Dronninglund')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9340, N'Asaa')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9352, N'Dybvad')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9362, N'Gandrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9370, N'Hals')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9380, N'Vestbjerg')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9381, N'Sulsted')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9382, N'Tylstrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9400, N'Nørresundby')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9430, N'Vadum')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9440, N'Aabybro')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9460, N'Brovst')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9480, N'Løkken')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9490, N'Pandrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9492, N'Blokhus')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9493, N'Saltum')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9500, N'Hobro')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9510, N'Arden')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9520, N'Skørping')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9530, N'Støvring')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9541, N'Suldrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9550, N'Mariager')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9560, N'Hadsund')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9574, N'Bælum')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9575, N'Terndrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9600, N'Aars')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9610, N'Nørager')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9620, N'Aalestrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9631, N'Gedsted')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9632, N'Møldrup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9640, N'Farsø')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9670, N'Løgstør')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9681, N'Ranum')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9690, N'Fjerritslev')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9700, N'Brønderslev')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9740, N'Jerslev J')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9750, N'Østervrå')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9760, N'Vrå')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9800, N'Hjørring')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9830, N'Tårs')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9850, N'Hirtshals')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9870, N'Sindal')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9881, N'Bindslev')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9900, N'Frederikshavn')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9940, N'Læsø')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9970, N'Strandby')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9981, N'Jerup')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9982, N'Ålbæk')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9990, N'Skagen')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9992, N'Jylland USF P')
INSERT [dbo].[ZipCodes] ([ZipCode], [Name]) VALUES (9993, N'Jylland USF B')
GO
ALTER TABLE [dbo].[Billing]  WITH CHECK ADD  CONSTRAINT [FK_Billing_Customer] FOREIGN KEY([Customer_ID])
REFERENCES [dbo].[Customer] ([Phone_Nr])
GO
ALTER TABLE [dbo].[Billing] CHECK CONSTRAINT [FK_Billing_Customer]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Customer] FOREIGN KEY([Customer_ID])
REFERENCES [dbo].[Customer] ([Phone_Nr])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Customer]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Room] FOREIGN KEY([Room_No])
REFERENCES [dbo].[Room] ([Room_No])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Room]
GO
ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [FK_Customer_ZipCodes] FOREIGN KEY([PostalCode])
REFERENCES [dbo].[ZipCodes] ([ZipCode])
GO
ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [FK_Customer_ZipCodes]
GO
ALTER TABLE [dbo].[Room_Features]  WITH CHECK ADD  CONSTRAINT [FK_Room_Features_Features] FOREIGN KEY([Feature_ID])
REFERENCES [dbo].[Features] ([Feature_ID])
GO
ALTER TABLE [dbo].[Room_Features] CHECK CONSTRAINT [FK_Room_Features_Features]
GO
ALTER TABLE [dbo].[Room_Features]  WITH CHECK ADD  CONSTRAINT [FK_Room_Features_Room] FOREIGN KEY([Room_No])
REFERENCES [dbo].[Room] ([Room_No])
GO
ALTER TABLE [dbo].[Room_Features] CHECK CONSTRAINT [FK_Room_Features_Room]
GO
/****** Object:  StoredProcedure [dbo].[CreateBilling]    Script Date: 11/12/2020 12.14.24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateBilling] @Customer_ID int,@Room_Nr int,@CheckIn_Date datetime,@CheckOut_Date datetime
AS
DECLARE @TotalFeatureCost int;
DECLARE @TotalBookedDays int;
DECLARE @RoomCost int;
DECLARE @FinalCost int;
SET @TotalFeatureCost = (SELECT SUM(fe.Cost) AS TotalFeatureCost FROM Room r JOIN Room_Features rf ON rf.Room_No = r.Room_No JOIN Features fe ON fe.Feature_ID = rf.Feature_ID WHERE rf.Room_No = @Room_Nr);
SET @TotalBookedDays = (SELECT DATEDIFF(day,@CheckIn_Date,@CheckOut_Date));
SET @RoomCost = (SELECT Room.Cost FROM Room WHERE Room.Room_No = @Room_Nr);
SET @FinalCost = (@TotalFeatureCost + @RoomCost) * @TotalBookedDays;

INSERT INTO Billing(Customer_ID,Charge) VALUES (@Customer_ID,@FinalCost);
GO
/****** Object:  StoredProcedure [dbo].[CreateBooking]    Script Date: 11/12/2020 12.14.24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateBooking] @Customer_ID int,@Room_No int, @CheckIn_Date DateTime,@CheckOut_Date DateTime
AS
INSERT INTO Booking (Customer_ID,Room_No,CheckIn_Date,CheckOut_Date,Reservation_Date)
VALUES (@Customer_ID,@Room_No,@CheckIn_Date,@CheckOut_Date,GETDATE())
GO
/****** Object:  StoredProcedure [dbo].[CreateCustomerAndBooking]    Script Date: 11/12/2020 12.14.24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script for SelectTopNRows command from SSMS  ******/
CREATE PROCEDURE [dbo].[CreateCustomerAndBooking] @Phone_Nr varchar(100), @Email varchar(100), @FirstName varchar(100),@LastName varchar(100), @PostalCode int, @StreetName varchar(100),@HouseNumber varchar(100),@Room_No int,@CheckIn_Date DateTime,@Checkout_Date DateTime
AS
EXEC CreateNewCustomer @Phone_Nr,@Email,@FirstName,@LastName,@PostalCode,@StreetName,@HouseNumber
EXEC CreateBooking @Phone_Nr,@Room_No,@CheckIn_Date,@Checkout_Date
EXEC CreateBilling @Phone_Nr,@Room_No,@CheckIn_Date,@Checkout_Date
GO
/****** Object:  StoredProcedure [dbo].[CreateNewCustomer]    Script Date: 11/12/2020 12.14.24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateNewCustomer] @Phone_Nr varchar(100), @Email varchar(100), @FirstName varchar(100),@LastName varchar(100), @PostalCode int, @StreetName varchar(100),@HouseNumber varchar(100)
AS
IF (NOT EXISTS (SELECT * FROM Customer WHERE Customer.Phone_Nr = @Phone_Nr))
BEGIN
INSERT INTO Landlyst.dbo.Customer (Phone_Nr,Email,FirstName,LastName,PostalCode,StreetName,HouseNumber)
VALUES (@Phone_Nr,@Email,@FirstName,@LastName,@PostalCode,@StreetName,@HouseNumber)
END
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
         Top = -144
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Room"
            Begin Extent = 
               Top = 9
               Left = 57
               Bottom = 206
               Right = 279
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Rooms'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Rooms'
GO
