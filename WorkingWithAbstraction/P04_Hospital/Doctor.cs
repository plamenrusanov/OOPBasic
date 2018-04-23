using System;
using System.Collections.Generic;
using System.Text;


public class Doctor
{
    public string Name { get; set; }

    public List<string> Patients { get; set; }

    public Doctor()
    {
        Patients = new List<string>();
    }
    public Doctor(string[] inputArgs) : this()
    {
        Name = $"{inputArgs[1]} {inputArgs[2]}";
        Patients.Add(inputArgs[3]);
    }
    
}


