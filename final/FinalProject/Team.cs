using System.Collections.Generic;

public class Team
{
    public string TeamName { get; set; }
    public List<Driver> Drivers { get; set; }

    public Team(string teamName, List<Driver> drivers)
    {
        TeamName = teamName;
        Drivers = drivers;
    }

    public void TeamStats()
    {
        // Implementation
    }
}
