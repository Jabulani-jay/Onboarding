USE [Users]
GO

/****** Object:  Table [dbo].[roles]    Script Date: 2021/07/22 20:52:46 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[roles]') AND type in (N'U'))
DROP TABLE [dbo].[roles]
GO

/****** Object:  Table [dbo].[roles]    Script Date: 2021/07/22 20:52:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[roles](
	[roleId] [int] NOT NULL,
	[role] [varchar](15) NOT NULL,
	[desc] [varchar](144) NULL,
 CONSTRAINT [PK_roles] PRIMARY KEY CLUSTERED 
(
	[roleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


