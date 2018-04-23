using System;
using System.Collections.Generic;
using System.Text;

public class Truck : Vehicle
{
    private double condition = 1.6;

    public Truck(double fuelQuantity, double consumption, double tankCapasity)
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

    public override void ReFull(double lt)
    {
        if (lt <= 0)
        {
            Console.WriteLine("Fuel must be a positive number");
            return;
        }
        if (this.FuelQuantity + lt <= this.TankCapacity)
        {
            this.FuelQuantity += lt * 0.95;
        }
        else
        {
            Console.WriteLine($"Cannot fit {lt} fuel in the tank");
        }  
    }
}

