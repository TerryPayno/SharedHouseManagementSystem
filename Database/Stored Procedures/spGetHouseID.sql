CREATE PROCEDURE [dbo].[spGetHouseID]
	@PostCode varchar(50)
AS
	SELECT HouseID FROM HouseTable WHERE (PostCode = @PostCode)

