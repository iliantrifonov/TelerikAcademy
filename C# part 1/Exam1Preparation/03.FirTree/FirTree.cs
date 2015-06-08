using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.FirTree
{
    class FirTree
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int rows = 0; rows < 1; rows++)
            {
                for (int position = 0; position < n + (n - 3); position++)
                {
                    if (position == (n + (n - 3)) / 2)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
            for (int rows = 1; rows < n - 1; rows++)
            {
                for (int position = 0; position < n + (n - 3); position++)
                {
                    if (position == ((n + (n - 3)) / 2 + rows) || position == ((n + (n - 3)) / 2 - rows))
                    {
                        Console.Write("*");
                    }
                    else if (position < ((n + (n - 3)) / 2 + rows) & position > ((n + (n - 3)) / 2 - rows))
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
            for (int rows = 0; rows < 1; rows++)
            {
                for (int position = 0; position < n + (n - 3); position++)
                {
                    if (position == (n + (n - 3)) / 2)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
