USE [SystemElementMVC5]
GO
SET IDENTITY_INSERT [dbo].[Elements] ON 

INSERT [dbo].[Elements] ([Id], [Url], [ParentId]) VALUES (1, N'\root', NULL)
INSERT [dbo].[Elements] ([Id], [Url], [ParentId]) VALUES (2, N'\parent1_1', 1)
INSERT [dbo].[Elements] ([Id], [Url], [ParentId]) VALUES (3, N'\parent1_2', 1)
INSERT [dbo].[Elements] ([Id], [Url], [ParentId]) VALUES (4, N'\parent1_3', 1)
INSERT [dbo].[Elements] ([Id], [Url], [ParentId]) VALUES (5, N'\parent3_1', 4)
INSERT [dbo].[Elements] ([Id], [Url], [ParentId]) VALUES (6, N'\parent3_2', 4)
INSERT [dbo].[Elements] ([Id], [Url], [ParentId]) VALUES (7, N'\parent3_3', 4)
INSERT [dbo].[Elements] ([Id], [Url], [ParentId]) VALUES (8, N'\parent3_3_3', 7)
SET IDENTITY_INSERT [dbo].[Elements] OFF