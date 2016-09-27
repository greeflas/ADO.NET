USE master;
IF DB_ID('HumanResources') IS NOT NULL
   DROP DATABASE HumanResources;
CREATE DATABASE HumanResources  collate Ukrainian_CI_AS;
GO
USE HumanResources;
IF OBJECT_ID('Employee', 'U') IS NOT NULL
   DROP TABLE Employee;


CREATE TABLE dbo.Employee
(
   EmployeeId int not null IDENTITY(1,1) primary key,
   FirstName NVARCHAR(100) NOT NULL,
   LastName NVARCHAR(100) NOT NULL,
   DateBirthday Date NOT NULL,
   INN VARCHAR(24) NOT NULL
);
GO
SET DATEFORMAT dmy;
SET IDENTITY_INSERT dbo.Employee ON;
INSERT INTO dbo.Employee (EmployeeId, FirstName, LastName, DateBirthday, INN)
VALUES
   (1, 'Igor', 'Krivonos', '16.08.1972', '112233445566'),
   (2, 'Ivan', 'Darda', '22.04.1980', '222233445566'),
   (3, 'Petr', 'Sivoy', '17.03.1989', '332233445566'),
   (4, 'Dasha', 'Snejko', '10.12.1995', '442233445566');
GO
SET IDENTITY_INSERT dbo.Employee OFF;
IF OBJECT_ID('dbo.JobTitle', 'U') IS NOT NULL
   DROP TABLE dbo.JobTitle;
CREATE TABLE dbo.JobTitle
(
   JobTitleId int not null IDENTITY(1,1) primary key,
   NameJobTitle NVARCHAR(100) NOT NULL
);
GO
SET IDENTITY_INSERT dbo.JobTitle ON;
 INSERT INTO dbo.JobTitle (JobTitleId, NameJobTitle)
 VALUES 
    (1,'director'), (2,'engineer'), (3,'senior engineer'),(4,'programmer'), (5,'middle programmer'),
    (6,'senior programmer'),(7,'manager');

SET IDENTITY_INSERT dbo.JobTitle OFF;

IF OBJECT_ID('dbo.EmpPromotion', 'U') IS NOT NULL
   DROP TABLE dbo.EmpPromotion;
CREATE TABLE dbo.EmpPromotion
(
   EmpPromotionId int not null IDENTITY(1,1) primary key,
   EmployeeId int not null FOREIGN KEY REFERENCES dbo.Employee(EmployeeId),
   JobTitleId int not null FOREIGN KEY REFERENCES dbo.JobTitle(JobTitleId),
   HireDate  Date NOT NULL,
   Salary money not null DEFAULT(0)
);
GO

SET IDENTITY_INSERT dbo.EmpPromotion ON;
INSERT INTO dbo.EmpPromotion
    (EmpPromotionId, EmployeeId, JobTitleId, HireDate, Salary) 
VALUES
    (1, 1, 2, '01.07.2000', 2000),
    (2, 1, 4, '16.12.2007', 3000),
    (3, 1, 6, '21.10.2009', 7000),
    (4, 1, 1, '12.09.2013', 6500),
    (5, 2, 6, '21.10.2012', 7500),
    (6, 3, 4, '21.10.2010', 3500),
    (7, 3, 5, '21.10.2010', 4500),
    (8, 4, 2, '21.10.2012', 3200),
    (9, 4, 3, '01.10.2013', 3700);
SET IDENTITY_INSERT dbo.EmpPromotion OFF;
GO
IF  OBJECT_ID('dbo.fn_Salary', 'TF') IS NOT NULL
   DROP FUNCTION dbo.fn_Salary;

GO   
CREATE FUNCTION [dbo].[fn_Salary]
(
  @eventdate AS DATETIME,
  @WorkDay MONEY
)
RETURNS @table_salary table (EmployeeId int, Salary money )
AS
BEGIN
DECLARE @tmp table (EmployeeId int, Salary money );
INSERT INTO @tmp
  SELECT p.EmployeeId, p.Salary 
  FROM EmpPromotion p
  WHERE 
        HireDate = (SELECT MAX(HireDate) FROM EmpPromotion 
                    WHERE EmployeeId=p.EmployeeId and HireDate<=@eventdate);

INSERT INTO @table_salary
SELECT e.EmployeeId, COALESCE(t.Salary,0)
FROM Employee e LEFT join @tmp t
ON e.EmployeeId=t.EmployeeId;

   
  RETURN 
END
GO

IF  OBJECT_ID('dbo.uspGetEmployeeSalary', 'P') IS NOT NULL
   DROP PROCEDURE dbo.uspGetEmployeeSalary;

GO    
CREATE PROCEDURE [dbo].[uspGetEmployeeSalary]
@LastName nvarchar(50),
@Salary money OUTPUT
AS  
BEGIN
  SELECT  @Salary = p.Salary
  FROM Employee e inner join EmpPromotion p
  ON e.EmployeeId=p.EmployeeId
  where e.LastName=@LastName and
  p.HireDate = (select MAX(HireDate) from EmpPromotion WHERE EmployeeId=e.EmployeeId)

END
GO