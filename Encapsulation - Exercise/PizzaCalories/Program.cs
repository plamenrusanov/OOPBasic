using System;
class Program
{
    static void Main(string[] args)
    {
        try
        {
            Pizza pizza = new Pizza(Console.ReadLine().Split()[1]);
            string[] doughArg = Console.ReadLine().Split();
            string flourType = doughArg[1];
            string bakingTechnique = doughArg[2];
            int weight = int.Parse(doughArg[3]);
            pizza.AddDough(flourType, bakingTechnique, weight);

            string inputTopings;
            while ((inputTopings = Console.ReadLine()) != "END")
            {
                string[] toppingArg = inputTopings.Split();
                pizza.AddTopping(toppingArg[1], int.Parse(toppingArg[2]));
            }
            Console.WriteLine($"{pizza.Name} - {pizza.CalCaloriesPizza():f2} Calories.");
        }
        catch (ArgumentException argEx)
        {

            Console.WriteLine(argEx.Message);
        }
    }
}

