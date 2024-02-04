using System;

class ListingActivity : Activity
{
    private string[] prompts;

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        prompts = new string[] {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void DoListingActivity()
    {
        StartActivity();
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Length)];

        Console.WriteLine(prompt);
        Console.WriteLine("You have several seconds to think about the prompt...");
        ShowSpinner(5);

        Console.WriteLine("Start listing items:");

        for (int i = 0; i < duration; i++)
        {
            Console.Write("Item: ");
            string item = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(item))
            {
                break;
            }
        }

        Console.WriteLine($"You listed {duration} items.");
        EndActivity();
    }
}
