USE Minions


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


   ALTER TABLE Users
	DROP CONSTRAINT [PK__Users__3214EC0783C24447]

ALTER TABLE Users
ADD CONSTRAINT PK_Users_CompositeIdUsername
PRIMARY KEY(Id, Username)


ALTER TABLE Users
ADD CONSTRAINT CK_Users_PasswordLength
CHECK(LEN([Password]) >= 5)

ALTER TABLE Users
ADD CONSTRAINT DF_Users_LastLogInTime
DEFAULT GETDATE() FOR LastLogInTime

INSERT INTO Users(Username, [Password], IsDeleted)
	VALUES
	('WAGNER', '123456', 0)

	SELECT * FROM Users

ALTER TABLE Users
DROP CONSTRAINT PK_Users_CompositeIdUsername

ALTER TABLE Users
ADD CONSTRAINT PK_Users_Id
PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT UQ_Users_UsernameLength
CHECK(LEN(Username) >= 3)
	