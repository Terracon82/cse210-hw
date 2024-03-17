class SimpleGoal : Goal
{
    static protected new string _goalTypeID = "1234";
    override public string GoalTypeID { get { return _goalTypeID; } }
    // private bool _isComplete = false;
    // public bool IsComplete { get { return _isComplete; } }

    protected override string CompletionIcon
    {
        get
        {
            if (_numberOfTimesCompleted >= 1)
            {
                return "X";
            }
            else
            {
                return " ";
            }
        }
        set { }
    }

    public SimpleGoal()
    {
        _goalTypeID = "1234";
        // base.CreateGoal();
    }

    public SimpleGoal(Goal goal) : base(goal.GoalID, goal.GoalName, goal.GoalDescription, goal.PointValue, goal.NumberOfTimesCompleted)
    {
        _goalTypeID = "1234";
    }

    // public override void CreateGoal()
    // {
    //     base.CreateGoal();
    // }

    // public override int GetScore()
    // {
    //     if (_numberOfTimesCompleted >= 1)
    //     {
    //         return _pointValue;
    //     }
    //     else
    //     {
    //         return 0;
    //     }
    // }

    public override int Accomplishment()
    {
        if (_numberOfTimesCompleted < 1)
        {
            return base.Accomplishment();
        }
        else
        {
            return 0;
        }
    }

    // public override string GetDisplayString()
    // {
    //     if (_numberOfTimesCompleted >= 1)
    //     {
    //         _completionIcon = "X";
    //     }
    //     else
    //     {
    //         _completionIcon = " ";
    //     }        
    //     return base.GetDisplayString();
    // }

    // public override string ExportGoal()
    // {
    //     return _goalTypeID + base.ExportGoal();
    // }

    public static new SimpleGoal ImportGoal(string goalText
    // , string goalTypeID = ""
    )
    {
        // return new SimpleGoal(Goal.ImportGoal(goalText));

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