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
        "What was the most memorable thing that happened today?"
        , "What was the best thing you did for someone today?"
        , "What is something that reminds you of the beauty of life?"
        , "Who was the most interesting person you interacted with today?"
        , "What was the best part of your day?"
        , "How did you see the hand of the Lord in my life today?"
        , "What was the strongest emotion you felt today?"
        , "If you had one thing you could do over today, what would it be?"
    };

    public static string RandomPrompt()
    {
        var random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index];
    }

    public static JournalEntry CreateEntry()
    {
        string date = DateTime.Now.ToString("M/d/yyyy");

        string prompt = RandomPrompt();

        bool choosingPromt = true;
        do
        {
        System.Console.WriteLine(prompt);
        System.Console.WriteLine(
            """

            Do you like this prompt?
                Press enter: Keep this prompt
                1: Generate new prompt
                2: Create custom prompt

            """
        );
        string promptChoice = Console.ReadLine();
        if (promptChoice == "1")
        {
            prompt = RandomPrompt();

        }
        else if (promptChoice == "2")
        {
            System.Console.WriteLine("Write your custom prompt:\n");
            prompt = Console.ReadLine();
        }
        else
        {
            choosingPromt = false;
        }
        } while (choosingPromt);

        System.Console.WriteLine("Response:\n");
        string response = Console.ReadLine();

        // // Alternate way to create an Entry
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
        // return "Date: " + date + "---" + "Prompt: " + prompt + "\n" + "Response:" + "\n" + response;
        return 
        $"""

        Date: {date} --- Prompt: {prompt}
        Response:
        {response}
        
        """;
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