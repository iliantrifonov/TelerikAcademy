namespace ConsoleCalendar.CommandExecutor
{
    public abstract class AbstractCommand : ICommandExecutor
    {
        protected AbstractCommand(IEventsManager eventManager)
        {
            this.EventManager = eventManager;
        }     
        
        protected IEventsManager EventManager { get; set; }

        public abstract string Execute(Command command);
    }
}
