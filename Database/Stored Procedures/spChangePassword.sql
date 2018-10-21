CREATE PROCEDURE [dbo].[spChangePassword]
	@GUID varchar(100),
	@NewPassword varchar(50)
	
AS
	Begin
		Declare @UserID int
		SELECT @UserID = UserID FROM ResetPasswordRequestTable
		WHERE id = @GUID

		UPDATE Users
		SET Password = @NewPassword
		WHERE UserID = @UserID
	End
