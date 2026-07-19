USE OnlineRetailStore;
DROP TABLE IF EXISTS Employees;

CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    EmployeeName VARCHAR(100),
    Department VARCHAR(50),
    Salary DECIMAL(10,2)
);
INSERT INTO Employees VALUES
(1,'John','IT',50000),
(2,'Mary','HR',45000),
(3,'David','Finance',60000),
(4,'Rahul','IT',55000),
(5,'Priya','HR',48000);
SELECT * FROM Employees;
DELIMITER //

CREATE PROCEDURE GetAllEmployees()
BEGIN
    SELECT * FROM Employees;
END //

DELIMITER ;
SHOW PROCEDURE STATUS
WHERE Db = 'OnlineRetailStore';
CALL GetAllEmployees();