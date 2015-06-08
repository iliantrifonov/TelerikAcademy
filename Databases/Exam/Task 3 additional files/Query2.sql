USE Company
GO

SELECT Departments.Name AS [Department Name], COUNT(Employees.Id) AS [Employee count]
FROM Departments
INNER JOIN Employees
	ON Employees.DepartmentId = Departments.Id
GROUP BY Departments.Name
ORDER BY COUNT(Employees.Id) DESC