using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    private string name;
    private Company company;
    private List<Pokemon> pokemons;
    private List<Parents> parents;
    private List<Children> children;
    private Car car;

    public Person(string name)
    {
        Name = name;
        Comp = new Company();
        Pokemons = new List<Pokemon>();
        Parents = new List<Parents>();
        Children = new List<Children>();
        C = new Car();
    }
    public Company Comp
    {
        get { return company; }
        set { company = value; }
    }
    public Car C
    {
        get { return car; }
        set { car = value; }
    }
    public List<Children> Children
    {
        get { return children; }
        set { children = value; }
    }
    public List<Parents> Parents
    {
        get { return parents; }
        set { parents = value; }
    }
    public List<Pokemon> Pokemons
    {
        get { return pokemons; }
        set { pokemons = value; }
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    internal static void ConsoleWritePerson(Person per)
    {
        Console.WriteLine($"{per.Name}");
        Console.WriteLine("Company:");
        if (per.Comp.CompanyName != null)
        {
            Console.WriteLine($"{per.Comp.CompanyName} {per.Comp.Department} {per.Comp.Salary:f2}");
        }        
        Console.WriteLine("Car:");
        if (per.C.CarModel != null)
        {
            Console.WriteLine($"{per.C.CarModel} {per.C.CarSpeed}");
        }       
        Console.WriteLine("Pokemon:");
        foreach (var item in per.Pokemons)
        {
            Console.WriteLine($"{item.PokemonName} {item.PokemonType}");
        }
        Console.WriteLine("Parents:");
        foreach (var item in per.Parents)
        {
            Console.WriteLine($"{item.Name} {item.Birthday}");
        }
        Console.WriteLine("Children:");
        foreach (var item in per.Children)
        {
            Console.WriteLine($"{item.Name} {item.Birthday}");
        }

    }
}

