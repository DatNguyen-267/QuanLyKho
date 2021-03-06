USE [QuanLyKho]
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [DisplayName], [Address], [Phone], [Email], [MoreInfo], [ContractDate]) VALUES (1, N'k9', N'ad', N'12312', N'k9', N'das', CAST(N'2020-12-24T00:00:00.000' AS DateTime))
INSERT [dbo].[Customer] ([Id], [DisplayName], [Address], [Phone], [Email], [MoreInfo], [ContractDate]) VALUES (2, N'dat', N'df', N'41413e', N'darqeq', N'ffff', NULL)
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Suplier] ON 

INSERT [dbo].[Suplier] ([Id], [DisplayName], [Address], [Phone], [Email], [MoreInfo], [ContractDate]) VALUES (1, N'Ktem', N'TPHCM', N'123', N'ktem@gmail', N'free education', NULL)
INSERT [dbo].[Suplier] ([Id], [DisplayName], [Address], [Phone], [Email], [MoreInfo], [ContractDate]) VALUES (2, N'DatN', N'Tien giang', N'324', N'datnguyen', N'thongminh', NULL)
SET IDENTITY_INSERT [dbo].[Suplier] OFF
GO
SET IDENTITY_INSERT [dbo].[Unit] ON 

INSERT [dbo].[Unit] ([Id], [DisplayName]) VALUES (1, N'kg')
INSERT [dbo].[Unit] ([Id], [DisplayName]) VALUES (2, N'thung')
INSERT [dbo].[Unit] ([Id], [DisplayName]) VALUES (3, N'bao')
SET IDENTITY_INSERT [dbo].[Unit] OFF
GO
INSERT [dbo].[Object] ([Id], [DisplayName], [IdUnit], [IdSuplier], [QRCode], [BarCode]) VALUES (N'1', N'Xi mang', 3, 1, NULL, NULL)
INSERT [dbo].[Object] ([Id], [DisplayName], [IdUnit], [IdSuplier], [QRCode], [BarCode]) VALUES (N'2', N'Gach', 1, 1, NULL, NULL)
GO
INSERT [dbo].[Output] ([Id], [DateOutput]) VALUES (N'1', CAST(N'2020-03-04T01:32:03.000' AS DateTime))
INSERT [dbo].[Output] ([Id], [DateOutput]) VALUES (N'2', CAST(N'2020-03-04T01:32:03.000' AS DateTime))
GO
INSERT [dbo].[OutputInfo] ([Id], [IdObject], [IdOutputInfo], [IdCustomer], [Count], [Status]) VALUES (N'1', N'1', N'1', 1, 10, NULL)
INSERT [dbo].[OutputInfo] ([Id], [IdObject], [IdOutputInfo], [IdCustomer], [Count], [Status]) VALUES (N'2', N'2 ', N'1', 1, 200, NULL)
GO
INSERT [dbo].[Input] ([Id], [DateInput]) VALUES (N'1', CAST(N'2020-03-04T01:32:03.000' AS DateTime))
INSERT [dbo].[Input] ([Id], [DateInput]) VALUES (N'2', CAST(N'2020-03-04T01:32:03.000' AS DateTime))
INSERT [dbo].[Input] ([Id], [DateInput]) VALUES (N'3', CAST(N'2020-03-04T01:32:03.000' AS DateTime))
GO
INSERT [dbo].[InputInfo] ([Id], [IdObject], [IdInput], [Count], [InputPrice], [OutputPrice], [Status]) VALUES (N'1', N'1', N'1', 50, 200000, 300000, NULL)
INSERT [dbo].[InputInfo] ([Id], [IdObject], [IdInput], [Count], [InputPrice], [OutputPrice], [Status]) VALUES (N'2', N'2', N'1', 1000, 200, 500, NULL)
GO
SET IDENTITY_INSERT [dbo].[UserRole] ON 

INSERT [dbo].[UserRole] ([Id], [DisplayName]) VALUES (1, N'Admin')
INSERT [dbo].[UserRole] ([Id], [DisplayName]) VALUES (2, N'Nhân viên')
SET IDENTITY_INSERT [dbo].[UserRole] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [DisplayName], [UserName], [Password], [IdRole]) VALUES (1, N'Dat', N'Admin', N'db69fc039dcbd2962cb4d28f5891aae1', 1)
INSERT [dbo].[Users] ([Id], [DisplayName], [UserName], [Password], [IdRole]) VALUES (2, N'Nhân Viên', N'staff', N'978aae9bb6bee8fb75de3e4830a1be46', 2)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
