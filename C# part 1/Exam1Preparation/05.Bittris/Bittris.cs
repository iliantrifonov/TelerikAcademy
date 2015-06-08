using System;

class Bittris
{
    static void Main()
    {
        int score = 0;
        int[] lines = new int[4];
        int N = int.Parse(Console.ReadLine());

        for (int counter = 0; counter < N / 4; counter++)
        {
            int number = int.Parse(Console.ReadLine());
            int shapeOnes = 0;
            int temp = number;
            while (temp != 0)
            {
                if ((temp & 1) == 1) 
                { 
                    shapeOnes++; 
                }
                temp >>= 1;
            }

            string[] directions = new string[3];

            for (int i = 0; i < 3; i++)
            {
                directions[i] = Console.ReadLine();
            }

            number = number & 255; //get the first 8 bits  

            if (lines[0] != 0)  //check if the first line is empty
            {
                score += shapeOnes;
                continue;
            }

            bool isPlaced = false;

            for (int i = 0; !isPlaced && i < 3; i++)
            {

                if (directions[i] == "R")
                {
                    temp = (number >> 1);
                    if (((temp << 1) & 255) == number) //no lost ones  
                    {
                        number = temp;
                    }

                }
                else if (directions[i] == "L")
                {
                    temp = (number << 1) & 255;
                    if ((temp >> 1) == number) //no lost ones  
                    {
                        number = temp;
                    }
                }

                if ((number & lines[i + 1]) != 0) //met obstacle
                {
                    lines[i] = number | lines[i];
                    isPlaced = true;
                }
                else if (i + 1 == 3) // reached last line
                {
                    i++;
                    lines[i] = lines[i] | number;
                    isPlaced = true;
                }

                if (isPlaced)
                {
                    if ((lines[i] | number) == 255) //emptify the line and shift the ones above it
                    {
                        score += shapeOnes * 10;
                        lines[i] = 0;
                        for (int j = i - 1; j > 0; j--)
                        {
                            lines[j + 1] = lines[j];
                        }
                        lines[0] = 0;
                    }
                    else
                    {
                        score += shapeOnes;
                    }
                    break;
                }
            }
        }

        Console.WriteLine(score);

    }
}

