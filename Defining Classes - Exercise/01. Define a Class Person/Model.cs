public class Model
{
   
    private string name;

    public Model(string model)
    {
        this.name = model;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

}