using System.Runtime.CompilerServices;

class ReflectionActivity : MindfulnessActivity
{
    private List<string> _prompts = new() {
        "Who are people that you appreciate?"
        ,"What are personal strengths of yours?"
        ,"Who are people that you have helped this week?"
        ,"When have you felt the Holy Ghost this month?"
        ,"Who are some of your personal heroes?"
    };

    private List<string> _questions = new() {
        "Why was this experience meaningful to you?"
        ,"Have you ever done anything like this before?"
        ,"How did you get started?"
        ,"How did you feel when it was complete?"
        ,"What made this time different than other times when you were not as successful?"
        ,"What is your favorite thing about this experience?"
        ,"What could you learn from this experience that applies to other situations?"
        ,"What did you learn about yourself through this experience?"
        ,"How can you keep this experience in mind in the future?"
    };

    private int _reflectionDuration;

    public ReflectionActivity(
        string activityTitle = "Reflection"
        , string activityDescription = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life."
        , int reflectionDuration = 12
    ) : base(
        activityTitle
        , activityDescription
    )
    {
        _reflectionDuration = reflectionDuration;
    }

    private void DoReflectionActivity(int duration)
    {
        Random random = new();

        System.Console.WriteLine("Consider the following prompt:");
        System.Console.WriteLine();
        System.Console.WriteLine($" --- {_prompts[random.Next(0, _prompts.Count)]} --- ");
        System.Console.WriteLine();

        System.Console.WriteLine("When you have something in mind, press enter to continue.");
        System.Console.ReadLine();

        System.Console.WriteLine("Now ponder on each of the following questions as they related to this experince.");
        System.Console.Write("You may begin in: ");
        IdleAnimation.DisplayCountdown(5);

        System.Console.Clear();


        int iterations = (int)(((double)duration / (double)_reflectionDuration) + 0.5);
        int iterationCount = 0;

        do
        {
            System.Console.Write($"{_questions[random.Next(0, _questions.Count)]} ");
            IdleAnimation.DisplaySpinner(12);
            System.Console.WriteLine();
            
            iterationCount++;
        } while (iterationCount < iterations);
    }

    public void StartReflectionActivity()
    {
        base.StartMindfulnessActivity(DoReflectionActivity);
    }
}