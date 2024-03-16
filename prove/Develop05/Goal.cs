class Goal
{
    static readonly public string _goalTypeID = "0000";
    // static readonly public string _delimeterGoalTypeID = "-+=+-";
    // static public string GoalTypeID { get { return _goalTypeID; } }
    protected static string _delimeter = "~-~-~-~";

    protected string _goalName;
    public string GoalName { get { return _goalName; } }

    protected string _goalDescription;
    public string GoalDescription { get { return _goalDescription; } }

    protected int _pointValue;
    public int PointValue { get { return _pointValue; } }

    protected int _numberOfTimesCompleted = 0;
    public int NumberOfTimesCompleted { get { return _numberOfTimesCompleted; } }

    public Goal()
    { }

    public Goal(string goalName, string goalDescription, int pointValue, int numberOfTimesCompleted)
    {
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

    virtual public string GetDisplayString()
    {
        return $"""
        {_goalName}
        {_goalDescription}
        Point Value: {_pointValue}
        Score: {GetScore()}


        """;
    }

    virtual public string ExportGoal()
    {
        return _delimeter
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
        // if (goalTypeID == "")
        // {
        //     goalTypeID = _goalTypeID;
        // }

        // if (goalTypeID != goalText.Split(_delimeter)[0])
        // {
        //     throw new WrongGoalTypeID("Incompatible goalTypeID");
        // }

        string goalName = goalText.Split(_delimeter)[1];
        string goalDescription = goalText.Split(_delimeter)[2];
        int pointValue = int.Parse(goalText.Split(_delimeter)[3]);
        int numberOfTimesCompleted = int.Parse(goalText.Split(_delimeter)[4]);

        return new Goal(goalName, goalDescription, pointValue, numberOfTimesCompleted);
    }

}
public class WrongGoalTypeID : Exception
{
    public WrongGoalTypeID(string message) : base(message)
    {
    }
}