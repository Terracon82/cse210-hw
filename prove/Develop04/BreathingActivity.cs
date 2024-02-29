class BreathingActivity : MindfulnessActivity
{
    // This is a list of lists. The sublist will have 4 elements: Breathe in duration, hold breath duration, breathe out duration, hold breath duration.
    private List<int> _breathingPattern = new();
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
        , getReadyDuration
    )
    {
        _breathingPattern.Add(breatheInDuration);
        _breathingPattern.Add(HoldBreathDuration);
        _breathingPattern.Add(breatheOutDuration);
        _breathingPattern.Add(HoldEmptyDuration);
        _concludingDuration = concludingDuration;
    }

    private void DoBreathingActivty(int duration)
    {
        int iterations = (int)(((double)duration / (double)_breathingPattern.Sum()) + 0.5);
        int iterationCount = 0;

        do
        {
            DisplayBreatheInCountdown(_breathingPattern[0]);
            DisplayHoldBreathCountdown(_breathingPattern[1]);
            DisplayBreatheOutCountdown(_breathingPattern[2]);
            DisplayHoldEmptyCountdown(_breathingPattern[3]);
            System.Console.WriteLine();

            iterationCount++;
        } while (iterationCount < iterations);
    }

    public void StartBreathingActivty()
    {
        base.StartMindfulnessActivity(DoBreathingActivty);
    }

    private void DisplayBreatheInCountdown(int duration)
    {
        System.Console.Write("Breathe in...");
        IdleAnimation.DisplayCountdown(duration);
        System.Console.WriteLine();
    }

    private void DisplayHoldBreathCountdown(int duration)
    {
        System.Console.Write("Hold breath...");
        IdleAnimation.DisplayCountdown(duration);
        System.Console.WriteLine();
    }

    private void DisplayBreatheOutCountdown(int duration)
    {
        System.Console.Write("Breathe out...");
        IdleAnimation.DisplayCountdown(duration);
        System.Console.WriteLine();
    }

    private void DisplayHoldEmptyCountdown(int duration)
    {
        System.Console.Write("Hold empty...");
        IdleAnimation.DisplayCountdown(duration);
        System.Console.WriteLine();
    }


}