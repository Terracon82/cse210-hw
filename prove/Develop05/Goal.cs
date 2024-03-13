class Goal
{
    protected int _pointValue;
    public int PointValue { get { return _pointValue; } }


    protected int _numberOfTimesCompleted = 0;
    protected string _goalName;
    public string GoalName { get { return _goalName; } }

    protected string _goalDescription;
    public string GoalDescription { get { return _goalDescription; } }

    private string _delimeter = "~-~-~-~";

    public Goal(string goalName, string goalDescription, int pointValue)
    {
        _goalName = goalName;
        _goalDescription = goalDescription;
        _pointValue = pointValue;
    }

    virtual public Goal CreateGoal()
    {
        System.Console.Write("What is the name of your goal? ");
        string goalName = System.Console.ReadLine();
        System.Console.WriteLine();

        System.Console.Write("What is a short description of your goal? ");
        string goalDescription = System.Console.ReadLine();
        System.Console.WriteLine();

        System.Console.Write("How many points are associated with your goal? ");
        int pointValue = int.Parse(System.Console.ReadLine());
        System.Console.WriteLine();

        return new Goal(goalName, goalDescription, pointValue);
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
        return _goalName + _delimeter + _goalDescription + _delimeter + _pointValue;
    }

}