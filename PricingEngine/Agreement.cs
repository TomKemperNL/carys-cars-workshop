using NodaMoney;

namespace CarysCars.PricingEngine;

public class Agreement
{
    public void ReturnCar()
    {
        this.Status = AgreementStatus.Completed;
    }

    public AgreementStatus Status { get; private set; }
    public Money AmountDue { get; }
}