using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Foundation3 World!");

        List<Address> addresses = CreateAddresses(3);

        List<Event> events = new()
        {
            new Lecture("Example Lecture Title", "This is very descriptive lecture.", "Sometime before yesterday and after tomorrow", "High noon", addresses[0], "The wise old man found on the side of the road.", 7)
            , new Reception("Example Reception Title", "This is very descriptive lecture.", "Sometime before yesterday and after tomorrow", "High noon", addresses[1], "FakeEmail@notmail.com")
            , new Outdoor("Example Lecture Title", "This is very descriptive lecture.", "Sometime before yesterday and after tomorrow", "High noon", addresses[2], "Spicy air, aka RADIATION")
        };

        foreach (Event myEvent in events)
        {
            System.Console.WriteLine("Details:");
            System.Console.WriteLine(myEvent.Details);
            System.Console.WriteLine();

            System.Console.WriteLine("Full Details:");
            System.Console.WriteLine(myEvent.FullDetails);
            System.Console.WriteLine();

            System.Console.WriteLine("Short Description:");
            System.Console.WriteLine(myEvent.ShortDescription);
            System.Console.WriteLine();

            System.Console.WriteLine("\n");
        }
    }

    static List<Address> CreateAddresses(int numAddresses)
    {
        List<Address> addresses = new();
        Random random = new();

        for (int i = 1; i <= numAddresses; i++)
        {
            string country = "";
            if (random.NextDouble() >= 0.5)
            {
                country = "USA";
            }
            else
            {
                country = "NotUSA";
            }

            addresses.Add(new Address($"Example street address {i}", $"Example city {i}", $"Example state {i}", country));
        }

        return addresses;
    }
}