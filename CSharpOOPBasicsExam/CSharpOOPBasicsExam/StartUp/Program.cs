using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{


    static void Main(string[] args)
    {
        RaceTower raceTower = new RaceTower();
        int laps = int.Parse(Console.ReadLine());
        int lengthTrack = int.Parse(Console.ReadLine());
        raceTower.SetTrackInfo(laps, lengthTrack);

        List<string> input;
        while (true)
        {
            input = Console.ReadLine().Split().ToList();
            if (input[0] == "RegisterDriver")
            {
                input = input.Skip(1).Take(10).ToList();
                raceTower.RegisterDriver(input);
            }
            else
            {
                break;
            }
        }

        do
        {
            switch (input[0])
            {

                case "Leaderboard":

                    Console.WriteLine(raceTower.GetLeaderboard());
                    break;

                case "CompleteLaps":
                    input = input.Skip(1).ToList();
                    string result = raceTower.CompleteLaps(input);
                    if (!string.IsNullOrEmpty(result))
                    {
                        Console.WriteLine(result.Trim());
                    }
                    break;
                case "Box":
                    input = input.Skip(1).ToList();
                    raceTower.DriverBoxes(input);
                    break;
                case "ChangeWeather":
                    input = input.Skip(1).ToList();
                    raceTower.ChangeWeather(input);
                    break;
                default:
                    break;

            }
            if (raceTower.CurrentLap < laps)
            {
                input = Console.ReadLine().Split().ToList();
            }
        } while (raceTower.CurrentLap < laps);

        Driver driver = raceTower.Drivers.OrderBy(d => d.TotalTime).First();
        Console.WriteLine($"{driver.Name} wins the race for {driver.TotalTime:f3} seconds.");
    }
}

