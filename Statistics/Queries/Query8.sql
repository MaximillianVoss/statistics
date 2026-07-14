--
WITH resultTabel (personalTyp,ersattningsDatum, ersattningsTyp,ersattningsKostnadInkl,
ersattningsKostnadExkl,sum)
AS
(
SELECT personalTyp,ersattningsDatum, ersattningsTyp,ersattningsKostnadInkl,
ersattningsKostnadExkl,ersattningsKostnadInkl+ersattningsKostnadExkl as Sum
FROM snille_personaltabell
INNER JOIN snille_ersattningstabell
ON snille_ersattningstabell.personalID = snille_personaltabell.personalID
WHERE ersattningsTyp=2
)
Select SUM(sum) as summa from resultTabel

--new version
WITH resultTabel 
(personalTyp, ersattningsDatum, ersattningsTyp, ersattningsKostnadInkl, ersattningsKostnadExkl, 
 ersattningHeldagAntal, ersattningHeldagBelopp, ersattningHalvdagAntal, ersattningHalvdagBelopp, 
 ersattningNattAntal, ersattningNattBelopp, ersattningFruAntal, ersattningFruBelopp, ersattningMiddagAntal, 
 ersattningMiddagBelopp, sum)
AS
(
SELECT 
personalTyp,ersattningsDatum, ersattningsTyp,ersattningsKostnadInkl,
ersattningsKostnadExkl,ersattningHeldagAntal,ersattningHeldagBelopp,
ersattningHalvdagAntal,ersattningHalvdagBelopp,
ersattningNattAntal,ersattningNattBelopp,
ersattningFruAntal,ersattningFruBelopp,
ersattningLunchAntal,ersattningLunchBelopp,
ersattningMiddagAntal,ersattningMiddagBelopp,

(ersattningHeldagAntal * ersattningHeldagBelopp) + 
(ersattningHalvdagAntal * ersattningHalvdagBelopp) + 
(ersattningNattAntal * ersattningNattBelopp) +  
(ersattningFruAntal * ersattningFruBelopp) + 
(ersattningLunchAntal * ersattningLunchBelopp) + 
(ersattningMiddagAntal * ersattningMiddagBelopp)

 as Sum
FROM snille_personaltabell
INNER JOIN snille_ersattningstabell
ON snille_ersattningstabell.personalID = snille_personaltabell.personalID
WHERE ersattningsTyp=2
)
Select SUM(sum) as summa from resultTabel
--WITH resultTabel 
(personalTyp, ersattningsDatum, ersattningsTyp, ersattningsKostnadInkl, ersattningsKostnadExkl, 
 ersattningHeldagAntal, ersattningHeldagBelopp, ersattningHalvdagAntal, ersattningHalvdagBelopp, 
 ersattningNattAntal, ersattningNattBelopp, ersattningFruAntal, ersattningFruBelopp, ersattningMiddagAntal, 
 ersattningMiddagBelopp, sum) 
 AS (SELECT personalTyp, ersattningsDatum, ersattningsTyp, ersattningsKostnadInkl, ersattningsKostnadExkl, 
 ersattningHeldagAntal, ersattningHeldagBelopp, ersattningHalvdagAntal, ersattningHalvdagBelopp, 
 ersattningNattAntal, ersattningNattBelopp, ersattningFruAntal, ersattningFruBelopp, ersattningMiddagAntal, 
 ersattningMiddagBelopp, 
 (ersattningHeldagAntal* ersattningHeldagBelopp) +  
 (ersattningHalvdagAntal* ersattningHalvdagBelopp) + 
  (ersattningNattAntal* ersattningNattBelopp) +  
   (ersattningFruAntal* ersattningFruBelopp) +  
   (ersattningLunchAntal* ersattningLunchBelopp) +  
   (ersattningMiddagAntal* ersattningMiddagBelopp) as Sum 
   FROM snille_personaltabell INNER JOIN snille_ersattningstabell 
   ON snille_ersattningstabell.personalID = snille_personaltabell.personalID 
   WHERE ersattningsTyp= 2 AND personalTyp=2
   ) Select SUM(sum) as summa from resultTabel  