using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static string currentPer;
    static void Main(string[] args)
    {
       
        List<Person> persons = new List<Person>();
        {
            Person per = new Person();
            currentPer = Console.ReadLine();

            if (char.IsDigit(currentPer[0]))
            {
                per.Birthday = currentPer;
                per.Name = string.Empty;
            }
            else
            {
                per.Birthday = string.Empty;
                per.Name = currentPer;
            }
            persons.Add(per);
        }
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] tokens = input.Split(" - ");
            if (tokens.Length == 2)
            {
                {
                    Person per = new Person();
                    string arg = tokens[0];

                    if (char.IsDigit(arg[0]))
                    {
                        per.Birthday = arg;
                    }
                    else
                    {
                        per.Name = arg;
                    }
                    string child = tokens[1];
                    if (char.IsDigit(child[0]))
                    {
                        per.Children.Add(new Person(string.Empty, child));
                    }
                    else
                    {
                        per.Children.Add(new Person(child, string.Empty));
                    }
                    persons.Add(per);
                }
                {
                    Person per = new Person();
                    string arg = tokens[1];

                    if (char.IsDigit(arg[0]))
                    {
                        per.Birthday = arg;
                    }
                    else
                    {
                        per.Name = arg;
                    }
                    string parent = tokens[0];
                    if (char.IsDigit(parent[0]))
                    {
                        per.Parents.Add(new Person(string.Empty, parent));
                    }
                    else
                    {
                        per.Parents.Add(new Person(parent, string.Empty));
                    }
                    persons.Add(per);
                }
            }
            else if (tokens.Length == 1)
            {
                string[] arg = tokens[0].Split();
                string name = $"{arg[0]} {arg[1]}";
                string birthday = arg[2];
                Person per = persons.FirstOrDefault(p => p.Name == name || p.Birthday == birthday);
                if (per != null)
                {
                    per.Name = name;
                    per.Birthday = birthday;
                }

            }
        }
       // per.Children = per.Children.Where(p => p.Name != string.Empty && p.Birthday != string.Empty).ToList();
       // per.Parents = per.Parents.Where(p => p.Name != string.Empty && p.Birthday != string.Empty).ToList();
        PrintResult(persons);
    }

    private static void PrintResult(List<Person> persons)
    {
        foreach (Person per in persons.Where(p => p.Name == currentPer || p.Birthday == currentPer))
        {
            Console.WriteLine(per.ToString());
            Console.WriteLine("Parents:");
            foreach (Person item in per.Parents)
            {
                Console.WriteLine(item.Parents);
            }
            Console.WriteLine("Children:");
            foreach (Person item in per.Children)
            {
                Console.WriteLine(item.Children);
            }
        }
       
    }
}

