CREATE DATABASE LibraryDB
GO
USE LibraryDB
GO
CREATE TABLE Suppliers (
    SupplierID INT PRIMARY KEY,
    Name VARCHAR(255),
    Address VARCHAR(255),
    Phone VARCHAR(20),
    Email VARCHAR(255)
);
GO

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    Name VARCHAR(255),
    Email VARCHAR(255),
    Phone VARCHAR(20)
);
GO

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    Name VARCHAR(255),
    Lastname VARCHAR(255),
    Email VARCHAR(255),
    Phone VARCHAR(20)
);
GO

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    Name VARCHAR(255),
    Description TEXT,
    Price DECIMAL(10, 2),
    Stock INT,
    SupplierID INT,
    FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID)
);
GO

CREATE TABLE PurchaseDetails (
    PurchaseDetailID INT PRIMARY KEY,
    ProductID INT,
    SupplierID INT,
    Quantity INT,
    UnitPrice DECIMAL(10, 2),
    Total DECIMAL(10, 2),
    Date DATE,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID)
);
GO

CREATE TABLE SalesDetails (
    SaleDetailID INT PRIMARY KEY,
    ProductID INT,
    EmployeeID INT,
    Quantity INT,
    UnitPrice DECIMAL(10, 2),
    Total DECIMAL(10, 2),
    Date DATE,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID)
);
GO

