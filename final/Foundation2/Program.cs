using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Foundation2 World!");

        List<Order> orders = CreateOrders(5);

        foreach (Order order in orders)
        {
            System.Console.WriteLine("\nPacking Label: ");
            System.Console.WriteLine(order.PackingLabel);
            System.Console.WriteLine("Shipping Label: ");
            System.Console.WriteLine(order.ShippingLabel);
            System.Console.WriteLine("\nTotal Price: ");
            System.Console.WriteLine(Math.Round(order.TotalPrice, 2));
            System.Console.WriteLine();
            System.Console.WriteLine();
        }
    }

    static List<Product> CreateProducts(int numProducts)
    {
        List<Product> products = new();
        Random random = new();

        for (int i = 1; i <= numProducts; i++)
        {
            products.Add(new Product($"Example ProductID {i}", $"Example product name {i}", (random.NextDouble() * 10) + 2, random.Next(10)));
        }

        return products;
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

    static List<Customer> CreateCustomers(int numCustomers)
    {
        List<Customer> customers = new();

        List<Address> addresses = CreateAddresses(numCustomers);

        for (int i = 0; i < numCustomers; i++)
        {
            customers.Add(new Customer($"Example customer name {i + 1}", addresses[i]));
        }
        return customers;
    }

    static List<Order> CreateOrders(int numOrders)
    {
        List<Order> orders = new();

        List<Customer> customers = CreateCustomers(numOrders);

        for (int i = 0; i < numOrders; i++)
        {
            orders.Add(new Order(CreateProducts(3), customers[i]));
        }

        return orders;
    }
}