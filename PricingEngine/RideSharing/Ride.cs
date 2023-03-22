using NodaTime;

namespace CarysCars.PricingEngine.RideSharing;

public class Ride
{
    public const double MaxReservationMinutes = 20;

    public Ride(Customer customer, Vehicle vehicle)
    {
        this.Customer = customer;
        this.Vehicle = vehicle;
        this.Status = RideStatus.Pending;
        this.ReservedTime = TimeProvider.Instance.Now;
    }

    public void Accept()
    {
        LocalDateTime now = TimeProvider.Instance.Now;

        double nrOfMinutesPassed = now.Minus(ReservedTime).ToDuration().TotalMinutes;
        if (nrOfMinutesPassed > MaxReservationMinutes)
        {
            throw ReservationExpiredException.TooLate((int)nrOfMinutesPassed);
        }
        this.StartTime = now;
        this.Status = RideStatus.Accepted;
    }

    public Vehicle Vehicle { get; }
    public Customer Customer { get; }

    private LocalDateTime ReservedTime { get; }
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