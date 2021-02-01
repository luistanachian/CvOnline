USE [master]
GO

CREATE DATABASE [Abilities]
GO

CREATE TABLE [Abilities].[dbo].[Companies](
	[idCompany] [smallint] IDENTITY(1,1) NOT NULL,
	[company] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED ( [idCompany] ASC ))
GO

CREATE TABLE [Abilities].[dbo].[SkillGroups](
	[idSkillGroup] [smallint] IDENTITY(1,1) NOT NULL,
	[skillGroup] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SkillGroups] PRIMARY KEY CLUSTERED ( [idSkillGroup] ASC ))ON [PRIMARY]
GO
CREATE TABLE [Abilities].[dbo].[Skills](
	[idSkill] [smallint] IDENTITY(1,1) NOT NULL,
	[idSkillGroup] [smallint] NOT NULL,
	[idCompany] [smallint] NOT NULL,
	[skill] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Skills] PRIMARY KEY CLUSTERED ([idSkill] ASC))
GO

ALTER TABLE [Abilities].[dbo].[Skills]  WITH CHECK ADD  CONSTRAINT [FK_Skills_Companies] FOREIGN KEY([idCompany])
REFERENCES [Abilities].[dbo].[Companies] ([idCompany])
GO

ALTER TABLE [Abilities].[dbo].[Skills] CHECK CONSTRAINT [FK_Skills_Companies]
GO

ALTER TABLE [Abilities].[dbo].[Skills]  WITH CHECK ADD  CONSTRAINT [FK_Skills_SkillGroups] FOREIGN KEY([idSkillGroup])
REFERENCES [Abilities].[dbo].[SkillGroups] ([idSkillGroup])
GO

ALTER TABLE [Abilities].[dbo].[Skills] CHECK CONSTRAINT [FK_Skills_SkillGroups]
GO

CREATE TABLE [Abilities].[dbo].[SkillVersions](
	[idSkillVersion] [int] IDENTITY(1,1) NOT NULL,
	[idSkill] [smallint] NOT NULL,
	[releaseDate] [date] NOT NULL,
	[version] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SkillVersions] PRIMARY KEY CLUSTERED ([idSkillVersion] ASC))
GO

ALTER TABLE [Abilities].[dbo].[SkillVersions]  WITH CHECK ADD  CONSTRAINT [FK_SkillVersions_Skills] FOREIGN KEY([idSkill])
REFERENCES [Abilities].[dbo].[Skills] ([idSkill])
GO

ALTER TABLE [Abilities].[dbo].[SkillVersions] CHECK CONSTRAINT [FK_SkillVersions_Skills]
GO
