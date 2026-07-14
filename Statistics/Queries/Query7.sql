--milestrat
WITH resultTabel (personalTyp,ersattningsDatum, ersattningsTyp,ersattningsKostnadInkl,
ersattningsKostnadExkl,sum)
AS
(
SELECT personalTyp,ersattningsDatum, ersattningsTyp,ersattningsKostnadInkl,
ersattningsKostnadExkl,ersattningsKostnadInkl+ersattningsKostnadExkl as Sum
FROM snille_personaltabell
INNER JOIN snille_ersattningstabell
ON snille_ersattningstabell.personalID = snille_personaltabell.personalID
WHERE ersattningsTyp=3
)
Select SUM(sum) as summa from resultTabel


--new version
WITH resultTabel (personalTyp,ersattningsDatum, ersattningsTyp,ersattningsAntal,ersattningsKostnadInkl,
ersattningsKostnadExkl,sum)
AS
(
SELECT personalTyp,ersattningsDatum, ersattningsTyp,ersattningsAntal,ersattningsKostnadInkl,
ersattningsKostnadExkl,ersattningsAntal*ersattningsKostnadExkl as Sum
FROM snille_personaltabell
INNER JOIN snille_ersattningstabell
ON snille_ersattningstabell.personalID = snille_personaltabell.personalID
WHERE ersattningsTyp=3
)
Select SUM(sum) as summa from resultTabel
--
WITH resultTabel (personalTyp,ersattningsDatum, ersattningsTyp,ersattningsAntal,ersattningsKostnadInkl,
ersattningsKostnadExkl,sum)
AS
(
SELECT personalTyp,ersattningsDatum, ersattningsTyp,ersattningsAntal,ersattningsKostnadInkl,
ersattningsKostnadExkl,ersattningsAntal*ersattningsKostnadExkl as Sum
FROM snille_personaltabell
INNER JOIN snille_ersattningstabell
ON snille_ersattningstabell.personalID = snille_personaltabell.personalID
WHERE ersattningsTyp=3 AND personalTyp=2
)
Select SUM(sum) as summa from resultTabel