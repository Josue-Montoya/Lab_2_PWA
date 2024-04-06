CREATE DATABASE LibraryGamesDB
GO
USE LibraryGamesDB
GO
CREATE TABLE Suppliers (
    SupplierID INT PRIMARY KEY IDENTITY(1,1),
    SName VARCHAR(255),
    SAddress VARCHAR(255),
    Phone VARCHAR(20),
    Email VARCHAR(255)
);
GO

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    CName VARCHAR(255),
    Email VARCHAR(255),
    Phone VARCHAR(20)
);
GO

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    EName VARCHAR(255),
    Lastname VARCHAR(255),
    Email VARCHAR(255),
    Phone VARCHAR(20)
);
GO

CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    PName VARCHAR(255),
    PDescription VARCHAR(255),
    Price MONEY,
    Stock INT,
    SupplierID INT,
    FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID)
);
GO

CREATE TABLE Entrace (
    PurchaseDetailID INT PRIMARY KEY IDENTITY(1,1),
    ProductID INT,
    SupplierID INT,
    Quantity INT,
    UnitPrice DECIMAL(10, 2),
    Total MONEY,
    EDate DATE,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID)
);
GO

CREATE TABLE Departures (
    SaleDetailID INT PRIMARY KEY IDENTITY(1,1),
    ProductID INT,
    EmployeeID INT,
    Quantity INT,
    UnitPrice DECIMAL(10, 2),
    Total MONEY,
    DDate DATE,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);
GO
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
CREATE PROCEDURE dbo.spEmployees_Delete
(@EmployeeID int)
AS
BEGIN
	DELETE FROM Employees WHERE EmployeeID = @EmployeeID
END;
GO


CREATE PROCEDURE dbo.spEmployees_GetAll
AS
BEGIN
	SELECT EmployeeID, EName, Lastname, Email, Phone FROM Employees
END;
GO


CREATE PROCEDURE dbo.spEmployees_GetById(@EmployeeID INT)
AS
BEGIN
	SELECT EmployeeID, EName, Lastname, Email, Phone
	FROM Employees
    WHERE EmployeeID = @EmployeeID
END;
GO


CREATE PROCEDURE dbo.spEmployees_Insert
(
	@EName nvarchar(255),
	@Lastname nvarchar(255),
	@Email nvarchar(20),
	@Phone VARCHAR(255)
)
AS
BEGIN
	INSERT INTO Employees 
	VALUES(@EName, @Lastname, @Email, @Phone)
END;
GO


CREATE PROCEDURE dbo.spEmployees_Update
(
	@EName nvarchar(255),
	@Lastname nvarchar(255),
	@Email nvarchar(20),
	@Phone VARCHAR(255),
	@EmployeeID int
)
AS
BEGIN
	UPDATE Employees 
	SET EName = @EName,
	Lastname = @Lastname,
	Email = @Email,
	Phone = @Phone
    WHERE EmployeeID = @EmployeeID
END;
GO
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