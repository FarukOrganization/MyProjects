



Create table CurrencyInformation
(
ID uniqueidentifier,
CurrencyName Varchar(100),
CountryId  uniqueidentifier,
UserId uniqueidentifier,
CreateDateTime datetime,
DeleteTime datetime
)
GO
drop table CountryInformation

Create table CountryInformation
(
ID uniqueidentifier primary key,
CountryName  Varchar(150),
UserId uniqueidentifier,
CreateDateTime datetime,
DeleteTime datetime
)

Go
Create table BankInformation
(
ID uniqueidentifier,
BankName  Varchar(150),
Detail Varchar(150),
UserId uniqueidentifier,
CreateDateTime datetime,
DeleteTime datetime
)

Go
Create table MoneyChangerInformation
(
ID uniqueidentifier,
MoneyChangerName  Varchar(150),
Owner Varchar(150),
Address Varchar(200),
UserId uniqueidentifier,
CreateDateTime datetime,
DeleteTime datetime
)
Go
Create table BankBranchInformation
(
ID uniqueidentifier,
BankId uniqueidentifier,
BranchName  Varchar(150),
Detail Varchar(150),
UserId uniqueidentifier,
CreateDateTime datetime,
DeleteTime datetime
)
Go
Drop table Customer

Create Table Customer
(
Id uniqueidentifier Primary key,
Name varchar(200),
PassportNo varchar(50),
Nationality uniqueidentifier foreign key references CountryInformation(ID),
MobileNumber varchar(20),
Address varchar(300),
UpdateCheckTimeStamp timestamp
)

Go
Drop table PurchaseInformation

Create Table PurchaseInformation
(
Id uniqueidentifier Primary key,
PurchaseGroupId uniqueidentifier,
Cust_Id uniqueidentifier,
MoneyReceiptNo varchar(50),
CurrencyId uniqueidentifier,
Amount decimal(12,2),
Rate decimal(7,3),
Total decimal(14,3),
--IsCustomer bit,
--IsBank bit,
--IsMoneyChanger bit,
CustomerType int,--1=normal people,2=Bank,3=moneychanger
AccNo varchar(100),
RefMoneyReceiptNo varchar(50),
IsCancel bit,
UserId uniqueidentifier,
PurchasedDate date,
CreateDateTime datetime,
DeleteTime datetime,
UpdateCheckTimeStamp timestamp
)
Go
Drop table SellInformation

Create Table SellInformation
(
Id uniqueidentifier Primary key,
SellGroupId uniqueidentifier,
Cust_Id uniqueidentifier,
MoneyReceiptNo varchar(50),
CurrencyId uniqueidentifier,
Amount decimal(12,2),
Rate decimal(7,3),
Total decimal(14,3),
--IsCustomer bit,
--IsBank bit,
--IsMoneyChanger bit,
CustomerType int,--1=normal people,2=Bank,3=moneychanger
AccNo varchar(100),
RefMoneyReceiptNo varchar(50),
IsCancel bit,
UserId uniqueidentifier,
SoldDate date,
CreateDateTime datetime,
DeleteTime datetime,
UpdateCheckTimeStamp timestamp
)





