use LibraryGamesDB

CREATE PROCEDURE dbo.spSuppliers_Delete
(@SupplierID int)
AS
BEGIN
	DELETE FROM Suppliers WHERE SupplierID = @SupplierID
END;
GO


CREATE PROCEDURE dbo.spSuppliers_GetAll
AS
BEGIN
	SELECT SupplierID, SName, SAddress, Phone, Email FROM Suppliers
END;
GO


CREATE PROCEDURE dbo.spSuppliers_GetById(@SupplierID INT)
AS
BEGIN
	SELECT SupplierID, SName, SAddress, Phone, Email
	FROM Suppliers
    WHERE SupplierID = @SupplierID
END;
GO


CREATE PROCEDURE dbo.spSuppliers_Insert
(
	@SName nvarchar(255),
	@SAddress nvarchar(255),
	@Phone nvarchar(20),
	@Email VARCHAR(255)
)
AS
BEGIN
	INSERT INTO Suppliers 
	VALUES(@SName, @SAddress, @Phone, @Email)
END;
GO


CREATE PROCEDURE dbo.spSuppliers_Update
(
	@SName nvarchar(255),
	@SAddress nvarchar(255),
	@Phone nvarchar(20),
	@Email VARCHAR(255),
	@SupplierID int
)
AS
BEGIN
	UPDATE Suppliers 
	SET SName = @SName,
	SAddress = @SAddress,
	Phone = @Phone,
	Email = @Email
    WHERE SupplierID = @SupplierID
END;
GO