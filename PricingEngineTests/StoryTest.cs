using System.Collections.Generic;
using CarysCars.PricingEngine.Pricing;
using CarysCars.PricingEngine.RideSharing;
using NodaMoney;
using NodaTime;

namespace CarysCars.PricingEngine;

/// <summary>
/// Based on https://marijn.huizendveld.com/workshops/carries-cars-ddd-traineeship
/// 
/// </summary>
public class StoryTest
{
    private double pricePerMinute = 0.24;
    private int nrOfVehicles = 300;

    [Fact]
    public void NormalRide()
    {
        FakeTimeProvider.Instance.SetNow(new LocalDateTime(2020, 02, 14, 09, 00));
        Customer tom = new Customer("Tom");
        Fleet fleet = Fleet.createDefault(nrOfVehicles);

        List<Vehicle> availableVehicles = fleet.LocateVehicles(tom);
        Ride ride = availableVehicles[0].Reserve(tom);

        Assert.Equal(RideStatus.Pending, ride.Status);
        //Reach vehicle within 20 minutes:
        FakeTimeProvider.Instance.Advance(10);

        ride.Accept();
        Assert.Equal(RideStatus.Accepted, ride.Status);
        //=> Should we care if the vehicle actually moves? Or is used?
        FakeTimeProvider.Instance.Advance(60);

        ride.ReturnCar();
        Assert.Equal(RideStatus.Completed, ride.Status);

        IPricingEngine engine = new PricingEngineMvp();

        Assert.Equal(new Money(60 * pricePerMinute), engine.CalculatePrice(ride.Duration, new Money(pricePerMinute)));
    }

    [Fact]
    public void RideNotReachedInTime()
    {
        FakeTimeProvider.Instance.SetNow(new LocalDateTime(2020, 02, 14, 09, 00));
        Customer tom = new Customer("Tom");
        Fleet fleet = Fleet.createDefault(nrOfVehicles);

        List<Vehicle> availableVehicles = fleet.LocateVehicles(tom);
        Ride ride = availableVehicles[0].Reserve(tom);

        Assert.Equal(RideStatus.Pending, ride.Status);
        //Can't reach vehicle within 20 minutes:
        FakeTimeProvider.Instance.Advance(30);

        Assert.Throws<ReservationExpiredException>(() => { ride.Accept(); });
    }

    [Fact]
    public void CustomerReturnsCarTooLate()
    {
        FakeTimeProvider.Instance.SetNow(new LocalDateTime(2020, 02, 14, 09, 00));
        Customer tom = new Customer("Tom");
        Fleet fleet = Fleet.createDefault(nrOfVehicles);

        List<Vehicle> availableVehicles = fleet.LocateVehicles(tom);
        Ride ride = availableVehicles[0].Reserve(tom);

        Assert.Equal(RideStatus.Pending, ride.Status);
        //Reach vehicle within 20 minutes:
        FakeTimeProvider.Instance.Advance(10);

        ride.Accept();
        Assert.Equal(RideStatus.Accepted, ride.Status);
        
        FakeTimeProvider.Instance.Advance(300);

        ride.ReturnCar();
        Assert.Equal(RideStatus.Completed, ride.Status);

        IPricingEngine engine = new PricingEngineMvp();

        //Assert some fine
        Assert.Equal(new Money((300 * pricePerMinute) + 100), engine.CalculatePrice(ride.Duration, new Money(pricePerMinute)));
    }

    
    [Fact]
    public void CustomerDrivingCarOutOfArea()
    {
        //Tsja.... Politie notificeren met laatste bekende locatie van de auto
        Assert.True(false);
    }
    
    [Fact]
    public void CustomerNotReturningCarAtAll()
    {
        //Tsja.... Politie notificeren met laatste bekende locatie van de auto
        Assert.True(false);
    }
}