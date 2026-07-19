USE OnlineRetailStore;

DROP FUNCTION IF EXISTS AnnualSalary;

DELIMITER //

CREATE FUNCTION AnnualSalary(
    MonthlySalary DECIMAL(10,2)
)
RETURNS DECIMAL(10,2)
DETERMINISTIC
BEGIN
    RETURN MonthlySalary * 12;
END //

DELIMITER ;

SELECT
    EmployeeName,
    Salary,
    AnnualSalary(Salary) AS YearlySalary
FROM Employees;