using System.IO.Enumeration;
using System.Reflection;

class User
{
    private static List<Type> _goalTypes = new() {
        typeof(SimpleGoal)
        , typeof(EternalGoal)
        , typeof(ChecklistGoal)
        };

    private List<Goal> _goals = new();
    private int _totalPoints = 0;

    private static string _delimeter = "~`~@~`~";
    private string _fileName = "";

    public void EternalQuest()
    {
        bool continueLoop = true;
        while (continueLoop)
        {
            System.Console.Write(
                $"""
                You have {_totalPoints} points.

                Menu Options:
                    1. Create New Goal
                    2. List Goals
                    3. Save Goals
                    4. Load Goals
                    5. Record Event
                    6. Quit
                Select a choice from the menu: 
                """
            );
            string userInput = System.Console.ReadLine();
            System.Console.WriteLine();

            switch (userInput)
            {
                case "6":
                    continueLoop = false;
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "2":
                    System.Console.WriteLine(ListGoals());
                    System.Console.WriteLine();
                    break;
                case "1":
                    CreateGoal();
                    break;
                default:
                    System.Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

        };
    }
    public void CreateGoal()
    {
        System.Console.Write(
            """
                    The types of Goals are:
                        1. Simple Goal
                        2. Eternal Goal
                        3. Checklist Goal
                    Which type of Goal would you like to create? 
                    """
        );
        string goalType = System.Console.ReadLine();
        System.Console.WriteLine();
        switch (goalType)
        {
            case "1":
                _goals.Add(new SimpleGoal());
                break;
            case "2":
                _goals.Add(new EternalGoal());
                break;
            case "3":
                _goals.Add(new ChecklistGoal());
                break;
            default:
                System.Console.WriteLine("Invalid Choice. Please try again.");
                break;
        }
    }

    public string ListGoals()
    {
        string displayString = "";
        for (int i = 0; i < _goals.Count; i++)
        {
            displayString += i + 1 + ". " + _goals[i].GetDisplayString() + "\n";
        }

        return displayString;
    }

    public void SaveGoals()
    {
        System.Console.WriteLine("What is your filename? ");
        _fileName = System.Console.ReadLine();

        LoadGoals(_fileName);

        string exportString = "";
        for (int i = 0; i < _goals.Count; i++)
        {
            exportString += _goals[i].ExportGoal();
            if (i != _goals.Count - 1)
            {
                exportString += _delimeter;
            }
        }

        Filemanager.SaveText(exportString, _fileName);
    }

    public void LoadGoals(string fileName = "")
    {
        if (fileName == "")
        {
            // Select file
            System.Console.WriteLine("What is your filename? ");
            _fileName = System.Console.ReadLine();
        }
        else
        {
            _fileName = fileName;
        }

        // Load file and split into a list
        string importString = Filemanager.LoadText(_fileName);
        List<string> goalTextList = importString.Split(_delimeter).ToList();

        // Load goals from list
        foreach (string goalText in goalTextList)
        {
            // Check each goal to match it to type of goal
            foreach (Type systemGoalType in _goalTypes)
            {
                // Attempt to import goal as each type of goal. If it does not match it returns null.
                Goal goal = (Goal)systemGoalType
                .GetMethod("ImportGoal", BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Invoke(null, new object[] { goalText }
                );

                // If the goal was of the correct type:
                if (goal != null)
                {
                    // Check if the goal already exists in the user's session.
                    bool alreadyExists = false;
                    for (int i = 0; i < _goals.Count; i++)
                    {
                        if (goal.GoalID == _goals[i].GoalID)
                        {
                            alreadyExists = true;
                        }
                    }

                    // If the goal does not already exist, it is added to the user's session.
                    if (!alreadyExists)
                    {
                        _goals.Add(goal);
                    }
                }
            }
        }

        // Recalculate total points.
        _totalPoints = 0;
        foreach (Goal goal in _goals)
        {
            _totalPoints += goal.GetScore();
        }
    }

    public void RecordEvent()
    {
        System.Console.WriteLine("The goals are:");
        System.Console.WriteLine(ListGoals());
        System.Console.Write("Which goal did you accomplish? ");
        int userInput = int.Parse(System.Console.ReadLine());
        System.Console.WriteLine();

        int pointsEarned = _goals[userInput - 1].Accomplishment();
        _totalPoints += pointsEarned;

        System.Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
        System.Console.WriteLine();
    }
}