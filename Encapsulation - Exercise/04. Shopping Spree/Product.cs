using System;
using System.Collections.Generic;
using System.Text;

public class Product
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    private decimal cost;

    public decimal Cost
    {
        get { return cost; }
        set { cost = value; }
    }

    public Product(string name, decimal cost)
    {
        Name = name;
        Cost = cost;
    }

    public override string ToString()
    {
        return Name;
    }
}

