CREATE TABLE [dbo].[Movies]
(
	[MovieID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MovieName] NCHAR(50) NOT NULL, 
    [MovieDescription] NCHAR(500) NULL
)
