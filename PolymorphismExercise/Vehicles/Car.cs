using System;
using System.Reflection;


public class Car : Vehicle
{
    private double condition = 0.9;

    public Car(double fuelQuantity, double consumption, double tankCapasity)
        : base(fuelQuantity, consumption, tankCapasity) { }

    public override void Drive(double km)
    {

        double needFuel = (Consumption + this.condition) * km;
        if (needFuel <= FuelQuantity)
        {
            Console.WriteLine($"{this.GetType()} travelled {km} km");
            FuelQuantity -= needFuel;
        }
        else
        {
            Console.WriteLine($"{this.GetType()} needs refueling");
        }
    }
}

