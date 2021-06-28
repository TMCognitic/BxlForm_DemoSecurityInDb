CREATE PROCEDURE [AppUserSchema].[CSP_AddContact]
	@LastName NVARCHAR(50),
	@FirstName NVARCHAR(50),
	@Email NVARCHAR(384)
AS
BEGIN
	INSERT INTO [dbo].[Contact] ([LastName], [FirstName], [Email]) VALUES (@LastName, @FirstName, @Email);
	RETURN 0
END
