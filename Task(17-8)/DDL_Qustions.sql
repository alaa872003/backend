--challenge

--insert into production.categories (category_name) values('Accessories')

--insert into sales.customers(first_name,last_name,email)
--values('jhon','Doe','jhon.doe@example.com'),
--		('jane','smith','jane.smith@example.com')

--		UPDATE sales.customers
--SET email = 'jane.smith@example.org'

--UPDATE
--    sales.staffs
--SET
--    email = 'newemail@example.com'
        
--FROM 
--    sales.staffs JOIN sales.stores
--        ON sales.stores.store_id =Sales.staffs.store_id


--Delete from sales.orders where order_status=1

      --advanced database--
	  --(challenge cte)
	  with cte_pro_cat_brand(pid,pname)as(
	  select product_id,product_name from production.products
	  join production.categories on products.category_id=categories.category_id
	  join production.brands on products.brand_id=brands.brand_id
	  )
	  
	  select pid,pname from cte_pro_cat_brand

	   with cte_pro_cat(product_name,total)as(

	  select product_name,count(*)  from production.products
	  join production.stocks on products.product_id=stocks.product_id
		group by products.product_name
	  )

	  	  select product_name,total from cte_pro_cat

	  --select pid,pname from cte_pro_cat_brand
