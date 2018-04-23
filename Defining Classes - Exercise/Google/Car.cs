public class Car
{
    private string carModel;
    private int carSpeed;
    public Car()
    {

    }
    public Car(string carModel, string carSpeed)
    {
        CarModel = carModel;
        CarSpeed = int .Parse(carSpeed);
    }
    public int CarSpeed
    {
        get { return carSpeed; }
        set { carSpeed = value; }
    }

    public string CarModel
    {
        get { return carModel; }
        set { carModel = value; }
    }

}