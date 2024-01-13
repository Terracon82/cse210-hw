using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep2 World!");

        //Primitive types
        int i;
        long l;
        float f;
        double d;
        char c;
        string s;
        byte b;
        bool b2;


        //Variables
        int myCount = 4;
        // myCount = "bob"; //This does not work.
        string aName = "bob";


        //var
        var anotherCount = 4;
        // anotherCount = 3.4; //This also does not work.



        //Printing Variables
        Console.Write("What's your age? ");



        //ReadLine
        var ageString = Console.ReadLine();
        System.Console.WriteLine($"My age is {ageString}."); // use cw + TAB for System.Console.WriteLine // Use $ at beginning of sting to evaluate variables in the string.
        System.Console.WriteLine($"My age is " + ageString + ".");



        //Converting Variables
        int age = int.Parse(ageString);



        //Conditionals
        if (age < 18)
            System.Console.WriteLine("You're a minor"); //C# does not care about whitespace or newlines.
        System.Console.WriteLine("This string prints regardless");

        if (age > 18)
        {
            System.Console.WriteLine("You're not a minor"); //Use brackets to form blocks of code.
            System.Console.WriteLine("This string only prints if you are old.");
        }



        //Operators
    }
}