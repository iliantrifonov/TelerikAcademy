--1.Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and 
--Accounts(Id(PK), PersonId(FK), Balance). Insert few records for testing. Write a stored 
--procedure that selects the full names of all persons.

CREATE DATABASE BankDB
GO

USE BankDB
GO

CREATE TABLE Persons (
	Id int IDENTITY NOT NULL PRIMARY KEY,
	FirstName nvarchar(50),
	LastName nvarchar(50),
	SSN nvarchar(50),
)
GO

CREATE TABLE Accounts (
	Id int IDENTITY NOT NULL PRIMARY KEY,
	PersonId int FOREIGN KEY REFERENCES Persons(Id),
	Balance money,
)
GO

INSERT INTO Persons
VALUES('Pesho', 'Ivanov','000000000000'),
		('Ivan', 'Petrov','11111111111'),
		('Mariika', 'Ivanova','22222222222'),
		('Jeni', 'Jekova','33333333333')
GO

INSERT INTO Accounts
VALUES (1, 230),
		(2, 330),
		(2, 500.55),
		(3, 45544),
		(4, 1000)
GO

CREATE PROC dbo.usp_SelectFullNames
AS
SELECT FirstName + ' ' + LastName AS [Full name]
FROM Persons
GO

EXEC usp_SelectFullNames
GO


--2.Create a stored procedure that accepts a number as a parameter and returns all persons 
--who have more money in their accounts than the supplied number.

CREATE PROC dbo.usp_GetAllPersonsWithMoreMoneyThan(@money money = 1000)
AS
SELECT *
FROM Persons p 
	INNER JOIN Accounts a
	ON p.Id = a.PersonId
WHERE a.Balance > @money
GO

EXEC usp_GetAllPersonsWithMoreMoneyThan 999
GO

--3.Create a function that accepts as parameters – sum, yearly interest rate and number of months. 
--It should calculate and return the new sum. Write a SELECT to test whether the function works as 
--expected.

CREATE FUNCTION ufn_GetSumFromYearlyInterestRateAndMonths
	(@sum money, @yearlyInterest money, @numberOfMonths int)
RETURNS money
AS
BEGIN
RETURN (@sum * @yearlyInterest * (CONVERT(money, @numberOfMonths) / 12 )) + @sum
END
GO


SELECT dbo.ufn_GetSumFromYearlyInterestRateAndMonths(1000, 0.06, 12)
GO

--4.Create a stored procedure that uses the function from the previous example to give an 
--interest to a person's account for one month. It should take the AccountId and the interest 
--rate as parameters.

CREATE PROC dbo.usp_GiveInterestToAccountForOneMonth
	(@accountId int, @yearlyInterest money)
AS
UPDATE BankDB.dbo.Accounts
SET Balance = BankDB.dbo.ufn_GetSumFromYearlyInterestRateAndMonths (Balance, @yearlyInterest, 1)
WHERE Id = @accountId
GO

DROP PROC dbo.usp_GiveInterestToAccountForOneMonth
GO

EXEC dbo.usp_GiveInterestToAccountForOneMonth 10, 0.10

--5.Add two more stored procedures WithdrawMoney( AccountId, money) and DepositMoney 
--(AccountId, money) that operate in transactions.

CREATE PROC dbo.usp_WithdrawMoney
	(@accountId int, @amount money)
AS
BEGIN TRAN
UPDATE BankDB.dbo.Accounts
SET Balance = Balance - @amount
WHERE Id = @accountId
COMMIT TRAN
GO

EXEC dbo.usp_WithdrawMoney 1, 10

CREATE PROC dbo.usp_DepositMoney
	(@accountId int, @amount money)
AS
BEGIN TRAN
UPDATE BankDB.dbo.Accounts
SET Balance = Balance + @amount
WHERE Id = @accountId
COMMIT TRAN
GO

EXEC dbo.usp_DepositMoney 1, 10
GO
--6.Create another table – Logs(LogID, AccountID, OldSum, NewSum). Add a trigger to 
--the Accounts table that enters a new entry into the Logs table every time the sum on 
--an account changes.

CREATE TABLE Logs (
  LogID INT IDENTITY,
  OldSum money NOT NULL,
  NewSum money NOT NULL,
  AccountID INT NOT NULL,
  CONSTRAINT PK_LogID PRIMARY KEY(LogID),
  CONSTRAINT FK_Logs_Accounts
  FOREIGN KEY (AccountID)
  REFERENCES Accounts(Id)
)
GO


CREATE TRIGGER tr_AccountsUpdate ON Accounts FOR UPDATE
AS
INSERT INTO Logs (OldSum, NewSum, AccountID)
SELECT d.Balance,
           i.Balance,
           d.Id
  FROM deleted AS d
  JOIN inserted AS i
    ON d.Id = i.Id
GO 

EXEC dbo.usp_DepositMoney 1, 100
GO

--7.Define a function in the database TelerikAcademy that returns all Employee's names 
--(first or middle or last name) and all town's names that are comprised of given set of 
--letters. Example 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.

--regularExpresions for SQL http://www.codeproject.com/Articles/42764/Regular-Expressions-in-MS-SQL-Server-2005-2008

sp_configure 'clr enabled', 1
GO
RECONFIGURE
GO
 
USE TelerikAcademy
CREATE ASSEMBLY
--assembly name for references from SQL script
SqlRegularExpressions
-- assembly name and full path to assembly dll,
-- SqlRegularExpressions in this case
FROM 'D:\T-SQL\SqlRegularExpressions.dll'  --change path to dll
WITH PERMISSION_SET = SAFE
GO
--function signature
CREATE FUNCTION RegExpLike(@Text nvarchar(MAX), @Pattern nvarchar(255)) RETURNS BIT
--function external name
AS EXTERNAL NAME SqlRegularExpressions.SqlRegularExpressions.[LIKE]
 
GO
 
CREATE FUNCTION fn_RegularExpressionFind ( @regularExpression nvarchar(30) )
RETURNS TABLE
AS
RETURN SELECT Emp.FirstName,
           Emp.MiddleName,
           Emp.LastName,
           Towns.Name
  FROM Employees AS Emp
  JOIN Addresses AS Addr
    ON Emp.AddressID = Addr.AddressID
  JOIN Towns
    ON Addr.TownID = Towns.TownID
 WHERE 1 = dbo.RegExpLike(LOWER(Towns.Name), @regularExpression)
   AND (1 = dbo.RegExpLike(LOWER(Emp.FirstName), @regularExpression)
    OR 1 = dbo.RegExpLike(LOWER(ISNULL(Emp.MiddleName, '')), @regularExpression)
        OR 1 = dbo.RegExpLike(LOWER(Emp.LastName), @regularExpression))
GO
 
SELECT * FROM fn_RegularExpressionFind('^[oistmiahf]+$')
GO

--8.Using database cursor write a T-SQL script that scans all employees and their addresses 
--and prints all pairs of employees that live in the same town.
SELECT a.FirstName, a.LastName, t1.Name, b.FirstName, b.LastName
FROM Employees a
JOIN Addresses adr
ON a.AddressID = adr.AddressID
JOIN Towns t1
ON adr.TownID = t1.TownID,
 Employees b
JOIN Addresses ad
ON b.AddressID = ad.AddressID
JOIN Towns t2
ON ad.TownID = t2.TownID
WHERE t1.Name = t2.Name
  AND a.EmployeeID <> b.EmployeeID
ORDER BY a.FirstName, b.FirstName
 
OPEN empCursor
DECLARE @firstName1 NVARCHAR(50)
DECLARE @lastName1 NVARCHAR(50)
DECLARE @town NVARCHAR(50)
DECLARE @firstName2 NVARCHAR(50)
DECLARE @lastName2 NVARCHAR(50)
FETCH NEXT FROM empCursor
        INTO @firstName1, @lastName1, @town, @firstName2, @lastName2
 
WHILE @@FETCH_STATUS = 0
        BEGIN
                PRINT @firstName1 + ' ' + @lastName1 +
                        '     ' + @town + '      ' + @firstName2 + ' ' + @lastName2
                FETCH NEXT FROM empCursor
                        INTO @firstName1, @lastName1, @town, @firstName2, @lastName2
        END
 
CLOSE empCursor
DEALLOCATE empCursor

--9.* Write a T-SQL script that shows for each town a list of all employees that live in it. 
--Sample output:
--Sofia -> Svetlin Nakov, Martin Kulov, George Denchev
--Ottawa -> Jose Saraiva

USE TelerikAcademy
DECLARE empCursor CURSOR READ_ONLY FOR
SELECT Name FROM Towns
OPEN empCursor
DECLARE @townName VARCHAR(50), @userNames VARCHAR(MAX)
FETCH NEXT FROM empCursor INTO @townName
 
 
WHILE @@FETCH_STATUS = 0
  BEGIN
                BEGIN
                DECLARE nameCursor CURSOR READ_ONLY FOR
                SELECT a.FirstName, a.LastName
                FROM Employees a
                JOIN Addresses adr
                ON a.AddressID = adr.AddressID
                JOIN Towns t1
                ON adr.TownID = t1.TownID
                WHERE t1.Name = @townName
                OPEN nameCursor
               
                DECLARE @firstName VARCHAR(50), @lastName VARCHAR(50)
                FETCH NEXT FROM nameCursor INTO @firstName,  @lastName
                WHILE @@FETCH_STATUS = 0
                        BEGIN
                                SET @userNames = CONCAT(@userNames, @firstName, ' ', @lastName, ', ')
                                FETCH NEXT FROM nameCursor
                                INTO @firstName,  @lastName
                        END
        CLOSE nameCursor
        DEALLOCATE nameCursor
                END
                SET @userNames = LEFT(@userNames, LEN(@userNames) - 1)
    PRINT @townName + ' -> ' + @userNames
    FETCH NEXT FROM empCursor
    INTO @townName
  END
CLOSE empCursor
DEALLOCATE empCursor
 
GO
--10.Define a .NET aggregate function StrConcat that takes as input a sequence of strings and 
--return a single string that consists of the input strings separated by ','. For example the 
--following SQL statement should return a single string:

--SELECT StrConcat(FirstName + ' ' + LastName)
--FROM Employees

-- This is not exactly what is necessary, but I was not sure how to put it in a function without calling the table.
DECLARE @name nvarchar(MAX);
SET @name = N'';
SELECT @name+=e.FirstName+N','
FROM Employees e
SELECT LEFT(@name,LEN(@name)-1);
GO
