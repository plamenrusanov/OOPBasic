using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

public abstract class Vehicle
{
    private double condition;
    private double fuelQuantity;
    private double consumation;
    private double tankCapasity;

    public Vehicle(double fuelQuantity, double consumption, double tankCapacity)
    {
        TankCapacity = tankCapacity;
        FuelQuantity = fuelQuantity;
        Consumption = consumption;   
    }

    public double FuelQuantity
    {
        get { return fuelQuantity; }
        set
        {
            if (value > TankCapacity)
            {
                value = 0;
            }
            fuelQuantity = value;
        }
    }

    public double Consumption
    {
        get { return consumation; }
        set { consumation = value; }
    }

    public double TankCapacity
    {
        get { return tankCapasity; }
        set { tankCapasity = value; }
    }


    public virtual void Drive(double km)
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

    public virtual void ReFull(double lt)
    {
        if (lt <= 0)
        {
            Console.WriteLine("Fuel must be a positive number");
            return;
        }
        if (this.FuelQuantity + lt <= this.TankCapacity)
        {
            this.FuelQuantity += lt;
        }
        else
        {
            Console.WriteLine($"Cannot fit {lt} fuel in the tank");
        }
    }

    public virtual void DriveEmpty(double km)
    {
        double needFuel = Consumption * km;
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

