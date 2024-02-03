using System;

class Program
{

    // public void DisplayOptions()
    // {
    //     System.Console.WriteLine("");
    // }

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the journal!");
        Journal myJournal = new();

        myJournal.CreateEntry();

        myJournal.DisplayJournal();
    }
}