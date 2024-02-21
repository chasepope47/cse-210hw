public class Car
{
    public string Model { get; private set; }
    public string Manufacturer { get; private set; }
    public string TireSupplier { get; private set; }

    public Car(string model, string manufacturer, string tireSupplier)
    {
        Model = model;
        Manufacturer = manufacturer;
        TireSupplier = tireSupplier;
    }
}
