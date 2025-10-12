using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Polymorphism in Action: Shapes Program ===\n");

        // Create a list of shapes
        List<Shape> shapes = new List<Shape>();

        // Add different shapes to the list
        shapes.Add(new Square("Red", 4));
        shapes.Add(new Rectangle("Blue", 5, 3));
        shapes.Add(new Circle("Green", 2.5));

        // Iterate through the list and display info polymorphically
        foreach (Shape shape in shapes)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Shape Color: {shape.GetColor()}");
            Console.ResetColor();

            Console.WriteLine($"Area: {shape.GetArea():0.00}\n");
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Demonstration complete — polymorphism allows different shapes to share the same interface but behave uniquely.");
        Console.ResetColor();
    }
}
