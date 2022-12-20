create table people
(
id int,
id2 varchar(20),
name varchar(20),
address varchar(20),
age int,
primary key(id, id2)
)

insert into people (id, id2, name, address, age)
values
(1, 'ok', 'Alex', 'Donetsk', 23),
(1, 'qwe', 'Ivan', 'Moskow', 34)

select * from people