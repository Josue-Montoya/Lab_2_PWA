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