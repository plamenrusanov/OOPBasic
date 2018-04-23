using System;

public class Program
{
    static void Main(string[] args)
    {
        string[] carArg = Console.ReadLine().Split();
        Vehicle car = new Car(double.Parse(carArg[1]), double.Parse(carArg[2]), double.Parse(carArg[3]));

        string[] trackArg = Console.ReadLine().Split();
        Vehicle track = new Truck(double.Parse(trackArg[1]), double.Parse(trackArg[2]), double.Parse(trackArg[3]));

        string[] busArg = Console.ReadLine().Split();
        Vehicle bus = new Bus(double.Parse(busArg[1]), double.Parse(busArg[2]), double.Parse(busArg[3]));

        int numberOfTraveles = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfTraveles; i++)
        {
            string[] command = Console.ReadLine().Split();
            switch (command[0])
            {
                case "Drive":
                    if (command[1] == "Car")
                        car.Drive(double.Parse(command[2]));
                    else if (command[1] == "Truck")
                        track.Drive(double.Parse(command[2]));
                    else
                        bus.Drive(double.Parse(command[2]));
                    break;

                case "Refuel":
                    if (command[1] == "Car")
                        car.ReFull(double.Parse(command[2]));
                    else if (command[1] == "Truck")
                        track.ReFull(double.Parse(command[2]));
                    else
                        bus.ReFull(double.Parse(command[2]));
                    break;

                case "DriveEmpty":
                    bus.DriveEmpty(double.Parse(command[2]));
                    break;

                default:
                    break;
            }
        }

        Console.WriteLine($"Car: {car.FuelQuantity:f2}");
        Console.WriteLine($"Truck: {track.FuelQuantity:f2}");
        Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
    }
}

