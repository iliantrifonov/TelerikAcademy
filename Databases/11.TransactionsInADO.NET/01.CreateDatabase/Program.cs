namespace _01.CreateDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main(string[] args)
        {
            var context = new AtmContext();
            context.CardAccounts.All(x => 1 == 1);
        }
    }
}
