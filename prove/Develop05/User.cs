using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
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
        foreach (Goal goal in _goals)
        {
            displayString += goal.GetDisplayString();
        }

        return displayString;
    }

    public void SaveGoals()
    {
        System.Console.WriteLine("What is your filename? ");
        _fileName = System.Console.ReadLine();

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

    public void LoadGoals()
    {
        System.Console.WriteLine("What is your filename? ");
        _fileName = System.Console.ReadLine();

        string importString = Filemanager.LoadText(_fileName);
        List<string> goalTextList = importString.Split(_delimeter).ToList();

        foreach (string goalText in goalTextList)
        {
            // string goalTypeID = goalText
            //     .Split(typeof(Goal)
            //     .GetField("_delimeterGoalTypeID")
            //     .GetValue(null).ToString())
            //     .ToList()[0];

            foreach (Type systemGoalType in _goalTypes)
            {
                try
                {
                    // var method = systemGoalType.GetMethod("ImportGoal"
                    // , BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy
                    // );

                    // var invokeStuff = method.Invoke(null, new object[] { goalText });


                    _goals.Add(
                        (Goal)systemGoalType
                        .GetMethod("ImportGoal", BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                        .Invoke(null, new object[] { goalText })
                        );
                }
                catch (WrongGoalTypeID)
                { }
            }
        }
    }

    public void RecordEvent()
    {

    }
}