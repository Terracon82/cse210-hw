using System.Runtime.CompilerServices;

class JournalEntry
{
    // Attributes of the class
    private string _date;
    private string _prompt;
    private string _response;

    // This is the delimeter within an entry. This goes between date, prompt, and response.
    private static string _delimeter = "~~!~withinEntryDelimeter~!1t3759U6827j0kO7~~";

    // This is the standard constructor method to create a JournalEntry
    public JournalEntry(string date, string prompt, string response)
    {
        this._date = date;
        this._prompt = prompt;
        this._response = response;
    }

    // // This is the dictionary option to create a JournalEntry
    // public JournalEntry(Dictionary<string, string> entryDict)
    // {
    //     this._date = entryDict["date"];
    //     this._prompt = entryDict["prompt"];
    //     this._response = entryDict["response"];
    // }

    // This is the list of prompts for a journal entry. A prompt is randomly selected from this list.
    private static List<string> prompts = new()
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

    // This method selects a random prompt from the above list.
    private static string RandomPrompt()
    {
        var random = new Random();
        int index = random.Next(prompts.Count);
        return prompts[index];
    }

    // This method interacts with the user to create an entry. It automatically generates a date and a prompt (unless a custom prompt is chosen), and it stores the response from the user.
    // Should I split this into two methods? One to get info from the user and one to create the entry?
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

        // Constructor way to create an Entry
        JournalEntry newEntry = new(date, prompt, response);

        // // Dictionary option to create an entry.
        // Dictionary<string, string> entryDict = new()
        // {
        //     {"date", date}
        //     , {"prompt", prompt}
        //     , {"response", response}
        // };
        // JournalEntry newEntry = new(entryDict);

        return newEntry;
    }

    // This returns the display string for each entry. It also contains the formatting for the printing of each entry.
    public string DisplayEntry()
    {
        // return "Date: " + date + "---" + "Prompt: " + prompt + "\n" + "Response:" + "\n" + response;
        return
        $"""

        Date: {_date} --- Prompt: {_prompt}
        Response:
        {_response}
        
        """;
    }

    // This returns the export string for each entry. It contains the export format for each entry.
    public string ExportEntry()
    {
        // This is the export format for an entry. This does not particularly matter as long as it is consitent, and there is a delimeter between each attribute.
        return _date + _delimeter + _prompt + _delimeter + _response;

        // // Alternate format method. I recommend doing the first because it is more difficult to mess up.
        // return 
        // $"""
        // {_date}{_delimeter}{_prompt}{_delimeter}{_response}
        // """;
    }

    // This loads an entry from a string in an entry's export format.
    public static JournalEntry LoadEntry(string importText)
    {
        // Standard option for creating an entry
        JournalEntry loadedEntry = new(
            importText.Split(_delimeter)[0]
            , importText.Split(_delimeter)[1]
            , importText.Split(_delimeter)[2]
        );

        // // Dictionary option for loading an entry. This potentially allows for a little more flexibility in changing the export format.
        // Dictionary<string, string> loadedEntryDict = new()
        // {
        //     {"date", importText.Split(_delimeter)[0]}
        //     , {"prompt", importText.Split(_delimeter)[1]}
        //     , {"response", importText.Split(_delimeter)[2]}
        // };
        // JournalEntry loadedEntry = new(loadedEntryDict);


        return loadedEntry;
    }

}