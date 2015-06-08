namespace CatalogOfFreeContent.CommandDispencer
{
    using System.Text;

    public abstract class AbstractCommand : ICommandHandler
    {
        public AbstractCommand(ICatalog catalog, StringBuilder output)
        {
            this.Catalog = catalog;
            this.Output = output;
        }
        
        protected ICatalog Catalog { get; set; }

        protected StringBuilder Output { get; set; }

        public abstract void Execute(ICommand command);
    }
}
