using System;
using System.Collections.Generic;
using System.Text;

public class Owl : Bird
{
    private string produseSound;
    private List<string> possibleFood;

    public Owl(string name, double weight, int foodEaten, double wingSize) 
        : base(name, weight, wingSize, foodEaten)
    {
        ProduceSound = "Hoot Hoot";
        PossibleFood = new List<string>()
        {
            "Meat"
        };
    }

    public override string ProduceSound { get => this.produseSound; set => this.produseSound = value; }

    public override List<string> PossibleFood { get => this.possibleFood; set => this.possibleFood = value; }

    public override void IncreaseWeight(int foodQuantity)
    {
        this.Weight += foodQuantity * 0.25;
    }
}
