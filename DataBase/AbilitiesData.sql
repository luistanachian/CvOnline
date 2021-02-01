USE [Abilities]
GO
SET IDENTITY_INSERT [dbo].[Companies] ON 
GO
INSERT [dbo].[Companies] ([idCompany], [company]) VALUES (1, N'Microsoft')
GO
SET IDENTITY_INSERT [dbo].[Companies] OFF
GO
SET IDENTITY_INSERT [dbo].[SkillGroups] ON 
GO
INSERT [dbo].[SkillGroups] ([idSkillGroup], [skillGroup]) VALUES (1, N'Operating Systems')
GO
SET IDENTITY_INSERT [dbo].[SkillGroups] OFF
GO
SET IDENTITY_INSERT [dbo].[Skills] ON 
GO
INSERT [dbo].[Skills] ([idSkill], [idSkillGroup], [idCompany], [skill]) VALUES (1, 1, 1, N'Windows')
GO
SET IDENTITY_INSERT [dbo].[Skills] OFF
GO
SET IDENTITY_INSERT [dbo].[SkillVersions] ON 
GO
INSERT [dbo].[SkillVersions] ([idSkillVersion], [idSkill], [releaseDate], [version]) VALUES (1, 1, CAST(N'1985-11-20' AS Date), N'1.0')
GO
INSERT [dbo].[SkillVersions] ([idSkillVersion], [idSkill], [releaseDate], [version]) VALUES (2, 1, CAST(N'1987-12-09' AS Date), N'2.0')
GO
INSERT [dbo].[SkillVersions] ([idSkillVersion], [idSkill], [releaseDate], [version]) VALUES (3, 1, CAST(N'1990-05-22' AS Date), N'3.0')
GO
INSERT [dbo].[SkillVersions] ([idSkillVersion], [idSkill], [releaseDate], [version]) VALUES (5, 1, CAST(N'1995-08-24' AS Date), N'95')
GO
INSERT [dbo].[SkillVersions] ([idSkillVersion], [idSkill], [releaseDate], [version]) VALUES (6, 1, CAST(N'1996-08-24' AS Date), N'NT 4.0')
GO
INSERT [dbo].[SkillVersions] ([idSkillVersion], [idSkill], [releaseDate], [version]) VALUES (7, 1, CAST(N'1998-05-25' AS Date), N'98')
GO
INSERT [dbo].[SkillVersions] ([idSkillVersion], [idSkill], [releaseDate], [version]) VALUES (8, 1, CAST(N'2000-02-17' AS Date), N'2000')
GO
INSERT [dbo].[SkillVersions] ([idSkillVersion], [idSkill], [releaseDate], [version]) VALUES (9, 1, CAST(N'2000-09-14' AS Date), N'ME')
GO
INSERT [dbo].[SkillVersions] ([idSkillVersion], [idSkill], [releaseDate], [version]) VALUES (10, 1, CAST(N'2001-10-25' AS Date), N'XP')
GO
INSERT [dbo].[SkillVersions] ([idSkillVersion], [idSkill], [releaseDate], [version]) VALUES (11, 1, CAST(N'2007-01-30' AS Date), N'Vista')
GO
INSERT [dbo].[SkillVersions] ([idSkillVersion], [idSkill], [releaseDate], [version]) VALUES (12, 1, CAST(N'2009-10-22' AS Date), N'7')
GO
INSERT [dbo].[SkillVersions] ([idSkillVersion], [idSkill], [releaseDate], [version]) VALUES (13, 1, CAST(N'2012-10-26' AS Date), N'8')
GO
INSERT [dbo].[SkillVersions] ([idSkillVersion], [idSkill], [releaseDate], [version]) VALUES (14, 1, CAST(N'2013-08-27' AS Date), N'8.1')
GO
INSERT [dbo].[SkillVersions] ([idSkillVersion], [idSkill], [releaseDate], [version]) VALUES (15, 1, CAST(N'2015-07-29' AS Date), N'10')
GO
SET IDENTITY_INSERT [dbo].[SkillVersions] OFF
GO
