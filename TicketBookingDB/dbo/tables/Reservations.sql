CREATE TABLE [dbo].[Reservations]
(
	[ReservationId] INT NOT NULL IDENTITY, 
	[ShowMovieID] INT NOT NULL , 
    [ShowTheatreID] INT NOT NULL, 
    [MovieTime] NCHAR(20) NOT NULL, 
    [SeatZone] NCHAR(20) NOT NULL, 
    [NoOfTickets] INT NOT NULL, 
    [AvailableTickets] INT NOT NULL,     
    CONSTRAINT [PK_Reservations] PRIMARY KEY ([ReservationId])
)
