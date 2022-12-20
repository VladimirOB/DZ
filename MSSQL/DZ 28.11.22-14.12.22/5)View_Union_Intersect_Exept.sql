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

SELECT CAST(1 AS FLOAT)/2 FROM titles

insert into publishers (pub_id, pub_name,city,state,country)
values('9955','Sun & Rain','London', Null,'UK ')