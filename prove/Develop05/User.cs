class User
{
    private List<Goal> _goals = new();

    private int _totalPoints = 0;

    public void EternalQuest()
    {
        while (true)
        {
            // NOTE: Make this a switch statement

            System.Console.Write(
                $"""
                You have {_totalPoints} points.

                Menu Options:
                    1. Create New Goal
                    2. List Goals
                    3. Save Goals
                    4. Load Goals
                    5. Record Event
                    6. Quit
                Select a choice from the menu: 
                """
            );
            string userInput = System.Console.ReadLine();
            System.Console.WriteLine();

            if (userInput == "6")
            {
                break;
            }
            else if (userInput == "5")
            {

            }
            else if (userInput == "4")
            {

            }
            else if (userInput == "3")
            {

            }
            else if (userInput == "2")
            {

            }
            else if (userInput == "1")
            {
                System.Console.Write(
                    """
                    The types of Goals are:
                        1. Simple Goal
                        2. Eternal Goal
                        3. Checklist Goal
                    Which type of Goal would you like to create? 
                    """
                );
                string goalType = System.Console.ReadLine();
                System.Console.WriteLine();

                if (goalType == "1")
                {

                }
                else if (goalType == "2")
                {

                }
                else if (goalType == "3")
                {

                }
            }

        };
    }
}