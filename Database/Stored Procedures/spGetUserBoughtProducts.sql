CREATE PROCEDURE [dbo].[spGetUserBoughtProducts]
	@UserID int
AS
	SELECT * FROM ProductsBought WHERE @UserID = UserPaidFull

