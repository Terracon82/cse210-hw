using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

class MindfulnessActivity
{
    private List<int> _acitvityDurations = new(); // Historical list of durations in seconds

    protected string _activityTitle;
    protected string _activityDescription;
    private int _getReadyDuration;


    public MindfulnessActivity(
        string activityTitle = "Mindfulness"
        , string activityDescription = ""
        , int getReadyDuration = 5
    )
    {
        _getReadyDuration = getReadyDuration;
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

            You have completed another {(int)(_acitvityDurations.Last())} seconds of the {_activityTitle} Activity.
            """
            );
            IdleAnimation.DisplaySpinner(5);
            System.Console.WriteLine();
        }
        else
        {
            System.Console.WriteLine(endingMessage);
        }
    }

    protected void StartMindfulnessActivity(Action<int> Activity)
    {
        DisplayStartMessage();

        System.Console.Write("How long, in seconds, would you like for your session? ");
        int duration = int.Parse(System.Console.ReadLine());
        _acitvityDurations.Add(duration); // Recording for historical purposes

        System.Console.Clear();

        System.Console.WriteLine("Get ready...");
        IdleAnimation.DisplaySpinner(_getReadyDuration);
        // System.Console.Write("\b \b");
        System.Console.WriteLine();

        Activity(duration);

        DisplayEndingMessage();
    }

}