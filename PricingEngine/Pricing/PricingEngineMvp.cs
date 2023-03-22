using NodaMoney;

namespace CarysCars.PricingEngine.Pricing;

public class PricingEngineMvp : IPricingEngine
{
    public Money CalculatePrice(Duration duration, Money pricePerMinute)
    {
        return duration.MultiplyByPricePerMinute(pricePerMinute);
    }
}