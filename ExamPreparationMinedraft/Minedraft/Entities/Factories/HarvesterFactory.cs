using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class HarvesterFactory
{
    public IHarvester CreateHarvester(List<string> args)
    {
        string typeString = args[0] + "Harvester";
        string id = args[1];
        double oreOutput = double.Parse(args[2]);
        double energyRequirement = double.Parse(args[3]);
        try
        {
            if (args.Count == 5)
            {
                int sonicFactor = int.Parse(args[4]);
                Type sonicType = Assembly.GetCallingAssembly().GetTypes().Single(t => t.Name == typeString);
                IHarvester sonicHarvester = (IHarvester)Activator.CreateInstance(sonicType, new object[] { id, oreOutput, energyRequirement, sonicFactor });
                return sonicHarvester;
            }

            Type type = Assembly.GetCallingAssembly().GetTypes().Single(t => t.Name == typeString);
            IHarvester hammerHarvester = (IHarvester)Activator.CreateInstance(type, new object[] { id, oreOutput, energyRequirement });
            return hammerHarvester;
        }
        catch (ArgumentException ae)
        {
            throw new TargetInvocationException(ae.Message, ae);
        }
    }
}
