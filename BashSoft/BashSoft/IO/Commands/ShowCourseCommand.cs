using System;
using System.Collections.Generic;
using System.Text;
using BashSoft;

public class ShowCourseCommand : Command
{
    public ShowCourseCommand(Tester judge, StudentsRepository repository, IOManager inputOutputManager, string[] data, string input) : base(judge, repository, inputOutputManager, data, input)
    {
    }

    public override void Execute()
    {
        if (this.Data.Length == 2)
        {
            string courseName = this.Data[1];
            this.Repository.GetAllStudentsFromCourse(courseName);
        }
        else if (this.Data.Length == 3)
        {
            string courseName = this.Data[1];
            string userName = this.Data[2];
            this.Repository.GetStudentScoresFromCourse(courseName, userName);
        }
        else
        {
            this.DisplayInvalidCommandMessage(this.Input);
        }
    }
}
