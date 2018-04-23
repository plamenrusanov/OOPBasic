using System;
using System.Collections.Generic;
using System.Text;

public abstract class Mammal : Animal
{
    private string livingRegion;

    public Mammal(string name, double weight, string livingRegion, int foodEaten = 0)
        : base(name, weight, foodEaten)
    {
        this.LivingRegion = livingRegion;
    }

    public string LivingRegion
    {
        get { return livingRegion; }
        set { livingRegion = value; }
    }

    public override string ToString()
    {
        return $"{GetType()} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }

}
