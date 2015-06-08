namespace CatalogOfFreeContent
{
    using System;
    using System.Text;
    using CatalogOfFreeContent.CommandDispencer;

    public class EntryPoint
    {
        public static void Main()
        {
            StringBuilder output = new StringBuilder();
            ICatalog catalog = new Catalog();
            var factory = new CommandFactory(catalog, output);
            var input = new UserInput();

            var commandList = input.GetCommands();
            foreach (ICommand command in commandList)
            {
                var commandExec = factory.GetCommandHandler(command.Type);
                commandExec.Execute(command);
            }

            Console.Write(output);
        }
    }
}