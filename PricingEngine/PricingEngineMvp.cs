using NodaMoney;

namespace CarysCars.PricingEngine;

public class PricingEngineMvp : PricingEngine
{
    public Money CalculatePrice(Duration duration, Money pricePerMinute)
    {
        return duration.MultiplyByPricePerMinute(pricePerMinute);
    }
}