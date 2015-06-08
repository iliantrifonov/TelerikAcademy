using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Lines
{
    class Lines
    {
        static void Main(string[] args)
        {
            byte[,] array = new byte[8, 8];
            for (int i = 0; i < 8; i++)
            {
                byte num = byte.Parse(Console.ReadLine());
                for (int k = 0; k < 8; k++)
                {
                    if (((num >> k) & 1) == 1 )
                    {
                        array[i, k] = 1;
                    }
                }
            }
            
            int maxCount = 0;
            int timesMax = 0;
            for (int i = 0; i < 8; i++)
            {
                int count = 0;
                for (int k = 0; k < 8; k++)
                {
                    if (array[i, k] == 1)
                    {
                        count++;
                    }
                    else
                    {
                        if (maxCount < count)
                        {
                            maxCount = count;
                            timesMax = 1;
                        }
                        else if (maxCount == count)
                        {
                            timesMax++;
                        }
                        count = 0;
                    }
                }
                if (maxCount < count)
                {
                    maxCount = count;
                    timesMax = 1;
                }
                else if (maxCount == count)
                {
                    timesMax++;
                }
                count = 0;
            }
            //vertical
            for (int i = 0; i < 8; i++)
            {
                int count = 0;
                for (int k = 0; k < 8; k++)
                {
                    if (array[k, i] == 1)
                    {
                        count++;
                    }
                    else
                    {
                        if (maxCount < count)
                        {
                            maxCount = count;
                            timesMax = 1;
                        }
                        else if (maxCount == count)
                        {
                            if (maxCount == 1)
                            {
                                
                            }
                            else
                            {
                                timesMax++;
                            }
                        }
                        count = 0;
                    }
                }
                if (maxCount < count)
                {
                    maxCount = count;
                    timesMax = 1;
                }
                else if (maxCount == count)
                {
                    if (maxCount == 1)
                    {

                    }
                    else
                    {
                        timesMax++;
                    }
                }
                count = 0;
            }
            Console.WriteLine(maxCount);
            Console.WriteLine(timesMax);
        }
    }
}
