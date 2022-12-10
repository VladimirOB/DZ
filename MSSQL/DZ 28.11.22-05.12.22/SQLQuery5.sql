--����������� ����������� �������� (���)
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

--����������� ����������� �������� (�)
select au_fname, au_lname, state 
from authors
where state = 'ca'
INTERSECT
select au_fname, au_lname, state 
from authors
where contract = 0

--��������� ����������� ��������. (��� ������ ����� CA)
select au_fname, au_lname, state 
from authors
EXCEPT
select au_fname, au_lname, state 
from authors
where state = 'CA'


--���������� � ����� ������� ����������� ��������. (��� ������ ����� CA)
select au_fname, au_lname, state 
into au_result
from authors
EXCEPT
select au_fname, au_lname, state 
from authors
where state = 'CA'


--_ - ���� ����� ������
--% - ����� ������ ����� �����
--^ - ��������� �������� � []

--����� �� ������� (�������� ��� �����, �������� ������� ���������� �� ����� 'N')
select * from titles
where title LIKE 'N%'

--����� �� ������� ( �������� ��� �����, � ��������� ������� ������ ����� '�' )
select * from titles
where title LIKE '_o%'

--����� �� ������� ( �������� ��� �����, �������� ������� ���������� �� ������� ����� )
select * from titles
where title LIKE '[aeuoiy]%'

--����� �� ������� ( �������� ��� �����, �������� ������� ������������� �� ����� ����� )
select * from titles
where title LIKE '%[a-z]'

--����� �� ������� ( �������� ��� �����, �������� ������� ���������� �� �� ������� ����� )
select * from titles
where title LIKE '[^aeuoiy]%'

-- ����������� ����� � ������
--cast() convert()

--�������� ��� ����� � �������� ������� ����������� ���� �� ���� �� ��������(?!-,)
select * from titles
where title LIKE '%?%' or title LIKE '%!%' or title LIKE '%-%' or title LIKE '%,%'

select * from titles
where title LIKE '%[?!,-]%'

--�������� �������������
create view v1
as
select * from authors
where state = 'CA'

--��������� ������������� �������������
alter view v1
as
select * from authors
where state = 'UT'

--������� ������� ����������� ������� ����� ������������� 
update v1
set contract = 0

select * from v1
--�������� �������������
drop view v1

use pubs

--1) �������� �����, � �������� ������� ����������� �����
select * from titles
where title NOT LIKE '%[0-9]%'

--2) �������� ����� ��� ������� ������ ���� (�� NULL)
select * from titles
where price is not null

--3) �������� �������, ������� ����� � ����� 'CA' � �������� �� ��������� (INTERSECT)
select * 
from authors
where state = 'ca'
INTERSECT
select *
from authors
where contract = 1

--4) ������������� ���������� ����� � ����� 'business', � �������� ������� ����������� ������ �����
create view v2
as
select * from titles
where type = 'business'
INTERSECT
select * from titles
where title NOT LIKE '%[0-9!@#$%^&*()_-,.\|?/]%'

select * from v2
drop view v2

--5) ������������� ���������� �������� �����, � ������� �������� ������ ����� ���� � ����� ������ $15
create view v3
as
select top 1 type from titles
where price >= 15
group by type
order by count(*) desc

select * from v3


SELECT CAST(1 AS FLOAT)/2 FROM titles