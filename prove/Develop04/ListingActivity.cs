using System.Transactions;

class ListingActivity : MindfulnessActivity
{
    private List<string> _prompts = new() {
        "Who are people that you appreciate?"
        , "What are personal strengths of yours?"
        , "Who are people that you have helped this week?"
        , "When have you felt the Holy Ghost this month?"
        , "Who are some of your personal heroes?"
        };

    private List<string> _responses = new();

    public ListingActivity(
        string activityTitle = "Listing"
        , string activityDescription = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."
    ) : base(
        activityTitle
        , activityDescription

    )
    {

    }

    private void DoListingActivity(int duration)
    {
        Random random = new();

        System.Console.WriteLine("List as many responses as you can to the following prompt:");
        System.Console.WriteLine($" --- {_prompts[random.Next(0, _prompts.Count)]} --- ");

        System.Console.Write("You may begin in: ");
        IdleAnimation.DisplayCountdown(5);
        System.Console.WriteLine();

        DateTime startTime = DateTime.Now;

        do
        {
            System.Console.Write("> ");
            _responses.Add(System.Console.ReadLine());

            if ((int)(DateTime.Now - startTime).TotalSeconds >= duration)
            {
                break;
            }
        } while (true);

        System.Console.WriteLine($"You listed {_responses.Count} items!");
        System.Console.WriteLine();

    }

    public void StartListingActivity()
    {
        base.StartMindfulnessActivity(DoListingActivity);
    }
}