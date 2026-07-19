-- Exercise 1: Ranking and Window Functions

CREATE DATABASE IF NOT EXISTS OnlineRetailStore;
USE OnlineRetailStore;

DROP TABLE IF EXISTS Products;

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10,2)
);


INSERT INTO Products VALUES
(1,'Laptop A','Electronics',80000),
(2,'Laptop B','Electronics',75000),
(3,'Laptop C','Electronics',75000),
(4,'Phone A','Electronics',60000),
(5,'Shirt A','Fashion',2000),
(6,'Shirt B','Fashion',2500),
(7,'Shirt C','Fashion',2500),
(8,'Watch A','Accessories',5000),
(9,'Watch B','Accessories',7000),
(10,'Watch C','Accessories',7000);

-- Display Products

SELECT * FROM Products;

-- ROW_NUMBER()

SELECT
    ProductID,
    ProductName,
    Category,
    Price,
    ROW_NUMBER() OVER(
        PARTITION BY Category
        ORDER BY Price DESC
    ) AS RowNum
FROM Products;

-- Top 3 Products Per Category

SELECT *
FROM (
    SELECT
        ProductID,
        ProductName,
        Category,
        Price,
        ROW_NUMBER() OVER(
            PARTITION BY Category
            ORDER BY Price DESC
        ) AS RowNum
    FROM Products
) RankedProducts
WHERE RowNum <= 3;

-- RANK()

SELECT
    ProductID,
    ProductName,
    Category,
    Price,
    RANK() OVER(
        PARTITION BY Category
        ORDER BY Price DESC
    ) AS ProductRank
FROM Products;

-- DENSE_RANK()

SELECT
    ProductID,
    ProductName,
    Category,
    Price,
    DENSE_RANK() OVER(
        PARTITION BY Category
        ORDER BY Price DESC
    ) AS DenseRank
FROM Products;