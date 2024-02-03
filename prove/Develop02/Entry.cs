using System.Runtime.CompilerServices;

class Entry
{
    public string date;
    public string prompt;
    public string response;

    // public Entry(string date, string prompt, string response)
    public Entry(Dictionary<string, string> entryDict)
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

    public static Entry CreateEntry()
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
        Entry newEntry = new(entryDict);

        return newEntry;
    }

    public void DisplayEntry()
    {
        System.Console.WriteLine(date);
        System.Console.WriteLine(prompt);
        System.Console.WriteLine(response);
        System.Console.WriteLine("");
    }


}