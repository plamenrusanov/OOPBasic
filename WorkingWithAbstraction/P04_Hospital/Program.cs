using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            List<Doctor> doctors = new List<Doctor>();
            List<Departments> departments = new List<Departments>();
            AddPatients(doctors, departments);
            
            DisplayConditions(doctors, departments);
                    
        }

        private static void AddPatients(List<Doctor> doctors, List<Departments> departments)
        {
            string input;
            while ((input = Console.ReadLine()) != "Output")
            {
                string[] patientData = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string docName = $"{patientData[1]} {patientData[2]}";
                Doctor doctor = doctors.FirstOrDefault(d => d.Name == docName);
                if (doctor == null)
                {
                    doctor = new Doctor(patientData);
                    doctors.Add(doctor);
                }
                else
                {
                    doctor.Patients.Add(patientData[3]);
                }
                Departments department = departments.FirstOrDefault(d => d.Name == patientData[0]);
                if (department == null)
                {
                    department = new Departments(patientData);
                    departments.Add(department);
                }
                else
                {
                    department.AddPatient(patientData[3]);
                }
            }
        }

        private static void DisplayConditions(List<Doctor> doctors, List<Departments> departments)
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] printArguments = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


                if (printArguments.Length == 1)
                {
                    Departments department = departments.FirstOrDefault(d => d.Name == printArguments[0]);
                    department.PrintDepartment();
                }
                else
                {
                    int room = -1;
                    bool isParse = int.TryParse(printArguments[1], out room);
                    if (isParse)
                    {
                        Departments department = departments.FirstOrDefault(d => d.Name == printArguments[0]);
                        department.PrintRoom(room);
                    }
                    else
                    {
                        string docName = $"{printArguments[0]} {printArguments[1]}";
                        Doctor doctor = doctors.FirstOrDefault(d => d.Name == docName);
                        Console.WriteLine(string.Join(Environment.NewLine, doctor.Patients.OrderBy(p => p)));
                    }
                }
            }

        }
    }
}
