WITH resultTabel (rapportradDatum, rapportradStart, rapportradSlut, rapportradLunchStart, rapportradLunchSlut,ejdebiterbar )
AS
(
SELECT rapportradDatum, rapportradStart, rapportradSlut, rapportradLunchStart, rapportradLunchSlut,ejdebiterbar 
FROM snille_rapportrader
INNER JOIN snille_personaltabell 
ON snille_rapportrader.personalID = snille_personaltabell.personalID
INNER JOIN snille_uppdragstabell 
ON snille_uppdragstabell.uppdragsID =snille_rapportrader.uppdragsID
WHERE snille_personaltabell.personalTyp = 2 AND snille_uppdragstabell.ejdebiterbar = 1
)
Select SUM(ejdebiterbar)as summa  from resultTabel
