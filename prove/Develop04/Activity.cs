using System;
using System.Threading;

class Activity
{
    private string name;
    private string description;
    protected int duration;

    public Activity(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    public void StartActivity()
    {
        Console.WriteLine($"Welcome to {name}!\n");
        Console.WriteLine(description);
        SetDuration();
        Console.WriteLine("\nGet ready to begin...");
        ShowSpinner(3);
    }

    private void SetDuration()
    {
        Console.WriteLine();
        Console.Write("Enter the duration of the activity in seconds: ");
        duration = int.Parse(Console.ReadLine());
    }

    public void EndActivity()
    {
        Console.WriteLine("\nGood job! You've completed the activity.");
        Console.WriteLine($"You've spent {duration} seconds on {name}.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        int animationDelay = 200; // milliseconds
        for (int i = 0; i < seconds * 1000 / animationDelay; i++)
        {
            Console.Write("-");
            Thread.Sleep(animationDelay);
            Console.Write("\b");
        }
        Console.WriteLine();
    }

    protected void ShowCountdown(int seconds)
    {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        do
        {
            DateTime currentTime = DateTime.Now;
            Console.Write($"{(endTime - currentTime).TotalSeconds:F0} seconds remaining ");
            Thread.Sleep(500);
            Console.Write("\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b"); // Move the cursor back
        } while (DateTime.Now < endTime);

        Console.WriteLine("Go!");
    }
}
