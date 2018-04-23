using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    private const double TankMaxCapacity = 160;

    private int hp;
    private double fuelAmount;
    private Tyre tyre;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        Hp = hp;
        FuelAmount = fuelAmount;
        Tyre = tyre;
    }

    public int Hp
    {
        get { return this.hp; }
        private set { this.hp = value; }
    }

    public double FuelAmount
    {
        get { return this.fuelAmount; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Out of fuel");
            }
            this.fuelAmount = value;
        }
    }

    public Tyre Tyre
    {
        get { return this.tyre; }
        private set { this.tyre = value; }
    }

    public void ReduceFuel(double reduceFuel)
    {
        this.FuelAmount -= reduceFuel;
       
    }

    public void Refull(double liter)
    {
        if (this.FuelAmount + liter > TankMaxCapacity)
        {
            this.FuelAmount = 160;
        }
        else
        {
            this.FuelAmount += liter;
        }
    }

    public void SetNewTyre(Tyre tyre)
    {
        this.Tyre = tyre;
    }
}

