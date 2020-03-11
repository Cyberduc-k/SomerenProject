
use [pdb1920nl15]
select *
from Docenten as D
join Begeleid as B on D.DocentID = B.DocentID
join Activiteiten as A on B.ActiviteitID = A.ActiviteitID


 