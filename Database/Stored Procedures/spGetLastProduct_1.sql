CREATE PROCEDURE [dbo].[spGetLastProduct]

AS
	SELECT TOP 1 ProductID FROM ProductsBought ORDER BY ProductID DESC

