CREATE PROCEDURE [dbo].[spAddNewHouse]
	@Street varchar(50),
	@PostCode varchar(50),
	@HouseNum int
AS
	INSERT INTO HouseTable (PostCode, FLineAddress, HouseNum) Values (@PostCode, @Street, @HouseNum)

