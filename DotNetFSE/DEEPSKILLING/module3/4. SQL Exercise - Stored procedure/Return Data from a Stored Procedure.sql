USE OnlineRetailStore;

DELIMITER //

CREATE PROCEDURE GetEmployeesByDepartment(
    IN DeptName VARCHAR(50)
)
BEGIN
    SELECT *
    FROM Employees
    WHERE Department = DeptName;
END //

DELIMITER ;

CALL GetEmployeesByDepartment('IT');