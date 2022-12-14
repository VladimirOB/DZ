create database Auto
go
use Auto

create table Cars(id int identity primary key, Brand varchar(20), Model varchar(20), MaxSpeed int, HP int, Price int)

select * from Cars

insert into Cars (Brand, Model, MaxSpeed, HP, Price)
values
('BMW', 'M3', 250, 300, 10000),
('AUDI', 'Q7', 210, 200, 12000)

delete from Cars 
where id = 2

drop table Cars

drop database Cars
