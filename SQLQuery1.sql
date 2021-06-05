/*Your dropdown lists */

GO
SET IDENTITY_INSERT [dbo].[Categories] ON
GO
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (1, N'Daily Hampers', N'Daily Hampers')
GO
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (2, N'Weekly Hampers', N'Weekly Hampers')
GO
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (3, N'Motherly Hampers', N'Motherly Hampers')
GO
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (4, N'Quarterly Hampers', N'Quarterly Hampers')
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF

------------------------------------------
GO
SET IDENTITY_INSERT [dbo].[ItemTypes] ON
GO
INSERT [dbo].[ItemTypes] ([Id], [Name]) VALUES (1, N'Buy 1 take 2')
GO
INSERT [dbo].[ItemTypes] ([Id], [Name]) VALUES (2, N'Clearance Sale')
GO
INSERT [dbo].[ItemTypes] ([Id], [Name]) VALUES (2, N'Markdown Item')
GO
SET IDENTITY_INSERT [dbo].[ItemTypes] OFF
------------------------------------------
SET IDENTITY_INSERT [dbo].[AspNetRoles] ON 
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (1, N'Admin', N'ADMIN', N'979797')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (2, N'User', N'USER', N'979799')
GO
SET IDENTITY_INSERT [dbo].[AspNetRoles] OFF
GO

update  [dbo].[Categories]  set [Description] = "Monthly Hampers"
where id =3