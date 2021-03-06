USE [Landlyst]
GO
/****** Object:  User [Lis]    Script Date: 11/12/2020 12.20.38 ******/
CREATE USER [Lis] FOR LOGIN [Lis] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [Poul]    Script Date: 11/12/2020 12.20.38 ******/
CREATE USER [Poul] FOR LOGIN [Poul] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  DatabaseRole [db_Lis]    Script Date: 11/12/2020 12.20.38 ******/
CREATE ROLE [db_Lis]
GO
ALTER ROLE [db_Lis] ADD MEMBER [Lis]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 11/12/2020 12.20.38 ******/
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
/****** Object:  View [dbo].[Rooms]    Script Date: 11/12/2020 12.20.38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Rooms]
AS
SELECT Room_No, Condition
FROM   dbo.Room
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 11/12/2020 12.20.38 ******/
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
/****** Object:  View [dbo].[ReservationView]    Script Date: 11/12/2020 12.20.38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ReservationView]
AS
SELECT * FROM Booking
GO
/****** Object:  Table [dbo].[Billing]    Script Date: 11/12/2020 12.20.38 ******/
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
/****** Object:  Table [dbo].[Booking_Audit]    Script Date: 11/12/2020 12.20.38 ******/
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
/****** Object:  Table [dbo].[Customer]    Script Date: 11/12/2020 12.20.38 ******/
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
/****** Object:  Table [dbo].[Features]    Script Date: 11/12/2020 12.20.38 ******/
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
/****** Object:  Table [dbo].[Room_Features]    Script Date: 11/12/2020 12.20.38 ******/
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
/****** Object:  Table [dbo].[ZipCodes]    Script Date: 11/12/2020 12.20.38 ******/
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
/****** Object:  StoredProcedure [dbo].[CreateBilling]    Script Date: 11/12/2020 12.20.38 ******/
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
/****** Object:  StoredProcedure [dbo].[CreateBooking]    Script Date: 11/12/2020 12.20.38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateBooking] @Customer_ID int,@Room_No int, @CheckIn_Date DateTime,@CheckOut_Date DateTime
AS
INSERT INTO Booking (Customer_ID,Room_No,CheckIn_Date,CheckOut_Date,Reservation_Date)
VALUES (@Customer_ID,@Room_No,@CheckIn_Date,@CheckOut_Date,GETDATE())
GO
/****** Object:  StoredProcedure [dbo].[CreateCustomerAndBooking]    Script Date: 11/12/2020 12.20.38 ******/
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
/****** Object:  StoredProcedure [dbo].[CreateNewCustomer]    Script Date: 11/12/2020 12.20.38 ******/
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
