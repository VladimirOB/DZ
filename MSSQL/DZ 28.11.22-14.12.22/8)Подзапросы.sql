use pubs

--показать книги с максимальной ценой
select * from titles
where price = (select max(price) from titles)

--показать книги которые стоят дороже средней цены
select * from titles
where price >= (select avg(price) from titles)

--показать книги издательства 'New Moon Books'
select title, type, price, pub_name
from publishers, titles
where titles.pub_id = publishers.pub_id
and pub_name = 'New Moon Books'

--показать книги издательства 'New Moon Books' v2
select * from titles where pub_id = 
(select pub_id from publishers where pub_name = 'New Moon Books')

--показать книги авторов из CA
select * from titles where title_id in
(select title_id from titleauthor where au_id in 
(select au_id from authors where state = 'CA'))

--показать автора самой дорогой книги
select * from authors 
where au_id in
(select au_id from titleauthor where title_id in
(select title_id from  titles where price =
(select max(price) from titles)))

--показать магазины которые продают книги в жанре бизн
select distinct stor_name
from titles, stores, sales
where stores.stor_id = sales.stor_id
and sales.title_id = titles.title_id
and type = 'business'
---
select stor_name from stores
where stor_id in
(select stor_id from sales where title_id in
(select title_id from titles where type = 'business'))

--Показать авторов книг, которые в названии содержат меньше 15 символов (len)
select * from authors
where au_id in
(select au_id from titleauthor where title_id in
(select title_id from titles where len(title) < 15))

--показать магазины, которые не продают книги авторов из СА
select * from stores
except
select * from stores
where stor_id in
(select stor_id from sales where title_id in
(select title_id from titleauthor where au_id in
(select au_id from authors where state = 'UT')))
---v2
select * from stores where stor_id in
(select stor_id from stores
except
(select stor_id from sales where title_id in
(select title_id from titleauthor where au_id in
(select au_id from authors where state = 'UT'))))
