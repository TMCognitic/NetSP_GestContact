CREATE PROCEDURE [dbo].[CheckUser]
	@Email NVARCHAR(320),
	@Passwd NVARCHAR(20)
AS
	SELECT Id, Nom, Prenom, @Email Email From Utilisateurs where Email = @Email and Passwd = HASHBYTES('SHA2_512', dbo.GetPreSalt() + @Passwd + dbo.GetPostSalt());
RETURN 0
