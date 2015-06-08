using System;


class PrintIndexOfLettersInWord
{
    static void Main(string[] args)
    {
        //Write a program that creates an array containing all letters from the alphabet (A-Z). Read a word from the console and print the index of each of its letters in the array.
        char[] alphabet = new char[26];
        for (int i = 0; i < alphabet.Length; i++)
		{
            alphabet[i] = (char)('A' + i);
		}
        Console.WriteLine("Enter word:");
        string word = Console.ReadLine();
        word = word.ToUpperInvariant();
        for (int i = 0; i < word.Length; i++)
        {
            int index = -1;
            for (int k = 0; k < alphabet.Length; k++)
            {
                if (alphabet[k] == word[i])
                {
                    index = k;
                    break;
                }
            }
            if (index == -1)
            {
                Console.WriteLine("You have entered an invalid word");
                break;
            }
            else
            {
                Console.Write(index + " ");
            }
        }
    }
}

