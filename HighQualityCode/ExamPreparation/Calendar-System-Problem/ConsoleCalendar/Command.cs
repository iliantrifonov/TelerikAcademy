namespace ConsoleCalendar
{
    public struct Command
    {
        public Command(string name, string[] commandArguments) : this()
        {
            this.CommandName = name;
            this.Arguments = commandArguments;
        }

        public string CommandName { get; private set; }

        public string[] Arguments { get; private set; }        
    }
}