USE [master]
GO
/****** Object:  Database [TFS]    Script Date: 26/08/2024 9:51:36 a. m. ******/
CREATE DATABASE [TFS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TFS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TFS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TFS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\TFS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TFS] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TFS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TFS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TFS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TFS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TFS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TFS] SET ARITHABORT OFF 
GO
ALTER DATABASE [TFS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TFS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TFS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TFS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TFS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TFS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TFS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TFS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TFS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TFS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TFS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TFS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TFS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TFS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TFS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TFS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TFS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TFS] SET RECOVERY FULL 
GO
ALTER DATABASE [TFS] SET  MULTI_USER 
GO
ALTER DATABASE [TFS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TFS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TFS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TFS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TFS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TFS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'TFS', N'ON'
GO
ALTER DATABASE [TFS] SET QUERY_STORE = OFF
GO
USE [TFS]
GO
/****** Object:  User [TFS]    Script Date: 26/08/2024 9:51:36 a. m. ******/
CREATE USER [TFS] FOR LOGIN [TFS] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [TFS]
GO
/****** Object:  Table [dbo].[Clasificaciones]    Script Date: 26/08/2024 9:51:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clasificaciones](
	[idClasificacionPK] [int] IDENTITY(1,1) NOT NULL,
	[descripcionClasificacion] [nvarchar](max) NULL,
	[idUsuarioCreaClasificacionFK] [int] NULL,
	[fechaCreaClasificacion] [datetime] NULL,
	[idUsuarioModificaClasificacionFK] [int] NULL,
	[fechaModificaClasificacion] [datetime] NULL,
 CONSTRAINT [PK_Clasificaciones] PRIMARY KEY CLUSTERED 
(
	[idClasificacionPK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 26/08/2024 9:51:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[idClientePK] [int] IDENTITY(1,1) NOT NULL,
	[descripcionCliente] [nvarchar](max) NULL,
	[idClasificacionClienteFK] [int] NULL,
	[idUsuarioCreaClienteFK] [int] NULL,
	[fechaCreaCliente] [datetime] NULL,
	[idUsuarioModificaClienteFK] [int] NULL,
	[fechaModificaCliente] [datetime] NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[idClientePK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Convenios]    Script Date: 26/08/2024 9:51:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Convenios](
	[idConvenioPK] [int] IDENTITY(1,1) NOT NULL,
	[descripcionConvenio] [nvarchar](max) NULL,
	[idUsuarioCreaConvenioFK] [int] NULL,
	[fechaCreaConvenio] [datetime] NULL,
	[idUsuarioModificaConvenioFK] [int] NULL,
	[fechaModificaConvenio] [datetime] NULL,
 CONSTRAINT [PK_Convenios] PRIMARY KEY CLUSTERED 
(
	[idConvenioPK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Financieras]    Script Date: 26/08/2024 9:51:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Financieras](
	[idFinancieraPK] [int] IDENTITY(1,1) NOT NULL,
	[descripcionFinananciera] [nvarchar](max) NULL,
	[idUsuarioCreaFinancieraFK] [int] NULL,
	[fechaCreaFinanciera] [datetime] NULL,
	[idUsuarioModificaFinancieraFK] [int] NULL,
	[fechaModificaFinanciera] [datetime] NULL,
 CONSTRAINT [PK_Financieras] PRIMARY KEY CLUSTERED 
(
	[idFinancieraPK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paquetes]    Script Date: 26/08/2024 9:51:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paquetes](
	[idPaquetePK] [int] IDENTITY(1,1) NOT NULL,
	[descripcionPaquete] [nvarchar](max) NULL,
	[idFinancieraFK] [int] NULL,
	[idVehiculoFK] [int] NULL,
	[montoSugeridoPaquete] [decimal](18, 2) NULL,
	[mesesSugeridoPaquete] [float] NULL,
	[interesesSugeridoPaquete] [float] NULL,
	[cuotaMensualEstimadaPaquete] [decimal](18, 2) NULL,
	[clausulasPaquete] [nvarchar](max) NULL,
	[idUsuarioCreaPaqueteFK] [int] NULL,
	[fechaCreaPaquete] [datetime] NULL,
	[idUsuarioModificaPaqueteFK] [int] NULL,
	[fechaModificaPaquete] [datetime] NULL,
 CONSTRAINT [PK_Paquetes] PRIMARY KEY CLUSTERED 
(
	[idPaquetePK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Perfiles]    Script Date: 26/08/2024 9:51:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Perfiles](
	[idPerfilPK] [int] IDENTITY(1,1) NOT NULL,
	[descripcionPerfil] [nvarchar](max) NULL,
	[idUsuarioCreaPerfilFK] [int] NULL,
	[fechaCreaPerfil] [datetime] NULL,
	[idUsuarioModificaPerfilFK] [int] NULL,
	[fechaModificaPerfil] [datetime] NULL,
 CONSTRAINT [PK_Perfiles] PRIMARY KEY CLUSTERED 
(
	[idPerfilPK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 26/08/2024 9:51:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[idUsuarioPK] [int] IDENTITY(1,1) NOT NULL,
	[descripcionUsuario] [nvarchar](max) NULL,
	[idUsuarioCreaUsuarioFK] [int] NULL,
	[fechaCreaUsuario] [datetime] NULL,
	[idUsuarioModificaUsuarioFK] [int] NULL,
	[fechaModificaUsuario] [datetime] NULL,
	[idPerfilUsuarioFK] [int] NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[idUsuarioPK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehiculos]    Script Date: 26/08/2024 9:51:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehiculos](
	[idVehiculoPK] [int] IDENTITY(1,1) NOT NULL,
	[descripcionVehiculo] [nvarchar](max) NULL,
	[matriculaVehiculo] [nvarchar](10) NULL,
	[idConvenioFK] [int] NULL,
	[idUsuarioCreaVehiculoFK] [int] NULL,
	[fechaCreaVehiculo] [datetime] NULL,
	[idUsuarioModificaVehiculoFK] [int] NULL,
	[fechaModificaVehiculo] [datetime] NULL,
 CONSTRAINT [PK_Vehiculos] PRIMARY KEY CLUSTERED 
(
	[idVehiculoPK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VentaPaquetes]    Script Date: 26/08/2024 9:51:36 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VentaPaquetes](
	[idVentaPaquetePK] [int] IDENTITY(1,1) NOT NULL,
	[numeroVentaPaquete] [int] NULL,
	[idClienteFK] [int] NULL,
	[idPaqueteFK] [int] NULL,
	[idUsuarioCreaVentaPaqueteFK] [int] NULL,
	[fechaCreaVentaPaquete] [datetime] NULL,
	[idUsuarioModificaVentaPaqueteFK] [int] NULL,
	[fechaModificaVentaPaquete] [datetime] NULL,
 CONSTRAINT [PK_VentaPaquetes] PRIMARY KEY CLUSTERED 
(
	[idVentaPaquetePK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clasificaciones] ON 

INSERT [dbo].[Clasificaciones] ([idClasificacionPK], [descripcionClasificacion], [idUsuarioCreaClasificacionFK], [fechaCreaClasificacion], [idUsuarioModificaClasificacionFK], [fechaModificaClasificacion]) VALUES (1, N'Clientes buenos', NULL, NULL, NULL, NULL)
INSERT [dbo].[Clasificaciones] ([idClasificacionPK], [descripcionClasificacion], [idUsuarioCreaClasificacionFK], [fechaCreaClasificacion], [idUsuarioModificaClasificacionFK], [fechaModificaClasificacion]) VALUES (2, N'Clientes malos', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Clasificaciones] OFF
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([idClientePK], [descripcionCliente], [idClasificacionClienteFK], [idUsuarioCreaClienteFK], [fechaCreaCliente], [idUsuarioModificaClienteFK], [fechaModificaCliente]) VALUES (1, N'Cliente a', 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Clientes] ([idClientePK], [descripcionCliente], [idClasificacionClienteFK], [idUsuarioCreaClienteFK], [fechaCreaCliente], [idUsuarioModificaClienteFK], [fechaModificaCliente]) VALUES (2, N'Cliente b', 2, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[Convenios] ON 

INSERT [dbo].[Convenios] ([idConvenioPK], [descripcionConvenio], [idUsuarioCreaConvenioFK], [fechaCreaConvenio], [idUsuarioModificaConvenioFK], [fechaModificaConvenio]) VALUES (1, N'Convenio único', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Convenios] OFF
GO
SET IDENTITY_INSERT [dbo].[Financieras] ON 

INSERT [dbo].[Financieras] ([idFinancieraPK], [descripcionFinananciera], [idUsuarioCreaFinancieraFK], [fechaCreaFinanciera], [idUsuarioModificaFinancieraFK], [fechaModificaFinanciera]) VALUES (1, N'Toyota Financial Services', 1, NULL, 1, NULL)
INSERT [dbo].[Financieras] ([idFinancieraPK], [descripcionFinananciera], [idUsuarioCreaFinancieraFK], [fechaCreaFinanciera], [idUsuarioModificaFinancieraFK], [fechaModificaFinanciera]) VALUES (2, N'Financiera convencional', 1, NULL, 1, NULL)
SET IDENTITY_INSERT [dbo].[Financieras] OFF
GO
SET IDENTITY_INSERT [dbo].[Paquetes] ON 

INSERT [dbo].[Paquetes] ([idPaquetePK], [descripcionPaquete], [idFinancieraFK], [idVehiculoFK], [montoSugeridoPaquete], [mesesSugeridoPaquete], [interesesSugeridoPaquete], [cuotaMensualEstimadaPaquete], [clausulasPaquete], [idUsuarioCreaPaqueteFK], [fechaCreaPaquete], [idUsuarioModificaPaqueteFK], [fechaModificaPaquete]) VALUES (1, N'Paquete A', 1, 1, CAST(50000000.00 AS Decimal(18, 2)), 60, 20, CAST(500000.00 AS Decimal(18, 2)), N'No hay cláusulas', 1, NULL, 1, NULL)
INSERT [dbo].[Paquetes] ([idPaquetePK], [descripcionPaquete], [idFinancieraFK], [idVehiculoFK], [montoSugeridoPaquete], [mesesSugeridoPaquete], [interesesSugeridoPaquete], [cuotaMensualEstimadaPaquete], [clausulasPaquete], [idUsuarioCreaPaqueteFK], [fechaCreaPaquete], [idUsuarioModificaPaqueteFK], [fechaModificaPaquete]) VALUES (2, N'Paquete B', 2, 1, CAST(50000000.00 AS Decimal(18, 2)), 60, 25, CAST(750000.00 AS Decimal(18, 2)), N'No hay cláusulas', 1, NULL, 1, NULL)
SET IDENTITY_INSERT [dbo].[Paquetes] OFF
GO
SET IDENTITY_INSERT [dbo].[Perfiles] ON 

INSERT [dbo].[Perfiles] ([idPerfilPK], [descripcionPerfil], [idUsuarioCreaPerfilFK], [fechaCreaPerfil], [idUsuarioModificaPerfilFK], [fechaModificaPerfil]) VALUES (1, N'Perfil de pleno acceso', NULL, NULL, NULL, NULL)
INSERT [dbo].[Perfiles] ([idPerfilPK], [descripcionPerfil], [idUsuarioCreaPerfilFK], [fechaCreaPerfil], [idUsuarioModificaPerfilFK], [fechaModificaPerfil]) VALUES (2, N'Perfil restringido', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Perfiles] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([idUsuarioPK], [descripcionUsuario], [idUsuarioCreaUsuarioFK], [fechaCreaUsuario], [idUsuarioModificaUsuarioFK], [fechaModificaUsuario], [idPerfilUsuarioFK]) VALUES (1, N'Administrador', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Usuarios] ([idUsuarioPK], [descripcionUsuario], [idUsuarioCreaUsuarioFK], [fechaCreaUsuario], [idUsuarioModificaUsuarioFK], [fechaModificaUsuario], [idPerfilUsuarioFK]) VALUES (2, N'Usuario funcional', 1, NULL, 1, NULL, 2)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
SET IDENTITY_INSERT [dbo].[Vehiculos] ON 

INSERT [dbo].[Vehiculos] ([idVehiculoPK], [descripcionVehiculo], [matriculaVehiculo], [idConvenioFK], [idUsuarioCreaVehiculoFK], [fechaCreaVehiculo], [idUsuarioModificaVehiculoFK], [fechaModificaVehiculo]) VALUES (1, N'Toyota Prado', N'abc-123', 1, 1, NULL, 1, NULL)
SET IDENTITY_INSERT [dbo].[Vehiculos] OFF
GO
SET IDENTITY_INSERT [dbo].[VentaPaquetes] ON 

INSERT [dbo].[VentaPaquetes] ([idVentaPaquetePK], [numeroVentaPaquete], [idClienteFK], [idPaqueteFK], [idUsuarioCreaVentaPaqueteFK], [fechaCreaVentaPaquete], [idUsuarioModificaVentaPaqueteFK], [fechaModificaVentaPaquete]) VALUES (1, 1, 2, 1, 1, NULL, 1, NULL)
SET IDENTITY_INSERT [dbo].[VentaPaquetes] OFF
GO
ALTER TABLE [dbo].[Clasificaciones]  WITH CHECK ADD  CONSTRAINT [FK_Clasificaciones_Usuarios_Crea] FOREIGN KEY([idUsuarioCreaClasificacionFK])
REFERENCES [dbo].[Usuarios] ([idUsuarioPK])
GO
ALTER TABLE [dbo].[Clasificaciones] CHECK CONSTRAINT [FK_Clasificaciones_Usuarios_Crea]
GO
ALTER TABLE [dbo].[Clasificaciones]  WITH CHECK ADD  CONSTRAINT [FK_Clasificaciones_Usuarios_Modifica] FOREIGN KEY([idUsuarioModificaClasificacionFK])
REFERENCES [dbo].[Usuarios] ([idUsuarioPK])
GO
ALTER TABLE [dbo].[Clasificaciones] CHECK CONSTRAINT [FK_Clasificaciones_Usuarios_Modifica]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Clasificaciones] FOREIGN KEY([idClasificacionClienteFK])
REFERENCES [dbo].[Clasificaciones] ([idClasificacionPK])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_Clasificaciones]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Usuarios_Crea] FOREIGN KEY([idUsuarioCreaClienteFK])
REFERENCES [dbo].[Usuarios] ([idUsuarioPK])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_Usuarios_Crea]
GO
ALTER TABLE [dbo].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Usuarios_Modifica] FOREIGN KEY([idUsuarioModificaClienteFK])
REFERENCES [dbo].[Usuarios] ([idUsuarioPK])
GO
ALTER TABLE [dbo].[Clientes] CHECK CONSTRAINT [FK_Clientes_Usuarios_Modifica]
GO
ALTER TABLE [dbo].[Convenios]  WITH CHECK ADD  CONSTRAINT [FK_Convenios_Usuarios_Crea] FOREIGN KEY([idUsuarioCreaConvenioFK])
REFERENCES [dbo].[Usuarios] ([idUsuarioPK])
GO
ALTER TABLE [dbo].[Convenios] CHECK CONSTRAINT [FK_Convenios_Usuarios_Crea]
GO
ALTER TABLE [dbo].[Convenios]  WITH CHECK ADD  CONSTRAINT [FK_Convenios_Usuarios_Modifica] FOREIGN KEY([idUsuarioModificaConvenioFK])
REFERENCES [dbo].[Usuarios] ([idUsuarioPK])
GO
ALTER TABLE [dbo].[Convenios] CHECK CONSTRAINT [FK_Convenios_Usuarios_Modifica]
GO
ALTER TABLE [dbo].[Financieras]  WITH CHECK ADD  CONSTRAINT [FK_Financieras_Usuarios_Crea] FOREIGN KEY([idUsuarioCreaFinancieraFK])
REFERENCES [dbo].[Usuarios] ([idUsuarioPK])
GO
ALTER TABLE [dbo].[Financieras] CHECK CONSTRAINT [FK_Financieras_Usuarios_Crea]
GO
ALTER TABLE [dbo].[Financieras]  WITH CHECK ADD  CONSTRAINT [FK_Financieras_Usuarios_Modifica] FOREIGN KEY([idUsuarioModificaFinancieraFK])
REFERENCES [dbo].[Usuarios] ([idUsuarioPK])
GO
ALTER TABLE [dbo].[Financieras] CHECK CONSTRAINT [FK_Financieras_Usuarios_Modifica]
GO
ALTER TABLE [dbo].[Paquetes]  WITH CHECK ADD  CONSTRAINT [FK_Paquetes_Financieras] FOREIGN KEY([idFinancieraFK])
REFERENCES [dbo].[Financieras] ([idFinancieraPK])
GO
ALTER TABLE [dbo].[Paquetes] CHECK CONSTRAINT [FK_Paquetes_Financieras]
GO
ALTER TABLE [dbo].[Paquetes]  WITH CHECK ADD  CONSTRAINT [FK_Paquetes_Usuarios_Crea] FOREIGN KEY([idUsuarioCreaPaqueteFK])
REFERENCES [dbo].[Usuarios] ([idUsuarioPK])
GO
ALTER TABLE [dbo].[Paquetes] CHECK CONSTRAINT [FK_Paquetes_Usuarios_Crea]
GO
ALTER TABLE [dbo].[Paquetes]  WITH CHECK ADD  CONSTRAINT [FK_Paquetes_Usuarios_Modifica] FOREIGN KEY([idUsuarioModificaPaqueteFK])
REFERENCES [dbo].[Usuarios] ([idUsuarioPK])
GO
ALTER TABLE [dbo].[Paquetes] CHECK CONSTRAINT [FK_Paquetes_Usuarios_Modifica]
GO
ALTER TABLE [dbo].[Paquetes]  WITH CHECK ADD  CONSTRAINT [FK_Paquetes_Vehiculos] FOREIGN KEY([idVehiculoFK])
REFERENCES [dbo].[Vehiculos] ([idVehiculoPK])
GO
ALTER TABLE [dbo].[Paquetes] CHECK CONSTRAINT [FK_Paquetes_Vehiculos]
GO
ALTER TABLE [dbo].[Perfiles]  WITH CHECK ADD  CONSTRAINT [FK_Perfiles_Usuarios_Crea] FOREIGN KEY([idUsuarioCreaPerfilFK])
REFERENCES [dbo].[Usuarios] ([idUsuarioPK])
GO
ALTER TABLE [dbo].[Perfiles] CHECK CONSTRAINT [FK_Perfiles_Usuarios_Crea]
GO
ALTER TABLE [dbo].[Perfiles]  WITH CHECK ADD  CONSTRAINT [FK_Perfiles_Usuarios_Modifica] FOREIGN KEY([idUsuarioModificaPerfilFK])
REFERENCES [dbo].[Usuarios] ([idUsuarioPK])
GO
ALTER TABLE [dbo].[Perfiles] CHECK CONSTRAINT [FK_Perfiles_Usuarios_Modifica]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Perfiles] FOREIGN KEY([idPerfilUsuarioFK])
REFERENCES [dbo].[Perfiles] ([idPerfilPK])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Perfiles]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Usuarios_Crea] FOREIGN KEY([idUsuarioCreaUsuarioFK])
REFERENCES [dbo].[Usuarios] ([idUsuarioPK])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Usuarios_Crea]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Usuarios_Modifica] FOREIGN KEY([idUsuarioModificaUsuarioFK])
REFERENCES [dbo].[Usuarios] ([idUsuarioPK])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Usuarios_Modifica]
GO
ALTER TABLE [dbo].[Vehiculos]  WITH CHECK ADD  CONSTRAINT [FK_Vehiculos_Convenios] FOREIGN KEY([idConvenioFK])
REFERENCES [dbo].[Convenios] ([idConvenioPK])
GO
ALTER TABLE [dbo].[Vehiculos] CHECK CONSTRAINT [FK_Vehiculos_Convenios]
GO
ALTER TABLE [dbo].[Vehiculos]  WITH CHECK ADD  CONSTRAINT [FK_Vehiculos_Usuarios_Crea] FOREIGN KEY([idUsuarioCreaVehiculoFK])
REFERENCES [dbo].[Usuarios] ([idUsuarioPK])
GO
ALTER TABLE [dbo].[Vehiculos] CHECK CONSTRAINT [FK_Vehiculos_Usuarios_Crea]
GO
ALTER TABLE [dbo].[Vehiculos]  WITH CHECK ADD  CONSTRAINT [FK_Vehiculos_Usuarios_Modifica] FOREIGN KEY([idUsuarioModificaVehiculoFK])
REFERENCES [dbo].[Usuarios] ([idUsuarioPK])
GO
ALTER TABLE [dbo].[Vehiculos] CHECK CONSTRAINT [FK_Vehiculos_Usuarios_Modifica]
GO
ALTER TABLE [dbo].[VentaPaquetes]  WITH CHECK ADD  CONSTRAINT [FK_VentaPaquetes_Clientes] FOREIGN KEY([idClienteFK])
REFERENCES [dbo].[Clientes] ([idClientePK])
GO
ALTER TABLE [dbo].[VentaPaquetes] CHECK CONSTRAINT [FK_VentaPaquetes_Clientes]
GO
ALTER TABLE [dbo].[VentaPaquetes]  WITH CHECK ADD  CONSTRAINT [FK_VentaPaquetes_Paquetes] FOREIGN KEY([idPaqueteFK])
REFERENCES [dbo].[Paquetes] ([idPaquetePK])
GO
ALTER TABLE [dbo].[VentaPaquetes] CHECK CONSTRAINT [FK_VentaPaquetes_Paquetes]
GO
ALTER TABLE [dbo].[VentaPaquetes]  WITH CHECK ADD  CONSTRAINT [FK_VentaPaquetes_Usuarios_Crea] FOREIGN KEY([idUsuarioCreaVentaPaqueteFK])
REFERENCES [dbo].[Usuarios] ([idUsuarioPK])
GO
ALTER TABLE [dbo].[VentaPaquetes] CHECK CONSTRAINT [FK_VentaPaquetes_Usuarios_Crea]
GO
ALTER TABLE [dbo].[VentaPaquetes]  WITH CHECK ADD  CONSTRAINT [FK_VentaPaquetes_Usuarios_Modifica] FOREIGN KEY([idUsuarioModificaVentaPaqueteFK])
REFERENCES [dbo].[Usuarios] ([idUsuarioPK])
GO
ALTER TABLE [dbo].[VentaPaquetes] CHECK CONSTRAINT [FK_VentaPaquetes_Usuarios_Modifica]
GO
USE [master]
GO
ALTER DATABASE [TFS] SET  READ_WRITE 
GO
