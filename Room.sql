CREATE TABLE [dbo].[Rooms] (
	[Id] int NOT NULL,
	[RoomType] nvarchar(max) NOT NULL,
	[RoomStatus] nvarchar(max) NOT NULL,
	[MaxNumber] int NOT NULL,
	[HotelId] int NOT NULL
	PRIMARY KEY (Id),
	FOREIGN KEY (HotelId) REFERENCES Hotel(Id)
	);
	Go