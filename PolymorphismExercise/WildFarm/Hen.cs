using System;
using System.Collections.Generic;
using System.Text;

public class Hen : Bird
{
    private string produseSound;
    private List<string> possibleFood;

    public Hen(string name, double weight, int foodEaten, double wingSize)
        : base(name, weight, wingSize, foodEaten)
    {
        ProduceSound = "Cluck";
        PossibleFood = new List<string>()
        {
            "Meat",
            "Fruit",
            "Seeds",
            "Vegetable"
        };
    }

    public override string ProduceSound
    {
        get => this.produseSound;
        set
        {
            this.produseSound = value;
        }
    }

    public override List<string> PossibleFood { get => this.possibleFood; set => this.possibleFood = value; }

    public override void IncreaseWeight(int foodQuantity)
    {
        this.Weight += foodQuantity * 0.35;
    }
}
