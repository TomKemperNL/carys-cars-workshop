namespace CarysCars.PricingEngine;

public class Vehicle
{
    public Location Location { get; } = PricingEngine.Location.Random(100, 100);

    public Reservation Reserve(Customer customer)
    {
        return new Reservation();
    }
}