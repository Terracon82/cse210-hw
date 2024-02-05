using System.Reflection.Metadata.Ecma335;

class Journal
{
    // This creates an empty list of entries.
    private List<JournalEntry> _entries = new();
    
    // This delimeter separates entries
    private string _delimeter = "~~!~betweenEntryDelimeter~!1as5DG813Y99K86Lf~~";

    // The JournalMenu method is an interface with the rest of the journal.
        // It includes displaying options, interpreting the response, and calling other methods from the class.
    public void JournalMenu()
    {
        bool loopJournal = true;
        while (loopJournal)
        {
            string optionsText =
            """
            Select one of the following:

            1: New Entry
            2: Display Journal
            3: Save Journal
            4: Load Journal
            5: Quit Journal

            """;

            // This takes user input
            System.Console.WriteLine(optionsText);
            string choice = Console.ReadLine();

            // Logic to choose what to do based on user input.
            if (choice == "5")
            {
                loopJournal = false;
            }
            else if (choice == "1")
            {
                this.CreateEntry();
            }
            else if (choice == "2")
            {
                this.DisplayJournal();
            }
            else if (choice == "3")
            {
                this.SaveJournal();
            }
            else if (choice == "4")
            {
                this.LoadJournal();
            }
            else // Mild error catching
            {
                System.Console.WriteLine("Invalid choice. Please enter a number.");
            }
        }
    }

    // This creates a new instance of the JournalEntry Class.
    public void CreateEntry()
    {
        JournalEntry newEntry = JournalEntry.CreateEntry();
        _entries.Add(newEntry);
    }

    // This Iterates through each entry in the journal and contains the format that separates each entry. It then prints them to the console.
    public void DisplayJournal()
    {
        string displayText = "";
        foreach (JournalEntry entry in _entries)
        {
            displayText += // This is the format between each entry.
            $"""

            {entry.DisplayEntry()}

            """;
            // "\n" + "Entry:\n" + entry.DisplayEntry();
        }
        System.Console.WriteLine(displayText);
    }

    // This function returns a string of the entire journal in export format, which means delimeters within and between each entry.
    private string ExportJournal()
    {
        string exportText = "";
        for (int index = 0; index < _entries.Count; index++)
        {
            exportText += _entries[index].ExportEntry();

            if (index < _entries.Count - 1) // This if statement only adds delimeters *between* entries, rather than after every entry.
            {
                exportText += _delimeter;
            }
        }
        return exportText;
    }

    // This method calls the Export Journal function to send a string to the Filemanager, which then saves it to a file. It takes input from the user for the file name to save to.
    public void SaveJournal(string fileName = "journal.txt")
    {
        System.Console.WriteLine("Enter file name with file extension:");
        fileName = System.Console.ReadLine();
        Filemanager.SaveText(this.ExportJournal(), fileName);
    }

    // This method loads the journal from a text file. The name of the file to retrieve is given by the user.
    public void LoadJournal(string fileName = "journal.txt")
    {
        System.Console.WriteLine("Enter file name with file extension:");
        fileName = System.Console.ReadLine();
        string importText = Filemanager.LoadText(fileName);

        foreach (var entryText in importText.Split(_delimeter))
        {
            this._entries.Add(JournalEntry.LoadEntry(entryText));
        }

    }
}