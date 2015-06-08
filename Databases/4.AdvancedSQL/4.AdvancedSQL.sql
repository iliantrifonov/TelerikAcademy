USE TelerikAcademy

--1.Write a SQL query to find the names and salaries of the employees that take the minimal 
--salary in the company. Use a nested SELECT statement.

SELECT e.FirstName, e.LastName, e.Salary
FROM Employees e
WHERE e.Salary = (SELECT MIN(Salary) FROM Employees)

--2.Write a SQL query to find the names and salaries of the employees that have a salary that
--is up to 10% higher than the minimal salary for the company.

SELECT e.FirstName, e.LastName, e.Salary
FROM Employees e
WHERE e.Salary BETWEEN (SELECT MIN(Salary) 
						FROM Employees) AND (
						SELECT MIN(Salary)*1.1 
						FROM Employees)

--3.Write a SQL query to find the full name, salary and department of the employees that take 
--the minimal salary in their department. Use a nested SELECT statement.

SELECT e.FirstName + ' ' + e.LastName AS [Full Name], e.Salary, e.DepartmentID
FROM Employees e
WHERE e.Salary = (SELECT MIN(Salary) 
				  FROM Employees 
				  WHERE DepartmentID = e.DepartmentID)
ORDER BY e.DepartmentID

--4.Write a SQL query to find the average salary in the department #1.

SELECT AVG(Salary) AS [Avarage Salary]
FROM Employees
WHERE DepartmentID = 1

--5.Write a SQL query to find the average salary  in the "Sales" department.

SELECT AVG(Salary) AS [Avarage Salary], d.Name
FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
GROUP BY d.Name

--6.Write a SQL query to find the number of employees in the "Sales" department.

SELECT COUNT(*) AS [Number of employees], d.Name
FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
GROUP BY d.Name

--7.Write a SQL query to find the number of all employees that have manager.

SELECT COUNT(*) AS [Number of employees with a manager]
FROM Employees e
WHERE e.ManagerID IS NOT NULL

--8.Write a SQL query to find the number of all employees that have no manager.

SELECT COUNT(*) AS [Number of employees without a manager]
FROM Employees e
WHERE e.ManagerID IS NULL

--9.Write a SQL query to find all departments and the average salary for each of them.

SELECT d.Name, AVG(Salary)
FROM Employees e
	INNER JOIN Departments d
	ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name

--10.Write a SQL query to find the count of all employees in each department and for each town.

SELECT COUNT(*) AS [Employee count], d.Name AS [Department Name], t.Name AS [Town Name]
FROM Employees e 
	INNER JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
		INNER JOIN Addresses a
		ON e.AddressID = a.AddressID
			INNER JOIN Towns t
			ON t.TownID = a.TownID
GROUP BY d.Name, t.Name
ORDER BY d.Name

--11.Write a SQL query to find all managers that have exactly 5 employees. Display their first 
--name and last name.

SELECT m.FirstName, m.LastName
FROM Employees m
	INNER JOIN Employees e
	ON e.ManagerID = m.EmployeeID
WHERE e.ManagerID = m.EmployeeID
GROUP BY m.FirstName, m.LastName
HAVING COUNT(e.ManagerID) = 5

--12.Write a SQL query to find all employees along with their managers. For employees that do 
--not have manager display the value "(no manager)".

SELECT e.FirstName + ' ' + e.LastName AS [Employee name], COALESCE(m.FirstName + ' ' + m.LastName, '(no manager)') AS [Manager name]
FROM Employees e
	LEFT OUTER JOIN Employees m
	ON e.ManagerID = m.EmployeeID
WHERE e.ManagerID = m.EmployeeID OR e.ManagerID IS NULL
ORDER BY e.ManagerID

--13.Write a SQL query to find the names of all employees whose last name is exactly 5 characters
--long. Use the built-in LEN(str) function.

SELECT e.FirstName, e.LastName
FROM Employees e
WHERE LEN(e.LastName) = 5

--14.Write a SQL query to display the current date and time in the following format "day.month.year
--hour:minutes:seconds:milliseconds". Search in  Google to find how to format dates in SQL Server.

SELECT CONVERT(VARCHAR(24),GETDATE(),104) + ' ' + CONVERT(VARCHAR(24),GETDATE(),114)


--15.Write a SQL statement to create a table Users. Users should have username, password, full name 
--and last login time. Choose appropriate data types for the table fields. Define a primary key 
--column with a primary key constraint. Define the primary key column as identity to facilitate 
--inserting records. Define unique constraint to avoid repeating usernames. Define a check constraint 
--to ensure the password is at least 5 characters long.

CREATE TABLE Users (
  UsersID int IDENTITY NOT NULL UNIQUE,
  UserName nvarchar(100) NOT NULL UNIQUE,
  Password nvarchar(100) NOT NULL,
  FullName nvarchar(100) NOT NULL,
  LastLoginTime datetime,
  CONSTRAINT PK_Users PRIMARY KEY(UsersID)
)
GO

ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [MinLengthConstraint] CHECK (DATALENGTH([Password]) >= 5)
GO

--16.Write a SQL statement to create a view that displays the users from the Users table that have 
--been in the system today. Test if the view works correctly.

CREATE VIEW [Logged in today] AS
SELECT *
FROM Users
WHERE DAY(LastLoginTime) = DAY(GETDATE()) AND MONTH(LastLoginTime) = MONTH(GETDATE()) AND YEAR(LastLoginTime) = YEAR(GETDATE())
GO

INSERT INTO Users(UserName, Password, FullName, LastLoginTime)
VALUES ('SomeUser', 'somepassword', 'The full name', GETDATE());
GO

SELECT *
FROM [Logged in today]

--17.Write a SQL statement to create a table Groups. Groups should have unique name (use unique 
--constraint). Define primary key and identity column.

CREATE TABLE Groups (
  GroupID int IDENTITY NOT NULL UNIQUE,
  CONSTRAINT PK_Groups PRIMARY KEY(GroupID)
)
GO
ALTER TABLE Groups
ADD Name nvarchar(100) NOT NULL UNIQUE
GO

--18.Write a SQL statement to add a column GroupID to the table Users. Fill some data in this new 
--column and as well in the Groups table. Write a SQL statement to add a foreign key constraint between 
--tables Users and Groups tables.

ALTER TABLE Users
ADD GroupID int
GO

INSERT INTO Groups(Name)
VALUES ('First group');
GO

INSERT INTO Users(UserName, Password, FullName, LastLoginTime, GroupID)
VALUES ('SomeUser2', 'somepassword', 'The full name', GETDATE(), 1);
GO

ALTER TABLE Users
ADD CONSTRAINT FK_Groups_Users FOREIGN KEY (GroupID) REFERENCES Groups(GroupID)
GO

--19.Write SQL statements to insert several records in the Users and Groups tables.

INSERT INTO Groups(Name)
VALUES ('Second group');
GO

INSERT INTO Groups(Name)
VALUES ('Third group');
GO

INSERT INTO Groups(Name)
VALUES ('Forth group');
GO

INSERT INTO Users(UserName, Password, FullName, LastLoginTime, GroupID)
VALUES ('SomeUser3', 'somepassword', 'The full name', GETDATE(), 2);
GO

INSERT INTO Users(UserName, Password, FullName, LastLoginTime, GroupID)
VALUES ('SomeUser4', 'somepassword', 'The full name', GETDATE(), 2);
GO

--20.Write SQL statements to update some of the records in the Users and Groups tables.

UPDATE Users
SET FullName='Other full name'
WHERE UserName='SomeUser4'
GO

UPDATE Users
SET UserName='Changed user name'
WHERE UserName='SomeUser4'
GO

UPDATE Groups
SET Name='Some really cool new group'
WHERE GroupID=1
GO

--21.Write SQL statements to delete some of the records from the Users and Groups tables.

DELETE FROM Users
WHERE UsersID=1
GO

DELETE FROM Groups
WHERE GroupID=4
GO

--22.Write SQL statements to insert in the Users table the names of all employees from the Employees 
--table. Combine the first and last names as a full name. For username use the first letter of the 
--first name + the last name (in lowercase). Use the same for the password, and NULL for last login time.

INSERT INTO Users(UserName, Password, FullName)
--Adding 4 letters from first name here and below as I dont get all uniques.
SELECT SUBSTRING(LOWER(FirstName), 0, 4) + LOWER(LastName), 
		+ SUBSTRING(LOWER(FirstName), 0, 4) + LOWER(LastName),
		(FirstName + ' ' + LastName)
FROM Employees
GO

--23.Write a SQL statement that changes the password to NULL for all users that have not been in the 
--system since 10.03.2010.

--Was not nullable before
ALTER TABLE Users 
ALTER COLUMN Password nvarchar(100) NULL
GO

UPDATE Users
SET Password=NULL
WHERE LastLoginTime < CONVERT(datetime, '10/03/2010', 103)
GO

--24.Write a SQL statement that deletes all users without passwords (NULL password).

DELETE FROM Users
WHERE Password=NULL
GO

--25.Write a SQL query to display the average employee salary by department and job title.

SELECT AVG(Salary) AS [Avarage salary], e.JobTitle, d.Name AS [Department name]
FROM Employees e 
	INNER JOIN Departments d
	on e.DepartmentID = d.DepartmentID
GROUP BY e.JobTitle, d.Name

--26.Write a SQL query to display the minimal employee salary by department and job title along with 
--the name of some of the employees that take it.

SELECT e.FirstName, e.LastName, MIN(Salary) AS [Minimal salary], e.JobTitle, d.Name AS [Department name]
FROM Employees e 
	INNER JOIN Departments d
	on e.DepartmentID = d.DepartmentID
GROUP BY e.JobTitle, d.Name, e.FirstName, e.LastName

--27.Write a SQL query to display the town where maximal number of employees work.

SELECT TOP 1 t.Name, COUNT(t.Name) AS [Count]
FROM Employees e
	INNER JOIN Addresses a
	ON a.AddressID = e.AddressID
	INNER JOIN Towns t
	ON t.TownID = a.TownID
GROUP BY t.Name
ORDER BY [Count] DESC

--28.Write a SQL query to display the number of managers from each town.

SELECT t.Name, COUNT(t.Name) AS [Manager Count]
FROM Employees e
	INNER JOIN Employees m
	ON e.ManagerID = m.EmployeeID
	INNER JOIN Addresses a
	ON a.AddressID = e.AddressID
	INNER JOIN Towns t
	ON t.TownID = a.TownID
GROUP BY t.Name, m.EmployeeID
ORDER BY [Manager Count] DESC

--29.Write a SQL to create table WorkHours to store work reports for each employee (employee id, 
--date, task, hours, comments). Don't forget to define  identity, primary key and appropriate 
--foreign key. 

CREATE TABLE WorkHours(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	EmployeeId int NOT NULL FOREIGN KEY REFERENCES Employees(EmployeeId),
	ReportDate date NOT NULL,
	Task nvarchar(80) NOT NULL,
	ExecutionHours float NOT NULL,
	Comments nvarchar(255) NOT NULL
)
GO

--		Issue few SQL statements to insert, update and delete of some data in the table.
--		Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers. 
--For each change keep the old record data, the new record data and the command 
--(insert / update / delete).

INSERT WorkHours VALUES('1', GETDATE(), 'DoStuff', '2.5', 'Comment1');
INSERT WorkHours VALUES('2', GETDATE(), 'Do other stuff', '1', 'Comment2');
UPDATE WorkHours SET Comments = 'Changed comment' WHERE WorkHours.EmployeeId = 2;
DELETE FROM WorkHours WHERE WorkHours.EmployeeId = 1;
INSERT WorkHours VALUES('1', GETDATE(), 'Some work', '2.5', 'Comment3');
GO

CREATE TABLE WorkHoursLogs(
	Id int IDENTITY NOT NULL PRIMARY KEY,
	OldEmployeeId int FOREIGN KEY REFERENCES Employees(EmployeeId),
	NewEmployeeId int FOREIGN KEY REFERENCES Employees(EmployeeId),
	OldReportDate date,
	NewReportDate date,
	OldTask nvarchar(80),
	NewTask nvarchar(80),
	OldExecutionHours float,
	NewExecutionHours float,
	OldComments nvarchar(255),
	NewComments nvarchar(255),
	Command nvarchar(50) NULL
)
GO

CREATE TRIGGER WorkHoursAfterInsert ON dbo.WorkHours AFTER INSERT AS
BEGIN
	DECLARE
		@NewEmployeeId int,
		@NewReportDate date,
		@NewTask nvarchar(80),
		@NewExecutionHours float,
		@NewComments nvarchar(255);
	SELECT
		@NewEmployeeId = inserted.EmployeeId,
		@NewReportDate = inserted.ReportDate,
		@NewTask = inserted.Task,
		@NewExecutionHours = inserted.ExecutionHours,
		@NewComments = inserted.Comments
	FROM inserted;
	INSERT INTO WorkHoursLogs (
		NewEmployeeId,
		NewReportDate,
		NewTask,
		NewExecutionHours,
		NewComments,
		Command
	)
	VALUES (
		@NewEmployeeId,
		@NewReportDate,
		@NewTask,
		@NewExecutionHours,
		@NewComments,
		'INSERT'
	)
END
GO

INSERT WorkHours VALUES('1', GETDATE(), 'Inserted thing', '2.5', 'Comment4');
GO

SELECT * FROM WorkHoursLogs;
GO

CREATE TRIGGER WorkHoursAfterUpdate ON dbo.WorkHours AFTER UPDATE AS
BEGIN
	DECLARE
		@NewEmployeeId int,
		@NewReportDate date,
		@NewTask nvarchar(80),
		@NewExecutionHours float,
		@NewComments nvarchar(255),
		@OldEmployeeId int,
		@OldReportDate date,
		@OldTask nvarchar(80),
		@OldExecutionHours float,
		@OldComments nvarchar(255);
	SELECT
		@NewEmployeeId = inserted.EmployeeId,
		@NewReportDate = inserted.ReportDate,
		@NewTask = inserted.Task,
		@NewExecutionHours = inserted.ExecutionHours,
		@NewComments = inserted.Comments
	FROM inserted;
	SELECT
		@OldEmployeeId = deleted.EmployeeId,
		@OldReportDate = deleted.ReportDate,
		@OldTask = deleted.Task,
		@OldExecutionHours = deleted.ExecutionHours,
		@OldComments = deleted.Comments
	FROM deleted;
	INSERT INTO WorkHoursLogs (
		NewEmployeeId,
		NewReportDate,
		NewTask,
		NewExecutionHours,
		NewComments,
		OldEmployeeId,
		OldReportDate,
		OldTask,
		OldExecutionHours,
		OldComments,
		Command
		)
	VALUES (
		@NewEmployeeId,
		@NewReportDate,
		@NewTask,
		@NewExecutionHours,
		@NewComments,
		@OldEmployeeId,
		@OldReportDate,
		@OldTask,
		@OldExecutionHours,
		@OldComments,
		'UPDATE'
	);
END
GO

UPDATE WorkHours SET Comments = 'Updated another comment' WHERE WorkHours.EmployeeId = 1;
GO

SELECT * FROM WorkHoursLogs;
GO

CREATE TRIGGER WorkHoursAfterDelete ON dbo.WorkHours AFTER DELETE AS
BEGIN
	DECLARE
		@NewEmployeeId int,
		@NewReportDate date,
		@NewTask nvarchar(80),
		@NewExecutionHours float,
		@NewComments nvarchar(255),
		@OldEmployeeId int,
		@OldReportDate date,
		@OldTask nvarchar(80),
		@OldExecutionHours float,
		@OldComments nvarchar(255);
	SELECT
		@NewEmployeeId = inserted.EmployeeId,
		@NewReportDate = inserted.ReportDate,
		@NewTask = inserted.Task,
		@NewExecutionHours = inserted.ExecutionHours,
		@NewComments = inserted.Comments
	FROM inserted;
	SELECT
		@OldEmployeeId = deleted.EmployeeId,
		@OldReportDate = deleted.ReportDate,
		@OldTask = deleted.Task,
		@OldExecutionHours = deleted.ExecutionHours,
		@OldComments = deleted.Comments
	FROM deleted;
	INSERT INTO WorkHoursLogs (
		NewEmployeeId,
		NewReportDate,
		NewTask,
		NewExecutionHours,
		NewComments,
		OldEmployeeId,
		OldReportDate,
		OldTask,
		OldExecutionHours,
		OldComments,
		Command
	)
	VALUES (
		@NewEmployeeId,
		@NewReportDate,
		@NewTask,
		@NewExecutionHours,
		@NewComments,
		@OldEmployeeId,
		@OldReportDate,
		@OldTask,
		@OldExecutionHours,
		@OldComments,
		'DELETE'
	);
END
GO

DELETE FROM WorkHours WHERE WorkHours.EmployeeId = 1;
GO

SELECT * FROM WorkHoursLogs;
GO

--30.Start a database transaction, delete all employees from the 'Sales' department along with 
--all dependent records from the pother tables. At the end rollback the transaction.

ALTER TABLE dbo.Employees
ADD CONSTRAINT FK_Employees_Addresses_Cascade
FOREIGN KEY (AddressID) 
REFERENCES dbo.Addresses(AddressID) 
ON DELETE CASCADE;

ALTER TABLE dbo.Employees
ADD CONSTRAINT FK_Employees_Departments_Cascade
FOREIGN KEY (DepartmentID) 
REFERENCES dbo.Departments(DepartmentID) 
ON DELETE CASCADE;

ALTER TABLE dbo.EmployeesProjects
ADD CONSTRAINT FK_EmployeesProjects_Employees_Cascade
FOREIGN KEY (EmployeeID) 
REFERENCES dbo.Employees(EmployeeID) 
ON DELETE CASCADE;
GO

BEGIN TRAN DeleteEmployee
DELETE FROM Employees 
WHERE Employees.EmployeeID = 5;
ROLLBACK TRAN
GO

--31.Start a database transaction and drop the table EmployeesProjects. Now how you could restore 
--back the lost table data?

BEGIN TRAN
DROP TABLE EmployeesProjects
ROLLBACK TRAN

--32.Find how to use temporary tables in SQL Server. Using temporary tables backup all records 
--from EmployeesProjects and restore them back after dropping and re-creating the table.


BEGIN TRAN
SELECT *
INTO #EmployeesProjects_Archive
FROM EmployeesProjects;

DROP TABLE EmployeesProjects;

SELECT *
INTO EmployeesProjects
FROM #EmployeesProjects_Archive;
DROP TABLE #EmployeesProjects_Archive;
COMMIT TRAN
GO
