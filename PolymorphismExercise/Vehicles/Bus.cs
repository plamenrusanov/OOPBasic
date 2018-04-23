using System;
using System.Collections.Generic;
using System.Text;

public class Bus : Vehicle
{
    private double condition = 1.4;

    public Bus(double fuelQuantity, double consumption, double tankCapacity)
        : base(fuelQuantity, consumption, tankCapacity) { }

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
