using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();
        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Car car = new Car(parameters);
            cars.Add(car);          
        }
        string command = Console.ReadLine();
        List<string> filterCars = filterCarsByCommand(cars, command);
        PrintResult(filterCars);
       
    }

    private static void PrintResult(List<string> filterCars)
    {
        Console.WriteLine(string.Join(Environment.NewLine, filterCars));
    }

    private static List<string> filterCarsByCommand(List<Car> cars, string command)
    {
        List<string> filterCars = new List<string>();
        if (command == "fragile")
        {
            filterCars = cars
                .Where(x => x.Cargo.CargoType == "fragile" && x.Tires.Any(y => y.Key < 1))
                .Select(x => x.Model)
                .ToList();   
        }
        else
        {
            filterCars = cars
                .Where(x => x.Cargo.CargoType == "flamable" && x.Engine.EnginePower > 250)
                .Select(x => x.Model)
                .ToList();
        }
        return filterCars;
    }
}