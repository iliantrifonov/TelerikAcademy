namespace ConsolePhonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Output : IOutput
    {
        private StringBuilder output;

        public Output()
        {
            this.output = new StringBuilder();
        }

        public void Add(string text)
        {
            this.output.AppendLine(text);
        }

        public override string ToString()
        {
            return this.output.ToString();
        }
    }
}
