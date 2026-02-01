using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        //Create addresses
        Address address1 = new Address("720 Main St", "Springfield", "IL", "USA");
        Address address2 = new Address("456 Oak Ave", "Toronto", "ON", "Canada");
        Address address3 = new Address("327 Raposo Tavares Rd", "Embu das Artes", "SP", "Brazil");
       
        //Create customers
        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Jane Smith", address2);
        Customer customer3 = new Customer("Luciana Oliveira", address3);

        //Create products
        Product product1 = new Product("1001", "Wireless Mouse", 25.99, 25);
        Product product2 = new Product("1002", "Mechanical Keyboard", 129.99, 3);
        Product product3 = new Product("1003", "USB-C Cable", 15.99, 5);
        Product product4 = new Product("1004", "HD Monitor", 199.99, 10);
        Product product5 = new Product("1005", "External Hard Drive", 89.99, 7);
        Product product6 = new Product("1006", "Webcam", 49.99, 6);
        Product product7 = new Product("1007", "Laptop Stand", 39.99, 12);
        
        //Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);
        
        Order order2 = new Order(customer2);
        order2.AddProduct(product1);
        order2.AddProduct(product4);
        order2.AddProduct(product7);

        Order order3 = new Order(customer3);
        order3.AddProduct(product5);
        order3.AddProduct(product6);

        foreach(Order order in new List<Order> { order1, order2, order3 })
        {
        //Display Packing, Shipping Labels and Total Cost
        order.DisplayOrderInfo();   
        }
    }
}