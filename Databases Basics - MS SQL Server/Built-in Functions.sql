--Problem 1. Find Names of All Employees by First Name
USE SoftUni

SELECT [FirstName], [LastName] FROM Employees
WHERE SUBSTRING([FirstName],1, 2) = 'SA'

--Problem 2. Find Names of All employees by Last Name 

SELECT [FirstName], [LastName] FROM Employees
WHERE [LastName] LIKE '%ei%'

--Problem 3. Find First Names of All Employees

SELECT [FirstName] FROM Employees
WHERE DepartmentID = 3 OR DepartmentID = 10 AND (YEAR(HireDate) >= 1995 AND YEAR(HireDate) <= 2005)

-- Problem 4. Find All Employees Except Engineers

SELECT [FirstName], [LastName] FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'


-- Problem 5. Find Towns with Name Length

SELECT [Name] FROM Towns
WHERE LEN([Name]) = 5 OR LEN([Name]) = 6
ORDER BY [Name]

--06. Find Towns Starting With

SELECT * FROM Towns
WHERE SUBSTRING([Name], 1,1) = 'M' OR SUBSTRING([Name], 1,1) = 'K' OR SUBSTRING([Name], 1,1) = 'B' OR SUBSTRING([Name], 1,1) = 'E'
ORDER BY [Name]

-- 07. Find Towns Not Starting With

SELECT * FROM Towns
WHERE SUBSTRING([Name], 1,1) != 'R' AND SUBSTRING([Name], 1,1) != 'B' AND SUBSTRING([Name], 1,1) != 'D'
ORDER BY [Name]

-- Problem 8. Create View Employees Hired After 2000 Year

-- Problem 9. Length of Last Name

SELECT [FirstName], [LastName] FROM Employees
WHERE LEN([LastName]) = 5

-- Rank Employees by Salary

SELECT [EmployeeID], [FirstName], [LastName], [Salary],
DENSE_RANK() OVER (
	PARTITION BY [Salary]
	ORDER BY [EmployeeID]

) AS [Rank]
FROM Employees
WHERE [Salary] >= 10000 AND [Salary] <= 50000
ORDER BY Salary DESC
 

