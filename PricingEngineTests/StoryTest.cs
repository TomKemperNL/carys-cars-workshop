using System.Collections.Generic;
using NodaMoney;
using NodaTime;

namespace CarysCars.PricingEngine;

/// <summary>
/// Based on https://marijn.huizendveld.com/workshops/carries-cars-ddd-traineeship
/// 
/// </summary>
public class StoryTest
{
    [Fact]
    public void normalRide()
    {
        double pricePerMinute = 0.24;
        int nrOfVehicles = 300;
        
        FakeTimeProvider.Instance.SetNow(new LocalDateTime(2020, 02, 14, 09, 00));
        Customer tom = new Customer("Tom");
        Fleet fleet = Fleet.createDefault(nrOfVehicles);

        List<Vehicle> availableVehicles = fleet.LocateVehicles(tom);
        Reservation pending = availableVehicles[0].Reserve(tom);
        //Reach vehicle within 20 minutes:
        FakeTimeProvider.Instance.Advance(10);

        Agreement agreed = pending.Accept();
        //=> Should we care if the vehicle actually moves? Or is used?
        FakeTimeProvider.Instance.Advance(60);

        agreed.ReturnCar();

        Assert.Equal(ReservationStatus.Accepted, pending.Status);
        Assert.Equal(AgreementStatus.Completed, agreed.Status);
        Assert.Equal(new Money(60 * 0.24), agreed.AmountDue);
    }
    
    
}