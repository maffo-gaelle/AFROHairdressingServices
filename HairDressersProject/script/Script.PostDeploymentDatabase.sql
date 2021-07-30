/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

use HairDressersProject

GO
Set Identity_insert ProfessionnalCategory on;
INSERT INTO ProfessionnalCategory (Id, NameCategory) VALUES 
(1, 'hairdresser'),
(2, 'Makeup artist'),
(3, 'dressmaker'),
(4, 'commercial');
Set Identity_insert ProfessionnalCategory off;


INSERT INTO [User] (ID, LastName, FirstName, Pseudo, Email, Passwd, [Role], BirthDate, IdProfessionnalCategory) VALUES
(1, 'Georges', 'Lucas', 'TheBest', 'thebest@test.com', 'thebest', '2', '1944-05-17 00:00:00', 1),
(2, 'Clint', 'Eastwood', 'Hello world', 'helloworld@test.com', 'helloworld', 1, '1930-05-31 00:00:00', null),
(3, 'Sean', 'Connery', 'sean sean', 'sean@test.com', 'seansean', 1, '1930-08-25 00:00:00', null)


Set Identity_insert Avis on;
INSERT INTO Avis (ID, Content, Star, UserIdProfessionnal, UserIdMember, [Timestamp] ) VALUES
(1, 'Elle était top la prestation, Meci !', 3, 1, 1, GetDate())
Set Identity_insert Avis off;

Set Identity_insert Comment on;
INSERT INTO student (ID, Content, AvisId ) VALUES
(1, 'Super, Mais pourquoi seulement 3 étoiles ? ', 1)
Set Identity_insert Comment off;

Set Identity_insert UserComment on;
INSERT INTO student (IdComment, IdUser ) VALUES
(1, 1)
Set Identity_insert UserComment off;

