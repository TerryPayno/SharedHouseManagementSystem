CREATE PROCEDURE [dbo].[spAddNewUser] (@FirstName varchar(50), @LastName varchar(50), @Email varchar(50), @Password varchar(50), @HouseID int)

AS

INSERT INTO Users (FirstName,LastName,Email,Password,HouseID) Values (@FirstName, @LastName, @Email, @Password,@HouseID)