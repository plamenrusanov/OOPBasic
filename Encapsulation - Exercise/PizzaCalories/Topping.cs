using System;
using System.Collections.Generic;

internal class Topping
{
    private const int MIN_WEIGHT = 1;
    private const int MAX_WEIGHT = 50;

    private Dictionary<string, double> validToppingType = new Dictionary<string, double>
    {
        ["meat"] =  1.2,
        ["veggies"] = 0.8,
        ["cheese"] =  1.1,
	    ["sauce"] = 0.9
    };

    private string type;
    private int weight;

    public Topping(string type, int weight)
    {
        Type = type;
        Weight = weight;
    }

    private string Type
    {
        get { return type; }
        set
        {
            if (!validToppingType.ContainsKey(value.ToLower()))
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            type = value;
        }
    }
   
    private int Weight
    {
        get { return weight; }
        set
        {
            if (value < MIN_WEIGHT || value > MAX_WEIGHT)
            {
                throw new ArgumentException($"{Type} weight should be in the range [{MIN_WEIGHT}..{MAX_WEIGHT}].");
            }
            weight = value;
        }
    }

    internal double CalCaloriesTopping()
    {
        double typeCoefficient = validToppingType.GetValueOrDefault(Type.ToLower());
        return Math.Round((Weight * 2 * typeCoefficient),2);
    }
}

