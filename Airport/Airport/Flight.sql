CREATE TABLE [dbo].[Flights]
(
	[Number] INT NOT NULL PRIMARY KEY, 
    [DateTime] DATETIME NOT NULL, 
    [DestinationPort] NVARCHAR(50) NOT NULL, 
    [Plane] NVARCHAR(50) NOT NULL, 
    [PlacesLeft] INT NOT NULL, 
    [DeparturePort] NVARCHAR(50) NOT NULL
	CONSTRAINT [FK_Flights_Planes] FOREIGN KEY ([Plane]) REFERENCES [Planes]([Number])
)
