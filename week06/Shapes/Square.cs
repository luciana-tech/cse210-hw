using System;

public class Square : Shape
{
    private double _sideLength;

    public Square(string color, double sideLength) : base(color)
    {
        _sideLength = sideLength;
    }

    public override double GetArea()
    {
        return _sideLength * _sideLength; // Area of a square is side length squared
    }
}