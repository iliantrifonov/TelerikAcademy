namespace CatalogOfFreeContent.CommandDispencer
{
    using System.Text;

    public class AddApplicationCommand : AbstractCommand
    {
        public AddApplicationCommand(ICatalog catalog, StringBuilder output)
            : base(catalog, output)
        {
        }

        public override void Execute(ICommand command)
        {
            this.Catalog.Add(new Content(ContentType.Application, command.Parameters));

            this.Output.AppendLine("Application added");
        }
    }
}
