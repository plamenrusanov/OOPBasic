

public class AggressiveDriver : Driver
{
    public AggressiveDriver(string name, Car Car) 
        : base( name, Car, 2.7)
    {
    }

    public override double Speed => base.Speed * 1.3;
}
