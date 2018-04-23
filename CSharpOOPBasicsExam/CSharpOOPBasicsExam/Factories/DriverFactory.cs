using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class DriverFactory
{
    public static Driver CreateDriver(List<string> arguments)
    {
        string driverType = arguments[0];
        string driverName = arguments[1];
        int hp = int.Parse(arguments[2]);
        double fuelAmount = double.Parse(arguments[3]);
       

        try
        {
            arguments = arguments.Skip(4).Take(3).ToList();
            Tyre tyre = TyreFactory.CreateTyre(arguments);

            Car car = new Car(hp, fuelAmount, tyre);

            if (driverType == "Aggressive")
            {
                Driver driver = new AggressiveDriver(driverName, car);
                return driver;
            }
            else if (driverType == "Endurance")
            {
                Driver driver = new EnduranceDriver(driverName, car);
                return driver;
            }
            return null;

        }
        catch (Exception)
        {
            return null;
        }
    }
}
