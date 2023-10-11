/****** Drops then creates the database required by our program ******/
--DROP DATABASE HashedPasswords
CREATE DATABASE HashedPasswords


USE [HashedPasswords]
GO
/****** Object:  Table [dbo].[EncryptedVault]    Script Date: 09-10-2023 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EncryptedVault](
	[Vaultid] [int] IDENTITY(1,1) NOT NULL,
	[Userguid] [uniqueidentifier] NOT NULL,
	[Sitename] [varbinary](max) NOT NULL,
	[Username] [varbinary](max) NOT NULL,
	[Password] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_EncryptedVault_1] PRIMARY KEY CLUSTERED 
(
	[Vaultid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 09-10-2023 15:41:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Guid] [uniqueidentifier] NOT NULL,
	[Username] [nvarchar](255) NOT NULL UNIQUE,
	[Password] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Guid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[EncryptedVault]  WITH CHECK ADD  CONSTRAINT [FK_EncryptedVault_User] FOREIGN KEY([Userguid])
REFERENCES [dbo].[User] ([Guid])
GO
ALTER TABLE [dbo].[EncryptedVault] CHECK CONSTRAINT [FK_EncryptedVault_User]
GO
