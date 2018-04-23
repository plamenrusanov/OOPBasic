using System;
using System.Collections.Generic;
using System.Text;
using BashSoft;

public class PrintFilteredStudentsCommand : Command
{
    public PrintFilteredStudentsCommand(Tester judge, StudentsRepository repository, IOManager inputOutputManager, string[] data, string input) : base(judge, repository, inputOutputManager, data, input)
    {
    }

    public override void Execute()
    {
        if (this.Data.Length == 5)
        {
            string courseName = this.Data[1];
            string filter = this.Data[2].ToLower();
            string takeCommand = this.Data[3].ToLower();
            string takeQuantity = this.Data[4].ToLower();
            TryParseParametersForFilterAndTake(takeQuantity, takeCommand, filter, courseName);
        }
        else
        {
            DisplayInvalidCommandMessage(this.Input);
        }
    }

    private void TryParseParametersForFilterAndTake(string takeQuantity, string takeCommand, string filter, string courseName)
    {
        if (takeCommand == "take")
        {
            if (takeQuantity == "all")
            {
                this.Repository.FilterAndTake(courseName, filter);
            }
            else
            {
                int studenToTake;
                bool hasParsed = int.TryParse(takeQuantity, out studenToTake);
                if (hasParsed)
                {
                    this.Repository.FilterAndTake(courseName, filter, studenToTake);
                }
            }

        }
        else
        {
            OutputWriter.DisplayException(ExceptionMessages.InvalidTakeQuantityParameter);
        }
    }
}
