CREATE TABLE [dbo].[Contacts]
(
	[Id] INT NOT NULL IDENTITY, 
    [Nom] NVARCHAR(50) NOT NULL, 
    [Prenom] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(320) NOT NULL, 
    [Tel] NVARCHAR(15) NOT NULL, 
    [UtilisateurId] INT NOT NULL, 
    CONSTRAINT [PK_Contacts] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Contacts_Utilisateurs] FOREIGN KEY ([UtilisateurId]) REFERENCES [Utilisateurs]([Id])    
)
