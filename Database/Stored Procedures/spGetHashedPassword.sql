CREATE PROCEDURE [dbo].[spGetHashedPassword] (@Email varchar(50))

AS
select Password,UserID,HouseID from Users where Email = @Email