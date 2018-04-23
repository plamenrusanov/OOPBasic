using System;
using System.Collections.Generic;
using System.Linq;
class Program
{
    static void Main(string[] args)
    {
        List<Person> persons = new List<Person>();
        string[] personInput = Console.ReadLine().Split(new[] { ";" },StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < personInput.Length; i++)
        {
            string[] personArg = personInput[i].Split(new[] { "=" },StringSplitOptions.RemoveEmptyEntries);
            string name = personArg[0];
            decimal money = decimal.Parse(personArg[1]);
            try
            {
                Person person = new Person(name, money);
                persons.Add(person);
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
                return;
            }
        }


        List<Product> products = new List<Product>();
        string[] productInput = Console.ReadLine().Split(new[] { ";" },StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < productInput.Length; i++)
        {
            string[] productArg = productInput[i].Split(new[] { "=" },StringSplitOptions.RemoveEmptyEntries);
            string name = productArg[0];
            decimal cost = decimal.Parse(productArg[1]);
            Product product = new Product(name, cost);
            products.Add(product);
        }

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] shopping = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string personName = shopping[0];
            string productName = shopping[1];
            Person currentPerson = persons.FirstOrDefault(p => p.Name == personName);
            Product currentProduct = products.FirstOrDefault(p => p.Name == productName);
            if (currentPerson != null && currentProduct != null)
            {
                currentPerson.PersonBuyProduct(currentProduct);
            }
            
        }

        foreach (Person person in persons)
        {
            Console.WriteLine(person);
        }
    }
}

