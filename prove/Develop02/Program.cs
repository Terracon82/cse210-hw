using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the journal!");
        Journal myJournal = new();
        myJournal.JournalMenu();

        // Above and beyond: I added capability for the user to add custom prompts to their journal entries.
    }
}