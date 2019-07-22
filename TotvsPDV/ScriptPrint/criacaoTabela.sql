USE [TotvsPDV]
GO

/****** Object:  Table [dbo].[RegistroCaixa]    Script Date: 22/07/2019 04:00:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RegistroCaixa](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[produto] [varchar](50) NOT NULL,
	[valor] [decimal](18, 2) NOT NULL,
	[dinheiro] [decimal](18, 2) NOT NULL,
	[troco] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_RegistroCaixa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


