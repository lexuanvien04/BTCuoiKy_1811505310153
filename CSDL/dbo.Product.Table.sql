USE [HoTenDB]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 06/21/2021 12:38:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductID] [varchar](50) NOT NULL,
	[ProductName] [nvarchar](100) NULL,
	[UnitCost] [money] NULL,
	[Quantity] [int] NULL,
	[image] [varbinary](max) NULL,
	[CategoryID] [varchar](50) NOT NULL,
	[Description] [nvarchar](100) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC,
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
