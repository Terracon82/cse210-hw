using System;

class Program
{
    static void Main(string[] args)
    {
        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the program.");
        }

        static string PromptUserName()
        {
            Console.Write("State your name: ");
            string name = Console.ReadLine().ToString();
            return name;
        }

        static int PromptUserNumber()
        {
            Console.Write("Provide a number: ");
            int number = int.Parse(Console.ReadLine());
            return number;
        }    

        static int SquareNumber(int number)
        {
            int numberSqared = number * number;
            return numberSqared;
        }    

        static void DisplayResult(int numberSquared, string name)
        {
            Console.WriteLine($"{name}, the sqare of your number is {numberSquared}.");
        }

        DisplayWelcome();
        string name = PromptUserName();
        int number = PromptUserNumber();
        int numberSquared = SquareNumber(number);
        DisplayResult(numberSquared, name);
    }
}