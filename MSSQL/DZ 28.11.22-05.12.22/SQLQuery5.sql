--Объединение результатов запросов (или)
select au_fname, au_lname, state 
from authors
where state = 'ca'
UNION
select au_fname, au_lname, state 
from authors
where state = 'UT'
UNION
select title, type, notes
from titles
where type = 'mod_cook'

select au_fname, au_lname, state 
from authors
where state in('CA', 'UT')

--пересечение результатов запросов (и)
select au_fname, au_lname, state 
from authors
where state = 'ca'
INTERSECT
select au_fname, au_lname, state 
from authors
where contract = 0

--вычитание результатов запросов. (все авторы кроме CA)
select au_fname, au_lname, state 
from authors
EXCEPT
select au_fname, au_lname, state 
from authors
where state = 'CA'


--добавление в новую таблицу результатов запросов. (все авторы кроме CA)
select au_fname, au_lname, state 
into au_result
from authors
EXCEPT
select au_fname, au_lname, state 
from authors
where state = 'CA'


--_ - один любой символ
--% - любая строка любой длины
--^ - отрицание символов в []

--поиск по шаблону (показать все книги, названия которых начинаются на букву 'N')
select * from titles
where title LIKE 'N%'

--поиск по шаблону ( показать все книги, в названиях которых вторая буква 'О' )
select * from titles
where title LIKE '_o%'

--поиск по шаблону ( показать все книги, названия которых начинаются на гласную букву )
select * from titles
where title LIKE '[aeuoiy]%'

--поиск по шаблону ( показать все книги, названия которых закатчиваются на любую букву )
select * from titles
where title LIKE '%[a-z]'

--поиск по шаблону ( показать все книги, названия которых начинаются не на гласную букву )
select * from titles
where title LIKE '[^aeuoiy]%'

-- конвертация числа в строку
--cast() convert()

--показать все книги в названии которые встречается хотя бы один из символов(?!-,)
select * from titles
where title LIKE '%?%' or title LIKE '%!%' or title LIKE '%-%' or title LIKE '%,%'

select * from titles
where title LIKE '%[?!,-]%'

--создание представления
create view v1
as
select * from authors
where state = 'CA'

--изменение существующего представления
alter view v1
as
select * from authors
where state = 'UT'

--Удачная попытка модификации таблицы через представления 
update v1
set contract = 0

select * from v1
--удаление представления
drop view v1

use pubs

--1) показать книги, в названии которых отсутствуют цифры
select * from titles
where title NOT LIKE '%[0-9]%'

--2) показать книги для которых задана цена (не NULL)
select * from titles
where price is not null

--3) показать авторов, которые живут в штате 'CA' и работают по контракту (INTERSECT)
select * 
from authors
where state = 'ca'
INTERSECT
select *
from authors
where contract = 1

--4) представление показывает книги в жанре 'business', в названии которых встречаются только буквы
create view v2
as
select * from titles
where type = 'business'
INTERSECT
select * from titles
where title NOT LIKE '%[0-9!@#$%^&*()_-,.\|?/]%'

select * from v2
drop view v2

--5) представление показывает название жанра, в котором написано больше всего книг с ценой больше $15
create view v3
as
select top 1 type from titles
where price >= 15
group by type
order by count(*) desc

select * from v3


SELECT CAST(1 AS FLOAT)/2 FROM titles