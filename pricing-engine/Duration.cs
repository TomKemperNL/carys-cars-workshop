namespace pricing_engine;

public class Duration
{
    private int minutes;

    private Duration(int minutes)
    {
        this.minutes = minutes;
    }

    public static Duration ofMinutes(int minutes)
    {
        if (minutes < 1)
        {
            throw new SorryInvalidDurationProvided("Sorry, Duration should be at least one minute.");
        }
        
        return new Duration(minutes);
    }

    public static Duration FromString(string durationAsText)
    {
        return new Duration(Int32.Parse(durationAsText));
    }

    public override string ToString()
    {
        return this.minutes.ToString();
    }

    public override bool Equals(object? compareTo)
    {
        if (this.GetType().Equals(compareTo.GetType()))
        {
            Duration other = (Duration) compareTo;
            
            return this.minutes == other.minutes;
        }

        return false;
    }
}