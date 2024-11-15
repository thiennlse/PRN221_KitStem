CREATE database [KitsStemDB]
GO

USE [KitsStemDB]
GO
/****** Object:  Table [dbo].[Cart_Items]    Script Date: 11/15/2024 10:46:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart_Items](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[kit_id] [int] NULL,
	[quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Favorites]    Script Date: 11/15/2024 10:46:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Favorites](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[kit_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Help_Histories]    Script Date: 11/15/2024 10:46:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Help_Histories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_lab_id] [int] NULL,
	[step_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kit_Orders]    Script Date: 11/15/2024 10:46:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kit_Orders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[order_id] [int] NULL,
	[kit_id] [int] NULL,
	[quantity] [int] NULL,
	[price] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kit_Stems]    Script Date: 11/15/2024 10:46:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kit_Stems](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[attribute] [varchar](255) NULL,
	[status] [int] NULL,
	[imageUrl] [nvarchar](255) NULL,
	[name] [nvarchar](255) NULL,
	[quantity] [int] NULL,
	[price] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Labs]    Script Date: 11/15/2024 10:46:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Labs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[kit_id] [int] NULL,
	[description] [text] NULL,
	[step] [int] NULL,
	[help] [int] NULL,
	[deadline_day] [int] NULL,
	[Status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 11/15/2024 10:46:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[staff_id] [int] NULL,
	[user_id] [int] NULL,
	[phone] [varchar](255) NULL,
	[create_day] [datetime] NULL,
	[order_day] [datetime] NULL,
	[total_price] [float] NULL,
	[image] [varchar](255) NULL,
	[status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Steps]    Script Date: 11/15/2024 10:46:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Steps](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[lab_id] [int] NULL,
	[description] [text] NULL,
	[step] [int] NULL,
	[status] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User_Labs]    Script Date: 11/15/2024 10:46:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Labs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[lab_id] [int] NULL,
	[deadline] [datetime] NULL,
	[imageUrl] [nvarchar](255) NULL,
	[help_remaining] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/15/2024 10:46:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[roleId] [varchar](255) NULL,
	[name] [varchar](255) NULL,
	[phone] [varchar](255) NULL,
	[email] [varchar](255) NULL,
	[password] [varchar](255) NULL,
	[username] [varchar](255) NULL,
	[role] [int] NULL,
	[description] [text] NULL,
	[DOB] [datetime] NULL,
	[status] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cart_Items]  WITH CHECK ADD  CONSTRAINT [FK_CartItems_Kit] FOREIGN KEY([kit_id])
REFERENCES [dbo].[Kit_Stems] ([id])
GO
ALTER TABLE [dbo].[Cart_Items] CHECK CONSTRAINT [FK_CartItems_Kit]
GO
ALTER TABLE [dbo].[Cart_Items]  WITH CHECK ADD  CONSTRAINT [FK_CartItems_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Cart_Items] CHECK CONSTRAINT [FK_CartItems_User]
GO
ALTER TABLE [dbo].[Favorites]  WITH CHECK ADD  CONSTRAINT [FK_Favorites_Kit] FOREIGN KEY([kit_id])
REFERENCES [dbo].[Kit_Stems] ([id])
GO
ALTER TABLE [dbo].[Favorites] CHECK CONSTRAINT [FK_Favorites_Kit]
GO
ALTER TABLE [dbo].[Favorites]  WITH CHECK ADD  CONSTRAINT [FK_Favorites_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Favorites] CHECK CONSTRAINT [FK_Favorites_User]
GO
ALTER TABLE [dbo].[Help_Histories]  WITH CHECK ADD  CONSTRAINT [FK_HelpHistories_Step] FOREIGN KEY([step_id])
REFERENCES [dbo].[Steps] ([id])
GO
ALTER TABLE [dbo].[Help_Histories] CHECK CONSTRAINT [FK_HelpHistories_Step]
GO
ALTER TABLE [dbo].[Help_Histories]  WITH CHECK ADD  CONSTRAINT [FK_HelpHistories_UserLab] FOREIGN KEY([user_lab_id])
REFERENCES [dbo].[User_Labs] ([id])
GO
ALTER TABLE [dbo].[Help_Histories] CHECK CONSTRAINT [FK_HelpHistories_UserLab]
GO
ALTER TABLE [dbo].[Kit_Orders]  WITH CHECK ADD  CONSTRAINT [FK_KitOrders_Kit] FOREIGN KEY([kit_id])
REFERENCES [dbo].[Kit_Stems] ([id])
GO
ALTER TABLE [dbo].[Kit_Orders] CHECK CONSTRAINT [FK_KitOrders_Kit]
GO
ALTER TABLE [dbo].[Kit_Orders]  WITH CHECK ADD  CONSTRAINT [FK_KitOrders_Order] FOREIGN KEY([order_id])
REFERENCES [dbo].[Orders] ([id])
GO
ALTER TABLE [dbo].[Kit_Orders] CHECK CONSTRAINT [FK_KitOrders_Order]
GO
ALTER TABLE [dbo].[Labs]  WITH CHECK ADD  CONSTRAINT [FK_Labs_Kit] FOREIGN KEY([kit_id])
REFERENCES [dbo].[Kit_Stems] ([id])
GO
ALTER TABLE [dbo].[Labs] CHECK CONSTRAINT [FK_Labs_Kit]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_User]
GO
ALTER TABLE [dbo].[Steps]  WITH CHECK ADD  CONSTRAINT [FK_Steps_Lab] FOREIGN KEY([lab_id])
REFERENCES [dbo].[Labs] ([id])
GO
ALTER TABLE [dbo].[Steps] CHECK CONSTRAINT [FK_Steps_Lab]
GO
ALTER TABLE [dbo].[User_Labs]  WITH CHECK ADD  CONSTRAINT [FK_UserLabs_Lab] FOREIGN KEY([lab_id])
REFERENCES [dbo].[Labs] ([id])
GO
ALTER TABLE [dbo].[User_Labs] CHECK CONSTRAINT [FK_UserLabs_Lab]
GO
ALTER TABLE [dbo].[User_Labs]  WITH CHECK ADD  CONSTRAINT [FK_UserLabs_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[User_Labs] CHECK CONSTRAINT [FK_UserLabs_User]
GO
