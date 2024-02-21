using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning04 World!" + "\n");

        MathAssignment mathAssignmentBasic = new(
            "Samuel Bennett", "Multiplication", "1", "1"
            );

        MathAssignment mathAssignment = new(
            "Roberto Rodriguez", "Fractions", "7.3", "8-19"
            );

        WritingAssignment writingAssignment = new(
            "Mary Waters", "European History", "The Causes of World War II by Mary Waters"
        );


        System.Console.WriteLine(mathAssignmentBasic.GetSummary() + "\n");

        System.Console.WriteLine(mathAssignment.GetSummary());
        System.Console.WriteLine(mathAssignment.GetHomeworkList() + "\n");
        
        System.Console.WriteLine(writingAssignment.GetSummary());
        System.Console.WriteLine(writingAssignment.GetWritingInformation() + "\n");

    }
}