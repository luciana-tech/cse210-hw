using System;

public class Rectangle : Shape
{
    private double _width;
    private double _height;

    public Rectangle(string color, double height, double width) : base(color) 
    {   
        // Constructor that initializes the rectangle with a color, length, and width. It calls the base class constructor to set the color and then sets the length and width of the rectangle.
        _height = height;
        _width = width;
    }

    public override double GetArea()
    {
        return _width * _height; // Area of a rectangle is width multiplied by height
    }
}