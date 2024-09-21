using BikeStores.Data;
using BikeStores.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.AccessControl;

namespace BikeStores
{
    internal class Program
    {
        static void Main(string[] args)
        {
        ApplicationDbContext db = new ApplicationDbContext();
            //1)Retrieve all categories from the production.categories table.
            var categories = db.Categories.ToList();
            foreach (var item in categories)
            {
                Console.WriteLine($"Category id: {item.CategoryId},Category Name: {item.CategoryName}");
            }

            //2)Retrieve the first product from the production.products table.
            try
            {

            var firstProduct = db.Products.First();
            Console.WriteLine($"\nProduct id:{firstProduct.ProductId}, Product name:{firstProduct.ProductName}");

            }
              catch
            {
                Console.WriteLine("no element");
            }
            //3)Retrieve a specific product from the production.products table by ID.
            var specificProduct = db.Products.Find(4);
            Console.WriteLine($"\nProduct id:{specificProduct} , Product name: {specificProduct.ProductName} , Product ModelYear: {specificProduct.ModelYear}");
            //4)Retrieve all products from the production.products table with a certain model year.
            var products = db.Products.Where(e => e.ModelYear ==2018);
            foreach (var item in products)
            {
            Console.WriteLine($"\nProduct id:{item} , Product name: {item.ProductName} , Product ModelYear: {item.ModelYear}");
            }
            //5)Retrieve a specific customer from the sales.customers table by ID.
            var specificCustomer = db.Customers.Find(10);
            Console.WriteLine($"Customer id:{specificCustomer.CustomerId}, Customer name: {specificCustomer.FirstName+' '+specificCustomer.LastName}");
            //6)Retrieve a list of product names and their corresponding brand names.
            var productName=db.Products.Select(e => new { e.ProductName, e.Brand.BrandName}).ToList();
            foreach (var item in productName)
            {
                Console.WriteLine($"Product Name: {item.ProductName},Brand Name: {item.BrandName}");
            }

            //7)Count the number of products in a specific category.
                var productCount= db.Products.Count();
            Console.WriteLine($"\nCount of product: {productCount}");
            //8)Calculate the total list price of all products in a specific category.
            var totalListPrice=db.Products.Where(e=>e.CategoryId == 7).Sum(e=>e.ListPrice);
            Console.WriteLine($"Total of list price: {totalListPrice}");
            //9)Calculate the average list price of products.
            var averageListPrice = db.Products.Average(e=>e.ListPrice);
            Console.WriteLine($"Total of list price: {averageListPrice}");
            //10)Retrieve orders that are completed.
            var completedOrders = db.Orders.Where(e =>e.ShippedDate!=null);

            foreach (var item in completedOrders)
            {
                Console.WriteLine($"Order id: {item.OrderId}, Order Date: {item.OrderDate}, Order status: {item.OrderStatus}");
            }
        }
    }
}