namespace CarysCars.PricingEngine;

public class DurationTest
{
    [Fact]
    public void Is_at_least_one_minute()
    {
        var thrown = Assert.Throws<SorryInvalidDurationProvided>(() =>
        {
            const int lessThan1 = 0;

            return Duration.OfMinutes(lessThan1);
        });

        Assert.Equal("Sorry, Duration should be at least one minute.", thrown.Message);
    }

    [Fact]
    public void Converts_from_and_to_text()
    {
        var someDuration = Duration.OfMinutes(3);

        Assert.Equal(someDuration, Duration.FromString(someDuration.ToString()));
    }
}