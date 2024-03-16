class SimpleGoal : Goal
{
    static readonly public new string _goalTypeID = "1234";
    private bool _isComplete = false;
    public bool IsComplete { get { return _isComplete; } }

    public SimpleGoal()
    {
        base.CreateGoal();
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