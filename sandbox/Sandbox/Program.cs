using System;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        // The BigInteger may be unnecessary, but it shouldn't hurt.
        // do you have such things as longs in C#? (BigIntegers are immutable in Java, that's why I worried)

        // I don't think so. These are arbitrarily long. So there is no worry of size. Well, only the worry of my hardware.
        // I'm double checking now.
        // Oh, I missed the completion. 

        // Largest starting num: 837799
        // Largest sequence length: 524

        // Is this correct?
        
        long largestStartingNum = 1;
        long largestSequenceLength = 1;

        for (int i = 1; i <= 1000000; i++)
        {
            long myNumber = i;
            long sequenceLength = 0;

            while (myNumber != 1)
            {
                if (myNumber % 2 == 0) { myNumber /= 2; }
                else { myNumber = (myNumber * 3) + 1; }

                sequenceLength += 1;
            } // in programming, this is what we call a staircase.. :) - Keep coding silly

            if (sequenceLength > largestSequenceLength)
            {
                largestSequenceLength = sequenceLength;
                largestStartingNum = i;
            }
        }

        System.Console.WriteLine($"Largest starting num: {largestStartingNum}");
        System.Console.WriteLine($"Largest sequence length: {largestSequenceLength}");
        // c + w + TAB
    } // mine's: s o u t+tab
}