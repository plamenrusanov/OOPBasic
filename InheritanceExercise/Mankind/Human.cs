using System;
using System.Collections.Generic;
using System.Text;

public class Human
{
    protected string firstName;
    protected string lastName;

    public Human(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName
    {
        get { return firstName; }
        set
        {
            if (!IsUpperFirstChar(value))
            {
                throw new ArgumentException("Expected upper case letter! Argument: firstName");
            }
            if (value.Length < 4) 
            {
                throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
            }
            firstName = value;
        }
    }

    public string LastName
    {
        get { return lastName; }
        set
        {
            if (!IsUpperFirstChar(value))
            {
                throw new ArgumentException("Expected upper case letter! Argument: lastName");
            }
            if (value.Length < 3) 
            {
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
            }
            lastName = value;
        }
    }

    private bool IsUpperFirstChar(string value)
    {
        if (value[0] < 65 || value[0] > 90)
        {
            return false;
        }
        return true;
    }
}

