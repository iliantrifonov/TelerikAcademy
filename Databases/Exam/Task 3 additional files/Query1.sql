USE Company
GO

SELECT Employees.FirstName + ' ' + Employees.LastName AS [Full name], YearSalary AS Salary
FROM Employees
WHERE Employees.YearSalary BETWEEN 100000 AND 150000
ORDER BY Employees.YearSalary ASC