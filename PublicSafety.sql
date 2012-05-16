USE [PublicSafety]
GO
/****** Object:  Table [dbo].[crimerate]    Script Date: 05/17/2012 01:38:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[crimerate](
	[area] [char](50) NOT NULL,
	[crimerate] [int] NOT NULL,
	[accidentrate] [int] NOT NULL,
 CONSTRAINT [PK_crimerate] PRIMARY KEY CLUSTERED 
(
	[area] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[citizen]    Script Date: 05/17/2012 01:38:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[citizen](
	[ID] [char](18) NOT NULL,
	[name] [char](8) NOT NULL,
	[gender] [char](1) NOT NULL,
	[hometown] [char](12) NOT NULL,
	[address] [char](50) NOT NULL,
	[telephone] [char](12) NULL,
	[birthday] [date] NOT NULL,
	[crimestatus] [char](4) NOT NULL,
	[photo] [image] NULL,
	[tax] [int] NOT NULL,
 CONSTRAINT [PK_citizen] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[cases]    Script Date: 05/17/2012 01:38:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[cases](
	[caseID] [int] IDENTITY(1,1) NOT NULL,
	[casetype] [char](4) NOT NULL,
	[casedescribe] [text] NOT NULL,
	[casestatus] [char](4) NOT NULL,
	[caseaddress] [char](50) NOT NULL,
	[time] [timestamp] NOT NULL,
 CONSTRAINT [PK_cases] PRIMARY KEY CLUSTERED 
(
	[caseID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[publicplace]    Script Date: 05/17/2012 01:38:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[publicplace](
	[placeID] [int] IDENTITY(1,1) NOT NULL,
	[address] [char](50) NOT NULL,
	[introduction] [text] NOT NULL,
	[spending] [int] NOT NULL,
 CONSTRAINT [PK_publicplace] PRIMARY KEY CLUSTERED 
(
	[placeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[police]    Script Date: 05/17/2012 01:38:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[police](
	[policeID] [int] IDENTITY(1,1) NOT NULL,
	[policetype] [char](4) NOT NULL,
	[area] [char](50) NULL,
	[withagun] [char](2) NOT NULL,
	[salary] [int] NOT NULL,
	[ID] [char](18) NOT NULL,
 CONSTRAINT [PK_police] PRIMARY KEY CLUSTERED 
(
	[policeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[case_person]    Script Date: 05/17/2012 01:38:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[case_person](
	[caseID] [int] NOT NULL,
	[ID] [char](18) NOT NULL,
 CONSTRAINT [PK_case_person] PRIMARY KEY CLUSTERED 
(
	[caseID] ASC,
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[carmanager]    Script Date: 05/17/2012 01:38:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[carmanager](
	[drivinglicence] [char](10) NOT NULL,
	[drivinglicencetype] [char](8) NOT NULL,
	[point] [int] NOT NULL,
	[ID] [char](18) NOT NULL,
 CONSTRAINT [PK_carmanager] PRIMARY KEY CLUSTERED 
(
	[drivinglicence] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[carinfo]    Script Date: 05/17/2012 01:38:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[carinfo](
	[carID] [char](8) NOT NULL,
	[carstyle] [char](20) NOT NULL,
	[purchasetime] [date] NOT NULL,
	[latestchecktime] [date] NOT NULL,
	[insurancedate] [date] NOT NULL,
	[remark] [text] NULL,
	[status] [char](4) NOT NULL,
	[ID] [char](18) NOT NULL,
 CONSTRAINT [PK_carinfo] PRIMARY KEY CLUSTERED 
(
	[carID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[accident]    Script Date: 05/17/2012 01:38:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[accident](
	[accidentID] [int] IDENTITY(1,1) NOT NULL,
	[address] [char](50) NOT NULL,
	[time] [timestamp] NOT NULL,
	[accidentcontent] [text] NOT NULL,
	[type] [char](4) NOT NULL,
	[carID] [char](8) NOT NULL,
 CONSTRAINT [PK_accident] PRIMARY KEY CLUSTERED 
(
	[accidentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_police_citizen]    Script Date: 05/17/2012 01:38:49 ******/
ALTER TABLE [dbo].[police]  WITH CHECK ADD  CONSTRAINT [FK_police_citizen] FOREIGN KEY([ID])
REFERENCES [dbo].[citizen] ([ID])
GO
ALTER TABLE [dbo].[police] CHECK CONSTRAINT [FK_police_citizen]
GO
/****** Object:  ForeignKey [FK_case_person_cases]    Script Date: 05/17/2012 01:38:49 ******/
ALTER TABLE [dbo].[case_person]  WITH CHECK ADD  CONSTRAINT [FK_case_person_cases] FOREIGN KEY([caseID])
REFERENCES [dbo].[cases] ([caseID])
GO
ALTER TABLE [dbo].[case_person] CHECK CONSTRAINT [FK_case_person_cases]
GO
/****** Object:  ForeignKey [FK_case_person_citizen]    Script Date: 05/17/2012 01:38:49 ******/
ALTER TABLE [dbo].[case_person]  WITH CHECK ADD  CONSTRAINT [FK_case_person_citizen] FOREIGN KEY([ID])
REFERENCES [dbo].[citizen] ([ID])
GO
ALTER TABLE [dbo].[case_person] CHECK CONSTRAINT [FK_case_person_citizen]
GO
/****** Object:  ForeignKey [FK_carmanager_citizen]    Script Date: 05/17/2012 01:38:49 ******/
ALTER TABLE [dbo].[carmanager]  WITH CHECK ADD  CONSTRAINT [FK_carmanager_citizen] FOREIGN KEY([ID])
REFERENCES [dbo].[citizen] ([ID])
GO
ALTER TABLE [dbo].[carmanager] CHECK CONSTRAINT [FK_carmanager_citizen]
GO
/****** Object:  ForeignKey [FK_carinfo_citizen]    Script Date: 05/17/2012 01:38:49 ******/
ALTER TABLE [dbo].[carinfo]  WITH CHECK ADD  CONSTRAINT [FK_carinfo_citizen] FOREIGN KEY([ID])
REFERENCES [dbo].[citizen] ([ID])
GO
ALTER TABLE [dbo].[carinfo] CHECK CONSTRAINT [FK_carinfo_citizen]
GO
/****** Object:  ForeignKey [FK_accident_carinfo]    Script Date: 05/17/2012 01:38:49 ******/
ALTER TABLE [dbo].[accident]  WITH CHECK ADD  CONSTRAINT [FK_accident_carinfo] FOREIGN KEY([carID])
REFERENCES [dbo].[carinfo] ([carID])
GO
ALTER TABLE [dbo].[accident] CHECK CONSTRAINT [FK_accident_carinfo]
GO
