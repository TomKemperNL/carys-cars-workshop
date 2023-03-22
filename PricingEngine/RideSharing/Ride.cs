using NodaTime;

namespace CarysCars.PricingEngine.RideSharing;

public class Ride
{
    public Ride(Customer customer, Vehicle vehicle)
    {
        this.Customer = customer;
        this.Vehicle = vehicle;
        this.Status = RideStatus.Pending;
    }

    public void Accept()
    {
        this.StartTime = TimeProvider.Instance.Now;
        this.Status = RideStatus.Accepted;
    }

    public Vehicle Vehicle { get; private set; }
    public Customer Customer { get; private set; }
    private LocalDateTime StartTime { get; set; }
    private LocalDateTime EndTime { get; set; }
    public RideStatus Status { get; private set; }

    public Duration Duration
    {
        get
        {
            Period period = this.EndTime.Minus(this.StartTime);
            
            return Duration.OfMinutes((int)period.ToDuration().TotalMinutes);
        }
    }

    public void ReturnCar()
    {
        this.EndTime = TimeProvider.Instance.Now;
        this.Status = RideStatus.Completed;
    }
}