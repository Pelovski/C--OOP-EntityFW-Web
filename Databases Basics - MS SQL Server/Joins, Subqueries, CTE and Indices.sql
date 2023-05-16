--1. Employee Address
USE SoftUni

SELECT TOP(50) e.EmployeeId, e.JobTitle, e.AddressID, a.AddressText FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
ORDER BY E.AddressID

-- 2. Addresses with Towns

SELECT TOP(50) e.FirstName, e.LastName, t.Name AS Town, a.AddressText FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName

--3. Sales Employee

SELECT e.EmployeeID, e.FirstName, e.LastName, d.Name AS DepartmentName FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY e.EmployeeID


-- 4. Employee Departments

SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.Name AS DepartmentName FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID

-- 5. Employees Without Project

SELECT TOP(3) e.EmployeeID, e.FirstName FROM Employees AS e
FULL JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
WHERE ep.EmployeeID IS NULL
ORDER BY e.EmployeeID


-- 6. Employees Hired After

SELECT e.FirstName, e.LastName, e.HireDate, d.Name AS DeptName FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '1999-01-01' AND (d.Name = 'Sales' OR d.Name = 'Finance')
ORDER BY e.HireDate


-- 7. Employees with Project

SELECT TOP(5) e.EmployeeID, e.FirstName, p.Name FROM Employees AS e
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID


-- 8. Employee 24

SELECT e.EmployeeID, e.FirstName, p.Name AS ProjectName FROM Employees AS e
FULL JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
FULL JOIN Projects AS p ON ep.ProjectID = p.ProjectID


-- 09. Employee Manager

SELECT e.EmployeeID, e.FirstName, e.ManagerID, em.FirstName FROM Employees AS e
JOIN Employees AS em ON e.ManagerID = em.EmployeeID
WHERE e.ManagerID = 3 OR e.ManagerID = 7
ORDER BY e.EmployeeID

-- 14. Countries with Rivers

USE Geography

SELECT TOP(5) c.CountryName, r.RiverName FROM Countries AS c
FULL JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
FULL JOIN Rivers AS r ON cr.RiverId = r.Id
JOIN Continents AS co ON c.ContinentCode = co.ContinentCode
WHERE co.ContinentName = 'Africa'	
ORDER BY c.CountryName
