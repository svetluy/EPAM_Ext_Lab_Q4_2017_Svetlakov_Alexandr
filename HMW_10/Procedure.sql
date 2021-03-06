--13.1 
--Написать процедуру, которая возвращает самый крупный заказ для 
--каждого из продавцов за определенный год. В результатах не может 
--быть несколько заказов одного продавца, должен быть только один 
--и самый крупный. В результатах запроса должны быть выведены следующие 
--колонки: колонка с именем и фамилией продавца (FirstName и LastName – 
--пример: Nancy Davolio), номер заказа и его стоимость. В запросе надо 
--учитывать Discount при продаже товаров. Процедуре передается год, 
--за который надо сделать отчет, и количество возвращаемых записей. 
--Результаты запроса должны быть упорядочены по убыванию суммы заказа. 
--Процедура должна быть реализована с использованием оператора SELECT 
--и БЕЗ ИСПОЛЬЗОВАНИЯ КУРСОРОВ. Название функции соответственно GreatestOrders.

USE [Northwind]
GO
/****** Object:  StoredProcedure [Northwind].[GreatestOrders]    Script Date: 25.02.2018 17:50:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [Northwind].[GreatestOrders] @Year int
AS
select (
select FirstName+' '+LastName 
from Northwind.Employees where EmployeeID = ord.EmployeeID) as 'Seller',MAX(Quantity*OD.UnitPrice*(1-Discount)) AS 'OrderPrice'
from Northwind.Orders as ord inner join Northwind.[Order Details] as od on ord.OrderID = od.OrderID 
where YEAR(ord.OrderDate) = @Year group by EmployeeID order by OrderPrice desc;

--13.2 
--Написать процедуру, которая возвращает заказы в таблице Orders, 
--согласно указанному сроку доставки в днях (разница между OrderDate 
--и ShippedDate). В результатах должны быть возвращены заказы, срок 
--которых превышает переданное значение или еще недоставленные заказы. 
--Значению по умолчанию для передаваемого срока 35 дней. Название 
--процедуры ShippedOrdersDiff. Процедура должна высвечивать следующие 
--колонки: OrderID, OrderDate, ShippedDate, ShippedDelay (разность в 
--днях между ShippedDate и OrderDate), SpecifiedDelay (переданное в 
--процедуру значение). Необходимо продемонстрировать использование 
--этой процедуры.

/****** Object:  StoredProcedure [Northwind].[ShippedOrdersDiff]    Script Date: 25.02.2018 17:50:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [Northwind].[ShippedOrdersDiff] @Days int
AS
if(@Days is null)
set @Days = 35
select OrderID, OrderDate, ShippedDate, ShippedDate - OrderDate as 'ShippedDelay', @Days as 'SpecifiedDelay' 
from Northwind.Orders 
where DAY(ShippedDate - OrderDate) > @Days or ShippedDate is null;

--13.3 
--Написать процедуру, которая высвечивает всех подчиненных заданного продавца, 
--как непосредственных, так и подчиненных его подчиненных. В качестве входного 
--параметра функции используется EmployeeID. Необходимо распечатать имена подчиненных 
--и выровнять их в тексте (использовать оператор PRINT) согласно иерархии подчинения. 
--Продавец, для которого надо найти подчиненных также должен быть высвечен. Название 
--процедуры SubordinationInfo. В качестве алгоритма для решения этой задачи надо 
--использовать пример, приведенный в Books Online и рекомендованный Microsoft для 
--решения подобного типа задач. Продемонстрировать использование процедуры.
/****** Object:  StoredProcedure [Northwind].[SubordinationInfo]    Script Date: 25.02.2018 19:13:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [Northwind].[SubordinationInfo] @EmployeeID int
AS
select distinct emp.LastName
from Northwind.Employees emp inner join Northwind.Employees emp2 on emp.ReportsTo = @EmployeeID ;

--13.4 
--Написать функцию, которая определяет, есть ли у продавца подчиненные. 
--Возвращает тип данных BIT. В качестве входного параметра функции 
--используется EmployeeID. Название функции IsBoss. Продемонстрировать 
--использование функции для всех продавцов из таблицы Employees.
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER FUNCTION IsBoss(@EmployeeID int)
RETURNS bit
AS
BEGIN
	DECLARE @ResultVar bit, @SubordID int;

	set @SubordID=( select  distinct top 1 emp.EmployeeID 
    from Northwind.Employees emp inner join Northwind.Employees emp2 on emp.ReportsTo = @EmployeeID)
	
	if(@SubordID is not null)
	set @ResultVar = 1
	else
	set @ResultVar = 0;

	return @ResultVar;
END


