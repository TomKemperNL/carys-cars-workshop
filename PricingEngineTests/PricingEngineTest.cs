using CarysCars.PricingEngine.Pricing;
using NodaMoney;

namespace CarysCars.PricingEngine;

public class PricingEngineTest
{
    [Fact]
    public void CalculatePrice_charged_per_minute()
    {
        IPricingEngine pricingEngine = new PricingEngineMvp();

        var duration = Duration.OfMinutes(1);
        var pricePerMinute = Money.Euro(0.30);
        var actual = pricingEngine.CalculatePrice(duration, pricePerMinute);

        Assert.Equal(pricePerMinute, actual);
    }
}