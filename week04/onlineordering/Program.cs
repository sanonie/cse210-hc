using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var address1 = new Address("123 Main Street", "New York", "NY", "USA");
        var customer1 = new Customer("John Smith", address1);

        var product1 = new Product("Laptop", "P100", 800, 1);
        var product2 = new Product("Mouse", "P101", 20, 2);

        var products1 = new List<Product> { product1, product2 };
        var order1 = new Order(customer1, products1);

        var address2 = new Address("45 King Road", "Toronto", "Ontario", "Canada");
        var customer2 = new Customer("Mary Jane", address2);

        var product3 = new Product("Phone", "P200", 600, 1);
        var product4 = new Product("Headphones", "P201", 50, 2);

        var products2 = new List<Product> { product3, product4 };
        var order2 = new Order(customer2, products2);

        DisplayOrder("ORDER 1", order1);
        Console.WriteLine();
        DisplayOrder("ORDER 2", order2);
    }

    static void DisplayOrder(string orderTitle, Order order)
    {
        Console.WriteLine(orderTitle);
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order.CalculateTotalCost():F2}");
    }
}