using System;
using System.Collections.Generic;
using System.Text;
public abstract class Animal
{
    private string name;
    private double weight;
    private int foodEaten;
    private string produceSound;
    

    public Animal(string name, double weight, int foodEaten = 0)
    {
        Name = name;
        Weight = weight;
        FoodEaten = foodEaten;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public double Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    public int FoodEaten
    {
        get { return foodEaten; }
        set { foodEaten = value; }
    }

    public virtual string ProduceSound
    {
        get { return produceSound; }
        set { produceSound = value; }
    }

    public virtual List<string> PossibleFood { get; set; }
   
    public virtual void IncreaseWeight(int foodQuantity)
    {

    }

}
