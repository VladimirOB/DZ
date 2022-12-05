-- �������� ������ 5 �������
select top 5 * from authors

-- �������� ������ 5% �������
select top 5 percent * from authors

-- �������� ���� ����� ������� �����
select top 1 * from titles
order by price desc

-- distinct - ������ ������������� ���������� ��������
select distinct state from authors

-- ������������� ����� �� �����, ���� ������� ������ $10
-- �������� ������ ������, � ������� ������ 2 ����
-- ������������� �� ����������� ���� � ������� ��������
-- where - ��� ������ ������� �� �����������
-- having - ��� ������ ����� ����� �����������
select type, count(*) kolvo, min(price) min, max(price) max, avg(price) avg 
from titles
where price is not null
group by type
having count(*) > 2
order by min(price) desc

-- �������� ����� �����
select len('Hello')

-- �������� ����� � �� �����
select au_fname, len(au_fname) from authors

-- �������� ����� ������ ����� � ������
select au_fname, left(au_fname, 2), right(au_fname, 1) from authors

-- �������� ����� ������
select au_fname, substring(au_fname, 2, 3) [����� ������] from authors

-- ������ ����� ������ �� ������ ������
select au_fname, replace(au_fname, 'a', '!') from authors

-- ��������� ������
select au_fname, reverse(au_fname) from authors

select * from titles

-- ��������� ���� ���� ���� � ����� business �� $2
update titles
set price = price + 2
where type = 'business'

