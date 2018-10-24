CREATE PROCEDURE [dbo].[spAddCharges]
	@UserID int,
	@FirstName varchar(50),
	@LastName varchar(50),
	@Email varchar(50),
	@HouseID int,
	@IsPaying bit,
	@Price float,
	@ProductID int,
	@PaidShare bit

AS
	INSERT INTO ChargeTable (UserID,FirstName, LastName, Email, HouseID, IsPaying, Price, ProductID, PaidShare) Values (@UserID, @FirstName, @LastName, @Email, @HouseID, @IsPaying, @Price, @ProductID, @PaidShare)

