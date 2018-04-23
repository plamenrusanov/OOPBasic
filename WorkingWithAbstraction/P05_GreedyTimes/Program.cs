using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class Program
    {
        static Dictionary<string, Dictionary<string, long>> data;
        static long gold = 0;
        static long gem = 0;
        static long cash = 0;
        static long bagCapasity;
        static void Main(string[] args)
        {
            bagCapasity = long.Parse(Console.ReadLine());
            data = new Dictionary<string, Dictionary<string, long>>();
            string[] treasureArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < treasureArgs.Length; i += 2)
            {
                if (treasureArgs[i].Length == 3)
                {
                    string currentCash = treasureArgs[i];
                    long currentQuantity = long.Parse(treasureArgs[i + 1]);
                    AddDataCash(currentCash, currentQuantity);
                    
                }
                else if (treasureArgs[i].ToLower() == "gold")
                {
                    long currentQuantity = long.Parse(treasureArgs[i + 1]);
                    AddDataGold(currentQuantity);
                }
                else if (treasureArgs[i].Length >= 4 && treasureArgs[i].ToLower().EndsWith("gem"))
                {
                    string currentGem = treasureArgs[i];
                    long currentQuantity = long.Parse(treasureArgs[i + 1]);
                    AddDataGem(currentGem, currentQuantity);
                }
                
            }

            PrintResult();

            {


                /*
                long bagCapacity = long.Parse(Console.ReadLine());
                string[] seif = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var bag = new Dictionary<string, Dictionary<string, long>>();
                long gold = 0;
                long gem = 0;
                long cash = 0;

                for (int i = 0; i < seif.Length; i += 2)
                {
                    string name = seif[i];
                    long broika = long.Parse(seif[i + 1]);

                    string kvoE = string.Empty;

                    if (name.Length == 3)
                    {
                        kvoE = "Cash";
                    }
                    else if (name.ToLower().EndsWith("gem"))
                    {
                        kvoE = "Gem";
                    }
                    else if (name.ToLower() == "gold")
                    {
                        kvoE = "Gold";
                    }

                    if (kvoE == "")
                    {
                        continue;
                    }
                    else if (bagCapacity < bag.Values.Select(x => x.Values.Sum()).Sum() + broika)
                    {
                        continue;
                    }

                    switch (kvoE)
                    {
                        case "Gem":
                            if (!bag.ContainsKey(kvoE))
                            {
                                if (bag.ContainsKey("Gold"))
                                {
                                    if (broika > bag["Gold"].Values.Sum())
                                    {
                                        continue;
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            else if (bag[kvoE].Values.Sum() + broika > bag["Gold"].Values.Sum())
                            {
                                continue;
                            }
                            break;
                        case "Cash":
                            if (!bag.ContainsKey(kvoE))
                            {
                                if (bag.ContainsKey("Gem"))
                                {
                                    if (broika > bag["Gem"].Values.Sum())
                                    {
                                        continue;
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            else if (bag[kvoE].Values.Sum() + broika > bag["Gem"].Values.Sum())
                            {
                                continue;
                            }
                            break;
                    }

                    if (!bag.ContainsKey(kvoE))
                    {
                        bag[kvoE] = new Dictionary<string, long>();
                    }

                    if (!bag[kvoE].ContainsKey(name))
                    {
                        bag[kvoE][name] = 0;
                    }

                    bag[kvoE][name] += broika;
                    if (kvoE == "Gold")
                    {
                        gold += broika;
                    }
                    else if (kvoE == "Gem")
                    {
                        gem += broika;
                    }
                    else if (kvoE == "Cash")
                    {
                        cash += broika;
                    }
                }

                foreach (var x in bag)
                {
                    Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");
                    foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                    {
                        Console.WriteLine($"##{item2.Key} - {item2.Value}");
                    }
                }*/
            }
        }

        private static void AddDataCash(string currentCash, long currentQuantity)
        {
            if (!IsFullBag(currentQuantity) && cash + currentQuantity <= gem)
            {
                if (!data.ContainsKey("Cash"))
                {
                    data.Add("Cash", new Dictionary<string, long>());
                }
                if (!data["Cash"].ContainsKey(currentCash))
                {
                    data["Cash"].Add(currentCash, 0);
                }
                data["Cash"][currentCash] += currentQuantity;
                cash += currentQuantity;
            }
        }

        private static void PrintResult()
        {
            foreach (var x in data)
            {
                Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");
                foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
            
        }

        private static void AddDataGem(string currentGem, long currentQuantity)
        {

            if (!IsFullBag(currentQuantity) && gem + currentQuantity <= gold)
            {
                if (!data.ContainsKey("Gem"))
                {
                    data.Add("Gem", new Dictionary<string, long>());
                }
                if (!data["Gem"].ContainsKey(currentGem))
                {
                    data["Gem"].Add(currentGem, 0);
                }
                data["Gem"][currentGem] += currentQuantity;
                gem += currentQuantity;
            }
        }

        private static void AddDataGold(long currentQuantity)
        {
         
            if (!IsFullBag(currentQuantity))
            {
                if (!data.ContainsKey("Gold"))
                {
                    data.Add("Gold", new Dictionary<string, long>());
                }
                if (!data["Gold"].ContainsKey("Gold"))
                {
                    data["Gold"].Add("Gold", 0);
                }
                data["Gold"]["Gold"] += currentQuantity;
                gold += currentQuantity;
            }
        }

        private static bool IsFullBag(long currentQuantity)
        {
            if (bagCapasity >= SumQuantity() + currentQuantity)
            {
                return false;
            }
            return true;
        }

        private static long SumQuantity()
        {
            return gold + gem + cash;
        }

       
    }
}