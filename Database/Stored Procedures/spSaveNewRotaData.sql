CREATE PROCEDURE [dbo].[spSaveNewRotaData]
	@ID int,
	@Time time,
	@Monday varchar(50),
	@Tuesday varchar(50),
	@Wednesday varchar(50),
	@Thursday varchar(50),
	@Friday varchar(50),
	@Saturday varchar(50),
	@Sunday varchar(50)
AS
	UPDATE RotaDataTable 
	SET TIME = @Time, Monday = @Monday, Tuesday = @Tuesday, Wednesday = @Wednesday, Thursday = @Thursday, Friday = @Thursday, Saturday = @Saturday, Sunday = @Sunday
	WHERE id = @ID
RETURN 0
