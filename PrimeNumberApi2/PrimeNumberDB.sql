-- Create the database
CREATE DATABASE PrimeNumberDB;
GO

-- Use the database
USE PrimeNumberDB;
GO

-- Create the PrimeChecks table
CREATE TABLE PrimeChecks (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Number INT NOT NULL,
    IsPrime BIT NOT NULL,
    CheckedAt DATETIME NOT NULL
);
GO