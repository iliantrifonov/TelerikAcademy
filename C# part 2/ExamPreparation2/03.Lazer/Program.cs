using System;

namespace Lazers
{
    class MainClass
    {
        public static Lazer lazer;

        public static void Main(string[] args)
        {
            int[] arrSize = GetInput(Console.ReadLine());
            int arrWidth = arrSize[0];
            int arrHeight = arrSize[1];
            int arrDepth = arrSize[2];

            int[] laserPos = GetInput(Console.ReadLine());
            int laserWidth = laserPos[0] - 1;
            int laserHeight = laserPos[1] - 1;
            int laserDepth = laserPos[2] - 1;

            int[] direction = GetInput(Console.ReadLine());
            int dirWidth = direction[0];
            int dirHeight = direction[1];
            int dirDepth = direction[2];
            bool[, ,] cubeArr = new bool[arrHeight, arrWidth, arrDepth];
            for (int i = 0; i < cubeArr.GetLength(0); i++)
            {
                cubeArr[i, 0, 0] = true;
                cubeArr[i, 0, cubeArr.GetLength(2) - 1] = true;
                cubeArr[i, cubeArr.GetLength(1) - 1, cubeArr.GetLength(2) - 1] = true;
                cubeArr[i, cubeArr.GetLength(1) - 1, 0] = true;
            }
            for (int i = 0; i < cubeArr.GetLength(1); i++)
            {
                cubeArr[0, i, 0] = true;
                cubeArr[0, i, cubeArr.GetLength(2) - 1] = true;
                cubeArr[cubeArr.GetLength(0) - 1, i, cubeArr.GetLength(2) - 1] = true;
                cubeArr[cubeArr.GetLength(0) - 1, i, 0] = true;

            }
            for (int i = 0; i < cubeArr.GetLength(2); i++)
            {
                cubeArr[0, 0, i] = true;
                cubeArr[0, cubeArr.GetLength(1) - 1, i] = true;
                cubeArr[cubeArr.GetLength(0) - 1, cubeArr.GetLength(1) - 1, i] = true;
                cubeArr[cubeArr.GetLength(0) - 1, 0, i] = true;

            }
            lazer = new Lazer(laserHeight, laserWidth, laserDepth, dirHeight, dirWidth, dirDepth);
            while (true)
            {
                Move(lazer, cubeArr);
            }
        }

        public static void Move(Lazer a, bool[, ,] cubeArr)
        {
            Lazer copyLazer = new Lazer(a);
            copyLazer.height += copyLazer.directionHeight;
            copyLazer.width += copyLazer.directionWidth;
            copyLazer.depth += copyLazer.directionDepth;
            try
            {
                if (cubeArr[copyLazer.height, copyLazer.width, copyLazer.depth] == true)
                {
                    Console.WriteLine("{0} {1} {2}", lazer.width + 1, lazer.height + 1, lazer.depth + 1);
                    Environment.Exit(0);
                }
                cubeArr[copyLazer.height, copyLazer.width, copyLazer.depth] = true;
                lazer = new Lazer(copyLazer);
            }
            catch (IndexOutOfRangeException)
            {
                ChangeDirection(copyLazer, cubeArr);
                Move(lazer, cubeArr);
            }
        }

        public static void ChangeDirection(Lazer a, bool[, ,] cubeArr)
        {
            if (a.height >= cubeArr.GetLength(0) || a.height < 0)
            {
                lazer.directionHeight *= -1;
            }
            else if (a.width >= cubeArr.GetLength(1) || a.width < 0)
            {
                lazer.directionWidth *= -1;
            }
            else if (a.depth >= cubeArr.GetLength(2) || a.depth < 0)
            {
                lazer.directionDepth *= -1;
            }
        }

        public static int[] GetInput(string input)
        {
            string[] a = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] result = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                result[i] = int.Parse(a[i]);
            }
            return result;
        }
    }
    public class Lazer
    {
        public int height;
        public int width;
        public int depth;

        public int directionHeight;
        public int directionWidth;
        public int directionDepth;

        public Lazer(int height, int width, int depth, int directionHeight, int directionWidth, int directionDepth)
        {
            this.height = height;
            this.width = width;
            this.depth = depth;
            this.directionHeight = directionHeight;
            this.directionWidth = directionWidth;
            this.directionDepth = directionDepth;
        }
        public Lazer(Lazer a)
        {
            this.height = a.height;
            this.width = a.width;
            this.depth = a.depth;
            this.directionHeight = a.directionHeight;
            this.directionWidth = a.directionWidth;
            this.directionDepth = a.directionDepth;
        }
    }
}
