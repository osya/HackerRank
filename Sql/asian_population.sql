SELECT SUM(ci.Population)
FROM City ci
INNER JOIN Country co on ci.CountryCode = co.Code
WHERE co.Continent = 'Asia';