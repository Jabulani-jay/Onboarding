USE [Users]
GO

/****** Object:  Table [dbo].[Task]    Script Date: 2021/09/06 12:09:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Task]') AND type in (N'U'))
DROP TABLE [dbo].[Task]
GO

/****** Object:  Table [dbo].[Task]    Script Date: 2021/09/06 12:09:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Task](
	[progressId] [int] IDENTITY(1,1) NOT NULL,
	[task] [varchar](50) NULL,
	[desc] [varbinary](50) NULL,
 CONSTRAINT [PK_progress] PRIMARY KEY CLUSTERED 
(
	[progressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
5


INSERT INTO [dbo].[Task]
           ([task])
     VALUES
           ('Tools'),
		   ('Policies and guidelines'),
		   ('Time Management'),
		   ('Training'),
		   ('Rules of engagement'),
		   ('Behaviour manifesto'),
		   ('Who we are?')
GO

