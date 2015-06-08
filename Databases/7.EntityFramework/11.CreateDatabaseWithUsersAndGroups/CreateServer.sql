﻿USE [master]
GO
/****** Object: Database [Groups] Script Date: 16.7.2013 г. 16:54:20 ******/
CREATE DATABASE [Groups]

GO
ALTER DATABASE [Groups] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Groups].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Groups] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Groups] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Groups] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Groups] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Groups] SET ARITHABORT OFF
GO
ALTER DATABASE [Groups] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Groups] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Groups] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Groups] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Groups] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Groups] SET CURSOR_DEFAULT GLOBAL
GO
ALTER DATABASE [Groups] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Groups] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Groups] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Groups] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Groups] SET DISABLE_BROKER
GO
ALTER DATABASE [Groups] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Groups] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Groups] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Groups] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Groups] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Groups] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Groups] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Groups] SET RECOVERY FULL
GO
ALTER DATABASE [Groups] SET MULTI_USER
GO
ALTER DATABASE [Groups] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Groups] SET DB_CHAINING OFF
GO
ALTER DATABASE [Groups] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF )
GO
ALTER DATABASE [Groups] SET TARGET_RECOVERY_TIME = 0 SECONDS
GO
EXEC sys.sp_db_vardecimal_storage_format N'Groups', N'ON'
GO
USE [Groups]
GO
/****** Object: Table [dbo].[Groups] Script Date: 16.7.2013 г. 16:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
[GroupID] [int] IDENTITY(1,1) NOT NULL,
[GroupName] [nvarchar](50) NOT NULL,
CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED
(
[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object: Table [dbo].[Users] Script Date: 16.7.2013 г. 16:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
[UserID] [int] IDENTITY(1,1) NOT NULL,
[UserName] [nvarchar](50) NOT NULL,
[GroupID] [int] NOT NULL,
CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED
(
[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Groups] ON
INSERT [dbo].[Groups] ([GroupID], [GroupName]) VALUES (1, N'Admins')
SET IDENTITY_INSERT [dbo].[Groups] OFF
ALTER TABLE [dbo].[Users] WITH CHECK ADD CONSTRAINT [FK_Users_Groups] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Groups] ([GroupID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Groups]
GO
USE [master]
GO
ALTER DATABASE [Groups] SET READ_WRITE
GO