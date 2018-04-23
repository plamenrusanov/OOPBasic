using System;
using System.Collections.Generic;
using System.Text;
using BashSoft;

public class ChangeAbsolutePathCommand : Command
{
    public ChangeAbsolutePathCommand(Tester judge, StudentsRepository repository, IOManager inputOutputManager, string[] data, string input) : base(judge, repository, inputOutputManager, data, input)
    {
    }

    public override void Execute()
    {
        string absPath = this.Data[1];
        this.InputOutputManager.ChangeCurrentDirectoryAbsolute(absPath);
    }
}
