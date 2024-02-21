public class Team
{
    public string TeamName { get; private set; }
    public string Manufacturer { get; private set; }

    public Team(string teamName, string manufacturer)
    {
        TeamName = teamName;
        Manufacturer = manufacturer;
    }
}
