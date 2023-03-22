using NodaTime;

namespace CarysCars.PricingEngine;

public interface ITimeProvider
{
    LocalDateTime Now { get; }
}