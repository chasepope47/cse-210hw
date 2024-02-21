public class RaceSimulator
{
    public RaceResult SimulateRace(RaceTrack track, Team team, List<Driver> drivers)
    {
        // Simulation logic
        // This is just a mock implementation for demonstration purposes
        List<Team> finishOrder = new List<Team> { team };
        return new RaceResult(finishOrder);
    }
}
