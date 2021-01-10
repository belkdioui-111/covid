CREATE TRIGGER change_etat
ON consultation
AFTER INSERT , UPDATE AS 
DECLARE @etat as varchar(50)
DECLARE @cin as varchar(50)
SELECT @etat =inserted.etat_couleur, @cin = inserted.cin_citoyen from inserted
BEGIN
UPDATE covid_suivi.citoyen_ SET etat_couleur=@etat where cin=@cin;
END