using System;

public class Customer
{
    // Create attributes
    private string _name;
    private Address _address;

    // Constructor - receives name and address
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;  // Store the passed address
    }

    public bool LiveInUSA()
    {
        return _address.IsInUSA();
    }

    public string GetCustomerInfo()
    {
        return $"Customer: {_name}\n{_address.GetFullAddress()}";
    }
}