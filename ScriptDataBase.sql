USE [master]
GO

/****** Object:  Database [GestionLogistica]    Script Date: 18/10/2021 3:53:53 p. m. ******/
DROP DATABASE [GestionLogistica]
GO

/****** Object:  Database [GestionLogistica]    Script Date: 18/10/2021 3:53:53 p. m. ******/
CREATE DATABASE [GestionLogistica]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'GestionLogistica', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQL2K17\MSSQL\DATA\GestionLogistica.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'GestionLogistica_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQL2K17\MSSQL\DATA\GestionLogistica_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [GestionLogistica].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [GestionLogistica] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [GestionLogistica] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [GestionLogistica] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [GestionLogistica] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [GestionLogistica] SET ARITHABORT OFF 
GO

ALTER DATABASE [GestionLogistica] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [GestionLogistica] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [GestionLogistica] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [GestionLogistica] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [GestionLogistica] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [GestionLogistica] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [GestionLogistica] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [GestionLogistica] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [GestionLogistica] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [GestionLogistica] SET  DISABLE_BROKER 
GO

ALTER DATABASE [GestionLogistica] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [GestionLogistica] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [GestionLogistica] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [GestionLogistica] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [GestionLogistica] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [GestionLogistica] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [GestionLogistica] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [GestionLogistica] SET RECOVERY FULL 
GO

ALTER DATABASE [GestionLogistica] SET  MULTI_USER 
GO

ALTER DATABASE [GestionLogistica] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [GestionLogistica] SET DB_CHAINING OFF 
GO

ALTER DATABASE [GestionLogistica] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [GestionLogistica] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [GestionLogistica] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [GestionLogistica] SET QUERY_STORE = OFF
GO

ALTER DATABASE [GestionLogistica] SET  READ_WRITE 
GO


USE [GestionLogistica]
GO
/****** Object:  Table [dbo].[Bodegas]    Script Date: 18/10/2021 3:52:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bodegas](
	[BodegaId] [int] IDENTITY(1,1) NOT NULL,
	[CodBodega] [varchar](10) NULL,
	[NombreBodega] [varchar](50) NULL,
 CONSTRAINT [PK_Bodegas] PRIMARY KEY CLUSTERED 
(
	[BodegaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 18/10/2021 3:52:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[ClienteId] [int] IDENTITY(1,1) NOT NULL,
	[NombreCliente] [varchar](50) NULL,
	[DireccionCliente] [varchar](50) NULL,
	[TelefonoCliente] [varchar](50) NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EntregaMaritimo]    Script Date: 18/10/2021 3:52:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EntregaMaritimo](
	[EntregaId] [int] IDENTITY(1,1) NOT NULL,
	[TipoProducto] [int] NULL,
	[CantidadProducto] [int] NULL,
	[FechaRegistro] [date] NULL,
	[FechaEntrega] [date] NULL,
	[PuertoId] [int] NULL,
	[PrecioEnvio] [decimal](18, 2) NULL,
	[NumeroFlota] [varchar](6) NULL,
	[Descuento] [int] NULL,
	[NumeroGuia] [varchar](10) NULL,
	[ClienteId] [int] NOT NULL,
 CONSTRAINT [PK_EntregaMaritimo] PRIMARY KEY CLUSTERED 
(
	[EntregaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EntregaTerrestre]    Script Date: 18/10/2021 3:52:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EntregaTerrestre](
	[EntregaId] [int] IDENTITY(1,1) NOT NULL,
	[TipoProducto] [int] NULL,
	[CantidadProducto] [int] NULL,
	[FechaRegistro] [date] NULL,
	[FechaEntrega] [date] NULL,
	[BodegaId] [int] NULL,
	[PrecioEnvio] [decimal](18, 2) NULL,
	[PlacaVehiculo] [varchar](6) NULL,
	[Descuento] [int] NULL,
	[NumeroGuia] [varchar](10) NULL,
	[ClienteId] [int] NOT NULL,
 CONSTRAINT [PK_EntregaTerrestre] PRIMARY KEY CLUSTERED 
(
	[EntregaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Puertos]    Script Date: 18/10/2021 3:52:50 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Puertos](
	[PuertoId] [int] IDENTITY(1,1) NOT NULL,
	[CodPuerto] [varchar](10) NULL,
	[NombrePuerto] [nvarchar](50) NULL,
 CONSTRAINT [PK_Puertos] PRIMARY KEY CLUSTERED 
(
	[PuertoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EntregaMaritimo]  WITH CHECK ADD  CONSTRAINT [FK_EntregaMaritimo_Clientes] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([ClienteId])
GO
ALTER TABLE [dbo].[EntregaMaritimo] CHECK CONSTRAINT [FK_EntregaMaritimo_Clientes]
GO
ALTER TABLE [dbo].[EntregaMaritimo]  WITH CHECK ADD  CONSTRAINT [FK_EntregaMaritimo_Puertos] FOREIGN KEY([PuertoId])
REFERENCES [dbo].[Puertos] ([PuertoId])
GO
ALTER TABLE [dbo].[EntregaMaritimo] CHECK CONSTRAINT [FK_EntregaMaritimo_Puertos]
GO
ALTER TABLE [dbo].[EntregaTerrestre]  WITH CHECK ADD  CONSTRAINT [FK_EntregaTerrestre_Bodegas] FOREIGN KEY([BodegaId])
REFERENCES [dbo].[Bodegas] ([BodegaId])
GO
ALTER TABLE [dbo].[EntregaTerrestre] CHECK CONSTRAINT [FK_EntregaTerrestre_Bodegas]
GO
ALTER TABLE [dbo].[EntregaTerrestre]  WITH CHECK ADD  CONSTRAINT [FK_EntregaTerrestre_Clientes] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([ClienteId])
GO
ALTER TABLE [dbo].[EntregaTerrestre] CHECK CONSTRAINT [FK_EntregaTerrestre_Clientes]
GO
