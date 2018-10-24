CREATE PROCEDURE [dbo].[spAddProductsBought]
	@Quantity int,
	@Price float,
	@Description varchar(50),
	@ProductGroup varchar(50),
	@UserPaidFull bit,
	@HouseID int,
	@Name varchar(50)
AS
	INSERT INTO ProductsBought (Quantity, Price, Description, ProductGroup, UserPaidFull, HouseID, Name) Values (@Quantity, @Price, @Description, @ProductGroup, @UserPaidFull, @HouseID, @Name)

