using System;
using System.Collections.Generic;
using System.Text;

public abstract class Harvester : IHarvester
{
    private string id;
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement)
    {
        Id = id;
        OreOutput = oreOutput;
        EnergyRequirement = energyRequirement;
    }

    public string Id{ get; }

    public double OreOutput
    {
        get { return this.oreOutput; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("OreOutput");
            }
            this.oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get { return this.energyRequirement; }
        protected set
        {
            if (value < 0 || value > 20000)
            {
                throw new ArgumentException("EnergyRequirement");
            }
            this.energyRequirement = value;
        }
    }
}