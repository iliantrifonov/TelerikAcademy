using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePhonebook.Command
{
    public class CommandFactory : ICommandFactory
    {
        private Dictionary<string, ICommand> commandInstances;

        public CommandFactory(IPhoneConverter converter, IPhonebookRepositoryWithRemove data, IOutput output)
        {
            this.commandInstances = new Dictionary<string, ICommand>();
            this.commandInstances.Add("AddPhone", new AddPhoneCommand(converter, data, output));
            this.commandInstances.Add("ChangePhone", new ChangePhoneCommand(converter, data, output));
            this.commandInstances.Add("List", new ListCommand(data, output));
            this.commandInstances.Add("Remove", new RemovePhoneCommand(data, output));
        }

        public ICommand GetCommandInstance(string commandName, int argumentsCount)
        {
            if (!this.commandInstances.ContainsKey(commandName))
            {
                throw new ArgumentException(string.Format("The {0} command is invalid", commandName));
            }

            if (commandName == "AddPhone" && argumentsCount < 2)
            {
                throw new ArgumentException(string.Format("The amount of the entries is invalid ({0}).", argumentsCount));
            }

            if (commandName == "ChangePhone" && argumentsCount != 2)
            {
                throw new ArgumentException(string.Format("The amount of the entries is invalid ({0}).", argumentsCount));
            }

            if (commandName == "List" && argumentsCount != 2)
            {
                throw new ArgumentException(string.Format("The amount of the entries is invalid ({0}).", argumentsCount));
            }

            if (commandName == "Remove" && argumentsCount != 1)
            {
                throw new ArgumentException(string.Format("The amount of the entries is invalid ({0}).", argumentsCount));
            }

            return this.commandInstances[commandName];
        }
    }
}
