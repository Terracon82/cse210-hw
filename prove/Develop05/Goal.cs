using System.ComponentModel.Design;

class Goal
{
    static protected string _goalTypeID = "0000";
    public virtual string GoalTypeID { get { return "0000"; } set { } }
    // static readonly public string _delimeterGoalTypeID = "-+=+-";
    // static public string GoalTypeID { get { return _goalTypeID; } }
    protected static string _delimeter = "~---~";

    protected virtual string CompletionIcon { get { return " "; } set { } }

    public Guid GoalID { get; private set; }

    protected string _goalName;
    public string GoalName { get { return _goalName; } }

    protected string _goalDescription;
    public string GoalDescription { get { return _goalDescription; } }

    protected int _pointValue;
    public int PointValue { get { return _pointValue; } }

    protected int _numberOfTimesCompleted = 0;
    public int NumberOfTimesCompleted { get { return _numberOfTimesCompleted; } }

    public Goal()
    {
        GoalID = Guid.NewGuid();
        CreateGoal();
    }

    public Goal(Guid goalID, string goalName, string goalDescription, int pointValue, int numberOfTimesCompleted)
    {
        GoalID = goalID;
        _goalName = goalName;
        _goalDescription = goalDescription;
        _pointValue = pointValue;
        _numberOfTimesCompleted = numberOfTimesCompleted;
    }

    virtual public void CreateGoal()
    {
        System.Console.Write("What is the name of your goal? ");
        _goalName = System.Console.ReadLine();
        System.Console.WriteLine();

        System.Console.Write("What is a short description of your goal? ");
        _goalDescription = System.Console.ReadLine();
        System.Console.WriteLine();

        System.Console.Write("How many points are associated with your goal? ");
        _pointValue = int.Parse(System.Console.ReadLine());
        System.Console.WriteLine();

        // return new Goal(goalName, goalDescription, pointValue);
    }

    virtual public int GetScore()
    {
        return _pointValue * _numberOfTimesCompleted;
    }

    virtual public int Accomplishment()
    {
        _numberOfTimesCompleted += 1;
        return _pointValue;
    }

    public string GetDisplayString()
    {
        // return $"""
        // {_goalName}
        // {_goalDescription}
        // Point Value: {_pointValue}
        // Score: {GetScore()}


        // """;
        return $"[{CompletionIcon}]({GetScore()} points) {_goalName} ({_goalDescription})";
    }

    virtual public string ExportGoal()
    {
        return GoalTypeID + _delimeter
        + GoalID.ToString() + _delimeter
        + _goalName + _delimeter
        + _goalDescription + _delimeter
        + _pointValue + _delimeter
        + _numberOfTimesCompleted
        ;
    }

    public static Goal ImportGoal(string goalText
    // , string goalTypeID = ""
    )
    {
            Guid goalID = Guid.Parse(goalText.Split(_delimeter)[1]);
            string goalName = goalText.Split(_delimeter)[2];
            string goalDescription = goalText.Split(_delimeter)[3];
            int pointValue = int.Parse(goalText.Split(_delimeter)[4]);
            int numberOfTimesCompleted = int.Parse(goalText.Split(_delimeter)[5]);

            return new Goal(goalID, goalName, goalDescription, pointValue, numberOfTimesCompleted);
    }

}