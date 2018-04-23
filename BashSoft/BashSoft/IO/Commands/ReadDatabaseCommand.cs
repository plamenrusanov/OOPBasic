using System;
using System.Collections.Generic;
using System.Text;
using BashSoft;

public class ReadDatabaseCommand : Command
{
    public ReadDatabaseCommand(Tester judge, StudentsRepository repository, IOManager inputOutputManager, string[] data, string input) : base(judge, repository, inputOutputManager, data, input)
    {
    }

    public override void Execute()
    {
        string fileName = this.Data[1];
        this.Repository.LoadData(fileName);
    }
}
