using BashSoft;
using System;
using System.Collections.Generic;
using System.Text;

public abstract class Command
{
    private string input;
    private string[] data;
    private Tester judge;
    private StudentsRepository repository;
    private IOManager inputOutputManager;
   

    public Command(Tester judge, StudentsRepository repository, IOManager inputOutputManager, string[] data, string input)
    {
        this.judge = judge;
        this.repository = repository;
        this.inputOutputManager = inputOutputManager;
        Data = data;
        Input = input;
    }

    protected string[] Data
    {
        get { return this.data; }
        private set
        {
            if (value == null || value.Length == 0)
            {
                throw new NullReferenceException();
            }
            data = value;
        }
    }

    protected string Input
    {
        get { return this.input; }
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidStringException();
            }
            input = value;
        }
    }

    protected Tester Judge
    {
        get { return this.judge; }
    }

    protected StudentsRepository Repository
    {
        get { return this.repository; }
    }

    protected IOManager InputOutputManager
    {
        get { return this.inputOutputManager; }
    }

    public void DisplayInvalidCommandMessage(string input)
    {
        OutputWriter.DisplayException($"The command '{input}' is invalid");
    }

    public abstract void Execute();
}
