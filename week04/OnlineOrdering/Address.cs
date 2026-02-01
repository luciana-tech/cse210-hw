using System;

public class Address
{
 // Create attributes
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    // Add a constructor to set address details
    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool IsInUSA()
    {
        // Check if the country is USA
        return _country.ToUpper() == "USA" || _country.ToUpper() == "US";
    }

    public string GetFullAddress()
    {
        // Return the full address as a string
        return $"Address: {_street}\n{_city}, {_state}, {_country}";
    }
}