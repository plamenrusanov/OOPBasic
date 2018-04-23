public class Children
{
    private string name;
    private string birthday;
    public Children()
    {

    }
    public Children(string childName, string childBirthday)
    {
        Name = childName;
        Birthday = childBirthday;
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