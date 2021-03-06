-- Script Date: 1/6/2015 9:43 AM  - ErikEJ.SqlCeScripting version 3.5.2.42
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
-- tblClient: 1 row(s)
-- tblConsultantLog: 0 row(s)
-- tblInfor: 1894 row(s)
-- tblPermission: 0 row(s)
-- tblUpdate: 1 row(s)
-- tblUser: 2 row(s)
-- tblUserPermission: 0 row(s)

SET IDENTITY_INSERT [tblUserPermission] OFF;
GO
INSERT INTO [tblUser] ([UserID],[UserName],[FullName],[PhoneNumber],[Email],[Password],[LastLoginTime],[Active],[UpdateDate],[Permission],[IsDeleted],[ServerUpdate]) VALUES ('b0b6997c-282b-4aff-b286-b0820cdb0100',N'admin',N'Administrator',N'0906576535',N'vanlinh.dev.vn@gmail.com',N'123456',{ts '2014-05-05 00:00:00.000'},1,{ts '2014-12-29 10:54:47.593'},N'Toàn quyền',0,NULL);
GO
INSERT INTO [tblUser] ([UserID],[UserName],[FullName],[PhoneNumber],[Email],[Password],[LastLoginTime],[Active],[UpdateDate],[Permission],[IsDeleted],[ServerUpdate]) VALUES ('df3be810-a6f4-4db2-92bd-fa6780c98565',N'vanlinh',N'Đặng Văn Linh',N'1234567895',N'vanlinh@dev.vn',N'123456',{ts '2014-05-05 00:00:00.000'},1,{ts '2014-12-29 10:54:47.763'},N'Toàn quyền',0,NULL);
GO
SET IDENTITY_INSERT [tblUpdate] ON;
GO
INSERT INTO [tblUpdate] ([ID],[LastConsutantUpdate],[LastInfoUpdate],[LastUserUpdate],[LastClientUpdate],[LastUserPermissionUpdate],[LastActivityLogUpdate],[LocalConsutantUpdate],[LocalInfoUpdate],[LocalUserUpdate],[LocalActivityLogUpdate],[LocalClientUpdate]) VALUES (2,{ts '2000-01-01 00:00:00.000'},{ts '2014-12-29 03:54:30.037'},{ts '2014-12-29 03:54:46.103'},{ts '2014-12-29 02:57:41.307'},{ts '2000-01-01 00:00:00.000'},{ts '2000-01-01 00:00:00.000'},{ts '2000-01-01 00:00:00.000'},{ts '2014-12-29 10:54:09.310'},{ts '2014-12-29 10:54:47.847'},{ts '2000-01-01 00:00:00.000'},{ts '2014-12-29 09:57:42.007'});
GO
SET IDENTITY_INSERT [tblUpdate] OFF;
GO
INSERT INTO [tblClient] ([ClientID],[ClientName],[ClientCode],[LocationCode],[LocationName],[Descriptions],[UpdateDate],[IsDeleted],[ServerUpdate]) VALUES ('9e82f6ef-9f96-4d8c-9763-ed3a8a371172',N'TRẠM 01',N'TR01',N'DNA',N'Đà Nẵng',N'Mô tả',{ts '2014-12-19 18:13:35.727'},0,NULL);
GO
SET IDENTITY_INSERT [tblActivityLog] OFF;
GO
DBCC CHECKIDENT ('tblUserPermission', RESEED, 2);
GO
DBCC CHECKIDENT ('tblUpdate', RESEED, 3);
GO
DBCC CHECKIDENT ('tblActivityLog', RESEED, 2);
GO

