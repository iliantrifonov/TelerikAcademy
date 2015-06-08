USE master
GO

CREATE DATABASE PerformanceDB
GO

USE PerformanceDB
GO


CREATE TABLE Logs(
  Id int NOT NULL IDENTITY,
  LogText nvarchar(300),
  LogDate datetime,
  CONSTRAINT PK_Logs_Id PRIMARY KEY (Id)
)

-- Create the entries.
SET NOCOUNT ON
DECLARE @RowCount int = 10000
WHILE @RowCount > 0
BEGIN
  DECLARE @Text nvarchar(100) = 
    'Text ' + CONVERT(nvarchar(100), @RowCount) + ': ' +
    CONVERT(nvarchar(100), newid())
  DECLARE @Date datetime = 
	DATEADD(month, CONVERT(varbinary, newid()) % (50 * 12), getdate())
  INSERT INTO Logs(LogText, LogDate)
  VALUES(@Text, @Date)
  SET @RowCount = @RowCount - 1
END
SET NOCOUNT OFF

WHILE (SELECT COUNT(*) FROM Logs) < 1000000
BEGIN
  INSERT INTO Logs(LogText, LogDate)
  SELECT LogText, LogDate FROM Logs
END

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

----------------------------TASK 1--------------------------------
SELECT l.LogDate
FROM Logs l
WHERE YEAR(l.LogDate) < 2014 AND YEAR(l.LogDate) > 1998

----------------------------TASK 2--------------------------------

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

CREATE INDEX IDX_Logs_LogDate ON Logs(LogDate)
SELECT l.LogDate
FROM Logs l
WHERE YEAR(l.LogDate) < 2014 AND YEAR(l.LogDate) > 1998

----------------------------TASK 3--------------------------------

-- Note that you need full text indexing service running and installed for this to work ( I do not have it installed so this is not tested properly. )

CHECKPOINT; DBCC DROPCLEANBUFFERS; -- Empty the SQL Server cache

DROP INDEX Logs.IDX_Logs_LogDate
CREATE FULLTEXT INDEX IDX_Logs_LogText ON Logs(LogText)
GO
SELECT l.LogText
FROM Logs l
WHERE LogText 
