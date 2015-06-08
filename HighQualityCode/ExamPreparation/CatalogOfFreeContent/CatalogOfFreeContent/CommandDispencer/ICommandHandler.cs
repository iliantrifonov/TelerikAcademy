namespace CatalogOfFreeContent.CommandDispencer
{
    public interface ICommandHandler
    {
        void Execute(ICommand command);
    }
}
