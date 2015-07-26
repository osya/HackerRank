select co.Continent, FLOOR(AVG(ci.Population))
from Country co left join City ci on ci.CountryCode = co.Code
group by co.Continent
having Cast(AVG(ci.Population) as int) is not null;