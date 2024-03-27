USE [master]
GO
/****** Object:  Database [QLdienthoai]    Script Date: 18/09/2021 9:52:44 CH ******/
CREATE DATABASE [QLdienthoai2]
 CONTAINMENT = NONE

ALTER DATABASE [QLdienthoai2] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLdienthoai].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLdienthoai2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLdienthoai2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLdienthoai2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLdienthoai2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLdienthoai2] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLdienthoai2] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QLdienthoai2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLdienthoai2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLdienthoai2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLdienthoai2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLdienthoai2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLdienthoai2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLdienthoai2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLdienthoai2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLdienthoai2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLdienthoai2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLdienthoai2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLdienthoai2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLdienthoai2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLdienthoai2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLdienthoai2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLdienthoai2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLdienthoai2] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLdienthoai2] SET  MULTI_USER 
GO
ALTER DATABASE [QLdienthoai2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLdienthoai2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLdienthoai2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLdienthoai2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLdienthoai2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QLdienthoai2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [QLdienthoai2] SET QUERY_STORE = OFF
GO
USE [QLdienthoai2]
GO
/****** Object:  Table [dbo].[Chitietdonhang]    Script Date: 18/09/2021 9:52:44 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chitietdonhang](
	[Madon] [int] NOT NULL,
	[Masp] [int] NOT NULL,
	[Soluong] [int] NULL,
	[Dongia] [decimal](18, 0) NULL,
	[Thanhtien] [decimal](18, 0) NULL,
	[Phuongthucthanhtoan] [int] NULL,
 CONSTRAINT [PK_Chitietdonhang] PRIMARY KEY CLUSTERED 
(
	[Madon] ASC,
	[Masp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Donhang]    Script Date: 18/09/2021 9:52:44 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Donhang](
	[Madon] [int] IDENTITY(1,1) NOT NULL,
	[Ngaydat] [datetime] NULL,
	[Tinhtrang] [int] NULL,
	[MaNguoidung] [int] NULL,
	[Thanhtoan] [int] NULL,
	[Diachinhanhang] [nvarchar](100) NULL,
	[Tongtien] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Donhang] PRIMARY KEY CLUSTERED 
(
	[Madon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hangsanxuat]    Script Date: 18/09/2021 9:52:44 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hangsanxuat](
	[Mahang] [int] IDENTITY(1,1) NOT NULL,
	[Tenhang] [nchar](10) NULL,
 CONSTRAINT [PK_Hangsanxuat] PRIMARY KEY CLUSTERED 
(
	[Mahang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hedieuhanh]    Script Date: 18/09/2021 9:52:44 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hedieuhanh](
	[Mahdh] [int] IDENTITY(1,1) NOT NULL,
	[Tenhdh] [nchar](10) NULL,
 CONSTRAINT [PK_Hedieuhanh] PRIMARY KEY CLUSTERED 
(
	[Mahdh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nguoidung]    Script Date: 18/09/2021 9:52:44 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nguoidung](
	[MaNguoiDung] [int] IDENTITY(1,1) NOT NULL,
	[Hoten] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Dienthoai] [nchar](10) NULL,
	[Matkhau] [varchar](50) NULL,
	[IDQuyen] [int] NULL,
	[Diachi] [nvarchar](100) NULL,
	[Anhdaidien] [nchar](30) NULL,
 CONSTRAINT [PK_Khachhang] PRIMARY KEY CLUSTERED 
(
	[MaNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanQuyen]    Script Date: 18/09/2021 9:52:44 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanQuyen](
	[IDQuyen] [int] IDENTITY(1,1) NOT NULL,
	[TenQuyen] [nvarchar](20) NULL,
 CONSTRAINT [PK_PhanQuyen] PRIMARY KEY CLUSTERED 
(
	[IDQuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sanpham]    Script Date: 18/09/2021 9:52:44 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sanpham](
	[Masp] [int] IDENTITY(1,1) NOT NULL,
	[Tensp] [nvarchar](50) NULL,
	[Giatien] [decimal](18, 0) NULL,
	[Soluong] [int] NULL,
	[Mota] [ntext] NULL,
	[Thesim] [int] NULL,
	[Bonhotrong] [int] NULL,
	[Sanphammoi] [bit] NULL,
	[Ram] [int] NULL,
	[Anhbia] [nvarchar](50) NULL,
	[Mahang] [int] NULL,
	[Mahdh] [int] NULL,
 CONSTRAINT [PK_Sanpham] PRIMARY KEY CLUSTERED 
(
	[Masp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[Chitietdonhang] ([Madon], [Masp], [Soluong], [Dongia], [Thanhtien], [Phuongthucthanhtoan]) VALUES (24, 2, 1, CAST(2000000 AS Decimal(18, 0)), CAST(2000000 AS Decimal(18, 0)), 1)
INSERT [dbo].[Chitietdonhang] ([Madon], [Masp], [Soluong], [Dongia], [Thanhtien], [Phuongthucthanhtoan]) VALUES (24, 5, 1, CAST(2000000 AS Decimal(18, 0)), CAST(2000000 AS Decimal(18, 0)), 1)
INSERT [dbo].[Chitietdonhang] ([Madon], [Masp], [Soluong], [Dongia], [Thanhtien], [Phuongthucthanhtoan]) VALUES (25, 2, 5, CAST(2000000 AS Decimal(18, 0)), CAST(10000000 AS Decimal(18, 0)), 1)
INSERT [dbo].[Chitietdonhang] ([Madon], [Masp], [Soluong], [Dongia], [Thanhtien], [Phuongthucthanhtoan]) VALUES (25, 5, 1, CAST(2000000 AS Decimal(18, 0)), CAST(2000000 AS Decimal(18, 0)), 1)
INSERT [dbo].[Chitietdonhang] ([Madon], [Masp], [Soluong], [Dongia], [Thanhtien], [Phuongthucthanhtoan]) VALUES (26, 2, 3, CAST(2000000 AS Decimal(18, 0)), CAST(6000000 AS Decimal(18, 0)), 1)
INSERT [dbo].[Chitietdonhang] ([Madon], [Masp], [Soluong], [Dongia], [Thanhtien], [Phuongthucthanhtoan]) VALUES (26, 5, 1, CAST(2000000 AS Decimal(18, 0)), CAST(2000000 AS Decimal(18, 0)), 1)
INSERT [dbo].[Chitietdonhang] ([Madon], [Masp], [Soluong], [Dongia], [Thanhtien], [Phuongthucthanhtoan]) VALUES (27, 2, 3, CAST(2000000 AS Decimal(18, 0)), CAST(6000000 AS Decimal(18, 0)), 1)
INSERT [dbo].[Chitietdonhang] ([Madon], [Masp], [Soluong], [Dongia], [Thanhtien], [Phuongthucthanhtoan]) VALUES (27, 5, 1, CAST(2000000 AS Decimal(18, 0)), CAST(2000000 AS Decimal(18, 0)), 1)
INSERT [dbo].[Chitietdonhang] ([Madon], [Masp], [Soluong], [Dongia], [Thanhtien], [Phuongthucthanhtoan]) VALUES (28, 2, 1, CAST(2000000 AS Decimal(18, 0)), CAST(2000000 AS Decimal(18, 0)), 1)
INSERT [dbo].[Chitietdonhang] ([Madon], [Masp], [Soluong], [Dongia], [Thanhtien], [Phuongthucthanhtoan]) VALUES (28, 5, 1, CAST(2000000 AS Decimal(18, 0)), CAST(2000000 AS Decimal(18, 0)), 1)
INSERT [dbo].[Chitietdonhang] ([Madon], [Masp], [Soluong], [Dongia], [Thanhtien], [Phuongthucthanhtoan]) VALUES (29, 2, 1, CAST(2000000 AS Decimal(18, 0)), CAST(2000000 AS Decimal(18, 0)), 1)
INSERT [dbo].[Chitietdonhang] ([Madon], [Masp], [Soluong], [Dongia], [Thanhtien], [Phuongthucthanhtoan]) VALUES (30, 2, 10, CAST(2000000 AS Decimal(18, 0)), CAST(20000000 AS Decimal(18, 0)), 1)
INSERT [dbo].[Chitietdonhang] ([Madon], [Masp], [Soluong], [Dongia], [Thanhtien], [Phuongthucthanhtoan]) VALUES (30, 5, 1, CAST(2000000 AS Decimal(18, 0)), CAST(2000000 AS Decimal(18, 0)), 1)
INSERT [dbo].[Chitietdonhang] ([Madon], [Masp], [Soluong], [Dongia], [Thanhtien], [Phuongthucthanhtoan]) VALUES (31, 2, 10, CAST(2000000 AS Decimal(18, 0)), CAST(20000000 AS Decimal(18, 0)), 1)
INSERT [dbo].[Chitietdonhang] ([Madon], [Masp], [Soluong], [Dongia], [Thanhtien], [Phuongthucthanhtoan]) VALUES (31, 5, 1, CAST(2000000 AS Decimal(18, 0)), CAST(2000000 AS Decimal(18, 0)), 1)
INSERT [dbo].[Chitietdonhang] ([Madon], [Masp], [Soluong], [Dongia], [Thanhtien], [Phuongthucthanhtoan]) VALUES (32, 9, 2, CAST(1000000 AS Decimal(18, 0)), CAST(2000000 AS Decimal(18, 0)), 1)
GO
SET IDENTITY_INSERT [dbo].[Donhang] ON 

INSERT [dbo].[Donhang] ([Madon], [Ngaydat], [Tinhtrang], [MaNguoidung], [Thanhtoan], [Diachinhanhang], [Tongtien]) VALUES (24, CAST(N'2021-09-18T14:59:42.090' AS DateTime), 1, 16, 1, N'TP BD', CAST(4000000 AS Decimal(18, 0)))
INSERT [dbo].[Donhang] ([Madon], [Ngaydat], [Tinhtrang], [MaNguoidung], [Thanhtoan], [Diachinhanhang], [Tongtien]) VALUES (25, CAST(N'2021-09-18T15:03:47.463' AS DateTime), 1, 15, 1, N'TP BD', CAST(12000000 AS Decimal(18, 0)))
INSERT [dbo].[Donhang] ([Madon], [Ngaydat], [Tinhtrang], [MaNguoidung], [Thanhtoan], [Diachinhanhang], [Tongtien]) VALUES (26, CAST(N'2021-09-18T15:04:01.733' AS DateTime), NULL, 15, 1, N'TP BD', CAST(8000000 AS Decimal(18, 0)))
INSERT [dbo].[Donhang] ([Madon], [Ngaydat], [Tinhtrang], [MaNguoidung], [Thanhtoan], [Diachinhanhang], [Tongtien]) VALUES (27, CAST(N'2021-09-18T15:04:23.733' AS DateTime), NULL, 15, 1, N'TP BD', CAST(8000000 AS Decimal(18, 0)))
INSERT [dbo].[Donhang] ([Madon], [Ngaydat], [Tinhtrang], [MaNguoidung], [Thanhtoan], [Diachinhanhang], [Tongtien]) VALUES (28, CAST(N'2021-09-18T15:04:57.770' AS DateTime), NULL, 16, 1, N'TP BD', CAST(4000000 AS Decimal(18, 0)))
INSERT [dbo].[Donhang] ([Madon], [Ngaydat], [Tinhtrang], [MaNguoidung], [Thanhtoan], [Diachinhanhang], [Tongtien]) VALUES (29, CAST(N'2021-09-18T15:05:21.277' AS DateTime), NULL, 36, 1, N'TP BD', CAST(2000000 AS Decimal(18, 0)))
INSERT [dbo].[Donhang] ([Madon], [Ngaydat], [Tinhtrang], [MaNguoidung], [Thanhtoan], [Diachinhanhang], [Tongtien]) VALUES (30, CAST(N'2021-09-18T17:18:36.577' AS DateTime), NULL, 36, 1, N'TPBD', CAST(22000000 AS Decimal(18, 0)))
INSERT [dbo].[Donhang] ([Madon], [Ngaydat], [Tinhtrang], [MaNguoidung], [Thanhtoan], [Diachinhanhang], [Tongtien]) VALUES (31, CAST(N'2021-09-18T17:18:50.487' AS DateTime), NULL, 36, 1, N'h', CAST(22000000 AS Decimal(18, 0)))
INSERT [dbo].[Donhang] ([Madon], [Ngaydat], [Tinhtrang], [MaNguoidung], [Thanhtoan], [Diachinhanhang], [Tongtien]) VALUES (32, CAST(N'2021-09-18T21:48:55.610' AS DateTime), 1, 16, 1, N'TP BD', CAST(2000000 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Donhang] OFF
GO
SET IDENTITY_INSERT [dbo].[Hangsanxuat] ON 

INSERT [dbo].[Hangsanxuat] ([Mahang], [Tenhang]) VALUES (1, N'Sam Sung  ')
INSERT [dbo].[Hangsanxuat] ([Mahang], [Tenhang]) VALUES (2, N'Apple     ')
INSERT [dbo].[Hangsanxuat] ([Mahang], [Tenhang]) VALUES (3, N'Xiaomi    ')
INSERT [dbo].[Hangsanxuat] ([Mahang], [Tenhang]) VALUES (4, N'Vsmart    ')
INSERT [dbo].[Hangsanxuat] ([Mahang], [Tenhang]) VALUES (5, N'Bphone    ')
SET IDENTITY_INSERT [dbo].[Hangsanxuat] OFF
GO
SET IDENTITY_INSERT [dbo].[Hedieuhanh] ON 

INSERT [dbo].[Hedieuhanh] ([Mahdh], [Tenhdh]) VALUES (1, N'Android   ')
INSERT [dbo].[Hedieuhanh] ([Mahdh], [Tenhdh]) VALUES (2, N'IOS       ')
INSERT [dbo].[Hedieuhanh] ([Mahdh], [Tenhdh]) VALUES (3, N'VOS       ')
SET IDENTITY_INSERT [dbo].[Hedieuhanh] OFF
GO
SET IDENTITY_INSERT [dbo].[Nguoidung] ON 

INSERT [dbo].[Nguoidung] ([MaNguoiDung], [Hoten], [Email], [Dienthoai], [Matkhau], [IDQuyen], [Diachi], [Anhdaidien]) VALUES (14, N'Man tran admin', N'Admin@gmail.com', N'0812883636', N'12345678', 2, N'B�nh d??ng', N'/Images/files/ip3.jpg         ')
INSERT [dbo].[Nguoidung] ([MaNguoiDung], [Hoten], [Email], [Dienthoai], [Matkhau], [IDQuyen], [Diachi], [Anhdaidien]) VALUES (15, N'test', N'test@gmail.com', N'0812883636', N'12345678', 1, NULL, N'/Images/files/avt4.jpg        ')
INSERT [dbo].[Nguoidung] ([MaNguoiDung], [Hoten], [Email], [Dienthoai], [Matkhau], [IDQuyen], [Diachi], [Anhdaidien]) VALUES (16, N'H? t�n 11', N'Khach@gmail.com', N'0812883636', N'12345678', NULL, N'B�nh d??ng', N'/Images/files/avt3.jpg        ')
INSERT [dbo].[Nguoidung] ([MaNguoiDung], [Hoten], [Email], [Dienthoai], [Matkhau], [IDQuyen], [Diachi], [Anhdaidien]) VALUES (36, N'mantran', N'mantran@gmail.com', N'0812883637', N'12345678', 1, NULL, NULL)
INSERT [dbo].[Nguoidung] ([MaNguoiDung], [Hoten], [Email], [Dienthoai], [Matkhau], [IDQuyen], [Diachi], [Anhdaidien]) VALUES (39, N'Nguy?n V?n A', N'testa@gmail.com', N'0812883636', N'12345678', 1, NULL, NULL)
INSERT [dbo].[Nguoidung] ([MaNguoiDung], [Hoten], [Email], [Dienthoai], [Matkhau], [IDQuyen], [Diachi], [Anhdaidien]) VALUES (41, N'Nguy?n V?n B', N'tetsb@gmail.com', N'0812883636', N'12345678', 1, NULL, NULL)
INSERT [dbo].[Nguoidung] ([MaNguoiDung], [Hoten], [Email], [Dienthoai], [Matkhau], [IDQuyen], [Diachi], [Anhdaidien]) VALUES (42, N'Nguy?n V?n C', N'testc@gmail.com', N'0812883636', N'12345678', 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Nguoidung] OFF
GO
SET IDENTITY_INSERT [dbo].[PhanQuyen] ON 

INSERT [dbo].[PhanQuyen] ([IDQuyen], [TenQuyen]) VALUES (1, N'Member')
INSERT [dbo].[PhanQuyen] ([IDQuyen], [TenQuyen]) VALUES (2, N'Admin')
SET IDENTITY_INSERT [dbo].[PhanQuyen] OFF
GO
SET IDENTITY_INSERT [dbo].[Sanpham] ON 

INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Giatien], [Soluong], [Mota], [Thesim], [Bonhotrong], [Sanphammoi], [Ram], [Anhbia], [Mahang], [Mahdh]) VALUES (2, N'Apple Iphone 3', CAST(2000000 AS Decimal(18, 0)), 9, N'Apple Iphone 3', 1, 8, 0, 8, N'/Images/files/ip3.jpg', 2, 2)
INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Giatien], [Soluong], [Mota], [Thesim], [Bonhotrong], [Sanphammoi], [Ram], [Anhbia], [Mahang], [Mahdh]) VALUES (5, N'Apple Iphone 4', CAST(2000000 AS Decimal(18, 0)), 10, N'Apple Iphone 4', 1, 8, 0, 1, N'/Images/files/ip4.jpg', 2, 2)
INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Giatien], [Soluong], [Mota], [Thesim], [Bonhotrong], [Sanphammoi], [Ram], [Anhbia], [Mahang], [Mahdh]) VALUES (6, N'Apple Iphone 5', CAST(2000000 AS Decimal(18, 0)), 10, N'Apple Iphone 5', 1, 8, 0, 1, N'/Images/files/ip5.jpg', 2, 2)
INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Giatien], [Soluong], [Mota], [Thesim], [Bonhotrong], [Sanphammoi], [Ram], [Anhbia], [Mahang], [Mahdh]) VALUES (7, N'Apple Iphone 6', CAST(2000000 AS Decimal(18, 0)), 2, N'Apple Iphone 6', 1, 8, 0, 1, N'/Images/files/ip6.jpg', 2, 2)
INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Giatien], [Soluong], [Mota], [Thesim], [Bonhotrong], [Sanphammoi], [Ram], [Anhbia], [Mahang], [Mahdh]) VALUES (8, N'SamSung GalaxyS1', CAST(1000000 AS Decimal(18, 0)), 1, N'SamSung GalaxyS1', 2, 8, 0, 2, N'/Images/files/ss1.jpg', 1, 1)
INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Giatien], [Soluong], [Mota], [Thesim], [Bonhotrong], [Sanphammoi], [Ram], [Anhbia], [Mahang], [Mahdh]) VALUES (9, N'SamSung GalaxyS2', CAST(1000000 AS Decimal(18, 0)), 1, N'SamSung GalaxyS2', 1, 8, 0, 1, N'/Images/files/ss2.jpg', 1, 1)
INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Giatien], [Soluong], [Mota], [Thesim], [Bonhotrong], [Sanphammoi], [Ram], [Anhbia], [Mahang], [Mahdh]) VALUES (10, N'SamSung GalaxyS3', CAST(2000000 AS Decimal(18, 0)), 1, N'SamSung GalaxyS3', 1, 8, 0, 2, N'/Images/files/ss3.jpg', 1, 1)
INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Giatien], [Soluong], [Mota], [Thesim], [Bonhotrong], [Sanphammoi], [Ram], [Anhbia], [Mahang], [Mahdh]) VALUES (11, N'SamSung GalaxyS4', CAST(2000000 AS Decimal(18, 0)), 2, N'SamSung GalaxyS4', 2, 8, 0, 2, N'/Images/files/ss4.jpg', 1, 1)
INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Giatien], [Soluong], [Mota], [Thesim], [Bonhotrong], [Sanphammoi], [Ram], [Anhbia], [Mahang], [Mahdh]) VALUES (13, N'Xiaomi mi4', CAST(200000 AS Decimal(18, 0)), 10, N'Xiaomi mi4', 2, 8, 0, 4, N'/Images/files/mi4.jpg', 3, 1)
INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Giatien], [Soluong], [Mota], [Thesim], [Bonhotrong], [Sanphammoi], [Ram], [Anhbia], [Mahang], [Mahdh]) VALUES (14, N'Xiaomi mi5', CAST(2000000 AS Decimal(18, 0)), 10, N'Xiaomi mi5', 2, 16, 0, 6, N'/Images/files/mi5.jpg', 3, 1)
INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Giatien], [Soluong], [Mota], [Thesim], [Bonhotrong], [Sanphammoi], [Ram], [Anhbia], [Mahang], [Mahdh]) VALUES (15, N'Xiaomi mi6', CAST(20000 AS Decimal(18, 0)), 10, N'Xiaomi mi6', 2, 8, 0, 6, N'/Images/files/mi6.jpg', 3, 1)
INSERT [dbo].[Sanpham] ([Masp], [Tensp], [Giatien], [Soluong], [Mota], [Thesim], [Bonhotrong], [Sanphammoi], [Ram], [Anhbia], [Mahang], [Mahdh]) VALUES (16, N'Xiaomi mi7', CAST(200000 AS Decimal(18, 0)), 10, N'Mi7', 2, 8, 0, 2, N'/Images/files/mi7.jpg', 3, 1)
SET IDENTITY_INSERT [dbo].[Sanpham] OFF
GO
ALTER TABLE [dbo].[Nguoidung] ADD  CONSTRAINT [DF_Nguoidung_IDQuyen]  DEFAULT ((0)) FOR [IDQuyen]
GO
ALTER TABLE [dbo].[Chitietdonhang]  WITH CHECK ADD  CONSTRAINT [FK_Chitietdonhang_Donhang] FOREIGN KEY([Madon])
REFERENCES [dbo].[Donhang] ([Madon])
GO
ALTER TABLE [dbo].[Chitietdonhang] CHECK CONSTRAINT [FK_Chitietdonhang_Donhang]
GO
ALTER TABLE [dbo].[Chitietdonhang]  WITH CHECK ADD  CONSTRAINT [FK_Chitietdonhang_Sanpham] FOREIGN KEY([Masp])
REFERENCES [dbo].[Sanpham] ([Masp])
GO
ALTER TABLE [dbo].[Chitietdonhang] CHECK CONSTRAINT [FK_Chitietdonhang_Sanpham]
GO
ALTER TABLE [dbo].[Donhang]  WITH CHECK ADD  CONSTRAINT [FK_Donhang_Khachhang] FOREIGN KEY([MaNguoidung])
REFERENCES [dbo].[Nguoidung] ([MaNguoiDung])
GO
ALTER TABLE [dbo].[Donhang] CHECK CONSTRAINT [FK_Donhang_Khachhang]
GO
ALTER TABLE [dbo].[Nguoidung]  WITH CHECK ADD  CONSTRAINT [FK_Nguoidung_Nguoidung] FOREIGN KEY([IDQuyen])
REFERENCES [dbo].[PhanQuyen] ([IDQuyen])
GO
ALTER TABLE [dbo].[Nguoidung] CHECK CONSTRAINT [FK_Nguoidung_Nguoidung]
GO
ALTER TABLE [dbo].[Sanpham]  WITH CHECK ADD  CONSTRAINT [FK_Sanpham_Hangsanxuat] FOREIGN KEY([Mahang])
REFERENCES [dbo].[Hangsanxuat] ([Mahang])
GO
ALTER TABLE [dbo].[Sanpham] CHECK CONSTRAINT [FK_Sanpham_Hangsanxuat]
GO
ALTER TABLE [dbo].[Sanpham]  WITH CHECK ADD  CONSTRAINT [FK_Sanpham_Hedieuhanh] FOREIGN KEY([Mahdh])
REFERENCES [dbo].[Hedieuhanh] ([Mahdh])
GO
ALTER TABLE [dbo].[Sanpham] CHECK CONSTRAINT [FK_Sanpham_Hedieuhanh]
GO
USE [master]
GO
ALTER DATABASE [QLdienthoai2] SET  READ_WRITE 
