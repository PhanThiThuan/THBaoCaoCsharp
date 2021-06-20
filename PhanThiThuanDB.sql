Create database PhanThiThuanDB
use PhanThiThuanDB
go
create table UserAccount(
	ID bigint IDENTITY(1,1) primary key,
	UserName varchar(50) null,
	Password varchar(32) null,
	Status nvarchar(30) null
)
go
create table Category(
	ID bigint IDENTITY(1,1) primary key,
	Name nvarchar(100) null,
	Description nvarchar(255) null
)go
create table Product(
	ID bigint IDENTITY(1,1) primary key,
	Name nvarchar(250) null,
	UnitCost decimal(18,0) null,
	Quantity int null,
	Image nvarchar(250) null,
	Description nvarchar(255) null,
	Status nvarchar(30) null,
	ProductType bigint null,
	constraint fk_Product_Category foreign key (ProductType) references Category(ID)
)
