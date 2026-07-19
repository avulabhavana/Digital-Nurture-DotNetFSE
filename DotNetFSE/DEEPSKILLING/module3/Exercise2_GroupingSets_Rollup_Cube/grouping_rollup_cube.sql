USE OnlineRetailStore;

DROP TABLE IF EXISTS OrderDetails;
DROP TABLE IF EXISTS Orders;
DROP TABLE IF EXISTS Customers;

CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    CustomerName VARCHAR(100),
    Region VARCHAR(50)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    OrderDate DATE
);

CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT
);

INSERT INTO Customers VALUES
(1,'John','North'),
(2,'Mary','South'),
(3,'David','East');

INSERT INTO Orders VALUES
(1001,1,'2025-01-10'),
(1002,2,'2025-01-15'),
(1003,3,'2025-01-20');

INSERT INTO OrderDetails VALUES
(1,1001,1,2),
(2,1001,5,5),
(3,1002,2,3),
(4,1002,5,4),
(5,1003,1,1);

-- GROUPING SETS Alternative 1
SELECT
    C.Region,
    SUM(OD.Quantity) AS TotalQuantity
FROM Customers C
JOIN Orders O ON C.CustomerID = O.CustomerID
JOIN OrderDetails OD ON O.OrderID = OD.OrderID
GROUP BY C.Region;

-- GROUPING SETS Alternative 2
SELECT
    P.Category,
    SUM(OD.Quantity) AS TotalQuantity
FROM Products P
JOIN OrderDetails OD ON P.ProductID = OD.ProductID
GROUP BY P.Category;

-- GROUPING SETS Alternative 3
SELECT
    C.Region,
    P.Category,
    SUM(OD.Quantity) AS TotalQuantity
FROM Customers C
JOIN Orders O ON C.CustomerID = O.CustomerID
JOIN OrderDetails OD ON O.OrderID = OD.OrderID
JOIN Products P ON OD.ProductID = P.ProductID
GROUP BY C.Region, P.Category;

-- ROLLUP
SELECT
    C.Region,
    P.Category,
    SUM(OD.Quantity) AS TotalQuantity
FROM Customers C
JOIN Orders O ON C.CustomerID = O.CustomerID
JOIN OrderDetails OD ON O.OrderID = OD.OrderID
JOIN Products P ON OD.ProductID = P.ProductID
GROUP BY C.Region, P.Category WITH ROLLUP;