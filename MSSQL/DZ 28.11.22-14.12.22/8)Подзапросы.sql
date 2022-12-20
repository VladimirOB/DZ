use pubs

--�������� ����� � ������������ �����
select * from titles
where price = (select max(price) from titles)

--�������� ����� ������� ����� ������ ������� ����
select * from titles
where price >= (select avg(price) from titles)

--�������� ����� ������������ 'New Moon Books'
select title, type, price, pub_name
from publishers, titles
where titles.pub_id = publishers.pub_id
and pub_name = 'New Moon Books'

--�������� ����� ������������ 'New Moon Books' v2
select * from titles where pub_id = 
(select pub_id from publishers where pub_name = 'New Moon Books')

--�������� ����� ������� �� CA
select * from titles where title_id in
(select title_id from titleauthor where au_id in 
(select au_id from authors where state = 'CA'))

--�������� ������ ����� ������� �����
select * from authors 
where au_id in
(select au_id from titleauthor where title_id in
(select title_id from  titles where price =
(select max(price) from titles)))

--�������� �������� ������� ������� ����� � ����� ����
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

--�������� ������� ����, ������� � �������� �������� ������ 15 �������� (len)
select * from authors
where au_id in
(select au_id from titleauthor where title_id in
(select title_id from titles where len(title) < 15))

--�������� ��������, ������� �� ������� ����� ������� �� ��
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
