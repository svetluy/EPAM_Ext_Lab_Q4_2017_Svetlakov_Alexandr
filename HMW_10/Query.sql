-- 1.1
-- Выбрать в таблице Orders заказы, которые были доставлены после
-- 6 мая 1998 года (колонка ShippedDate) включительно и которые
-- доставлены с ShipVia >= 2. Формат указания даты должен быть
-- верным при любых региональных настройках, согласно требованиям
-- статьи “Writing International Transact-SQL Statements” в Books
-- Online раздел “Accessing and Changing Relational Data Overview”.
-- Этот метод использовать далее для всех заданий. Запрос должен
-- высвечивать только колонки OrderID, ShippedDate и ShipVia. 
-- Пояснить почему сюда не попали заказы с NULL-ом в колонке ShippedDate.

 --Сюда не попали заказы с NULL-ом в колонке ShippedDate,
 --потому что под выборку поподают только те записи, для которых выражение после where возвращает true
 select 
 OrderID, 
 ShippedDate, 
 ShipVia 
 from Northwind.Orders 
 where (ShippedDate >= { d'1996-05-06'} and ShipVia >= 2);

--1.2
-- Написать запрос, который выводит только недоставленные заказы из таблицы Orders.
-- В результатах запроса высвечивать для колонки ShippedDate вместо значений NULL
-- строку ‘Not Shipped’ – использовать системную функцию CASЕ. Запрос должен
--  высвечивать только колонки OrderID и ShippedDate.
select 
OrderID, 
ShippedDate =
case 
when ShippedDate is null then 'Not Shipped'
end
from Northwind.Orders 
where ShippedDate is null;

--1.3
-- Выбрать в таблице Orders заказы, которые были доставлены после 6 мая 1998 года (ShippedDate)
-- не включая эту дату или которые еще не доставлены. В запросе должны высвечиваться только
-- колонки OrderID (переименовать в Order Number) и ShippedDate (переименовать в Shipped Date).
-- В результатах запроса высвечивать для колонки ShippedDate вместо значений NULL строку ‘Not Shipped’,
-- для остальных значений высвечивать дату в формате по умолчанию.
select 
OrderID, 
ShippedDate = 
case 
when ShippedDate is null then 'Not Shipped'
else CONVERT(char, ShippedDate, 102)
end
from Northwind.Orders 
where (ShippedDate > { d'1996-05-06'} or ShippedDate is null);

--2.1
-- Выбрать из таблицы Customers всех заказчиков, проживающих в USA и Canada. Запрос сделать
-- с только помощью оператора IN. Высвечивать колонки с именем пользователя и названием 
-- страны в результатах запроса. Упорядочить результаты запроса по имени заказчиков и по месту
-- проживания.
select 
ContactName,
Country from Northwind.Customers 
where Country in ('USA','Canada') 
order by Country, ContactName;

--2.2
--Выбрать из таблицы Customers всех заказчиков, не проживающих в USA и Canada.
--Запрос сделать с помощью оператора IN. Высвечивать колонки с именем пользователя
--и названием страны в результатах запроса. Упорядочить результаты запроса по имени
--заказчиков.
select 
ContactName, 
Country from Northwind.Customers 
where Country not in ('USA','Canada') 
order by ContactName;

--2.3
 --Выбрать из таблицы Customers все страны, в которых проживают заказчики.
 --Страна должна быть упомянута только один раз и список отсортирован по убыванию.
 --Не использовать предложение GROUP BY. Высвечивать только одну колонку в результатах
 --запроса.
select distinct 
Country 
from Northwind.Customers;

--3.1
--Выбрать все заказы (OrderID) из таблицы Order Details (заказы не должны повторяться),
--где встречаются продукты с количеством от 3 до 10 включительно – это колонка Quantity
--в таблице Order Details. Использовать оператор BETWEEN. Запрос должен высвечивать 
--только колонку OrderID.
select distinct 
OrderID
from Northwind.[Order Details] 
where Quantity between 3 and 10;

--3.2
--Выбрать всех заказчиков из таблицы Customers, у которых название страны начинается на буквы
--из диапазона b и g. Использовать оператор BETWEEN. Проверить, что в результаты запроса попадает
--Germany. Запрос должен высвечивать только колонки CustomerID и Country и отсортирован по Country.
select 
CustomerID, 
Country 
from Northwind.Customers 
where Country between 'b' and 'h' 
order by Country;

--3.3
--Выбрать всех заказчиков из таблицы Customers, у которых название страны начинается на буквы из диапазона b и g,
--не используя оператор BETWEEN. С помощью опции “Execution Plan” определить какой запрос предпочтительнее 3.2 или 3.3
--для этого надо ввести в скрипт выполнение текстового Execution Plan-a для двух этих запросов, результаты выполнения
--Execution Plan надо ввести в скрипт в виде комментария и по их результатам дать ответ на вопрос – по какому параметру
--было проведено сравнение. Запрос должен высвечивать только колонки CustomerID и Country и отсортирован по Country.
select 
CustomerID, 
Country 
from Northwind.Customers 
where (Country > 'b' and Country < 'h') 
order by Country;

--4.1
--В таблице Products найти все продукты (колонка ProductName), где встречается подстрока 'chocolade'. 
--Известно, что в подстроке 'chocolade' может быть изменена одна буква 'c' в середине - найти все 
--продукты, которые удовлетворяют этому условию. Подсказка: результаты запроса должны высвечивать 2 строки.

select 
ProductName 
from Northwind.Products 
where ProductName like '%cho_olade%';

--5.1
--Найти общую сумму всех заказов из таблицы Order Details с учетом
--количества закупленных товаров и скидок по ним. Результат
--округлить до сотых и высветить в стиле 1 для типа данных money.
--Скидка (колонка Discount) составляет процент из стоимости для
--данного товара. Для определения действительной цены на
--проданный продукт надо вычесть скидку из указанной в колонке
--UnitPrice цены. Результатом запроса должна быть одна запись с
--одной колонкой с названием колонки 'Totals'.
select 
ROUND(SUM(UnitPrice * (1 - Discount) * Quantity), 2) as 'Totals'
from Northwind.[Order Details];

--5.2
--По таблице Orders найти количество заказов, которые еще не были
--доставлены (т.е. в колонке ShippedDate нет значения даты
--доставки). Использовать при этом запросе только оператор
--COUNT. Не использовать предложения WHERE и GROUP.

select 
Count(*) - Count(ShippedDate) 
from Northwind.Orders;

--5.3
--По таблице Orders найти количество различных покупателей
--(CustomerID), сделавших заказы. Использовать функцию COUNT и
--не использовать предложения WHERE и GROUP.

select 
Count(distinct CustomerID) 
from Northwind.Orders;

--6.1
--По таблице Orders найти количество заказов с группировкой по
--годам. В результатах запроса надо высвечивать две колонки c
--названиями Year и Total. Написать проверочный запрос, который
--вычисляет количество всех заказов.

select 
YEAR(OrderDate) as 'Year', 
COUNT(OrderID) as 'Total' 
from Northwind.Orders 
group by Year(OrderDate);

select COUNT(OrderID) 
from Northwind.Orders;

--6.2
-- По таблице Orders найти количество заказов, cделанных каждым
--продавцом. Заказ для указанного продавца – это любая запись в
--таблице Orders, где в колонке EmployeeID задано значение для
--данного продавца. В результатах запроса надо высвечивать
--колонку с именем продавца (Должно высвечиваться имя
--полученное конкатенацией LastName & FirstName. Эта строка
--LastName & FirstName должна быть получена отдельным запросом
--в колонке основного запроса. Также основной запрос должен
--использовать группировку по EmployeeID.) с названием колонки
--‘Seller’ и колонку c количеством заказов высвечивать с названием
--'Amount'. Результаты запроса должны быть упорядочены по
--убыванию количества заказов.

select --переписать на один select
LastName+' '+FirstName  as 'Seller', 
COUNT(OrderID) as 'Amount' 
FROM Northwind.Orders as ord inner join Northwind.Employees as emp on ord.EmployeeID = emp.EmployeeID
GROUP BY ord.EmployeeID, emp.LastName, emp.FirstName order by Amount desc; --переписал

--6.3 По таблице Orders найти количество заказов, cделанных каждым
--продавцом и для каждого покупателя. Необходимо определить это
--только для заказов сделанных в 1998 году. В результатах запроса
--надо высвечивать колонку с именем продавца (название колонки
--‘Seller’), колонку с именем покупателя (название колонки
--‘Customer’) и колонку c количеством заказов высвечивать с
--названием 'Amount'. В запросе необходимо использовать
--специальный оператор языка T-SQL для работы с выражением
--GROUP (Этот же оператор поможет выводить строку “ALL” в
--результатах запроса). Группировки должны быть сделаны по
--ID продавца и покупателя. Результаты запроса должны быть
--упорядочены по продавцу, покупателю и по убыванию количества
--продаж. В результатах должна быть сводная информация по
--продажам.



select --у тебя дублируется условие, так не должно быть. Посмотри в сторону case
'All' as 'Seller',--так и не придумал, как здесь case использовать
'All' as 'Custmer', 
COUNT(OrderID) as 'Amount' 
from Northwind.Orders 
where YEAR(OrderDate) = 1998 
union
select
LastName+' '+FirstName  as 'Seller', 
'All' as 'Custmer',
 COUNT(OrderID) as 'Amount'
FROM Northwind.Orders as ord inner join Northwind.Employees as emp on ord.EmployeeID = emp.EmployeeID
where YEAR(ord.OrderDate) = 1998 
GROUP BY ord.EmployeeID, emp.LastName, emp.FirstName 
union
select
'All' as 'Seller', 
ContactName as 'Custmer', 
COUNT(OrderID) as 'Amount'
FROM Northwind.Orders as ord inner join Northwind.Customers as cus on ord.CustomerID = cus.CustomerID
where YEAR(ord.OrderDate) = 1998 
GROUP BY ord.EmployeeID, ContactName 
union
select  
LastName+' '+FirstName as 'Seller', 
ContactName as 'Custmer', 
COUNT(ord.OrderID) as 'Amount'
from Northwind.Orders as ord inner join Northwind.Customers as cus on ord.CustomerID = cus.CustomerID 
inner join Northwind.Employees as emp on ord.EmployeeID = emp.EmployeeID
where YEAR(ord.OrderDate) = 1998 
group by emp.EmployeeID, ord.CustomerID, emp.LastName, emp.FirstName , cus.ContactName 
order by Amount desc;


--6.4 
--Найти покупателей и продавцов, которые живут в одном городе.
--Если в городе живут только один или несколько продавцов или
--только один или несколько покупателей, то информация о таких
--покупателя и продавцах не должна попадать в результирующий
--набор. Не использовать конструкцию JOIN. В результатах запроса
--необходимо вывести следующие заголовки для результатов
--запроса: ‘Person’, ‘Type’ (здесь надо выводить строку ‘Customer’
--или ‘Seller’ в завимости от типа записи), ‘City’. Отсортировать
--результаты запроса по колонке ‘City’ и по ‘Person’.

select 
cu.ContactName as 'Person', 
'Custmer' as 'Type',
cu.City 
from  Northwind.Customers as cu,Northwind.Employees as emp 
where cu.City = emp.City
union
select emp.FirstName+' '+emp.LastName as 'Person','Seller' as 'Type', cu.City from  Northwind.Customers as cu,Northwind.Employees as emp 
where cu.City = emp.City 
order by  City, Person;
--6.5
--Найти всех покупателей, которые живут в одном городе. В запросе 
--использовать соединение таблицы Customers c собой - самосоединение. 
--Высветить колонки CustomerID и City. Запрос не должен высвечивать 
--дублируемые записи. Для проверки написать запрос, который высвечивает 
--города, которые встречаются более одного раза в таблице Customers. 
--Это позволит проверить правильность запроса.

select distinct 
cu1.CustomerID,
cu1.City 
from Northwind.Customers as cu1 join Northwind.Customers as cu2 
on cu1.City = cu2.City 
where cu1.CustomerID<>cu2.CustomerID;
select City from Northwind.Customers 
group by City 
having COUNT(City)>1;

--6.7
--По таблице Employees найти для каждого продавца его
--руководителя, т.е. кому он делает репорты. Высветить колонки с
--именами 'User Name' (LastName) и 'Boss'. В колонках должны быть
--высвечены имена из колонки LastName. Высвечены ли все
--продавцы в этом запросе?

select 
emp1.LastName,
emp2.LastName as 'Boss' 
from Northwind.Employees as emp1 join Northwind.Employees as emp2 
on emp1.ReportsTo = emp2.EmployeeID
where emp1.LastName<>emp2.LastName;--Высвечены ли все продавцы в этом запросе? 

select distinct 
LastName 
from Northwind.Employees; -- вроде все

--7.1 
--Определить продавцов, которые обслуживают регион 'Western'
--(таблица Region). Результаты запроса должны высвечивать два
--поля: 'LastName' продавца и название обслуживаемой территории
--('TerritoryDescription' из таблицы Territories). Запрос должен
--использовать JOIN в предложении FROM. Для определения связей
--между таблицами Employees и Territories надо использовать
--графические диаграммы для базы Northwind.

select 
(
select LastName 
from Northwind.Employees 
where EmployeeID = emp.EmployeeID) as 'LastName'  , 
ter.TerritoryDescription 
from Northwind.EmployeeTerritories as emp inner join Northwind.Territories as ter 
on emp.TerritoryID = ter.TerritoryID 
where ter.RegionID = 
(
select 
RegionID 
from Northwind.Region 
where RegionDescription = 'Western');

--8.1 
--Высветить в результатах запроса имена всех заказчиков из
--таблицы Customers и суммарное количество их заказов из таблицы
--Orders. Принять во внимание, что у некоторых заказчиков нет
--заказов, но они также должны быть выведены в результатах
--запроса. Упорядочить результаты запроса по возрастанию
--количества заказов.

select 
(
select 
ContactName 
from Northwind.Customers 
where CustomerID = ord.CustomerID
) as 'ContactName',COUNT(ord.OrderID) as 'Amount'
from Northwind.Customers as cu full join Northwind.Orders as ord 
on cu.CustomerID = ord.CustomerID 
group by ord.CustomerID order by Amount;

--9.1 Высветить всех поставщиков колонка CompanyName в таблице
--Suppliers, у которых нет хотя бы одного продукта на складе
--(UnitsInStock в таблице Products равно 0). Использовать
--вложенный SELECT для этого запроса с использованием
--оператора IN. Можно ли использовать вместо оператора IN
--оператор '=' ?

select 
CompanyName 
from Northwind.Suppliers 
where SupplierID not in 
(
select 
SupplierID 
from Northwind.Products 
where UnitsInStock = 0
);

--10.1 
--Высветить всех продавцов, которые имеют более 150 заказов.
--Использовать вложенный коррелированный SELECT.

select 
LastName 
from Northwind.Employees
where employeeID in
(
select 
EmployeeID 
from Northwind.Orders 
group by EmployeeID 
having Count(OrderID)>150
);

--11.1 
--Высветить всех заказчиков (таблица Customers), 
--которые не имеют ни одного заказа (подзапрос по таблице Orders). 
--Использовать коррелированный SELECT и оператор EXISTS.

SELECT 
ContactName 
FROM Northwind.Customers as cu
WHERE NOT EXISTS 
(
SELECT * FROM Northwind.orders as ord
WHERE cu.CustomerID = ord.CustomerID);

--12.1 
--Для формирования алфавитного указателя Employees высветить из таблицы 
--Employees список только тех букв алфавита, с которых начинаются фамилии 
--Employees (колонка LastName ) из этой таблицы. Алфавитный список должен 
--быть отсортирован по возрастанию.
select distinct 
SUBSTRING(lastname,1,1) as 'AlphList' 
from Northwind.Employees 
order by AlphList;

--13.1
EXEC [Northwind].[GreatestOrders] @Year = 1998;
--13.2
EXEC [Northwind].[ShippedOrdersDiff] @Days = 10;
--13.3
EXEC [Northwind].[SubordinationInfo] @EmployeeID = 2;--вывел фамилии подчиненных

--13.4
begin
declare @Boss bit, @EmployeeID int;
set @EmployeeID = 9;
while @EmployeeID > 0
	begin				
	set @Boss = dbo.IsBoss(@EmployeeID);
	set @EmployeeID = @EmployeeID - 1;

	select LastName,	
	case @Boss 
	when 0 then 'Not a boss'
	else 'Boss'
	end  as 'Boss'
	from Northwind.Employees where EmployeeID = @EmployeeID+1;
	--print @Boss; -- аналогично
	end;
end;