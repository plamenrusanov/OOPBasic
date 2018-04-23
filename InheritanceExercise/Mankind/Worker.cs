using System;
using System.Collections.Generic;
using System.Text;

public class Worker:Human
{
    private decimal weekSalary;
    private decimal hoursPerDay;

    public Worker(string firstName, string lastName, decimal weekSalary, decimal hoursPerDay):base(firstName, lastName)
    {
        WeekSalary = weekSalary;
        HoursPerDay = hoursPerDay;
    }
  
    public decimal WeekSalary
    {
        get { return weekSalary; }
        set
        {
            if (value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            weekSalary = value;
        }
    }

    public decimal HoursPerDay
    {
        get { return hoursPerDay; }
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            hoursPerDay = value;
        }
    }

    public decimal MoneyPerHour()
    {
        return weekSalary / (hoursPerDay * 5);
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"First Name: {FirstName}")
            .AppendLine($"Last Name: {LastName}")
            .AppendLine($"Week Salary: {WeekSalary:f2}")
            .AppendLine($"Hours per day: {HoursPerDay:f2}")
            .AppendLine($"Salary per hour: {MoneyPerHour():f2}");

        string result = stringBuilder.ToString().Trim();
        return result;
    }
}

