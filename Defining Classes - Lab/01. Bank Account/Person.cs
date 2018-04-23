using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01._Bank_Account
{
    class Person
    {
        private string name;
        private int age;
        private List<BankAccount> accounts;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
            this.accounts = new List<BankAccount>();
        }
        public Person(string name, int age, List<BankAccount> accounts)
        {
            this.name = name;
            this.age = age;
            this.accounts = accounts;
        }
        public decimal GetBalance(int id)
        {
            return this.accounts[id].Balance;
        }

    }
}
