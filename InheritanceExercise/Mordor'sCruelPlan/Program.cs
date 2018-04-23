using System;

namespace Mordor_sCruelPlan
{
    class Program
    {
        static void Main(string[] args)
        {
            int happiness = 0;

            string[] inputFood = Console.ReadLine().Split(' ');

            for (int i = 0; i < inputFood.Length; i++)
            {
                switch (inputFood[i].ToLower())
                {
                    case "cram":
                        happiness += 2;
                        break;
                    case "lembas":
                        happiness += 3;
                        break;
                    case "apple":
                        happiness += 1;
                        break;
                    case "melon":
                        happiness += 1;
                        break;
                    case "honeycake":
                        happiness += 5;
                        break;
                    case "mushrooms":
                        happiness -= 10;
                        break;
                    default:
                        happiness -= 1;
                        break;
                }
            }

            if (happiness < -5)
            {
                Console.WriteLine($"{happiness}\nAngry");
            }
            else if (happiness <= 0)
            {
                Console.WriteLine($"{happiness}\nSad");
            }
            else if (happiness <= 15)
            {
                Console.WriteLine($"{happiness}\nHappy");
            }
            else
            {
                Console.WriteLine($"{happiness}\nJavaScript");
            }
        }
    }
}
