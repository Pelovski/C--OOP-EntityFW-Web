CREATE TABLE Departments(
	Id INT PRIMARY KEY IDENTITY,
   [Name] NVARCHAR(20) NOT NULL
)

CREATE TABLE Employees(
    Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	MiddleName NVARCHAR(20),
	LastName NVARCHAR(20) NOT NULL,
	JobTitle NVARCHAR(20) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
	HireDate DATETIME2 NOT NULL,
	Salary DECIMAL(10,2) NOT NULL,
	AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
)

INSERT INTO Towns ([Name])
	VALUES
		('Sofia'),
		('Plovdiv'),
		('Varna'),
		('Burgas') 

INSERT INTO Departments([Name])
	VALUES
	    ('Engineering'),
		('Sales'),
		('Marketing'),
		('Software Development'),
		('Quality Assurance')

INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary)
	VALUES
		('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00),
		('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000.00),
		('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2006-08-28', 525.25),
		('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000.00),
		('Peter', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88)



SELECT * FROM Addresses



SELECT * FROM Towns
ORDER BY [Name] ASC


SELECT * FROM Departments
ORDER BY [Name] ASC

SELECT * FROM Employees
ORDER BY Salary DESC

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC

UPDATE Employees
SET Salary += Salary *0.1