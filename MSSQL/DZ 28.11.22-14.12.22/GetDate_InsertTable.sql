--получить текущие дату и врем€
select getdate()

--получить текущий год
select year(getdate())

--получить текущий мес€ц
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

--увеличить текущую дату на 2 дн€ назад
select dateadd(dd, -2, getdate())

--конвертаци€ строки в getdate(datetime)
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

