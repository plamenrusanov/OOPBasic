using System;
using System.Collections.Generic;
using System.Text;

public class Mouse : Mammal
{
    private string produseSound;
    private List<string> possibleFood;

    public Mouse(string name, double weight, string livingRegion, int foodEaten = 0)
        : base(name, weight, livingRegion, foodEaten)
    {
        ProduceSound = "Squeak";
        PossibleFood = new List<string>()
        {
            "Vegetable",
            "Fruit"
        };
    }

    public override string ProduceSound { get => this.produseSound; set => this.produseSound = value; }

    public override List<string> PossibleFood { get => this.possibleFood; set => this.possibleFood = value; }

    public override void IncreaseWeight(int foodQuantity)
    {
        this.Weight += foodQuantity * 0.1;
    }
}
