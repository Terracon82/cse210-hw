class EternalGoal : Goal
{
    static readonly public new string _goalTypeID = "8888";
    public EternalGoal()
    {
        base.CreateGoal();
    }

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
}