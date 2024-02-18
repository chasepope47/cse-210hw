class Program
{
    static void Main(string[] args)
    {
        // Create objects
        RaceTrack track = new RaceTrack("Monaco", 3.337, "Dry");
        Driver driver1 = new Driver("Lewis Hamilton", "British");
        Driver driver2 = new Driver("Max Verstappen", "Dutch");
        List<Driver> drivers = new List<Driver> { driver1, driver2 };
        Team team = new Team("Mercedes", drivers);
        UserInterface ui = new UserInterface();
        DataStorage storage = new DataStorage();

        // Interact with the system
        ui.SimulateRace();
        ui.ManageTeams();
        ui.AnalyzeRaceData();
        storage.SaveData();
        storage.LoadData();
    }
}
