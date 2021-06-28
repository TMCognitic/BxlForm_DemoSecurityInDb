CREATE PROCEDURE [AppUserSchema].[CSP_DeleteContact]
	@Id INT
AS
BEGIN
	DELETE FROM [dbo].[Contact] WHERE [Id] = @Id;
	RETURN 0
END