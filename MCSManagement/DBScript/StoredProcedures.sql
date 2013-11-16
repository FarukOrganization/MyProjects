


-------------------Currency information related stored procedures----------------

Alter procedure CreateNewCurrencyInformation  
(  
@ID uniqueidentifier,  
@CurrencyName Varchar(100),  
@CountryId  uniqueidentifier,  
@UserId uniqueidentifier--,  
--@CreateDateTime datetime  
)  
As  
  
declare @Count int  
  
set @Count=(Select COUNT(*) from CurrencyInformation Where CurrencyName=@CurrencyName and DeleteTime is null)  
    
if @Count=0 or @Count is null  
Begin 
  
	Insert into CurrencyInformation(Id,CurrencyName,CountryId,UserId,CreateDateTime) values  
	(  
	@ID,  
	@CurrencyName,  
	@CountryId,  
	@UserId,  
	getdate()  
	)  

End

GO

Alter procedure GetAllCurrencyInformation
As

Select Id,CurrencyName,
CountryId,
(Select CountryName from CountryInformation where Id=CountryId and deletetime is null) as CountryName,
UserId,
CreateDateTime 

from CurrencyInformation
where deletetime is null

GO

Create procedure UpdateCurrencyInformation
(
@ID uniqueidentifier,
@CurrencyName Varchar(100),
@CountryId  uniqueidentifier--,
--@UserId uniqueidentifier--,
--@CreateDateTime datetime
)
As

Update CurrencyInformation 
set CurrencyName=@CurrencyName,
CountryId=@CountryId
Where 
Id=@ID

GO

Alter procedure DeleteCurrencyInformation
(
@ID uniqueidentifier
)
As

Update CurrencyInformation 
set DeleteTime=GETDATE()
Where 
Id=@ID

GO

-------------------Country information related stored procedures----------------

Alter procedure CreateNewCountryInformation 
(  
@ID uniqueidentifier,  
@CountryName Varchar(100),  
@UserId uniqueidentifier--,  
--@CreateDateTime datetime  
)  
As  
  
declare @Count int

set @Count=(Select COUNT(*) from CountryInformation Where CountryName=@CountryName and DeleteTime is null)
  
 if @Count=0 or @Count is null
 Begin
  
  Insert into CountryInformation(Id,CountryName,UserId,CreateDateTime) values  
  (  
	@ID,  
	@CountryName,  
	@UserId,  
	getdate()  
  ) 

 End 

GO

Alter procedure GetAllCountryInformation 
As

Select Id,CountryName,UserId,CreateDateTime from CountryInformation
where deletetime is null

Go

Create procedure UpdateCountryInformation
(
@ID uniqueidentifier,
@CountryName Varchar(100)
)
As

Update CountryInformation 
set CountryName=@CountryName
Where 
Id=@ID

GO

Alter procedure DeleteCountryInformation
(
@ID uniqueidentifier
)
As

Update CountryInformation 
set DeleteTime=GETDATE()
Where 
Id=@ID

GO

-------------------Bank information related stored procedures----------------

Alter procedure CreateNewBankInformation 
(  
@ID uniqueidentifier,  
@BankName Varchar(150),  
@Detail Varchar(150),
@UserId uniqueidentifier--,  
--@CreateDateTime datetime  
)  
As  
  
declare @Count int

set @Count=(Select COUNT(*) from BankInformation Where BankName=@BankName and DeleteTime is null)
  
 if @Count=0 or @Count is null
 Begin
  
  Insert into BankInformation(Id,BankName,Detail,UserId,CreateDateTime) values  
  (  
	@ID,  
	@BankName,  
	@Detail,
	@UserId,  
	getdate()  
  ) 

 End 

GO

Alter procedure GetAllBankInformation
As

Select Id,BankName,Detail,UserId,CreateDateTime from BankInformation
where deletetime is null

Go

Alter procedure UpdateBankInformation
(
@ID uniqueidentifier,
@BankName Varchar(150),
@Detail Varchar(150)
)
As

Update BankInformation 
set BankName=@BankName,Detail=@Detail
Where 
Id=@ID

GO

Alter procedure DeleteBankInformation
(
@ID uniqueidentifier
)
As

Update BankInformation 
set DeleteTime=GETDATE()
Where 
Id=@ID

GO
-------------------Branch information related stored procedures----------------

Alter procedure CreateNewBranchInformation 
(  
@ID uniqueidentifier,  
@BankId uniqueidentifier,
@BranchName Varchar(150),  
@Detail Varchar(150),
@UserId uniqueidentifier--,  
--@CreateDateTime datetime  
)  
As  
  
declare @Count int

set @Count=(Select COUNT(*) from BankBranchInformation Where BranchName=@BranchName and BankId=@BankId and DeleteTime is null)
  
 if @Count=0 or @Count is null
 Begin
  
  Insert into BankBranchInformation(Id,BankId,BranchName,Detail,UserId,CreateDateTime) values  
  (  
	@ID,  
	@BankId,
	@BranchName,  
	@Detail,
	@UserId,  
	getdate()  
  ) 

 End 

GO

Alter procedure GetAllBranchInformationByBankId
(
 @BankId uniqueidentifier
)
As

Select Id,BankId,BranchName,Detail,UserId,CreateDateTime from BankBranchInformation
where deletetime is null 
and BankId=@BankId

Go

Alter procedure UpdateBranchInformation
(
@ID uniqueidentifier,
@BranchName Varchar(150),
@Detail Varchar(150)
)
As

Update BankBranchInformation 
set BranchName=@BranchName,Detail=@Detail
Where 
Id=@ID

GO

Alter procedure DeleteBranchInformation
(
@ID uniqueidentifier
)
As

Update BankBranchInformation 
set DeleteTime=GETDATE()
Where 
Id=@ID

GO

-------------------MoneyChanger information related stored procedures----------------


Alter procedure CreateNewMoneyChangerInformation 
(  
@ID uniqueidentifier,  
@MoneyChangerName Varchar(150),  
@Owner Varchar(150),
@Address Varchar(200),
@UserId uniqueidentifier--,  
--@CreateDateTime datetime  
)  
As  
  
declare @Count int

set @Count=(Select COUNT(*) from MoneyChangerInformation Where MoneyChangerName=@MoneyChangerName and DeleteTime is null)
  
 if @Count=0 or @Count is null
 Begin
  
  Insert into MoneyChangerInformation(Id,MoneyChangerName,Owner,Address,UserId,CreateDateTime) values  
  (  
	@ID,  
	@MoneyChangerName, 
	@Owner,
	@Address,
	@UserId,  
	getdate()  
  ) 

 End 

GO

Alter procedure GetAllMoneyChangerInformation
As

Select Id,MoneyChangerName,Owner,Address,UserId,CreateDateTime from MoneyChangerInformation
where deletetime is null

Go

Alter procedure UpdateMoneyChangerInformation
(
@ID uniqueidentifier,
@MoneyChangerName Varchar(150),
@Owner Varchar(150),
@Address Varchar(200)
)
As

Update MoneyChangerInformation 
set MoneyChangerName=@MoneyChangerName,Owner=@Owner,Address=@Address
Where 
Id=@ID

GO

Alter procedure DeleteMoneyChangerInformation
(
@ID uniqueidentifier
)
As

Update MoneyChangerInformation 
set DeleteTime=GETDATE()
Where 
Id=@ID

GO

Drop Procedure GetPurchaseInformation

Go 
CREATE Procedure GetPurchaseInformation     
(      
@FromDate date,      
@ToDate date,      
@MoneyReceiptNo varchar(50)=null,      
@CutomerType varchar(20)=null      
)      
As      
    
Declare @IsValid bit    
set @IsValid=0    
    
If @MoneyReceiptNo is null or @MoneyReceiptNo=''    
Begin    
 set @IsValid=1    
End    
      
If @CutomerType='Customer'      
Begin      
      
 Select Id,PurchaseGroupId,
  CustomerType,     
 (Select Name from Customer where Id=Cust_Id) as CustomerName,      
 MoneyReceiptNo,      
 (Select CurrencyName from CurrencyInformation where Id=CurrencyId) as CurrencyName,      
 Amount,Rate,Total,PurchasedDate      
 From PurchaseInformation      
 Where PurchasedDate  between @FromDate and @ToDate      
 And (MoneyReceiptNo=@MoneyReceiptNo or @IsValid=1)    
      
End      
Else if @CutomerType='Bank'      
Begin      
      
 Select Id,PurchaseGroupId,   
 CustomerType,    
 (Select BranchName from BankBranchInformation where Id=Cust_Id) as CustomerName,      
 MoneyReceiptNo,      
 (Select CurrencyName from CurrencyInformation where Id=CurrencyId) as CurrencyName,      
 Amount,Rate,Total,PurchasedDate      
 From PurchaseInformation      
 Where PurchasedDate  between @FromDate and @ToDate      
 And (MoneyReceiptNo=@MoneyReceiptNo or @IsValid=1)    
      
End      
Else if @CutomerType='MoneyChanger'      
Begin      
      
 Select Id,PurchaseGroupId,   
 CustomerType,    
 (Select MoneyChangerName from MoneyChangerInformation where Id=Cust_Id) as CustomerName,      
 MoneyReceiptNo,      
 (Select CurrencyName from CurrencyInformation where Id=CurrencyId) as CurrencyName,      
 Amount,Rate,Total,PurchasedDate      
 From PurchaseInformation      
 Where PurchasedDate  between @FromDate and @ToDate      
 And (MoneyReceiptNo=@MoneyReceiptNo or @IsValid=1)    
  
End  
Else  
Begin  
  
 Select Id,PurchaseGroupId, 
 CustomerType,       
 MoneyReceiptNo,      
 (Select CurrencyName from CurrencyInformation where Id=CurrencyId) as CurrencyName,      
 Amount,Rate,Total,PurchasedDate      
 From PurchaseInformation      
 Where PurchasedDate  between @FromDate and @ToDate      
 And (MoneyReceiptNo=@MoneyReceiptNo or @IsValid=1)  
  
End

Go
Drop Procedure GetSellInformation

Go 
CREATE Procedure GetSellInformation     
(      
@FromDate date,      
@ToDate date,      
@MoneyReceiptNo varchar(50)=null,      
@CutomerType varchar(20)=null      
)      
As      
    
Declare @IsValid bit    
set @IsValid=0    
    
If @MoneyReceiptNo is null or @MoneyReceiptNo=''    
Begin    
 set @IsValid=1    
End    
      
If @CutomerType='Customer'      
Begin      
      
 Select Id,SellGroupId,
  CustomerType,     
 (Select Name from Customer where Id=Cust_Id) as CustomerName,      
 MoneyReceiptNo,      
 (Select CurrencyName from CurrencyInformation where Id=CurrencyId) as CurrencyName,      
 Amount,Rate,Total,SoldDate      
 From SellInformation      
 Where SoldDate  between @FromDate and @ToDate      
 And (MoneyReceiptNo=@MoneyReceiptNo or @IsValid=1)    
      
End      
Else if @CutomerType='Bank'      
Begin      
      
 Select Id,SellGroupId,   
 CustomerType,    
 (Select BranchName from BankBranchInformation where Id=Cust_Id) as CustomerName,      
 MoneyReceiptNo,      
 (Select CurrencyName from CurrencyInformation where Id=CurrencyId) as CurrencyName,      
 Amount,Rate,Total,SoldDate      
 From SellInformation      
 Where SoldDate  between @FromDate and @ToDate      
 And (MoneyReceiptNo=@MoneyReceiptNo or @IsValid=1)    
      
End      
Else if @CutomerType='MoneyChanger'      
Begin      
      
 Select Id,SellGroupId,   
 CustomerType,    
 (Select MoneyChangerName from MoneyChangerInformation where Id=Cust_Id) as CustomerName,      
 MoneyReceiptNo,      
 (Select CurrencyName from CurrencyInformation where Id=CurrencyId) as CurrencyName,      
 Amount,Rate,Total,SoldDate      
 From SellInformation      
 Where SoldDate  between @FromDate and @ToDate      
 And (MoneyReceiptNo=@MoneyReceiptNo or @IsValid=1)    
  
End  
Else  
Begin  
  
 Select Id,SellGroupId, 
 CustomerType,       
 MoneyReceiptNo,      
 (Select CurrencyName from CurrencyInformation where Id=CurrencyId) as CurrencyName,      
 Amount,Rate,Total,SoldDate      
 From SellInformation      
 Where SoldDate  between @FromDate and @ToDate      
 And (MoneyReceiptNo=@MoneyReceiptNo or @IsValid=1)  
  
End