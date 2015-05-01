CREATE TABLE [dbo].[Clients]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NCHAR(10) NOT NULL, 
    [Phone] NCHAR(10) NOT NULL, 
    [CardNumber] NVARCHAR(MAX) NOT NULL, 
    [PassportNumber] NVARCHAR(MAX) NOT NULL
		
)
