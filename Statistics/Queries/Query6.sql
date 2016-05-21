WITH resultTabel (personalTyp,ersattningsDatum, ersattningsTyp,ersattningsKostnadInkl,
ersattningsKostnadExkl,sum)
AS
(
SELECT personalTyp,ersattningsDatum, ersattningsTyp,ersattningsKostnadInkl,
ersattningsKostnadExkl,ersattningsKostnadInkl+ersattningsKostnadExkl as Sum
FROM snille_personaltabell
INNER JOIN snille_ersattningstabell
ON snille_ersattningstabell.personalID = snille_personaltabell.personalID
WHERE ersattningsTyp=1 
)
Select SUM(sum) as summa from resultTabel


