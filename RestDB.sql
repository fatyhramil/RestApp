USE [RestDatabase]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 10.04.2022 23:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[RestaurantID] [int] NULL,
	[PeopleCount] [int] NULL,
	[DateTime] [datetime] NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 10.04.2022 23:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Path] [nvarchar](150) NULL,
	[RestaurantID] [int] NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KitchenType]    Script Date: 10.04.2022 23:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KitchenType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_KitchenType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ownership]    Script Date: 10.04.2022 23:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ownership](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[RestaurantID] [int] NULL,
 CONSTRAINT [PK_Ownership] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Restaurant]    Script Date: 10.04.2022 23:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Restaurant](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[PlaceCount] [int] NULL,
	[Image] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[HasTerrace] [bit] NULL,
	[StartTime] [time](7) NULL,
	[EndTime] [time](7) NULL,
	[Hotwords] [nvarchar](150) NULL,
	[AveragePrice] [float] NULL,
	[Rating] [float] NULL,
 CONSTRAINT [PK_Restaurant] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RestaurantKitchen]    Script Date: 10.04.2022 23:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RestaurantKitchen](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RestaurantID] [int] NULL,
	[KitchenID] [int] NULL,
 CONSTRAINT [PK_RestaurantKitchen] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 10.04.2022 23:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 10.04.2022 23:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Phone] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
	[RoleID] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Booking] ON 

INSERT [dbo].[Booking] ([ID], [UserID], [RestaurantID], [PeopleCount], [DateTime]) VALUES (1, 2, 1, 4, CAST(N'2022-04-10T19:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Booking] OFF
GO
SET IDENTITY_INSERT [dbo].[Image] ON 

INSERT [dbo].[Image] ([ID], [Path], [RestaurantID]) VALUES (0, N'D:\Programming\WPF\RestApp\Pract_pr_22\Images\63616.jpg', 1)
SET IDENTITY_INSERT [dbo].[Image] OFF
GO
SET IDENTITY_INSERT [dbo].[KitchenType] ON 

INSERT [dbo].[KitchenType] ([ID], [Name]) VALUES (1, N'Европейская')
INSERT [dbo].[KitchenType] ([ID], [Name]) VALUES (2, N'Грузинская')
INSERT [dbo].[KitchenType] ([ID], [Name]) VALUES (3, N'Китайская')
INSERT [dbo].[KitchenType] ([ID], [Name]) VALUES (4, N'Японская')
INSERT [dbo].[KitchenType] ([ID], [Name]) VALUES (5, N'Итальянская')
SET IDENTITY_INSERT [dbo].[KitchenType] OFF
GO
SET IDENTITY_INSERT [dbo].[Ownership] ON 

INSERT [dbo].[Ownership] ([ID], [UserID], [RestaurantID]) VALUES (1, 3, 1)
SET IDENTITY_INSERT [dbo].[Ownership] OFF
GO
SET IDENTITY_INSERT [dbo].[Restaurant] ON 

INSERT [dbo].[Restaurant] ([ID], [Name], [Description], [Address], [PlaceCount], [Image], [Phone], [HasTerrace], [StartTime], [EndTime], [Hotwords], [AveragePrice], [Rating]) VALUES (1, N'Клод моне', N'Клод моне', N'Москва', 100, NULL, N'+88005553535', 1, CAST(N'12:00:00' AS Time), CAST(N'20:00:00' AS Time), NULL, 2, 5)
SET IDENTITY_INSERT [dbo].[Restaurant] OFF
GO
SET IDENTITY_INSERT [dbo].[RestaurantKitchen] ON 

INSERT [dbo].[RestaurantKitchen] ([ID], [RestaurantID], [KitchenID]) VALUES (1, 1, 1)
SET IDENTITY_INSERT [dbo].[RestaurantKitchen] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([ID], [Name]) VALUES (1, N'Клиент')
INSERT [dbo].[Role] ([ID], [Name]) VALUES (2, N'Владелец')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [Phone], [Password], [Name], [RoleID]) VALUES (2, N'+79872338790', N'OQxU]#YN', N'Рамиль', 1)
INSERT [dbo].[User] ([ID], [Phone], [Password], [Name], [RoleID]) VALUES (3, N'+79872338791', N'KLU^yyF*', N'Вилен', 2)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Restaurant] FOREIGN KEY([RestaurantID])
REFERENCES [dbo].[Restaurant] ([ID])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Restaurant]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_User]
GO
ALTER TABLE [dbo].[Image]  WITH CHECK ADD  CONSTRAINT [FK_Image_Restaurant] FOREIGN KEY([RestaurantID])
REFERENCES [dbo].[Restaurant] ([ID])
GO
ALTER TABLE [dbo].[Image] CHECK CONSTRAINT [FK_Image_Restaurant]
GO
ALTER TABLE [dbo].[Ownership]  WITH CHECK ADD  CONSTRAINT [FK_Ownership_Restaurant] FOREIGN KEY([RestaurantID])
REFERENCES [dbo].[Restaurant] ([ID])
GO
ALTER TABLE [dbo].[Ownership] CHECK CONSTRAINT [FK_Ownership_Restaurant]
GO
ALTER TABLE [dbo].[Ownership]  WITH CHECK ADD  CONSTRAINT [FK_Ownership_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Ownership] CHECK CONSTRAINT [FK_Ownership_User]
GO
ALTER TABLE [dbo].[RestaurantKitchen]  WITH CHECK ADD  CONSTRAINT [FK_RestaurantKitchen_KitchenType] FOREIGN KEY([KitchenID])
REFERENCES [dbo].[KitchenType] ([ID])
GO
ALTER TABLE [dbo].[RestaurantKitchen] CHECK CONSTRAINT [FK_RestaurantKitchen_KitchenType]
GO
ALTER TABLE [dbo].[RestaurantKitchen]  WITH CHECK ADD  CONSTRAINT [FK_RestaurantKitchen_Restaurant] FOREIGN KEY([RestaurantID])
REFERENCES [dbo].[Restaurant] ([ID])
GO
ALTER TABLE [dbo].[RestaurantKitchen] CHECK CONSTRAINT [FK_RestaurantKitchen_Restaurant]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
