USE [HoTenDB]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 06/21/2021 12:38:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [varchar](50) NOT NULL,
	[CustomerName] [nvarchar](100) NULL,
	[Sex] [bit] NULL,
	[DOB] [date] NULL,
	[PhoneNumber] [char](10) NULL,
	[Address] [nvarchar](100) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
