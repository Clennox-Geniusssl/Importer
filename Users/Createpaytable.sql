USE Users;
GO

DROP TABLE IF EXISTS Info.PayInfo;
GO


CREATE TABLE Info.PayInfo
(
AdeptRef varchar(10) NOT NULL,
Amount numeric(4,2) NULL,
EffectiveDate datetime2(0) NOT NULL,
Source varchar(100) NOT NULL,
Method varchar(25)NOT NULL,
Comment varchar(50) NOT NULL
);

DROP TABLE IF EXISTS Info.UserInfo;
GO

CREATE TABLE Info.UserInfo
(
DebtType varchar(20) NOT NULL,
AccNum numeric(10) NOT NULL,
AccName varchar(50) NOT NULL,
DOB datetime NOT NULL,
Balance decimal(6,2) NOT NULL,
Email varchar(255) NOT NULL,
Phone numeric(15) NOT NULL,
Addr1 nvarchar(100)	NOT NULL,
Addr2 nvarchar(100) NULL,
Addr3 nvarchar(100) NOT NULL,
Postcode nvarchar(10) NOT NULL
);