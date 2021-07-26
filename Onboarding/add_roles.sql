USE [Users]
GO

INSERT INTO [dbo].[roles]
           ([roleId]
           ,[role]
           ,[desc])
     VALUES
           (1,
           'admin',
           'admin for recruits to be on boarded')
GO

INSERT INTO [dbo].[roles]
           ([roleId]
           ,[role]
           ,[desc])
     VALUES
           (2,
           'recruit',
           'recruits to be on boarded')
GO


