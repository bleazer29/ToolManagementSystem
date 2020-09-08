USE [TMSdb]
GO
/****** Object:  Table [dbo].[Attribute]    Script Date: 08.09.2020 8:18:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attribute](
	[AttributeId] [bigint] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[UnitId] [bigint] NULL,
 CONSTRAINT [PK_Attribute] PRIMARY KEY CLUSTERED 
(
	[AttributeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contract]    Script Date: 08.09.2020 8:18:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contract](
	[ContractId] [bigint] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[DateStart] [datetime2](7) NULL,
	[DateEnd] [datetime2](7) NULL,
	[CounterpartyId] [bigint] NOT NULL,
 CONSTRAINT [PK_Contract] PRIMARY KEY CLUSTERED 
(
	[ContractId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContractWell]    Script Date: 08.09.2020 8:18:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContractWell](
	[ContractWellId] [bigint] NOT NULL,
	[ContractId] [bigint] NOT NULL,
	[WellId] [bigint] NOT NULL,
 CONSTRAINT [PK_ContractWell] PRIMARY KEY CLUSTERED 
(
	[ContractWellId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Counterparty]    Script Date: 08.09.2020 8:18:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Counterparty](
	[CounterpartyId] [bigint] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Address] [nvarchar](250) NULL,
	[EDRPOU] [nvarchar](10) NULL,
 CONSTRAINT [PK_Counterparty] PRIMARY KEY CLUSTERED 
(
	[CounterpartyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cycle]    Script Date: 08.09.2020 8:18:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cycle](
	[CycleId] [bigint] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[CreatorId] [bigint] NOT NULL,
	[CreationDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Cycle] PRIMARY KEY CLUSTERED 
(
	[CycleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CycleItem]    Script Date: 08.09.2020 8:18:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CycleItem](
	[CycleItemId] [bigint] NOT NULL,
	[PrevToolStatusId] [bigint] NULL,
	[CurrToolStatusId] [bigint] NOT NULL,
	[NextToolStatusId] [bigint] NULL,
	[CycleId] [bigint] NOT NULL,
 CONSTRAINT [PK_CycleItem] PRIMARY KEY CLUSTERED 
(
	[CycleItemId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 08.09.2020 8:18:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentId] [bigint] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Document]    Script Date: 08.09.2020 8:18:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Document](
	[DocumentId] [nchar](10) NULL,
	[Name] [nchar](150) NULL,
	[FilePath] [nchar](250) NULL,
	[FileExtension] [nchar](20) NULL,
	[CreatorId] [bigint] NULL,
	[CreationDate] [datetime2](7) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nomenclature]    Script Date: 08.09.2020 8:18:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nomenclature](
	[NomenclatureId] [bigint] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[VendorCode] [nvarchar](50) NOT NULL,
	[MaxOperatingTime] [bigint] NOT NULL,
 CONSTRAINT [PK_Nomenclature] PRIMARY KEY CLUSTERED 
(
	[NomenclatureId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NomenclatureAttribute]    Script Date: 08.09.2020 8:18:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NomenclatureAttribute](
	[NomenclatureAttributeId] [bigint] NOT NULL,
	[NomenclatureId] [bigint] NOT NULL,
	[AttributeId] [bigint] NOT NULL,
	[Value] [float] NOT NULL,
 CONSTRAINT [PK_NomenclatureAttribute] PRIMARY KEY CLUSTERED 
(
	[NomenclatureAttributeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderStatus]    Script Date: 08.09.2020 8:18:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderStatus](
	[OrderStatusId] [bigint] NOT NULL,
	[Name] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_OrderStatus] PRIMARY KEY CLUSTERED 
(
	[OrderStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 08.09.2020 8:18:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[PermissionId] [bigint] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[ViewName] [nvarchar](250) NOT NULL,
	[Alias] [nvarchar](250) NULL,
	[OrderNo] [int] NULL,
	[ParentPermissionId] [bigint] NULL,
 CONSTRAINT [PK_Permission] PRIMARY KEY CLUSTERED 
(
	[PermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Report]    Script Date: 08.09.2020 8:18:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Report](
	[ReportId] [bigint] NOT NULL,
	[Name] [nchar](250) NOT NULL,
	[FillePath] [nchar](250) NOT NULL,
 CONSTRAINT [PK_Report] PRIMARY KEY CLUSTERED 
(
	[ReportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReportHistory]    Script Date: 08.09.2020 8:18:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportHistory](
	[ReportHistoryId] [bigint] NOT NULL,
	[Name] [nchar](250) NOT NULL,
	[CreatorId] [bigint] NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[ReportId] [bigint] NOT NULL,
 CONSTRAINT [PK_ReportHistory] PRIMARY KEY CLUSTERED 
(
	[ReportHistoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Right]    Script Date: 08.09.2020 8:18:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Right](
	[RightId] [bigint] NOT NULL,
	[Name] [nchar](250) NOT NULL,
	[Alias] [nchar](250) NULL,
 CONSTRAINT [PK_Right] PRIMARY KEY CLUSTERED 
(
	[RightId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 08.09.2020 8:18:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [bigint] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Alias] [nvarchar](250) NULL,
	[CreationDate] [datetime2](7) NULL,
	[CreatorId] [bigint] NOT NULL,
	[LastUpdate] [datetime2](7) NULL,
	[LastUpdatorId] [bigint] NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolePermission]    Script Date: 08.09.2020 8:18:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolePermission](
	[RolePermissionId] [bigint] NOT NULL,
	[RoleId] [bigint] NOT NULL,
	[PermissionId] [bigint] NOT NULL,
	[CreationDate] [datetime2](7) NULL,
	[CreatorId] [bigint] NOT NULL,
	[LastUpdate] [datetime2](7) NULL,
	[LastUpdatorId] [bigint] NULL,
 CONSTRAINT [PK_RolePermissionId] PRIMARY KEY CLUSTERED 
(
	[RolePermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolePermissionRight]    Script Date: 08.09.2020 8:18:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolePermissionRight](
	[RoleRightPermission] [bigint] NOT NULL,
	[RolePermissionId] [bigint] NOT NULL,
	[RightId] [bigint] NOT NULL,
	[CreationDate] [datetime2](7) NULL,
	[CreatorId] [bigint] NOT NULL,
	[LastUpdate] [datetime2](7) NULL,
	[LastUpdatorId] [bigint] NULL,
 CONSTRAINT [PK_RolePermissionRight] PRIMARY KEY CLUSTERED 
(
	[RoleRightPermission] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tool]    Script Date: 08.09.2020 8:18:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tool](
	[ToolId] [nchar](10) NULL,
	[Name] [nchar](250) NULL,
	[NomenclatureId] [bigint] NULL,
	[DepartmentId] [bigint] NULL,
	[SerialNum] [nchar](50) NULL,
	[PartNum] [nchar](50) NULL,
	[VendorNum] [nchar](50) NULL,
	[ToolStatusId] [bigint] NULL,
	[MaxOperatingTime] [bigint] NULL,
	[TotalOperatingTime] [bigint] NULL,
	[CycleOperatingTime] [bigint] NULL,
	[CycleId] [bigint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ToolClassification]    Script Date: 08.09.2020 8:18:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ToolClassification](
	[ToolClassificationId] [bigint] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[ParentToolClassificationId] [bigint] NULL,
 CONSTRAINT [PK_ToolClassification] PRIMARY KEY CLUSTERED 
(
	[ToolClassificationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ToolHistory]    Script Date: 08.09.2020 8:18:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ToolHistory](
	[ToolHistoryId] [bigint] NULL,
	[ToolId] [bigint] NULL,
	[ToolStatusId] [bigint] NULL,
	[CreationDate] [datetime2](7) NULL,
	[CreatorId] [bigint] NULL,
	[Message] [nvarchar](max) NULL,
	[Commentary] [nvarchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ToolStatus]    Script Date: 08.09.2020 8:18:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ToolStatus](
	[ToolStatusId] [bigint] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_ToolStatus] PRIMARY KEY CLUSTERED 
(
	[ToolStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Unit]    Script Date: 08.09.2020 8:18:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit](
	[UnitId] [bigint] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Unit] PRIMARY KEY CLUSTERED 
(
	[UnitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 08.09.2020 8:18:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [bigint] NOT NULL,
	[FIO] [nvarchar](250) NOT NULL,
	[Login] [nvarchar](250) NOT NULL,
	[Password] [nvarchar](250) NOT NULL,
	[DepartmentId] [bigint] NULL,
	[CreationDate] [datetime2](7) NULL,
	[CreatorId] [bigint] NOT NULL,
	[LastUpdate] [datetime2](7) NULL,
	[LastUpdatorId] [bigint] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 08.09.2020 8:18:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserRoleId] [bigint] NOT NULL,
	[UserId] [bigint] NOT NULL,
	[RoleId] [bigint] NOT NULL,
	[CreationDate] [datetime2](7) NULL,
	[CreatorId] [bigint] NOT NULL,
	[LastUpdate] [datetime2](7) NULL,
	[LastUpdatorId] [bigint] NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[UserRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Well]    Script Date: 08.09.2020 8:18:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Well](
	[WellId] [bigint] NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[CounterpartyId] [bigint] NOT NULL,
 CONSTRAINT [PK_Well] PRIMARY KEY CLUSTERED 
(
	[WellId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Attribute]  WITH CHECK ADD  CONSTRAINT [FK_Attribute_Unit_UnitId] FOREIGN KEY([UnitId])
REFERENCES [dbo].[Unit] ([UnitId])
GO
ALTER TABLE [dbo].[Attribute] CHECK CONSTRAINT [FK_Attribute_Unit_UnitId]
GO
ALTER TABLE [dbo].[Contract]  WITH CHECK ADD  CONSTRAINT [FK_Contract_Counterparty_CounterpartyId] FOREIGN KEY([CounterpartyId])
REFERENCES [dbo].[Counterparty] ([CounterpartyId])
GO
ALTER TABLE [dbo].[Contract] CHECK CONSTRAINT [FK_Contract_Counterparty_CounterpartyId]
GO
ALTER TABLE [dbo].[ContractWell]  WITH CHECK ADD  CONSTRAINT [FK_ContractWell_Contract_ConctractId] FOREIGN KEY([ContractId])
REFERENCES [dbo].[Contract] ([ContractId])
GO
ALTER TABLE [dbo].[ContractWell] CHECK CONSTRAINT [FK_ContractWell_Contract_ConctractId]
GO
ALTER TABLE [dbo].[ContractWell]  WITH CHECK ADD  CONSTRAINT [FK_ContractWell_Well_WellId] FOREIGN KEY([WellId])
REFERENCES [dbo].[Well] ([WellId])
GO
ALTER TABLE [dbo].[ContractWell] CHECK CONSTRAINT [FK_ContractWell_Well_WellId]
GO
ALTER TABLE [dbo].[Cycle]  WITH CHECK ADD  CONSTRAINT [FK_Cycle_User_CreatorId] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Cycle] CHECK CONSTRAINT [FK_Cycle_User_CreatorId]
GO
ALTER TABLE [dbo].[CycleItem]  WITH CHECK ADD  CONSTRAINT [FK_CycleItem_Cycle_CycleId] FOREIGN KEY([CycleId])
REFERENCES [dbo].[Cycle] ([CycleId])
GO
ALTER TABLE [dbo].[CycleItem] CHECK CONSTRAINT [FK_CycleItem_Cycle_CycleId]
GO
ALTER TABLE [dbo].[CycleItem]  WITH CHECK ADD  CONSTRAINT [FK_CycleItem_ToolStatus_CurrToolStatusId] FOREIGN KEY([CurrToolStatusId])
REFERENCES [dbo].[ToolStatus] ([ToolStatusId])
GO
ALTER TABLE [dbo].[CycleItem] CHECK CONSTRAINT [FK_CycleItem_ToolStatus_CurrToolStatusId]
GO
ALTER TABLE [dbo].[CycleItem]  WITH CHECK ADD  CONSTRAINT [FK_CycleItem_ToolStatus_NextToolStatusId] FOREIGN KEY([NextToolStatusId])
REFERENCES [dbo].[ToolStatus] ([ToolStatusId])
GO
ALTER TABLE [dbo].[CycleItem] CHECK CONSTRAINT [FK_CycleItem_ToolStatus_NextToolStatusId]
GO
ALTER TABLE [dbo].[CycleItem]  WITH CHECK ADD  CONSTRAINT [FK_CycleItem_ToolStatus_PrevToolStatusId] FOREIGN KEY([PrevToolStatusId])
REFERENCES [dbo].[ToolStatus] ([ToolStatusId])
GO
ALTER TABLE [dbo].[CycleItem] CHECK CONSTRAINT [FK_CycleItem_ToolStatus_PrevToolStatusId]
GO
ALTER TABLE [dbo].[Document]  WITH CHECK ADD  CONSTRAINT [FK_Document_User_UserId] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Document] CHECK CONSTRAINT [FK_Document_User_UserId]
GO
ALTER TABLE [dbo].[NomenclatureAttribute]  WITH CHECK ADD  CONSTRAINT [FK_NomenclatureAttribute_Attribute_AttributeId] FOREIGN KEY([AttributeId])
REFERENCES [dbo].[Attribute] ([AttributeId])
GO
ALTER TABLE [dbo].[NomenclatureAttribute] CHECK CONSTRAINT [FK_NomenclatureAttribute_Attribute_AttributeId]
GO
ALTER TABLE [dbo].[NomenclatureAttribute]  WITH CHECK ADD  CONSTRAINT [FK_NomenclatureAttribute_Nomenclature_NomenclatureId] FOREIGN KEY([NomenclatureId])
REFERENCES [dbo].[Nomenclature] ([NomenclatureId])
GO
ALTER TABLE [dbo].[NomenclatureAttribute] CHECK CONSTRAINT [FK_NomenclatureAttribute_Nomenclature_NomenclatureId]
GO
ALTER TABLE [dbo].[Permission]  WITH CHECK ADD  CONSTRAINT [FK_Permission_Permission] FOREIGN KEY([ParentPermissionId])
REFERENCES [dbo].[Permission] ([PermissionId])
GO
ALTER TABLE [dbo].[Permission] CHECK CONSTRAINT [FK_Permission_Permission]
GO
ALTER TABLE [dbo].[ReportHistory]  WITH CHECK ADD  CONSTRAINT [FK_ReportHistory_Report_ReportId] FOREIGN KEY([ReportId])
REFERENCES [dbo].[Report] ([ReportId])
GO
ALTER TABLE [dbo].[ReportHistory] CHECK CONSTRAINT [FK_ReportHistory_Report_ReportId]
GO
ALTER TABLE [dbo].[ReportHistory]  WITH CHECK ADD  CONSTRAINT [FK_ReportHistory_User_CreatorId] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[ReportHistory] CHECK CONSTRAINT [FK_ReportHistory_User_CreatorId]
GO
ALTER TABLE [dbo].[Role]  WITH CHECK ADD  CONSTRAINT [FK_Role_User_CreatorId] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Role] CHECK CONSTRAINT [FK_Role_User_CreatorId]
GO
ALTER TABLE [dbo].[Role]  WITH CHECK ADD  CONSTRAINT [FK_Role_User_LastUpdatorId] FOREIGN KEY([LastUpdatorId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Role] CHECK CONSTRAINT [FK_Role_User_LastUpdatorId]
GO
ALTER TABLE [dbo].[RolePermission]  WITH CHECK ADD  CONSTRAINT [FK_RolePermission_Permission] FOREIGN KEY([PermissionId])
REFERENCES [dbo].[Permission] ([PermissionId])
GO
ALTER TABLE [dbo].[RolePermission] CHECK CONSTRAINT [FK_RolePermission_Permission]
GO
ALTER TABLE [dbo].[RolePermission]  WITH CHECK ADD  CONSTRAINT [FK_RolePermission_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[RolePermission] CHECK CONSTRAINT [FK_RolePermission_Role]
GO
ALTER TABLE [dbo].[RolePermission]  WITH CHECK ADD  CONSTRAINT [FK_RolePermission_User_CreatorId] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[RolePermission] CHECK CONSTRAINT [FK_RolePermission_User_CreatorId]
GO
ALTER TABLE [dbo].[RolePermission]  WITH CHECK ADD  CONSTRAINT [FK_RolePermission_User_LastUpdatorId] FOREIGN KEY([LastUpdatorId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[RolePermission] CHECK CONSTRAINT [FK_RolePermission_User_LastUpdatorId]
GO
ALTER TABLE [dbo].[RolePermissionRight]  WITH CHECK ADD  CONSTRAINT [FK_RolePermissionRight_Right] FOREIGN KEY([RightId])
REFERENCES [dbo].[Right] ([RightId])
GO
ALTER TABLE [dbo].[RolePermissionRight] CHECK CONSTRAINT [FK_RolePermissionRight_Right]
GO
ALTER TABLE [dbo].[RolePermissionRight]  WITH CHECK ADD  CONSTRAINT [FK_RolePermissionRight_RolePermission] FOREIGN KEY([RolePermissionId])
REFERENCES [dbo].[RolePermission] ([RolePermissionId])
GO
ALTER TABLE [dbo].[RolePermissionRight] CHECK CONSTRAINT [FK_RolePermissionRight_RolePermission]
GO
ALTER TABLE [dbo].[RolePermissionRight]  WITH CHECK ADD  CONSTRAINT [FK_RolePermissionRight_User_CreatorId] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[RolePermissionRight] CHECK CONSTRAINT [FK_RolePermissionRight_User_CreatorId]
GO
ALTER TABLE [dbo].[RolePermissionRight]  WITH CHECK ADD  CONSTRAINT [FK_RolePermissionRight_User_LastUpdatorId] FOREIGN KEY([LastUpdatorId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[RolePermissionRight] CHECK CONSTRAINT [FK_RolePermissionRight_User_LastUpdatorId]
GO
ALTER TABLE [dbo].[Tool]  WITH CHECK ADD  CONSTRAINT [FK_Tool_Cycle_CycleId] FOREIGN KEY([CycleId])
REFERENCES [dbo].[Cycle] ([CycleId])
GO
ALTER TABLE [dbo].[Tool] CHECK CONSTRAINT [FK_Tool_Cycle_CycleId]
GO
ALTER TABLE [dbo].[Tool]  WITH CHECK ADD  CONSTRAINT [FK_Tool_Department_DepartmentId] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([DepartmentId])
GO
ALTER TABLE [dbo].[Tool] CHECK CONSTRAINT [FK_Tool_Department_DepartmentId]
GO
ALTER TABLE [dbo].[Tool]  WITH CHECK ADD  CONSTRAINT [FK_Tool_Nomenclature_NomenclatureId] FOREIGN KEY([NomenclatureId])
REFERENCES [dbo].[Nomenclature] ([NomenclatureId])
GO
ALTER TABLE [dbo].[Tool] CHECK CONSTRAINT [FK_Tool_Nomenclature_NomenclatureId]
GO
ALTER TABLE [dbo].[Tool]  WITH CHECK ADD  CONSTRAINT [FK_Tool_ToolStatus_ToolStatusId] FOREIGN KEY([ToolStatusId])
REFERENCES [dbo].[ToolStatus] ([ToolStatusId])
GO
ALTER TABLE [dbo].[Tool] CHECK CONSTRAINT [FK_Tool_ToolStatus_ToolStatusId]
GO
ALTER TABLE [dbo].[ToolClassification]  WITH CHECK ADD  CONSTRAINT [FK_ToolClassification_ToolClassification_ParentToolClassificationId] FOREIGN KEY([ParentToolClassificationId])
REFERENCES [dbo].[ToolClassification] ([ToolClassificationId])
GO
ALTER TABLE [dbo].[ToolClassification] CHECK CONSTRAINT [FK_ToolClassification_ToolClassification_ParentToolClassificationId]
GO
ALTER TABLE [dbo].[ToolHistory]  WITH CHECK ADD  CONSTRAINT [FK_ToolHistory_ToolStatus_ToolStatusId] FOREIGN KEY([ToolStatusId])
REFERENCES [dbo].[ToolStatus] ([ToolStatusId])
GO
ALTER TABLE [dbo].[ToolHistory] CHECK CONSTRAINT [FK_ToolHistory_ToolStatus_ToolStatusId]
GO
ALTER TABLE [dbo].[ToolHistory]  WITH CHECK ADD  CONSTRAINT [FK_ToolHistory_User_CreatorId] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[ToolHistory] CHECK CONSTRAINT [FK_ToolHistory_User_CreatorId]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([DepartmentId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Department]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_User_CreatorId] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_User_CreatorId]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_User_LastUpdatorId] FOREIGN KEY([LastUpdatorId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_User_LastUpdatorId]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User_CreatorId] FOREIGN KEY([CreatorId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_User_CreatorId]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User_LastUpdatorId] FOREIGN KEY([LastUpdatorId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_User_LastUpdatorId]
GO
ALTER TABLE [dbo].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserRole] CHECK CONSTRAINT [FK_UserRole_User_UserId]
GO
ALTER TABLE [dbo].[Well]  WITH CHECK ADD  CONSTRAINT [FK_Well_Counterparty_CounterpartyId] FOREIGN KEY([CounterpartyId])
REFERENCES [dbo].[Counterparty] ([CounterpartyId])
GO
ALTER TABLE [dbo].[Well] CHECK CONSTRAINT [FK_Well_Counterparty_CounterpartyId]
GO
