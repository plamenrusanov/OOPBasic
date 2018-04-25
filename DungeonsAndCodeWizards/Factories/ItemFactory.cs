using System;
using System.Collections.Generic;
using System.Text;

public class ItemFactory
{
    public Item CreateItem(string[] args)
    {
        Type type = Type.GetType(args[0]);
        if (type == null)
        {
            throw new ArgumentException($"Invalid item \"{args[0]}\"!");
        }
        return (Item)Activator.CreateInstance(type);
    }
}
