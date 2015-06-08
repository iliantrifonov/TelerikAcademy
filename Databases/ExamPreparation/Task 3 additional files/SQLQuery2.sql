USE ToyStore
GO

SELECT m.Name AS Manufacturer, COUNT(t.Name) AS [Count of toys]
FROM Manufacturers m
INNER JOIN Toys t
	ON t.ManufacturerId = m.Id
INNER JOIN AgeRanges a
	ON t.AgeRangeId = a.Id
WHERE a.MinimumAge >= 5 AND a.MaximumAge <= 10
GROUP BY m.Name
ORDER BY m.Name