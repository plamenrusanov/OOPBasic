using System;
using System.Collections.Generic;
using System.Text;

public abstract class Bird : Animal
{
    private double wingSize;

    public Bird(string name, double weight, double wingSize, int foodEaten)
        : base(name, weight, foodEaten)
    {
        this.WingSize = wingSize;
    }

    public double WingSize
    {
        get { return wingSize; }
        set { wingSize = value; }
    }

    public override string ToString()
    {
        return $"{GetType()} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
    }
}
