public class Driver
{
    public string Name { get; private set; }
    public string Manufacturer { get; private set; }

    public Driver(string name, string manufacturer)
    {
        Name = name;
        Manufacturer = manufacturer;
    }
}
