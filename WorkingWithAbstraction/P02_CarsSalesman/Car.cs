using System;
using System.Collections.Generic;
using System.Text;

class Car
{
    private const string offset = "  ";

    private string model;
    private Engine engine;
    private int weight;
    private string color;
    /*
    public Car(string model, Engine engine)
    {
        this.model = model;
        this.engine = engine;
        this.weight = -1;
        this.color = "n/a";
    }

    public Car(string model, Engine engine, int weight)
    {
        this.model = model;
        this.engine = engine;
        this.weight = weight;
        this.color = "n/a";
    }

    public Car(string model, Engine engine, string color)
    {
        this.model = model;
        this.engine = engine;
        this.weight = -1;
        this.color = color;
    }
    */
    public Car(string model, Engine engine, int weight = -1, string color = "n/a")
    {
        Model = model;
        Engin = engine;
        Weight = weight;
        Color = color;
    }
    public string Model { get; set; }
    public Engine Engin { get; set; }
    public int Weight { get; set; }
    public string Color { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("{0}:\n", Model);
        sb.Append(Engin.ToString());
        sb.AppendFormat("{0}Weight: {1}\n", offset, Weight == -1 ? "n/a" : Weight.ToString());
        sb.AppendFormat("{0}Color: {1}", offset, Color);

        return sb.ToString();
    }
}
