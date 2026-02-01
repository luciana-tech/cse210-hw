using System;

public class Product
{
    private string _productName;
    private string _productId;
    private double _price;
    private int _quantity;

    // Constructor
    public Product(string productId, string productName, double price, int quantity)
        {
            _productId = productId;
            _productName = productName;
            _price = price;
            _quantity = quantity;
        }

    // Calculate total
    public double CalculateTotal()
        {
            return _price * _quantity;
        }   
    public string GetProductInfo()
        {
            return $"{_productId}, {_productName}";
        }    
}