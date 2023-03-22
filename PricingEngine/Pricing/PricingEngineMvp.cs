using NodaMoney;

namespace CarysCars.PricingEngine.Pricing;

public class PricingEngineMvp : IPricingEngine
{
    public Money CalculatePrice(Duration duration, Money pricePerMinute)
    {
        
        Money result = duration.MultiplyByPricePerMinute(pricePerMinute);

        if (duration.IsOverTime)
        {
            result = Money.Add(new Money(100), result);
        }

        return result;
    }
}