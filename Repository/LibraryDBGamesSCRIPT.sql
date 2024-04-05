USE [LibraryGamesDB]
GO
ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK__Products__Suppli__4F7CD00D]
GO
ALTER TABLE [dbo].[Entrace] DROP CONSTRAINT [FK__Entrace__Supplie__534D60F1]
GO
ALTER TABLE [dbo].[Entrace] DROP CONSTRAINT [FK__Entrace__Product__52593CB8]
GO
ALTER TABLE [dbo].[Departures] DROP CONSTRAINT [FK__Departure__Produ__5629CD9C]
GO
ALTER TABLE [dbo].[Departures] DROP CONSTRAINT [FK__Departure__Emplo__571DF1D5]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 4/4/2024 22:25:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Suppliers]') AND type in (N'U'))
DROP TABLE [dbo].[Suppliers]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 4/4/2024 22:25:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Products]') AND type in (N'U'))
DROP TABLE [dbo].[Products]
GO
/****** Object:  Table [dbo].[Entrace]    Script Date: 4/4/2024 22:25:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Entrace]') AND type in (N'U'))
DROP TABLE [dbo].[Entrace]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 4/4/2024 22:25:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employees]') AND type in (N'U'))
DROP TABLE [dbo].[Employees]
GO
/****** Object:  Table [dbo].[Departures]    Script Date: 4/4/2024 22:25:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Departures]') AND type in (N'U'))
DROP TABLE [dbo].[Departures]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 4/4/2024 22:25:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers]') AND type in (N'U'))
DROP TABLE [dbo].[Customers]
GO
USE [master]
GO
/****** Object:  Database [LibraryGamesDB]    Script Date: 4/4/2024 22:25:35 ******/
DROP DATABASE [LibraryGamesDB]
GO
/****** Object:  Database [LibraryGamesDB]    Script Date: 4/4/2024 22:25:35 ******/
CREATE DATABASE [LibraryGamesDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LibraryGamesDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\LibraryGamesDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LibraryGamesDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\LibraryGamesDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [LibraryGamesDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LibraryGamesDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LibraryGamesDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LibraryGamesDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LibraryGamesDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LibraryGamesDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LibraryGamesDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [LibraryGamesDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [LibraryGamesDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LibraryGamesDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LibraryGamesDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LibraryGamesDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LibraryGamesDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LibraryGamesDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LibraryGamesDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LibraryGamesDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LibraryGamesDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [LibraryGamesDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LibraryGamesDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LibraryGamesDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LibraryGamesDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LibraryGamesDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LibraryGamesDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LibraryGamesDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LibraryGamesDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [LibraryGamesDB] SET  MULTI_USER 
GO
ALTER DATABASE [LibraryGamesDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LibraryGamesDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LibraryGamesDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LibraryGamesDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LibraryGamesDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [LibraryGamesDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [LibraryGamesDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [LibraryGamesDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [LibraryGamesDB]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 4/4/2024 22:25:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CName] [varchar](255) NULL,
	[Email] [varchar](255) NULL,
	[Phone] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departures]    Script Date: 4/4/2024 22:25:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departures](
	[SaleDetailID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NULL,
	[EmployeeID] [int] NULL,
	[Quantity] [int] NULL,
	[UnitPrice] [decimal](10, 2) NULL,
	[Total] [money] NULL,
	[DDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[SaleDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 4/4/2024 22:25:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[EName] [varchar](255) NULL,
	[Lastname] [varchar](255) NULL,
	[Email] [varchar](255) NULL,
	[Phone] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entrace]    Script Date: 4/4/2024 22:25:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entrace](
	[PurchaseDetailID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NULL,
	[SupplierID] [int] NULL,
	[Quantity] [int] NULL,
	[UnitPrice] [decimal](10, 2) NULL,
	[Total] [money] NULL,
	[EDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[PurchaseDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 4/4/2024 22:25:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[PName] [varchar](255) NULL,
	[PDescription] [varchar](255) NULL,
	[Price] [money] NULL,
	[Stock] [int] NULL,
	[SupplierID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Suppliers]    Script Date: 4/4/2024 22:25:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Suppliers](
	[SupplierID] [int] IDENTITY(1,1) NOT NULL,
	[SName] [varchar](255) NULL,
	[SAddress] [varchar](255) NULL,
	[Phone] [varchar](20) NULL,
	[Email] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Departures]  WITH CHECK ADD FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([EmployeeID])
GO
ALTER TABLE [dbo].[Departures]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Entrace]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Entrace]  WITH CHECK ADD FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Suppliers] ([SupplierID])
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD FOREIGN KEY([SupplierID])
REFERENCES [dbo].[Suppliers] ([SupplierID])
GO
USE [master]
GO
ALTER DATABASE [LibraryGamesDB] SET  READ_WRITE 
GO
