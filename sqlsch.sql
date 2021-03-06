-- Script Date: 1/6/2015 9:35 AM  - ErikEJ.SqlCeScripting version 3.5.2.42
-- Database information:
-- Locale Identifier: 1033
-- Encryption Mode: 
-- Case Sensitive: False
-- Database: D:\Apps\Hội An\DNNEW\SonartezClient.sdf
-- ServerVersion: 4.0.8876.1
-- DatabaseSize: 11.457 MB
-- Created: 1/5/2015 2:47 PM

-- User Table information:
-- Number of tables: 8
-- tblActivityLog: 0 row(s)
-- tblClient: 2 row(s)
-- tblConsultantLog: 0 row(s)
-- tblInfor: 1894 row(s)
-- tblPermission: 0 row(s)
-- tblUpdate: 1 row(s)
-- tblUser: 4 row(s)
-- tblUserPermission: 0 row(s)

CREATE TABLE [tblUserPermission] (
  [ID] int IDENTITY (2,1) NOT NULL
, [UserID] uniqueidentifier NULL
, [PermissionID] nvarchar(10) NULL
, [PermissionName] nvarchar(250) NULL
, [UpdateTime] datetime NULL
, [ServerUpdate] datetime NULL
);
GO
CREATE TABLE [tblUser] (
  [UserID] uniqueidentifier NOT NULL
, [UserName] nvarchar(100) NULL
, [FullName] nvarchar(100) NULL
, [PhoneNumber] nvarchar(50) NULL
, [Email] nvarchar(100) NULL
, [Password] nvarchar(50) NULL
, [LastLoginTime] datetime NULL
, [Active] int NULL
, [UpdateDate] datetime NULL
, [Permission] nvarchar(20) NULL
, [IsDeleted] int NULL
, [ServerUpdate] datetime NULL
);
GO
CREATE TABLE [tblUpdate] (
  [ID] int IDENTITY (2,1) NOT NULL
, [LastConsutantUpdate] datetime NULL
, [LastInfoUpdate] datetime NULL
, [LastUserUpdate] datetime NULL
, [LastClientUpdate] datetime NULL
, [LastUserPermissionUpdate] datetime NULL
, [LastActivityLogUpdate] datetime NULL
, [LocalConsutantUpdate] datetime NULL
, [LocalInfoUpdate] datetime NULL
, [LocalUserUpdate] datetime NULL
, [LocalActivityLogUpdate] datetime NULL
, [LocalClientUpdate] datetime NULL
);
GO
CREATE TABLE [tblPermission] (
  [PermissionCode] nvarchar(10) NOT NULL
, [PermissionName] nvarchar(250) NULL
, [ServerUpdate] datetime NULL
);
GO
CREATE TABLE [tblInfor] (
  [ID] uniqueidentifier NOT NULL
, [InfoTitle] nvarchar(250) NULL
, [InfoContent] ntext NULL
, [InfoTag] nvarchar(250) NULL
, [CreateUserID] uniqueidentifier NULL
, [UpdateUserID] uniqueidentifier NULL
, [CreateDate] datetime NULL
, [UpdateDate] datetime NULL
, [Status] nvarchar(50) NULL
, [InfoType] nvarchar(50) NULL
, [BeginDate] datetime NULL
, [ExprieDate] datetime NULL
, [InfoContentHtml] ntext NULL
, [IsDeleted] int NULL
, [ServerUpdate] datetime NULL
, [Location] nvarchar(100) NULL
, [Category] nvarchar(200) NULL
);
GO
CREATE TABLE [tblConsultantLog] (
  [ID] nvarchar(50) NOT NULL
, [ConsType] nvarchar(50) NULL
, [CreateDate] datetime NULL
, [FinishDate] datetime NULL
, [FinishType] nvarchar(50) NULL
, [SubmitDate] datetime NULL
, [Status] nvarchar(50) NULL
, [ClientID] uniqueidentifier NULL
, [ClientCode] nvarchar(50) NULL
, [ClientName] nvarchar(50) NULL
, [UserID] uniqueidentifier NULL
, [UserName] nvarchar(100) NULL
, [TargetType] nvarchar(50) NULL
, [TargetName] nvarchar(250) NULL
, [TargetPhoneNumber] nvarchar(50) NULL
, [TargetEmail] nvarchar(150) NULL
, [TargetCountry] nvarchar(50) NULL
, [TargetCount] int NULL
, [Question] nvarchar(500) NULL
, [AnswerRef] nvarchar(250) NULL
, [Descriptions] nvarchar(500) NULL
, [UpdateDate] datetime NULL
, [IsDeleted] int NULL
, [ServerUpdate] datetime NULL
);
GO
CREATE TABLE [tblClient] (
  [ClientID] uniqueidentifier NOT NULL
, [ClientName] nvarchar(150) NULL
, [ClientCode] nvarchar(50) NULL
, [LocationCode] nvarchar(50) NULL
, [LocationName] nvarchar(150) NULL
, [Descriptions] nvarchar(500) NULL
, [UpdateDate] datetime NULL
, [IsDeleted] int NULL
, [ServerUpdate] datetime NULL
);
GO
CREATE TABLE [tblActivityLog] (
  [ID] int IDENTITY (2,1) NOT NULL
, [ActivityType] nvarchar(150) NULL
, [UserID] uniqueidentifier NULL
, [UserName] nvarchar(100) NULL
, [ClientID] uniqueidentifier NULL
, [ClientName] nvarchar(150) NULL
, [CreateDate] datetime NULL
, [Descriptions] nvarchar(250) NULL
, [IsDeleted] int NULL
, [ServerUpdate] datetime NULL
);
GO
ALTER TABLE [tblUserPermission] ADD CONSTRAINT [PK_tblUserPermission] PRIMARY KEY ([ID]);
GO
ALTER TABLE [tblUser] ADD CONSTRAINT [PK_tblUser] PRIMARY KEY ([UserID]);
GO
ALTER TABLE [tblUpdate] ADD CONSTRAINT [PK_tblUpdate] PRIMARY KEY ([ID]);
GO
ALTER TABLE [tblPermission] ADD CONSTRAINT [PK_tblPermission] PRIMARY KEY ([PermissionCode]);
GO
ALTER TABLE [tblInfor] ADD CONSTRAINT [PK_tblInfor] PRIMARY KEY ([ID]);
GO
ALTER TABLE [tblConsultantLog] ADD CONSTRAINT [PK_tblConsultantLog] PRIMARY KEY ([ID]);
GO
ALTER TABLE [tblClient] ADD CONSTRAINT [PK_tblClient] PRIMARY KEY ([ClientID]);
GO
ALTER TABLE [tblActivityLog] ADD CONSTRAINT [PK_ActivityLog] PRIMARY KEY ([ID]);
GO

