using System;
using System.Collections.Generic;
using System.Text;

namespace SpecialValue
{
    class MainClass
    {
        public static short maxLenght;
        public static void Main(string[] args)
        {
            short numberOfRows = short.Parse(Console.ReadLine());
            short[][] listMatrix = new short[numberOfRows][];
            for (short i = 0; i < numberOfRows; i++)
            {
                listMatrix[i] = GetInputRow(Console.ReadLine());
            }
            GetMaxLenght(listMatrix);
            short specialMaxNum = 0;
            for (short i = 0; i < listMatrix[0].Length; i++)
            {
                short result = GetPath(listMatrix, i);
                if (result > specialMaxNum)
                {
                    specialMaxNum = result;
                }
            }
            Console.WriteLine(specialMaxNum);
        }

        public static void GetMaxLenght(short[][] listMatrix)
        {
            maxLenght = 0;
            for (short i = 0; i < listMatrix.Length; i++)
            {
                if (listMatrix[i].Length > maxLenght)
                {
                    maxLenght = (short)listMatrix[i].Length;
                }
            }
        }

        public static short GetPath(short[][] listMatrix, short index)
        {
            //bool[,] arrBool = new bool[listMatrix.Length, maxLenght];
            short row = 0;
            short col = index;
            short count = 1;
            while (listMatrix[row][col] >= 0)
            {
                //if (arrBool[row, col] == true)
                //{
                //    return 0;
                //}
                //arrBool[row, col] = true;
                col = listMatrix[row][col];
                row++;
                if (row >= listMatrix.Length)
                {
                    row -= (short)listMatrix.Length;
                }
                count++;
            }
            short result = (short)(count + Math.Abs(listMatrix[row][col]));
            return result;
        }

        public static short[] GetInputRow(string a)
        {
            string[] arrSplit = a.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            short[] numArr = new short[arrSplit.Length];
            for (short i = 0; i < arrSplit.Length; i++)
            {
                numArr[i] = short.Parse(arrSplit[i]);
            }
            return numArr;
        }
    }
}
