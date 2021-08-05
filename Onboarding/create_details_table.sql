USE [Users]
GO

ALTER TABLE [dbo].[details] DROP CONSTRAINT [FK_details_roles]
GO

ALTER TABLE [dbo].[details] DROP CONSTRAINT [FK_details_email]
GO

ALTER TABLE [dbo].[details] DROP CONSTRAINT [DF_details_active]
GO

ALTER TABLE [dbo].[details] DROP CONSTRAINT [DF_details_role]
GO

/****** Object:  Table [dbo].[details]    Script Date: 2021/08/04 20:35:41 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[details]') AND type in (N'U'))
DROP TABLE [dbo].[details]
GO

/****** Object:  Table [dbo].[details]    Script Date: 2021/08/04 20:35:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[details](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[role] [int] NOT NULL,
	[firstname] [varchar](50) NOT NULL,
	[lastname] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_details] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[password] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[details] ADD  CONSTRAINT [DF_details_role]  DEFAULT ((1)) FOR [role]
GO

ALTER TABLE [dbo].[details] ADD  CONSTRAINT [DF_details_active]  DEFAULT ((1)) FOR [active]
GO

ALTER TABLE [dbo].[details]  WITH CHECK ADD  CONSTRAINT [FK_details_email] FOREIGN KEY([email])
REFERENCES [dbo].[registered_emails] ([email])
GO

ALTER TABLE [dbo].[details] CHECK CONSTRAINT [FK_details_email]
GO

ALTER TABLE [dbo].[details]  WITH CHECK ADD  CONSTRAINT [FK_details_roles] FOREIGN KEY([role])
REFERENCES [dbo].[roles] ([roleId])
GO

ALTER TABLE [dbo].[details] CHECK CONSTRAINT [FK_details_roles]
GO


