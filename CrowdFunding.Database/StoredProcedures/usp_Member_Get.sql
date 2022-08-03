-- Get a member by username or id

CREATE PROCEDURE [dbo].[usp_Member_Get]
	@Id int = NULL,
	@Username VARCHAR(35)
AS
BEGIN
	IF @Id IS NOT NULL 
	BEGIN
		SELECT m.[Id], m.[LastName], m.[FirstName], m.[Username], m.[Email], m.[BirthDate], m.[Image], m.[Created], m.[LastLogin] 
		FROM Member m
		JOIN Country c on m.CountryId = c.Id
		WHERE m.Id = @Id;	
	END
	ELSE
	BEGIN
		SELECT m.[Id], m.[LastName], m.[FirstName], m.[Username], m.[Email], m.[BirthDate], m.[Image], m.[Created], m.[LastLogin] 
		FROM Member m
		JOIN Country c on m.CountryId = c.Id
		WHERE m.Username = @Username;	
	END
END
RETURN 0
