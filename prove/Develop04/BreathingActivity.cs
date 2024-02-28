class BreathingActivity : MindfulnessActivity
{
    // This is a list of lists. The sublist will have 4 elements: Breathe in duration, hold breath duration, breathe out duration, hold breath duration.
    private List<int> _breathingPattern = new();
    private int _getReadyDuration;
    private int _concludingDuration;

    public BreathingActivity(
        string activityTitle = "Breathing"
        , string activityDescription =
        """
        This activity will help you relax by walking your through breathin in and out slowly. 
        Clear your mind and focus on your breathing.
        """
        , int getReadyDuration = 5
        , int breatheInDuration = 4
        , int HoldBreathDuration = 7
        , int breatheOutDuration = 8
        , int HoldEmptyDuration = 4
        , int concludingDuration = 4
    ) : base(
        activityTitle
        , activityDescription
    )
    {
        _getReadyDuration = getReadyDuration;
        _breathingPattern.Add(breatheInDuration);
        _breathingPattern.Add(HoldBreathDuration);
        _breathingPattern.Add(breatheOutDuration);
        _breathingPattern.Add(HoldEmptyDuration);
        _concludingDuration = concludingDuration;
    }

    public void StartBreathingActivty(duration)
    {
        System.Console.WriteLine("Get ready...");
        IdleAnimation.DisplaySpinner(_getReadyDuration);
    }

    private void DisplayBreatheInCountdown(int duration)
    {
        System.Console.WriteLine("Breathe in...");
        IdleAnimation.DisplayCountdown(duration)
    }

    private void DisplayHoldBreathCountdown(int duration)
    {
        System.Console.WriteLine("Hold breath...");
        IdleAnimation.DisplayCountdown(duration)
    }

    private void DisplayBreatheOutCountdown(int duration)
    {
        System.Console.WriteLine("Breathe out...");
        IdleAnimation.DisplayCountdown(duration)
    }

    private void DisplayHoldEmptyCountdown(int duration)
    {
        System.Console.WriteLine("Hold empty...");
        IdleAnimation.DisplayCountdown(duration)
    }


}