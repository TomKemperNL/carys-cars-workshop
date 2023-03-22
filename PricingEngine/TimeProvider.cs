using NodaTime;

namespace CarysCars.PricingEngine;

public class TimeProvider : ITimeProvider
{
    public static ITimeProvider Instance { get; protected set; } = new TimeProvider();

    protected TimeProvider()
    {
    }

    public virtual LocalDateTime Now => SystemClock.Instance.GetCurrentInstant().InUtc().LocalDateTime;
}