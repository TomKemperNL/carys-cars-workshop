namespace CarysCars.PricingEngine;

public class Reservation
{
    public Agreement Accept()
    {
        this.Status = ReservationStatus.Accepted;
        return new Agreement();
    }

    public ReservationStatus Status { get; private set; } = ReservationStatus.Pending;
}