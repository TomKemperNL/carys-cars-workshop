using NodaMoney;

namespace pricing_engine;

public class PricingEngineTest
{
    [Fact]
    public void calculatePrice_charged_per_minute()
    {
        var pricingEngine = new PricingEngineMvp();

        var duration = Duration.ofMinutes(1);
        var pricePerMinute = Money.Euro(0.30);
        var actual = pricingEngine.CalculatePrice(duration, pricePerMinute);

        var expected = pricePerMinute;
        Assert.Equal(expected, actual);
    }
}