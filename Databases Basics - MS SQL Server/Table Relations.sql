USE People

	CREATE TABLE Passports (
		PassportID INT  PRIMARY KEY IDENTITY (101,1),
		PassportNumber VARCHAR(8)  NOT NULL
	);

DROP TABLE Persons

INSERT INTO Passports (PassportNumber)
VALUES 
		('N34FG21B'),
		('K65LO4R7'),
		('ZE657QP2')

SELECT * FROM Passports

CREATE TABLE Persons(
	
	PersonID INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(20) NOT NULL,
	Salary DECIMAL(7,2) NOT NULL,
	PassportID INT FOREIGN KEY (PassportID) REFERENCES  Passports(PassportID) UNIQUE
);

INSERT INTO Persons ([FirstName], Salary, PassportID)
VALUES 
		('Roberto', 43300, 102),
		('Tom', 56100, 103),
		('Yana', 60200, 101)

SELECT * FROM Persons

CREATE TABLE Manufacturers(
	
	ManufacturerID INT PRIMARY KEY IDENTITY,
	[Name] CHAR(20) NOT NULL,
	EstablishedOn DATE NOT NULL
)

CREATE TABLE Models (
	
	ModelID INT PRIMARY KEY IDENTITY(101,1),
	[Name] CHAR(20) NOT NULL,
	ManufacturerID INT FOREIGN KEY(ManufacturerID) REFERENCES Manufacturers(ManufacturerID)

)


INSERT INTO Manufacturers([Name], EstablishedOn)
VALUES 
		('BMW', CONVERT(date, '07/03/1916',103)),
		('Tesla', CONVERT(date, '01/01/2003',103)),
		('Lada', CONVERT(date, '01/05/1966',103))

SELECT * FROM Manufacturers


INSERT INTO Models([Name], ManufacturerID)
VALUES 
		('X1', 1),
		('i6',1),
		('Model 6', 2),
		('Model X', 2),
		('Model 3', 2),
		('Nova', 3)


SELECT * FROM Models

CREATE TABLE Students(
	
	StudentID INT PRIMARY KEY IDENTITY,
	[Name] CHAR(20) NOT NULL
)

CREATE TABLE EXAMS (

	ExamID INT PRIMARY KEY IDENTITY(101, 1),
	[Name] CHAR(20) NOT NULL
)

CREATE TABLE StudentsExams(
	
	StudentID INT NOT NULL FOREIGN KEY REFERENCES Students(StudentID),
	ExamID INT NOT NULL FOREIGN KEY REFERENCES EXAMS(ExamID),
	PRIMARY KEY(StudentID, ExamID)
)

DROP TABLE StudentsExams
DROP TABLE Exams

INSERT INTO Students([Name])
VALUES 
		('Mila'),
		('Toni'),
		('Ron')

INSERT INTO Exams([Name])
VALUES 
		('SpringMVC'),
		('Neo4j'),
		('Oracle 11g')

INSERT INTO StudentsExams(StudentID, ExamID)
VALUES 
		(1,101),
		(1,102),
		(2,101),
		(3,103),
		(2,102),
		(2,103)



