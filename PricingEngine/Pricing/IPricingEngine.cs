using NodaMoney;

namespace CarysCars.PricingEngine.Pricing;

public interface IPricingEngine
{
    Money CalculatePrice(Duration duration, Money pricePerMinute);
}
