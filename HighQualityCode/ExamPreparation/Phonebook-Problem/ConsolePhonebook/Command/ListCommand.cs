namespace ConsolePhonebook.Command
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ListCommand : ICommand
    {
        private IPhonebookRepository data;
        private IOutput output;

        public ListCommand(IPhonebookRepository data, IOutput output)
        {
            this.data = data;
            this.output = output;
        }

        public void Execute(string[] commandArguments)
        {
            try
            {
                IEnumerable<PhonebookEntry> entries = this.data.ListEntries(int.Parse(commandArguments[0]), int.Parse(commandArguments[1]));
                foreach (var entry in entries)
                {
                    this.output.Add(entry.ToString());
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                this.output.Add("Invalid range");
            }
        }
    }
}
