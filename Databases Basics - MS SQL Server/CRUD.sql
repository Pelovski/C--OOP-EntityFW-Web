USE SoftUni
--Find all departments
SELECT * FROM  Departments


--Find all department Names
SELECT [Name] FROM Departments

--Find Salary of Each Employee
SELECT FirstName, LastName, Salary FROM  Employees

--Find Full Name of Each Employee

SELECT FirstName, MiddleName, LastName FROM  Employees


--Find Email Address of Each Employee

SELECT FirstName + '.' + LastName  + '@softuni.bg' AS [Full Email Address] FROM  Employees 