using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        var animals = new List<Animal>();

        string input;
        while ((input = Console.ReadLine()) != "Beast!")
        {
            string[] animalArg = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string name = animalArg[0];
            int age = int.Parse(animalArg[1]);
            string gender = animalArg[2];
            try
            {
                
                Animal animal;
                switch (input)
                {
                    case "Dog":                     
                        animal = new Dog(name, age, gender);
                        animals.Add(animal);
                        break;
                    case "Cat":
                        animal = new Cat(name, age, gender);
                        animals.Add(animal);
                        break;
                    case "Frog":
                        animal = new Frog(name, age, gender);
                        animals.Add(animal);
                        break;
                    case "Kitten":
                        animal = new Kitten(name, age, gender);
                        animals.Add(animal);
                        break;
                    case "Tomcat":
                        animal = new Tomcat(name, age, gender);
                        animals.Add(animal);
                        break;
                    default:
                        throw new Exception();
                }

               
            }
            catch (Exception)
            {

                Console.WriteLine("Invalid input!");
            }
        }
        foreach (var item in animals)
        {
            Console.WriteLine(item);
        }
    }
}

