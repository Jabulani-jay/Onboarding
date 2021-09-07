USE [Users]
GO

/****** Object:  Table [dbo].[CompletedTask]    Script Date: 2021/09/06 15:11:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CompletedTask]') AND type in (N'U'))
DROP TABLE [dbo].[CompletedTask]
GO

/****** Object:  Table [dbo].[CompletedTask]    Script Date: 2021/09/06 15:11:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CompletedTask](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[TaskCompleted] [varchar](50) NULL,
 CONSTRAINT [PK_CompletedTask] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


