using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private string name;
    private string birthday;
    private List<Person> parents;
    private List<Person> children;
    public Person()
    {
        this.Parents = new List<Person>();
        this.Children = new List<Person>();
    }
    public Person(string name, string birthday):this()
    {
        Name = name;
        Birthday = birthday;
    }
  
    public List<Person> Children 
    {
        get { return children; }
        set { children = value; }
    }


    public List<Person> Parents
    {
        get { return parents; }
        set { parents = value; }
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
    public override string ToString()
    {
        return $"{Name} {Birthday}";
    }
}

