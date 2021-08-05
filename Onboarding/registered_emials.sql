USE [Users]
GO

ALTER TABLE [dbo].[registered_emails] DROP CONSTRAINT [DF_registered_emails_created]
GO

/****** Object:  Table [dbo].[registered_emails]    Script Date: 2021/08/04 20:37:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[registered_emails]') AND type in (N'U'))
DROP TABLE [dbo].[registered_emails]
GO

/****** Object:  Table [dbo].[registered_emails]    Script Date: 2021/08/04 20:37:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[registered_emails](
	[emailId] [int]IDENTITY(1,1) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[created] [datetime] NOT NULL,
 CONSTRAINT [PK_registered_emails] PRIMARY KEY CLUSTERED 
(
	[emailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[registered_emails] ADD  CONSTRAINT [DF_registered_emails_created]  DEFAULT (getdate()) FOR [created]
GO


