using System;
using System.Collections.Generic;
using System.Text;

 public class CarSalesman
{
    
    private string model;
    private string engine;
    private string weight;
    private string color;
    public CarSalesman(string model, string engine, string weight = "n/a", string color = "n/a")
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = weight;
        this.Color = color;
    }
    public string Engine
    {
        get { return engine; }
        set { engine = value; }
    }

    public string Color
    {
        get { return color; }
        set { color = value; }
    }

    public string Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }
    
}

