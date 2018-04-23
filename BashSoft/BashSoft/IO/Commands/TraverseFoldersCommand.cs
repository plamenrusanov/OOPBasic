﻿using System;
using System.Collections.Generic;
using System.Text;
using BashSoft;

public class TraverseFoldersCommand : Command
{
    public TraverseFoldersCommand(Tester judge, StudentsRepository repository, IOManager inputOutputManager, string[] data, string input) : base(judge, repository, inputOutputManager, data, input)
    {
    }

    public override void Execute()
    {
        if (this.Data.Length == 1)
        {
            this.InputOutputManager.TraverseDirectory(0);
        }
        else if (this.Data.Length == 2)
        {
            int depth;
            bool hasParsed = int.TryParse(this.Data[1], out depth);
            if (hasParsed)
            {
                this.InputOutputManager.TraverseDirectory(depth);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.UnableToParseNumber);
            }
        }
    }
}
