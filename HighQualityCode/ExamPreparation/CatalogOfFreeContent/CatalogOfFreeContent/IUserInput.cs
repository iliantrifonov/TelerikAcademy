namespace CatalogOfFreeContent
{
    using System.Collections.Generic;

    public interface IUserInput
    {
        IEnumerable<ICommand> GetCommands();
    }
}
