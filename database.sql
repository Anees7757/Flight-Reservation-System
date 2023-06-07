USE [master]
GO
/****** Object:  Database [Flight Reservation System]    Script Date: 6/7/2023 10:19:41 PM ******/
CREATE DATABASE [Flight Reservation System]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Flight Reservation System', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Flight Reservation System.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Flight Reservation System_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Flight Reservation System_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Flight Reservation System] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Flight Reservation System].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Flight Reservation System] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Flight Reservation System] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Flight Reservation System] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Flight Reservation System] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Flight Reservation System] SET ARITHABORT OFF 
GO
ALTER DATABASE [Flight Reservation System] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Flight Reservation System] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Flight Reservation System] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Flight Reservation System] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Flight Reservation System] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Flight Reservation System] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Flight Reservation System] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Flight Reservation System] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Flight Reservation System] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Flight Reservation System] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Flight Reservation System] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Flight Reservation System] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Flight Reservation System] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Flight Reservation System] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Flight Reservation System] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Flight Reservation System] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Flight Reservation System] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Flight Reservation System] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Flight Reservation System] SET  MULTI_USER 
GO
ALTER DATABASE [Flight Reservation System] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Flight Reservation System] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Flight Reservation System] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Flight Reservation System] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Flight Reservation System] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Flight Reservation System] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Flight Reservation System] SET QUERY_STORE = OFF
GO
USE [Flight Reservation System]
GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 6/7/2023 10:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Flight Id] [int] NULL,
	[User Id] [int] NULL,
	[Departure] [varchar](50) NOT NULL,
	[Arival] [varchar](50) NOT NULL,
	[Departure Date] [varchar](50) NOT NULL,
	[Return Date] [varchar](50) NULL,
	[Passengers] [varchar](50) NOT NULL,
	[Cabin] [varchar](50) NOT NULL,
	[Flight Type] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flight]    Script Date: 6/7/2023 10:20:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flight](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Flight No] [varchar](50) NOT NULL,
	[Departure] [varchar](50) NOT NULL,
	[Arival] [varchar](50) NOT NULL,
	[depDate] [varchar](50) NULL,
	[AriDate] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/7/2023 10:20:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](20) NOT NULL,
	[Gender] [varchar](20) NOT NULL,
	[Passport_Number] [varchar](50) NOT NULL,
	[DOB] [varchar](50) NOT NULL,
	[Nationality] [varchar](50) NOT NULL,
	[Email_Type] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Phone_Type] [varchar](50) NOT NULL,
	[Phone_Number] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[Address] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[isLoggedIn] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD FOREIGN KEY([Flight Id])
REFERENCES [dbo].[Flight] ([Id])
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD FOREIGN KEY([User Id])
REFERENCES [dbo].[Users] ([Id])
GO
USE [master]
GO
ALTER DATABASE [Flight Reservation System] SET  READ_WRITE 
GO
