use LibraryGamesDB

CREATE PROCEDURE dbo.spCustomers_Delete
(@CustomerID int)
AS
BEGIN
	DELETE FROM Customers WHERE CustomerID = @CustomerID
END;
GO


CREATE PROCEDURE dbo.spCustomers_GetAll
AS
BEGIN
	SELECT CustomerID, CName, Email, Phone FROM Customers
END;
GO


CREATE PROCEDURE dbo.spCustomers_GetById(@CustomerID INT)
AS
BEGIN
	SELECT CustomerID, CName, Email, Phone
	FROM Customers
    WHERE CustomerID = @CustomerID
END;
GO


CREATE PROCEDURE dbo.spCustomers_Insert
(
	@CName nvarchar(255),
	@Email nvarchar(255),
	@Phone nvarchar(20)
)
AS
BEGIN
	INSERT INTO Customers 
	VALUES(@CName, @Email, @Phone)
END;
GO


CREATE PROCEDURE dbo.spCustomers_Update
(
	@CName nvarchar(255),
	@Email nvarchar(255),
	@Phone nvarchar(20),
	@CustomerID int
)
AS
BEGIN
	UPDATE Customers 
	SET CName = @CName,
	Email = @Email,
	Phone = @Phone
    WHERE CustomerID = @CustomerID
END;
GO