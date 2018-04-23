public class Engine
{
    
    private string model;
    private int power;
    private string displacement;
    private string efficiency;
    public Engine(string model, int power, string displacement = "n/a", string efficiency = "n/a")
    {
        this.Model = model;
        this.Power = power;
        this.Displacement = displacement;
        this.Efficiency = efficiency;
    }
    public string Efficiency
    {
        get { return efficiency; }
        set { efficiency = value; }
    }

    public string Displacement
    {
        get { return displacement; }
        set { displacement = value; }
    }

    public int Power
    {
        get { return power; }
        set { power = value; }
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }









    /*
    private int engineSpeed;
    private int enginePower;

    public Engine(int engineSpeed, int enginePower)
    {
        this.engineSpeed = engineSpeed;
        this.enginePower = enginePower;
    }

    public int EngineSpeed
    {
        get { return engineSpeed; }
        set { engineSpeed = value; }
    }
    public int EnginePower
    {
        get { return enginePower; }
        set { enginePower = value; }
    }*/
}