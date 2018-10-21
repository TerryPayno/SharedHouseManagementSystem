CREATE PROCEDURE [dbo].[spResetPasswordRequest]
	@Email varchar(50)
AS
	Begin
		Declare @UserID int

		
		Select @UserID = UserID
		From Users
		where Email = @Email

		if(@UserID iS NOT NULL)
		Begin
			Declare @GUID UniqueIdentifier
			Set @GUID = NEWID()

			Insert into ResetPasswordRequestTable
			(ID, UserID, ResetRequestDateTime)
			Values (@GUID, @UserID, GETDATE())

			Select 1 as ReturnCode, @GUID as UniqueID, @Email as Email
		END
		Else
		Begin
			Select 0 as ReturnCode, NULL as UniqueID, NULL as Email
		End
	End
		