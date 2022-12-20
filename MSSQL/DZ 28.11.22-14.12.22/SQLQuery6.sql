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
