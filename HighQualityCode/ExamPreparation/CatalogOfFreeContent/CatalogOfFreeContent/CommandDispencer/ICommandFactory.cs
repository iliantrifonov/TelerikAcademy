namespace CatalogOfFreeContent.CommandDispencer
{
    public interface ICommandFactory
    {
        ICommandHandler GetCommandHandler(CommandType type);
    }
}
