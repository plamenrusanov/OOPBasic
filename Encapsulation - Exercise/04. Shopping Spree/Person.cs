using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    private string name;

    public string Name
    {
        get { return name; }
        private set
        {
            if (!IsValidName(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            name = value;
        }
    }

    private bool IsValidName(string value)
    {
        if (value == null || value == string.Empty || value == " " )
        {
            return false;
        }
        return true;
    }

    private decimal money;

    public decimal Money
    {
        get { return money; }
        private set
        {
            if (!IsMoneyArePositive(value))
            {
                throw new ArgumentException("Money cannot be negative");
            }
            money = value;
        }
    }

    private bool IsMoneyArePositive(decimal value)
    {
        return value >= 0;
    }

    private List<Product> bag;

    public List<Product> Bag
    {
        get { return bag; }
        set { bag = value; }
    }

    public Person(string name, decimal money)
    {
        Name = name;
        Money = money;
        Bag = new List<Product>();
    }

    public void PersonBuyProduct(Product product)
    {
        if (this.Money < product.Cost)
        {
            Console.WriteLine($"{Name} can't afford {product.Name}");
        }
        else
        {
            Bag.Add(product);
            Money -= product.Cost;
            Console.WriteLine($"{Name} bought {product.Name}");
        }
    }

    public override string ToString()
    {
        if (Bag.Count == 0)
        {
            return $"{Name} - Nothing bought";
        }
        return $"{Name} - {string.Join(", ", Bag)}";
    }
}


