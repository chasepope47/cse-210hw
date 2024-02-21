using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the F1 Race Simulator!");

        // Mock F1 race data
        List<RaceTrack> raceTracks = new List<RaceTrack>
        {
            new RaceTrack("Monaco Grand Prix", 3.337, "Dry", "Street Circuit"),
            new RaceTrack("Silverstone Circuit", 5.891, "Partly Cloudy", "Road Course"),
            new RaceTrack("Circuit de Spa-Francorchamps", 7.004, "Rain", "Road Course")
            // Add more race tracks as needed
        };

        // Mock F1 teams data
        List<Team> teams = new List<Team>
        {
            new Team("Mercedes", "Mercedes"),
            new Team("Red Bull Racing", "Red Bull Racing"),
            new Team("Scuderia Ferrari", "Ferrari")
            // Add more teams with manufacturers as needed
        };

        // Display race track options and get user's choice
        Console.WriteLine("\nSelect a race track:");
        for (int i = 0; i < raceTracks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {raceTracks[i].TrackName}");
        }
        int trackChoice = GetUserChoice(raceTracks.Count);

        // Get user's selected race track
        RaceTrack selectedRaceTrack = raceTracks[trackChoice - 1];

        // Display team options and get user's choice
        Console.WriteLine("\nSelect a team:");
        for (int i = 0; i < teams.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {teams[i].TeamName}");
        }
        int teamChoice = GetUserChoice(teams.Count);

        // Get user's selected team
        Team selectedTeam = teams[teamChoice - 1];

        // Get user's selected drivers for the team
        List<Driver> selectedDrivers = GetDriversForTeam(selectedTeam);

        // Simulate the race
        RaceSimulator raceSimulator = new RaceSimulator();
        RaceResult raceResult = raceSimulator.SimulateRace(selectedRaceTrack, selectedTeam, selectedDrivers);

        // Display the race result
        DisplayRaceResult(raceResult);
    }

    // Method to get user's choice from the given range of options
    private static int GetUserChoice(int maxChoice)
    {
        int choice;
        while (true)
        {
            Console.Write($"Enter your choice (1-{maxChoice}): ");
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= maxChoice)
            {
                break;
            }
            Console.WriteLine("Invalid choice. Please try again.");
        }
        return choice;
    }

    // Method to get user's selected drivers for the team
    private static List<Driver> GetDriversForTeam(Team team)
    {
        List<Driver> drivers = new List<Driver>();

        Console.WriteLine($"\nSelect drivers for {team.TeamName}:");
        for (int i = 0; i < 2; i++) // Assuming each team has 2 drivers
        {
            Console.Write($"Enter Driver {i + 1}'s name: ");
            string driverName = Console.ReadLine();
            drivers.Add(new Driver(driverName, team.Manufacturer));
        }

        return drivers;
    }

    // Method to display the race result
    private static void DisplayRaceResult(RaceResult raceResult)
    {
        Console.WriteLine("\nRace Result:");
        foreach (var team in raceResult.FinishOrder)
        {
            Console.WriteLine($"{team.TeamName} - Position: {raceResult.FinishOrder.IndexOf(team) + 1}");
        }
    }
}
