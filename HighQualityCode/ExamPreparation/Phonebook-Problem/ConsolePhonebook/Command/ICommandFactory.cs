namespace ConsolePhonebook.Command
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICommandFactory
    {
        ICommand GetCommandInstance(string commandName, int argumentsCount);
    }
}
