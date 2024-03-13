class EternalGoal : Goal
{
    public EternalGoal(Goal goal) : base(goal.GoalName, goal.GoalDescription, goal.PointValue)
    {

    }

    override public EternalGoal CreateGoal()
    {
        return new EternalGoal(base.CreateGoal());
    }


    // public override int GetScore()
    // {
    //     return base._pointValue * _numberOfTimesCompleted;
    // }


    public override string GetDisplayString()
    {
        return base.GetDisplayString();
    }    
}