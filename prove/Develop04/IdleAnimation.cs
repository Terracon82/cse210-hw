static class IdleAnimation
{
    static public void DisplaySpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            System.Console.Write("|");
            Thread.Sleep(250);
            System.Console.Write("\b \b");

            System.Console.Write("/");
            Thread.Sleep(250);
            System.Console.Write("\b \b");

            System.Console.Write("-");
            Thread.Sleep(250);
            System.Console.Write("\b \b");

            System.Console.Write("\\");
            Thread.Sleep(250);
            System.Console.Write("\b \b");
        }
    }

    static public void DisplayCountdown(int seconds)
    {
        for (int i = seconds; i > seconds; i--)
        {
            System.Console.Write(i);
            Thread.Sleep(1000);
            System.Console.Write("\b \b");
        }
    }


}