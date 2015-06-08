namespace ConsolePhonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IOutput
    {
        void Add(string text);

        string ToString();
    }
}
