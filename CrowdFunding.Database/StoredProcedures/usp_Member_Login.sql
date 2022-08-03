-- Selects a username upon successful identification

CREATE PROCEDURE [dbo].[usp_Member_Login]
	@Username VARCHAR(35) = NULL,
	@Email VARCHAR(300) = NULL,
	@PasswordHash CHAR(97)
AS
BEGIN
	IF @Username IS NOT NULL AND @PasswordHash IS NOT NULL
	BEGIN
		IF EXISTS(SELECT [Id] FROM Member WHERE @Username = [Username] AND @PasswordHash = [PasswordHash])
		BEGIN
			UPDATE Member
			SET [LastLogin] = SYSDATETIME()
			WHERE [Username] = @Username;
			EXECUTE usp_Member_Get @Username
		END
	END

	ELSE IF @Email IS NOT NULL AND @PasswordHash IS NOT NULL
	BEGIN
		DECLARE @Id INT 
		SELECT @Id = [Id] FROM Member WHERE @Email = [Email]
		IF EXISTS(SELECT [Id] FROM Member WHERE @Email = [Email] AND @PasswordHash = [PasswordHash])
		BEGIN
			UPDATE Member
			SET [LastLogin] = SYSDATETIME()
			WHERE [Email] = @Email;
			EXECUTE usp_Member_Get @Id
		END
	END
END
RETURN 0
