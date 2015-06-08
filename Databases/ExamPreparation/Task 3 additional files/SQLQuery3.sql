USE ToyStore
GO

SELECT t.Name, t.Price, t.Color
FROM Toys t
INNER JOIN ToysCategories tc
	ON t.Id = tc.ToyId
INNER JOIN Categories c
	ON tc.CategoriesId = c.Id
WHERE c.Name = 'boys'