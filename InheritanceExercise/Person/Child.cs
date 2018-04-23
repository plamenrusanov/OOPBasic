using System;
using System.Collections.Generic;
using System.Text;

public class Child:Person
{
    private const int MAX_AGE = 15;

    protected new int age;

    public Child(string name, int age):base(name, age)
    {       
        Age = age;
    }

    public new int Age
    {
        get { return age; }
        set
        {
            if (value > MAX_AGE)
            {
                throw new ArgumentException("Child's age must be less than 15!");
            }
            age = value;
        }
    }
}


