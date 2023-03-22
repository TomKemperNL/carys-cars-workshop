using NodaTime;

namespace CarysCars.PricingEngine;

public class FakeTimeProvider : TimeProvider
{
    private static FakeTimeProvider instance = new FakeTimeProvider();

    public new static FakeTimeProvider Instance
    {
        get
        {
            TimeProvider.Instance = instance;
            return instance;
        }
    }

    private LocalDateTime now;
    public override LocalDateTime Now => now;

    public void SetNow(LocalDateTime newTime)
    {
        this.now = newTime;
    }

    public void Advance(int minutes)
    {
        this.now = this.now.PlusMinutes(minutes);
    }
}