using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private List<Driver> drivers;
    private Stack<KeyValuePair<string, string>> PoorDrivers;
    private int currentLap;
    private int maxLaps;
    private int trackLength;
    private string whether;

    public RaceTower()
    {
        PoorDrivers = new Stack<KeyValuePair<string, string>>();
        this.whether = "Sunny";
        CurrentLap = 0;
        Drivers = new List<Driver>();
    }

    public int CurrentLap
    {
        get { return this.currentLap; }
        private set { this.currentLap = value; }
    }

    public List<Driver> Drivers
    {
        get { return this.drivers; }
        private set { this.drivers = value; }
    }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.maxLaps = lapsNumber;
        this.trackLength = trackLength;
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        Driver driver = DriverFactory.CreateDriver(commandArgs);
        if (driver != null)
        {
            Drivers.Add(driver);
        }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        string driversName = commandArgs[1];
        Driver driver = drivers.FirstOrDefault(d => d.Name == driversName);
        if (driver != null)
        {
            if (commandArgs[0] == "Refuel")
            {
                driver.Car.Refull(double.Parse(commandArgs[2]));
            }
            else if (commandArgs[0] == "ChangeTyres")
            {
                Tyre tyre = TyreFactory.CreateTyre(commandArgs.Skip(2).ToList());
                driver.Car.SetNewTyre(tyre);
            }
            driver.AddTime(20);
        }

    }

    public string CompleteLaps(List<string> commandArgs)
    {
        StringBuilder message = new StringBuilder();
        int laps = int.Parse(commandArgs[0]);
        if (currentLap + laps > maxLaps)
        {
            return ($"There is no time! On lap {currentLap}.");
        }
        else
        {
            for (int i = 0; i < laps; i++)
            {
                string result = TurnLap();
                if (result != null)
                {
                    message.AppendLine(result);
                }
            }

        }
    
        return message.ToString().Trim();
    }

    private string Overtaking()
    {
        for (int i = drivers.Count - 1; i > 0; i--)
        {
            double diffTime = drivers[i - 1].TotalTime - drivers[i].TotalTime;

            if (diffTime >= 0 && diffTime <= 3 && drivers[i - 1].GetType().ToString() == "AggressiveDriver" && drivers[i - 1].Car.Tyre.GetType().ToString() == "UltrasoftTyre")
            {
                if (whether == "Foggy")
                {
                    AddCrashedDriver(drivers[i].Name);
                }
                else
                {
                    return SetExtraTimeToDrivers(i, 3);
                }
            }
            else if (diffTime >= 0 && diffTime <= 3 && drivers[i - 1].GetType().ToString() == "EnduranceDriver" && drivers[i - 1].Car.Tyre.GetType().ToString() == "HardTyre")
            {
                if (whether == "Rainy")
                {
                    AddCrashedDriver(drivers[i].Name);
                }
                else
                {
                    return SetExtraTimeToDrivers(i, 3);
                }
            }
            else if (diffTime >= 0 && diffTime <= 2)
            {
                return SetExtraTimeToDrivers(i, 2);
            }
        }
        return null;
    }

    private void AddCrashedDriver(string name, string message = "Crashed")
    {
        PoorDrivers.Push(new KeyValuePair<string, string>(name, message));
        drivers.Remove(drivers.FirstOrDefault(d => d.Name == name));
    }

    private string SetExtraTimeToDrivers(int i, int v)
    {
        drivers[i - 1].RemoveTime(3);
        drivers[i].AddTime(3);
        return ($"{drivers[i - 1].Name} has overtaken {drivers[i].Name} on lap {currentLap}.");
    }

    public string TurnLap()
    {

        bool isOutDriver = false;
        List<string> names = new List<string>();
        foreach (Driver driver in drivers)
        {
            try
            {
                double currentTime = 60 / (trackLength / driver.Speed);
                driver.AddTime(currentTime); 
                double fuel = driver.FuelConsumptionPerKm;
                driver.Car.ReduceFuel(trackLength * fuel);
                driver.Car.Tyre.ReduceDegradation();
            }
            catch (Exception e)
            { 
                PoorDrivers.Push(new KeyValuePair<string, string>(driver.Name, e.Message));
                isOutDriver = true;
                names.Add(driver.Name);
            }
        }
        if (isOutDriver)
        {
            for (int i = 0; i < names.Count; i++)
            {
                Driver driver = drivers.FirstOrDefault(d => d.Name == names[i]);

                if (driver != null)
                {
                    drivers.Remove(driver);
                    i--;
                }
            }
        }
        currentLap++;
        string result = Overtaking();
        return result;
    }

    public string GetLeaderboard()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Lap {currentLap}/{maxLaps}");
        int count = 1;
        foreach (var item in drivers.OrderBy(d => d.TotalTime))
        {
            sb.AppendLine($"{count} {item.Name} {item.TotalTime:f3}");
            count++;
        }
        foreach (var item in PoorDrivers)
        {
            sb.AppendLine($"{count} {item.Key} {item.Value}");
            count++;
        }
        return sb.ToString().TrimEnd();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        this.whether = commandArgs[0];
    }

}
