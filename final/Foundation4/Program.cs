using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Foundation4 World!");

        List<Activity> activities = new()
        {
            new Running("30 Feb 2023", 15, 2)
            , new Cycling("12 Jun 2025", 30, 10)
            , new Swimming("0 Oct 1007", 25, 6)
        };

        foreach (Activity activity in activities)
        {
            System.Console.WriteLine(activity.Summary);
        }
    }
}