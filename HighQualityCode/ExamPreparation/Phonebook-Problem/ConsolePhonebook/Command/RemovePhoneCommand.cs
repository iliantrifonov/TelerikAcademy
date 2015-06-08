namespace ConsolePhonebook.Command
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RemovePhoneCommand : ICommand
    {
        private IPhonebookRepositoryWithRemove data;
        private IOutput output;

        public RemovePhoneCommand(IPhonebookRepositoryWithRemove data, IOutput output)
        {
            this.data = data;
            this.output = output;
        }

        public void Execute(string[] commandArguments)
        {
            try
            {
                this.data.Remove(commandArguments[0]);
            }
            catch (ArgumentOutOfRangeException)
            {
                this.output.Add("Phone number could not be found");
            }
            catch(ArgumentException)
            {
                this.output.Add("Invalid phone number");
            }
        }
    }
}
