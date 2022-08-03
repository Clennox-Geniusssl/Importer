--CREATE DATABASE Users
--GO

--USE Users;
--GO

--SELECT * FROM sys.databases 
--WHERE name = 'Users';

--USE Users;
--GO

--EXEC sp_helpfile;
--GO

CREATE SCHEMA Info 
    AUTHORIZATION dbo;
GO

ALTER DATABASE Users
    ADD FILEGROUP PayData;
ALTER DATABASE Users
    ADD FILE (
       NAME = PayData,
       FILENAME = 'C:\temp\clennox\PayData.mdf'
    )
    TO FILEGROUP PayData;

	ALTER DATABASE Users
	ADD LOG FILE
	(NAME = PlayLogs,
	FILENAME = 'C:\temp\clennox\PlayLogs.ldf'
	);
	GO