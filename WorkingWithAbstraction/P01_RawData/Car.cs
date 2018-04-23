using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    private string model;
    private Engine engine;
    private Cargo cargo;
    private List<KeyValuePair<double, int>> tires;

    public Car(string[] parameters)
    {
        Model = parameters[0];
        Engine = new Engine(parameters[2], parameters[1]);
        Cargo = new Cargo(parameters[3], parameters[4]);
        AddTires(parameters);    
    }

    private void AddTires(string[] parameters)
    {
        Tires = new List<KeyValuePair<double, int>>();
        for (int i = 5; i < parameters.Length; i+=2)
        {
            var temp = new KeyValuePair<double, int>(double.Parse(parameters[i]), int.Parse(parameters[i+1]));
            Tires.Add(temp);
        }
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }
    public Engine Engine
    {
        get { return engine; }
        set { engine = value; }
    }
    public Cargo Cargo
    {
        get { return cargo; }
        set { cargo = value; }
    }
    public List<KeyValuePair<double, int>> Tires
    {
        get { return tires; }
        set { tires = value; }
    }
}

