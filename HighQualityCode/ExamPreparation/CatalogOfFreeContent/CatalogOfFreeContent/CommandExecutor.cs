namespace CatalogOfFreeContent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CommandExecutor : ICommandExecutor
    {
        public void ExecuteCommand(ICatalog catalogue, ICommand command, StringBuilder output)
        {
            switch (command.Type)
            {
                case CommandType.AddBook:
                    {
                        catalogue.Add(new Content(ContentType.Book, command.Parameters));
                        output.AppendLine("Book added");
                    }

                    break;
                case CommandType.AddMovie:
                    {
                        catalogue.Add(new Content(ContentType.Movie, command.Parameters));

                        output.AppendLine("Movie added");
                    }

                    break;
                case CommandType.AddSong:
                    {
                        catalogue.Add(new Content(ContentType.Song, command.Parameters));

                        output.AppendLine("Song added");
                    }

                    break;
                case CommandType.AddApplication:
                    {
                        catalogue.Add(new Content(ContentType.Application, command.Parameters));

                        output.AppendLine("Application added");
                    }

                    break;
                case CommandType.Update:
                    {
                        if (command.Parameters.Length != 2)
                        {
                            throw new ArgumentException("The number of command paramenters must be 2");
                        }

                        var numberOfUpdatedItems = catalogue.UpdateContent(command.Parameters[0], command.Parameters[1]);
                        output.AppendLine(string.Format("{0} items updated", numberOfUpdatedItems));
                    }

                    break;
                case CommandType.Find:
                    {
                        if (command.Parameters.Length != 2)
                        {
                            throw new ArgumentException("The number of command paramenters must be 2");
                        }

                        int numberOfElementsToList = int.Parse(command.Parameters[1]);

                        IEnumerable<IContent> foundContent = catalogue.GetListContent(command.Parameters[0], numberOfElementsToList);

                        if (foundContent.Count() == 0)
                        {
                            output.AppendLine("No items found");
                        }
                        else
                        {
                            foreach (IContent content in foundContent)
                            {
                                output.AppendLine(content.TextRepresentation);
                            }
                        }
                    }

                    break;
                default:
                    {
                        throw new ArgumentException(string.Format("Command type {0} is invalid.", command.Type));
                    }
            }
        }
    }
}