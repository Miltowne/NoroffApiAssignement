SELECT Country, COUNT(*) NumberOfCountries
FROM Customer
GROUP BY Country
ORDER BY NumberOfCountries DESC