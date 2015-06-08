namespace CatalogOfFreeContent.CommandDispencer
{
    using System.Text;

    public class AddSongCommand : AbstractCommand
    {
        public AddSongCommand(ICatalog catalog, StringBuilder output)
            : base(catalog, output)
        {
        }

        public override void Execute(ICommand command)
        {
            this.Catalog.Add(new Content(ContentType.Song, command.Parameters));

            this.Output.AppendLine("Song added");
        }
    }
}