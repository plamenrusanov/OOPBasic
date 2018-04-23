using System;
using System.Collections.Generic;
using System.Text;

public class Engine
{
    private int engineSpeed;
    private int enginePower;

    public Engine(string enginePower, string engineSpeed)
    {
        EnginePower = int.Parse(enginePower);
        EngineSpeed = int.Parse(engineSpeed);
    }

    public int EnginePower
    {
        get { return enginePower; }
        set { enginePower = value; }
    }
    public int EngineSpeed
    {
        get { return engineSpeed; }
        set { engineSpeed = value; }
    }
}

