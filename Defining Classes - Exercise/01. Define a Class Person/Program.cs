using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
       
        int n = int.Parse(Console.ReadLine());
        List<Engine> motors = new List<Engine>();
        for (int i = 0; i < n; i++)
        {
            string[] engineArgs = Console.ReadLine().Split();
            string model = engineArgs[0];
            int power = int.Parse(engineArgs[1]);
            string displacement = "n/a";
            string efficiency = "n/a";
            if (engineArgs.Length == 4)
            {
                displacement = engineArgs[2];
                efficiency = engineArgs[3];
            }
            else if (engineArgs.Length == 3)
            {
                if (char.IsDigit(engineArgs[2][0]))
                {
                    displacement = engineArgs[2];
                }
                else
                {
                    efficiency = engineArgs[2];
                }
            }
            Engine engine = new Engine(model, power, displacement, efficiency);
            motors.Add(engine);
        }

        int m = int.Parse(Console.ReadLine());
        List<CarSalesman> cars = new List<CarSalesman>();
        for (int i = 0; i < m; i++)
        {
            string[] carArgs = Console.ReadLine().Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
            string model = carArgs[0];
            string engine = carArgs[1];
            string weight = "n/a";
            string color = "n/a";
            if (carArgs.Length == 4)
            {
                weight = carArgs[2];
                color = carArgs[3];
            }
            else if (carArgs.Length == 3)
            {
                if (char.IsDigit(carArgs[2][0]))
                {
                    weight = carArgs[2];
                }
                else
                {
                    color = carArgs[2];
                }
            }
            CarSalesman car = new CarSalesman(model, engine, weight, color);
            cars.Add(car);
        }


        foreach (var item in cars)
        {
            Console.WriteLine($"{item.Model}:");
            Console.WriteLine($"  {item.Engine}:");
            var en = motors.FirstOrDefault(e => e.Model == item.Engine);
            Console.WriteLine($"    Power: {en.Power}");
            Console.WriteLine($"    Displacement: {en.Displacement}");
            Console.WriteLine($"    Efficiency: {en.Efficiency}");
            Console.WriteLine($"  Weight: {item.Weight}");
            Console.WriteLine($"  Color: {item.Color}");
        }
    }

}

