using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BashSoft
{
    public class RepositoryFilter
    {
        public void FilterAndTake(Dictionary<string, double> sudentsWithMarks, string wantedFilter, int studentsToTake)
        {
            if (wantedFilter == "exellent")
            {
                FilterAndTake(sudentsWithMarks, x => x >= 5, studentsToTake);
            }
            else if (wantedFilter == "average")
            {
                FilterAndTake(sudentsWithMarks, x => x < 5 && x >= 3.5, studentsToTake);
            }
            else if (wantedFilter == "poor")
            {
                FilterAndTake(sudentsWithMarks, x => x < 3.5, studentsToTake);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidStudentFilter);
            }
        }

        private void FilterAndTake(Dictionary<string, double> sudentsWithMarks, Predicate<double> givenFilter, int studentsToTake)
        {
            int counterForPrinted = 0;
            foreach (var userName_Points in sudentsWithMarks)
            {
                if (counterForPrinted == studentsToTake)
                {
                    break;
                }

                if (givenFilter(userName_Points.Value))
                {
                    StudentsRepository studentsRepository = new StudentsRepository(new RepositoryFilter(), new RepositorySorters());
                    studentsRepository.PrintStudent(userName_Points);
                    counterForPrinted++;
                }
            }

        }

        private double Average(List<int> scoresOnTask)
        {
            int totalScore = 0;

            foreach (var score in scoresOnTask)
            {
                totalScore += score;
            }
            var persentageOfAll = totalScore / (scoresOnTask.Count * 100);
            var mark = persentageOfAll * 4 + 2;
            return mark;
        }
    }
}
