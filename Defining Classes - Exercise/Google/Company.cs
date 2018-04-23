public class Company
{
    private string companyName;
    private string department;
    private decimal salary;
    public Company()
    {

    }
    public Company(string companyName, string department, decimal salary)
    {
        Salary = salary;
        Department = department;
        CompanyName = companyName;
    }
    public decimal Salary
    {
        get { return salary; }
        set { salary = value; }
    }

    public string Department
    {
        get { return department; }
        set { department = value; }
    }

    public string CompanyName
    {
        get { return companyName; }
        set { companyName = value; }
    }

}