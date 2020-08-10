CREATE TABLE [dbo].[Hotel] (
	[Id] int NOT NULL,
	[HotelName] nvarchar(max) NOT NULL,
	[HotelDescription] nvarchar(max),
	[ImagePath] nvarchar(max),
	[Price] int NOT NULL
	PRIMARY KEY (Id)
	);
	GO