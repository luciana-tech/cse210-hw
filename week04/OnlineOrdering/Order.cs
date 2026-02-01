using System;
using System.Collections.Generic;


public class Order
{
    private Customer _customer;
    private List<Product> _products = new List<Product>();

    // Constructor - receives a Customer object
    public Order(Customer customer)
    {
        _customer = customer;  // Customer is passed in, not created here
    }

    // Method to add products
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalCost()
    {   
    // Calculate the Total Cost
    double totalProductsCost = 0;
    
    foreach(Product product in _products)
    {
        totalProductsCost += product.CalculateTotal();
    }
    double shippingCost;
    if(_customer.LiveInUSA())
    {
        shippingCost = 5;
    }

    else
    {
        shippingCost = 35; 

    }
    return totalProductsCost + shippingCost;
    }
        public void GetPackingLabel()
        {
            foreach(Product product in _products)
        {
            Console.WriteLine(product.GetProductInfo());
        }
        }

         public void GetShippingLabel()
        {
            Console.WriteLine(_customer.GetCustomerInfo());
        }           
        
        public void DisplayOrderInfo()
        {
            Console.WriteLine("Packing Label:");
            GetPackingLabel();
            Console.WriteLine();
            Console.WriteLine("Shipping Label:");
            GetShippingLabel();
            Console.WriteLine();
            Console.WriteLine($"Total Cost: ${CalculateTotalCost():F2}");
            Console.WriteLine("--------------------------\n");

        }
    }

