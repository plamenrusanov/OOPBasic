using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
   /* public Model model;

    public Engine engine;

    public Cargo cargo;

    private double[][] tires;

    public double[][] Tires
    {
        get { return tires; }
        set { tires = value; }
    }

    public Car(string[] carArgs)
    {
        string model = carArgs[0];
        this.model = new Model(model);

        int engineSpeed = int.Parse(carArgs[1]);
        int enginePower = int.Parse(carArgs[2]);
        this.engine = new Engine(engineSpeed, enginePower);

        int cargoWeight = int.Parse(carArgs[3]);
        string cargoType = carArgs[4];
        this.cargo = new Cargo(cargoWeight, cargoType);B

        this.Tires = new double[2][];
        Tires[0] = new double[4];
        Tires[1] = new double[4];
        for (int i = 5; i < carArgs.Length; i++)
        {
            if (i % 2 != 0)
            {
                Tires[0][(i - 5) / 2] = double.Parse(carArgs[i]);
            }
            else
            {
                Tires[1][(i - 6) / 2] = double.Parse(carArgs[i]);
            }

        }

    }
    */
    /*
    int carCount = int.Parse(Console.ReadLine());
    List<Car> data = new List<Car>();
        for (int i = 0; i<carCount; i++)
        {
            string[] carArgs = Console.ReadLine().Split();
    Car car = new Car(carArgs);
    data.Add(car);           
        }
string command = Console.ReadLine();
        switch (command)
        {
            case "fragile":
                data = data.Where(c => c.cargo.CargoType == command).Where(c => c.Tires[0].Any(e => e< 1)).ToList();
                break;
            case "flamable":
                data = data.Where(c => c.cargo.CargoType == command).Where(c => c.engine.EnginePower > 250).ToList();
                break;
            default:
                break;
        }
        foreach (var item in data)
        {
            Console.WriteLine($"{item.model.Name}");
        }
        */
}

