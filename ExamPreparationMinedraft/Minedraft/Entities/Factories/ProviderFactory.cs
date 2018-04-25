using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
public class ProviderFactory
{
    public IProvider CreateProvider (List<string> args)
    {
        string typeString = args[0] + "Provider";
        string id = args[1];
        double energyOutput = double.Parse(args[2]);

        try
        {
            Type type = Assembly.GetCallingAssembly().GetTypes().Single(t => t.Name == typeString);
            IProvider provider = (IProvider)Activator.CreateInstance(type, new object[] { id, energyOutput });
            return provider;
        }
        catch (ArgumentException ae)
        {

            throw new TargetInvocationException(ae.Message, ae);
        }
    }
}