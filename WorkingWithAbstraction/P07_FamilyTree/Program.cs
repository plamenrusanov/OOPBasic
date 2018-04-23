using System;
using System.Collections.Generic;
using System.Linq;

namespace P07_FamilyTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var familyTree = new List<Person>();
            string personInput = Console.ReadLine();
            Person mainPerson = new Person();

            if (IsBirthday(personInput))
            {
                mainPerson.Birthday = personInput;
            }
            else
            {
                mainPerson.Name = personInput;
            }

            familyTree.Add(mainPerson);

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(" - ");
                if (tokens.Length > 1)
                {
                    string firstPerson = tokens[0];
                    string secondPerson = tokens[1];
                    if (IsBirthday(firstPerson))
                    {
                        var parent = familyTree.FirstOrDefault(p => p.Birthday == firstPerson);
                        if (parent == null)
                        {
                            parent = new Person();
                            familyTree.Add(parent);
                            parent.Birthday = firstPerson;
                        }
                        var child = familyTree.FirstOrDefault(p => p.Name == secondPerson || p.Birthday == secondPerson);
                        if (child == null)
                        {
                            child = new Person();
                            familyTree.Add(child);
                        }
                      
                        if (IsBirthday(secondPerson))
                        {
                            child.Birthday = secondPerson;
                        }
                        else
                        {
                            child.Name = secondPerson;
                        }
                        child.Parents.Add(parent);
                        parent.Children.Add(child);
                    }
                    else
                    {
                        var parent = familyTree.FirstOrDefault(p => p.Name == firstPerson);
                        if (parent == null)
                        {
                            parent = new Person();
                            familyTree.Add(parent);
                            parent.Name = firstPerson;
                        }
                        var child = familyTree.FirstOrDefault(p => p.Name == secondPerson || p.Birthday == secondPerson);
                        if (child == null)
                        {
                            child = new Person();
                            familyTree.Add(child);
                        }
                        
                        if (IsBirthday(secondPerson))
                        {
                            child.Birthday = secondPerson;
                        }
                        else
                        {
                            child.Name = secondPerson;
                        }
                        child.Parents.Add(parent);
                        parent.Children.Add(child);
                    }
                  
                }

                else
                {
                    tokens = tokens[0].Split();
                    string name = $"{tokens[0]} {tokens[1]}";
                    string birthday = tokens[2];

                    var person = familyTree.FirstOrDefault(p => p.Name == name);
                    var person2 = familyTree.FirstOrDefault(p => p.Birthday == birthday);
                    if (person != null)
                    {
                        person.Birthday = birthday;
                    }                  
                    if (person2 != null)
                    {
                        person2.Name = name;

                    }
                    if (person != null && person2 != null)
                    {

                        person.Children = person.Children.Concat(person2.Children).Distinct().ToList();
                        person.Parents = person.Parents.Concat(person2.Parents).Distinct().ToList();
                        person2.Children = person2.Children.Concat(person.Children).Distinct().ToList();
                        person2.Parents = person2.Parents.Concat(person.Parents).Distinct().ToList();
                        familyTree.Distinct();

                    }
                    if (person == null && person2 == null)
                    {
                        var p = new Person();
                        p.Name = name;
                        p.Birthday = birthday;
                        familyTree.Add(p);
                    }                  
                }
            }
            Console.WriteLine(mainPerson);
            Console.WriteLine("Parents:");
            foreach (var p in mainPerson.Parents)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("Children:");
            foreach (var c in mainPerson.Children)
            {
                Console.WriteLine(c);
            }

        }

       

        private static void SetChild(List<Person> familyTree, Person parentPerson, string child)
        {
            var childPerson = new Person();

            if (IsBirthday(child))
            {
                if (!familyTree.Any(p => p.Birthday == child))
                {
                    childPerson.Birthday = child;
                }
                else
                {
                    childPerson = familyTree.First(p => p.Birthday == child);
                }
            }
            else
            {
                if (!familyTree.Any(p => p.Name == child))
                {
                    childPerson.Name = child;
                }
                else
                {
                    childPerson = familyTree.First(p => p.Name == child);
                }
            }

            parentPerson.Children.Add(childPerson);
            childPerson.Parents.Add(parentPerson);
            familyTree.Add(childPerson);
        }

        static bool IsBirthday(string input)
        {
            return Char.IsDigit(input[0]);
        }
    }
}
