using System.Runtime.CompilerServices;

class JournalEntry
{
    public string date;
    public string prompt;
    public string response;

    private static string _delimeter = "~~!~withinEntryDelimeter~!1t3759U6827j0kO7~~";

    // public Entry(string date, string prompt, string response)
    public JournalEntry(Dictionary<string, string> entryDict)
    {
        this.date = entryDict["date"];
        this.prompt = entryDict["prompt"];
        this.response = entryDict["response"];
    }

    public static List<string> prompts = new()
    {
        "What was the most memorable things that happened today?"
        , "What was the best thing you did for someone today?"
        , "Was there anything that reminded you of the beauty of life today?"
    };

    public static string RandomPrompt()
    {
        var random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index];
    }

    public static JournalEntry CreateEntry()
    {
        string prompt = RandomPrompt();
        System.Console.WriteLine(prompt);
        string response = Console.ReadLine();
        string date = DateTime.Now.ToString("M/d/yyyy");

        // Entry newEntry = new(date, prompt, response);
        // Entry newEntry = new();
        // newEntry.date = date;
        // newEntry.prompt = prompt;
        // newEntry.response = response;
        // return newEntry;

        Dictionary<string, string> entryDict = new()
        {
            {"date", date}
            , {"prompt", prompt}
            , {"response", response}
        };
        JournalEntry newEntry = new(entryDict);

        return newEntry;
    }

    public string DisplayEntry()
    {
        // System.Console.WriteLine(date);
        // System.Console.WriteLine(prompt);
        // System.Console.WriteLine(response);
        // System.Console.WriteLine("");

        return date + "\n" + prompt + "\n" + response;
    }

    public string ExportEntry()
    {
        return date + _delimeter + prompt + _delimeter + response;
    }
    public static JournalEntry LoadEntry(string importText)
    {
        Dictionary<string, string> loadedEntryDict = new()
        {
            {"date", importText.Split(_delimeter)[0]}
            , {"prompt", importText.Split(_delimeter)[1]}
            , {"response", importText.Split(_delimeter)[2]}
        };
        JournalEntry loadedEntry = new(loadedEntryDict);
        return loadedEntry;
    }

}