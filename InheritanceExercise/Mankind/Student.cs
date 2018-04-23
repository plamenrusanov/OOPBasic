using System;
using System.Collections.Generic;
using System.Text;

public class Student:Human
{
    private string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber):base(firstName, lastName)
    {
        FacultyNumber = facultyNumber;
    }

    public string FacultyNumber
    {
        get { return facultyNumber; }
        set
        {
            if (!IsValidNumber(value))
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            facultyNumber = value;
        }
    }

    private bool IsValidNumber(string value)
    {
        if (value.Length < 5 || value.Length > 10)
        {
            return false;
        }
        for (int i = 0; i < value.Length; i++)
        {
            if (!Char.IsLetterOrDigit(value[i]))
            {
                return false;
            }
        }
        return true;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"First Name: {FirstName}")
            .AppendLine($"Last Name: {LastName}")
            .AppendLine($"Faculty number: {FacultyNumber}");
        string result = stringBuilder.ToString();
        return result;
    }
}


