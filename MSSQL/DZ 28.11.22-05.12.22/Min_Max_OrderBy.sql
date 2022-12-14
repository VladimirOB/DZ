select * from jobs
select min_lvl, max_lvl from jobs

select * from authors
select * from titles
select au_fname, phone, state, contract from authors
where state in ('CA', 'KS') and contract = 0

select au_fname, phone, state, contract from authors
where state != 'IN' or contract = 0

select title, type, pubdate, price
from titles
where price >= 10 and price <= 20

select title, type, pubdate, price
from titles
where price between 10 and 20

select * from authors
order by state desc

select * from authors
order by state

select * from authors
order by contract desc, state, au_fname


select * from titles
select count(*) as 'Count' from titles

select * from titles
select count(price) as 'Count' from titles

select * from titles
select count(*) as 'Count', sum(price) from titles
select count(*) as 'Count', avg(price) 'Average' from titles

select count(*) as 'Count', sum(price) 'Sum', avg(price) 'Average', min(price) as 'Min price', max(price) 'Max price' from titles
