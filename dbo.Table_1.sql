CREATE TABLE [dbo].[User_Interest]
(
    [Id]  INT  IDENTITY (1, 1) NOT NULL,
	[UserId]  UNIQUEIDENTIFIER NULL references Contact(UserId),
	[InterestId]  INT NOT NULL references Interest(InterestId),
	CONSTRAINT [PK_dbo.User_Interest] PRIMARY KEY CLUSTERED ([Id] ASC)
)
