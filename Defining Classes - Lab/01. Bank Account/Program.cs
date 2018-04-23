using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, BankAccount> bank = new Dictionary<int, BankAccount>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var cmdArgs = input.Split();
            var cmdType = cmdArgs[0];
            switch (cmdType)
            {
                case "Create":
                    Create(cmdArgs, bank);
                    break;
                case "Deposit":
                    Deposit(cmdArgs, bank);
                    break;
                case "Withdraw":
                    Withdraw(cmdArgs, bank);
                    break;
                case "Print":
                    Print(cmdArgs, bank);
                    break;
                default:
                    break;
            }
        }

    }

    private static void Print(string[] cmdArgs, Dictionary<int, BankAccount> bank)
    {
        int id = int.Parse(cmdArgs[1]);
        if (!bank.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            Console.WriteLine(bank[id].ToString());
        }
    }

    private static void Withdraw(string[] cmdArgs, Dictionary<int, BankAccount> bank)
    {
        int id = int.Parse(cmdArgs[1]);
        decimal amount = decimal.Parse(cmdArgs[2]);
        if (!bank.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else if (bank[id].Balance < amount)
        {
            Console.WriteLine("Insufficient balance");
        }
        else
        {
            bank[id].Withdraw(amount);
        }
    }

    private static void Deposit(string[] cmdArgs, Dictionary<int, BankAccount> bank)
    {
        int id = int.Parse(cmdArgs[1]);
        decimal amount = decimal.Parse(cmdArgs[2]);
        if (!bank.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            bank[id].Deposit(amount);
        }

    }

    private static void Create(string[] cmdArgs, Dictionary<int, BankAccount> bank)
    {
        var id = int.Parse(cmdArgs[1]);
        if (bank.ContainsKey(id))
        {
            Console.WriteLine("Account already exists");
        }
        else
        {
            var acc = new BankAccount();
            acc.Id = id;
            bank.Add(id, acc);
        }
    }
}

