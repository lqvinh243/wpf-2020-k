 USE master;
 Go
 DROP DATABASE MyShop;
 Go
 IF(db_id(N'MyShop') IS NULL)
 CREATE DATABASE MyShop
 GO

 USE MyShop
 GO

/****** Object:  Table [dbo].[Category]    Script Date: 20/04/2020 3:44:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

if not exists (select * from sysobjects where name='Category' and xtype='U')
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [text] NULL,
	[Name_Slug] varchar(255) NULL,
	[CreatedAt] [DATETIME] NOT NULL DEFAULT CURRENT_TIMESTAMP,
	[UpdatedAt] [DATETIME] NOT NULL DEFAULT CURRENT_TIMESTAMP,
	[DeletedAt] [DATETIME] NULL
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 20/04/2020 3:44:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

if not exists (select * from sysobjects where name='Product' and xtype='U')
CREATE TABLE [dbo].[Product](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CatID] [int] NULL,
	[Name] [text] NULL,
	[Description] [text] NULL,
	[Name_Slug] varchar(255) NULL,
	[SKU] [text] NOT NULL,
	[Price] [float] NULL,
	[Quantity] [int] NULL,
	[ImagePath] [text] NULL,
	[CreatedAt] [DATETIME] NOT NULL DEFAULT CURRENT_TIMESTAMP,
	[UpdatedAt] [DATETIME] NOT NULL DEFAULT CURRENT_TIMESTAMP,
	[DeletedAt] [DATETIME] NULL
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

if not exists (select * from sysobjects where name='Order' and xtype='U')
CREATE TABLE [dbo].[Order](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] varchar(50) NOT NULL,
	[TotalAmount] [float] NOT NULL DEFAULT 0,
	[CreatedAt] [DATETIME] NOT NULL DEFAULT CURRENT_TIMESTAMP,
	[UpdatedAt] [DATETIME] NOT NULL DEFAULT CURRENT_TIMESTAMP,
	[DeletedAt] [DATETIME] NULL,
	[ClientID] [int] NULL,
	[ManagerID] [int] NULL
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

if not exists (select * from sysobjects where name='OrderProduct')
CREATE TABLE [dbo].[OrderProduct](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProductID] [int] NOT NULL,
	[Name] varchar(255) NOT NULL,
	[OrderID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Amount] [float] NOT NULL,
	[TotalAmount] [float] NOT NULL,
	[CreatedAt] [DATETIME] NOT NULL DEFAULT CURRENT_TIMESTAMP,
	[UpdatedAt] [DATETIME] NOT NULL DEFAULT CURRENT_TIMESTAMP,
	[DeletedAt] [DATETIME] NULL,
	CONSTRAINT UC_OrderProduct UNIQUE (ProductID,OrderID),
 CONSTRAINT [PK_OrderProduct] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

if not exists (select * from sysobjects where name='Client')
CREATE TABLE [dbo].[Client](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] varchar(255) NOT NULL,
	[Password] varchar(255) NOT NULL,
	[Name] varchar(255) NOT NULL,
	[RoleID] [int] NOT NULL,
	[CreatedAt] [DATETIME] NOT NULL DEFAULT CURRENT_TIMESTAMP,
	[UpdatedAt] [DATETIME] NOT NULL DEFAULT CURRENT_TIMESTAMP,
	[DeletedAt] [DATETIME] NULL,
	UNIQUE(UserName),
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

if not exists (select * from sysobjects where name='Manager')
CREATE TABLE [dbo].[Manager](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] varchar(255) NOT NULL,
	[Password] varchar(255) NOT NULL,
	[RoleID] [int] NOT NULL,
	[Name] varchar(255) NOT NULL,
	[CreatedAt] [DATETIME] NOT NULL DEFAULT CURRENT_TIMESTAMP,
	[UpdatedAt] [DATETIME] NOT NULL DEFAULT CURRENT_TIMESTAMP,
	[DeletedAt] [DATETIME] NULL
 CONSTRAINT [PK_Manager] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 
GO

if not exists (select * from sysobjects where name='SupperAdmin')
CREATE TABLE [dbo].[SupperAdmin](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] varchar(255) NOT NULL,
	[Password] varchar(255) NOT NULL,
	[RoleID] [int] NOT NULL,
	[Name] varchar(255) NOT NULL,
	[CreatedAt] [DATETIME] NOT NULL DEFAULT CURRENT_TIMESTAMP,
	[UpdatedAt] [DATETIME] NOT NULL DEFAULT CURRENT_TIMESTAMP,
	[DeletedAt] [DATETIME] NULL
 CONSTRAINT [PK_SupperAdmin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

if not exists (select * from sysobjects where name='Role')
CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] varchar(255) NOT NULL,
	[RoleID] [int] NOT NULL,
	[CreatedAt] [DATETIME] NOT NULL DEFAULT CURRENT_TIMESTAMP,
	[UpdatedAt] [DATETIME] NOT NULL DEFAULT CURRENT_TIMESTAMP,
	[DeletedAt] [DATETIME] NULL,
	UNIQUE (RoleID),
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

if not exists (select * from INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME ='FK_Product_Category')
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CatID])
REFERENCES [dbo].[Category] ([ID])
GO

if not exists (select * from INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME ='FK_Product_Category')
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO

if not exists (select * from INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME ='FK_Client_Role')
ALTER TABLE [dbo].[Client] WITH CHECK ADD  CONSTRAINT [FK_Client_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO

if not exists (select * from INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME ='FK_Client_Role')
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_Role]
GO

if not exists (select * from INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME ='FK_Manager_Role')
ALTER TABLE [dbo].[Manager] WITH CHECK ADD  CONSTRAINT [FK_Manager_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO

if not exists (select * from INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME ='FK_Manager_Role')
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Manager_Role]
GO

if not exists (select * from INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME ='FK_SupperAdmin_Role')
ALTER TABLE [dbo].[SupperAdmin] WITH CHECK ADD  CONSTRAINT [FK_SupperAdmin_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO

if not exists (select * from INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME ='FK_SupperAdmin_Role')
ALTER TABLE [dbo].[SupperAdmin] CHECK CONSTRAINT [FK_SupperAdmin_Role]
GO

if not exists (select * from INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME ='FK_Order_Client')
ALTER TABLE [dbo].[Order] WITH CHECK ADD  CONSTRAINT [FK_Order_Client] FOREIGN KEY([ClientID])
REFERENCES [dbo].[Client] ([ID])
GO

if not exists (select * from INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME ='FK_Order_Client')
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Order_Client]
GO

if not exists (select * from INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME ='FK_Order_Manager')
ALTER TABLE [dbo].[Order] WITH CHECK ADD  CONSTRAINT [FK_Order_Manager] FOREIGN KEY([ManagerID])
REFERENCES [dbo].[Manager] ([ID])
GO

if not exists (select * from INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME ='FK_Order_Manager')
ALTER TABLE [dbo].[Manager] CHECK CONSTRAINT [FK_Order_Manager]
GO

if not exists (select * from INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME ='FK_OrderProduct_Order')
ALTER TABLE [dbo].[OrderProduct] WITH CHECK ADD  CONSTRAINT [FK_OrderProduct_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([ID])
GO

if not exists (select * from INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME ='FK_OrderProduct_Order')
ALTER TABLE [dbo].[OrderProduct] CHECK CONSTRAINT [FK_OrderProduct_Order]
GO

if not exists (select * from INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME ='FK_OrderProduct_Product')
ALTER TABLE [dbo].[OrderProduct] WITH CHECK ADD  CONSTRAINT [FK_OrderProduct_Product] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Product] ([ID])
GO

if not exists (select * from INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME ='FK_OrderProduct_Product')
ALTER TABLE [dbo].[OrderProduct] CHECK CONSTRAINT FK_OrderProduct_Product
GO


INSERT INTO [dbo].[Role] (NAME,RoleID) VALUES ('SUPPER_ADMIN',1)
INSERT INTO [dbo].[Role] (NAME,RoleID) VALUES ('MANAGER',2)
INSERT INTO [dbo].[Role] (NAME,RoleID) VALUES ('CLIENT',3)