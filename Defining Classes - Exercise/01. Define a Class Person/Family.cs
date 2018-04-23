using System;
using System.Collections.Generic;
using System.Linq;


public class Family
{
    private List<Person> family;

    public List<Person> MyProperty
    {
        get { return family; }
        set { family = value; }
    }
    public Family()
    {
        family = new List<Person>();
    }
    public void AddMember(Person member)
    {
        MyProperty.Add(member);
    }
    public Person GetOldestMember()
    {
        return family.OrderByDescending(p => p.Age).First();
    }
    public List<Person> GetMoreThanThirty()
    {
        return family.Where(p => p.Age > 30).OrderBy(p => p.Name).ToList();
    }

}

