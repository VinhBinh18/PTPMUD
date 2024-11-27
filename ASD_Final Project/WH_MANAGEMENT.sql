-- Database and tables creation
CREATE DATABASE WH_MANAGEMENT_four;
GO
USE WH_MANAGEMENT_four;
GO

-- 1. Create WareHouse table
CREATE TABLE WareHouse
(
    Wh_ID INT IDENTITY(1,1),
    Wh_Name NVARCHAR(50),
    Wh_Address NVARCHAR(255),
    Wh_Phone NVARCHAR(20),
    PRIMARY KEY (Wh_ID)
);
GO

-- 2. Create WH_Transaction table
CREATE TABLE WH_Transaction
(
    T_ID INT IDENTITY(1,1),
    T_Note NVARCHAR(100),
    T_EntryDate DATETIME,
    T_ExportDate DATETIME,
    T_Type NVARCHAR(20),
    Wh_ID INT,
    PRIMARY KEY (T_ID)
);
GO

-- 3. Create WH_Transaction_Details table
CREATE TABLE WH_Transaction_Details
(
    TD_ID INT IDENTITY(1,1),
    TD_Quantity FLOAT,
    TD_Dates DATETIME,
    T_ID INT,
    P_ID INT,
    PRIMARY KEY (TD_ID)
);
GO

-- 4. Create Calculation_Unit table
CREATE TABLE Calculation_Unit
(
    Un_ID INT IDENTITY(1,1),
    Un_Name NVARCHAR(20),
    PRIMARY KEY (Un_ID)
);
GO

-- 5. Create Origin table
CREATE TABLE Origin
(
    O_ID INT IDENTITY(1,1),
    O_Name NVARCHAR(20),
    PRIMARY KEY (O_ID)
);
GO

-- 6. Create Suppliers table
CREATE TABLE Suppliers
(
    S_ID INT IDENTITY(1,1),
    S_Name NVARCHAR(50),
    S_Address NVARCHAR(225),
    S_Phone NVARCHAR(20),
    S_Email NVARCHAR(50),
    PRIMARY KEY (S_ID)
);
GO

-- 7. Create Products table
CREATE TABLE Products
(
    P_ID INT IDENTITY(1,1),
    P_Name NVARCHAR(100),
    P_Price FLOAT,
    S_ID INT,
    O_ID INT,
    Un_ID INT,
    PRIMARY KEY (P_ID)
);
GO

-- 8. Create Roles table
CREATE TABLE Roles
(
    Rl_ID INT IDENTITY(1,1),
    Rl_Name NVARCHAR(30),
    PRIMARY KEY (Rl_ID)
);
GO

-- 9. Create Users table
CREATE TABLE Users
(
    U_ID INT IDENTITY(1,1),
    U_UserName NVARCHAR(100),
    U_Password NVARCHAR(50),
    U_Address NVARCHAR(225),
    U_Phone NVARCHAR(20),
    Rl_ID INT,
    Wh_ID INT,
    PRIMARY KEY (U_ID)
);
GO

-- Adding foreign keys
ALTER TABLE WH_Transaction
    ADD CONSTRAINT FK2_WarehouseID_Trans FOREIGN KEY (Wh_ID)
    REFERENCES WareHouse(Wh_ID);
GO

ALTER TABLE Users
    ADD CONSTRAINT FK6_RolesID_User FOREIGN KEY (Rl_ID)
    REFERENCES Roles(Rl_ID);
GO

ALTER TABLE Users

    ADD CONSTRAINT FK10_WhID_User FOREIGN KEY (Wh_ID)
    REFERENCES WareHouse(Wh_ID)

GO

ALTER TABLE WH_Transaction_Details
    ADD CONSTRAINT FK4_TransactionID_Trans_Details FOREIGN KEY (T_ID)
    REFERENCES WH_Transaction(T_ID);
GO

ALTER TABLE WH_Transaction_Details
    ADD CONSTRAINT FK5_ProductID_Trans_Details FOREIGN KEY (P_ID)
    REFERENCES Products(P_ID);
GO

ALTER TABLE Products
    ADD CONSTRAINT FK7_SuppID_Products FOREIGN KEY (S_ID)
    REFERENCES Suppliers(S_ID);
GO

ALTER TABLE Products
    ADD CONSTRAINT FK8_OriginID_Products FOREIGN KEY (O_ID)
    REFERENCES Origin(O_ID);
GO

ALTER TABLE Products
    ADD CONSTRAINT FK9_UnitID_Products FOREIGN KEY (Un_ID)
    REFERENCES Calculation_Unit(Un_ID);
GO

INSERT INTO WareHouse (Wh_Name, Wh_Address, Wh_Phone)
VALUES
('Warehouse North', '123 North St, Hanoi', '02412345678'),
('Warehouse Central', '456 Central Ave, Da Nang', '02312345678'),
('Warehouse South', '789 South Rd, HCMC', '02812345678');

-- Sample data for Roles
INSERT INTO Roles (Rl_Name)
VALUES ('Admin'), ('Manager'), ('Staff');

-- Sample data for Calculation_Unit
INSERT INTO Calculation_Unit (Un_Name)
VALUES ('Box'), ('Bag'), ('Bottle');

-- Sample data for Origin
INSERT INTO Origin (O_Name)
VALUES ('Vietnam'), ('USA'), ('UK'), ('Japan'), ('Thailand');

-- Sample data for Suppliers
INSERT INTO Suppliers (S_Name, S_Address, S_Phone, S_Email)
VALUES 
('Supplier A', '200 Maple St, Hanoi', '02498765432', 'supplierA@example.com'),
('Supplier B', '300 Pine Rd, HCMC', '02865432109', 'supplierB@example.com'),
('Supplier C', '400 Oak Ave, Da Nang', '02334567890', 'supplierC@example.com');

-- Sample data for Products
INSERT INTO Products (P_Name, P_Price, S_ID, O_ID, Un_ID)
VALUES 
('Product 1', 50000, 1, 1, 1),
('Product 2', 75000, 2, 2, 2),
('Product 3', 100000, 3, 3, 3),
('Product 4', 25000, 1, 4, 1),
('Product 5', 150000, 2, 5, 2);

-- Sample data for Users
INSERT INTO Users (U_UserName, U_Password, U_Address, U_Phone, Rl_ID, Wh_ID)
VALUES 
('user1', 'password1', '123 Maple St, Hanoi', '0123456789', 1, 1),
('user2', 'password2', '456 Pine Rd, Da Nang', '0987654321', 2, 2),
('user3', 'password3', '789 Oak Ave, HCMC', '0321654987', 3, 3);

-- Sample data for WH_Transaction
INSERT INTO WH_Transaction (T_Note, T_EntryDate, T_ExportDate, T_Type, Wh_ID)
VALUES 
('January Shipment', '2023-01-10', NULL, 'Import', 1),
('February Shipment', '2023-02-10', '2023-03-01', 'Export', 1),
('March Shipment', '2023-03-10', NULL, 'Import', 2),
('April Shipment', '2023-04-10', '2023-04-20', 'Export', 2),
('May Shipment', '2023-05-10', NULL, 'Import', 3);

-- Sample data for WH_Transaction_Details
INSERT INTO WH_Transaction_Details (TD_Quantity, TD_Dates, T_ID, P_ID)
VALUES 
(100, '2023-01-10', 1, 1),
(150, '2023-02-10', 2, 2),
(200, '2023-03-10', 3, 3),
(250, '2023-04-10', 4, 4),
(300, '2023-05-10', 5, 5);

-- Sample data insertion for WareHouse, Roles, Calculation_Unit, Origin, Suppliers, Products, Users, WH_Transaction, and WH_Transaction_Details

-- Optimized Query to Check Product Status in Storage and Generate Report
WITH TransactionStatus AS (
    SELECT 
        p.P_Name AS ProductName,
        w.Wh_Name AS Warehouse,
        t.T_Note AS TransactionNote,
        t.T_EntryDate AS EntryDate,
        t.T_ExportDate AS ExportDate,
        DATEDIFF(DAY, t.T_EntryDate, COALESCE(t.T_ExportDate, GETDATE())) AS DaysInStorage,
        CASE
            WHEN t.T_ExportDate IS NULL THEN 'Not Shipped'
            WHEN DATEDIFF(DAY, t.T_EntryDate, t.T_ExportDate) <= 20 THEN 'In Transit'
            ELSE 'Delivered'
        END AS Status
    FROM 
        WH_Transaction t
        JOIN WareHouse w ON t.Wh_ID = w.Wh_ID
        JOIN WH_Transaction_Details td ON t.T_ID = td.T_ID
        JOIN Products p ON td.P_ID = p.P_ID
    WHERE 
        DATEDIFF(DAY, t.T_EntryDate, COALESCE(t.T_ExportDate, GETDATE())) > 20
)

SELECT 
    ProductName,
    Warehouse,
    TransactionNote,
    EntryDate,
    ExportDate,
    DaysInStorage,
    Status
FROM 
    TransactionStatus
ORDER BY 
    Status, DaysInStorage DESC;
go
SELECT 
    w.Wh_Name AS WarehouseName,
    p.P_Name AS ProductName,
    p.P_Price AS ProductPrice,
    td.TD_Quantity AS Quantity,
    t.T_Note AS TransactionNote,
    t.T_EntryDate AS EntryDate,
    t.T_ExportDate AS ExportDate
FROM 
    WH_Transaction t
    JOIN WareHouse w ON t.Wh_ID = w.Wh_ID
    JOIN WH_Transaction_Details td ON t.T_ID = td.T_ID
    JOIN Products p ON td.P_ID = p.P_ID
ORDER BY 
    w.Wh_Name, p.P_Name;



SELECT 
    w.Wh_Name AS WarehouseName,
    p.P_Name AS ProductName,
    SUM(td.TD_Quantity) AS TotalQuantity
FROM 
    WH_Transaction t
    JOIN WareHouse w ON t.Wh_ID = w.Wh_ID
    JOIN WH_Transaction_Details td ON t.T_ID = td.T_ID
    JOIN Products p ON td.P_ID = p.P_ID
WHERE 
    w.Wh_Name = 'Warehouse North'
GROUP BY 
    w.Wh_Name, p.P_Name
ORDER BY 
    p.P_Name;