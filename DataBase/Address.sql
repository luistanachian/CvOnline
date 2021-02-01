USE [master]
GO

CREATE DATABASE [Address]
GO

CREATE TABLE [Address].[dbo].[Countries](
	[code] [nvarchar](2) NOT NULL,
	[country] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED ([code] ASC))
GO
