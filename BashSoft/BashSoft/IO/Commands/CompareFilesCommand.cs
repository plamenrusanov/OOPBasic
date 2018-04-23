﻿using System;
using System.Collections.Generic;
using System.Text;
using BashSoft;

public class CompareFilesCommand : Command
{
    public CompareFilesCommand(Tester judge, StudentsRepository repository, IOManager inputOutputManager, string[] data, string input) : base(judge, repository, inputOutputManager, data, input)
    {
    }

    public override void Execute()
    {
        if (this.Data.Length == 3)
        {
            string firstPath = this.Data[1];
            string secondPath = this.Data[2];
            this.Judge.CompareContent(firstPath, secondPath);
        }
    }
}
