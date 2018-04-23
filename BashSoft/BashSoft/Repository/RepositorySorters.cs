using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BashSoft
{
    public class RepositorySorters
    {
        public void OrderAndTake(Dictionary<string, double> wantedData, string comparison, int studentsToTake)
        {
            comparison = comparison.ToLower();
            if (comparison == "ascending")
            {
                PrintStudents(wantedData.OrderBy(x => x.Value)
                    .Take(studentsToTake)
                    .ToDictionary(pear => pear.Key, pear => pear.Value));
            }
            else if (comparison == "descending")
            {
                PrintStudents(wantedData.OrderByDescending(x => x.Value)
                    .Take(studentsToTake)
                    .ToDictionary(pear => pear.Key, pear => pear.Value));
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidStudentFilter);
            }
        }

        private void PrintStudents (Dictionary<string, double> sortedStudents)
        {
            foreach (var item in sortedStudents)
            {
                StudentsRepository studentsRepository = new StudentsRepository(new RepositoryFilter(), new RepositorySorters());
                studentsRepository.PrintStudent(item);
            }
        }     
    }
}
