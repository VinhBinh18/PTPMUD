-- 1/ Tạo DB + Sử dụng DB
CREATE DATABASE WH_MANAGEMENT
GO
USE WH_MANAGEMENT
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
    S_Name NVARCHAR(50),
    S_Address NVARCHAR(225),
    S_Phone NVARCHAR(20),
    S_Email NVARCHAR(20),
    PRIMARY KEY (S_ID)
)
GO

CREATE TABLE Products
(
    P_ID INT IDENTITY(1,1),
    P_Name NVARCHAR(100),
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
    Rl_Name NVARCHAR(30),
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
ALTER TABLE Users
    ADD CONSTRAINT FK10_Wh_ID_User FOREIGN KEY (Wh_ID)
    REFERENCES WareHouse(Wh_ID)
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



-- 1. Thêm dữ liệu vào bảng WareHouse
INSERT INTO WareHouse (Wh_Name, Wh_Address, Wh_Phone)
VALUES
('Kho Miền Bắc', '123 Đường Láng, Hà Nội', '02412345678'),
('Kho Miền Nam', '456 Đường Cộng Hòa, TP.HCM', '02898765432');

-- 2. Thêm dữ liệu vào bảng Branch
INSERT INTO Branch (B_Name, B_Address, B_Phone, Wh_ID)
VALUES
('Chi nhánh Hà Nội', '789 Đường Hoàng Quốc Việt, Hà Nội', '02411112222', 1),
('Chi nhánh Đà Nẵng', '123 Đường Nguyễn Văn Linh, Đà Nẵng', '02361112222', 1),
('Chi nhánh TP.HCM', '456 Đường Lê Văn Sỹ, TP.HCM', '02833334444', 2);

-- 3. Thêm dữ liệu vào bảng Roles
INSERT INTO Roles (Rl_Name)
VALUES
('Admin'),
('Manager'),
('Staff');

-- 4. Thêm dữ liệu vào bảng Calculation_Unit
INSERT INTO Calculation_Unit (Un_Name)
VALUES
('kg'),
('hộp'),
('túi'),
('chai'),
('lon'),
('hũ'),
('bao'),
('hộp lớn');

-- 5. Thêm dữ liệu vào bảng Origin
INSERT INTO Origin (O_Name)
VALUES
('Việt Nam'),
('Mỹ'),
('Anh Quốc'),
('Nhật Bản'),
('Thái Lan'),
('Hàn Quốc'),
('Đức'),
('Pháp'),
('Ý');

-- 6. Thêm dữ liệu vào bảng Suppliers
INSERT INTO Suppliers (S_Name, S_Address, S_Phone, S_Email)
VALUES
('Royal Canin', '200 Đường Cách Mạng Tháng 8, TP.HCM', '0281234567', 'royalcanin@gmail.com'),
('Pedigree', '350 Đường Lê Trọng Tấn, Hà Nội', '0242345678', 'pedigree@gmail.com'),
('Whiskas', '100 Đường Yết Kiêu, Đà Nẵng', '0236456789', 'whiskas@gmail.com'),
('Me-O', '500 Đường Lê Văn Việt, TP.HCM', '0287654321', 'me-o@gmail.com'),
('SmartHeart', '20 Đường Trường Chinh, TP.HCM', '0281122334', 'smartheart@gmail.com'),
('Aatas', '99 Đường Lý Tử Tấn, Đà Nẵng', '0236888999', 'aataspet@gmail.com'),
('Hills Science Diet', '456 Đường Cống Quỳnh, TP.HCM', '0286677889', 'hillss@gmail.com'),
('Cat Eye', '321 Đường Huỳnh Thúc Kháng, Hà Nội', '0245566778', 'cateye@gmail.com'),
('Nutri Source', '555 Đường HOÀNG DIỆU, Hà Nội', '0249988776', 'nutrice@gmail.com');

-- 7. Thêm dữ liệu vào bảng Products
INSERT INTO Products (P_Name, P_Price, S_ID, O_ID, Un_ID)
VALUES
('Thức ăn hạt Royal Canin cho chó', 500000, 1, 2, 1),
('Thức ăn Pedigree cho chó lớn', 750000, 2, 1, 1),
('Thức ăn Whiskas cho mèo con', 300000, 3, 2, 2),
('Thức ăn Me-O vị cá ngừ cho mèo', 400000, 4, 4, 3),
('Thức ăn hạt SmartHeart cho chó con', 250000, 5, 5, 1),
('Thức ăn Aatas vị cá ngừ cho mèo', 300000, 6, 4, 2),
('Thức ăn Hills Science cho chó lớn', 450000, 7, 3, 3),
('Đồ ăn nhẹ Royal Canin cho chó', 200000, 1, 2, 4),
('Thức ăn Pedigree vị gà cho chó', 350000, 2, 5, 2),
('Đồ ăn Whiskas vị cá cho mèo', 150000, 3, 2, 5),
('Thức ăn Me-O vị hải sản cho mèo', 320000, 4, 4, 1),
('Đồ ăn nhẹ Nutri Source cho mèo', 250000, 9, 1, 4),
('Thức ăn Cat Eye cho mèo lông dài', 300000, 9, 5, 3),
('Thức ăn Royal Canin Indoor cho mèo', 400000, 1, 2, 2),
('Bóng chơi cho chó Cat Eye', 50000, 9, 1, 2),
('Xương gặm cho chó SmartHeart', 70000, 5, 3, 3),
('Chuông đeo cổ cho mèo Pedigree', 80000, 2, 5, 5),
('Găng tay chải lông cho chó mèo Hill Science', 60000, 7, 4, 1),
('Đĩa bay đồ chơi cho chó mèo Aatas', 50000, 6, 3, 2),
('Sữa tắm cho chó mèo Nutri Source', 150000, 6, 2, 4),
('Vitamin bổ sung cho chó mèo Royal Canin', 200000, 1, 1, 5),
('Thuốc trị ve rận cho chó mèo Cat Eye', 180000, 9, 3, 2),
('Xịt khử mùi cho chuồng thú Hills Science', 120000, 7, 5, 3),
('Bột tắm khô cho mèo Me-O', 160000, 4, 4, 1),
('Đồ ăn hạt Pedigree vị rau củ cho chó', 340000, 2, 1, 1),
('Đồ chơi gặm dành cho chó Me-O', 60000, 4, 2, 2), 
('Đồ chơi mèo Aatas dạng lò xo', 70000, 6, 5, 5),
('Sữa bột bổ sung Hills cho chó con', 220000, 7, 4, 3),
('Thức ăn ướt SmartHeart vị thịt gà cho mèo', 270000, 5, 3, 4),
('Xương giả cho chó Cat Eye', 55000, 9, 2, 5),
('Hạt dinh dưỡng Royal Canin cho mèo', 420000, 1, 4, 1),
('Đồ chơi lăn Whiskas cho mèo', 65000, 3, 1, 3),
('Vitamin bổ sung Pedigree cho mèo lông ngắn', 250000, 2, 3, 2),
('Nước hoa khử mùi Nutri Source cho chuồng', 180000, 3, 4, 5);

-- 8. Thêm dữ liệu vào bảng Users
INSERT INTO Users (U_UserName, U_Password, U_Address, U_Phone, Rl_ID)
VALUES
('Quang Minh', '123', '100 Thành Thái, P.12, Q.10, Tp. HCM', '0123456789', 1),
('Nhật Phương', '1234', '180 Hải Thượng Lãn Ông, P. 10 , Quận 5 , TP. HCM', '0234567890', 2),
('Vĩnh bình', '12345', '172 Tân Kỳ Tân Quý, P. Sơn Kỳ, Q. Tân Phú, Tp. HCM ', '0345678901', 3);


-- 9. Thêm dữ liệu vào bảng WH_Transaction
INSERT INTO WH_Transaction (T_Number, T_TotalQuantity, T_TotalAmount, T_Note, T_EntryDate, T_ExportDate, T_Type, T_Status, B_ID, Wh_ID)
VALUES
('GD001', 200, 10000000, 'Nhập hàng tháng 1', '2024-01-01', NULL, 'Nhập', 1, 1, 1),
('GD002', 150, 7500000, 'Nhập hàng bổ sung', '2024-01-15', NULL, 'Nhập', 1, 2, 1),
('GD003', 50, 2500000, 'Xuất hàng', NULL, '2024-01-20', 'Xuất', 1, 3, 1),
('GD004', 500, 25000000, 'Nhập hàng định kỳ tháng 2', '2024-02-05', NULL, 'Nhập', 1, 1, 1),
('GD005', 350, 17500000, 'Nhập bổ sung thức ăn', '2024-02-15', NULL, 'Nhập', 1, 2, 1),
('GD006', 100, 5000000, 'Xuất hàng cho chi nhánh', NULL, '2024-02-20', 'Xuất', 1, 3, 1),
('GD007', 200, 10000000, 'Nhập thêm đồ chơi', '2024-03-01', NULL, 'Nhập', 1, 1, 2),
('GD008', 300, 15000000, 'Xuất hàng dịp lễ', NULL, '2024-03-10', 'Xuất', 1, 2, 2);

-- 10. Thêm dữ liệu vào bảng WH_Transaction_Details
INSERT INTO WH_Transaction_Details (TD_Quantity, TD_UnitPrice, TD_TotalPrice, TD_Dates, T_ID, P_ID)
VALUES
(20, 500000, 10000000, '2024-01-01', 1, 1),
(10, 750000, 7500000, '2024-01-15', 2, 2),
(5, 500000, 2500000, '2024-01-20', 3, 3),
(10, 500000, 5000000, '2024-02-05', 4, 1),
(20, 250000, 5000000, '2024-02-05', 4, 2),
(15, 300000, 4500000, '2024-02-15', 5, 3),
(10, 200000, 2000000, '2024-02-15', 5, 4),
(5, 750000, 3750000, '2024-02-20', 6, 5),
(10, 500000, 5000000, '2024-02-20', 6, 6),
(25, 300000, 7500000, '2024-03-01', 7, 7),
(30, 200000, 6000000, '2024-03-01', 7, 8),
(40, 300000, 12000000, '2024-03-10', 8, 9),
(35, 400000, 14000000, '2024-03-10', 8, 10),
(15, 220000, 3300000, '2024-02-05', 4, 11),
(8, 340000, 2720000, '2024-02-15', 5, 12),
(20, 150000, 3000000, '2024-02-20', 6, 13),
(30, 50000, 1500000, '2024-03-01', 7, 14),
(50, 180000, 9000000, '2024-03-10', 8, 15);



-- 11. Thêm dữ liệu vào bảng Report
INSERT INTO Report (R_Name, R_Descriptions, R_StartDate, R_EndDate, B_ID, Wh_ID)
VALUES
('Doanh thu tháng 1', 'Báo cáo tổng doanh thu tháng 1 năm 2024', '2024-01-01', '2024-01-31', 1, 1),
('Doanh thu tháng 2', 'Báo cáo tổng doanh thu tháng 2 năm 2024', '2024-02-01', '2024-02-28', 1, 1),
('Doanh thu quý 1', 'Báo cáo tổng doanh thu quý 1 năm 2024', '2024-01-01', '2024-03-31', 2, 2),
('Xuất kho tháng 1', 'Báo cáo tổng số hàng xuất kho tháng 1 năm 2024', '2024-01-01', '2024-01-31', 2, 1),
('Nhập kho tháng 2', 'Báo cáo tổng số hàng nhập kho tháng 2 năm 2024', '2024-02-01', '2024-02-28', 1, 2),
('Báo cáo nhập hàng quý 1', 'Báo cáo tổng số hàng nhập kho quý 1 năm 2024', '2024-01-01', '2024-03-31', 1, 1),
('Báo cáo xuất hàng quý 1', 'Báo cáo tổng số hàng xuất kho quý 1 năm 2024', '2024-01-01', '2024-03-31', 2, 2),
('Doanh thu tháng 3', 'Báo cáo tổng doanh thu tháng 3 năm 2024', '2024-03-01', '2024-03-31',  1, 1),
('Báo cáo tồn kho tháng 1', 'Báo cáo tổng số hàng tồn kho tháng 1 năm 2024', '2024-01-01', '2024-01-31', 2, 2),
('Báo cáo tồn kho tháng 2', 'Báo cáo tổng số hàng tồn kho tháng 2 năm 2024', '2024-02-01', '2024-02-28', 1, 1);












