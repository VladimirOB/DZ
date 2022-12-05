-- показать первые 5 записей
select top 5 * from authors

-- показать первые 5% записей
select top 5 percent * from authors

-- показать одну самую дорогую книгу
select top 1 * from titles
order by price desc

-- distinct - убрать повторяющиеся результаты запросов
select distinct state from authors

-- сгруппировать книги по жанру, цена которых больше $10
-- показать только группы, в которых больше 2 книг
-- отсортировать по минимальной цене в порядке убывания
-- where - это фильтр записей до группировки
-- having - это фильтр групп после группировки
select type, count(*) kolvo, min(price) min, max(price) max, avg(price) avg 
from titles
where price is not null
group by type
having count(*) > 2
order by min(price) desc

-- показать длина слова
select len('Hello')

-- показать имена и их длины
select au_fname, len(au_fname) from authors

-- получить часть строки слева и справа
select au_fname, left(au_fname, 2), right(au_fname, 1) from authors

-- получить часть строки
select au_fname, substring(au_fname, 2, 3) [часть строки] from authors

-- замена части строки на другую строку
select au_fname, replace(au_fname, 'a', '!') from authors

-- переворот строки
select au_fname, reverse(au_fname) from authors

select * from titles

-- увеличить цену всех книг в жанре business на $2
update titles
set price = price + 2
where type = 'business'

