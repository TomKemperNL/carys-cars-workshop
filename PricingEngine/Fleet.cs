namespace CarysCars.PricingEngine;

public class Fleet
{
    public static Fleet createDefault(int nrOfVehicles)
    {
        Fleet newOne = new Fleet();
        for (int i = 0; i < nrOfVehicles; i++)
        {
            newOne.Vehicles.Add(new Vehicle());
        }

        return newOne;
    }


    public List<Vehicle> LocateVehicles(Customer customer)
    {
        return this.Vehicles.OrderBy(v => v.Location.DistanceTo(customer.Location)).Take(10).ToList();
    }
    
    public List<Vehicle> Vehicles { get; private set; } = new List<Vehicle>();
}