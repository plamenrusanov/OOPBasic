using System;
using System.Collections.Generic;
using System.Text;

public class UltrasoftTyre : Tyre
{
    private double grip;
 

    public UltrasoftTyre(double hardness, double grip) 
        : base("Ultrasoft", hardness)
    {
        Grip = grip;
    }

    public double Grip
    {
        get { return grip; }
        private set
        {
            if (value < 0)
            {
                throw new Exception("Blown Tyre");
            }
            grip = value;
        }
    }

    public override void ReduceDegradation()
    {
        double currentDeg = (Hardness + Grip);    
        if (base.Degradation - currentDeg < 30)
        {
            throw new Exception("Blown Tyre");
        }
        base.Degradation -= currentDeg;
    }
}
