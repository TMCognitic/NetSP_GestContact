CREATE TABLE [dbo].[Utilisateurs]
(
	[Id] INT NOT NULL IDENTITY, 
    [Nom] NVARCHAR(50) NOT NULL, 
    [Prenom] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(320) NOT NULL, 
    [Passwd] BINARY(64) not null, 
    CONSTRAINT [PK_Utilisateurs] PRIMARY KEY ([Id]) ,
    CONSTRAINT [UK_Utilisateurs_Email] UNIQUE ([Email])
)
