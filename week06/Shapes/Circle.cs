using System;
public class Circle : Shape
{
    private double _radius;

    public Circle(string color, double radius) : base(color)
    {
        _radius = radius; // Constructor that initializes the circle with a color and radius. It calls the base class constructor to set the color and then sets the radius of the circle.
    }

    public override double GetArea()
    {
        return Math.PI * _radius * _radius; // Area of a circle is π * radius squared
    }
}