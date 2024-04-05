use LibraryGamesDB

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