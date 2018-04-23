

public abstract class Driver
{
    private double totalTime;
    private string name;
    private Car car;

    protected Driver( string name, Car car, double fuelConsumationPerKm)
    {
        Name = name;    
        Car = car;
        FuelConsumptionPerKm = fuelConsumationPerKm;
        TotalTime = 0;
    }

    public Car Car
    {
        get { return this.car; }
        private set
        {
            this.car = value;
        }
    }

    public string Name
    {
        get { return this.name; }
        private set
        {
            this.name = value;
        }
    }

    public double TotalTime
    {
        get { return this.totalTime; }
        private set
        {
            this.totalTime = value;
        }
    }

    public double FuelConsumptionPerKm
    {
        get;
    }

    public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

    public void AddTime(double seconds)
    {
        this.totalTime += seconds;
    }

    public void RemoveTime(double seconds)
    {
        this.totalTime -= seconds;
    }
}
