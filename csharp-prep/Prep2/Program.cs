using System;

class Program
{
    static void Main(string[] args)
    {
        // Initial prompt for grade percentage
        Console.Write("What is your grade Percentage? ");
        float gradePercentage = float.Parse(Console.ReadLine());

        // Logic to determine grade letter
        string gradeLetter = "undefined value";
        if (gradePercentage >= 90)
        {
            gradeLetter = "A";
        }
        else if (gradePercentage >= 80)
        {
            gradeLetter = "B";
        }
        else if (gradePercentage >= 70)
        {
            gradeLetter = "C";
        }
        else if (gradePercentage >= 60)
        {
            gradeLetter = "D";
        }
        else if (gradePercentage < 60)
        {
            gradeLetter = "F";
        }

        // Grade sign logic (+ or -)
        string gradeSign = "";
        if (gradePercentage % 10 > 7 && gradeLetter != "A" && gradeLetter != "F") 
        {
            gradeSign = "+";
        }
        else if (gradePercentage % 10 < 3 && gradeLetter != "F")
        {
            gradeSign = "-";
        }

        // Print statement with logic to determine whether to use "a" or "an"
        var anGrades = new List<string>() { "A", "F" };
        if (anGrades.Contains(gradeLetter))
        {
            Console.WriteLine($"You scored an {gradeLetter}{gradeSign}");
        }
        else
        {
            Console.WriteLine($"You scored a {gradeLetter}{gradeSign}");
        }

        // Logic and print statement determining whether the class was passed.
        var passingGrades = new List<string>() { "A", "B", "C" };
        if (passingGrades.Contains(gradeLetter))
        {
            Console.Write("Congrats! You survived the course!");
            Thread.Sleep(1000);
            Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
            Console.WriteLine("Congrats! You passed the course!");
        }
        else
        {
            Console.WriteLine("You failed. Better luck next time.");
        }

    }
}