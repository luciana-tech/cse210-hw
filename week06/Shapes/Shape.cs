using System;

public class Shape
{
    private string _color; // Private field to store the color of the shape
    
    // Constructor

    public Shape(string color)
    {
        _color = color;
    }

    public string GetColor()
    {
        return _color; //getter returns the value of the private field _color
    }

    public void SetColor(string color)
    {
        _color = color; //setter sets the value of the private field _color to the value passed as an argument
    }

    public virtual double GetArea()
    {
        return 0; // This method is meant to be overridden in derived classes, so it returns 0 by default
    }
}