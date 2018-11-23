--Создание базы и заполнение таблицы пользователей


CREATE TABLE [dbo].[Users](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](250) NOT NULL,
	[Password] [nvarchar](250) NOT NULL,
	[UserStatus] [int] NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[Birthday] [datetime] NULL,
 CONSTRAINT [UsersId] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE TABLE [dbo].[Notes](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[Tags] [nvarchar](max) NULL,
	[CreationTime] [datetime] NOT NULL,
	[ChangeTime] [datetime] NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[NoteStatus] [int] NULL,
	[IsDraft] [bit] NOT NULL,
 CONSTRAINT [Notes_pk] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Notes]  WITH CHECK ADD  CONSTRAINT [FK_Notes_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO

ALTER TABLE [dbo].[Notes] CHECK CONSTRAINT [FK_Notes_Users]
GO



CREATE TABLE [dbo].[Files](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileN] [nvarchar](255) NOT NULL,
	[GuidName] [nvarchar](50) NOT NULL,
	[NoteId] [bigint] NOT NULL,
	[FileStatus] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Files]  WITH CHECK ADD  CONSTRAINT [FK_Files_Notes2] FOREIGN KEY([NoteId])
REFERENCES [dbo].[Notes] ([Id])
GO

ALTER TABLE [dbo].[Files] CHECK CONSTRAINT [FK_Files_Notes2]
GO


--Заполнение пользователей


INSERT INTO dbo.Users
(
    Login,
    Password,
    Email,
    BirthDay,
    UserStatus
    
)
VALUES
(   N'admin',       
    N'21232f297a57a5a743894a0e4a801fc3',       -- admin
    N'admin@admin.ru',       
    '20011001', 
    1
    ),
	(   N'usr',  
    N'0a744893951e0d1706ff74a7afccf561',       -- usr
    N'usr@admin.ru',    
    '20021001', 
    1
    )