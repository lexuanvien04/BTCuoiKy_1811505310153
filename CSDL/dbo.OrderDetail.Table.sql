USE [HoTenDB]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 06/21/2021 12:38:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderID] [varchar](50) NOT NULL,
	[ProductID] [varchar](50) NOT NULL,
	[ProductName] [nvarchar](50) NULL,
	[Quantity] [int] NULL,
	[Total] [money] NULL,
	[Description] [nchar](10) NULL,
 CONSTRAINT [PK_OrderDetail_1] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
