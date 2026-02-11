using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Build a List of shapes
        List<Shape> shapes = new List<Shape>();
        
       // Add a Square
        Square s1 = new Square("Yellow", 7);
        shapes.Add(s1);

        // Add a Rectangle
        Rectangle s2 = new Rectangle("Purple", 3, 5);
        shapes.Add(s2);

        // Add a Circle
        Circle s3 = new Circle("Orange", 9);
        shapes.Add(s3);
        
        // Iterate through the list and display information
        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();
            Console.WriteLine($"The {color} shape has an area of {area:F2}.");
        }
    }
}