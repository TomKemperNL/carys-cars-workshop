namespace CarysCars.PricingEngine;

public class Customer
{
    public string Name { get; }
    
    public Location Location { get; }

    public Customer(String name)
    {
        this.Name = name;
        this.Location = Location.Random(100, 100);
    }

    public override string ToString()
    {
        return Name.ToString();
    }
}