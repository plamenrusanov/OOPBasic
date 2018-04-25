using System;
using System.Collections.Generic;
using System.Text;

public abstract class Provider : IProvider
{

    private double enrgyOutput;
    protected Provider(string id, double energyOutput)
    {
        Id = id;
        EnergyOutput = energyOutput;
    }

    public string Id { get; }
   
    public double EnergyOutput
    {
        get { return this.enrgyOutput; }
        protected set
        {
            if (value < 0 || value >= 10000)
            {
                throw new ArgumentException("EnergyOutput");
            }
            this.enrgyOutput = value;
        }
    }

}