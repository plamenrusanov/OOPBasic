using System;
using System.Collections.Generic;
using System.Text;

public class Dog : Mammal
{
    private string produseSound;
    private List<string> possibleFood;

    public Dog(string name, double weight, string livingRegion, int foodEaten = 0)
        : base(name, weight, livingRegion, foodEaten)
    {
        ProduceSound = "Woof!";
        PossibleFood = new List<string>()
        {
            "Meat"
        };
    }

    public override string ProduceSound { get => this.produseSound; set => this.produseSound = value; }

    public override List<string> PossibleFood { get => this.possibleFood; set => this.possibleFood = value; }

    public override void IncreaseWeight(int foodQuantity)
    {
        this.Weight += foodQuantity * 0.4;
    }
}
