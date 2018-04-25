using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

public class DraftManager
{
    private string mode;
    private double totalStoredEnergy;
    private double totalMinedOre;
    private List<IHarvester> harvesters;
    private List<IProvider> providers;
    private ProviderFactory providerFactory;
    private HarvesterFactory harvesterFactory;

    public DraftManager()
    {
        this.mode = "Full";
        this.totalStoredEnergy = 0;
        this.totalMinedOre = 0;
        this.harvesters = new List<IHarvester>();
        this.providers = new List<IProvider>();
        this.providerFactory = new ProviderFactory();
        this.harvesterFactory = new HarvesterFactory();
    }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            IHarvester harvester = harvesterFactory.CreateHarvester(arguments);
            harvesters.Add(harvester);
        }
        catch(TargetInvocationException tie)
        {
            return string.Format("Harvester is not registered, because of it's {0}", tie.InnerException.Message);
        }
        return $"Successfully registered {arguments[0]} Harvester - {arguments[1]}";
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            IProvider provider = providerFactory.CreateProvider(arguments);
            providers.Add(provider);
        }
        catch (TargetInvocationException tie)
        {
            return string.Format("Provider is not registered, because of it's {0}", tie.InnerException.Message);
        }
        return $"Successfully registered {arguments[0]} Provider - {arguments[1]}";
    }

    public string Day()
    {
        double summedEnergyOutput = providers.Select(p => p.EnergyOutput).Sum();
        this.totalStoredEnergy += summedEnergyOutput;
        double summedOreOutput = harvesters.Select(h => h.OreOutput).Sum();
        double sumEnergyRequirement = harvesters.Select(h => h.EnergyRequirement).Sum();
        switch (mode)
        {
            case "Full":
                if (sumEnergyRequirement <= totalStoredEnergy)
                {
                    totalStoredEnergy -= sumEnergyRequirement;
                }
                else summedOreOutput = 0;
                break;
            case "Half":
                if (sumEnergyRequirement * 0.6 <= totalStoredEnergy)
                {
                    totalStoredEnergy -= sumEnergyRequirement * 0.6;
                    summedOreOutput *= 0.5;
                }
                else summedOreOutput = 0;
                break;
            case "Ënergy":
                if (sumEnergyRequirement <= totalStoredEnergy)
                {
                    summedOreOutput = 0;
                }
                break;
            default:
                break;
        }
        this.totalMinedOre += summedOreOutput;
        return $"A day has passed.\nEnergy Provided: { summedEnergyOutput}\nPlumbus Ore Mined: {summedOreOutput}";
    }

    public string Mode(List<string> arguments)
    {
        string newMode = arguments[0];
        switch (newMode)
        {
            case "Full":
                this.mode = "Full";
                break;
            case "Half":
                this.mode = "Half";
                break;
            case "Energy":
                this.mode = "Energy";
                break;
            default:
                return "Wrong argument mode!"; 
        }
        return $"Successfully changed working mode to {newMode} Mode";
    }

    public string Check(List<string> arguments)
    {
        StringBuilder sb = new StringBuilder();
        string id = arguments[0];
        IHarvester harvester = harvesters.FirstOrDefault(h => h.Id == id);
        if (harvester != null)
        {
            sb.AppendLine($"{harvester.GetType().Name.Replace("Harvester", "")} Harvester - {id}")
                .AppendLine($"Ore Output: {harvester.OreOutput}")
                .AppendLine($"Energy Requirement: {harvester.EnergyRequirement}");
        }
        IProvider provider = providers.FirstOrDefault(p => p.Id == id);
        if (provider != null)
        {
            sb.AppendLine($"{provider.GetType().Name.Replace("Provider", "")} Provider - {id}")
                .AppendLine($"Energy Output: {provider.EnergyOutput}");
        }
        if (harvester == null && provider == null)
        {
            sb.AppendLine($"No element found with id - {id}");
        }
        return sb.ToString().Trim();
    }

    public string ShutDown()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("System Shutdown")
            .AppendLine($"Total Energy Stored: {this.totalStoredEnergy}")
            .AppendLine($"Total Mined Plumbus Ore: {this.totalMinedOre}");
        return sb.ToString().Trim();
    }

}