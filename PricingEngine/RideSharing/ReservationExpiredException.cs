namespace CarysCars.PricingEngine.RideSharing;

[Serializable]
public class ReservationExpiredException : Exception
{
    private ReservationExpiredException(String message) : base(message)
    {
    }

    public static ReservationExpiredException TooLate(int byMinutes)
    {
        return new ReservationExpiredException($"Sorry, your reservation expired {byMinutes} minutes ago...");
    }
}