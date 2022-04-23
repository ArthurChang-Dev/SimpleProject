--CREATE DATABASE Development;

USE Development;
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES
			WHERE TABLE_SCHEMA = 'dbo'
			AND TABLE_NAME = 'Todos')
BEGIN
	CREATE TABLE dbo.Todos(
		[ID] INT IDENTITY(1, 1) NOT NULL,
		[Title] NVARCHAR(256) NOT NULL,
		[DateCreated] DATETIME2 NOT NULL,
		[DateModified] DATETIME2,
	);
END

--Test data
--INSERT INTO dbo.todos(title, datecreated)
--values 
--('Connect .net core app to local db', CURRENT_TIMESTAMP),
--('Create a db user for .net core app', CURRENT_TIMESTAMP)