CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [name] VARCHAR(MAX) NULL, 
    [price] MONEY NULL, 
    [year] INT NULL, 
    [city] VARCHAR(MAX) NULL, 
    [date] DATE NULL, 
    [photo] VARCHAR(MAX) NULL, 
    [link] VARCHAR(MAX) NULL
)
