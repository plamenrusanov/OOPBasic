using System;
using System.Collections.Generic;
using System.Text;


public class Trainer
{
    private string name;
    private int numberOfBadges;
    private List<Pokemon> pokemons;
    
   

    public Trainer(string trainer, string pokName, string pokElement, int pokHealt, int numberOFBadges = 0)
    {
        this.Name = trainer;
        this.Pokemons = new List<Pokemon>();
        Pokemon p = new Pokemon(pokName, pokElement, pokHealt);
        Pokemons.Add(p);
        this.NumberOfBadges = numberOFBadges;
    }

    public List<Pokemon> Pokemons
    {
        get { return pokemons; }
        set { pokemons = value; }
    }


    public int NumberOfBadges
    {
        get { return numberOfBadges; }
        set { numberOfBadges = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    /*static void Main()
    {
        List<Trainer> data = new List<Trainer>();
        string input;
        while ((input = Console.ReadLine()) != "Tournament")
        {
            string[] tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string trainer = tokens[0];
            string pokName = tokens[1];
            string pokElement = tokens[2];
            int pokHealt = int.Parse(tokens[3]);
            if (data.Any(tr => tr.Name == trainer))
            {
                var temp = data.FirstOrDefault(x => x.Name == trainer);
                int index = data.FindIndex(e => e == temp);
                var p = new Pokemon(pokName, pokElement, pokHealt);
                data[index].Pokemons.Add(p);
            }
            else
            {
                Trainer t = new Trainer(trainer, pokName, pokElement, pokHealt);
                data.Add(t);
            }
          
        }

        while ((input = Console.ReadLine()) != "End")
        {
            Asd(data, input);
        }
        foreach (var item in data.OrderByDescending(t => t.NumberOfBadges))
        {
            Console.WriteLine($"{item.Name} {item.NumberOfBadges} {item.Pokemons.Count}");
        }
    }

    private static void Asd(List<Trainer> data, string input)
    {
        
            for (int i = 0; i < data.Count; i++)
            {
                List<Pokemon> pok = data[i].Pokemons;
                bool hasElement = pok.Any(p => p.Element == input);
                if (hasElement)
                {
                    data[i].NumberOfBadges++;
                }
                else
                {
                    pok.ForEach(p => p.Health -= 10);
                    data[i].Pokemons = pok.Where(p => p.Health > 0).ToList();
                }
            }
        
    }*/
}

