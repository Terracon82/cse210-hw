using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Develop04 World!");

        // IdleAnimation.DisplayCountdown(15);
        // System.Console.WriteLine();
        // IdleAnimation.DisplaySpinner(5);

        BreathingActivity breathingActivity = new();
        // breathingActivity.StartBreathingActivty();

        ReflectionActivity reflectionActivity = new();
        // reflectionActivity.StartReflectionActivity();

        ListingActivity listingActivity = new();
        // listingActivity.StartListingActivity();

        do
        {
            System.Console.Clear();
            System.Console.WriteLine("Menu Options: ");
            System.Console.WriteLine(
                """
                1. Start breathing activity
                2. Start reflecting activity
                3. Start listing activity
                4. Quit
                """
            );
            System.Console.Write("Select a choice from the menu: ");

            string userChoice = System.Console.ReadLine();
            System.Console.WriteLine();

            if (userChoice == "4")
            {
                break;
            }
            else if (userChoice == "1")
            {
                breathingActivity.StartBreathingActivty();
            }
            else if (userChoice == "2")
            {
                reflectionActivity.StartReflectionActivity();
            }
            else if (userChoice == "3")
            {
                listingActivity.StartListingActivity();
            }
            else
            {
                System.Console.WriteLine("Please choose a number.");
                Thread.Sleep(3000);
            }
        } while (true);
    }
}