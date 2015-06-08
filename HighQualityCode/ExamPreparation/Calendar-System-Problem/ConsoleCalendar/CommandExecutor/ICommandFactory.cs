namespace ConsoleCalendar.CommandExecutor
{
    public interface ICommandFactory
    {
        ICommandExecutor GetCommandExecutor(string commandName);
    }
}
