using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace BashSoft
{
    public class CommandInterpreter
    {
        private Tester judge;
        private StudentsRepository repository;
        private IOManager inputOutputManager;

        public CommandInterpreter(Tester judge, StudentsRepository repository, IOManager inputOutputManager)
        {
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        public void InterpredCommand(string input)
        {
            string[] data = input.Split(' ');
            string commandName = data[0];
            try
            {
                Command command = this.ParseCommand(input, commandName, data);
                command.Execute();

            }
            catch (ArgumentOutOfRangeException aoore)
            {
                OutputWriter.DisplayException(aoore.Message);
            }
            catch (DirectoryNotFoundException dnfe)
            {
                OutputWriter.DisplayException(dnfe.Message);
            }
            catch (ArgumentException ae)
            {
                OutputWriter.DisplayException(ae.Message);
            }
            catch (Exception e)
            {
                OutputWriter.DisplayException(e.Message);
            }

        }

        private Command ParseCommand(string input, string command, string[] data)
        {
            switch (command)
            {
                case "open":
                    return new OpenFileCommand(this.judge, this.repository, this.inputOutputManager, data, input);
                
                case "mkdir":
                    return new MakeDirectoryCommand(this.judge, this.repository, this.inputOutputManager, data, input);
              
                case "ls":
                    return new TraverseFoldersCommand(this.judge, this.repository, this.inputOutputManager, data, input);
              
                case "cmp":
                    return new CompareFilesCommand(this.judge, this.repository, this.inputOutputManager, data, input);
               
                case "cdRel":
                    return new ChangeRelativePathCommand(this.judge, this.repository, this.inputOutputManager, data, input);
             
                case "cdAbs":
                    return new ChangeAbsolutePathCommand(this.judge, this.repository, this.inputOutputManager, data, input);
             
                case "readDb":
                    return new ReadDatabaseCommand(this.judge, this.repository, this.inputOutputManager, data, input);
               
                case "help":
                    return new GetHelpCommand(this.judge, this.repository, this.inputOutputManager, data, input);
              
                case "filter":
                    return new PrintFilteredStudentsCommand(this.judge, this.repository, this.inputOutputManager, data, input);
           
                case "order":
                    return new PrintOrderedStudentsCommand(this.judge, this.repository, this.inputOutputManager, data, input);
             
                case "decOrder":
                    return null;

                case "download":
                    return null;

                case "downloadAsynch":
                    return null;

                case "show":
                    return new ShowCourseCommand(this.judge, this.repository, this.inputOutputManager, data, input);
            
                case "dropdb":
                    return new DropDatabaseCommand(this.judge, this.repository, this.inputOutputManager, data, input);
              
                default:
                    throw new InvalidCommandException(input);
            }
        }
    }
}
