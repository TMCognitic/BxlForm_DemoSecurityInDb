CREATE PROCEDURE [AppUserSchema].[CSP_UpdateContact]
	@Id INT,
	@LastName NVARCHAR(50),
	@FirstName NVARCHAR(50),
	@Email NVARCHAR(384)
AS
BEGIN
	UPDATE [dbo].[Contact] SET [LastName] = @LastName, [FirstName] = @FirstName, [Email] = @Email, [LastUpdated] = SYSDATETIME() WHERE [Id] = @Id;
	RETURN 0
END