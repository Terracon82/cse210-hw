using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

class MindfulnessActivity
{
    private List<int> _acitvityDurations = new(); // In seconds

    protected string _activityTitle;
    protected string _activityDescription;


    public MindfulnessActivity(
        string activityTitle = "Mindfulness"
        , string activityDescription = ""
    )
    {
        _activityTitle = activityTitle;
        _activityDescription = activityDescription;

    }
    public void DisplayStartMessage(string startingMessage = "")
    {
        if (startingMessage == "")
        {
            System.Console.WriteLine(
                $"""
                Welcome to the {_activityTitle} Activity!

                {_activityDescription}
                """
                );
        }
        else
        {
            System.Console.WriteLine(startingMessage);
        }
    }

    public void DisplayEndingMessage(string endingMessage = "")
    {
        if (endingMessage == "")
        {
            System.Console.WriteLine(
            $"""
            Well done!

            You have completed another {(int)(_acitvityDurations.Last() * 1000)} seconds of the {_activityTitle} Activity.
            """
            );
        }
        else
        {
            System.Console.WriteLine(endingMessage);
        }
    }

    public void StartMindfulnessActivity(Action<int> Activity)
    {
        DisplayStartMessage();

        System.Console.Write("How long, in seconds, would you like for your session? ");
        int duration = int.Parse(System.Console.ReadLine());

        _acitvityDurations.Add(duration);

        Activity(duration);

        DisplayEndingMessage();
    }

}