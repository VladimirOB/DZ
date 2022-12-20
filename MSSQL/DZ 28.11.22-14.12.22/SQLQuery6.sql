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
