namespace CarysCars.PricingEngine;

public class Vehicle
{
    public Location Location { get; } = PricingEngine.Location.Random(100, 100);

    public Ride Reserve(Customer customer)
    {
        return new Ride(customer, this);
    }
}