using System;
using System.Collections.Generic;
using System.Text;

public class Cargo
{
   
   
    private int cargoWeight;
    private string cargoType;
    public Cargo(string cargoWeight, string cargoType)
    {
        CargoWeight = int.Parse(cargoWeight);
        CargoType = cargoType;

    }
    public string CargoType
    {
        get { return cargoType; }
        set { cargoType = value; }
    }

    public int CargoWeight
    {
        get { return cargoWeight; }
        set { cargoWeight = value; }
    }

}

