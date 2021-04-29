--1) Print the city name and the count of authors from every city

select city,count(au_id) from authors where au_id=au_id
group by city


--2) Print the authors who are not from the city in which the publisher 'New Moon Books' is from.

select au_fname,au_lname from authors a join titleauthor ta on a.au_id=ta.au_id join titles t 
on t.title_id=ta.title_id join publishers p on p.pub_id=t.pub_id
where a.city!= (select city from publishers where pub_name='New Moon Books')


--3) Create a procudure that will take the author first name and last name and new price 
--The procedure should update teh price of the books written by the author with the give name 

create proc proc_UpdatePrice
(@fname varchar(30),@lname varchar(30) , @newPrice money)
as
begin
	update titles
	set titles.price = @newPrice
	where title_id in ( select title_id from titleauthor where au_id in (select au_id from 
	authors where au_fname=@fname and au_lname=@lname))
	
end

exec proc_UpdatePrice 'Marjorie','Green',40


--4) Create a function that will calculate tax for the sale of every book
--If quantity <10 tax is 2%
--10 -20 tax is 5%
--20 - 50 tax is 6%
--above 30 tax is 7.5%
--The fuction should take quantity and return tax
create function fn_Tax(@quantity int)
 returns float
 as
 begin
	declare
	@tax float, @taxAmount float
	
	if(@quantity<10)
		set @tax=2
	else if(@quantity>=10 and @quantity<=20)
		set @tax=5
	else if(@quantity>20 and @quantity<=30)
		set @tax=6
	else 
		set @tax=7.5
	set @taxAmount = ((@tax/100)*(select price from titles where title_id in
					(select title_id from sales where qty=@quantity))*@quantity)
	return @taxAmount
 end
 drop function fn_Tax
select dbo.fn_Tax(50) 'Tax'
