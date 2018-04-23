using BashSoft;

public class MakeDirectoryCommand : Command
{
    public MakeDirectoryCommand(Tester judge, StudentsRepository repository, IOManager inputOutputManager, string[] data, string input) : base(judge, repository, inputOutputManager, data, input)
    {
    }

    public override void Execute()
    {
        if (this.Data.Length != 2)
        {
            throw new InvalidCommandException(this.Input);
        }
        string folderName = this.Data[1];
        this.InputOutputManager.CreateDirectoryInCurrentFolder(folderName);
    }
}
