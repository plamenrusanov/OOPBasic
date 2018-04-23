using System;

namespace Mankind
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] studentArg = Console.ReadLine().Split();
                string firstName = studentArg[0];
                string lastName = studentArg[1];
                string facultyNamber = studentArg[2];
                Student student = new Student(firstName, lastName, facultyNamber);

                string[] workerArg = Console.ReadLine().Split();
                string firstN = workerArg[0];
                string lastN = workerArg[1];
                decimal weekSalary = decimal.Parse(workerArg[2]);
                decimal HoursPerDay = decimal.Parse(workerArg[3]);
                Worker worker = new Worker(firstN, lastN, weekSalary, HoursPerDay);

                Console.WriteLine(student);
                Console.WriteLine(worker);
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
        }
    }
}
