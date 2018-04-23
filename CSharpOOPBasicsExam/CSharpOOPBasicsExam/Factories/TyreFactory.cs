using System;
using System.Collections.Generic;
using System.Text;

public static class TyreFactory
{
    public static Tyre CreateTyre(List<string> arguments)
    {
        string tyreType = arguments[0];
        double tyreHardness = double.Parse(arguments[1]);

        switch (tyreType)
        {
            case "Ultrasoft":
                return new UltrasoftTyre(tyreHardness, double.Parse(arguments[2]));

            case "Hard":
                return new HardTyre(tyreHardness);

            default:
                return null;
        }
        
    }
}
