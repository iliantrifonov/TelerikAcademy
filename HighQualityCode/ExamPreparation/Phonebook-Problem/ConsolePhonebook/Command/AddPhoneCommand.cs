namespace ConsolePhonebook.Command
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AddPhoneCommand : ICommand
    {
        private IPhoneConverter converter;
        private IPhonebookRepository data;
        private IOutput output;

        public AddPhoneCommand(IPhoneConverter converter, IPhonebookRepository data, IOutput output)
        {
            this.converter = converter;
            this.data = data;
            this.output = output;
        }

        public void Execute(string[] commandArguments)
        {
            string holderName = commandArguments[0];
            var phoneEntries = commandArguments.Skip(1).ToList();
            for (int i = 0; i < phoneEntries.Count; i++)
            {
                phoneEntries[i] = this.converter.Convert(phoneEntries[i]);
            }

            bool isNewContact = this.data.AddPhone(holderName, phoneEntries);

            if (isNewContact)
            {
                this.output.Add("Phone entry created");
            }
            else
            {
                this.output.Add("Phone entry merged");
            }
        }
    }
}
