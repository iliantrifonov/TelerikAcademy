namespace CatalogOfFreeContent.CommandDispencer
{
    using System;
    using System.Text;

    public class UpdateCommand : AbstractCommand
    {
        public UpdateCommand(ICatalog catalog, StringBuilder output)
            : base(catalog, output)
        {
        }

        public override void Execute(ICommand command)
        {
            if (command.Parameters.Length != 2)
            {
                throw new ArgumentException("The number of command paramenters must be 2");
            }

            var numberOfUpdatedItems = Catalog.UpdateContent(command.Parameters[0], command.Parameters[1]);
            Output.AppendLine(string.Format("{0} items updated", numberOfUpdatedItems));
        }
    }
}
