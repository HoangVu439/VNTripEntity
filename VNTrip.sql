create database VNTrip
go

use VNTrip
go

 --\\Khach hang
create table Customer
(
	 ID int identity(1,1) not null primary key,
	 Email varchar(50) not null,
	 Password varchar(16) not null,
	 Name nvarchar(100),
	 Gender nvarchar(4),
	 Address nvarchar(100),
	 Phone_Number int,
	 Note nvarchar(200),
	 Status varchar(6),
	 created_at datetime,
	 updated_at datetime
)

--Hoa don
create table Bills
(
	ID int identity(1,1) not null primary key,
	ID_Customer int,
	constraint fk_cus_bill foreign key (ID_Customer) references Customer(ID),
	Date_order datetime,
	Phone_Number int,
	Email varchar(50) not null,
	created_at datetime,
	updated_at datetime
)

--Khu vuc khach san/nn
create table Khuvuc
(
	ID int identity(1,1) not null primary key,
	Name nvarchar(30),
	Description nvarchar(300),
	Image nvarchar(200)
)

--Khach san
create table KhachSan
(
	ID int identity(1,1) not null primary key,
	Name nvarchar(50),
	ID_Khuvuc int,
	Group_Pro nvarchar(50),
	Address nvarchar(100),
	Phone_Number int,
	Description nvarchar(4000),
	Utilities nvarchar(500),
	Thongtin nvarchar(200),
	Checkin nvarchar(20),
	Checkout nvarchar(20),
	Image nvarchar(100),
	constraint fk_br_pro foreign key (ID_Khuvuc) references Khuvuc(ID),
	created_at datetime,
	updated_at datetime
)

--Loai phong khach san
create table LoaiPhongKS
(
	ID int identity(1,1) not null primary key,
	Name nvarchar(50),
	ID_KhachSan int,
	TenLoaiPhong nvarchar(50),
	SucChua nvarchar(20),
	BuaAn nvarchar(20),
	Description nvarchar(1000),
	Utilities nvarchar(500),
	Image nvarchar(100),
	constraint fk_br_ks foreign key (ID_KhachSan) references KhachSan(ID),
	Price money,
	Promotion_Price money,
	created_at datetime,
	updated_at datetime
)

create table AnhLoaiPhongKS
(
	ID int identity(1,1) not null primary key,
	ID_LoaiPhongKS int,
	TenLoaiPhong nvarchar(50),
	Image1 nvarchar(100),
	Image2 nvarchar(100),
	Image3 nvarchar(100),
	Image4 nvarchar(100),
	Image5 nvarchar(100),
	constraint fk_br_kss foreign key (ID_LoaiPhongKS) references LoaiPhongKS(ID)
)

--Ve may bay
create table VeMayBay
(
	ID int identity(1,1) not null primary key,
	Name nvarchar(50),
	ID_Khuvuc int,
	Group_Pro nvarchar(50),
	Tenhang nvarchar(50),
	Diemdi nvarchar(30),
	Diemden nvarchar(30),
	Ngaydi datetime,
	Ngayve datetime,
	Price money,
	Image nvarchar(100),
	Description nvarchar(200),
	constraint fk_br_pru foreign key (ID_Khuvuc) references Khuvuc(ID)
)

--Nha Nghi
create table NhaNghi
(
	ID int identity(1,1) not null primary key,
	Name nvarchar(50),
	ID_Khuvuc int,
	Group_Pro nvarchar(50),
	Description nvarchar(500),
	Address nvarchar(100),
	Phone_Number int,
	constraint fk_br_pre foreign key (ID_Khuvuc) references Khuvuc(ID),
	Image nvarchar(100),
	created_at datetime,
	updated_at datetime
)

--Loai phong nha nghi
create table LoaiPhongNN
(
	ID int identity(1,1) not null primary key,
	Name nvarchar(50),
	ID_NhaNghi int,
	TenLoaiPhong nvarchar(50),
	Description nvarchar(500),
	Price2h money,
	PriceNight money,
	Image nvarchar(100),
	constraint fk_br_nn foreign key (ID_NhaNghi) references NhaNghi(ID),
	created_at datetime,
	updated_at datetime
)

create table AnhLoaiPhongNN
(
	ID int identity(1,1) not null primary key,
	ID_LoaiPhongNN int,
	TenLoaiPhong nvarchar(50),
	Image1 nvarchar(100),
	Image2 nvarchar(100),
	Image3 nvarchar(100),
	Image4 nvarchar(100),
	Image5 nvarchar(100),
	constraint fk_br_nnn foreign key (ID_LoaiPhongNN) references LoaiPhongNN(ID)
)
--Chi tiet hoa Don
create table Bill_Detail
(
	ID int identity(1,1) not null primary key,
	ID_Bill int,
	ID_LoaiPhongKS int,
	ID_VeMayBay int,
	ID_LoaiPhongNN int,
	constraint fk_Bill_BD foreign key (ID_Bill) references Bills(ID),	
	constraint fk_Pro_ks foreign key (ID_LoaiPhongKS) references LoaiPhongKS(ID),
	constraint fk_Pro_vmb foreign key (ID_VeMayBay) references VeMayBay(ID),
	constraint fk_Pro_nn foreign key (ID_LoaiPhongNN) references LoaiPhongNN(ID),
	Quantity int,
	created_at datetime,
	updated_at datetime
)

--Admin
create table Admin
(
	ID int identity(1,1) not null primary key,
	Email varchar(50),
	Password varchar(16),
	created_at datetime,
	updated_at datetime
)

--Tin tuc
create table News
(
	ID int identity(1,1) not null primary key,
	Title nvarchar(300),
	Content ntext,
	Image nvarchar(200)
)

--Hinh anh tin tuc
create table New_Image
(
	ID int identity(1,1) not null primary key,
	ID_New int,
	constraint fk_img_new foreign key (ID_New) references News(ID),
	Image nvarchar(200)
)

--Gio hang
create table Cart
(
	ID int identity(1,1) not null primary key,
	ID_Customer int,
	ID_LoaiPhongKS int,
	ID_VeMayBay int,
	ID_LoaiPhongNN int,
	Quantity_Purchased int,
	constraint fk_Cus_c foreign key (ID_Customer) references Customer(ID),
	constraint fk_Pro_kss foreign key (ID_LoaiPhongKS) references LoaiPhongKS(ID),
	constraint fk_Pro_vmbb foreign key (ID_VeMayBay) references VeMayBay(ID),
	constraint fk_Pro_nnn foreign key (ID_LoaiPhongNN) references LoaiPhongNN(ID),
	created_at datetime,
	updated_at datetime
)
