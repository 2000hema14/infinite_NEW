create Database MiniCaseStudyDB
use MiniCaseStudyDB


-- Train Table
CREATE TABLE train (
    Train_Id INT PRIMARY KEY,
    Class VARCHAR(50),
    TrainName VARCHAR(100),
    FromStation VARCHAR(100),
    ToStation VARCHAR(100),
    TotalBerths INT,
    AvailableBerths INT,
    Fare DECIMAL(10, 2),
    IsActive VARCHAR(8) 
);

-- Insert sample values
INSERT INTO train (Train_Id, Class, TrainName, FromStation, ToStation, TotalBerths, AvailableBerths, Fare, IsActive) 
VALUES 
    (1, 'First Class', 'SMVT SF Express', 'Delhi', 'Patna', 100, 50, 550.00, 'Active'),
    (2, 'Second Class', 'Mysore Express', 'Mysore', 'Mangalore', 200, 150, 250.00, 'Active'),
    (3, 'Sleeper', 'KSR Bengaluru Express', 'Bengaluru', 'Delhi', 150, 100, 175.00, 'Active'),
    (4, 'Economy', 'Chennai Express', 'Bengaluru', 'Chennai', 100, 90, 150.00, 'Active');

-- Booking Table
CREATE TABLE Booking (
    Booking_Id INT PRIMARY KEY IDENTITY,
    Train_Id INT,
    Class VARCHAR(50),
    PassengerName VARCHAR(100),
    SeatsBooked INT,
    BookingDate DATE,
    DepartureDate DATE,
    TotalAmount DECIMAL(10, 2),
    FOREIGN KEY (Train_Id) REFERENCES train(Train_Id)
);


-- Insert sample values
INSERT INTO Booking (Train_Id, Class, PassengerName, SeatsBooked, BookingDate, DepartureDate, TotalAmount) 
VALUES 
    (1, 'First Class', 'John Doe', 5, '2024-04-10', '2024-04-15', 2000.00),
    (2, 'Second Class', 'Jane Smith', 3, '2024-04-11', '2024-04-16', 1000.00),
    (3, 'Sleeper', 'Arun', 2, '2024-05-12', '2024-05-17', 600.00),
    (4, 'Economy', 'Alice Johnson', 2, '2024-04-12', '2024-04-17', 600.00);

-- CancellationDetails Table
CREATE TABLE CancellationDetails (
    CancellationDetailId INT PRIMARY KEY IDENTITY,
    BookingId INT NOT NULL,
    SeatsCancelled INT NOT NULL,
    RefundAmount DECIMAL(18, 2) NOT NULL,
    CancellationDate DATETIME NOT NULL,
    CONSTRAINT FK_Booking_CancellationDetails FOREIGN KEY (BookingId) REFERENCES Booking (Booking_Id)
);

-- Stored procedures for admin side

-- Add a new train to the system
CREATE PROCEDURE AddTrain (
    @trainId INT,
    @class VARCHAR(50),
    @trainName VARCHAR(100),
    @fromStation VARCHAR(100),
    @toStation VARCHAR(100),
    @totalBerths INT,
    @availableBerths INT,
    @fare DECIMAL(10, 2),
    @isActive VARCHAR(8)
)
AS
BEGIN
    INSERT INTO train (Train_Id, Class, TrainName, FromStation, ToStation, TotalBerths, AvailableBerths, Fare, IsActive)
    VALUES (@trainId, @class, @trainName, @fromStation, @toStation, @totalBerths, @availableBerths, @fare, @isActive)
END

-- Update details of an existing train
CREATE PROCEDURE UpdateTrain (
    @trainId INT,
    @newTrainName VARCHAR(100),
    @newFromStation VARCHAR(100),
    @newToStation VARCHAR(100),
    @newTotalBerths INT,
    @newAvailableBerths INT,
    @newFare DECIMAL(10, 2),
    @newIsActive VARCHAR(8)
)
AS
BEGIN
    UPDATE train
    SET TrainName = @newTrainName,
        FromStation = @newFromStation,
        ToStation = @newToStation,
        TotalBerths = @newTotalBerths,
        AvailableBerths = @newAvailableBerths,
        Fare = @newFare,
        IsActive = @newIsActive
    WHERE Train_Id = @trainId
END

-- Delete a train from the system
CREATE or alter PROCEDURE DeleteTrain (
    @trainId INT
)
AS
BEGIN
    UPDATE train
    SET IsActive = 'Inactive'
    WHERE Train_Id = @trainId;
END


-- View all bookings
CREATE PROCEDURE ViewBookings
AS
BEGIN
    SELECT * FROM Booking
END

-- View all cancellations
CREATE PROCEDURE ViewCancellations
AS
BEGIN
    SELECT * FROM CancellationDetails
END


-------------- Stored procedures for user side-------------------------------

-- Book a ticket for a specific train
CREATE OR ALTER PROCEDURE BookTicket (
    @trainId INT,
    @class VARCHAR(50),
    @passengerName VARCHAR(100),
    @seatsBooked INT,
    @bookingDate DATE,
    @departureDate DATE,
	@dateOfTravel DATE 
)
AS
BEGIN
    DECLARE @totalAmount DECIMAL(10, 2)
    SELECT @totalAmount = (Fare * @seatsBooked) FROM train WHERE Train_Id = @trainId AND Class = @class AND IsActive = 'Active'

    IF @totalAmount IS NOT NULL
    BEGIN
        INSERT INTO Booking (Train_Id, Class, PassengerName, SeatsBooked, BookingDate, DepartureDate, TotalAmount)
        VALUES (@trainId, @class, @passengerName, @seatsBooked, @bookingDate, @departureDate, @totalAmount)

        -- Decrement AvailableBerths
        UPDATE train SET AvailableBerths = AvailableBerths - @seatsBooked WHERE Train_Id = @trainId
    END
    ELSE
    BEGIN
        PRINT 'Error: The selected train is not active or does not exist.'
    END
END


---- Cancel a booked ticket
CREATE OR ALTER PROCEDURE CancelTicket (
     @bookingId INT,
    @seatsToCancel INT
)
AS
BEGIN
    DECLARE @refundAmount DECIMAL(10, 2)
    SELECT @refundAmount = (TotalAmount / SeatsBooked) * @seatsToCancel FROM Booking WHERE Booking_Id = @bookingId

    IF @refundAmount IS NOT NULL
    BEGIN
        INSERT INTO CancellationDetails (BookingId, SeatsCancelled, RefundAmount, CancellationDate)
        VALUES (@bookingId, @seatsToCancel, @refundAmount, GETDATE())

        UPDATE Booking
        SET SeatsBooked = SeatsBooked - @seatsToCancel,
            TotalAmount = TotalAmount - @refundAmount
        WHERE Booking_Id = @bookingId

        -- Increment AvailableBerths
        UPDATE train SET AvailableBerths = AvailableBerths + @seatsToCancel WHERE Train_Id IN (SELECT Train_Id FROM Booking WHERE Booking_Id = @bookingId AND SeatsBooked = 0)
    END
    ELSE
    BEGIN
        PRINT 'Error: Invalid booking ID or number of seats to cancel.'
    END
END


-- Add a new stored procedure to retrieve available berths for each train
CREATE PROCEDURE GetAvailableBerths
AS
BEGIN
    SELECT Train_Id, Class, AvailableBerths FROM train
END


select * from train
select * from Booking
select * from CancellationDetails

