USE [tenken]
GO
/****** Object:  Schema [tk]    Script Date: 3/17/2019 7:02:54 PM ******/
CREATE SCHEMA [tk]
GO
/****** Object:  Table [dbo].[tk_book]    Script Date: 3/17/2019 7:02:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tk_book](
	[BookID] [int] IDENTITY(1,1) NOT NULL,
	[BookName] [nchar](100) NOT NULL,
	[BookTypeID] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Description] [nchar](200) NULL,
	[Image] [nchar](200) NULL,
 CONSTRAINT [PK_tk.book] PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tk_book_type]    Script Date: 3/17/2019 7:02:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tk_book_type](
	[BookTypeID] [int] IDENTITY(1,1) NOT NULL,
	[BookTypeName] [nchar](50) NOT NULL,
 CONSTRAINT [PK_tk.book_type] PRIMARY KEY CLUSTERED 
(
	[BookTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tk_cart]    Script Date: 3/17/2019 7:02:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tk_cart](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CartID] [int] NOT NULL,
	[BookID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [int] NOT NULL,
 CONSTRAINT [PK_cart] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tk_user]    Script Date: 3/17/2019 7:02:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tk_user](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nchar](50) NOT NULL,
	[Password] [nchar](200) NOT NULL,
	[Admin] [bit] NOT NULL,
 CONSTRAINT [PK_tk_user] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tk_user_cart_xref]    Script Date: 3/17/2019 7:02:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tk_user_cart_xref](
	[CartID] [int] NOT NULL,
	[UserID] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [tk].[register_user]    Script Date: 3/17/2019 7:02:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [tk].[register_user]
@userName varchar(50),
@password varchar(200),
@resultOut varchar(200) out,
@userIdOut int out
AS
BEGIN
	IF EXISTS (SELECT TOP 1 'x' from dbo.tk_user where UserName= @userName)
	BEGIN
		SET @userIdOut = -1;
		SET @resultOut = 'Failed.UserExist';
		RETURN;
	END

	INSERT INTO tk_user(UserName,Password,Admin) 
	VALUES (@userName,@password,0)
	SET @userIdOut = SCOPE_IDENTITY();
	SET @resultOut = 'Success.CreateUser';
END
GO
