namespace CarysCars.PricingEngine.RideSharing;

public class Vehicle
{
    public Location Location { get; } = Location.Random(100, 100);

    public Ride Reserve(Customer customer)
    {
        return new Ride(customer, this);
    }
}