using System;
using System.Collections.Generic;
using System.Text;

public class Tiger : Feline
{
    private string produseSound;
    private List<string> possibleFood;

    public Tiger(string name, double weight, string livingRegion, string breed, int foodEaten = 0)
        : base(name, weight, livingRegion, breed, foodEaten)
    {
        ProduceSound = "ROAR!!!";
        PossibleFood = new List<string>()
        {
            "Meat"
        };
    }

    public override string ProduceSound { get => this.produseSound; set => this.produseSound = value; }

    public override List<string> PossibleFood { get => this.possibleFood; set => this.possibleFood = value; }

    public override void IncreaseWeight(int foodQuantity)
    {
        this.Weight += foodQuantity;
    }
}
