CREATE PROCEDURE [dbo].[AddUtilisateur]
	@Nom NVARCHAR(50),
	@Prenom NVARCHAR(50),
	@Email NVARCHAR(320),
	@Passwd NVARCHAR(20)
AS
Begin
	Insert into Utilisateurs(Nom, Prenom, Email, Passwd)
	output inserted.Id
	values(@Nom, @Prenom, @Email, HASHBYTES('SHA2_512', dbo.GetPreSalt() + @Passwd + dbo.GetPostSalt()));
End
