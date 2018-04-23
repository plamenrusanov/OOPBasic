using System;
using System.Collections.Generic;
using System.Text;
using BashSoft;
using System.Diagnostics;

public class OpenFileCommand : Command
{
    public OpenFileCommand(Tester judge, StudentsRepository repository, IOManager inputOutputManager, string[] data, string input) : base(judge, repository, inputOutputManager, data, input)
    {
    }

    public override void Execute()
    {
        if (this.Data.Length != 2)
        {
            throw new InvalidCommandException(this.Input);
        }
        string fileName = this.Data[1];
        Process.Start(SessionData.currentPath + "\\" + fileName);
    }
}
