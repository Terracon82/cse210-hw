class SimpleGoal : Goal
{
    private bool _isComplete = false;
    public bool IsComplete { get { return _isComplete; } }

    public SimpleGoal(Goal goal) : base(goal.GoalName, goal.GoalDescription, goal.PointValue)
    {

    }

    override public SimpleGoal CreateGoal()
    {
        return new SimpleGoal(base.CreateGoal());
    }

    public override int GetScore()
    {
        if (_isComplete)
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
}