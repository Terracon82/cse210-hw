class EternalGoal : Goal
{
    static readonly public new string _goalTypeID = "8888";
    public EternalGoal()
    {
        base.CreateGoal();
    }

    public EternalGoal(Goal goal) : base(goal.GoalName, goal.GoalDescription, goal.PointValue, goal.NumberOfTimesCompleted)
    { }    

    // override public EternalGoal CreateGoal()
    // {
    //     return new EternalGoal(base.CreateGoal());
    // }


    public override int GetScore()
    {
        return base.GetScore();
    }


    public override string GetDisplayString()
    {
        return base.GetDisplayString();
    }    

    public override string ExportGoal()
    {
        return _goalTypeID + base.ExportGoal();
    }

    public static new EternalGoal ImportGoal(string goalText
    // , string goalTypeID = ""
    )
    {
        if (_goalTypeID != goalText.Split(_delimeter)[0])
        {
            throw new WrongGoalTypeID("Incompatible goalTypeID");
        }        
        // goalTypeID = _goalTypeID;
        return new EternalGoal(Goal.ImportGoal(goalText
        // , _goalTypeID
        ));
    }    
}