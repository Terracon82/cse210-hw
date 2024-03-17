using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Hello Eternal Quest!");

        // string specialChar = "\u25CB";
        // Console.WriteLine(specialChar);

        User user = new();
        user.EternalQuest();
    }
}