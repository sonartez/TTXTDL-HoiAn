USE [Sonartez_Server]
GO
/****** Object:  Table [dbo].[tblActivityLog]    Script Date: 12/11/2014 6:12:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblActivityLog](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ActivityType] [nvarchar](150) NULL,
	[UserID] [uniqueidentifier] NULL,
	[UserName] [nvarchar](100) NULL,
	[ClientID] [uniqueidentifier] NULL,
	[ClientName] [nvarchar](150) NULL,
	[CreateDate] [datetime] NULL,
	[Descriptions] [nvarchar](250) NULL,
 CONSTRAINT [PK_ActivityLog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblClient]    Script Date: 12/11/2014 6:12:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblClient](
	[ClientID] [uniqueidentifier] NOT NULL,
	[ClientName] [nvarchar](150) NULL,
	[ClientCode] [nvarchar](50) NULL,
	[LocationCode] [nvarchar](50) NULL,
	[LocationName] [nvarchar](150) NULL,
	[Descriptions] [nvarchar](500) NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_tblClient] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblConsultantLog]    Script Date: 12/11/2014 6:12:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblConsultantLog](
	[ID] [nvarchar](50) NOT NULL,
	[ConsType] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[FinishDate] [datetime] NULL,
	[FinishType] [nvarchar](50) NULL,
	[SubmitDate] [datetime] NULL,
	[Status] [nvarchar](50) NULL,
	[ClientID] [uniqueidentifier] NULL,
	[ClientCode] [nvarchar](50) NULL,
	[ClientName] [nvarchar](50) NULL,
	[UserID] [uniqueidentifier] NULL,
	[UserName] [nvarchar](100) NULL,
	[TargetType] [nvarchar](50) NULL,
	[TargetName] [nvarchar](250) NULL,
	[TargetPhoneNumber] [nvarchar](50) NULL,
	[TargetEmail] [nvarchar](150) NULL,
	[TargetCountry] [nvarchar](50) NULL,
	[TargetCount] [int] NULL,
	[Question] [nvarchar](500) NULL,
	[AnswerRef] [nvarchar](250) NULL,
	[Descriptions] [nvarchar](500) NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_tblConsultantLog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblInfor]    Script Date: 12/11/2014 6:12:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblInfor](
	[ID] [uniqueidentifier] NOT NULL,
	[InfoTitle] [nvarchar](250) NULL,
	[InfoContent] [ntext] NULL,
	[InfoTag] [nvarchar](250) NULL,
	[CreateUserID] [uniqueidentifier] NULL,
	[UpdateUserID] [uniqueidentifier] NULL,
	[CreateDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[Status] [nvarchar](50) NULL,
	[InfoType] [nvarchar](50) NULL,
	[BeginDate] [datetime] NULL,
	[ExprieDate] [datetime] NULL,
	[InfoContentHtml] [ntext] NULL,
 CONSTRAINT [PK_tblInfor] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblPermission]    Script Date: 12/11/2014 6:12:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPermission](
	[PermissionCode] [nvarchar](10) NOT NULL,
	[PermissionName] [nvarchar](250) NULL,
 CONSTRAINT [PK_tblPermission] PRIMARY KEY CLUSTERED 
(
	[PermissionCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblUpdate]    Script Date: 12/11/2014 6:12:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUpdate](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[LastConsutantUpdate] [datetime] NULL,
	[LastInfoUpdate] [datetime] NULL,
	[LastUserUpdate] [datetime] NULL,
	[LastClientUpdate] [datetime] NULL,
	[LastUserPermissionUpdate] [datetime] NULL,
	[LastActivityLogUpdate] [datetime] NULL,
 CONSTRAINT [PK_tblUpdate] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 12/11/2014 6:12:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUser](
	[UserID] [uniqueidentifier] NOT NULL,
	[UserName] [nvarchar](100) NULL,
	[FullName] [nvarchar](100) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[Email] [nvarchar](100) NULL,
	[Password] [nvarchar](50) NULL,
	[LastLoginTime] [datetime] NULL,
	[Active] [int] NULL,
	[UpdateDate] [datetime] NULL,
	[Permission] [nvarchar](20) NULL,
 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblUserPermission]    Script Date: 12/11/2014 6:12:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUserPermission](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [uniqueidentifier] NULL,
	[PermissionID] [nvarchar](10) NULL,
	[PermissionName] [nvarchar](250) NULL,
	[UpdateTime] [datetime] NULL,
 CONSTRAINT [PK_tblUserPermission] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
