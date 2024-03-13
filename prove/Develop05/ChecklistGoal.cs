class ChecklistGoal : Goal
{
    int _numberOfTimesItNeedsToBeCompleted = 1;
    int _bonusPointAmount = 0;

    public ChecklistGoal(Goal goal, int numberOfTimesItNeedsToBeCompleted, int bonusPointAmount) : base(goal.GoalName, goal.GoalDescription, goal.PointValue)
    {
        _numberOfTimesItNeedsToBeCompleted = numberOfTimesItNeedsToBeCompleted;
        _bonusPointAmount = bonusPointAmount;
    }

    override public ChecklistGoal CreateGoal()
    {
        Goal goal = base.CreateGoal();

        System.Console.Write("How many times does this goal need to be accomplished? ");
        int numberOfTimesItNeedsToBeCompleted = int.Parse(System.Console.ReadLine());
        System.Console.WriteLine();

        System.Console.Write("What is the bonus for completeing the goal? ");
        int bonusPointAmount = int.Parse(System.Console.ReadLine());
        System.Console.WriteLine();

        return new ChecklistGoal(goal, numberOfTimesItNeedsToBeCompleted, bonusPointAmount);
    }

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