using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int numberResponse;

        List<int> numberList = new List<int>();

        do
        {
            Console.Write("Enter number: ");
            numberResponse = int.Parse(Console.ReadLine());

            if (numberResponse != 0)
            {
                numberList.Add(numberResponse);
            }
        } while (numberResponse != 0);

        int listSum = numberList.Sum();
        double listAverage = numberList.Average();
        int listMax = numberList.Max();
        int listMinPositive = numberList.Where(x => x > 0).ToList().Min();
        numberList.Sort();

        Console.WriteLine($"The sum is: {listSum}");
        Console.WriteLine($"The average is: {listAverage}");
        Console.WriteLine($"The largest number is: {listMax}");
        Console.WriteLine($"The smallest positive number is: {listMinPositive}");
        Console.WriteLine("The sorted list is:");
        foreach (var num in numberList)
        {
            Console.WriteLine(num);
        }
    }
}