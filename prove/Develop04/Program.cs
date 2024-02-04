using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Mindfulness App!");

        bool exitRequested = false;

        do
        {
            Console.Clear(); // Clear the terminal
            Console.WriteLine("\nChoose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice (1-4): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PerformBreathingActivity();
                    break;
                case "2":
                    PerformReflectionActivity();
                    break;
                case "3":
                    PerformListingActivity();
                    break;
                case "4":
                    exitRequested = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                    break;
            }

        } while (!exitRequested);

        Console.WriteLine("Thank you for using the Mindfulness App!");
    }

    static void PerformBreathingActivity()
    {
        Console.Clear(); // Clear the terminal
        BreathingActivity breathingActivity = new BreathingActivity();
        breathingActivity.DoBreathingActivity();
    }

    static void PerformReflectionActivity()
    {
        Console.Clear(); // Clear the terminal
        ReflectionActivity reflectionActivity = new ReflectionActivity();
        reflectionActivity.DoReflectionActivity();
    }

    static void PerformListingActivity()
    {
        Console.Clear(); // Clear the terminal
        ListingActivity listingActivity = new ListingActivity();
        listingActivity.DoListingActivity();
    }
}
