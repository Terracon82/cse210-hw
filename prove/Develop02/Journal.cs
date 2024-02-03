class Journal
{
    public List<Entry> entries = new(); 

    public void CreateEntry()
    {
        Entry newEntry = Entry.CreateEntry();
        entries.Add(newEntry);
        // List<Entry> entries = new()
        // {
        //     newEntry
        // };
        // return entries;
    }

    public void DisplayJournal()
    {
        foreach (Entry entry in entries)
        {
            entry.DisplayEntry();
        }
    }
}