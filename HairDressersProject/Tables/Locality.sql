CREATE TABLE [dbo].[Locality]
(
    [Ville] VARCHAR(50) NOT NULL, 
    [CodePostal] VARCHAR(4) NOT NULL UNIQUE, 
    CONSTRAINT [PK_Locality] PRIMARY KEY ([CodePostal]), 
    CONSTRAINT [CK_Locality_CodePostal_Ville] UNIQUE(Ville, CodePostal)
)
