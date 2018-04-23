using System;
using System.Collections.Generic;
using System.Text;
using BashSoft;

public class ChangeRelativePathCommand : Command
{
    public ChangeRelativePathCommand(Tester judge, StudentsRepository repository, IOManager inputOutputManager, string[] data, string input) : base(judge, repository, inputOutputManager, data, input)
    {
    }

    public override void Execute()
    {
        string relPath = this.Data[1];
        this.InputOutputManager.ChangeCurrentDirectoryRelative(relPath);
    }
}
