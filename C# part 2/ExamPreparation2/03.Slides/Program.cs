using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Slides
{
    class Program
    {
        private static string[, ,] cubeArr;
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] arrSize = input.Split(' ');
            int width = int.Parse(arrSize[0]);
            int height = int.Parse(arrSize[1]);
            int depth = int.Parse(arrSize[2]);
            cubeArr = new string[height, width, depth];
            for (int h = 0; h < height; h++)
            {
                Queue<string> que = ConvertStringToQueue(Console.ReadLine());
                for (int d = 0; d < depth; d++)
                {
                    for (int w = 0; w < width; w++)
                    {
                        cubeArr[h, w, d] = que.Dequeue();
                    }
                }
            }
            input = Console.ReadLine();
            string[] ballPosition = input.Split(' ');
            int ballW = int.Parse(ballPosition[0]);
            int ballD = int.Parse(ballPosition[1]);
            int ballH = 0;
            Ball ball = new Ball(ballH, ballW, ballD);

            while (true)
            {
                string command = cubeArr[ball.height, ball.width, ball.depth];
                if (command[0] == 'S')
                {
                    ball = Slide(command, ball);
                }
                else if (command == "B")
                {
                    PrintResult(ball, command);
                }
                else if (command[0] == 'T')
                {
                    Teleport(command, ball);
                }
                else if (command == "E")
                {
                    if (ball.height >= cubeArr.GetLength(0) - 1)
                    {
                        PrintResult(ball, command);
                    }
                    ball.height++;
                }
            }
        }

        private static Ball Teleport(string command, Ball cubeBall)
        {
            string[] splitCommands = command.Split();
            int moveW = int.Parse(splitCommands[1]);
            int moveD = int.Parse(splitCommands[2]);
            Ball newBall = new Ball(cubeBall.height, cubeBall.width, cubeBall.depth);
            cubeBall.width = moveW;
            cubeBall.depth = moveD;
            if (IsInsideArray(cubeBall))
            {
                return cubeBall;
            }
            else
            {
                PrintResult(newBall, command);
                return newBall;
            }
        }

        private static Ball Slide(string command, Ball cubeBall)
        {
            Ball newBall = new Ball(cubeBall.height, cubeBall.width, cubeBall.depth);
            if (command == "S L")
            {
                cubeBall.width--;
                cubeBall.height++;
            }
            else if (command == "S R")
            {
                cubeBall.width++;
                cubeBall.height++;
            }
            else if (command == "S B")
            {
                cubeBall.depth++;
                cubeBall.height++;
            }
            else if (command == "S F")
            {
                cubeBall.depth--;
                cubeBall.height++;
            }
            else if (command == "S FL")
            {
                cubeBall.depth--;
                cubeBall.width--;
                cubeBall.height++;
            }
            else if (command == "S FR")
            {
                cubeBall.depth--;
                cubeBall.width++;
                cubeBall.height++;
            }
            else if (command == "S BR")
            {
                cubeBall.depth++;
                cubeBall.width++;
                cubeBall.height++;
            }
            else if (command == "S BL")
            {
                cubeBall.depth++;
                cubeBall.width--;
                cubeBall.height++;
            }
            if (IsInsideArray(cubeBall))
            {
                return cubeBall;
            }
            else
            {
                PrintResult(newBall, command);
                return newBall;
            }
        }

        private static void PrintResult(Ball a, string command)
        {
            if (command == "B" || a.height != cubeArr.GetLength(0) - 1)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine("Yes");
            }
            Console.WriteLine("{0} {1} {2}", a.width, a.height, a.depth);
            Environment.Exit(0);
        }

        private static bool IsInsideArray(Ball cubeBall)
        {
            try
            {
                if (cubeArr[cubeBall.height,cubeBall.width,cubeBall.depth] == " ")
                {
                    
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private static Queue<string> ConvertStringToQueue(string numbersString)
        {
            string[] arrayOfHeight = numbersString.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            Queue<string> que = new Queue<string>();
            for (int i = 0; i < arrayOfHeight.Length; i++)
            {
                string[] arrayOfWidth = arrayOfHeight[i].Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                for (int zi = 0; zi < arrayOfWidth.Length; zi++)
                {
                    if (arrayOfWidth[zi] == " " || arrayOfWidth[zi] == "  ")
                    {
                        
                    }
                    else
                    {
                        que.Enqueue(arrayOfWidth[zi]);
                    }
                }
            }
            return que;
        }

        class Ball
        {
            public int height;
            public int width;
            public int depth;

            public Ball(int height, int width, int depth)
            {
                this.height = height;
                this.width = width;
                this.depth = depth;
            }

            private void MoveTo(int coordHeight, int coordWidth, int coordDepth)
            {
                this.height = coordHeight;
                this.width = coordWidth;
                this.depth = coordDepth;
            }
        }
    }
}
