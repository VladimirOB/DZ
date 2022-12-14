use pubs

select * from titles
select * from publishers

select * from stores
select * from sales

select * from titleauthor
select * from authors

--���������� ������������ ( ������ � ������ )
select title, type, pubdate, pub_name, state, city, publishers.pub_id 
from titles, publishers

-- ���������� �����
select title, type, pubdate, pub_name, state, city, publishers.pub_id 
from titles, publishers
where publishers.pub_id = titles.pub_id

--�������� ������� ���� � ������ ������� (��������� "������ �� ������")
select title, stor_name, ord_date, qty
from titles, stores, sales
where sales.title_id = titles.title_id
and stores.stor_id = sales.stor_id

--�������� ���� ������� � �� ����� � ����� �������
select au_fname, au_lname, state, title, price, type
from authors, titles, titleauthor
where titles.title_id = titleauthor.title_id
and authors.au_id = titleauthor.au_id
and type = 'business'

-- ����� ���� � 5 ������ � �������

--1)�������� ����� ������� �� �����(��)
select title, type, state, price
from authors, titles, titleauthor
where titles.title_id = titleauthor.title_id
and authors.au_id = titleauthor.au_id
and state = 'CA'


--2)�������� ��������, ������� ������� ����� � ����� 'business' � ����� �� 15$ �� 25$
select stor_name, title, type, price, ord_date, qty
from titles, stores, sales
where sales.title_id = titles.title_id
and stores.stor_id = sales.stor_id
and type = 'business'
and price between 15 and 25


--3)�������� �������, ������� �� ������ ����� ------
select au_id, au_fname, au_lname
from authors
EXCEPT
select authors.au_id, au_fname, au_lname
from titles, authors, titleauthor
where titles.title_id = titleauthor.title_id
and authors.au_id = titleauthor.au_id


--4)�������� ��������, ������� ������� ����� ������� �� ������(��, UT, IN)
select distinct stor_name
from titles, stores, sales, authors, titleauthor 
where sales.title_id = titles.title_id
and stores.stor_id = sales.stor_id
and titleauthor.au_id = authors.au_id
and titleauthor.title_id = titles.title_id
and authors.state in ('CA', 'UT', 'IN')

--5)�������� ������� ���� ���� � ����� business �������, ���������� �� ���������
select avg(price)
from authors, titles, titleauthor
where titles.title_id = titleauthor.title_id
and authors.au_id = titleauthor.au_id
and type = 'business'
and contract = 1