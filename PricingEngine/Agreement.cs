using NodaMoney;

namespace CarysCars.PricingEngine;

public class Agreement
{
    public void ReturnCar()
    {
        throw new NotImplementedException();
    }

    public AgreementStatus Status { get; }
    public Money AmountDue { get; }
}