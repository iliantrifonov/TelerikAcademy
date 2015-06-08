USE ToyStore
GO

SELECT Name, Price
FROM Toys
WHERE Type = 'puzzle' AND Price > 10
ORDER BY Price
