using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            Animal animal = AddAnimal(animals, input);
            string food = Console.ReadLine();
            animal = EatingAnimal(animal, food);
            animals.Add(animal);
        }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }


    }

    private static Animal EatingAnimal(Animal animal, string food)
    {
        string[] foodArg = food.Split();
        string foodName = foodArg[0];
        int quantity = int.Parse(foodArg[1]);
        if (animal.PossibleFood.Contains(foodName))
        {
            animal.FoodEaten += quantity;
            animal.IncreaseWeight(quantity);
        }
        else
        {
            Console.WriteLine($"{animal.GetType()} does not eat {foodName}!");
        }
        return animal;
    }

    private static Animal AddAnimal(List<Animal> animals, string input)
    {
        string[] aniArg = input.Split();
        string name = aniArg[1];
        double weight = double.Parse(aniArg[2]);
        switch (aniArg[0])
        {
            case "Owl":
                double wingSize = double.Parse(aniArg[3]);
                Animal owl = new Owl(name, weight, 0, wingSize);
                Console.WriteLine(owl.ProduceSound);
               // animals.Add(owl);
                return owl;
   
            case "Hen":
                double wings = double.Parse(aniArg[3]);
                Animal hen = new Hen(name, weight, 0, wings);
                Console.WriteLine(hen.ProduceSound);
               // animals.Add(hen);
                return hen;
              
            case "Mouse":
                string livingRegion = aniArg[3];
                Animal mouse = new Mouse(name, weight, livingRegion);
                Console.WriteLine(mouse.ProduceSound);
               // animals.Add(mouse);
                return mouse;
                
            case "Dog":
                string livingR = aniArg[3];
                Animal dog = new Dog(name, weight, livingR);
                Console.WriteLine(dog.ProduceSound);
               // animals.Add(dog);
                return dog;
                
            case "Cat":
                string livReg = aniArg[3];
                string breed = aniArg[4];
                Animal cat = new Cat(name, weight, livReg, breed);
                Console.WriteLine(cat.ProduceSound);
               // animals.Add(cat);
                return cat;
                
            case "Tiger":
                string lReg = aniArg[3];
                string br = aniArg[4];
                Animal tiger = new Tiger(name, weight, lReg, br);
                Console.WriteLine(tiger.ProduceSound);
              //  animals.Add(tiger);
                return tiger;
       

            default:
                return null;
               
        }

    }
}

