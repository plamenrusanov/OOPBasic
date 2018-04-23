using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private const int MIN_NAME_LENGTH = 3;

    protected string name;
    protected int age;

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public virtual int Age
    {
        get { return age; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Age must be positive!");
            }
            age = value;
        }
    }

    public virtual string Name
    {
        get { return name; }
        set
        {
            if (value.Length < MIN_NAME_LENGTH)
            {
                throw new ArgumentException("Name's length should not be less than 3 symbols!");
            }
            name = value;
        }
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(String.Format("Name: {0}, Age: {1}",
                             this.Name,
                             this.Age));

        return stringBuilder.ToString();
    }

}

