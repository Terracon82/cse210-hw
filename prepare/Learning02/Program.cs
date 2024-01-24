using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning02 World!");

        var carList = new List<Car>();

        Car carInstance1 = new("Honda", "Civic", 12, 30);
            // Car carInstance2 = new();
            // var carInstance3 = new Car();


        Person owner = new()
        {
            name = "Jeff",
            phone = "1234567890"
        };
        carInstance1.owner = new Person();

        carList.Add(carInstance1);

        carInstance1 = new Car
        (
            "Ford",
            "F-150",
            18,
            25
        );

        owner = new()
        {
            name = "Jeff",
            phone = "1234567890"
        };
        carInstance1.owner = new Person();

        carList.Add(carInstance1);


        foreach (var c in carList)
        {
            // System.Console.WriteLine($"{c.make}, {c.model}: total range = {c.TotalRange()}");
            c.DisplayData();
        }
    }
}
