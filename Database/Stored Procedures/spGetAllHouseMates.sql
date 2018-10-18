CREATE PROCEDURE [dbo].[spGetAllHouseMates] (@HouseID int)

AS
select * from Users where HouseID = @HouseID