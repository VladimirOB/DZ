--получить текущие дату и время
select getdate()

--получить текущий год
select year(getdate())

--получить текущий месяц
select month(getdate())

--получить текущий день
select day(getdate())

--получить текущий день
select datepart(dd, getdate())

--получить текущий час
select datepart(hh, getdate())

--получить текущую минуту и секунду
select datepart(mi, getdate()) 'Min', datepart(ss, getdate()) 'Sec'

--получить кол-во минут между датами
select DATEDIFF (mi, '2011-12-23', getdate())

--увеличить текущую дату на 2 дня назад
select dateadd(dd, -2, getdate())

--конвертация строки в getdate(datetime)
select month('2020-11-24')

--выбор отдельно года
select title, pubdate, year(pubdate) from titles

--выбор отдельно года и прибавили 11 лет отдельно
select title, pubdate, year(pubdate), dateadd(yy, 11, pubdate) from titles

--ко всем датам публикации книг прибавить 2 года
update titles
set pubdate = dateadd(yy, 2, pubdate);

--сохранение результатов в новой отдельной таблице
select title, pubdate, year(pubdate) year, dateadd(yy, 2, pubdate) year2
into my_result
from titles

select * from my_result

drop table my_result

--сохранение результатов в отдельной таблице
select au_fname, au_lname, state, city into au_results from authors
where state = 'ca'

--вставить записи в существующую таблицу из результатов запроса
insert into au_results
select au_fname, au_lname, state, city from authors
where state = 'UT'

--добавление столбца в таблицу
alter table au_results
add address varchar(20)

update au_results
set address = '12'

-- смена типа существующего столбца(работает если тип подходит)
alter table au_results
alter column address int

--удаление существующего столбца
alter table au_results
drop column address

select * from au_results

drop table au_results


--1) Показать год публикации самой дорогой книги
select top 1 year(pubdate) from titles
--where price is not null
order by price desc

--2) Показать сколько лет прошло между публикациями самой ранней и самой поздней книги
--select min(pubdate) min, max(pubdate) max from titles
select DATEDIFF(yy, min(pubdate), max(pubdate)) from titles

--3) Увеличить даты публикаций книг в жанре 'business' на 2 месяца
--select * from titles
update titles
set pubdate = dateadd(mm, 2, pubdate)
where type = 'business'

--4) Скопировать авторов, живущих в штате 'CA' и работающих по контракту в отдельную таблицу
select * from authors

select * 
into my_res
from authors
where state = 'CA' and contract = 1;

select * from my_res
drop table my_res

--5) Добавить в эту таблицу авторов, живущих в штате 'KS'
insert into my_res
select * from authors
where state = 'KS'

