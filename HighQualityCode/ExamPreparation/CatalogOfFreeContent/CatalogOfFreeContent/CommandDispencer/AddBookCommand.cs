namespace CatalogOfFreeContent.CommandDispencer
{
    using System.Text;

    public class AddBookCommand : AbstractCommand
    {
        public AddBookCommand(ICatalog catalog, StringBuilder output) : base(catalog, output) 
        { 
        }

        public override void Execute(ICommand command)
        {
            this.Catalog.Add(new Content(ContentType.Book, command.Parameters));
            this.Output.AppendLine("Book added");
        }
    }
}
