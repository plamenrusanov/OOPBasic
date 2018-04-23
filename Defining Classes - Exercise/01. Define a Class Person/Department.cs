using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Department
{
    private List<Employee>employees;
    private string name;
    

    public Department(string department)
    {
        this.Name = department;
        this.Employees = new List<Employee>();
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public List<Employee>Employees

    {
        get { return employees; }
        set { employees = value; }
    }

    public decimal AverageSalary => this.employees.Select(e => e.Salary).Average();

    public void AddEmployee(Employee employee)
    {
        this.employees.Add(employee);
    }
}

