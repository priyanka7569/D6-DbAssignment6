create database ProductInventoryDb
use ProductInventoryDb
create table Product
(ProductId int primary key,
ProductName nvarchar(50),
Price float,
Quantity int,
MfDate date,
ExpDate date,
)

insert into Product values(10,'Laptop',62000.50,2,'11/12/2023','10/12/2026')

select * from Product