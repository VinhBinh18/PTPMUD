-- 1/ Tạo DB + Sử dụng DB
	Create Database WarehouseManagement
	Go
	Use WarehouseManagement
	Go

-- 2/ Tạo các table + Khoá chính	
	create table WareHouse
	(
		WarehouseID nvarchar(50),
		WarehouseName nvarchar(50),
		WarehouseAddress nvarchar(50),
		Phone nvarchar(20),
		primary key (WarehouseID)
	)
	go

	create table Branch
	(
		BranchID  nvarchar(50),
		BranchName nvarchar(50),
		BranchAddress nvarchar(50),
		Phone nvarchar(20),
		WarehouseID nvarchar(50),
		primary key (BranchID)
	)
	go

	create table WH_Transaction
	(
		TransactionID  nvarchar(50),
		TransactionNumber nvarchar(50),
		TotalNumber float,
		TotalAmount float,
		Note nvarchar(50),
		EntryDate datetime,
		ExportDate datetime,
		TransactionType nvarchar(20),
		TransactionStatus bit,
		BranchID  nvarchar(50),
		WarehouseID nvarchar(50),
		primary key (TransactionID)
	)
	go


	create table WH_Transaction_Details
	(
		TransDetailsID  nvarchar(50),
		Quantity float,
		UnitPrice float,
		TotalPrice float,
		Dates datetime,
		TransactionID  nvarchar(50),
		ProductID  nvarchar(20),
		primary key (TransDetailsID)
	)
	go

	/* DROP TABLE WH_Transaction_Details*/

	create table Report
	(
		ReportID  nvarchar(50),
		ReportName nvarchar(50),
		Descriptions nvarchar(50),
		StartDate datetime,
		EndDate datetime,
		BranchID  nvarchar(50),
		WarehouseID nvarchar(50),
		primary key (ReportID)
	)
	go

	create table Calculation_Unit
	(
		UnitID  nvarchar(20),
		UnitName  nvarchar(20),
		primary key (UnitID)
	)
	go

	create table Origin
	(
		OriginID  nvarchar(20),
		OriginName  nvarchar(20),
		primary key (OriginID)
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
		ProductID  nvarchar(20),
		ProductName  nvarchar(20),
		Price float,
		Supp_ID  nvarchar(20),
		OriginID  nvarchar(20),
		UnitID  nvarchar(20)
		primary key (ProductID)
	)
	go


	create table Roles
	(
		RolesID  nvarchar(20),
		RolesName  nvarchar(20),
		primary key (RolesID)
	)
	go

	create table Users
	(
		UserID  nvarchar(50),
		UserName  nvarchar(20),
		Addresss nvarchar(50),
		RolesID  nvarchar(20),
		Phone nvarchar(20),
		primary key (UserID)
	)
	go

-- 3/ Tạo khoá ngoại
--Tạo khoá ngoại ở bảng Branch
	Alter table Branch
		add constraint FK1_WarehouseID
		foreign key (WarehouseID)
		references WareHouse(WarehouseID) 
		go

--Tạo khoá ngoại ở bảng WH_Transaction
	Alter table WH_Transaction
		add constraint FK2_WarehouseID_Trans
		foreign key (WarehouseID)
		references WareHouse(WarehouseID) 
		go

	Alter table WH_Transaction
		add constraint FK3_BranchID_Trans
		foreign key (BranchID)
		references Branch(BranchID) 
		go

--Tạo khoá ngoại ở bảng Report
	Alter table Report
		add constraint FK4_WarehouseID_Report
		foreign key (WarehouseID)
		references WareHouse(WarehouseID) 
		go
	Alter table Report
		add constraint FK5_BranchID_Report
		foreign key (BranchID)
		references Branch(BranchID) 
		go

--Tạo khoá ngoại ở bảng Users
	Alter table Users
		add constraint FK6_RolesID_User
		foreign key (RolesID)
		references Roles(RolesID) 
		go


--Tạo khoá ngoại ở bảng WH_Transaction_Details
	Alter table WH_Transaction_Details
		add constraint FK4_TransactionID_Trans_Details
		foreign key (TransactionID)
		references WH_Transaction(TransactionID) 
		go
	Alter table WH_Transaction_Details
		add constraint FK5_ProductID_Trans_Details
		foreign key (ProductID)
		references Products(ProductID) 
		go

--Tạo khoá ngoại ở bảng Products
	Alter table Products
		add constraint FK7_SuppID_Products
		foreign key (Supp_ID)
		references Suppliers(Supp_ID) 
		go
	Alter table Products
		add constraint FK8_OriginID_Products
		foreign key (OriginID)
		references Origin(OriginID) 
		go
	Alter table Products
		add constraint FK8_UnitID_Products
		foreign key (UnitID)
		references Calculation_Unit(UnitID) 
		go