class SimpleGoal : Goal
{
    static readonly public new string _goalTypeID = "1234";
    // private bool _isComplete = false;
    // public bool IsComplete { get { return _isComplete; } }

    public SimpleGoal()
    {
        base.CreateGoal();
    }

    public SimpleGoal(Goal goal) : base(goal.GoalName, goal.GoalDescription, goal.PointValue, goal.NumberOfTimesCompleted)
    { }

    public override void CreateGoal()
    {
        base.CreateGoal();
    }

    public override int GetScore()
    {
        if (_numberOfTimesCompleted >= 1)
        {
            return _pointValue;
        }
        else
        {
            return 0;
        }
    }

    public override string GetDisplayString()
    {
        return base.GetDisplayString();
    }

    public override string ExportGoal()
    {
        return _goalTypeID + base.ExportGoal();
    }

    public static new SimpleGoal ImportGoal(string goalText
    // , string goalTypeID = ""
    )
    {
        if (_goalTypeID == goalText.Split(_delimeter)[0])
        {
            // throw new WrongGoalTypeID("Incompatible goalTypeID");

        // goalTypeID = _goalTypeID;
        return new SimpleGoal(Goal.ImportGoal(goalText
        // , _goalTypeID
        )
        );
        }
        else
        {
            return null;
        }
    }
}