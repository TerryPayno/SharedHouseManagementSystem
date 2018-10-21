CREATE PROCEDURE [dbo].[spGetCharges]
	@UserID int
AS
	SELECT * FROM ChargeTable ChT 
	LEFT join ProductsBought PB on PB.ProductID = ChT.ProductID
	WHERE @UserID = UserID