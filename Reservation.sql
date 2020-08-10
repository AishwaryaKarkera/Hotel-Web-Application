CREATE TABLE [dbo].[Reservation] (
	[Id] int NOT NULL,
	[CheckIn] date NOT NULL,
	[CheckOut] date NOT NULL,
	[RoomId] int NOT NULL
	PRIMARY KEY (Id),
	FOREIGN KEY (RoomId) REFERENCES Rooms(Id)
	);
	GO

