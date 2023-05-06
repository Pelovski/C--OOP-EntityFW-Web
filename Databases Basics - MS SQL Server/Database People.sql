USE Minions

CREATE TABLE People (
	
	Id INT PRIMARY KEY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX),
	Height  DECIMAL(10,2),
	[Weight] DECIMAL (10,2),
	Gender VARCHAR(2) NOT NULL,
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX)
)

CREATE TABLE Users(
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL, 
   [Password] VARCHAR(26) NOT NULL,
   ProfilePicture VARBINARY(MAX)
	CHECK(DATALENGTH(ProfilePicture) <= 900 * 1024),
   LastLoginTime DATETIME2 NOT NULL,
   IsDeleted BIT NOT NULL
)

INSERT INTO Users(Username, [Password], LastLoginTime, IsDeleted)
	VALUES
	('Venger', '123456', '1993-03-29', 0),
	('Pesho', '1234dfd56', '2023-03-15', 0),
	('Stamat', 'ajsdhasdbv', '2012-10-12', 0),
	('Ivan', 'ladyGaga12', '2022-08-13', 0),
	('Pavel', 'Stamte24', '2023-05-06', 0)


