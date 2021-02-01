USE [master]
GO

DROP DATABASE [Abilities]
GO
CREATE DATABASE [Abilities]
GO

CREATE TABLE [Abilities].[dbo].[Companies](
	[idCompany] [smallint] IDENTITY(1,1) NOT NULL,
	[company] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED ( [idCompany] ASC ))
GO

CREATE TABLE [Abilities].[dbo].[Groups](
	[idGroup] [smallint] IDENTITY(1,1) NOT NULL,
	[group] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED ( [idGroup] ASC ))ON [PRIMARY]
GO
