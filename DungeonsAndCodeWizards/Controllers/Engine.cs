using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engine
{
    private StringBuilder sb;
    DungeonMaster dungeonMaster;

    public Engine()
    {
        this.sb = new StringBuilder();
        this.dungeonMaster = new DungeonMaster();
    }

    public void Run()
    {
       
        while (!dungeonMaster.IsGameOver())
        {
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                break;
            }
            string[] tokens = input.Split();
            string command = tokens[0];
            tokens = tokens.Skip(1).ToArray();

            try
            {
                
                switch (command)
                {
                    case "JoinParty":
                        sb.AppendLine(dungeonMaster.JoinParty(tokens));
                        break;
                    case "AddItemToPool":
                        sb.AppendLine(dungeonMaster.AddItemToPool(tokens));
                        break;
                    case "PickUpItem":
                        sb.AppendLine(dungeonMaster.PickUpItem(tokens));
                        break;
                    case "UseItem":
                        sb.AppendLine(dungeonMaster.UseItem(tokens));
                        break;
                    case "UseItemOn":
                        sb.AppendLine(dungeonMaster.UseItemOn(tokens));
                        break;
                    case "GiveCharacterItem":
                        sb.AppendLine(dungeonMaster.GiveCharacterItem(tokens));
                        break;
                    case "GetStats":
                        sb.AppendLine(dungeonMaster.GetStats());
                        break;
                    case "Attack":
                        sb.AppendLine(dungeonMaster.Attack(tokens));
                        break;
                    case "Heal":
                        sb.AppendLine(dungeonMaster.Heal(tokens));
                        break;
                    case "EndTurn":
                        sb.AppendLine(dungeonMaster.EndTurn(tokens));
                        break;                
                    default:
                        break;
                }
            }
            catch (ArgumentException ae)
            {
                sb.AppendLine($"Parameter Error: {ae.Message}");
            }
            catch (InvalidOperationException ioe)
            {
                sb.AppendLine($"Invalid Operation: {ioe.Message}");
            }
        }
        sb.AppendLine("Final stats:")
            .AppendLine(dungeonMaster.GetStats());
        Console.WriteLine(sb.ToString().Trim());
    }
}
