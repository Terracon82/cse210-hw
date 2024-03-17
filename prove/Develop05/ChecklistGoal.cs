class ChecklistGoal : Goal
{
    static readonly private new string _goalTypeID = "5678";
    override public string GoalTypeID { get { return _goalTypeID; } }
    // protected override string GoalTypeID { get { return "5678"; } }

    protected override string CompletionIcon
    {
        get
        {
            if (_numberOfTimesCompleted >= _numberOfTimesItNeedsToBeCompleted)
            {
                return "\u2713";
            }
            else
            {
                return $"{_numberOfTimesCompleted}/{_numberOfTimesItNeedsToBeCompleted}";
            }
        }
        set { }
    }

    int _numberOfTimesItNeedsToBeCompleted = 1;
    int _bonusPointAmount = 0;

    public ChecklistGoal()
    {
        // _goalTypeID = "5678";
        // base.CreateGoal();

        System.Console.Write("How many times does this goal need to be accomplished? ");
        _numberOfTimesItNeedsToBeCompleted = int.Parse(System.Console.ReadLine());
        System.Console.WriteLine();

        System.Console.Write("What is the bonus for completeing the goal? ");
        _bonusPointAmount = int.Parse(System.Console.ReadLine());
        System.Console.WriteLine();
    }

    public ChecklistGoal(Goal goal, int numberOfTimesItNeedsToBeCompleted, int bonusPointAmount) : base(goal.GoalID, goal.GoalName, goal.GoalDescription, goal.PointValue, goal.NumberOfTimesCompleted)
    {
        // _goalTypeID = "5678";
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
        if (_numberOfTimesCompleted >= _numberOfTimesItNeedsToBeCompleted)
        {
            return base.GetScore() + _bonusPointAmount;
        }
        else
        {
            return base.GetScore();
        }
    }

    public override int Accomplishment()
    {
        int pointReward = base.Accomplishment();
        if (_numberOfTimesCompleted >= _numberOfTimesItNeedsToBeCompleted)
        {
            return pointReward + _bonusPointAmount;
        }
        else
        {
            return pointReward;
        }
    }


    // public override string GetDisplayString()
    // {
    //     return base.GetDisplayString();
    // }


    public override string ExportGoal()
    {
        return base.ExportGoal()
        + _delimeter + _numberOfTimesItNeedsToBeCompleted
        + _delimeter + _bonusPointAmount
        ;
    }

    public static new ChecklistGoal ImportGoal(string goalText
    // , string goalTypeID = ""
    )
    { 
        // var debugStrings = goalText.Split(_delimeter);
        if (_goalTypeID == goalText.Split(_delimeter)[0])
        {
            // throw new WrongGoalTypeID("Incompatible goalTypeID");
            // goalTypeID = _goalTypeID;
            return new ChecklistGoal(Goal.ImportGoal(goalText
            // , _goalTypeID
            )
            , int.Parse(goalText.Split(_delimeter)[6])
            , int.Parse(goalText.Split(_delimeter)[7])
            );
        }
        else
        {
            return null;
        }
    }
}