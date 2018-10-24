CREATE PROCEDURE [dbo].[spGetPaidShares]
	@UserID int
AS

		SELECT * FROM ChargeTable ChT 
		LEFT join ProductsBought PB on PB.ProductID = ChT.ProductID
		WHERE @UserID = UserID AND 1 = PaidShare
