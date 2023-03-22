using NodaMoney;

namespace CarysCars.PricingEngine;

public class Duration
{
    private readonly int minutes;

    private Duration(int minutes)
    {
        this.minutes = minutes;
    }

    public static Duration OfMinutes(int minutes)
    {
        if (minutes < 1)
        {
            throw SorryInvalidDurationProvided.BecauseDurationWasLessThanOneMinute();
        }

        return new Duration(minutes);
    }

    public static Duration FromString(string durationAsText)
    {
        return new Duration(int.Parse(durationAsText));
    }
    
    public Money MultiplyByPricePerMinute(Money pricePerMinute)
    {
        return pricePerMinute * this.minutes;
    } 

    public override string ToString()
    {
        return this.minutes.ToString();
    }

    private bool Equals(Duration other)
    {
        return minutes == other.minutes;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == this.GetType() && Equals((Duration)obj);
    }

    public override int GetHashCode()
    {
        return minutes;
    }
}

public class SorryInvalidDurationProvided : Exception
{
    private SorryInvalidDurationProvided(string message) : base(message)
    {
    }

    public static SorryInvalidDurationProvided BecauseDurationWasLessThanOneMinute()
    {
        return new SorryInvalidDurationProvided("Sorry, Duration should be at least one minute.");
    }
}
