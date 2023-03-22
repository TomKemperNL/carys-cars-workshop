using NodaMoney;

namespace CarysCars.PricingEngine;

public interface IPricingEngine
{
    Money CalculatePrice(Duration duration, Money pricePerMinute);
}
