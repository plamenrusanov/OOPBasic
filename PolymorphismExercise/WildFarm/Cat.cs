using System;
using System.Collections.Generic;
using System.Text;

public class Cat : Feline
{
    private string produseSound;
    private List<string> possibleFood;

    public Cat(string name, double weight, string livingRegion, string breed, int foodEaten = 0) 
        : base(name, weight, livingRegion, breed, foodEaten)
    {
        ProduceSound = "Meow";
        PossibleFood = new List<string>()
        {
            "Vegetable",
            "Meat"
        };
    }

    public override string ProduceSound { get => this.produseSound; set => this.produseSound = value; }

    public override List<string> PossibleFood { get => this.possibleFood; set => this.possibleFood = value; }

    public override void IncreaseWeight(int foodQuantity)
    {
        this.Weight += foodQuantity * 0.3;
    }
}
