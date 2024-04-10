CREATE DATABASE LibraryDB
GO
USE LibraryDB
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

Create TABLE Entrance (
    EntranceID INT PRIMARY KEY IDENTITY(1,1),
    ProductID INT,
    SupplierID INT,
    Quantity INT,
    UnitPrice DECIMAL(10, 2),
    Total DECIMAL(10, 2),
    EDate DATETIME,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID)
);


GO
Create TABLE Departures (
    DepartureID INT PRIMARY KEY IDENTITY(1,1),
    ProductID INT,
    EmployeeID INT,
    Quantity INT,
    UnitPrice DECIMAL(10, 2),
    Total DECIMAL(10, 2),
    DDate DATETIME,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);
GO

----------------------------------------------------------------
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


CREATE PROCEDURE dbo.spCustomers_Delete
(@CustomerID int)
AS
BEGIN
	DELETE FROM Customers WHERE CustomerID = @CustomerID
END;
GO

------------------------------------------------------
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


CREATE PROCEDURE dbo.spEmployees_Delete
(@EmployeeID int)
AS
BEGIN
	DELETE FROM Employees WHERE EmployeeID = @EmployeeID
END;
GO


-----------------------------------------------------------
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


CREATE PROCEDURE dbo.spSuppliers_Delete
(@SupplierID int)
AS
BEGIN
	DELETE FROM Suppliers WHERE SupplierID = @SupplierID
END;
GO


--------------------------------------------------------------
--SP_Product
CREATE PROCEDURE dbo.spProducts_GetAll
AS
BEGIN
    SELECT Products.ProductID, Products.PName, Products.PDescription, Products.Price, Products.Stock, Suppliers.SName
    FROM Products
    INNER JOIN Suppliers
    ON Products.SupplierID = Suppliers.SupplierID;
END;
GO


CREATE PROCEDURE dbo.spProducts_GetByID
(@ProductID INT)
AS
BEGIN 
    SELECT ProductID, PName, PDescription, Price, Stock, SupplierID
    FROM Products
    WHERE ProductID = @ProductID;
END;
GO


CREATE PROCEDURE dbo.spProducts_Insert
(
    @PName VARCHAR(255),
    @PDescription VARCHAR(255),
    @Price DECIMAL(18, 2),
    @Stock INT,
    @SupplierID INT
)
AS
BEGIN
    INSERT INTO Products (PName, PDescription, Price, Stock, SupplierID)
    VALUES (@PName, @PDescription, @Price, @Stock, @SupplierID);
END;
GO


CREATE PROCEDURE dbo.spProducts_Update
(
    @ProductID INT,
    @PName VARCHAR(255),
    @PDescription VARCHAR(255),
    @Price DECIMAL(18, 2),
    @Stock INT,
    @SupplierID INT
)
AS
BEGIN
    UPDATE Products
    SET PName = @PName,
        PDescription = @PDescription,
        Price = @Price,
        Stock = @Stock,
        SupplierID = @SupplierID
    WHERE ProductID = @ProductID;
END;
GO


CREATE PROCEDURE dbo.spProducts_Delete
(
    @ProductID INT
)
AS
BEGIN
    DELETE FROM Products
    WHERE ProductID = @ProductID;
END;
GO


--------------------------------------------------------------
-- SP_Entrances
Create PROCEDURE dbo.spEntrance_GetAll
AS
BEGIN
    SELECT Entrance.EntranceID, Entrance.ProductID, Entrance.SupplierID, Entrance.Quantity, Entrance.UnitPrice, Entrance.Total, Entrance.EDate, Products.PName, Suppliers.SName
    FROM Entrance
    INNER JOIN Products ON Entrance.ProductID = Products.ProductID
    INNER JOIN Suppliers ON Entrance.SupplierID = Suppliers.SupplierID;
END;
GO


Create PROCEDURE dbo.spEntrance_GetByID
(@EntranceID INT)
AS
BEGIN 
    SELECT EntranceID, ProductID, SupplierID, Quantity, UnitPrice, Total, EDate
    FROM Entrance
    WHERE EntranceID = @EntranceID;
END;
GO


Create PROCEDURE dbo.spEntrance_Insert
(
    @ProductID INT,
    @SupplierID INT,
    @Quantity INT,
    @UnitPrice DECIMAL(10, 2),
    @Total DECIMAL(10, 2),
    @EDate DATETIME
)
AS
BEGIN
    INSERT INTO Entrance (ProductID, SupplierID, Quantity, UnitPrice, Total, EDate)
    VALUES (@ProductID, @SupplierID, @Quantity, @UnitPrice, @Total, @EDate);
END;
GO


CREATE PROCEDURE dbo.spEntrance_Update
(
    @EntranceID INT,
    @ProductID INT,
    @SupplierID INT,
    @Quantity INT,
    @UnitPrice DECIMAL(10, 2),
	@Total Decimal(10,2),
    @EDate DATETIME
)
AS
BEGIN
    UPDATE Entrance
    SET ProductID = @ProductID,
        SupplierID = @SupplierID,
        Quantity = @Quantity,
        UnitPrice = @UnitPrice,
		Total = @Total,
        EDate = @EDate
    WHERE EntranceID = @EntranceID;
END;
GO


CREATE PROCEDURE dbo.spEntrance_Delete
(
    @EntranceID INT
)
AS
BEGIN
    DELETE FROM Entrance
    WHERE EntranceID = @EntranceID;
END;
GO


-------------------------------------------------------------
--SP_Departures
CREATE PROCEDURE dbo.spDeparture_GetAll
AS
BEGIN
    SELECT Departures.DepartureID, Departures.ProductID, Departures.EmployeeID, Departures.Quantity, Departures.UnitPrice, Departures.Total, Departures.DDate, Products.PName, Employees.EName
    FROM Departures
    INNER JOIN Products ON Departures.ProductID = Products.ProductID
    INNER JOIN Employees ON Departures.EmployeeID = Employees.EmployeeID;
END;
GO


CREATE PROCEDURE dbo.spDeparture_GetByID
(
    @DepartureID INT
)
AS
BEGIN 
    SELECT DepartureID, ProductID, EmployeeID, Quantity, UnitPrice, Total, DDate
    FROM Departures
    WHERE DepartureID = @DepartureID;
END;
GO


CREATE PROCEDURE dbo.spDeparture_Insert
(
    @ProductID INT,
    @EmployeeID INT,
    @Quantity INT,
    @UnitPrice DECIMAL(10, 2),
    @Total DECIMAL(10, 2),
    @DDate DATETIME
)
AS
BEGIN
    INSERT INTO Departures (ProductID, EmployeeID, Quantity, UnitPrice, Total, DDate)
    VALUES (@ProductID, @EmployeeID, @Quantity, @UnitPrice, @Total, @DDate);
END;
GO


Create PROCEDURE dbo.spDeparture_Update
(
    @DepartureID INT,
    @ProductID INT,
    @EmployeeID INT,
    @Quantity INT,
    @UnitPrice DECIMAL(10, 2),
    @Total DECIMAL(10, 2),
    @DDate DATETIME
)
AS
BEGIN
    UPDATE Departures
    SET ProductID = @ProductID,
        EmployeeID = @EmployeeID,
        Quantity = @Quantity,
        UnitPrice = @UnitPrice,
        Total = @Total,
        DDate = @DDate
    WHERE DepartureID = @DepartureID;
END;
GO


Create PROCEDURE dbo.spDeparture_Delete
(
    @DepartureID INT
)
AS
BEGIN
    DELETE FROM Departures
    WHERE DepartureID = @DepartureID;
END;
GO