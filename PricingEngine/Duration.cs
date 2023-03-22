using NodaMoney;

namespace CarysCars.PricingEngine;

public class Duration
{
    private int minutes;

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
        return new Duration(Int32.Parse(durationAsText));
    }
    
    public Money MultiplyByPricePerMinute(Money pricePerMinute)
    {
        return pricePerMinute * this.minutes;
    } 

    public override string ToString()
    {
        return this.minutes.ToString();
    }

    public override bool Equals(object? compareTo)
    {
        if (this.GetType().Equals(compareTo.GetType()))
        {
            Duration other = (Duration)compareTo;

            return this.minutes == other.minutes;
        }

        return false;
    }
}
public class SorryInvalidDurationProvided : Exception
{
    public SorryInvalidDurationProvided(string message) : base(message)
    {
    }

    public static SorryInvalidDurationProvided BecauseDurationWasLessThanOneMinute()
    {
        return new SorryInvalidDurationProvided("Sorry, Duration should be at least one minute.");
    }
}
