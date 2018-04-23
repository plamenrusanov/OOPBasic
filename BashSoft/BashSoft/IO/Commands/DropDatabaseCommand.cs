using System;
using System.Collections.Generic;
using System.Text;
using BashSoft;

public class DropDatabaseCommand : Command
{
    public DropDatabaseCommand(Tester judge, StudentsRepository repository, IOManager inputOutputManager, string[] data, string input) : base(judge, repository, inputOutputManager, data, input)
    {
    }

    public override void Execute()
    {
        if (this.Data.Length != 1)
        {
            this.DisplayInvalidCommandMessage(this.Input);
            return;
        }
        this.Repository.UnloadData();
        OutputWriter.WriteMessageOnNewLine("Database dropped!");
    }
}
