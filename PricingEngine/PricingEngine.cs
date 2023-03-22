using NodaMoney;

namespace CarysCars.PricingEngine;

public interface PricingEngine
{
    Money CalculatePrice(Duration duration, Money pricePerMinute);
}
