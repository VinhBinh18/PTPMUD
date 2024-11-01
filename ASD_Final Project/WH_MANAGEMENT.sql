-- 1/ Tạo DB + Sử dụng DB
	Create Database WarehouseManagement
	Go
	Use WarehouseManagement
	Go

-- 2/ Tạo các table + Khoá chính	
	create table WareHouse
	(
		Wh_ID nvarchar(50),
		Wh_Name nvarchar(50),
		Wh_Address nvarchar(50),
		Phone nvarchar(20),
		primary key (Wh_ID)
	)
	go

	create table Branch
	(
		B_ID  nvarchar(50),
		B_Name nvarchar(50),
		B_Address nvarchar(50),
		Phone nvarchar(20),
		Wh_ID nvarchar(50),
		primary key (B_ID)
	)
	go

	create table WH_Transaction
	(
		T_ID  nvarchar(50),
		T_Number nvarchar(50),
		TotalQuantity float,
		TotalAmount float,
		Note nvarchar(50),
		EntryDate datetime,
		ExportDate datetime,
		T_Type nvarchar(20),
		T_Status bit,
		B_ID  nvarchar(50),
		Wh_ID nvarchar(50),
		primary key (T_ID)
	)
	go


	create table WH_Transaction_Details
	(
		TD_ID  nvarchar(50),
		Quantity float,
		UnitPrice float,
		TotalPrice float,
		Dates datetime,
		T_ID  nvarchar(50),
		P_ID  nvarchar(20),
		primary key (TD_ID)
	)
	go

	/* DROP TABLE WH_Transaction_Details*/

	create table Report
	(
		R_ID  nvarchar(50),
		R_Name nvarchar(50),
		Descriptions nvarchar(50),
		StartDate datetime,
		EndDate datetime,
		B_ID  nvarchar(50),
		Wh_ID nvarchar(50),
		primary key (R_ID)
	)
	go

	create table Calculation_Unit
	(
		Un_ID  nvarchar(20),
		Un_Name  nvarchar(20),
		primary key (Un_ID)
	)
	go

	create table Origin
	(
		O_ID  nvarchar(20),
		O_Name  nvarchar(20),
		primary key (O_ID)
	)
	go

	create table Suppliers
	(
		Supp_ID  nvarchar(20),
		Supp_Name  nvarchar(20),
		Supp_Address  nvarchar(20),
		Supp_Phone  nvarchar(20),
		Email nvarchar(20),
		primary key (Supp_ID)
	)
	go

	create table Products
	(
		P_ID  nvarchar(20),
		P_Name  nvarchar(20),
		Price float,
		Supp_ID  nvarchar(20),
		O_ID  nvarchar(20),
		Un_ID  nvarchar(20)
		primary key (P_ID)
	)
	go


	create table Roles
	(
		R_ID  nvarchar(20),
		R_Name  nvarchar(20),
		primary key (R_ID)
	)
	go

	create table Users
	(
		U_ID  nvarchar(50),
		U_Name  nvarchar(20),
		Addresss nvarchar(50),
		R_ID  nvarchar(20),
		Phone nvarchar(20),
		primary key (U_ID)
	)
	go

-- 3/ Tạo khoá ngoại
--Tạo khoá ngoại ở bảng Branch
	Alter table Branch
		add constraint FK1_WarehouseID
		foreign key (Wh_ID)
		references WareHouse(Wh_ID) 
		go

--Tạo khoá ngoại ở bảng WH_Transaction
	Alter table WH_Transaction
		add constraint FK2_WarehouseID_Trans
		foreign key (Wh_ID)
		references WareHouse(Wh_ID) 
		go

	Alter table WH_Transaction
		add constraint FK3_BranchID_Trans
		foreign key (B_ID)
		references Branch(B_ID) 
		go

--Tạo khoá ngoại ở bảng Report
	Alter table Report
		add constraint FK4_WarehouseID_Report
		foreign key (Wh_ID)
		references WareHouse(Wh_ID) 
		go
	Alter table Report
		add constraint FK5_BranchID_Report
		foreign key (B_ID)
		references Branch(B_ID) 
		go

--Tạo khoá ngoại ở bảng Users
	Alter table Users
		add constraint FK6_RolesID_User
		foreign key (R_ID)
		references Roles(R_ID) 
		go


--Tạo khoá ngoại ở bảng WH_Transaction_Details
	Alter table WH_Transaction_Details
		add constraint FK4_TransactionID_Trans_Details
		foreign key (T_ID)
		references WH_Transaction(T_ID) 
		go
	Alter table WH_Transaction_Details
		add constraint FK5_ProductID_Trans_Details
		foreign key (P_ID)
		references Products(P_ID) 
		go

--Tạo khoá ngoại ở bảng Products
	Alter table Products
		add constraint FK7_SuppID_Products
		foreign key (Supp_ID)
		references Suppliers(Supp_ID) 
		go
	Alter table Products
		add constraint FK8_OriginID_Products
		foreign key (O_ID)
		references Origin(O_ID) 
		go
	Alter table Products
		add constraint FK8_UnitID_Products
		foreign key (Un_ID)
		references Calculation_Unit(Un_ID) 
		go