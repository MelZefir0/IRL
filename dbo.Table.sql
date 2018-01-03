CREATE TABLE [dbo].[Contact_Interest]
(
	[Id] INT IDENTITY (1, 1) NOT NULL,
	[ContactId] INT NOT NULL references Contact(ContactId),
	[InterestId] INT NOT NULL references Interest(InterestId),
	CONSTRAINT [PK_dbo.Contact_Interest] PRIMARY KEY CLUSTERED ([Id] ASC)
)
