using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning03 World! \nThis is only fractionally better than the last.");
        Fraction fraction1 = new();
        Fraction fraction2 = new(6);
        Fraction fraction3 = new(6, 7);

        System.Console.WriteLine(fraction1.GetFractionString());
        System.Console.WriteLine(fraction1.GetDecimalValue());
        System.Console.WriteLine("");

        System.Console.WriteLine(fraction2.GetFractionString());
        System.Console.WriteLine(fraction2.GetDecimalValue());
        System.Console.WriteLine("");

        System.Console.WriteLine(fraction3.GetFractionString());
        System.Console.WriteLine(fraction3.GetDecimalValue());
        System.Console.WriteLine("");

        System.Console.WriteLine("");
        System.Console.WriteLine("");

        fraction1.Numerator = 5;
        fraction1.Denominator = 3;

        fraction2.Numerator = 8;
        fraction2.Denominator = 14;

        fraction3.Numerator = 3;
        fraction3.Denominator = 7;                


        System.Console.WriteLine(fraction1.GetFractionString());
        System.Console.WriteLine(fraction1.GetDecimalValue());
        System.Console.WriteLine("");

        System.Console.WriteLine(fraction2.GetFractionString());
        System.Console.WriteLine(fraction2.GetDecimalValue());
        System.Console.WriteLine("");

        System.Console.WriteLine(fraction3.GetFractionString());
        System.Console.WriteLine(fraction3.GetDecimalValue());
        System.Console.WriteLine("");
    }
}