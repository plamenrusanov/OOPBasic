using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Person> data = new List<Person>();
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string name = tokens[0];
            if (!data.Any(p => p.Name == name))
            {
                var person = new Person(name);
                data.Add(person);
            }
            switch (tokens[1])
            {
                case "company":
                    AddCompany(data, tokens);
                    break;
                case "pokemon":
                    AddPokemon(data, tokens);
                    break;
                case "parents":
                    AddParents(data, tokens);
                    break;
                case "children":
                    AddChildren(data, tokens);
                    break;
                case "car":
                    AddCar(data, tokens);
                    break;
                default:
                    break;
            }
        }
        string com = Console.ReadLine();

        Person per = data.FirstOrDefault(p => p.Name == com);
        Person.ConsoleWritePerson(per);
    }

    private static void AddCar(List<Person> data, string[] tokens)
    {
        string name = tokens[0];
        string carModel = tokens[2];
        string carSpeed = tokens[3];
        Car car = new Car(carModel, carSpeed);
        data.FirstOrDefault(p => p.Name == name).C = car;
    }

    private static void AddChildren(List<Person> data, string[] tokens)
    {
        string name = tokens[0];
        string childName = tokens[2];
        string childBirthday = tokens[3];
        Children child = new Children(childName, childBirthday);
        data.FirstOrDefault(p => p.Name == name).Children.Add(child);
    }

    private static void AddParents(List<Person> data, string[] tokens)
    {
        string name = tokens[0];
        string parentName = tokens[2];
        string birthday = tokens[3];
        Parents parent = new Parents(parentName, birthday);
        data.FirstOrDefault(p => p.Name == name).Parents.Add(parent);
    }

    private static void AddPokemon(List<Person> data, string[] tokens)
    {
        string name = tokens[0];
        string pokemonName = tokens[2];
        string pokemonType = tokens[3];
        Pokemon pok = new Pokemon(pokemonName, pokemonType);
        data.FirstOrDefault(p => p.Name == name).Pokemons.Add(pok);
    }

    private static void AddCompany(List<Person> data, string[] tokens)
    {
        string name = tokens[0];
        string companyName = tokens[2];
        string department = tokens[3];
        decimal salary = decimal.Parse(tokens[4]);
        data.FirstOrDefault(p => p.Name == name).Comp = new Company(companyName, department, salary);
    }
}

