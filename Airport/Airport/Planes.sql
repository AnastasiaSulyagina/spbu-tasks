CREATE TABLE [dbo].[Planes]
(
	[Number] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [Type] NCHAR(10) NOT NULL, 
    [PlacesNumber] NCHAR(10) NOT NULL, 
    [Pilot] NCHAR(10) NOT NULL, 
    [Speed] INT NOT NULL
)
