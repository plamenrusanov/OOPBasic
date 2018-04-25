using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engine
{
    private StringBuilder sb;
    private DraftManager draftManager;

    public Engine()
    {
        this.sb = new StringBuilder();
        this.draftManager = new DraftManager();
    }

    public void Run()
    {
        bool isShutdown = false;
       
        while (!isShutdown)
        {
            List<string> input = Console.ReadLine().Split().ToList();
            string command = input[0];
            input.RemoveAt(0);
            switch (command)
            {
                case "RegisterHarvester":
                    sb.AppendLine(draftManager.RegisterHarvester(input));
                    break;
                case "RegisterProvider":
                    sb.AppendLine(draftManager.RegisterProvider(input));
                    break;
                case "Day":
                    sb.AppendLine(draftManager.Day());
                    break;
                case "Mode":
                    sb.AppendLine(draftManager.Mode(input));
                    break;
                case "Check":
                    sb.AppendLine(draftManager.Check(input));
                    break;
                case "Shutdown":
                    isShutdown = true;
                    sb.AppendLine(draftManager.ShutDown());
                    break;
                default:
                    break;
            }

        }

        Console.WriteLine(sb.ToString().Trim());
    }
}
