USE OnlineRetailStore;
DROP TABLE IF EXISTS CustomersIndex;

CREATE TABLE CustomersIndex (
    CustomerID INT PRIMARY KEY,
    CustomerName VARCHAR(100),
    Email VARCHAR(100),
    City VARCHAR(50)
);
INSERT INTO CustomersIndex VALUES
(1,'John','john@gmail.com','Hyderabad'),
(2,'Mary','mary@gmail.com','Bangalore'),
(3,'David','david@gmail.com','Chennai'),
(4,'Rahul','rahul@gmail.com','Mumbai'),
(5,'Priya','priya@gmail.com','Delhi');
SELECT * FROM CustomersIndex;
CREATE INDEX idx_customer_name
ON CustomersIndex(CustomerName);
SHOW INDEX FROM CustomersIndex;
SELECT *
FROM CustomersIndex
WHERE CustomerName = 'John';
DROP INDEX idx_customer_name
ON CustomersIndex;
SHOW INDEX FROM CustomersIndex;