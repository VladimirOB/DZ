use pubs

select * from titles
select * from publishers

select * from stores
select * from sales

select * from titleauthor
select * from authors

--декартовое произведение ( каждый с каждым )
select title, type, pubdate, pub_name, state, city, publishers.pub_id 
from titles, publishers

-- правильный поиск
select title, type, pubdate, pub_name, state, city, publishers.pub_id 
from titles, publishers
where publishers.pub_id = titles.pub_id

--показать продажи книг в разных магазах (связанные "многие ко многим")
select title, stor_name, ord_date, qty
from titles, stores, sales
where sales.title_id = titles.title_id
and stores.stor_id = sales.stor_id

--Показать всех авторов и их книги в жанре бизнесс
select au_fname, au_lname, state, title, price, type
from authors, titles, titleauthor
where titles.title_id = titleauthor.title_id
and authors.au_id = titleauthor.au_id
and type = 'business'

-- может быть и 5 таблиц в запросе

--1)Показать книги авторов из штата(СА)
select title, type, state, price
from authors, titles, titleauthor
where titles.title_id = titleauthor.title_id
and authors.au_id = titleauthor.au_id
and state = 'CA'


--2)Показать магазины, которые продают книги в жанре 'business' с ценой от 15$ до 25$
select stor_name, title, type, price, ord_date, qty
from titles, stores, sales
where sales.title_id = titles.title_id
and stores.stor_id = sales.stor_id
and type = 'business'
and price between 15 and 25


--3)Показать авторов, которые не издают книги ------
select au_id, au_fname, au_lname
from authors
EXCEPT
select authors.au_id, au_fname, au_lname
from titles, authors, titleauthor
where titles.title_id = titleauthor.title_id
and authors.au_id = titleauthor.au_id


--4)Показать магазины, которые продают книги авторов из штатов(СА, UT, IN)
select distinct stor_name
from titles, stores, sales, authors, titleauthor 
where sales.title_id = titles.title_id
and stores.stor_id = sales.stor_id
and titleauthor.au_id = authors.au_id
and titleauthor.title_id = titles.title_id
and authors.state in ('CA', 'UT', 'IN')

--5)Показать среднюю цену книг в жанре business авторов, работающих по контракту
select avg(price)
from authors, titles, titleauthor
where titles.title_id = titleauthor.title_id
and authors.au_id = titleauthor.au_id
and type = 'business'
and contract = 1