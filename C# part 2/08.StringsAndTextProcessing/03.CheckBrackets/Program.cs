using System;

namespace _03.CheckBrackets
{
    //Write a program to check if in a given expression the brackets are put correctly.
    //Example of correct expression: ((a+b)/5-d).
    //Example of incorrect expression: )(a+b)).

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter expression: ");
            string expression = Console.ReadLine();
            if (CheckBrackets(expression))
            {
                Console.WriteLine("The brackets are in the correct way");
            }
            else
            {
                Console.WriteLine("The brackets aren't in the correct way");
            }
        }

        private static bool CheckBrackets(string expression)
        {
            char[] splitExpression = expression.ToCharArray();
            int amountOfOpenBrackets = 0;
            int closedBrackets = 0;
            for (int i = 0; i < splitExpression.Length; i++)
            {
                if (splitExpression[i] == '(')
                {
                    amountOfOpenBrackets++;
                }
                else if (splitExpression[i] == ')')
                {
                    closedBrackets++;
                }
                if (amountOfOpenBrackets - closedBrackets < 0)
                {
                    return false;
                }
            }
            if (amountOfOpenBrackets - closedBrackets != 0)
            {
                return false;
            }
            return true;
        }
    }
}
