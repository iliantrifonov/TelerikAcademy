namespace CatalogOfFreeContent.CommandDispencer
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CommandFactory : ICommandFactory
    {
        private Dictionary<CommandType, ICommandHandler> commands;

        public CommandFactory(ICatalog catalog, StringBuilder output)
        {
            var addApp = new AddApplicationCommand(catalog, output);
            var addBook = new AddBookCommand(catalog, output);
            var addMovie = new AddMovieCommand(catalog, output);
            var addSong = new AddSongCommand(catalog, output);
            var find = new FindCommand(catalog, output);
            var update = new UpdateCommand(catalog, output);

            this.commands = new Dictionary<CommandType, ICommandHandler>();

            this.commands.Add(CommandType.AddApplication, addApp);
            this.commands.Add(CommandType.AddBook, addBook);
            this.commands.Add(CommandType.AddMovie, addMovie);
            this.commands.Add(CommandType.AddSong, addSong);
            this.commands.Add(CommandType.Find, find);
            this.commands.Add(CommandType.Update, update);
        }

        public ICommandHandler GetCommandHandler(CommandType type)
        {
            if (!this.commands.ContainsKey(type))
            {
                throw new ArgumentException(string.Format("Invalid type {0}", type));
            }

            return this.commands[type];
        }
    }
}
