select ci.Name
from City ci
inner join Country co on ci.CountryCode = co.Code
where co.Continent = 'Africa';