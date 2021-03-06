USE [master]
GO
/****** Object:  Database [PeopleAddressDB]    Script Date: 21.8.2014 г. 17:14:59 ч. ******/
CREATE DATABASE [PeopleAddressDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PeopleAddressDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\PeopleAddressDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PeopleAddressDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\PeopleAddressDB_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [PeopleAddressDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PeopleAddressDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PeopleAddressDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PeopleAddressDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PeopleAddressDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PeopleAddressDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PeopleAddressDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [PeopleAddressDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PeopleAddressDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PeopleAddressDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PeopleAddressDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PeopleAddressDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PeopleAddressDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PeopleAddressDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PeopleAddressDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PeopleAddressDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PeopleAddressDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PeopleAddressDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PeopleAddressDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PeopleAddressDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PeopleAddressDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PeopleAddressDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PeopleAddressDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PeopleAddressDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PeopleAddressDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PeopleAddressDB] SET  MULTI_USER 
GO
ALTER DATABASE [PeopleAddressDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PeopleAddressDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PeopleAddressDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PeopleAddressDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [PeopleAddressDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [PeopleAddressDB]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 21.8.2014 г. 17:14:59 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[AddressText] [nvarchar](50) NOT NULL,
	[TownId] [int] NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continent]    Script Date: 21.8.2014 г. 17:14:59 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continent](
	[ContinentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Continent] PRIMARY KEY CLUSTERED 
(
	[ContinentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Country]    Script Date: 21.8.2014 г. 17:14:59 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[ContinentId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Person]    Script Date: 21.8.2014 г. 17:14:59 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[AddressId] [int] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Town]    Script Date: 21.8.2014 г. 17:14:59 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Town](
	[TownId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](10) NULL,
	[CountryId] [int] NOT NULL,
 CONSTRAINT [PK_Town] PRIMARY KEY CLUSTERED 
(
	[TownId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Address] ON 

INSERT [dbo].[Address] ([AddressId], [AddressText], [TownId]) VALUES (1, N'Some address 1', 1)
INSERT [dbo].[Address] ([AddressId], [AddressText], [TownId]) VALUES (2, N'Some address 2 ', 1)
INSERT [dbo].[Address] ([AddressId], [AddressText], [TownId]) VALUES (3, N'Some address 3 ', 2)
SET IDENTITY_INSERT [dbo].[Address] OFF
SET IDENTITY_INSERT [dbo].[Continent] ON 

INSERT [dbo].[Continent] ([ContinentId], [Name]) VALUES (1, N'Europe')
INSERT [dbo].[Continent] ([ContinentId], [Name]) VALUES (2, N'South America')
INSERT [dbo].[Continent] ([ContinentId], [Name]) VALUES (3, N'North America')
SET IDENTITY_INSERT [dbo].[Continent] OFF
SET IDENTITY_INSERT [dbo].[Country] ON 

INSERT [dbo].[Country] ([CountryId], [ContinentId], [Name]) VALUES (1, 1, N'Bulgaria')
INSERT [dbo].[Country] ([CountryId], [ContinentId], [Name]) VALUES (3, 1, N'France')
INSERT [dbo].[Country] ([CountryId], [ContinentId], [Name]) VALUES (4, 2, N'Argentina')
SET IDENTITY_INSERT [dbo].[Country] OFF
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (1, N'Invancho', N'Penkov', 1)
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (2, N'Mariika', N'Pekova', 1)
INSERT [dbo].[Person] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (3, N'Gergana', N'Ivanova', 2)
SET IDENTITY_INSERT [dbo].[Person] OFF
SET IDENTITY_INSERT [dbo].[Town] ON 

INSERT [dbo].[Town] ([TownId], [Name], [CountryId]) VALUES (1, N'Sofia     ', 1)
INSERT [dbo].[Town] ([TownId], [Name], [CountryId]) VALUES (2, N'Plovdiv   ', 1)
SET IDENTITY_INSERT [dbo].[Town] OFF
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Town] FOREIGN KEY([TownId])
REFERENCES [dbo].[Town] ([TownId])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Town]
GO
ALTER TABLE [dbo].[Country]  WITH CHECK ADD  CONSTRAINT [FK_Country_Continent] FOREIGN KEY([ContinentId])
REFERENCES [dbo].[Continent] ([ContinentId])
GO
ALTER TABLE [dbo].[Country] CHECK CONSTRAINT [FK_Country_Continent]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Address] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Address] ([AddressId])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Address]
GO
ALTER TABLE [dbo].[Town]  WITH CHECK ADD  CONSTRAINT [FK_Town_Country] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([CountryId])
GO
ALTER TABLE [dbo].[Town] CHECK CONSTRAINT [FK_Town_Country]
GO
USE [master]
GO
ALTER DATABASE [PeopleAddressDB] SET  READ_WRITE 
GO
