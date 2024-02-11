using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    private static List<Goal> goals = new List<Goal>();
    private static int score = 0;

    static void Main(string[] args)
    {
        LoadGoals(); // Load goals from file, if available

        while (true)
        {
            DisplaySavedGoals();
            Console.WriteLine($"You have {score} points\n");
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        CreateNewGoal();
                        break;
                    case 2:
                        ListGoals();
                        break;
                    case 3:
                        SaveGoals();
                        break;
                    case 4:
                        LoadGoals();
                        break;
                    case 5:
                        RecordEvent();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Please select a number between 1 and 6.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid choice! Please enter a valid number.");
            }

            Console.WriteLine();
        }
    }

    // Method to create a new goal
    static void CreateNewGoal()
    {
        Console.Write("Enter the title of the goal: ");
        string title = Console.ReadLine();

        Console.Write("Enter the description of the goal: ");
        string description = Console.ReadLine();

        Console.Write("Enter the points for the goal: ");
        int points;
        if (!int.TryParse(Console.ReadLine(), out points))
        {
            Console.WriteLine("Invalid points value! Please enter an integer.");
            return;
        }

        goals.Add(new SimpleGoal(title, description, points));
        Console.WriteLine("Goal created successfully.");
    }

    // Method to list goals
    static void ListGoals()
    {
        foreach (var goal in goals)
        {
            Console.WriteLine(goal.DisplayDetails());
        }
    }

    // Method to save goals to file
    static void SaveGoals()
    {
        try
        {
            string json = JsonSerializer.Serialize(goals);
            File.WriteAllText("goals.json", json);
            Console.WriteLine("Goals saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }

   // Method to load goals from file
    static void LoadGoals()
    {
       try
       {
           if (File.Exists("goals.json"))
           {
               string json = File.ReadAllText("goals.json");
               List<Goal> loadedGoals = JsonSerializer.Deserialize<List<Goal>>(json);
    
               // Filter out completed goals
               goals = loadedGoals.Where(g => !g.Completed).ToList();
    
               Console.WriteLine("Goals loaded successfully.");
           }
           else
           {
               Console.WriteLine("No saved goals found.");
           }
       }
       catch (Exception ex)
       {
           Console.WriteLine($"Error loading goals: {ex.Message}");
       }
    }

    // Method to record an event and update score
    static void RecordEvent()
    {
        Console.WriteLine("Select the goal you have completed:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Title}");
        }

        int choice;
        if (int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice <= goals.Count)
        {
            Goal goal = goals[choice - 1];
            goal.Complete();
            score += goal.GetPoints();

            Console.Write("Do you want to erase this goal from the list? (Y/N): ");
            string eraseChoice = Console.ReadLine().Trim().ToUpper();

            if (eraseChoice == "Y")
            {
                goals.RemoveAt(choice - 1); // Remove the completed goal from the list
                Console.WriteLine("Goal erased from the list.");
            }
            else
            {
                Console.WriteLine("Event recorded successfully.");
            }
        }
        else
        {
            Console.WriteLine("Invalid choice! Please select a valid goal.");
        }
    }


    // Method to display saved goals
    static void DisplaySavedGoals()
    {
        if (goals.Count > 0)
        {
            Console.WriteLine("Saved Goals:");
            foreach (var goal in goals)
            {
                Console.WriteLine(goal.DisplayStatus());
            }
            Console.WriteLine();
        }
    }


// Define Goal class and its derivatives here...

class Goal
{
    public string Title { get; protected set; }
    public string Description { get; protected set; }
    public int Points { get; protected set; }
    public bool Completed { get; protected set; }

    public Goal(string title, string description, int points)
    {
        Title = title;
        Description = description;
        Points = points;
        Completed = false;
    }

    public virtual void Complete()
    {
        Completed = true;
    }

    public virtual string DisplayStatus()
    {
        return $"{Title}: {(Completed ? "Completed" : "Not Completed")} ({Points} points)";
    }

    public virtual string DisplayDetails()
    {
        return $"{Title}: {(Completed ? "Completed" : "Not Completed")} - {Description} ({Points} points)";
    }

    public virtual int GetPoints()
    {
        return Completed ? Points : 0;
    }
}

class SimpleGoal : Goal
    {
        public SimpleGoal(string title, string description, int points) : base(title, description, points)
        {
        }
    }

    class EternalGoal : Goal
    {
        public EternalGoal(string title, string description, int points) : base(title, description, points)
        {
        }
    }

    class ChecklistGoal : Goal
    {
        public ChecklistGoal(string title, string description, int points) : base(title, description, points)
        {
        }
    }
}
