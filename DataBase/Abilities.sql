USE [master]
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
CREATE TABLE [Abilities].[dbo].[Skills](
	[idSkill] [smallint] IDENTITY(1,1) NOT NULL,
	[idGroup] [smallint] NOT NULL,
	[idCompany] [smallint] NOT NULL,
	[skill] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Skills] PRIMARY KEY CLUSTERED ([idSkill] ASC))
GO

ALTER TABLE [Abilities].[dbo].[Skills]  WITH CHECK ADD  CONSTRAINT [FK_Skills_Companies] FOREIGN KEY([idCompany])
REFERENCES [Abilities].[dbo].[Companies] ([idCompany])
GO

ALTER TABLE [Abilities].[dbo].[Skills] CHECK CONSTRAINT [FK_Skills_Companies]
GO

ALTER TABLE [Abilities].[dbo].[Skills]  WITH CHECK ADD  CONSTRAINT [FK_Skills_Groups] FOREIGN KEY([idGroup])
REFERENCES [Abilities].[dbo].[Groups] ([idGroup])
GO

ALTER TABLE [Abilities].[dbo].[Skills] CHECK CONSTRAINT [FK_Skills_Groups]
GO

CREATE TABLE [Abilities].[dbo].[SkillsVersions](
	[idSkillVersion] [int] IDENTITY(1,1) NOT NULL,
	[idSkill] [smallint] NOT NULL,
	[releaseDate] [date] NOT NULL,
	[version] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SkillsVersions] PRIMARY KEY CLUSTERED ([idSkillVersion] ASC))
GO

ALTER TABLE [Abilities].[dbo].[SkillsVersions]  WITH CHECK ADD  CONSTRAINT [FK_SkillsVersions_Skills] FOREIGN KEY([idSkill])
REFERENCES [Abilities].[dbo].[Skills] ([idSkill])
GO

ALTER TABLE [Abilities].[dbo].[SkillsVersions] CHECK CONSTRAINT [FK_SkillsVersions_Skills]
GO
