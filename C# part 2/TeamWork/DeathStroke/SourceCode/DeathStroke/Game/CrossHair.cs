using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class CrossHair
    {
        public int positionX { get; private set; }
        public int positionY { get; private set; }
        //Two dimentional array..
        private static char[,] crossHairShape=  { { ' ', ' ', '^', ' ', ' '} ,
                                                 { '(', ' ', '+', ' ', ')'} ,
                                                 { ' ', ' ', '_', ' ', ' '} };

        public CrossHair()
        {
            this.positionX = Console.WindowWidth / 2;
            this.positionY = Console.WindowHeight / 2;
        }

        public void MoveLeft()
        {
            this.positionX--;
            if (positionX < 3)
            {
                positionX = 3;
            }
        }

        public void MoveRight()
        {
            this.positionX++;
            if (positionX > Console.WindowWidth - 4)
            {
                positionX = Console.WindowWidth - 4;
            }
        }

        public void MoveUp()
        {
            this.positionY--;
            if (positionY < 1)
            {
                positionY = 1;
            }
        }

        public void MoveDown()
        {
            this.positionY++;
            if (positionY > Console.WindowHeight - 4)
            {
                positionY = Console.WindowHeight - 4;
            }
        }

        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.White;
            int startX = this.positionX - 2;
            int startY = this.positionY - 1;
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    if (crossHairShape[row,col] == ' ')
                    {
                        continue;
                    }
                    Console.SetCursorPosition(startX + col, startY + row);
                    Console.Write(crossHairShape[row,col]);
                }
            }
        }
    }
}
