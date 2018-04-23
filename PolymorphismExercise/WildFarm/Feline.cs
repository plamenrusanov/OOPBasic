using System;
using System.Collections.Generic;
using System.Text;

public abstract class Feline : Mammal
{
    private string breed;

    public Feline(string name, double weight, string livingRegion, string breed, int foodEaten = 0) 
        : base(name, weight, livingRegion, foodEaten)
    {
        this.Breed = breed;
    }

    public string Breed
    {
        get { return breed; }
        set { breed = value; }
    }

    public override string ToString()
    {
        return $"{GetType()} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }

}
