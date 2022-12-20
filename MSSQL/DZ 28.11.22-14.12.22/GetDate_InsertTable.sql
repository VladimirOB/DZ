--�������� ������� ���� � �����
select getdate()

--�������� ������� ���
select year(getdate())

--�������� ������� �����
select month(getdate())

--�������� ������� ����
select day(getdate())

--�������� ������� ����
select datepart(dd, getdate())

--�������� ������� ���
select datepart(hh, getdate())

--�������� ������� ������ � �������
select datepart(mi, getdate()) 'Min', datepart(ss, getdate()) 'Sec'

--�������� ���-�� ����� ����� ������
select DATEDIFF (mi, '2011-12-23', getdate())

--��������� ������� ���� �� 2 ��� �����
select dateadd(dd, -2, getdate())

--����������� ������ � getdate(datetime)
select month('2020-11-24')

--����� �������� ����
select title, pubdate, year(pubdate) from titles

--����� �������� ���� � ��������� 11 ��� ��������
select title, pubdate, year(pubdate), dateadd(yy, 11, pubdate) from titles

--�� ���� ����� ���������� ���� ��������� 2 ����
update titles
set pubdate = dateadd(yy, 2, pubdate);

--���������� ����������� � ����� ��������� �������
select title, pubdate, year(pubdate) year, dateadd(yy, 2, pubdate) year2
into my_result
from titles

select * from my_result

drop table my_result

--���������� ����������� � ��������� �������
select au_fname, au_lname, state, city into au_results from authors
where state = 'ca'

--�������� ������ � ������������ ������� �� ����������� �������
insert into au_results
select au_fname, au_lname, state, city from authors
where state = 'UT'

--���������� ������� � �������
alter table au_results
add address varchar(20)

update au_results
set address = '12'

-- ����� ���� ������������� �������(�������� ���� ��� ��������)
alter table au_results
alter column address int

--�������� ������������� �������
alter table au_results
drop column address

select * from au_results

drop table au_results

