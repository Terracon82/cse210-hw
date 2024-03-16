class ChecklistGoal : Goal
{
    static readonly public new string _goalTypeID = "5678";
    int _numberOfTimesItNeedsToBeCompleted = 1;
    int _bonusPointAmount = 0;

    public ChecklistGoal()
    
    {
        base.CreateGoal();

        System.Console.Write("How many times does this goal need to be accomplished? ");
        _numberOfTimesItNeedsToBeCompleted = int.Parse(System.Console.ReadLine());
        System.Console.WriteLine();

        System.Console.Write("What is the bonus for completeing the goal? ");
        _bonusPointAmount = int.Parse(System.Console.ReadLine());
        System.Console.WriteLine();
        
    }

    // override public ChecklistGoal CreateGoal()
    // {
    //     Goal goal = base.CreateGoal();

    //     return new ChecklistGoal(goal, numberOfTimesItNeedsToBeCompleted, bonusPointAmount);
    // }

    public override int GetScore()
    {
        if (base._numberOfTimesCompleted >= _numberOfTimesItNeedsToBeCompleted)
        {
            return base.GetScore() + _bonusPointAmount;
        }
        else
        {
            return base.GetScore();
        }
    }


    public override string GetDisplayString()
    {
        return base.GetDisplayString();
    }
}