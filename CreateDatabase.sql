CREATE DATABASE [ConvertTest]

USE [ConvertTest]
GO

--[dbo].[Calls]
CREATE TABLE [dbo].[Calls](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Document] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[Date] [datetime2](7) NOT NULL,
	[DocumentType] [int] NOT NULL,
	[IsCustomer] [bit] NOT NULL,
	[ValidDocument] [bit] NOT NULL,
	[CallId] [bigint] NOT NULL,
 CONSTRAINT [PK_Calls] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Calls] ADD  DEFAULT ((0)) FOR [DocumentType]
GO

ALTER TABLE [dbo].[Calls] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsCustomer]
GO

ALTER TABLE [dbo].[Calls] ADD  DEFAULT (CONVERT([bit],(0))) FOR [ValidDocument]
GO

ALTER TABLE [dbo].[Calls] ADD  DEFAULT (CONVERT([bigint],(0))) FOR [CallId]
GO

--[dbo].[Customer]
USE [ConvertTest2]
GO

CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Document] [nvarchar](max) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

--inserts
insert into Customer values('Guilherme','68152387096')
insert into Customer values('Renato','46825816004')
insert into Customer values('Nely','88608393000161')
insert into Customer values('Marcilei','14070167000133')

--[WindowsServiceRegister]

USE [ConvertTest2]
GO

CREATE TABLE [dbo].[WindowsServiceRegister](
	[int] [int] IDENTITY(1,1) NOT NULL,
	[CallId] [bigint] NOT NULL,
	[Document] [nvarchar](max) NOT NULL,
	[Data] [datetime2](7) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

