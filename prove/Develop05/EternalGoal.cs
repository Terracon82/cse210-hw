using System.Dynamic;
using System.Reflection.Metadata.Ecma335;

class EternalGoal : Goal
{
    static readonly private new string _goalTypeID = "8888";
    override public string GoalTypeID { get { return _goalTypeID; } }
    // protected override string GoalTypeID { get { return "8888"; } }

    protected override string CompletionIcon { get { return "\u25CB"; } }

    public EternalGoal()
    {
        // _goalTypeID = "8888";
        // base.CreateGoal();
    }

    public EternalGoal(Goal goal) : base(goal.GoalID, goal.GoalName, goal.GoalDescription, goal.PointValue, goal.NumberOfTimesCompleted)
    {
        // _goalTypeID = "8888";
    }

    // override public EternalGoal CreateGoal()
    // {
    //     return new EternalGoal(base.CreateGoal());
    // }


    // public override int GetScore()
    // {
    //     return base.GetScore();
    // }


    // public override string GetDisplayString()
    // {
    //     return base.GetDisplayString();
    // }

    // public override string ExportGoal()
    // {
    //     return _goalTypeID + base.ExportGoal();
    // }

    public static new EternalGoal ImportGoal(string goalText
    // , string goalTypeID = ""
    )
    {
        // return new EternalGoal(Goal.ImportGoal(goalText));
        // return Goal.ImportGoal(goalText);
        if (_goalTypeID == goalText.Split(_delimeter)[0])
        {
            // throw new WrongGoalTypeID("Incompatible goalTypeID");

            // goalTypeID = _goalTypeID;
            return new EternalGoal(Goal.ImportGoal(goalText
            // , _goalTypeID
            ));
        }
        else
        {
            return null;
        }
    }
}