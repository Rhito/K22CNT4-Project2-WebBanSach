USE [master]
GO
/****** Object:  Database [K22CNT4-TTCD1-DinhTienLuc]    Script Date: 11/16/2024 11:01:13 PM ******/
CREATE DATABASE [K22CNT4-TTCD1-DinhTienLuc]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'K22CNT4-TTCD1-DinhTienLuc', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\K22CNT4-TTCD1-DinhTienLuc.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'K22CNT4-TTCD1-DinhTienLuc_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\K22CNT4-TTCD1-DinhTienLuc_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [K22CNT4-TTCD1-DinhTienLuc].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [K22CNT4-TTCD1-DinhTienLuc] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [K22CNT4-TTCD1-DinhTienLuc] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [K22CNT4-TTCD1-DinhTienLuc] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [K22CNT4-TTCD1-DinhTienLuc] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [K22CNT4-TTCD1-DinhTienLuc] SET ARITHABORT OFF 
GO
ALTER DATABASE [K22CNT4-TTCD1-DinhTienLuc] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [K22CNT4-TTCD1-DinhTienLuc] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [K22CNT4-TTCD1-DinhTienLuc] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [K22CNT4-TTCD1-DinhTienLuc] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [K22CNT4-TTCD1-DinhTienLuc] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [K22CNT4-TTCD1-DinhTienLuc] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [K22CNT4-TTCD1-DinhTienLuc] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [K22CNT4-TTCD1-DinhTienLuc] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [K22CNT4-TTCD1-DinhTienLuc] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [K22CNT4-TTCD1-DinhTienLuc] SET  DISABLE_BROKER 
GO
ALTER DATABASE [K22CNT4-TTCD1-DinhTienLuc] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [K22CNT4-TTCD1-DinhTienLuc] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [K22CNT4-TTCD1-DinhTienLuc] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [K22CNT4-TTCD1-DinhTienLuc] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [K22CNT4-TTCD1-DinhTienLuc] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [K22CNT4-TTCD1-DinhTienLuc] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [K22CNT4-TTCD1-DinhTienLuc] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [K22CNT4-TTCD1-DinhTienLuc] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [K22CNT4-TTCD1-DinhTienLuc] SET  MULTI_USER 
GO
ALTER DATABASE [K22CNT4-TTCD1-DinhTienLuc] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [K22CNT4-TTCD1-DinhTienLuc] SET DB_CHAINING OFF 
GO
ALTER DATABASE [K22CNT4-TTCD1-DinhTienLuc] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [K22CNT4-TTCD1-DinhTienLuc] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
USE [K22CNT4-TTCD1-DinhTienLuc]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 11/16/2024 11:01:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdSach] [int] NOT NULL,
	[IdUser] [int] NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[Quantity] [int] NOT NULL,
	[TotalPrice] [decimal](18, 0) NOT NULL,
	[SachImages] [nvarchar](500) NOT NULL,
	[TenSach] [nchar](110) NOT NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhMucSach]    Script Date: 11/16/2024 11:01:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMucSach](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_DanhMucSach] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 11/16/2024 11:01:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](110) NOT NULL,
	[Phone] [nvarchar](10) NOT NULL,
	[Address] [nvarchar](200) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 11/16/2024 11:01:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[SachId] [int] NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sach]    Script Date: 11/16/2024 11:01:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sach](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdDanhMuc] [int] NOT NULL,
	[Name] [nvarchar](110) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[Images] [nvarchar](500) NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Sach_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Slide]    Script Date: 11/16/2024 11:01:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slide](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Images] [nvarchar](500) NULL,
 CONSTRAINT [PK_SlideTb] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/16/2024 11:01:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nchar](110) NOT NULL,
	[Password] [nchar](50) NOT NULL,
	[Status] [bit] NOT NULL,
	[Role] [bit] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[DanhMucSach] ON 

INSERT [dbo].[DanhMucSach] ([Id], [Name], [Status]) VALUES (1, N'Văn học hiện đại', 1)
INSERT [dbo].[DanhMucSach] ([Id], [Name], [Status]) VALUES (3, N'Tâm lý học', 1)
INSERT [dbo].[DanhMucSach] ([Id], [Name], [Status]) VALUES (4, N'Kinh tế', 1)
INSERT [dbo].[DanhMucSach] ([Id], [Name], [Status]) VALUES (5, N'Sách võ công', 0)
SET IDENTITY_INSERT [dbo].[DanhMucSach] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [CustomerName], [Phone], [Address], [Email]) VALUES (1, N'Longs', N'0372657741', N'Hà nộis', N'Lasngiuen@gm.mails')
INSERT [dbo].[Order] ([Id], [CustomerName], [Phone], [Address], [Email]) VALUES (2, N'123', N'1234567890', N'123', N'123@gmai.com')
INSERT [dbo].[Order] ([Id], [CustomerName], [Phone], [Address], [Email]) VALUES (4, N'ANh Hieu suy tinh', N'0388146141', N'HieuKhekhec123', N'HieuKhekhec123@gmail.com')
INSERT [dbo].[Order] ([Id], [CustomerName], [Phone], [Address], [Email]) VALUES (5, N'Hiéuuyus', N'1234567890', N'Dónguytinh', N'HieuCoichuong123@gmail.hieu')
INSERT [dbo].[Order] ([Id], [CustomerName], [Phone], [Address], [Email]) VALUES (7, N'Long long', N'0372657743', N'12 Pho hang ma', N'Long@gmail.com')
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetail] ON 

INSERT [dbo].[OrderDetail] ([Id], [OrderId], [SachId], [Price], [Quantity]) VALUES (1, 1, 3, CAST(250000 AS Decimal(18, 0)), 2)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [SachId], [Price], [Quantity]) VALUES (2, 2, 3, CAST(125000 AS Decimal(18, 0)), 2)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [SachId], [Price], [Quantity]) VALUES (3, 1, 10, CAST(6000000 AS Decimal(18, 0)), 30)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [SachId], [Price], [Quantity]) VALUES (4, 4, 4, CAST(50000 AS Decimal(18, 0)), 1)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [SachId], [Price], [Quantity]) VALUES (5, 4, 5, CAST(500000 AS Decimal(18, 0)), 2)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [SachId], [Price], [Quantity]) VALUES (6, 4, 6, CAST(230000 AS Decimal(18, 0)), 2)
INSERT [dbo].[OrderDetail] ([Id], [OrderId], [SachId], [Price], [Quantity]) VALUES (13, 7, 7, CAST(28000 AS Decimal(18, 0)), 5)
SET IDENTITY_INSERT [dbo].[OrderDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[Sach] ON 

INSERT [dbo].[Sach] ([Id], [IdDanhMuc], [Name], [Quantity], [Price], [Description], [Images], [Status]) VALUES (1, 1, N'Walden', 1, CAST(1 AS Decimal(18, 0)), N'Walden', N'/Uploads/images/Walden.jpg', 1)
INSERT [dbo].[Sach] ([Id], [IdDanhMuc], [Name], [Quantity], [Price], [Description], [Images], [Status]) VALUES (2, 1, N'Bác sĩ Zhivago', 30, CAST(320000 AS Decimal(18, 0)), N'B&aacute;c sĩ Zhivago', N'/Uploads/images/BacSiZhivago.jpg', 1)
INSERT [dbo].[Sach] ([Id], [IdDanhMuc], [Name], [Quantity], [Price], [Description], [Images], [Status]) VALUES (3, 1, N'Kafka bên bờ biển', 15, CAST(125000 AS Decimal(18, 0)), N'Kafka b&ecirc;n bờ biển', N'/Uploads/images/KafkaBenBoBien.jpg', 1)
INSERT [dbo].[Sach] ([Id], [IdDanhMuc], [Name], [Quantity], [Price], [Description], [Images], [Status]) VALUES (4, 1, N'Giết con chim nhạn', 45, CAST(50000 AS Decimal(18, 0)), N'"Giết con chim nhạn"', N'/Uploads/images/Gietconchimnhan.png', 1)
INSERT [dbo].[Sach] ([Id], [IdDanhMuc], [Name], [Quantity], [Price], [Description], [Images], [Status]) VALUES (5, 1, N'Lolita', 5, CAST(500000 AS Decimal(18, 0)), N'Liệu "Lolita" của Vladimir Nabokov là một câu chuyện về thứ tình cảm trần trụi nhưng chung thủy đến tột cùng hay là một lời tố cáo sự suy đồi đạo đức trong xã hội?', N'/Uploads/images/Lolita.jpg', 1)
INSERT [dbo].[Sach] ([Id], [IdDanhMuc], [Name], [Quantity], [Price], [Description], [Images], [Status]) VALUES (6, 1, N'Một lít nước mắt', 50, CAST(230000 AS Decimal(18, 0)), N'"Một lít nước mắt"', N'/Uploads/images/motlitnuocmat01-7e3e698c-ae8d-4b37-8f36-8302d813f1af_1(1).png', 1)
INSERT [dbo].[Sach] ([Id], [IdDanhMuc], [Name], [Quantity], [Price], [Description], [Images], [Status]) VALUES (7, 1, N'Bay qua hồ gươm', 95, CAST(28000 AS Decimal(18, 0)), N'Bay qua hồ gươm', N'/Uploads/images/bay-qua-ho-guom-1-01.png', 1)
INSERT [dbo].[Sach] ([Id], [IdDanhMuc], [Name], [Quantity], [Price], [Description], [Images], [Status]) VALUES (8, 1, N'Năm tháng đằng đẵng chẳng có ngày nào thích hợp đi làm', 10, CAST(210000 AS Decimal(18, 0)), N'"Năm tháng đằng đẵng chẳng có ngày nào thích hợp đi làm"', N'/Uploads/images/nam-thang-dang-dang-chang-co-ngay-nao-thich-hop-di-lam-convert-01.png', 1)
INSERT [dbo].[Sach] ([Id], [IdDanhMuc], [Name], [Quantity], [Price], [Description], [Images], [Status]) VALUES (9, 5, N'Chúng sinh bình đẳng', 1, CAST(10920391 AS Decimal(18, 0)), N'Một chưởng b&igrave;nh thi&ecirc;n hạ', N'/Uploads/images/motchuongbinhthienha.png', 0)
INSERT [dbo].[Sach] ([Id], [IdDanhMuc], [Name], [Quantity], [Price], [Description], [Images], [Status]) VALUES (10, 4, N'40 Thế kỉ kiểm soát giá và tiền công', 120, CAST(200000 AS Decimal(18, 0)), N'40 Thế kỉ kiểm soát giá và tiền công', N'/Uploads/images/40thekikiemsoatgiavatiencong.jpg', 1)
INSERT [dbo].[Sach] ([Id], [IdDanhMuc], [Name], [Quantity], [Price], [Description], [Images], [Status]) VALUES (11, 4, N'Kinh tế học cơ bản', 12, CAST(120000 AS Decimal(18, 0)), N'Kinh tế học cơ bản', N'/Uploads/images/Kinhtehoccoban.jpg', 1)
INSERT [dbo].[Sach] ([Id], [IdDanhMuc], [Name], [Quantity], [Price], [Description], [Images], [Status]) VALUES (12, 4, N'Kinh tế học trần trụi: lột trần khoa học lệch lạc', 12, CAST(120000 AS Decimal(18, 0)), N'Kinh tế học trần trụi: lột trần khoa học lệch lạc', N'/Uploads/images/KinhtehoctrantruiLottrankhoahoclechlac.jpg', 1)
INSERT [dbo].[Sach] ([Id], [IdDanhMuc], [Name], [Quantity], [Price], [Description], [Images], [Status]) VALUES (13, 4, N'Người giàu theo quan điểm công chúng', 111, CAST(110000 AS Decimal(18, 0)), N'Người giàu theo quan điểm công chúng', N'/Uploads/images/Nguoigiautheoquandiemcongchung.jpg', 1)
INSERT [dbo].[Sach] ([Id], [IdDanhMuc], [Name], [Quantity], [Price], [Description], [Images], [Status]) VALUES (14, 4, N'Tài chính và xã hội tốt', 189, CAST(267300 AS Decimal(18, 0)), N'Tài chính và xã hội tốt', N'/Uploads/images/Taichinhvaxahoitot.jpg', 1)
INSERT [dbo].[Sach] ([Id], [IdDanhMuc], [Name], [Quantity], [Price], [Description], [Images], [Status]) VALUES (15, 4, N'Trường phái kinh tế học Áo', 210, CAST(321000 AS Decimal(18, 0)), N'Trường phái kinh tế học Áo', N'/Uploads/images/TruongphaikinhtehocAo.jpg', 1)
INSERT [dbo].[Sach] ([Id], [IdDanhMuc], [Name], [Quantity], [Price], [Description], [Images], [Status]) VALUES (16, 4, N'Cuộc chiến vi mạch', 150, CAST(311000 AS Decimal(18, 0)), N'Cuộc chiến vi mạch', N'/Uploads/images/cuocchienvimachbiacung01scaled.png', 1)
INSERT [dbo].[Sach] ([Id], [IdDanhMuc], [Name], [Quantity], [Price], [Description], [Images], [Status]) VALUES (17, 4, N'Người giàu nhất thành Babylon', 300, CAST(360000 AS Decimal(18, 0)), N'Người gi&agrave;u nhất th&agrave;nh Babylon', N'/Uploads/images/Nguoigiaunhatthanhbabylon.jpg', 1)
INSERT [dbo].[Sach] ([Id], [IdDanhMuc], [Name], [Quantity], [Price], [Description], [Images], [Status]) VALUES (18, 3, N'Điểm bùng phát', 34, CAST(120000 AS Decimal(18, 0)), N'Điểm b&ugrave;ng ph&aacute;t', N'/Uploads/images/DiemBungpHat.png', 1)
INSERT [dbo].[Sach] ([Id], [IdDanhMuc], [Name], [Quantity], [Price], [Description], [Images], [Status]) VALUES (19, 3, N'Giao Tiếp Bất Kì Ai', 53, CAST(570000 AS Decimal(18, 0)), N'Giao Tiếp Bất K&igrave; Ai', N'/Uploads/images/GiaoTiepBatKyAi.jpg', 1)
INSERT [dbo].[Sach] ([Id], [IdDanhMuc], [Name], [Quantity], [Price], [Description], [Images], [Status]) VALUES (20, 3, N'Hiểu hết về tâm lý', 96, CAST(431000 AS Decimal(18, 0)), N'Hiểu hết về t&acirc;m l&yacute;', N'/Uploads/images/HieuHetVeTamLyHoc.jpg', 1)
INSERT [dbo].[Sach] ([Id], [IdDanhMuc], [Name], [Quantity], [Price], [Description], [Images], [Status]) VALUES (21, 3, N'Kiếp nào ta cũng nhìn thấy nhau', 5, CAST(500001 AS Decimal(18, 0)), N'Kiếp n&agrave;o ta cũng nh&igrave;n thấy nhau', N'/Uploads/images/KiepNaoTaCungNhinThayNhau.jpg', 1)
INSERT [dbo].[Sach] ([Id], [IdDanhMuc], [Name], [Quantity], [Price], [Description], [Images], [Status]) VALUES (22, 3, N'Những đòn tâm lý thuyết phục', 50, CAST(110000 AS Decimal(18, 0)), N'Những đ&ograve;n t&acirc;m l&yacute; thuyết phục', N'/Uploads/images/NhungDonTamLyThuyetPhuc.png', 1)
INSERT [dbo].[Sach] ([Id], [IdDanhMuc], [Name], [Quantity], [Price], [Description], [Images], [Status]) VALUES (23, 3, N'Phi lý trí', 20, CAST(200000 AS Decimal(18, 0)), N'Phi l&yacute; tr&iacute;', N'/Uploads/images/PhiLyTri.jpg', 1)
INSERT [dbo].[Sach] ([Id], [IdDanhMuc], [Name], [Quantity], [Price], [Description], [Images], [Status]) VALUES (24, 3, N'Sức mạnh của hiện tại', 120, CAST(88000 AS Decimal(18, 0)), N'Sức mạnh của hiện tại', N'/Uploads/images/SucManhCuaHienTai.png', 1)
INSERT [dbo].[Sach] ([Id], [IdDanhMuc], [Name], [Quantity], [Price], [Description], [Images], [Status]) VALUES (25, 3, N'Sức mạnh của thói quen', 20, CAST(65500 AS Decimal(18, 0)), N'Sức mạnh của th&oacute;i quen', N'/Uploads/images/SucManhCuaThoiQuen.png', 1)
INSERT [dbo].[Sach] ([Id], [IdDanhMuc], [Name], [Quantity], [Price], [Description], [Images], [Status]) VALUES (26, 3, N'Tư duy nhanh và chậm', 250, CAST(250000 AS Decimal(18, 0)), N'Tư duy nhanh v&agrave; chậm', N'/Uploads/images/TuDuyNhanhVaCham.png', 1)
SET IDENTITY_INSERT [dbo].[Sach] OFF
GO
SET IDENTITY_INSERT [dbo].[Slide] ON 

INSERT [dbo].[Slide] ([Id], [Images]) VALUES (1, N'/Uploads/images/slide.jpg')
INSERT [dbo].[Slide] ([Id], [Images]) VALUES (2, N'https://bizweb.dktcdn.net/100/363/455/articles/website-a-nh-da-i-die-n-ba-i-vie-t-17.png?v=1714815417920')
INSERT [dbo].[Slide] ([Id], [Images]) VALUES (3, N'/Uploads/images/news.png')
INSERT [dbo].[Slide] ([Id], [Images]) VALUES (5, N'/Uploads/images/pha-n-2-ca-y-cam-ngo-t-cu-a-to-i.png')
INSERT [dbo].[Slide] ([Id], [Images]) VALUES (6, N'/Uploads/images/seo-2.png')
INSERT [dbo].[Slide] ([Id], [Images]) VALUES (7, N'/Uploads/images/website-a-nh-da-i-die-n-ba-i-vie-t-17.png')
SET IDENTITY_INSERT [dbo].[Slide] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Name], [Email], [Password], [Status], [Role]) VALUES (1005, N'Lực', N'Luc123@gmail.com                                                                                              ', N'123                                               ', 1, 1)
INSERT [dbo].[User] ([Id], [Name], [Email], [Password], [Status], [Role]) VALUES (1008, N'Đinh Tiến Long', N'l@m.com                                                                                                       ', N'123                                               ', 1, 0)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF_User_Role]  DEFAULT ((0)) FOR [Role]
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK_Cart_Sach1] FOREIGN KEY([IdSach])
REFERENCES [dbo].[Sach] ([Id])
GO
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK_Cart_Sach1]
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK_Cart_User1] FOREIGN KEY([IdUser])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK_Cart_User1]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Sach] FOREIGN KEY([SachId])
REFERENCES [dbo].[Sach] ([Id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Sach]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_DanhMucSach1] FOREIGN KEY([IdDanhMuc])
REFERENCES [dbo].[DanhMucSach] ([Id])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_DanhMucSach1]
GO
USE [master]
GO
ALTER DATABASE [K22CNT4-TTCD1-DinhTienLuc] SET  READ_WRITE 
GO
