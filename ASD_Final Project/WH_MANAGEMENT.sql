-- 1/ Tạo DB + Sử dụng DB
CREATE DATABASE WarehouseManagement
GO
USE WarehouseManagement
GO

-- 2/ Tạo các table + Khóa chính tự tăng
CREATE TABLE WareHouse
(
    Wh_ID INT IDENTITY(1,1),
    Wh_Name NVARCHAR(50),
    Wh_Address NVARCHAR(255),
    Wh_Phone NVARCHAR(20),
    PRIMARY KEY (Wh_ID)
)
GO

CREATE TABLE Branch
(
    B_ID INT IDENTITY(1,1),
    B_Name NVARCHAR(50),
    B_Address NVARCHAR(225),
    B_Phone NVARCHAR(20),
    Wh_ID INT,
    PRIMARY KEY (B_ID)
)
GO

CREATE TABLE WH_Transaction
(
    T_ID INT IDENTITY(1,1),
    T_Number NVARCHAR(50),
    T_TotalQuantity FLOAT,
    T_TotalAmount FLOAT,
    T_Note NVARCHAR(100),
    T_EntryDate DATETIME,
    T_ExportDate DATETIME,
    T_Type NVARCHAR(20),
    T_Status BIT,
    B_ID INT,
    Wh_ID INT,
    PRIMARY KEY (T_ID)
)
GO

CREATE TABLE WH_Transaction_Details
(
    TD_ID INT IDENTITY(1,1),
    TD_Quantity FLOAT,
    TD_UnitPrice FLOAT,
    TD_TotalPrice FLOAT,
    TD_Dates DATETIME,
    T_ID INT,
    P_ID INT,
    PRIMARY KEY (TD_ID)
)
GO

CREATE TABLE Report
(
    R_ID INT IDENTITY(1,1),
    R_Name NVARCHAR(50),
    R_Descriptions NVARCHAR(50),
    R_StartDate DATETIME,
    R_EndDate DATETIME,
    B_ID INT,
    Wh_ID INT,
    PRIMARY KEY (R_ID)
)
GO

CREATE TABLE Calculation_Unit
(
    Un_ID INT IDENTITY(1,1),
    Un_Name NVARCHAR(20),
    PRIMARY KEY (Un_ID)
)
GO

CREATE TABLE Origin
(
    O_ID INT IDENTITY(1,1),
    O_Name NVARCHAR(20),
    PRIMARY KEY (O_ID)
)
GO

CREATE TABLE Suppliers
(
    S_ID INT IDENTITY(1,1),
    S_Name NVARCHAR(20),
    S_Address NVARCHAR(225),
    S_Phone NVARCHAR(20),
    S_Email NVARCHAR(20),
    PRIMARY KEY (S_ID)
)
GO

CREATE TABLE Products
(
    P_ID INT IDENTITY(1,1),
    P_Name NVARCHAR(20),
    P_Price FLOAT,
    S_ID INT,
    O_ID INT,
    Un_ID INT,
    PRIMARY KEY (P_ID)
)
GO

CREATE TABLE Roles
(
    Rl_ID INT IDENTITY(1,1),
    Rl_Name NVARCHAR(20),
    PRIMARY KEY (Rl_ID)
)
GO

CREATE TABLE Users
(
    U_ID INT IDENTITY(1,1),
    U_UserName NVARCHAR(100),
    U_Password NVARCHAR(50),
    U_Address NVARCHAR(225),
    U_Phone NVARCHAR(20),
    Rl_ID INT,
    PRIMARY KEY (U_ID)
)
GO

-- 3/ Tạo khóa ngoại
-- Khóa ngoại cho bảng Branch
ALTER TABLE Branch
    ADD CONSTRAINT FK1_WarehouseID FOREIGN KEY (Wh_ID)
    REFERENCES WareHouse(Wh_ID)
GO

-- Khóa ngoại cho bảng WH_Transaction
ALTER TABLE WH_Transaction
    ADD CONSTRAINT FK2_WarehouseID_Trans FOREIGN KEY (Wh_ID)
    REFERENCES WareHouse(Wh_ID)
GO

ALTER TABLE WH_Transaction
    ADD CONSTRAINT FK3_BranchID_Trans FOREIGN KEY (B_ID)
    REFERENCES Branch(B_ID)
GO

-- Khóa ngoại cho bảng Report
ALTER TABLE Report
    ADD CONSTRAINT FK4_WarehouseID_Report FOREIGN KEY (Wh_ID)
    REFERENCES WareHouse(Wh_ID)
GO

ALTER TABLE Report
    ADD CONSTRAINT FK5_BranchID_Report FOREIGN KEY (B_ID)
    REFERENCES Branch(B_ID)
GO

-- Khóa ngoại cho bảng Users
ALTER TABLE Users
    ADD CONSTRAINT FK6_RolesID_User FOREIGN KEY (Rl_ID)
    REFERENCES Roles(Rl_ID)
GO

-- Khóa ngoại cho bảng WH_Transaction_Details
ALTER TABLE WH_Transaction_Details
    ADD CONSTRAINT FK4_TransactionID_Trans_Details FOREIGN KEY (T_ID)
    REFERENCES WH_Transaction(T_ID)
GO

ALTER TABLE WH_Transaction_Details
    ADD CONSTRAINT FK5_ProductID_Trans_Details FOREIGN KEY (P_ID)
    REFERENCES Products(P_ID)
GO

-- Khóa ngoại cho bảng Products
ALTER TABLE Products
    ADD CONSTRAINT FK7_SuppID_Products FOREIGN KEY (S_ID)
    REFERENCES Suppliers(S_ID)
GO

ALTER TABLE Products
    ADD CONSTRAINT FK8_OriginID_Products FOREIGN KEY (O_ID)
    REFERENCES Origin(O_ID)
GO

ALTER TABLE Products
    ADD CONSTRAINT FK9_UnitID_Products FOREIGN KEY (Un_ID)
    REFERENCES Calculation_Unit(Un_ID)
GO
