namespace _03.RefactorLoop
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            string fugitiveName = "Pesho";
            string[] names = { "Ivancho", "Pesho", "Toshkata", "Iva", "Asq", "Desi" };
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]);
                if (names[i] == fugitiveName)
                {
                    Console.WriteLine("Fugitive found, call ze police!");
                    break;
                }
            }
        }
    }
}
