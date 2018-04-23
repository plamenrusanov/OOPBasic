public class Parents
{
    private string name;
    private string birthday;
    public Parents()
    {

    }
    public Parents(string parentName, string birthday)
    {
        Name = parentName;
        Birthday = birthday;

    }
    public string Birthday
    {
        get { return birthday; }
        set { birthday = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
  
}