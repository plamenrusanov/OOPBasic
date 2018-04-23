using System;

public abstract class Tyre
{
    private double degradation;
    protected Tyre(string name, double hardness)
    {
        Name = name;
        Hardness = hardness;
        Degradation = 100;
    }
    public string Name
    {
        get;
    }

    public double Degradation
    {
        get { return this.degradation; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Blown Tyre");
            }
            this.degradation = value;
        }
    }

    public double Hardness
    {
        get;
    }

    public virtual void ReduceDegradation()
    {
        this.Degradation -= Hardness;     
    }

}
