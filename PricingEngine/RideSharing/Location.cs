namespace CarysCars.PricingEngine.RideSharing;

public sealed class Location
{
    public double Latitude { get; }
    public double Longtitude { get; }

    public Location(double lat, double lon)
    {
        this.Latitude = lat;
        this.Longtitude = lon;
    }

    public double DistanceTo(Location other)
    {
        //Note: this is not how any of this works...
        return Math.Sqrt(Math.Pow(this.Latitude - other.Latitude, 2) + Math.Pow(this.Longtitude - other.Longtitude, 2));
    }

    private bool Equals(Location other)
    {
        return Latitude.Equals(other.Latitude) && Longtitude.Equals(other.Longtitude);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Location)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Latitude, Longtitude);
    }

    private static Random random = new Random();

    public static Location Random(double maxLat, double maxLon)
    {
        return new Location(random.NextDouble() * maxLat, random.NextDouble() * maxLon);
    }
}