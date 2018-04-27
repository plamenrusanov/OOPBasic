using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using StorageMaster;

// ReSharper disable CheckNamespace
// ReSharper disable InconsistentNaming

[TestFixture]
public class Business_Logic_012_Storage_UnloadVehicle_Full
{
    // MUST exist within project, otherwise a Compile Time Error will be thrown.
    private static readonly Assembly ProjectAssembly = typeof(StartUp).Assembly;

    [Test]
    public void UnloadVehicle()
    {
        var storage = CreateObjectInstance(GetType("DistributionCenter"), "Source");

        var vehicle = InvokeMethod(storage, "GetVehicle", 0);
        var vehicle2 = InvokeMethod(storage, "GetVehicle", 1);

        var productsToAdd = new[]
        {
            CreateObjectInstance(GetType("HardDrive"), 1),
            CreateObjectInstance(GetType("HardDrive"), 1),
        };

        foreach (var product in productsToAdd)
        {
            InvokeMethod(vehicle, "LoadProduct", product);
            InvokeMethod(vehicle2, "LoadProduct", product);
        }

        InvokeMethod(storage, "UnloadVehicle", 0);

        Assert.That(() => InvokeMethod(storage, "UnloadVehicle", 1), Throws.InvalidOperationException,
            $"UnloadVehicle does not throw exception when the storage is full.");
    }

    private static object GetPropertyValue(object instance, string name)
    {
        var value = instance.GetType().GetProperty(name).GetValue(instance);
        return value;
    }

    private object InvokeMethod(object instance, string name, params object[] parameters)
    {
        try
        {
            var result = instance.GetType().GetMethod(name).Invoke(instance, parameters);
            return result;
        }
        catch (TargetInvocationException e)
        {
            throw e.InnerException;
        }
    }

    private static object CreateObjectInstance(Type type, params object[] parameters)
    {
        try
        {
            var instance = Activator.CreateInstance(type, parameters);
            return instance;
        }
        catch (TargetInvocationException e)
        {
            throw e.InnerException;
        }
    }

    private static Type GetType(string name)
    {
        var type = ProjectAssembly
            .GetTypes()
            .FirstOrDefault(t => t.Name == name);

        return type;
    }
}