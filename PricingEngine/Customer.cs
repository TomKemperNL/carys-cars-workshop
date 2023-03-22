namespace CarysCars.PricingEngine;

public class Customer
{
    public string Name { get; }

    public Customer(String name)
    {
        this.Name = name;
    }

    public override string ToString()
    {
        return Name.ToString();
    }
}