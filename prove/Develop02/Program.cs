using System;

class Program
{

    // public void DisplayOptions()
    // {
    //     System.Console.WriteLine("");
    // }

    static void Main(string[] args)
    {
        // System.Console.WriteLine(System.IO.Directory.GetCurrentDirectory());
        Console.WriteLine("Welcome to the journal!");
        Journal myJournal = new();

        myJournal.JournalMenu();

        // // System.Console.WriteLine(myJournal._optionsText);

        // myJournal.CreateEntry();

        // System.Console.WriteLine("\n" + myJournal.DisplayJournal());
    }
}