namespace ConsolePhonebook.Command
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ChangePhoneCommand : ICommand
    {
        private IPhoneConverter converter;
        private IPhonebookRepository data;
        private IOutput output;

        public ChangePhoneCommand(IPhoneConverter converter, IPhonebookRepository data, IOutput output)
        {
            this.converter = converter;
            this.data = data;
            this.output = output;
        }

        public void Execute(string[] commandArguments)
        {
            var changedCount = this.data.ChangePhone(this.converter.Convert(commandArguments[0]), this.converter.Convert(commandArguments[1]));

            this.output.Add(string.Format("{0} numbers changed", changedCount));
        }
    }
}
