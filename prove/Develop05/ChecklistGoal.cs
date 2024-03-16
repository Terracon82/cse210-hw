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

    public ChecklistGoal(Goal goal, int numberOfTimesItNeedsToBeCompleted, int bonusPointAmount) : base(goal.GoalName, goal.GoalDescription, goal.PointValue, goal.NumberOfTimesCompleted)
    { 
        _numberOfTimesItNeedsToBeCompleted = numberOfTimesItNeedsToBeCompleted;
        _bonusPointAmount = bonusPointAmount;
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

    public override string ExportGoal()
    {
        return _goalTypeID 
        + base.ExportGoal() + _delimeter
        + _numberOfTimesItNeedsToBeCompleted + _delimeter
        + _bonusPointAmount
        ;
    }

    public static new ChecklistGoal ImportGoal(string goalText
    // , string goalTypeID = ""
    )
    {
        if (_goalTypeID == goalText.Split(_delimeter)[0])
        {
            // throw new WrongGoalTypeID("Incompatible goalTypeID");
        // goalTypeID = _goalTypeID;
        return new ChecklistGoal(Goal.ImportGoal(goalText
        // , _goalTypeID
        )
        , int.Parse(goalText.Split(_delimeter)[5])
        , int.Parse(goalText.Split(_delimeter)[6])
        );
        }  
        else 
        {
            return null;
        }      
    }    
}