using System;

class Program
{
    static void Main(string[] args)
    {
        bool playAgain = false;
        do
        {
            Random randomNumberGenerator = new Random();
            int magicNumber = randomNumberGenerator.Next(1, 11);

            bool answerCorrect = false;
            int attemptNumber = 0;
            while (!answerCorrect)
            {
                Console.Write("What is your guess? ");
                int numberGuess = int.Parse(Console.ReadLine());
                attemptNumber++;

                if (numberGuess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (numberGuess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else if (numberGuess == magicNumber)
                {
                    // Console.WriteLine("You guessed it!");
                    answerCorrect = true;
                    if (attemptNumber > 1)
                    {
                        Console.WriteLine($"You guessed it in {attemptNumber} attempts!");
                    }
                    else if (attemptNumber == 1)
                    {
                        Console.WriteLine($"You guessed it in {attemptNumber} attempt!");
                    }
                }


            }

            Console.Write("Play again? (y/n) ");
            string playAgainResponse = Console.ReadLine();
            if (playAgainResponse == "y")
            {
                playAgain = true;
            }
            else
            {
                playAgain = false;
            }

        } while (playAgain);


    }
}