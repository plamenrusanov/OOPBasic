using System;
using System.Collections.Generic;

public class Pizza
{
    private const int MAX_TOPPINGS = 10;

    private string name;
    private Dough dough;
    private List<Topping> toppings;

    private Pizza()
    {
        Toppings = new List<Topping>();
    }

    public Pizza(string name) : this()
    {
        Name = name;
    }

    public string Name
    {
        get { return name; }
        private set
        {
            if (value.Length < 1 || value.Length > 15)
            {
                throw new ArgumentException($"Pizza name should be between 1 and 15 symbols.");
            }
            name = value;
        }
    }

    private Dough Dough
    {
        get { return dough; }
        set { dough = value; }
    }

    private List<Topping> Toppings
    {
        get { return toppings; }
        set { toppings = value; }
    }

    public void AddDough(string flourType, string bakingTechnique, int weight)
    {
        Dough = new Dough(flourType, bakingTechnique, weight);
    }

    public void AddTopping(string type, int weight)
    {
        if (Toppings.Count > MAX_TOPPINGS)
        {
            throw new ArgumentException($"Number of toppings should be in range [0..{MAX_TOPPINGS}].");
        }
        Topping topping = new Topping(type, weight);
        Toppings.Add(topping);
    }

   public double CalCaloriesPizza()
    {
        double calories = Dough.CalcCaloriesDough();
        foreach (Topping t in toppings)
        {
            calories += t.CalCaloriesTopping();
        }

        return calories;
    }
}

