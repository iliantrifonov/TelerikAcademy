
using System.Numerics;
using System;

class AstrologicalDigits
{
    static void Main()
    {
        string number = Console.ReadLine();
        byte[] array = new byte[number.Length];
        for (int i = 0; i < number.Length; i++)
        {
            switch (number[i])
            {
                case '1':
                    array[i] = 1;
                    break;
                case '2':
                    array[i] = 2;
                    break;
                case '3':
                    array[i] = 3;
                    break;
                case '4':
                    array[i] = 4;
                    break;
                case '5':
                    array[i] = 5;
                    break;
                case '6':
                    array[i] = 6;
                    break;
                case '7':
                    array[i] = 7;
                    break;
                case '8':
                    array[i] = 8;
                    break;
                case '9':
                    array[i] = 9;
                    break;
                default:
                    break;
            }
        }
        BigInteger num = 0;

        for (int i = 0; i < array.Length; i++)
		{
			num += array[i];
		}
        while (num > 9)
	    {
            BigInteger tempNum = num;
            num =0;
            while (tempNum > 0)
            {
                num += (tempNum % 10);
                tempNum /= 10;
            }
	    }
        Console.WriteLine(num);
    }
}

