namespace CatalogOfFreeContent.CommandDispencer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class FindCommand : AbstractCommand
    {
        public FindCommand(ICatalog catalog, StringBuilder output)
            : base(catalog, output)
        {
        }

        public override void Execute(ICommand command)
        {
            if (command.Parameters.Length != 2)
            {
                throw new ArgumentException("The number of command paramenters must be 2");
            }

            int numberOfElementsToList = int.Parse(command.Parameters[1]);

            IEnumerable<IContent> foundContent = Catalog.GetListContent(command.Parameters[0], numberOfElementsToList);

            if (foundContent.Count() == 0)
            {
                Output.AppendLine("No items found");
            }
            else
            {
                foreach (IContent content in foundContent)
                {
                    Output.AppendLine(content.TextRepresentation);
                }
            }
        }
    }
}