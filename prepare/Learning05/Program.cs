using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning05 World!");

        List<Shape> shapeList = new();

        shapeList.Add(new Square("Blue", 10));

        shapeList.Add(new Rectangle("Red", 10, 5));

        shapeList.Add(new Circle("Green", 1));

        foreach (Shape shape in shapeList)
        {
            System.Console.WriteLine(shape.Color);
            System.Console.WriteLine(shape.GetArea());
        }

    }
}