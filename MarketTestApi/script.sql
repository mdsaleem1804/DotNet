USE [TestMarkel]
GO
/****** Object:  Table [dbo].[Claims]    Script Date: 7/30/2020  6:08:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Claims](
	[UCR] [varchar](20) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[ClaimDate] [datetime] NOT NULL,
	[LossDate] [datetime] NOT NULL,
	[AssuredName] [varchar](100) NOT NULL,
	[IncurredClass] [decimal](15, 2) NOT NULL,
	[Closed] [bit] NOT NULL,
 CONSTRAINT [PK_Claims] PRIMARY KEY CLUSTERED 
(
	[UCR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClaimType]    Script Date: 7/30/2020  6:08:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClaimType](
	[Id] [int] NOT NULL,
	[Name] [varchar](20) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 7/30/2020  6:08:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[Id] [int] NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[Address1] [varchar](100) NOT NULL,
	[Address2] [varchar](100) NOT NULL,
	[Address3] [varchar](100) NOT NULL,
	[PostCode] [varchar](20) NOT NULL,
	[Country] [varchar](50) NOT NULL,
	[Active] [bit] NOT NULL,
	[InsuranceEndDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
