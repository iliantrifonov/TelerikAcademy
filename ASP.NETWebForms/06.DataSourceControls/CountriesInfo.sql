USE [master]
GO
/****** Object:  Database [CountriesInfo]    Script Date: 10/25/2014 20:00:26 ******/
CREATE DATABASE [CountriesInfo]
GO
ALTER DATABASE [CountriesInfo] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CountriesInfo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CountriesInfo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CountriesInfo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CountriesInfo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CountriesInfo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CountriesInfo] SET ARITHABORT OFF 
GO
ALTER DATABASE [CountriesInfo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CountriesInfo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CountriesInfo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CountriesInfo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CountriesInfo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CountriesInfo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CountriesInfo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CountriesInfo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CountriesInfo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CountriesInfo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CountriesInfo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CountriesInfo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CountriesInfo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CountriesInfo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CountriesInfo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CountriesInfo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CountriesInfo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CountriesInfo] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CountriesInfo] SET  MULTI_USER 
GO
ALTER DATABASE [CountriesInfo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CountriesInfo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CountriesInfo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CountriesInfo] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CountriesInfo] SET DELAYED_DURABILITY = DISABLED 
GO
USE [CountriesInfo]
GO
/****** Object:  Table [dbo].[Continents]    Script Date: 10/25/2014 20:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Continents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Countries]    Script Date: 10/25/2014 20:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Countries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Language] [nvarchar](50) NULL,
	[Population] [int] NOT NULL,
	[ContinentId] [int] NOT NULL,
	[Flag] [varbinary](max) NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Towns]    Script Date: 10/25/2014 20:00:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Towns](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Population] [int] NOT NULL,
	[CountryId] [int] NOT NULL,
 CONSTRAINT [PK_Towns] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Continents] ON 

INSERT [dbo].[Continents] ([Id], [Name]) VALUES (1, N'Africa')
INSERT [dbo].[Continents] ([Id], [Name]) VALUES (2, N'Europe')
INSERT [dbo].[Continents] ([Id], [Name]) VALUES (3, N'Australia')
INSERT [dbo].[Continents] ([Id], [Name]) VALUES (4, N'Asia')
INSERT [dbo].[Continents] ([Id], [Name]) VALUES (5, N'South America')
SET IDENTITY_INSERT [dbo].[Continents] OFF
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([Id], [Name], [Language], [Population], [ContinentId], [Flag]) VALUES (1, N'Bulgaria1', N'Bulgarian', 123, 2, NULL)
INSERT [dbo].[Countries] ([Id], [Name], [Language], [Population], [ContinentId], [Flag]) VALUES (2, N'France', N'French', 2222, 2, NULL)
INSERT [dbo].[Countries] ([Id], [Name], [Language], [Population], [ContinentId], [Flag]) VALUES (3, N'Ruanda', N'Some..', 2223, 1, NULL)
INSERT [dbo].[Countries] ([Id], [Name], [Language], [Population], [ContinentId], [Flag]) VALUES (4, N'Russia', N'Russian', 31123, 4, NULL)
INSERT [dbo].[Countries] ([Id], [Name], [Language], [Population], [ContinentId], [Flag]) VALUES (5, N'SS', N'SS', 232, 1, NULL)
SET IDENTITY_INSERT [dbo].[Countries] OFF
SET IDENTITY_INSERT [dbo].[Towns] ON 

INSERT [dbo].[Towns] ([Id], [Name], [Population], [CountryId]) VALUES (1, N'Sofia', 23, 1)
INSERT [dbo].[Towns] ([Id], [Name], [Population], [CountryId]) VALUES (2, N'Plovdiv', 22, 1)
INSERT [dbo].[Towns] ([Id], [Name], [Population], [CountryId]) VALUES (3, N'Burgas', 2, 1)
INSERT [dbo].[Towns] ([Id], [Name], [Population], [CountryId]) VALUES (4, N'Paris', 23, 2)
INSERT [dbo].[Towns] ([Id], [Name], [Population], [CountryId]) VALUES (5, N'Moscow', 233, 4)
INSERT [dbo].[Towns] ([Id], [Name], [Population], [CountryId]) VALUES (6, N'Melnik', 2, 1)
SET IDENTITY_INSERT [dbo].[Towns] OFF
ALTER TABLE [dbo].[Countries]  WITH CHECK ADD  CONSTRAINT [FK_Countries_Continents] FOREIGN KEY([ContinentId])
REFERENCES [dbo].[Continents] ([Id])
GO
ALTER TABLE [dbo].[Countries] CHECK CONSTRAINT [FK_Countries_Continents]
GO
ALTER TABLE [dbo].[Towns]  WITH CHECK ADD  CONSTRAINT [FK_Towns_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
GO
ALTER TABLE [dbo].[Towns] CHECK CONSTRAINT [FK_Towns_Countries]
GO
USE [master]
GO
ALTER DATABASE [CountriesInfo] SET  READ_WRITE 
GO
