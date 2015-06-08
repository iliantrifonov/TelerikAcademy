//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace _03.Tron3D
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string coords = Console.ReadLine();
//            string[] splitCoords = coords.Split(' ');
//            int row = int.Parse(splitCoords[0]);
//            int col = int.Parse(splitCoords[1]);
//            int depth = int.Parse(splitCoords[2]);
//            string movementStringRed = Console.ReadLine();
//            string movementStringBlue = Console.ReadLine();
//            int[,,] cubeArr = new int[row + 1, col + 1, depth + 1];
//            for (int column = 1; column < cubeArr.GetLength(1) - 1; column++)
//            {
//                for (int deep = 1; deep < cubeArr.GetLength(2) - 1; deep++)
//                {
//                    cubeArr[0, column, deep] = 5;
//                    cubeArr[cubeArr.GetLength(0) - 1, column, deep] = 5;
//                }
//            }
//            Player red = new Player(cubeArr.GetLength(0) / 2, cubeArr.GetLength(1) / 2, 0);
//            Player blue = new Player(cubeArr.GetLength(0) / 2, cubeArr.GetLength(1) / 2, cubeArr.GetLength(2) - 1);

//            bool blueCrash = false;
//            bool redCrash = false;
//            int indexRed = 0;
//            int indexBlue = 0;

//            while (true)
//            {
//                try
//                {
//                    while (CanTurnWillMove(ref red, movementStringRed[indexRed], cubeArr))
//                    {
//                        indexRed++;
//                    }
//                }
//                catch (MulticastNotSupportedException)
//                {
//                    redCrash = true;
//                }
//                try
//                {
//                    while (CanTurnWillMove(ref blue, movementStringRed[indexBlue], cubeArr))
//                    {
//                        indexBlue++;
//                    }
//                }
//                catch (MulticastNotSupportedException)
//                {
//                    blueCrash = true;
//                    if (red.row == blue.row && red.col == blue.col && red.depth == blue.depth)
//                    {
//                        redCrash = true;
//                    }
//                }
//                if (redCrash == true && blueCrash == true)
//                {
//                    Console.WriteLine("DRAW");
//                    int lengthViaRow = Math.Abs((cubeArr.GetLength(0) / 2) - red.row);
//                    int lenghtViaCol = Math.Abs((cubeArr.GetLength(1) / 2) - red.col);
//                    int result = lengthViaRow + lenghtViaCol + red.depth;
//                    Console.WriteLine(result);
//                    return;
//                }
//                else if (redCrash == true)
//                {
//                    Console.WriteLine("BLUE");
//                    int lengthViaRow = Math.Abs((cubeArr.GetLength(0) / 2) - red.row);
//                    int lenghtViaCol = Math.Abs((cubeArr.GetLength(1) / 2) - red.col);
//                    int result = lengthViaRow + lenghtViaCol + red.depth;
//                    Console.WriteLine(result);
//                    return;
//                }
//                else if (blueCrash == true)
//                {
//                    Console.WriteLine("RED");
//                    int lengthViaRow = Math.Abs((cubeArr.GetLength(0) / 2) - red.row);
//                    int lenghtViaCol = Math.Abs((cubeArr.GetLength(1) / 2) - red.col);
//                    int result = lengthViaRow + lenghtViaCol + red.depth;
//                    Console.WriteLine(result);
//                    return;
//                }
//                indexRed++;
//                indexBlue++;
//            }
//        }

//        public static bool CanTurnWillMove(ref Player player,char moveOrTurn, int[,,] cubeArr)
//        {
//            if (moveOrTurn == 'M')
//            {
//                if (IsOnTurn(ref player, cubeArr))
//                {

//                }
//                if (IsGameOver(ref player, cubeArr))
//                {
//                    throw new MulticastNotSupportedException();
//                }
//                player.row += player.directionRow;
//                player.col += player.directionCol;
//                player.depth += player.directionDepth;
//                cubeArr[player.row, player.col, player.depth] = 3;
//                return false;
//            }
//            else if (moveOrTurn == 'L')
//            {
//                if (player.directionCol == 1)
//                {
//                    player.directionCol = 0;
//                    player.directionRow = -1;
//                }
//                else if (player.directionCol == -1)
//                {
//                    player.directionCol = 0;
//                    player.directionRow = 1;
//                }
//                else if (player.directionRow == 1)
//                {
//                    player.directionRow = 0;
//                    player.directionCol = 1;
//                }
//                else if (player.directionRow == -1)
//                {
//                    player.directionRow = 0;
//                    player.directionCol = -1;
//                }
//                else if (player.directionDepth == 1)
//                {
//                    player.directionDepth = 0;
//                    player.directionRow = -1;
//                }
//                else if (player.directionDepth == -1)
//                {
//                    player.directionDepth = 0;
//                    player.directionRow = 1;
//                }
//                return true;
//            }
//            else if (moveOrTurn == 'R')
//            {
//                if (player.directionCol == 1)
//                {
//                    player.directionCol = 0;
//                    player.directionRow = 1;
//                }
//                else if (player.directionCol == -1)
//                {
//                    player.directionCol = 0;
//                    player.directionRow = -1;
//                }
//                else if (player.directionRow == 1)
//                {
//                    player.directionRow = 0;
//                    player.directionCol = -1;
//                }
//                else if (player.directionRow == -1)
//                {
//                    player.directionRow = 0;
//                    player.directionCol = 1;
//                }
//                else if (player.directionDepth == 1)
//                {
//                    player.directionDepth = 0;
//                    player.directionRow = 1;
//                }
//                else if (player.directionDepth == -1)
//                {
//                    player.directionDepth = 0;
//                    player.directionRow = -1;
//                }
//                return true;
//            }
//            return true;
//        }

//        public static bool IsGameOver(ref Player player, int[, ,] cubicArr)
//        {
//            int futureRow = player.row + player.directionRow;
//            int futureCol = player.col + player.directionCol;
//            int futureDepth = player.depth + player.directionDepth;
//            if (futureRow > cubicArr.GetLength(0) - 1 || futureRow < 0)
//            {
//                player.row += player.directionRow;
//                player.col += player.directionCol;
//                player.depth += player.directionDepth;
//                return true;
//            }
//            if (cubicArr[futureRow,futureCol,futureDepth] > 0)
//            {
//                player.row += player.directionRow;
//                player.col += player.directionCol;
//                player.depth += player.directionDepth;
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }

//        public static bool IsOnTurn(ref Player player, int[, ,] cubicArray)
//        {
//            if (player.col == 0 && player.directionCol == -1)
//            {
//                player.directionCol = 0;
//                if (player.depth == 0)
//                {
//                    player.directionDepth = 1;
//                }
//                else if (player.depth == cubicArray.GetLength(2) - 1)
//                {
//                    player.directionDepth = -1;
//                }
//                return true;
//            }
//            else if (player.col == cubicArray.GetLength(1) - 1 && player.directionCol == 1)
//            {
//                player.directionCol = 0;
//                if (player.depth == 0)
//                {
//                    player.directionDepth = 1;
//                }
//                else if (player.depth == cubicArray.GetLength(2) - 1)
//                {
//                    player.directionDepth = -1;
//                }
//                return true;
//            }
//            else if (player.depth == 0 && player.directionDepth == - 1)
//            {
//                player.directionDepth = 0;
//                if (player.col == 0)
//                {
//                    player.directionCol = 1;
//                }
//                else if (player.col == cubicArray.GetLength(1) - 1)
//                {
//                    player.directionCol = -1;
//                }
//                return true;
//            }
//            else if (player.depth == cubicArray.GetLength(2) - 1 && player.directionDepth == 1)
//            {
//                player.directionDepth = 0;
//                if (player.col == 0)
//                {
//                    player.directionCol = 1;
//                }
//                else if (player.col == cubicArray.GetLength(1) - 1)
//                {
//                    player.directionCol = -1;
//                }
//                return true;
//            }
//            return false;
//        }
//    }

//    class Player
//    {
//        public int row;
//        public int col;
//        public int depth;
//        public int directionRow = 0;
//        public int directionCol = 1;
//        public int directionDepth = 0;

//        public Player(int row, int col, int depth)
//        {
//            this.row = row;
//            this.col = col;
//            this.depth = depth;
//        }
//    }
//}
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // read input
        int[] xyz = Console.ReadLine().Split(' ')
            .Select(int.Parse).ToArray();

        int x = xyz[0], y = xyz[1], z = xyz[2];

        string[] commands = { Console.ReadLine(), Console.ReadLine() };

        // prepare variables 

        // H, V
        int[] dims = { 2 * y + 2 * z, x + 1 };
        bool[,] visited = new bool[dims[0], dims[1]];

        // red player / blue player
        int[] direction = { 0, 2 };
        int[] directionH = { 1, 0, -1, 0 };
        int[] directionV = { 0, 1, 0, -1 };
        int[,] position = { { y / 2, x / 2 }, { y + z + y / 2, x / 2 } };
        // did player go on forbidden walls?
        bool[] outside = { false, false };

        // index into the 'commands' strings we read from the console
        int[] commandIndex = { 0, 0 };

        // algorithm

        // for every game cycle
        while (true)
        {
            // for both players
            for (int player = 0; player <= 1; player += 1)
            {
                visited[position[player, 0], position[player, 1]] = true;

                // read next command from player's string
                char cmd = commands[player][commandIndex[player]];
                commandIndex[player] += 1;

                // turn?
                if (cmd == 'L' || cmd == 'R')
                {
                    // adjust direction index
                    direction[player] += (cmd == 'L') ? 1 : 3;
                    direction[player] %= 4;
                    // read more commands for same player
                    player -= 1;
                    continue;
                }
                else
                {
                    int newH = position[player, 0] + directionH[direction[player]];
                    int newV = position[player, 1] + directionV[direction[player]];

                    // went on forbidden wall
                    if (newV < 0 || newV >= dims[1])
                    {
                        outside[player] = true;
                        continue;
                    }

                    // went above top or below bottom?
                    if (newH < 0 || newH >= dims[0])
                    {
                        // loop over to other side
                        newH += dims[0]; newH %= dims[0];
                    }

                    position[player, 0] = newH;
                    position[player, 1] = newV;
                }
            }

            // after each game cycle
            // check if anyone died

            // crashed head to head?
            bool headOnCollision = position[0, 0] == position[1, 0] &&
                                   position[0, 1] == position[1, 1];

            bool redDied = visited[position[0, 0], position[0, 1]] || headOnCollision || outside[0];
            bool blueDied = visited[position[1, 0], position[1, 1]] || headOnCollision || outside[1];

            if (redDied || blueDied)
            {
                if (redDied && blueDied) Console.WriteLine("DRAW");
                else if (redDied) Console.WriteLine("BLUE");
                else if (blueDied) Console.WriteLine("RED");
                // we can ask them for 3D distance or just 2D manhattan distance along the surface of the cube
                Console.WriteLine(GetDistanceFromStart(position[0, 0], position[0, 1], x, y, z));
                return;
            }
        }
    }

    static double GetDistanceFromStart(int h, int v, int x, int y, int z)
    {
        // use symmetry
        if (h > z + y + y / 2)
            h = 2 * z + y - h;

        return Math.Abs(h - y / 2) + Math.Abs(v - x / 2);
    }
}
