using System.Reflection.Metadata.Ecma335;

class Journal
{
    public List<JournalEntry> entries = new();
    private string _delimeter = "~~!~betweenEntryDelimeter~!1as5DG813Y99K86Lf~~";

    public void JournalMenu()
    {
        bool loopJournal = true;
        while (loopJournal)
        {
            string optionsText =
            """

            0: Quit Journal
            1: New Entry
            2: Display Journal
            3: Save Journal
            4: Load Journal

            """;

            System.Console.WriteLine(optionsText);
            string choice = Console.ReadLine();
            if (choice == "0")
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
            else
            {
                System.Console.WriteLine("Invalid choice. Please enter a number.");
            }
        }
    }

    public void CreateEntry()
    {
        JournalEntry newEntry = JournalEntry.CreateEntry();
        entries.Add(newEntry);
    }

    public void DisplayJournal()
    {
        string displayText = "";
        foreach (JournalEntry entry in entries)
        {
            displayText += "\n" + "Entry:\n" + entry.DisplayEntry();
        }
        System.Console.WriteLine(displayText);
    }

    public string ExportJournal()
    {
        string exportText = "";
        for (int index = 0; index < entries.Count; index++) 
        {
            exportText += entries[index].ExportEntry();
            if (index < entries.Count - 1)
            {
                exportText += _delimeter;
            }
        }
        return exportText;
    }

    public void SaveJournal()
    {
        System.Console.WriteLine("Enter file name with file extension:");
        string fileName = System.Console.ReadLine();
        Filemanager.SaveText(this.ExportJournal(), fileName);
    }

    public void LoadJournal()
    {
        System.Console.WriteLine("Enter file name with file extension:");
        string fileName = System.Console.ReadLine();
        string importText = Filemanager.LoadText(fileName);

        foreach (var entryText in importText.Split(_delimeter))
        {
            this.entries.Add(JournalEntry.LoadEntry(entryText));
        }

    }
}