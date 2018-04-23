using System;
using System.IO;

namespace BashSoft
{
    class Launcher
    {
        static void Main(string[] args)
        {
            Tester tester = new Tester();
            IOManager iOManager = new IOManager();
            StudentsRepository repo = new StudentsRepository(new RepositoryFilter(), new RepositorySorters());

            CommandInterpreter interpreter = new CommandInterpreter(tester, repo, iOManager);
            InputReader reader = new InputReader(interpreter);
           
            reader.StartReadingCommands();
        }
    }
}
