namespace CatalogOfFreeContent.CommandDispencer
{
    using System.Text;

    public class AddMovieCommand : AbstractCommand
    {
        public AddMovieCommand(ICatalog catalog, StringBuilder output)
            : base(catalog, output)
        {
        }

        public override void Execute(ICommand command)
        {
            this.Catalog.Add(new Content(ContentType.Movie, command.Parameters));

            this.Output.AppendLine("Movie added");
        }
    }
}
